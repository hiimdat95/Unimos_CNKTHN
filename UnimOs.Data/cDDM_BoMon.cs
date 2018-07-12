using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_BoMon : cDBase
    {
        public DataTable GetByIDKhoa(int IDDM_Khoa)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, IDDM_Khoa));

            return RunProcedureGet("sp_DM_BoMon_GetByIDKhoa", colParam);
        }
    }
}
