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
    public partial class dlgXoaKhoiKienThuc : frmBase
    {
        KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo;
        cBKQHT_ChuongTrinhDaoTao oBKQHT_ChuongTrinhDaoTao;
        KQHT_CTDT_CT_KhoiKienThucInfo pKQHT_CTDT_CT_KhoiKienThucInfo;
        cBKQHT_CTDT_CT_KhoiKienThuc oBKQHT_CTDT_CT_KhoiKienThuc;
        public dlgXoaKhoiKienThuc(int KQHT_CTDTID)
        {
            InitializeComponent();
            oBKQHT_ChuongTrinhDaoTao = new cBKQHT_ChuongTrinhDaoTao();
            pKQHT_ChuongTrinhDaoTaoInfo = new KQHT_ChuongTrinhDaoTaoInfo();
            pKQHT_CTDT_CT_KhoiKienThucInfo = new KQHT_CTDT_CT_KhoiKienThucInfo();
            oBKQHT_CTDT_CT_KhoiKienThuc = new cBKQHT_CTDT_CT_KhoiKienThuc();
            pKQHT_ChuongTrinhDaoTaoInfo.KQHT_ChuongTrinhDaoTaoID = KQHT_CTDTID;
            this.Tag = "";
        }

        private void dlgXoaKhoiKienThuc_Load(object sender, EventArgs e)
        {
            DataTable dtTemp = oBKQHT_CTDT_CT_KhoiKienThuc.Get(pKQHT_CTDT_CT_KhoiKienThucInfo);
            dtTemp.DefaultView.RowFilter = "IDKQHT_ChuongTrinhDaoTao=" + pKQHT_ChuongTrinhDaoTaoInfo.KQHT_ChuongTrinhDaoTaoID;
            grdKhoiKienThuc.DataSource = dtTemp.DefaultView;
           

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn muốn xóa!") == DialogResult.Yes)
            {
                bool Chon = false;
                try
                {
                    for (int i = 0; i < grvKhoiKienThuc.RowCount; i++)
                    {
                        if (bool.Parse(grvKhoiKienThuc.GetDataRow(i)["Chon"].ToString()) == true)
                        {
                            Chon = true;
                            pKQHT_CTDT_CT_KhoiKienThucInfo.KQHT_CTDT_CT_KhoiKienThucID = int.Parse(grvKhoiKienThuc.GetDataRow(i)["KQHT_CTDT_CT_KhoiKienThucID"].ToString());
                            oBKQHT_CTDT_CT_KhoiKienThuc.Delete(pKQHT_CTDT_CT_KhoiKienThucInfo);
                        }
                    }
                    if (Chon == false)
                        ThongBao("Bạn chưa chọn khối kiến thức nào.");
                    else
                    {
                        this.Tag = "1";
                        this.Close();
                    }
                }
                catch
                {
                    XoaThatBai();
                }
            }

        }

        private void bntHuy_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
    }
}