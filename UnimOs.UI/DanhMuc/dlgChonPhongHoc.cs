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
    public partial class dlgChonPhongHoc : frmBase
    {
        string mPhongHoc;
        public dlgChonPhongHoc(string strPhongHoc)
        {
            InitializeComponent();
            mPhongHoc = (strPhongHoc == "" ? "0" : strPhongHoc);
            this.Tag = "";
        }

        private void dlgChonPhongHoc_Load(object sender, EventArgs e)
        {
            _LoadPhongHoc();
        }

        private void _LoadPhongHoc()
        {
            cBDM_PhongHoc oBPhongHoc = new cBDM_PhongHoc();
            DataTable dtPhongHoc = oBPhongHoc.GetChon(0,mPhongHoc);
            grdPhongHoc.DataSource = dtPhongHoc;
            grvPhongHoc.ExpandAllGroups();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string Result = "";
            for (int i = 0; i < grvPhongHoc.DataRowCount; i++)
            {
                if (bool.Parse(grvPhongHoc.GetDataRow(i)["Chon"].ToString()) == true)
                {
                    Result += grvPhongHoc.GetDataRow(i)["DM_PhongHocID"].ToString() + ",";
                }
            }
            if (Result == "")
            {
               
                XtraMessageBox.Show("Bạn chưa chọn phòng học nào!");
            }
            else
            {
                this.Tag = Result.Substring(0, Result.Length - 1);
                this.Close();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
    }
}