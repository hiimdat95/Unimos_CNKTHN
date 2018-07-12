using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_QuaTrinhBoNhiemChucVu : cDBase
    {
        public DataTable GetBy_IDNS_GiaoVien(int IDNS_GiaoVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));

            return RunProcedureGet("sp_NS_QuaTrinhBoNhiemChucVu_GetBy_IDNS_GiaoVien", colParam);
        }

        public DataTable GetSoLuongBoNhiem(DateTime DenNgay)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DenNgay", SqlDbType.DateTime, DenNgay));

            return RunProcedureGet("sp_NS_QuaTrinhBoNhiemChucVu_GetSoLuongBoNhiem", colParam);
        }

        public DataTable GetSoLuongBienCheSuNghiep(DateTime DenNgay)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DenNgay", SqlDbType.DateTime, DenNgay));

            return RunProcedureGet("sp_NS_QuaTrinhBoNhiemChucVu_GetSoLuongBienCheSuNghiep", colParam);
        }
    }
}
