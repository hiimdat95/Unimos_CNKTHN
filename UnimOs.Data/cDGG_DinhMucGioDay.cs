using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDGG_DinhMucGioDay : cDBase
    {
        public DataTable GetByIDNS_DonVi(int IDNS_DonVi, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_DonVi", SqlDbType.Int, IDNS_DonVi));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_GG_DinhMucGioDay_GetByIDNS_DonVi", colParam);
        }
    }
}
