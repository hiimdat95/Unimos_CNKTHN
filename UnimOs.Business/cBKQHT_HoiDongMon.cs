using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_HoiDongMon : cBBase
    {
        private cDKQHT_HoiDongMon oDKQHT_HoiDongMon;
        private KQHT_HoiDongMonInfo oKQHT_HoiDongMonInfo;

        public cBKQHT_HoiDongMon()        
        {
            oDKQHT_HoiDongMon = new cDKQHT_HoiDongMon();
        }

        public DataTable Get(KQHT_HoiDongMonInfo pKQHT_HoiDongMonInfo)        
        {
            return oDKQHT_HoiDongMon.Get(pKQHT_HoiDongMonInfo);
        }

        public DataTable GetByNamHocHocKy(int IDDM_NamHoc, int HocKy)        
        {
            return oDKQHT_HoiDongMon.GetByNamHocHocKy(IDDM_NamHoc, HocKy);
        }

        public DataTable GetSinhVien(int KQHT_HoiDongMonID)
        {
            return oDKQHT_HoiDongMon.GetSinhVien(KQHT_HoiDongMonID);
        }

        public DataTable GetGiangVien(int KQHT_HoiDongMonID)
        {
            return oDKQHT_HoiDongMon.GetGiangVien(KQHT_HoiDongMonID);
        }

        public int Add(KQHT_HoiDongMonInfo pKQHT_HoiDongMonInfo)
        {
			int ID = 0;
            ID = oDKQHT_HoiDongMon.Add(pKQHT_HoiDongMonInfo);
            mErrorMessage = oDKQHT_HoiDongMon.ErrorMessages;
            mErrorNumber = oDKQHT_HoiDongMon.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_HoiDongMonInfo pKQHT_HoiDongMonInfo)
        {
            oDKQHT_HoiDongMon.Update(pKQHT_HoiDongMonInfo);
            mErrorMessage = oDKQHT_HoiDongMon.ErrorMessages;
            mErrorNumber = oDKQHT_HoiDongMon.ErrorNumber;
        }
        
        public void Delete(KQHT_HoiDongMonInfo pKQHT_HoiDongMonInfo)
        {
            oDKQHT_HoiDongMon.Delete(pKQHT_HoiDongMonInfo);
            mErrorMessage = oDKQHT_HoiDongMon.ErrorMessages;
            mErrorNumber = oDKQHT_HoiDongMon.ErrorNumber;
        }

        public List<KQHT_HoiDongMonInfo> GetList(KQHT_HoiDongMonInfo pKQHT_HoiDongMonInfo)
        {
            List<KQHT_HoiDongMonInfo> oKQHT_HoiDongMonInfoList = new List<KQHT_HoiDongMonInfo>();
            DataTable dtb = Get(pKQHT_HoiDongMonInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_HoiDongMonInfo = new KQHT_HoiDongMonInfo();

                    oKQHT_HoiDongMonInfo.KQHT_HoiDongMonID = int.Parse(dtb.Rows[i]["KQHT_HoiDongMonID"].ToString());
                    oKQHT_HoiDongMonInfo.TenHoiDong = dtb.Rows[i]["TenHoiDong"].ToString();
                    oKQHT_HoiDongMonInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
                    oKQHT_HoiDongMonInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oKQHT_HoiDongMonInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    
                    oKQHT_HoiDongMonInfoList.Add(oKQHT_HoiDongMonInfo);
                }
            }
            return oKQHT_HoiDongMonInfoList;
        }
        
        public void ToDataRow(KQHT_HoiDongMonInfo pKQHT_HoiDongMonInfo, ref DataRow dr)
        {

			dr[pKQHT_HoiDongMonInfo.strKQHT_HoiDongMonID] = pKQHT_HoiDongMonInfo.KQHT_HoiDongMonID;
			dr[pKQHT_HoiDongMonInfo.strTenHoiDong] = pKQHT_HoiDongMonInfo.TenHoiDong;
			dr[pKQHT_HoiDongMonInfo.strIDDM_MonHoc] = pKQHT_HoiDongMonInfo.IDDM_MonHoc;
			dr[pKQHT_HoiDongMonInfo.strIDDM_NamHoc] = pKQHT_HoiDongMonInfo.IDDM_NamHoc;
			dr[pKQHT_HoiDongMonInfo.strHocKy] = pKQHT_HoiDongMonInfo.HocKy;
        }
        
        public void ToInfo(ref KQHT_HoiDongMonInfo pKQHT_HoiDongMonInfo, DataRow dr)
        {

			pKQHT_HoiDongMonInfo.KQHT_HoiDongMonID = int.Parse(dr[pKQHT_HoiDongMonInfo.strKQHT_HoiDongMonID].ToString());
			pKQHT_HoiDongMonInfo.TenHoiDong = dr[pKQHT_HoiDongMonInfo.strTenHoiDong].ToString();
			pKQHT_HoiDongMonInfo.IDDM_MonHoc = int.Parse(dr[pKQHT_HoiDongMonInfo.strIDDM_MonHoc].ToString());
			pKQHT_HoiDongMonInfo.IDDM_NamHoc = int.Parse(dr[pKQHT_HoiDongMonInfo.strIDDM_NamHoc].ToString());
			pKQHT_HoiDongMonInfo.HocKy = int.Parse(dr[pKQHT_HoiDongMonInfo.strHocKy].ToString());
        }
    }
}
