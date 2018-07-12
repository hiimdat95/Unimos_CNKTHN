using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_QuocTich : cDBase
    {
        public DataTable Get(DM_QuocTichInfo pDM_QuocTichInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_QuocTichID",SqlDbType.Int,pDM_QuocTichInfo.DM_QuocTichID));

            return RunProcedureGet("sp_DM_QuocTich_Get", colParam);            
        }

        public int Add(DM_QuocTichInfo pDM_QuocTichInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaNuoc",SqlDbType.NVarChar,pDM_QuocTichInfo.MaNuoc));
            colParam.Add(CreateParam("@TenNuoc",SqlDbType.NVarChar,pDM_QuocTichInfo.TenNuoc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_QuocTich_Add", colParam);
        }
        
        public void Update(DM_QuocTichInfo pDM_QuocTichInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaNuoc",SqlDbType.NVarChar,pDM_QuocTichInfo.MaNuoc));
            colParam.Add(CreateParam("@TenNuoc",SqlDbType.NVarChar,pDM_QuocTichInfo.TenNuoc));
            colParam.Add(CreateParam("@DM_QuocTichID",SqlDbType.Int,pDM_QuocTichInfo.DM_QuocTichID));

            RunProcedure("sp_DM_QuocTich_Update", colParam);
        }
        
        public void Delete(DM_QuocTichInfo pDM_QuocTichInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_QuocTichID",SqlDbType.Int,pDM_QuocTichInfo.DM_QuocTichID));

            RunProcedure("sp_DM_QuocTich_Delete", colParam);
        }
    }
}
