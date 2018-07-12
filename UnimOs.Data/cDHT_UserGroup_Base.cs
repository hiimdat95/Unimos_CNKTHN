using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDHT_UserGroup : cDBase
    {
        public DataTable Get(HT_UserGroupInfo pHT_UserGroupInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_UserGroupID",SqlDbType.Int,pHT_UserGroupInfo.HT_UserGroupID));

            return RunProcedureGet("sp_HT_UserGroup_Get", colParam);            
        }

        public int Add(HT_UserGroupInfo pHT_UserGroupInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenNhom",SqlDbType.NVarChar,pHT_UserGroupInfo.TenNhom));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_HT_UserGroup_Add", colParam);
        }
        
        public void Update(HT_UserGroupInfo pHT_UserGroupInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenNhom",SqlDbType.NVarChar,pHT_UserGroupInfo.TenNhom));
            colParam.Add(CreateParam("@HT_UserGroupID",SqlDbType.Int,pHT_UserGroupInfo.HT_UserGroupID));

            RunProcedure("sp_HT_UserGroup_Update", colParam);
        }
        
        public void Delete(HT_UserGroupInfo pHT_UserGroupInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_UserGroupID",SqlDbType.Int,pHT_UserGroupInfo.HT_UserGroupID));

            RunProcedure("sp_HT_UserGroup_Delete", colParam);
        }
    }
}
