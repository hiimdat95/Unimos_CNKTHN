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
using TruongViet.UnimOs.Entity;
using System.IO;
using System.Diagnostics;
namespace UnimOs.UI
{
    public partial class frmBaoCaoSoLuongCongChucVaHocSinh : frmBase
    {
        private cBNS_GiaoVien oBNS_GiaoVien;
        private DataTable dtBaoCao;
        public frmBaoCaoSoLuongCongChucVaHocSinh()
        {
            InitializeComponent();
            dtpDenNgay.EditValue = DateTime.Now;
            oBNS_GiaoVien = new cBNS_GiaoVien();
            grdbBinhQuan.Caption = "Bình quân năm (từ " + DateTime.Parse(dtpDenNgay.EditValue.ToString()).Day + "/" + DateTime.Parse(dtpDenNgay.EditValue.ToString()).Month + "/" + (DateTime.Parse(dtpDenNgay.EditValue.ToString()).Year + 1).ToString() + " sđến " + dtpDenNgay.Text + ")";
        }

        private void frmBaoCaoSoLuongCongChucVaHocSinh_Load(object sender, EventArgs e)
        {
            CreateTable();
        }

        private void bgrvBaoCao_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dtpDenNgay.EditValue == null)
            {
                ThongBao("Bạn phải chọn đến ngày !");
                return;
            }
            CreateTable();
            XuLyTable();
            grdBaoCao.DataSource = dtBaoCao;
        }

        private void CreateTable()
        {
            dtBaoCao = new DataTable();
            dtBaoCao.Columns.Add("ID", typeof(string));
            dtBaoCao.Columns.Add("TenKhoi", typeof(string));
            dtBaoCao.Columns.Add("IDNS_LinhVucCongTac", typeof(int));
            dtBaoCao.Columns.Add("DaiHanTapTrung", typeof(int));
            dtBaoCao.Columns.Add("TaiChuc", typeof(int));
            dtBaoCao.Columns.Add("TongSoBienChe", typeof(int));
            dtBaoCao.Columns.Add("DungLopBienChe", typeof(int));
            dtBaoCao.Columns.Add("PhucVuBienChe", typeof(int));
            dtBaoCao.Columns.Add("TongSoNgoaiBienChe", typeof(int));
            dtBaoCao.Columns.Add("DungLopNgoaiBienChe", typeof(int));
            dtBaoCao.Columns.Add("PhucVuNgoaiBienChe", typeof(int));
        }

        private void XuLyTable()
        {
            DataTable dt = oBNS_GiaoVien.GetBaoCaoChatLuongCanBo((DateTime)dtpDenNgay.EditValue);
            if (dt.Rows.Count <= 0)
                return;
            int TongSoBienChe = 0, DungLopBienChe = 0, PhucVuBienChe = 0;
            int TongSoNgoaiBienChe = 0, DungLopNgoaiBienChe = 0, PhucVuNgoaiBienChe = 0;
            string ID = dt.Rows[0]["ID"].ToString();

            DataRow drNew = dtBaoCao.NewRow();
            drNew["ID"] = int.Parse(ID);
            drNew["TenKhoi"] = "Cao đẳng, TCCN";//dt.Rows[0]["TenKhoi"].ToString();
            drNew["DaiHanTapTrung"] = dt.Rows[0]["DaiHanTapTrung"].ToString();
            drNew["TaiChuc"] = dt.Rows[0]["TaiChuc"].ToString();
            foreach (DataRow dr in dt.Rows)
            {
                if (ID != dr["ID"].ToString())
                {
                    if (DungLopBienChe > 0)
                        drNew["DungLopBienChe"] = DungLopBienChe;
                    if (PhucVuBienChe > 0)
                        drNew["PhucVuBienChe"] = PhucVuBienChe;
                    if (TongSoBienChe > 0)
                        drNew["TongSoBienChe"] = TongSoBienChe;
                    if (DungLopNgoaiBienChe > 0)
                        drNew["DungLopNgoaiBienChe"] = DungLopNgoaiBienChe;
                    if (PhucVuNgoaiBienChe > 0)
                        drNew["PhucVuNgoaiBienChe"] = PhucVuNgoaiBienChe;
                    if (TongSoNgoaiBienChe > 0)
                        drNew["TongSoNgoaiBienChe"] = TongSoNgoaiBienChe;
                    dtBaoCao.Rows.Add(drNew);

                    DungLopBienChe = 0;
                    PhucVuBienChe = 0;
                    TongSoBienChe = 0;
                    DungLopNgoaiBienChe = 0;
                    PhucVuNgoaiBienChe = 0;
                    TongSoNgoaiBienChe = 0;
                    ID = dr["ID"].ToString();
                    drNew = dtBaoCao.NewRow();
                    drNew["ID"] = int.Parse(ID);
                    drNew["TenKhoi"] = "Cao đẳng, TCCN";//dr["TenKhoi"].ToString();
                    drNew["DaiHanTapTrung"] = dt.Rows[0]["DaiHanTapTrung"].ToString();
                    drNew["TaiChuc"] = dt.Rows[0]["TaiChuc"].ToString();
                }
                if ("" + dr["IDHinhThucHDLD"] == "BCSN")
                {
                    if ("" + dr["IDNS_LinhVucCongTac"] == "1")
                        DungLopBienChe++;
                    else
                        PhucVuBienChe++;
                    TongSoBienChe++;
                }
                if ("" + dr["IDHinhThucHDLD"] == "TLKP")
                {
                    if ("" + dr["IDNS_LinhVucCongTac"] == "1")
                        DungLopNgoaiBienChe++;
                    else
                        PhucVuNgoaiBienChe++;
                    TongSoNgoaiBienChe++;
                }
            }
            if (DungLopBienChe > 0)
                drNew["DungLopBienChe"] = DungLopBienChe;
            if (PhucVuBienChe > 0)
                drNew["PhucVuBienChe"] = PhucVuBienChe;
            if (TongSoBienChe > 0)
                drNew["TongSoBienChe"] = TongSoBienChe;
            if (DungLopNgoaiBienChe > 0)
                drNew["DungLopNgoaiBienChe"] = DungLopNgoaiBienChe;
            if (PhucVuNgoaiBienChe > 0)
                drNew["PhucVuNgoaiBienChe"] = PhucVuNgoaiBienChe;
            if (TongSoNgoaiBienChe > 0)
                drNew["TongSoNgoaiBienChe"] = TongSoNgoaiBienChe;

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
            string strFileExcel = DuongDan + "\\Template\\Temp_BaoCaoSoLuongCongChucVaHocSinh.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + "! Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                return;
            }
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Excel file (*.xls)|*.xls";
            sv.Title = "Xuất dữ liệu";
            sv.FileName = "Bao cao so luong cong chuc va hoc sinh " + ((DateTime)dtpDenNgay.EditValue).ToString("yyyyMMdd") + ".xls";
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
            int DongBatDau = 10, SoCot = 12;
            Excel.Range cel;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);
                excel.Cells[4, 1] = "BÁO CÁO SỐ LƯỢNG CÔNG CHỨC VÀ HỌC SINH";
                excel.Cells[5, 1] = "Có mặt tại trường đến " + DateTime.Parse(dtpDenNgay.EditValue.ToString()).Day + " tháng " + DateTime.Parse(dtpDenNgay.EditValue.ToString()).Month + " năm " + DateTime.Parse(dtpDenNgay.EditValue.ToString()).Year;
                excel.Cells[7, 3] = "Bình quân năm (từ " + DateTime.Parse(dtpDenNgay.EditValue.ToString()).Day + "/" + DateTime.Parse(dtpDenNgay.EditValue.ToString()).Month + "/" + (DateTime.Parse(dtpDenNgay.EditValue.ToString()).Year + 1).ToString() + "đến " + dtpDenNgay.Text + ")";

                int count = dtBaoCao.Rows.Count;
                DataRow dr;
                for (int i = 0; i < count; i++)
                {
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 1]);
                    cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                    dr = dtBaoCao.Rows[i];

                    excel.Cells[i + DongBatDau, 1] = i + 1;
                    excel.Cells[i + DongBatDau, 2] = "" + dr["TenKhoi"];
                    excel.Cells[i + DongBatDau, 3] = "" + dr["DaiHanTapTrung"];
                    excel.Cells[i + DongBatDau, 4] = "" + dr["TaiChuc"];
                    excel.Cells[i + DongBatDau, 7] = "" + dr["TongSoBienChe"];
                    excel.Cells[i + DongBatDau, 8] = "" + dr["DungLopBienChe"];
                    excel.Cells[i + DongBatDau, 9] = "" + dr["PhucVuBienChe"];
                    excel.Cells[i + DongBatDau, 10] = "" + dr["TongSoNgoaiBienChe"];
                    excel.Cells[i + DongBatDau, 11] = "" + dr["DungLopNgoaiBienChe"];
                    excel.Cells[i + DongBatDau, 12] = "" + dr["PhucVuNgoaiBienChe"];
                }
                // Them dong tong
                cel = (Excel.Range)(excel.Cells[count + DongBatDau + 1, 1]);
                cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);

                excel.Cells[count + DongBatDau, 2] = "Tổng cộng";
                excel.Cells[count + DongBatDau, 3] = dtBaoCao.Compute("Sum(DaiHanTapTrung)", "").ToString();
                excel.Cells[count + DongBatDau, 4] = dtBaoCao.Compute("Sum(TaiChuc)", "").ToString();
                excel.Cells[count + DongBatDau, 7] = dtBaoCao.Compute("Sum(TongSoBienChe)", "").ToString();
                excel.Cells[count + DongBatDau, 8] = dtBaoCao.Compute("Sum(DungLopBienChe)", "").ToString();
                excel.Cells[count + DongBatDau, 9] = dtBaoCao.Compute("Sum(PhucVuBienChe)", "").ToString();
                excel.Cells[count + DongBatDau, 10] = dtBaoCao.Compute("Sum(TongSoNgoaiBienChe)", "").ToString();
                excel.Cells[count + DongBatDau, 11] = dtBaoCao.Compute("Sum(DungLopNgoaiBienChe)", "").ToString();
                excel.Cells[count + DongBatDau, 12] = dtBaoCao.Compute("Sum(PhucVuNgoaiBienChe)", "").ToString();
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