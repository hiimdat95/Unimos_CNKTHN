using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBXL_Tuan : cBBase
    {
        private cDXL_Tuan oDXL_Tuan;
        private XL_TuanInfo oXL_TuanInfo;

        public cBXL_Tuan()        
        {
            oDXL_Tuan = new cDXL_Tuan();
        }

        public DataTable Get(XL_TuanInfo pXL_TuanInfo)        
        {
            return oDXL_Tuan.Get(pXL_TuanInfo);
        }

        public DataTable GetByIDNamHoc(XL_TuanInfo pTuanInfo)
        {
            return oDXL_Tuan.GetByIDNamHoc(pTuanInfo);
        }

        public DataTable GetByTuanThu(XL_TuanInfo pTuanInfo)
        {
            return oDXL_Tuan.GetByTuanThu(pTuanInfo);
        }

        public DataTable GetByHocKy_NamHoc(int IDNamHoc, int HocKy)
        {
            return oDXL_Tuan.GetBy_NamHoc_HocKy(IDNamHoc, HocKy);
        }

        public DataTable GetByTuTuan(int IDNamHoc, int HocKy, int TuTuan)
        {
            return oDXL_Tuan.GetByTuanThu(IDNamHoc, HocKy, TuTuan);
        }

        public int Add(XL_TuanInfo pXL_TuanInfo)
        {
			int ID = 0;
            ID = oDXL_Tuan.Add(pXL_TuanInfo);
            mErrorMessage = oDXL_Tuan.ErrorMessages;
            mErrorNumber = oDXL_Tuan.ErrorNumber;
            return ID;
        }

        public void Update(XL_TuanInfo pXL_TuanInfo)
        {
            oDXL_Tuan.Update(pXL_TuanInfo);
            mErrorMessage = oDXL_Tuan.ErrorMessages;
            mErrorNumber = oDXL_Tuan.ErrorNumber;
        }
        
        public void Delete(XL_TuanInfo pXL_TuanInfo)
        {
            oDXL_Tuan.Delete(pXL_TuanInfo);
            mErrorMessage = oDXL_Tuan.ErrorMessages;
            mErrorNumber = oDXL_Tuan.ErrorNumber;
        }

        public void DeleteTuanThua(XL_TuanInfo pTuanInfo)
        {
            oDXL_Tuan.DeleteTuanThua(pTuanInfo);
            mErrorMessage = oDXL_Tuan.ErrorMessages;
            mErrorNumber = oDXL_Tuan.ErrorNumber;
        }

        public List<XL_TuanInfo> GetList(XL_TuanInfo pXL_TuanInfo)
        {
            List<XL_TuanInfo> oXL_TuanInfoList = new List<XL_TuanInfo>();
            DataTable dtb = Get(pXL_TuanInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oXL_TuanInfo = new XL_TuanInfo();
                    

                    oXL_TuanInfo.XL_TuanID = long.Parse(dtb.Rows[i]["XL_TuanID"].ToString());
                    oXL_TuanInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oXL_TuanInfo.TuanThu = int.Parse(dtb.Rows[i]["TuanThu"].ToString());
                    oXL_TuanInfo.TuNgay = DateTime.Parse(dtb.Rows[i]["TuNgay"].ToString());
                    oXL_TuanInfo.DenNgay = DateTime.Parse(dtb.Rows[i]["DenNgay"].ToString());
                    oXL_TuanInfo.ChoPhepXemLich = bool.Parse(dtb.Rows[i]["ChoPhepXemLich"].ToString());
                    
                    oXL_TuanInfoList.Add(oXL_TuanInfo);
                }
            }
            return oXL_TuanInfoList;
        }
    }
}
