using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBXL_KeHoachTruong : cBBase
    {
        private cDXL_KeHoachTruong oDXL_KeHoachTruong;
        private XL_KeHoachTruongInfo oXL_KeHoachTruongInfo;

        public cBXL_KeHoachTruong()        
        {
            oDXL_KeHoachTruong = new cDXL_KeHoachTruong();
        }

        public DataTable Get(XL_KeHoachTruongInfo pXL_KeHoachTruongInfo)        
        {
            return oDXL_KeHoachTruong.Get(pXL_KeHoachTruongInfo);
        }

        public DataTable GetByIDTuan(long IDTuan)
        {
            return oDXL_KeHoachTruong.GetByIDTuan(IDTuan);
        }

        public int Add(XL_KeHoachTruongInfo pXL_KeHoachTruongInfo)
        {
			int ID = 0;
            ID = oDXL_KeHoachTruong.Add(pXL_KeHoachTruongInfo);
            mErrorMessage = oDXL_KeHoachTruong.ErrorMessages;
            mErrorNumber = oDXL_KeHoachTruong.ErrorNumber;
            return ID;
        }

        public void Update(XL_KeHoachTruongInfo pXL_KeHoachTruongInfo)
        {
            oDXL_KeHoachTruong.Update(pXL_KeHoachTruongInfo);
            mErrorMessage = oDXL_KeHoachTruong.ErrorMessages;
            mErrorNumber = oDXL_KeHoachTruong.ErrorNumber;
        }
        public int CheckAddPhongHoc(long IDXL_TuTuan, long IDXL_DenTuan, int IDDM_PhongHoc, int IDDM_Lop, int CaHoc)
        {
            return oDXL_KeHoachTruong.CheckAddPhongHoc(IDXL_TuTuan, IDXL_DenTuan, IDDM_PhongHoc, IDDM_Lop, CaHoc);
        }

        public void UpdatePhongHoc(long IDXL_TuTuan, long IDXL_DenTuan, int IDDM_PhongHoc, int IDDM_Lop)
        {
            oDXL_KeHoachTruong.UpdatePhongHoc(IDXL_TuTuan, IDXL_DenTuan, IDDM_PhongHoc, IDDM_Lop);
            mErrorMessage = oDXL_KeHoachTruong.ErrorMessages;
            mErrorNumber = oDXL_KeHoachTruong.ErrorNumber;
        }
        
        public void Delete(XL_KeHoachTruongInfo pXL_KeHoachTruongInfo)
        {
            oDXL_KeHoachTruong.Delete(pXL_KeHoachTruongInfo);
            mErrorMessage = oDXL_KeHoachTruong.ErrorMessages;
            mErrorNumber = oDXL_KeHoachTruong.ErrorNumber;
        }

        public List<XL_KeHoachTruongInfo> GetList(XL_KeHoachTruongInfo pXL_KeHoachTruongInfo)
        {
            List<XL_KeHoachTruongInfo> oXL_KeHoachTruongInfoList = new List<XL_KeHoachTruongInfo>();
            DataTable dtb = Get(pXL_KeHoachTruongInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oXL_KeHoachTruongInfo = new XL_KeHoachTruongInfo();
                    

                    oXL_KeHoachTruongInfo.XL_KeHoachTruongID = int.Parse(dtb.Rows[i]["XL_KeHoachTruongID"].ToString());
                    oXL_KeHoachTruongInfo.IDXL_Tuan = long.Parse(dtb.Rows[i]["IDXL_Tuan"].ToString());
                    oXL_KeHoachTruongInfo.IDDM_Lop = int.Parse(dtb.Rows[i]["IDDM_Lop"].ToString());
                    oXL_KeHoachTruongInfo.CaHoc = int.Parse(dtb.Rows[i]["CaHoc"].ToString());
                    oXL_KeHoachTruongInfo.IDDM_PhongHoc = int.Parse(dtb.Rows[i]["IDDM_PhongHoc"].ToString());
                    oXL_KeHoachTruongInfo.IDXL_KeHoachKhac = int.Parse(dtb.Rows[i]["IDXL_KeHoachKhac"].ToString());
                    oXL_KeHoachTruongInfo.NgayNghi = dtb.Rows[i]["NgayNghi"].ToString();
                    
                    oXL_KeHoachTruongInfoList.Add(oXL_KeHoachTruongInfo);
                }
            }
            return oXL_KeHoachTruongInfoList;
        }
    }
}
