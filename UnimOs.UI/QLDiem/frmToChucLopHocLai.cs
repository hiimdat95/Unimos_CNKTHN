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
    public partial class frmToChucLopHocLai : frmBase
    {
        private int status;
        private cBKQHT_LopHocLai oBKQHT_LopHocLai;
        private KQHT_LopHocLaiInfo pKQHT_LopHocLaiInfo;
        private cBXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private DataTable dtLop;
        private DataRow drLop;
        public int DM_MonHocID;

        public frmToChucLopHocLai()
        {
            InitializeComponent();
            pKQHT_LopHocLaiInfo = new KQHT_LopHocLaiInfo();
            oBKQHT_LopHocLai = new cBKQHT_LopHocLai();
            oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();

            txtHocKy.Text = Program.HocKy.ToString();
            txtNamHoc.Text = Program.NamHoc;
            DM_MonHocID = 0;
        }
        private void frmToChucLopHocLai_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            bar2.Visible = true;
            cmbMonHoc.Properties.DataSource = oBXL_MonHocTrongKy.GetMonKy(0,Program.IDNamHoc, Program.HocKy);
            cmbMonHoc.EditValue = DM_MonHocID;
            pKQHT_LopHocLaiInfo.KQHT_LopHocLaiID = 0;
            GetLopHocLai(DM_MonHocID);
        }
        private void GetLopHocLai(int mDM_MonHocID)
        {
            dtLop = oBKQHT_LopHocLai.GetByHocKyNamHoc(mDM_MonHocID, Program.HocKy, Program.IDNamHoc);
            grdLop.DataSource = dtLop;
        }
        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearText();
            txtTenLop.Focus();
            panelTop.Visible = true;
            status = 0;
        }
        private void ClearText()
        {
            txtTenLop.Text = "";          
            cmbGiangVien.EditValue = null;
        }
        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Mã và tên hệ không được rỗng
            if (txtTenLop.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenLop, "Tên lớp không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenLop;
            }
            if (cmbMonHoc.EditValue == null)
            {
                dxErrorProvider.SetError(cmbMonHoc, "Chưa chọn môn học.");
                if (CtrlErr == null) CtrlErr = cmbMonHoc;
            }
            //Kiểm tra cập nhật thành công
            if ((CtrlErr != null))
                return false;
            else
                return true;
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            status = 1;
            panelTop.Visible = true;
            GetInfo();
        }
        private void GetInfo()
        {
            txtTenLop.Text = pKQHT_LopHocLaiInfo.TenLop;
            cmbMonHoc.EditValue = pKQHT_LopHocLaiInfo.IDDM_MonHoc;
            cmbGiangVien.EditValue = pKQHT_LopHocLaiInfo.IDNS_GiaoVien;           
        }

        private void SetInfo()
        {
            pKQHT_LopHocLaiInfo.TenLop = txtTenLop.Text;
            pKQHT_LopHocLaiInfo.IDDM_MonHoc = int.Parse(cmbMonHoc.EditValue.ToString());
            pKQHT_LopHocLaiInfo.IDNS_GiaoVien = cmbGiangVien.EditValue== null?0:int.Parse(cmbGiangVien.EditValue.ToString());
            pKQHT_LopHocLaiInfo.HocKy = Program.HocKy;
            pKQHT_LopHocLaiInfo.IDDM_NamHoc = Program.IDNamHoc;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!Check_Valid()) return;
            try
            {
                SetInfo();
                if (status == 0)
                {
                    oBKQHT_LopHocLai.Add(pKQHT_LopHocLaiInfo);
                    ThemThanhCong();
                    GetLopHocLai(DM_MonHocID);
                }
                else
                {
                    oBKQHT_LopHocLai.Update(pKQHT_LopHocLaiInfo);
                    SuaThanhCong();
                    GetLopHocLai(DM_MonHocID);
                }
                ClearText();
                cmbGiangVien.EditValue = null;
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

        private void grvLop_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvLop.FocusedRowHandle >= 0)
            {
                drLop = grvLop.GetDataRow(grvLop.FocusedRowHandle);
                oBKQHT_LopHocLai.ToInfo(ref pKQHT_LopHocLaiInfo, drLop);
            }
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    oBKQHT_LopHocLai.Delete(pKQHT_LopHocLaiInfo);
                    XoaThanhCong();
                    GetLopHocLai(DM_MonHocID);
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private void cmbMonHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbMonHoc.EditValue != null)
            {
                DM_MonHocID = int.Parse(cmbMonHoc.EditValue.ToString());
                GetLopHocLai(DM_MonHocID);
            }
            else
                GetLopHocLai(0);
        }

        private void cmbMonHoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbMonHoc.EditValue = null;
        }
    }
}