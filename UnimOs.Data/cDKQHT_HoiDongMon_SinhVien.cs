using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_HoiDongMon_SinhVien : cDBase
    {
        public DataTable GetByThiTotNghiep(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int IDKQHT_HoiDongMon)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@IDKQHT_HoiDongMon", SqlDbType.Int, IDKQHT_HoiDongMon));

            return RunProcedureGet("sp_KQHT_HoiDongMon_SinhVien_GetByThiTotNghiep", colParam);
        }

    }
}
