using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBHT_ThongTinTruong : cBBase
    {
        private cDHT_ThongTinTruong oDHT_ThongTinTruong;
        private HT_ThongTinTruongInfo oHT_ThongTinTruongInfo;

        public cBHT_ThongTinTruong()        
        {
            oDHT_ThongTinTruong = new cDHT_ThongTinTruong();
        }

        public DataTable Get(HT_ThongTinTruongInfo pHT_ThongTinTruongInfo)        
        {
            return oDHT_ThongTinTruong.Get(pHT_ThongTinTruongInfo);
        }

        public int Add(HT_ThongTinTruongInfo pHT_ThongTinTruongInfo)
        {
			int ID = 0;
            ID = oDHT_ThongTinTruong.Add(pHT_ThongTinTruongInfo);
            mErrorMessage = oDHT_ThongTinTruong.ErrorMessages;
            mErrorNumber = oDHT_ThongTinTruong.ErrorNumber;
            return ID;
        }

        public void Update(HT_ThongTinTruongInfo pHT_ThongTinTruongInfo)
        {
            oDHT_ThongTinTruong.Update(pHT_ThongTinTruongInfo);
            mErrorMessage = oDHT_ThongTinTruong.ErrorMessages;
            mErrorNumber = oDHT_ThongTinTruong.ErrorNumber;
        }
        
        public void Delete(HT_ThongTinTruongInfo pHT_ThongTinTruongInfo)
        {
            oDHT_ThongTinTruong.Delete(pHT_ThongTinTruongInfo);
            mErrorMessage = oDHT_ThongTinTruong.ErrorMessages;
            mErrorNumber = oDHT_ThongTinTruong.ErrorNumber;
        }

        public List<HT_ThongTinTruongInfo> GetList(HT_ThongTinTruongInfo pHT_ThongTinTruongInfo)
        {
            List<HT_ThongTinTruongInfo> oHT_ThongTinTruongInfoList = new List<HT_ThongTinTruongInfo>();
            DataTable dtb = Get(pHT_ThongTinTruongInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oHT_ThongTinTruongInfo = new HT_ThongTinTruongInfo();

                    oHT_ThongTinTruongInfo.HT_ThongTinTruongID = int.Parse(dtb.Rows[i]["HT_ThongTinTruongID"].ToString());
                    oHT_ThongTinTruongInfo.MaThongTin = dtb.Rows[i]["MaThongTin"].ToString();
                    oHT_ThongTinTruongInfo.TenThongTin = dtb.Rows[i]["TenThongTin"].ToString();
                    oHT_ThongTinTruongInfo.GiaTri = dtb.Rows[i]["GiaTri"].ToString();
                    oHT_ThongTinTruongInfo.SapXep = int.Parse(dtb.Rows[i]["SapXep"].ToString());
                    
                    oHT_ThongTinTruongInfoList.Add(oHT_ThongTinTruongInfo);
                }
            }
            return oHT_ThongTinTruongInfoList;
        }
        
        public void ToDataRow(HT_ThongTinTruongInfo pHT_ThongTinTruongInfo, ref DataRow dr)
        {

			dr[pHT_ThongTinTruongInfo.strHT_ThongTinTruongID] = pHT_ThongTinTruongInfo.HT_ThongTinTruongID;
			dr[pHT_ThongTinTruongInfo.strMaThongTin] = pHT_ThongTinTruongInfo.MaThongTin;
			dr[pHT_ThongTinTruongInfo.strTenThongTin] = pHT_ThongTinTruongInfo.TenThongTin;
			dr[pHT_ThongTinTruongInfo.strGiaTri] = pHT_ThongTinTruongInfo.GiaTri;
			dr[pHT_ThongTinTruongInfo.strSapXep] = pHT_ThongTinTruongInfo.SapXep;
        }
        
        public void ToInfo(ref HT_ThongTinTruongInfo pHT_ThongTinTruongInfo, DataRow dr)
        {

			pHT_ThongTinTruongInfo.HT_ThongTinTruongID = int.Parse(dr[pHT_ThongTinTruongInfo.strHT_ThongTinTruongID].ToString());
			pHT_ThongTinTruongInfo.MaThongTin = dr[pHT_ThongTinTruongInfo.strMaThongTin].ToString();
			pHT_ThongTinTruongInfo.TenThongTin = dr[pHT_ThongTinTruongInfo.strTenThongTin].ToString();
			pHT_ThongTinTruongInfo.GiaTri = dr[pHT_ThongTinTruongInfo.strGiaTri].ToString();
			pHT_ThongTinTruongInfo.SapXep = int.Parse(dr[pHT_ThongTinTruongInfo.strSapXep].ToString());
        }
    }
}
