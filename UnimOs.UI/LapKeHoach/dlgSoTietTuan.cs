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
    public partial class dlgSoTietTuan : frmBase
    {
        public dlgSoTietTuan(int SoTiet)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            if (SoTiet > 0)
                txtSoTiet.EditValue = (decimal)SoTiet;
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}