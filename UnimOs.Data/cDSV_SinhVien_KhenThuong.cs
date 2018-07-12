using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_SinhVien_KhenThuong : cDBase
    {
        public DataTable GetByQuyetDinh(int IDSV_QuyetDinhKhenThuong)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_QuyetDinhKhenThuong", SqlDbType.Int, IDSV_QuyetDinhKhenThuong));

            return RunProcedureGet("sp_SV_SinhVien_KhenThuong_GetByQuyetDinh", colParam);
        }
    }
}
