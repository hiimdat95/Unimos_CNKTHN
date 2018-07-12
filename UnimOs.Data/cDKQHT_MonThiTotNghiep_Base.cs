using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_MonThiTotNghiep : cDBase
    {
        public DataTable Get(KQHT_MonThiTotNghiepInfo pKQHT_MonThiTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_MonThiTotNghiepID",SqlDbType.Int,pKQHT_MonThiTotNghiepInfo.KQHT_MonThiTotNghiepID));

            return RunProcedureGet("sp_KQHT_MonThiTotNghiep_Get", colParam);            
        }

        public int Add(KQHT_MonThiTotNghiepInfo pKQHT_MonThiTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaMon",SqlDbType.NVarChar,pKQHT_MonThiTotNghiepInfo.MaMon));
            colParam.Add(CreateParam("@TenMon",SqlDbType.NVarChar,pKQHT_MonThiTotNghiepInfo.TenMon));
            colParam.Add(CreateParam("@TinhDiem",SqlDbType.Bit,pKQHT_MonThiTotNghiepInfo.TinhDiem));
            colParam.Add(CreateParam("@DiemDieuKien",SqlDbType.Float,pKQHT_MonThiTotNghiepInfo.DiemDieuKien));
            colParam.Add(CreateParam("@SoHocTrinh",SqlDbType.Float,pKQHT_MonThiTotNghiepInfo.SoHocTrinh));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_MonThiTotNghiep_Add", colParam);
        }
        
        public void Update(KQHT_MonThiTotNghiepInfo pKQHT_MonThiTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaMon",SqlDbType.NVarChar,pKQHT_MonThiTotNghiepInfo.MaMon));
            colParam.Add(CreateParam("@TenMon",SqlDbType.NVarChar,pKQHT_MonThiTotNghiepInfo.TenMon));
            colParam.Add(CreateParam("@TinhDiem",SqlDbType.Bit,pKQHT_MonThiTotNghiepInfo.TinhDiem));
            colParam.Add(CreateParam("@DiemDieuKien",SqlDbType.Float,pKQHT_MonThiTotNghiepInfo.DiemDieuKien));
            colParam.Add(CreateParam("@SoHocTrinh",SqlDbType.Float,pKQHT_MonThiTotNghiepInfo.SoHocTrinh));
            colParam.Add(CreateParam("@KQHT_MonThiTotNghiepID",SqlDbType.Int,pKQHT_MonThiTotNghiepInfo.KQHT_MonThiTotNghiepID));

            RunProcedure("sp_KQHT_MonThiTotNghiep_Update", colParam);
        }
        
        public void Delete(KQHT_MonThiTotNghiepInfo pKQHT_MonThiTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_MonThiTotNghiepID",SqlDbType.Int,pKQHT_MonThiTotNghiepInfo.KQHT_MonThiTotNghiepID));

            RunProcedure("sp_KQHT_MonThiTotNghiep_Delete", colParam);
        }
    }
}
