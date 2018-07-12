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
        public DataTable Get(KQHT_DangKyMonChonInfo pKQHT_DangKyMonChonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DangKyMonChonID",SqlDbType.Int,pKQHT_DangKyMonChonInfo.KQHT_DangKyMonChonID));

            return RunProcedureGet("sp_KQHT_DangKyMonChon_Get", colParam);            
        }

        public int Add(KQHT_DangKyMonChonInfo pKQHT_DangKyMonChonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DangKyMonChonInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy",SqlDbType.Int,pKQHT_DangKyMonChonInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@IDHT_User",SqlDbType.Int,pKQHT_DangKyMonChonInfo.IDHT_User));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_DangKyMonChon_Add", colParam);
        }
        
        public void Update(KQHT_DangKyMonChonInfo pKQHT_DangKyMonChonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DangKyMonChonInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy",SqlDbType.Int,pKQHT_DangKyMonChonInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@IDHT_User",SqlDbType.Int,pKQHT_DangKyMonChonInfo.IDHT_User));
            colParam.Add(CreateParam("@KQHT_DangKyMonChonID",SqlDbType.Int,pKQHT_DangKyMonChonInfo.KQHT_DangKyMonChonID));

            RunProcedure("sp_KQHT_DangKyMonChon_Update", colParam);
        }
        
        public void Delete(KQHT_DangKyMonChonInfo pKQHT_DangKyMonChonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DangKyMonChonID",SqlDbType.Int,pKQHT_DangKyMonChonInfo.KQHT_DangKyMonChonID));

            RunProcedure("sp_KQHT_DangKyMonChon_Delete", colParam);
        }
    }
}
