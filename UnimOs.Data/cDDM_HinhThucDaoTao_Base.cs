using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_HinhThucDaoTao : cDBase
    {
        public DataTable Get(DM_HinhThucDaoTaoInfo pDM_HinhThucDaoTaoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_HinhThucDaoTaoID",SqlDbType.Int,pDM_HinhThucDaoTaoInfo.DM_HinhThucDaoTaoID));

            return RunProcedureGet("sp_DM_HinhThucDaoTao_Get", colParam);            
        }

        public int Add(DM_HinhThucDaoTaoInfo pDM_HinhThucDaoTaoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenHinhThucDaoTao",SqlDbType.NVarChar,pDM_HinhThucDaoTaoInfo.TenHinhThucDaoTao));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_HinhThucDaoTao_Add", colParam);
        }
        
        public void Update(DM_HinhThucDaoTaoInfo pDM_HinhThucDaoTaoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenHinhThucDaoTao",SqlDbType.NVarChar,pDM_HinhThucDaoTaoInfo.TenHinhThucDaoTao));
            colParam.Add(CreateParam("@DM_HinhThucDaoTaoID",SqlDbType.Int,pDM_HinhThucDaoTaoInfo.DM_HinhThucDaoTaoID));

            RunProcedure("sp_DM_HinhThucDaoTao_Update", colParam);
        }
        
        public void Delete(DM_HinhThucDaoTaoInfo pDM_HinhThucDaoTaoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_HinhThucDaoTaoID",SqlDbType.Int,pDM_HinhThucDaoTaoInfo.DM_HinhThucDaoTaoID));

            RunProcedure("sp_DM_HinhThucDaoTao_Delete", colParam);
        }
    }
}
