using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_QuyChe_ThamSoQuyChe : cDBase
    {
        public DataTable Get(KQHT_QuyChe_ThamSoQuyCheInfo pKQHT_QuyChe_ThamSoQuyCheInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_QuyChe_ThamSoQuyCheID",SqlDbType.Int,pKQHT_QuyChe_ThamSoQuyCheInfo.KQHT_QuyChe_ThamSoQuyCheID));

            return RunProcedureGet("sp_KQHT_QuyChe_ThamSoQuyChe_Get", colParam);            
        }

        public void Delete_By_QuyChe(int KQHT_QuyCheID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_QuyCheID", SqlDbType.Int, KQHT_QuyCheID));

            RunProcedure("sp_KQHT_QuyChe_ThamSoQuyChe_Delete_By_QuyChe", colParam);
        }
        
        public void Update(KQHT_QuyChe_ThamSoQuyCheInfo pKQHT_QuyChe_ThamSoQuyCheInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_QuyChe",SqlDbType.Int,pKQHT_QuyChe_ThamSoQuyCheInfo.IDKQHT_QuyChe));
            colParam.Add(CreateParam("@IDKQHT_ThamSoQuyChe",SqlDbType.Int,pKQHT_QuyChe_ThamSoQuyCheInfo.IDKQHT_ThamSoQuyChe));
            colParam.Add(CreateParam("@GiaTri",SqlDbType.NVarChar,pKQHT_QuyChe_ThamSoQuyCheInfo.GiaTri));
            colParam.Add(CreateParam("@KQHT_QuyChe_ThamSoQuyCheID",SqlDbType.Int,pKQHT_QuyChe_ThamSoQuyCheInfo.KQHT_QuyChe_ThamSoQuyCheID));

            RunProcedure("sp_KQHT_QuyChe_ThamSoQuyChe_Update", colParam);
        }
        
        public void Delete(KQHT_QuyChe_ThamSoQuyCheInfo pKQHT_QuyChe_ThamSoQuyCheInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_QuyChe_ThamSoQuyCheID",SqlDbType.Int,pKQHT_QuyChe_ThamSoQuyCheInfo.KQHT_QuyChe_ThamSoQuyCheID));

            RunProcedure("sp_KQHT_QuyChe_ThamSoQuyChe_Delete", colParam);
        }
    }
}
