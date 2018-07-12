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
using System.IO;
using System.Diagnostics;
using System.Reflection;
using Aspose.Cells;
using Aspose.Words;

namespace UnimOs.UI
{
    public partial class frmQuyetDinhTotNghiep : frmBase
    {
        private cBKQHT_QuyetDinhTotNghiep oBKQHT_QuyetDinhTotNghiep;
        private cBKQHT_QuyetDinhTotNghiep_SinhVien oBKQHT_QuyetDinhTotNghiep_SinhVien;
        private cBSV_SinhVien oBSV_SinhVien;
        public DataTable dtQuyetDinh;
        private DataTable dtSinhVien;
        private DataRow drQuyetDinh;
        private Cells _range;
        private Worksheet _exSheet;
        private cBKQHT_DiemTongKetHocKy oBKQHT_DiemTongKetHocKy;
        public frmQuyetDinhTotNghiep()
        {
            InitializeComponent();
            oBKQHT_QuyetDinhTotNghiep = new cBKQHT_QuyetDinhTotNghiep();
            oBKQHT_QuyetDinhTotNghiep_SinhVien = new cBKQHT_QuyetDinhTotNghiep_SinhVien();
            oBSV_SinhVien = new cBSV_SinhVien();
            oBKQHT_DiemTongKetHocKy = new cBKQHT_DiemTongKetHocKy();
            repositoryItemcmbXepLoaiTN.DataSource = (new cBKQHT_XepLoaiTotNghiep()).Get(new KQHT_XepLoaiTotNghiepInfo());
        }

        private void frmQuyetDinhTotNghiep_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            dtQuyetDinh = oBKQHT_QuyetDinhTotNghiep.GetByIDDM_NamHoc(Program.IDNamHoc);
            grdQuyetDinh.DataSource = dtQuyetDinh;
        }

