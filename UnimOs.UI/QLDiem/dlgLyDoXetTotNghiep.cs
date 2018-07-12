using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UnimOs.UI
{
    public partial class dlgLyDoXetTotNghiep : frmBase
    {
        DataRow[] dr;
        bool XetVot;
        public dlgLyDoXetTotNghiep(ref DataRow[] mdr, bool mXetVot)
        {
            InitializeComponent();
            dr = mdr;
            XetVot = mXetVot;
            if (dr.Length > 1)
            {
                txtMaSV.Text = ".....";
                txtTenSV.Text = ".....";
            }
            else
            {
                txtMaSV.Text = dr[0]["MaSinhVien"].ToString();
                txtTenSV.Text = dr[0]["HoVaTen"].ToString();
            }
        }

        private void dlgLyDoXetTotNghiep_Load(object sender, EventArgs e)
        {

        }
        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((DxErrorProvider != null)) DxErrorProvider.Dispose();
            //Mã và tên hệ không được rỗng
            if (txtLyDo.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtLyDo, "Lý do không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtLyDo;
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
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!Check_Valid()) return;
            this.Tag = "1";
            foreach (DataRow drr in dr)
            {
                drr["LyDo"] = txtLyDo.Text.Trim();
                drr["XetVot"] = XetVot;
            }
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
    }
}