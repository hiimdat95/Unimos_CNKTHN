using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.wsBusiness;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Entity.Model;
using TruongViet.UnimOs.Data;
using UnimOs.wsBusiness.wsUnimOs;

namespace TruongViet.UnimOs.wsBusiness
{
    public class cBwsHT_ThamSoHeThong : cBwsBase
    {
        private cDHT_ThamSoHeThong oDHT_ThamSoHeThong;
        private HT_ThamSoHeThongInfo oHT_ThamSoHeThongInfo;

        public cBwsHT_ThamSoHeThong()
        {
            oDHT_ThamSoHeThong = new cDHT_ThamSoHeThong();
        }

        public DataTable Get(HT_ThamSoHeThongInfo pHT_ThamSoHeThongInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_HT_ThamSoHeThong_GetResult>(client.cDHT_ThamSoHeThong_Get(GlobalVar.MaXacThuc, pHT_ThamSoHeThongInfo));
            }
        }

        public DataTable GetByMaThamSo(string MaThamSoHeThong)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_HT_ThamSoHeThong_GetByMaThamSoResult>(client.cDHT_ThamSoHeThong_GetByMaThamSo(GlobalVar.MaXacThuc, MaThamSoHeThong));
            }
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
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_HT_ThamSoHeThong_GetByPhanHeResult>(client.cDHT_ThamSoHeThong_GetByPhanHe(GlobalVar.MaXacThuc, PhanHe));
            }
        }

        public int Add(HT_ThamSoHeThongInfo pHT_ThamSoHeThongInfo)
        {
            int ID = 0;
            var client = new UnimOsServiceClient();
            ID = client.cDHT_ThamSoHeThong_Add(GlobalVar.MaXacThuc, pHT_ThamSoHeThongInfo);
            client.Close();
            mErrorMessage = oDHT_ThamSoHeThong.ErrorMessages;
            mErrorNumber = oDHT_ThamSoHeThong.ErrorNumber;
            return ID;
        }

        //public void Update(HT_ThamSoHeThongInfo pHT_ThamSoHeThongInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDHT_ThamSoHeThong_Update(GlobalVar.MaXacThuc, pHT_ThamSoHeThongInfo);
        //    client.Close();
        //    mErrorMessage = oDHT_ThamSoHeThong.ErrorMessages;
        //    mErrorNumber = oDHT_ThamSoHeThong.ErrorNumber;
        //}

        //public void Delete(HT_ThamSoHeThongInfo pHT_ThamSoHeThongInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDHT_ThamSoHeThong_Delete(GlobalVar.MaXacThuc, pHT_ThamSoHeThongInfo);
        //    client.Close();
        //    mErrorMessage = oDHT_ThamSoHeThong.ErrorMessages;
        //    mErrorNumber = oDHT_ThamSoHeThong.ErrorNumber;
        //}

        public List<HT_ThamSoHeThongInfo> GetList(HT_ThamSoHeThongInfo pHT_ThamSoHeThongInfo)
        {
            List<HT_ThamSoHeThongInfo> oHT_ThamSoHeThongInfoList = new List<HT_ThamSoHeThongInfo>();
            DataTable dtb = Get(pHT_ThamSoHeThongInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
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

                    oHT_ThamSoHeThongInfoList.Add(oHT_ThamSoHeThongInfo);
                }
            }
            return oHT_ThamSoHeThongInfoList;
        }
    }
}
