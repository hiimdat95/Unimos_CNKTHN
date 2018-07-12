using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.Business;
//using TruongViet.UnimOs.Data;
using TruongViet.UnimOs.Entity;

namespace UnimOs.UI
{
    public partial class frmChonNamHoc : frmBase
    {
        private cBDM_NamHoc oBNamHoc;
        private DM_NamHocInfo pNamHocInfo;
       
        public frmChonNamHoc()
        {
            InitializeComponent();
            oBNamHoc = new cBDM_NamHoc();
            pNamHocInfo = new DM_NamHocInfo();
            DataTable dtNamHoc = new DataTable();
            dtNamHoc = oBNamHoc.Get(pNamHocInfo);
            cmbNamHoc.Properties.ValueMember = "DM_NamHocID";
            cmbNamHoc.Properties.DisplayMember = "TenNamHoc";
            cmbNamHoc.Properties.DataSource = dtNamHoc;
            if (dtNamHoc != null)
            {
                cmbNamHoc.EditValue = dtNamHoc.Rows[0]["DM_NamHocID"];
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("HocKy", typeof(int));
            DataRow dr = dt.NewRow();
            dr["HocKy"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["HocKy"] = 2;
            dt.Rows.Add(dr);
            cmbHocKy.Properties.ValueMember = "HocKy";
            cmbHocKy.Properties.DisplayMember = "HocKy";
            cmbHocKy.Properties.DataSource = dt;
            cmbHocKy.EditValue = dt.Rows[0]["HocKy"];
        }

        private void frmChonNamHoc_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.IDDM_NamHoc != 0)
                cmbNamHoc.EditValue = Properties.Settings.Default.IDDM_NamHoc;
            cmbHocKy.EditValue = Properties.Settings.Default.HocKy;
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            Program.NamHoc = cmbNamHoc.Text;
            Program.IDNamHoc = int.Parse(cmbNamHoc.EditValue.ToString());
            Program.HocKy = int.Parse(cmbHocKy.Text);
            Program.TuNgay = ((DateTime)cmbNamHoc.GetColumnValue("TuNgay")).Date;
            Program.DenNgay = ((DateTime)cmbNamHoc.GetColumnValue("DenNgay")).Date;

            Properties.Settings.Default.IDDM_NamHoc = Program.IDNamHoc;
            Properties.Settings.Default.HocKy = Program.HocKy;
            Properties.Settings.Default.Save();
            this.Close();            
        }
    }
}