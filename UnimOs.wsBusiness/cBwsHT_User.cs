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
    public class cBwsHT_User : cBwsBase
    {
        private cDHT_User oDHT_User;
        private HT_UserInfo oHT_UserInfo;

        public cBwsHT_User()
        {
            oDHT_User = new cDHT_User();
        }

        //public DataTable Get(HT_UserInfo pHT_UserInfo)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<HT_UserInfo>(client.cDHT_User_Get(GlobalVar.MaXacThuc, pHT_UserInfo));
        //    }
        //}

        public DataTable GetChucNang(string UserName)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_HT_User_GetChucNangResult>(client.cDHT_User_GetChucNang(GlobalVar.MaXacThuc, UserName));
            }
        }

        public DataTable GetByUserName(string UserName)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_HT_User_GetByUserNameResult>(client.cDHT_User_GetByUserName(GlobalVar.MaXacThuc, UserName));
            }
        }

        //public int Add(HT_UserInfo pHT_UserInfo)
        //{
        //    int ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDHT_User_Add(GlobalVar.MaXacThuc, pHT_UserInfo);
        //    client.Close();
        //    mErrorMessage = oDHT_User.ErrorMessages;
        //    mErrorNumber = oDHT_User.ErrorNumber;
        //    return ID;
        //}

        //public void Update(HT_UserInfo pHT_UserInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDHT_User_Update(GlobalVar.MaXacThuc, pHT_UserInfo);
        //    client.Close();
        //    mErrorMessage = oDHT_User.ErrorMessages;
        //    mErrorNumber = oDHT_User.ErrorNumber;
        //}

        public void UpdateChucNang(int HT_UserID, int IDHT_UserGroup)
        {
            var client = new UnimOsServiceClient();
            client.cDHT_User_UpdateChucNang(GlobalVar.MaXacThuc, HT_UserID, IDHT_UserGroup);
            client.Close();
            mErrorMessage = oDHT_User.ErrorMessages;
            mErrorNumber = oDHT_User.ErrorNumber;
        }

        //public void Delete(HT_UserInfo pHT_UserInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDHT_User_Delete(GlobalVar.MaXacThuc, pHT_UserInfo);
        //    client.Close();
        //    mErrorMessage = oDHT_User.ErrorMessages;
        //    mErrorNumber = oDHT_User.ErrorNumber;
        //}

        //public List<HT_UserInfo> GetList(HT_UserInfo pHT_UserInfo)
        //{
        //    List<HT_UserInfo> oHT_UserInfoList = new List<HT_UserInfo>();
        //    DataTable dtb = Get(pHT_UserInfo);
        //    if (dtb != null)
        //    {
        //        for (int i = 0; i < dtb.Rows.Count; i++)
        //        {
        //            oHT_UserInfo = new HT_UserInfo();

        //            oHT_UserInfo.HT_UserID = int.Parse(dtb.Rows[i]["HT_UserID"].ToString());
        //            oHT_UserInfo.UserName = dtb.Rows[i]["UserName"].ToString();
        //            oHT_UserInfo.Password = dtb.Rows[i]["Password"].ToString();
        //            oHT_UserInfo.FullName = dtb.Rows[i]["FullName"].ToString();
        //            oHT_UserInfo.IDNS_GiaoVien = "" + dtb.Rows[i]["IDNS_GiaoVien"] == "" ? 0 : int.Parse("" + dtb.Rows[i]["IDNS_GiaoVien"]);
        //            oHT_UserInfo.IDHT_UserGroup = "" + dtb.Rows[i]["IDHT_UserGroup"] == "" ? 0 : int.Parse("" + dtb.Rows[i]["IDHT_UserGroup"]);
        //            oHT_UserInfo.Active = bool.Parse(dtb.Rows[i]["Active"].ToString());
        //            oHT_UserInfo.IpAddress = dtb.Rows[i]["IpAddress"].ToString();
        //            oHT_UserInfo.MacAddress = dtb.Rows[i]["MacAddress"].ToString();

        //            oHT_UserInfoList.Add(oHT_UserInfo);
        //        }
        //    }
        //    return oHT_UserInfoList;
        //}

        public void ToDataRow(HT_UserInfo pHT_UserInfo, ref DataRow dr)
        {

            dr[pHT_UserInfo.strHT_UserID] = pHT_UserInfo.HT_UserID;
            dr[pHT_UserInfo.strUserName] = pHT_UserInfo.UserName;
            dr[pHT_UserInfo.strPassword] = pHT_UserInfo.Password;
            dr[pHT_UserInfo.strFullName] = pHT_UserInfo.FullName;
            dr[pHT_UserInfo.strIDNS_GiaoVien] = pHT_UserInfo.IDNS_GiaoVien;
            dr[pHT_UserInfo.strIDHT_UserGroup] = pHT_UserInfo.IDHT_UserGroup;
            dr[pHT_UserInfo.strActive] = pHT_UserInfo.Active;
            dr[pHT_UserInfo.strIpAddress] = pHT_UserInfo.IpAddress;
            dr[pHT_UserInfo.strMacAddress] = pHT_UserInfo.MacAddress;
        }

        public void ToInfo(ref HT_UserInfo pHT_UserInfo, DataRow dr)
        {
            pHT_UserInfo.HT_UserID = int.Parse(dr[pHT_UserInfo.strHT_UserID].ToString());
            pHT_UserInfo.UserName = dr[pHT_UserInfo.strUserName].ToString();
            pHT_UserInfo.Password = dr[pHT_UserInfo.strPassword].ToString();
            pHT_UserInfo.FullName = dr[pHT_UserInfo.strFullName].ToString();
            if ("" + dr[pHT_UserInfo.strIDNS_GiaoVien] != "")
                pHT_UserInfo.IDNS_GiaoVien = int.Parse(dr[pHT_UserInfo.strIDNS_GiaoVien].ToString());
            if ("" + dr[pHT_UserInfo.strIDHT_UserGroup] != "")
                pHT_UserInfo.IDHT_UserGroup = int.Parse(dr[pHT_UserInfo.strIDHT_UserGroup].ToString());
            pHT_UserInfo.Active = bool.Parse(dr[pHT_UserInfo.strActive].ToString());
            pHT_UserInfo.IpAddress = "" + dr[pHT_UserInfo.strIpAddress].ToString();
            pHT_UserInfo.MacAddress = "" + dr[pHT_UserInfo.strMacAddress].ToString();
        }
    }
}
