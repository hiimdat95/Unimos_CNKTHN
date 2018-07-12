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
    public partial class frmTongHopChiHocBong : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private cBSV_SinhVien oBSV_SinhVien;
        private cBTC_DanhSachHocBong oBTC_DanhSachHocBong;
        private DataTable dtKhoaHoc, dtTongHop;

        public frmTongHopChiHocBong()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            oBSV_SinhVien = new cBSV_SinhVien();
            pDM_LopInfo = new DM_LopInfo();
            oBTC_DanhSachHocBong = new cBTC_DanhSachHocBong();
        }

        private void frmTongHopChiHocBong_Load(object sender, EventArgs e)
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

        private void cmbLop_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbLop.EditValue != null)
            {
                pDM_LopInfo.DM_LopID = int.Parse(cmbLop.EditValue.ToString());
            }
            else
                pDM_LopInfo.DM_LopID = 0;
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

        private void cmbThang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbThang.EditValue = null;
        }

        private void bgvTongHop_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            if (pDM_LopInfo.DM_LopID > 0)
            {
                colNgaySinh.Visible = true;
                colTenSinhVien.Visible = true;
                colTenLop.Visible = false;
                dtTongHop = oBTC_DanhSachHocBong.GetDanhSachSinhVien(pDM_LopInfo.DM_LopID, Program.IDNamHoc, Program.HocKy, (cmbThang.EditValue == null ? 0 : int.Parse("0" + cmbThang.EditValue.ToString())));
                grdTongHop.DataSource = dtTongHop;
            }
            else
            {
                colNgaySinh.Visible = false;
                colTenSinhVien.Visible = false;
                colTenLop.Visible = true;
                dtTongHop = oBTC_DanhSachHocBong.GetDanhSachLop(pDM_LopInfo, Program.IDNamHoc, Program.HocKy, (cmbThang.EditValue == null ? 0 : int.Parse("0" + cmbThang.EditValue.ToString())), Program.NamHoc);
                grdTongHop.DataSource = dtTongHop;
                if (dtTongHop != null && dtTongHop.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtTongHop.Rows)
                    {
                        dr["TongCong"] = double.Parse("0" + dr["HBHT"].ToString()) + double.Parse("0" + dr["HBTC"].ToString());
                        dr["ConLinh"] = double.Parse("0" + dr["TongCong"].ToString()) - double.Parse("0" + dr["SoTienBiTru"].ToString());
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bgvTongHop_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name=="colSoTienBiTru")
                if (e.Value.ToString() != "")
                {
                    DataRow dr = bgvTongHop.GetDataRow(e.RowHandle);
                    dr["ConLinh"] = double.Parse("0" + dr["TongCong"].ToString()) - double.Parse("0" + e.Value.ToString());
                }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (bgvTongHop.DataRowCount > 0)
            {
                XuatTheoTemplate();
            }
        }
        private void XuatTheoTemplate()
        {
            if (dtTongHop == null && dtTongHop.Rows.Count == 0)
            {
                ThongBao("Không có dữ liệu để xuất ra excel!");
                return;
            }
            string DuongDan = Application.StartupPath;
            string strFileExcel ="";
             if (colTenLop.Visible== true)
                 strFileExcel = DuongDan + "\\Template\\BangKeChiHocBong.xls";
            else
                 strFileExcel = DuongDan + "\\Template\\BangKeChiHocBong_SV.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + "! Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
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
                if (colTenLop.Visible == true)
                    XuatDuLieuRaExcel_Lop(dtTongHop, strTenFileExcelMoi);
                else
                    XuatDuLieuRaExcel_SV(dtTongHop, strTenFileExcelMoi);
                ThongBao("Xuất dữ liệu thành công!");
            }

        }

        private void XuatDuLieuRaExcel_SV(DataTable dtChiTiet, string FileExcel)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int i = 0;
            int DongBatDau = 6;
            Excel.Range cel;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);
                excel.Cells[1, 1] = Program.TenTruong.ToUpper();
                cel = (Excel.Range)excel.Cells[1, 1];
                cel.Font.Bold = true;

                excel.Cells[3, 1] = cmbNamHoc.Text.ToString();
                cel = (Excel.Range)excel.Cells[3, 1];

                excel.Cells[3, 2] = cmbHocKy.Text;
                cel = (Excel.Range)excel.Cells[3, 2];

                excel.Cells[3, 3] = cmbThang.Text;
                cel = (Excel.Range)excel.Cells[3, 3];


                for (int k = 0; k < dtChiTiet.Rows.Count + 1; k++)
                {
                    for (int l = 1; l < 12; l++)
                    {
                        cel = (Excel.Range)(excel.Cells[DongBatDau + k, l]);
                        cel.Borders.Value = 1;
                    }
                }

                for (i = 0; i < dtChiTiet.Rows.Count; i++)
                {
                 //   double DiemTB = 0;
                    //int HeSo = 0;
                    excel.Cells[i + DongBatDau + 1, 1] = i + 1;
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 1]);

                    excel.Cells[i + DongBatDau + 1, 2] = dtChiTiet.Rows[i]["MaSinhVien"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 2]);

                    excel.Cells[i + DongBatDau + 1, 3] = dtChiTiet.Rows[i]["HoVaTen"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 3]);

                    excel.Cells[i + DongBatDau + 1, 4] = dtChiTiet.Rows[i]["NgaySinh"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 4]);

                    //for (int j = 6; j < dtSinhVien.Columns.Count - 2; j++)
                    //{
                    //    //if (dtChiTiet.Rows[i][j] + "" != "")
                    //    //{
                    //    //    HeSo += 2;
                    //    //    DiemTB += 2 * (float)dtChiTiet.Rows[i][j];
                    //    //}
                    //    excel.Cells[i + DongBatDau + 1, j - 1] = dtChiTiet.Rows[i][j] + "";
                    //    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, j - 1]);
                    //}

                    //excel.Cells[i + DongBatDau + 1, 11] = DiemTB / HeSo;
                    //cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 11]);

                    excel.Cells[i + DongBatDau + 1, 5] = dtChiTiet.Rows[i]["HBHT"]+ "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 5]);

                    excel.Cells[i + DongBatDau + 1, 6] = dtChiTiet.Rows[i]["HBTC"] ;
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 6]);
                    excel.Cells[i + DongBatDau + 1, 7] = dtChiTiet.Rows[i]["TongCong"];
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 7]);
                    excel.Cells[i + DongBatDau + 1, 8] = dtChiTiet.Rows[i]["SoNgay"];
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 8]);
                    excel.Cells[i + DongBatDau + 1, 9] = dtChiTiet.Rows[i]["SoTienBiTru"] ;
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 9]);
                    excel.Cells[i + DongBatDau + 1, 10] = dtChiTiet.Rows[i]["ConLinh"] ;
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 10]);
                    excel.Cells[i + DongBatDau + 1, 11] = dtChiTiet.Rows[i]["GhiChu"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 11]);
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
        private void XuatDuLieuRaExcel_Lop(DataTable dtChiTiet, string FileExcel)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int i = 0;
            int DongBatDau = 6;
            Excel.Range cel;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);
                excel.Cells[1, 1] = Program.TenTruong.ToUpper();
                //cel = (Excel.Range)excel.Cells[1, 1];
                //cel.Font.Bold = true;

                //excel.Cells[3, 1] = cmbNamHoc.Text.ToString();
                //cel = (Excel.Range)excel.Cells[3, 1];

                //excel.Cells[3, 2] = cmbHocKy.Text;
                //cel = (Excel.Range)excel.Cells[3, 2];

                //excel.Cells[3, 3] = cmbThang.Text;
                //cel = (Excel.Range)excel.Cells[3, 3];


                for (int k = 0; k < dtChiTiet.Rows.Count + 1; k++)
                {
                    for (int l = 1; l < 10; l++)
                    {
                        cel = (Excel.Range)(excel.Cells[DongBatDau + k, l]);
                        cel.Borders.Value = 1;
                    }
                }

                for (i = 0; i < dtChiTiet.Rows.Count; i++)
                {
                    //   double DiemTB = 0;
                    //int HeSo = 0;
                    excel.Cells[i + DongBatDau + 1, 1] = i + 1;
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 1]);

                    excel.Cells[i + DongBatDau + 1, 2] = dtChiTiet.Rows[i]["TenLop"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 2]);

                    excel.Cells[i + DongBatDau + 1, 3] = dtChiTiet.Rows[i]["HBHT"] ;
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 3]);

                    excel.Cells[i + DongBatDau + 1, 4] = dtChiTiet.Rows[i]["HBTC"] ;
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 4]);

                    excel.Cells[i + DongBatDau + 1, 5] = dtChiTiet.Rows[i]["TongCong"];
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 5]);

                    excel.Cells[i + DongBatDau + 1, 6] = dtChiTiet.Rows[i]["SoNgay"];
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 6]);

                    excel.Cells[i + DongBatDau + 1, 7] = dtChiTiet.Rows[i]["SoTienBiTru"] ;
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 7]);

                    excel.Cells[i + DongBatDau + 1, 8] = dtChiTiet.Rows[i]["ConLinh"];
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 8]);

                    excel.Cells[i + DongBatDau + 1, 9] = dtChiTiet.Rows[i]["GhiChu"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 9]);
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
    }
}