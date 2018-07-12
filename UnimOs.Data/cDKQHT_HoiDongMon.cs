using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_HoiDongMon : cDBase
    {
        public DataTable GetByNamHocHocKy(int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_KQHT_HoiDongMon_GetByNamHocHocKy", colParam);
        }

        public DataTable GetSinhVien(int KQHT_HoiDongMonID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_HoiDongMonID", SqlDbType.Int, KQHT_HoiDongMonID));

            return RunProcedureGet("sp_KQHT_HoiDongMon_GetSinhVien", colParam);
        }

        public DataTable GetGiangVien(int KQHT_HoiDongMonID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_HoiDongMonID", SqlDbType.Int, KQHT_HoiDongMonID));

            return RunProcedureGet("sp_KQHT_HoiDongMon_GetGiangVien", colParam);
        }
    }
}
