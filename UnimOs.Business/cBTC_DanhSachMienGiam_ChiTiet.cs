using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBTC_DanhSachMienGiam_ChiTiet : cBBase
    {
        private cDTC_DanhSachMienGiam_ChiTiet oDTC_DanhSachMienGiam_ChiTiet;
        private TC_DanhSachMienGiam_ChiTietInfo oTC_DanhSachMienGiam_ChiTietInfo;

        public cBTC_DanhSachMienGiam_ChiTiet()        
        {
            oDTC_DanhSachMienGiam_ChiTiet = new cDTC_DanhSachMienGiam_ChiTiet();
        }

        public DataTable Get(TC_DanhSachMienGiam_ChiTietInfo pTC_DanhSachMienGiam_ChiTietInfo)        
        {
            return oDTC_DanhSachMienGiam_ChiTiet.Get(pTC_DanhSachMienGiam_ChiTietInfo);
        }

        public int Add(TC_DanhSachMienGiam_ChiTietInfo pTC_DanhSachMienGiam_ChiTietInfo)
        {
			int ID = 0;
            ID = oDTC_DanhSachMienGiam_ChiTiet.Add(pTC_DanhSachMienGiam_ChiTietInfo);
            mErrorMessage = oDTC_DanhSachMienGiam_ChiTiet.ErrorMessages;
            mErrorNumber = oDTC_DanhSachMienGiam_ChiTiet.ErrorNumber;
            return ID;
        }

        public void DeleteBy_MienGiam(int IDTC_DanhSachMienGiam)
        {
            oDTC_DanhSachMienGiam_ChiTiet.DeleteBy_MienGiam(IDTC_DanhSachMienGiam);
            mErrorMessage = oDTC_DanhSachMienGiam_ChiTiet.ErrorMessages;
            mErrorNumber = oDTC_DanhSachMienGiam_ChiTiet.ErrorNumber;
        }

        public void Update(TC_DanhSachMienGiam_ChiTietInfo pTC_DanhSachMienGiam_ChiTietInfo)
        {
            oDTC_DanhSachMienGiam_ChiTiet.Update(pTC_DanhSachMienGiam_ChiTietInfo);
            mErrorMessage = oDTC_DanhSachMienGiam_ChiTiet.ErrorMessages;
            mErrorNumber = oDTC_DanhSachMienGiam_ChiTiet.ErrorNumber;
        }
        
        public void Delete(TC_DanhSachMienGiam_ChiTietInfo pTC_DanhSachMienGiam_ChiTietInfo)
        {
            oDTC_DanhSachMienGiam_ChiTiet.Delete(pTC_DanhSachMienGiam_ChiTietInfo);
            mErrorMessage = oDTC_DanhSachMienGiam_ChiTiet.ErrorMessages;
            mErrorNumber = oDTC_DanhSachMienGiam_ChiTiet.ErrorNumber;
        }

        public List<TC_DanhSachMienGiam_ChiTietInfo> GetList(TC_DanhSachMienGiam_ChiTietInfo pTC_DanhSachMienGiam_ChiTietInfo)
        {
            List<TC_DanhSachMienGiam_ChiTietInfo> oTC_DanhSachMienGiam_ChiTietInfoList = new List<TC_DanhSachMienGiam_ChiTietInfo>();
            DataTable dtb = Get(pTC_DanhSachMienGiam_ChiTietInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTC_DanhSachMienGiam_ChiTietInfo = new TC_DanhSachMienGiam_ChiTietInfo();

                    oTC_DanhSachMienGiam_ChiTietInfo.TC_DanhSachMienGiam_ChiTietID = int.Parse(dtb.Rows[i]["TC_DanhSachMienGiam_ChiTietID"].ToString());
                    oTC_DanhSachMienGiam_ChiTietInfo.IDTC_DanhSachMienGiam = int.Parse(dtb.Rows[i]["IDTC_DanhSachMienGiam"].ToString());
                    oTC_DanhSachMienGiam_ChiTietInfo.Thang = int.Parse(dtb.Rows[i]["Thang"].ToString());
                    oTC_DanhSachMienGiam_ChiTietInfo.SoTien = float.Parse(dtb.Rows[i]["SoTien"].ToString());
                    
                    oTC_DanhSachMienGiam_ChiTietInfoList.Add(oTC_DanhSachMienGiam_ChiTietInfo);
                }
            }
            return oTC_DanhSachMienGiam_ChiTietInfoList;
        }
        
        public void ToDataRow(TC_DanhSachMienGiam_ChiTietInfo pTC_DanhSachMienGiam_ChiTietInfo, ref DataRow dr)
        {

			dr[pTC_DanhSachMienGiam_ChiTietInfo.strTC_DanhSachMienGiam_ChiTietID] = pTC_DanhSachMienGiam_ChiTietInfo.TC_DanhSachMienGiam_ChiTietID;
			dr[pTC_DanhSachMienGiam_ChiTietInfo.strIDTC_DanhSachMienGiam] = pTC_DanhSachMienGiam_ChiTietInfo.IDTC_DanhSachMienGiam;
			dr[pTC_DanhSachMienGiam_ChiTietInfo.strThang] = pTC_DanhSachMienGiam_ChiTietInfo.Thang;
			dr[pTC_DanhSachMienGiam_ChiTietInfo.strSoTien] = pTC_DanhSachMienGiam_ChiTietInfo.SoTien;
        }
        
        public void ToInfo(ref TC_DanhSachMienGiam_ChiTietInfo pTC_DanhSachMienGiam_ChiTietInfo, DataRow dr)
        {

			pTC_DanhSachMienGiam_ChiTietInfo.TC_DanhSachMienGiam_ChiTietID = int.Parse(dr[pTC_DanhSachMienGiam_ChiTietInfo.strTC_DanhSachMienGiam_ChiTietID].ToString());
			pTC_DanhSachMienGiam_ChiTietInfo.IDTC_DanhSachMienGiam = int.Parse(dr[pTC_DanhSachMienGiam_ChiTietInfo.strIDTC_DanhSachMienGiam].ToString());
			pTC_DanhSachMienGiam_ChiTietInfo.Thang = int.Parse(dr[pTC_DanhSachMienGiam_ChiTietInfo.strThang].ToString());
			pTC_DanhSachMienGiam_ChiTietInfo.SoTien = float.Parse(dr[pTC_DanhSachMienGiam_ChiTietInfo.strSoTien].ToString());
        }
    }
}
