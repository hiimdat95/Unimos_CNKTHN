using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBSV_SinhVien_ThongTinKhac : cBBase
    {
        private cDSV_SinhVien_ThongTinKhac oDSV_SinhVien_ThongTinKhac;
        private SV_SinhVien_ThongTinKhacInfo oSV_SinhVien_ThongTinKhacInfo;

        public cBSV_SinhVien_ThongTinKhac()        
        {
            oDSV_SinhVien_ThongTinKhac = new cDSV_SinhVien_ThongTinKhac();
        }

        public DataTable Get(SV_SinhVien_ThongTinKhacInfo pSV_SinhVien_ThongTinKhacInfo)        
        {
            return oDSV_SinhVien_ThongTinKhac.Get(pSV_SinhVien_ThongTinKhacInfo);
        }

        public int Add(SV_SinhVien_ThongTinKhacInfo pSV_SinhVien_ThongTinKhacInfo)
        {
			int ID = 0;
            ID = oDSV_SinhVien_ThongTinKhac.Add(pSV_SinhVien_ThongTinKhacInfo);
            mErrorMessage = oDSV_SinhVien_ThongTinKhac.ErrorMessages;
            mErrorNumber = oDSV_SinhVien_ThongTinKhac.ErrorNumber;
            return ID;
        }

        public void Update(SV_SinhVien_ThongTinKhacInfo pSV_SinhVien_ThongTinKhacInfo)
        {
            oDSV_SinhVien_ThongTinKhac.Update(pSV_SinhVien_ThongTinKhacInfo);
            mErrorMessage = oDSV_SinhVien_ThongTinKhac.ErrorMessages;
            mErrorNumber = oDSV_SinhVien_ThongTinKhac.ErrorNumber;
        }

        public void UpdateHoSo(SV_SinhVien_ThongTinKhacInfo pSV_SinhVien_ThongTinKhacInfo)
        {
            oDSV_SinhVien_ThongTinKhac.UpdateHoSo(pSV_SinhVien_ThongTinKhacInfo);
            mErrorMessage = oDSV_SinhVien_ThongTinKhac.ErrorMessages;
            mErrorNumber = oDSV_SinhVien_ThongTinKhac.ErrorNumber;
        }
        
        public void Delete(SV_SinhVien_ThongTinKhacInfo pSV_SinhVien_ThongTinKhacInfo)
        {
            oDSV_SinhVien_ThongTinKhac.Delete(pSV_SinhVien_ThongTinKhacInfo);
            mErrorMessage = oDSV_SinhVien_ThongTinKhac.ErrorMessages;
            mErrorNumber = oDSV_SinhVien_ThongTinKhac.ErrorNumber;
        }

        public List<SV_SinhVien_ThongTinKhacInfo> GetList(SV_SinhVien_ThongTinKhacInfo pSV_SinhVien_ThongTinKhacInfo)
        {
            List<SV_SinhVien_ThongTinKhacInfo> oSV_SinhVien_ThongTinKhacInfoList = new List<SV_SinhVien_ThongTinKhacInfo>();
            DataTable dtb = Get(pSV_SinhVien_ThongTinKhacInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oSV_SinhVien_ThongTinKhacInfo = new SV_SinhVien_ThongTinKhacInfo();

                    oSV_SinhVien_ThongTinKhacInfo.SV_SinhVien_ThongTinKhacID = int.Parse(dtb.Rows[i]["SV_SinhVien_ThongTinKhacID"].ToString());
                    oSV_SinhVien_ThongTinKhacInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oSV_SinhVien_ThongTinKhacInfo.KhenThuongKyLuat = dtb.Rows[i]["KhenThuongKyLuat"].ToString();
                    oSV_SinhVien_ThongTinKhacInfo.QuaTrinhHocTapCongTac = dtb.Rows[i]["QuaTrinhHocTapCongTac"].ToString();
                    
                    oSV_SinhVien_ThongTinKhacInfoList.Add(oSV_SinhVien_ThongTinKhacInfo);
                }
            }
            return oSV_SinhVien_ThongTinKhacInfoList;
        }
        
        public void ToDataRow(SV_SinhVien_ThongTinKhacInfo pSV_SinhVien_ThongTinKhacInfo, ref DataRow dr)
        {

			dr[pSV_SinhVien_ThongTinKhacInfo.strSV_SinhVien_ThongTinKhacID] = pSV_SinhVien_ThongTinKhacInfo.SV_SinhVien_ThongTinKhacID;
			dr[pSV_SinhVien_ThongTinKhacInfo.strIDSV_SinhVien] = pSV_SinhVien_ThongTinKhacInfo.IDSV_SinhVien;
			dr[pSV_SinhVien_ThongTinKhacInfo.strKhenThuongKyLuat] = pSV_SinhVien_ThongTinKhacInfo.KhenThuongKyLuat;
			dr[pSV_SinhVien_ThongTinKhacInfo.strQuaTrinhHocTapCongTac] = pSV_SinhVien_ThongTinKhacInfo.QuaTrinhHocTapCongTac;
        }
        
        public void ToInfo(ref SV_SinhVien_ThongTinKhacInfo pSV_SinhVien_ThongTinKhacInfo, DataRow dr)
        {

			pSV_SinhVien_ThongTinKhacInfo.SV_SinhVien_ThongTinKhacID = int.Parse(dr[pSV_SinhVien_ThongTinKhacInfo.strSV_SinhVien_ThongTinKhacID].ToString());
			pSV_SinhVien_ThongTinKhacInfo.IDSV_SinhVien = int.Parse(dr[pSV_SinhVien_ThongTinKhacInfo.strIDSV_SinhVien].ToString());
			pSV_SinhVien_ThongTinKhacInfo.KhenThuongKyLuat = dr[pSV_SinhVien_ThongTinKhacInfo.strKhenThuongKyLuat].ToString();
			pSV_SinhVien_ThongTinKhacInfo.QuaTrinhHocTapCongTac = dr[pSV_SinhVien_ThongTinKhacInfo.strQuaTrinhHocTapCongTac].ToString();
        }
    }
}
