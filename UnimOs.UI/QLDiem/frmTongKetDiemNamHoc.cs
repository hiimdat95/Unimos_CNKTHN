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
    public partial class frmTongKetDiemNamHoc : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private DataTable dtSinhVien, dtMonHoc, dtData, dtXepLoai;
        private cBXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private cBKQHT_DiemTongKetHocKy oBKQHT_DiemTongKetHocKy;
        private KQHT_DiemTongKetHocKyInfo pKQHT_DiemTongKetHocKyInfo;
        private KQHT_XepLoaiTotNghiepInfo pKQHT_XepLoaiTotNghiepInfo;
        private cBKQHT_XepLoaiTotNghiep oBKQHT_XepLoaiTotNghiep;
        private cBKQHT_DiemTongKetMon oBKQHT_DiemTongKetMon;
        private int IDDM_Lop = 0;
        private int dtColStart = 0, dtColEnd = 0, _ColStart = 6;

        public frmTongKetDiemNamHoc()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
            pKQHT_DiemTongKetHocKyInfo = new KQHT_DiemTongKetHocKyInfo();
            oBKQHT_DiemTongKetHocKy = new cBKQHT_DiemTongKetHocKy();
            pKQHT_XepLoaiTotNghiepInfo = new KQHT_XepLoaiTotNghiepInfo();
            oBKQHT_XepLoaiTotNghiep = new cBKQHT_XepLoaiTotNghiep();
            oBKQHT_DiemTongKetMon = new cBKQHT_DiemTongKetMon();
        }

        private void frmTongKetDiemNamHoc_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
            dtXepLoai = oBKQHT_XepLoaiTotNghiep.Get(pKQHT_XepLoaiTotNghiepInfo);
            repositoryXepLoai.DataSource = dtXepLoai;
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                IDDM_Lop = pDM_LopInfo.DM_LopID;
                dtSinhVien = CreateTable();
                AddBand();
                XuLyTable();
                grdDiem.DataSource = dtSinhVien;
                dtSinhVien.AcceptChanges();
                btnCapNhat.Enabled = true;
            }
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SV_SinhVienID", typeof(int));
            dt.Columns.Add("MaSinhVien", typeof(string));
            dt.Columns.Add("HoVa", typeof(string));
            dt.Columns.Add("Ten", typeof(string));
            dt.Columns.Add("NgaySinh", typeof(string));
            dt.Columns.Add("DiemTK1", typeof(float));
            dt.Columns.Add("KQHT_XepLoaiTotNghiepID1", typeof(int));
            dt.Columns.Add("GhiChuL1", typeof(string));
            dt.Columns.Add("DiemTK2", typeof(float));
            dt.Columns.Add("KQHT_XepLoaiTotNghiepID2", typeof(int));
            dt.Columns.Add("GhiChuL2", typeof(string));
            dtColStart = 11;
            dtColEnd = dtColStart;
            return dt;
        }

        private void AddBand()
        {
            BandedGridColumn bgc; GridBand grbHocKy, grbTenMon, grbSoTrinh;
            dtMonHoc = oBXL_MonHocTrongKy.GetByLop(IDDM_Lop, Program.IDNamHoc, 0);
            grbMonHoc.Children.Clear();
            if ((dtMonHoc != null) && (dtMonHoc.Rows.Count > 0))
            {
                string HocKy = dtMonHoc.Rows[0]["HocKy"].ToString();
                int BandWidth = 0;
                grbHocKy = new GridBand();
                grbMonHoc.Children.AddRange(new GridBand[] { grbHocKy });
                foreach (DataRow dr in dtMonHoc.Rows)
                {
                    if (HocKy != dr["HocKy"].ToString())
                    {
                        if (grbHocKy.Children.Count == 0)
                            grbHocKy.Visible = false;
                        else
                            grbHocKy.Visible = true;
                        SetBandCaption(grbHocKy, "HỌC KỲ " + HocKy, BandWidth);
                        HocKy = dr["HocKy"].ToString();
                        grbHocKy = new GridBand();
                        grbMonHoc.Children.AddRange(new GridBand[] { grbHocKy });
                        BandWidth = 0;
                    }
                    // Dinh dang cua grid
                    //   Ten mon
                    // SoHocTrinh
                    //  L1  |  L2

                    // Begin Add band TenMonHoc
                    grbTenMon = new GridBand();
                    grbTenMon.RowCount = 2;
                    grbTenMon.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    grbHocKy.Children.AddRange(new GridBand[] { grbTenMon });

                    // Begin Add band SoHocTrinh
                    grbSoTrinh = new GridBand();
                    grbTenMon.Children.Add(grbSoTrinh);

                    for (int j = 1; j <= 2; j++)
                    {
                        dtColEnd++;
                        dtSinhVien.Columns.Add("C" + HocKy + "_" + dr["XL_MonHocTrongKyID"] + "_" + j.ToString(), typeof(float));
                        // Begin Add column DiemLan1
                        bgc = new BandedGridColumn();
                        grbSoTrinh.Columns.Add(bgc);

                        SetColumnBandCaption(bgc, "L" + j.ToString(), "C" + HocKy + "_" + dr["XL_MonHocTrongKyID"] + "_" + j.ToString(), 40,
                            DevExpress.Utils.HorzAlignment.Default, false);

                        bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                        bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        bgc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        //bgc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                        bgvDiem.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });
                        // End Add column DiemLan1
                    }

                    SetBandCaption(grbSoTrinh, dr["SoHocTrinh"].ToString(), 80);
                    // End Add band SoHocTrinh

                    SetBandCaption(grbTenMon, dr["TenMonHoc"].ToString(), 80);
                    // End Add band TenMonHoc
                }
                SetBandCaption(grbHocKy, "HỌC KỲ " + HocKy, BandWidth);
                if (grbHocKy.Children.Count == 0)
                    grbHocKy.Visible = false;
                else
                    grbHocKy.Visible = true;
            }
        }

        private void XuLyTable()
        {
            dtData = oBKQHT_DiemTongKetHocKy.GetDanhSach(IDDM_Lop, Program.IDNamHoc, 0, 1);
            DataRow drNew;
            
            //try
            //{
                if (dtData.Rows.Count > 0)
                {
                    string SV_SinhVienID = dtData.Rows[0]["SV_SinhVienID"].ToString(), Ho_Dem = "";

                    drNew = dtSinhVien.NewRow();
                    drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                    drNew["MaSinhVien"] = dtData.Rows[0]["MaSinhVien"];
                    drNew["Ten"] = GetTen(dtData.Rows[0]["HoVaTen"].ToString(), ref Ho_Dem);
                    drNew["HoVa"] = Ho_Dem;
                    drNew["NgaySinh"] = "" + dtData.Rows[0]["NgaySinh"];
                    if (dtData.Rows[0]["DiemTK1"].ToString() != "")
                    {
                        grbDiemTK.Visible = true;
                        colDiemTK.Visible = true;
                        colXepLoai.Visible = true;
                    }
                    else
                    {
                        grbDiemTK.Visible = false;
                        colDiemTK.Visible = false;
                        colXepLoai.Visible = false;
                    }
                    drNew["DiemTK1"] = dtData.Rows[0]["DiemTK1"];
                    drNew["KQHT_XepLoaiTotNghiepID1"] = dtData.Rows[0]["IDDM_XepLoaiL1"];

                    drNew["DiemTK2"] = dtData.Rows[0]["DiemTK2"];
                    drNew["KQHT_XepLoaiTotNghiepID2"] = dtData.Rows[0]["IDDM_XepLoaiL2"];
                    
                    foreach (DataRow dr in dtData.Rows)
                    {
                        if (dr["SV_SinhVienID"].ToString() != SV_SinhVienID)
                        {
                            dtSinhVien.Rows.Add(drNew);

                            SV_SinhVienID = dr["SV_SinhVienID"].ToString();
                            drNew = dtSinhVien.NewRow();

                            drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                            drNew["MaSinhVien"] = dr["MaSinhVien"];

                            drNew["Ten"] = GetTen(dr["HoVaTen"].ToString(), ref Ho_Dem);
                            drNew["HoVa"] = Ho_Dem;

                            drNew["NgaySinh"] = "" + dr["NgaySinh"];

                            drNew["DiemTK1"] = dr["DiemTK1"];
                            drNew["KQHT_XepLoaiTotNghiepID1"] = dr["IDDM_XepLoaiL1"];
                            drNew["GhiChuL1"] = "" + dr["GhiChuL1"];

                            drNew["DiemTK2"] = dr["DiemTK2"];
                            drNew["KQHT_XepLoaiTotNghiepID2"] = dr["IDDM_XepLoaiL2"];
                            drNew["GhiChuL2"] = "" + dr["GhiChuL2"];

                            if ("" + dr["IDXL_MonHocTrongKy"] != "")
                            {
                                drNew["C" + dr["HocKy"] + "_" + dr["IDXL_MonHocTrongKy"] + "_1"] = dr["DiemLan1"];
                                drNew["C" + dr["HocKy"] + "_" + dr["IDXL_MonHocTrongKy"] + "_2"] = dr["DiemLan2"];
                            }
                        }
                        else
                        {
                            if ("" + dr["IDXL_MonHocTrongKy"] != "")
                            {
                                drNew["C" + dr["HocKy"] + "_" + dr["IDXL_MonHocTrongKy"] + "_1"] = dr["DiemLan1"];
                                drNew["C" + dr["HocKy"] + "_" + dr["IDXL_MonHocTrongKy"] + "_2"] = dr["DiemLan2"];
                            }
                        }
                    }
                    dtSinhVien.Rows.Add(drNew);
                    dtSinhVien.DefaultView.Sort = "Ten, HoVa";
                }
                else
                    grbDiemTK.Visible = false;
            //}
            //catch (Exception ex)
            //{
            //    ThongBaoLoi(ex.Message);
            //}
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            grbDiemTK.Visible = true;
            colDiemTK.Visible = true;
            colXepLoai.Visible = true;
            MathParser parser = new MathParser();
            double TongHeSo = 0, TongSoDiemL1, TongSoDiemL2, DiemTK;
            bool IsCoDiemLan2;
            int SoMonL1, SoMonL2;
            int SoThapPhanLamTron = int.Parse((new cBKQHT_QuyChe()).GetByMaThamSo(pDM_LopInfo.IDDM_TrinhDo, "TBC_LAMTRON"));
            // HocKy = 0: Tinh diem ca nam
            int SoMonCoDiem = oBKQHT_DiemTongKetMon.GetSoMonCoDiemByLop(pDM_LopInfo.DM_LopID, Program.IDNamHoc, 0, ref TongHeSo);
            string[] arrStr;

            if (dtSinhVien.Rows.Count > 0 && dtMonHoc != null && dtMonHoc.Rows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < dtSinhVien.Rows.Count; i++)
                    {
                        TongSoDiemL1 = 0;
                        TongSoDiemL2 = 0;
                        SoMonL1 = 0;
                        SoMonL2 = 0;
                        IsCoDiemLan2 = false;

                        for (int j = dtColStart; j < dtSinhVien.Columns.Count; j += 2)
                        {
                            arrStr = dtSinhVien.Columns[j].ColumnName.Split('_');
                            if (arrStr.Length > 0)
                            {
                                DataRow[] dr = dtMonHoc.Select("XL_MonHocTrongKyID = " + arrStr[1]);
                                if (dr.Length > 0 && (bool)dr[0]["TinhDiemToanKhoa"] == true)
                                {
                                    if (dtSinhVien.Rows[i][dtSinhVien.Columns[j].ColumnName].ToString() != "")
                                    {
                                        TongSoDiemL1 += double.Parse("0" + dtSinhVien.Rows[i][dtSinhVien.Columns[j].ColumnName].ToString()) * double.Parse("0" + dr[0]["SoHocTrinh"].ToString());
                                        SoMonL1++;
                                    }
                                    if (dtSinhVien.Rows[i][dtSinhVien.Columns[j + 1].ColumnName].ToString() != "")
                                    {
                                        IsCoDiemLan2 = true;
                                        TongSoDiemL2 += double.Parse("0" + dtSinhVien.Rows[i][dtSinhVien.Columns[j + 1].ColumnName].ToString()) * double.Parse("0" + dr[0]["SoHocTrinh"].ToString());
                                        SoMonL2++;
                                    }
                                    else if (dtSinhVien.Rows[i][dtSinhVien.Columns[j].ColumnName].ToString() != "")
                                    {
                                        TongSoDiemL2 += double.Parse("0" + dtSinhVien.Rows[i][dtSinhVien.Columns[j].ColumnName].ToString()) * double.Parse("0" + dr[0]["SoHocTrinh"].ToString());
                                        SoMonL2++;
                                    }
                                }
                            }
                        }

                        DiemTK = parser.Round(TongSoDiemL1 / TongHeSo, SoThapPhanLamTron, true);
                        dtSinhVien.Rows[i]["DiemTK1"] = DiemTK;
                        if (SoMonL1 < SoMonCoDiem)
                        {
                            dtSinhVien.Rows[i]["GhiChuL1"] = (SoMonCoDiem - SoMonL1).ToString() + " môn không có điểm";
                            dtSinhVien.Rows[i]["KQHT_XepLoaiTotNghiepID1"] = 0;
                        }
                        else
                        {
                            for (int j = 0; j < dtXepLoai.Rows.Count; j++)
                            {
                                if (DiemTK >= double.Parse(dtXepLoai.Rows[j]["TuDiem"].ToString()))
                                {
                                    dtSinhVien.Rows[i]["KQHT_XepLoaiTotNghiepID1"] = dtXepLoai.Rows[j]["KQHT_XepLoaiTotNghiepID"];
                                    dtSinhVien.Rows[i]["GhiChuL1"] = "";
                                    break;
                                }
                            }
                        }
                        if (IsCoDiemLan2)
                        {
                            DiemTK = parser.Round(TongSoDiemL2 / TongHeSo, SoThapPhanLamTron, true);
                            dtSinhVien.Rows[i]["DiemTK2"] = DiemTK;
                            if (SoMonL2 < SoMonCoDiem)
                            {
                                dtSinhVien.Rows[i]["GhiChuL2"] = (SoMonCoDiem - SoMonL2).ToString() + " môn không có điểm";
                                dtSinhVien.Rows[i]["KQHT_XepLoaiTotNghiepID2"] = 0;
                            }
                            else
                            {
                                for (int j = 0; j < dtXepLoai.Rows.Count; j++)
                                {
                                    if (DiemTK >= double.Parse(dtXepLoai.Rows[j]["TuDiem"].ToString()))
                                    {
                                        dtSinhVien.Rows[i]["KQHT_XepLoaiTotNghiepID2"] = dtXepLoai.Rows[j]["KQHT_XepLoaiTotNghiepID"];
                                        dtSinhVien.Rows[i]["GhiChuL2"] = "";
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            dtSinhVien.Rows[i]["DiemTK2"] = DBNull.Value;
                            dtSinhVien.Rows[i]["KQHT_XepLoaiTotNghiepID2"] = DBNull.Value;
                            dtSinhVien.Rows[i]["GhiChuL2"] = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    ThongBaoLoi(ex.Message);
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = dtSinhVien.GetChanges();
            if (dtTemp != null)
            {
                foreach (DataRow dr in dtTemp.Rows)
                {
                    if (dr.RowState == DataRowState.Modified)
                    {
                        if ("" + dr["DiemTK1"] != "")
                        {
                            try
                            {
                                pKQHT_DiemTongKetHocKyInfo = new KQHT_DiemTongKetHocKyInfo();
                                pKQHT_DiemTongKetHocKyInfo.HocKy = 0;
                                pKQHT_DiemTongKetHocKyInfo.IDDM_NamHoc = Program.IDNamHoc;
                                pKQHT_DiemTongKetHocKyInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                                pKQHT_DiemTongKetHocKyInfo.DiemL1 = float.Parse(dr["DiemTK1"].ToString());
                                pKQHT_DiemTongKetHocKyInfo.IDDM_XepLoaiL1 = int.Parse("0" + dr["KQHT_XepLoaiTotNghiepID1"].ToString());
                                pKQHT_DiemTongKetHocKyInfo.GhiChuL1 = "" + dr["GhiChuL1"];

                                pKQHT_DiemTongKetHocKyInfo.DiemL2 = ("" + dr["DiemTK2"] != "" ? double.Parse(dr["DiemTK2"].ToString()) : pKQHT_DiemTongKetHocKyInfo.DiemL2);
                                pKQHT_DiemTongKetHocKyInfo.IDDM_XepLoaiL2 = int.Parse("0" + dr["KQHT_XepLoaiTotNghiepID2"].ToString());
                                pKQHT_DiemTongKetHocKyInfo.GhiChuL2 = "" + dr["GhiChuL2"];

                                oBKQHT_DiemTongKetHocKy.Add(pKQHT_DiemTongKetHocKyInfo);
                            }
                            catch
                            {
                                // error
                            }
                        }
                    }
                }
                ThongBao("Cập nhật thành công!");
            }
            else
                ThongBao("Bạn cần thay đổi thông tin trước khi cập nhật!");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bgvDiem_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            XuatBangDiem(2);
        }

        private void btnInBangDiem_Click(object sender, EventArgs e)
        {
            if (grbSinhVien.View.DataRowCount == 0)
            {
                ThongBaoLoi("Không có dữ liệu để in");
                return;
            }
            int IDSinhVien = int.Parse(grbSinhVien.View.GetDataRow(grbSinhVien.View.FocusedRowHandle)["SV_SinhVienID"].ToString());
            DataTable dt = new DataTable();
            dt = oBKQHT_DiemTongKetHocKy.GetDiemTongKet(IDSinhVien, Program.IDNamHoc,0);
            frmReport frm = new frmReport(dt, "rDiemMonTheoNam");
            frm.ShowDialog();
        }

        #region Xuat bang diem
        private void XuatBangDiem(int SoLanThi)
        {
            if (dtSinhVien.Rows.Count == 0)
            {
                ThongBao("Không có dữ liệu để xuất ra excel!");
                return;
            }
            string strFileExcel = Application.StartupPath + "\\Template\\Temp_TongKetDiemNamHoc_SS.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + "!\nĐề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                return;
            }
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Excel file (*.xls)|*.xls";
            sv.Title = "Xuất dữ liệu";
            sv.FileName = "KQHT_" + pDM_LopInfo.TenLop.Replace("Lớp: ", "") + "_" + Program.NamHoc + ".xls";
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
                XuatBangDiemRaExcel(dtSinhVien, strTenFileExcelMoi, SoLanThi);
                ThongBao("Xuất dữ liệu thành công!");
            }
        }

        private void XuatBangDiemRaExcel(DataTable dtChiTiet, string FileExcel, int SoLanThi)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int DongBatDau = 12, CotBatDau = _ColStart, SoCot = 0;
            Excel.Range cel;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);

                cel = (Excel.Range)excel.Cells[5, 1];
                excel.Cells[5, 1] = cel.Text + " LỚP " + pDM_LopInfo.TenLop.Replace("Lớp: ", "").ToUpper();

                excel.Cells[6, 1] = "NĂM HỌC: " + Program.NamHoc;

                // Them các tiêu đề cột môn học phía sau
                if (grbMonHoc.Children.Count > 0)
                {
                    int CotDau = CotBatDau, CotDauKy = CotBatDau;
                    foreach (GridBand grbHocKy in grbMonHoc.Children)
                    {
                        foreach (GridBand grbTenMon in grbHocKy.Children)
                        {
                            for (int i = 1; i <= grbTenMon.Children[0].Columns.Count; i++)
                            {
                                cel = (Excel.Range)(excel.Cells[DongBatDau - 1, CotBatDau]);
                                cel.EntireColumn.Insert(Excel.XlDirection.xlToRight, null);
                                SoCot++;

                                // Lần thi [DongBatDau - 1]
                                excel.Cells[DongBatDau - 1, CotBatDau] = "L" + i.ToString();
                                cel = (Excel.Range)(excel.Cells[DongBatDau - 1, CotBatDau]);
                                cel.ColumnWidth = 3;

                                CotBatDau++;
                            }
                            // Số học trình [DongBatDau - 2]
                            excel.Cells[DongBatDau - 2, CotDau] = grbTenMon.Children[0].Caption;
                            cel = excel.get_Range(excel.Cells[DongBatDau - 2, CotDau], excel.Cells[DongBatDau - 2, CotBatDau - 1]);
                            cel.Merge(null);
                            cel.Borders.Value = 1;

                            // Tên môn học [DongBatDau - 3]
                            excel.Cells[DongBatDau - 3, CotDau] = grbTenMon.Caption;
                            cel = excel.get_Range(excel.Cells[DongBatDau - 3, CotDau], excel.Cells[DongBatDau - 3, CotBatDau - 1]);
                            cel.Font.Size = 10;
                            cel.Font.Bold = false;
                            cel.WrapText = true;
                            cel.Merge(null);
                            cel.Borders.Value = 1;

                            CotDau = CotBatDau;
                        }
                        // Tên học kỳ [DongBatDau - 4]
                        excel.Cells[DongBatDau - 4, CotDauKy] = grbHocKy.Caption;
                        cel = excel.get_Range(excel.Cells[DongBatDau - 4, CotDauKy], excel.Cells[DongBatDau - 4, CotBatDau - 1]);
                        cel.Font.Size = 10;
                        cel.Font.Bold = false;
                        cel.WrapText = true;
                        cel.Merge(null);
                        cel.Borders.Value = 1;

                        CotDauKy = CotBatDau;
                    }
                    // ĐIỂM [DongBatDau - 5]
                    excel.Cells[DongBatDau - 5, _ColStart] = "ĐIỂM MÔN HỌC";
                    cel = excel.get_Range(excel.Cells[DongBatDau - 5, _ColStart], excel.Cells[DongBatDau - 5, _ColStart + SoCot - 1]);
                    cel.Merge(null);
                    cel.Borders.Value = 1;

                    int colPhongDaoTao = SoCot / 2 - 5;
                    excel.Cells[DongBatDau + 5, _ColStart + colPhongDaoTao] = "TP đào tạo";
                }

                DataRow dr;
                int SoSinhVien = bgvDiem.DataRowCount;
                for (int j = 0; j < SoSinhVien; j++)
                {
                    dr = bgvDiem.GetDataRow(j);
                    cel = (Excel.Range)(excel.Cells[j + DongBatDau + 1, 1]);
                    cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);

                    excel.Cells[j + DongBatDau, 1] = j + 1;
                    excel.Cells[j + DongBatDau, 2] = dr["MaSinhVien"];
                    excel.Cells[j + DongBatDau, 3] = dr["HoVa"];
                    excel.Cells[j + DongBatDau, 4] = dr["Ten"];
                    excel.Cells[j + DongBatDau, 5] = "'" + dr["NgaySinh"];

                    for (int i = dtColStart; i < dtColEnd; i++)
                    {
                        if ("" + dr[i] != "")
                        {
                            cel = (Excel.Range)excel.Cells[j + DongBatDau, _ColStart + i - dtColStart];
                            excel.Cells[j + DongBatDau, _ColStart + i - dtColStart] = dr[i];
                            cel.NumberFormat = "0.0";
                        }
                    }
                    if ("" + dr["DiemTK1"] != "")
                    {
                        cel = (Excel.Range)excel.Cells[j + DongBatDau, _ColStart + SoCot];
                        excel.Cells[j + DongBatDau, _ColStart + SoCot] = dr["DiemTK1"];
                        cel.NumberFormat = "0.0";
                    }
                    if ("" + dr["DiemTK2"] != "")
                    {
                        cel = (Excel.Range)excel.Cells[j + DongBatDau, _ColStart + SoCot + 1];
                        excel.Cells[j + DongBatDau, _ColStart + SoCot + 1] = dr["DiemTK2"];
                        cel.NumberFormat = "0.0";
                    }
                }
                // Đưa dữ liệu phần tỷ lệ kết quả học tập
                // Tỷ lệ giỏi
                string Condition = "";
                int SoLuong = 0;
                DataRow[] arrDr = dtXepLoai.Select("MaXepLoai = 'XS' Or MaXepLoai = 'G'");
                if (arrDr.Length > 0)
                {
                    Condition = "";
                    foreach (DataRow drXL in arrDr)
                    {
                        Condition += (Condition == "" ? "" : " OR ") + "KQHT_XepLoaiTotNghiepID1 = " + drXL["KQHT_XepLoaiTotNghiepID"];
                    }

                    SoLuong = int.Parse(dtSinhVien.Compute("Count(SV_SinhVienID)", Condition).ToString());
                    cel = (Excel.Range)excel.Cells[DongBatDau + SoSinhVien + 2, 2];
                    excel.Cells[DongBatDau + SoSinhVien + 2, 2] = cel.Text + TinhPhanTram(SoLuong, SoSinhVien);
                }
                // Tỷ lệ khá
                arrDr = dtXepLoai.Select("MaXepLoai = 'K'");
                if (arrDr.Length > 0)
                {
                    Condition = "";
                    foreach (DataRow drXL in arrDr)
                    {
                        Condition += (Condition == "" ? "" : " OR ") + "KQHT_XepLoaiTotNghiepID1 = " + drXL["KQHT_XepLoaiTotNghiepID"];
                    }

                    SoLuong = int.Parse(dtSinhVien.Compute("Count(SV_SinhVienID)", Condition).ToString());
                    cel = (Excel.Range)excel.Cells[DongBatDau + SoSinhVien + 3, 2];
                    excel.Cells[DongBatDau + SoSinhVien + 3, 2] = cel.Text + TinhPhanTram(SoLuong, SoSinhVien);
                }
                // Tỷ lệ trung bình
                arrDr = dtXepLoai.Select("MaXepLoai = 'TBK' OR MaXepLoai = 'TB'");
                if (arrDr.Length > 0)
                {
                    Condition = "";
                    foreach (DataRow drXL in arrDr)
                    {
                        Condition += (Condition == "" ? "" : " OR ") + "KQHT_XepLoaiTotNghiepID1 = " + drXL["KQHT_XepLoaiTotNghiepID"];
                    }

                    SoLuong = int.Parse(dtSinhVien.Compute("Count(SV_SinhVienID)", Condition).ToString());
                    cel = (Excel.Range)excel.Cells[DongBatDau + SoSinhVien + 4, 2];
                    excel.Cells[DongBatDau + SoSinhVien + 4, 2] = cel.Text + TinhPhanTram(SoLuong, SoSinhVien);
                }
                // Tỷ lệ yếu
                arrDr = dtXepLoai.Select("MaXepLoai = 'Y'");
                if (arrDr.Length > 0)
                {
                    Condition = "";
                    foreach (DataRow drXL in arrDr)
                    {
                        Condition += (Condition == "" ? "" : " OR ") + "KQHT_XepLoaiTotNghiepID1 = " + drXL["KQHT_XepLoaiTotNghiepID"];
                    }

                    SoLuong = int.Parse(dtSinhVien.Compute("Count(SV_SinhVienID)", Condition).ToString());
                    cel = (Excel.Range)excel.Cells[DongBatDau + SoSinhVien + 2, 4];
                    excel.Cells[DongBatDau + SoSinhVien + 2, 4] = cel.Text + TinhPhanTram(SoLuong, SoSinhVien);
                }
                // Tỷ lệ kém
                arrDr = dtXepLoai.Select("MaXepLoai = 'K-'");
                if (arrDr.Length > 0)
                {
                    Condition = "";
                    foreach (DataRow drXL in arrDr)
                    {
                        Condition += (Condition == "" ? "" : " OR ") + "KQHT_XepLoaiTotNghiepID1 = " + drXL["KQHT_XepLoaiTotNghiepID"];
                    }
                    Condition += " OR KQHT_XepLoaiTotNghiepID1 = 0";

                    SoLuong = int.Parse(dtSinhVien.Compute("Count(SV_SinhVienID)", Condition).ToString());
                    cel = (Excel.Range)excel.Cells[DongBatDau + SoSinhVien + 3, 4];
                    excel.Cells[DongBatDau + SoSinhVien + 3, 4] = cel.Text + TinhPhanTram(SoLuong, SoSinhVien);
                }

                // Set style
                cel = excel.get_Range(excel.Cells[DongBatDau, 1],
                    excel.Cells[DongBatDau + SoSinhVien - 1, _ColStart + SoCot + 2 - 1]);
                cel.Borders.LineStyle = Excel.XlLineStyle.xlDot;
                cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;

                cel = excel.get_Range(excel.Cells[DongBatDau, 1], excel.Cells[DongBatDau + SoSinhVien - 1, 1]);
                cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                for (int i = 1; i <= _ColStart - 1; i++)
                {
                    cel = excel.get_Range(excel.Cells[DongBatDau, i], excel.Cells[DongBatDau + SoSinhVien - 1, i]);
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    if (i != 3)
                        cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    else
                        cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                }
                for (int i = _ColStart; i <= _ColStart + SoCot + 2 - 1; i++)
                {
                    cel = excel.get_Range(excel.Cells[DongBatDau, i], excel.Cells[DongBatDau + SoSinhVien - 1, i]);
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }
                cel = excel.get_Range(excel.Cells[DongBatDau + SoSinhVien - 1, 1],
                    excel.Cells[DongBatDau + SoSinhVien - 1, _ColStart + SoCot + 2 - 1]);
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

        private string TinhPhanTram(int SoLuong, int SoSinhVien)
        {
            return Math.Round(((double)SoLuong / (double)SoSinhVien * 100), 0, MidpointRounding.AwayFromZero) +
                "% (" + SoLuong.ToString() + " SV)";
        }
        #endregion
    }
}