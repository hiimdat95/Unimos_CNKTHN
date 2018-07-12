using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBXL_KeHoachThucHanhChiTiet : cBBase
    {
        private cDXL_KeHoachThucHanhChiTiet oDXL_KeHoachThucHanhChiTiet;
        private XL_KeHoachThucHanhChiTietInfo oXL_KeHoachThucHanhChiTietInfo;

        public cBXL_KeHoachThucHanhChiTiet()        
        {
            oDXL_KeHoachThucHanhChiTiet = new cDXL_KeHoachThucHanhChiTiet();
        }

        public DataTable Get(XL_KeHoachThucHanhChiTietInfo pXL_KeHoachThucHanhChiTietInfo)        
        {
            return oDXL_KeHoachThucHanhChiTiet.Get(pXL_KeHoachThucHanhChiTietInfo);
        }

        public DataTable GetByNamHocHocKy(int IDDM_NamHoc, int HocKy)
        {
            return oDXL_KeHoachThucHanhChiTiet.GetByNamHocHocKy(IDDM_NamHoc, HocKy);
        }

        public DataTable GetByIDXL_Tuan(long IDXL_Tuan)
        {
            return oDXL_KeHoachThucHanhChiTiet.GetByIDXL_Tuan(IDXL_Tuan);
        }

        public int Add(XL_KeHoachThucHanhChiTietInfo pXL_KeHoachThucHanhChiTietInfo)
        {
			int ID = 0;
            ID = oDXL_KeHoachThucHanhChiTiet.Add(pXL_KeHoachThucHanhChiTietInfo);
            mErrorMessage = oDXL_KeHoachThucHanhChiTiet.ErrorMessages;
            mErrorNumber = oDXL_KeHoachThucHanhChiTiet.ErrorNumber;
            return ID;
        }

        public void Update(XL_KeHoachThucHanhChiTietInfo pXL_KeHoachThucHanhChiTietInfo)
        {
            oDXL_KeHoachThucHanhChiTiet.Update(pXL_KeHoachThucHanhChiTietInfo);
            mErrorMessage = oDXL_KeHoachThucHanhChiTiet.ErrorMessages;
            mErrorNumber = oDXL_KeHoachThucHanhChiTiet.ErrorNumber;
        }
        
        public void Delete(XL_KeHoachThucHanhChiTietInfo pXL_KeHoachThucHanhChiTietInfo)
        {
            oDXL_KeHoachThucHanhChiTiet.Delete(pXL_KeHoachThucHanhChiTietInfo);
            mErrorMessage = oDXL_KeHoachThucHanhChiTiet.ErrorMessages;
            mErrorNumber = oDXL_KeHoachThucHanhChiTiet.ErrorNumber;
        }

        public List<XL_KeHoachThucHanhChiTietInfo> GetList(XL_KeHoachThucHanhChiTietInfo pXL_KeHoachThucHanhChiTietInfo)
        {
            List<XL_KeHoachThucHanhChiTietInfo> oXL_KeHoachThucHanhChiTietInfoList = new List<XL_KeHoachThucHanhChiTietInfo>();
            DataTable dtb = Get(pXL_KeHoachThucHanhChiTietInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oXL_KeHoachThucHanhChiTietInfo = new XL_KeHoachThucHanhChiTietInfo();

                    oXL_KeHoachThucHanhChiTietInfo.XL_KeHoachThucHanhChiTietID = long.Parse(dtb.Rows[i]["XL_KeHoachThucHanhChiTietID"].ToString());
                    oXL_KeHoachThucHanhChiTietInfo.IDXL_KeHoachThucHanh = int.Parse(dtb.Rows[i]["IDXL_KeHoachThucHanh"].ToString());
                    oXL_KeHoachThucHanhChiTietInfo.IDXL_Tuan = long.Parse(dtb.Rows[i]["IDXL_Tuan"].ToString());
                    oXL_KeHoachThucHanhChiTietInfo.CaHoc = int.Parse(dtb.Rows[i]["CaHoc"].ToString());
                    oXL_KeHoachThucHanhChiTietInfo.ToThucHanh = int.Parse(dtb.Rows[i]["ToThucHanh"].ToString());
                    oXL_KeHoachThucHanhChiTietInfo.NgayThucHanh = DateTime.Parse(dtb.Rows[i]["NgayThucHanh"].ToString());
                    
                    oXL_KeHoachThucHanhChiTietInfoList.Add(oXL_KeHoachThucHanhChiTietInfo);
                }
            }
            return oXL_KeHoachThucHanhChiTietInfoList;
        }
        
        public void ToDataRow(XL_KeHoachThucHanhChiTietInfo pXL_KeHoachThucHanhChiTietInfo, ref DataRow dr)
        {

			dr[pXL_KeHoachThucHanhChiTietInfo.strXL_KeHoachThucHanhChiTietID] = pXL_KeHoachThucHanhChiTietInfo.XL_KeHoachThucHanhChiTietID;
			dr[pXL_KeHoachThucHanhChiTietInfo.strIDXL_KeHoachThucHanh] = pXL_KeHoachThucHanhChiTietInfo.IDXL_KeHoachThucHanh;
			dr[pXL_KeHoachThucHanhChiTietInfo.strIDXL_Tuan] = pXL_KeHoachThucHanhChiTietInfo.IDXL_Tuan;
			dr[pXL_KeHoachThucHanhChiTietInfo.strCaHoc] = pXL_KeHoachThucHanhChiTietInfo.CaHoc;
			dr[pXL_KeHoachThucHanhChiTietInfo.strToThucHanh] = pXL_KeHoachThucHanhChiTietInfo.ToThucHanh;
			dr[pXL_KeHoachThucHanhChiTietInfo.strNgayThucHanh] = pXL_KeHoachThucHanhChiTietInfo.NgayThucHanh;
        }
        
        public void ToInfo(ref XL_KeHoachThucHanhChiTietInfo pXL_KeHoachThucHanhChiTietInfo, DataRow dr)
        {

			pXL_KeHoachThucHanhChiTietInfo.XL_KeHoachThucHanhChiTietID = long.Parse(dr[pXL_KeHoachThucHanhChiTietInfo.strXL_KeHoachThucHanhChiTietID].ToString());
			pXL_KeHoachThucHanhChiTietInfo.IDXL_KeHoachThucHanh = int.Parse(dr[pXL_KeHoachThucHanhChiTietInfo.strIDXL_KeHoachThucHanh].ToString());
			pXL_KeHoachThucHanhChiTietInfo.IDXL_Tuan = long.Parse(dr[pXL_KeHoachThucHanhChiTietInfo.strIDXL_Tuan].ToString());
			pXL_KeHoachThucHanhChiTietInfo.CaHoc = int.Parse(dr[pXL_KeHoachThucHanhChiTietInfo.strCaHoc].ToString());
			pXL_KeHoachThucHanhChiTietInfo.ToThucHanh = int.Parse(dr[pXL_KeHoachThucHanhChiTietInfo.strToThucHanh].ToString());
			pXL_KeHoachThucHanhChiTietInfo.NgayThucHanh = DateTime.Parse(dr[pXL_KeHoachThucHanhChiTietInfo.strNgayThucHanh].ToString());
        }
    }
}
