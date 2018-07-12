using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DangKyThiLaiTotNghiep : cDBase
    {
        public DataTable GetByMon(int IDDM_MonHoc, int IDDM_NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));

            return RunProcedureGet("sp_KQHT_DangKyThiLaiTotNghiep_GetByMon", colParam);
        }
        public DataTable GetThiLai(int IDDM_MonHoc, int IDDM_NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));

            return RunProcedureGet("sp_KQHT_DangKyThiLaiTotNghiep_GetThiLai", colParam);
        }
        public DataTable GetChuaThi(int IDDM_MonHoc, int IDDM_NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));

            return RunProcedureGet("sp_KQHT_DangKyThiLaiTotNghiep_GetChuaThi", colParam);
        }
        public void DeleteByMon(int IDDM_MonHoc, int IDDM_NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));

            RunProcedure("sp_KQHT_DangKyThiLaiTotNghiep_DeleteByMon", colParam);
        }
    }
}
