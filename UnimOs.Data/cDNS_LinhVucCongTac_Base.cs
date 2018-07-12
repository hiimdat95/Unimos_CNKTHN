using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_LinhVucCongTac : cDBase
    {
        public DataTable Get(NS_LinhVucCongTacInfo pNS_LinhVucCongTacInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_LinhVucCongTacID",SqlDbType.Int,pNS_LinhVucCongTacInfo.NS_LinhVucCongTacID));

            return RunProcedureGet("sp_NS_LinhVucCongTac_Get", colParam);            
        }

        public int Add(NS_LinhVucCongTacInfo pNS_LinhVucCongTacInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@STT",SqlDbType.Int,pNS_LinhVucCongTacInfo.STT));
            colParam.Add(CreateParam("@TenLinhVuc",SqlDbType.NVarChar,pNS_LinhVucCongTacInfo.TenLinhVuc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_LinhVucCongTac_Add", colParam);
        }
        
        public void Update(NS_LinhVucCongTacInfo pNS_LinhVucCongTacInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@STT",SqlDbType.Int,pNS_LinhVucCongTacInfo.STT));
            colParam.Add(CreateParam("@TenLinhVuc",SqlDbType.NVarChar,pNS_LinhVucCongTacInfo.TenLinhVuc));
            colParam.Add(CreateParam("@NS_LinhVucCongTacID",SqlDbType.Int,pNS_LinhVucCongTacInfo.NS_LinhVucCongTacID));

            RunProcedure("sp_NS_LinhVucCongTac_Update", colParam);
        }
        
        public void Delete(NS_LinhVucCongTacInfo pNS_LinhVucCongTacInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_LinhVucCongTacID",SqlDbType.Int,pNS_LinhVucCongTacInfo.NS_LinhVucCongTacID));

            RunProcedure("sp_NS_LinhVucCongTac_Delete", colParam);
        }
    }
}
