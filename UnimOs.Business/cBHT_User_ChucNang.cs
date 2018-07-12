using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBHT_User_ChucNang : cBBase
    {
        private cDHT_User_ChucNang oDHT_User_ChucNang;
        private HT_User_ChucNangInfo oHT_User_ChucNangInfo;

        public cBHT_User_ChucNang()        
        {
            oDHT_User_ChucNang = new cDHT_User_ChucNang();
        }

        public DataTable Get(HT_User_ChucNangInfo pHT_User_ChucNangInfo)        
        {
            return oDHT_User_ChucNang.Get(pHT_User_ChucNangInfo);
        }

        public int Add(HT_User_ChucNangInfo pHT_User_ChucNangInfo)
        {
			int ID = 0;
            ID = oDHT_User_ChucNang.Add(pHT_User_ChucNangInfo);
            mErrorMessage = oDHT_User_ChucNang.ErrorMessages;
            mErrorNumber = oDHT_User_ChucNang.ErrorNumber;
            return ID;
        }

        public void Update(HT_User_ChucNangInfo pHT_User_ChucNangInfo)
        {
            oDHT_User_ChucNang.Update(pHT_User_ChucNangInfo);
            mErrorMessage = oDHT_User_ChucNang.ErrorMessages;
            mErrorNumber = oDHT_User_ChucNang.ErrorNumber;
        }
        
        public void Delete(HT_User_ChucNangInfo pHT_User_ChucNangInfo)
        {
            oDHT_User_ChucNang.Delete(pHT_User_ChucNangInfo);
            mErrorMessage = oDHT_User_ChucNang.ErrorMessages;
            mErrorNumber = oDHT_User_ChucNang.ErrorNumber;
        }

        public void DeleteNotIn(int IDHT_User, string strNotIn)
        {
            oDHT_User_ChucNang.DeleteNotIn(IDHT_User, strNotIn);
            mErrorMessage = oDHT_User_ChucNang.ErrorMessages;
            mErrorNumber = oDHT_User_ChucNang.ErrorNumber;
        }

        public List<HT_User_ChucNangInfo> GetList(HT_User_ChucNangInfo pHT_User_ChucNangInfo)
        {
            List<HT_User_ChucNangInfo> oHT_User_ChucNangInfoList = new List<HT_User_ChucNangInfo>();
            DataTable dtb = Get(pHT_User_ChucNangInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oHT_User_ChucNangInfo = new HT_User_ChucNangInfo();

                    oHT_User_ChucNangInfo.HT_User_ChucNangID = int.Parse(dtb.Rows[i]["HT_User_ChucNangID"].ToString());
                    oHT_User_ChucNangInfo.IDHT_User = int.Parse(dtb.Rows[i]["IDHT_User"].ToString());
                    oHT_User_ChucNangInfo.IDHT_ChucNang = int.Parse(dtb.Rows[i]["IDHT_ChucNang"].ToString());
                    oHT_User_ChucNangInfo.Them = bool.Parse(dtb.Rows[i]["Them"].ToString());
                    oHT_User_ChucNangInfo.Sua = bool.Parse(dtb.Rows[i]["Sua"].ToString());
                    oHT_User_ChucNangInfo.Xoa = bool.Parse(dtb.Rows[i]["Xoa"].ToString());
                    
                    oHT_User_ChucNangInfoList.Add(oHT_User_ChucNangInfo);
                }
            }
            return oHT_User_ChucNangInfoList;
        }
        
        public void ToDataRow(HT_User_ChucNangInfo pHT_User_ChucNangInfo, ref DataRow dr)
        {

			dr[pHT_User_ChucNangInfo.strHT_User_ChucNangID] = pHT_User_ChucNangInfo.HT_User_ChucNangID;
			dr[pHT_User_ChucNangInfo.strIDHT_User] = pHT_User_ChucNangInfo.IDHT_User;
			dr[pHT_User_ChucNangInfo.strIDHT_ChucNang] = pHT_User_ChucNangInfo.IDHT_ChucNang;
			dr[pHT_User_ChucNangInfo.strThem] = pHT_User_ChucNangInfo.Them;
			dr[pHT_User_ChucNangInfo.strSua] = pHT_User_ChucNangInfo.Sua;
			dr[pHT_User_ChucNangInfo.strXoa] = pHT_User_ChucNangInfo.Xoa;
        }
        
        public void ToInfo(ref HT_User_ChucNangInfo pHT_User_ChucNangInfo, DataRow dr)
        {

			pHT_User_ChucNangInfo.HT_User_ChucNangID = int.Parse(dr[pHT_User_ChucNangInfo.strHT_User_ChucNangID].ToString());
			pHT_User_ChucNangInfo.IDHT_User = int.Parse(dr[pHT_User_ChucNangInfo.strIDHT_User].ToString());
			pHT_User_ChucNangInfo.IDHT_ChucNang = int.Parse(dr[pHT_User_ChucNangInfo.strIDHT_ChucNang].ToString());
			pHT_User_ChucNangInfo.Them = bool.Parse(dr[pHT_User_ChucNangInfo.strThem].ToString());
			pHT_User_ChucNangInfo.Sua = bool.Parse(dr[pHT_User_ChucNangInfo.strSua].ToString());
			pHT_User_ChucNangInfo.Xoa = bool.Parse(dr[pHT_User_ChucNangInfo.strXoa].ToString());
        }
    }
}
