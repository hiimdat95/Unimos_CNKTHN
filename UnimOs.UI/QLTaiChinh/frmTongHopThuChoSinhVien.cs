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
    public partial class frmTongHopThuChoSinhVien : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private cBTC_QuyenHoaDon oBTC_QuyenHoaDon;
        private TC_QuyenHoaDonInfo pTC_QuyenHoaDonInfo;
        private cBSV_SinhVien oBSV_SinhVien;
        private DataTable dtSinhVien, dtKhoaHoc;
        private cBTC_BienLaiThuTien oBTC_BienLaiThuTien;
        private int IDTC_LoaiThuChi, intHocKy, IDDM_NamHoc, IDTC_QuyenHoaDon;
        private DataRow drTongHop;

        public frmTongHopThuChoSinhVien()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            oBSV_SinhVien = new cBSV_SinhVien();
            pDM_LopInfo = new DM_LopInfo();
            oBTC_BienLaiThuTien = new cBTC_BienLaiThuTien();
            oBTC_QuyenHoaDon = new cBTC_QuyenHoaDon();
            pTC_QuyenHoaDonInfo = new TC_QuyenHoaDonInfo();
        }

        private void frmTongHopThuChoSinhVien_Load(object sender, EventArgs e)
        {
            grvTongHop.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[]{
                new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoTienMienGiam", grcMienGiam, "{0:#,###}"),
                new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoTienPhaiNop", grcPhaiNop, "{0:#,###}"),
                new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoTienDaNop", grcDaNop, "{0:#,###}")
            });
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
            DataTable dtTemp = oBTC_QuyenHoaDon.Get(pTC_QuyenHoaDonInfo);
            cmbQuyenHoaDon.Properties.DataSource = dtTemp;
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

        private void LoadComboLoaiThuChi()
        {
            DataTable dtTemp = LoadLoaiThuChiTongHop();
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
            //if (cmbTrinhDo.EditValue != null)
            //{
            //    string strFilter = "";
            //    if (cmbTrinhDo.EditValue != null)
            //        strFilter = "IDDM_TrinhDo = " + cmbTrinhDo.EditValue.ToString();
            //    if (cmbNganh.EditValue != null)
            //        strFilter += strFilter == "" ? "IDDM_Nganh = " + cmbNganh.EditValue.ToString() : " And IDDM_Nganh = " + cmbNganh.EditValue.ToString();

            //    if (strFilter != "")
            //    {
            //        DataView dv = new DataView(dtKhoaHoc);
            //        dv.RowFilter = strFilter;
            //        cmbKhoaHoc.Properties.DataSource = dv;
            //    }
            //    else
            //        cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;
            //}
            LoadDanhSachLop();
        }
        private void cmbQuyenHoaDon_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbQuyenHoaDon.EditValue != null)
            {
                IDTC_QuyenHoaDon = int.Parse(cmbQuyenHoaDon.EditValue.ToString());
            }
            else
                IDTC_QuyenHoaDon = 0;
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
            else
                IDTC_LoaiThuChi = 0;
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

        private void cmbNamHoc_EditValueChanged(object sender, EventArgs e)
        {
            LoadComboLoaiThuChi();
            if (cmbNamHoc.EditValue != null)
            {
                IDDM_NamHoc = int.Parse(cmbNamHoc.EditValue.ToString());
            }
            else
                IDDM_NamHoc = 0;
        }

        private void cmbHocKy_EditValueChanged(object sender, EventArgs e)
        {
            LoadComboLoaiThuChi();
            if (cmbHocKy.EditValue != null)
            {
                intHocKy = int.Parse(cmbHocKy.EditValue.ToString());
            }
            else
                intHocKy = 0;
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
        private void cmbQuyenHoaDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbQuyenHoaDon.EditValue = null;
        }
        private void cmbLoaiThuChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbLoaiThuChi.EditValue = null;
        }

        private void cmbNamHoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbNamHoc.EditValue = null;
        }

        private void cmbHocKy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbHocKy.EditValue = null;
        }

        private void grvTongHop_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvTongHop_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvTongHop.FocusedRowHandle >= 0)
                drTongHop = grvTongHop.GetDataRow(grvTongHop.FocusedRowHandle);
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            try
            {
                CreateWaitDialog();
                dtSinhVien = oBTC_BienLaiThuTien.GetTongHop(pDM_LopInfo, IDDM_NamHoc, IDTC_LoaiThuChi, intHocKy, IDTC_QuyenHoaDon, chkTuDau.Checked);
                rdDanhSach.EditValue = "0";
                dtSinhVien.DefaultView.RowFilter = " NoKyTruoc>0 or SoTienPhaiNop>0 or SoTienDaNop >0 or SoTienMienGiam >0";
                grdTongHop.DataSource = dtSinhVien.DefaultView;
                if (dtSinhVien != null && dtSinhVien.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSinhVien.Rows)
                    {
                        try
                        {
                            if (float.Parse("0" + dr["SoTienConLai"]) > 0)
                                dr["SoTienThieu"] = dr["SoTienConLai"];
                        }
                        catch
                        {
                            dr["SoTienThua"] = dr["SoTienConLai"].ToString().Replace("-", "");
                        }
                    }
                }
                CloseWaitDialog();
            }
            catch
            {
                CloseWaitDialog();
            }
        }

        private void rdDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtSinhVien != null && dtSinhVien.Rows.Count > 0)
            {
                if (rdDanhSach.SelectedIndex == 0)
                    dtSinhVien.DefaultView.RowFilter = " NoKyTruoc>0 or SoTienPhaiNop>0 or SoTienDaNop >0 or SoTienMienGiam >0 ";
                else if (rdDanhSach.SelectedIndex == 1)
                    dtSinhVien.DefaultView.RowFilter = "( NoKyTruoc>0 or SoTienPhaiNop>0 or SoTienDaNop >0 or SoTienMienGiam >0 ) and SoTienConLai<=0";
                else if (rdDanhSach.SelectedIndex == 2)
                    dtSinhVien.DefaultView.RowFilter = "( NoKyTruoc>0 or SoTienPhaiNop>0 or SoTienDaNop >0 or SoTienMienGiam >0 ) and SoTienConLai>0";
                else if (rdDanhSach.SelectedIndex == 3)
                    dtSinhVien.DefaultView.RowFilter = "( NoKyTruoc>0 or SoTienPhaiNop>0 or SoTienDaNop >0 or SoTienMienGiam >0 ) and SoTienThua>0";
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (drTongHop != null)
            {
                dlgSinhVien_ChiTietThu dlg = new dlgSinhVien_ChiTietThu(drTongHop, IDTC_LoaiThuChi,intHocKy, IDDM_NamHoc);
                dlg.ShowDialog();
               
            }
            else
                ThongBao("Bạn chưa chọn sinh viên!");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            XuatTheoTemplate();
        }
        private void XuatTheoTemplate()
        {
            if (grvTongHop.DataRowCount==0)
            {
                ThongBao("Không có dữ liệu để xuất ra excel.");
                return;
            }
            string DuongDan = Application.StartupPath;
            string strFileExcel = DuongDan + "\\Template\\BaoCaoTongThuSinhVien.xls";
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
            int DongBatDau =10;
            Excel.Range cel;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);
                // Phần này là thêm Header.
                excel.Cells[3, 2] = cmbHe.Text;
                cel = (Excel.Range)excel.Cells[3,2];

                excel.Cells[3, 4 ]= cmbTrinhDo.Text;
                cel = (Excel.Range)excel.Cells[3, 4];

                excel.Cells[3, 6] = cmbKhoaHoc.Text;
                cel = (Excel.Range)excel.Cells[3, 6];

                excel.Cells[3, 8] = cmbKhoa.Text;
                cel = (Excel.Range)excel.Cells[3, 8];

                excel.Cells[7, 5] = cmbHocKy.Text;
                cel = (Excel.Range)excel.Cells[7, 5];

                excel.Cells[7, 7] = cmbNamHoc.Text;
                cel = (Excel.Range)excel.Cells[7, 7];

                // Phần này là thêm Detail.
                string TenLop = grvTongHop.GetDataRow(0)["TenLop"].ToString();
                double SumTongThu = 0, SumMienGiam = 0, SumPhaiNop = 0, SumDaNop = 0, SumSoTienThua = 0, SumSoTienThieu = 0, SumNoKyTruoc=0;
               
                for (i = 0; i < grvTongHop.DataRowCount; i++)
                {
                    if (TenLop != grvTongHop.GetDataRow(i)["TenLop"].ToString() || i == 0)
                    {
                        
                        excel.Cells[i + DongBatDau, 2] = grvTongHop.GetDataRow(i)["TenLop"].ToString();
                        cel = (Excel.Range)(excel.Cells[i + DongBatDau, 2]);
                        cel.Font.Bold = true;
                        cel.Borders.Value = 1;
                        DongBatDau += 1;
                    }
                    excel.Cells[i + DongBatDau, 1] = i+ 1;
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 1]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau, 2] = grvTongHop.GetDataRow(i)["MaSinhVien"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 2]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau, 3] = grvTongHop.GetDataRow(i)["HoVaTen"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 3]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau,4] = grvTongHop.GetDataRow(i)["NgaySinh"] + "";
                     cel = (Excel.Range)(excel.Cells[i + DongBatDau, 4]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau, 5] = grvTongHop.GetDataRow(i)["NoKyTruoc"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 5]);
                    cel.Borders.Value = 1;
                    SumNoKyTruoc += double.Parse("0" + grvTongHop.GetDataRow(i)["NoKyTruoc"] + "");

                    excel.Cells[i + DongBatDau, 6] = grvTongHop.GetDataRow(i)["TongThu"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 6]);
                    cel.Borders.Value = 1;
                    SumTongThu += double.Parse("0" + grvTongHop.GetDataRow(i)["TongThu"] + "");

                    excel.Cells[i + DongBatDau, 7] = grvTongHop.GetDataRow(i)["SoTienMienGiam"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau,7]);
                    cel.Borders.Value = 1;
                    SumMienGiam += double.Parse("0" + grvTongHop.GetDataRow(i)["SoTienMienGiam"] + "");

                    excel.Cells[i + DongBatDau, 8] = grvTongHop.GetDataRow(i)["SoTienPhaiNop"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 8]);
                    cel.Borders.Value = 1;
                    SumPhaiNop += double.Parse("0" + grvTongHop.GetDataRow(i)["SoTienPhaiNop"] + "");

                    excel.Cells[i + DongBatDau, 9] = grvTongHop.GetDataRow(i)["SoTienDaNop"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 9]);
                    cel.Borders.Value = 1;
                    SumDaNop += double.Parse("0" + grvTongHop.GetDataRow(i)["SoTienDaNop"] + "");

                    excel.Cells[i + DongBatDau, 10] = grvTongHop.GetDataRow(i)["SoTienThieu"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 10]);
                    cel.Borders.Value = 1;
                    SumSoTienThieu += double.Parse("0" + grvTongHop.GetDataRow(i)["SoTienThieu"] + "");

                    excel.Cells[i + DongBatDau, 11] = grvTongHop.GetDataRow(i)["SoTienThua"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau, 11]);
                    cel.Borders.Value = 1;
                    SumSoTienThua += double.Parse("0" + grvTongHop.GetDataRow(i)["SoTienThua"] + "");

                    TenLop = grvTongHop.GetDataRow(i)["TenLop"].ToString();
                }
                for (int j = 0; j < 11; j++)
                {
                    cel = (Excel.Range)(excel.Cells[grvTongHop.DataRowCount + DongBatDau, j+1]);
                    cel.Font.Bold = true;
                    cel.Borders.Value = 1;
                }
                excel.Cells[grvTongHop.DataRowCount + DongBatDau, 2] ="Tổng cộng:";
                excel.Cells[grvTongHop.DataRowCount + DongBatDau, 5] = SumNoKyTruoc;
                excel.Cells[grvTongHop.DataRowCount + DongBatDau, 6] = SumTongThu;
                excel.Cells[grvTongHop.DataRowCount + DongBatDau, 7] = SumMienGiam;
                excel.Cells[grvTongHop.DataRowCount + DongBatDau, 8] = SumPhaiNop;
                excel.Cells[grvTongHop.DataRowCount + DongBatDau, 9] = SumDaNop;
                excel.Cells[grvTongHop.DataRowCount + DongBatDau, 10] = SumSoTienThieu;
                excel.Cells[grvTongHop.DataRowCount + DongBatDau, 11] =SumSoTienThua;
            }

            catch (Exception e)
            {
                CloseWaitDialog();
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ThongBaoLoi("Xuất dữ liệu không thành công! Hãy đóng file Excel Tổng hợp thu tiền cho sinh viên trước khi xuất dữ liệu. Thông báo lỗi: " + e.Message);
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

        private void chkTuDau_CheckedChanged(object sender, EventArgs e)
        {
            grcNoKyTruoc.Visible = chkTuDau.Checked;
        }
    }
}