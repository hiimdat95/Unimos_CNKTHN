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
using DevExpress.Utils;
using System.IO;
using System.Diagnostics;

namespace UnimOs.UI
{
    public partial class frmTongHopDiemThiTotNghiep_QCNghe : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private cBSV_SinhVien oBSV_SinhVien;
        private KQHT_XepLoaiTotNghiepInfo pKQHT_XepLoaiTotNghiepInfo;
        private cBKQHT_XepLoaiTotNghiep oBKQHT_XepLoaiTotNghiep;
        private cBKQHT_DiemTongKetToanKhoa oBKQHT_DiemTongKetToanKhoa;
        private KQHT_DiemTongKetToanKhoaInfo pKQHT_DiemTongKetToanKhoaInfo;
        private cBKQHT_MonThiTotNghiep_Lop oBKQHT_MonThiTotNghiep_Lop;
        private cBXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private cBKQHT_DiemTongKetMon oBKQHT_DiemTongKetMon;
        private DataTable dtKhoaHoc, dtSinhVien, dtTrinhDo, dtXepLoai, dtLop, dtDiemTotNghiep, dtDiem;
        private int NamHocBatDau = 0, NamHocKetThuc = 0;
        private string strCongThucDiem = "";
        private MathParser parser = new MathParser();
        private string IDMonChinhTri, IDMonLyThuyet, IDMonThucHanh;

