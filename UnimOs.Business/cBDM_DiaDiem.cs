using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_DiaDiem : cBBase
    {
        private cDDM_DiaDiem oDDM_DiaDiem;
        private DM_DiaDiemInfo oDM_DiaDiemInfo;

        public cBDM_DiaDiem()        
        {
            oDDM_DiaDiem = new cDDM_DiaDiem();
        }

        public DataTable Get(DM_DiaDiemInfo pDM_DiaDiemInfo)        
        {
            return oDDM_DiaDiem.Get(pDM_DiaDiemInfo);
        }

        public int Add(DM_DiaDiemInfo pDM_DiaDiemInfo)
        {
			int ID = 0;
            ID = oDDM_DiaDiem.Add(pDM_DiaDiemInfo);
            mErrorMessage = oDDM_DiaDiem.ErrorMessages;
            mErrorNumber = oDDM_DiaDiem.ErrorNumber;
            return ID;
        }

        public void Update(DM_DiaDiemInfo pDM_DiaDiemInfo)
        {
            oDDM_DiaDiem.Update(pDM_DiaDiemInfo);
            mErrorMessage = oDDM_DiaDiem.ErrorMessages;
            mErrorNumber = oDDM_DiaDiem.ErrorNumber;
        }
        
        public void Delete(DM_DiaDiemInfo pDM_DiaDiemInfo)
        {
            oDDM_DiaDiem.Delete(pDM_DiaDiemInfo);
            mErrorMessage = oDDM_DiaDiem.ErrorMessages;
            mErrorNumber = oDDM_DiaDiem.ErrorNumber;
        }

        public List<DM_DiaDiemInfo> GetList(DM_DiaDiemInfo pDM_DiaDiemInfo)
        {
            List<DM_DiaDiemInfo> oDM_DiaDiemInfoList = new List<DM_DiaDiemInfo>();
            DataTable dtb = Get(pDM_DiaDiemInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_DiaDiemInfo = new DM_DiaDiemInfo();

                    oDM_DiaDiemInfo.DM_DiaDiemID = int.Parse(dtb.Rows[i]["DM_DiaDiemID"].ToString());
                    oDM_DiaDiemInfo.MaDiaDiem = dtb.Rows[i]["MaDiaDiem"].ToString();
                    oDM_DiaDiemInfo.TenDiaDiem = dtb.Rows[i]["TenDiaDiem"].ToString();
                    
                    oDM_DiaDiemInfoList.Add(oDM_DiaDiemInfo);
                }
            }
            return oDM_DiaDiemInfoList;
        }
        
        public void ToDataRow(DM_DiaDiemInfo pDM_DiaDiemInfo, ref DataRow dr)
        {
			dr[pDM_DiaDiemInfo.strDM_DiaDiemID] = pDM_DiaDiemInfo.DM_DiaDiemID;
			dr[pDM_DiaDiemInfo.strMaDiaDiem] = pDM_DiaDiemInfo.MaDiaDiem;
			dr[pDM_DiaDiemInfo.strTenDiaDiem] = pDM_DiaDiemInfo.TenDiaDiem;
            dr[pDM_DiaDiemInfo.strMoTa] = pDM_DiaDiemInfo.MoTa;
        }
    }
}
