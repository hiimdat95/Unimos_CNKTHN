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
        public DataTable GetByIDHe(int IDDM_He)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, IDDM_He));

            return RunProcedureGet("sp_DM_TrinhDo_GetByIDHe", colParam);
        }
    }
}
