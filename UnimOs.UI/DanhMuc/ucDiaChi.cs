using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
//using DevExpress.XtraEditors;

namespace UnimOs.UI
{
    public partial class ucDiaChi : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDiaChi()
        {
            InitializeComponent();
        }

        public int returnID()
        {
            if (cmbXa.EditValue != null)
                return int.Parse(cmbXa.EditValue.ToString());
            else if (cmbHuyen.EditValue != null)
                return int.Parse(cmbHuyen.EditValue.ToString());
            else if (cmbTinh.EditValue != null)
                return int.Parse(cmbTinh.EditValue.ToString());
            else
                return 0;
        }

        public string returnDiaChi()
        {
            string value = txtSoNha.Text.Trim();
            if (cmbXa.EditValue != null)
                value += (value == "" ? "" : " - ") + cmbXa.Text;
            if (cmbHuyen.EditValue != null)
                value += (value == "" ? "" : " - ") + cmbHuyen.Text;
            if (cmbTinh.EditValue != null)
                value += (value == "" ? "" : " - ") + cmbTinh.Text;
            return value;
        }

        private void cmbTinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteInLookUp(cmbTinh);
            }
            else if (e.KeyCode == Keys.F5)
            {
                frmTinhHuyenXa frm = new frmTinhHuyenXa();
                frm.ShowDialog();
            }
        }

        private void cmbHuyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteInLookUp(cmbHuyen);
            }
            else if (e.KeyCode == Keys.F5)
            {
                frmTinhHuyenXa frm = new frmTinhHuyenXa();
                frm.ShowDialog();
            }
        }

        private void cmbXa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteInLookUp(cmbXa);
            }
            else if (e.KeyCode == Keys.F5)
            {
                frmTinhHuyenXa frm = new frmTinhHuyenXa();
                frm.ShowDialog();
            }
        }

        protected void DeleteInLookUp(LookUpEdit cmb)
        {
            cmb.ClosePopup();
            cmb.EditValue = null;
        }
    }
}
