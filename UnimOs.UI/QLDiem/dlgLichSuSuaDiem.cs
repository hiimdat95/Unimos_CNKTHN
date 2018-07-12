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

namespace UnimOs.UI
{
    public partial class dlgLichSuSuaDiem : frmBase
    {
        private cBKQHT_DiemThanhPhan oBKQHT_DiemThanhPhan;
        private cBKQHT_DiemThi oBKQHT_DiemThi;
        private cBKQHT_DiemTongKetMon oBKQHT_DiemTongKetMon;
        private cBKQHT_DiemDanh oBKQHT_DiemDanh;
        private DataTable dtSinhVien, dtThanhPhan;
        private DataRow drMonHoc;
        private DM_LopInfo pDM_LopInfo;
        private int ColStart = 8, ColEnd, IDKQHT_ThanhPhanTBHS = 0, SoLanThi = 0;
        private string IDThanhPhanThi = "";

        public dlgLichSuSuaDiem(DataTable dtLichSu, DM_LopInfo _pDM_LopInfo, DataRow _drMonHoc)
        {
            InitializeComponent();

            pDM_LopInfo = _pDM_LopInfo;
            drMonHoc = _drMonHoc;

            oBKQHT_DiemThanhPhan = new cBKQHT_DiemThanhPhan();
            oBKQHT_DiemThi = new cBKQHT_DiemThi();
            oBKQHT_DiemTongKetMon = new cBKQHT_DiemTongKetMon();
            oBKQHT_DiemDanh = new cBKQHT_DiemDanh();

            lblTenMonHoc.Text = string.Format("Môn: {0}, lớp: {1}", drMonHoc["TenMonHoc"], pDM_LopInfo.TenLop);

            grdLichSu.DataSource = dtLichSu;
        }

