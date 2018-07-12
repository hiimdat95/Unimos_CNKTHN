using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_CongThucDiemToanKhoa : cDBase
    {
        public DataTable Get(KQHT_CongThucDiemToanKhoaInfo pKQHT_CongThucDiemToanKhoaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_CongThucDiemToanKhoaID",SqlDbType.Int,pKQHT_CongThucDiemToanKhoaInfo.KQHT_CongThucDiemToanKhoaID));

            return RunProcedureGet("sp_KQHT_CongThucDiemToanKhoa_Get", colParam);            
        }

        public int Add(KQHT_CongThucDiemToanKhoaInfo pKQHT_CongThucDiemToanKhoaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenCongThucDiem",SqlDbType.NVarChar,pKQHT_CongThucDiemToanKhoaInfo.TenCongThucDiem));
            colParam.Add(CreateParam("@CongThuc",SqlDbType.NVarChar,pKQHT_CongThucDiemToanKhoaInfo.CongThuc));
            colParam.Add(CreateParam("@GhChu",SqlDbType.NVarChar,pKQHT_CongThucDiemToanKhoaInfo.GhChu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_CongThucDiemToanKhoa_Add", colParam);
        }
        
        public void Update(KQHT_CongThucDiemToanKhoaInfo pKQHT_CongThucDiemToanKhoaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenCongThucDiem",SqlDbType.NVarChar,pKQHT_CongThucDiemToanKhoaInfo.TenCongThucDiem));
            colParam.Add(CreateParam("@CongThuc",SqlDbType.NVarChar,pKQHT_CongThucDiemToanKhoaInfo.CongThuc));
            colParam.Add(CreateParam("@GhChu",SqlDbType.NVarChar,pKQHT_CongThucDiemToanKhoaInfo.GhChu));
            colParam.Add(CreateParam("@KQHT_CongThucDiemToanKhoaID",SqlDbType.Int,pKQHT_CongThucDiemToanKhoaInfo.KQHT_CongThucDiemToanKhoaID));

            RunProcedure("sp_KQHT_CongThucDiemToanKhoa_Update", colParam);
        }
        
        public void Delete(KQHT_CongThucDiemToanKhoaInfo pKQHT_CongThucDiemToanKhoaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_CongThucDiemToanKhoaID",SqlDbType.Int,pKQHT_CongThucDiemToanKhoaInfo.KQHT_CongThucDiemToanKhoaID));

            RunProcedure("sp_KQHT_CongThucDiemToanKhoa_Delete", colParam);
        }
    }
}
