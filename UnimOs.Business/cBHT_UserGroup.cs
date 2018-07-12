using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBHT_UserGroup : cBBase
    {
        private cDHT_UserGroup oDHT_UserGroup;
        private HT_UserGroupInfo oHT_UserGroupInfo;

        public cBHT_UserGroup()        
        {
            oDHT_UserGroup = new cDHT_UserGroup();
        }

        public DataTable Get(HT_UserGroupInfo pHT_UserGroupInfo)        
        {
            return oDHT_UserGroup.Get(pHT_UserGroupInfo);
        }

        public int Add(HT_UserGroupInfo pHT_UserGroupInfo)
        {
			int ID = 0;
            ID = oDHT_UserGroup.Add(pHT_UserGroupInfo);
            mErrorMessage = oDHT_UserGroup.ErrorMessages;
            mErrorNumber = oDHT_UserGroup.ErrorNumber;
            return ID;
        }

        public void Update(HT_UserGroupInfo pHT_UserGroupInfo)
        {
            oDHT_UserGroup.Update(pHT_UserGroupInfo);
            mErrorMessage = oDHT_UserGroup.ErrorMessages;
            mErrorNumber = oDHT_UserGroup.ErrorNumber;
        }
        
        public void Delete(HT_UserGroupInfo pHT_UserGroupInfo)
        {
            oDHT_UserGroup.Delete(pHT_UserGroupInfo);
            mErrorMessage = oDHT_UserGroup.ErrorMessages;
            mErrorNumber = oDHT_UserGroup.ErrorNumber;
        }

        public List<HT_UserGroupInfo> GetList(HT_UserGroupInfo pHT_UserGroupInfo)
        {
            List<HT_UserGroupInfo> oHT_UserGroupInfoList = new List<HT_UserGroupInfo>();
            DataTable dtb = Get(pHT_UserGroupInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oHT_UserGroupInfo = new HT_UserGroupInfo();

                    oHT_UserGroupInfo.HT_UserGroupID = int.Parse(dtb.Rows[i]["HT_UserGroupID"].ToString());
                    oHT_UserGroupInfo.TenNhom = dtb.Rows[i]["TenNhom"].ToString();
                    
                    oHT_UserGroupInfoList.Add(oHT_UserGroupInfo);
                }
            }
            return oHT_UserGroupInfoList;
        }
        
        public void ToDataRow(HT_UserGroupInfo pHT_UserGroupInfo, ref DataRow dr)
        {

			dr[pHT_UserGroupInfo.strHT_UserGroupID] = pHT_UserGroupInfo.HT_UserGroupID;
			dr[pHT_UserGroupInfo.strTenNhom] = pHT_UserGroupInfo.TenNhom;
        }
        
        public void ToInfo(ref HT_UserGroupInfo pHT_UserGroupInfo, DataRow dr)
        {

			pHT_UserGroupInfo.HT_UserGroupID = int.Parse(dr[pHT_UserGroupInfo.strHT_UserGroupID].ToString());
			pHT_UserGroupInfo.TenNhom = dr[pHT_UserGroupInfo.strTenNhom].ToString();
        }
    }
}
