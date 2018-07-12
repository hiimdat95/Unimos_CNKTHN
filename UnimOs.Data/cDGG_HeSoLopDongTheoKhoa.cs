using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDGG_HeSoLopDongTheoKhoa : cDBase
    {
        public DataTable GetAll(int GG_HeSoLopDongTheoKhoaID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@GG_HeSoLopDongTheoKhoaID", SqlDbType.Int, GG_HeSoLopDongTheoKhoaID));

            return RunProcedureGet("sp_GG_HeSoLopDongTheoKhoa_GetAll", colParam);
        }
    }
}
