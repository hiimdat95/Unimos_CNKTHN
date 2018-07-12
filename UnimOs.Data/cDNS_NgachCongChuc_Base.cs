using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_NgachCongChuc : cDBase
    {
        public DataTable Get(NS_NgachCongChucInfo pNS_NgachCongChucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_NgachCongChucID",SqlDbType.Int,pNS_NgachCongChucInfo.NS_NgachCongChucID));

            return RunProcedureGet("sp_NS_NgachCongChuc_Get", colParam);            
        }

        public int Add(NS_NgachCongChucInfo pNS_NgachCongChucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaNgachCongChuc",SqlDbType.NVarChar,pNS_NgachCongChucInfo.MaNgachCongChuc));
            colParam.Add(CreateParam("@TenNgachCongChuc",SqlDbType.NVarChar,pNS_NgachCongChucInfo.TenNgachCongChuc));
            colParam.Add(CreateParam("@IDNS_NhomNgach",SqlDbType.Int,pNS_NgachCongChucInfo.IDNS_NhomNgach));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_NgachCongChuc_Add", colParam);
        }
        
        public void Update(NS_NgachCongChucInfo pNS_NgachCongChucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaNgachCongChuc",SqlDbType.NVarChar,pNS_NgachCongChucInfo.MaNgachCongChuc));
            colParam.Add(CreateParam("@TenNgachCongChuc",SqlDbType.NVarChar,pNS_NgachCongChucInfo.TenNgachCongChuc));
            colParam.Add(CreateParam("@IDNS_NhomNgach",SqlDbType.Int,pNS_NgachCongChucInfo.IDNS_NhomNgach));
            colParam.Add(CreateParam("@NS_NgachCongChucID",SqlDbType.Int,pNS_NgachCongChucInfo.NS_NgachCongChucID));

            RunProcedure("sp_NS_NgachCongChuc_Update", colParam);
        }
        
        public void Delete(NS_NgachCongChucInfo pNS_NgachCongChucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_NgachCongChucID",SqlDbType.Int,pNS_NgachCongChucInfo.NS_NgachCongChucID));

            RunProcedure("sp_NS_NgachCongChuc_Delete", colParam);
        }
    }
}
