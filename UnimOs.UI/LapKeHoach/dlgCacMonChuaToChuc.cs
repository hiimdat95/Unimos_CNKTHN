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
    public partial class dlgCacMonChuaToChuc :  frmBase
    {
        KQHT_ChuongTrinhDaoTaoInfo pKQHT_CTDTInfo;
        cBKQHT_ChuongTrinhDaoTao oBKQHT_CTDT;
        public dlgCacMonChuaToChuc(int KQHT_ChuongTrinhDaoTaoID, int DM_LopID, int CTDT_HocKy)
        {
            InitializeComponent();
            pKQHT_CTDTInfo = new KQHT_ChuongTrinhDaoTaoInfo();
            oBKQHT_CTDT = new cBKQHT_ChuongTrinhDaoTao();
            repositoryThiMonKhung.DataSource = LoadHinhThucThi();
            DataTable dtTemp = oBKQHT_CTDT.GetMonChuaToChuc(KQHT_ChuongTrinhDaoTaoID, DM_LopID, CTDT_HocKy);
            if (dtTemp != null)
            {
                grdMonKhung.DataSource = dtTemp;
            }
        }

        private void dlgCacMonChuaToChuc_Load(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvMonKhung_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToXls(grvMonKhung);
        }
    }
}