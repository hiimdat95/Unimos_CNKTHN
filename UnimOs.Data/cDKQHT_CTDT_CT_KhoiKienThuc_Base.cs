using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_CTDT_CT_KhoiKienThuc : cDBase
    {
        public DataTable Get(KQHT_CTDT_CT_KhoiKienThucInfo pKQHT_CTDT_CT_KhoiKienThucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_CTDT_CT_KhoiKienThucID",SqlDbType.Int,pKQHT_CTDT_CT_KhoiKienThucInfo.KQHT_CTDT_CT_KhoiKienThucID));

            return RunProcedureGet("sp_KQHT_CTDT_CT_KhoiKienThuc_Get", colParam);            
        }

        public int Add(KQHT_CTDT_CT_KhoiKienThucInfo pKQHT_CTDT_CT_KhoiKienThucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_ChuongTrinhDaoTao",SqlDbType.Int,pKQHT_CTDT_CT_KhoiKienThucInfo.IDKQHT_ChuongTrinhDaoTao));
            colParam.Add(CreateParam("@IDKQHT_CT_KhoiKienThuc",SqlDbType.Int,pKQHT_CTDT_CT_KhoiKienThucInfo.IDKQHT_CT_KhoiKienThuc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_CTDT_CT_KhoiKienThuc_Add", colParam);
        }
        
        public void Update(KQHT_CTDT_CT_KhoiKienThucInfo pKQHT_CTDT_CT_KhoiKienThucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_ChuongTrinhDaoTao",SqlDbType.Int,pKQHT_CTDT_CT_KhoiKienThucInfo.IDKQHT_ChuongTrinhDaoTao));
            colParam.Add(CreateParam("@IDKQHT_CT_KhoiKienThuc",SqlDbType.Int,pKQHT_CTDT_CT_KhoiKienThucInfo.IDKQHT_CT_KhoiKienThuc));
            colParam.Add(CreateParam("@KQHT_CTDT_CT_KhoiKienThucID",SqlDbType.Int,pKQHT_CTDT_CT_KhoiKienThucInfo.KQHT_CTDT_CT_KhoiKienThucID));

            RunProcedure("sp_KQHT_CTDT_CT_KhoiKienThuc_Update", colParam);
        }
        
        public void Delete(KQHT_CTDT_CT_KhoiKienThucInfo pKQHT_CTDT_CT_KhoiKienThucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_CTDT_CT_KhoiKienThucID",SqlDbType.Int,pKQHT_CTDT_CT_KhoiKienThucInfo.KQHT_CTDT_CT_KhoiKienThucID));

            RunProcedure("sp_KQHT_CTDT_CT_KhoiKienThuc_Delete", colParam);
        }
    }
}
