using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_TrinhDoLyLuan : cDBase
    {
        public DataTable Get(DM_TrinhDoLyLuanInfo pDM_TrinhDoLyLuanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_TrinhDoLyLuanID",SqlDbType.Int,pDM_TrinhDoLyLuanInfo.DM_TrinhDoLyLuanID));

            return RunProcedureGet("sp_DM_TrinhDoLyLuan_Get", colParam);            
        }

        public int Add(DM_TrinhDoLyLuanInfo pDM_TrinhDoLyLuanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenTrinhDoLyLuan",SqlDbType.NVarChar,pDM_TrinhDoLyLuanInfo.TenTrinhDoLyLuan));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_TrinhDoLyLuan_Add", colParam);
        }
        
        public void Update(DM_TrinhDoLyLuanInfo pDM_TrinhDoLyLuanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenTrinhDoLyLuan",SqlDbType.NVarChar,pDM_TrinhDoLyLuanInfo.TenTrinhDoLyLuan));
            colParam.Add(CreateParam("@DM_TrinhDoLyLuanID",SqlDbType.Int,pDM_TrinhDoLyLuanInfo.DM_TrinhDoLyLuanID));

            RunProcedure("sp_DM_TrinhDoLyLuan_Update", colParam);
        }
        
        public void Delete(DM_TrinhDoLyLuanInfo pDM_TrinhDoLyLuanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_TrinhDoLyLuanID",SqlDbType.Int,pDM_TrinhDoLyLuanInfo.DM_TrinhDoLyLuanID));

            RunProcedure("sp_DM_TrinhDoLyLuan_Delete", colParam);
        }
    }
}
