using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.wsBusiness;
using TruongViet.UnimOs.Entity;
using System.IO;

namespace UnimOs.Khoa
{
    public partial class frmGioGiangGiaoVienHeSoLopDong : frmBase
    {
        private cBwsGG_CongViecGiaoVien oBGG_CongViecGiaoVien;
        private GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo;
        private cBwsGG_GiangDayGiaoVien oBGG_GiangDayGiaoVien;
        private GG_GiangDayGiaoVienInfo pGG_GiangDayGiaoVienInfo;
        private DataTable dtGioGiang, dtHeSo;
        private DataRow drGioGiang;
        private DataRow[] arrDr;
        private bool Loaded = false;
        private int SoGioThucHanhTrongTuan, SoTietQuyDoiThucHanhTrongTuan;

        public frmGioGiangGiaoVienHeSoLopDong()
        {
            InitializeComponent();
            oBGG_CongViecGiaoVien = new cBwsGG_CongViecGiaoVien();
            pGG_CongViecGiaoVienInfo = new GG_CongViecGiaoVienInfo();
            oBGG_GiangDayGiaoVien = new cBwsGG_GiangDayGiaoVien();
            pGG_GiangDayGiaoVienInfo = new GG_GiangDayGiaoVienInfo();
            cmbDonVi.Properties.DataSource = LoadDonVi();
            // Thực hiện tính tổng theo group
            this.grvGioGiang.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TongTiet", this.grcTongTiet, "{0:#,##0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LyThuyet", this.grcLyThuyet, "{0:#,##0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThucHanh", this.grcThucHanh, "{0:#,##0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GioQuyChuan", this.grcGioChuan, "{0:#,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LyThuyetQuyChuan", this.grcLyThuyeQuyDoi, "{0:#,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThucHanhQuyChuan", this.grcThucHanhQuyDoi, "{0:#,##0.00}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "HeSoLopDong", this.grcHeSoLop, "{0:#,##0.00}")});

            cBwsHT_ThamSoHeThong oBHT_ThamSoHeThong = new cBwsHT_ThamSoHeThong();
            SoGioThucHanhTrongTuan = int.Parse(oBHT_ThamSoHeThong.GetGiaTriByMaThamSo("SoTietThucHanhTrong1Tuan"));
            SoTietQuyDoiThucHanhTrongTuan = int.Parse(oBHT_ThamSoHeThong.GetGiaTriByMaThamSo("SoTietQuyDoiThucHanhTrongTuan"));
        }

        private void frmGioGiangGiaoVienHeSoLopDong_Load(object sender, EventArgs e)
        {
            cBwsGG_HeSoLopDongTheoKhoa oBGG_HeSoLopDongTheoKhoa = new cBwsGG_HeSoLopDongTheoKhoa();
            dtHeSo = oBGG_HeSoLopDongTheoKhoa.Get(new GG_HeSoLopDongTheoKhoaInfo());
            cmbDonVi.EditValue = (new cBwsNS_DonVi()).GetByIDDM_Khoa(Program.objUserCurrent.IDDM_Khoa_GiaoVu);
            Loaded = true;
            LoadData();
        }

        private void cmbDonVi_EditValueChanged(object sender, EventArgs e)
        {
            if (Loaded)
                LoadData();
        }

        private void LoadData()
        {
            dtGioGiang = oBGG_CongViecGiaoVien.GetByHocKy(Program.IDNamHoc, Program.HocKy, 
                cmbDonVi.EditValue == null ? 0 : int.Parse(cmbDonVi.EditValue.ToString()));
            DataView dv = new DataView(dtGioGiang);
            dv.Sort = "NS_GiaoVienID, wTYPE DESC";
            dtGioGiang = dv.ToTable();
            foreach (DataRow dr in dtGioGiang.Rows)
            {
                TinhGioChuan(dr);
            }
            grdGioGiang.DataSource = dtGioGiang;
        }

        private void TinhGioChuan(DataRow dr)
        {
            double SoGioChuanLT = 0, SoGioChuanTH = 0, HeSoLopDong = 0;
            if (dr["wTYPE"].ToString() == "GD")
            {
                if ((int)dr["SoSinhVien"] == 45)
                    SoGioChuanLT = 0;
                dr["HeSo"] = DBNull.Value;
                // Tim he so ly thuyet
                arrDr = dtHeSo.Select("IDDM_TrinhDo = " + dr["IDDM_TrinhDo"] + " And IDDM_Khoa = " + dr["IDDM_Khoa"] + 
                    " And LoaiGiangDay = 'LY_THUYET'");
                if (arrDr.Length > 0)
                {
                    SoGioChuanLT = TinhQuyChuan(arrDr[0], int.Parse("0" + dr["LyThuyet"]), (int)dr["SoSinhVien"], ref HeSoLopDong);
                    dr["LyThuyetQuyChuan"] = SoGioChuanLT; 
                }
                arrDr = dtHeSo.Select("IDDM_TrinhDo = " + dr["IDDM_TrinhDo"] + " And IDDM_Khoa = " + dr["IDDM_Khoa"] + 
                    " And LoaiGiangDay = 'THUC_HANH'");
                if (arrDr.Length > 0)
                {
                    SoGioChuanTH = TinhQuyChuanTH(arrDr[0], int.Parse("0" + dr["ThucHanh"]), 
                        int.Parse(dr["SoNhom"].ToString()), (int)dr["SoSinhVien"], ref HeSoLopDong);
                    dr["ThucHanhQuyChuan"] = SoGioChuanTH;
                }
                if (HeSoLopDong > 0)
                    dr["HeSoLopDong"] = Math.Round(HeSoLopDong, 2, MidpointRounding.AwayFromZero);
                dr["GioQuyChuan"] = Math.Round(SoGioChuanLT + SoGioChuanTH + HeSoLopDong, 2, MidpointRounding.AwayFromZero);
            }
            else if (dr["wTYPE"].ToString() == "CVK")
            {
                dr["GioQuyChuan"] = Math.Round(double.Parse("0" + dr["TongTiet"]) * double.Parse("0" + dr["HeSo"]), 2, MidpointRounding.AwayFromZero);
            }
        }

        private double TinhQuyChuan(DataRow drHeSo, int SoTiet, int SoSinhVien, ref double HeSoLopDong)
        {
            double SoGioQuyChuan = 0;
            if (SoSinhVien <= (int)drHeSo["SoSVToiDa"])
                SoGioQuyChuan = (double)drHeSo["HeSoQuyChuan"] * SoTiet;
            else
            {
                SoGioQuyChuan = (double)drHeSo["HeSoQuyChuan"] * SoTiet;
                HeSoLopDong += (double)drHeSo["HeSoQuyChuan"] * (((double)(SoSinhVien - (int)drHeSo["SoSVToiDa"]) / 
                    (int)drHeSo["SoCongThem1Tiet"]) * (SoTiet / (double)drHeSo["SoTietDinhMuc1Tuan"]));
            }
            return Math.Round(SoGioQuyChuan, 2, MidpointRounding.AwayFromZero);
        }

        private double TinhQuyChuanTH(DataRow drHeSo, int SoTiet, int SoNhom, int SoSinhVien, ref double HeSoLopDong)
        {
            double SoGioQuyChuan = 0;
            int[] arrNhom = new int[SoNhom];
            int k = 0;
            while (SoNhom > 0)
            {
                arrNhom[k] = SoSinhVien / SoNhom;
                SoSinhVien -= arrNhom[k];
                k++;
                SoNhom--;
            }
            foreach (int SoSV in arrNhom)
            {
                if (SoSV <= (int)drHeSo["SoSVToiDa"])
                    SoGioQuyChuan += (double)drHeSo["HeSoQuyChuan"] * (SoTiet * SoTietQuyDoiThucHanhTrongTuan / SoGioThucHanhTrongTuan);
                else
                {
                    SoGioQuyChuan += (double)drHeSo["HeSoQuyChuan"] * (SoTiet * SoTietQuyDoiThucHanhTrongTuan / SoGioThucHanhTrongTuan);
                    HeSoLopDong += (double)drHeSo["HeSoQuyChuan"] * (((double)(SoSV - (int)drHeSo["SoSVToiDa"]) /
                        (int)drHeSo["SoCongThem1Tiet"]) * ((SoTiet * SoTietQuyDoiThucHanhTrongTuan / SoGioThucHanhTrongTuan) /
                        (double)drHeSo["SoTietDinhMuc1Tuan"]));
                }
            }
            return Math.Round(SoGioQuyChuan, 2, MidpointRounding.AwayFromZero);
        }

        private void grvGioGiang_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            drGioGiang = grvGioGiang.GetDataRow(grvGioGiang.FocusedRowHandle);
            TinhGioChuan(drGioGiang);
        }

