using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_CTDT_Lop : cDBase
    {
        public DataTable Get(KQHT_CTDT_LopInfo pKQHT_CTDT_LopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_CTDT_LopID",SqlDbType.Int,pKQHT_CTDT_LopInfo.KQHT_CTDT_LopID));

            return RunProcedureGet("sp_KQHT_CTDT_Lop_Get", colParam);            
        }

        public int Add(KQHT_CTDT_LopInfo pKQHT_CTDT_LopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pKQHT_CTDT_LopInfo.IDDM_Lop));
            colParam.Add(CreateParam("@IDKQHT_ChuongTrinhDaoTao",SqlDbType.Int,pKQHT_CTDT_LopInfo.IDKQHT_ChuongTrinhDaoTao));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_CTDT_Lop_Add", colParam);
        }
        
        public void Update(KQHT_CTDT_LopInfo pKQHT_CTDT_LopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pKQHT_CTDT_LopInfo.IDDM_Lop));
            colParam.Add(CreateParam("@IDKQHT_ChuongTrinhDaoTao",SqlDbType.Int,pKQHT_CTDT_LopInfo.IDKQHT_ChuongTrinhDaoTao));
            colParam.Add(CreateParam("@KQHT_CTDT_LopID",SqlDbType.Int,pKQHT_CTDT_LopInfo.KQHT_CTDT_LopID));

            RunProcedure("sp_KQHT_CTDT_Lop_Update", colParam);
        }
        
        public void Delete(KQHT_CTDT_LopInfo pKQHT_CTDT_LopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_CTDT_LopID",SqlDbType.Int,pKQHT_CTDT_LopInfo.KQHT_CTDT_LopID));

            RunProcedure("sp_KQHT_CTDT_Lop_Delete", colParam);
        }
    }
}
