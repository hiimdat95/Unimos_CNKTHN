using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_PhuCap : cBBase
    {
        private cDNS_PhuCap oDNS_PhuCap;
        private NS_PhuCapInfo oNS_PhuCapInfo;

        public cBNS_PhuCap()        
        {
            oDNS_PhuCap = new cDNS_PhuCap();
        }

        public DataTable Get(NS_PhuCapInfo pNS_PhuCapInfo)        
        {
            return oDNS_PhuCap.Get(pNS_PhuCapInfo);
        }

        public DataTable GetBy_IDNS_GiaoVien(int IDNS_GiaoVien)
        {
            return oDNS_PhuCap.GetBy_IDNS_GiaoVien(IDNS_GiaoVien);
        }

        public int Add(NS_PhuCapInfo pNS_PhuCapInfo)
        {
			int ID = 0;
            ID = oDNS_PhuCap.Add(pNS_PhuCapInfo);
            mErrorMessage = oDNS_PhuCap.ErrorMessages;
            mErrorNumber = oDNS_PhuCap.ErrorNumber;
            return ID;
        }

        public int Add_Update(NS_PhuCapInfo pNS_PhuCapInfo)
        {
            int ID = 0;
            ID = oDNS_PhuCap.Add_Update(pNS_PhuCapInfo);
            mErrorMessage = oDNS_PhuCap.ErrorMessages;
            mErrorNumber = oDNS_PhuCap.ErrorNumber;
            return ID;
        }

        public void Update(NS_PhuCapInfo pNS_PhuCapInfo)
        {
            oDNS_PhuCap.Update(pNS_PhuCapInfo);
            mErrorMessage = oDNS_PhuCap.ErrorMessages;
            mErrorNumber = oDNS_PhuCap.ErrorNumber;
        }
        
        public void Delete(NS_PhuCapInfo pNS_PhuCapInfo)
        {
            oDNS_PhuCap.Delete(pNS_PhuCapInfo);
            mErrorMessage = oDNS_PhuCap.ErrorMessages;
            mErrorNumber = oDNS_PhuCap.ErrorNumber;
        }

        public List<NS_PhuCapInfo> GetList(NS_PhuCapInfo pNS_PhuCapInfo)
        {
            List<NS_PhuCapInfo> oNS_PhuCapInfoList = new List<NS_PhuCapInfo>();
            DataTable dtb = Get(pNS_PhuCapInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNS_PhuCapInfo = new NS_PhuCapInfo();

                    oNS_PhuCapInfo.NS_PhuCapID = int.Parse(dtb.Rows[i]["NS_PhuCapID"].ToString());
                    oNS_PhuCapInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oNS_PhuCapInfo.IDNS_LoaiPhuCap = int.Parse(dtb.Rows[i]["IDNS_LoaiPhuCap"].ToString());
                    oNS_PhuCapInfo.HeSoPhuCap = double.Parse(dtb.Rows[i]["HeSoPhuCap"].ToString());
                    oNS_PhuCapInfo.PhanTramHuong = double.Parse(dtb.Rows[i]["PhanTramHuong"].ToString());
                    oNS_PhuCapInfo.PhuCapTuNgay = DateTime.Parse(dtb.Rows[i]["PhuCapTuNgay"].ToString());
                    oNS_PhuCapInfo.PhuCapDenNgay = DateTime.Parse(dtb.Rows[i]["PhuCapDenNgay"].ToString());
                    oNS_PhuCapInfo.TinhBHXH = bool.Parse(dtb.Rows[i]["TinhBHXH"].ToString());
                    
                    oNS_PhuCapInfoList.Add(oNS_PhuCapInfo);
                }
            }
            return oNS_PhuCapInfoList;
        }
        
        public void ToDataRow(NS_PhuCapInfo pNS_PhuCapInfo, ref DataRow dr)
        {

			dr[pNS_PhuCapInfo.strNS_PhuCapID] = pNS_PhuCapInfo.NS_PhuCapID;
			dr[pNS_PhuCapInfo.strIDNS_GiaoVien] = pNS_PhuCapInfo.IDNS_GiaoVien;
			dr[pNS_PhuCapInfo.strIDNS_LoaiPhuCap] = pNS_PhuCapInfo.IDNS_LoaiPhuCap;
			dr[pNS_PhuCapInfo.strHeSoPhuCap] = pNS_PhuCapInfo.HeSoPhuCap;
			dr[pNS_PhuCapInfo.strPhanTramHuong] = pNS_PhuCapInfo.PhanTramHuong;
			dr[pNS_PhuCapInfo.strPhuCapTuNgay] = pNS_PhuCapInfo.PhuCapTuNgay;
			dr[pNS_PhuCapInfo.strPhuCapDenNgay] = pNS_PhuCapInfo.PhuCapDenNgay;
			dr[pNS_PhuCapInfo.strTinhBHXH] = pNS_PhuCapInfo.TinhBHXH;
        }
        
        public void ToInfo(ref NS_PhuCapInfo pNS_PhuCapInfo, DataRow dr)
        {

			pNS_PhuCapInfo.NS_PhuCapID = int.Parse(dr[pNS_PhuCapInfo.strNS_PhuCapID].ToString());
			pNS_PhuCapInfo.IDNS_GiaoVien = int.Parse("0" + dr[pNS_PhuCapInfo.strIDNS_GiaoVien]);
			pNS_PhuCapInfo.IDNS_LoaiPhuCap = int.Parse("0" + dr[pNS_PhuCapInfo.strIDNS_LoaiPhuCap]);
            pNS_PhuCapInfo.HeSoPhuCap = double.Parse("0" + dr[pNS_PhuCapInfo.strHeSoPhuCap]);
            pNS_PhuCapInfo.PhanTramHuong = double.Parse("0" + dr[pNS_PhuCapInfo.strPhanTramHuong]);
            if (dr[pNS_PhuCapInfo.strPhuCapTuNgay].ToString() != "")
			    pNS_PhuCapInfo.PhuCapTuNgay = DateTime.Parse(dr[pNS_PhuCapInfo.strPhuCapTuNgay].ToString());
            if (dr[pNS_PhuCapInfo.strPhuCapDenNgay].ToString() != "")
			    pNS_PhuCapInfo.PhuCapDenNgay = DateTime.Parse(dr[pNS_PhuCapInfo.strPhuCapDenNgay].ToString());
			pNS_PhuCapInfo.TinhBHXH = bool.Parse(dr[pNS_PhuCapInfo.strTinhBHXH].ToString());
        }
    }
}
