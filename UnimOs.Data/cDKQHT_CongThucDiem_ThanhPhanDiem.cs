using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_CongThucDiem_ThanhPhanDiem : cDBase
    {
        public DataTable GetByCongThucDiem(int IDKQHT_CongThucDiem)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_CongThucDiem", SqlDbType.Int, IDKQHT_CongThucDiem));

            return RunProcedureGet("sp_KQHT_CongThucDiem_ThanhPhanDiem_GetByCongThucDiem", colParam);            
        }
    }
}
