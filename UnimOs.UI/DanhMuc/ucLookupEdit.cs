using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UnimOs.UI
{
    public partial class ucLookupEdit : DevExpress.XtraEditors.XtraUserControl
    {
        public ucLookupEdit()
        {
            InitializeComponent();
        }

        private void cmb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmb.EditValue = null;
        }
    }
}
