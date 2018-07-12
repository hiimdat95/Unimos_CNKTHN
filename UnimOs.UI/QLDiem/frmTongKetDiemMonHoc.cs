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
using System.Diagnostics;

namespace UnimOs.UI
{
    public partial class frmTongKetDiemMonHoc : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DataTable dtMonKy, dtSinhVien, dtThanhPhan, dtData;
        private cBXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private cBKQHT_DiemTongKetMon oBKQHT_DiemTongKetMon;
        private KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo;
        private cBKQHT_CongThucDiem oBKQHT_CongThucDiem;
        private int IDDM_Lop = 0;
        private DM_LopInfo pDM_LopInfo;

        public frmTongKetDiemMonHoc()
        {
            InitializeComponent();

            // Check quyền để cho phép hay không cho phép thực hiện thao tạc lưu dữ liệu
            SetQuyen(this, "" + this.Tag);

            oBDM_Lop = new cBDM_Lop();
            oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
            pKQHT_DiemTongKetMonInfo = new KQHT_DiemTongKetMonInfo();
            oBKQHT_DiemTongKetMon = new cBKQHT_DiemTongKetMon();
            oBKQHT_CongThucDiem = new cBKQHT_CongThucDiem();
        }

        private void frmTongKetDiemMonHoc_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                IDDM_Lop = pDM_LopInfo.DM_LopID;
                LoadMonKy();
                if (cmbMonHoc.ItemIndex < 0)
                    cmbMonHoc_EditValueChanged(null, null);
            }
        }

        private void LoadMonKy()
        {
            dtMonKy = oBXL_MonHocTrongKy.GetByLop(IDDM_Lop, Program.IDNamHoc, Program.HocKy);
            cmbMonHoc.Properties.DataSource = dtMonKy;
            if ((dtMonKy != null) && (dtMonKy.Rows.Count > 0))
            {
                cmbMonHoc.ItemIndex = 0;
                cmbMonHoc_EditValueChanged(null, null);
            }
            else
            {
                cmbMonHoc.EditValue = null;
                if (dtSinhVien != null)
                    dtSinhVien.Clear();
            }
        }

        private void cmbMonHoc_EditValueChanged(object sender, EventArgs e)
        {
            LoadSinhVien();
            if (cmbMonHoc.EditValue != null)
            {
                btnCapNhat.Enabled = true;
                btnTongHop.Enabled = true;
            }
            else
            {
                btnCapNhat.Enabled = false;
                btnTongHop.Enabled = false;
            }
        }

        private void LoadSinhVien()
        {
            //if (cmbMonHoc.EditValue == null) return;
            if (dtSinhVien != null)
                dtSinhVien.Clear();
            dtSinhVien = CreateTable();
            AddBand();
            XuLyTable();
            grdDiem.DataSource = dtSinhVien;
            dtSinhVien.AcceptChanges();
            btnCapNhat.Enabled = true;
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SV_SinhVienID", typeof(int));
            dt.Columns.Add("MaSinhVien", typeof(string));
            dt.Columns.Add("HoVaTen", typeof(string));
            dt.Columns.Add("CongThuc", typeof(string));
            dt.Columns.Add("NgaySinh", typeof(string));
            dt.Columns.Add("LT1", typeof(float));
            dt.Columns.Add("LT2", typeof(float));
            dt.Columns.Add("DiemTK1", typeof(float));
            dt.Columns.Add("DiemTK2", typeof(float));
            return dt;
        }

        private void AddBand()
        {
            BandedGridColumn bgc;
            KQHT_ThanhPhanDiemInfo pKQHT_ThanPhanDiemInfo = new KQHT_ThanhPhanDiemInfo();
            cBKQHT_ThanhPhanDiem oBKQHT_ThanhPhanDiem = new cBKQHT_ThanhPhanDiem();
            dtThanhPhan = oBKQHT_ThanhPhanDiem.GetByIDTrinhDo(pDM_LopInfo.IDDM_TrinhDo);
            // dtThanhPhan = oBKQHT_CongThucDiem.GetMon(IDDM_Lop, Program.IDNamHoc, Program.HocKy, int.Parse(cmbMonHoc.EditValue.ToString()));
            grbNhapDiem.Columns.Clear();
            if ((dtThanhPhan != null) && (dtThanhPhan.Rows.Count > 0))
            {
                foreach (DataRow dr in dtThanhPhan.Rows)
                {
                    dtSinhVien.Columns.Add(dr["KQHT_ThanhPhanDiemID"].ToString(), typeof(float));
                    bgc = new BandedGridColumn();
                    grbNhapDiem.Columns.Add(bgc);

                    SetColumnBandCaption(bgc, dr["KyHieu"].ToString(), dr["KQHT_ThanhPhanDiemID"].ToString(), 60, DevExpress.Utils.HorzAlignment.Default, false);
                    bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    bgc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    bgc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                    bgvDiem.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });
                }
            }
            //dtSinhVien.Columns.Add("TK", typeof(float));
            //bgc = new BandedGridColumn();
            //grbNhapDiem.Columns.Add(bgc);

            //SetColumnBandCaption(bgc, "Tổng kết", "TK", 80, DevExpress.Utils.HorzAlignment.Default, false);
            //bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //bgc.OptionsColumn.AllowEdit = false;
            //bgc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //bgc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

            //bgvDiem.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });
        }

        private void XuLyTable()
        {
            int IDDM_MonHoc = cmbMonHoc.EditValue == null ? 0 : int.Parse(cmbMonHoc.EditValue.ToString());
            dtData = oBKQHT_DiemTongKetMon.GetMonKy(IDDM_Lop, IDDM_MonHoc,
                Program.IDNamHoc, Program.HocKy, (cmbLanThi.EditValue == null ? 0 : int.Parse(cmbLanThi.EditValue.ToString())));
            DataRow drNew;
            DataRow[] drDiem;
            try
            {
                if (dtData.Rows.Count > 0)
                {
                    //if ("" + dtData.Rows[0]["DiemTongKet"] != "")
                    //    bgvDiem.Columns["TK"].Visible = true;
                    //else
                    //    bgvDiem.Columns["TK"].Visible = false;

                    string SV_SinhVienID = dtData.Rows[0]["SV_SinhVienID"].ToString();
                    drNew = dtSinhVien.NewRow();
                    drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                    drNew["MaSinhVien"] = dtData.Rows[0]["MaSinhVien"].ToString();
                    drNew["HoVaTen"] = dtData.Rows[0]["HoVaTen"].ToString();
                    drNew["NgaySinh"] = dtData.Rows[0]["NgaySinh"].ToString();

                    if ("" + dtData.Rows[0]["LT1"] != "")
                        drNew["LT1"] = dtData.Rows[0]["LT1"];
                    if ("" + dtData.Rows[0]["LT2"] != "")
                        drNew["LT2"] = dtData.Rows[0]["LT2"];

                    drNew["CongThuc"] = dtData.Rows[0]["CongThuc"].ToString();
                    lbCongThucDiem.Text = dtData.Rows[0]["CongThuc"].ToString();
                    drDiem = dtData.Select("SV_SinhVienID =" + SV_SinhVienID);

                    if ("" + dtData.Rows[0]["DiemTongKet"] != "")
                        drNew["DiemTK1"] = dtData.Rows[0]["DiemTongKet"];
                    else
                    {
                        if ("" + dtData.Rows[0]["CongThuc"] != "")
                        drNew["DiemTK1"] = float.Parse(TestCongThuc(drDiem).ToString());
                    }

                    if ("" + dtData.Rows[0]["DiemTK2"] != "")
                        drNew["DiemTK2"] = dtData.Rows[0]["DiemTK2"];
                    //else
                    //    drNew["DiemTK1"] = float.Parse(TestCongThuc(drDiem).ToString());

                    //if ("" + dtData.Rows[0]["CongThuc"] != "")
                    //    drNew["DiemTK1"] = float.Parse(TestCongThuc(drDiem).ToString());

                    foreach (DataRow dr in dtData.Rows)
                    {
                        if (dr["SV_SinhVienID"].ToString() != SV_SinhVienID)
                        {
                            dtSinhVien.Rows.Add(drNew);

                            SV_SinhVienID = dr["SV_SinhVienID"].ToString();
                            drNew = dtSinhVien.NewRow();

                            drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                            drNew["MaSinhVien"] = dr["MaSinhVien"].ToString();
                            drNew["HoVaTen"] = dr["HoVaTen"].ToString();
                            drNew["CongThuc"] = dr["CongThuc"].ToString();
                            drNew["NgaySinh"] = dr["NgaySinh"].ToString();

                            drNew["LT1"] = dr["LT1"];
                            drNew["LT2"] = dr["LT2"];
                            drNew["DiemTK2"] = dr["DiemTK2"];
                            drDiem = dtData.Select("SV_SinhVienID =" + SV_SinhVienID);

                            if ("" + dr["DiemTongKet"] != "")
                                drNew["DiemTK1"] = dr["DiemTongKet"];
                            else
                            {
                                if ("" + dr["CongThuc"] != "")
                                    drNew["DiemTK1"] = float.Parse(TestCongThuc(drDiem).ToString());
                            }
                            try
                            {
                                drNew[dr["KQHT_ThanhPhanDiemID"].ToString()] = dr["Diem"];
                            }
                            catch
                            { }
                        }
                        else
                        {
                            try
                            {
                                drNew[dr["KQHT_ThanhPhanDiemID"].ToString()] = dr["Diem"];
                            }
                            catch (Exception ex)
                            { }
                        }
                    }
                    dtSinhVien.Rows.Add(drNew);
                }
            }
            catch
            { }
        }

        private double TestCongThuc(DataRow[] drDiem)
        {
            double Value = 0; int SoSauDauPhay;
            try
            {
                MathParser parser = new MathParser();
                foreach (DataRow dr in drDiem)
                {
                    parser.CreateVar(dr["KyHieu"].ToString(), double.Parse("0" + dr["Diem"].ToString()), null);
                }
                string formula = null;
                formula = drDiem[0]["CongThuc"].ToString();
                parser.OptimizationOn = true;
                if (formula.IndexOf("R+(") == 0 | formula.IndexOf("R-(") == 0)
                {
                    SoSauDauPhay = int.Parse(formula.Substring(3, 1));
                    double tmp = 0;
                    if (formula.IndexOf("R+(") == 0)
                    {
                        formula = formula.Substring(5, formula.Length - 5);
                        parser.Expression = formula;
                        parser.Parse();
                        tmp = double.Parse(parser.Value.ToString());
                        Value = parser.Round(tmp, SoSauDauPhay, true);
                    }
                    else
                    {
                        formula = formula.Substring(5, formula.Length - 5);
                        parser.Expression = formula;
                        parser.Parse();
                        tmp = double.Parse(parser.Value.ToString());
                        Value = parser.Round(tmp, SoSauDauPhay, false);
                    }
                }
                else
                {
                    parser.Expression = formula;
                    parser.Parse();
                    Value = double.Parse(parser.Value.ToString());
                }
                return Value;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void cmbLanThi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbLanThi.EditValue = null;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (bgvDiem.Columns["TK"].Visible)
            {
                if (dtSinhVien.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSinhVien.Rows)
                    {
                        try
                        {
                            if ("" + dr["TK"].ToString() != "")
                            {
                                pKQHT_DiemTongKetMonInfo.Diem = float.Parse(dr["TK"].ToString());
                                pKQHT_DiemTongKetMonInfo.HocKy = Program.HocKy;
                                pKQHT_DiemTongKetMonInfo.IDDM_NamHoc = Program.IDNamHoc;
                                pKQHT_DiemTongKetMonInfo.IDDM_MonHoc = int.Parse(cmbMonHoc.EditValue.ToString());
                                pKQHT_DiemTongKetMonInfo.LyDo = "";
                                pKQHT_DiemTongKetMonInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                                pKQHT_DiemTongKetMonInfo.LanThi = int.Parse(cmbLanThi.EditValue.ToString());
                                pKQHT_DiemTongKetMonInfo.IDXL_MonHocTrongKy = int.Parse(cmbMonHoc.GetColumnValue("XL_MonHocTrongKyID").ToString());
                                oBKQHT_DiemTongKetMon.Add(pKQHT_DiemTongKetMonInfo);
                            }
                        }
                        catch
                        {
                            // error
                        }
                    }
                    ThongBao("Cập nhật thành công!");
                }
                else
                    ThongBao("Không có dữ liệu!");
            }
            else
                ThongBao("Bạn chưa tổng hợp điểm!");
        }

        private void cmbLanThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSinhVien();
            if (cmbLanThi.EditValue == null)
            {
                //btnTongHop.Enabled = false;
                grbDiemThi.Visible = true;
                grbDiemTK1.Visible = true;
            }
            else
            {
                btnTongHop.Enabled = true;
                grbDiemThi.Visible = false;
                grbDiemTK1.Visible = false;
            }
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            if (dtSinhVien.Rows.Count > 0)
            {
                if ("" + dtSinhVien.Rows[0]["CongThuc"] != "")
                {
                    for (int i = 0; i < dtSinhVien.Rows.Count; i++)
                    {
                        dtSinhVien.Rows[i]["TK"] = dtSinhVien.Rows[i]["DiemTK"];
                    }
                    bgvDiem.Columns["TK"].Visible = true;
                }
                else
                    ThongBao("Môn học chưa có công thức điểm!");
            }
        }

        private void bgvDiem_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void bgvDiem_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {

        }

        private void btnXuatBangKetQua_Click(object sender, EventArgs e)
        {
            XuatBangKQHT();
        }

        #region Xuat bang ket qua hoc tap
        private void XuatBangKQHT()
        {
            if (dtSinhVien.Rows.Count == 0)
            {
                ThongBao("Không có dữ liệu để xuất ra excel!");
                return;
            }

            string DuongDan = Application.StartupPath;
            string strFileExcel = DuongDan + "\\Template\\Temp_PhieuBaoDiem_SS.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + "! Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                return;
            }

            SaveFileDialog sv = new SaveFileDialog();
            sv.FileName = "PhieuKQHT_" + pDM_LopInfo.TenLop.Replace("Lớp: ", "");
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
                XuatBangKQHTRaExcel(dtSinhVien, strTenFileExcelMoi);
                ThongBao("Xuất dữ liệu thành công!");
            }
        }

        private void XuatBangKQHTRaExcel(DataTable dtChiTiet, string FileExcel)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int i = 0;
            int DongBatDau = 12, SoCot = 14;
            Excel.Range cel;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);
                
                // Ten mon
                cel = (Excel.Range)excel.Cells[5, 2];
                excel.Cells[5, 2] = cel.Text + " " + cmbMonHoc.Text;

                //cel = (Excel.Range)excel.Cells[5, 7];
                excel.Cells[5, 7] = "" + pDM_LopInfo.TenLop;

                cel = (Excel.Range)excel.Cells[6, 2];
                excel.Cells[6, 2] = cel.Text + " " + Program.HocKy.ToString();

                cel = (Excel.Range)excel.Cells[6, 7];
                excel.Cells[6, 7] = cel.Text + " " + Program.NamHoc;

                cel = (Excel.Range)excel.Cells[7, 2];
                excel.Cells[7, 2] = cel.Text + " " + cmbMonHoc.GetColumnValue("SoTiet");

                cel = (Excel.Range)excel.Cells[7, 7];
                excel.Cells[7, 7] = cel.Text + " " + cmbMonHoc.GetColumnValue("SoTiet");

                for (int k = 0; k < dtChiTiet.Rows.Count; k++)
                {
                    cel = (Excel.Range)(excel.Cells[DongBatDau + k + 1, 1]);
                    cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);

                    for (int l = 1; l <= SoCot; l++)
                    {
                        cel = (Excel.Range)(excel.Cells[DongBatDau + k, l]);
                        cel.Borders.Value = 1;
                    }
                }

                string Ho_Dem = "";
                for (i = 0; i < dtChiTiet.Rows.Count; i++)
                {
                    //double DiemTB = 0;
                    //int HeSo = 0;
                    excel.Cells[i + DongBatDau, 1] = i + 1;

                    excel.Cells[i + DongBatDau, 2] = "" +  dtChiTiet.Rows[i]["MaSinhVien"];

                    excel.Cells[i + DongBatDau, 4] = "" + GetTen("" + dtChiTiet.Rows[i]["HoVaTen"], ref Ho_Dem);

                    excel.Cells[i + DongBatDau, 3] = "" + Ho_Dem;

                    //excel.Cells[i + DongBatDau + 1, 4] = dtChiTiet.Rows[i]["NgaySinh"] + "";

                    //for (int j = 6; j < dtChiTiet.Columns.Count - 2; j++)
                    //{
                    //    if (dtChiTiet.Rows[i][j] + "" != "")
                    //    {
                    //        HeSo += 2;
                    //        DiemTB += 2 * (double)dtChiTiet.Rows[i][j];
                    //    }
                    //    excel.Cells[i + DongBatDau + 1, j - 1] = dtChiTiet.Rows[i][j] + "";
                    //}

                    //if (HeSo > 0)
                    //{
                    //    excel.Cells[i + DongBatDau + 1, 11] = DiemTB / HeSo;
                    //}

                    //excel.Cells[i + DongBatDau + 1, 12] = dtChiTiet.Rows[i][dtChiTiet.Columns.Count - 2] + "";

                    //excel.Cells[i + DongBatDau + 1, 13] = dtChiTiet.Rows[i][dtChiTiet.Columns.Count - 1] + "";
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

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            XuatTheoTemplate();
        }

        private void XuatTheoTemplate()
        {
            if (dtSinhVien.Rows.Count == 0)
            {
                ThongBao("Không có dữ liệu để xuất ra excel!");
                return;
            }

            string DuongDan = Application.StartupPath;
            string strFileExcel = DuongDan + "\\Template\\PhieuBaoDiem.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + "! Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                return;
            }

            SaveFileDialog sv = new SaveFileDialog();
            sv.FileName = "PhieuKQHT_" + pDM_LopInfo.TenLop.Replace("Lớp: ", "");
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
                XuatDuLieuRaExcel(dtSinhVien, strTenFileExcelMoi);
                ThongBao("Xuất dữ liệu thành công!");
            }
        }

        private void XuatDuLieuRaExcel(DataTable dtChiTiet, string FileExcel)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int i = 0;
            int DongBatDau = 7;
            Excel.Range cel;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);
                excel.Cells[1, 1] = Program.TenTruong.ToUpper();
                cel = (Excel.Range)excel.Cells[1, 1];
                cel.Font.Bold = true;

                excel.Cells[2, 1] = uctrlLop.trlLop.FocusedNode.ParentNode.RootNode["TenLop"];
                cel = (Excel.Range)excel.Cells[2, 1];

                excel.Cells[4, 3] = cmbMonHoc.Text;
                cel = (Excel.Range)excel.Cells[4, 3];

                excel.Cells[4, 12] = cmbMonHoc.GetColumnValue("SoTiet");
                cel = (Excel.Range)excel.Cells[4, 12];

                excel.Cells[5, 1] = uctrlLop.trlLop.FocusedNode["TenLop"];
                cel = (Excel.Range)excel.Cells[5, 1];

                // Them các tiêu đề cột phía sau
                for (int j = 6; j < dtChiTiet.Columns.Count - 2; j++)
                {
                    int intID = 0;
                    if (int.TryParse(dtChiTiet.Columns[j].ColumnName, out intID))
                    {
                        excel.Cells[DongBatDau, j - 4] = excel.Cells[i + DongBatDau + 1, j - 4] = ReturnTenThanhPhanDiem(dtChiTiet.Columns[j].ColumnName + "");
                        cel = (Excel.Range)(excel.Cells[DongBatDau, j]);
                    }
                }

                for (int k = 0; k < dtChiTiet.Rows.Count + 1; k++)
                {
                    for (int l = 1; l <= 14; l++)
                    {
                        cel = (Excel.Range)(excel.Cells[DongBatDau + k, l]);
                        cel.Borders.Value = 1;
                    }
                }

                for (i = 0; i < dtChiTiet.Rows.Count; i++)
                {
                    double DiemTB = 0;
                    int HeSo = 0;
                    excel.Cells[i + DongBatDau + 1, 1] = i + 1;

                    excel.Cells[i + DongBatDau + 1, 2] = dtChiTiet.Rows[i]["MaSinhVien"] + "";

                    excel.Cells[i + DongBatDau + 1, 3] = dtChiTiet.Rows[i]["HoVaTen"] + "";

                    excel.Cells[i + DongBatDau + 1, 4] = dtChiTiet.Rows[i]["NgaySinh"] + "";

                    for (int j = 6; j < dtChiTiet.Columns.Count - 2; j++)
                    {
                        if (dtChiTiet.Rows[i][j] + "" != "")
                        {
                            HeSo += 2;
                            DiemTB += 2 * (float)dtChiTiet.Rows[i][j];
                        }
                        excel.Cells[i + DongBatDau + 1, j - 1] = dtChiTiet.Rows[i][j] + "";
                    }

                    if (HeSo > 0)
                    {
                        excel.Cells[i + DongBatDau + 1, 11] = DiemTB / HeSo;
                    }

                    excel.Cells[i + DongBatDau + 1, 12] = dtChiTiet.Rows[i][dtChiTiet.Columns.Count - 2] + "";

                    excel.Cells[i + DongBatDau + 1, 13] = dtChiTiet.Rows[i][dtChiTiet.Columns.Count - 1] + "";
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

        private string ReturnTenThanhPhanDiem(string ID)
        {

            DataRow[] dr = dtThanhPhan.Select("KQHT_ThanhPhanDiemID = " + ID);
            return dr[0]["KyHieu"].ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMonHoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbMonHoc.EditValue = null;
            }
        }
    }
}