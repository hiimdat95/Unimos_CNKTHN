using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_QuyChe : cDBase
    {
        public DataTable GetThamSo(int KQHT_QuyCheID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_QuyCheID", SqlDbType.Int, KQHT_QuyCheID));

            return RunProcedureGet("sp_KQHT_QuyChe_GetThamSo", colParam);
        }

        public DataTable GetThamSo_NotIn(int KQHT_QuyCheID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_QuyCheID", SqlDbType.Int, KQHT_QuyCheID));

            return RunProcedureGet("sp_KQHT_QuyChe_GetThamSo_NotIn", colParam);
        }

        public string GetByMaThamSo(int IDDM_TrinhDo, string MaThamSo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, IDDM_TrinhDo));
            colParam.Add(CreateParam("@MaThamSo", SqlDbType.NVarChar, MaThamSo));
            colParam.Add(CreateParamOut("@GiaTri", SqlDbType.NVarChar, 200));

            return (string)RunProcedureOut("sp_KQHT_QuyChe_GetByMaThamSo", colParam, "GiaTri");
        }
    }
}
