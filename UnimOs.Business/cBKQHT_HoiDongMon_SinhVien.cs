using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_HoiDongMon_SinhVien : cBBase
    {
        private cDKQHT_HoiDongMon_SinhVien oDKQHT_HoiDongMon_SinhVien;
        private KQHT_HoiDongMon_SinhVienInfo oKQHT_HoiDongMon_SinhVienInfo;

        public cBKQHT_HoiDongMon_SinhVien()        
        {
            oDKQHT_HoiDongMon_SinhVien = new cDKQHT_HoiDongMon_SinhVien();
        }

        public DataTable Get(KQHT_HoiDongMon_SinhVienInfo pKQHT_HoiDongMon_SinhVienInfo)        
        {
            return oDKQHT_HoiDongMon_SinhVien.Get(pKQHT_HoiDongMon_SinhVienInfo);
        }

        public DataTable GetByThiTotNghiep(int IDDM_Lop, int IDDM_MonHOc, int IDDM_NamHOc, int HocKy, int IDKQHT_HoiDongMon)
        {
            return oDKQHT_HoiDongMon_SinhVien.GetByThiTotNghiep(IDDM_Lop, IDDM_MonHOc, IDDM_NamHOc, HocKy, IDKQHT_HoiDongMon);
        }
        public int Add(KQHT_HoiDongMon_SinhVienInfo pKQHT_HoiDongMon_SinhVienInfo)
        {
			int ID = 0;
            ID = oDKQHT_HoiDongMon_SinhVien.Add(pKQHT_HoiDongMon_SinhVienInfo);
            mErrorMessage = oDKQHT_HoiDongMon_SinhVien.ErrorMessages;
            mErrorNumber = oDKQHT_HoiDongMon_SinhVien.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_HoiDongMon_SinhVienInfo pKQHT_HoiDongMon_SinhVienInfo)
        {
            oDKQHT_HoiDongMon_SinhVien.Update(pKQHT_HoiDongMon_SinhVienInfo);
            mErrorMessage = oDKQHT_HoiDongMon_SinhVien.ErrorMessages;
            mErrorNumber = oDKQHT_HoiDongMon_SinhVien.ErrorNumber;
        }
        
        public void Delete(KQHT_HoiDongMon_SinhVienInfo pKQHT_HoiDongMon_SinhVienInfo)
        {
            oDKQHT_HoiDongMon_SinhVien.Delete(pKQHT_HoiDongMon_SinhVienInfo);
            mErrorMessage = oDKQHT_HoiDongMon_SinhVien.ErrorMessages;
            mErrorNumber = oDKQHT_HoiDongMon_SinhVien.ErrorNumber;
        }

        public List<KQHT_HoiDongMon_SinhVienInfo> GetList(KQHT_HoiDongMon_SinhVienInfo pKQHT_HoiDongMon_SinhVienInfo)
        {
            List<KQHT_HoiDongMon_SinhVienInfo> oKQHT_HoiDongMon_SinhVienInfoList = new List<KQHT_HoiDongMon_SinhVienInfo>();
            DataTable dtb = Get(pKQHT_HoiDongMon_SinhVienInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_HoiDongMon_SinhVienInfo = new KQHT_HoiDongMon_SinhVienInfo();

                    oKQHT_HoiDongMon_SinhVienInfo.KQHT_HoiDongMon_SinhVienID = int.Parse(dtb.Rows[i]["KQHT_HoiDongMon_SinhVienID"].ToString());
                    oKQHT_HoiDongMon_SinhVienInfo.IDKQHT_HoiDongMon = int.Parse(dtb.Rows[i]["IDKQHT_HoiDongMon"].ToString());
                    oKQHT_HoiDongMon_SinhVienInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    
                    oKQHT_HoiDongMon_SinhVienInfoList.Add(oKQHT_HoiDongMon_SinhVienInfo);
                }
            }
            return oKQHT_HoiDongMon_SinhVienInfoList;
        }
        
        public void ToDataRow(KQHT_HoiDongMon_SinhVienInfo pKQHT_HoiDongMon_SinhVienInfo, ref DataRow dr)
        {

			dr[pKQHT_HoiDongMon_SinhVienInfo.strKQHT_HoiDongMon_SinhVienID] = pKQHT_HoiDongMon_SinhVienInfo.KQHT_HoiDongMon_SinhVienID;
			dr[pKQHT_HoiDongMon_SinhVienInfo.strIDKQHT_HoiDongMon] = pKQHT_HoiDongMon_SinhVienInfo.IDKQHT_HoiDongMon;
			dr[pKQHT_HoiDongMon_SinhVienInfo.strIDSV_SinhVien] = pKQHT_HoiDongMon_SinhVienInfo.IDSV_SinhVien;
        }
        
        public void ToInfo(ref KQHT_HoiDongMon_SinhVienInfo pKQHT_HoiDongMon_SinhVienInfo, DataRow dr)
        {

			pKQHT_HoiDongMon_SinhVienInfo.KQHT_HoiDongMon_SinhVienID = int.Parse(dr[pKQHT_HoiDongMon_SinhVienInfo.strKQHT_HoiDongMon_SinhVienID].ToString());
			pKQHT_HoiDongMon_SinhVienInfo.IDKQHT_HoiDongMon = int.Parse(dr[pKQHT_HoiDongMon_SinhVienInfo.strIDKQHT_HoiDongMon].ToString());
			pKQHT_HoiDongMon_SinhVienInfo.IDSV_SinhVien = int.Parse(dr[pKQHT_HoiDongMon_SinhVienInfo.strIDSV_SinhVien].ToString());
        }
    }
}
