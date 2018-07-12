using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;
using System.Collections;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_MonHoc : cBBase
    {
        private cDDM_MonHoc oDDM_MonHoc;
        private DM_MonHocInfo oDM_MonHocInfo;

        public cBDM_MonHoc()        
        {
            oDDM_MonHoc = new cDDM_MonHoc();
        }

        public DataTable Get(DM_MonHocInfo pDM_MonHocInfo)        
        {
            return oDDM_MonHoc.Get(pDM_MonHocInfo);
        }

        public DataTable GetDanhSach(int IDDM_BoMon)
        {
            return oDDM_MonHoc.GetDanhSach(IDDM_BoMon);
             
        }

        public DataTable GetPhongChuyenMon(string IDDM_PhongHocs)
        {
            return oDDM_MonHoc.GetPhongChuyenMon(IDDM_PhongHocs);
        }

        public DataTable GetNotInIDCTKhoiKienThuc(int IDKQHT_CT_KhoiKienThuc)
        {
            return oDDM_MonHoc.GetNotInIDCTKhoiKienThuc(IDKQHT_CT_KhoiKienThuc);
        }

        public DataTable GetNotInIDNSGiaoVien(int IDNS_GiaoVien)
        {
            return oDDM_MonHoc.GetNotInIDNSGiaoVien(IDNS_GiaoVien);
        }

        public DataTable GetMonKyByLop(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            return oDDM_MonHoc.GetMonKyByLop(IDDM_Lop, IDDM_NamHoc, HocKy);
        }

        // Lấy ra danh sách các môn học phòng chuyên môn
        public Hashtable GetPhongHoc_MonHoc(int SuDungPhong)        
        {
            Hashtable htb = new Hashtable();
            DataTable dt = oDDM_MonHoc.GetPhongHoc_MonHoc(SuDungPhong);
            if (dt.Rows.Count > 0)
            {
                string[] strPhong;
                int[] arrPhong;
                string dsPhong;
                string IDDM_MonHoc = dt.Rows[0]["IDDM_MonHoc"].ToString();
                dsPhong = ""; //dt.Rows[0]["IDDM_PhongHoc"].ToString(); ;
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["IDDM_MonHoc"].ToString() != IDDM_MonHoc)
                    {
                        strPhong = dsPhong.Split(',');
                        arrPhong = new int[strPhong.Length];
                        for (int i = 0; i < strPhong.Length; i++)
                        {
                            arrPhong[i] = int.Parse(strPhong[i]);
                        }
                        htb.Add(int.Parse(IDDM_MonHoc), arrPhong);

                        IDDM_MonHoc = dr["IDDM_MonHoc"].ToString();
                        dsPhong = dr["IDDM_PhongHoc"].ToString();
                    }
                    else
                    {
                        dsPhong += dsPhong == "" ? dr["IDDM_PhongHoc"].ToString() : "," + dr["IDDM_PhongHoc"].ToString();
                    }
                }
                strPhong = dsPhong.Split(',');
                arrPhong = new int[strPhong.Length];
                for (int i = 0; i < strPhong.Length; i++)
                {
                    arrPhong[i] = int.Parse(strPhong[i]);
                }
                htb.Add(int.Parse(IDDM_MonHoc), arrPhong);
            }
            return htb;
        }

        private int[] GetPhongChuyenMon(int IDDM_MonHoc)
        {
            cBXL_PhongHoc_MonHoc oBXL_PhongHoc_MonHoc = new cBXL_PhongHoc_MonHoc();
            DataTable dt = oBXL_PhongHoc_MonHoc.GetByIDDM_MonHoc(IDDM_MonHoc);
            if (dt.Rows.Count > 0)
            {
                int[] arr = new int[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    arr[i] = int.Parse(dt.Rows[i]["IDDM_PhongHoc"].ToString());
                }
                return arr;
            }
            else
                return null;
        }

        public DataTable GetMonThiTotNghiep(int IDDM_NamHoc)
        {
            return oDDM_MonHoc.GetMonThiTotNghiep(IDDM_NamHoc);
        }

        public int Add(DM_MonHocInfo pDM_MonHocInfo)
        {
			int ID = 0;
            ID = oDDM_MonHoc.Add(pDM_MonHocInfo);
            mErrorMessage = oDDM_MonHoc.ErrorMessages;
            mErrorNumber = oDDM_MonHoc.ErrorNumber;
            return ID;
        }

        public int AddByImport(DM_MonHocInfo pDM_MonHocInfo, ref string Error)
        {
            int ID = 0;
            ID = oDDM_MonHoc.AddByImport(pDM_MonHocInfo, ref Error);
            mErrorMessage = oDDM_MonHoc.ErrorMessages;
            mErrorNumber = oDDM_MonHoc.ErrorNumber;
            return ID;
        }

        public void Update(DM_MonHocInfo pDM_MonHocInfo)
        {
            oDDM_MonHoc.Update(pDM_MonHocInfo);
            mErrorMessage = oDDM_MonHoc.ErrorMessages;
            mErrorNumber = oDDM_MonHoc.ErrorNumber;
        }
        
        public void Delete(DM_MonHocInfo pDM_MonHocInfo)
        {
            oDDM_MonHoc.Delete(pDM_MonHocInfo);
            mErrorMessage = oDDM_MonHoc.ErrorMessages;
            mErrorNumber = oDDM_MonHoc.ErrorNumber;
        }

        public List<DM_MonHocInfo> GetList(DM_MonHocInfo pDM_MonHocInfo)
        {
            List<DM_MonHocInfo> oDM_MonHocInfoList = new List<DM_MonHocInfo>();
            DataTable dtb = Get(pDM_MonHocInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_MonHocInfo = new DM_MonHocInfo();

                    oDM_MonHocInfo.DM_MonHocID = int.Parse(dtb.Rows[i]["DM_MonHocID"].ToString());
                    oDM_MonHocInfo.MaMonHoc = dtb.Rows[i]["MaMonHoc"].ToString();
                    oDM_MonHocInfo.TenMonHoc = dtb.Rows[i]["TenMonHoc"].ToString();
                    oDM_MonHocInfo.TenMonHoc_E = dtb.Rows[i]["TenMonHoc_E"].ToString();
                    oDM_MonHocInfo.TenVietTat = dtb.Rows[i]["TenVietTat"].ToString();
                    oDM_MonHocInfo.SoTiet = int.Parse(dtb.Rows[i]["SoTiet"].ToString());
                    oDM_MonHocInfo.LyThuyet = int.Parse(dtb.Rows[i]["LyThuyet"].ToString());
                    oDM_MonHocInfo.ThucHanh = int.Parse(dtb.Rows[i]["ThucHanh"].ToString());
                    oDM_MonHocInfo.LoaiTietKhac1 = int.Parse(dtb.Rows[i]["LoaiTietKhac1"].ToString());
                    oDM_MonHocInfo.LoaiTietKhac2 = int.Parse(dtb.Rows[i]["LoaiTietKhac2"].ToString());
                    oDM_MonHocInfo.SoHocTrinh = double.Parse(dtb.Rows[i]["SoHocTrinh"].ToString());
                    oDM_MonHocInfo.ChoPhepXepLich = bool.Parse(dtb.Rows[i]["ChoPhepXepLich"].ToString());
                    oDM_MonHocInfo.SuDungPhong = int.Parse(dtb.Rows[i]["SuDungPhong"].ToString());
                    oDM_MonHocInfo.IDDM_TrinhDo = int.Parse(dtb.Rows[i]["IDDM_TrinhDo"].ToString());
                    oDM_MonHocInfo.IDDM_Nganh = int.Parse(dtb.Rows[i]["IDDM_Nganh"].ToString());
                    oDM_MonHocInfo.IDDM_ChuyenNganh = int.Parse(dtb.Rows[i]["IDDM_ChuyenNganh"].ToString());
                    oDM_MonHocInfo.IDDM_BoMon = int.Parse(dtb.Rows[i]["IDDM_BoMon"].ToString());
                    oDM_MonHocInfo.IDDM_KhoiKienThuc = int.Parse(dtb.Rows[i]["IDDM_KhoiKienThuc"].ToString());
                    oDM_MonHocInfo.IDDM_HinhThucThi = int.Parse(dtb.Rows[i]["IDDM_HinhThucThi"].ToString());
                    oDM_MonHocInfo.MoTa = dtb.Rows[i]["MoTa"].ToString();
                    
                    oDM_MonHocInfoList.Add(oDM_MonHocInfo);
                }
            }
            return oDM_MonHocInfoList;
        }
        
        public void ToDataRow(DM_MonHocInfo pDM_MonHocInfo, ref DataRow dr)
        {
			dr[pDM_MonHocInfo.strDM_MonHocID] = pDM_MonHocInfo.DM_MonHocID;
			dr[pDM_MonHocInfo.strMaMonHoc] = pDM_MonHocInfo.MaMonHoc;
			dr[pDM_MonHocInfo.strTenMonHoc] = pDM_MonHocInfo.TenMonHoc;
			dr[pDM_MonHocInfo.strTenMonHoc_E] = pDM_MonHocInfo.TenMonHoc_E;
            dr[pDM_MonHocInfo.strTenVietTat] = pDM_MonHocInfo.TenVietTat;
			dr[pDM_MonHocInfo.strSoTiet] = pDM_MonHocInfo.SoTiet;
			dr[pDM_MonHocInfo.strLyThuyet] = pDM_MonHocInfo.LyThuyet;
			dr[pDM_MonHocInfo.strThucHanh] = pDM_MonHocInfo.ThucHanh;
			dr[pDM_MonHocInfo.strLoaiTietKhac1] = pDM_MonHocInfo.LoaiTietKhac1;
			dr[pDM_MonHocInfo.strLoaiTietKhac2] = pDM_MonHocInfo.LoaiTietKhac2;
			dr[pDM_MonHocInfo.strSoHocTrinh] = pDM_MonHocInfo.SoHocTrinh;
			dr[pDM_MonHocInfo.strChoPhepXepLich] = pDM_MonHocInfo.ChoPhepXepLich;
			dr[pDM_MonHocInfo.strSuDungPhong] = pDM_MonHocInfo.SuDungPhong;
			dr[pDM_MonHocInfo.strIDDM_TrinhDo] = pDM_MonHocInfo.IDDM_TrinhDo;
			dr[pDM_MonHocInfo.strIDDM_Nganh] = pDM_MonHocInfo.IDDM_Nganh;
			dr[pDM_MonHocInfo.strIDDM_ChuyenNganh] = pDM_MonHocInfo.IDDM_ChuyenNganh;
			dr[pDM_MonHocInfo.strIDDM_BoMon] = pDM_MonHocInfo.IDDM_BoMon;
			dr[pDM_MonHocInfo.strIDDM_KhoiKienThuc] = pDM_MonHocInfo.IDDM_KhoiKienThuc;
			dr[pDM_MonHocInfo.strIDDM_HinhThucThi] = pDM_MonHocInfo.IDDM_HinhThucThi;
			dr[pDM_MonHocInfo.strMoTa] = pDM_MonHocInfo.MoTa;
            dr[pDM_MonHocInfo.strTinhDiemToanKhoa] = pDM_MonHocInfo.TinhDiemToanKhoa;
        }

        public void ToInfo(ref DM_MonHocInfo pDM_MonHocInfo, DataRow dr)
        {
            pDM_MonHocInfo.DM_MonHocID = int.Parse(dr[pDM_MonHocInfo.strDM_MonHocID].ToString());
            pDM_MonHocInfo.MaMonHoc = dr[pDM_MonHocInfo.strMaMonHoc].ToString();
            pDM_MonHocInfo.TenMonHoc = dr[pDM_MonHocInfo.strTenMonHoc].ToString();
            pDM_MonHocInfo.TenMonHoc_E = dr[pDM_MonHocInfo.strTenMonHoc_E].ToString();
            pDM_MonHocInfo.TenVietTat = dr[pDM_MonHocInfo.strTenVietTat].ToString();
            pDM_MonHocInfo.SoTiet = int.Parse(dr[pDM_MonHocInfo.strSoTiet].ToString());
            pDM_MonHocInfo.LyThuyet = int.Parse(dr[pDM_MonHocInfo.strLyThuyet].ToString());
            pDM_MonHocInfo.ThucHanh = int.Parse(dr[pDM_MonHocInfo.strThucHanh].ToString());
            pDM_MonHocInfo.LoaiTietKhac1 = int.Parse(dr[pDM_MonHocInfo.strLoaiTietKhac1].ToString());
            pDM_MonHocInfo.LoaiTietKhac2 = int.Parse(dr[pDM_MonHocInfo.strLoaiTietKhac2].ToString());
            pDM_MonHocInfo.SoHocTrinh = double.Parse(dr[pDM_MonHocInfo.strSoHocTrinh].ToString());
            pDM_MonHocInfo.ChoPhepXepLich = bool.Parse(dr[pDM_MonHocInfo.strChoPhepXepLich].ToString());
            pDM_MonHocInfo.SuDungPhong = int.Parse(dr[pDM_MonHocInfo.strSuDungPhong].ToString());
            pDM_MonHocInfo.IDDM_TrinhDo = int.Parse(dr[pDM_MonHocInfo.strIDDM_TrinhDo].ToString());
            pDM_MonHocInfo.IDDM_Nganh = int.Parse(dr[pDM_MonHocInfo.strIDDM_Nganh].ToString());
            pDM_MonHocInfo.IDDM_ChuyenNganh = int.Parse(dr[pDM_MonHocInfo.strIDDM_ChuyenNganh].ToString());
            pDM_MonHocInfo.IDDM_BoMon = int.Parse(dr[pDM_MonHocInfo.strIDDM_BoMon].ToString());
            pDM_MonHocInfo.IDDM_KhoiKienThuc = int.Parse(dr[pDM_MonHocInfo.strIDDM_KhoiKienThuc].ToString());
            pDM_MonHocInfo.IDDM_HinhThucThi = int.Parse(dr[pDM_MonHocInfo.strIDDM_HinhThucThi].ToString());
            pDM_MonHocInfo.MoTa = dr[pDM_MonHocInfo.strMoTa].ToString();
            pDM_MonHocInfo.TinhDiemToanKhoa = bool.Parse(dr[pDM_MonHocInfo.strTinhDiemToanKhoa].ToString());
        }

        public void ToInfo(ref DM_MonHocInfo pDM_MonHocInfo, DataRow dr, DataTable dt)
        {
            if (dt.Columns.Contains(pDM_MonHocInfo.strMaMonHoc))
                pDM_MonHocInfo.MaMonHoc = dr[pDM_MonHocInfo.strMaMonHoc].ToString().Trim();
            else
                pDM_MonHocInfo.MaMonHoc = "";
            if (dt.Columns.Contains(pDM_MonHocInfo.strTenMonHoc))
                pDM_MonHocInfo.TenMonHoc = dr[pDM_MonHocInfo.strTenMonHoc].ToString().Trim();
            if (dt.Columns.Contains(pDM_MonHocInfo.strTenVietTat))
                pDM_MonHocInfo.TenVietTat = dr[pDM_MonHocInfo.strTenVietTat].ToString().Trim();
            if (dt.Columns.Contains(pDM_MonHocInfo.strSoTiet))
                pDM_MonHocInfo.SoTiet = int.Parse("0" + dr[pDM_MonHocInfo.strSoTiet]);
            if (dt.Columns.Contains(pDM_MonHocInfo.strLyThuyet))
            {
                if ("" + dr[pDM_MonHocInfo.strLyThuyet] == "")
                    if (int.Parse("0" + dr[pDM_MonHocInfo.strThucHanh]) <= 0)
                        pDM_MonHocInfo.LyThuyet = int.Parse(dr[pDM_MonHocInfo.strSoTiet].ToString().Trim());
                    else
                        pDM_MonHocInfo.LyThuyet = 0;
                else
                    pDM_MonHocInfo.LyThuyet = int.Parse(dr[pDM_MonHocInfo.strLyThuyet].ToString().Trim());
            }
            if (dt.Columns.Contains(pDM_MonHocInfo.strThucHanh))
                pDM_MonHocInfo.ThucHanh = int.Parse("0" + dr[pDM_MonHocInfo.strThucHanh]);
            if (dt.Columns.Contains(pDM_MonHocInfo.strSoHocTrinh))
                pDM_MonHocInfo.SoHocTrinh = double.Parse("0" + dr[pDM_MonHocInfo.strSoHocTrinh]);
            else
                pDM_MonHocInfo.SoHocTrinh = Math.Round(double.Parse("0" + dr[pDM_MonHocInfo.strSoTiet]) / 15, 0);

            pDM_MonHocInfo.SuDungPhong = (int)SU_DUNG_PHONG.BAT_KY;
        }
    }
}
