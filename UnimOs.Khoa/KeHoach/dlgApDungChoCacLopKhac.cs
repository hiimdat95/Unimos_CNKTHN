using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UnimOs.Khoa
{
    public partial class dlgApDungChoCacLopKhac : frmBase
    {
        private DataView dtview;       
        public dlgApDungChoCacLopKhac(DataView dtLop)
        {
            InitializeComponent();
            dtview = dtLop;
            this.Tag = "";
        }

        private void dlgApDungChoCacLopKhac_Load(object sender, EventArgs e)
        {
            grDSLop.DataSource = dtview;
            if (grvDSLop.DataRowCount > 0)
                btnCapNhat.Enabled = true;
            else
                btnCapNhat.Enabled = false;
           
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string ChuoiDM_LopID = "";
            for (int i = 0; i < grvDSLop.DataRowCount; i++)
            {
                if ((bool)(grvDSLop.GetDataRow(i)["Chon"]) == true)
                {
                    ChuoiDM_LopID += grvDSLop.GetDataRow(i)["DM_LopID"].ToString() + ",";
                }
            }

            if (ChuoiDM_LopID  !=  "")
            {
                this.Tag = ChuoiDM_LopID;
                this.Close();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
    }
}