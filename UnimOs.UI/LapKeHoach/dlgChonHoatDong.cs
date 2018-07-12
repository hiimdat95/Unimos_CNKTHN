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
    public partial class dlgChonHoatDong : frmBase
    {
        public int mKeHoachKhacID = 0;
        public string mTenKeHoachKhac = "", mTenVietTat = "";
        public string mNgayNghi = "";
        //public DateTime mTuNgay = DateTime.Parse("01/01/1900"), mDenNgay = DateTime.Parse("01/01/1900");

        public dlgChonHoatDong()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void dlgChonHoatDong_Load(object sender, EventArgs e)
        {
            try
            {
                LoadKeHoachKhac();
                SetText();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void LoadKeHoachKhac()
        {
            cBXL_KeHoachKhac oBKeHoachKhac = new cBXL_KeHoachKhac();
            XL_KeHoachKhacInfo pKeHoachKhacInfo = new XL_KeHoachKhacInfo();
            pKeHoachKhacInfo.XL_KeHoachKhacID = 0;
            cmbIDKeHoachKhac.Properties.DataSource = oBKeHoachKhac.GetCombo(pKeHoachKhacInfo);
            //cmbIDKeHoachKhac.Properties.DisplayMember = "TenKeHoachKhac";
            //cmbIDKeHoachKhac.Properties.ValueMember = "XL_KeHoachKhacID";
        }

        private void SetText()
        {
            if (mKeHoachKhacID != 0)
                cmbIDKeHoachKhac.EditValue = mKeHoachKhacID;
            SetNgayNghi();
        }

        private void SetNgayNghi()
        {
            if (mNgayNghi == "") return;
            if (mNgayNghi == "CaTuan")
                chkCaTuan.Checked = true;
            string[] arrStr = mNgayNghi.Split(',');
            foreach (string str in arrStr)
            {
                SetCheck(str);
            }
        }

        private void SetCheck(string Thu)
        {
            if (Thu == "1")
                chkT2.Checked = true;
            else if (Thu == "2")
                chkT3.Checked = true;
            else if (Thu == "3")
                chkT4.Checked = true;
            else if (Thu == "4")
                chkT5.Checked = true;
            else if (Thu == "5")
                chkT6.Checked = true;
            else if (Thu == "6")
                chkT7.Checked = true;
            else if (Thu == "0")
                chkCN.Checked = true;
        }

        private string GetNgayNghi()
        {
            if (chkCaTuan.Checked)
                return "CaTuan";
            string str = "";
            if (chkT2.Checked)
                str = "1";
            if (chkT3.Checked)
                str += str == "" ? "2" : ",2";
            if (chkT4.Checked)
                str += str == "" ? "3" : ",3";
            if (chkT5.Checked)
                str += str == "" ? "4" : ",4";
            if (chkT6.Checked)
                str += str == "" ? "5" : ",5";
            if (chkT7.Checked)
                str += str == "" ? "6" : ",6";
            if (chkCN.Checked)
                str += str == "" ? "0" : ",0";
            return str;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Check_Valid())
                {
                    cmbIDKeHoachKhac.Focus();
                    return;
                }
                mKeHoachKhacID = (int)cmbIDKeHoachKhac.EditValue;
                mTenKeHoachKhac = cmbIDKeHoachKhac.Text;
                mTenVietTat = cmbIDKeHoachKhac.GetColumnValue("TenVietTat").ToString();
                mNgayNghi = GetNgayNghi();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckValid()
        {
            if (cmbIDKeHoachKhac.EditValue == null)
            {
                XtraMessageBox.Show("Bạn chưa chọn hoạt động nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((DxErrorProvider != null)) DxErrorProvider.Dispose();
            //Thông không được rỗng
            if (cmbIDKeHoachKhac.ItemIndex == -1)
            {
                DxErrorProvider.SetError(cmbIDKeHoachKhac, "Kế hoạch không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbIDKeHoachKhac;
            }
            
            //Kiểm tra Thông thành công
            if ((CtrlErr != null)) return false;
            return true;
        }

        private void chkCaTuan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCaTuan.Checked)
                this.CheckAll(false);
        }

        private void CheckAll(bool status)
        {
            chkT2.Checked = status;
            chkT3.Checked = status;
            chkT4.Checked = status;
            chkT5.Checked = status;
            chkT6.Checked = status;
            chkT7.Checked = status;
            chkCN.Checked = status;
        }

        private void chkT_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckEdit)sender).Checked)
                chkCaTuan.Checked = false;
        }
    }
}