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
    public partial class dlgChonMonHoc :  frmBase
    {
        private cBDM_MonHoc oBDM_MonHoc;
        private DM_MonHocInfo pDM_MonHocInfo;
        private cBXL_GiaoVien_MonHoc oBXL_GV_MH;
        private XL_GiaoVien_MonHocInfo pXL_GV_MHInfo;
        private DataTable dtMonHoc ;
        private string HoTen;

        public dlgChonMonHoc(int mIDNS_GiaoVien, string mHoTen)
        {
            InitializeComponent();
            oBDM_MonHoc = new cBDM_MonHoc();
            pDM_MonHocInfo = new DM_MonHocInfo();
            oBXL_GV_MH = new cBXL_GiaoVien_MonHoc();
            pXL_GV_MHInfo = new XL_GiaoVien_MonHocInfo();
            pXL_GV_MHInfo.IDNS_GiaoVien = mIDNS_GiaoVien;
            HoTen = mHoTen;
            this.Tag = "";
        }

        private void dlgChonMonHoc_Load(object sender, EventArgs e)
        {   
            LoadGrid();
        }
        private void LoadGrid()
        {
            dtMonHoc = oBDM_MonHoc.GetNotInIDNSGiaoVien(pXL_GV_MHInfo.IDNS_GiaoVien);
            grdMonHoc.DataSource = dtMonHoc;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
           
            bool Chon = false;
            string TenMonHocs = "";
            try
            {
                foreach (DataRow dr in dtMonHoc.Rows)
                {
                    if (bool.Parse(dr["Chon"].ToString()) == true)
                    {
                        Chon = true;
                        pXL_GV_MHInfo.IDDM_MonHoc = int.Parse(dr["DM_MonHocID"].ToString());
                        TenMonHocs += dr["TenMonHoc"].ToString() + ",";
                        oBXL_GV_MH.Add(pXL_GV_MHInfo);
                    }
                }
                if (Chon == false)
                    ThongBao("Bạn chưa chọn môn nào.");
                else
                {
                    // Ghi Log
                    GhiLog("Thêm các môn học '" + TenMonHocs + "' cho giáo viên '" + HoTen + "'", "Thêm", this.Tag.ToString());
                    this.Tag = "1";
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ThongBao(ex.Message);
            }
        }
    }
}