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
using DevExpress.Utils;
using System.IO;
using System.Diagnostics;

namespace UnimOs.UI
{
    public partial class frmXetThiTotNghiep :frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private cBSV_SinhVien oBSV_SinhVien;
        private cBKQHT_DanhSachKhongThiTotNghiep oBKQHT_DanhSachKhongThiTotNghiep;
        private KQHT_DanhSachKhongThiTotNghiepInfo pKQHT_DanhSachKhongThiTotNghiepInfo;
        private DataTable dtKhoaHoc, dtSinhVien, dtKhongThi, dtTrinhDo;

        double PTDVHTNO = 0;

        public frmXetThiTotNghiep()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            pDM_LopInfo = new DM_LopInfo();
            oBSV_SinhVien = new cBSV_SinhVien();
            oBKQHT_DanhSachKhongThiTotNghiep = new cBKQHT_DanhSachKhongThiTotNghiep();
            pKQHT_DanhSachKhongThiTotNghiepInfo = new KQHT_DanhSachKhongThiTotNghiepInfo();
        }

        private void frmXetThiTotNghiep_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void LoadCombo()
        {
            cmbHe.Properties.DataSource = LoadHe();
            dtTrinhDo = LoadTrinhDo();
            cmbTrinhDo.Properties.DataSource = dtTrinhDo;
            cmbKhoa.Properties.DataSource = LoadKhoa();
            dtKhoaHoc = LoadKhoaHoc();
            cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;
        }

        private void GetpLopInfo()
        {
            pDM_LopInfo.IDDM_Khoa = cmbKhoa.EditValue == null ? 0 : int.Parse(cmbKhoa.EditValue.ToString());
            pDM_LopInfo.IDDM_He = cmbHe.EditValue == null ? 0 : int.Parse(cmbHe.EditValue.ToString());
            pDM_LopInfo.IDDM_TrinhDo = cmbTrinhDo.EditValue == null ? 0 : int.Parse(cmbTrinhDo.EditValue.ToString());
            pDM_LopInfo.IDDM_Nganh = cmbNganh.EditValue == null ? 0 : int.Parse(cmbNganh.EditValue.ToString());
            pDM_LopInfo.IDDM_KhoaHoc = cmbKhoaHoc.EditValue == null ? 0 : int.Parse(cmbKhoaHoc.EditValue.ToString());
        }

        private void LoadDanhSachLop()
        {
            GetpLopInfo();
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

        private void cmbKhoa_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.EditValue != null)
            {
                cmbNganh.Properties.DataSource = LoadNganhByIDKhoa(int.Parse("0" + cmbKhoa.EditValue));
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

        private void cmbKhoaHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbKhoaHoc.EditValue != null)
            {
                try
                {
                    pDM_LopInfo.IDDM_TrinhDo = int.Parse("0" + cmbKhoaHoc.GetColumnValue("IDDM_TrinhDo")); 
                    LoadDanhSachLop();
                }
                catch
                {
                    pDM_LopInfo.IDDM_TrinhDo = 0;
                    pDM_LopInfo.IDDM_KhoaHoc = 0;
                }
           }
        
            
        }

        private void cmbLop_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbLop.EditValue != null)
            {
                pDM_LopInfo.DM_LopID = int.Parse(cmbLop.EditValue.ToString());
            }
        }
        private void cmbNganh_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbNganh.EditValue != null)
            {
                pDM_LopInfo.IDDM_Nganh = int.Parse(cmbNganh.EditValue.ToString());
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

        private void grvThi_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvKhongThi_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void LoadDanhSachSinhVien()
        {
            pDM_LopInfo.DM_LopID = cmbLop.EditValue == null ? 0 : int.Parse(cmbLop.EditValue.ToString());
            dtSinhVien = oBSV_SinhVien.GetSinhVien_XetThiTotNghiep(pDM_LopInfo, Program.NamHoc, 0, PTDVHTNO);
            grdThi.DataSource = dtSinhVien;
            dtKhongThi = oBSV_SinhVien.GetTongHop_KhongThiTotNghiep(pDM_LopInfo, Program.NamHoc, 0, PTDVHTNO);
            grdKhongThi.DataSource = dtKhongThi;
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            GetpLopInfo();
            // lay tham so quy che
            DataRow[] dr = dtTrinhDo.Select("DM_TrinhDoID = " + pDM_LopInfo.IDDM_TrinhDo.ToString());
            if (dr.Length > 0)
            {
                int IDKQHT_QuyChe = int.Parse(dr[0]["IDKQHT_QuyChe"].ToString());
                cBKQHT_QuyChe oBKQHT_QuyChe = new cBKQHT_QuyChe();
                DataTable dtThamSo = oBKQHT_QuyChe.GetThamSo(IDKQHT_QuyChe);
                if (dtThamSo.Rows.Count > 0)
                {
                    DataRow[] drThamSo = dtThamSo.Select("MaThamSo='TTN_PTDVHT'");
                    if (drThamSo.Length > 0)
                    {
                        if (double.TryParse(drThamSo[0]["GiaTri"].ToString(), out PTDVHTNO) == false)
                        {
                            PTDVHTNO = double.Parse("0" + drThamSo[0]["GiaTriMacDinh"].ToString());
                        }
                    }
                }
            }
            CreateWaitDialog("Đang tải dữ liệu", "Tải dữ liệu. Xin vui lòng chờ.");
            LoadDanhSachSinhVien();
            CloseWaitDialog();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            CreateWaitDialog("Đang tải dữ liệu", "Tải dữ liệu. Xin vui lòng chờ.");
            GetpLopInfo();
            pDM_LopInfo.DM_LopID = cmbLop.EditValue == null ? 0 : int.Parse(cmbLop.EditValue.ToString());
            dtSinhVien = oBKQHT_DanhSachKhongThiTotNghiep.GetNotInSinhVien(pDM_LopInfo, Program.NamHoc, Program.IDNamHoc);
            grdThi.DataSource = dtSinhVien;
            dtKhongThi = oBKQHT_DanhSachKhongThiTotNghiep.GetInSinhVien(pDM_LopInfo, Program.NamHoc, Program.IDNamHoc);
            grdKhongThi.DataSource = dtKhongThi;
            CloseWaitDialog();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dtKhongThi != null )
            {
                if (ThongBaoChon("Bạn có chắc chắn muốn lưu dữ liệu!") == DialogResult.Yes)
                {
                    // xoa het tat ca truoc khi luu thay doi
                    try
                    {
                        oBKQHT_DanhSachKhongThiTotNghiep.DeleteAll(pDM_LopInfo, Program.NamHoc, Program.IDNamHoc);
                    }
                    catch { }
                    foreach (DataRow dr in dtKhongThi.Rows)
                    {
                        pKQHT_DanhSachKhongThiTotNghiepInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                        pKQHT_DanhSachKhongThiTotNghiepInfo.IDDM_NamHoc = Program.IDNamHoc;
                        pKQHT_DanhSachKhongThiTotNghiepInfo.LyDo = dr["LyDo"].ToString();
                        pKQHT_DanhSachKhongThiTotNghiepInfo.XetVot = false;
                        oBKQHT_DanhSachKhongThiTotNghiep.Add(pKQHT_DanhSachKhongThiTotNghiepInfo);
                    }
                    // luu cac sinh vien duoc xet vot
                    DataRow[] adr = dtSinhVien.Select("XetVot=1");
                    foreach (DataRow dr in adr)
                    {
                        pKQHT_DanhSachKhongThiTotNghiepInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                        pKQHT_DanhSachKhongThiTotNghiepInfo.IDDM_NamHoc = Program.IDNamHoc;
                        pKQHT_DanhSachKhongThiTotNghiepInfo.LyDo = dr["LyDo"].ToString();
                        pKQHT_DanhSachKhongThiTotNghiepInfo.XetVot = true;
                        oBKQHT_DanhSachKhongThiTotNghiep.Add(pKQHT_DanhSachKhongThiTotNghiepInfo);
                    }
                    ThongBao("Lưu thông tin thành công!");
                }
            }
            else
                ThongBao("Không có dữ liệu để lưu!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int Count = dtSinhVien.Rows.Count;
            DataRow[] dr = dtSinhVien.Select("Chon=1");
            if (dr.Length > 0)
            {
                dlgLyDoXetTotNghiep dlg = new dlgLyDoXetTotNghiep(ref dr,false);
                dlg.ShowDialog();
                if (dlg.Tag.ToString() == "1")
                {
                    for (int i = 0; i < Count; i++)
                    {
                        if ((bool)dtSinhVien.Rows[i]["Chon"])
                        {
                            dtSinhVien.Rows[i]["Chon"] = false;
                            dtKhongThi.ImportRow(dtSinhVien.Rows[i]);
                            dtSinhVien.Rows.Remove(dtSinhVien.Rows[i]);
                            Count = Count - 1;
                            i = i - 1;
                        }
                    }
                }
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int Count = dtKhongThi.Rows.Count;
            DataRow[] dr = dtKhongThi.Select("Chon=1");
            if (dr.Length > 0)
            {
                dlgLyDoXetTotNghiep dlg = new dlgLyDoXetTotNghiep(ref dr,true);
                dlg.ShowDialog();
                if (dlg.Tag.ToString() == "1")
                {
                    for (int i = 0; i < Count; i++)
                    {
                        if ((bool)dtKhongThi.Rows[i]["Chon"])
                        {
                            dtKhongThi.Rows[i]["Chon"] = false;
                            dtSinhVien.ImportRow(dtKhongThi.Rows[i]);
                            dtKhongThi.Rows.Remove(dtKhongThi.Rows[i]);
                            Count = Count - 1;
                            i = i - 1;
                        }
                    }
                }
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
        }

        private void btnInDsXet_Click(object sender, EventArgs e)
        {
            if (cmbKhoaHoc.EditValue != null)
            {
                CreateWaitDialog("Đang tải dữ liệu, xin vui lòng chờ!", "Xuất báo cáo");
                GetpLopInfo();
                pDM_LopInfo.DM_LopID = cmbLop.EditValue == null ? 0 : int.Parse(cmbLop.EditValue.ToString());
                DataTable dt = oBSV_SinhVien.GetDanhSachXetThiTotNghiep(pDM_LopInfo, Program.NamHoc, Program.IDNamHoc);
                if (dt.Rows.Count > 0)
                {
                    string HoVa = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        GetTen(dr["HoVaTen"].ToString(), ref HoVa);
                        dr["HoVa"] = HoVa;
                    }
                    dt.Columns.Add("TenKhoaHoc", typeof(string));
                    dt.Rows[0]["TenKhoaHoc"] = cmbKhoaHoc.Text;
                    frmReport frm = new frmReport(dt, "rDanhSachXetDieuKienDuThiTotNghiep");
                    frm.Show();
                    CloseWaitDialog();
                }
                else
                {
                    CloseWaitDialog();
                    ThongBao("Không có dữ liệu để in báo cáo.");
                }
            }
            else
                ThongBao("Bạn phải chọn khóa học.");
        }

        private void btnInDsDuDK_Click(object sender, EventArgs e)
        {
            if (cmbKhoaHoc.EditValue != null)
            {
                CreateWaitDialog("Đang tải dữ liệu, xin vui lòng chờ!", "Xuất báo cáo");
                GetpLopInfo();
                pDM_LopInfo.DM_LopID = cmbLop.EditValue == null ? 0 : int.Parse(cmbLop.EditValue.ToString());
                DataTable dt = oBSV_SinhVien.GetDanhSachDuThiTotNghiep(pDM_LopInfo, Program.NamHoc, Program.IDNamHoc);
                if (dt.Rows.Count > 0)
                {
                    string HoVa = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        GetTen(dr["HoVaTen"].ToString(), ref HoVa);
                        dr["HoVa"] = HoVa;
                    }
                    dt.Columns.Add("TenKhoaHoc", typeof(string));
                    dt.Rows[0]["TenKhoaHoc"] = cmbTrinhDo.Text + " " + cmbKhoaHoc.Text;
                    frmReport frm = new frmReport(dt, "rDanhSachDuDieuKienDuThiTotNghiep");
                    frm.Show();
                    CloseWaitDialog();
                }
                else
                {
                    CloseWaitDialog();
                    ThongBao("Không có dữ liệu để in báo cáo.");
                }
            }
            else
                ThongBao("Bạn phải chọn khóa học.");
        }

        private void btnInDsKhongDuDK_Click(object sender, EventArgs e)
        {
            if (cmbKhoaHoc.EditValue != null)
            {
                CreateWaitDialog("Đang tải dữ liệu, xin vui lòng chờ!", "Xuất báo cáo");
                GetpLopInfo();
                pDM_LopInfo.DM_LopID = cmbLop.EditValue == null ? 0 : int.Parse(cmbLop.EditValue.ToString());
                DataTable dt = oBSV_SinhVien.GetDanhSachKhongDuThiTotNghiep(pDM_LopInfo, Program.NamHoc, Program.IDNamHoc);
                if (dt.Rows.Count > 0)
                {
                    dt.Columns.Add("TenKhoaHoc", typeof(string));
                    dt.Rows[0]["TenKhoaHoc"] = cmbTrinhDo.Text + " " + cmbKhoaHoc.Text;
                    frmReport frm = new frmReport(dt, "rDanhSachKhongDuDieuKienDuThiTotNghiep");
                    frm.Show();
                    CloseWaitDialog();
                }
                else
                {
                    CloseWaitDialog();
                    ThongBao("Không có dữ liệu để in báo cáo.");
                }
            }
            else
                ThongBao("Bạn phải chọn khóa học.");
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (cmbKhoaHoc.EditValue != null)
            {
                CreateWaitDialog("Đang tải dữ liệu, xin vui lòng chờ!", "Xuất báo cáo");
                GetpLopInfo();
                pDM_LopInfo.DM_LopID = cmbLop.EditValue == null ? 0 : int.Parse(cmbLop.EditValue.ToString());
                DataTable dt = oBSV_SinhVien.GetDanhSachXetThiTotNghiep(pDM_LopInfo, Program.NamHoc, Program.IDNamHoc);
                if (dt.Rows.Count > 0)
                {
                    string HoVa = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr["Ten"] = GetTen(dr["HoVaTen"].ToString(), ref HoVa);
                        dr["HoVa"] = HoVa;
                    }
                    dt.Columns.Add("TenKhoaHoc", typeof(string));
                    dt.Rows[0]["TenKhoaHoc"] = cmbKhoaHoc.Text;
                    //frmReport frm = new frmReport(dt, "rDanhSachXetDieuKienDuThiTotNghiep");
                    //frm.Show();
                    CloseWaitDialog();
                    XuatTheoTemplate(dt);
                }
                else
                {
                    CloseWaitDialog();
                    ThongBao("Không có dữ liệu để in báo cáo.");
                }
            }
            else
                ThongBao("Bạn phải chọn khóa học.");
        }

        #region Xuat theo template
        private void XuatTheoTemplate(DataTable dtBaoCao)
        {
            if (dtBaoCao.Rows.Count == 0)
            {
                ThongBao("Không có dữ liệu để xuất ra excel!");
                return;
            }
            string DuongDan = Application.StartupPath;
            string strFileExcel = DuongDan + "\\Template\\Temp_DanhSachXetThiTotNghiep.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + "! Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                return;
            }
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Excel file (*.xls)|*.xls";
            sv.Title = "Xuất dữ liệu";
            sv.FileName = "Danh sach xet thi tot nghiep " + cmbKhoaHoc.Text + ".xls";
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
                XuatDuLieuRaExcel(dtBaoCao, strTenFileExcelMoi);
                ThongBao("Xuất dữ liệu thành công!");
            }
        }

        private void XuatDuLieuRaExcel(DataTable dtSinhVien, string FileExcel)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int DongBatDau = 9, SoCot = 9;
            Excel.Range cel;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);
                if (cmbKhoaHoc.ItemIndex >= 0)
                {
                    string str = cmbTrinhDo.EditValue != null ? "TRÌNH ĐỘ: " + cmbTrinhDo.Text : "";
                    str += (str == "" ? "KHÓA HỌC: " : " - ") + cmbKhoaHoc.Text;
                    excel.Cells[6, 1] = str.ToUpper();
                }

                DataRow dr;
                int SoSinhVien = dtSinhVien.Rows.Count, SoLop = 1, STT = 0, k = 0;
                string IDDM_Lop = dtSinhVien.Rows[0]["IDDM_Lop"].ToString();
                // Insert column Lop
                cel = (Excel.Range)(excel.Cells[DongBatDau + 1, 1]);
                cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                cel = excel.get_Range(excel.Cells[DongBatDau, 1], excel.Cells[DongBatDau, SoCot]);
                cel.WrapText = false;
                excel.Cells[DongBatDau, 1] = "Lớp: " + dtSinhVien.Rows[0]["TenLopSoTrinh"];
                cel.Font.Size = 11;
                cel.Font.Bold = true;
                cel.Merge(null);

                for (int i = 0; i < SoSinhVien; i++)
                {
                    if (IDDM_Lop != dtSinhVien.Rows[i]["IDDM_Lop"].ToString())
                    {
                        IDDM_Lop = dtSinhVien.Rows[i]["IDDM_Lop"].ToString();
                        k = 0;
                        // Insert column Lop
                        cel = (Excel.Range)(excel.Cells[i + DongBatDau + SoLop + 1, 1]);
                        cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);

                        cel = excel.get_Range(excel.Cells[i + DongBatDau + SoLop, 1], excel.Cells[i + DongBatDau + SoLop, SoCot]);
                        cel.WrapText = false;
                        excel.Cells[i + DongBatDau + SoLop, 1] = "Lớp: " + dtSinhVien.Rows[i]["TenLopSoTrinh"];
                        cel.Font.Size = 11;
                        cel.Font.Bold = true;
                        cel.Merge(null);
                        SoLop++;
                    }
                    dr = dtSinhVien.Rows[i];
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + SoLop + 1, 1]);
                    cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);

                    STT++;
                    k++;
                    excel.Cells[i + DongBatDau + SoLop, 1] = STT;
                    excel.Cells[i + DongBatDau + SoLop, 2] = k;
                    excel.Cells[i + DongBatDau + SoLop, 3] = "" + dr["MaSinhVien"];
                    excel.Cells[i + DongBatDau + SoLop, 4] = "" + dr["HoVa"];
                    excel.Cells[i + DongBatDau + SoLop, 5] = "" + dr["Ten"];
                    excel.Cells[i + DongBatDau + SoLop, 6] = "" + dr["NgaySinh"];
                    excel.Cells[i + DongBatDau + SoLop, 7] = "" + dr["NoiSinh"];
                    excel.Cells[i + DongBatDau + SoLop, 8] = "" + dr["LyDo"];
                    excel.Cells[i + DongBatDau + SoLop, 9] = "" + dr["GhiChu"];
                }

                // Set style
                cel = excel.get_Range(excel.Cells[DongBatDau, 1], excel.Cells[DongBatDau + SoLop + SoSinhVien - 1, SoCot]);
                cel.Borders.LineStyle = Excel.XlLineStyle.xlDot;
                cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;

                cel = excel.get_Range(excel.Cells[DongBatDau, 1], excel.Cells[DongBatDau + SoLop + SoSinhVien - 1, 1]);
                cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;

                for (int j = 1; j <= SoCot; j++)
                {
                    cel = excel.get_Range(excel.Cells[DongBatDau, j], excel.Cells[DongBatDau + SoLop + SoSinhVien - 1, j]);
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    if (j != 4)
                        cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    else
                        cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                }

                cel = excel.get_Range(excel.Cells[DongBatDau + SoLop + SoSinhVien - 1, 1], excel.Cells[DongBatDau + SoLop + SoSinhVien - 1, SoCot]);
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