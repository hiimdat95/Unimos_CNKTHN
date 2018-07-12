using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_DiemTongKetMon : cBBase
    {
        private cDKQHT_DiemTongKetMon oDKQHT_DiemTongKetMon;
        private KQHT_DiemTongKetMonInfo oKQHT_DiemTongKetMonInfo;

        public cBKQHT_DiemTongKetMon()        
        {
            oDKQHT_DiemTongKetMon = new cDKQHT_DiemTongKetMon();
        }

        public DataTable Get(KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo)        
        {
            return oDKQHT_DiemTongKetMon.Get(pKQHT_DiemTongKetMonInfo);
        }

        public DataTable GetDanhSach(int IDDM_Lop,int IDDM_MonHoc,int IDDM_NamHoc, int HocKy, int LanThi,int Kieu)
        {
            return oDKQHT_DiemTongKetMon.GetDanhSach(IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi,Kieu);
        }

        public DataTable GetDanhSachNhapDiem(int IDDM_Lop, int IDDM_MonHoc, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            return oDKQHT_DiemTongKetMon.GetDanhSachNhapDiem(IDDM_Lop, IDDM_MonHoc, IDXL_MonHocTrongKy, IDDM_NamHoc, HocKy, LanThi);
        }

        public DataTable GetByLop(int IDDM_Lop, int IDDM_MonHoc, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy)
        {
            return oDKQHT_DiemTongKetMon.GetByLop(IDDM_Lop, IDDM_MonHoc, IDXL_MonHocTrongKy, IDDM_NamHoc, HocKy);
        }

        public DataTable ChoNhapLaiDiem_GetByLop(int IDKQHT_ChoNhapLaiDiem)
        {
            return oDKQHT_DiemTongKetMon.ChoNhapLaiDiem_GetByLop(IDKQHT_ChoNhapLaiDiem);
        }

        public DataTable GetMonKy(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            return oDKQHT_DiemTongKetMon.GetMonKy(IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi);
        }

        public int GetSoMonCoDiemByLop(int IDDM_Lop, int IDDM_NamHoc, int HocKy, ref double TongSoTrinh)
        {
            DataTable dt = oDKQHT_DiemTongKetMon.GetSoMonCoDiemByLop(IDDM_Lop, IDDM_NamHoc, HocKy);
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
            return oDKQHT_DiemTongKetMon.GetDiemThucTapTotNghiep(pDM_LopInfo);
        }

        public void Add(KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo)
        {
			oDKQHT_DiemTongKetMon.Add(pKQHT_DiemTongKetMonInfo);
            mErrorMessage = oDKQHT_DiemTongKetMon.ErrorMessages;
            mErrorNumber = oDKQHT_DiemTongKetMon.ErrorNumber;
            
        }

        public long AddByImport(KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo, string MaSinhVien)
        {
            pKQHT_DiemTongKetMonInfo.KQHT_DiemTongKetMonID = oDKQHT_DiemTongKetMon.AddByImport(pKQHT_DiemTongKetMonInfo, MaSinhVien);
            mErrorMessage = oDKQHT_DiemTongKetMon.ErrorMessages;
            mErrorNumber = oDKQHT_DiemTongKetMon.ErrorNumber;
            return pKQHT_DiemTongKetMonInfo.KQHT_DiemTongKetMonID;
        }

        public void Update(KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo)
        {
            oDKQHT_DiemTongKetMon.Update(pKQHT_DiemTongKetMonInfo);
            mErrorMessage = oDKQHT_DiemTongKetMon.ErrorMessages;
            mErrorNumber = oDKQHT_DiemTongKetMon.ErrorNumber;
        }
        
        public void Delete(KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo)
        {
            oDKQHT_DiemTongKetMon.Delete(pKQHT_DiemTongKetMonInfo);
            mErrorMessage = oDKQHT_DiemTongKetMon.ErrorMessages;
            mErrorNumber = oDKQHT_DiemTongKetMon.ErrorNumber;
        }

        public void DeleteByIDMonHocTrongKy(int IDSV_SinhVien, long IDXL_MonHocTrongKy, int LanThi)
        {
            oDKQHT_DiemTongKetMon.DeleteByIDMonHocTrongKy(IDSV_SinhVien, IDXL_MonHocTrongKy, LanThi);
            mErrorMessage = oDKQHT_DiemTongKetMon.ErrorMessages;
            mErrorNumber = oDKQHT_DiemTongKetMon.ErrorNumber;
        }

        public List<KQHT_DiemTongKetMonInfo> GetList(KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo)
        {
            List<KQHT_DiemTongKetMonInfo> oKQHT_DiemTongKetMonInfoList = new List<KQHT_DiemTongKetMonInfo>();
            DataTable dtb = Get(pKQHT_DiemTongKetMonInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_DiemTongKetMonInfo = new KQHT_DiemTongKetMonInfo();

                    oKQHT_DiemTongKetMonInfo.KQHT_DiemTongKetMonID = long.Parse(dtb.Rows[i]["KQHT_DiemTongKetMonID"].ToString());
                    oKQHT_DiemTongKetMonInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oKQHT_DiemTongKetMonInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
                    oKQHT_DiemTongKetMonInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oKQHT_DiemTongKetMonInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oKQHT_DiemTongKetMonInfo.LanThi = int.Parse(dtb.Rows[i]["LanThi"].ToString());
                    oKQHT_DiemTongKetMonInfo.Diem = double.Parse(dtb.Rows[i]["Diem"].ToString());
                    oKQHT_DiemTongKetMonInfo.LyDo = dtb.Rows[i]["LyDo"].ToString();
                    oKQHT_DiemTongKetMonInfo.IDKQHT_XepLoai = int.Parse(dtb.Rows[i]["IDKQHT_XepLoai"].ToString());
                    
                    oKQHT_DiemTongKetMonInfoList.Add(oKQHT_DiemTongKetMonInfo);
                }
            }
            return oKQHT_DiemTongKetMonInfoList;
        }
        
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
        
        public void ToInfo(ref KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo, DataRow dr)
        {

			pKQHT_DiemTongKetMonInfo.KQHT_DiemTongKetMonID = long.Parse(dr[pKQHT_DiemTongKetMonInfo.strKQHT_DiemTongKetMonID].ToString());
			pKQHT_DiemTongKetMonInfo.IDSV_SinhVien = int.Parse(dr[pKQHT_DiemTongKetMonInfo.strIDSV_SinhVien].ToString());
			pKQHT_DiemTongKetMonInfo.IDDM_MonHoc = int.Parse(dr[pKQHT_DiemTongKetMonInfo.strIDDM_MonHoc].ToString());
			pKQHT_DiemTongKetMonInfo.IDDM_NamHoc = int.Parse(dr[pKQHT_DiemTongKetMonInfo.strIDDM_NamHoc].ToString());
			pKQHT_DiemTongKetMonInfo.HocKy = int.Parse(dr[pKQHT_DiemTongKetMonInfo.strHocKy].ToString());
			pKQHT_DiemTongKetMonInfo.LanThi = int.Parse(dr[pKQHT_DiemTongKetMonInfo.strLanThi].ToString());
			pKQHT_DiemTongKetMonInfo.Diem = double.Parse(dr[pKQHT_DiemTongKetMonInfo.strDiem].ToString());
			pKQHT_DiemTongKetMonInfo.LyDo = dr[pKQHT_DiemTongKetMonInfo.strLyDo].ToString();
			pKQHT_DiemTongKetMonInfo.IDKQHT_XepLoai = int.Parse(dr[pKQHT_DiemTongKetMonInfo.strIDKQHT_XepLoai].ToString());
        }

        public void TinhDiemTBM(DataTable dtSV, DataTable dtXLMonHoc, DataRow drMonHoc, int IDDM_Lop, int IDDM_TrinhDo, string IDThanhPhanThi, 
            int IDKQHT_ThanhPhanTBHS, int LanThi, string CongThucDiem, int IDDM_NamHoc, int HocKy, int IDNS_GiaoVien)
        {
            DataTable dtDiem = (new cBKQHT_DiemThanhPhan()).GetTongHopTBHS(int.Parse(drMonHoc["XL_MonHocTrongKyID"].ToString()), 
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
                    oDKQHT_DiemTongKetMon.Add(oKQHT_DiemTongKetMonInfo);
                    dr["TK_" + LanThi.ToString()] = oKQHT_DiemTongKetMonInfo.Diem;
                    dr["IDKQHT_XepLoai_" + LanThi.ToString()] = oKQHT_DiemTongKetMonInfo.IDKQHT_XepLoai;
                }
                else
                {
                    oDKQHT_DiemTongKetMon.DeleteByIDMonHocTrongKy(int.Parse(dr["SV_SinhVienID"].ToString()), oKQHT_DiemTongKetMonInfo.IDXL_MonHocTrongKy, LanThi);
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
