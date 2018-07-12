using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_MonThiTotNghiep_Lop : cDBase
    {
        public DataTable GetAllMon(int IDDM_NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));

            return RunProcedureGet("sp_KQHT_MonThiTotNghiep_Lop_GetAllMon", colParam);
        }

        public DataTable GetIn_Mon(int IDDM_Lop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));

            return RunProcedureGet("sp_KQHT_MonThiTotNghiep_Lop_GetIn_Mon", colParam);
        }

        public DataTable GetNotIn_Mon(int IDDM_Lop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));

            return RunProcedureGet("sp_KQHT_MonThiTotNghiep_Lop_GetNotIn_Mon", colParam);
        }

        public void Delete_ByLop(int IDDM_Lop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));

            RunProcedure("sp_KQHT_MonThiTotNghiep_Lop_Delete_ByLop", colParam);
        }
    }
}
