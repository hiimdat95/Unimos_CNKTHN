using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDHT_ChucNang : cDBase
    {
        public DataTable GetIn(int IDHT_UserGroup, int IDHT_User)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDHT_UserGroup", SqlDbType.Int, IDHT_UserGroup));
            colParam.Add(CreateParam("@IDHT_User", SqlDbType.Int, IDHT_User));

            return RunProcedureGet("sp_HT_ChucNang_GetIn", colParam);
        }

        public DataTable GetNotIn(int IDHT_UserGroup, int IDHT_User)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDHT_UserGroup", SqlDbType.Int, IDHT_UserGroup));
            colParam.Add(CreateParam("@IDHT_User", SqlDbType.Int, IDHT_User));

            return RunProcedureGet("sp_HT_ChucNang_GetNotIn", colParam);
        }
    }
}
