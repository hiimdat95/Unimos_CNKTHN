using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBXL_MonHocTrongKy : cBBase
    {
        private cDXL_MonHocTrongKy oDXL_MonHocTrongKy;
        private XL_MonHocTrongKyInfo oXL_MonHocTrongKyInfo;

        public cBXL_MonHocTrongKy()        
        {
            oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
        }

        public DataTable Get(XL_MonHocTrongKyInfo pXL_MonHocTrongKyInfo)        
        {
            return oDXL_MonHocTrongKy.Get(pXL_MonHocTrongKyInfo);
        }

        public DataTable GetMonKy(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            return oDXL_MonHocTrongKy.GetMonKy(IDDM_Lop, IDDM_NamHoc, HocKy);
        }

        public DataTable GetMonKyToanKhoaByLop(int IDDM_Lop)
        {
            return oDXL_MonHocTrongKy.GetMonKyToanKhoaByLop(IDDM_Lop);
        }

        public DataTable GetToChucThi(int IDDM_NamHoc, int HocKy)
        {
            return oDXL_MonHocTrongKy.GetToChucThi(IDDM_NamHoc, HocKy);
        }

        public DataTable GetMonKyChuaThucHanh(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            return oDXL_MonHocTrongKy.GetMonKyChuaThucHanh(IDDM_Lop, IDDM_NamHoc, HocKy);
        }

        public DataTable GetByLop(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            return oDXL_MonHocTrongKy.GetByLop(IDDM_Lop, IDDM_NamHoc, HocKy);
        }

        public DataTable GetByLopKhoa(int IDDM_Lop, int IDKhoa_GiaoVu, int IDDM_NamHoc, int HocKy)
        {
            return oDXL_MonHocTrongKy.GetByLopKhoa(IDDM_Lop, IDKhoa_GiaoVu, IDDM_NamHoc, HocKy);
        }

        public DataTable GetToanKhoa(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            return oDXL_MonHocTrongKy.GetToanKhoa(IDDM_Lop, IDDM_NamHoc, HocKy);
        }

        public DataTable GetByHocKyNamHoc(int IDDM_Lop, int HocKy, int IDDM_NamHoc, int IDDM_Khoa, int IDDM_BoMon)
        {
            return oDXL_MonHocTrongKy.GetByHocKyNamHoc(IDDM_Lop, HocKy, IDDM_NamHoc, IDDM_Khoa, IDDM_BoMon);
        }

        public DataTable GetByIDGiaoVien(int IDNS_GiaoVien, int IDDM_Lop, int HocKy, int IDDM_NamHoc)
        {
            return oDXL_MonHocTrongKy.GetByIDGiaoVien(IDNS_GiaoVien, IDDM_Lop, HocKy, IDDM_NamHoc);
        }

        public DataTable GetNhapDuLieuByHocKyNamHoc(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            return oDXL_MonHocTrongKy.GetNhapDuLieuByHocKyNamHoc(IDDM_Lop, IDDM_NamHoc, HocKy);
        }

        public DataTable GetAllByHocKyNamHoc(int IDDM_Lop, int HocKy, int IDDM_NamHoc)
        {
            return oDXL_MonHocTrongKy.GetAllByHocKyNamHoc(IDDM_Lop, HocKy, IDDM_NamHoc);
        }

        public DataTable GetByLopGop(string IDDM_Lops, int HocKy, int IDDM_NamHoc, int SoLop)
        {
            return oDXL_MonHocTrongKy.GetByLopGop(IDDM_Lops, HocKy, IDDM_NamHoc, SoLop);
        }
        
        public DataTable GetDiemMonByIDSV_SinhVienAndIDDM_Lop(int IDSV_SinhVien, int IDDM_Lop)
        {
            return oDXL_MonHocTrongKy.GetDiemMonByIDSV_SinhVienAndIDDM_Lop(IDSV_SinhVien, IDDM_Lop);
        }

        public void ChuyenDiemByChuyenLop(int IDSV_SinhVien, int IDXL_MonHocTrongKy_Cu, int IDDM_MonHoc_Cu, int IDXL_MonHocTrongKy_Moi, int IDDM_MonHoc_Moi,
                int IDDM_NamHoc_Moi, int HocKy_Moi)
        {
            oDXL_MonHocTrongKy.ChuyenDiemByChuyenLop(IDSV_SinhVien, IDXL_MonHocTrongKy_Cu, IDDM_MonHoc_Cu, IDXL_MonHocTrongKy_Moi, IDDM_MonHoc_Moi,
                IDDM_NamHoc_Moi, HocKy_Moi);
        }

        public int Add(XL_MonHocTrongKyInfo pXL_MonHocTrongKyInfo)
        {
			int ID = 0;
            ID = oDXL_MonHocTrongKy.Add(pXL_MonHocTrongKyInfo);
            mErrorMessage = oDXL_MonHocTrongKy.ErrorMessages;
            mErrorNumber = oDXL_MonHocTrongKy.ErrorNumber;
            return ID;
        }

        public void Update(XL_MonHocTrongKyInfo pXL_MonHocTrongKyInfo)
        {
            oDXL_MonHocTrongKy.Update(pXL_MonHocTrongKyInfo);
            mErrorMessage = oDXL_MonHocTrongKy.ErrorMessages;
            mErrorNumber = oDXL_MonHocTrongKy.ErrorNumber;
        }

        public void UpdateTachGop(int XL_MonHocTrongKyID, bool HocOLopTachGop)
        {
            oDXL_MonHocTrongKy.UpdateTachGop(XL_MonHocTrongKyID, HocOLopTachGop);
            mErrorMessage = oDXL_MonHocTrongKy.ErrorMessages;
            mErrorNumber = oDXL_MonHocTrongKy.ErrorNumber;
        }

        public void ApDungCacLopKhac(int DM_LopID, int DM_LopIDNew, int IDDM_NamHoc, int HocKy)
        {
            oDXL_MonHocTrongKy.ApDungCacLopKhac(DM_LopID, DM_LopIDNew,IDDM_NamHoc,HocKy);
            mErrorMessage = oDXL_MonHocTrongKy.ErrorMessages;
            mErrorNumber = oDXL_MonHocTrongKy.ErrorNumber;
        }
        
        public void Delete(XL_MonHocTrongKyInfo pXL_MonHocTrongKyInfo)
        {
            oDXL_MonHocTrongKy.Delete(pXL_MonHocTrongKyInfo);
            mErrorMessage = oDXL_MonHocTrongKy.ErrorMessages;
            mErrorNumber = oDXL_MonHocTrongKy.ErrorNumber;
        }

        public void DeleteByHocKyNamHoc(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            oDXL_MonHocTrongKy.DeleteByHocKyNamHoc(IDDM_Lop, IDDM_NamHoc, HocKy);
            mErrorMessage = oDXL_MonHocTrongKy.ErrorMessages;
            mErrorNumber = oDXL_MonHocTrongKy.ErrorNumber;
        }

        public void DeleteMonHocNotIn(int IDDM_Lop, int IDDM_NamHoc, int HocKy, string IDDM_MonHocs)
        {
            oDXL_MonHocTrongKy.DeleteMonHocNotIn(IDDM_Lop, IDDM_NamHoc, HocKy, IDDM_MonHocs);
            mErrorMessage = oDXL_MonHocTrongKy.ErrorMessages;
            mErrorNumber = oDXL_MonHocTrongKy.ErrorNumber;
        }

        public List<XL_MonHocTrongKyInfo> GetList(XL_MonHocTrongKyInfo pXL_MonHocTrongKyInfo)
        {
            List<XL_MonHocTrongKyInfo> oXL_MonHocTrongKyInfoList = new List<XL_MonHocTrongKyInfo>();
            DataTable dtb = Get(pXL_MonHocTrongKyInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oXL_MonHocTrongKyInfo = new XL_MonHocTrongKyInfo();

                    oXL_MonHocTrongKyInfo.XL_MonHocTrongKyID = int.Parse(dtb.Rows[i]["XL_MonHocTrongKyID"].ToString());
                    oXL_MonHocTrongKyInfo.IDKQHT_CTDT_ChiTiet = int.Parse(dtb.Rows[i]["IDKQHT_CTDT_ChiTiet"].ToString());
                    oXL_MonHocTrongKyInfo.IDDM_Lop = int.Parse(dtb.Rows[i]["IDDM_Lop"].ToString());
                    oXL_MonHocTrongKyInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oXL_MonHocTrongKyInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oXL_MonHocTrongKyInfo.SoTiet = int.Parse(dtb.Rows[i]["SoTiet"].ToString());
                    oXL_MonHocTrongKyInfo.LyThuyet = int.Parse(dtb.Rows[i]["LyThuyet"].ToString());
                    oXL_MonHocTrongKyInfo.ThucHanh = int.Parse(dtb.Rows[i]["ThucHanh"].ToString());
                    oXL_MonHocTrongKyInfo.LoaiTietKhac1 = int.Parse(dtb.Rows[i]["LoaiTietKhac1"].ToString());
                    oXL_MonHocTrongKyInfo.LoaiTietKhac2 = int.Parse(dtb.Rows[i]["LoaiTietKhac2"].ToString());
                    oXL_MonHocTrongKyInfo.SoHocTrinh = double.Parse(dtb.Rows[i]["SoHocTrinh"].ToString());
                    oXL_MonHocTrongKyInfo.ChoPhepXepLich = bool.Parse(dtb.Rows[i]["ChoPhepXepLich"].ToString());
                    oXL_MonHocTrongKyInfo.IDDM_HinhThucThi = int.Parse(dtb.Rows[i]["IDDM_HinhThucThi"].ToString());
                    oXL_MonHocTrongKyInfo.SapXep = int.Parse(dtb.Rows[i]["SapXep"].ToString());
                    
                    oXL_MonHocTrongKyInfoList.Add(oXL_MonHocTrongKyInfo);
                }
            }
            return oXL_MonHocTrongKyInfoList;
        }
        
        public void ToDataRow(XL_MonHocTrongKyInfo pXL_MonHocTrongKyInfo, ref DataRow dr)
        {

			dr[pXL_MonHocTrongKyInfo.strXL_MonHocTrongKyID] = pXL_MonHocTrongKyInfo.XL_MonHocTrongKyID;
			dr[pXL_MonHocTrongKyInfo.strIDKQHT_CTDT_ChiTiet] = pXL_MonHocTrongKyInfo.IDKQHT_CTDT_ChiTiet;
			dr[pXL_MonHocTrongKyInfo.strIDDM_Lop] = pXL_MonHocTrongKyInfo.IDDM_Lop;
			dr[pXL_MonHocTrongKyInfo.strHocKy] = pXL_MonHocTrongKyInfo.HocKy;
			dr[pXL_MonHocTrongKyInfo.strIDDM_NamHoc] = pXL_MonHocTrongKyInfo.IDDM_NamHoc;
			dr[pXL_MonHocTrongKyInfo.strSoTiet] = pXL_MonHocTrongKyInfo.SoTiet;
			dr[pXL_MonHocTrongKyInfo.strLyThuyet] = pXL_MonHocTrongKyInfo.LyThuyet;
			dr[pXL_MonHocTrongKyInfo.strThucHanh] = pXL_MonHocTrongKyInfo.ThucHanh;
			dr[pXL_MonHocTrongKyInfo.strLoaiTietKhac1] = pXL_MonHocTrongKyInfo.LoaiTietKhac1;
			dr[pXL_MonHocTrongKyInfo.strLoaiTietKhac2] = pXL_MonHocTrongKyInfo.LoaiTietKhac2;
			dr[pXL_MonHocTrongKyInfo.strSoHocTrinh] = pXL_MonHocTrongKyInfo.SoHocTrinh;
			dr[pXL_MonHocTrongKyInfo.strChoPhepXepLich] = pXL_MonHocTrongKyInfo.ChoPhepXepLich;
			dr[pXL_MonHocTrongKyInfo.strIDDM_HinhThucThi] = pXL_MonHocTrongKyInfo.IDDM_HinhThucThi;
			dr[pXL_MonHocTrongKyInfo.strSapXep] = pXL_MonHocTrongKyInfo.SapXep;
            dr[pXL_MonHocTrongKyInfo.strTinhDiemToanKhoa] = pXL_MonHocTrongKyInfo.TinhDiemToanKhoa;
        }
    }
}
