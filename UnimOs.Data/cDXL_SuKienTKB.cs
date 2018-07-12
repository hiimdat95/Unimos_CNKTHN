using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_SuKienTKB : cDBase
    {
        public bool CheckExist(long IDXL_Tuan)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_Tuan", SqlDbType.BigInt, IDXL_Tuan));

            DataTable dt = RunProcedureGet("sp_XL_SuKienTKB_Check_Exist", colParam);
            if (dt.Rows.Count > 0)
            {
                if (int.Parse(dt.Rows[0][0].ToString()) == 0)
                    return false;
                return true;
            }
            return false;
        }

        public DataTable Get_TKB(long IDXL_Tuan)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_Tuan", SqlDbType.BigInt, IDXL_Tuan));

            return RunProcedureGet("sp_XL_SuKienTKB_Get_TKB", colParam);
        }

        public DataSet Get_TKBByIDDM_Lop(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGetDataSet("sp_XL_SuKienTKB_GetTKBByIDDM_Lop", colParam);
        }
    }
}
