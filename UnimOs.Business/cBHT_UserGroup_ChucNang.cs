using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBHT_UserGroup_ChucNang : cBBase
    {
        private cDHT_UserGroup_ChucNang oDHT_UserGroup_ChucNang;
        private HT_UserGroup_ChucNangInfo oHT_UserGroup_ChucNangInfo;

        public cBHT_UserGroup_ChucNang()        
        {
            oDHT_UserGroup_ChucNang = new cDHT_UserGroup_ChucNang();
        }

        public DataTable Get(HT_UserGroup_ChucNangInfo pHT_UserGroup_ChucNangInfo)        
        {
            return oDHT_UserGroup_ChucNang.Get(pHT_UserGroup_ChucNangInfo);
        }

        public int Add(HT_UserGroup_ChucNangInfo pHT_UserGroup_ChucNangInfo)
        {
			int ID = 0;
            ID = oDHT_UserGroup_ChucNang.Add(pHT_UserGroup_ChucNangInfo);
            mErrorMessage = oDHT_UserGroup_ChucNang.ErrorMessages;
            mErrorNumber = oDHT_UserGroup_ChucNang.ErrorNumber;
            return ID;
        }

        public void Update(HT_UserGroup_ChucNangInfo pHT_UserGroup_ChucNangInfo)
        {
            oDHT_UserGroup_ChucNang.Update(pHT_UserGroup_ChucNangInfo);
            mErrorMessage = oDHT_UserGroup_ChucNang.ErrorMessages;
            mErrorNumber = oDHT_UserGroup_ChucNang.ErrorNumber;
        }
        
        public void Delete(HT_UserGroup_ChucNangInfo pHT_UserGroup_ChucNangInfo)
        {
            oDHT_UserGroup_ChucNang.Delete(pHT_UserGroup_ChucNangInfo);
            mErrorMessage = oDHT_UserGroup_ChucNang.ErrorMessages;
            mErrorNumber = oDHT_UserGroup_ChucNang.ErrorNumber;
        }

        public void DeleteNotIn(int IDHT_UserGroup, string strNotIn)
        {
            oDHT_UserGroup_ChucNang.DeleteNotIn(IDHT_UserGroup, strNotIn);
            mErrorMessage = oDHT_UserGroup_ChucNang.ErrorMessages;
            mErrorNumber = oDHT_UserGroup_ChucNang.ErrorNumber;
        }

        public List<HT_UserGroup_ChucNangInfo> GetList(HT_UserGroup_ChucNangInfo pHT_UserGroup_ChucNangInfo)
        {
            List<HT_UserGroup_ChucNangInfo> oHT_UserGroup_ChucNangInfoList = new List<HT_UserGroup_ChucNangInfo>();
            DataTable dtb = Get(pHT_UserGroup_ChucNangInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oHT_UserGroup_ChucNangInfo = new HT_UserGroup_ChucNangInfo();

                    oHT_UserGroup_ChucNangInfo.HT_UserGroup_ChucNangID = int.Parse(dtb.Rows[i]["HT_UserGroup_ChucNangID"].ToString());
                    oHT_UserGroup_ChucNangInfo.IDHT_UserGroup = int.Parse(dtb.Rows[i]["IDHT_UserGroup"].ToString());
                    oHT_UserGroup_ChucNangInfo.IDHT_ChucNang = int.Parse(dtb.Rows[i]["IDHT_ChucNang"].ToString());
                    oHT_UserGroup_ChucNangInfo.Xem = bool.Parse(dtb.Rows[i]["Xem"].ToString());
                    oHT_UserGroup_ChucNangInfo.Sua = bool.Parse(dtb.Rows[i]["Sua"].ToString());
                    oHT_UserGroup_ChucNangInfo.Xoa = bool.Parse(dtb.Rows[i]["Xoa"].ToString());
                    oHT_UserGroup_ChucNangInfo.Them = bool.Parse(dtb.Rows[i]["Them"].ToString());
                    
                    oHT_UserGroup_ChucNangInfoList.Add(oHT_UserGroup_ChucNangInfo);
                }
            }
            return oHT_UserGroup_ChucNangInfoList;
        }
        
        public void ToDataRow(HT_UserGroup_ChucNangInfo pHT_UserGroup_ChucNangInfo, ref DataRow dr)
        {

			dr[pHT_UserGroup_ChucNangInfo.strHT_UserGroup_ChucNangID] = pHT_UserGroup_ChucNangInfo.HT_UserGroup_ChucNangID;
			dr[pHT_UserGroup_ChucNangInfo.strIDHT_UserGroup] = pHT_UserGroup_ChucNangInfo.IDHT_UserGroup;
			dr[pHT_UserGroup_ChucNangInfo.strIDHT_ChucNang] = pHT_UserGroup_ChucNangInfo.IDHT_ChucNang;
			dr[pHT_UserGroup_ChucNangInfo.strXem] = pHT_UserGroup_ChucNangInfo.Xem;
			dr[pHT_UserGroup_ChucNangInfo.strSua] = pHT_UserGroup_ChucNangInfo.Sua;
			dr[pHT_UserGroup_ChucNangInfo.strXoa] = pHT_UserGroup_ChucNangInfo.Xoa;
			dr[pHT_UserGroup_ChucNangInfo.strThem] = pHT_UserGroup_ChucNangInfo.Them;
        }
        
        public void ToInfo(ref HT_UserGroup_ChucNangInfo pHT_UserGroup_ChucNangInfo, DataRow dr)
        {

			pHT_UserGroup_ChucNangInfo.HT_UserGroup_ChucNangID = int.Parse(dr[pHT_UserGroup_ChucNangInfo.strHT_UserGroup_ChucNangID].ToString());
			pHT_UserGroup_ChucNangInfo.IDHT_UserGroup = int.Parse(dr[pHT_UserGroup_ChucNangInfo.strIDHT_UserGroup].ToString());
			pHT_UserGroup_ChucNangInfo.IDHT_ChucNang = int.Parse(dr[pHT_UserGroup_ChucNangInfo.strIDHT_ChucNang].ToString());
			pHT_UserGroup_ChucNangInfo.Xem = bool.Parse(dr[pHT_UserGroup_ChucNangInfo.strXem].ToString());
			pHT_UserGroup_ChucNangInfo.Sua = bool.Parse(dr[pHT_UserGroup_ChucNangInfo.strSua].ToString());
			pHT_UserGroup_ChucNangInfo.Xoa = bool.Parse(dr[pHT_UserGroup_ChucNangInfo.strXoa].ToString());
			pHT_UserGroup_ChucNangInfo.Them = bool.Parse(dr[pHT_UserGroup_ChucNangInfo.strThem].ToString());
        }
    }
}
