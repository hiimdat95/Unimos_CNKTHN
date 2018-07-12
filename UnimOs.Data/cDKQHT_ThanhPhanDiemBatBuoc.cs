using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_ThanhPhanDiemBatBuoc : cDBase
    {
        public DataTable GetByIDThanhPhanDiem(int IDKQHT_ThanhPhanDiem)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_ThanhPhanDiem", SqlDbType.Int, IDKQHT_ThanhPhanDiem));

            return RunProcedureGet("sp_KQHT_ThanhPhanDiemBatBuoc_GetByIDThanhPhanDiem", colParam);
        }

        public DataTable GetByTrinhDo(int IDDM_TrinhDo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, IDDM_TrinhDo));

            return RunProcedureGet("sp_KQHT_ThanhPhanDiemBatBuoc_GetByTrinhDo", colParam);
        }
    }
}
