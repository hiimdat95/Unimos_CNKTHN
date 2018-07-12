using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDGG_DinhMucTheoChucDanh : cDBase
    {
        public DataTable Get()
        {
            ArrayList colParam = new ArrayList();
            return RunProcedureGet("sp_GG_DinhMucTheoChucDanh_Get_All", colParam);
        }
    }
}
