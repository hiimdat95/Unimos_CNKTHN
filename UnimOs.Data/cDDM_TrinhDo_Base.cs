using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_TrinhDo : cDBase
    {
        public DataTable Get(DM_TrinhDoInfo pDM_TrinhDoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_TrinhDoID",SqlDbType.Int,pDM_TrinhDoInfo.DM_TrinhDoID));

            return RunProcedureGet("sp_DM_TrinhDo_Get", colParam);            
        }

        public int Add(DM_TrinhDoInfo pDM_TrinhDoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He",SqlDbType.Int,pDM_TrinhDoInfo.IDDM_He));
            colParam.Add(CreateParam("@IDKQHT_QuyChe",SqlDbType.Int,pDM_TrinhDoInfo.IDKQHT_QuyChe));
            colParam.Add(CreateParam("@MaTrinhDo",SqlDbType.NVarChar,pDM_TrinhDoInfo.MaTrinhDo));
            colParam.Add(CreateParam("@TenTrinhDo",SqlDbType.NVarChar,pDM_TrinhDoInfo.TenTrinhDo));
            colParam.Add(CreateParam("@TenTrinhDo_E",SqlDbType.NVarChar,pDM_TrinhDoInfo.TenTrinhDo_E));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_TrinhDo_Add", colParam);
        }
        
        public void Update(DM_TrinhDoInfo pDM_TrinhDoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He",SqlDbType.Int,pDM_TrinhDoInfo.IDDM_He));
            colParam.Add(CreateParam("@IDKQHT_QuyChe",SqlDbType.Int,pDM_TrinhDoInfo.IDKQHT_QuyChe));
            colParam.Add(CreateParam("@MaTrinhDo",SqlDbType.NVarChar,pDM_TrinhDoInfo.MaTrinhDo));
            colParam.Add(CreateParam("@TenTrinhDo",SqlDbType.NVarChar,pDM_TrinhDoInfo.TenTrinhDo));
            colParam.Add(CreateParam("@TenTrinhDo_E",SqlDbType.NVarChar,pDM_TrinhDoInfo.TenTrinhDo_E));
            colParam.Add(CreateParam("@DM_TrinhDoID",SqlDbType.Int,pDM_TrinhDoInfo.DM_TrinhDoID));

            RunProcedure("sp_DM_TrinhDo_Update", colParam);
        }
        
        public void Delete(DM_TrinhDoInfo pDM_TrinhDoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_TrinhDoID",SqlDbType.Int,pDM_TrinhDoInfo.DM_TrinhDoID));

            RunProcedure("sp_DM_TrinhDo_Delete", colParam);
        }
    }
}
