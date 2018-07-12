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
        public void UpdateChucNang(int HT_UserID, int IDHT_UserGroup)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDHT_UserGroup", SqlDbType.Int, IDHT_UserGroup));
            colParam.Add(CreateParam("@HT_UserID", SqlDbType.Int, HT_UserID));

            RunProcedure("sp_HT_User_UpdateChucNang", colParam);
        }

        public DataTable GetChucNang(string UserName)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@UserName", SqlDbType.NVarChar, 50, UserName));

            return RunProcedureGet("sp_HT_User_GetChucNang", colParam);
        }

        public DataTable GetByUserName(string UserName)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@UserName", SqlDbType.NVarChar, UserName));

            return RunProcedureGet("sp_HT_User_GetByUserName", colParam);
        }
    }
}
