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
    public partial class frmBaoCaoTangGiamBienChe : frmBase
    {
        private cBNS_Luong oBNS_Luong;
        private DataTable dtBaoCao;

        public frmBaoCaoTangGiamBienChe()
        {
            InitializeComponent();
            oBNS_Luong = new cBNS_Luong();
            dtpDenNgay.EditValue = DateTime.Now;
        }

        private void bgrvBaoCao_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void frmBaoCaoTangGiamBienChe_Load(object sender, EventArgs e)
        {
            CreateTable();
        }

        private void CreateTable()
        {
            dtBaoCao = new DataTable();
            dtBaoCao.Columns.Add("NS_NgachCongChucID", typeof(int));
            dtBaoCao.Columns.Add("MaNgachCongChuc", typeof(string));
            dtBaoCao.Columns.Add("TuyenMoi", typeof(int));
            dtBaoCao.Columns.Add("TongCong", typeof(int));
            dtBaoCao.Columns.Add("ChuyenNoiKhac", typeof(int));
            dtBaoCao.Columns.Add("NghiHuu", typeof(int));
            dtBaoCao.Columns.Add("ThoiViec", typeof(int));
            dtBaoCao.Columns.Add("ThucTang", typeof(int));
            dtBaoCao.Columns.Add("ThucGiam", typeof(int));
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
            DataTable dt = oBNS_Luong.GetSoLuongCongChuc((DateTime)dtpDenNgay.EditValue);
            if (dt.Rows.Count <= 0)
                return;
            int TuyenMoi = 0, TongCong = 0, ChuyenNoiKhac = 0, NghiHuu = 0, ThoiViec = 0;
            string NS_NgachCongChucID = dt.Rows[0]["NS_NgachCongChucID"].ToString();

            DataRow drNew = dtBaoCao.NewRow();
            drNew["NS_NgachCongChucID"] = int.Parse(NS_NgachCongChucID);
            drNew["MaNgachCongChuc"] = dt.Rows[0]["MaNgachCongChuc"].ToString();
            foreach (DataRow dr in dt.Rows)
            {
                if (NS_NgachCongChucID != dr["NS_NgachCongChucID"].ToString())
                {
                    if(TuyenMoi > 0)
                        drNew["TuyenMoi"] = TuyenMoi;
                    if (TongCong > 0)
                        drNew["TongCong"] = TongCong;
                    if (ChuyenNoiKhac > 0)
                        drNew["ChuyenNoiKhac"] = ChuyenNoiKhac;
                    if (NghiHuu > 0)
                        drNew["NghiHuu"] = NghiHuu;
                    if (ThoiViec > 0)
                        drNew["ThoiViec"] = ThoiViec;

                    if ((TuyenMoi > (ChuyenNoiKhac + NghiHuu + ThoiViec)) && ((TuyenMoi - (ChuyenNoiKhac + NghiHuu + ThoiViec)) > 0))
                        drNew["ThucTang"] = TuyenMoi - (ChuyenNoiKhac + NghiHuu + ThoiViec);
                    if (((ChuyenNoiKhac + NghiHuu + ThoiViec) > TuyenMoi) && (((ChuyenNoiKhac + NghiHuu + ThoiViec) - TuyenMoi) > 0))
                        drNew["ThucGiam"] = (ChuyenNoiKhac + NghiHuu + ThoiViec) - TuyenMoi;
                    dtBaoCao.Rows.Add(drNew);

                    TuyenMoi = 0;
                    TongCong = 0;
                    ChuyenNoiKhac = 0;
                    NghiHuu = 0;
                    ThoiViec = 0;
                    NS_NgachCongChucID = dr["NS_NgachCongChucID"].ToString();
                    drNew = dtBaoCao.NewRow();
                    drNew["NS_NgachCongChucID"] = int.Parse(NS_NgachCongChucID);
                    drNew["MaNgachCongChuc"] = dr["MaNgachCongChuc"].ToString();
                }
                if ("" + dr["IDNS_HinhThucNghiViec"] == "")
                {
                    TongCong++;
                    TuyenMoi++;
                }
                if ("" + dr["IDNS_HinhThucNghiViec"] == "CHUYENCONGTAC")
                    ChuyenNoiKhac++;
                if ("" + dr["IDNS_HinhThucNghiViec"] == "NGHIHUU")
                    NghiHuu++;
                if ("" + dr["IDNS_HinhThucNghiViec"] == "THOIVIEC")
                    ThoiViec++;
            }
            if (TuyenMoi > 0)
                drNew["TuyenMoi"] = TuyenMoi;
            if (TongCong > 0)
                drNew["TongCong"] = TongCong;
            if (ChuyenNoiKhac > 0)
                drNew["ChuyenNoiKhac"] = ChuyenNoiKhac;
            if (NghiHuu > 0)
                drNew["NghiHuu"] = NghiHuu;
            if (ThoiViec > 0)
                drNew["ThoiViec"] = ThoiViec;

            if ((TuyenMoi > (ChuyenNoiKhac + NghiHuu + ThoiViec)) && ((TuyenMoi - (ChuyenNoiKhac + NghiHuu + ThoiViec)) > 0))
                drNew["ThucTang"] = TuyenMoi - (ChuyenNoiKhac + NghiHuu + ThoiViec);
            if (((ChuyenNoiKhac + NghiHuu + ThoiViec) > TuyenMoi) && (((ChuyenNoiKhac + NghiHuu + ThoiViec) - TuyenMoi) > 0))
                drNew["ThucGiam"] = (ChuyenNoiKhac + NghiHuu + ThoiViec) - TuyenMoi;
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
            string strFileExcel = DuongDan + "\\Template\\Temp_BaoCaoTangGiamBienChe.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + "! Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                return;
            }
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Excel file (*.xls)|*.xls";
            sv.Title = "Xuất dữ liệu";
            sv.FileName = "Bao cao tang giam bien che " + ((DateTime)dtpDenNgay.EditValue).ToString("yyyyMMdd") + ".xls";
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
            int DongBatDau = 9, SoCot = 12;
            Excel.Range cel;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);
                excel.Cells[4, 1] = "BÁO CÁO TĂNG GIẢM BIÊN CHẾ NĂM " + DateTime.Parse(dtpDenNgay.EditValue.ToString()).Year;
                excel.Cells[5, 1] = "(Có đến ngày " + dtpDenNgay.Text + ")";

                int count = dtBaoCao.Rows.Count;
                DataRow dr;
                for (int i = 0; i < count; i++)
                {
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 1]);
                    cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                    dr = dtBaoCao.Rows[i];

                    excel.Cells[i + DongBatDau, 1] = i + 1;
                    excel.Cells[i + DongBatDau, 2] = "" + dr["MaNgachCongChuc"];
                    excel.Cells[i + DongBatDau, 3] = "" + dr["TuyenMoi"];
                    excel.Cells[i + DongBatDau, 5] = "" + dr["TongCong"];
                    excel.Cells[i + DongBatDau, 6] = "" + dr["ChuyenNoiKhac"];
                    excel.Cells[i + DongBatDau, 7] = "" + dr["NghiHuu"];
                    excel.Cells[i + DongBatDau, 8] = "" + dr["ThoiViec"];
                    excel.Cells[i + DongBatDau, 11] = "" + dr["ThucTang"];
                    excel.Cells[i + DongBatDau, 12] = "" + dr["ThucGiam"];
                }
                // Them dong tong
                cel = (Excel.Range)(excel.Cells[count + DongBatDau + 1, 1]);
                cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);

                excel.Cells[count + DongBatDau, 2] = "Tổng cộng";
                excel.Cells[count + DongBatDau, 3] = dtBaoCao.Compute("Sum(TuyenMoi)", "").ToString();
                excel.Cells[count + DongBatDau, 5] = dtBaoCao.Compute("Sum(TongCong)", "").ToString();
                excel.Cells[count + DongBatDau, 6] = dtBaoCao.Compute("Sum(ChuyenNoiKhac)", "").ToString();
                excel.Cells[count + DongBatDau, 7] = dtBaoCao.Compute("Sum(NghiHuu)", "").ToString();
                excel.Cells[count + DongBatDau, 8] = dtBaoCao.Compute("Sum(ThoiViec)", "").ToString();
                excel.Cells[count + DongBatDau, 11] = dtBaoCao.Compute("Sum(ThucTang)", "").ToString();
                excel.Cells[count + DongBatDau, 12] = dtBaoCao.Compute("Sum(ThucGiam)", "").ToString();
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