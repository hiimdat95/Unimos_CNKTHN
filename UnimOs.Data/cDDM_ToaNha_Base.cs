using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_ToaNha : cDBase
    {
        public DataTable Get(DM_ToaNhaInfo pDM_ToaNhaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_ToaNhaID",SqlDbType.Int,pDM_ToaNhaInfo.DM_ToaNhaID));

            return RunProcedureGet("sp_DM_ToaNha_Get", colParam);            
        }

        public int Add(DM_ToaNhaInfo pDM_ToaNhaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_DiaDiem",SqlDbType.Int,pDM_ToaNhaInfo.IDDM_DiaDiem));
            colParam.Add(CreateParam("@MaToaNha",SqlDbType.NVarChar,pDM_ToaNhaInfo.MaToaNha));
            colParam.Add(CreateParam("@TenToaNha",SqlDbType.NVarChar,pDM_ToaNhaInfo.TenToaNha));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_ToaNha_Add", colParam);
        }
        
        public void Update(DM_ToaNhaInfo pDM_ToaNhaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_DiaDiem",SqlDbType.Int,pDM_ToaNhaInfo.IDDM_DiaDiem));
            colParam.Add(CreateParam("@MaToaNha",SqlDbType.NVarChar,pDM_ToaNhaInfo.MaToaNha));
            colParam.Add(CreateParam("@TenToaNha",SqlDbType.NVarChar,pDM_ToaNhaInfo.TenToaNha));
            colParam.Add(CreateParam("@DM_ToaNhaID",SqlDbType.Int,pDM_ToaNhaInfo.DM_ToaNhaID));

            RunProcedure("sp_DM_ToaNha_Update", colParam);
        }
        
        public void Delete(DM_ToaNhaInfo pDM_ToaNhaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_ToaNhaID",SqlDbType.Int,pDM_ToaNhaInfo.DM_ToaNhaID));

            RunProcedure("sp_DM_ToaNha_Delete", colParam);
        }
    }
}
