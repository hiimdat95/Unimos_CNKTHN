using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_SinhVien_KyLuat : cDBase
    {
        public DataTable GetByQuyetDinh(int IDSV_QuyetDinhKyLuat)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_QuyetDinhKyLuat", SqlDbType.Int, IDSV_QuyetDinhKyLuat));

            return RunProcedureGet("sp_SV_SinhVien_KyLuat_GetByQuyetDinh", colParam);
        }
    }
}
