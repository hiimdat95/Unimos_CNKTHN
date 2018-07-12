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
    public partial class dlgChonCTKhoiKienThuc : frmBase
    {
        private cBKQHT_CT_KhoiKienThuc oBKQHT_CT_KhoiKienThuc;
        private KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo;
        private cBKQHT_MonHoc_CT_KhoiKienThuc oBKQHT_MonHoc_CT_KhoiKienThuc;
        private KQHT_MonHoc_CT_KhoiKienThucInfo pKQHT_MonHoc_CT_KhoiKienThucInfo;
        private DataTable dtCTDT, dtMonHoc;
        private int IDKQHT_ChuongTrinhDaoTao;

        public dlgChonCTKhoiKienThuc(int mIDKQHT_ChuongTrinhDaoTao)
        {
            InitializeComponent();
            oBKQHT_CT_KhoiKienThuc = new cBKQHT_CT_KhoiKienThuc();
            pKQHT_CT_KhoiKienThucInfo = new KQHT_CT_KhoiKienThucInfo();
            oBKQHT_MonHoc_CT_KhoiKienThuc = new cBKQHT_MonHoc_CT_KhoiKienThuc();
            pKQHT_MonHoc_CT_KhoiKienThucInfo = new KQHT_MonHoc_CT_KhoiKienThucInfo();
            IDKQHT_ChuongTrinhDaoTao = mIDKQHT_ChuongTrinhDaoTao;
        }

        private void dlgChonCTKhoiKienThuc_Load(object sender, EventArgs e)
        {
            repositorycmbHinhThucThi.DataSource = LoadHinhThucThi();
            LoadCTDT();
        }

        private void LoadCTDT()
        {
            dtCTDT = oBKQHT_CT_KhoiKienThuc.GetChon(IDKQHT_ChuongTrinhDaoTao);
            grdCTDT.DataSource = dtCTDT;
        }

        private void SetButton(bool status)
        {
            btnChon.Enabled = status;
        }

        private void grvCTDT_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvCTDT.DataRowCount > 0)
            {
                if (grvCTDT.FocusedRowHandle >= 0)
                {
                    SetButton(true);
                    DataRow dr = grvCTDT.GetDataRow(grvCTDT.FocusedRowHandle);
                    pKQHT_CT_KhoiKienThucInfo.KQHT_CT_KhoiKienThucID = int.Parse(dr[pKQHT_CT_KhoiKienThucInfo.strKQHT_CT_KhoiKienThucID].ToString());
                    //pKQHT_CT_KhoiKienThucInfo.TenCT_KhoiKienThuc = dr[pKQHT_CT_KhoiKienThucInfo.strTenCT_KhoiKienThuc].ToString();
                    //pKQHT_CT_KhoiKienThucInfo.CT_KhoiKienThucSo = int.Parse(dr[pKQHT_CT_KhoiKienThucInfo.strCT_KhoiKienThucSo].ToString());
                    //pKQHT_CT_KhoiKienThucInfo.IDDM_TrinhDo = int.Parse(dr[pKQHT_CT_KhoiKienThucInfo.strIDDM_TrinhDo].ToString());
                    //pKQHT_CT_KhoiKienThucInfo.IDDM_KhoaHoc = int.Parse(dr[pKQHT_CT_KhoiKienThucInfo.strIDDM_KhoaHoc].ToString());
                    //pKQHT_CT_KhoiKienThucInfo.IDDM_Nganh = int.Parse(dr[pKQHT_CT_KhoiKienThucInfo.strIDDM_Nganh].ToString());
                    //pKQHT_CT_KhoiKienThucInfo.IDDM_ChuyenNganh = int.Parse(dr[pKQHT_CT_KhoiKienThucInfo.strIDDM_ChuyenNganh].ToString());
                    //pKQHT_CT_KhoiKienThucInfo.MoTa = "" + dr[pKQHT_CT_KhoiKienThucInfo.strMoTa].ToString();

                    dtMonHoc = oBKQHT_MonHoc_CT_KhoiKienThuc.GetDanhSachMon(pKQHT_CT_KhoiKienThucInfo.KQHT_CT_KhoiKienThucID);
                    grdMonHoc.DataSource = dtMonHoc;
                }
                else
                    SetButton(false);
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (grvCTDT.FocusedRowHandle < 0) return;
            try
            {
                cBKQHT_CTDT_CT_KhoiKienThuc oB = new cBKQHT_CTDT_CT_KhoiKienThuc();
                KQHT_CTDT_CT_KhoiKienThucInfo p = new KQHT_CTDT_CT_KhoiKienThucInfo();
                p.IDKQHT_ChuongTrinhDaoTao = IDKQHT_ChuongTrinhDaoTao;
                p.IDKQHT_CT_KhoiKienThuc = pKQHT_CT_KhoiKienThucInfo.KQHT_CT_KhoiKienThucID;
                oB.Add(p);
                this.Tag = "1";
                this.Close();
            }
            catch (Exception ex)
            {
                ThongBao(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void grvMonHoc_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
    }
}