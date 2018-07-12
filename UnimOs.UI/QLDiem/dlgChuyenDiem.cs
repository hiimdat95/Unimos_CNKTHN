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
    public partial class dlgChuyenDiem : frmBase
    {
        public dlgChuyenDiem(bool DiemThanhPhan, bool ThiLan1, bool DiemThanhPhanL2, bool ThiLan2, bool NhapDiemLan2)
        {
            InitializeComponent();
            chkDiemThanhPhan.Checked = DiemThanhPhan;
            chkDiemThanhPhan.Enabled = !DiemThanhPhan;
            chkDiemThanhPhanL2.Checked = DiemThanhPhanL2;
            chkDiemThanhPhanL2.Enabled = !DiemThanhPhanL2;
            chkThiLan1.Checked = ThiLan1;
            chkThiLan1.Enabled = !ThiLan1;
            chkThiLan2.Checked = ThiLan2;
            chkThiLan2.Enabled = !ThiLan2;
            if (!NhapDiemLan2)
            {
                chkDiemThanhPhanL2.Enabled = false;
                chkThiLan2.Enabled = false;
            }
            else
            {
                chkDiemThanhPhan.Enabled = false;
                chkThiLan1.Enabled = false;
            }
        }

        private void dlgChuyenDiem_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (chkDiemThanhPhan.Checked || chkThiLan1.Checked || chkDiemThanhPhanL2.Checked || chkThiLan2.Checked)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}