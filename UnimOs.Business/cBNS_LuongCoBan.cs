using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_LuongCoBan : cBBase
    {
        private cDNS_LuongCoBan oDNS_LuongCoBan;
        private NS_LuongCoBanInfo oNS_LuongCoBanInfo;

        public cBNS_LuongCoBan()        
        {
            oDNS_LuongCoBan = new cDNS_LuongCoBan();
        }

        public DataTable Get(NS_LuongCoBanInfo pNS_LuongCoBanInfo)        
        {
            return oDNS_LuongCoBan.Get(pNS_LuongCoBanInfo);
        }

        public DataTable Get_DenNgayInfo()        
        {
            return oDNS_LuongCoBan.Get_DenNgayInfo();
        }

        public int Add(NS_LuongCoBanInfo pNS_LuongCoBanInfo)
        {
			int ID = 0;
            ID = oDNS_LuongCoBan.Add(pNS_LuongCoBanInfo);
            mErrorMessage = oDNS_LuongCoBan.ErrorMessages;
            mErrorNumber = oDNS_LuongCoBan.ErrorNumber;
            return ID;
        }

        public int Add_Update(NS_LuongCoBanInfo pNS_LuongCoBanInfo)
        {
            int ID = 0;
            ID = oDNS_LuongCoBan.Add_Update(pNS_LuongCoBanInfo);
            mErrorMessage = oDNS_LuongCoBan.ErrorMessages;
            mErrorNumber = oDNS_LuongCoBan.ErrorNumber;
            return ID;
        }

        public void Update(NS_LuongCoBanInfo pNS_LuongCoBanInfo)
        {
            oDNS_LuongCoBan.Update(pNS_LuongCoBanInfo);
            mErrorMessage = oDNS_LuongCoBan.ErrorMessages;
            mErrorNumber = oDNS_LuongCoBan.ErrorNumber;
        }
        
        public void Delete(NS_LuongCoBanInfo pNS_LuongCoBanInfo)
        {
            oDNS_LuongCoBan.Delete(pNS_LuongCoBanInfo);
            mErrorMessage = oDNS_LuongCoBan.ErrorMessages;
            mErrorNumber = oDNS_LuongCoBan.ErrorNumber;
        }

        public List<NS_LuongCoBanInfo> GetList(NS_LuongCoBanInfo pNS_LuongCoBanInfo)
        {
            List<NS_LuongCoBanInfo> oNS_LuongCoBanInfoList = new List<NS_LuongCoBanInfo>();
            DataTable dtb = Get(pNS_LuongCoBanInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNS_LuongCoBanInfo = new NS_LuongCoBanInfo();

                    oNS_LuongCoBanInfo.NS_LuongCoBanID = int.Parse(dtb.Rows[i]["NS_LuongCoBanID"].ToString());
                    oNS_LuongCoBanInfo.LuongCoBan = double.Parse(dtb.Rows[i]["LuongCoBan"].ToString());
                    oNS_LuongCoBanInfo.TuNgay = DateTime.Parse(dtb.Rows[i]["TuNgay"].ToString());
                    oNS_LuongCoBanInfo.DenNgay = DateTime.Parse(dtb.Rows[i]["DenNgay"].ToString());
                    
                    oNS_LuongCoBanInfoList.Add(oNS_LuongCoBanInfo);
                }
            }
            return oNS_LuongCoBanInfoList;
        }
        
        public void ToDataRow(NS_LuongCoBanInfo pNS_LuongCoBanInfo, ref DataRow dr)
        {

			dr[pNS_LuongCoBanInfo.strNS_LuongCoBanID] = pNS_LuongCoBanInfo.NS_LuongCoBanID;
			dr[pNS_LuongCoBanInfo.strLuongCoBan] = pNS_LuongCoBanInfo.LuongCoBan;
			dr[pNS_LuongCoBanInfo.strTuNgay] = pNS_LuongCoBanInfo.TuNgay;
			dr[pNS_LuongCoBanInfo.strDenNgay] = pNS_LuongCoBanInfo.DenNgay;
        }
        
        public void ToInfo(ref NS_LuongCoBanInfo pNS_LuongCoBanInfo, DataRow dr)
        {

			pNS_LuongCoBanInfo.NS_LuongCoBanID = int.Parse(dr[pNS_LuongCoBanInfo.strNS_LuongCoBanID].ToString());
            pNS_LuongCoBanInfo.LuongCoBan = double.Parse("0" + dr[pNS_LuongCoBanInfo.strLuongCoBan]);
            if (dr[pNS_LuongCoBanInfo.strTuNgay].ToString() != "")
                pNS_LuongCoBanInfo.TuNgay = DateTime.Parse(dr[pNS_LuongCoBanInfo.strTuNgay].ToString());
            if (dr[pNS_LuongCoBanInfo.strDenNgay].ToString() != "")
			    pNS_LuongCoBanInfo.DenNgay = DateTime.Parse(dr[pNS_LuongCoBanInfo.strDenNgay].ToString());
        }
    }
}
