using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBHT_ThamSoHeThong : cBBase
    {
        private cDHT_ThamSoHeThong oDHT_ThamSoHeThong;
        private HT_ThamSoHeThongInfo oHT_ThamSoHeThongInfo;

        public cBHT_ThamSoHeThong()        
        {
            oDHT_ThamSoHeThong = new cDHT_ThamSoHeThong();
        }

        public DataTable Get(HT_ThamSoHeThongInfo pHT_ThamSoHeThongInfo)        
        {
            return oDHT_ThamSoHeThong.Get(pHT_ThamSoHeThongInfo);
        }

        public DataTable GetByMaThamSo(string MaThamSoHeThong)
        {
            return oDHT_ThamSoHeThong.GetByMaThamSo(MaThamSoHeThong);
        }

        public string GetGiaTriByMaThamSo(string MaThamSoHeThong)
        {
            DataTable dt = GetByMaThamSo(MaThamSoHeThong);
            if (dt.Rows.Count > 0)
                return "" + dt.Rows[0]["GiaTri"];
            return "";
        }

        public DataTable GetByPhanHe(int PhanHe)
        {
            return oDHT_ThamSoHeThong.GetByPhanHe(PhanHe);
        }

        public int Add(HT_ThamSoHeThongInfo pHT_ThamSoHeThongInfo)
        {
			int ID = 0;
            ID = oDHT_ThamSoHeThong.Add(pHT_ThamSoHeThongInfo);
            mErrorMessage = oDHT_ThamSoHeThong.ErrorMessages;
            mErrorNumber = oDHT_ThamSoHeThong.ErrorNumber;
            return ID;
        }

        public void Update(HT_ThamSoHeThongInfo pHT_ThamSoHeThongInfo)
        {
            oDHT_ThamSoHeThong.Update(pHT_ThamSoHeThongInfo);
            mErrorMessage = oDHT_ThamSoHeThong.ErrorMessages;
            mErrorNumber = oDHT_ThamSoHeThong.ErrorNumber;
        }
        
        public void Delete(HT_ThamSoHeThongInfo pHT_ThamSoHeThongInfo)
        {
            oDHT_ThamSoHeThong.Delete(pHT_ThamSoHeThongInfo);
            mErrorMessage = oDHT_ThamSoHeThong.ErrorMessages;
            mErrorNumber = oDHT_ThamSoHeThong.ErrorNumber;
        }

        public List<HT_ThamSoHeThongInfo> GetList(HT_ThamSoHeThongInfo pHT_ThamSoHeThongInfo)
        {
            List<HT_ThamSoHeThongInfo> oHT_ThamSoHeThongInfoList = new List<HT_ThamSoHeThongInfo>();
            DataTable dtb = Get(pHT_ThamSoHeThongInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oHT_ThamSoHeThongInfo = new HT_ThamSoHeThongInfo();
                    

                    oHT_ThamSoHeThongInfo.HT_ThamSoHeThongID = int.Parse(dtb.Rows[i]["HT_ThamSoHeThongID"].ToString());
                    oHT_ThamSoHeThongInfo.MaThamSoHeThong = dtb.Rows[i]["MaThamSoHeThong"].ToString();
                    oHT_ThamSoHeThongInfo.TenThamSoHeThong = dtb.Rows[i]["TenThamSoHeThong"].ToString();
                    oHT_ThamSoHeThongInfo.IDDM_He = int.Parse(dtb.Rows[i]["IDDM_He"].ToString());
                    oHT_ThamSoHeThongInfo.PhanHe = int.Parse(dtb.Rows[i]["PhanHe"].ToString());
                    oHT_ThamSoHeThongInfo.GiaTri = dtb.Rows[i]["GiaTri"].ToString();
                    oHT_ThamSoHeThongInfo.GhiChu = dtb.Rows[i]["GhiChu"].ToString();
                    oHT_ThamSoHeThongInfo.TrangThai = bool.Parse(dtb.Rows[i]["TrangThai"].ToString());
                    oHT_ThamSoHeThongInfo.SapXep = int.Parse(dtb.Rows[i]["SapXep"].ToString());
                    
                    oHT_ThamSoHeThongInfoList.Add(oHT_ThamSoHeThongInfo);
                }
            }
            return oHT_ThamSoHeThongInfoList;
        }

        public List<HT_ThamSoHeThongInfo> GetListByPhanHe(int PhanHe)
        {
            List<HT_ThamSoHeThongInfo> oHT_ThamSoHeThongInfoList = new List<HT_ThamSoHeThongInfo>();
            DataTable dtb = GetByPhanHe(PhanHe);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                     oHT_ThamSoHeThongInfo = new HT_ThamSoHeThongInfo();


                     oHT_ThamSoHeThongInfo.HT_ThamSoHeThongID = int.Parse(dtb.Rows[i]["HT_ThamSoHeThongID"].ToString());
                     oHT_ThamSoHeThongInfo.MaThamSoHeThong = dtb.Rows[i]["MaThamSoHeThong"].ToString();
                     oHT_ThamSoHeThongInfo.TenThamSoHeThong = dtb.Rows[i]["TenThamSoHeThong"].ToString();
                     oHT_ThamSoHeThongInfo.PhanHe = int.Parse(dtb.Rows[i]["PhanHe"].ToString());
                     oHT_ThamSoHeThongInfo.GiaTri = dtb.Rows[i]["GiaTri"].ToString();
                     oHT_ThamSoHeThongInfo.GhiChu = dtb.Rows[i]["GhiChu"].ToString();
                     oHT_ThamSoHeThongInfo.TrangThai = bool.Parse(dtb.Rows[i]["TrangThai"].ToString());
                     oHT_ThamSoHeThongInfo.SapXep = int.Parse(dtb.Rows[i]["SapXep"].ToString());

                     oHT_ThamSoHeThongInfoList.Add( oHT_ThamSoHeThongInfo);
                }
            }
            return  oHT_ThamSoHeThongInfoList;
        }
    }
}
