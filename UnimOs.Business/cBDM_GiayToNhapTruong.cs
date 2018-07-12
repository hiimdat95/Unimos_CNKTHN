using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_GiayToNhapTruong : cBBase
    {
        private cDDM_GiayToNhapTruong oDDM_GiayToNhapTruong;
        private DM_GiayToNhapTruongInfo oDM_GiayToNhapTruongInfo;

        public cBDM_GiayToNhapTruong()        
        {
            oDDM_GiayToNhapTruong = new cDDM_GiayToNhapTruong();
        }

        public DataTable Get(DM_GiayToNhapTruongInfo pDM_GiayToNhapTruongInfo)        
        {
            return oDDM_GiayToNhapTruong.Get(pDM_GiayToNhapTruongInfo);
        }

        public int Add(DM_GiayToNhapTruongInfo pDM_GiayToNhapTruongInfo)
        {
			int ID = 0;
            ID = oDDM_GiayToNhapTruong.Add(pDM_GiayToNhapTruongInfo);
            mErrorMessage = oDDM_GiayToNhapTruong.ErrorMessages;
            mErrorNumber = oDDM_GiayToNhapTruong.ErrorNumber;
            return ID;
        }

        public void Update(DM_GiayToNhapTruongInfo pDM_GiayToNhapTruongInfo)
        {
            oDDM_GiayToNhapTruong.Update(pDM_GiayToNhapTruongInfo);
            mErrorMessage = oDDM_GiayToNhapTruong.ErrorMessages;
            mErrorNumber = oDDM_GiayToNhapTruong.ErrorNumber;
        }
        
        public void Delete(DM_GiayToNhapTruongInfo pDM_GiayToNhapTruongInfo)
        {
            oDDM_GiayToNhapTruong.Delete(pDM_GiayToNhapTruongInfo);
            mErrorMessage = oDDM_GiayToNhapTruong.ErrorMessages;
            mErrorNumber = oDDM_GiayToNhapTruong.ErrorNumber;
        }

        public List<DM_GiayToNhapTruongInfo> GetList(DM_GiayToNhapTruongInfo pDM_GiayToNhapTruongInfo)
        {
            List<DM_GiayToNhapTruongInfo> oDM_GiayToNhapTruongInfoList = new List<DM_GiayToNhapTruongInfo>();
            DataTable dtb = Get(pDM_GiayToNhapTruongInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_GiayToNhapTruongInfo = new DM_GiayToNhapTruongInfo();

                    oDM_GiayToNhapTruongInfo.DM_GiayToNhapTruongID = int.Parse(dtb.Rows[i]["DM_GiayToNhapTruongID"].ToString());
                    oDM_GiayToNhapTruongInfo.TenGiayTo = dtb.Rows[i]["TenGiayTo"].ToString();
                    
                    oDM_GiayToNhapTruongInfoList.Add(oDM_GiayToNhapTruongInfo);
                }
            }
            return oDM_GiayToNhapTruongInfoList;
        }
        
        public void ToDataRow(DM_GiayToNhapTruongInfo pDM_GiayToNhapTruongInfo, ref DataRow dr)
        {

			dr[pDM_GiayToNhapTruongInfo.strDM_GiayToNhapTruongID] = pDM_GiayToNhapTruongInfo.DM_GiayToNhapTruongID;
			dr[pDM_GiayToNhapTruongInfo.strTenGiayTo] = pDM_GiayToNhapTruongInfo.TenGiayTo;
        }
        
        public void ToInfo(ref DM_GiayToNhapTruongInfo pDM_GiayToNhapTruongInfo, DataRow dr)
        {

			pDM_GiayToNhapTruongInfo.DM_GiayToNhapTruongID = int.Parse(dr[pDM_GiayToNhapTruongInfo.strDM_GiayToNhapTruongID].ToString());
			pDM_GiayToNhapTruongInfo.TenGiayTo = dr[pDM_GiayToNhapTruongInfo.strTenGiayTo].ToString();
        }
    }
}
