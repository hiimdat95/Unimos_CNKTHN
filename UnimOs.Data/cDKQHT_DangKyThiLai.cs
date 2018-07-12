using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DangKyThiLai : cDBase
    {
        public DataTable GetSinhVien(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int Kieu, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));
            colParam.Add(CreateParam("@Kieu", SqlDbType.Int, Kieu));

            return RunProcedureGet("sp_KQHT_DangKyThiLai_GetSinhVien", colParam);
        }

        public void DeleteByMonHoc(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            RunProcedure("sp_KQHT_DangKyThiLai_DeleteByMonHoc", colParam);
        }
    }
}
