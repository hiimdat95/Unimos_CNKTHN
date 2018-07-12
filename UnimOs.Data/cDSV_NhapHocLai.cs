using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_NhapHocLai : cDBase
    {
        public DataTable GetSinhVien_ChuaNhapHoc()
        {
            ArrayList colParam = new ArrayList();

            return RunProcedureGet("sp_SV_NhapHocLai_GetSinhVien_ChuaNhapHoc", colParam);
        }
        public DataTable GetSinhVien(int IDDM_Lop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_LopMoi", SqlDbType.Int, IDDM_Lop));

            return RunProcedureGet("sp_SV_NhapHocLai_GetSinhVien", colParam);
        }
    }
}