        public frmTongHopDiemThiTotNghiep_QCNghe()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            pDM_LopInfo = new DM_LopInfo();
            oBSV_SinhVien = new cBSV_SinhVien();
            pKQHT_XepLoaiTotNghiepInfo = new KQHT_XepLoaiTotNghiepInfo();
            oBKQHT_XepLoaiTotNghiep = new cBKQHT_XepLoaiTotNghiep();
            oBKQHT_DiemTongKetToanKhoa = new cBKQHT_DiemTongKetToanKhoa();
            pKQHT_DiemTongKetToanKhoaInfo = new KQHT_DiemTongKetToanKhoaInfo();
            oBKQHT_MonThiTotNghiep_Lop = new cBKQHT_MonThiTotNghiep_Lop();
            oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
            oBKQHT_DiemTongKetMon = new cBKQHT_DiemTongKetMon();
        }

        private void frmTongHopDiemThiTotNghiep_Load(object sender, EventArgs e)
        {
            LoadCombo();
            dtXepLoai = oBKQHT_XepLoaiTotNghiep.Get(pKQHT_XepLoaiTotNghiepInfo);
            repositoryXepLoai.DataSource = dtXepLoai;
        }

        private void LoadCombo()
        {
            cmbHe.Properties.DataSource = LoadHe();
            dtTrinhDo = LoadTrinhDo();
            cmbTrinhDo.Properties.DataSource = dtTrinhDo;
            cmbKhoa.Properties.DataSource = LoadKhoa();
            dtKhoaHoc = LoadKhoaHoc();
            cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;
            DataTable dtCongThuc = LoadCongThucDiemToanKhoa();
            cmbCongThuc.Properties.DataSource = dtCongThuc;
            rdTongHop_SelectedIndexChanged(null, null);
            if (dtCongThuc.Rows.Count > 0)
                cmbCongThuc.ItemIndex = 0;
        }

        private void LoadDanhSachLop()
        {
            pDM_LopInfo.IDDM_Khoa = cmbKhoa.EditValue == null ? 0 : int.Parse(cmbKhoa.EditValue.ToString());
            pDM_LopInfo.IDDM_He = cmbHe.EditValue == null ? 0 : int.Parse(cmbHe.EditValue.ToString());
            pDM_LopInfo.IDDM_TrinhDo = cmbTrinhDo.EditValue == null ? 0 : int.Parse(cmbTrinhDo.EditValue.ToString());
            pDM_LopInfo.IDDM_Nganh = cmbNganh.EditValue == null ? 0 : int.Parse(cmbNganh.EditValue.ToString());
            pDM_LopInfo.IDDM_KhoaHoc = cmbKhoaHoc.EditValue == null ? 0 : int.Parse(cmbKhoaHoc.EditValue.ToString());
            dtLop = oBDM_Lop.GetDanhSachLop(pDM_LopInfo, Program.NamHoc);
            cmbLop.Properties.DataSource = dtLop;
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SV_SinhVienID", typeof(int));
            dt.Columns.Add("IDDM_Lop", typeof(int));
            dt.Columns.Add("MaSinhVien", typeof(string));
            dt.Columns.Add("HoVa", typeof(string));
            dt.Columns.Add("TenSV", typeof(string));
            dt.Columns.Add("NgaySinh", typeof(DateTime));
            dt.Columns.Add("NoiSinh", typeof(string));
            dt.Columns.Add("TenLop", typeof(string));
            dt.Columns.Add("DiemTK", typeof(double));
            dt.Columns.Add("DiemTBMH", typeof(double));
            dt.Columns.Add("DiemTHXL", typeof(double));
            dt.Columns.Add("DiemTTTN", typeof(double));
            dt.Columns.Add("KQHT_XepLoaiTotNghiepID", typeof(int));
            dt.Columns.Add("GhiChu", typeof(string));
            dt.Columns.Add("SoMonThiLai", typeof(int));
            dt.Columns.Add("SoHocTrinhThiLai", typeof(double));
            dt.Columns.Add("MonThiLai", typeof(string));

            dt.Columns.Add("SoMonNo", typeof(int));
            dt.Columns.Add("SoHocTrinhNo", typeof(double));
            dt.Columns.Add("MonHocNo", typeof(string));

            dt.Columns.Add("SoMonChuaCoDiem", typeof(int));
            return dt;
        }

        private void AddBand()
        {
            BandedGridColumn bgc; GridBand grb, grbHK;
            DataTable dtTemp = LoadNamHoc();
            int IDNamHoc = 0, BandWidth = 0, SoNam = NamHocKetThuc - NamHocBatDau;
            //ClearGridBandColumn(bgvDiem, grbMonHoc);
            //grbMonHoc.Children.Clear();
            //// add band Năm Học
            //for (int j = 0; j < SoNam; j++)
            //{
            //    BandWidth = 0;
            //    grb = new GridBand();
            //    SetBandCaption(grb, "Năm học thứ " + (j + 1).ToString(), 50);
            //    grbMonHoc.Children.AddRange(new GridBand[] { grb });
            //    DataRow[] adr = dtTemp.Select("TenNamHoc = '" + ((NamHocBatDau + j) + "-" + (NamHocBatDau + j + 1)) + "'");
            //    if (adr.Length > 0)
            //    {
            //        IDNamHoc = int.Parse(adr[0]["DM_NamHocID"].ToString());
            //        // add band Học Kỳ
            //        for (int i = 1; i <= 2; i++)
            //        {
            //            grbHK = new GridBand();
            //            SetBandCaption(grbHK, "Học kỳ " + i.ToString(), 50);
            //            grb.Children.AddRange(new GridBand[] { grbHK });
            //            // add band Môn Học
            //            dtMonHoc = oBXL_MonHocTrongKy.GetMonKy(pDM_LopInfo.DM_LopID, IDNamHoc, i);
            //            foreach (DataRow dr in dtMonHoc.Rows)
            //            {
            //                bgc = new BandedGridColumn();
            //                grbHK.Columns.Add(bgc);
            //                bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //                bgc.DisplayFormat.FormatString = "n1";
            //                SetColumnBandCaption(bgc, dr["TenMonHoc"].ToString(), "C" + "_" + dr["XL_MonHocTrongKyID"].ToString(), 110, DevExpress.Utils.HorzAlignment.Center, false);
            //                bgvDiem.Columns.AddRange(new BandedGridColumn[] { bgc });
            //                BandWidth += 100;
            //                dtSinhVien.Columns.Add("C" + "_" + dr["XL_MonHocTrongKyID"].ToString(), typeof(double));
            //            }
            //            if (grbHK.Columns.Count == 0)
            //                grbHK.Visible = false;
            //            else
            //                grbHK.Visible = true;
            //        }
            //    }
            //}

            // add band Môn thi tốt nghiệp
            if (dtLop != null && dtLop.Rows.Count > 0)
            {
                grbTotNghiep.Columns.Clear();
                DataTable dtTotNghiep = oBKQHT_MonThiTotNghiep_Lop.GetIn_Mon(int.Parse(dtLop.Rows[0]["DM_LopID"].ToString()));
                if (dtTotNghiep.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtTotNghiep.Rows)
                    {
                        bgc = new BandedGridColumn();
                        grbTotNghiep.Columns.Add(bgc);
                        bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        bgc.DisplayFormat.FormatString = "n1";
                        SetColumnBandCaption(bgc, dr["TenMonHoc"].ToString(), "TN" + "_" + dr["DM_MonHocID"].ToString(), 110, DevExpress.Utils.HorzAlignment.Center, false);
                        bgvDiem.Columns.AddRange(new BandedGridColumn[] { bgc });
                        BandWidth += 100;
                        dtSinhVien.Columns.Add("TN" + "_" + dr["DM_MonHocID"].ToString(), typeof(double));
                        if (dr["MaMonHoc"].ToString() == "TTN_CT")
                            IDMonChinhTri = dr["DM_MonHocID"].ToString();
                        else if (dr["MaMonHoc"].ToString() == "TTN_LTCM")
                            IDMonLyThuyet = dr["DM_MonHocID"].ToString();
                        else if (dr["MaMonHoc"].ToString() == "TTN_THNN")
                            IDMonThucHanh = dr["DM_MonHocID"].ToString();
                    }
                    grbTotNghiep.Visible = true;
                }
                else
                {
                    IDMonChinhTri = "";
                    IDMonLyThuyet = "";
                    IDMonThucHanh = "";
                    grbTotNghiep.Visible = false;
                }
            }
        }

        private void XuLyTable()
        {
            // add diem cua mon hoc trong ky
            dtDiem = oBKQHT_DiemTongKetToanKhoa.GetTongHop(pDM_LopInfo, Program.IDNamHoc, int.Parse(cmbLanThi.EditValue.ToString()));
            DataTable dtThucTapTotNghiep = oBKQHT_DiemTongKetMon.GetDiemThucTapTotNghiep(pDM_LopInfo);
            DataRow drNew;
            try
            {
                if (dtDiem.Rows.Count > 0)
                {
                    int SoMonThiLai = 0, SoMonNo = 0, SoMonCoDiem = 0, SoMonDaCoDiem = 0;
                    double SoHocTrinhThiLai = 0, SoHocTrinhNo = 0, TongSoHocTrinh = 0;
                    object DiemTTTN;
                    string SV_SinhVienID = dtDiem.Rows[0]["SV_SinhVienID"].ToString(), MonThiLai = "", MonHocNo = "", HoDem = "";
                    string IDDM_Lop = dtDiem.Rows[0]["IDDM_Lop"].ToString();

                    drNew = dtSinhVien.NewRow();
                    drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                    drNew["MaSinhVien"] = dtDiem.Rows[0]["MaSinhVien"].ToString();
                    drNew["TenSV"] = GetTen(dtDiem.Rows[0]["HoVaTen"].ToString(), ref HoDem);
                    drNew["HoVa"] = HoDem;
                    drNew["NgaySinh"] = dtDiem.Rows[0]["NgaySinh"];
                    drNew["NoiSinh"] = "" + dtDiem.Rows[0]["NoiSinh"];
                    drNew["TenLop"] = dtDiem.Rows[0]["TenLop"].ToString();
                    drNew["DiemTK"] = dtDiem.Rows[0]["DiemTongKet"];
                    drNew["DiemTBMH"] = dtDiem.Rows[0]["DiemTBMH"];
                    drNew["DiemTHXL"] = dtDiem.Rows[0]["DiemTHXL"];
                    drNew["IDDM_Lop"] = dtDiem.Rows[0]["IDDM_Lop"];
                    drNew["KQHT_XepLoaiTotNghiepID"] = dtDiem.Rows[0]["IDDM_XepLoai"];
                    drNew["GhiChu"] = dtDiem.Rows[0]["GhiChu"];

                    DiemTTTN = dtThucTapTotNghiep.Compute("Sum(Diem)", "IDSV_SinhVien = " + SV_SinhVienID.ToString());
                    if ("" + DiemTTTN != "")
                        drNew["DiemTTTN"] = Math.Round(double.Parse(DiemTTTN.ToString()), 1, MidpointRounding.AwayFromZero);

                    SoMonCoDiem = oBKQHT_DiemTongKetMon.GetSoMonCoDiemByLop(int.Parse(IDDM_Lop), 0, 0, ref TongSoHocTrinh);

                    foreach (DataRow dr in dtDiem.Rows)
                    {
                        if (dr["SV_SinhVienID"].ToString() != SV_SinhVienID)
                        {
                            if (SoMonThiLai > 0)
                            {
                                drNew["SoMonThiLai"] = SoMonThiLai;
                                drNew["SoHocTrinhThiLai"] = SoHocTrinhThiLai;
                                drNew["MonThiLai"] = MonThiLai;
                            }
                            if (SoMonNo > 0)
                            {
                                drNew["SoMonNo"] = SoMonNo;
                                drNew["SoHocTrinhNo"] = SoHocTrinhNo;
                                drNew["MonHocNo"] = MonHocNo;
                            }
                            if (SoMonDaCoDiem < SoMonCoDiem)
                                drNew["SoMonChuaCoDiem"] = SoMonCoDiem - SoMonDaCoDiem;

                            dtSinhVien.Rows.Add(drNew);
                            if (IDDM_Lop != dr["IDDM_Lop"].ToString())
                            {
                                IDDM_Lop = dr["IDDM_Lop"].ToString();
                                SoMonCoDiem = oBKQHT_DiemTongKetMon.GetSoMonCoDiemByLop(int.Parse(IDDM_Lop), 0, 0, ref TongSoHocTrinh);
                            }
                            // Gán lại giá trị
                            SoMonThiLai = 0;
                            SoHocTrinhThiLai = 0;
                            MonThiLai = "";

                            SoMonDaCoDiem = 0;
                            SoMonNo = 0;
                            SoHocTrinhNo = 0;
                            MonHocNo = "";

                            SV_SinhVienID = dr["SV_SinhVienID"].ToString();

                            drNew = dtSinhVien.NewRow();

                            drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                            drNew["MaSinhVien"] = dr["MaSinhVien"].ToString();
                            drNew["TenSV"] = GetTen(dr["HoVaTen"].ToString(), ref HoDem);
                            drNew["HoVa"] = HoDem;
                            drNew["NgaySinh"] = dr["NgaySinh"];
                            drNew["NoiSinh"] = "" + dr["NoiSinh"];
                            drNew["TenLop"] = dr["TenLop"].ToString();
                            drNew["DiemTK"] = dr["DiemTongKet"];
                            drNew["DiemTBMH"] = dr["DiemTBMH"];
                            drNew["DiemTHXL"] = dr["DiemTHXL"];
                            drNew["IDDM_Lop"] = dr["IDDM_Lop"];
                            drNew["KQHT_XepLoaiTotNghiepID"] = dr["IDDM_XepLoai"];
                            drNew["GhiChu"] = dr["GhiChu"];

                            DiemTTTN = dtThucTapTotNghiep.Compute("Sum(Diem)", "IDSV_SinhVien = " + SV_SinhVienID.ToString());
                            if ("" + DiemTTTN != "")
                                drNew["DiemTTTN"] = Math.Round(double.Parse(DiemTTTN.ToString()), 1, MidpointRounding.AwayFromZero);

                            if ("" + dr["Diem"] != "")
                            {
                                try
                                {
                                    if (dr["LanThi"].ToString() == "2")
                                    {
                                        SoMonThiLai++;
                                        SoHocTrinhThiLai += double.Parse(dr["SoHocTrinh"].ToString());
                                        MonThiLai += (MonThiLai == "" ? "" : ", ") + dr["TenMonHoc"];
                                    }
                                    //drNew["C" + "_" + dr["IDXL_MonHocTrongKy"].ToString()] = double.Parse(dr["Diem"].ToString());
                                    
                                    SoMonDaCoDiem++;
                                    if (double.Parse(dr["Diem"].ToString()) < 5.0)
                                    {
                                        SoMonNo++;
                                        SoHocTrinhNo += double.Parse(dr["SoHocTrinh"].ToString());
                                        MonHocNo += (MonHocNo == "" ? "" : ", ") + dr["TenMonHoc"];
                                    }
                                }
                                catch { }
                            }
                        }
                        else
                        {
                            if ("" + dr["Diem"] != "")
                            {
                                try
                                {
                                    if (dr["LanThi"].ToString() == "2")
                                    {
                                        SoMonThiLai++;
                                        SoHocTrinhThiLai += double.Parse(dr["SoHocTrinh"].ToString());
                                        MonThiLai += (MonThiLai == "" ? "" : ", ") + dr["TenMonHoc"];
                                    }
                                    //drNew["C" + "_" + dr["IDXL_MonHocTrongKy"].ToString()] = double.Parse(dr["Diem"].ToString());

                                    SoMonDaCoDiem++;
                                    if (double.Parse(dr["Diem"].ToString()) < 5.0)
                                    {
                                        SoMonNo++;
                                        SoHocTrinhNo += double.Parse(dr["SoHocTrinh"].ToString());
                                        MonHocNo += (MonHocNo == "" ? "" : ", ") + dr["TenMonHoc"];
                                    }
                                }
                                catch { }
                            }
                        }
                    }

                    if (SoMonThiLai > 0)
                    {
                        drNew["SoMonThiLai"] = SoMonThiLai;
                        drNew["SoHocTrinhThiLai"] = SoHocTrinhThiLai;
                        drNew["MonThiLai"] = MonThiLai;
                    }
                    if (SoMonNo > 0)
                    {
                        drNew["SoMonNo"] = SoMonNo;
                        drNew["SoHocTrinhNo"] = SoHocTrinhNo;
                        drNew["MonHocNo"] = MonHocNo;
                    }
                    if (SoMonDaCoDiem < SoMonCoDiem)
                        drNew["SoMonChuaCoDiem"] = SoMonCoDiem - SoMonDaCoDiem;
                    dtSinhVien.Rows.Add(drNew);
                }
            }
            catch
            { }

            // add mon thi tot nghiep
            dtDiemTotNghiep = oBKQHT_DiemTongKetToanKhoa.GetDiemTotNghieps(pDM_LopInfo, Program.IDNamHoc, int.Parse(cmbLanThi.EditValue.ToString()));
            try
            {
                if (dtDiemTotNghiep.Rows.Count > 0)
                {
                    foreach (DataRow drSinhVien in dtSinhVien.Rows)
                    {
                        DataRow[] drTemp = dtDiemTotNghiep.Select("SV_SinhVienID=" + drSinhVien["SV_SinhVienID"]);
                        foreach (DataRow dr in drTemp)
                        {
                            if ("" + dr["Diem"] != "")
                            {
                                try
                                {
                                    drSinhVien["TN_" + dr["IDDM_MonHoc"]] = double.Parse(dr["Diem"].ToString());
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
            catch
            { }
        }

        private void TongHopDiemSinhVien()
        {
            if (cmbKhoaHoc.ItemIndex < 0)
            {
                ThongBao("Bạn phải chọn khóa học !");
                return;
            }

            NamHocKetThuc = int.Parse(cmbKhoaHoc.GetColumnValue("NamRaTruong").ToString());
            NamHocBatDau = int.Parse(cmbKhoaHoc.GetColumnValue("NamVaoTruong").ToString());
            dtSinhVien = CreateTable();
            AddBand();
            XuLyTable();
            TongHopDiem();
            grdDiem.DataSource = dtSinhVien;
        }

        private void LocDiemSinhVien()
        {
            if (cmbKhoaHoc.ItemIndex < 0)
            {
                ThongBao("Bạn phải chọn khóa học !");
                return;
            }

            NamHocKetThuc = int.Parse(cmbKhoaHoc.GetColumnValue("NamRaTruong").ToString());
            NamHocBatDau = int.Parse(cmbKhoaHoc.GetColumnValue("NamVaoTruong").ToString());
            dtSinhVien = CreateTable();
            AddBand();
            XuLyTable();
            grdDiem.DataSource = dtSinhVien;
        }

        private double TestCongThuc(double DiemTBMH, DataRow[] drDiem)
        {
            double Value = 0; int SoSauDauPhay;
            try
            {
                // add thanh phan diem TBTK
                parser.CreateVar("TBTK", DiemTBMH, null);
                foreach (DataRow dr in drDiem)
                {
                    parser.CreateVar(dr["MaMonHoc"].ToString(), double.Parse("0" + dr["Diem"].ToString()), null);
                }
                string formula = null;
                formula = strCongThucDiem;
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

        private void TongHopDiem()
        {
            grbDiemTK.Visible = true;
            MathParser parser = new MathParser();
            double SoMonCoDiem = 0;
            double TongHeSoTemp = 0, TongHeSoTN = 0, TongSoDiem = 0, DiemTHXL = 0;
            int IDDM_LopTemp = 0;
            if (dtSinhVien.Rows.Count > 0)
            {
                IDDM_LopTemp = int.Parse(dtSinhVien.Rows[0]["IDDM_Lop"].ToString());
                //DataTable dtTemp = oBXL_MonHocTrongKy.GetToanKhoa(IDDM_LopTemp, 0, 0);
                DataTable dtMonTotNghiep = oBKQHT_MonThiTotNghiep_Lop.GetIn_Mon(IDDM_LopTemp);

                SoMonCoDiem = oBKQHT_DiemTongKetMon.GetSoMonCoDiemByLop(IDDM_LopTemp, 0, 0, ref TongHeSoTemp);
                for (int i = 0; i < dtSinhVien.Rows.Count; i++)
                {
                    TongSoDiem = 0;
                    if (IDDM_LopTemp != int.Parse(dtSinhVien.Rows[i]["IDDM_Lop"].ToString()))
                    {
                        IDDM_LopTemp = int.Parse(dtSinhVien.Rows[i]["IDDM_Lop"].ToString());
                        //dtTemp = oBXL_MonHocTrongKy.GetToanKhoa(IDDM_LopTemp, 0, 0);
                        dtMonTotNghiep = oBKQHT_MonThiTotNghiep_Lop.GetIn_Mon(IDDM_LopTemp);
                        SoMonCoDiem = oBKQHT_DiemTongKetMon.GetSoMonCoDiemByLop(IDDM_LopTemp, 0, 0, ref TongHeSoTemp);
                    }
                    //// môn học trong kỳ
                    //for (int j = 0; j < dtSinhVien.Columns.Count; j++)
                    //{
                    //    if (dtSinhVien.Columns[j].ColumnName.IndexOf("C_") >= 0 && "" + dtSinhVien.Rows[i][dtSinhVien.Columns[j].ColumnName] != "")
                    //    {
                    //        DataRow[] dr = dtTemp.Select("XL_MonHocTrongKyID = " + dtSinhVien.Columns[j].ColumnName.Substring(2));
                    //        if (dr.Length > 0)
                    //        {
                    //            TongSoDiem += double.Parse("0" + dtSinhVien.Rows[i][dtSinhVien.Columns[j].ColumnName].ToString()) * double.Parse("0" + dr[0]["SoHocTrinh"].ToString());
                    //        }
                    //    }
                    //}
                    TongSoDiem = double.Parse("0" + dtDiem.Compute("Sum(TongDiemMon)", "TinhDiemToanKhoa = 1 And SV_SinhVienID = " + dtSinhVien.Rows[i]["SV_SinhVienID"]).ToString());

                    if (TongHeSoTemp != 0)
                        dtSinhVien.Rows[i]["DiemTBMH"] = parser.Round(TongSoDiem / TongHeSoTemp, 1, true);
                    else
                        dtSinhVien.Rows[i]["DiemTBMH"] = 0;

                    // môn thi tốt nghiệp
                    if (dtMonTotNghiep != null)
                    {
                        if (rdTongHop.SelectedIndex == 0)
                        {
                            TongHeSoTN = TongHeSoTemp;
                            // tinh diem theo don vi hoc trinh
                            for (int n = 0; n < dtMonTotNghiep.Rows.Count; n++)
                            {
                                try
                                {
                                    if ("" + dtSinhVien.Rows[i]["TN_" + dtMonTotNghiep.Rows[n]["DM_MonHocID"].ToString()] != "" && bool.Parse(dtMonTotNghiep.Rows[n]["TinhDiem"].ToString()) == true)
                                    {
                                        TongHeSoTN += double.Parse("0" + dtMonTotNghiep.Rows[n]["SoHocTrinh"].ToString());
                                        TongSoDiem += double.Parse("0" + dtSinhVien.Rows[i]["TN_" + dtMonTotNghiep.Rows[n]["DM_MonHocID"].ToString()].ToString()) * double.Parse("0" + dtMonTotNghiep.Rows[n]["SoHocTrinh"].ToString());
                                    }
                                }
                                catch { }
                            }
                            if (TongHeSoTN > 0)
                                dtSinhVien.Rows[i]["DiemTK"] = parser.Round(TongSoDiem / TongHeSoTN, 1, true);
                        }
                        else
                        {
                            // tinh diem theo cong thuc diem
                            if (dtDiemTotNghiep != null)
                            {
                                DataRow[] drTemp = dtDiemTotNghiep.Select("SV_SinhVienID = " + dtSinhVien.Rows[i]["SV_SinhVienID"]);
                                dtSinhVien.Rows[i]["DiemTK"] = TestCongThuc(double.Parse(dtSinhVien.Rows[i]["DiemTBMH"].ToString()), drTemp);
                            }
                        }
                    }
                    else
                        dtSinhVien.Rows[i]["DiemTK"] = dtSinhVien.Rows[i]["DiemTBMH"];

                    //// Điểm xếp loại
                    // Tính điểm theo công thức
                    dtSinhVien.Rows[i]["DiemTHXL"] = dtSinhVien.Rows[i]["DiemTK"];
                    // xep loai
                    if ("" + dtSinhVien.Rows[i]["DiemTHXL"] != "")
                    {
                        DiemTHXL = double.Parse(dtSinhVien.Rows[i]["DiemTHXL"].ToString());
                        int SoMonTNDuoi5 = (int)dtDiemTotNghiep.Compute("Count(SV_SinhVienID)", "SV_SinhVienID = " + dtSinhVien.Rows[i]["SV_SinhVienID"] + " and Diem < 5");
                        int SoMonTNCoDiem = (int)dtDiemTotNghiep.Compute("count(Diem)", "SV_SinhVienID = " + dtSinhVien.Rows[i]["SV_SinhVienID"]);

                        if (SoMonTNDuoi5 > 0 || SoMonTNCoDiem < 3)
                        {
                            dtSinhVien.Rows[i]["KQHT_XepLoaiTotNghiepID"] = 0;
                            dtSinhVien.Rows[i]["GhiChu"] = "Không đạt";
                        }
                        else
                        {
                            for (int j = 0; j < dtXepLoai.Rows.Count; j++)
                            {
                                if (DiemTHXL >= 5)
                                {
                                    if (DiemTHXL >= double.Parse(dtXepLoai.Rows[j]["TuDiem"].ToString()))
                                    {
                                        dtSinhVien.Rows[i]["KQHT_XepLoaiTotNghiepID"] = dtXepLoai.Rows[j]["KQHT_XepLoaiTotNghiepID"];
                                        dtSinhVien.Rows[i]["GhiChu"] = "";
                                        break;
                                    }
                                }
                                else
                                {
                                    dtSinhVien.Rows[i]["KQHT_XepLoaiTotNghiepID"] = 0;
                                    dtSinhVien.Rows[i]["GhiChu"] = "Không đạt";
                                    break;
                                }
                            }
                        }
                    }
                }
            }
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

        private void cmbKhoa_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.EditValue != null)
            {
                cmbNganh.Properties.DataSource = LoadNganhByIDKhoa(int.Parse("0" + cmbKhoa.EditValue));
            }
            LoadDanhSachLop();
        }

        private void cmbNganh_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbNganh.EditValue != null)
            {
                pDM_LopInfo.IDDM_Nganh = int.Parse(cmbNganh.EditValue.ToString());
            }
            LoadDanhSachLop();
        }

        private void cmbKhoaHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbKhoaHoc.EditValue != null)
            {
                try
                {
                    pDM_LopInfo.IDDM_TrinhDo = int.Parse("0" + cmbKhoaHoc.GetColumnValue("IDDM_TrinhDo"));
                }
                catch
                {
                    pDM_LopInfo.IDDM_TrinhDo = 0;
                    pDM_LopInfo.IDDM_KhoaHoc = 0;
                }
            }
            LoadDanhSachLop();
        }

        private void cmbLop_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbLop.EditValue != null)
            {
                pDM_LopInfo.DM_LopID = int.Parse(cmbLop.EditValue.ToString());
            }
        }

        private void rdTongHop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdTongHop.SelectedIndex == 0)
            {
                cmbCongThuc.Enabled = false;
                lblCongThucDiem.Text = "";
            }
            else
            {
                cmbCongThuc.Enabled = true;
                if (strCongThucDiem != "")
                    lblCongThucDiem.Text = "Công thức điểm: " + strCongThucDiem;
            }
        }

        private void rdLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtSinhVien == null)
                return;
            if (rdLoc.SelectedIndex == 0)
            {
                dtSinhVien.DefaultView.RowFilter = "";
                grdDiem.DataSource = dtSinhVien;
            }
            else if (rdLoc.SelectedIndex == 1)
            {
                dtSinhVien.DefaultView.RowFilter = "KQHT_XepLoaiTotNghiepID>0";
                grdDiem.DataSource = dtSinhVien.DefaultView;
            }
            else
            {
                dtSinhVien.DefaultView.RowFilter = "KQHT_XepLoaiTotNghiepID=0";
                grdDiem.DataSource = dtSinhVien.DefaultView;
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
            {
                cmbTrinhDo.EditValue = null;
                pDM_LopInfo.IDDM_He = 0;
            }
        }

        private void cmbKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbKhoa.EditValue = null;
                pDM_LopInfo.IDDM_Khoa = 0;
            }
        }

        private void cmbNganh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbNganh.EditValue = null;
                pDM_LopInfo.IDDM_Nganh = 0;
            }
        }

        private void cmbKhoaHoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbKhoaHoc.EditValue = null;
                pDM_LopInfo.IDDM_KhoaHoc = 0;
            }
        }

        private void cmbLop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbLop.EditValue = null;
                pDM_LopInfo.DM_LopID = 0;
            }
        }

        private void rdOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdOption.SelectedIndex == 0)
            {
                //grbTBMH.Visible = false;
                grbMonHoc.Visible = true;
            }
            else
            {
                //grbTBMH.Visible = true;
                grbMonHoc.Visible = false;
            }
        }

        private void cmbCongThuc_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbCongThuc.EditValue != null)
            {
                strCongThucDiem = cmbCongThuc.GetColumnValue("CongThuc").ToString();
                lblCongThucDiem.Text = "Công thức điểm: " + strCongThucDiem;
            }
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            if (pDM_LopInfo.IDDM_Khoa == 0 && pDM_LopInfo.IDDM_He == 0 && pDM_LopInfo.IDDM_TrinhDo == 0 && pDM_LopInfo.IDDM_Nganh == 0 && pDM_LopInfo.IDDM_KhoaHoc == 0 && pDM_LopInfo.DM_LopID == 0)
            {
                ThongBao("Bạn chưa chọn điều kiện tổng hợp!");
                return;
            }
            else
            {
                CreateWaitDialog("Đang tổng hợp dữ liệu", "Tổng hợp dữ liệu. Xin vui lòng chờ.");
                //   LoadDanhSachLop();
                rdLoc.SelectedIndex = 0;
                TongHopDiemSinhVien();
                CloseWaitDialog();
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (pDM_LopInfo.IDDM_Khoa == 0 && pDM_LopInfo.IDDM_He == 0 && pDM_LopInfo.IDDM_TrinhDo == 0 && pDM_LopInfo.IDDM_Nganh == 0 && pDM_LopInfo.IDDM_KhoaHoc == 0 && pDM_LopInfo.DM_LopID == 0)
            {
                ThongBao("Bạn chưa chọn điều kiện tổng hợp!");
                return;
            }
            else
            {
                CreateWaitDialog("Đang tổng hợp dữ liệu", "Tổng hợp dữ liệu. Xin vui lòng chờ.");
                rdLoc.SelectedIndex = 0;
                LocDiemSinhVien();
                CloseWaitDialog();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dtSinhVien != null)
            {
                foreach (DataRow dr in dtSinhVien.Rows)
                {
                    try
                    {
                        pKQHT_DiemTongKetToanKhoaInfo.GhiChu = dr["GhiChu"].ToString();
                        pKQHT_DiemTongKetToanKhoaInfo.DiemTBMH = double.Parse("0" + dr["DiemTBMH"].ToString());
                        pKQHT_DiemTongKetToanKhoaInfo.Diem = double.Parse("0" + dr["DiemTK"].ToString());
                        pKQHT_DiemTongKetToanKhoaInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                        pKQHT_DiemTongKetToanKhoaInfo.DiemTHXL = double.Parse("0" + dr["DiemTHXL"].ToString());
                        pKQHT_DiemTongKetToanKhoaInfo.IDDM_XepLoai = int.Parse("0" + dr["KQHT_XepLoaiTotNghiepID"].ToString());
                        pKQHT_DiemTongKetToanKhoaInfo.LanCuoi = true;
                        pKQHT_DiemTongKetToanKhoaInfo.LanThi = int.Parse(cmbLanThi.EditValue.ToString());
                        pKQHT_DiemTongKetToanKhoaInfo.IDDM_NamHoc = Program.IDNamHoc;
                        oBKQHT_DiemTongKetToanKhoa.Add(pKQHT_DiemTongKetToanKhoaInfo);
                    }
                    catch
                    {
                        // error
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
            XuatTheoTemplate();
        }

        #region Xuat theo template
        private void XuatTheoTemplate()
        {
            if (dtSinhVien.Rows.Count == 0)
            {
                ThongBao("Không có dữ liệu để xuất ra excel!");
                return;
            }
            string DuongDan = Application.StartupPath;
            string strFileExcel = DuongDan + "\\Template\\Temp_DanhSachXetDieuKienTotNghiep.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + "! Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                return;
            }
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Excel file (*.xls)|*.xls";
            sv.Title = "Xuất dữ liệu";
            sv.FileName = "Danh sach xet dieu kien tot nghiep" + (cmbKhoaHoc.ItemIndex >= 0 ? " " + cmbKhoaHoc.Text : "") + ".xls";
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

        private void XuatDuLieuRaExcel(DataTable dtSinhVien, string FileExcel)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int DongBatDau = 9, SoCot = 20;
            Excel.Range cel;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);
                if (cmbKhoaHoc.ItemIndex >= 0)
                {
                    cel = (Excel.Range)excel.Cells[4, 1];
                    excel.Cells[4, 1] = cel.Text + " KHÓA " + cmbKhoaHoc.Text.ToUpper();
                }

                DataRow dr;
                int SoSinhVien = dtSinhVien.Rows.Count, SoLop = 1, k = 0;
                string IDDM_Lop = dtSinhVien.Rows[0]["IDDM_Lop"].ToString();
                DataRow[] arrDr;
                // Insert column Lop
                cel = (Excel.Range)(excel.Cells[DongBatDau + 1, 1]);
                cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                excel.Cells[DongBatDau, 2] = "Lớp: " + dtSinhVien.Rows[0]["TenLop"];
                
                cel = excel.get_Range(excel.Cells[DongBatDau, 1], excel.Cells[DongBatDau, SoCot]);
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
                        excel.Cells[i + DongBatDau + SoLop, 2] = "Lớp: " + dtSinhVien.Rows[i]["TenLop"];
                        
                        cel = excel.get_Range(excel.Cells[i + DongBatDau + SoLop, 1], excel.Cells[i + DongBatDau + SoLop, SoCot]);
                        cel.Font.Size = 11;
                        cel.Font.Bold = true;
                        cel.Merge(null);
                        SoLop++;
                    }
                    dr = bgvDiem.GetDataRow(i);
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + SoLop + 1, 1]);
                    cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);

                    k++;
                    excel.Cells[i + DongBatDau + SoLop, 1] = k;
                    excel.Cells[i + DongBatDau + SoLop, 2] = "" + dr["MaSinhVien"];
                    excel.Cells[i + DongBatDau + SoLop, 3] = "" + dr["HoVa"];
                    excel.Cells[i + DongBatDau + SoLop, 4] = "" + dr["TenSV"];
                    excel.Cells[i + DongBatDau + SoLop, 5] = ("" + dr["NgaySinh"] == "" ? "" : 
                        DateTime.Parse(dr["NgaySinh"].ToString()).ToString("dd/MM/yyyy"));
                    excel.Cells[i + DongBatDau + SoLop, 6] = "" + dr["NoiSinh"];

                    if ("" + dr["DiemTBMH"] != "")
                    {
                        cel = (Excel.Range)excel.Cells[i + DongBatDau + SoLop, 7];
                        excel.Cells[i + DongBatDau + SoLop, 7] = double.Parse(dr["DiemTBMH"].ToString());
                        cel.NumberFormat = "0.0";
                    }
                    if ("" + dr["DiemTTTN"] != "")
                    {
                        cel = (Excel.Range)excel.Cells[i + DongBatDau + SoLop, 8];
                        excel.Cells[i + DongBatDau + SoLop, 8] = double.Parse(dr["DiemTTTN"].ToString());
                        cel.NumberFormat = "0.0";
                    }
                    if (IDMonChinhTri != "" && "" + dr["TN_" + IDMonChinhTri] != "")
                    {
                        cel = (Excel.Range)excel.Cells[i + DongBatDau + SoLop, 9];
                        excel.Cells[i + DongBatDau + SoLop, 9] = double.Parse(dr["TN_" + IDMonChinhTri].ToString());
                        cel.NumberFormat = "0.0";
                    }
                    if (IDMonLyThuyet != "" && "" + dr["TN_" + IDMonLyThuyet] != "")
                    {
                        cel = (Excel.Range)excel.Cells[i + DongBatDau + SoLop, 10];
                        excel.Cells[i + DongBatDau + SoLop, 10] = double.Parse(dr["TN_" + IDMonLyThuyet].ToString());
                        cel.NumberFormat = "0.0";
                    }
                    if (IDMonThucHanh != "" && "" + dr["TN_" + IDMonThucHanh] != "")
                    {
                        cel = (Excel.Range)excel.Cells[i + DongBatDau + SoLop, 11];
                        excel.Cells[i + DongBatDau + SoLop, 11] = double.Parse(dr["TN_" + IDMonThucHanh].ToString());
                        cel.NumberFormat = "0.0";
                    }
                    if ("" + dr["DiemTK"] != "")
                    {
                        cel = (Excel.Range)excel.Cells[i + DongBatDau + SoLop, 15];
                        excel.Cells[i + DongBatDau + SoLop, 15] = double.Parse(dr["DiemTK"].ToString());
                        cel.NumberFormat = "0.0";
                    }
                    if ("" + dr["DiemTHXL"] != "")
                    {
                        cel = (Excel.Range)excel.Cells[i + DongBatDau + SoLop, 16];
                        excel.Cells[i + DongBatDau + SoLop, 16] = double.Parse(dr["DiemTHXL"].ToString());
                        cel.NumberFormat = "0.0";
                    }
                    if ("" + dr["KQHT_XepLoaiTotNghiepID"] != "")
                    {
                        arrDr = dtXepLoai.Select("KQHT_XepLoaiTotNghiepID = " + dr["KQHT_XepLoaiTotNghiepID"]);
                        if (arrDr.Length > 0)
                        {
                            cel = (Excel.Range)excel.Cells[i + DongBatDau + SoLop, 17];
                            excel.Cells[i + DongBatDau + SoLop, 17] = arrDr[0]["TenXepLoai"].ToString();
                        }
                    }
                    if ("" + dr["SoMonThiLai"] != "")
                    {
                        cel = (Excel.Range)excel.Cells[i + DongBatDau + SoLop, 18];
                        excel.Cells[i + DongBatDau + SoLop, 18] = int.Parse(dr["SoMonThiLai"].ToString());
                    }
                    if ("" + dr["SoHocTrinhThiLai"] != "")
                    {
                        cel = (Excel.Range)excel.Cells[i + DongBatDau + SoLop, 19];
                        excel.Cells[i + DongBatDau + SoLop, 19] = double.Parse(dr["SoHocTrinhThiLai"].ToString());
                    }
                    if ("" + dr["GhiChu"] != "")
                    {
                        cel = (Excel.Range)excel.Cells[i + DongBatDau + SoLop, 20];
                        excel.Cells[i + DongBatDau + SoLop, 20] = dr["GhiChu"].ToString();
                    }
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
                    if (j != 3)
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