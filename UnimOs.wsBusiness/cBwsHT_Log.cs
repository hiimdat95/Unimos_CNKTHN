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
    public class cBwsHT_Log : cBwsBase
    {
        private cDHT_Log oDHT_Log;


        private HT_LogInfo oHT_LogInfo;

        public cBwsHT_Log()
        {
            oDHT_Log = new cDHT_Log();
        }

        //public DataTable Get(HT_LogInfo pHT_LogInfo)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<HT_LogInfo>(client.cDHT_Log_Get(GlobalVar.MaXacThuc, pHT_LogInfo));
        //    }
        //}

        public DataTable Search(int IDPhanHe, int IDChucNang, string SuKien, string NguoiDung, string NoiDung, DateTime dtTuNgay, DateTime dtDenNgay)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<HT_LogInfo>(client.cDHT_Log_Search(GlobalVar.MaXacThuc, IDPhanHe, IDChucNang, SuKien, NguoiDung, NoiDung, dtTuNgay, dtDenNgay));
            }
        }

        public int Add(HT_LogInfo pHT_LogInfo)
        {
            int ID = 0;
            var client = new UnimOsServiceClient();
            ID = client.cDHT_Log_Add(GlobalVar.MaXacThuc, pHT_LogInfo);
            client.Close();
            mErrorMessage = oDHT_Log.ErrorMessages;
            mErrorNumber = oDHT_Log.ErrorNumber;
            return ID;
        }

        //public void Update(HT_LogInfo pHT_LogInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDHT_Log_Update(GlobalVar.MaXacThuc, pHT_LogInfo);
        //    client.Close();
        //    mErrorMessage = oDHT_Log.ErrorMessages;
        //    mErrorNumber = oDHT_Log.ErrorNumber;
        //}

        //public void Delete(HT_LogInfo pHT_LogInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDHT_Log_Delete(GlobalVar.MaXacThuc, pHT_LogInfo);
        //    client.Close();
        //    mErrorMessage = oDHT_Log.ErrorMessages;
        //    mErrorNumber = oDHT_Log.ErrorNumber;
        //}

        //public List<HT_LogInfo> GetList(HT_LogInfo pHT_LogInfo)
        //{
        //    List<HT_LogInfo> oHT_LogInfoList = new List<HT_LogInfo>();
        //    DataTable dtb = Get(pHT_LogInfo);
        //    if (dtb != null)
        //    {
        //        for (int i = 0; i < dtb.Rows.Count; i++)
        //        {
        //            oHT_LogInfo = new HT_LogInfo();

        //            oHT_LogInfo.HT_LogID = long.Parse(dtb.Rows[i]["HT_LogID"].ToString());
        //            oHT_LogInfo.Tag = dtb.Rows[i]["Tag"].ToString();
        //            oHT_LogInfo.SuKien = dtb.Rows[i]["SuKien"].ToString();
        //            oHT_LogInfo.NoiDung = dtb.Rows[i]["NoiDung"].ToString();
        //            oHT_LogInfo.ThoiDiem = DateTime.Parse(dtb.Rows[i]["ThoiDiem"].ToString());
        //            oHT_LogInfo.UserName = dtb.Rows[i]["UserName"].ToString();
        //            oHT_LogInfo.IPMayTram = dtb.Rows[i]["IPMayTram"].ToString();
        //            oHT_LogInfo.MacMayTram = dtb.Rows[i]["MacMayTram"].ToString();

        //            oHT_LogInfoList.Add(oHT_LogInfo);
        //        }
        //    }
        //    return oHT_LogInfoList;
        //}

        //public void ToDataRow(HT_LogInfo pHT_LogInfo, ref DataRow dr)
        //{

        //    dr[pHT_LogInfo.strHT_LogID] = pHT_LogInfo.HT_LogID;
        //    dr[pHT_LogInfo.strTag] = pHT_LogInfo.Tag;
        //    dr[pHT_LogInfo.strSuKien] = pHT_LogInfo.SuKien;
        //    dr[pHT_LogInfo.strNoiDung] = pHT_LogInfo.NoiDung;
        //    dr[pHT_LogInfo.strThoiDiem] = pHT_LogInfo.ThoiDiem;
        //    dr[pHT_LogInfo.strUserName] = pHT_LogInfo.UserName;
        //    dr[pHT_LogInfo.strIPMayTram] = pHT_LogInfo.IPMayTram;
        //    dr[pHT_LogInfo.strMacMayTram] = pHT_LogInfo.MacMayTram;
        //}

        public void ToInfo(ref HT_LogInfo pHT_LogInfo, DataRow dr)
        {

            pHT_LogInfo.HT_LogID = long.Parse(dr[pHT_LogInfo.strHT_LogID].ToString());
            pHT_LogInfo.Tag = dr[pHT_LogInfo.strTag].ToString();
            pHT_LogInfo.SuKien = dr[pHT_LogInfo.strSuKien].ToString();
            pHT_LogInfo.NoiDung = dr[pHT_LogInfo.strNoiDung].ToString();
            pHT_LogInfo.ThoiDiem = DateTime.Parse(dr[pHT_LogInfo.strThoiDiem].ToString());
            pHT_LogInfo.UserName = dr[pHT_LogInfo.strUserName].ToString();
            pHT_LogInfo.IPMayTram = dr[pHT_LogInfo.strIPMayTram].ToString();
            pHT_LogInfo.MacMayTram = dr[pHT_LogInfo.strMacMayTram].ToString();
        }
    }
}
