using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_CongThucDiem : cDBase
    {
        public DataTable Get(KQHT_CongThucDiemInfo pKQHT_CongThucDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_CongThucDiemID",SqlDbType.Int,pKQHT_CongThucDiemInfo.KQHT_CongThucDiemID));

            return RunProcedureGet("sp_KQHT_CongThucDiem_Get", colParam);            
        }

        public int Add(KQHT_CongThucDiemInfo pKQHT_CongThucDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pKQHT_CongThucDiemInfo.IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_CongThucDiemInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_CongThucDiemInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_CongThucDiemInfo.HocKy));
            colParam.Add(CreateParam("@CongThuc",SqlDbType.NVarChar,pKQHT_CongThucDiemInfo.CongThuc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_CongThucDiem_Add", colParam);
        }
        
        public void Update(KQHT_CongThucDiemInfo pKQHT_CongThucDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pKQHT_CongThucDiemInfo.IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_CongThucDiemInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_CongThucDiemInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_CongThucDiemInfo.HocKy));
            colParam.Add(CreateParam("@CongThuc",SqlDbType.NVarChar,pKQHT_CongThucDiemInfo.CongThuc));
            colParam.Add(CreateParam("@KQHT_CongThucDiemID",SqlDbType.Int,pKQHT_CongThucDiemInfo.KQHT_CongThucDiemID));

            RunProcedure("sp_KQHT_CongThucDiem_Update", colParam);
        }
        
        public void Delete(KQHT_CongThucDiemInfo pKQHT_CongThucDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_CongThucDiemID",SqlDbType.Int,pKQHT_CongThucDiemInfo.KQHT_CongThucDiemID));

            RunProcedure("sp_KQHT_CongThucDiem_Delete", colParam);
        }
    }
}
