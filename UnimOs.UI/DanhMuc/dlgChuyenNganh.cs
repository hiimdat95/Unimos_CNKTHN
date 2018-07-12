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
    public partial class dlgChuyenNganh : frmBase
    {
        private cBDM_ChuyenNganh oBDM_ChuyenNganh;
        private DM_ChuyenNganhInfo pDM_ChuyenNganhInfo;
        private bool UPDATE;
        private string TenNganh;
        private frmNganhChuyenNganh frm;
        private string Ma;

        public dlgChuyenNganh(frmNganhChuyenNganh mfrm, string mTenNganh, bool mUPDATE)
        {
            InitializeComponent();
            oBDM_ChuyenNganh = new cBDM_ChuyenNganh();
            pDM_ChuyenNganhInfo = mfrm.pDM_ChuyenNganhInfo;
            UPDATE = mUPDATE;
            TenNganh = mTenNganh;
            frm = mfrm;
        }

        private void dlgChuyenNganh_Load(object sender, EventArgs e)
        {
            SetText();
        }

        private void SetText()
        {
            txtNganh.Text = TenNganh;
            if (UPDATE)
            {
                txtMaChuyenNganh.Text = pDM_ChuyenNganhInfo.MaChuyenNganh;
                txtTenChuyenNganh.Text = pDM_ChuyenNganhInfo.TenChuyenNganh;
                txtTenChuyenNganh_E.Text = pDM_ChuyenNganhInfo.TenChuyenNganh_E;
            }
        }

        private void ClearText()
        {
            txtMaChuyenNganh.Text = "";
            txtTenChuyenNganh.Text = "";
            txtTenChuyenNganh_E.Text = "";
        }

        private void GetpInfo()
        {
            pDM_ChuyenNganhInfo.MaChuyenNganh = txtMaChuyenNganh.Text.Trim();
            pDM_ChuyenNganhInfo.TenChuyenNganh = txtTenChuyenNganh.Text.Trim();
            pDM_ChuyenNganhInfo.TenChuyenNganh_E = txtTenChuyenNganh_E.Text.Trim();
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtMaChuyenNganh.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtMaChuyenNganh, "Mã chuyên ngành không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMaChuyenNganh;
            }
            if (txtTenChuyenNganh.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenChuyenNganh, "Tên chuyên ngành không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenChuyenNganh;
            }
            
            //kiểm tra mã nhập vào có trùng với dữ liệu trước không.
            if (UPDATE == true && txtMaChuyenNganh.Text.Trim() == Ma)
            {
                UPDATE = true;
            }
            else
            {
                if (frm.grvChuyenNganh.RowCount != 0)
                {
                    for (int i = 0; i < frm.grvChuyenNganh.RowCount; i++)
                    {

                        if (txtMaChuyenNganh.Text.Trim() == frm.grvChuyenNganh.GetDataRow(i)[pDM_ChuyenNganhInfo.strMaChuyenNganh].ToString())
                        {

                            if (CtrlErr == null) CtrlErr = txtMaChuyenNganh;
                            txtMaChuyenNganh.Text = "";
                            txtMaChuyenNganh.Focus();
                            ThongBao("Mã chuyên ngành bạn nhập đã bị trùng");
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
            Ma = pDM_ChuyenNganhInfo.MaChuyenNganh;
            if (!CheckValid()) return;
            try
            {
                GetpInfo();
                if (UPDATE == true)
                {
                    oBDM_ChuyenNganh.Update(pDM_ChuyenNganhInfo);
                    frm.pDM_ChuyenNganhInfo = pDM_ChuyenNganhInfo;
                    frm.EditChuyenNganh(UPDATE);
                    SuaThanhCong();
                    // ghi log
                    GhiLog("Sửa chuyên ngành '" + pDM_ChuyenNganhInfo.TenChuyenNganh + "'", "Sửa", this.Tag.ToString());
                    this.Close();
                }
                else
                {
                    pDM_ChuyenNganhInfo.DM_ChuyenNganhID = oBDM_ChuyenNganh.Add(pDM_ChuyenNganhInfo);
                    frm.pDM_ChuyenNganhInfo = pDM_ChuyenNganhInfo;
                    frm.EditChuyenNganh(UPDATE);
                    // ghi log
                    GhiLog("Thêm chuyên ngành '" + pDM_ChuyenNganhInfo.TenChuyenNganh + "'", "Thêm", this.Tag.ToString());
                    ClearText();
                    txtMaChuyenNganh.Focus();
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