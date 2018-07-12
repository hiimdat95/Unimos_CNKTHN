using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDGG_HeSoTheoTrinhDo : cDBase
    {
        public DataTable GetAll()
        {
            ArrayList colParam = new ArrayList();

            return RunProcedureGet("sp_GG_HeSoTheoTrinhDo_GetAll", colParam);
        }
    }
}
