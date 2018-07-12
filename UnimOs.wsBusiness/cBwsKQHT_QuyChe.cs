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
    public class cBwsKQHT_QuyChe : cBwsBase
    {
        private cDKQHT_QuyChe oDKQHT_QuyChe;
        private KQHT_QuyCheInfo oKQHT_QuyCheInfo;

        public cBwsKQHT_QuyChe()
        {
            oDKQHT_QuyChe = new cDKQHT_QuyChe();
        }

        public DataTable Get(KQHT_QuyCheInfo pKQHT_QuyCheInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_QuyChe_GetResult>(client.cDKQHT_QuyChe_Get(GlobalVar.MaXacThuc, pKQHT_QuyCheInfo));
            }
        }

        public DataTable GetThamSo(int KQHT_QuyCheID)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_QuyChe_GetThamSoResult>(client.cDKQHT_QuyChe_GetThamSo(GlobalVar.MaXacThuc, KQHT_QuyCheID));
            }
        }

        public DataTable GetThamSo_NotIn(int KQHT_QuyCheID)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_QuyChe_GetThamSo_NotInResult>(client.cDKQHT_QuyChe_GetThamSo_NotIn(GlobalVar.MaXacThuc, KQHT_QuyCheID));
            }
        }

        public string GetByMaThamSo(int IDDM_TrinhDo, string MaThamSo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return client.cDKQHT_QuyChe_GetByMaThamSo(GlobalVar.MaXacThuc, IDDM_TrinhDo, MaThamSo);
            }
        }

        public int Add(KQHT_QuyCheInfo pKQHT_QuyCheInfo)
        {
            int ID = 0;
            var client = new UnimOsServiceClient();
            ID = client.cDKQHT_QuyChe_Add(GlobalVar.MaXacThuc, pKQHT_QuyCheInfo);
            client.Close();
            mErrorMessage = oDKQHT_QuyChe.ErrorMessages;
            mErrorNumber = oDKQHT_QuyChe.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_QuyCheInfo pKQHT_QuyCheInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_QuyChe_Update(GlobalVar.MaXacThuc, pKQHT_QuyCheInfo);
            client.Close();
            mErrorMessage = oDKQHT_QuyChe.ErrorMessages;
            mErrorNumber = oDKQHT_QuyChe.ErrorNumber;
        }

        public void Delete(KQHT_QuyCheInfo pKQHT_QuyCheInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_QuyChe_Delete(GlobalVar.MaXacThuc, pKQHT_QuyCheInfo);
            client.Close();
            mErrorMessage = oDKQHT_QuyChe.ErrorMessages;
            mErrorNumber = oDKQHT_QuyChe.ErrorNumber;
        }

        public List<KQHT_QuyCheInfo> GetList(KQHT_QuyCheInfo pKQHT_QuyCheInfo)
        {
            List<KQHT_QuyCheInfo> oKQHT_QuyCheInfoList = new List<KQHT_QuyCheInfo>();
            DataTable dtb = Get(pKQHT_QuyCheInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oKQHT_QuyCheInfo = new KQHT_QuyCheInfo();


                    oKQHT_QuyCheInfo.KQHT_QuyCheID = int.Parse(dtb.Rows[i]["KQHT_QuyCheID"].ToString());
                    oKQHT_QuyCheInfo.MaQuyChe = dtb.Rows[i]["MaQuyChe"].ToString();
                    oKQHT_QuyCheInfo.TenQuyChe = dtb.Rows[i]["TenQuyChe"].ToString();

                    oKQHT_QuyCheInfoList.Add(oKQHT_QuyCheInfo);
                }
            }
            return oKQHT_QuyCheInfoList;
        }
    }
}
