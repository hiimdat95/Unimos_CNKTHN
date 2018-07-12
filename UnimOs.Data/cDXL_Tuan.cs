using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_Tuan : cDBase
    {
        public DataTable GetByIDNamHoc(XL_TuanInfo pTuanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNamHoc", SqlDbType.Int, pTuanInfo.IDDM_NamHoc));

            return RunProcedureGet("sp_XL_Tuan_GetByIDNamHoc", colParam);
        }

        public DataTable GetByTuanThu(XL_TuanInfo pTuanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TuanThu", SqlDbType.Int, pTuanInfo.TuanThu));
            colParam.Add(CreateParam("@IDNamHoc", SqlDbType.Int, pTuanInfo.IDDM_NamHoc));

            return RunProcedureGet("sp_XL_Tuan_GetByTuanThu", colParam);
        }

        public DataTable GetBy_NamHoc_HocKy(int IDNamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@IDNamHoc", SqlDbType.Int, IDNamHoc));

            return RunProcedureGet("sp_XL_Tuan_GetByNamHoc_HocKy", colParam);
        }

        public DataTable GetByTuanThu(int IDNamHoc, int HocKy, int TuTuan)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNamHoc", SqlDbType.Int, IDNamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@TuTuan", SqlDbType.Int, TuTuan));

            return RunProcedureGet("sp_XL_Tuan_GetByTuTuan", colParam);
        }

        public void DeleteTuanThua(XL_TuanInfo pTuanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TuanThu", SqlDbType.Int, pTuanInfo.TuanThu));
            colParam.Add(CreateParam("@IDNamHoc", SqlDbType.Int, pTuanInfo.IDDM_NamHoc));

            RunProcedure("sp_XL_Tuan_DeleteTuanThua", colParam);
        }
    }
}
