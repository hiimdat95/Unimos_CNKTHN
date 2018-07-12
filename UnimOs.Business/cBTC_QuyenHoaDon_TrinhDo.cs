using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBTC_QuyenHoaDon_TrinhDo : cBBase
    {
        private cDTC_QuyenHoaDon_TrinhDo oDTC_QuyenHoaDon_TrinhDo;
        private TC_QuyenHoaDon_TrinhDoInfo oTC_QuyenHoaDon_TrinhDoInfo;

        public cBTC_QuyenHoaDon_TrinhDo()        
        {
            oDTC_QuyenHoaDon_TrinhDo = new cDTC_QuyenHoaDon_TrinhDo();
        }

        public DataTable Get(TC_QuyenHoaDon_TrinhDoInfo pTC_QuyenHoaDon_TrinhDoInfo)        
        {
            return oDTC_QuyenHoaDon_TrinhDo.Get(pTC_QuyenHoaDon_TrinhDoInfo);
        }

        public int Add(TC_QuyenHoaDon_TrinhDoInfo pTC_QuyenHoaDon_TrinhDoInfo)
        {
			int ID = 0;
            ID = oDTC_QuyenHoaDon_TrinhDo.Add(pTC_QuyenHoaDon_TrinhDoInfo);
            mErrorMessage = oDTC_QuyenHoaDon_TrinhDo.ErrorMessages;
            mErrorNumber = oDTC_QuyenHoaDon_TrinhDo.ErrorNumber;
            return ID;
        }

        public void Update(TC_QuyenHoaDon_TrinhDoInfo pTC_QuyenHoaDon_TrinhDoInfo)
        {
            oDTC_QuyenHoaDon_TrinhDo.Update(pTC_QuyenHoaDon_TrinhDoInfo);
            mErrorMessage = oDTC_QuyenHoaDon_TrinhDo.ErrorMessages;
            mErrorNumber = oDTC_QuyenHoaDon_TrinhDo.ErrorNumber;
        }
        
        public void Delete(TC_QuyenHoaDon_TrinhDoInfo pTC_QuyenHoaDon_TrinhDoInfo)
        {
            oDTC_QuyenHoaDon_TrinhDo.Delete(pTC_QuyenHoaDon_TrinhDoInfo);
            mErrorMessage = oDTC_QuyenHoaDon_TrinhDo.ErrorMessages;
            mErrorNumber = oDTC_QuyenHoaDon_TrinhDo.ErrorNumber;
        }

        public List<TC_QuyenHoaDon_TrinhDoInfo> GetList(TC_QuyenHoaDon_TrinhDoInfo pTC_QuyenHoaDon_TrinhDoInfo)
        {
            List<TC_QuyenHoaDon_TrinhDoInfo> oTC_QuyenHoaDon_TrinhDoInfoList = new List<TC_QuyenHoaDon_TrinhDoInfo>();
            DataTable dtb = Get(pTC_QuyenHoaDon_TrinhDoInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTC_QuyenHoaDon_TrinhDoInfo = new TC_QuyenHoaDon_TrinhDoInfo();

                    oTC_QuyenHoaDon_TrinhDoInfo.TC_QuyenHoaDon_TrinhDoID = int.Parse(dtb.Rows[i][oTC_QuyenHoaDon_TrinhDoInfo.strTC_QuyenHoaDon_TrinhDoID].ToString());
                    oTC_QuyenHoaDon_TrinhDoInfo.IDTC_QuyenHoaDon = int.Parse(dtb.Rows[i][oTC_QuyenHoaDon_TrinhDoInfo.strIDTC_QuyenHoaDon].ToString());
                    oTC_QuyenHoaDon_TrinhDoInfo.IDDM_TrinhDo = int.Parse(dtb.Rows[i][oTC_QuyenHoaDon_TrinhDoInfo.strIDDM_TrinhDo].ToString());
                    
                    oTC_QuyenHoaDon_TrinhDoInfoList.Add(oTC_QuyenHoaDon_TrinhDoInfo);
                }
            }
            return oTC_QuyenHoaDon_TrinhDoInfoList;
        }
        
        public void ToDataRow(TC_QuyenHoaDon_TrinhDoInfo pTC_QuyenHoaDon_TrinhDoInfo, ref DataRow dr)
        {

			dr[pTC_QuyenHoaDon_TrinhDoInfo.strTC_QuyenHoaDon_TrinhDoID] = pTC_QuyenHoaDon_TrinhDoInfo.TC_QuyenHoaDon_TrinhDoID;
			dr[pTC_QuyenHoaDon_TrinhDoInfo.strIDTC_QuyenHoaDon] = pTC_QuyenHoaDon_TrinhDoInfo.IDTC_QuyenHoaDon;
			dr[pTC_QuyenHoaDon_TrinhDoInfo.strIDDM_TrinhDo] = pTC_QuyenHoaDon_TrinhDoInfo.IDDM_TrinhDo;
        }
        
        public void ToInfo(ref TC_QuyenHoaDon_TrinhDoInfo pTC_QuyenHoaDon_TrinhDoInfo, DataRow dr)
        {

			pTC_QuyenHoaDon_TrinhDoInfo.TC_QuyenHoaDon_TrinhDoID = int.Parse(dr[oTC_QuyenHoaDon_TrinhDoInfo.strTC_QuyenHoaDon_TrinhDoID].ToString());
			pTC_QuyenHoaDon_TrinhDoInfo.IDTC_QuyenHoaDon = int.Parse(dr[oTC_QuyenHoaDon_TrinhDoInfo.strIDTC_QuyenHoaDon].ToString());
			pTC_QuyenHoaDon_TrinhDoInfo.IDDM_TrinhDo = int.Parse(dr[oTC_QuyenHoaDon_TrinhDoInfo.strIDDM_TrinhDo].ToString());
        }
    }
}
