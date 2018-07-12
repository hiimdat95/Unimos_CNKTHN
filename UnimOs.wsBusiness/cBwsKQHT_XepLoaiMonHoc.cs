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
    public class cBwsKQHT_XepLoaiMonHoc : cBwsBase
    {
        private cDKQHT_XepLoaiMonHoc oDKQHT_XepLoaiMonHoc;
        private KQHT_XepLoaiMonHocInfo oKQHT_XepLoaiMonHocInfo;

        public cBwsKQHT_XepLoaiMonHoc()
        {
            oDKQHT_XepLoaiMonHoc = new cDKQHT_XepLoaiMonHoc();
        }

        public DataTable Get(KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_XepLoaiMonHoc_GetResult>(client.cDKQHT_XepLoaiMonHoc_Get(GlobalVar.MaXacThuc, pKQHT_XepLoaiMonHocInfo));
            }
        }

        public int Add(KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo)
        {
            int ID = 0;
            var client = new UnimOsServiceClient();
            ID = client.cDKQHT_XepLoaiMonHoc_Add(GlobalVar.MaXacThuc, pKQHT_XepLoaiMonHocInfo);
            client.Close();
            mErrorMessage = oDKQHT_XepLoaiMonHoc.ErrorMessages;
            mErrorNumber = oDKQHT_XepLoaiMonHoc.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_XepLoaiMonHoc_Update(GlobalVar.MaXacThuc, pKQHT_XepLoaiMonHocInfo);
            client.Close();
            mErrorMessage = oDKQHT_XepLoaiMonHoc.ErrorMessages;
            mErrorNumber = oDKQHT_XepLoaiMonHoc.ErrorNumber;
        }

        public void Delete(KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_XepLoaiMonHoc_Delete(GlobalVar.MaXacThuc, pKQHT_XepLoaiMonHocInfo);
            client.Close();
            mErrorMessage = oDKQHT_XepLoaiMonHoc.ErrorMessages;
            mErrorNumber = oDKQHT_XepLoaiMonHoc.ErrorNumber;
        }

        public List<KQHT_XepLoaiMonHocInfo> GetList(KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo)
        {
            List<KQHT_XepLoaiMonHocInfo> oKQHT_XepLoaiMonHocInfoList = new List<KQHT_XepLoaiMonHocInfo>();
            DataTable dtb = Get(pKQHT_XepLoaiMonHocInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oKQHT_XepLoaiMonHocInfo = new KQHT_XepLoaiMonHocInfo();

                    oKQHT_XepLoaiMonHocInfo.KQHT_XepLoaiMonHocID = int.Parse(dtb.Rows[i]["KQHT_XepLoaiMonHocID"].ToString());
                    oKQHT_XepLoaiMonHocInfo.TenXepLoai = dtb.Rows[i]["TenXepLoai"].ToString();
                    oKQHT_XepLoaiMonHocInfo.TuDiem = double.Parse(dtb.Rows[i]["TuDiem"].ToString());
                    oKQHT_XepLoaiMonHocInfo.MaXepLoai = dtb.Rows[i]["MaXepLoai"].ToString();

                    oKQHT_XepLoaiMonHocInfoList.Add(oKQHT_XepLoaiMonHocInfo);
                }
            }
            return oKQHT_XepLoaiMonHocInfoList;
        }

        public void ToDataRow(KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo, ref DataRow dr)
        {

            dr[pKQHT_XepLoaiMonHocInfo.strKQHT_XepLoaiMonHocID] = pKQHT_XepLoaiMonHocInfo.KQHT_XepLoaiMonHocID;
            dr[pKQHT_XepLoaiMonHocInfo.strTenXepLoai] = pKQHT_XepLoaiMonHocInfo.TenXepLoai;
            dr[pKQHT_XepLoaiMonHocInfo.strTuDiem] = pKQHT_XepLoaiMonHocInfo.TuDiem;
            dr[pKQHT_XepLoaiMonHocInfo.strMaXepLoai] = pKQHT_XepLoaiMonHocInfo.MaXepLoai;
        }

        public void ToInfo(ref KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo, DataRow dr)
        {

            pKQHT_XepLoaiMonHocInfo.KQHT_XepLoaiMonHocID = int.Parse(dr[pKQHT_XepLoaiMonHocInfo.strKQHT_XepLoaiMonHocID].ToString());
            pKQHT_XepLoaiMonHocInfo.TenXepLoai = dr[pKQHT_XepLoaiMonHocInfo.strTenXepLoai].ToString();
            pKQHT_XepLoaiMonHocInfo.TuDiem = double.Parse(dr[pKQHT_XepLoaiMonHocInfo.strTuDiem].ToString());
            pKQHT_XepLoaiMonHocInfo.MaXepLoai = dr[pKQHT_XepLoaiMonHocInfo.strMaXepLoai].ToString();
        }
    }
}