        private void btnInBangTongHop_Click(object sender, EventArgs e)
        {
            if (cmbDonVi.EditValue != null)
            {
                DataTable dt = oBGG_GiangDayGiaoVien.GetBangTongHop((int)cmbDonVi.EditValue, cmbDonVi.Text, 
                    Program.IDNamHoc, Program.NamHoc, Program.HocKy);
                frmReport frm = new frmReport(dt, "rTongHopGioGiang_BangTongHop");
                frm.ShowDialog();
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToXls(grvGioGiang, "GioGiangGiaoVien_HK" + Program.HocKy.ToString() + "_NamHoc" + Program.NamHoc);
        }

        private void GetpGiangDayGiaoVienInfo(DataRow dr)
        {
            pGG_GiangDayGiaoVienInfo = new GG_GiangDayGiaoVienInfo();
            pGG_GiangDayGiaoVienInfo.IDNS_GiaoVien = int.Parse(dr["NS_GiaoVienID"].ToString());
            pGG_GiangDayGiaoVienInfo.IDXL_MonHocTrongKy = long.Parse(dr["XL_MonHocTrongKyID"].ToString());
            pGG_GiangDayGiaoVienInfo.IDDM_NamHoc = Program.IDNamHoc;
            pGG_GiangDayGiaoVienInfo.HocKy = Program.HocKy;
            if ("" + dr["SoSinhVien"] != "")
                pGG_GiangDayGiaoVienInfo.SoSinhVien = int.Parse(dr["SoSinhVien"].ToString());
            if ("" + dr["LyThuyet"] != "")
                pGG_GiangDayGiaoVienInfo.LyThuyet = int.Parse(dr["LyThuyet"].ToString());
            if ("" + dr["LyThuyetQuyChuan"] != "")
                pGG_GiangDayGiaoVienInfo.LyThuyetQuyChuan = double.Parse(dr["LyThuyetQuyChuan"].ToString());
            if ("" + dr["ThucHanh"] != "")
                pGG_GiangDayGiaoVienInfo.ThucHanh = int.Parse(dr["ThucHanh"].ToString());
            if ("" + dr["SoNhom"] != "")
                pGG_GiangDayGiaoVienInfo.SoNhom = int.Parse(dr["SoNhom"].ToString());
            if ("" + dr["ThucHanhQuyChuan"] != "")
                pGG_GiangDayGiaoVienInfo.ThucHanhQuyChuan = double.Parse(dr["ThucHanhQuyChuan"].ToString());
            if ("" + dr["HeSoLopDong"] != "")
                pGG_GiangDayGiaoVienInfo.HeSoLopDong = double.Parse(dr["HeSoLopDong"].ToString());
            pGG_GiangDayGiaoVienInfo.SoGioChuan = double.Parse(dr["GioQuyChuan"].ToString());
            pGG_GiangDayGiaoVienInfo.GhiChu = "" + dr["GhiChu"];
        }

        private void GetpCongViecGiaoVienInfo(DataRow dr)
        {
            pGG_CongViecGiaoVienInfo = new GG_CongViecGiaoVienInfo();
            pGG_CongViecGiaoVienInfo.IDNS_GiaoVien = int.Parse(dr["NS_GiaoVienID"].ToString());
            pGG_CongViecGiaoVienInfo.IDDM_LoaiCongViec = int.Parse(dr["DM_LoaiCongViecID"].ToString());
            pGG_CongViecGiaoVienInfo.IDDM_NamHoc = Program.IDNamHoc;
            pGG_CongViecGiaoVienInfo.HocKy = Program.HocKy;
            if ("" + dr["TongTiet"] != "")
                pGG_CongViecGiaoVienInfo.SoGio = double.Parse(dr["TongTiet"].ToString());
            if ("" + dr["HeSo"] != "")
            pGG_CongViecGiaoVienInfo.HeSo = double.Parse(dr["HeSo"].ToString());
            pGG_CongViecGiaoVienInfo.GioQuyChuan = double.Parse(dr["GioQuyChuan"].ToString());
            pGG_CongViecGiaoVienInfo.GhiChu = "" + dr["GhiChu"];
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dtGioGiang == null || dtGioGiang.Rows.Count <= 0)
                return;
            int intErr = 0;
            string NS_GiaoVienID = dtGioGiang.Rows[0]["NS_GiaoVienID"].ToString(), IDGGNotIn = "", IDCVNotIn = "";
            foreach(DataRow dr in dtGioGiang.Rows)
            {
                if (NS_GiaoVienID != dr["NS_GiaoVienID"].ToString())
                {
                    if (IDGGNotIn == "")
                    {
                        IDGGNotIn = ",0";
                    }
                    oBGG_GiangDayGiaoVien.DeleteNotIn(int.Parse(NS_GiaoVienID), Program.IDNamHoc, Program.HocKy, IDGGNotIn.Substring(1));

                    if (IDCVNotIn == "")
                    {
                        IDCVNotIn = ",0";
                    }
                    oBGG_CongViecGiaoVien.DeleteNotIn(int.Parse(NS_GiaoVienID), Program.IDNamHoc, Program.HocKy, IDCVNotIn.Substring(1));

                    NS_GiaoVienID = dr["NS_GiaoVienID"].ToString();
                    IDGGNotIn = "";
                    IDCVNotIn = "";
                }
                if ("" + dr["GioQuyChuan"] != "")
                {
                    if (double.Parse(dr["GioQuyChuan"].ToString()) > 0)
                    {
                        try
                        {
                            if (dr["wTYPE"].ToString() == "GD")
                            {
                                GetpGiangDayGiaoVienInfo(dr);
                                pGG_GiangDayGiaoVienInfo.GG_GiangDayGiaoVienID = oBGG_GiangDayGiaoVien.UpdateAdd(pGG_GiangDayGiaoVienInfo);
                                IDGGNotIn += "," + pGG_GiangDayGiaoVienInfo.GG_GiangDayGiaoVienID.ToString();
                            }
                            else if (dr["wTYPE"].ToString() == "CVK")
                            {
                                GetpCongViecGiaoVienInfo(dr);
                                pGG_CongViecGiaoVienInfo.GG_CongViecGiaoVienID = oBGG_CongViecGiaoVien.UpdateAdd(pGG_CongViecGiaoVienInfo);
                                IDCVNotIn += "," + pGG_CongViecGiaoVienInfo.GG_CongViecGiaoVienID.ToString();
                            }
                        }
                        catch
                        {
                            intErr++;
                        }
                    }
                }
            }
            // Xoa du lieu thua
            if (IDGGNotIn == "")
            {
                IDGGNotIn = ",0";
            }
            oBGG_GiangDayGiaoVien.DeleteNotIn(int.Parse(NS_GiaoVienID), Program.IDNamHoc, Program.HocKy, IDGGNotIn.Substring(1));

            if (IDCVNotIn == "")
            {
                IDCVNotIn = ",0";
            }
            oBGG_CongViecGiaoVien.DeleteNotIn(int.Parse(NS_GiaoVienID), Program.IDNamHoc, Program.HocKy, IDCVNotIn.Substring(1));
            

            if (intErr > 0)
                ThongBao("Dữ liệu trên " + intErr.ToString() + " dòng cập nhật không thành công.");
            else
                ThongBao("Cập nhật dữ liệu thành công.");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbDonVi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbDonVi.EditValue = null;
        }

