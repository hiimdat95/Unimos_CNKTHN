using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.wsBusiness;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data; using UnimOs.wsBusiness.wsUnimOs;

namespace TruongViet.UnimOs.wsBusiness
{
    public class cBwsKQHT_CongThucDiem_ThanhPhanDiem : cBwsBase
    {
        private cDKQHT_CongThucDiem_ThanhPhanDiem oDKQHT_CongThucDiem_ThanhPhanDiem;
        private KQHT_CongThucDiem_ThanhPhanDiemInfo oKQHT_CongThucDiem_ThanhPhanDiemInfo;

        public cBwsKQHT_CongThucDiem_ThanhPhanDiem()        
        {
            oDKQHT_CongThucDiem_ThanhPhanDiem = new cDKQHT_CongThucDiem_ThanhPhanDiem();
        }

        public DataTable Get(KQHT_CongThucDiem_ThanhPhanDiemInfo pKQHT_CongThucDiem_ThanhPhanDiemInfo)        
        {
            return oDKQHT_CongThucDiem_ThanhPhanDiem.Get(pKQHT_CongThucDiem_ThanhPhanDiemInfo);
        }

        public DataTable GetByCongThucDiem(int IDKQHT_CongThucDiem)
        {
            return oDKQHT_CongThucDiem_ThanhPhanDiem.GetByCongThucDiem(IDKQHT_CongThucDiem);
        }

        public int Add(KQHT_CongThucDiem_ThanhPhanDiemInfo pKQHT_CongThucDiem_ThanhPhanDiemInfo)
        {
			int ID = 0;
            ID = oDKQHT_CongThucDiem_ThanhPhanDiem.Add(pKQHT_CongThucDiem_ThanhPhanDiemInfo);
            mErrorMessage = oDKQHT_CongThucDiem_ThanhPhanDiem.ErrorMessages;
            mErrorNumber = oDKQHT_CongThucDiem_ThanhPhanDiem.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_CongThucDiem_ThanhPhanDiemInfo pKQHT_CongThucDiem_ThanhPhanDiemInfo)
        {
            oDKQHT_CongThucDiem_ThanhPhanDiem.Update(pKQHT_CongThucDiem_ThanhPhanDiemInfo);
            mErrorMessage = oDKQHT_CongThucDiem_ThanhPhanDiem.ErrorMessages;
            mErrorNumber = oDKQHT_CongThucDiem_ThanhPhanDiem.ErrorNumber;
        }
        
        public void Delete(KQHT_CongThucDiem_ThanhPhanDiemInfo pKQHT_CongThucDiem_ThanhPhanDiemInfo)
        {
            oDKQHT_CongThucDiem_ThanhPhanDiem.Delete(pKQHT_CongThucDiem_ThanhPhanDiemInfo);
            mErrorMessage = oDKQHT_CongThucDiem_ThanhPhanDiem.ErrorMessages;
            mErrorNumber = oDKQHT_CongThucDiem_ThanhPhanDiem.ErrorNumber;
        }

        public List<KQHT_CongThucDiem_ThanhPhanDiemInfo> GetList(KQHT_CongThucDiem_ThanhPhanDiemInfo pKQHT_CongThucDiem_ThanhPhanDiemInfo)
        {
            List<KQHT_CongThucDiem_ThanhPhanDiemInfo> oKQHT_CongThucDiem_ThanhPhanDiemInfoList = new List<KQHT_CongThucDiem_ThanhPhanDiemInfo>();
            DataTable dtb = Get(pKQHT_CongThucDiem_ThanhPhanDiemInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_CongThucDiem_ThanhPhanDiemInfo = new KQHT_CongThucDiem_ThanhPhanDiemInfo();

                    oKQHT_CongThucDiem_ThanhPhanDiemInfo.KQHT_CongThucDiem_ThanhPhanDiemID = int.Parse(dtb.Rows[i]["KQHT_CongThucDiem_ThanhPhanDiemID"].ToString());
                    oKQHT_CongThucDiem_ThanhPhanDiemInfo.IDKQHT_CongThucDiem = int.Parse(dtb.Rows[i]["IDKQHT_CongThucDiem"].ToString());
                    oKQHT_CongThucDiem_ThanhPhanDiemInfo.IDKQHT_ThanhPhanDiem = int.Parse(dtb.Rows[i]["IDKQHT_ThanhPhanDiem"].ToString());
                    
                    oKQHT_CongThucDiem_ThanhPhanDiemInfoList.Add(oKQHT_CongThucDiem_ThanhPhanDiemInfo);
                }
            }
            return oKQHT_CongThucDiem_ThanhPhanDiemInfoList;
        }
        
        public void ToDataRow(KQHT_CongThucDiem_ThanhPhanDiemInfo pKQHT_CongThucDiem_ThanhPhanDiemInfo, ref DataRow dr)
        {

			dr[pKQHT_CongThucDiem_ThanhPhanDiemInfo.strKQHT_CongThucDiem_ThanhPhanDiemID] = pKQHT_CongThucDiem_ThanhPhanDiemInfo.KQHT_CongThucDiem_ThanhPhanDiemID;
			dr[pKQHT_CongThucDiem_ThanhPhanDiemInfo.strIDKQHT_CongThucDiem] = pKQHT_CongThucDiem_ThanhPhanDiemInfo.IDKQHT_CongThucDiem;
			dr[pKQHT_CongThucDiem_ThanhPhanDiemInfo.strIDKQHT_ThanhPhanDiem] = pKQHT_CongThucDiem_ThanhPhanDiemInfo.IDKQHT_ThanhPhanDiem;
        }
        
        public void ToInfo(ref KQHT_CongThucDiem_ThanhPhanDiemInfo pKQHT_CongThucDiem_ThanhPhanDiemInfo, DataRow dr)
        {

			pKQHT_CongThucDiem_ThanhPhanDiemInfo.KQHT_CongThucDiem_ThanhPhanDiemID = int.Parse(dr[pKQHT_CongThucDiem_ThanhPhanDiemInfo.strKQHT_CongThucDiem_ThanhPhanDiemID].ToString());
			pKQHT_CongThucDiem_ThanhPhanDiemInfo.IDKQHT_CongThucDiem = int.Parse(dr[pKQHT_CongThucDiem_ThanhPhanDiemInfo.strIDKQHT_CongThucDiem].ToString());
			pKQHT_CongThucDiem_ThanhPhanDiemInfo.IDKQHT_ThanhPhanDiem = int.Parse(dr[pKQHT_CongThucDiem_ThanhPhanDiemInfo.strIDKQHT_ThanhPhanDiem].ToString());
        }
    }
}
