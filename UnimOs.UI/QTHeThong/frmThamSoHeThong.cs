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
    public partial class frmThamSoHeThong : frmBase
    {
        cBHT_ThamSoHeThong oBThamSoHeThong;
        HT_ThamSoHeThongInfo pThamSoHeThongInfo;
        public frmThamSoHeThong()
        {
            InitializeComponent();
            oBThamSoHeThong = new cBHT_ThamSoHeThong();
        }

        private void frmThamSoHeThong_Load(object sender, EventArgs e)
        {
            LoadThamSoXepLich();
        }

        private void LoadThamSoXepLich()
        {
            grdXepLich.DataSource = oBThamSoHeThong.GetListByPhanHe(0);
        }

        private void grvXepLich_DoubleClick(object sender, EventArgs e)
        {
            dlgThamSoHeThong dlg = new dlgThamSoHeThong(pThamSoHeThongInfo);
            dlg.ShowDialog();
            if (dlg.Result == true)
                LoadThamSoXepLich();
        }

        private void grvXepLich_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            pThamSoHeThongInfo = (HT_ThamSoHeThongInfo)grvXepLich.GetRow(grvXepLich.FocusedRowHandle);
        }

        private void frmThamSoHeThong_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogIn frm = new frmLogIn();
            frm.DocThamSoXepLich();
            frm.Dispose();
        }

        private void grvXepLich_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
    }
}