using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_SoQuyetDinh : cBBase
    {
        private cDNS_SoQuyetDinh oDNS_SoQuyetDinh;
        private NS_SoQuyetDinhInfo oNS_SoQuyetDinhInfo;

        public cBNS_SoQuyetDinh()        
        {
            oDNS_SoQuyetDinh = new cDNS_SoQuyetDinh();
        }

        public DataTable Get(NS_SoQuyetDinhInfo pNS_SoQuyetDinhInfo)        
        {
            return oDNS_SoQuyetDinh.Get(pNS_SoQuyetDinhInfo);
        }

        public int Add(NS_SoQuyetDinhInfo pNS_SoQuyetDinhInfo)
        {
			int ID = 0;
            ID = oDNS_SoQuyetDinh.Add(pNS_SoQuyetDinhInfo);
            mErrorMessage = oDNS_SoQuyetDinh.ErrorMessages;
            mErrorNumber = oDNS_SoQuyetDinh.ErrorNumber;
            return ID;
        }

        public void Update(NS_SoQuyetDinhInfo pNS_SoQuyetDinhInfo)
        {
            oDNS_SoQuyetDinh.Update(pNS_SoQuyetDinhInfo);
            mErrorMessage = oDNS_SoQuyetDinh.ErrorMessages;
            mErrorNumber = oDNS_SoQuyetDinh.ErrorNumber;
        }
        
        public void Delete(NS_SoQuyetDinhInfo pNS_SoQuyetDinhInfo)
        {
            oDNS_SoQuyetDinh.Delete(pNS_SoQuyetDinhInfo);
            mErrorMessage = oDNS_SoQuyetDinh.ErrorMessages;
            mErrorNumber = oDNS_SoQuyetDinh.ErrorNumber;
        }

        public List<NS_SoQuyetDinhInfo> GetList(NS_SoQuyetDinhInfo pNS_SoQuyetDinhInfo)
        {
            List<NS_SoQuyetDinhInfo> oNS_SoQuyetDinhInfoList = new List<NS_SoQuyetDinhInfo>();
            DataTable dtb = Get(pNS_SoQuyetDinhInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNS_SoQuyetDinhInfo = new NS_SoQuyetDinhInfo();

                    oNS_SoQuyetDinhInfo.NS_SoQuyetDinhID = int.Parse(dtb.Rows[i]["NS_SoQuyetDinhID"].ToString());
                    oNS_SoQuyetDinhInfo.SoQuyetDinh = dtb.Rows[i]["SoQuyetDinh"].ToString();
                    oNS_SoQuyetDinhInfo.NgayQuyetDinh = DateTime.Parse(dtb.Rows[i]["NgayQuyetDinh"].ToString());
                    
                    oNS_SoQuyetDinhInfoList.Add(oNS_SoQuyetDinhInfo);
                }
            }
            return oNS_SoQuyetDinhInfoList;
        }
        
        public void ToDataRow(NS_SoQuyetDinhInfo pNS_SoQuyetDinhInfo, ref DataRow dr)
        {

			dr[pNS_SoQuyetDinhInfo.strNS_SoQuyetDinhID] = pNS_SoQuyetDinhInfo.NS_SoQuyetDinhID;
			dr[pNS_SoQuyetDinhInfo.strSoQuyetDinh] = pNS_SoQuyetDinhInfo.SoQuyetDinh;
			dr[pNS_SoQuyetDinhInfo.strNgayQuyetDinh] = pNS_SoQuyetDinhInfo.NgayQuyetDinh;
        }
        
        public void ToInfo(ref NS_SoQuyetDinhInfo pNS_SoQuyetDinhInfo, DataRow dr)
        {

			pNS_SoQuyetDinhInfo.NS_SoQuyetDinhID = int.Parse(dr[pNS_SoQuyetDinhInfo.strNS_SoQuyetDinhID].ToString());
			pNS_SoQuyetDinhInfo.SoQuyetDinh = dr[pNS_SoQuyetDinhInfo.strSoQuyetDinh].ToString();
			pNS_SoQuyetDinhInfo.NgayQuyetDinh = DateTime.Parse(dr[pNS_SoQuyetDinhInfo.strNgayQuyetDinh].ToString());
        }
    }
}
