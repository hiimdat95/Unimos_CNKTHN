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
    public partial class frmCanhBaoHanNangLuongNghiHuu : frmBase
    {
        cBNS_Luong oBNS_Luong;
        cBNS_GiaoVien oBNS_GiaoVien;
        DataTable dtHanCanhBaoNangLuong, dtHanCanhBaoNghiHuu, dtHanCanhBaoHetNhiemKy;
        private string CanhBaoOnSelect = "CanhBaoHanNangLuong";

        public frmCanhBaoHanNangLuongNghiHuu()
        {
            oBNS_Luong = new cBNS_Luong();
            oBNS_GiaoVien = new cBNS_GiaoVien();
            InitializeComponent();
            dtpTinhDenNgay.EditValue = DateTime.Today;
        }

        private void grvCanhBaoHanNangLuong_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void Get_HanCanhBaoNangLuong()
        {
            if (cmbHanCanhBao.SelectedIndex != -1 && dtpTinhDenNgay.EditValue != null)
            {
                int HanCanhBao = cmbHanCanhBao.SelectedIndex + 1;
                DateTime TinhDenNgay = DateTime.Parse(dtpTinhDenNgay.EditValue.ToString());
                dtHanCanhBaoNangLuong = oBNS_Luong.Get_CanhBaoHanNangLuong(HanCanhBao, TinhDenNgay);
                grdCanhBaoHanNangLuong.DataSource = dtHanCanhBaoNangLuong;
            }
        }

        private void Get_HanCanhBaoNghiHuu()
        {
            if (cmbHanCanhBao.SelectedIndex != -1 && dtpTinhDenNgay.EditValue != null)
            {
                int HanCanhBao = cmbHanCanhBao.SelectedIndex + 1;
                DateTime TinhDenNgay = DateTime.Parse(dtpTinhDenNgay.EditValue.ToString());
                dtHanCanhBaoNghiHuu = oBNS_GiaoVien.Get_CanhBaoHanNghiHuu(HanCanhBao, TinhDenNgay);
                grdCanhBaoHanNghiHuu.DataSource = dtHanCanhBaoNghiHuu;
            }
        }

        private void Get_HanCanhBaoHetNhiemKy()
        {
            if (cmbHanCanhBao.SelectedIndex != -1 && dtpTinhDenNgay.EditValue != null)
            {
                int HanCanhBao = cmbHanCanhBao.SelectedIndex + 1;
                DateTime TinhDenNgay = DateTime.Parse(dtpTinhDenNgay.EditValue.ToString());
                dtHanCanhBaoHetNhiemKy = oBNS_GiaoVien.Get_CanhBaoHetNhiemKy(HanCanhBao, TinhDenNgay);
                grdCanhBaoHetNhiemKy.DataSource = dtHanCanhBaoHetNhiemKy;
            }
        }

        private void tabCanhBao_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tabCanhBao.SelectedTabPage == tabHanNangLuong)
            {
                CanhBaoOnSelect = "CanhBaoHanNangLuong";
            }
            if (tabCanhBao.SelectedTabPage == tabHanNghiHuu)
            {
                CanhBaoOnSelect = "CanhBaoHanNghiHuu";
            }
            if (tabCanhBao.SelectedTabPage == tabHetNhiemKy)
            {
                CanhBaoOnSelect = "CanhBaoHetNhiemKy";
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (CanhBaoOnSelect)
            {
                case "CanhBaoHanNangLuong":
                    {
                        Get_HanCanhBaoNangLuong();
                        break;
                    }
                case "CanhBaoHanNghiHuu":
                    {
                        Get_HanCanhBaoNghiHuu();
                        break;
                    }
                case "CanhBaoHetNhiemKy":
                    {
                        Get_HanCanhBaoHetNhiemKy();
                        break;
                    }
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            Lib.clsExportToExcel xls = new Lib.clsExportToExcel();
            xls.XtraGridTo(grvCanhBaoHanNghiHuu, 5, 1);
        }
    }
}