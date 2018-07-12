using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_KeHoachChiTiet : cDBase
    {
        public DataTable Get_TKB(int IDXL_Tuan)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_Tuan", SqlDbType.BigInt, IDXL_Tuan));

            return RunProcedureGet("sp_XL_KeHoachChiTiet_Get_TKB", colParam);
        }

        public DataTable Get_SuKienTKB(long IDXL_Tuan)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_Tuan", SqlDbType.BigInt, IDXL_Tuan));

            return RunProcedureGet("sp_XL_KeHoachChiTiet_Get_SuKienTKB", colParam);
        }

        public DataTable GetKeHoachByLop(int IDDM_NamHoc, int HocKy, int IDDM_Lop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));

            return RunProcedureGet("sp_XL_KeHoachChiTiet_GetKeHoachByLop", colParam);
        }

        public DataTable GetChiTietGV(int IDNS_GiaoVien, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_XL_KeHoachChiTiet_GetChiTietGV", colParam);
        }
    }
}
