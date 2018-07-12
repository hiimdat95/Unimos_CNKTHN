using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using TruongViet.UnimOs.Business;
using System.IO;
using System.Diagnostics;

namespace UnimOs.UI
{
    public partial class frmBaoCaoKeHoachBienCheSuNghiep : frmBase
    {
        private cBNS_QuaTrinhBoNhiemChucVu oBNS_QuaTrinhBoNhiemChucVu;
        private DataTable dtBaoCao;
        private cBNS_Luong oBNS_Luong;
        private DataTable dtBaoCaoTemp;

        public frmBaoCaoKeHoachBienCheSuNghiep()
        {
            InitializeComponent();
            oBNS_QuaTrinhBoNhiemChucVu = new cBNS_QuaTrinhBoNhiemChucVu();
            oBNS_Luong = new cBNS_Luong();
            dtpDenNgay.EditValue = DateTime.Now;
            grdbBienCheDuocGiao.Caption = "Biên chế được giao năm " + DateTime.Parse(dtpDenNgay.EditValue.ToString()).Year.ToString();
            grdbCoMatDen.Caption = "Có mặt đến " + dtpDenNgay.Text;
            grdbKeHoachNam.Caption = "Kế hoạch năm " + (DateTime.Parse(dtpDenNgay.EditValue.ToString()).Year + 1).ToString();
            bgcolHDLĐuocGiamNam.Caption = "68 được giao năm " + DateTime.Parse(dtpDenNgay.EditValue.ToString()).Year.ToString();
            bgcolKHCuaNam.Caption = "KH lao động theo Nghị định 68 của năm " + DateTime.Parse(dtpDenNgay.EditValue.ToString()).Year.ToString();
        }

        private void bgrvBaoCao_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void frmBaoCaoKeHoachBienCheSuNghiep_Load(object sender, EventArgs e)
        {
            CreateTable();
        }

        private void CreateTable()
        {
            dtBaoCao = new DataTable();
            dtBaoCao.Columns.Add("ID", typeof(int));
            dtBaoCao.Columns.Add("TenDonVi", typeof(string));
            dtBaoCao.Columns.Add("SoQDThanhLap", typeof(string));
            dtBaoCao.Columns.Add("CCQDThanhLap", typeof(string));
            dtBaoCao.Columns.Add("TongSo", typeof(int));
            dtBaoCao.Columns.Add("VCLanhDao", typeof(int));
            dtBaoCao.Columns.Add("VCTrongBMQL", typeof(int));
            dtBaoCao.Columns.Add("VCConLai", typeof(int));
        }

        private void CreateTableTemp()
        {
            dtBaoCaoTemp = new DataTable();
            dtBaoCaoTemp.Columns.Add("NS_NgachCongChucID", typeof(int));
            dtBaoCaoTemp.Columns.Add("MaNgachCongChuc", typeof(string));
            dtBaoCaoTemp.Columns.Add("TuyenMoi", typeof(int));
            dtBaoCaoTemp.Columns.Add("TongCong", typeof(int));
            dtBaoCaoTemp.Columns.Add("ChuyenNoiKhac", typeof(int));
            dtBaoCaoTemp.Columns.Add("NghiHuu", typeof(int));
            dtBaoCaoTemp.Columns.Add("ThoiViec", typeof(int));
            dtBaoCaoTemp.Columns.Add("ThucTang", typeof(int));
            dtBaoCaoTemp.Columns.Add("ThucGiam", typeof(int));
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dtpDenNgay.EditValue == null)
            {
                ThongBao("Bạn chưa chọn ngày báo cáo !");
                return;
            }

            if (dtBaoCao != null)
                dtBaoCao.Rows.Clear();
            XuLyTable();
            grdBaoCao.DataSource = dtBaoCao;
        }

