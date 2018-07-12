using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_He : cDBase
    {
        public DataTable Get(DM_HeInfo pDM_HeInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_HeID",SqlDbType.Int,pDM_HeInfo.DM_HeID));

            return RunProcedureGet("sp_DM_He_Get", colParam);            
        }

        public int Add(DM_HeInfo pDM_HeInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaHe",SqlDbType.NVarChar,pDM_HeInfo.MaHe));
            colParam.Add(CreateParam("@TenHe",SqlDbType.NVarChar,pDM_HeInfo.TenHe));
            colParam.Add(CreateParam("@TenHe_E",SqlDbType.NVarChar,pDM_HeInfo.TenHe_E));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_He_Add", colParam);
        }
        
        public void Update(DM_HeInfo pDM_HeInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaHe",SqlDbType.NVarChar,pDM_HeInfo.MaHe));
            colParam.Add(CreateParam("@TenHe",SqlDbType.NVarChar,pDM_HeInfo.TenHe));
            colParam.Add(CreateParam("@TenHe_E",SqlDbType.NVarChar,pDM_HeInfo.TenHe_E));
            colParam.Add(CreateParam("@DM_HeID",SqlDbType.Int,pDM_HeInfo.DM_HeID));

            RunProcedure("sp_DM_He_Update", colParam);
        }
        
        public void Delete(DM_HeInfo pDM_HeInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_HeID",SqlDbType.Int,pDM_HeInfo.DM_HeID));

            RunProcedure("sp_DM_He_Delete", colParam);
        }
    }
}
