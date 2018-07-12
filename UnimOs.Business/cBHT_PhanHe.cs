using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBHT_PhanHe : cBBase
    {
        private cDHT_PhanHe oDHT_PhanHe;
        private HT_PhanHeInfo oHT_PhanHeInfo;

        public cBHT_PhanHe()        
        {
            oDHT_PhanHe = new cDHT_PhanHe();
        }

        public DataTable Get(HT_PhanHeInfo pHT_PhanHeInfo)        
        {
            return oDHT_PhanHe.Get(pHT_PhanHeInfo);
        }

        public int Add(HT_PhanHeInfo pHT_PhanHeInfo)
        {
			int ID = 0;
            ID = oDHT_PhanHe.Add(pHT_PhanHeInfo);
            mErrorMessage = oDHT_PhanHe.ErrorMessages;
            mErrorNumber = oDHT_PhanHe.ErrorNumber;
            return ID;
        }

        public void Update(HT_PhanHeInfo pHT_PhanHeInfo)
        {
            oDHT_PhanHe.Update(pHT_PhanHeInfo);
            mErrorMessage = oDHT_PhanHe.ErrorMessages;
            mErrorNumber = oDHT_PhanHe.ErrorNumber;
        }
        
        public void Delete(HT_PhanHeInfo pHT_PhanHeInfo)
        {
            oDHT_PhanHe.Delete(pHT_PhanHeInfo);
            mErrorMessage = oDHT_PhanHe.ErrorMessages;
            mErrorNumber = oDHT_PhanHe.ErrorNumber;
        }

        public List<HT_PhanHeInfo> GetList(HT_PhanHeInfo pHT_PhanHeInfo)
        {
            List<HT_PhanHeInfo> oHT_PhanHeInfoList = new List<HT_PhanHeInfo>();
            DataTable dtb = Get(pHT_PhanHeInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oHT_PhanHeInfo = new HT_PhanHeInfo();

                    oHT_PhanHeInfo.HT_PhanHeID = int.Parse(dtb.Rows[i]["HT_PhanHeID"].ToString());
                    oHT_PhanHeInfo.MaPhanHe = dtb.Rows[i]["MaPhanHe"].ToString();
                    oHT_PhanHeInfo.TenPhanHe = dtb.Rows[i]["TenPhanHe"].ToString();
                    oHT_PhanHeInfo.MoTa = dtb.Rows[i]["MoTa"].ToString();
                    oHT_PhanHeInfo.SapXep = int.Parse(dtb.Rows[i]["SapXep"].ToString());
                    
                    oHT_PhanHeInfoList.Add(oHT_PhanHeInfo);
                }
            }
            return oHT_PhanHeInfoList;
        }
        
        public void ToDataRow(HT_PhanHeInfo pHT_PhanHeInfo, ref DataRow dr)
        {

			dr[pHT_PhanHeInfo.strHT_PhanHeID] = pHT_PhanHeInfo.HT_PhanHeID;
			dr[pHT_PhanHeInfo.strMaPhanHe] = pHT_PhanHeInfo.MaPhanHe;
			dr[pHT_PhanHeInfo.strTenPhanHe] = pHT_PhanHeInfo.TenPhanHe;
			dr[pHT_PhanHeInfo.strMoTa] = pHT_PhanHeInfo.MoTa;
			dr[pHT_PhanHeInfo.strSapXep] = pHT_PhanHeInfo.SapXep;
        }
        
        public void ToInfo(ref HT_PhanHeInfo pHT_PhanHeInfo, DataRow dr)
        {

			pHT_PhanHeInfo.HT_PhanHeID = int.Parse(dr[pHT_PhanHeInfo.strHT_PhanHeID].ToString());
			pHT_PhanHeInfo.MaPhanHe = dr[pHT_PhanHeInfo.strMaPhanHe].ToString();
			pHT_PhanHeInfo.TenPhanHe = dr[pHT_PhanHeInfo.strTenPhanHe].ToString();
			pHT_PhanHeInfo.MoTa = dr[pHT_PhanHeInfo.strMoTa].ToString();
			pHT_PhanHeInfo.SapXep = int.Parse(dr[pHT_PhanHeInfo.strSapXep].ToString());
        }
    }
}
