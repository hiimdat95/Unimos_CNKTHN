using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_NgachCongChuc : cBBase
    {
        private cDNS_NgachCongChuc oDNS_NgachCongChuc;
        private NS_NgachCongChucInfo oNS_NgachCongChucInfo;

        public cBNS_NgachCongChuc()        
        {
            oDNS_NgachCongChuc = new cDNS_NgachCongChuc();
        }

        public DataTable Get(NS_NgachCongChucInfo pNS_NgachCongChucInfo)        
        {
            return oDNS_NgachCongChuc.Get(pNS_NgachCongChucInfo);
        }

        public int Add(NS_NgachCongChucInfo pNS_NgachCongChucInfo)
        {
			int ID = 0;
            ID = oDNS_NgachCongChuc.Add(pNS_NgachCongChucInfo);
            mErrorMessage = oDNS_NgachCongChuc.ErrorMessages;
            mErrorNumber = oDNS_NgachCongChuc.ErrorNumber;
            return ID;
        }

        public void Update(NS_NgachCongChucInfo pNS_NgachCongChucInfo)
        {
            oDNS_NgachCongChuc.Update(pNS_NgachCongChucInfo);
            mErrorMessage = oDNS_NgachCongChuc.ErrorMessages;
            mErrorNumber = oDNS_NgachCongChuc.ErrorNumber;
        }
        
        public void Delete(NS_NgachCongChucInfo pNS_NgachCongChucInfo)
        {
            oDNS_NgachCongChuc.Delete(pNS_NgachCongChucInfo);
            mErrorMessage = oDNS_NgachCongChuc.ErrorMessages;
            mErrorNumber = oDNS_NgachCongChuc.ErrorNumber;
        }

        public List<NS_NgachCongChucInfo> GetList(NS_NgachCongChucInfo pNS_NgachCongChucInfo)
        {
            List<NS_NgachCongChucInfo> oNS_NgachCongChucInfoList = new List<NS_NgachCongChucInfo>();
            DataTable dtb = Get(pNS_NgachCongChucInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNS_NgachCongChucInfo = new NS_NgachCongChucInfo();

                    oNS_NgachCongChucInfo.NS_NgachCongChucID = int.Parse(dtb.Rows[i]["NS_NgachCongChucID"].ToString());
                    oNS_NgachCongChucInfo.MaNgachCongChuc = dtb.Rows[i]["MaNgachCongChuc"].ToString();
                    oNS_NgachCongChucInfo.TenNgachCongChuc = dtb.Rows[i]["TenNgachCongChuc"].ToString();
                    oNS_NgachCongChucInfo.IDNS_NhomNgach = int.Parse(dtb.Rows[i]["IDNS_NhomNgach"].ToString());
                    
                    oNS_NgachCongChucInfoList.Add(oNS_NgachCongChucInfo);
                }
            }
            return oNS_NgachCongChucInfoList;
        }
        
        public void ToDataRow(NS_NgachCongChucInfo pNS_NgachCongChucInfo, ref DataRow dr)
        {

			dr[pNS_NgachCongChucInfo.strNS_NgachCongChucID] = pNS_NgachCongChucInfo.NS_NgachCongChucID;
			dr[pNS_NgachCongChucInfo.strMaNgachCongChuc] = pNS_NgachCongChucInfo.MaNgachCongChuc;
			dr[pNS_NgachCongChucInfo.strTenNgachCongChuc] = pNS_NgachCongChucInfo.TenNgachCongChuc;
			dr[pNS_NgachCongChucInfo.strIDNS_NhomNgach] = pNS_NgachCongChucInfo.IDNS_NhomNgach;
        }
        
        public void ToInfo(ref NS_NgachCongChucInfo pNS_NgachCongChucInfo, DataRow dr)
        {

			pNS_NgachCongChucInfo.NS_NgachCongChucID = int.Parse(dr[pNS_NgachCongChucInfo.strNS_NgachCongChucID].ToString());
			pNS_NgachCongChucInfo.MaNgachCongChuc = dr[pNS_NgachCongChucInfo.strMaNgachCongChuc].ToString();
			pNS_NgachCongChucInfo.TenNgachCongChuc = dr[pNS_NgachCongChucInfo.strTenNgachCongChuc].ToString();
			pNS_NgachCongChucInfo.IDNS_NhomNgach = int.Parse("0" + dr[pNS_NgachCongChucInfo.strIDNS_NhomNgach]);
        }
    }
}
