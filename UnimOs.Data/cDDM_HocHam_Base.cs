using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_HocHam : cDBase
    {
        public DataTable Get(DM_HocHamInfo pDM_HocHamInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_HocHamID",SqlDbType.Int,pDM_HocHamInfo.DM_HocHamID));

            return RunProcedureGet("sp_DM_HocHam_Get", colParam);            
        }

        public int Add(DM_HocHamInfo pDM_HocHamInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenHocHam",SqlDbType.NVarChar,pDM_HocHamInfo.TenHocHam));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_HocHam_Add", colParam);
        }
        
        public void Update(DM_HocHamInfo pDM_HocHamInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenHocHam",SqlDbType.NVarChar,pDM_HocHamInfo.TenHocHam));
            colParam.Add(CreateParam("@DM_HocHamID",SqlDbType.Int,pDM_HocHamInfo.DM_HocHamID));

            RunProcedure("sp_DM_HocHam_Update", colParam);
        }
        
        public void Delete(DM_HocHamInfo pDM_HocHamInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_HocHamID",SqlDbType.Int,pDM_HocHamInfo.DM_HocHamID));

            RunProcedure("sp_DM_HocHam_Delete", colParam);
        }
    }
}
