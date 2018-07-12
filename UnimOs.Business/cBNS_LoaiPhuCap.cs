using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_LoaiPhuCap : cBBase
    {
        private cDNS_LoaiPhuCap oDNS_LoaiPhuCap;
        private NS_LoaiPhuCapInfo oNS_LoaiPhuCapInfo;

        public cBNS_LoaiPhuCap()        
        {
            oDNS_LoaiPhuCap = new cDNS_LoaiPhuCap();
        }

        public DataTable Get(NS_LoaiPhuCapInfo pNS_LoaiPhuCapInfo)        
        {
            return oDNS_LoaiPhuCap.Get(pNS_LoaiPhuCapInfo);
        }

        public int Add(NS_LoaiPhuCapInfo pNS_LoaiPhuCapInfo)
        {
			int ID = 0;
            ID = oDNS_LoaiPhuCap.Add(pNS_LoaiPhuCapInfo);
            mErrorMessage = oDNS_LoaiPhuCap.ErrorMessages;
            mErrorNumber = oDNS_LoaiPhuCap.ErrorNumber;
            return ID;
        }

        public void Update(NS_LoaiPhuCapInfo pNS_LoaiPhuCapInfo)
        {
            oDNS_LoaiPhuCap.Update(pNS_LoaiPhuCapInfo);
            mErrorMessage = oDNS_LoaiPhuCap.ErrorMessages;
            mErrorNumber = oDNS_LoaiPhuCap.ErrorNumber;
        }
        
        public void Delete(NS_LoaiPhuCapInfo pNS_LoaiPhuCapInfo)
        {
            oDNS_LoaiPhuCap.Delete(pNS_LoaiPhuCapInfo);
            mErrorMessage = oDNS_LoaiPhuCap.ErrorMessages;
            mErrorNumber = oDNS_LoaiPhuCap.ErrorNumber;
        }

        public List<NS_LoaiPhuCapInfo> GetList(NS_LoaiPhuCapInfo pNS_LoaiPhuCapInfo)
        {
            List<NS_LoaiPhuCapInfo> oNS_LoaiPhuCapInfoList = new List<NS_LoaiPhuCapInfo>();
            DataTable dtb = Get(pNS_LoaiPhuCapInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNS_LoaiPhuCapInfo = new NS_LoaiPhuCapInfo();

                    oNS_LoaiPhuCapInfo.NS_LoaiPhuCapID = int.Parse(dtb.Rows[i]["NS_LoaiPhuCapID"].ToString());
                    oNS_LoaiPhuCapInfo.KyHieu = dtb.Rows[i]["KyHieu"].ToString();
                    oNS_LoaiPhuCapInfo.TenLoaiPhuCap = dtb.Rows[i]["TenLoaiPhuCap"].ToString();
                    oNS_LoaiPhuCapInfo.LaPhuCapChucVu = bool.Parse(dtb.Rows[i]["LaPhuCapChucVu"].ToString());
                    oNS_LoaiPhuCapInfo.BHXH = bool.Parse(dtb.Rows[i]["BHXH"].ToString());
                    
                    oNS_LoaiPhuCapInfoList.Add(oNS_LoaiPhuCapInfo);
                }
            }
            return oNS_LoaiPhuCapInfoList;
        }
        
        public void ToDataRow(NS_LoaiPhuCapInfo pNS_LoaiPhuCapInfo, ref DataRow dr)
        {

			dr[pNS_LoaiPhuCapInfo.strNS_LoaiPhuCapID] = pNS_LoaiPhuCapInfo.NS_LoaiPhuCapID;
			dr[pNS_LoaiPhuCapInfo.strKyHieu] = pNS_LoaiPhuCapInfo.KyHieu;
			dr[pNS_LoaiPhuCapInfo.strTenLoaiPhuCap] = pNS_LoaiPhuCapInfo.TenLoaiPhuCap;
            dr[pNS_LoaiPhuCapInfo.strLaPhuCapChucVu] = pNS_LoaiPhuCapInfo.LaPhuCapChucVu;
			dr[pNS_LoaiPhuCapInfo.strBHXH] = pNS_LoaiPhuCapInfo.BHXH;
        }
        
        public void ToInfo(ref NS_LoaiPhuCapInfo pNS_LoaiPhuCapInfo, DataRow dr)
        {

			pNS_LoaiPhuCapInfo.NS_LoaiPhuCapID = int.Parse(dr[pNS_LoaiPhuCapInfo.strNS_LoaiPhuCapID].ToString());
			pNS_LoaiPhuCapInfo.KyHieu = dr[pNS_LoaiPhuCapInfo.strKyHieu].ToString();
			pNS_LoaiPhuCapInfo.TenLoaiPhuCap = dr[pNS_LoaiPhuCapInfo.strTenLoaiPhuCap].ToString();
            pNS_LoaiPhuCapInfo.LaPhuCapChucVu = bool.Parse(dr[pNS_LoaiPhuCapInfo.strLaPhuCapChucVu].ToString());
			pNS_LoaiPhuCapInfo.BHXH = bool.Parse(dr[pNS_LoaiPhuCapInfo.strBHXH].ToString());
        }
    }
}
