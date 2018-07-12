using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_ThangRenLuyenTrongKy : cDBase
    {
        public DataTable GetByHocKyNamHoc(int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_SV_ThangRenLuyenTrongKy_GetByHocKyNamHoc", colParam);
        }
    }
}
