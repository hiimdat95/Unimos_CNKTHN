using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBTC_DanhSachTroCap_ChiTiet : cBBase
    {
        private cDTC_DanhSachTroCap_ChiTiet oDTC_DanhSachTroCap_ChiTiet;
        private TC_DanhSachTroCap_ChiTietInfo oTC_DanhSachTroCap_ChiTietInfo;

        public cBTC_DanhSachTroCap_ChiTiet()        
        {
            oDTC_DanhSachTroCap_ChiTiet = new cDTC_DanhSachTroCap_ChiTiet();
        }

        public DataTable Get(TC_DanhSachTroCap_ChiTietInfo pTC_DanhSachTroCap_ChiTietInfo)        
        {
            return oDTC_DanhSachTroCap_ChiTiet.Get(pTC_DanhSachTroCap_ChiTietInfo);
        }

        public int Add(TC_DanhSachTroCap_ChiTietInfo pTC_DanhSachTroCap_ChiTietInfo)
        {
			int ID = 0;
            ID = oDTC_DanhSachTroCap_ChiTiet.Add(pTC_DanhSachTroCap_ChiTietInfo);
            mErrorMessage = oDTC_DanhSachTroCap_ChiTiet.ErrorMessages;
            mErrorNumber = oDTC_DanhSachTroCap_ChiTiet.ErrorNumber;
            return ID;
        }

        public void Update(TC_DanhSachTroCap_ChiTietInfo pTC_DanhSachTroCap_ChiTietInfo)
        {
            oDTC_DanhSachTroCap_ChiTiet.Update(pTC_DanhSachTroCap_ChiTietInfo);
            mErrorMessage = oDTC_DanhSachTroCap_ChiTiet.ErrorMessages;
            mErrorNumber = oDTC_DanhSachTroCap_ChiTiet.ErrorNumber;
        }
        
        public void Delete(TC_DanhSachTroCap_ChiTietInfo pTC_DanhSachTroCap_ChiTietInfo)
        {
            oDTC_DanhSachTroCap_ChiTiet.Delete(pTC_DanhSachTroCap_ChiTietInfo);
            mErrorMessage = oDTC_DanhSachTroCap_ChiTiet.ErrorMessages;
            mErrorNumber = oDTC_DanhSachTroCap_ChiTiet.ErrorNumber;
        }

        public void DeleteBy_TroCap(int IDTC_DanhSachTroCap)
        {
            oDTC_DanhSachTroCap_ChiTiet.DeleteBy_TroCap(IDTC_DanhSachTroCap);
            mErrorMessage = oDTC_DanhSachTroCap_ChiTiet.ErrorMessages;
            mErrorNumber = oDTC_DanhSachTroCap_ChiTiet.ErrorNumber;
        }

        public List<TC_DanhSachTroCap_ChiTietInfo> GetList(TC_DanhSachTroCap_ChiTietInfo pTC_DanhSachTroCap_ChiTietInfo)
        {
            List<TC_DanhSachTroCap_ChiTietInfo> oTC_DanhSachTroCap_ChiTietInfoList = new List<TC_DanhSachTroCap_ChiTietInfo>();
            DataTable dtb = Get(pTC_DanhSachTroCap_ChiTietInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTC_DanhSachTroCap_ChiTietInfo = new TC_DanhSachTroCap_ChiTietInfo();

                    oTC_DanhSachTroCap_ChiTietInfo.TC_DanhSachTroCap_ChiTietID = int.Parse(dtb.Rows[i]["TC_DanhSachTroCap_ChiTietID"].ToString());
                    oTC_DanhSachTroCap_ChiTietInfo.IDTC_DanhSachTroCap = int.Parse(dtb.Rows[i]["IDTC_DanhSachTroCap"].ToString());
                    oTC_DanhSachTroCap_ChiTietInfo.Thang = int.Parse(dtb.Rows[i]["Thang"].ToString());
                    oTC_DanhSachTroCap_ChiTietInfo.SoTien = float.Parse(dtb.Rows[i]["SoTien"].ToString());
                    
                    oTC_DanhSachTroCap_ChiTietInfoList.Add(oTC_DanhSachTroCap_ChiTietInfo);
                }
            }
            return oTC_DanhSachTroCap_ChiTietInfoList;
        }
        
        public void ToDataRow(TC_DanhSachTroCap_ChiTietInfo pTC_DanhSachTroCap_ChiTietInfo, ref DataRow dr)
        {

			dr[pTC_DanhSachTroCap_ChiTietInfo.strTC_DanhSachTroCap_ChiTietID] = pTC_DanhSachTroCap_ChiTietInfo.TC_DanhSachTroCap_ChiTietID;
			dr[pTC_DanhSachTroCap_ChiTietInfo.strIDTC_DanhSachTroCap] = pTC_DanhSachTroCap_ChiTietInfo.IDTC_DanhSachTroCap;
			dr[pTC_DanhSachTroCap_ChiTietInfo.strThang] = pTC_DanhSachTroCap_ChiTietInfo.Thang;
			dr[pTC_DanhSachTroCap_ChiTietInfo.strSoTien] = pTC_DanhSachTroCap_ChiTietInfo.SoTien;
        }
        
        public void ToInfo(ref TC_DanhSachTroCap_ChiTietInfo pTC_DanhSachTroCap_ChiTietInfo, DataRow dr)
        {

			pTC_DanhSachTroCap_ChiTietInfo.TC_DanhSachTroCap_ChiTietID = int.Parse(dr[pTC_DanhSachTroCap_ChiTietInfo.strTC_DanhSachTroCap_ChiTietID].ToString());
			pTC_DanhSachTroCap_ChiTietInfo.IDTC_DanhSachTroCap = int.Parse(dr[pTC_DanhSachTroCap_ChiTietInfo.strIDTC_DanhSachTroCap].ToString());
			pTC_DanhSachTroCap_ChiTietInfo.Thang = int.Parse(dr[pTC_DanhSachTroCap_ChiTietInfo.strThang].ToString());
			pTC_DanhSachTroCap_ChiTietInfo.SoTien = float.Parse(dr[pTC_DanhSachTroCap_ChiTietInfo.strSoTien].ToString());
        }
    }
}