        #region Xuất chi tiết giờ giảng ra Excel
        private void btnXuatTemplate_Click(object sender, EventArgs e)
        {
            if (dtGioGiang == null || dtGioGiang.Rows.Count == 0)
            {
                ThongBao("Không có dữ liệu để xuất ra excel!");
                return;
            }
            XuatChiTietGioGiang();
        }

        private void XuatChiTietGioGiang()
        {
            string strFileExcel = Application.StartupPath + "\\Template\\Temp_TongHopGioGiang_HSL_ChiTiet.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + "! Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                return;
            }

            SaveFileDialog sv = new SaveFileDialog();
            sv.FileName = "GioGiang_" + (new Lib.clsVietToEn()).ConvertVietToEn(cmbDonVi.Text) + 
                "_Nam" + Program.NamHoc + "_HK" + Program.HocKy.ToString() + ".xls";
            sv.Filter = "Excel file (*.xls)|*.xls";
            sv.Title = "Xuất dữ liệu";
            if (sv.ShowDialog() == DialogResult.OK)
            {
                string strTenFileExcelMoi = sv.FileName;
                try
                {
                    File.Copy(strFileExcel, strTenFileExcelMoi, true);
                }
                catch (Exception ex)
                {
                    ThongBaoLoi("File excel đang được mở. Đề nghị đóng file này trước khi xuất dữ liệu! Thông báo lỗi: " + ex.Message);
                    return;
                }
                finally { }
                DataView dv = new DataView(dtGioGiang);
                dv.RowFilter = "wType = 'GD' OR (wType = 'CVK' And GioQuyChuan > 0)";
                if (dv.Count > 0)
                {
                    dv.Sort = "KhoaDonVi DESC, Ten, HoTen, MaGiaoVien";
                    DataTable dt = dv.ToTable();
                    XuatChiTietGioGiangRaExcel(dt, strTenFileExcelMoi);
                    ThongBao("Xuất dữ liệu thành công!");
                }
                else
                    ThongBao("Không có dữ liệu để xuất Excel.");
            }
        }

