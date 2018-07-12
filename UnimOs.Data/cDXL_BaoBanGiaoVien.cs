using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_BaoBanGiaoVien : cDBase
    {
        public DataTable GetByHocKy(int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_XL_BaoBanGiaoVien_GetByHocKy", colParam);
        }

        public DataTable GetByIDTuan(long IDXL_Tuan)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_Tuan", SqlDbType.BigInt, IDXL_Tuan));

            return RunProcedureGet("sp_XL_BaoBanGiaoVien_GetByIDTuan", colParam);
        }
    }
}
