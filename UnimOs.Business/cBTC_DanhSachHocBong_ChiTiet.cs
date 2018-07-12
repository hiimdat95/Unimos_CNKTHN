using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBTC_DanhSachHocBong_ChiTiet : cBBase
    {
        private cDTC_DanhSachHocBong_ChiTiet oDTC_DanhSachHocBong_ChiTiet;
        private TC_DanhSachHocBong_ChiTietInfo oTC_DanhSachHocBong_ChiTietInfo;

        public cBTC_DanhSachHocBong_ChiTiet()        
        {
            oDTC_DanhSachHocBong_ChiTiet = new cDTC_DanhSachHocBong_ChiTiet();
        }

        public DataTable Get(TC_DanhSachHocBong_ChiTietInfo pTC_DanhSachHocBong_ChiTietInfo)        
        {
            return oDTC_DanhSachHocBong_ChiTiet.Get(pTC_DanhSachHocBong_ChiTietInfo);
        }

        public int Add(TC_DanhSachHocBong_ChiTietInfo pTC_DanhSachHocBong_ChiTietInfo)
        {
			int ID = 0;
            ID = oDTC_DanhSachHocBong_ChiTiet.Add(pTC_DanhSachHocBong_ChiTietInfo);
            mErrorMessage = oDTC_DanhSachHocBong_ChiTiet.ErrorMessages;
            mErrorNumber = oDTC_DanhSachHocBong_ChiTiet.ErrorNumber;
            return ID;
        }

        public void Update(TC_DanhSachHocBong_ChiTietInfo pTC_DanhSachHocBong_ChiTietInfo)
        {
            oDTC_DanhSachHocBong_ChiTiet.Update(pTC_DanhSachHocBong_ChiTietInfo);
            mErrorMessage = oDTC_DanhSachHocBong_ChiTiet.ErrorMessages;
            mErrorNumber = oDTC_DanhSachHocBong_ChiTiet.ErrorNumber;
        }

        public void UpdateThieuCong(TC_DanhSachHocBong_ChiTietInfo pTC_DanhSachHocBong_ChiTietInfo)
        {
            oDTC_DanhSachHocBong_ChiTiet.UpdateThieuCong(pTC_DanhSachHocBong_ChiTietInfo);
            mErrorMessage = oDTC_DanhSachHocBong_ChiTiet.ErrorMessages;
            mErrorNumber = oDTC_DanhSachHocBong_ChiTiet.ErrorNumber;
        }
        
        public void Delete(TC_DanhSachHocBong_ChiTietInfo pTC_DanhSachHocBong_ChiTietInfo)
        {
            oDTC_DanhSachHocBong_ChiTiet.Delete(pTC_DanhSachHocBong_ChiTietInfo);
            mErrorMessage = oDTC_DanhSachHocBong_ChiTiet.ErrorMessages;
            mErrorNumber = oDTC_DanhSachHocBong_ChiTiet.ErrorNumber;
        }

        public void DeleteBy_HocBong(int IDTC_DanhSachHocBong)
        {
            oDTC_DanhSachHocBong_ChiTiet.DeleteBy_HocBong(IDTC_DanhSachHocBong);
            mErrorMessage = oDTC_DanhSachHocBong_ChiTiet.ErrorMessages;
            mErrorNumber = oDTC_DanhSachHocBong_ChiTiet.ErrorNumber;
        }

        public List<TC_DanhSachHocBong_ChiTietInfo> GetList(TC_DanhSachHocBong_ChiTietInfo pTC_DanhSachHocBong_ChiTietInfo)
        {
            List<TC_DanhSachHocBong_ChiTietInfo> oTC_DanhSachHocBong_ChiTietInfoList = new List<TC_DanhSachHocBong_ChiTietInfo>();
            DataTable dtb = Get(pTC_DanhSachHocBong_ChiTietInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTC_DanhSachHocBong_ChiTietInfo = new TC_DanhSachHocBong_ChiTietInfo();

                    oTC_DanhSachHocBong_ChiTietInfo.TC_DanhSachHocBong_ChiTietID = int.Parse(dtb.Rows[i]["TC_DanhSachHocBong_ChiTietID"].ToString());
                    oTC_DanhSachHocBong_ChiTietInfo.IDTC_DanhSachHocBong = int.Parse(dtb.Rows[i]["IDTC_DanhSachHocBong"].ToString());
                    oTC_DanhSachHocBong_ChiTietInfo.Thang = int.Parse(dtb.Rows[i]["Thang"].ToString());
                    oTC_DanhSachHocBong_ChiTietInfo.SoTien = float.Parse(dtb.Rows[i]["SoTien"].ToString());
                    
                    oTC_DanhSachHocBong_ChiTietInfoList.Add(oTC_DanhSachHocBong_ChiTietInfo);
                }
            }
            return oTC_DanhSachHocBong_ChiTietInfoList;
        }
        
        public void ToDataRow(TC_DanhSachHocBong_ChiTietInfo pTC_DanhSachHocBong_ChiTietInfo, ref DataRow dr)
        {

			dr[pTC_DanhSachHocBong_ChiTietInfo.strTC_DanhSachHocBong_ChiTietID] = pTC_DanhSachHocBong_ChiTietInfo.TC_DanhSachHocBong_ChiTietID;
			dr[pTC_DanhSachHocBong_ChiTietInfo.strIDTC_DanhSachHocBong] = pTC_DanhSachHocBong_ChiTietInfo.IDTC_DanhSachHocBong;
			dr[pTC_DanhSachHocBong_ChiTietInfo.strThang] = pTC_DanhSachHocBong_ChiTietInfo.Thang;
			dr[pTC_DanhSachHocBong_ChiTietInfo.strSoTien] = pTC_DanhSachHocBong_ChiTietInfo.SoTien;
        }
        
        public void ToInfo(ref TC_DanhSachHocBong_ChiTietInfo pTC_DanhSachHocBong_ChiTietInfo, DataRow dr)
        {

			pTC_DanhSachHocBong_ChiTietInfo.TC_DanhSachHocBong_ChiTietID = int.Parse(dr[pTC_DanhSachHocBong_ChiTietInfo.strTC_DanhSachHocBong_ChiTietID].ToString());
			pTC_DanhSachHocBong_ChiTietInfo.IDTC_DanhSachHocBong = int.Parse(dr[pTC_DanhSachHocBong_ChiTietInfo.strIDTC_DanhSachHocBong].ToString());
			pTC_DanhSachHocBong_ChiTietInfo.Thang = int.Parse(dr[pTC_DanhSachHocBong_ChiTietInfo.strThang].ToString());
			pTC_DanhSachHocBong_ChiTietInfo.SoTien = float.Parse(dr[pTC_DanhSachHocBong_ChiTietInfo.strSoTien].ToString());
        }
    }
}