        private void XuLyTable()
        {
            DataTable dt = oBNS_QuaTrinhBoNhiemChucVu.GetSoLuongBienCheSuNghiep((DateTime)dtpDenNgay.EditValue);
            if (dt.Rows.Count <= 0)
                return;
            int VCLanhDao = 0, TongSo = 0, VCTrongBMQL = 0, VCConLai = 0;
            string ID = dt.Rows[0]["ID"].ToString();

            DataRow drNew = dtBaoCao.NewRow();
            drNew["ID"] = int.Parse(ID);
            drNew["TenDonVi"] = dt.Rows[0]["TenDonVi"].ToString();
            drNew["SoQDThanhLap"] = dt.Rows[0]["SoQDThanhLap"].ToString();
            drNew["CCQDThanhLap"] = dt.Rows[0]["CCQDThanhLap"].ToString();

            foreach (DataRow dr in dt.Rows)
            {
                if (ID != dr["ID"].ToString())
                {
                    if (VCLanhDao > 0)
                        drNew["VCLanhDao"] = VCLanhDao;
                    if (TongSo > 0)
                        drNew["TongSo"] = TongSo;
                    if (VCTrongBMQL > 0)
                        drNew["VCTrongBMQL"] = VCTrongBMQL;
                    if (VCConLai > 0)
                        drNew["VCConLai"] = VCConLai;
                    dtBaoCao.Rows.Add(drNew);

                    VCLanhDao = 0;
                    TongSo = 0;
                    VCTrongBMQL = 0;
                    VCConLai = 0;
                    ID = dr["ID"].ToString();
                    drNew = dtBaoCao.NewRow();
                    drNew["ID"] = int.Parse(ID);
                    drNew["TenDonVi"] = dr["TenDonVi"].ToString();
                    drNew["SoQDThanhLap"] = dr["SoQDThanhLap"].ToString();
                    drNew["CCQDThanhLap"] = dr["CCQDThanhLap"].ToString();
                }
                if ("" + dr["IDLoaiVienChuc"] == "")
                {
                    VCConLai++;
                }
                if ("" + dr["IDLoaiVienChuc"] == "VIENCHUCLANHDAO")
                    VCLanhDao++;
                if ("" + dr["IDLoaiVienChuc"] == "BOMAYQUANLY")
                    VCTrongBMQL++;
                TongSo = VCLanhDao + VCTrongBMQL + VCConLai; 
            }
            if (VCLanhDao > 0)
                drNew["VCLanhDao"] = VCLanhDao;
            if (TongSo > 0)
                drNew["TongSo"] = TongSo;
            if (VCTrongBMQL > 0)
                drNew["VCTrongBMQL"] = VCTrongBMQL;
            if (VCConLai > 0)
                drNew["VCConLai"] = VCConLai;
            dtBaoCao.Rows.Add(drNew);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            XuatTheoTemplate();
        }

