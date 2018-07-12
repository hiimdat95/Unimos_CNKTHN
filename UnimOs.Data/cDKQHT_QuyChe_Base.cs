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
        public DataTable Get(KQHT_QuyCheInfo pKQHT_QuyCheInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_QuyCheID",SqlDbType.Int,pKQHT_QuyCheInfo.KQHT_QuyCheID));

            return RunProcedureGet("sp_KQHT_QuyChe_Get", colParam);            
        }

        public int Add(KQHT_QuyCheInfo pKQHT_QuyCheInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaQuyChe",SqlDbType.NVarChar,pKQHT_QuyCheInfo.MaQuyChe));
            colParam.Add(CreateParam("@TenQuyChe",SqlDbType.NVarChar,pKQHT_QuyCheInfo.TenQuyChe));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_QuyChe_Add", colParam);
        }
        
        public void Update(KQHT_QuyCheInfo pKQHT_QuyCheInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaQuyChe",SqlDbType.NVarChar,pKQHT_QuyCheInfo.MaQuyChe));
            colParam.Add(CreateParam("@TenQuyChe",SqlDbType.NVarChar,pKQHT_QuyCheInfo.TenQuyChe));
            colParam.Add(CreateParam("@KQHT_QuyCheID",SqlDbType.Int,pKQHT_QuyCheInfo.KQHT_QuyCheID));

            RunProcedure("sp_KQHT_QuyChe_Update", colParam);
        }
        
        public void Delete(KQHT_QuyCheInfo pKQHT_QuyCheInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_QuyCheID",SqlDbType.Int,pKQHT_QuyCheInfo.KQHT_QuyCheID));

            RunProcedure("sp_KQHT_QuyChe_Delete", colParam);
        }
    }
}
