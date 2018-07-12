using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_HanhVi : cDBase
    {
        public DataTable Get(DM_HanhViInfo pDM_HanhViInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_HanhViID",SqlDbType.Int,pDM_HanhViInfo.DM_HanhViID));

            return RunProcedureGet("sp_DM_HanhVi_Get", colParam);            
        }

        public int Add(DM_HanhViInfo pDM_HanhViInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaHanhVi",SqlDbType.NVarChar,pDM_HanhViInfo.MaHanhVi));
            colParam.Add(CreateParam("@TenHanhVi",SqlDbType.NVarChar,pDM_HanhViInfo.TenHanhVi));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_HanhVi_Add", colParam);
        }
        
        public void Update(DM_HanhViInfo pDM_HanhViInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaHanhVi",SqlDbType.NVarChar,pDM_HanhViInfo.MaHanhVi));
            colParam.Add(CreateParam("@TenHanhVi",SqlDbType.NVarChar,pDM_HanhViInfo.TenHanhVi));
            colParam.Add(CreateParam("@DM_HanhViID",SqlDbType.Int,pDM_HanhViInfo.DM_HanhViID));

            RunProcedure("sp_DM_HanhVi_Update", colParam);
        }
        
        public void Delete(DM_HanhViInfo pDM_HanhViInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_HanhViID",SqlDbType.Int,pDM_HanhViInfo.DM_HanhViID));

            RunProcedure("sp_DM_HanhVi_Delete", colParam);
        }
    }
}
