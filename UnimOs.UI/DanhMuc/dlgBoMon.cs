using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Business;
using System.Data.SqlClient;

namespace UnimOs.UI
{
    public partial class dlgBoMon : frmBase
    {
        frmKhoaBoMon frm;
        private DM_BoMonInfo pDM_BoMonInfo;
        private cBDM_BoMon oBDM_BoMon;
        private bool UPDATE;
        private string Ma;
        public dlgBoMon(DM_BoMonInfo mDM_BoMonInfo, bool mUPDATE, frmKhoaBoMon mfrm)
        {
            InitializeComponent();
            pDM_BoMonInfo = mDM_BoMonInfo;
            UPDATE = mUPDATE;
            frm = mfrm;
            oBDM_BoMon = new cBDM_BoMon();

        }

        private void dlgBoMon_Load(object sender, EventArgs e)
        {
            cmbKhoa.Properties.DataSource = LoadKhoa();
            cmbKhoa.EditValue = pDM_BoMonInfo.IDDM_Khoa;
            SetText();
        }

        private void SetText()
        {
            if (UPDATE == true)
            {
                txtMaBoMon.Text = pDM_BoMonInfo.MaBoMon;
                txtTenBoMon.Text = pDM_BoMonInfo.TenBoMon;
            }
        }

        private void ClearText()
        {
            txtMaBoMon.Text = "";
            txtTenBoMon.Text = "";
        }

        private void GetpDM_BoMon()
        {
            pDM_BoMonInfo.MaBoMon = txtMaBoMon.Text.Trim();
            pDM_BoMonInfo.TenBoMon = txtTenBoMon.Text.Trim();
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtMaBoMon.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtMaBoMon, "Mã bộ môn không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMaBoMon;
            }
            if (txtTenBoMon.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenBoMon, "Tên bộ môn không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenBoMon;
            }
            if (UPDATE == true && txtMaBoMon.Text.Trim() == Ma)
            {
                UPDATE = true;
            }
            else
            {
                //kiểm tra mã nhập vào có trùng với dữ liệu trước không.
                if (frm.grvBoMon.RowCount != 0)
                {
                    for (int i = 0; i < frm.grvBoMon.RowCount; i++)
                    {
                            if (txtMaBoMon.Text.Trim() == frm.grvBoMon.GetDataRow(i)[pDM_BoMonInfo.strMaBoMon].ToString())
                            {

                                if (CtrlErr == null) CtrlErr = txtMaBoMon;
                                txtMaBoMon.Text = "";
                                txtMaBoMon.Focus();
                                ThongBao("Mã bộ môn bạn nhập đã bị trùng");
                                break;
                            }
                    }
                }
            }
            if ((CtrlErr != null))
                return false;
            else
                return true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            Ma = pDM_BoMonInfo.MaBoMon;
            if (!CheckValid()) return;
            try
            {
                GetpDM_BoMon();
                if (UPDATE == true)
                {
                    oBDM_BoMon.Update(pDM_BoMonInfo);
                    frm.pDM_BoMonInfo = pDM_BoMonInfo;
                    frm.EditBoMon(EDIT_MODE.SUA);
                    SuaThanhCong();
                    // ghi log
                    GhiLog("Sửa bộ môn " + pDM_BoMonInfo.TenBoMon, "Thêm", frm.Tag.ToString());

                    this.Close();
                }
                else
                {
                    pDM_BoMonInfo.DM_BoMonID = oBDM_BoMon.Add(pDM_BoMonInfo);
                    frm.pDM_BoMonInfo = pDM_BoMonInfo;
                    frm.EditBoMon(EDIT_MODE.THEM);
                    // ghi log
                    GhiLog("Thêm bộ môn '" + pDM_BoMonInfo.TenBoMon + "' vào cơ sở dữ liệu", "Cập nhật", frm.Tag.ToString());
                    ClearText();
                    txtMaBoMon.Focus();
                }
            }
            catch (SqlException SqlEx)
            {
                XtraMessageBox.Show(SqlEx.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}