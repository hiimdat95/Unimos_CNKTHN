using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_SoQuyetDinh : cDBase
    {
        public DataTable Get(NS_SoQuyetDinhInfo pNS_SoQuyetDinhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_SoQuyetDinhID",SqlDbType.Int,pNS_SoQuyetDinhInfo.NS_SoQuyetDinhID));

            return RunProcedureGet("sp_NS_SoQuyetDinh_Get", colParam);            
        }

        public int Add(NS_SoQuyetDinhInfo pNS_SoQuyetDinhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pNS_SoQuyetDinhInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayQuyetDinh",SqlDbType.DateTime,pNS_SoQuyetDinhInfo.NgayQuyetDinh));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_SoQuyetDinh_Add", colParam);
        }
        
        public void Update(NS_SoQuyetDinhInfo pNS_SoQuyetDinhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pNS_SoQuyetDinhInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayQuyetDinh",SqlDbType.DateTime,pNS_SoQuyetDinhInfo.NgayQuyetDinh));
            colParam.Add(CreateParam("@NS_SoQuyetDinhID",SqlDbType.Int,pNS_SoQuyetDinhInfo.NS_SoQuyetDinhID));

            RunProcedure("sp_NS_SoQuyetDinh_Update", colParam);
        }
        
        public void Delete(NS_SoQuyetDinhInfo pNS_SoQuyetDinhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_SoQuyetDinhID",SqlDbType.Int,pNS_SoQuyetDinhInfo.NS_SoQuyetDinhID));

            RunProcedure("sp_NS_SoQuyetDinh_Delete", colParam);
        }
    }
}
