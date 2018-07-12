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
        public int Add(KQHT_QuyChe_ThamSoQuyCheInfo pKQHT_QuyChe_ThamSoQuyCheInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_QuyChe", SqlDbType.Int, pKQHT_QuyChe_ThamSoQuyCheInfo.IDKQHT_QuyChe));
            colParam.Add(CreateParam("@IDKQHT_ThamSoQuyChe", SqlDbType.Int, pKQHT_QuyChe_ThamSoQuyCheInfo.IDKQHT_ThamSoQuyChe));
            colParam.Add(CreateParam("@GiaTri", SqlDbType.NVarChar, pKQHT_QuyChe_ThamSoQuyCheInfo.GiaTri));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_QuyChe_ThamSoQuyChe_Add", colParam);
        }
    }
}