        private void btnInBangDiem_Click(object sender, EventArgs e)
        {
            if (grvLichSu.FocusedRowHandle < 0)
            {
                ThongBao("Bạn chưa chọn lần nhập lại điểm nào !");
                return;
            }

            // Lấy danh sách sinh viên
            dtSinhVien = CreateTable();
            AddBand();
            XuLyTable((int)grvLichSu.GetDataRow(grvLichSu.FocusedRowHandle)["KQHT_ChoNhapLaiDiemID"]);

            if (dtSinhVien.Rows.Count <= 0)
            {
                ThongBao("Không có dữ liệu để in báo cáo !");
                return;
            }

            DataTable dtMain = oBKQHT_DiemThanhPhan.CreateTableReportMain();
            DataRow dr = dtMain.NewRow();
            dr["TenMonHoc"] = drMonHoc["TenMonHoc"];
            dr["TenLop"] = pDM_LopInfo.TenLop.Replace("Lớp: ", "");
            dr["HocKy"] = Program.HocKy;
            dr["NamHoc"] = Program.NamHoc;
            dr["SoTiet"] = drMonHoc["SoTiet"];

            #region Tổng hợp Xếp loại
            // Đưa dữ liệu phần tỷ lệ kết quả học tập
            DataTable dtXepLoai;
            cBKQHT_XepLoaiMonHoc oBKQHT_XepLoaiMonHoc = new cBKQHT_XepLoaiMonHoc();
            KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo = new KQHT_XepLoaiMonHocInfo();
            int SoSinhVien;

            dtXepLoai = oBKQHT_XepLoaiMonHoc.Get(pKQHT_XepLoaiMonHocInfo);
            //dr = dtMain.NewRow();
            SoSinhVien = dtSinhVien.Rows.Count;
            // Tỷ lệ giỏi
            string Condition = "";
            int SoLuong = 0;
            DataRow[] ArrDr = dtXepLoai.Select("MaXepLoai = 'G'");
            if (ArrDr.Length > 0)
            {
                Condition = "IDKQHT_XepLoai_1 = " + ArrDr[0]["KQHT_XepLoaiMonHocID"];
                //foreach (DataRow drXL in ArrDr)
                //{
                //    Condition += (Condition == "" ? "" : " OR ") + "IDKQHT_XepLoai_1 = " + drXL["KQHT_XepLoaiMonHocID"];
                //}

                SoLuong = int.Parse(dtSinhVien.Compute("Count(SV_SinhVienID)", Condition).ToString());
                dr["LoaiGioi"] = TinhPhanTram(SoLuong, SoSinhVien);
            }

            // Tỷ lệ khá
            ArrDr = dtXepLoai.Select("MaXepLoai = 'K'");
            if (ArrDr.Length > 0)
            {
                Condition = "IDKQHT_XepLoai_1 = " + ArrDr[0]["KQHT_XepLoaiMonHocID"];
                //foreach (DataRow drXL in ArrDr)
                //{
                //    Condition += (Condition == "" ? "" : " OR ") + "IDKQHT_XepLoai_1 = " + drXL["KQHT_XepLoaiMonHocID"];
                //}

                SoLuong = int.Parse(dtSinhVien.Compute("Count(SV_SinhVienID)", Condition).ToString());
                dr["LoaiKha"] = TinhPhanTram(SoLuong, SoSinhVien);
            }
            // Tỷ lệ trung bình
            ArrDr = dtXepLoai.Select("MaXepLoai = 'TB'");
            if (ArrDr.Length > 0)
            {
                Condition = "IDKQHT_XepLoai_1 = " + ArrDr[0]["KQHT_XepLoaiMonHocID"];
                //foreach (DataRow drXL in ArrDr)
                //{
                //    Condition += (Condition == "" ? "" : " OR ") + "IDKQHT_XepLoai_1 = " + drXL["KQHT_XepLoaiMonHocID"];
                //}

                SoLuong = int.Parse(dtSinhVien.Compute("Count(SV_SinhVienID)", Condition).ToString());
                dr["LoaiTrungBinh"] = TinhPhanTram(SoLuong, SoSinhVien);
            }
            // Tỷ lệ yếu
            ArrDr = dtXepLoai.Select("MaXepLoai = 'Y'");
            if (ArrDr.Length > 0)
            {
                Condition = "IDKQHT_XepLoai_1 = " + ArrDr[0]["KQHT_XepLoaiMonHocID"];
                //foreach (DataRow drXL in ArrDr)
                //{
                //    Condition += (Condition == "" ? "" : " OR ") + "IDKQHT_XepLoai_1 = " + drXL["KQHT_XepLoaiMonHocID"];
                //}

                SoLuong = int.Parse(dtSinhVien.Compute("Count(SV_SinhVienID)", Condition).ToString());
                dr["LoaiYeu"] = TinhPhanTram(SoLuong, SoSinhVien);
            }
            // Tỷ lệ kém
            ArrDr = dtXepLoai.Select("MaXepLoai = 'KM'");
            if (ArrDr.Length > 0)
            {
                Condition = "IDKQHT_XepLoai_1 = " + ArrDr[0]["KQHT_XepLoaiMonHocID"];
                //foreach (DataRow drXL in ArrDr)
                //{
                //    Condition += (Condition == "" ? "" : " OR ") + "IDKQHT_XepLoai_1 = " + drXL["KQHT_XepLoaiMonHocID"];
                //}
                Condition += " OR IDKQHT_XepLoai_1 = 0";

                SoLuong = int.Parse(dtSinhVien.Compute("Count(SV_SinhVienID)", Condition).ToString());
                dr["LoaiKem"] = TinhPhanTram(SoLuong, SoSinhVien);
            }

            dtMain.Rows.Add(dr);
            #endregion

            DataTable dtSub = oBKQHT_DiemThanhPhan.CreateTableReportSub_CDCNKT(dtSinhVien, dtThanhPhan, ColStart, IDKQHT_ThanhPhanTBHS);
            frmReport frm = new frmReport(dtMain, dtSub, "rBangKetQuaHocTap", "rBangKetQuaHocTapSub", new string[] { "SubReport1" });
            frm.Show();
        }

        private string TinhPhanTram(int SoLuong, int SoSinhVien)
        {
            return Math.Round(((double)SoLuong / (double)SoSinhVien * 100), 0, MidpointRounding.AwayFromZero) +
                "% (" + SoLuong.ToString() + " SV)";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Lấy điểm theo lần cho nhập lại điểm
        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SV_SinhVienID", typeof(int));
            dt.Columns.Add("MaSinhVien", typeof(string));
            dt.Columns.Add("HoVa", typeof(string));
            dt.Columns.Add("TenSV", typeof(string));
            dt.Columns.Add("NgaySinh", typeof(DateTime));
            dt.Columns.Add("TenLop", typeof(string));
            dt.Columns.Add("CoLyDo", typeof(int));
            dt.Columns.Add("KhongLyDo", typeof(int));
            ColStart = 8;
            ColEnd = ColStart;
            return dt;
        }

