using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_QuanHam : cDBase
    {
        public DataTable Get(DM_QuanHamInfo pDM_QuanHamInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_QuanHamID",SqlDbType.Int,pDM_QuanHamInfo.DM_QuanHamID));

            return RunProcedureGet("sp_DM_QuanHam_Get", colParam);            
        }

        public int Add(DM_QuanHamInfo pDM_QuanHamInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenQuanHam",SqlDbType.NVarChar,pDM_QuanHamInfo.TenQuanHam));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_QuanHam_Add", colParam);
        }
        
        public void Update(DM_QuanHamInfo pDM_QuanHamInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenQuanHam",SqlDbType.NVarChar,pDM_QuanHamInfo.TenQuanHam));
            colParam.Add(CreateParam("@DM_QuanHamID",SqlDbType.Int,pDM_QuanHamInfo.DM_QuanHamID));

            RunProcedure("sp_DM_QuanHam_Update", colParam);
        }
        
        public void Delete(DM_QuanHamInfo pDM_QuanHamInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_QuanHamID",SqlDbType.Int,pDM_QuanHamInfo.DM_QuanHamID));

            RunProcedure("sp_DM_QuanHam_Delete", colParam);
        }
    }
}
