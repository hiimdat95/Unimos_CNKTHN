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
using System.Data.SqlClient;

namespace UnimOs.UI
{
    public partial class dlgPhongHoc : frmBase
    {
        private cBDM_PhongHoc oBDM_PhongHoc;
        private DM_PhongHocInfo pDM_PhongHocInfo;
        private frmPhongHoc frm;
        private bool UPDATE;

        public dlgPhongHoc(frmPhongHoc mfrm, bool mUPDATE)
        {
            InitializeComponent();
            frm = mfrm;
            pDM_PhongHocInfo = mfrm.pDM_PhongHocInfo;
            UPDATE = mUPDATE;
        }

        private void dlgPhongHoc_Load(object sender, EventArgs e)
        {
            oBDM_PhongHoc = new cBDM_PhongHoc();
            DataTable dtLoaiPhong = LoadLoaiPhong();
            cmbLoaiPhong.Properties.DataSource = dtLoaiPhong;
            if (dtLoaiPhong.Rows.Count > 0)
                cmbLoaiPhong.ItemIndex = 0;
            DataTable dtTang = LoadTang();
            cmbTang.Properties.DataSource = dtTang;
            if (dtTang.Rows.Count > 0)
                cmbTang.ItemIndex = 0;
            SetText();
        }

        private void SetText()
        {
            if (UPDATE)
            {
                cmbLoaiPhong.EditValue = pDM_PhongHocInfo.IDDM_LoaiPhong;
                cmbTang.EditValue = pDM_PhongHocInfo.IDDM_Tang;
                txtTenPhong.Text = pDM_PhongHocInfo.TenPhongHoc;
                txtSucChua.Text = pDM_PhongHocInfo.SucChua.ToString();
            }
        }

        private void GetpInfo()
        { 
            pDM_PhongHocInfo.IDDM_LoaiPhong = int.Parse(cmbLoaiPhong.EditValue.ToString());
            pDM_PhongHocInfo.IDDM_Tang = int.Parse(cmbTang.EditValue.ToString());
            pDM_PhongHocInfo.TenPhongHoc = txtTenPhong.Text;
            pDM_PhongHocInfo.SucChua = int.Parse(txtSucChua.Text);
        }

        private void ClearText()
        { 
            txtTenPhong.Text = "";
            txtSucChua.Text = "0";
        }

        private bool CheckValid()
        {
            
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtTenPhong.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenPhong, "Tên phòng học không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenPhong;
            }
            if (txtSucChua.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtSucChua, "Sức chứa không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtSucChua;
            }
           
            if (txtTenPhong.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenPhong, "Tên phòng học không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenPhong;
            }
            if (cmbLoaiPhong.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenPhong, "Bạn chưa chọn loại phòng.");
                if (CtrlErr == null) CtrlErr = cmbLoaiPhong;
            }
            if ((CtrlErr != null))
                return false;
            else
                return true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            try
            {
                GetpInfo();
                if (UPDATE == true)
                {
                    oBDM_PhongHoc.Update(pDM_PhongHocInfo);
                    frm.pDM_PhongHocInfo= pDM_PhongHocInfo;
                    frm.EditPhongHoc(UPDATE, cmbLoaiPhong.Text, cmbTang.Text);
                    // ghi log
                    GhiLog("Sửa phòng học '" + pDM_PhongHocInfo.TenPhongHoc + "'", "Sửa", this.Tag.ToString());
                    SuaThanhCong();
                    this.Close();
                }
                else
                {
                    pDM_PhongHocInfo.DM_PhongHocID = oBDM_PhongHoc.Add(pDM_PhongHocInfo);
                    frm.pDM_PhongHocInfo = pDM_PhongHocInfo;
                    frm.EditPhongHoc(UPDATE, cmbLoaiPhong.Text, cmbTang.Text);
                    // ghi log
                    GhiLog("Thêm phòng học '" + pDM_PhongHocInfo.TenPhongHoc + "'", "Thêm", this.Tag.ToString());
                    ClearText();
                    txtTenPhong.Focus();
                }
            }
            catch (SqlException SqlEx)
            {
                ThongBao(SqlEx.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}