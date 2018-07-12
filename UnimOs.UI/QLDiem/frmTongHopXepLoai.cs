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
using DevExpress.XtraGrid.Views.BandedGrid;
using System.IO;

namespace UnimOs.UI
{
    public partial class frmTongHopXepLoai : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private DataTable dtKhoaHoc, dtXepLoai, dtLop;
        private int _DongBatDau = 9, _CotBatDau = 4, ColStart;

        public frmTongHopXepLoai()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            pDM_LopInfo = new DM_LopInfo();
        }

        private void frmTongHopXepLoai_Load(object sender, EventArgs e)
        {
            LoadCombo();
            LoadDanhSachLop();
        }
        private void LoadCombo()
        {
            cmbHe.Properties.DataSource = LoadHe();
            cmbTrinhDo.Properties.DataSource = LoadTrinhDo();
            cmbKhoa.Properties.DataSource = LoadKhoa();
            dtKhoaHoc = LoadKhoaHoc();
            cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;
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
        }

        private void cmbKhoa_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.EditValue != null)
            {
                cmbNganh.Properties.DataSource = LoadNganhByIDKhoa(int.Parse("0" + cmbKhoa.EditValue));
            }
        }

        private void LoadDanhSachLop()
        {
            dtLop = CreateTable();
            AddBand();
            XuLyTable();
            grdLop.DataSource = dtLop;
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
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DM_LopID", typeof(int));
            dt.Columns.Add("TenLop", typeof(string));
            dt.Columns.Add("SoSinhVien", typeof(int));
            ColStart = 3;
            return dt;
        }

        private void AddBand()
        {
            GridBand grb;
            BandedGridColumn bgcSoSV, bgcTyLe;
            KQHT_XepLoaiTotNghiepInfo pKQHT_XepLoaiTotNghiepInfo = new KQHT_XepLoaiTotNghiepInfo();
            cBKQHT_XepLoaiTotNghiep oBKQHT_XepLoaiTotNghiep = new cBKQHT_XepLoaiTotNghiep();
            dtXepLoai = oBKQHT_XepLoaiTotNghiep.Get(pKQHT_XepLoaiTotNghiepInfo);
            grbXepLoai.Columns.Clear();
            grbXepLoai.Children.Clear();
            if ((dtXepLoai != null) && (dtXepLoai.Rows.Count > 0))
            {
                foreach (DataRow dr in dtXepLoai.Rows)
                {
                    dtLop.Columns.Add(dr["KQHT_XepLoaiTotNghiepID"].ToString(), typeof(double));
                    dtLop.Columns.Add("TyLe_" + dr["KQHT_XepLoaiTotNghiepID"], typeof(string));
                    // Add band Tên xếp loại
                    grb = new GridBand();
                    grbXepLoai.Children.AddRange(new GridBand[] { grb });
                    // Add cột số sinh viên
                    bgcSoSV = new BandedGridColumn();
                    grb.Columns.Add(bgcSoSV);

                    SetColumnBandCaption(bgcSoSV, "SL", dr["KQHT_XepLoaiTotNghiepID"].ToString(), 
                        50, DevExpress.Utils.HorzAlignment.Default, true);
                    bgcSoSV.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    bgcSoSV.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                    // Add cột tỷ lệ
                    bgcTyLe = new BandedGridColumn();
                    grb.Columns.Add(bgcTyLe);

                    SetColumnBandCaption(bgcTyLe, "%", "TyLe_" + dr["KQHT_XepLoaiTotNghiepID"].ToString(),
                        50, DevExpress.Utils.HorzAlignment.Far, false);
                    bgcTyLe.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    bgcTyLe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                    bgvLop.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgcSoSV, bgcTyLe });

                    SetBandCaption(grb, dr["TenXepLoai"].ToString(), 100);
                    // End add band Tên xếp loại
                }
                // Add band chưa xếp loại
                dtLop.Columns.Add("0", typeof(double));
                dtLop.Columns.Add("TyLe_0", typeof(string));
                // Add band Tên xếp loại
                grb = new GridBand();
                grbXepLoai.Children.AddRange(new GridBand[] { grb });
                // Add cột số sinh viên
                bgcSoSV = new BandedGridColumn();
                grb.Columns.Add(bgcSoSV);

                SetColumnBandCaption(bgcSoSV, "SL", "0", 50, DevExpress.Utils.HorzAlignment.Default, false);
                bgcSoSV.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                bgcSoSV.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                // Add cột tỷ lệ
                bgcTyLe = new BandedGridColumn();
                grb.Columns.Add(bgcTyLe);

                SetColumnBandCaption(bgcTyLe, "%", "TyLe_0", 50, DevExpress.Utils.HorzAlignment.Far, false);
                bgcTyLe.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                bgcTyLe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                bgvLop.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgcSoSV, bgcTyLe });

                SetBandCaption(grb, "Chưa xếp loại", 100);
                // End add band Tên xếp loại
            }
        }

        private void XuLyTable()
        {
            if (dtXepLoai.Rows.Count > 0)
            {
                DataTable dtData;
                int IDDM_NamHoc, HocKy;
                pDM_LopInfo.IDDM_Khoa = cmbKhoa.EditValue == null ? 0 : int.Parse(cmbKhoa.EditValue.ToString());
                pDM_LopInfo.IDDM_He = cmbHe.EditValue == null ? 0 : int.Parse(cmbHe.EditValue.ToString());
                pDM_LopInfo.IDDM_TrinhDo = cmbTrinhDo.EditValue == null ? 0 : int.Parse(cmbTrinhDo.EditValue.ToString());
                pDM_LopInfo.IDDM_Nganh = cmbNganh.EditValue == null ? 0 : int.Parse(cmbNganh.EditValue.ToString());
                pDM_LopInfo.IDDM_KhoaHoc = cmbKhoaHoc.EditValue == null ? 0 : int.Parse(cmbKhoaHoc.EditValue.ToString());
                if (rdNamHoc.SelectedIndex == 0)
                {
                    IDDM_NamHoc = Program.IDNamHoc;
                    HocKy = Program.HocKy;
                }
                else if (rdNamHoc.SelectedIndex == 1)
                {
                    IDDM_NamHoc = Program.IDNamHoc;
                    HocKy = 0;
                }
                else
                {
                    IDDM_NamHoc = 0;
                    HocKy = 0;
                }

               dtData = oBDM_Lop.GetTongHopXepLoai(pDM_LopInfo, Program.NamHoc, IDDM_NamHoc, HocKy);
               DataRow drNew;
                if (dtData.Rows.Count > 0)
                {
                    string DM_LopID = dtData.Rows[0]["DM_LopID"].ToString();
                    drNew = dtLop.NewRow();
                    drNew["DM_LopID"] = int.Parse(DM_LopID);
                    drNew["SoSinhVien"] = dtData.Rows[0]["SoSinhVien"];
                    drNew["TenLop"] = dtData.Rows[0]["TenLop"].ToString();
                    foreach (DataRow dr in dtData.Rows)
                    {
                        if (dr["DM_LopID"].ToString() != DM_LopID)
                        {
                            dtLop.Rows.Add(drNew);

                            DM_LopID = dr["DM_LopID"].ToString();
                            drNew = dtLop.NewRow();

                            drNew["DM_LopID"] = int.Parse(DM_LopID);
                            drNew["SoSinhVien"] = dr["SoSinhVien"];
                            drNew["TenLop"] = dr["TenLop"].ToString();

                            drNew[dr["IDDM_XepLoaiL1"].ToString()] = dr["TongSo"];
                            drNew["TyLe_" + dr["IDDM_XepLoaiL1"]] = dr["TyLe"].ToString() + " %";
                        }
                        else
                        {
                            drNew[dr["IDDM_XepLoaiL1"].ToString()] = dr["TongSo"];
                            drNew["TyLe_" + dr["IDDM_XepLoaiL1"]] = dr["TyLe"].ToString() + " %";
                        }
                    }
                    dtLop.Rows.Add(drNew);
                }
            }
        }

        private void bgvLop_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
        private void btnLocSV_Click(object sender, EventArgs e)
        {
            LoadDanhSachLop();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Xuat bang ket qua hoc tap
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dtLop == null || dtLop.Rows.Count == 0)
            {
                ThongBao("Không có dữ liệu để xuất ra excel!");
                return;
            }
            XuatPhieuNhapDiem();
        }

        private string GetTenTrinhDo()
        {
            string str = "";
            if (cmbHe.EditValue != null)
                str += "Hệ: " + cmbHe.Text;
            if (cmbTrinhDo.EditValue != null)
                str += (str == "" ? "" : " - ") + "Trình độ: " + cmbTrinhDo.Text;
            if (cmbKhoa.EditValue != null)
                str += (str == "" ? "" : " - ") + "Khoa: " + cmbKhoa.Text;
            if (cmbKhoaHoc.EditValue != null)
                str += (str == "" ? "" : " - ") + "Khóa: " + cmbKhoaHoc.Text;
            return str;
        }

        private void XuatPhieuNhapDiem()
        {
            string strFileExcel = Application.StartupPath + "\\Template\\Temp_TongHopXepLoai.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + "! Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                return;
            }

            SaveFileDialog sv = new SaveFileDialog();
            if (rdNamHoc.EditValue.ToString() == "0")
                sv.FileName = "Xep Loai HL HK " + Program.HocKy + " Nam " + Program.NamHoc + ".xls";
            else if (rdNamHoc.EditValue.ToString() == "1")
                sv.FileName = "Xep Loai HL Nam " + Program.NamHoc + ".xls";
            else
                sv.FileName = "Xep Loai HL Toan khoa (Nam " + Program.NamHoc + ").xls";
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
                DataTable dt = ((DataView)bgvLop.DataSource).ToTable();
                XuatPhieuNhapRaExcel(dt, strTenFileExcelMoi);
                ThongBao("Xuất dữ liệu thành công!");
            }
        }

        private void XuatPhieuNhapRaExcel(DataTable dtChiTiet, string FileExcel)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int DongBatDau = _DongBatDau, CotBatDau = _CotBatDau, SoCot = ColStart;
            Excel.Range cel;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);

                //// Ten mon
                //cel = (Excel.Range)excel.Cells[5, 2];
                //excel.Cells[5, 2] = cel.Text + " " + drMonHoc["TenMonHoc"].ToString();

                //cel = (Excel.Range)excel.Cells[5, 5];
                excel.Cells[3, 1] = GetTenTrinhDo();

                if (rdNamHoc.EditValue.ToString() == "0")
                    excel.Cells[4, 1] = "XẾP LOẠI HỌC LỰC HỌC KỲ " + Program.HocKy + " NĂM HỌC " + Program.NamHoc;
                else if (rdNamHoc.EditValue.ToString() == "1")
                    excel.Cells[4, 1] = "XẾP LOẠI HỌC LỰC NĂM HỌC " + Program.NamHoc;
                else
                    excel.Cells[4, 1] = "XẾP LOẠI HỌC LỰC TOÀN KHÓA";

                // Insert columns
                if (grbXepLoai.Children.Count > 0)
                {
                    int CotDau = CotBatDau;
                    for (int i = 0; i < grbXepLoai.Children.Count; i++)
                    {
                        foreach (BandedGridColumn bgc in grbXepLoai.Children[i].Columns)
                        {
                            cel = (Excel.Range)(excel.Cells[8, CotBatDau]);
                            cel.EntireColumn.Insert(Excel.XlDirection.xlToRight, null);
                            SoCot++;
                            excel.Cells[8, CotBatDau] = bgc.Caption;
                            CotBatDau++;
                        }
                        cel = excel.get_Range(excel.Cells[8, CotDau], excel.Cells[8, CotBatDau - 1]);
                        cel.Borders.Value = 1;
                        excel.Cells[7, CotDau] = grbXepLoai.Children[i].Caption;
                        cel = excel.get_Range(excel.Cells[7, CotDau], excel.Cells[7, CotBatDau - 1]);
                        cel.Merge(null);
                        cel.Borders.Value = 1;
                        CotDau = CotBatDau;
                    }
                    excel.Cells[6, 4] = "XẾP LOẠI";
                    cel = excel.get_Range(excel.Cells[6, 4], excel.Cells[6, CotBatDau - 1]);
                    cel.Merge(null);
                    cel.Borders.Value = 1;
                }

                for (int i = 4; i < CotBatDau; i++)
                {
                    cel = (Excel.Range)(excel.Cells[8, i]);
                    cel.ColumnWidth = 5.0;
                }

                for (int i = 0; i < dtChiTiet.Rows.Count; i++)
                {
                    // Insert rows
                    cel = (Excel.Range)(excel.Cells[DongBatDau + i + 1, 1]);
                    cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);

                    for (int l = 1; l <= SoCot; l++)
                    {
                        cel = (Excel.Range)(excel.Cells[DongBatDau + i, l]);
                        cel.Borders.Value = 1;
                    }
                    excel.Cells[i + DongBatDau, 1] = i + 1;

                    excel.Cells[i + DongBatDau, 2] = "" + dtChiTiet.Rows[i]["TenLop"];

                    excel.Cells[i + DongBatDau, 3] = "" + dtChiTiet.Rows[i]["SoSinhVien"];
                    for (int k = ColStart; k < dtChiTiet.Columns.Count; k++)
                    {
                        excel.Cells[DongBatDau + i, _CotBatDau + k - ColStart] = dtChiTiet.Rows[i][k];
                    }
                }
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

        private void cmbHe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbHe.ClosePopup();
                cmbHe.EditValue = null;
            }
        }

        private void cmbTrinhDo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbTrinhDo.ClosePopup();
                cmbTrinhDo.EditValue = null;
            }
        }

        private void cmbKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbKhoa.ClosePopup();
                cmbKhoa.EditValue = null;
            }
        }

        private void cmbNganh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbNganh.ClosePopup();
                cmbNganh.EditValue = null;
            }
        }

        private void cmbKhoaHoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbKhoaHoc.ClosePopup();
                cmbKhoaHoc.EditValue = null;
            }
        }
    }
}