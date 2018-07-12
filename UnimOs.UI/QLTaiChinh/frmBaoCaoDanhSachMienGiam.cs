using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;

namespace UnimOs.UI
{
    public partial class frmBaoCaoDanhSachMienGiam : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private cBSV_SinhVien oBSV_SinhVien;
        private DataTable dtSinhVien, dtKhoaHoc;
        private cBTC_DinhMucThuSinhVien oBTC_DinhMucThuSinhVien;
        private int IDTC_LoaiThuChi = 0;

        public frmBaoCaoDanhSachMienGiam()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            oBSV_SinhVien = new cBSV_SinhVien();
            pDM_LopInfo = new DM_LopInfo();
            oBTC_DinhMucThuSinhVien = new cBTC_DinhMucThuSinhVien();
        }

        private void frmBaoCaoDanhSachMienGiam_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }
        private void LoadCombo()
        {
            cmbHe.Properties.DataSource = LoadHe();
            cmbTrinhDo.Properties.DataSource = LoadTrinhDo();
            cmbKhoa.Properties.DataSource = LoadKhoa();
            dtKhoaHoc = LoadKhoaHoc();
            cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;
            cmbLop.Properties.DataSource = oBDM_Lop.GetDanhSachLop(new DM_LopInfo(), Program.NamHoc);
            cmbNamHoc.Properties.DataSource = LoadNamHoc();
            cmbNamHoc.EditValue = Program.IDNamHoc;
            DataTable dt = new DataTable();
            dt.Columns.Add("HocKy");
            DataRow dr = dt.NewRow();
            dr["HocKy"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["HocKy"] = 2;
            dt.Rows.Add(dr);
            cmbHocKy.Properties.DataSource = dt;
            cmbHocKy.EditValue = Program.HocKy.ToString();
            LoadComboLoaiThuChi();
        }

        private void LoadComboLoaiThuChi()
        {
            DataTable dtTemp = LoadLoaiThuChi(int.Parse("0" + cmbNamHoc.EditValue), int.Parse("0" + cmbHocKy.EditValue));
            dtTemp.DefaultView.RowFilter = "KhoanThu=1";
            cmbLoaiThuChi.Properties.DataSource = dtTemp.DefaultView;
            if (dtTemp.DefaultView.Count > 0)
                cmbLoaiThuChi.EditValue = dtTemp.DefaultView[0]["TC_LoaiThuChiID"];

        }

        private void LoadDanhSachLop()
        {
            pDM_LopInfo.IDDM_Khoa = cmbKhoa.EditValue == null ? 0 : int.Parse(cmbKhoa.EditValue.ToString());
            pDM_LopInfo.IDDM_He = cmbHe.EditValue == null ? 0 : int.Parse(cmbHe.EditValue.ToString());
            pDM_LopInfo.IDDM_TrinhDo = cmbTrinhDo.EditValue == null ? 0 : int.Parse(cmbTrinhDo.EditValue.ToString());
            pDM_LopInfo.IDDM_Nganh = cmbNganh.EditValue == null ? 0 : int.Parse(cmbNganh.EditValue.ToString());
            pDM_LopInfo.IDDM_KhoaHoc = cmbKhoaHoc.EditValue == null ? 0 : int.Parse(cmbKhoaHoc.EditValue.ToString());
            cmbLop.Properties.DataSource = oBDM_Lop.GetDanhSachLop(pDM_LopInfo, Program.NamHoc);
        }

        private void cmbHe_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbHe.EditValue != null)
            {
                DataTable dtTrinhDo = LoadTrinhDoByIDHe(int.Parse(cmbHe.EditValue.ToString()));
                cmbTrinhDo.Properties.DataSource = dtTrinhDo;
                if (dtTrinhDo.Rows.Count > 0)
                    cmbTrinhDo.ItemIndex = 0;
            }
            LoadDanhSachLop();
        }

        private void cmbTrinhDo_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbTrinhDo.EditValue != null)
            {
                string strFilter = "";
                if (cmbTrinhDo.EditValue != null)
                    strFilter = "IDDM_TrinhDo = " + cmbTrinhDo.EditValue.ToString();
                if (cmbNganh.EditValue != null)
                    strFilter += strFilter == "" ? "IDDM_Nganh = " + cmbNganh.EditValue.ToString() : " And IDDM_Nganh = " + cmbNganh.EditValue.ToString();

                if (strFilter != "")
                {
                    DataView dv = new DataView(dtKhoaHoc);
                    dv.RowFilter = strFilter;
                    cmbKhoaHoc.Properties.DataSource = dv;
                }
                else
                    cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;
            }
            LoadDanhSachLop();
        }

        private void cmbKhoa_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.EditValue != null)
            {
                cmbNganh.Properties.DataSource = LoadNganhByIDKhoa(int.Parse(cmbKhoa.EditValue.ToString()));
            }
            LoadDanhSachLop();
        }

        private void cmbNganh_EditValueChanged(object sender, EventArgs e)
        {
            LoadDanhSachLop();
        }

        private void cmbKhoaHoc_EditValueChanged(object sender, EventArgs e)
        {
            LoadDanhSachLop();
        }

        private void cmbLoaiThuChi_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbLoaiThuChi.EditValue != null)
            {
                IDTC_LoaiThuChi = int.Parse(cmbLoaiThuChi.EditValue.ToString());
            }
        }
        private void cmbHe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbHe.EditValue = null;
        }

        private void cmbTrinhDo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbTrinhDo.EditValue = null;
        }

        private void cmbKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbKhoa.EditValue = null;
        }

        private void cmbNganh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbNganh.EditValue = null;
        }

        private void cmbKhoaHoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbKhoaHoc.EditValue = null;
        }

        private void cmbLop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbLop.EditValue = null;
        }
        private void btnTongHop_Click(object sender, EventArgs e)
        {
            if (IDTC_LoaiThuChi > 0)
            {
                dtSinhVien = oBTC_DinhMucThuSinhVien.GetInSinhVien(pDM_LopInfo, int.Parse(cmbNamHoc.EditValue.ToString()), int.Parse(cmbHocKy.EditValue.ToString()), IDTC_LoaiThuChi);
                dtSinhVien.DefaultView.RowFilter = "isnull(SoTienMienGiam,0)>0";
                grdMienGiam.DataSource = dtSinhVien.DefaultView;
            }
            
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            btnTongHop_Click(null, null);
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Excel file (*.xls)|*.xls";
            sv.Title = "Xuất dữ liệu";
            if (sv.ShowDialog() == DialogResult.OK)
            {
                CreateWaitDialog("Đang xuất dữ liệu ra Excel", "Xin vui lòng chờ.");
                Application.DoEvents();
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                ExportTo(new DevExpress.XtraExport.ExportXlsProvider(sv.FileName), grvMienGiam);
                CloseWaitDialog();
                if (XtraMessageBox.Show("Xuất dữ liệu thành công!\n Bạn có muốn mở file này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo.FileName = sv.FileName;
                        process.StartInfo.Verb = "Open";
                        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                        process.Start();
                    }
                    catch
                    {
                        XtraMessageBox.Show(this, "Bạn chưa cài đặt ứng dụng Office để chạy file excel", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            //if (dtSinhVien != null && dtSinhVien.Rows.Count == 0)
            //{
            //    ThongBao("Không có dữ liệu để xuất ra excel!");
            //    return;
            //}
            //string DuongDan = Application.ExecutablePath;
            //DuongDan = DuongDan.Substring(0, DuongDan.LastIndexOf("\\"));
            //string strFileExcel = DuongDan + "\\Template\\BaoCaoDanhSachMienGiam.xls";
            //if (!File.Exists(strFileExcel))
            //{
            //    ThongBao("Không tìm thấy file " + strFileExcel + "! Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
            //    return;
            //}
            ////string strTenFileExcelMoi = DuongDan + "\\Template\\BangKeChungTuThang" + Thang.ToString() + "Nam" + Nam.ToString() + ".xls";
            ////string strTenFileExcelMoi = "";
            ////try
            ////{
            ////    if (!Directory.Exists("D:\\BaoCao"))
            ////        Directory.CreateDirectory("D:\\BaoCao");
            ////    strTenFileExcelMoi = "D:\\BaoCao\\BangKeChungTuThang" + Thang.ToString() + "Nam" + Nam.ToString() + ".xls";
            ////}
            ////catch
            ////{
            ////    strTenFileExcelMoi = DuongDan + "\\Template\\BangKeChungTuThang" + Thang.ToString() + "Nam" + Nam.ToString() + ".xls";
            ////}
            ////finally { }
            // SaveFileDialog sv = new SaveFileDialog();
            //sv.Filter = "Excel file (*.xls)|*.xls";
            //sv.Title = "Xuất dữ liệu";
            //if (sv.ShowDialog() == DialogResult.OK)
            //{
            //    CreateWaitDialog("Đang xuất dữ liệu ra Excel", "Xin vui lòng chờ.");
            //    Application.DoEvents();
            //    System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            //}
            //try
            //{
            //    File.Copy(strFileExcel, sv.FileName, true);
            //}
            //catch (Exception ex)
            //{
            //    ThongBaoLoi("File excel đang được mở. Đề nghị đóng file này trước khi xuất dữ liệu! Thông báo lỗi: " + ex.Message);
            //    return;
            //}
            //finally { }
            //XuatDuLieuRaExcel(dtSinhVien, sv.FileName);
            //ThongBao("Xuất dữ liệu thành công!");
        }

        private void grvMienGiam_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void cmbNamHoc_EditValueChanged(object sender, EventArgs e)
        {
            LoadComboLoaiThuChi();
        }

        private void cmbHocKy_EditValueChanged(object sender, EventArgs e)
        {
            LoadComboLoaiThuChi();
        }
        //private void XuatDuLieuRaExcel(DataTable dtSinhVien, string FileExcel)
        //{
        //    CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
        //    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
        //    int i = 0;
        //    int DongBatDau = 8;

        //    Excel.Range cel;

        //    Excel.ApplicationClass excel = new Excel.ApplicationClass();
        //    try
        //    {
        //        excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);
        //        //excel.Cells[5, 1] = "Tháng " + Thang.ToString() + " năm " + Nam.ToString();
        //        //cel = (Excel.Range)excel.Cells[5, 1];
        //        //cel.Font.Bold = true;

        //        cel = (Excel.Range)(excel.Cells[i + DongBatDau - 1, 1]);
        //        cel.Borders.Value = 1;
        //        cel = (Excel.Range)(excel.Cells[i + DongBatDau - 1, 2]);
        //        cel.Borders.Value = 1;
        //        // Them các tiêu đề cột phía sau
        //        for (int j = 1; j < dtSinhVien.Columns.Count; j++)
        //        {
        //            excel.Cells[i + DongBatDau - 1, j + 2] = dtSinhVien.Columns[j].ColumnName;
        //            cel = (Excel.Range)(excel.Cells[i + DongBatDau - 1, j + 2]);
        //            cel.Font.Bold = true;
        //            cel.Borders.Value = 1;
        //        }
        //        for (i = 0; i < dtSinhVien.Rows.Count; i++)
        //        {
        //            //excel.Cells[i + DongBatDau, 1] = (i + 1).ToString(); // Số chứng từ
        //            cel = (Excel.Range)excel.Cells[i + DongBatDau, 1];
        //            cel.Borders.Value = 1;

        //            //  excel.Cells[i + DongBatDau, 2] = dtbBangKeChungTu.Rows[i][""].ToString();
        //            cel = (Excel.Range)excel.Cells[i + DongBatDau, 2];
        //            cel.Borders.Value = 1;
        //            if (i == dtSinhVien.Rows.Count - 1)
        //                cel.Font.Bold = true;
        //            for (int j = 1; j < dtSinhVien.Columns.Count; j++)
        //            {
        //                excel.Cells[i + DongBatDau, j + 2] = (dtSinhVien.Rows[i][j] + "").ToString();
        //                cel = (Excel.Range)excel.Cells[i + DongBatDau, j + 2];
        //                cel.Borders.Value = 1;
        //                if (i == dtSinhVien.Rows.Count - 1)
        //                    cel.Font.Bold = true;
        //            }
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        CloseWaitDialog();
        //        this.Cursor = System.Windows.Forms.Cursors.Default;
        //        ThongBaoLoi("Xuất dữ liệu không thành công! Hãy đóng file Excel Bảng kê chứng từ trước khi xuất dữ liệu. Thông báo lỗi: " + e.Message);
        //        return;
        //    }
        //    finally
        //    {
        //        excel.Application.Workbooks[1].Save();
        //        excel.Application.Workbooks.Close();
        //        excel.Application.Quit();
        //        excel.Quit();
        //        Process.Start(FileExcel);
        //        CloseWaitDialog();
        //        this.Cursor = System.Windows.Forms.Cursors.Default;
        //    }
        //}
    }
}