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

namespace UnimOs.Khoa
{
    public partial class dlgCTDTChonLopHoc : frmBase
    {
        cBKQHT_CTDT_Lop oBKQHT_CTDT_Lop;
        KQHT_CTDT_LopInfo pKQHT_CTDT_LopInfo;
        private int IDDM_TrinhDo;
        private DataTable dtLop;

        public dlgCTDTChonLopHoc(int mIDDM_TrinhDo, int mKQHT_ChuongTrinhDaoTaoID, string TenCTDT)
        {
            InitializeComponent();
            oBKQHT_CTDT_Lop = new cBKQHT_CTDT_Lop();
            pKQHT_CTDT_LopInfo = new KQHT_CTDT_LopInfo();
            pKQHT_CTDT_LopInfo.IDKQHT_ChuongTrinhDaoTao = mKQHT_ChuongTrinhDaoTaoID;
            IDDM_TrinhDo = mIDDM_TrinhDo;
            lblCTDT.Text = TenCTDT.ToUpper();
            this.Tag = "";
        }

        private void dlgCTDTChonLopHoc_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            cBDM_Lop oBDM_Lop = new cBDM_Lop();
            dtLop = oBDM_Lop.GetChon(IDDM_TrinhDo, Program.NamHoc);
            grdDSLop.DataSource = dtLop;
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            bool Chon = false;
            try
            {
                foreach (DataRow dr in dtLop.Rows)
                {
                    if (bool.Parse(dr["Chon"].ToString()) == true)
                    {
                        Chon = true;
                        pKQHT_CTDT_LopInfo.IDDM_Lop = int.Parse(dr["DM_LopID"].ToString());
                        oBKQHT_CTDT_Lop.Add(pKQHT_CTDT_LopInfo);
                    }
                }
                if (Chon == false)
                    ThongBao("Bạn chưa chọn lớp nào.");
                else
                {
                    this.Tag = "1";
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ThongBao(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void grvDSLop_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvDSLop, "Chon", e);
        }
    }
}