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
    public partial class dlgQDKyLuat : frmBase
    {
        private cBSV_QuyetDinhKyLuat oBSV_QuyetDinhKyLuat;
        private SV_QuyetDinhKyLuatInfo pSV_QuyetDinhKyLuatInfo;
        public DataRow drQuyetDinh;
        private EDIT_MODE edit;

        public dlgQDKyLuat(EDIT_MODE _edit)
        {
            InitializeComponent();
            edit = _edit;
            this.DialogResult = DialogResult.Cancel;
            oBSV_QuyetDinhKyLuat = new cBSV_QuyetDinhKyLuat();
            pSV_QuyetDinhKyLuatInfo = new SV_QuyetDinhKyLuatInfo();
        }

        private void dlgQDKyLuat_Load(object sender, EventArgs e)
        {
            dtpNgayQuyetDinh.EditValue = DateTime.Now;
            txtNamHoc.Text = Program.NamHoc;
            txtHocKy.Text = Program.HocKy.ToString();
            cmbCapKyLuat.Properties.DataSource = LoadCapKhenThuong();
            cmbLoaiKyLuat.Properties.DataSource = LoadHanhVi();
            if (edit == EDIT_MODE.SUA)
            {
                txtSoQuyetDinh.Text = drQuyetDinh[pSV_QuyetDinhKyLuatInfo.strSoQuyetDinh].ToString();
                dtpNgayQuyetDinh.EditValue = drQuyetDinh[pSV_QuyetDinhKyLuatInfo.strNgayQuyetDinh];
                cmbCapKyLuat.EditValue = drQuyetDinh[pSV_QuyetDinhKyLuatInfo.strIDDM_CapKhenThuong];
                cmbLoaiKyLuat.EditValue = drQuyetDinh[pSV_QuyetDinhKyLuatInfo.strIDDM_HanhVi];
                txtNoiDung.Text = "" + drQuyetDinh[pSV_QuyetDinhKyLuatInfo.strNoiDung];
            }
        }

        private void GetpInfo()
        {
            pSV_QuyetDinhKyLuatInfo.IDDM_NamHoc = Program.IDNamHoc;
            pSV_QuyetDinhKyLuatInfo.HocKy = Program.HocKy;
            pSV_QuyetDinhKyLuatInfo.SoQuyetDinh = txtSoQuyetDinh.Text.Trim();
            pSV_QuyetDinhKyLuatInfo.NgayQuyetDinh = (DateTime)dtpNgayQuyetDinh.EditValue;
            pSV_QuyetDinhKyLuatInfo.IDDM_CapKhenThuong = int.Parse(cmbCapKyLuat.EditValue.ToString());
            pSV_QuyetDinhKyLuatInfo.IDDM_HanhVi = int.Parse(cmbLoaiKyLuat.EditValue.ToString());
            pSV_QuyetDinhKyLuatInfo.NoiDung = txtNoiDung.Text.Trim();
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtSoQuyetDinh.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtSoQuyetDinh, "Số quyết định không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtSoQuyetDinh;
            }
            if (dtpNgayQuyetDinh.EditValue == null)
            {
                dxErrorProvider.SetError(dtpNgayQuyetDinh, "Ngày quyết định không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpNgayQuyetDinh;
            }
            if (cmbCapKyLuat.EditValue == null)
            {
                dxErrorProvider.SetError(cmbCapKyLuat, "Cấp kỷ luật không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbCapKyLuat;
            }
            if (cmbLoaiKyLuat.EditValue == null)
            {
                dxErrorProvider.SetError(cmbLoaiKyLuat, "Loại kỷ luật không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbLoaiKyLuat;
            }

            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            else
                return true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            try
            {
                GetpInfo();
                if (edit == EDIT_MODE.THEM)
                {
                    pSV_QuyetDinhKyLuatInfo.SV_QuyetDinhKyLuatID = oBSV_QuyetDinhKyLuat.Add(pSV_QuyetDinhKyLuatInfo);
                    GhiLog("Thêm quyết định kỷ luật '" + pSV_QuyetDinhKyLuatInfo.SoQuyetDinh + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    oBSV_QuyetDinhKyLuat.ToDataRow(pSV_QuyetDinhKyLuatInfo, ref drQuyetDinh);
                }
                else
                {
                    pSV_QuyetDinhKyLuatInfo.SV_QuyetDinhKyLuatID = int.Parse(drQuyetDinh[pSV_QuyetDinhKyLuatInfo.strSV_QuyetDinhKyLuatID].ToString());
                    oBSV_QuyetDinhKyLuat.Update(pSV_QuyetDinhKyLuatInfo);
                    GhiLog("Sửa quyết định kỷ luật '" + pSV_QuyetDinhKyLuatInfo.SoQuyetDinh + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    oBSV_QuyetDinhKyLuat.ToDataRow(pSV_QuyetDinhKyLuatInfo, ref drQuyetDinh);
                }
                drQuyetDinh["TenHanhVi"] = cmbLoaiKyLuat.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            { }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}