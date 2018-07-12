using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDHT_User : cDBase
    {
        public DataTable Get(HT_UserInfo pHT_UserInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_UserID",SqlDbType.Int,pHT_UserInfo.HT_UserID));

            return RunProcedureGet("sp_HT_User_Get", colParam);            
        }

        public int Add(HT_UserInfo pHT_UserInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@UserName",SqlDbType.NVarChar,pHT_UserInfo.UserName));
            colParam.Add(CreateParam("@Password",SqlDbType.NVarChar,pHT_UserInfo.Password));
            colParam.Add(CreateParam("@FullName",SqlDbType.NVarChar,pHT_UserInfo.FullName));
            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pHT_UserInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDHT_UserGroup",SqlDbType.Int,pHT_UserInfo.IDHT_UserGroup));
            colParam.Add(CreateParam("@Active",SqlDbType.Bit,pHT_UserInfo.Active));
            colParam.Add(CreateParam("@IpAddress",SqlDbType.NVarChar,pHT_UserInfo.IpAddress));
            colParam.Add(CreateParam("@MacAddress",SqlDbType.NVarChar,pHT_UserInfo.MacAddress));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_HT_User_Add", colParam);
        }
        
        public void Update(HT_UserInfo pHT_UserInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@UserName",SqlDbType.NVarChar,pHT_UserInfo.UserName));
            colParam.Add(CreateParam("@Password",SqlDbType.NVarChar,pHT_UserInfo.Password));
            colParam.Add(CreateParam("@FullName",SqlDbType.NVarChar,pHT_UserInfo.FullName));
            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pHT_UserInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDHT_UserGroup",SqlDbType.Int,pHT_UserInfo.IDHT_UserGroup));
            colParam.Add(CreateParam("@Active",SqlDbType.Bit,pHT_UserInfo.Active));
            colParam.Add(CreateParam("@IpAddress",SqlDbType.NVarChar,pHT_UserInfo.IpAddress));
            colParam.Add(CreateParam("@MacAddress",SqlDbType.NVarChar,pHT_UserInfo.MacAddress));
            colParam.Add(CreateParam("@HT_UserID",SqlDbType.Int,pHT_UserInfo.HT_UserID));

            RunProcedure("sp_HT_User_Update", colParam);
        }
        
        public void Delete(HT_UserInfo pHT_UserInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_UserID",SqlDbType.Int,pHT_UserInfo.HT_UserID));

            RunProcedure("sp_HT_User_Delete", colParam);
        }
    }
}
