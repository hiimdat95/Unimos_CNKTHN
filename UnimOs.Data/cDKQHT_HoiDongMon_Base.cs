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
        public DataTable Get(KQHT_HoiDongMonInfo pKQHT_HoiDongMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_HoiDongMonID",SqlDbType.Int,pKQHT_HoiDongMonInfo.KQHT_HoiDongMonID));

            return RunProcedureGet("sp_KQHT_HoiDongMon_Get", colParam);            
        }

        public int Add(KQHT_HoiDongMonInfo pKQHT_HoiDongMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenHoiDong",SqlDbType.NVarChar,pKQHT_HoiDongMonInfo.TenHoiDong));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_HoiDongMonInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_HoiDongMonInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_HoiDongMonInfo.HocKy));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_HoiDongMon_Add", colParam);
        }
        
        public void Update(KQHT_HoiDongMonInfo pKQHT_HoiDongMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenHoiDong",SqlDbType.NVarChar,pKQHT_HoiDongMonInfo.TenHoiDong));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_HoiDongMonInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_HoiDongMonInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_HoiDongMonInfo.HocKy));
            colParam.Add(CreateParam("@KQHT_HoiDongMonID",SqlDbType.Int,pKQHT_HoiDongMonInfo.KQHT_HoiDongMonID));

            RunProcedure("sp_KQHT_HoiDongMon_Update", colParam);
        }
        
        public void Delete(KQHT_HoiDongMonInfo pKQHT_HoiDongMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_HoiDongMonID",SqlDbType.Int,pKQHT_HoiDongMonInfo.KQHT_HoiDongMonID));

            RunProcedure("sp_KQHT_HoiDongMon_Delete", colParam);
        }
    }
}
