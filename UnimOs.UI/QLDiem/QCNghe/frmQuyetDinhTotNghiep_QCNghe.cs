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

namespace UnimOs.UI
{
    public partial class frmQuyetDinhTotNghiep_QCNghe : frmBase
    {
        private cBKQHT_QuyetDinhTotNghiep oBKQHT_QuyetDinhTotNghiep;
        private cBKQHT_QuyetDinhTotNghiep_SinhVien oBKQHT_QuyetDinhTotNghiep_SinhVien;
        private cBSV_SinhVien oBSV_SinhVien;
        public DataTable dtQuyetDinh;
        private DataTable dtSinhVien;
        private DataRow drQuyetDinh;

        public frmQuyetDinhTotNghiep_QCNghe()
        {
            InitializeComponent();
            oBKQHT_QuyetDinhTotNghiep = new cBKQHT_QuyetDinhTotNghiep();
            oBKQHT_QuyetDinhTotNghiep_SinhVien = new cBKQHT_QuyetDinhTotNghiep_SinhVien();
            oBSV_SinhVien = new cBSV_SinhVien();

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
                    frmDevReport frm = new frmDevReport(dtReport, "rBangDiemCaoDangLT_VietDuc",
                        new string[] { "DiemNam1", "DiemNam2", "TTN_CT", "TTN_LTCM", "TTN_THNN", "DiemToanKhoa", "DiemXLTotNghiep" }, "0:n1", "groupSV_SinhVienID", "SV_SinhVienID");
                    frm.ShowDialog();
                }
            }
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

        }

        private void grvTotNghiep_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvTotNghiep, "Chon", e);
        }

        private void barbtnInBangDiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dtSinhVien != null || dtSinhVien.Rows.Count > 0)
            {
                int[] arrDr = grvTotNghiep.GetSelectedRows();
                if (arrDr.Length > 0)
                {
                    DataRow dr;
                    string IDSV_SinhViens = "";
                    foreach (int i in arrDr)
                    {
                        dr = grvTotNghiep.GetDataRow(i);
                        IDSV_SinhViens += dr["SV_SinhVienID"] + ",";
                    }
                    IDSV_SinhViens = IDSV_SinhViens.Substring(0, IDSV_SinhViens.Length - 1);
                    DataTable dtReport = oBKQHT_QuyetDinhTotNghiep_SinhVien.GetBangDiemLanCuoi(IDSV_SinhViens, Program.IDNamHoc, Program.NamHoc);
                    frmDevReport frm = new frmDevReport(dtReport, "rBangDiemCaoDangLT_VietDuc",
                        new string[] { "DiemNam1", "DiemNam2", "TTN_CT", "TTN_LTCM", "TTN_THNN", "DiemToanKhoa", "DiemXLTotNghiep" }, "0:n1", "groupSV_SinhVienID", "SV_SinhVienID");
                    frm.ShowDialog();
                }
            }
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

            SaveFileDialog sv = new SaveFileDialog();
            sv.FileName = "BangDiemCuoiKhoa_" + drSinhVien["MaSinhVien"] + ".xls";
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
                DataTable dt = oBKQHT_QuyetDinhTotNghiep_SinhVien.GetBangDiemLanCuoi(drSinhVien["SV_SinhVienID"].ToString(), Program.IDNamHoc, Program.NamHoc);
                XuatBangDiemRaExcel(dt, strTenFileExcelMoi);
                ThongBao("Xuất dữ liệu thành công!");
            }
        }

        private void XuatBangDiemRaExcel(DataTable dtChiTiet, string FileExcel)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int DongBatDau = 13;
            Excel.Range cel;
            DataRow dr;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);

                dr = dtChiTiet.Rows[0];

                excel.Cells[5, 1] = dr["TenTrinhDo"].ToString();

                excel.Cells[6, 3] = dr["HoVaTen"].ToString();

                excel.Cells[7, 3] = dr["NgaySinh"].ToString();

                cel = (Excel.Range)excel.Cells[8, 2];
                excel.Cells[8, 2] = cel.Text + "  " + dr["NoiSinh"];

                excel.Cells[6, 9] = dr["TenNganh"].ToString();

                excel.Cells[7, 9] = dr["TenHe"].ToString();

                excel.Cells[8, 9] = dr["TenLop"].ToString();

                excel.Cells[9, 9] = dr["TenKhoaHoc"].ToString();

                excel.Cells[10, 3] = dr["NamThuNhat"].ToString();

                excel.Cells[10, 9] = dr["NamThuHai"].ToString();

                excel.Cells[16, 4] = dr["TTN_CT"].ToString();

                excel.Cells[17, 4] = dr["TTN_LTCM"].ToString();

                excel.Cells[18, 4] = dr["TTN_THNN"].ToString();

                excel.Cells[19, 4] = dr["DiemToanKhoa"].ToString();

                excel.Cells[20, 4] = dr["DiemTotNghiep"].ToString();

                excel.Cells[21, 4] = dr["XepLoaiTotNghiep"].ToString();

                cel = (Excel.Range)excel.Cells[22, 2];
                excel.Cells[22, 2] = cel.Text.ToString().Replace("[SoQuyetDinh]", dr["SoQuyetDinh"].ToString()).Replace("[NgayQuyetDinh]", dr["NgayQuyetDinh"].ToString());

                cel = (Excel.Range)excel.Cells[23, 8];
                excel.Cells[23, 8] = cel.Text + ", " + dr["NgayKy"].ToString();

                foreach (DataRow drItem in dtChiTiet.Rows)
                {
                    // Insert rows
                    cel = (Excel.Range)(excel.Cells[DongBatDau + 1, 1]);
                    cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);

                    excel.Cells[DongBatDau, 1] = "" + drItem["TT1"];

                    excel.Cells[DongBatDau, 2] = "" + drItem["TenMonHoc1"];

                    cel = excel.get_Range(excel.Cells[DongBatDau, 2], excel.Cells[DongBatDau, 3]);
                    cel.Merge(null);

                    excel.Cells[DongBatDau, 4] = "" + drItem["SoHocTrinh1"];

                    excel.Cells[DongBatDau, 5] = "" + drItem["DiemNam1"];

                    excel.Cells[DongBatDau, 7] = "" + drItem["TT2"];

                    excel.Cells[DongBatDau, 8] = "" + drItem["TenMonHoc2"];
                    cel = excel.get_Range(excel.Cells[DongBatDau, 8], excel.Cells[DongBatDau, 9]);
                    cel.Merge(null);

                    excel.Cells[DongBatDau, 10] = "" + drItem["SoHocTrinh2"];

                    excel.Cells[DongBatDau, 11] = "" + drItem["DiemNam2"];

                    DongBatDau++;
                }

                cel = (Excel.Range)(excel.Cells[DongBatDau, 1]);
                cel.EntireRow.Delete(Excel.XlDirection.xlUp);

                // Set style
                cel = excel.get_Range(excel.Cells[13, 1], excel.Cells[DongBatDau - 1, 5]);
                cel.Borders.Value = 1;

                cel = excel.get_Range(excel.Cells[13, 7], excel.Cells[DongBatDau - 1, 11]);
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
                XuatDuLieuRaExcel(dtBaoCao, strTenFileExcelMoi, TrangThai);
                ThongBao("Xuất dữ liệu thành công!");
            }
        }

        private void XuatDuLieuRaExcel(DataTable dtBaoCao, string FileExcel, string TrangThai)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int DongBatDau = 10;
            Excel.Range cel;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);
                if (TrangThai == "YES")
                    excel.Cells[4, 1] = "DANH SÁCH SINH VIÊN ĐỦ ĐIỀU KIỆN TỐT NGHIỆP";
                else
                    excel.Cells[4, 1] = "DANH SÁCH SINH VIÊN KHÔNG ĐỦ ĐIỀU KIỆN TỐT NGHIỆP";
                excel.Cells[5, 3] = Program.NamHoc;

                for (int i = 0; i < dtBaoCao.Rows.Count; i++)
                {
                    //Xử lý cho cột 1: STT
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 1]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    excel.Cells[i + DongBatDau + 0, 1] = i + 1;
                    //Xử lý cho cột 2: Mã SV
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 2]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    excel.Cells[i + DongBatDau + 0, 2] = (dtBaoCao.Rows[i]["MaSinhVien"] + "");
                    //Xử lý cho cột 3: Tên SV
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 3]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    excel.Cells[i + DongBatDau + 0, 3] = (dtBaoCao.Rows[i]["HoVaTen"] + "");
                    //Xử lý cho cột 4: Ngày sinh
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 4]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    if (dtBaoCao.Rows[i]["NgaySinh"] + "" != "")
                    {
                        string str = dtBaoCao.Rows[i]["NgaySinh"] + "";
                        str = str.Replace("12:00:00 AM", "");
                        excel.Cells[i + DongBatDau + 0, 4] = str;
                        //excel.Cells[i + DongBatDau + 0, 4] = DateTime.Parse(dtBaoCao.Rows[i]["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                    }
                    else
                        excel.Cells[i + DongBatDau + 0, 4] = "";
                    //Xử lý cho cột 5: Điểm môn TN1
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 5]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    excel.Cells[i + DongBatDau + 0, 5] = (dtBaoCao.Rows[i]["DiemMonTotNghiep1"] + "");
                    //Xử lý cho cột 6: Điểm môn TN2
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 6]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    excel.Cells[i + DongBatDau + 0, 6] = (dtBaoCao.Rows[i]["DiemMonTotNghiep2"] + "");
                    //Xử lý cho cột 7: Điểm môn TN3
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 7]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    excel.Cells[i + DongBatDau + 0, 7] = (dtBaoCao.Rows[i]["DiemMonTotNghiep3"] + "");
                    //Xử lý cho cột 8: Điểm TBC TK
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 8]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    excel.Cells[i + DongBatDau + 0, 8] = (dtBaoCao.Rows[i]["DiemTrungBinhChungToanKhoa"] + "");
                    //Xử lý cho cột 9: Điểm TBC TN
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 9]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    excel.Cells[i + DongBatDau + 0, 9] = (dtBaoCao.Rows[i]["DiemTrungBinhChungTotNghiep"] + "");
                    //Xử lý cho cột 10: Điểm XL TN
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 10]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    excel.Cells[i + DongBatDau + 0, 10] = (dtBaoCao.Rows[i]["DiemXepLoaiTotNghiep"] + "");
                    //Xử lý cho cột 11: Điểm XL TN
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 11]);
                    cel.WrapText = true;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    if (TrangThai == "YES")
                    {
                        excel.Cells[i + DongBatDau, 11] = (dtBaoCao.Rows[i]["TenXepLoai"] + "");
                    }
                }
                for (int k = 1; k <= 11; k++)
                {
                    cel = (Excel.Range)(excel.Cells[(dtBaoCao.Rows.Count + DongBatDau) - 1, k]);
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                }
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
    }
}
