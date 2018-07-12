using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_DonVi : cDBase
    {
        public DataTable GetByID(int IDNS_DonVi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_DonViID", SqlDbType.Int, IDNS_DonVi));

            return RunProcedureGet("sp_NS_DonVi_GetByID", colParam);
        }

        public DataTable GetByIDDM_Khoa(int IDDM_Khoa)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, IDDM_Khoa));

            return RunProcedureGet("sp_NS_DonVi_GetByIDDM_Khoa", colParam);
        }
    }
}
