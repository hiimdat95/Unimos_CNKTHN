using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDHT_DongBo : cDBase
    {
        public DataTable Get(HT_DongBoInfo pHT_DongBoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_DongBoID",SqlDbType.BigInt,pHT_DongBoInfo.HT_DongBoID));

            return RunProcedureGet("sp_HT_DongBo_Get", colParam);            
        }

        public int Add(HT_DongBoInfo pHT_DongBoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenBang",SqlDbType.NVarChar,pHT_DongBoInfo.TenBang));
            colParam.Add(CreateParam("@IDThayDoi",SqlDbType.BigInt,pHT_DongBoInfo.IDThayDoi));
            colParam.Add(CreateParam("@ThaoTac",SqlDbType.NChar,pHT_DongBoInfo.ThaoTac));
            colParam.Add(CreateParam("@DaDongBo",SqlDbType.Bit,pHT_DongBoInfo.DaDongBo));
            colParam.Add(CreateParam("@CreatedTime",SqlDbType.DateTime,pHT_DongBoInfo.CreatedTime));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_HT_DongBo_Add", colParam);
        }
        
        public void Update(HT_DongBoInfo pHT_DongBoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenBang",SqlDbType.NVarChar,pHT_DongBoInfo.TenBang));
            colParam.Add(CreateParam("@IDThayDoi",SqlDbType.BigInt,pHT_DongBoInfo.IDThayDoi));
            colParam.Add(CreateParam("@ThaoTac",SqlDbType.NChar,pHT_DongBoInfo.ThaoTac));
            colParam.Add(CreateParam("@DaDongBo",SqlDbType.Bit,pHT_DongBoInfo.DaDongBo));
            colParam.Add(CreateParam("@CreatedTime",SqlDbType.DateTime,pHT_DongBoInfo.CreatedTime));
            colParam.Add(CreateParam("@HT_DongBoID",SqlDbType.BigInt,pHT_DongBoInfo.HT_DongBoID));

            RunProcedure("sp_HT_DongBo_Update", colParam);
        }
        
        public void Delete(HT_DongBoInfo pHT_DongBoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_DongBoID",SqlDbType.BigInt,pHT_DongBoInfo.HT_DongBoID));

            RunProcedure("sp_HT_DongBo_Delete", colParam);
        }
    }
}
