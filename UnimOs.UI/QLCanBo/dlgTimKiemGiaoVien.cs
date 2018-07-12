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
    public partial class dlgTimKiemGiaoVien : frmBase
    {
        private cBNS_GiaoVien oBNS_GiaoVien;
        private NS_GiaoVienInfo pGiaoVien_Info;
        DataTable dtGiaoVien;
        private int IDNS_DonVi;
        public dlgTimKiemGiaoVien(int mIDNS_DonVi)
        {
            pGiaoVien_Info = new NS_GiaoVienInfo();
            oBNS_GiaoVien = new cBNS_GiaoVien();
            IDNS_DonVi = mIDNS_DonVi;
            InitializeComponent();
            this.Tag = "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if ((txtHoTen.Text.Trim() !="") || (txtMaGV.Text.Trim() !=""))
            {
                pGiaoVien_Info.MaGiaoVien = txtMaGV.Text.Trim();
                pGiaoVien_Info.HoTen = txtHoTen.Text.Trim();
                dtGiaoVien = oBNS_GiaoVien.TimKiem(pGiaoVien_Info);
                if (dtGiaoVien != null)
                {
                    grdGiaoVien.DataSource = dtGiaoVien;                   
                }
            }
            else
            {
                ThongBao("Bạn chưa chọn thông tin tìm kiếm!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void dlgTimKiemGiaoVien_Load(object sender, EventArgs e)
        {

        }     

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (IDNS_DonVi > 0)
            {
                string ChuoiNS_GiaoVienID = "";
                try
                {
                    foreach (DataRow dr in dtGiaoVien.Rows)
                    {
                        if (bool.Parse(dr["Chon"].ToString()) == true)
                        {
                            ChuoiNS_GiaoVienID += dr["NS_GiaoVienID"].ToString() + ",";
                        }
                    }
                    if (ChuoiNS_GiaoVienID == "")
                        ThongBao("Bạn chưa chọn giáo viên nào.");
                    else
                    {
                        try
                        {
                            oBNS_GiaoVien.UpdateDanhSach(IDNS_DonVi, ChuoiNS_GiaoVienID.Substring(0, ChuoiNS_GiaoVienID.Length - 1));
                            this.Tag = "1";
                            this.Close();
                        }
                        catch (Exception ex1)
                        {
                            ThongBao(ex1.Message);
                        }

                    }
                }
                catch (Exception ex)
                {
                    ThongBao(ex.Message);
                }
            }
            else
            {
                ThongBao("Bạn chưa chọn đơn vị nào.");
                this.Tag = "";
                this.Close();
            }
        }        
    }
}