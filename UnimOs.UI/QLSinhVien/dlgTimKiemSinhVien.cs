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
    public partial class dlgTimKiemSinhVien : frmBase
    {
        private cBSV_SinhVien oBSV_SinhVien;
        private SV_SinhVienInfo pSV_SinhVienInfo;
        private int IDDM_Lop;
        private DataTable dtSinhVien,dtResult;

        public dlgTimKiemSinhVien( DataTable mdtSinhVien, int mIDDM_Lop)
        {
            InitializeComponent();
            pSV_SinhVienInfo = new SV_SinhVienInfo();
            oBSV_SinhVien = new cBSV_SinhVien();
            IDDM_Lop = mIDDM_Lop;
            dtSinhVien = mdtSinhVien;
            btnChon.Enabled = false;
            this.Tag = "";
        }

        private void dlgTimKiemSinhVien_Load(object sender, EventArgs e)
        {

        }

        private void grvGiaoVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnChon_Click(object sender, EventArgs e)
        {

            string ChuoiNS_SinhVienID = "";
            try
            {
                foreach (DataRow dr in dtResult.Rows)
                {
                    if (bool.Parse(dr["Chon"].ToString()) == true)
                    {
                        ChuoiNS_SinhVienID += dr["SV_SinhVienID"].ToString() + ",";
                    }
                }
                if (ChuoiNS_SinhVienID == "")
                    ThongBao("Bạn chưa chọn sinh viên nào.");
                else
                {
                    try
                    {
                        oBSV_SinhVien.UpdateDanhSach(IDDM_Lop, ChuoiNS_SinhVienID);
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if ((txtHoTen.Text.Trim() != "") || (txtMaSV.Text.Trim() != ""))
            {
                dtResult = new DataTable();
                pSV_SinhVienInfo.MaSinhVien = txtMaSV.Text.Trim();
                pSV_SinhVienInfo.HoVaTen = txtHoTen.Text.Trim();
                dtResult = oBSV_SinhVien.TimKiem(pSV_SinhVienInfo);
                if (dtResult != null)
                {
                    grdSinhVien.DataSource = dtResult;
                    if (dtResult.Rows.Count > 0)
                        btnChon.Enabled = true;
                    else
                        btnChon.Enabled = false;
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
    }
}