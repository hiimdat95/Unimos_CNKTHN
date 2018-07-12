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
    public partial class dlgQDKhenThuong : frmBase
    {
        private cBSV_QuyetDinhKhenThuong oBSV_QuyetDinhKhenThuong;
        private SV_QuyetDinhKhenThuongInfo pSV_QuyetDinhKhenThuongInfo;
        public DataRow drQuyetDinh;
        private EDIT_MODE edit;

        public dlgQDKhenThuong(EDIT_MODE _edit)
        {
            InitializeComponent();
            edit = _edit;
            this.DialogResult = DialogResult.Cancel;
            oBSV_QuyetDinhKhenThuong = new cBSV_QuyetDinhKhenThuong();
            pSV_QuyetDinhKhenThuongInfo = new SV_QuyetDinhKhenThuongInfo();
        }

        private void dlgQDKhenThuong_Load(object sender, EventArgs e)
        {
            dtpNgayQuyetDinh.EditValue = DateTime.Now;
            txtNamHoc.Text = Program.NamHoc;
            txtHocKy.Text = Program.HocKy.ToString();
            cmbCapKhenThuong.Properties.DataSource = LoadCapKhenThuong();
            cmbLoaiKhenThuong.Properties.DataSource = LoadLoaiKhenThuong();
            if (edit == EDIT_MODE.SUA)
            {
                txtSoQuyetDinh.Text = drQuyetDinh[pSV_QuyetDinhKhenThuongInfo.strSoQuyetDinh].ToString();
                dtpNgayQuyetDinh.EditValue = drQuyetDinh[pSV_QuyetDinhKhenThuongInfo.strNgayQuyetDinh];
                cmbCapKhenThuong.EditValue = drQuyetDinh[pSV_QuyetDinhKhenThuongInfo.strIDDM_CapKhenThuong];
                cmbLoaiKhenThuong.EditValue = drQuyetDinh[pSV_QuyetDinhKhenThuongInfo.strIDDM_LoaiKhenThuong];
                txtNoiDung.Text = "" + drQuyetDinh[pSV_QuyetDinhKhenThuongInfo.strNoiDung];
            }
        }

        private void GetpInfo()
        {
            pSV_QuyetDinhKhenThuongInfo.IDDM_NamHoc = Program.IDNamHoc;
            pSV_QuyetDinhKhenThuongInfo.HocKy = Program.HocKy;
            pSV_QuyetDinhKhenThuongInfo.SoQuyetDinh = txtSoQuyetDinh.Text.Trim();
            pSV_QuyetDinhKhenThuongInfo.NgayQuyetDinh = (DateTime)dtpNgayQuyetDinh.EditValue;
            pSV_QuyetDinhKhenThuongInfo.IDDM_CapKhenThuong = int.Parse(cmbCapKhenThuong.EditValue.ToString());
            pSV_QuyetDinhKhenThuongInfo.IDDM_LoaiKhenThuong = int.Parse(cmbLoaiKhenThuong.EditValue.ToString());
            pSV_QuyetDinhKhenThuongInfo.NoiDung = txtNoiDung.Text.Trim();
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
            if (cmbCapKhenThuong.EditValue == null)
            {
                dxErrorProvider.SetError(cmbCapKhenThuong, "Cấp khen thưởng không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbCapKhenThuong;
            }
            if (cmbLoaiKhenThuong.EditValue == null)
            {
                dxErrorProvider.SetError(cmbLoaiKhenThuong, "Loại khen thưởng không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbLoaiKhenThuong;
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
                    pSV_QuyetDinhKhenThuongInfo.SV_QuyetDinhKhenThuongID = oBSV_QuyetDinhKhenThuong.Add(pSV_QuyetDinhKhenThuongInfo);
                    GhiLog("Thêm quyết định khen thưởng '" + pSV_QuyetDinhKhenThuongInfo.SoQuyetDinh + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    oBSV_QuyetDinhKhenThuong.ToDataRow(pSV_QuyetDinhKhenThuongInfo, ref drQuyetDinh);
                }
                else
                {
                    pSV_QuyetDinhKhenThuongInfo.SV_QuyetDinhKhenThuongID = int.Parse(drQuyetDinh[pSV_QuyetDinhKhenThuongInfo.strSV_QuyetDinhKhenThuongID].ToString());
                    oBSV_QuyetDinhKhenThuong.Update(pSV_QuyetDinhKhenThuongInfo);
                    GhiLog("Sửa quyết định khen thưởng '" + pSV_QuyetDinhKhenThuongInfo.SoQuyetDinh + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    oBSV_QuyetDinhKhenThuong.ToDataRow(pSV_QuyetDinhKhenThuongInfo, ref drQuyetDinh);
                }
                drQuyetDinh["TenLoaiKhenThuong"] = cmbLoaiKhenThuong.Text;
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