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

namespace UnimOs.UI
{
    public partial class dlgApDungNhieuTuan : frmBase
    {
        int TuanThu;
        public dlgApDungNhieuTuan(int mTuanThu)
        {
            InitializeComponent();
            TuanThu = mTuanThu;
        }

        private void dlgApDungNhieuTuan_Load(object sender, EventArgs e)
        {
            cBXL_Tuan oBTuan = new cBXL_Tuan();
            DataTable dtTuan = oBTuan.GetByTuTuan(Program.IDNamHoc, Program.HocKy, TuanThu);
            cmbTuan.Properties.DataSource = dtTuan;
            if (dtTuan.Rows.Count > 0)
                cmbTuan.EditValue = TuanThu + 1;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cmbTuan.EditValue == null)
                this.Tag = 0;
            else
                this.Tag = cmbTuan.Text;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Tag = 0;
            this.Close();
        }
    }
}