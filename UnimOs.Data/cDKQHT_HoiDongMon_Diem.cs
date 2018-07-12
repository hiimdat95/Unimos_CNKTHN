using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_HoiDongMon_Diem : cDBase
    {
        public DataTable GetDanhSach(int KQHT_HoiDongMonID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_HoiDongMonID", SqlDbType.Int, KQHT_HoiDongMonID));

            return RunProcedureGet("sp_KQHT_HoiDongMon_Diem_GetDanhSach", colParam);
        }
    }
}