        private void ThuocTrinhDo(string IDDM_TrinhDo, double SoTiet, ref double SoTietCD, ref double SoTietTC)
        {
            if (IDDM_TrinhDo == "1" || IDDM_TrinhDo == "2" || IDDM_TrinhDo == "3")
                SoTietCD += SoTiet;
            else if(IDDM_TrinhDo == "4" || IDDM_TrinhDo == "5")
                SoTietTC += SoTiet;
        }

        private void XuatChiTietGioGiangRaExcel(DataTable dtChiTiet, string FileExcel)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int DongBatDau = 7, DongKetThuc = DongBatDau, STT = 1;
            double SoTietTC = 0, SoTietCD = 0, TongThucHien = 0, DinhMuc = 0;
            bool IsDaThemDong = false;
            Excel.Range cel;
            
            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);
                
                DataTable dtDinhMuc = (new cBwsGG_DinhMucGioDay()).GetByIDNS_DonVi((int)cmbDonVi.EditValue, Program.IDNamHoc, Program.HocKy);
                
                // Ten don vi
                excel.Cells[4, 1] = cmbDonVi.Text.ToUpper();
                // Năm học, học kỳ
                excel.Cells[5, 1] = "HỌC KỲ " + Program.HocKy.ToString() + " NĂM HỌC " + Program.NamHoc;

                Lib.clsDataTableHelper clsDt = new Lib.clsDataTableHelper();
                DataTable dtGV = clsDt.SelectDistinct(dtChiTiet, new string[] { "Ten", "HoTen", "NS_GiaoVienID" }, new string[] { "KhoaDonVi" });
                DataView dv = new DataView(dtGV);
                dv.Sort = "KhoaDonVi DESC, Ten, HoTen";
                dtGV = dv.ToTable();
                DataRow[] arrDr;
                string IDNS_GiaoVien = dtGV.Rows[0]["NS_GiaoVienID"].ToString();
                arrDr = dtDinhMuc.Select("IDNS_GiaoVien = " + dtGV.Rows[0]["NS_GiaoVienID"]);
                DinhMuc = (arrDr.Length <= 0 ? 0 : double.Parse(arrDr[0]["SoGioDinhMuc"].ToString()));
                // Them dong moi
                cel = (Excel.Range)(excel.Cells[DongBatDau + 1, 1]);
                cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                IsDaThemDong = true;
                excel.Cells[DongKetThuc, 1] = STT.ToString();
                STT++;
                excel.Cells[DongKetThuc, 2] = dtGV.Rows[0]["HoTen"].ToString();

                foreach (DataRow dr in dtGV.Rows)
                {
                    if (IDNS_GiaoVien != dr["NS_GiaoVienID"].ToString())
                    {
                        // Gan gia tri cho row dau tien cua giao vien
                        excel.Cells[DongBatDau, 12] = SoTietTC;
                        excel.Cells[DongBatDau, 13] = SoTietCD;
                        excel.Cells[DongBatDau, 14] = DinhMuc;
                        excel.Cells[DongBatDau, 15] = TongThucHien;
                        if (DinhMuc - TongThucHien < 0)
                            excel.Cells[DongBatDau, 16] = TongThucHien - DinhMuc;
                        else
                            excel.Cells[DongBatDau, 17] = DinhMuc - TongThucHien;
                        // Merge va border cac dong trong cac cot
                        cel = excel.get_Range(excel.Cells[DongBatDau, 1], excel.Cells[DongKetThuc - 1, 1]);
                        cel.Merge(null);
                        cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        cel.VerticalAlignment = Excel.XlVAlign.xlVAlignTop;

                        cel = excel.get_Range(excel.Cells[DongBatDau, 2], excel.Cells[DongKetThuc - 1, 2]);
                        cel.Merge(null);
                        cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        cel.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        cel = excel.get_Range(excel.Cells[DongBatDau, 2], excel.Cells[DongKetThuc - 1, 2]);
                        cel.Merge(null);
                        cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        cel.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                        for (int j = 12; j <= 17; j++)
                        {
                            cel = excel.get_Range(excel.Cells[DongBatDau, j], excel.Cells[DongKetThuc - 1, j]);
                            cel.Merge(null);
                            cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                            cel.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        }
                        // Them dong moi cho giao vien moi
                        cel = (Excel.Range)(excel.Cells[DongKetThuc + 1, 1]);
                        cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                        IsDaThemDong = true;

                        IDNS_GiaoVien = dr["NS_GiaoVienID"].ToString();
                        DongBatDau = DongKetThuc;
                        SoTietTC = 0;
                        SoTietCD = 0;
                        TongThucHien = 0;
                        arrDr = dtDinhMuc.Select("IDNS_GiaoVien = " + IDNS_GiaoVien);
                        DinhMuc = (arrDr.Length <= 0 ? 0 : double.Parse(arrDr[0]["SoGioDinhMuc"].ToString()));
                        excel.Cells[DongKetThuc, 1] = STT.ToString();
                        STT++;
                        excel.Cells[DongKetThuc, 2] = dr["HoTen"].ToString();
                    }

                    arrDr = dtChiTiet.Select("NS_GiaoVienID = " + IDNS_GiaoVien + " And wType = 'GD'");
                    if (arrDr.Length > 0)
                    {
                        for (int j = 0; j < arrDr.Length; j++)
                        {
                            if (!IsDaThemDong)
                            {
                                cel = (Excel.Range)(excel.Cells[DongKetThuc + 1, 1]);
                                cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                            }
                            excel.Cells[DongKetThuc, 3] = arrDr[j]["TenMonHoc"];
                            
                            excel.Cells[DongKetThuc, 4] = arrDr[j]["TenLop"] + " (" + arrDr[j]["SoSinhVien"] + ")";

                            if (double.Parse("0" + arrDr[j]["LyThuyet"]) > 0)
                            {
                                excel.Cells[DongKetThuc, 5] = arrDr[j]["LyThuyet"];
                                ThuocTrinhDo(arrDr[j]["IDDM_TrinhDo"].ToString(), double.Parse(arrDr[j]["LyThuyet"].ToString()),
                                    ref SoTietCD, ref SoTietTC);
                            }
                            
                            cel = (Excel.Range)(excel.Cells[DongKetThuc, 6]);
                            if (double.Parse("0" + arrDr[j]["LyThuyetQuyChuan"]) > 0)
                            {
                                excel.Cells[DongKetThuc, 6] = arrDr[j]["LyThuyetQuyChuan"];
                                cel.NumberFormat = "#,##0.00";
                            }
                            cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                            if (double.Parse("0" + arrDr[j]["ThucHanh"]) > 0)
                            {
                                excel.Cells[DongKetThuc, 7] = arrDr[j]["ThucHanh"];
                                ThuocTrinhDo(arrDr[j]["IDDM_TrinhDo"].ToString(), 
                                    double.Parse(arrDr[j]["ThucHanh"].ToString()) * SoTietQuyDoiThucHanhTrongTuan / SoGioThucHanhTrongTuan,
                                    ref SoTietCD, ref SoTietTC);
                                excel.Cells[DongKetThuc, 8] = arrDr[j]["SoNhom"];
                            }

                            cel = (Excel.Range)(excel.Cells[DongKetThuc, 9]);
                            if (double.Parse("0" + arrDr[j]["ThucHanhQuyChuan"]) > 0)
                            {
                                excel.Cells[DongKetThuc, 9] = arrDr[j]["ThucHanhQuyChuan"];
                                cel.NumberFormat = "#,##0.00";
                            }
                            cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                            cel = (Excel.Range)(excel.Cells[DongKetThuc, 10]);
                            if (double.Parse("0" + arrDr[j]["HeSoLopDong"]) > 0)
                            {
                                excel.Cells[DongKetThuc, 10] = arrDr[j]["HeSoLopDong"];
                                cel.NumberFormat = "#,##0.00";
                            }
                            cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                            cel = (Excel.Range)(excel.Cells[DongKetThuc, 11]);
                            if (double.Parse("0" + arrDr[j]["GioQuyChuan"]) > 0)
                            {
                                excel.Cells[DongKetThuc, 11] = arrDr[j]["GioQuyChuan"];
                                cel.NumberFormat = "#,##0.00";
                            }
                            cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            TongThucHien += double.Parse(arrDr[j]["GioQuyChuan"].ToString());

                            IsDaThemDong = false;
                            DongKetThuc++;
                        }
                    }

                    arrDr = dtChiTiet.Select("NS_GiaoVienID = " + IDNS_GiaoVien + " And wType = 'CVK'");
                    if (arrDr.Length > 0)
                    {
                        for (int j = 0; j < arrDr.Length; j++)
                        {
                            if (!IsDaThemDong)
                            {
                                cel = (Excel.Range)(excel.Cells[DongKetThuc + 1, 1]);
                                cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                            }

                            excel.Cells[DongKetThuc, 3] = arrDr[j]["TenMonHoc"];
                            excel.Cells[DongKetThuc, 4] = arrDr[j]["GhiChu"];

                            cel = (Excel.Range)(excel.Cells[DongKetThuc, 11]);
                            excel.Cells[DongKetThuc, 11] = arrDr[j]["GioQuyChuan"];
                            cel.NumberFormat = "#,##0.00";
                            cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            SoTietCD += double.Parse(arrDr[j]["GioQuyChuan"].ToString());
                            TongThucHien += double.Parse(arrDr[j]["GioQuyChuan"].ToString());

                            IsDaThemDong = false;
                            DongKetThuc++;
                        }
                    }
                }
                // Gan gia tri cho row dau tien cua giao vien cuối cùng
                excel.Cells[DongBatDau, 12] = SoTietTC;
                excel.Cells[DongBatDau, 13] = SoTietCD;
                excel.Cells[DongBatDau, 14] = DinhMuc;
                excel.Cells[DongBatDau, 15] = TongThucHien;
                if (DinhMuc - TongThucHien < 0)
                    excel.Cells[DongBatDau, 16] = TongThucHien - DinhMuc;
                else
                    excel.Cells[DongBatDau, 17] = DinhMuc - TongThucHien;
                
                // Thêm dòng tổng hợp vào cuối cùng
                cel = (Excel.Range)(excel.Cells[DongKetThuc + 1, 1]);
                cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                DinhMuc = double.Parse("0" + dtDinhMuc.Compute("Sum(SoGioDinhMuc)", ""));
                TongThucHien = double.Parse("0"+dtChiTiet.Compute("Sum(GioQuyChuan)", ""));
                excel.Cells[DongKetThuc, 14] = DinhMuc;
                cel = (Excel.Range)(excel.Cells[DongKetThuc, 14]);
                cel.NumberFormat = "#,##0.00";
                cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                excel.Cells[DongKetThuc, 15] = TongThucHien;
                cel = (Excel.Range)(excel.Cells[DongKetThuc, 15]);
                cel.NumberFormat = "#,##0.00";
                cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                if (DinhMuc - TongThucHien < 0)
                {
                    excel.Cells[DongKetThuc, 16] = TongThucHien - DinhMuc;
                    cel = (Excel.Range)(excel.Cells[DongKetThuc, 16]);
                    cel.NumberFormat = "#,##0.00";
                    cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }
                else
                {
                    excel.Cells[DongKetThuc, 17] = DinhMuc - TongThucHien;
                    cel = (Excel.Range)(excel.Cells[DongKetThuc, 17]);
                    cel.NumberFormat = "#,##0.00";
                    cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }
                cel = excel.get_Range(excel.Cells[DongKetThuc, 1], excel.Cells[DongKetThuc, 13]);
                cel.Merge(null);
                cel = excel.get_Range(excel.Cells[DongKetThuc, 1], excel.Cells[DongKetThuc, 17]);
                cel.Borders.Value = 1;

                // Merge va border cac dong trong cac cot
                cel = excel.get_Range(excel.Cells[DongBatDau, 1], excel.Cells[DongKetThuc - 1, 1]);
                cel.Merge(null);
                cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                cel.VerticalAlignment = Excel.XlVAlign.xlVAlignTop;

                cel = excel.get_Range(excel.Cells[DongBatDau, 2], excel.Cells[DongKetThuc - 1, 2]);
                cel.Merge(null);
                cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                cel.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                cel = excel.get_Range(excel.Cells[DongBatDau, 2], excel.Cells[DongKetThuc - 1, 2]);
                cel.Merge(null);
                cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                cel.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                for (int j = 12; j <= 17; j++)
                {
                    cel = excel.get_Range(excel.Cells[DongBatDau, j], excel.Cells[DongKetThuc - 1, j]);
                    cel.Merge(null);
                    cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    cel.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                }
                cel = excel.get_Range(excel.Cells[7, 1], excel.Cells[DongKetThuc - 1, 17]);
                cel.Borders.Value = 1;

                excel.Application.Workbooks[1].Save();
                excel.Visible = true;
                //Process.Start(FileExcel);
            }
            catch (Exception e)
            {
                excel.Application.Workbooks[1].Save();
                this.Cursor = System.Windows.Forms.Cursors.Default;
                excel.Application.Workbooks.Close();
                excel.Application.Quit();
                excel.Quit();
                ThongBaoLoi("Xuất dữ liệu không thành công! Hãy đóng các file Excel trước khi xuất dữ liệu. Thông báo lỗi: " + e.Message);
                CloseWaitDialog();
                this.Cursor = System.Windows.Forms.Cursors.Default;
                return;
            }
            finally
            {
                CloseWaitDialog();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
        #endregion
    }
}
