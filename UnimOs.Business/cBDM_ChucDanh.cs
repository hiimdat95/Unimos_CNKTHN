using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_ChucDanh : cBBase
    {
        private cDDM_ChucDanh oDDM_ChucDanh;
        private DM_ChucDanhInfo oDM_ChucDanhInfo;

        public cBDM_ChucDanh()        
        {
            oDDM_ChucDanh = new cDDM_ChucDanh();
        }

        public DataTable Get(DM_ChucDanhInfo pDM_ChucDanhInfo)        
        {
            return oDDM_ChucDanh.Get(pDM_ChucDanhInfo);
        }

        public DataTable GetChucDanhChuaDinhMuc()
        {
            return oDDM_ChucDanh.GetChucDanhChuaDinhMuc();
        }

        public int Add(DM_ChucDanhInfo pDM_ChucDanhInfo)
        {
			int ID = 0;
            ID = oDDM_ChucDanh.Add(pDM_ChucDanhInfo);
            mErrorMessage = oDDM_ChucDanh.ErrorMessages;
            mErrorNumber = oDDM_ChucDanh.ErrorNumber;
            return ID;
        }

        public void Update(DM_ChucDanhInfo pDM_ChucDanhInfo)
        {
            oDDM_ChucDanh.Update(pDM_ChucDanhInfo);
            mErrorMessage = oDDM_ChucDanh.ErrorMessages;
            mErrorNumber = oDDM_ChucDanh.ErrorNumber;
        }
        
        public void Delete(DM_ChucDanhInfo pDM_ChucDanhInfo)
        {
            oDDM_ChucDanh.Delete(pDM_ChucDanhInfo);
            mErrorMessage = oDDM_ChucDanh.ErrorMessages;
            mErrorNumber = oDDM_ChucDanh.ErrorNumber;
        }

        public List<DM_ChucDanhInfo> GetList(DM_ChucDanhInfo pDM_ChucDanhInfo)
        {
            List<DM_ChucDanhInfo> oDM_ChucDanhInfoList = new List<DM_ChucDanhInfo>();
            DataTable dtb = Get(pDM_ChucDanhInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_ChucDanhInfo = new DM_ChucDanhInfo();

                    oDM_ChucDanhInfo.DM_ChucDanhID = int.Parse(dtb.Rows[i]["DM_ChucDanhID"].ToString());
                    oDM_ChucDanhInfo.TenChucDanh = dtb.Rows[i]["TenChucDanh"].ToString();
                    
                    oDM_ChucDanhInfoList.Add(oDM_ChucDanhInfo);
                }
            }
            return oDM_ChucDanhInfoList;
        }
        
        public void ToDataRow(DM_ChucDanhInfo pDM_ChucDanhInfo, ref DataRow dr)
        {

			dr[pDM_ChucDanhInfo.strDM_ChucDanhID] = pDM_ChucDanhInfo.DM_ChucDanhID;
			dr[pDM_ChucDanhInfo.strTenChucDanh] = pDM_ChucDanhInfo.TenChucDanh;
        }
        
        public void ToInfo(ref DM_ChucDanhInfo pDM_ChucDanhInfo, DataRow dr)
        {

			pDM_ChucDanhInfo.DM_ChucDanhID = int.Parse(dr[pDM_ChucDanhInfo.strDM_ChucDanhID].ToString());
			pDM_ChucDanhInfo.TenChucDanh = dr[pDM_ChucDanhInfo.strTenChucDanh].ToString();
        }
    }
}
