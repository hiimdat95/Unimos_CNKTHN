using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_MonHoc_CT_KhoiKienThuc : cDBase
    {
        public DataTable GetDanhSach(int IDKQHT_CT_KhoiKienThuc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_CT_KhoiKienThuc", SqlDbType.Int, IDKQHT_CT_KhoiKienThuc));

            return RunProcedureGet("sp_KQHT_MonHoc_CT_KhoiKienThuc_GetDanhSach", colParam);
        }
    }
}
