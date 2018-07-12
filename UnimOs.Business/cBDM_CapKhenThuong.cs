using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_CapKhenThuong : cBBase
    {
        private cDDM_CapKhenThuong oDDM_CapKhenThuong;
        private DM_CapKhenThuongInfo oDM_CapKhenThuongInfo;

        public cBDM_CapKhenThuong()        
        {
            oDDM_CapKhenThuong = new cDDM_CapKhenThuong();
        }

        public DataTable Get(DM_CapKhenThuongInfo pDM_CapKhenThuongInfo)        
        {
            return oDDM_CapKhenThuong.Get(pDM_CapKhenThuongInfo);
        }

        public int Add(DM_CapKhenThuongInfo pDM_CapKhenThuongInfo)
        {
			int ID = 0;
            ID = oDDM_CapKhenThuong.Add(pDM_CapKhenThuongInfo);
            mErrorMessage = oDDM_CapKhenThuong.ErrorMessages;
            mErrorNumber = oDDM_CapKhenThuong.ErrorNumber;
            return ID;
        }

        public void Update(DM_CapKhenThuongInfo pDM_CapKhenThuongInfo)
        {
            oDDM_CapKhenThuong.Update(pDM_CapKhenThuongInfo);
            mErrorMessage = oDDM_CapKhenThuong.ErrorMessages;
            mErrorNumber = oDDM_CapKhenThuong.ErrorNumber;
        }
        
        public void Delete(DM_CapKhenThuongInfo pDM_CapKhenThuongInfo)
        {
            oDDM_CapKhenThuong.Delete(pDM_CapKhenThuongInfo);
            mErrorMessage = oDDM_CapKhenThuong.ErrorMessages;
            mErrorNumber = oDDM_CapKhenThuong.ErrorNumber;
        }

        public List<DM_CapKhenThuongInfo> GetList(DM_CapKhenThuongInfo pDM_CapKhenThuongInfo)
        {
            List<DM_CapKhenThuongInfo> oDM_CapKhenThuongInfoList = new List<DM_CapKhenThuongInfo>();
            DataTable dtb = Get(pDM_CapKhenThuongInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_CapKhenThuongInfo = new DM_CapKhenThuongInfo();

                    oDM_CapKhenThuongInfo.DM_CapKhenThuongID = int.Parse(dtb.Rows[i]["DM_CapKhenThuongID"].ToString());
                    oDM_CapKhenThuongInfo.TenCapKhenThuong = dtb.Rows[i]["TenCapKhenThuong"].ToString();
                    
                    oDM_CapKhenThuongInfoList.Add(oDM_CapKhenThuongInfo);
                }
            }
            return oDM_CapKhenThuongInfoList;
        }
        
        public void ToDataRow(DM_CapKhenThuongInfo pDM_CapKhenThuongInfo, ref DataRow dr)
        {

			dr[pDM_CapKhenThuongInfo.strDM_CapKhenThuongID] = pDM_CapKhenThuongInfo.DM_CapKhenThuongID;
			dr[pDM_CapKhenThuongInfo.strTenCapKhenThuong] = pDM_CapKhenThuongInfo.TenCapKhenThuong;
        }
        
        public void ToInfo(ref DM_CapKhenThuongInfo pDM_CapKhenThuongInfo, DataRow dr)
        {

			pDM_CapKhenThuongInfo.DM_CapKhenThuongID = int.Parse(dr[pDM_CapKhenThuongInfo.strDM_CapKhenThuongID].ToString());
			pDM_CapKhenThuongInfo.TenCapKhenThuong = dr[pDM_CapKhenThuongInfo.strTenCapKhenThuong].ToString();
        }
    }
}
