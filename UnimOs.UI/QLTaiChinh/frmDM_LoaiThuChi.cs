using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;

namespace UnimOs.UI
{
    public partial class frmDM_LoaiThuChi : frmBase
    {
        private int status = 0;
        private cBTC_LoaiThuChi oBTC_LoaiThuChi;
        private TC_LoaiThuChiInfo pTC_LoaiThuChiInfo;
        private DataTable dtTree;

        public frmDM_LoaiThuChi()
        {
            InitializeComponent();
            pTC_LoaiThuChiInfo = new TC_LoaiThuChiInfo();
            oBTC_LoaiThuChi = new cBTC_LoaiThuChi();
        }

        private void frmTC_LoaiThuChi_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetComboLoaiThuChi();
            GetLoaiThuChi();
        }

        private void GetLoaiThuChi()
        {
            dtTree = oBTC_LoaiThuChi.Get_Tree(Program.IDNamHoc, Program.HocKy);
            trvLoaiThuChi.DataSource = dtTree;
            trvLoaiThuChi.ExpandAll();
        }

        private void GetComboLoaiThuChi()
        {
            DataTable dtTemp = oBTC_LoaiThuChi.GetBy_IDNamHoc_HocKy(Program.IDNamHoc, Program.HocKy, true);
            cmbLoaiThuChiCha.Properties.DataSource = dtTemp;
            if (status == 1)
            {
                trvLoaiThuChi_FocusedNodeChanged(null, null);
                DataView dvTemp = new DataView(dtTemp);
                dvTemp.RowFilter = "TC_LoaiThuChiID <> " + pTC_LoaiThuChiInfo.TC_LoaiThuChiID;
                cmbLoaiThuChiCha.Properties.DataSource = dvTemp;
            }
        }

        private void ClearText()
        {
            txtTenLoaiThuChi.Text = "";
            txtSoTien.Text = "";
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtTenLoaiThuChi.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenLoaiThuChi, "Tên loại thu chi không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenLoaiThuChi;
            }

            //Kiểm tra cập nhật thành công
            if ((CtrlErr != null))
                return false;
            else
                return true;
        }

        private void GetInfo()
        {
            txtTenLoaiThuChi.Text = pTC_LoaiThuChiInfo.TenLoaiThuChi;
            rdThuChi.SelectedIndex  =( pTC_LoaiThuChiInfo.KhoanThu==true?0:1);
            chkBatBuoc.Checked = pTC_LoaiThuChiInfo.BatBuoc;
            chkNienKhoa.Checked = pTC_LoaiThuChiInfo.TheoNienKhoa;
            chkHocPhi.Checked = pTC_LoaiThuChiInfo.HocPhi;
            chkNhapHoc.Checked = pTC_LoaiThuChiInfo.NhapHoc;
            cmbLoaiThuChiCha.EditValue = (pTC_LoaiThuChiInfo.ParentID == 0 ? null : pTC_LoaiThuChiInfo.ParentID.ToString());
            txtSoTien.Text = pTC_LoaiThuChiInfo.SoTien.ToString();
        }

        private void SetInfo()
        {
            pTC_LoaiThuChiInfo.TenLoaiThuChi = txtTenLoaiThuChi.Text;
            pTC_LoaiThuChiInfo.KhoanThu = (rdThuChi.SelectedIndex == 0 ?true  :false);
            pTC_LoaiThuChiInfo.BatBuoc = chkBatBuoc.Checked;
            pTC_LoaiThuChiInfo.TheoNienKhoa= chkNienKhoa.Checked;
            pTC_LoaiThuChiInfo.HocPhi =  chkHocPhi.Checked;
            pTC_LoaiThuChiInfo.NhapHoc=chkNhapHoc.Checked;
            pTC_LoaiThuChiInfo.SoTien = float.Parse("0" + txtSoTien.Text.Trim());
            pTC_LoaiThuChiInfo.ParentID = int.Parse("0" + cmbLoaiThuChiCha.EditValue);
            pTC_LoaiThuChiInfo.IDNamHoc = Program.IDNamHoc;
            pTC_LoaiThuChiInfo.HocKy = Program.HocKy;
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            status = 1;
            panelTop.Visible = true;
            GetComboLoaiThuChi();
            GetInfo();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                trvLoaiThuChi_FocusedNodeChanged(null, null);
                try
                {
                    oBTC_LoaiThuChi.Delete(pTC_LoaiThuChiInfo);
                    GetLoaiThuChi();
                    XoaThanhCong();
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!Check_Valid()) return;
            try
            {
                SetInfo();
                if (status == 0)
                {
                    oBTC_LoaiThuChi.Add(pTC_LoaiThuChiInfo);
                    GetLoaiThuChi();
                    ThemThanhCong();

                }
                else
                {
                    oBTC_LoaiThuChi.Update(pTC_LoaiThuChiInfo);
                    GetLoaiThuChi();
                    panelTop.Visible = false;
                    SuaThanhCong();
                }
                ClearText();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;

        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearText();
            panelTop.Visible = true;
            status = 0;
            GetComboLoaiThuChi();
        }

        private void cmbLoaiThuChiCha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbLoaiThuChiCha.EditValue = null;
        }

        private void trvLoaiThuChi_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (trvLoaiThuChi.Nodes.Count > 0)
            {
                pTC_LoaiThuChiInfo.TC_LoaiThuChiID = int.Parse("0" + trvLoaiThuChi.FocusedNode["TC_LoaiThuChiID"]);
                pTC_LoaiThuChiInfo.TenLoaiThuChi = trvLoaiThuChi.FocusedNode["TenLoaiThuChi"] + "";
                pTC_LoaiThuChiInfo.SoTien = double.Parse("0" + trvLoaiThuChi.FocusedNode["SoTien"]);
                pTC_LoaiThuChiInfo.KhoanThu = bool.Parse(trvLoaiThuChi.FocusedNode["KhoanThu"].ToString());
                pTC_LoaiThuChiInfo.BatBuoc = bool.Parse(trvLoaiThuChi.FocusedNode["BatBuoc"].ToString());
                pTC_LoaiThuChiInfo.TheoNienKhoa = bool.Parse(trvLoaiThuChi.FocusedNode["TheoNienKhoa"].ToString());
                pTC_LoaiThuChiInfo.HocPhi = bool.Parse(trvLoaiThuChi.FocusedNode["HocPhi"].ToString());
                pTC_LoaiThuChiInfo.NhapHoc = bool.Parse(trvLoaiThuChi.FocusedNode["NhapHoc"].ToString());
                pTC_LoaiThuChiInfo.ParentID = int.Parse("0" + trvLoaiThuChi.FocusedNode["ParentID"]);
                pTC_LoaiThuChiInfo.IDNamHoc = int.Parse("0" + trvLoaiThuChi.FocusedNode["IDNamHoc"]);
                pTC_LoaiThuChiInfo.HocKy = int.Parse("0" + trvLoaiThuChi.FocusedNode["HocKy"]);
            }
        }
    }
}