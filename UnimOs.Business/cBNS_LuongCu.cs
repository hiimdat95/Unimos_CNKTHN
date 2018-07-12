using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBNS_LuongCu : cBBase
    {
        private cDNS_LuongCu oDNS_LuongCu;
        private NS_LuongCuInfo oNS_LuongCuInfo;

        public cBNS_LuongCu()        
        {
            oDNS_LuongCu = new cDNS_LuongCu();
        }

        public DataTable Get(NS_LuongCuInfo pNS_LuongCuInfo)        
        {
            return oDNS_LuongCu.Get(pNS_LuongCuInfo);
        }

        public int Add(NS_LuongCuInfo pNS_LuongCuInfo)
        {
			int ID = 0;
            ID = oDNS_LuongCu.Add(pNS_LuongCuInfo);
            mErrorMessage = oDNS_LuongCu.ErrorMessages;
            mErrorNumber = oDNS_LuongCu.ErrorNumber;
            return ID;
        }

        public int Add_InfoFull(NS_LuongCuInfo pNS_LuongCuInfo)
        {
            int ID = 0;
            ID = oDNS_LuongCu.Add_InfoFull(pNS_LuongCuInfo);
            mErrorMessage = oDNS_LuongCu.ErrorMessages;
            mErrorNumber = oDNS_LuongCu.ErrorNumber;
            return ID;
        }

        public void Update(NS_LuongCuInfo pNS_LuongCuInfo)
        {
            oDNS_LuongCu.Update(pNS_LuongCuInfo);
            mErrorMessage = oDNS_LuongCu.ErrorMessages;
            mErrorNumber = oDNS_LuongCu.ErrorNumber;
        }
        
        public void Delete(NS_LuongCuInfo pNS_LuongCuInfo)
        {
            oDNS_LuongCu.Delete(pNS_LuongCuInfo);
            mErrorMessage = oDNS_LuongCu.ErrorMessages;
            mErrorNumber = oDNS_LuongCu.ErrorNumber;
        }

        public List<NS_LuongCuInfo> GetList(NS_LuongCuInfo pNS_LuongCuInfo)
        {
            List<NS_LuongCuInfo> oNS_LuongCuInfoList = new List<NS_LuongCuInfo>();
            DataTable dtb = Get(pNS_LuongCuInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oNS_LuongCuInfo = new NS_LuongCuInfo();

                    oNS_LuongCuInfo.NS_LuongCuID = int.Parse(dtb.Rows[i]["NS_LuongCuID"].ToString());
                    oNS_LuongCuInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oNS_LuongCuInfo.CongViecDamNhiem = dtb.Rows[i]["CongViecDamNhiem"].ToString();
                    oNS_LuongCuInfo.IDNS_NgachCongChuc = int.Parse(dtb.Rows[i]["IDNS_NgachCongChuc"].ToString());
                    oNS_LuongCuInfo.BacLuong = int.Parse(dtb.Rows[i]["BacLuong"].ToString());
                    oNS_LuongCuInfo.HeSoLuong = double.Parse(dtb.Rows[i]["HeSoLuong"].ToString());
                    oNS_LuongCuInfo.PhanTramHuong = double.Parse(dtb.Rows[i]["PhanTramHuong"].ToString());
                    oNS_LuongCuInfo.TuNgay = DateTime.Parse(dtb.Rows[i]["TuNgay"].ToString());
                    oNS_LuongCuInfo.DenNgay = DateTime.Parse(dtb.Rows[i]["DenNgay"].ToString());
                    
                    oNS_LuongCuInfoList.Add(oNS_LuongCuInfo);
                }
            }
            return oNS_LuongCuInfoList;
        }
        
        public void ToDataRow(NS_LuongCuInfo pNS_LuongCuInfo, ref DataRow dr)
        {

			dr[pNS_LuongCuInfo.strNS_LuongCuID] = pNS_LuongCuInfo.NS_LuongCuID;
			dr[pNS_LuongCuInfo.strIDNS_GiaoVien] = pNS_LuongCuInfo.IDNS_GiaoVien;
			dr[pNS_LuongCuInfo.strCongViecDamNhiem] = pNS_LuongCuInfo.CongViecDamNhiem;
			dr[pNS_LuongCuInfo.strIDNS_NgachCongChuc] = pNS_LuongCuInfo.IDNS_NgachCongChuc;
			dr[pNS_LuongCuInfo.strBacLuong] = pNS_LuongCuInfo.BacLuong;
			dr[pNS_LuongCuInfo.strHeSoLuong] = pNS_LuongCuInfo.HeSoLuong;
			dr[pNS_LuongCuInfo.strPhanTramHuong] = pNS_LuongCuInfo.PhanTramHuong;
			dr[pNS_LuongCuInfo.strTuNgay] = pNS_LuongCuInfo.TuNgay;
			dr[pNS_LuongCuInfo.strDenNgay] = pNS_LuongCuInfo.DenNgay;
        }
        
        public void ToInfo(ref NS_LuongCuInfo pNS_LuongCuInfo, DataRow dr)
        {

			pNS_LuongCuInfo.NS_LuongCuID = int.Parse(dr[pNS_LuongCuInfo.strNS_LuongCuID].ToString());
			pNS_LuongCuInfo.IDNS_GiaoVien = int.Parse("0" + dr[pNS_LuongCuInfo.strIDNS_GiaoVien]);
			pNS_LuongCuInfo.CongViecDamNhiem = dr[pNS_LuongCuInfo.strCongViecDamNhiem].ToString();
			pNS_LuongCuInfo.IDNS_NgachCongChuc = int.Parse("0" + dr[pNS_LuongCuInfo.strIDNS_NgachCongChuc]);
			pNS_LuongCuInfo.BacLuong = int.Parse("0" + dr[pNS_LuongCuInfo.strBacLuong]);
            pNS_LuongCuInfo.HeSoLuong = double.Parse("0" + dr[pNS_LuongCuInfo.strHeSoLuong]);
            pNS_LuongCuInfo.PhanTramHuong = double.Parse("0" + dr[pNS_LuongCuInfo.strPhanTramHuong]);
            if (dr[pNS_LuongCuInfo.strTuNgay].ToString() != "")
			    pNS_LuongCuInfo.TuNgay = DateTime.Parse(dr[pNS_LuongCuInfo.strTuNgay].ToString());
            if (dr[pNS_LuongCuInfo.strDenNgay].ToString() != "")
			    pNS_LuongCuInfo.DenNgay = DateTime.Parse(dr[pNS_LuongCuInfo.strDenNgay].ToString());
        }
    }
}
