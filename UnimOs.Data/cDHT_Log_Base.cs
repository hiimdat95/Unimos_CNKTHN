using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDHT_Log : cDBase
    {
        public DataTable Get(HT_LogInfo pHT_LogInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_LogID",SqlDbType.BigInt,pHT_LogInfo.HT_LogID));

            return RunProcedureGet("sp_HT_Log_Get", colParam);            
        }

        public int Add(HT_LogInfo pHT_LogInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Tag",SqlDbType.NVarChar,pHT_LogInfo.Tag));
            colParam.Add(CreateParam("@SuKien",SqlDbType.NVarChar,pHT_LogInfo.SuKien));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NText,pHT_LogInfo.NoiDung));
            colParam.Add(CreateParam("@ThoiDiem",SqlDbType.DateTime,pHT_LogInfo.ThoiDiem));
            colParam.Add(CreateParam("@UserName",SqlDbType.NVarChar,pHT_LogInfo.UserName));
            colParam.Add(CreateParam("@IPMayTram",SqlDbType.NVarChar,pHT_LogInfo.IPMayTram));
            colParam.Add(CreateParam("@MacMayTram",SqlDbType.NVarChar,pHT_LogInfo.MacMayTram));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_HT_Log_Add", colParam);
        }
        
        public void Update(HT_LogInfo pHT_LogInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Tag",SqlDbType.NVarChar,pHT_LogInfo.Tag));
            colParam.Add(CreateParam("@SuKien",SqlDbType.NVarChar,pHT_LogInfo.SuKien));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NText,pHT_LogInfo.NoiDung));
            colParam.Add(CreateParam("@ThoiDiem",SqlDbType.DateTime,pHT_LogInfo.ThoiDiem));
            colParam.Add(CreateParam("@UserName",SqlDbType.NVarChar,pHT_LogInfo.UserName));
            colParam.Add(CreateParam("@IPMayTram",SqlDbType.NVarChar,pHT_LogInfo.IPMayTram));
            colParam.Add(CreateParam("@MacMayTram",SqlDbType.NVarChar,pHT_LogInfo.MacMayTram));
            colParam.Add(CreateParam("@HT_LogID",SqlDbType.BigInt,pHT_LogInfo.HT_LogID));

            RunProcedure("sp_HT_Log_Update", colParam);
        }
        
        public void Delete(HT_LogInfo pHT_LogInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_LogID",SqlDbType.BigInt,pHT_LogInfo.HT_LogID));

            RunProcedure("sp_HT_Log_Delete", colParam);
        }
    }
}