        public void grvQuyetDinh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvQuyetDinh.FocusedRowHandle >= 0)
            {
                drQuyetDinh = grvQuyetDinh.GetDataRow(grvQuyetDinh.FocusedRowHandle);
                dtSinhVien = oBKQHT_QuyetDinhTotNghiep_SinhVien.GetByQuyetDinh(int.Parse(drQuyetDinh["KQHT_QuyetDinhTotNghiepID"].ToString()));
                oBSV_SinhVien.TachCotHoVaTen(ref dtSinhVien);
                grdTotNghiep.DataSource = dtSinhVien;
            }
        }

        private void grvQuyetDinh_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow drNew = dtQuyetDinh.NewRow();
            dlgQuyetDinhTotNghiep dlg = new dlgQuyetDinhTotNghiep(this, drNew);
            dlg.ShowDialog();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvQuyetDinh.FocusedRowHandle >= 0)
            {
                dlgQuyetDinhTotNghiep dlg = new dlgQuyetDinhTotNghiep(this, drQuyetDinh);
                dlg.ShowDialog();
            }
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvQuyetDinh.FocusedRowHandle >= 0)
            {
                if (ThongBaoChon("Xóa quyết định sẽ xóa cả danh sách sinh viên trong quyết định này.\nBạn có chắc chắn muốn xóa không?") == DialogResult.Yes)
                {
                    KQHT_QuyetDinhTotNghiepInfo pKQHT_QuyetDinhTotNghiepInfo = new KQHT_QuyetDinhTotNghiepInfo();
                    pKQHT_QuyetDinhTotNghiepInfo.KQHT_QuyetDinhTotNghiepID = int.Parse(drQuyetDinh[pKQHT_QuyetDinhTotNghiepInfo.strKQHT_QuyetDinhTotNghiepID].ToString());
                    oBKQHT_QuyetDinhTotNghiep.Delete(pKQHT_QuyetDinhTotNghiepInfo);
                    dtQuyetDinh.Rows.Remove(drQuyetDinh);
                    grvQuyetDinh_FocusedRowChanged(null, null);
                }
            }
        }

        private void barbtnInQuyetDinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnInBangDiem_Click(object sender, EventArgs e)
        {
            if (dtSinhVien != null || dtSinhVien.Rows.Count > 0)
            {
                DataRow[] arrDr = dtSinhVien.Select("Chon=1");
                if (arrDr.Length > 0)
                {
                    string IDSV_SinhViens = "";
                    foreach (DataRow dr in arrDr)
                        IDSV_SinhViens += dr["SV_SinhVienID"] + ",";
                    IDSV_SinhViens = IDSV_SinhViens.Substring(0, IDSV_SinhViens.Length - 1);
                    DataTable dtReport = oBKQHT_QuyetDinhTotNghiep_SinhVien.GetBangDiemLanCuoi(IDSV_SinhViens, Program.IDNamHoc, Program.NamHoc);
                    if (dtReport != null && dtReport.Rows.Count > 0)
                    {
                        string ReportName = "rBangDiemTrungCap";

                        if (dtReport.Rows[0]["TenTrinhDo"].ToString().ToLower().IndexOf("cao đẳng") >= 0 || dtReport.Rows[0]["TenTrinhDo"].ToString().ToLower().IndexOf("sơ cấp nghề") >= 0)
                            ReportName = "rBangDiemCaoDang_CDCNKT";

                        frmDevReport frm = new frmDevReport(dtReport, ReportName,
                            new string[] { "DiemNam1", "DiemNam2", "TTN_CT", "TTN_LTCM", "TTN_THNN", "DiemToanKhoa", "DiemTotNghiep" },
                            "0:n1", "groupSV_SinhVienID", "SV_SinhVienID");
                        frm.ShowDialog();
                    }
                }
                else
                    ThongBao("Bạn chưa chọn sinh viên nào để in bảng điểm.");
            }
            else
                ThongBao("Bạn chưa chọn sinh viên nào để in bảng điểm.");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDanhSoBang_Click(object sender, EventArgs e)
        {
            if (dtSinhVien != null || dtSinhVien.Rows.Count > 0)
            {
                dlgQuyetDinhTotNghiep_DanhSoBang dlg = new dlgQuyetDinhTotNghiep_DanhSoBang(ref dtSinhVien);
                dlg.ShowDialog();
            }
        }

        private void btnLuuSoBang_Click(object sender, EventArgs e)
        {
            if (dtSinhVien != null || dtSinhVien.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow dr in dtSinhVien.Rows)
                    {
                        oBKQHT_QuyetDinhTotNghiep_SinhVien.UpdateSoBang(int.Parse(dr["KQHT_QuyetDinhTotNghiep_SinhVienID"].ToString()), "" + dr["SoBang"]);
                    }
                }
                catch (Exception ex)
                {
                    ThongBaoLoi("Có lỗi khi cập nhật: " + ex.Message);
                }
            }
        }

        private void btnXoaSinhVien_Click(object sender, EventArgs e)
        {
            if (dtSinhVien != null || dtSinhVien.Rows.Count > 0)
            {
                DataRow[] arrDr = dtSinhVien.Select("Chon=1");
                if (arrDr.Length > 0)
                {
                    if (ThongBaoChon("Bạn có chắc muốn xóa các sinh viên này khỏi quyết định tốt nghiệp không ?") == DialogResult.Yes)
                    {
                        KQHT_QuyetDinhTotNghiep_SinhVienInfo p = new KQHT_QuyetDinhTotNghiep_SinhVienInfo();
                        foreach (DataRow dr in arrDr)
                        {
                            p.KQHT_QuyetDinhTotNghiep_SinhVienID = int.Parse(dr["KQHT_QuyetDinhTotNghiep_SinhVienID"].ToString());
                            oBKQHT_QuyetDinhTotNghiep_SinhVien.Delete(p);
                        }

                        grvQuyetDinh_FocusedRowChanged(null, null);
                        XoaThanhCong();
                    }
                }
                else
                    ThongBao("Bạn chưa chọn sinh viên nào !");
            }
        }

        private void grvTotNghiep_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvTotNghiep, "Chon", e);
        }

        private void barbtnInBangDiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnInBangDiem_Click(null, null);
        }

        private void grvTotNghiep_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && grdTotNghiep.ClientRectangle.Contains(e.X, e.Y))
            {
                popupMenu1.ShowPopup(MousePosition);
            }
        }

        private void btnXuatExcelBangDiem_Click(object sender, EventArgs e)
        {
            if (dtSinhVien == null || dtSinhVien.Rows.Count == 0)
            {
                ThongBao("Không có dữ liệu để xuất Excel.");
                return;
            }

            XuatBangDiemCuoiKhoa(grvTotNghiep.GetDataRow(grvTotNghiep.FocusedRowHandle));
        }

        #region Xuat bang ket qua hoc tap
        private void XuatBangDiemCuoiKhoa(DataRow drSinhVien)
        {
            string strFileExcel = Application.StartupPath + "\\Template\\Temp_BangDiemCuoiKhoa_TC.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + "! Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                return;
            }

            string strTenFileExcelMoi = "BangDiemCuoiKhoa_" + drSinhVien["MaSinhVien"] + ".xls";

            DataTable dt = oBKQHT_QuyetDinhTotNghiep_SinhVien.GetBangDiemLanCuoi(drSinhVien["SV_SinhVienID"].ToString(), Program.IDNamHoc, Program.NamHoc);

            if (dt.Rows.Count > 0)
            {
                if ((dt.Rows[0]["TenTrinhDo"].ToString().ToLower().IndexOf("cao đẳng") >= 0) || (dt.Rows[0]["TenTrinhDo"].ToString().ToLower().IndexOf("sơ cấp nghề") >= 0))
                    XuatBangDiemRaExcel_CaoDang(dt, strTenFileExcelMoi);
                else
                    XuatBangDiemRaExcel(dt, strTenFileExcelMoi);
            }
            else
                ThongBao("Không có dữ liệu để xuất Excel !");
        }

        private void XuatBangDiemRaExcel(DataTable dtChiTiet, string FileExcel)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");

            #region Chuẩn bị tệp excel để ghi dữ liệu
            Workbook exBook = new Workbook();
            exBook.Open(Application.StartupPath + "\\Template\\Temp_BangDiemCuoiKhoa_TC.xls", FileFormatType.Excel2003);

            _exSheet = exBook.Worksheets[0];
            _range = _exSheet.Cells;
            DataRow dr = dtChiTiet.Rows[0];
            #endregion

            SaveFileDialog sv = new SaveFileDialog();
            sv.FileName = "BangDiemCuoiKhoa - " + dr["MaSinhVien"] + " - " + dr["HoVaTen"] + ".xls";
            sv.Filter = "Excel file (*.xls)|*.xls";
            sv.Title = "Xuất dữ liệu";
            if (sv.ShowDialog() == DialogResult.OK)
            {
                #region Đổ dữ liệu vào báo cáo
                int DongBatDau = 13;

                _range["A5"].PutValue("TRÌNH ĐỘ " + dr["TenTrinhDo"].ToString().ToUpper().Replace("TRÌNH ĐỘ ", ""));
                _range["C7"].PutValue(dr["HoVaTen"]);
                _range["I7"].PutValue(dr["TenNganh"]);
                _range["C8"].PutValue(dr["NgaySinh"]);
                _range["I8"].PutValue(dr["TenHe"]);

                // Put nơi sinh và bôi đậm Nơi sinh
                Aspose.Cells.Font _fontGoc = _range["B9"].Style.Font;
                int _count = ("" + _range["B9"].Value).Length;
                _range["B9"].PutValue("" + _range["B9"].Value + dr["NoiSinh"]);
                Aspose.Cells.Font _font = _range["B9"].Characters(_count, ("" + dr["NoiSinh"]).Length).Font;
                _font.IsBold = true;
                _font.Name = _fontGoc.Name;
                _font.Size = _fontGoc.Size;

                _range["I9"].PutValue(dr["TenLop"]);
                _range["I10"].PutValue(dr["TenKhoaHoc"]);

                _range["C11"].PutValue(dr["NamThuNhat"]);
                _range["I11"].PutValue(dr["NamThuHai"]);
                _range["D19"].PutValue(dr["TTN_CT"]);
                _range["D20"].PutValue(dr["TTN_LTCM"]);
                _range["D21"].PutValue(dr["TTN_THNN"]);
                _range["D22"].PutValue(dr["DiemToanKhoa"]);
                _range["D23"].PutValue(dr["DiemTotNghiep"]);
                _range["D24"].PutValue(dr["XepLoaiTotNghiep"]);

                _fontGoc = _range["B25"].Style.Font;
                _count = ("" + _range["B25"].Value).IndexOf("[SoQuyetDinh]");
                _range["B25"].PutValue(("" + _range["B25"].Value).Replace("[SoQuyetDinh]", "" + dr["SoQuyetDinh"]).
                    Replace("[NgayQuyetDinh]", dr["NgayQuyetDinh"].ToString()));
                _font = _range["B25"].Characters(_count, ("" + dr["SoQuyetDinh"]).Length).Font;
                _font.IsBold = true;
                _font.Name = _fontGoc.Name;
                _font.Size = _fontGoc.Size;

                _range["H26"].PutValue(_range["H26"].Value + ", " + dr["NgayKy"]);

                _count = dtChiTiet.Rows.Count;

                if (_count > 3)
                    _range.InsertRows(DongBatDau + 1, _count - 3);
                else
                    _range.DeleteRows(DongBatDau + 1, 3 - _count);

                foreach (DataRow drItem in dtChiTiet.Rows)
                {
                    _range[DongBatDau, 0].PutValue(drItem["TT1"]);
                    _exSheet.Cells.Merge(DongBatDau, 1, 1, 2);
                    _range[DongBatDau, 1].PutValue(drItem["TenMonHoc1"]);
                    _range[DongBatDau, 12].PutValue(drItem["TenMonHoc1"]);
                    _range[DongBatDau, 1].Style.IsTextWrapped = true;
                    _range[DongBatDau, 3].PutValue(drItem["SoHocTrinh1"]);
                    _range[DongBatDau, 4].PutValue(drItem["DiemNam1"]);

                    _range[DongBatDau, 6].PutValue(drItem["TT2"]);
                    _exSheet.Cells.Merge(DongBatDau, 7, 1, 2);
                    _range[DongBatDau, 7].PutValue(drItem["TenMonHoc2"]);
                    _range[DongBatDau, 13].PutValue(drItem["TenMonHoc2"]);
                    _range[DongBatDau, 7].Style.IsTextWrapped = true;
                    _range[DongBatDau, 9].PutValue(drItem["SoHocTrinh2"]);
                    _range[DongBatDau, 10].PutValue(drItem["DiemNam2"]);

                    //_exSheet.AutoFitRow(DongBatDau);

                    DongBatDau++;
                }

                //_exSheet.AutoFitRows();

                //_range.HideColumn(13);
                //_range.HideColumn(12);
                #endregion

                #region Lưu và mở file excel
                string strTenFileExcelMoi = sv.FileName;
                exBook.Save(strTenFileExcelMoi, FileFormatType.Excel2003);
                CloseWaitDialog();
                ThongBao("Xuất dữ liệu thành công.");

                try
                {
                    Process.Start(strTenFileExcelMoi);
                }
                catch (Exception ex)
                {
                    ThongBaoLoi("Đã có lỗi: " + ex.Message);
                }
                #endregion
            }
            else
            {
                CloseWaitDialog();
            }
        }

        private void XuatBangDiemRaExcel_CaoDang(DataTable dtChiTiet, string FileExcel)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");

            #region Chuẩn bị tệp excel để ghi dữ liệu
            Workbook exBook = new Workbook();
            exBook.Open(Application.StartupPath + "\\Template\\Temp_BangDiemCuoiKhoa_CD.xls", FileFormatType.Excel2003);

            _exSheet = exBook.Worksheets[0];
            _range = _exSheet.Cells;
            DataRow dr = dtChiTiet.Rows[0];
            #endregion

            SaveFileDialog sv = new SaveFileDialog();
            sv.FileName = "BangDiemCuoiKhoa - " + dr["MaSinhVien"] + " - " + dr["HoVaTen"] + ".xls";
            sv.Filter = "Excel file (*.xls)|*.xls";
            sv.Title = "Xuất dữ liệu";
            if (sv.ShowDialog() == DialogResult.OK)
            {
                #region Đổ dữ liệu vào báo cáo
                int DongBatDau = 11;

                _range["C6"].PutValue(dr["HoVaTen"]);
                _range["I6"].PutValue(dr["TenTrinhDo"]);
                _range["C7"].PutValue(dr["NgaySinh"]);
                _range["I7"].PutValue(dr["TenHe"]);
                _range["C8"].PutValue(dr["NoiSinh"]);
                _range["I8"].PutValue(dr["TenNganh"]);
                _range["C9"].PutValue(dr["TenLop"]);
                _range["I9"].PutValue(dr["TenKhoaHoc"]);

                _range["D16"].PutValue(dr["DiemToanKhoa"]);
                _range["I16"].PutValue(dr["XepLoaiTotNghiep"]);

                int _count = dtChiTiet.Rows.Count;

                if (_count > 3)
                    _range.InsertRows(DongBatDau + 1, _count - 3);
                else
                    _range.DeleteRows(DongBatDau + 1, 3 - _count);

                foreach (DataRow drItem in dtChiTiet.Rows)
                {
                    _range[DongBatDau, 0].PutValue(drItem["TT1"]);
                    _range[DongBatDau, 12].PutValue(drItem["TenMonHoc1"]);
                    _range[DongBatDau, 1].Style.IsTextWrapped = true;
                    _range[DongBatDau, 3].PutValue(drItem["SoHocTrinh1"]);
                    _range[DongBatDau, 4].PutValue(drItem["DiemNam1"]);

                    _range[DongBatDau, 6].PutValue(drItem["TT2"]);
                    _range[DongBatDau, 13].PutValue(drItem["TenMonHoc2"]);
                    _range[DongBatDau, 7].Style.IsTextWrapped = true;
                    _range[DongBatDau, 9].PutValue(drItem["SoHocTrinh2"]);
                    _range[DongBatDau, 10].PutValue(drItem["DiemNam2"]);

                    _exSheet.AutoFitRow(DongBatDau);

                    _exSheet.Cells.Merge(DongBatDau, 1, 1, 2);
                    _range[DongBatDau, 1].PutValue(drItem["TenMonHoc1"]);

                    _exSheet.Cells.Merge(DongBatDau, 7, 1, 2);
                    _range[DongBatDau, 7].PutValue(drItem["TenMonHoc2"]);

                    DongBatDau++;
                }

                _range.HideColumn(13);
                _range.HideColumn(12);

                _exSheet.Replace("[SoQuyetDinh]", "" + dr["SoQuyetDinh"]);
                _exSheet.Replace("[NgayQuyetDinh]", "" + dr["NgayQuyetDinh"]);

                _exSheet.Replace("TenNgayKy", "" + dr["NgayKy"]);
                #endregion

                #region Lưu và mở file excel
                string strTenFileExcelMoi = sv.FileName;
                exBook.Save(strTenFileExcelMoi, FileFormatType.Excel2003);
                CloseWaitDialog();
                ThongBao("Xuất dữ liệu thành công.");

                try
                {
                    Process.Start(strTenFileExcelMoi);
                }
                catch (Exception ex)
                {
                    ThongBaoLoi("Đã có lỗi: " + ex.Message);
                }
                #endregion
            }
            else
            {
                CloseWaitDialog();
            }
        }

        private void XuatBangDiemRaExcel_Old(DataTable dtChiTiet, string FileExcel)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int DongBatDau = 14;
            Excel.Range cel;
            DataRow dr;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);

                dr = dtChiTiet.Rows[0];

                excel.Cells[5, 1] = dr["TenTrinhDo"].ToString();

                excel.Cells[7, 3] = dr["HoVaTen"].ToString();

                excel.Cells[8, 3] = "'" + dr["NgaySinh"];

                cel = (Excel.Range)excel.Cells[9, 2];
                excel.Cells[9, 2] = cel.Text + "  " + dr["NoiSinh"];

                excel.Cells[7, 9] = dr["TenNganh"].ToString();

                excel.Cells[8, 9] = dr["TenHe"].ToString();

                excel.Cells[9, 9] = dr["TenLop"].ToString();

                excel.Cells[10, 9] = dr["TenKhoaHoc"].ToString();

                excel.Cells[11, 3] = dr["NamThuNhat"].ToString();

                excel.Cells[11, 9] = dr["NamThuHai"].ToString();

                excel.Cells[17, 4] = dr["TTN_CT"].ToString();

                excel.Cells[18, 4] = dr["TTN_LTCM"].ToString();

                excel.Cells[19, 4] = dr["TTN_THNN"].ToString();

                excel.Cells[20, 4] = dr["DiemToanKhoa"].ToString();

                excel.Cells[21, 4] = dr["DiemTotNghiep"].ToString();

                excel.Cells[22, 4] = dr["XepLoaiTotNghiep"].ToString();

                cel = (Excel.Range)excel.Cells[23, 2];
                excel.Cells[23, 2] = cel.Text.ToString().Replace("[SoQuyetDinh]", "" + dr["SoQuyetDinh"]).Replace("[NgayQuyetDinh]", dr["NgayQuyetDinh"].ToString());

                cel = (Excel.Range)excel.Cells[24, 8];
                excel.Cells[24, 8] = cel.Text + ", " + dr["NgayKy"].ToString();

                foreach (DataRow drItem in dtChiTiet.Rows)
                {
                    // Insert rows
                    cel = (Excel.Range)(excel.Cells[DongBatDau + 1, 1]);
                    cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);

                    excel.Cells[DongBatDau, 1] = "" + drItem["TT1"];

                    excel.Cells[DongBatDau, 2] = "" + drItem["TenMonHoc1"];

                    excel.Cells[DongBatDau, 13] = "" + drItem["TenMonHoc1"];
                    cel = excel.get_Range(excel.Cells[DongBatDau, 2], excel.Cells[DongBatDau, 3]);
                    cel.Merge(null);

                    excel.Cells[DongBatDau, 4] = "" + drItem["SoHocTrinh1"];

                    excel.Cells[DongBatDau, 5] = "" + drItem["DiemNam1"];

                    excel.Cells[DongBatDau, 7] = "" + drItem["TT2"];

                    excel.Cells[DongBatDau, 8] = "" + drItem["TenMonHoc2"];
                    cel = excel.get_Range(excel.Cells[DongBatDau, 8], excel.Cells[DongBatDau, 9]);
                    cel.Merge(null);

                    excel.Cells[DongBatDau, 14] = "" + drItem["TenMonHoc2"];

                    excel.Cells[DongBatDau, 10] = "" + drItem["SoHocTrinh2"];

                    excel.Cells[DongBatDau, 11] = "" + drItem["DiemNam2"];

                    cel.Rows.AutoFit();

                    DongBatDau++;
                }

                cel = (Excel.Range)(excel.Cells[DongBatDau, 1]);
                cel.EntireRow.Delete(Excel.XlDirection.xlUp);

                ((Excel.Range)(excel.Cells[DongBatDau, 14])).EntireColumn.Hidden = true;
                ((Excel.Range)(excel.Cells[DongBatDau, 13])).EntireColumn.Hidden = true;

                // Set style
                cel = excel.get_Range(excel.Cells[14, 1], excel.Cells[DongBatDau - 1, 5]);
                cel.Borders.Value = 1;

                cel = excel.get_Range(excel.Cells[14, 7], excel.Cells[DongBatDau - 1, 11]);
                cel.Borders.Value = 1;

                excel.Visible = true;
            }
            catch (Exception e)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ThongBaoLoi("Xuất dữ liệu không thành công! Hãy đóng file Excel Phiếu báo điểm trước khi xuất dữ liệu. Thông báo lỗi: " + e.Message);
                return;
            }
            finally
            {
                excel.Application.Workbooks[1].Save();
                //excel.Application.Workbooks.Close();
                //excel.Application.Quit();
                //excel.Quit();
                CloseWaitDialog();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
        #endregion

        private void btnInDSSVDuDKTotNghiep_Click(object sender, EventArgs e)
        {
            DataTable dtTempSinhVien = oBKQHT_QuyetDinhTotNghiep_SinhVien.GetByIDDM_NamHoc(Program.IDNamHoc);
            XuatTheoTemplate(dtTempSinhVien, "YES");
        }

        #region Xuat theo template
        private void XuatTheoTemplate(DataTable dtBaoCao, string TrangThai)
        {
            if (dtBaoCao.Rows.Count == 0)
            {
                ThongBao("Không có dữ liệu để xuất ra excel!");
                return;
            }
            string DuongDan = Application.StartupPath;
            string strFileExcel = DuongDan + "\\Template\\Temp_DanhSachSinhVien_TotNghiep.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + "! Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                return;
            }
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Excel file (*.xls)|*.xls";
            sv.Title = "Xuất dữ liệu";
            if (TrangThai == "YES")
                sv.FileName = "DanhSachSinhVien_DuDieuKienTotNghiep_" + Program.NamHoc + ".xls";
            else
                sv.FileName = "DanhSachSinhVien_KhongDuDieuKienTotNghiep_" + Program.NamHoc + ".xls";
            if (sv.ShowDialog() == DialogResult.OK)
            {
                //string strTenFileExcelMoi = sv.FileName;
                //try
                //{
                //    File.Copy(strFileExcel, strTenFileExcelMoi, true);
                //}
                //catch (Exception ex)
                //{
                //    ThongBaoLoi("File excel đang được mở. Đề nghị đóng file này trước khi xuất dữ liệu! Thông báo lỗi: " + ex.Message);
                //    return;
                //}
                //finally { }

                XuatDuLieuRaExcel(dtBaoCao, sv.FileName, TrangThai);

                ThongBao("Xuất dữ liệu thành công!");
            }
        }

        private void XuatDuLieuRaExcel(DataTable dtBaoCao, string FileExcel, string TrangThai)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int DongBatDau = 9, dem = 1;
            Excel.Range cel;
            Excel.Worksheet Wsheet;
            Excel.Workbook Wbook;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                Wbook = excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);
                Wsheet = (Excel.Worksheet)Wbook.ActiveSheet;
                if (TrangThai == "YES")
                    excel.Cells[4, 1] = "DANH SÁCH SINH VIÊN ĐỦ ĐIỀU KIỆN TỐT NGHIỆP";
                else
                    excel.Cells[4, 1] = "DANH SÁCH SINH VIÊN KHÔNG ĐỦ ĐIỀU KIỆN TỐT NGHIỆP";
                excel.Cells[5, 1] = "KHÓA HỌC " + Program.NamHoc;

                string HoVa = "", TenKhoa1, TenKhoa2, TenLop1, TenLop2, cot1, cot2;
                TenKhoa1 = "";
                TenLop1 = "";
                for (int i = 0; i < dtBaoCao.Rows.Count; i++)
                {
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 1]);
                    cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);

                    TenKhoa2 = dtBaoCao.Rows[i]["NienKhoa"].ToString();
                    if (TenKhoa1 != TenKhoa2)
                    {
                        cel = (Excel.Range)(excel.Cells[i + DongBatDau, 1]);

                        //merge cell
                        cot1 = "A" + (i + DongBatDau);
                        cot2 = "L" + (i + DongBatDau);
                        cel = Wsheet.get_Range(cot1, cot2);
                        cel.Merge(Missing.Value);
                        excel.Cells[i + DongBatDau + 0, 1] = "Nghành: " + TenKhoa2.ToUpper();
                        cel.WrapText = true;
                        cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                        cel.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
                        cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                        cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                        cel.HorizontalAlignment = HorizontalAlignment.Right;
                        cel.Font.Bold = true;

                        TenKhoa1 = TenKhoa2;

                        DongBatDau++;
                        cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 1]);
                        cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);

                        dem = 1;
                    }
                    TenLop2 = dtBaoCao.Rows[i]["TenLop"].ToString();
                    if (TenLop1 != TenLop2)
                    {
                        cel = (Excel.Range)(excel.Cells[i + DongBatDau, 1]);

                        //cel.HorizontalAlignment = HorizontalAlignment.Left;
                        //MERGE CELL
                        cot1 = "A" + (i + DongBatDau);
                        cot2 = "L" + (i + DongBatDau);
                        cel = Wsheet.get_Range(cot1, cot2);
                        cel.Merge(Missing.Value);
                        excel.Cells[i + DongBatDau + 0, 1] = "Lớp: " + TenLop2.ToUpper();
                        cel.WrapText = true;
                        cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                        cel.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
                        cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                        cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                        cel.Font.Bold = true;
                        cel.HorizontalAlignment = HorizontalAlignment.Right;
                        TenLop1 = TenLop2;
                        DongBatDau++;
                        cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 1]);
                        cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);

                        dem = 1;
                    }
                    //Xử lý cho cột 1: STT
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 1]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Font.Bold = false;
                    excel.Cells[i + DongBatDau + 0, 1] = dem;

                    //Xử lý cho cột 2: Mã SV
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 2]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    excel.Cells[i + DongBatDau + 0, 2] = (dtBaoCao.Rows[i]["MaSinhVien"] + "");

                    //Xử lý cho cột 3: Họ và

                    GetTen(dtBaoCao.Rows[i]["HoVaTen"].ToString(), ref HoVa);
                    dtBaoCao.Rows[i]["HoVa"] = HoVa;

                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 3]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    //cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    excel.Cells[i + DongBatDau + 0, 3] = (dtBaoCao.Rows[i]["HoVa"] + "");

                    //Xử lý cho cột 4: Tên
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 4]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    //cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    excel.Cells[i + DongBatDau + 0, 4] = (dtBaoCao.Rows[i]["Ten"] + "");
                    //Xử lý cho cột 5: Ngày sinh
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 5]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    if (dtBaoCao.Rows[i]["NgaySinh"] + "" != "")
                    {
                        string str = dtBaoCao.Rows[i]["NgaySinh"] + "";
                        str = str.Replace("12:00:00 AM", "");
                        excel.Cells[i + DongBatDau + 0, 5] = str;
                        //excel.Cells[i + DongBatDau + 0, 4] = DateTime.Parse(dtBaoCao.Rows[i]["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                    }
                    else
                        excel.Cells[i + DongBatDau + 0, 5] = "";
                    //Xử lý cho cột 6: Nơi sinh
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 6]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    excel.Cells[i + DongBatDau + 0, 6] = (dtBaoCao.Rows[i]["NoiSinh"] + "");
                    //Xử lý cho cột 7: Điểm môn TN1: Điểm môn C.Môn
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 7]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    excel.Cells[i + DongBatDau + 0, 7] = (dtBaoCao.Rows[i]["DiemMonTotNghiep3"] + "");
                    //Xử lý cho cột 8: Điểm môn TN2: CSNghanh
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 8]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    excel.Cells[i + DongBatDau + 0, 8] = (dtBaoCao.Rows[i]["DiemMonTotNghiep2"] + "");
                    //Xử lý cho cột 9: Điểm môn TN3: MLN - TTHCM
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 9]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    excel.Cells[i + DongBatDau + 0, 9] = (dtBaoCao.Rows[i]["DiemMonTotNghiep1"] + "");
                    //Xử lý cho cột 10: Điểm TTTN
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 10]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    excel.Cells[i + DongBatDau + 0, 10] = (dtBaoCao.Rows[i]["DiemMonTotNghiep4"] + "");
                    //Xử lý cho cột 11: Điểm TBC TK
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 11]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    excel.Cells[i + DongBatDau + 0, 11] = (dtBaoCao.Rows[i]["DiemTrungBinhChungToanKhoa"] + "");
                    ////Xử lý cho cột 12: Xếp loại
                    //cel = (Excel.Range)(excel.Cells[i + DongBatDau, 12]);
                    //cel.WrapText = true;
                    //cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    //cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    //cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    //excel.Cells[i + DongBatDau + 0, 12] = (dtBaoCao.Rows[i]["DiemXepLoaiTotNghiep"] + "");
                    //Xử lý cho cột 12: Điểm XL TN
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 12]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    if (TrangThai == "YES")
                    {
                        excel.Cells[i + DongBatDau, 12] = (dtBaoCao.Rows[i]["TenXepLoai"] + "");
                    }
                    dem++;
                }
                for (int k = 1; k <= 12; k++)
                {
                    cel = (Excel.Range)(excel.Cells[(dtBaoCao.Rows.Count + DongBatDau) - 1, k]);
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                }

                /*
                int Folter = dtBaoCao.Rows.Count;
                string cot1, cot2;
                cot1 = "B" + (DongBatDau + Folter + 2);
                cot2 = "C" + (DongBatDau + Folter + 2);
    
                cel = Wsheet.get_Range(cot1, cot2);
                cel.Value2 = "T.P. Đào tạo";
                cel.Font.Bold = true;
                cel.Merge(Missing.Value);

                cot1 = "J" + (DongBatDau + Folter + 2);
                cot2 = "K" + (DongBatDau + Folter + 2);
                cel = Wsheet.get_Range(cot1, cot2);
                cel.Value2 = "HIỆU TRƯỞNG";
                cel.Font.Bold = true;
                cel.Merge(Missing.Value);
                */
            }
            catch (Exception e)
            {
                CloseWaitDialog();
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ThongBaoLoi("Xuất dữ liệu không thành công! Hãy đóng file Excel Phiếu báo điểm trước khi xuất dữ liệu. Thông báo lỗi: " + e.Message);
                return;
            }
            finally
            {
                excel.Application.Workbooks[1].Save();
                excel.Application.Workbooks.Close();
                excel.Application.Quit();
                excel.Quit();
                Process.Start(FileExcel);
                CloseWaitDialog();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
        #endregion

        private void btnInDSSVKhongDuDKTotNghiep_Click(object sender, EventArgs e)
        {
            DataTable dtTemSinhVien = oBKQHT_QuyetDinhTotNghiep_SinhVien.GetNotIn(new DM_LopInfo(), Program.IDNamHoc);
            XuatTheoTemplate(dtTemSinhVien, "NO");
        }

        private void btnSoKQHT_Click(object sender, EventArgs e)
        {
            try
            {
                var source = grvTotNghiep.DataSource as DataView;

                if (source == null) return;

                var numItem = source.Table.Rows.Count;

                if (numItem == 0)
                {
                    ThongBaoLoi("Không có dữ liệu.");
                    return;
                }

                bool hasData = false;
                for (var i = 0; i < numItem; i++)
                {
                    var row = grvTotNghiep.GetDataRow(i);

                    if ((bool)row["Chon"])
                    {
                        hasData = true;
                        break;
                    }
                }

                if (!hasData)
                {
                    ThongBaoLoi("Bạn chưa chọn sinh viên cần xuất dữ liệu.");
                    return;
                }

                string strFile = Application.StartupPath + "\\Template\\Temp_SoLuuKetQuaHocTap.doc";
                string strFile2 = Application.StartupPath + "\\Template\\Temp_SoLuuKetQuaHocTap_CaoDang.doc";
                if (!File.Exists(strFile) || !File.Exists(strFile2))
                {
                    ThongBao("Không tìm thấy file mẫu! Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                    return;
                }

                SaveFileDialog dlg = new SaveFileDialog()
                {
                    Title = "Chọn nơi lưu Tệp xuất ra",
                    Filter = "Microsoft Word Documents (*.doc) | *.doc",
                    FileName = "SoLuuKetQuaHocTap_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".doc"
                };

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                CreateWaitDialog("Đang xuất dữ liệu ra file.", "Xin vui lòng chờ!");

                Document newExportDoc = null;

                var soQD = grvQuyetDinh.GetFocusedRowCellValue("SoQuyetDinh") + "";
                var ngayQD = string.Format("{0:dd/MM/yyyy}",grvQuyetDinh.GetFocusedRowCellValue("NgayQuyetDinh"));
                for (var i = 0; i < numItem; i++)
                {
                    var row = grvTotNghiep.GetDataRow(i);

                    if (!(bool)row["Chon"]) continue;

                    var dt = oBKQHT_DiemTongKetHocKy.GetDiemTongKet_KQHT((int)row["SV_SinhVienID"]);
                    DataTable dtTN = oBKQHT_QuyetDinhTotNghiep_SinhVien.GetBangDiemLanCuoi(row["SV_SinhVienID"] + "", Program.IDNamHoc, Program.NamHoc);
                    DataTable dtthiTN = oBKQHT_DiemTongKetHocKy.GetBangDiemThiTN((int)row["SV_SinhVienID"]);

                    if (dt.Rows.Count > 0)
                    {
                        if (newExportDoc == null)
                            newExportDoc = XuatBangDiemTongKet(dt, dtTN, dtthiTN, row["SoBang"] + "", soQD,ngayQD);
                        else
                            newExportDoc.AppendDocument(XuatBangDiemTongKet(dt, dtTN, dtthiTN, row["SoBang"] + "", soQD, ngayQD), ImportFormatMode.KeepSourceFormatting);
                    }
                }

                //var lastBreak = newExportDoc.LastChild;
                //newExportDoc.RemoveChild(lastBreak);

                newExportDoc.Save(dlg.FileName, SaveFormat.Doc);

                ThongBao("Đã xuất dữ liệu thành công.");

                Process.Start(dlg.FileName);
            }
            catch (Exception ex)
            {
                ThongBaoLoi(ex.Message);
            }
            finally
            {
                CloseWaitDialog();
            }
        }

        private Document XuatBangDiemTongKet(DataTable dulieu, DataTable dttn, DataTable dThitn, string soBangTN, string soQDTN, string ngayQDTN)
        {
            try
            {
                #region Chuẩn bị tệp để ghi dữ liệu
                string strFile = "";
                if (dulieu.Rows[0]["TenTrinhDo"] + "" == "Cao đẳng chính quy")
                {

                    strFile = Application.StartupPath + "\\Template\\Temp_SoLuuKetQuaHocTap_CaoDang.doc";
                }
                else
                {
                    strFile = Application.StartupPath + "\\Template\\Temp_SoLuuKetQuaHocTap.doc";
                }

                Document doc = new Document(strFile);
                DocumentBuilder builder = new DocumentBuilder(doc);

                #endregion

                bool inNamHoc1 = false;
                bool inNamHoc2 = false;
                bool inNamHoc3 = false;
                var hoTen = dulieu.Rows[0]["HoVaTen"] + "";
                builder.MoveToBookmark("HoTen");
                builder.Write(hoTen);

                var ngaySinh = string.Format("{0:dd/MM/yyyy}", dulieu.Rows[0]["NgaySinh"]);
                builder.MoveToBookmark("NgaySinh");
                builder.Write(ngaySinh);

                var noiSinh = dulieu.Rows[0]["NoiSinh"] + "";
                builder.MoveToBookmark("NoiSinh");
                builder.Write(noiSinh);

                var lop = dulieu.Rows[0]["TenLop"] + "";
                builder.MoveToBookmark("Lop");
                builder.Write(lop);

                var khoaHoc = dulieu.Rows[0]["TenKhoaHoc"] + "";
                builder.MoveToBookmark("KhoaHoc");
                builder.Write(khoaHoc);

                var nganhNghe = dulieu.Rows[0]["TenNganh"] + "";
                builder.MoveToBookmark("NganhNghe");
                builder.Write(nganhNghe);

                var chuyenNganh = dulieu.Rows[0]["TenChuyenNganh"] + "";
                builder.MoveToBookmark("ChuyenNganh");
                builder.Write(chuyenNganh);

                builder.MoveToBookmark("So_QDTN");
                builder.Write(soQDTN+" Ngày quyết định: "+ngayQDTN);

                builder.MoveToBookmark("So_BangTN");
                builder.Write(soBangTN);

                //if (dulieu.Rows[0]["NamXuat"]+"" == "1")
                //{
                //    builder.MoveToBookmark("NamHoc_1");
                //    builder.Write(dulieu.Rows[0]["TennamHoc"] + "");

                //    builder.MoveToBookmark("NamHoc_2");
                //    builder.Write(dulieu.Rows[0]["TennamHoc"] + "");

                //    //inNamHoc1 = true;
                //}

                int i = 0, j = 0;
                string ky = "";

                var tableDiem = new DataTable();
                tableDiem.Columns.Add("STT_1", typeof(string));
                tableDiem.Columns.Add("Ten_1", typeof(string));
                tableDiem.Columns.Add("DVHT_1", typeof(string));
                tableDiem.Columns.Add("Diem1_1", typeof(string));
                tableDiem.Columns.Add("Diem2_1", typeof(string));
                tableDiem.Columns.Add("STT_2", typeof(string));
                tableDiem.Columns.Add("Ten_2", typeof(string));
                tableDiem.Columns.Add("DVHT_2", typeof(string));
                tableDiem.Columns.Add("Diem1_2", typeof(string));
                tableDiem.Columns.Add("Diem2_2", typeof(string));

                // nam 1
                var tableDiemNam1 = tableDiem.Clone();
                tableDiemNam1.TableName = "DiemNam1";

                var tableDiemNam1Ky1 = dulieu.AsEnumerable().OrderBy(p => int.Parse("0" + p["ThucHanh"])).Where(p => p["NamXuat"] + "" == "1" && p["HocKy"] + "" == "1");
                var tableDiemNam1Ky2 = dulieu.AsEnumerable().OrderBy(p => int.Parse("0" + p["ThucHanh"])).Where(p => p["NamXuat"] + "" == "1" && p["HocKy"] + "" == "2");


                CreateBangDiemExport(tableDiemNam1,
                    tableDiemNam1Ky1.AsDataView().Count > 0 ? tableDiemNam1Ky1.CopyToDataTable() : dulieu.Clone(),
                    tableDiemNam1Ky2.AsDataView().Count > 0 ? tableDiemNam1Ky2.CopyToDataTable() : dulieu.Clone());

                // nam 2
                var tableDiemNam2 = tableDiem.Clone();
                tableDiemNam2.TableName = "DiemNam2";

                var tableDiemNam2Ky1 = dulieu.AsEnumerable().OrderBy(p => int.Parse("0" + p["ThucHanh"])).Where(p => p["NamXuat"] + "" == "2" && p["HocKy"] + "" == "1");
                var tableDiemNam2Ky2 = dulieu.AsEnumerable().OrderBy(p => int.Parse("0" + p["ThucHanh"])).Where(p => p["NamXuat"] + "" == "2" && p["HocKy"] + "" == "2");

                CreateBangDiemExport(tableDiemNam2,
                    tableDiemNam2Ky1.AsDataView().Count > 0 ? tableDiemNam2Ky1.CopyToDataTable() : dulieu.Clone(),
                    tableDiemNam2Ky2.AsDataView().Count > 0 ? tableDiemNam2Ky2.CopyToDataTable() : dulieu.Clone());

                // nam 3 (neu co)
                var tableDiemNam3 = tableDiem.Clone();
                tableDiemNam3.TableName = "DiemNam3";

                var tableDiemNam3Ky1 = dulieu.AsEnumerable().OrderBy(p => int.Parse("0" + p["ThucHanh"])).Where(p => p["NamXuat"] + "" == "3" && p["HocKy"] + "" == "1");
                var tableDiemNam3Ky2 = dulieu.AsEnumerable().OrderBy(p => int.Parse("0" + p["ThucHanh"])).Where(p => p["NamXuat"] + "" == "3" && p["HocKy"] + "" == "2");


                CreateBangDiemExport(tableDiemNam3,
                    tableDiemNam3Ky1.AsDataView().Count > 0 ? tableDiemNam3Ky1.CopyToDataTable() : dulieu.Clone(),
                    tableDiemNam3Ky2.AsDataView().Count > 0 ? tableDiemNam3Ky2.CopyToDataTable() : dulieu.Clone());

                foreach (DataRow row in dulieu.Rows)
                {
                    #region ///
                    if (row["HocKy"] + "" != ky)
                    {
                        i = 0;
                        j = 0;
                        ky = row["HocKy"] + "";
                        if (row["NamXuat"] + "" == "1")
                        {
                            if (!inNamHoc1)
                            {
                                builder.MoveToBookmark("NamHoc_1");
                                builder.Write(row["TennamHoc"] + "");

                                builder.MoveToBookmark("NamHoc_2");
                                builder.Write(row["TennamHoc"] + "");
                                if (row["HocKy"] + "" == "1")
                                {
                                    builder.MoveToBookmark("KQ_XepLoai_Nam1_Ky1");
                                    builder.Write(row["TenXepLoai"] + "");
                                }

                                inNamHoc1 = true;
                            }
                            if (row["HocKy"] + "" == "2")
                            {
                                builder.MoveToBookmark("KQ_XepLoai_Nam1_Ky2");
                                builder.Write(row["TenXepLoai"] + "");
                            }
                        }
                        else if (row["NamXuat"] + "" == "2")
                        {
                            if (!inNamHoc2)
                            {
                                builder.MoveToBookmark("NamHoc_3");
                                builder.Write(row["TennamHoc"] + "");

                                builder.MoveToBookmark("NamHoc_4");
                                builder.Write(row["TennamHoc"] + "");
                                if (row["HocKy"] + "" == "1")
                                {
                                    builder.MoveToBookmark("KQ_XepLoai_Nam2_Ky1");
                                    builder.Write(row["TenXepLoai"] + "");
                                }

                                inNamHoc2 = true;
                            }
                            if (row["HocKy"] + "" == "2")
                            {
                                builder.MoveToBookmark("KQ_XepLoai_Nam2_Ky2");
                                builder.Write(row["TenXepLoai"] + "");
                            }
                        }
                        else if (row["NamXuat"] + "" == "3")
                        {

                            if (!inNamHoc3)
                            {
                                builder.MoveToBookmark("NamHoc_5");
                                builder.Write(row["TennamHoc"] + "");

                                builder.MoveToBookmark("NamHoc_6");
                                builder.Write(row["TennamHoc"] + "");

                                inNamHoc3 = true;
                            }
                            if (row["HocKy"] + "" == "1")
                            {
                                builder.MoveToBookmark("KQ_XepLoai_Nam3_Ky1");
                                builder.Write(row["TenXepLoai"] + "");
                            }

                            if (row["HocKy"] + "" == "2")
                            {
                                builder.MoveToBookmark("KQ_XepLoai_Nam3_Ky2");
                                builder.Write(row["TenXepLoai"] + "");
                            }
                        }

                    }
                    //if (int.Parse("0" + row["ThucHanh"]) == 0)
                    //{
                    //    i++;
                    //    builder.MoveToBookmark(string.Format("Nam_{0}_Ky_{1}_Mon_{2}_Ten", row["NamXuat"], row["HocKy"], i));
                    //    builder.Write(row["TenMonHoc"] + "");
                    //    builder.MoveToBookmark(string.Format("Nam_{0}_Ky_{1}_Mon_{2}_DVHT", row["NamXuat"], row["HocKy"], i));
                    //    builder.Write(row["SoHocTrinh"] + "");
                    //    builder.MoveToBookmark(string.Format("Nam_{0}_Ky_{1}_Mon_{2}_Diem1", row["NamXuat"], row["HocKy"], i));
                    //    builder.Write(row["DiemLan1"] + "");
                    //    builder.MoveToBookmark(string.Format("Nam_{0}_Ky_{1}_Mon_{2}_Diem2", row["NamXuat"], row["HocKy"], i));
                    //    builder.Write(row["DiemLan2"] + "");
                    //}
                    //else
                    //{

                    //    j++;
                    //    builder.MoveToBookmark(string.Format("Nam_{0}_Ky_{1}_Mon_TH_{2}_Ten", row["NamXuat"], row["HocKy"], j));
                    //    builder.Write(row["TenMonHoc"] + "");
                    //    builder.MoveToBookmark(string.Format("Nam_{0}_Ky_{1}_Mon_TH_{2}_DVHT", row["NamXuat"], row["HocKy"], j));
                    //    builder.Write(row["SoHocTrinh"] + "");
                    //    builder.MoveToBookmark(string.Format("Nam_{0}_Ky_{1}_Mon_TH_{2}_Diem1", row["NamXuat"], row["HocKy"], j));
                    //    builder.Write(row["DiemLan1"] + "");
                    //    builder.MoveToBookmark(string.Format("Nam_{0}_Ky_{1}_Mon_TH_{2}_Diem2", row["NamXuat"], row["HocKy"], j));
                    //    builder.Write(row["DiemLan2"] + "");

                    //}
                    #endregion
                }

                if (dThitn.Rows.Count > 0)
                {
                    for (int k = 0; k < dThitn.Rows.Count; k++)
                    {
                        builder.MoveToBookmark(string.Format("Diem_ThiTN_{0}_Ten", k));
                        builder.Write(dThitn.Rows[k]["TenMonHoc"].ToString());
                        builder.MoveToBookmark(string.Format("Diem_ThiTN_{0}", k));
                        builder.Write(dThitn.Rows[k]["Diem"].ToString());

                    }
                }
                else
                {
                    builder.MoveToBookmark(string.Format("Diem_ThiTN_{0}_Ten", 0));
                    builder.Write("Chính Trị");
                    builder.MoveToBookmark(string.Format("Diem_ThiTN_{0}", 0));
                    builder.Write(dttn.Rows[0]["TTN_CT"].ToString());
                    builder.MoveToBookmark(string.Format("Diem_ThiTN_{0}_Ten", 1));
                    builder.Write("Lý thuyết chuyên môn");
                    builder.MoveToBookmark(string.Format("Diem_ThiTN_{0}", 1));
                    builder.Write(dttn.Rows[0]["TTN_LTCM"].ToString());
                    builder.MoveToBookmark(string.Format("Diem_ThiTN_{0}_Ten", 2));
                    builder.Write("Thực hành nghề nghiệp");
                    builder.MoveToBookmark(string.Format("Diem_ThiTN_{0}", 2));
                    builder.Write(dttn.Rows[0]["TTN_THNN"].ToString());
                    
                }
                if (dttn.Rows.Count > 0)
                {
                    builder.MoveToBookmark("Diem_TBCToanKhoa");
                    builder.Write(dttn.Rows[0]["DiemToanKhoa"] + "");
                    builder.MoveToBookmark("Diem_TBCTotNghiep");
                    builder.Write(dttn.Rows[0]["DiemTotNghiep"] + "");
                    
                    builder.MoveToBookmark("DiemXepLoaiTN");
                    builder.Write(dttn.Rows[0]["DiemXepLoaiTotNghiep"] + "");
                    builder.MoveToBookmark("KQ_XepLoaiTNToanKhoa");
                    builder.Write(dttn.Rows[0]["XepLoaiTotNghiep"] + "");
                   
                }

                doc.MailMerge.RemoveEmptyRegions = true;
                doc.MailMerge.ExecuteWithRegions(tableDiemNam1);
                doc.MailMerge.ExecuteWithRegions(tableDiemNam2);
                doc.MailMerge.ExecuteWithRegions(tableDiemNam3);

                return doc;
            }
            catch (Exception ex)
            {
                ThongBaoLoi(ex.Message);
                return null;
            }}

        private void CreateBangDiemExport(DataTable resultTable, DataTable ky1, DataTable ky2)
        {
            var thucHanh = false;

            if (ky1.Rows.Count > 0)
            {
                DataRow firstRow = resultTable.NewRow();
                firstRow["STT_1"] = "I. ";
                firstRow["Ten_1"] = "Lý thuyết";
                resultTable.Rows.Add(firstRow);

                int stt = 1;
                foreach (DataRow row in ky1.Rows)
                {
                    if (int.Parse("0" + row["ThucHanh"]) > 0 && !thucHanh)
                    {
                        DataRow r = resultTable.NewRow();

                        r["STT_1"] = "II. ";
                        r["Ten_1"] = "Thực hành";
                        resultTable.Rows.Add(r);
                        thucHanh = true;
                        stt = 1;
                    }

                    DataRow rIm = resultTable.NewRow();
                    rIm["STT_1"] = stt + ". ";
                    rIm["Ten_1"] = row["TenMonHoc"];
                    rIm["DVHT_1"] = row["SoHocTrinh"];
                    rIm["Diem1_1"] = row["DiemLan1"];
                    rIm["Diem2_1"] = row["DiemLan2"];
                    resultTable.Rows.Add(rIm);
                    stt++;
                }
            }
            if (ky2.Rows.Count > 0)
            {
                thucHanh = false;

                DataRow rowInsert = null;
                if (resultTable.Rows.Count > 0)
                {
                    rowInsert = resultTable.Rows[0];
                }
                else
                {
                    rowInsert = resultTable.NewRow();
                }

                rowInsert["STT_2"] = "I. ";
                rowInsert["Ten_2"] = "Lý thuyết";

                if (resultTable.Rows.Count == 0)
                {
                    resultTable.Rows.Add(rowInsert);
                }

                int stt = 1;
                int rowIndex = 1;
                foreach (DataRow row in ky2.Rows)
                {
                    if (int.Parse("0" + row["ThucHanh"]) > 0 && !thucHanh)
                    {
                        DataRow r = null;
                        if (rowIndex >= resultTable.Rows.Count)
                        {
                            r = resultTable.NewRow();
                        }
                        else
                        {
                            r = resultTable.Rows[rowIndex];
                        }

                        r["STT_2"] = "II. ";
                        r["Ten_2"] = "Thực hành";

                        if (rowIndex >= resultTable.Rows.Count)
                        {
                            resultTable.Rows.Add(r);
                        }
                        thucHanh = true;
                        rowIndex++;
                        stt = 1;
                    }

                    DataRow rIm = null;
                    if (rowIndex >= resultTable.Rows.Count)
                    {
                        rIm = resultTable.NewRow();
                    }
                    else
                    {
                        rIm = resultTable.Rows[rowIndex];
                    }

                    rIm["STT_2"] = stt + ". ";
                    rIm["Ten_2"] = row["TenMonHoc"];
                    rIm["DVHT_2"] = row["SoHocTrinh"];
                    rIm["Diem1_2"] = row["DiemLan1"];
                    rIm["Diem2_2"] = row["DiemLan2"];

                    if (rowIndex >= resultTable.Rows.Count)
                    {
                        resultTable.Rows.Add(rIm);
                    }

                    rowIndex++;
                    stt++;
                }
            }
        }
    }
}
