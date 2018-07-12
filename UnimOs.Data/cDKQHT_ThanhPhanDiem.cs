using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_ThanhPhanDiem : cDBase
    {
        public DataTable GetLapCongThuc()
        {
            ArrayList colParam = new ArrayList();

            return RunProcedureGet("sp_KQHT_ThanhPhanDiem_GetLapCongThuc", colParam);
        }

        public DataTable GetNhapDuLieu()
        {
            ArrayList colParam = new ArrayList();

            return RunProcedureGet("sp_KQHT_ThanhPhanDiem_GetNhapDuLieu", colParam);
        }

        public DataTable GetByIDTrinhDo(int IDDM_TrinhDo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, IDDM_TrinhDo));

            return RunProcedureGet("sp_KQHT_ThanhPhanDiem_GetByIDTrinhDo", colParam);
        }
    }
}
