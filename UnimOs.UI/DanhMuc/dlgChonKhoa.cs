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
    public partial class dlgChonKhoa : frmBase
    {
        private DataTable dtKhoa;
        private bool MultiCheck;
        public int[] arrIDChecked;

        public dlgChonKhoa(bool _MultiCheck, int[] _arrIDChecked)
        {
            InitializeComponent();
            MultiCheck = _MultiCheck;
            arrIDChecked = _arrIDChecked;
            grcChon.Visible = _MultiCheck;
        }

        private void dlgChonKhoa_Load(object sender, EventArgs e)
        {
            dtKhoa = LoadKhoa();
            grdKhoa.DataSource = dtKhoa;
            if (!MultiCheck)
            {
                if (arrIDChecked != null)
                {
                    for (int i = 0; i < grvKhoa.DataRowCount; i++)
                    {
                        if ("" + grvKhoa.GetDataRow(i)["DM_KhoaID"] == arrIDChecked[0].ToString())
                            grvKhoa.FocusedRowHandle = i;
                    }
                }
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (!MultiCheck)
            {
                if (grvKhoa.FocusedRowHandle >= 0)
                {
                    arrIDChecked = new int[1];
                    arrIDChecked[0] = int.Parse(grvKhoa.GetDataRow(grvKhoa.FocusedRowHandle)["DM_KhoaID"].ToString());
                    this.DialogResult = DialogResult.OK;
                }
            }
            else 
            { 
                
            }
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}