using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_SinhVien_QuanHeGiaDinh : cDBase
    {
        public DataTable GetBySinhVien(int IDSV_SinhVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));

            return RunProcedureGet("sp_SV_SinhVien_QuanHeGiaDinh_GetBySinhVien", colParam);
        }
    }
}
