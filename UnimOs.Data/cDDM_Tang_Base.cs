using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_Tang : cDBase
    {
        public DataTable Get(DM_TangInfo pDM_TangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_TangID",SqlDbType.Int,pDM_TangInfo.DM_TangID));

            return RunProcedureGet("sp_DM_Tang_Get", colParam);            
        }

        public int Add(DM_TangInfo pDM_TangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenTang",SqlDbType.NVarChar,pDM_TangInfo.TenTang));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_Tang_Add", colParam);
        }
        
        public void Update(DM_TangInfo pDM_TangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenTang",SqlDbType.NVarChar,pDM_TangInfo.TenTang));
            colParam.Add(CreateParam("@DM_TangID",SqlDbType.Int,pDM_TangInfo.DM_TangID));

            RunProcedure("sp_DM_Tang_Update", colParam);
        }
        
        public void Delete(DM_TangInfo pDM_TangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_TangID",SqlDbType.Int,pDM_TangInfo.DM_TangID));

            RunProcedure("sp_DM_Tang_Delete", colParam);
        }
    }
}
