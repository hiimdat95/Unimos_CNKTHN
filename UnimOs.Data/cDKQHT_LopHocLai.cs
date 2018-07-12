using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_LopHocLai : cDBase
    {
        public DataTable GetByHocKyNamHoc(int IDDM_MonHoc,int HocKy, int IDNamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDNamHoc));

            return RunProcedureGet("sp_KQHT_LopHocLai_GetByHocKyNamHoc", colParam);
        }

        public DataTable GetSinhVien(int IDKQHT_LopHocLai, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_LopHocLai", SqlDbType.Int, IDKQHT_LopHocLai));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));

            return RunProcedureGet("sp_KQHT_LopHocLai_GetSinhVien", colParam);
        }
    }
}
