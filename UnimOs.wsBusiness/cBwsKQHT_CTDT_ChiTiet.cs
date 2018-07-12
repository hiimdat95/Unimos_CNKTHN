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
    public class cBwsKQHT_CTDT_ChiTiet : cBwsBase
    {
        private cDKQHT_CTDT_ChiTiet oDKQHT_CTDT_ChiTiet;
        private KQHT_CTDT_ChiTietInfo oKQHT_CTDT_ChiTietInfo;

        public cBwsKQHT_CTDT_ChiTiet()
        {
            oDKQHT_CTDT_ChiTiet = new cDKQHT_CTDT_ChiTiet();
        }

        public DataTable Get(KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_CTDT_ChiTiet_GetResult>(client.cDKQHT_CTDT_ChiTiet_Get(GlobalVar.MaXacThuc, pKQHT_CTDT_ChiTietInfo));
            }
        }

        public int Add(KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo)
        {
            int ID = 0;
            var client = new UnimOsServiceClient();
            ID = client.cDKQHT_CTDT_ChiTiet_Add(GlobalVar.MaXacThuc, pKQHT_CTDT_ChiTietInfo);
            client.Close();
            mErrorMessage = oDKQHT_CTDT_ChiTiet.ErrorMessages;
            mErrorNumber = oDKQHT_CTDT_ChiTiet.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_CTDT_ChiTiet_Update(GlobalVar.MaXacThuc, pKQHT_CTDT_ChiTietInfo);
            client.Close();
            mErrorMessage = oDKQHT_CTDT_ChiTiet.ErrorMessages;
            mErrorNumber = oDKQHT_CTDT_ChiTiet.ErrorNumber;
        }

        public void Delete(KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_CTDT_ChiTiet_Delete(GlobalVar.MaXacThuc, pKQHT_CTDT_ChiTietInfo);
            client.Close();
            mErrorMessage = oDKQHT_CTDT_ChiTiet.ErrorMessages;
            mErrorNumber = oDKQHT_CTDT_ChiTiet.ErrorNumber;
        }

        public void DeleteByHocKy(KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_CTDT_ChiTiet_DeleteByHocKy(GlobalVar.MaXacThuc, pKQHT_CTDT_ChiTietInfo);
            client.Close();
            mErrorMessage = oDKQHT_CTDT_ChiTiet.ErrorMessages;
            mErrorNumber = oDKQHT_CTDT_ChiTiet.ErrorNumber;
        }

        public List<KQHT_CTDT_ChiTietInfo> GetList(KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo)
        {
            List<KQHT_CTDT_ChiTietInfo> oKQHT_CTDT_ChiTietInfoList = new List<KQHT_CTDT_ChiTietInfo>();
            DataTable dtb = Get(pKQHT_CTDT_ChiTietInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oKQHT_CTDT_ChiTietInfo = new KQHT_CTDT_ChiTietInfo();

                    oKQHT_CTDT_ChiTietInfo.KQHT_CTDT_ChiTietID = long.Parse(dtb.Rows[i]["KQHT_CTDT_ChiTietID"].ToString());
                    oKQHT_CTDT_ChiTietInfo.IDKQHT_MonHoc_CT_KhoiKienThuc = int.Parse(dtb.Rows[i]["IDKQHT_MonHoc_CT_KhoiKienThuc"].ToString());
                    oKQHT_CTDT_ChiTietInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oKQHT_CTDT_ChiTietInfo.SoTiet = int.Parse(dtb.Rows[i]["SoTiet"].ToString());
                    oKQHT_CTDT_ChiTietInfo.LyThuyet = int.Parse(dtb.Rows[i]["LyThuyet"].ToString());
                    oKQHT_CTDT_ChiTietInfo.ThucHanh = int.Parse(dtb.Rows[i]["ThucHanh"].ToString());
                    oKQHT_CTDT_ChiTietInfo.LoaiTietKhac1 = int.Parse(dtb.Rows[i]["LoaiTietKhac1"].ToString());
                    oKQHT_CTDT_ChiTietInfo.LoaiTietKhac2 = int.Parse(dtb.Rows[i]["LoaiTietKhac2"].ToString());
                    oKQHT_CTDT_ChiTietInfo.SoHocTrinh = double.Parse(dtb.Rows[i]["SoHocTrinh"].ToString());

                    oKQHT_CTDT_ChiTietInfoList.Add(oKQHT_CTDT_ChiTietInfo);
                }
            }
            return oKQHT_CTDT_ChiTietInfoList;
        }

        public void ToDataRow(KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo, ref DataRow dr)
        {

            dr[pKQHT_CTDT_ChiTietInfo.strKQHT_CTDT_ChiTietID] = pKQHT_CTDT_ChiTietInfo.KQHT_CTDT_ChiTietID;
            dr[pKQHT_CTDT_ChiTietInfo.strIDKQHT_MonHoc_CT_KhoiKienThuc] = pKQHT_CTDT_ChiTietInfo.IDKQHT_MonHoc_CT_KhoiKienThuc;
            dr[pKQHT_CTDT_ChiTietInfo.strHocKy] = pKQHT_CTDT_ChiTietInfo.HocKy;
            dr[pKQHT_CTDT_ChiTietInfo.strSoTiet] = pKQHT_CTDT_ChiTietInfo.SoTiet;
            dr[pKQHT_CTDT_ChiTietInfo.strLyThuyet] = pKQHT_CTDT_ChiTietInfo.LyThuyet;
            dr[pKQHT_CTDT_ChiTietInfo.strThucHanh] = pKQHT_CTDT_ChiTietInfo.ThucHanh;
            dr[pKQHT_CTDT_ChiTietInfo.strLoaiTietKhac1] = pKQHT_CTDT_ChiTietInfo.LoaiTietKhac1;
            dr[pKQHT_CTDT_ChiTietInfo.strLoaiTietKhac2] = pKQHT_CTDT_ChiTietInfo.LoaiTietKhac2;
            dr[pKQHT_CTDT_ChiTietInfo.strSoHocTrinh] = pKQHT_CTDT_ChiTietInfo.SoHocTrinh;
        }
    }
}
