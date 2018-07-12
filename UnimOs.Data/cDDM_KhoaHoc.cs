using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_KhoaHoc : cDBase
    {
        public DataTable GetAll()
        {
            ArrayList colParam = new ArrayList();

            return RunProcedureGet("sp_DM_KhoaHoc_GetAll", colParam);
        }
    }
}
