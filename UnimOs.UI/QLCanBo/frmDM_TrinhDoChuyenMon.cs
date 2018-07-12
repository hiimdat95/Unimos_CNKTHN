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
    public partial class frmDM_TrinhDoChuyenMon : frmBase
    {
        private cBDM_TrinhDoChuyenMon oBDM_TrinhDoChuyenMon;
        private DM_TrinhDoChuyenMonInfo pDM_TrinhDoChuyenMonInfo;
        private DataTable dtTrinhDoChuyenMon;
        private DataRow drTrinhDoChuyenMon;
        private EDIT_MODE edit;
        public frmHoSoGiaoVien ofrmHoSoGiaoVien;

        public frmDM_TrinhDoChuyenMon(frmHoSoGiaoVien _frmHoSoGiaoVien)
        {
            InitializeComponent();
            oBDM_TrinhDoChuyenMon = new cBDM_TrinhDoChuyenMon();
            pDM_TrinhDoChuyenMonInfo = new DM_TrinhDoChuyenMonInfo();
            SetControl(false);
            ofrmHoSoGiaoVien = _frmHoSoGiaoVien;
        }

        private void frmDM_TrinhDoChuyenMon_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetTrinhDoChuyenMon();
            LoadNhomTrinhDo();
        }

        private void GetTrinhDoChuyenMon()
        {
            pDM_TrinhDoChuyenMonInfo.DM_TrinhDoChuyenMonID = 0;
            dtTrinhDoChuyenMon = oBDM_TrinhDoChuyenMon.Get(pDM_TrinhDoChuyenMonInfo);
            trlTrinhDoChuyenMon.DataSource = dtTrinhDoChuyenMon;
            trlTrinhDoChuyenMon.ExpandAll();
        }

        private void LoadNhomTrinhDo()
        {
            DataView dv = new DataView(dtTrinhDoChuyenMon);
            dv.RowFilter = "ParentID = 0";
            cmbNhomTrinhDo.Properties.DataSource = dv;
        }

        private void grvTrinhDoChuyenMon_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void cmbNhomTrinhDo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbNhomTrinhDo.ClosePopup();
                cmbNhomTrinhDo.EditValue = 0;
            }
        }

        private void ClearText()
        {
            txtTenTrinhDoChuyenMon.Text = "";
            txtTenTrinhDoChuyenMon.Focus();
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtTenTrinhDoChuyenMon.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenTrinhDoChuyenMon, "Tên trình độ chuyên môn không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenTrinhDoChuyenMon;
            }
           
            //Kiểm tra cập nhật thành công
            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            else
                return true;
        }

        private void SetText()
        {
            cmbNhomTrinhDo.EditValue = pDM_TrinhDoChuyenMonInfo.ParentID;
            txtTenTrinhDoChuyenMon.Text = pDM_TrinhDoChuyenMonInfo.TenTrinhDoChuyenMon;
            txtTenTrinhDoChuyenMon.Focus();
        }

        private void GetpInfo()
        {
            pDM_TrinhDoChuyenMonInfo.ParentID = cmbNhomTrinhDo.EditValue == null ? 0 : int.Parse(cmbNhomTrinhDo.EditValue.ToString());
            pDM_TrinhDoChuyenMonInfo.TenTrinhDoChuyenMon = txtTenTrinhDoChuyenMon.Text;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            trlTrinhDoChuyenMon.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            trlTrinhDoChuyenMon.Enabled = false;
            edit = EDIT_MODE.SUA;
            panelTop.Visible = true;
            SetText();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    pDM_TrinhDoChuyenMonInfo.DM_TrinhDoChuyenMonID = int.Parse(drTrinhDoChuyenMon[pDM_TrinhDoChuyenMonInfo.strDM_TrinhDoChuyenMonID].ToString());
                    oBDM_TrinhDoChuyenMon.Delete(pDM_TrinhDoChuyenMonInfo);
                    // ghi log
                    GhiLog("Xóa trình độ chuyên môn '" + pDM_TrinhDoChuyenMonInfo.TenTrinhDoChuyenMon + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtTrinhDoChuyenMon.Rows.Remove(drTrinhDoChuyenMon);
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
            if (!CheckValid()) return;
            try
            {
                GetpInfo();
                if (edit == EDIT_MODE.THEM)
                {
                    pDM_TrinhDoChuyenMonInfo.DM_TrinhDoChuyenMonID = oBDM_TrinhDoChuyenMon.Add(pDM_TrinhDoChuyenMonInfo);
                    GhiLog("Thêm trình độ chuyên môn '" + pDM_TrinhDoChuyenMonInfo.TenTrinhDoChuyenMon + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtTrinhDoChuyenMon.NewRow();
                    oBDM_TrinhDoChuyenMon.ToDataRow(pDM_TrinhDoChuyenMonInfo, ref drNew);
                    dtTrinhDoChuyenMon.Rows.Add(drNew);
                    if (pDM_TrinhDoChuyenMonInfo.ParentID == 0)
                        LoadNhomTrinhDo();
                    ClearText();
                }
                else
                {
                    pDM_TrinhDoChuyenMonInfo.DM_TrinhDoChuyenMonID = int.Parse(drTrinhDoChuyenMon[pDM_TrinhDoChuyenMonInfo.strDM_TrinhDoChuyenMonID].ToString());
                    oBDM_TrinhDoChuyenMon.Update(pDM_TrinhDoChuyenMonInfo);
                    GhiLog("Sửa trình độ chuyên môn '" + pDM_TrinhDoChuyenMonInfo.TenTrinhDoChuyenMon + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    drTrinhDoChuyenMon[pDM_TrinhDoChuyenMonInfo.strTenTrinhDoChuyenMon] = txtTenTrinhDoChuyenMon.Text;
                    SuaThanhCong();
                    btnHuy_Click(null, null);
                }
            }
            catch
            {
                ThongBaoLoi("Có lỗi trong quá trình thêm hoặc sửa hoặc ghi log.");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            trlTrinhDoChuyenMon.Enabled = true;
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void grvTrinhDoChuyenMon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (trlTrinhDoChuyenMon.FocusedNode != null)
            {
                drTrinhDoChuyenMon = (DataRow)trlTrinhDoChuyenMon.GetDataRecordByNode(trlTrinhDoChuyenMon.FocusedNode);
                oBDM_TrinhDoChuyenMon.ToInfo(ref pDM_TrinhDoChuyenMonInfo, drTrinhDoChuyenMon);
                if (ofrmHoSoGiaoVien != null)
                {
                    ofrmHoSoGiaoVien.IDDM_TrinhDoChuyenMon = int.Parse(drTrinhDoChuyenMon[pDM_TrinhDoChuyenMonInfo.strDM_TrinhDoChuyenMonID].ToString());
                }
                SetControl(true);
                return;
            }
            
            SetControl(false);
            drTrinhDoChuyenMon = null;
        }
    }
}
