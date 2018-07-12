using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_ToaNha : cDBase
    {
        public DataTable GetByIDDiaDiem(int IDDM_DiaDiem)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_DiaDiem", SqlDbType.Int, IDDM_DiaDiem));

            return RunProcedureGet("sp_DM_ToaNha_GetByIDDiaDiem", colParam);
        }
    }
}
