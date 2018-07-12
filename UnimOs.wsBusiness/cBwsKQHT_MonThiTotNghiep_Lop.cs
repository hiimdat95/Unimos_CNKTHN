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
    public class cBwsKQHT_MonThiTotNghiep_Lop : cBwsBase
    {
        private cDKQHT_MonThiTotNghiep_Lop oDKQHT_MonThiTotNghiep_Lop;
        private KQHT_MonThiTotNghiep_LopInfo oKQHT_MonThiTotNghiep_LopInfo;

        public cBwsKQHT_MonThiTotNghiep_Lop()
        {
            oDKQHT_MonThiTotNghiep_Lop = new cDKQHT_MonThiTotNghiep_Lop();
        }

        //public DataTable Get(KQHT_MonThiTotNghiep_LopInfo pKQHT_MonThiTotNghiep_LopInfo)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<KQHT_MonThiTotNghiep_LopInfo>(client.cDKQHT_MonThiTotNghiep_Lop_Get(GlobalVar.MaXacThuc, pKQHT_MonThiTotNghiep_LopInfo));
        //    }
        //}
        public DataTable GetAllMon(int IDDM_NamHoc)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_MonThiTotNghiep_Lop_GetAllMonResult>(client.cDKQHT_MonThiTotNghiep_Lop_GetAllMon(GlobalVar.MaXacThuc, IDDM_NamHoc));
            }
        }

        public DataTable GetIn_Mon(int IDDM_Lop)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_MonThiTotNghiep_Lop_GetIn_MonResult>(client.cDKQHT_MonThiTotNghiep_Lop_GetIn_Mon(GlobalVar.MaXacThuc, IDDM_Lop));
            }
        }

        public DataTable GetNotIn_Mon(int IDDM_Lop)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_MonThiTotNghiep_Lop_GetNotIn_MonResult>(client.cDKQHT_MonThiTotNghiep_Lop_GetNotIn_Mon(GlobalVar.MaXacThuc, IDDM_Lop));
            }
        }

        //public int Add(KQHT_MonThiTotNghiep_LopInfo pKQHT_MonThiTotNghiep_LopInfo)
        //{
        //    int ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDKQHT_MonThiTotNghiep_Lop_Add(GlobalVar.MaXacThuc, pKQHT_MonThiTotNghiep_LopInfo);
        //    client.Close();
        //    mErrorMessage = oDKQHT_MonThiTotNghiep_Lop.ErrorMessages;
        //    mErrorNumber = oDKQHT_MonThiTotNghiep_Lop.ErrorNumber;
        //    return ID;
        //}

        //public void Update(KQHT_MonThiTotNghiep_LopInfo pKQHT_MonThiTotNghiep_LopInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDKQHT_MonThiTotNghiep_Lop_Update(GlobalVar.MaXacThuc, pKQHT_MonThiTotNghiep_LopInfo);
        //    client.Close();
        //    mErrorMessage = oDKQHT_MonThiTotNghiep_Lop.ErrorMessages;
        //    mErrorNumber = oDKQHT_MonThiTotNghiep_Lop.ErrorNumber;
        //}

        public void Delete_ByLop(int IDDM_Lop)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_MonThiTotNghiep_Lop_Delete_ByLop(GlobalVar.MaXacThuc, IDDM_Lop);
            client.Close();
            mErrorMessage = oDKQHT_MonThiTotNghiep_Lop.ErrorMessages;
            mErrorNumber = oDKQHT_MonThiTotNghiep_Lop.ErrorNumber;
        }
        //public void Delete(KQHT_MonThiTotNghiep_LopInfo pKQHT_MonThiTotNghiep_LopInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDKQHT_MonThiTotNghiep_Lop_Delete(GlobalVar.MaXacThuc, pKQHT_MonThiTotNghiep_LopInfo);
        //    client.Close();
        //    mErrorMessage = oDKQHT_MonThiTotNghiep_Lop.ErrorMessages;
        //    mErrorNumber = oDKQHT_MonThiTotNghiep_Lop.ErrorNumber;
        //}

        //public List<KQHT_MonThiTotNghiep_LopInfo> GetList(KQHT_MonThiTotNghiep_LopInfo pKQHT_MonThiTotNghiep_LopInfo)
        //{
        //    List<KQHT_MonThiTotNghiep_LopInfo> oKQHT_MonThiTotNghiep_LopInfoList = new List<KQHT_MonThiTotNghiep_LopInfo>();
        //    DataTable dtb = Get(pKQHT_MonThiTotNghiep_LopInfo);
        //    if (dtb != null)
        //    {
        //        for (int i = 0; i < dtb.Rows.Count; i++)
        //        {
        //            oKQHT_MonThiTotNghiep_LopInfo = new KQHT_MonThiTotNghiep_LopInfo();

        //            oKQHT_MonThiTotNghiep_LopInfo.KQHT_MonThiTotNghiep_LopID = int.Parse(dtb.Rows[i]["KQHT_MonThiTotNghiep_LopID"].ToString());
        //            oKQHT_MonThiTotNghiep_LopInfo.IDDM_Lop = int.Parse(dtb.Rows[i]["IDDM_Lop"].ToString());
        //            oKQHT_MonThiTotNghiep_LopInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
        //            oKQHT_MonThiTotNghiep_LopInfo.SoHocTrinh = int.Parse(dtb.Rows[i]["SoHocTrinh"].ToString());
        //            oKQHT_MonThiTotNghiep_LopInfo.TinhDiem = bool.Parse(dtb.Rows[i]["TinhDiem"].ToString());

        //            oKQHT_MonThiTotNghiep_LopInfoList.Add(oKQHT_MonThiTotNghiep_LopInfo);
        //        }
        //    }
        //    return oKQHT_MonThiTotNghiep_LopInfoList;
        //}

        //public void ToDataRow(KQHT_MonThiTotNghiep_LopInfo pKQHT_MonThiTotNghiep_LopInfo, ref DataRow dr)
        //{

        //    dr[pKQHT_MonThiTotNghiep_LopInfo.strKQHT_MonThiTotNghiep_LopID] = pKQHT_MonThiTotNghiep_LopInfo.KQHT_MonThiTotNghiep_LopID;
        //    dr[pKQHT_MonThiTotNghiep_LopInfo.strIDDM_Lop] = pKQHT_MonThiTotNghiep_LopInfo.IDDM_Lop;
        //    dr[pKQHT_MonThiTotNghiep_LopInfo.strIDDM_MonHoc] = pKQHT_MonThiTotNghiep_LopInfo.IDDM_MonHoc;
        //    dr[pKQHT_MonThiTotNghiep_LopInfo.strTinhDiem] = pKQHT_MonThiTotNghiep_LopInfo.TinhDiem;
        //    dr[pKQHT_MonThiTotNghiep_LopInfo.strSoHocTrinh] = pKQHT_MonThiTotNghiep_LopInfo.SoHocTrinh;
        //}

        public void ToInfo(ref KQHT_MonThiTotNghiep_LopInfo pKQHT_MonThiTotNghiep_LopInfo, DataRow dr)
        {

            pKQHT_MonThiTotNghiep_LopInfo.KQHT_MonThiTotNghiep_LopID = int.Parse(dr[pKQHT_MonThiTotNghiep_LopInfo.strKQHT_MonThiTotNghiep_LopID].ToString());
            pKQHT_MonThiTotNghiep_LopInfo.IDDM_Lop = int.Parse(dr[pKQHT_MonThiTotNghiep_LopInfo.strIDDM_Lop].ToString());
            pKQHT_MonThiTotNghiep_LopInfo.IDDM_MonHoc = int.Parse(dr[pKQHT_MonThiTotNghiep_LopInfo.strIDDM_MonHoc].ToString());
            pKQHT_MonThiTotNghiep_LopInfo.TinhDiem = bool.Parse(dr[pKQHT_MonThiTotNghiep_LopInfo.strTinhDiem].ToString());
            pKQHT_MonThiTotNghiep_LopInfo.SoHocTrinh = int.Parse(dr[pKQHT_MonThiTotNghiep_LopInfo.strSoHocTrinh].ToString());
        }
    }
}
