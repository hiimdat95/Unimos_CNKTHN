using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_HoiDongMon_ChiTiet : cBBase
    {
        private cDKQHT_HoiDongMon_ChiTiet oDKQHT_HoiDongMon_ChiTiet;
        private KQHT_HoiDongMon_ChiTietInfo oKQHT_HoiDongMon_ChiTietInfo;

        public cBKQHT_HoiDongMon_ChiTiet()        
        {
            oDKQHT_HoiDongMon_ChiTiet = new cDKQHT_HoiDongMon_ChiTiet();
        }

        public DataTable Get(KQHT_HoiDongMon_ChiTietInfo pKQHT_HoiDongMon_ChiTietInfo)        
        {
            return oDKQHT_HoiDongMon_ChiTiet.Get(pKQHT_HoiDongMon_ChiTietInfo);
        }

        public DataTable GetByIDHoiDong(int IDKQHT_HoiDongMon)
        {
            return oDKQHT_HoiDongMon_ChiTiet.GetByIDHoiDong(IDKQHT_HoiDongMon);
        }

        public int Add(KQHT_HoiDongMon_ChiTietInfo pKQHT_HoiDongMon_ChiTietInfo)
        {
			int ID = 0;
            ID = oDKQHT_HoiDongMon_ChiTiet.Add(pKQHT_HoiDongMon_ChiTietInfo);
            mErrorMessage = oDKQHT_HoiDongMon_ChiTiet.ErrorMessages;
            mErrorNumber = oDKQHT_HoiDongMon_ChiTiet.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_HoiDongMon_ChiTietInfo pKQHT_HoiDongMon_ChiTietInfo)
        {
            oDKQHT_HoiDongMon_ChiTiet.Update(pKQHT_HoiDongMon_ChiTietInfo);
            mErrorMessage = oDKQHT_HoiDongMon_ChiTiet.ErrorMessages;
            mErrorNumber = oDKQHT_HoiDongMon_ChiTiet.ErrorNumber;
        }
        
        public void Delete(KQHT_HoiDongMon_ChiTietInfo pKQHT_HoiDongMon_ChiTietInfo)
        {
            oDKQHT_HoiDongMon_ChiTiet.Delete(pKQHT_HoiDongMon_ChiTietInfo);
            mErrorMessage = oDKQHT_HoiDongMon_ChiTiet.ErrorMessages;
            mErrorNumber = oDKQHT_HoiDongMon_ChiTiet.ErrorNumber;
        }

        public List<KQHT_HoiDongMon_ChiTietInfo> GetList(KQHT_HoiDongMon_ChiTietInfo pKQHT_HoiDongMon_ChiTietInfo)
        {
            List<KQHT_HoiDongMon_ChiTietInfo> oKQHT_HoiDongMon_ChiTietInfoList = new List<KQHT_HoiDongMon_ChiTietInfo>();
            DataTable dtb = Get(pKQHT_HoiDongMon_ChiTietInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_HoiDongMon_ChiTietInfo = new KQHT_HoiDongMon_ChiTietInfo();

                    oKQHT_HoiDongMon_ChiTietInfo.KQHT_HoiDongMon_ChiTietID = int.Parse(dtb.Rows[i]["KQHT_HoiDongMon_ChiTietID"].ToString());
                    oKQHT_HoiDongMon_ChiTietInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oKQHT_HoiDongMon_ChiTietInfo.TyLe = double.Parse(dtb.Rows[i]["TyLe"].ToString());
                    oKQHT_HoiDongMon_ChiTietInfo.HoTen = dtb.Rows[i]["HoTen"].ToString();
                    oKQHT_HoiDongMon_ChiTietInfo.ChucVu = dtb.Rows[i]["ChucVu"].ToString();
                    oKQHT_HoiDongMon_ChiTietInfo.DonViCongTac = dtb.Rows[i]["DonViCongTac"].ToString();
                    
                    oKQHT_HoiDongMon_ChiTietInfoList.Add(oKQHT_HoiDongMon_ChiTietInfo);
                }
            }
            return oKQHT_HoiDongMon_ChiTietInfoList;
        }
        
        public void ToDataRow(KQHT_HoiDongMon_ChiTietInfo pKQHT_HoiDongMon_ChiTietInfo, ref DataRow dr)
        {

			dr[pKQHT_HoiDongMon_ChiTietInfo.strKQHT_HoiDongMon_ChiTietID] = pKQHT_HoiDongMon_ChiTietInfo.KQHT_HoiDongMon_ChiTietID;
            dr[pKQHT_HoiDongMon_ChiTietInfo.strIDKQHT_HoiDongMon] = pKQHT_HoiDongMon_ChiTietInfo.IDKQHT_HoiDongMon;
			dr[pKQHT_HoiDongMon_ChiTietInfo.strIDNS_GiaoVien] = pKQHT_HoiDongMon_ChiTietInfo.IDNS_GiaoVien;
			dr[pKQHT_HoiDongMon_ChiTietInfo.strTyLe] = pKQHT_HoiDongMon_ChiTietInfo.TyLe;
			dr[pKQHT_HoiDongMon_ChiTietInfo.strHoTen] = pKQHT_HoiDongMon_ChiTietInfo.HoTen;
			dr[pKQHT_HoiDongMon_ChiTietInfo.strChucVu] = pKQHT_HoiDongMon_ChiTietInfo.ChucVu;
			dr[pKQHT_HoiDongMon_ChiTietInfo.strDonViCongTac] = pKQHT_HoiDongMon_ChiTietInfo.DonViCongTac;
        }
        
        public void ToInfo(ref KQHT_HoiDongMon_ChiTietInfo pKQHT_HoiDongMon_ChiTietInfo, DataRow dr)
        {

			pKQHT_HoiDongMon_ChiTietInfo.KQHT_HoiDongMon_ChiTietID = int.Parse(dr[pKQHT_HoiDongMon_ChiTietInfo.strKQHT_HoiDongMon_ChiTietID].ToString());
            pKQHT_HoiDongMon_ChiTietInfo.IDKQHT_HoiDongMon = int.Parse(dr[pKQHT_HoiDongMon_ChiTietInfo.strIDKQHT_HoiDongMon].ToString());
			pKQHT_HoiDongMon_ChiTietInfo.IDNS_GiaoVien = int.Parse("0" + dr[pKQHT_HoiDongMon_ChiTietInfo.strIDNS_GiaoVien].ToString());
			pKQHT_HoiDongMon_ChiTietInfo.TyLe = double.Parse(dr[pKQHT_HoiDongMon_ChiTietInfo.strTyLe].ToString());
			pKQHT_HoiDongMon_ChiTietInfo.HoTen = dr[pKQHT_HoiDongMon_ChiTietInfo.strHoTen].ToString();
			pKQHT_HoiDongMon_ChiTietInfo.ChucVu = dr[pKQHT_HoiDongMon_ChiTietInfo.strChucVu].ToString();
			pKQHT_HoiDongMon_ChiTietInfo.DonViCongTac = dr[pKQHT_HoiDongMon_ChiTietInfo.strDonViCongTac].ToString();
        }
    }
}