        private void AddBand()
        {
            KQHT_ThanhPhanDiemInfo pKQHT_ThanPhanDiemInfo = new KQHT_ThanhPhanDiemInfo();
            cBKQHT_ThanhPhanDiem oBKQHT_ThanhPhanDiem = new cBKQHT_ThanhPhanDiem();
            dtThanhPhan = oBKQHT_ThanhPhanDiem.GetByIDTrinhDo(pDM_LopInfo.IDDM_TrinhDo);

            if ((dtThanhPhan != null) && (dtThanhPhan.Rows.Count > 0))
            {
                foreach (DataRow dr in dtThanhPhan.Rows)
                {
                    if ("" + dr["CongThucDiem"] == "")
                    {
                        // Begin Add TenThanhPhanDiem
                        if (!bool.Parse(dr["Thi"].ToString()))
                        {
                            // Nếu không phải là thành phần thi
                            if (int.Parse(dr["SoDiem"].ToString()) == 1)
                            {
                                dtSinhVien.Columns.Add(dr["KQHT_ThanhPhanDiemID"].ToString() + "_1", typeof(double));
                                ColEnd++;
                            }
                            else
                            {
                                for (int i = 1; i <= int.Parse(dr["SoDiem"].ToString()); i++)
                                {
                                    dtSinhVien.Columns.Add(dr["KQHT_ThanhPhanDiemID"].ToString() + "_" + i.ToString(), typeof(double));
                                    ColEnd++;
                                }
                            }
                        }
                        else
                        {
                            // Nếu là thành phần thi
                            IDThanhPhanThi = dr["KQHT_ThanhPhanDiemID"].ToString();
                            SoLanThi = int.Parse(dr["SoLanThi"].ToString());
                            for (int i = 1; i <= SoLanThi; i++)
                            {
                                dtSinhVien.Columns.Add(dr["KQHT_ThanhPhanDiemID"].ToString() + "_" + i.ToString(), typeof(double));
                                ColEnd++;
                            }
                        }
                        // End Add TenThanhPhanDiem
                    }
                    else
                        IDKQHT_ThanhPhanTBHS = int.Parse(dr["KQHT_ThanhPhanDiemID"].ToString());
                }

                if (IDKQHT_ThanhPhanTBHS > 0)
                {
                    DataRow[] arrDr = dtThanhPhan.Select("KQHT_ThanhPhanDiemID = " + IDKQHT_ThanhPhanTBHS.ToString());
                    dtSinhVien.Columns.Add(IDKQHT_ThanhPhanTBHS.ToString() + "_1", typeof(double));
                }

                // Add cột lý do không được dự thi vào
                dtSinhVien.Columns.Add("LyDo", typeof(string));
                // Add cột điểm trung bình môn học
                for (int i = 1; i <= SoLanThi; i++)
                {
                    dtSinhVien.Columns.Add("TK_" + i.ToString(), typeof(double));
                    dtSinhVien.Columns.Add("IDKQHT_XepLoai_" + i.ToString(), typeof(int));
                    if (i > 1)
                        dtSinhVien.Columns.Add(IDKQHT_ThanhPhanTBHS.ToString() + "_" + i.ToString(), typeof(double));
                }
            }
        }

