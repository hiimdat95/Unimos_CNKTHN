using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_LuongCoBan : cDBase
    {
        public DataTable Get(NS_LuongCoBanInfo pNS_LuongCoBanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_LuongCoBanID",SqlDbType.Int,pNS_LuongCoBanInfo.NS_LuongCoBanID));

            return RunProcedureGet("sp_NS_LuongCoBan_Get", colParam);            
        }

        public int Add(NS_LuongCoBanInfo pNS_LuongCoBanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@LuongCoBan",SqlDbType.Money,pNS_LuongCoBanInfo.LuongCoBan));
            colParam.Add(CreateParam("@TuNgay",SqlDbType.DateTime,pNS_LuongCoBanInfo.TuNgay));
            colParam.Add(CreateParam("@DenNgay",SqlDbType.DateTime,pNS_LuongCoBanInfo.DenNgay));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_LuongCoBan_Add", colParam);
        }
        
        public void Update(NS_LuongCoBanInfo pNS_LuongCoBanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@LuongCoBan",SqlDbType.Money,pNS_LuongCoBanInfo.LuongCoBan));
            colParam.Add(CreateParam("@TuNgay",SqlDbType.DateTime,pNS_LuongCoBanInfo.TuNgay));
            colParam.Add(CreateParam("@DenNgay",SqlDbType.DateTime,pNS_LuongCoBanInfo.DenNgay));
            colParam.Add(CreateParam("@NS_LuongCoBanID",SqlDbType.Int,pNS_LuongCoBanInfo.NS_LuongCoBanID));

            RunProcedure("sp_NS_LuongCoBan_Update", colParam);
        }
        
        public void Delete(NS_LuongCoBanInfo pNS_LuongCoBanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_LuongCoBanID",SqlDbType.Int,pNS_LuongCoBanInfo.NS_LuongCoBanID));

            RunProcedure("sp_NS_LuongCoBan_Delete", colParam);
        }
    }
}
