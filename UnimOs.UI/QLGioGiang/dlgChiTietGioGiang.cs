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
    public partial class dlgChiTietGioGiang : frmBase
    {
        public dlgChiTietGioGiang(DataTable dt, DataTable dtCongViec)
        {
            InitializeComponent();
            grdGiaoVien.DataSource = dt;
            grdCongViec.DataSource = dtCongViec;
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}