        private void XuLyTable(int IDKQHT_ChoNhapLaiDiem)
        {
            if (dtThanhPhan.Rows.Count > 0)
            {
                // Lấy điểm thành phần để hiển thị lên grid
                DataTable dtData = oBKQHT_DiemThanhPhan.ChoNhapLaiDiem_GetDanhSach(IDKQHT_ChoNhapLaiDiem);
                DataRow drNew;
                if (dtData.Rows.Count > 0)
                {
                    // Thực hiện đưa danh sách và nhập các điểm thành phần (không có điểm thi) lên grid
                    string Ho_Dem = "";
                    string SV_SinhVienID = dtData.Rows[0]["SV_SinhVienID"].ToString();
                    drNew = dtSinhVien.NewRow();
                    drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                    drNew["MaSinhVien"] = dtData.Rows[0]["MaSinhVien"].ToString();
                    drNew["TenSV"] = GetTen(dtData.Rows[0]["HoVaTen"].ToString(), ref Ho_Dem);
                    drNew["HoVa"] = Ho_Dem;
                    drNew["NgaySinh"] = dtData.Rows[0]["NgaySinh"];
                    drNew["TenLop"] = dtData.Rows[0]["TenLop"].ToString();
                    drNew["LyDo"] = "" + dtData.Rows[0]["LyDo"];

                    foreach (DataRow dr in dtData.Rows)
                    {
                        if (dr["SV_SinhVienID"].ToString() != SV_SinhVienID)
                        {
                            dtSinhVien.Rows.Add(drNew);

                            SV_SinhVienID = dr["SV_SinhVienID"].ToString();
                            drNew = dtSinhVien.NewRow();

                            drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                            drNew["MaSinhVien"] = dr["MaSinhVien"].ToString();
                            drNew["TenSV"] = GetTen(dr["HoVaTen"].ToString(), ref Ho_Dem);
                            drNew["HoVa"] = Ho_Dem;
                            drNew["NgaySinh"] = dr["NgaySinh"];
                            drNew["TenLop"] = dr["TenLop"].ToString();
                            drNew["LyDo"] = "" + dr["LyDo"];

                            if ("" + dr["Diem"] != "")
                            {
                                drNew[dr["IDKQHT_ThanhPhanDiem"].ToString() + "_" + dr["DiemThu"]] = double.Parse(dr["Diem"].ToString());
                            }
                        }
                        else
                        {
                            if ("" + dr["Diem"] != "")
                                drNew[dr["IDKQHT_ThanhPhanDiem"].ToString() + "_" + dr["DiemThu"]] = double.Parse(dr["Diem"].ToString());
                        }
                    }
                    dtSinhVien.Rows.Add(drNew);
                }


                DataRow[] arrDr;
                // Lấy điểm thi để hiển thị lên grid
                if (IDThanhPhanThi != "")
                {
                    dtData = oBKQHT_DiemThi.ChoNhapLaiDiem_GetByLop(IDKQHT_ChoNhapLaiDiem);
                    if (dtData.Rows.Count > 0)
                    {
                        foreach (DataRow drSV in dtSinhVien.Rows)
                        {
                            arrDr = dtData.Select("IDSV_SinhVien = " + drSV["SV_SinhVienID"]);
                            if (arrDr.Length > 0)
                            {
                                foreach (DataRow dr in arrDr)
                                {
                                    if (int.Parse(dr["LanThi"].ToString()) <= SoLanThi)
                                        drSV[IDThanhPhanThi + "_" + dr["LanThi"]] = double.Parse(dr["Diem"].ToString());
                                }
                            }
                        }
                    }
                }

                // Lấy điểm tổng kết để hiển thị lên grid
                dtData = oBKQHT_DiemTongKetMon.ChoNhapLaiDiem_GetByLop(IDKQHT_ChoNhapLaiDiem);
                if (dtData.Rows.Count > 0)
                {
                    foreach (DataRow drSV in dtSinhVien.Rows)
                    {
                        arrDr = dtData.Select("IDSV_SinhVien = " + drSV["SV_SinhVienID"]);
                        if (arrDr.Length > 0)
                        {
                            foreach (DataRow dr in arrDr)
                            {
                                if (int.Parse(dr["LanThi"].ToString()) <= SoLanThi)
                                {
                                    drSV["TK_" + dr["LanThi"]] = double.Parse(dr["Diem"].ToString());
                                    drSV["IDKQHT_XepLoai_" + dr["LanThi"]] = dr["IDKQHT_XepLoai"];
                                }
                            }
                        }
                    }
                }

                // Lấy điểm danh để hiển thị lên grid
                dtData = oBKQHT_DiemDanh.ChoNhapLaiDiem_GetByLop(IDKQHT_ChoNhapLaiDiem);
                if (dtData.Rows.Count > 0)
                {
                    foreach (DataRow drSV in dtSinhVien.Rows)
                    {
                        arrDr = dtData.Select("IDSV_SinhVien = " + drSV["SV_SinhVienID"]);
                        if (arrDr.Length > 0)
                        {
                            foreach (DataRow dr in arrDr)
                            {
                                if ("" + dr["CoLyDo"] != "")
                                    drSV["CoLyDo"] = int.Parse(dr["CoLyDo"].ToString());
                                if ("" + dr["KhongLyDo"] != "")
                                    drSV["KhongLyDo"] = int.Parse(dr["KhongLyDo"].ToString());
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}