using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_CTDT_CT_KhoiKienThuc : cBBase
    {
        private cDKQHT_CTDT_CT_KhoiKienThuc oDKQHT_CTDT_CT_KhoiKienThuc;
        private KQHT_CTDT_CT_KhoiKienThucInfo oKQHT_CTDT_CT_KhoiKienThucInfo;

        public cBKQHT_CTDT_CT_KhoiKienThuc()        
        {
            oDKQHT_CTDT_CT_KhoiKienThuc = new cDKQHT_CTDT_CT_KhoiKienThuc();
        }

        public DataTable Get(KQHT_CTDT_CT_KhoiKienThucInfo pKQHT_CTDT_CT_KhoiKienThucInfo)        
        {
            return oDKQHT_CTDT_CT_KhoiKienThuc.Get(pKQHT_CTDT_CT_KhoiKienThucInfo);
        }

        public int Add(KQHT_CTDT_CT_KhoiKienThucInfo pKQHT_CTDT_CT_KhoiKienThucInfo)
        {
			int ID = 0;
            ID = oDKQHT_CTDT_CT_KhoiKienThuc.Add(pKQHT_CTDT_CT_KhoiKienThucInfo);
            mErrorMessage = oDKQHT_CTDT_CT_KhoiKienThuc.ErrorMessages;
            mErrorNumber = oDKQHT_CTDT_CT_KhoiKienThuc.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_CTDT_CT_KhoiKienThucInfo pKQHT_CTDT_CT_KhoiKienThucInfo)
        {
            oDKQHT_CTDT_CT_KhoiKienThuc.Update(pKQHT_CTDT_CT_KhoiKienThucInfo);
            mErrorMessage = oDKQHT_CTDT_CT_KhoiKienThuc.ErrorMessages;
            mErrorNumber = oDKQHT_CTDT_CT_KhoiKienThuc.ErrorNumber;
        }
        
        public void Delete(KQHT_CTDT_CT_KhoiKienThucInfo pKQHT_CTDT_CT_KhoiKienThucInfo)
        {
            oDKQHT_CTDT_CT_KhoiKienThuc.Delete(pKQHT_CTDT_CT_KhoiKienThucInfo);
            mErrorMessage = oDKQHT_CTDT_CT_KhoiKienThuc.ErrorMessages;
            mErrorNumber = oDKQHT_CTDT_CT_KhoiKienThuc.ErrorNumber;
        }

        public List<KQHT_CTDT_CT_KhoiKienThucInfo> GetList(KQHT_CTDT_CT_KhoiKienThucInfo pKQHT_CTDT_CT_KhoiKienThucInfo)
        {
            List<KQHT_CTDT_CT_KhoiKienThucInfo> oKQHT_CTDT_CT_KhoiKienThucInfoList = new List<KQHT_CTDT_CT_KhoiKienThucInfo>();
            DataTable dtb = Get(pKQHT_CTDT_CT_KhoiKienThucInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_CTDT_CT_KhoiKienThucInfo = new KQHT_CTDT_CT_KhoiKienThucInfo();

                    oKQHT_CTDT_CT_KhoiKienThucInfo.KQHT_CTDT_CT_KhoiKienThucID = int.Parse(dtb.Rows[i]["KQHT_CTDT_CT_KhoiKienThucID"].ToString());
                    oKQHT_CTDT_CT_KhoiKienThucInfo.IDKQHT_ChuongTrinhDaoTao = int.Parse(dtb.Rows[i]["IDKQHT_ChuongTrinhDaoTao"].ToString());
                    oKQHT_CTDT_CT_KhoiKienThucInfo.IDKQHT_CT_KhoiKienThuc = int.Parse(dtb.Rows[i]["IDKQHT_CT_KhoiKienThuc"].ToString());
                    
                    oKQHT_CTDT_CT_KhoiKienThucInfoList.Add(oKQHT_CTDT_CT_KhoiKienThucInfo);
                }
            }
            return oKQHT_CTDT_CT_KhoiKienThucInfoList;
        }
        
        public void ToDataRow(KQHT_CTDT_CT_KhoiKienThucInfo pKQHT_CTDT_CT_KhoiKienThucInfo, ref DataRow dr)
        {

			dr[pKQHT_CTDT_CT_KhoiKienThucInfo.strKQHT_CTDT_CT_KhoiKienThucID] = pKQHT_CTDT_CT_KhoiKienThucInfo.KQHT_CTDT_CT_KhoiKienThucID;
			dr[pKQHT_CTDT_CT_KhoiKienThucInfo.strIDKQHT_ChuongTrinhDaoTao] = pKQHT_CTDT_CT_KhoiKienThucInfo.IDKQHT_ChuongTrinhDaoTao;
			dr[pKQHT_CTDT_CT_KhoiKienThucInfo.strIDKQHT_CT_KhoiKienThuc] = pKQHT_CTDT_CT_KhoiKienThucInfo.IDKQHT_CT_KhoiKienThuc;
        }
    }
}
