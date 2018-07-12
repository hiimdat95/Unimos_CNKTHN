using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DangKyMonChon : cDBase
    {
        public DataTable GetSinhVien(int IDDM_Lop, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy, int Kieu)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@Kieu", SqlDbType.Int, Kieu));

            return RunProcedureGet("sp_KQHT_DangKyMonChon_GetSinhVien", colParam);
        }
        public void DeleteByMonHoc(KQHT_DangKyMonChonInfo pKQHT_DangKyMonChonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, pKQHT_DangKyMonChonInfo.IDXL_MonHocTrongKy));

            RunProcedure("sp_KQHT_DangKyMonChon_DeleteMonHoc", colParam);
        }
    }
}
