using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_LinhVucCongTac : cBBase
    {
        private cDNS_LinhVucCongTac oDNS_LinhVucCongTac;

        public cBNS_LinhVucCongTac()        
        {
            oDNS_LinhVucCongTac = new cDNS_LinhVucCongTac();
        }

        public DataTable Get(NS_LinhVucCongTacInfo pNS_LinhVucCongTacInfo)        
        {
            return oDNS_LinhVucCongTac.Get(pNS_LinhVucCongTacInfo);
        }

        public int Add(NS_LinhVucCongTacInfo pNS_LinhVucCongTacInfo)
        {
			int ID = 0;
            ID = oDNS_LinhVucCongTac.Add(pNS_LinhVucCongTacInfo);
            mErrorMessage = oDNS_LinhVucCongTac.ErrorMessages;
            mErrorNumber = oDNS_LinhVucCongTac.ErrorNumber;
            return ID;
        }

        public void Update(NS_LinhVucCongTacInfo pNS_LinhVucCongTacInfo)
        {
            oDNS_LinhVucCongTac.Update(pNS_LinhVucCongTacInfo);
            mErrorMessage = oDNS_LinhVucCongTac.ErrorMessages;
            mErrorNumber = oDNS_LinhVucCongTac.ErrorNumber;
        }
        
        public void Delete(NS_LinhVucCongTacInfo pNS_LinhVucCongTacInfo)
        {
            oDNS_LinhVucCongTac.Delete(pNS_LinhVucCongTacInfo);
            mErrorMessage = oDNS_LinhVucCongTac.ErrorMessages;
            mErrorNumber = oDNS_LinhVucCongTac.ErrorNumber;
        }

        public List<NS_LinhVucCongTacInfo> GetList(NS_LinhVucCongTacInfo pNS_LinhVucCongTacInfo)
        {
            List<NS_LinhVucCongTacInfo> oNS_LinhVucCongTacInfoList = new List<NS_LinhVucCongTacInfo>();
            DataTable dtb = Get(pNS_LinhVucCongTacInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    pNS_LinhVucCongTacInfo = new NS_LinhVucCongTacInfo();

                    pNS_LinhVucCongTacInfo.NS_LinhVucCongTacID = int.Parse(dtb.Rows[i][pNS_LinhVucCongTacInfo.strNS_LinhVucCongTacID].ToString());
                    pNS_LinhVucCongTacInfo.STT = int.Parse(dtb.Rows[i][pNS_LinhVucCongTacInfo.strSTT].ToString());
                    pNS_LinhVucCongTacInfo.TenLinhVuc = dtb.Rows[i][pNS_LinhVucCongTacInfo.strTenLinhVuc].ToString();
                    
                    oNS_LinhVucCongTacInfoList.Add(pNS_LinhVucCongTacInfo);
                }
            }
            return oNS_LinhVucCongTacInfoList;
        }
        
        public void ToDataRow(NS_LinhVucCongTacInfo pNS_LinhVucCongTacInfo, ref DataRow dr)
        {

			dr[pNS_LinhVucCongTacInfo.strNS_LinhVucCongTacID] = pNS_LinhVucCongTacInfo.NS_LinhVucCongTacID;
			dr[pNS_LinhVucCongTacInfo.strSTT] = pNS_LinhVucCongTacInfo.STT;
			dr[pNS_LinhVucCongTacInfo.strTenLinhVuc] = pNS_LinhVucCongTacInfo.TenLinhVuc;
        }
        
        public void ToInfo(ref NS_LinhVucCongTacInfo pNS_LinhVucCongTacInfo, DataRow dr)
        {

			pNS_LinhVucCongTacInfo.NS_LinhVucCongTacID = int.Parse(dr[pNS_LinhVucCongTacInfo.strNS_LinhVucCongTacID].ToString());
			pNS_LinhVucCongTacInfo.STT = int.Parse(dr[pNS_LinhVucCongTacInfo.strSTT].ToString());
			pNS_LinhVucCongTacInfo.TenLinhVuc = dr[pNS_LinhVucCongTacInfo.strTenLinhVuc].ToString();
        }
    }
}
