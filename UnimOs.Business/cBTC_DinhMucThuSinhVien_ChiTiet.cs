using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBTC_DinhMucThuSinhVien_ChiTiet : cBBase
    {
        private cDTC_DinhMucThuSinhVien_ChiTiet oDTC_DinhMucThuSinhVien_ChiTiet;
        private TC_DinhMucThuSinhVien_ChiTietInfo oTC_DinhMucThuSinhVien_ChiTietInfo;

        public cBTC_DinhMucThuSinhVien_ChiTiet()        
        {
            oDTC_DinhMucThuSinhVien_ChiTiet = new cDTC_DinhMucThuSinhVien_ChiTiet();
        }

        public DataTable Get(TC_DinhMucThuSinhVien_ChiTietInfo pTC_DinhMucThuSinhVien_ChiTietInfo)        
        {
            return oDTC_DinhMucThuSinhVien_ChiTiet.Get(pTC_DinhMucThuSinhVien_ChiTietInfo);
        }

        public int Add(TC_DinhMucThuSinhVien_ChiTietInfo pTC_DinhMucThuSinhVien_ChiTietInfo)
        {
			int ID = 0;
            ID = oDTC_DinhMucThuSinhVien_ChiTiet.Add(pTC_DinhMucThuSinhVien_ChiTietInfo);
            mErrorMessage = oDTC_DinhMucThuSinhVien_ChiTiet.ErrorMessages;
            mErrorNumber = oDTC_DinhMucThuSinhVien_ChiTiet.ErrorNumber;
            return ID;
        }

        public void Update(TC_DinhMucThuSinhVien_ChiTietInfo pTC_DinhMucThuSinhVien_ChiTietInfo)
        {
            oDTC_DinhMucThuSinhVien_ChiTiet.Update(pTC_DinhMucThuSinhVien_ChiTietInfo);
            mErrorMessage = oDTC_DinhMucThuSinhVien_ChiTiet.ErrorMessages;
            mErrorNumber = oDTC_DinhMucThuSinhVien_ChiTiet.ErrorNumber;
        }
        
        public void Delete(TC_DinhMucThuSinhVien_ChiTietInfo pTC_DinhMucThuSinhVien_ChiTietInfo)
        {
            oDTC_DinhMucThuSinhVien_ChiTiet.Delete(pTC_DinhMucThuSinhVien_ChiTietInfo);
            mErrorMessage = oDTC_DinhMucThuSinhVien_ChiTiet.ErrorMessages;
            mErrorNumber = oDTC_DinhMucThuSinhVien_ChiTiet.ErrorNumber;
        }
        public void DeleteBy_DinhMucThu(int IDTC_DinhMucThuSinhVien)
        {
            oDTC_DinhMucThuSinhVien_ChiTiet.DeleteBy_DinhMucThu(IDTC_DinhMucThuSinhVien);
            mErrorMessage = oDTC_DinhMucThuSinhVien_ChiTiet.ErrorMessages;
            mErrorNumber = oDTC_DinhMucThuSinhVien_ChiTiet.ErrorNumber;
        }
        public List<TC_DinhMucThuSinhVien_ChiTietInfo> GetList(TC_DinhMucThuSinhVien_ChiTietInfo pTC_DinhMucThuSinhVien_ChiTietInfo)
        {
            List<TC_DinhMucThuSinhVien_ChiTietInfo> oTC_DinhMucThuSinhVien_ChiTietInfoList = new List<TC_DinhMucThuSinhVien_ChiTietInfo>();
            DataTable dtb = Get(pTC_DinhMucThuSinhVien_ChiTietInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oTC_DinhMucThuSinhVien_ChiTietInfo = new TC_DinhMucThuSinhVien_ChiTietInfo();

                    oTC_DinhMucThuSinhVien_ChiTietInfo.TC_DinhMucThuSinhVien_ChiTietID = int.Parse(dtb.Rows[i]["TC_DinhMucThuSinhVien_ChiTietID"].ToString());
                    oTC_DinhMucThuSinhVien_ChiTietInfo.IDTC_DinhMucThuSinhVien = int.Parse(dtb.Rows[i]["IDTC_DinhMucThuSinhVien"].ToString());
                    oTC_DinhMucThuSinhVien_ChiTietInfo.Thang = int.Parse(dtb.Rows[i]["Thang"].ToString());
                    oTC_DinhMucThuSinhVien_ChiTietInfo.SoTien = double.Parse(dtb.Rows[i]["SoTien"].ToString());
                    
                    oTC_DinhMucThuSinhVien_ChiTietInfoList.Add(oTC_DinhMucThuSinhVien_ChiTietInfo);
                }
            }
            return oTC_DinhMucThuSinhVien_ChiTietInfoList;
        }
        
        public void ToDataRow(TC_DinhMucThuSinhVien_ChiTietInfo pTC_DinhMucThuSinhVien_ChiTietInfo, ref DataRow dr)
        {

			dr[pTC_DinhMucThuSinhVien_ChiTietInfo.strTC_DinhMucThuSinhVien_ChiTietID] = pTC_DinhMucThuSinhVien_ChiTietInfo.TC_DinhMucThuSinhVien_ChiTietID;
			dr[pTC_DinhMucThuSinhVien_ChiTietInfo.strIDTC_DinhMucThuSinhVien] = pTC_DinhMucThuSinhVien_ChiTietInfo.IDTC_DinhMucThuSinhVien;
			dr[pTC_DinhMucThuSinhVien_ChiTietInfo.strThang] = pTC_DinhMucThuSinhVien_ChiTietInfo.Thang;
			dr[pTC_DinhMucThuSinhVien_ChiTietInfo.strSoTien] = pTC_DinhMucThuSinhVien_ChiTietInfo.SoTien;
        }
        
        public void ToInfo(ref TC_DinhMucThuSinhVien_ChiTietInfo pTC_DinhMucThuSinhVien_ChiTietInfo, DataRow dr)
        {

			pTC_DinhMucThuSinhVien_ChiTietInfo.TC_DinhMucThuSinhVien_ChiTietID = int.Parse(dr[pTC_DinhMucThuSinhVien_ChiTietInfo.strTC_DinhMucThuSinhVien_ChiTietID].ToString());
			pTC_DinhMucThuSinhVien_ChiTietInfo.IDTC_DinhMucThuSinhVien = int.Parse(dr[pTC_DinhMucThuSinhVien_ChiTietInfo.strIDTC_DinhMucThuSinhVien].ToString());
			pTC_DinhMucThuSinhVien_ChiTietInfo.Thang = int.Parse(dr[pTC_DinhMucThuSinhVien_ChiTietInfo.strThang].ToString());
			pTC_DinhMucThuSinhVien_ChiTietInfo.SoTien = double.Parse(dr[pTC_DinhMucThuSinhVien_ChiTietInfo.strSoTien].ToString());
        }
    }
}
