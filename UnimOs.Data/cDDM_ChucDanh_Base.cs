using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_ChucDanh : cDBase
    {
        public DataTable Get(DM_ChucDanhInfo pDM_ChucDanhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_ChucDanhID",SqlDbType.Int,pDM_ChucDanhInfo.DM_ChucDanhID));

            return RunProcedureGet("sp_DM_ChucDanh_Get", colParam);            
        }

        public int Add(DM_ChucDanhInfo pDM_ChucDanhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenChucDanh",SqlDbType.NVarChar,pDM_ChucDanhInfo.TenChucDanh));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_ChucDanh_Add", colParam);
        }
        
        public void Update(DM_ChucDanhInfo pDM_ChucDanhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenChucDanh",SqlDbType.NVarChar,pDM_ChucDanhInfo.TenChucDanh));
            colParam.Add(CreateParam("@DM_ChucDanhID",SqlDbType.Int,pDM_ChucDanhInfo.DM_ChucDanhID));

            RunProcedure("sp_DM_ChucDanh_Update", colParam);
        }
        
        public void Delete(DM_ChucDanhInfo pDM_ChucDanhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_ChucDanhID",SqlDbType.Int,pDM_ChucDanhInfo.DM_ChucDanhID));

            RunProcedure("sp_DM_ChucDanh_Delete", colParam);
        }
    }
}
