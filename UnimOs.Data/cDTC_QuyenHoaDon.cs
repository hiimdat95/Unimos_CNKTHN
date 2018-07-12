using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_QuyenHoaDon : cDBase
    {
        public DataTable GetByHocKy_NamHoc(int HOcKy, int IDDM_NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HOcKy));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));

            return RunProcedureGet("sp_TC_QuyenHoaDon_GetByHocKy_NamHoc", colParam);
        }
        public DataTable GetTrinhDo(int Type, int IDTC_QuyenHoaDon, int HocKy, int IDDM_NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Type", SqlDbType.Int, Type));
            colParam.Add(CreateParam("@IDTC_QuyenHoaDon", SqlDbType.Int, IDTC_QuyenHoaDon));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));

            return RunProcedureGet("sp_TC_QuyenHoaDon_GetTrinhDo", colParam);
        }
    }
}
