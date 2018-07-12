using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_LoaiThuChi : cDBase
    {
        public DataTable GetBy_IDNamHoc_HocKy(int IDNamHoc, int HocKy, bool HasParent)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNamHoc", SqlDbType.Int, IDNamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@HasParent", SqlDbType.Bit, HasParent));

            return RunProcedureGet("sp_TC_LoaiThuChi_GetBy_IDNamHoc_HocKy", colParam);
        }

        public DataTable GetTongHop()
        {
            ArrayList colParam = new ArrayList();

            return RunProcedureGet("sp_TC_LoaiThuChi_GetTongHop", colParam);
        }
    }
}
