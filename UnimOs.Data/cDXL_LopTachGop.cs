using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_LopTachGop : cDBase
    {
        public DataTable GetByHocKyNamHoc(int HocKy, int IDDM_NamHoc, bool LopTach)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@LopTach", SqlDbType.Bit, LopTach));

            return RunProcedureGet("sp_XL_LopTachGop_GetByHocKyNamHoc", colParam);
        }

        public void UpdateTenLopGop(string mXL_LopTachGopIDs, string mTenLopGop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_LopTachGopIDs", SqlDbType.VarChar, 100, mXL_LopTachGopIDs));
            colParam.Add(CreateParam("@TenLopTachGop", SqlDbType.VarChar, 50, mTenLopGop));

            RunProcedure("sp_XL_LopTachGop_UpdateTenLopTachGop", colParam);
        }

        public void DeleteByLopGoc(string mXL_LopTachGopIDs)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_LopTachGopIDs", SqlDbType.VarChar, 100, mXL_LopTachGopIDs));

            RunProcedure("sp_XL_LopTachGop_DeleteByLopGoc", colParam);
        }

    }
}
