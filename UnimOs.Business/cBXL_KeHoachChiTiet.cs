using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBXL_KeHoachChiTiet : cBBase
    {
        private cDXL_KeHoachChiTiet oDXL_KeHoachChiTiet;
        private XL_KeHoachChiTietInfo oXL_KeHoachChiTietInfo;

        public cBXL_KeHoachChiTiet()        
        {
            oDXL_KeHoachChiTiet = new cDXL_KeHoachChiTiet();
        }

        public DataTable Get(XL_KeHoachChiTietInfo pXL_KeHoachChiTietInfo)        
        {
            return oDXL_KeHoachChiTiet.Get(pXL_KeHoachChiTietInfo);
        }

        public DataTable Get_SuKienTKB(long IDXL_Tuan)
        {
            return oDXL_KeHoachChiTiet.Get_SuKienTKB(IDXL_Tuan);
        }

        public DataTable GetKeHoachByLop(int IDDM_NamHoc, int HocKy, int IDDM_Lop)
        {
            return oDXL_KeHoachChiTiet.GetKeHoachByLop(IDDM_NamHoc, HocKy, IDDM_Lop);
        }

        public DataTable GetChiTietGV(int IDNS_GiaoVien, int IDDM_NamHoc, int HocKy)
        {
            return oDXL_KeHoachChiTiet.GetChiTietGV(IDNS_GiaoVien, IDDM_NamHoc, HocKy);
        }

        public int Add(XL_KeHoachChiTietInfo pXL_KeHoachChiTietInfo)
        {
			int ID = 0;
            ID = oDXL_KeHoachChiTiet.Add(pXL_KeHoachChiTietInfo);
            mErrorMessage = oDXL_KeHoachChiTiet.ErrorMessages;
            mErrorNumber = oDXL_KeHoachChiTiet.ErrorNumber;
            return ID;
        }

        public void Update(XL_KeHoachChiTietInfo pXL_KeHoachChiTietInfo)
        {
            oDXL_KeHoachChiTiet.Update(pXL_KeHoachChiTietInfo);
            mErrorMessage = oDXL_KeHoachChiTiet.ErrorMessages;
            mErrorNumber = oDXL_KeHoachChiTiet.ErrorNumber;
        }
        
        public void Delete(XL_KeHoachChiTietInfo pXL_KeHoachChiTietInfo)
        {
            oDXL_KeHoachChiTiet.Delete(pXL_KeHoachChiTietInfo);
            mErrorMessage = oDXL_KeHoachChiTiet.ErrorMessages;
            mErrorNumber = oDXL_KeHoachChiTiet.ErrorNumber;
        }

        public List<XL_KeHoachChiTietInfo> GetList(XL_KeHoachChiTietInfo pXL_KeHoachChiTietInfo)
        {
            List<XL_KeHoachChiTietInfo> oXL_KeHoachChiTietInfoList = new List<XL_KeHoachChiTietInfo>();
            DataTable dtb = Get(pXL_KeHoachChiTietInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oXL_KeHoachChiTietInfo = new XL_KeHoachChiTietInfo();

                    oXL_KeHoachChiTietInfo.XL_KeHoachChiTietID = long.Parse(dtb.Rows[i]["XL_KeHoachChiTietID"].ToString());
                    oXL_KeHoachChiTietInfo.IDXL_Tuan = long.Parse(dtb.Rows[i]["IDXL_Tuan"].ToString());
                    oXL_KeHoachChiTietInfo.IDDM_Lop = int.Parse(dtb.Rows[i]["IDDM_Lop"].ToString());
                    oXL_KeHoachChiTietInfo.IDXL_LopTachGop = int.Parse(dtb.Rows[i]["IDXL_LopTachGop"].ToString());
                    oXL_KeHoachChiTietInfo.IDXL_MonHocTrongKy = int.Parse(dtb.Rows[i]["IDXL_MonHocTrongKy"].ToString());
                    oXL_KeHoachChiTietInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
                    oXL_KeHoachChiTietInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oXL_KeHoachChiTietInfo.SoTiet = int.Parse(dtb.Rows[i]["SoTiet"].ToString());
                    oXL_KeHoachChiTietInfo.LoaiTiet = int.Parse(dtb.Rows[i]["LoaiTiet"].ToString());
                    oXL_KeHoachChiTietInfo.GhiChu = dtb.Rows[i]["GhiChu"].ToString();
                    
                    oXL_KeHoachChiTietInfoList.Add(oXL_KeHoachChiTietInfo);
                }
            }
            return oXL_KeHoachChiTietInfoList;
        }
        
        public void ToDataRow(XL_KeHoachChiTietInfo pXL_KeHoachChiTietInfo, ref DataRow dr)
        {

			dr[pXL_KeHoachChiTietInfo.strXL_KeHoachChiTietID] = pXL_KeHoachChiTietInfo.XL_KeHoachChiTietID;
			dr[pXL_KeHoachChiTietInfo.strIDXL_Tuan] = pXL_KeHoachChiTietInfo.IDXL_Tuan;
			dr[pXL_KeHoachChiTietInfo.strIDDM_Lop] = pXL_KeHoachChiTietInfo.IDDM_Lop;
			dr[pXL_KeHoachChiTietInfo.strIDXL_LopTachGop] = pXL_KeHoachChiTietInfo.IDXL_LopTachGop;
			dr[pXL_KeHoachChiTietInfo.strIDXL_MonHocTrongKy] = pXL_KeHoachChiTietInfo.IDXL_MonHocTrongKy;
			dr[pXL_KeHoachChiTietInfo.strIDDM_MonHoc] = pXL_KeHoachChiTietInfo.IDDM_MonHoc;
			dr[pXL_KeHoachChiTietInfo.strIDNS_GiaoVien] = pXL_KeHoachChiTietInfo.IDNS_GiaoVien;
			dr[pXL_KeHoachChiTietInfo.strSoTiet] = pXL_KeHoachChiTietInfo.SoTiet;
			dr[pXL_KeHoachChiTietInfo.strLoaiTiet] = pXL_KeHoachChiTietInfo.LoaiTiet;
			dr[pXL_KeHoachChiTietInfo.strGhiChu] = pXL_KeHoachChiTietInfo.GhiChu;
        }
        
        public void ToInfo(ref XL_KeHoachChiTietInfo pXL_KeHoachChiTietInfo, DataRow dr)
        {

			pXL_KeHoachChiTietInfo.XL_KeHoachChiTietID = long.Parse(dr[pXL_KeHoachChiTietInfo.strXL_KeHoachChiTietID].ToString());
			pXL_KeHoachChiTietInfo.IDXL_Tuan = long.Parse(dr[pXL_KeHoachChiTietInfo.strIDXL_Tuan].ToString());
			pXL_KeHoachChiTietInfo.IDDM_Lop = int.Parse(dr[pXL_KeHoachChiTietInfo.strIDDM_Lop].ToString());
			pXL_KeHoachChiTietInfo.IDXL_LopTachGop = int.Parse(dr[pXL_KeHoachChiTietInfo.strIDXL_LopTachGop].ToString());
			pXL_KeHoachChiTietInfo.IDXL_MonHocTrongKy = int.Parse(dr[pXL_KeHoachChiTietInfo.strIDXL_MonHocTrongKy].ToString());
			pXL_KeHoachChiTietInfo.IDDM_MonHoc = int.Parse(dr[pXL_KeHoachChiTietInfo.strIDDM_MonHoc].ToString());
			pXL_KeHoachChiTietInfo.IDNS_GiaoVien = int.Parse(dr[pXL_KeHoachChiTietInfo.strIDNS_GiaoVien].ToString());
			pXL_KeHoachChiTietInfo.SoTiet = int.Parse(dr[pXL_KeHoachChiTietInfo.strSoTiet].ToString());
			pXL_KeHoachChiTietInfo.LoaiTiet = int.Parse(dr[pXL_KeHoachChiTietInfo.strLoaiTiet].ToString());
			pXL_KeHoachChiTietInfo.GhiChu = dr[pXL_KeHoachChiTietInfo.strGhiChu].ToString();
        }
    }
}