        #region Xuat theo template
        private void XuatTheoTemplate()
        {
            if (dtBaoCao.Rows.Count == 0)
            {
                ThongBao("Không có dữ liệu để xuất ra excel!");
                return;
            }
            string DuongDan = Application.StartupPath;
            string strFileExcel = DuongDan + "\\Template\\Temp_BaoCaoKeHoachBienCheSuNghiep.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + "! Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                return;
            }
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Excel file (*.xls)|*.xls";
            sv.Title = "Xuất dữ liệu";
            sv.FileName = "Bao cao ke hoach bien che su nghiep " + ((DateTime)dtpDenNgay.EditValue).ToString("yyyyMMdd") + ".xls";
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
                XuatDuLieuRaExcel(strTenFileExcelMoi);
                ThongBao("Xuất dữ liệu thành công!");
            }
        }

        private void XuatDuLieuRaExcel(string FileExcel)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int DongBatDau = 17, SoCot = 19;
            Excel.Range cel;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);
                excel.Cells[4, 1] = "TỔNG HỢP KẾ HOẠCH BIÊN CHẾ SỰ NGHIỆP NĂM " + DateTime.Parse(dtpDenNgay.EditValue.ToString()).Year;
                excel.Cells[6, 1] = "I. Đánh giá tình hình quản lý và sử dụng biên chế sự nghiệp năm " + DateTime.Parse(dtpDenNgay.EditValue.ToString()).Year;

                DataTable dt = oBNS_Luong.GetSoLuongCongChuc((DateTime)dtpDenNgay.EditValue);
                if (dt.Rows.Count > 0)
                {
                    int ChuyenNoiKhac = 0, NghiHuu = 0, ThoiViec = 0;
                    string NS_NgachCongChucID = dt.Rows[0]["NS_NgachCongChucID"].ToString();
                    CreateTableTemp();
                    DataRow drNew = dtBaoCaoTemp.NewRow();
                    drNew["NS_NgachCongChucID"] = int.Parse(NS_NgachCongChucID);
                    drNew["MaNgachCongChuc"] = dt.Rows[0]["MaNgachCongChuc"].ToString();
                    foreach (DataRow drtemp in dt.Rows)
                    {
                        if (NS_NgachCongChucID != drtemp["NS_NgachCongChucID"].ToString())
                        {
                            if (ChuyenNoiKhac > 0)
                                drNew["ChuyenNoiKhac"] = ChuyenNoiKhac;
                            if (NghiHuu > 0)
                                drNew["NghiHuu"] = NghiHuu;
                            if (ThoiViec > 0)
                                drNew["ThoiViec"] = ThoiViec;
                            dtBaoCaoTemp.Rows.Add(drNew);
                            ChuyenNoiKhac = 0;
                            NghiHuu = 0;
                            ThoiViec = 0;
                            NS_NgachCongChucID = drtemp["NS_NgachCongChucID"].ToString();
                            drNew = dtBaoCaoTemp.NewRow();
                            drNew["NS_NgachCongChucID"] = int.Parse(NS_NgachCongChucID);
                            drNew["MaNgachCongChuc"] = drtemp["MaNgachCongChuc"].ToString();
                        }
                        if ("" + drtemp["IDNS_HinhThucNghiViec"] == "CHUYENCONGTAC")
                            ChuyenNoiKhac++;
                        if ("" + drtemp["IDNS_HinhThucNghiViec"] == "NGHIHUU")
                            NghiHuu++;
                        if ("" + drtemp["IDNS_HinhThucNghiViec"] == "THOIVIEC")
                            ThoiViec++;
                    }
                    if (ChuyenNoiKhac > 0)
                        drNew["ChuyenNoiKhac"] = ChuyenNoiKhac;
                    if (NghiHuu > 0)
                        drNew["NghiHuu"] = NghiHuu;
                    if (ThoiViec > 0)
                        drNew["ThoiViec"] = ThoiViec;
                    dtBaoCaoTemp.Rows.Add(drNew);

                    excel.Cells[8, 6] = "Nghi hưu năm " + DateTime.Parse(dtpDenNgay.EditValue.ToString()).Year.ToString() + ":   " + dtBaoCaoTemp.Compute("Sum(NghiHuu)", "").ToString();
                    excel.Cells[9, 6] = "Xin thôi việc năm " + DateTime.Parse(dtpDenNgay.EditValue.ToString()).Year.ToString() + ":  " + dtBaoCaoTemp.Compute("Sum(ThoiViec)", "").ToString();
                    excel.Cells[10, 6] = "Chuyển công tác năm " + DateTime.Parse(dtpDenNgay.EditValue.ToString()).Year.ToString() + ":   " + dtBaoCaoTemp.Compute("Sum(ChuyenNoiKhac)", "").ToString();
                }

                excel.Cells[13, 1] = "II. Biên chế sự nghiệp năm " + DateTime.Parse(dtpDenNgay.EditValue.ToString()).Year;
                excel.Cells[15, 5] = "HĐLĐ theo Nghị định 68 được giao năm " + DateTime.Parse(dtpDenNgay.EditValue.ToString()).Year;
                excel.Cells[15, 6] = "Biên chế được giao năm " + DateTime.Parse(dtpDenNgay.EditValue.ToString()).Year;
                excel.Cells[15, 10] = "Có mặt đến " + dtpDenNgay.Text;
                excel.Cells[15, 14] = "Kế hoạch năm " + (DateTime.Parse(dtpDenNgay.EditValue.ToString()).Year + 1).ToString();
                excel.Cells[16, 18] = "KH lao động theo Nghị định 68 của năm " + DateTime.Parse(dtpDenNgay.EditValue.ToString()).Year;
                int count = dtBaoCao.Rows.Count;
                DataRow dr;
                for (int i = 0; i < count; i++)
                {
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 1]);
                    cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                    dr = dtBaoCao.Rows[i];

                    excel.Cells[i + DongBatDau, 1] = i + 1;
                    excel.Cells[i + DongBatDau, 2] = "" + dr["TenDonVi"];
                    excel.Cells[i + DongBatDau, 3] = "" + dr["SoQDThanhLap"];
                    excel.Cells[i + DongBatDau, 4] = "" + dr["CCQDThanhLap"];
                    excel.Cells[i + DongBatDau, 10] = "" + dr["TongSo"];
                    excel.Cells[i + DongBatDau, 11] = "" + dr["VCLanhDao"];
                    excel.Cells[i + DongBatDau, 12] = "" + dr["VCTrongBMQL"];
                    excel.Cells[i + DongBatDau, 13] = "" + dr["VCConLai"];
                }
                // Them dong tong
                cel = (Excel.Range)(excel.Cells[count + DongBatDau + 1, 1]);
                cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);

                excel.Cells[count + DongBatDau, 2] = "Tổng cộng";
                excel.Cells[count + DongBatDau, 10] = dtBaoCao.Compute("Sum(TongSo)", "").ToString();
                excel.Cells[count + DongBatDau, 11] = dtBaoCao.Compute("Sum(VCLanhDao)", "").ToString();
                excel.Cells[count + DongBatDau, 12] = dtBaoCao.Compute("Sum(VCTrongBMQL)", "").ToString();
                excel.Cells[count + DongBatDau, 13] = dtBaoCao.Compute("Sum(VCConLai)", "").ToString();
                cel = excel.get_Range(excel.Cells[count + DongBatDau, 1], excel.Cells[DongBatDau + count, SoCot]);
                cel.Font.Bold = true;

                // Set style
                cel = excel.get_Range(excel.Cells[DongBatDau, 1], excel.Cells[DongBatDau + count - 1, SoCot]);
                cel.Borders.LineStyle = Excel.XlLineStyle.xlDot;
                cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;

                cel = excel.get_Range(excel.Cells[DongBatDau, 1], excel.Cells[DongBatDau + count, 1]);
                cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;

                for (int j = 1; j <= SoCot; j++)
                {
                    cel = excel.get_Range(excel.Cells[DongBatDau, j], excel.Cells[DongBatDau + count, j]);
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                }

                cel = excel.get_Range(excel.Cells[DongBatDau + count, 1], excel.Cells[DongBatDau + count, SoCot]);
                cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
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
    }
}