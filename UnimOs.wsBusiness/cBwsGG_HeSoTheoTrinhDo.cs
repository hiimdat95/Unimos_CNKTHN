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
    public class cBwsGG_HeSoTheoTrinhDo : cBwsBase
    {
        private cDGG_HeSoTheoTrinhDo oDGG_HeSoTheoTrinhDo;

        public cBwsGG_HeSoTheoTrinhDo()
        {
            oDGG_HeSoTheoTrinhDo = new cDGG_HeSoTheoTrinhDo();
        }

        //public DataTable Get(GG_HeSoTheoTrinhDoInfo pGG_HeSoTheoTrinhDoInfo)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<GG_HeSoTheoTrinhDoInfo>(client.cDGG_HeSoTheoTrinhDo_Get(GlobalVar.MaXacThuc, pGG_HeSoTheoTrinhDoInfo));
        //    }
        //}

        public DataTable GetAll()
        {
            return oDGG_HeSoTheoTrinhDo.GetAll();
        }

        //public int Add(GG_HeSoTheoTrinhDoInfo pGG_HeSoTheoTrinhDoInfo)
        //{
        //    int ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDGG_HeSoTheoTrinhDo_Add(GlobalVar.MaXacThuc, pGG_HeSoTheoTrinhDoInfo);
        //    client.Close();
        //    mErrorMessage = oDGG_HeSoTheoTrinhDo.ErrorMessages;
        //    mErrorNumber = oDGG_HeSoTheoTrinhDo.ErrorNumber;
        //    return ID;
        //}

        //public void Update(GG_HeSoTheoTrinhDoInfo pGG_HeSoTheoTrinhDoInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDGG_HeSoTheoTrinhDo_Update(GlobalVar.MaXacThuc, pGG_HeSoTheoTrinhDoInfo);
        //    client.Close();
        //    mErrorMessage = oDGG_HeSoTheoTrinhDo.ErrorMessages;
        //    mErrorNumber = oDGG_HeSoTheoTrinhDo.ErrorNumber;
        //}

        //public void Delete(GG_HeSoTheoTrinhDoInfo pGG_HeSoTheoTrinhDoInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDGG_HeSoTheoTrinhDo_Delete(GlobalVar.MaXacThuc, pGG_HeSoTheoTrinhDoInfo);
        //    client.Close();
        //    mErrorMessage = oDGG_HeSoTheoTrinhDo.ErrorMessages;
        //    mErrorNumber = oDGG_HeSoTheoTrinhDo.ErrorNumber;
        //}

        //public List<GG_HeSoTheoTrinhDoInfo> GetList(GG_HeSoTheoTrinhDoInfo pGG_HeSoTheoTrinhDoInfo)
        //{
        //    List<GG_HeSoTheoTrinhDoInfo> oGG_HeSoTheoTrinhDoInfoList = new List<GG_HeSoTheoTrinhDoInfo>();
        //    DataTable dtb = Get(pGG_HeSoTheoTrinhDoInfo);
        //    if (dtb != null)
        //    {
        //        for (int i = 0; i < dtb.Rows.Count; i++)
        //        {
        //            pGG_HeSoTheoTrinhDoInfo = new GG_HeSoTheoTrinhDoInfo();

        //            pGG_HeSoTheoTrinhDoInfo.GG_HeSoTheoTrinhDoID = int.Parse(dtb.Rows[i][pGG_HeSoTheoTrinhDoInfo.strGG_HeSoTheoTrinhDoID].ToString());
        //            pGG_HeSoTheoTrinhDoInfo.LoaiGiangDay = dtb.Rows[i][pGG_HeSoTheoTrinhDoInfo.strLoaiGiangDay].ToString();
        //            pGG_HeSoTheoTrinhDoInfo.IDDM_TrinhDo = int.Parse(dtb.Rows[i][pGG_HeSoTheoTrinhDoInfo.strIDDM_TrinhDo].ToString());
        //            pGG_HeSoTheoTrinhDoInfo.TuSo = int.Parse(dtb.Rows[i][pGG_HeSoTheoTrinhDoInfo.strTuSo].ToString());
        //            pGG_HeSoTheoTrinhDoInfo.DenSo = int.Parse(dtb.Rows[i][pGG_HeSoTheoTrinhDoInfo.strDenSo].ToString());
        //            pGG_HeSoTheoTrinhDoInfo.HeSo = double.Parse(dtb.Rows[i][pGG_HeSoTheoTrinhDoInfo.strHeSo].ToString());

        //            oGG_HeSoTheoTrinhDoInfoList.Add(pGG_HeSoTheoTrinhDoInfo);
        //        }
        //    }
        //    return oGG_HeSoTheoTrinhDoInfoList;
        //}

        public void ToDataRow(GG_HeSoTheoTrinhDoInfo pGG_HeSoTheoTrinhDoInfo, ref DataRow dr)
        {

            dr[pGG_HeSoTheoTrinhDoInfo.strGG_HeSoTheoTrinhDoID] = pGG_HeSoTheoTrinhDoInfo.GG_HeSoTheoTrinhDoID;
            dr[pGG_HeSoTheoTrinhDoInfo.strLoaiGiangDay] = pGG_HeSoTheoTrinhDoInfo.LoaiGiangDay;
            dr[pGG_HeSoTheoTrinhDoInfo.strIDDM_TrinhDo] = pGG_HeSoTheoTrinhDoInfo.IDDM_TrinhDo;
            dr[pGG_HeSoTheoTrinhDoInfo.strTuSo] = pGG_HeSoTheoTrinhDoInfo.TuSo;
            dr[pGG_HeSoTheoTrinhDoInfo.strDenSo] = pGG_HeSoTheoTrinhDoInfo.DenSo;
            dr[pGG_HeSoTheoTrinhDoInfo.strHeSo] = pGG_HeSoTheoTrinhDoInfo.HeSo;
        }

        public void ToInfo(ref GG_HeSoTheoTrinhDoInfo pGG_HeSoTheoTrinhDoInfo, DataRow dr)
        {

            pGG_HeSoTheoTrinhDoInfo.GG_HeSoTheoTrinhDoID = int.Parse(dr[pGG_HeSoTheoTrinhDoInfo.strGG_HeSoTheoTrinhDoID].ToString());
            pGG_HeSoTheoTrinhDoInfo.LoaiGiangDay = dr[pGG_HeSoTheoTrinhDoInfo.strLoaiGiangDay].ToString();
            pGG_HeSoTheoTrinhDoInfo.IDDM_TrinhDo = int.Parse(dr[pGG_HeSoTheoTrinhDoInfo.strIDDM_TrinhDo].ToString());
            pGG_HeSoTheoTrinhDoInfo.TuSo = int.Parse(dr[pGG_HeSoTheoTrinhDoInfo.strTuSo].ToString());
            pGG_HeSoTheoTrinhDoInfo.DenSo = int.Parse(dr[pGG_HeSoTheoTrinhDoInfo.strDenSo].ToString());
            pGG_HeSoTheoTrinhDoInfo.HeSo = double.Parse(dr[pGG_HeSoTheoTrinhDoInfo.strHeSo].ToString());
        }
    }
}
