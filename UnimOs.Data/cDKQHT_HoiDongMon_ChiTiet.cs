using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_HoiDongMon_ChiTiet : cDBase
    {
        public DataTable GetByIDHoiDong(int IDKQHT_HoiDongMon)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_HoiDongMon", SqlDbType.Int, IDKQHT_HoiDongMon));

            return RunProcedureGet("sp_KQHT_HoiDongMon_ChiTiet_GetByIDHoiDong", colParam);
        }
    }
}
