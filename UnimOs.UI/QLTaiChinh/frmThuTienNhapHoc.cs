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
    public partial class frmThuTienNhapHoc : frmBase
    {
        private cBSV_SinhVienNhapTruong oBSV_SinhVienNhapTruong;
        private SV_SinhVienNhapTruongInfo pSV_SinhVienNhapTruongInfo;
        private TC_BienLaiThuTienInfo pTC_BienLaiThuTienInfo;
        private cBTC_BienLaiThuTien oBTC_BienLaiThuTien;
        private DataTable dtSinhVien;
        private DataRow drSinhVien;
        public frmThuTienNhapHoc()
        {
            InitializeComponent();
            oBSV_SinhVienNhapTruong = new cBSV_SinhVienNhapTruong();
            pSV_SinhVienNhapTruongInfo = new SV_SinhVienNhapTruongInfo();
        }

        private void frmThuTienNhapHoc_Load(object sender, EventArgs e)
        {
            dtSinhVien = oBSV_SinhVienNhapTruong.GetByNamHoc(Program.IDNamHoc);
            grdSinhVien.DataSource = dtSinhVien;

        }

        private void grvSinhVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnThuTien_Click(object sender, EventArgs e)
        {
            if (grvSinhVien.FocusedRowHandle >= 0)
            {
                dlgBienLaiThuTienNhapHoc dlg = new dlgBienLaiThuTienNhapHoc(drSinhVien, false);
                dlg.ShowDialog();
                if (dlg.Tag.ToString() == "1")
                    frmThuTienNhapHoc_Load(null, null);
            }
        }

        private void grvSinhVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvSinhVien.FocusedRowHandle >= 0)
            {
                drSinhVien = grvSinhVien.GetDataRow(grvSinhVien.FocusedRowHandle);
            }
        }

        private void btnSUa_Click(object sender, EventArgs e)
        {
           if (grvSinhVien.FocusedRowHandle >= 0)
            {
                if ((bool)grvSinhVien.GetDataRow(grvSinhVien.FocusedRowHandle)["DaThuTien"])
                {
                    dlgBienLaiThuTienNhapHoc dlg = new dlgBienLaiThuTienNhapHoc(drSinhVien, true);
                    dlg.ShowDialog();
                    if (dlg.Tag.ToString() == "1")
                        frmThuTienNhapHoc_Load(null, null);
                }
                else
                    ThongBao("Sinh viên chưa nộp tiền!");
            }
            else
                ThongBao("Chưa chọn sinh viên!");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dlgThemSinhVienNhapHoc dlg = new dlgThemSinhVienNhapHoc();
            dlg.ShowDialog();
            if (dlg.DialogResult == DialogResult.OK)
                frmThuTienNhapHoc_Load(null, null);
        }

        private void btnXoaBienLai_Click(object sender, EventArgs e)
        {
            pTC_BienLaiThuTienInfo = new TC_BienLaiThuTienInfo();
            oBTC_BienLaiThuTien = new cBTC_BienLaiThuTien();
            if (grvSinhVien.FocusedRowHandle >= 0)
            {
                if ((bool)grvSinhVien.GetDataRow(grvSinhVien.FocusedRowHandle)["DaThuTien"])
                {
                    if (ThongBaoChon("Bạn chắc chắn muốn xóa?") == DialogResult.Yes)
                    {
                        try
                        {
                            pTC_BienLaiThuTienInfo.TC_BienLaiThuTienID = int.Parse(grvSinhVien.GetDataRow(grvSinhVien.FocusedRowHandle)["TC_BienLaiThuTienID"].ToString());
                            oBTC_BienLaiThuTien.Delete(pTC_BienLaiThuTienInfo);
                            drSinhVien["DaThuTien"] = false;
                            drSinhVien["SoTien"] =0;
                        }
                        catch { XoaThatBai(); }
                    }
                }
                else
                    ThongBao("Sinh viên chưa nộp tiền!");
            }
            else
                ThongBao("Chưa chọn sinh viên!");
        }

         private void btnXoaSinhVien_Click(object sender, EventArgs e)
        {
            if (grvSinhVien.FocusedRowHandle >= 0)
            {
                if ((bool)grvSinhVien.GetDataRow(grvSinhVien.FocusedRowHandle)["DaXetDuyet"]== false)
                {
                    if (ThongBaoChon("Xóa sinh viên, biên lai thu tiền cũng bị xóa! Bạn có chắc chắn muốn xóa?") == DialogResult.Yes)
                    {
                        try
                        {

                            pSV_SinhVienNhapTruongInfo.SV_SinhVienNhapTruongID = int.Parse(grvSinhVien.GetDataRow(grvSinhVien.FocusedRowHandle)["SV_SinhVienNhapTruongID"].ToString());
                            oBSV_SinhVienNhapTruong.Delete(pSV_SinhVienNhapTruongInfo);
                            frmThuTienNhapHoc_Load(null, null);
                            XoaThanhCong();
                        }
                        catch { ThongBao("Sinh viên đã có biên lai thu tiền không thể xóa!"); }
                    }
                }
                 else
                    ThongBao("Sinh viên đã được xét duyệt không thể xóa!");
            }
            else
                ThongBao("Chưa chọn sinh viên!");
        }
        private void btnXuatRaExcel_Click(object sender, EventArgs e)
        {

            XuatTheoTemplate();
        }
        private void XuatTheoTemplate()
        {
            if ( grvSinhVien.DataRowCount == 0)
            {
                ThongBao("Không có dữ liệu để xuất ra excel.");
                return;
            }
            string DuongDan = Application.StartupPath;
            string strFileExcel = DuongDan + "\\Template\\DanhSachThuTienNhapHoc.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + ". Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                return;
            }
            SaveFileDialog sv = new SaveFileDialog();
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
                XuatDuLieuRaExcel(strTenFileExcelMoi);
                ThongBao("Xuất dữ liệu thành công!");
            }

        }

        private void XuatDuLieuRaExcel(string FileExcel)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int i = 0;
            int DongBatDau = 8;
            Excel.Range cel;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);
                // Phần này là thêm Header.

                excel.Cells[5, 6] = Program.NamHoc;
                cel = (Excel.Range)excel.Cells[5, 6];

                // Phần này là thêm Detail.
                double SumTongThu = 0;

                for (i = 0; i < grvSinhVien.DataRowCount; i++)
                {
                   excel.Cells[i + DongBatDau, 1] = i + 1;
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 1]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau, 2] = grvSinhVien.GetDataRow(i)["SoBaoDanhTS"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 2]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau, 3] = grvSinhVien.GetDataRow(i)["HoVaTenTS"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 3]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau, 4] = grvSinhVien.GetDataRow(i)["NgaySinh"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 4]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau, 5] = grvSinhVien.GetDataRow(i)["KhoiThi"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 5]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau, 6] = grvSinhVien.GetDataRow(i)["NganhThi"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 6]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau, 7] = grvSinhVien.GetDataRow(i)["NoiSinhTS"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 7]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau, 8] = grvSinhVien.GetDataRow(i)["ThuongTruTS"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 8]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau, 9] = grvSinhVien.GetDataRow(i)["SoTien"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 9]);
                    cel.Borders.Value = 1;
                    SumTongThu += double.Parse("0" + grvSinhVien.GetDataRow(i)["SoTien"] + "");

                }
                for (int j = 0; j < 9; j++)
                {
                    cel = (Excel.Range)(excel.Cells[grvSinhVien.DataRowCount + DongBatDau, j + 1]);
                    cel.Font.Bold = true;
                    cel.Borders.Value = 1;
                }
                excel.Cells[grvSinhVien.DataRowCount + DongBatDau, 2] = "Tổng cộng:";
                excel.Cells[grvSinhVien.DataRowCount + DongBatDau, 9] = SumTongThu;
                
            }

            catch (Exception e)
            {
                CloseWaitDialog();
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ThongBaoLoi("Xuất dữ liệu không thành công! Hãy đóng file Excel Danh sách thu tiền nhập học trước khi xuất dữ liệu. Thông báo lỗi: " + e.Message);
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

       
    }
}