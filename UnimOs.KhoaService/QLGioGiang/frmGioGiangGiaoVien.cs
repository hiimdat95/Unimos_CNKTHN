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
    public partial class frmGioGiangGiaoVien : frmBase
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

        public frmGioGiangGiaoVien()
        {
            InitializeComponent();
            oBGG_CongViecGiaoVien = new cBwsGG_CongViecGiaoVien();
            pGG_CongViecGiaoVienInfo = new GG_CongViecGiaoVienInfo();
            oBGG_GiangDayGiaoVien = new cBwsGG_GiangDayGiaoVien();
            pGG_GiangDayGiaoVienInfo = new GG_GiangDayGiaoVienInfo();
            cmbDonVi.Properties.DataSource = LoadDonVi();
            // Thực hiện tính tổng theo group
            this.grvGioGiang.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TongTiet", this.grcTongTiet, "{0:#,###}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LyThuyet", this.grcLyThuyet, "{0:#,###}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThucHanh", this.grcThucHanh, "{0:#,###}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GioQuyChuan", this.grcGioChuan, "{0:#,###.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LyThuyetQuyDoi", this.grcLyThuyeQuyDoi, "{0:#,###.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThucHanhQuyDoi", this.grcThucHanhQuyDoi, "{0:#,###.##}")});

            cBwsHT_ThamSoHeThong oBHT_ThamSoHeThong = new cBwsHT_ThamSoHeThong();
            SoGioThucHanhTrongTuan = int.Parse(oBHT_ThamSoHeThong.GetGiaTriByMaThamSo("SoTietThucHanhTrong1Tuan"));
            SoTietQuyDoiThucHanhTrongTuan = int.Parse(oBHT_ThamSoHeThong.GetGiaTriByMaThamSo("SoTietQuyDoiThucHanhTrongTuan"));
        }

        private void frmGioGiangGiaoVien_Load(object sender, EventArgs e)
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
            foreach (DataRow dr in dtGioGiang.Rows)
            {
                TinhGioChuan(dr);
            }
            grdGioGiang.DataSource = dtGioGiang;
        }

        private void TinhGioChuan(DataRow dr)
        {
            double SoGioChuanLT = 0, SoGioChuanTH = 0;
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
                    SoGioChuanLT = TinhQuyChuan(arrDr[0], int.Parse("0" + dr["LyThuyet"]), (int)dr["SoSinhVien"]);
                    dr["LyThuyetQuyChuan"] = SoGioChuanLT; 
                }
                arrDr = dtHeSo.Select("IDDM_TrinhDo = " + dr["IDDM_TrinhDo"] + " And IDDM_Khoa = " + dr["IDDM_Khoa"] + 
                    " And LoaiGiangDay = 'THUC_HANH'");
                if (arrDr.Length > 0)
                {
                    SoGioChuanTH = TinhQuyChuanTH(arrDr[0], int.Parse("0" + dr["ThucHanh"]), int.Parse(dr["SoNhom"].ToString()), (int)dr["SoSinhVien"]);
                    dr["ThucHanhQuyChuan"] = SoGioChuanTH;
                }

                dr["GioQuyChuan"] = SoGioChuanLT + SoGioChuanTH;
            }
            else if (dr["wTYPE"].ToString() == "CVK")
            {
                dr["GioQuyChuan"] = double.Parse("0" + dr["TongTiet"]) * double.Parse("0" + dr["HeSo"]);
            }
        }

        private double TinhQuyChuan(DataRow drHeSo, int SoTiet, int SoSinhVien)
        {
            double SoGioQuyChuan = 0;
            if (SoSinhVien <= (int)drHeSo["SoSVToiDa"])
                SoGioQuyChuan = (double)drHeSo["HeSoQuyChuan"] * SoTiet;
            else
            {
                SoGioQuyChuan = (double)drHeSo["HeSoQuyChuan"] *
                    (SoTiet + (((double)(SoSinhVien - (int)drHeSo["SoSVToiDa"]) /
                    (int)drHeSo["SoCongThem1Tiet"]) * (SoTiet / (double)drHeSo["SoTietDinhMuc1Tuan"])));
            }
            return Math.Round(SoGioQuyChuan, 2, MidpointRounding.AwayFromZero);
        }

        private double TinhQuyChuanTH(DataRow drHeSo, int SoTiet, int SoNhom, int SoSinhVien)
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
                    SoGioQuyChuan += (double)drHeSo["HeSoQuyChuan"] *
                        (SoTiet + (((double)(SoSV - (int)drHeSo["SoSVToiDa"]) /
                        (int)drHeSo["SoCongThem1Tiet"]) * ((SoTiet * SoTietQuyDoiThucHanhTrongTuan / SoGioThucHanhTrongTuan) / 
                        (double)drHeSo["SoTietDinhMuc1Tuan"])));
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
            int intErr = 0;
            foreach(DataRow dr in dtGioGiang.Rows)
            {
                if ("" + dr["GioQuyChuan"] != "")
                {
                    if (double.Parse(dr["GioQuyChuan"].ToString()) > 0)
                    {
                        try
                        {
                            if (dr["wTYPE"].ToString() == "GD")
                            {
                                GetpGiangDayGiaoVienInfo(dr);
                                oBGG_GiangDayGiaoVien.UpdateAdd(pGG_GiangDayGiaoVienInfo);
                            }
                            else if (dr["wTYPE"].ToString() == "CVK")
                            {
                                GetpCongViecGiaoVienInfo(dr);
                                oBGG_CongViecGiaoVien.UpdateAdd(pGG_CongViecGiaoVienInfo);
                            }
                        }
                        catch
                        {
                            intErr++;
                        }
                    }
                }
            }
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
            string strFileExcel = Application.StartupPath + "\\Template\\Temp_TongHopGioGiang_ChiTiet.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + "! Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                return;
            }

            SaveFileDialog sv = new SaveFileDialog();
            sv.FileName = "GioGiang_" + (new Lib.clsVietToEn()).ConvertVietToEn(cmbDonVi.Text) + ".xls";
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
                dv.Sort = "Ten, HoTen";
                DataTable dt = dv.ToTable();
                XuatDanhSachDuThiRaExcel(dt, strTenFileExcelMoi);
                ThongBao("Xuất dữ liệu thành công!");
            }
        }

        private void XuatDanhSachDuThiRaExcel(DataTable dtChiTiet, string FileExcel)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int DongBatDau = 6, i = 0;
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
                DataTable dtGV = clsDt.SelectDistinct(dtChiTiet, new string[] { "Ten", "HoTen", "NS_GiaoVienID" });
                DataRow[] arrDr;
                double SoGioThucHien = 0;
                foreach (DataRow dr in dtGV.Rows)
                {
                    SoGioThucHien = 0;
                    cel = (Excel.Range)(excel.Cells[DongBatDau + i + 1, 1]);
                    cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                    i++;
                    cel = (Excel.Range)(excel.Cells[DongBatDau + i + 1, 1]);
                    cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                    excel.Cells[DongBatDau + i, 1] = "Giảng viên: " + dr["HoTen"];
                    cel = excel.get_Range(excel.Cells[DongBatDau + i, 1], excel.Cells[DongBatDau + i, 5]);
                    cel.Merge(null);
                    cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    i++;
                    arrDr = dtChiTiet.Select("NS_GiaoVienID = " + dr["NS_GiaoVienID"] + " And wType = 'CVK'");
                    if (arrDr.Length > 0)
                    {
                        // Thêm dòng công việc thực hiện
                        cel = (Excel.Range)(excel.Cells[DongBatDau + i + 1, 1]);
                        cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                        excel.Cells[DongBatDau + i, 2] = "'- Công việc thực hiện";
                        cel = excel.get_Range(excel.Cells[DongBatDau + i, 2], excel.Cells[DongBatDau + i, 5]);
                        cel.Merge(null);
                        cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        cel.Font.Bold = false;
                        i++;
                        // Thêm phần tiêu đề bảng
                        cel = (Excel.Range)(excel.Cells[DongBatDau + i + 1, 1]);
                        cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                        excel.Cells[DongBatDau + i, 1] = "TT";
                        
                        excel.Cells[DongBatDau + i, 2] = "Tên công việc";
                        cel = excel.get_Range(excel.Cells[DongBatDau + i, 2], excel.Cells[DongBatDau + i, 4]);
                        cel.Merge(null);
                        cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        
                        excel.Cells[DongBatDau + i, 5] = "Số giờ";
                        cel = excel.get_Range(excel.Cells[DongBatDau + i, 5], excel.Cells[DongBatDau + i, 6]);
                        cel.Merge(null);
                        cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        
                        excel.Cells[DongBatDau + i, 7] = "Hệ số";
                        cel = excel.get_Range(excel.Cells[DongBatDau + i, 7], excel.Cells[DongBatDau + i, 8]);
                        cel.Merge(null);
                        cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        excel.Cells[DongBatDau + i, 9] = "Giờ quy chuẩn";
                        cel = (Excel.Range)(excel.Cells[DongBatDau + i, 9]);
                        cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        excel.Cells[DongBatDau + i, 10] = "Ghi chú";
                        cel = excel.get_Range(excel.Cells[DongBatDau + i, 10], excel.Cells[DongBatDau + i, 11]);
                        cel.Merge(null);
                        cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        
                        cel = excel.get_Range(excel.Cells[DongBatDau + i, 1], excel.Cells[DongBatDau + i, 11]);
                        cel.Font.Bold = true;
                        cel.RowHeight = 35.25;
                        cel.Borders.Value = 1;
                        i++;
                        for (int j = 0; j < arrDr.Length; j++)
                        {
                            cel = (Excel.Range)(excel.Cells[DongBatDau + j + i + 1, 1]);
                            cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                            excel.Cells[DongBatDau + i + j, 1] = j + 1;

                            excel.Cells[DongBatDau + i + j, 2] = arrDr[j]["TenMonHoc"];
                            cel = excel.get_Range(excel.Cells[DongBatDau + i + j, 2], excel.Cells[DongBatDau + i + j, 4]);
                            cel.Merge(null);
                            cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                            excel.Cells[DongBatDau + i + j, 5] = arrDr[j]["TongTiet"];
                            cel = excel.get_Range(excel.Cells[DongBatDau + i + j, 5], excel.Cells[DongBatDau + i + j, 6]);
                            cel.Merge(null);
                            cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                            excel.Cells[DongBatDau + i + j, 7] = arrDr[j]["HeSo"];
                            cel = excel.get_Range(excel.Cells[DongBatDau + i + j, 7], excel.Cells[DongBatDau + i + j, 8]);
                            cel.Merge(null);
                            cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            cel.NumberFormat = "#,##0.00";

                            excel.Cells[DongBatDau + i + j, 9] = arrDr[j]["GioQuyChuan"];
                            cel = (Excel.Range)(excel.Cells[DongBatDau + i + j, 9]);
                            cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            cel.NumberFormat = "#,##0.00";
                            SoGioThucHien += double.Parse(arrDr[j]["GioQuyChuan"].ToString());

                            excel.Cells[DongBatDau + i + j, 10] = arrDr[j]["GhiChu"];
                            cel = excel.get_Range(excel.Cells[DongBatDau + i + j, 10], excel.Cells[DongBatDau + i + j, 11]);
                            cel.Merge(null);
                            cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                            cel = excel.get_Range(excel.Cells[DongBatDau + i + j, 1], excel.Cells[DongBatDau + i + j, 11]);
                            cel.Borders.Value = 1;
                            cel.Font.Bold = false;
                            i++;
                        }
                    }

                    arrDr = dtChiTiet.Select("NS_GiaoVienID = " + dr["NS_GiaoVienID"] + " And wType = 'GD'");
                    if (arrDr.Length > 0)
                    {
                        // Thêm dòng giảng dạy
                        cel = (Excel.Range)(excel.Cells[DongBatDau + i + 1, 1]);
                        cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                        excel.Cells[DongBatDau + i, 2] = "'- Giảng dạy";
                        cel = excel.get_Range(excel.Cells[DongBatDau + i, 2], excel.Cells[DongBatDau + i, 5]);
                        cel.Merge(null);
                        cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        cel.Font.Bold = false;
                        i++;

                        // Thêm phần tiêu đề bảng
                        cel = (Excel.Range)(excel.Cells[DongBatDau + i + 1, 1]);
                        cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                        
                        excel.Cells[DongBatDau + i, 1] = "TT";
                        
                        excel.Cells[DongBatDau + i, 2] = "Môn học";
                        cel = excel.get_Range(excel.Cells[DongBatDau + i, 2], excel.Cells[DongBatDau + i, 3]);
                        cel.Merge(null);
                        cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        
                        excel.Cells[DongBatDau + i, 4] = "Lớp";
                        cel = (Excel.Range)(excel.Cells[DongBatDau + i, 4]);
                        cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        excel.Cells[DongBatDau + i, 5] = "LT";
                        cel = (Excel.Range)(excel.Cells[DongBatDau + i, 5]);
                        cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        excel.Cells[DongBatDau + i, 6] = "LT chuẩn";
                        cel = (Excel.Range)(excel.Cells[DongBatDau + i, 6]);
                        cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        excel.Cells[DongBatDau + i, 7] = "TH";
                        cel = (Excel.Range)(excel.Cells[DongBatDau + i, 7]);
                        cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        excel.Cells[DongBatDau + i, 8] = "TH chuẩn";
                        cel = (Excel.Range)(excel.Cells[DongBatDau + i, 8]);
                        cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        excel.Cells[DongBatDau + i, 9] = "Giờ quy chuẩn";
                        cel = (Excel.Range)(excel.Cells[DongBatDau + i, 9]);
                        cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        excel.Cells[DongBatDau + i, 10] = "Ghi chú";
                        cel = excel.get_Range(excel.Cells[DongBatDau + i, 10], excel.Cells[DongBatDau + i, 11]);
                        cel.Merge(null);
                        cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        cel = excel.get_Range(excel.Cells[DongBatDau + i, 1], excel.Cells[DongBatDau + i, 11]);
                        cel.Font.Bold = true;
                        cel.RowHeight = 35.25;
                        cel.Borders.Value = 1;
                        i++;
                        for (int j = 0; j < arrDr.Length; j++)
                        {
                            cel = (Excel.Range)(excel.Cells[DongBatDau + i + 1, 1]);
                            cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);

                            excel.Cells[DongBatDau + i, 1] = j + 1;

                            excel.Cells[DongBatDau + i, 2] = arrDr[j]["TenMonHoc"];
                            cel = excel.get_Range(excel.Cells[DongBatDau + i, 2], excel.Cells[DongBatDau + i, 3]);
                            cel.Merge(null);
                            cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                            excel.Cells[DongBatDau + i, 4] = arrDr[j]["TenLop"] + " (" + arrDr[j]["SoSinhVien"] + ")";
                            cel = (Excel.Range)(excel.Cells[DongBatDau + i, 4]);
                            cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                            if (double.Parse("0" + arrDr[j]["LyThuyet"]) > 0)
                                excel.Cells[DongBatDau + i, 5] = arrDr[j]["LyThuyet"];
                            cel = (Excel.Range)(excel.Cells[DongBatDau + i, 5]);
                            cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                            cel = (Excel.Range)(excel.Cells[DongBatDau + i, 6]);
                            if (double.Parse("0" + arrDr[j]["LyThuyetQuyChuan"]) > 0)
                            {
                                excel.Cells[DongBatDau + i, 6] = arrDr[j]["LyThuyetQuyChuan"];
                                cel.NumberFormat = "#,##0.00";
                            }
                            cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                            if (double.Parse("0" + arrDr[j]["ThucHanh"]) > 0)
                                excel.Cells[DongBatDau + i, 7] = arrDr[j]["ThucHanh"];
                            cel = (Excel.Range)(excel.Cells[DongBatDau + i, 7]);
                            cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                            cel = (Excel.Range)(excel.Cells[DongBatDau + i, 8]);
                            if (double.Parse("0" + arrDr[j]["ThucHanhQuyChuan"]) > 0)
                            {
                                excel.Cells[DongBatDau + i, 8] = arrDr[j]["ThucHanhQuyChuan"];
                                cel.NumberFormat = "#,##0.00";
                            }                            
                            cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                            cel = (Excel.Range)(excel.Cells[DongBatDau + i, 9]);
                            if (double.Parse("0" + arrDr[j]["GioQuyChuan"]) > 0)
                            {
                                excel.Cells[DongBatDau + i, 9] = arrDr[j]["GioQuyChuan"];
                                cel.NumberFormat = "#,##0.00";
                            }
                            cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            SoGioThucHien += double.Parse(arrDr[j]["GioQuyChuan"].ToString());

                            excel.Cells[DongBatDau + i, 10] = arrDr[j]["GhiChu"];
                            cel = excel.get_Range(excel.Cells[DongBatDau + i, 10], excel.Cells[DongBatDau + i, 11]);
                            cel.Merge(null);
                            cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                            cel = excel.get_Range(excel.Cells[DongBatDau + i, 1], excel.Cells[DongBatDau + i, 11]);
                            cel.Borders.Value = 1;
                            cel.Font.Bold = false;
                            i++;
                        }
                    }
                    // Thêm dòng thừa thiếu giờ đối với giáo viên
                    arrDr = dtDinhMuc.Select("IDNS_GiaoVien = " + dr["NS_GiaoVienID"]);

                    string str = "Định mức: " + (arrDr.Length > 0 ? arrDr[0]["SoGioDinhMuc"] : "0")+";";
                    str += " Thực hiện: " + SoGioThucHien.ToString() + ";";
                    SoGioThucHien = SoGioThucHien - (arrDr.Length > 0 ? double.Parse(arrDr[0]["SoGioDinhMuc"].ToString()) : 0);
                    str += (SoGioThucHien >= 0 ? " Thừa: " + Math.Abs(SoGioThucHien).ToString() : " Thiếu: " + Math.Abs(SoGioThucHien).ToString());

                    cel = (Excel.Range)(excel.Cells[DongBatDau + i + 1, 1]);
                    cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                    excel.Cells[DongBatDau + i, 2] = str;
                    cel = excel.get_Range(excel.Cells[DongBatDau + i, 2], excel.Cells[DongBatDau + i, 11]);
                    cel.Merge(null);
                    cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    cel.Font.Bold = true;
                    i++;
                }

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
