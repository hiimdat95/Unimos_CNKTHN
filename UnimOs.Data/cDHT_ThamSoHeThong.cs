using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDHT_ThamSoHeThong : cDBase
    {
        public DataTable GetByMaThamSo(string MaThamSoHeThong)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaThamSoHeThong", SqlDbType.NVarChar, MaThamSoHeThong));

            return RunProcedureGet("sp_HT_ThamSoHeThong_GetByMaThamSo", colParam);
        }

        public DataTable GetByPhanHe(int PhanHe)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@PhanHe", SqlDbType.Int, PhanHe));

            return RunProcedureGet("sp_HT_ThamSoHeThong_GetByPhanHe", colParam);
        }
    }
}
