using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.wsBusiness;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Entity.Model;
using TruongViet.UnimOs.Data;
using UnimOs.wsBusiness.wsUnimOs;

namespace TruongViet.UnimOs.wsBusiness
{
    public class cBwsKQHT_DiemTongKetMon : cBwsBase
    {
        private cDKQHT_DiemTongKetMon oDKQHT_DiemTongKetMon;
        private KQHT_DiemTongKetMonInfo oKQHT_DiemTongKetMonInfo;

        public cBwsKQHT_DiemTongKetMon()
        {
            oDKQHT_DiemTongKetMon = new cDKQHT_DiemTongKetMon();
        }

        public DataTable Get(KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_DiemTongKetMon_GetResult>(client.cDKQHT_DiemTongKetMon_Get(GlobalVar.MaXacThuc, pKQHT_DiemTongKetMonInfo));
            }
        }

        public DataTable GetDanhSach(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi, int Kieu)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_DiemTongKetMon_GetDanhSachResult>(client.cDKQHT_DiemTongKetMon_GetDanhSach(GlobalVar.MaXacThuc, IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi, Kieu));
            }
        }

        public DataTable GetDanhSachNhapDiem(int IDDM_Lop, int IDDM_MonHoc, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_DiemTongKetMon_GetDanhSachNhapDiemResult>(client.cDKQHT_DiemTongKetMon_GetDanhSachNhapDiem(GlobalVar.MaXacThuc, IDDM_Lop, IDDM_MonHoc, IDXL_MonHocTrongKy, IDDM_NamHoc, HocKy, LanThi));
            }
        }

        public DataTable GetByLop(int IDDM_Lop, int IDDM_MonHoc, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_DiemTongKetMon_GetByLopResult>(client.cDKQHT_DiemTongKetMon_GetByLop(GlobalVar.MaXacThuc, IDDM_Lop, IDDM_MonHoc, IDXL_MonHocTrongKy, IDDM_NamHoc, HocKy));
            }
        }

        public DataTable ChoNhapLaiDiem_GetByLop(int IDKQHT_ChoNhapLaiDiem)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_DiemTongKetMon_ChoNhapLaiDiem_GetByLopResult>(client.cDKQHT_DiemTongKetMon_ChoNhapLaiDiem_GetByLop(GlobalVar.MaXacThuc, IDKQHT_ChoNhapLaiDiem));
            }
        }

        public DataTable GetMonKy(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_DiemTongKetMon_GetMonKyResult>(client.cDKQHT_DiemTongKetMon_GetMonKy(GlobalVar.MaXacThuc, IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi));
            }
        }

        public int GetSoMonCoDiemByLop(int IDDM_Lop, int IDDM_NamHoc, int HocKy, ref double TongSoTrinh)
        {
            var client = new UnimOsServiceClient();
            DataTable dt = ConvertList.ToDataTable<sp_KQHT_DiemTongKetMon_GetSoMonCoDiemByLopResult>(client.cDKQHT_DiemTongKetMon_GetSoMonCoDiemByLop(GlobalVar.MaXacThuc, IDDM_Lop, IDDM_NamHoc, HocKy));
            client.Close();
            if (dt.Rows.Count > 0)
            {
                TongSoTrinh = double.Parse(dt.Rows[0]["TongSoTrinh"].ToString());
                return int.Parse(dt.Rows[0]["SoMon"].ToString());
            }
            else
                return 0;
        }

        public DataTable GetDiemThucTapTotNghiep(DM_LopInfo pDM_LopInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<KQHT_DiemTongKetMonInfo>(client.cDKQHT_DiemTongKetMon_GetDiemThucTapTotNghiep(GlobalVar.MaXacThuc, pDM_LopInfo));
            }
        }

        public void Add(KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_DiemTongKetMon_Add(GlobalVar.MaXacThuc, pKQHT_DiemTongKetMonInfo);
            client.Close();
            mErrorMessage = oDKQHT_DiemTongKetMon.ErrorMessages;
            mErrorNumber = oDKQHT_DiemTongKetMon.ErrorNumber;

        }

        public long AddByImport(KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo, string MaSinhVien)
        {
            var client = new UnimOsServiceClient();
            pKQHT_DiemTongKetMonInfo.KQHT_DiemTongKetMonID = client.cDKQHT_DiemTongKetMon_AddByImport(GlobalVar.MaXacThuc, pKQHT_DiemTongKetMonInfo, MaSinhVien);
            client.Close();
            mErrorMessage = oDKQHT_DiemTongKetMon.ErrorMessages;
            mErrorNumber = oDKQHT_DiemTongKetMon.ErrorNumber;
            return pKQHT_DiemTongKetMonInfo.KQHT_DiemTongKetMonID;
        }

        //public void Update(KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDKQHT_DiemTongKetMon_Update(GlobalVar.MaXacThuc, pKQHT_DiemTongKetMonInfo);
        //    client.Close();
        //    mErrorMessage = oDKQHT_DiemTongKetMon.ErrorMessages;
        //    mErrorNumber = oDKQHT_DiemTongKetMon.ErrorNumber;
        //}

        //public void Delete(KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDKQHT_DiemTongKetMon_Delete(GlobalVar.MaXacThuc, pKQHT_DiemTongKetMonInfo);
        //    client.Close();
        //    mErrorMessage = oDKQHT_DiemTongKetMon.ErrorMessages;
        //    mErrorNumber = oDKQHT_DiemTongKetMon.ErrorNumber;
        //}

        public void DeleteByIDMonHocTrongKy(int IDSV_SinhVien, long IDXL_MonHocTrongKy, int LanThi)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_DiemTongKetMon_DeleteByIDMonHocTrongKy(GlobalVar.MaXacThuc, IDSV_SinhVien, IDXL_MonHocTrongKy, LanThi);
            client.Close();
            mErrorMessage = oDKQHT_DiemTongKetMon.ErrorMessages;
            mErrorNumber = oDKQHT_DiemTongKetMon.ErrorNumber;
        }

        //public List<KQHT_DiemTongKetMonInfo> GetList(KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo)
        //{
        //    List<KQHT_DiemTongKetMonInfo> oKQHT_DiemTongKetMonInfoList = new List<KQHT_DiemTongKetMonInfo>();
        //    DataTable dtb = Get(pKQHT_DiemTongKetMonInfo);
        //    if (dtb != null)
        //    {
        //        for (int i = 0; i < dtb.Rows.Count; i++)
        //        {
        //            oKQHT_DiemTongKetMonInfo = new KQHT_DiemTongKetMonInfo();

        //            oKQHT_DiemTongKetMonInfo.KQHT_DiemTongKetMonID = long.Parse(dtb.Rows[i]["KQHT_DiemTongKetMonID"].ToString());
        //            oKQHT_DiemTongKetMonInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
        //            oKQHT_DiemTongKetMonInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
        //            oKQHT_DiemTongKetMonInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
        //            oKQHT_DiemTongKetMonInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
        //            oKQHT_DiemTongKetMonInfo.LanThi = int.Parse(dtb.Rows[i]["LanThi"].ToString());
        //            oKQHT_DiemTongKetMonInfo.Diem = double.Parse(dtb.Rows[i]["Diem"].ToString());
        //            oKQHT_DiemTongKetMonInfo.LyDo = dtb.Rows[i]["LyDo"].ToString();
        //            oKQHT_DiemTongKetMonInfo.IDKQHT_XepLoai = int.Parse(dtb.Rows[i]["IDKQHT_XepLoai"].ToString());

        //            oKQHT_DiemTongKetMonInfoList.Add(oKQHT_DiemTongKetMonInfo);
        //        }
        //    }
        //    return oKQHT_DiemTongKetMonInfoList;
        //}

        public void ToDataRow(KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo, ref DataRow dr)
        {

            dr[pKQHT_DiemTongKetMonInfo.strKQHT_DiemTongKetMonID] = pKQHT_DiemTongKetMonInfo.KQHT_DiemTongKetMonID;
            dr[pKQHT_DiemTongKetMonInfo.strIDSV_SinhVien] = pKQHT_DiemTongKetMonInfo.IDSV_SinhVien;
            dr[pKQHT_DiemTongKetMonInfo.strIDDM_MonHoc] = pKQHT_DiemTongKetMonInfo.IDDM_MonHoc;
            dr[pKQHT_DiemTongKetMonInfo.strIDDM_NamHoc] = pKQHT_DiemTongKetMonInfo.IDDM_NamHoc;
            dr[pKQHT_DiemTongKetMonInfo.strHocKy] = pKQHT_DiemTongKetMonInfo.HocKy;
            dr[pKQHT_DiemTongKetMonInfo.strLanThi] = pKQHT_DiemTongKetMonInfo.LanThi;
            dr[pKQHT_DiemTongKetMonInfo.strDiem] = pKQHT_DiemTongKetMonInfo.Diem;
            dr[pKQHT_DiemTongKetMonInfo.strLyDo] = pKQHT_DiemTongKetMonInfo.LyDo;
            dr[pKQHT_DiemTongKetMonInfo.strIDKQHT_XepLoai] = pKQHT_DiemTongKetMonInfo.IDKQHT_XepLoai;
        }

        //public void ToInfo(ref KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo, DataRow dr)
        //{

        //    pKQHT_DiemTongKetMonInfo.KQHT_DiemTongKetMonID = long.Parse(dr[pKQHT_DiemTongKetMonInfo.strKQHT_DiemTongKetMonID].ToString());
        //    pKQHT_DiemTongKetMonInfo.IDSV_SinhVien = int.Parse(dr[pKQHT_DiemTongKetMonInfo.strIDSV_SinhVien].ToString());
        //    pKQHT_DiemTongKetMonInfo.IDDM_MonHoc = int.Parse(dr[pKQHT_DiemTongKetMonInfo.strIDDM_MonHoc].ToString());
        //    pKQHT_DiemTongKetMonInfo.IDDM_NamHoc = int.Parse(dr[pKQHT_DiemTongKetMonInfo.strIDDM_NamHoc].ToString());
        //    pKQHT_DiemTongKetMonInfo.HocKy = int.Parse(dr[pKQHT_DiemTongKetMonInfo.strHocKy].ToString());
        //    pKQHT_DiemTongKetMonInfo.LanThi = int.Parse(dr[pKQHT_DiemTongKetMonInfo.strLanThi].ToString());
        //    pKQHT_DiemTongKetMonInfo.Diem = double.Parse(dr[pKQHT_DiemTongKetMonInfo.strDiem].ToString());
        //    pKQHT_DiemTongKetMonInfo.LyDo = dr[pKQHT_DiemTongKetMonInfo.strLyDo].ToString();
        //    pKQHT_DiemTongKetMonInfo.IDKQHT_XepLoai = int.Parse(dr[pKQHT_DiemTongKetMonInfo.strIDKQHT_XepLoai].ToString());
        //}

        public void TinhDiemTBM(DataTable dtSV, DataTable dtXLMonHoc, DataRow drMonHoc, int IDDM_Lop, int IDDM_TrinhDo, string IDThanhPhanThi,
            int IDKQHT_ThanhPhanTBHS, int LanThi, string CongThucDiem, int IDDM_NamHoc, int HocKy, int IDNS_GiaoVien)
        {
            DataTable dtDiem = (new cBwsKQHT_DiemThanhPhan()).GetTongHopTBHS(int.Parse(drMonHoc["XL_MonHocTrongKyID"].ToString()),
                int.Parse(drMonHoc["DM_MonHocID"].ToString()), IDDM_Lop, IDDM_TrinhDo, IDDM_NamHoc, HocKy, LanThi);

            oKQHT_DiemTongKetMonInfo = new KQHT_DiemTongKetMonInfo();
            oKQHT_DiemTongKetMonInfo.IDDM_MonHoc = int.Parse(drMonHoc["DM_MonHocID"].ToString());
            oKQHT_DiemTongKetMonInfo.IDXL_MonHocTrongKy = int.Parse(drMonHoc["XL_MonHocTrongKyID"].ToString());
            oKQHT_DiemTongKetMonInfo.IDDM_NamHoc = IDDM_NamHoc;
            oKQHT_DiemTongKetMonInfo.HocKy = HocKy;
            oKQHT_DiemTongKetMonInfo.LanThi = LanThi;
            bool CoDiemThi, CoDiemTBHS;
            DataRow[] arrDr;

            foreach (DataRow dr in dtSV.Rows)
            {
                if ("" + dr[IDKQHT_ThanhPhanTBHS.ToString() + "_" + LanThi.ToString()] != "")
                    CoDiemTBHS = true;
                else
                    CoDiemTBHS = false;
                if ("" + dr[IDThanhPhanThi + "_" + LanThi.ToString()] != "")
                    CoDiemThi = true;
                else
                    CoDiemThi = false;

                if (CoDiemTBHS || CoDiemThi)
                {
                    arrDr = dtDiem.Select("IDSV_SinhVien = " + dr["SV_SinhVienID"]);

                    oKQHT_DiemTongKetMonInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                    oKQHT_DiemTongKetMonInfo.Diem = TestCongThuc(dr, arrDr, CongThucDiem, IDThanhPhanThi, IDKQHT_ThanhPhanTBHS, LanThi);
                    oKQHT_DiemTongKetMonInfo.IDKQHT_XepLoai = XepLoaiMonHoc(dtXLMonHoc, oKQHT_DiemTongKetMonInfo.Diem);
                    var client = new UnimOsServiceClient();
                    client.cDKQHT_DiemTongKetMon_Add(GlobalVar.MaXacThuc, oKQHT_DiemTongKetMonInfo);
                    client.Close();
                    dr["TK_" + LanThi.ToString()] = oKQHT_DiemTongKetMonInfo.Diem;
                    dr["IDKQHT_XepLoai_" + LanThi.ToString()] = oKQHT_DiemTongKetMonInfo.IDKQHT_XepLoai;
                }
                else
                {
                    var client = new UnimOsServiceClient();
                    client.cDKQHT_DiemTongKetMon_DeleteByIDMonHocTrongKy(GlobalVar.MaXacThuc, int.Parse(dr["SV_SinhVienID"].ToString()), oKQHT_DiemTongKetMonInfo.IDXL_MonHocTrongKy, LanThi);
                    client.Close();
                }
            }
        }

        public int XepLoaiMonHoc(DataTable dtXLMonHoc, double Diem)
        {
            foreach (DataRow dr in dtXLMonHoc.Rows)
            {
                if (Diem >= double.Parse("0" + dr["TuDiem"]))
                    return int.Parse(dr["KQHT_XepLoaiMonHocID"].ToString());
            }
            return 0;
        }

        private double TestCongThuc(DataRow drDiem, DataRow[] arrDrDiem, string CongThucDiem, string IDThanhPhanThi, int IDKQHT_ThanhPhanTBHS, int LanThi)
        {
            double Value = 0; int SoSauDauPhay;
            try
            {
                MathParser parser = new MathParser();
                parser.CreateVar("TBHS", double.Parse("0" + drDiem[IDKQHT_ThanhPhanTBHS.ToString() + "_" + LanThi.ToString()]), null);
                parser.CreateVar("THI", double.Parse("0" + drDiem[IDThanhPhanThi + "_" + LanThi.ToString()]), null);

                foreach (DataRow dr in arrDrDiem)
                {
                    if (!(dr["KyHieu"].ToString() == "TBHS" || dr["KyHieu"].ToString() == "THI"))
                    {
                        parser.CreateVar(dr["KyHieu"].ToString(), double.Parse("0" + dr["TongDiem"]), null);
                        parser.CreateVar("Count" + dr["KyHieu"], int.Parse("0" + dr["SoDiem"]), null);
                    }
                }

                string formula = CongThucDiem;
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
    }
}
