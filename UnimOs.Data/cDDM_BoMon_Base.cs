using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_BoMon : cDBase
    {
        public DataTable Get(DM_BoMonInfo pDM_BoMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_BoMonID",SqlDbType.Int,pDM_BoMonInfo.DM_BoMonID));

            return RunProcedureGet("sp_DM_BoMon_Get", colParam);            
        }

        public int Add(DM_BoMonInfo pDM_BoMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Khoa",SqlDbType.Int,pDM_BoMonInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@MaBoMon",SqlDbType.NVarChar,pDM_BoMonInfo.MaBoMon));
            colParam.Add(CreateParam("@TenBoMon",SqlDbType.NVarChar,pDM_BoMonInfo.TenBoMon));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_BoMon_Add", colParam);
        }
        
        public void Update(DM_BoMonInfo pDM_BoMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Khoa",SqlDbType.Int,pDM_BoMonInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@MaBoMon",SqlDbType.NVarChar,pDM_BoMonInfo.MaBoMon));
            colParam.Add(CreateParam("@TenBoMon",SqlDbType.NVarChar,pDM_BoMonInfo.TenBoMon));
            colParam.Add(CreateParam("@DM_BoMonID",SqlDbType.Int,pDM_BoMonInfo.DM_BoMonID));

            RunProcedure("sp_DM_BoMon_Update", colParam);
        }
        
        public void Delete(DM_BoMonInfo pDM_BoMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_BoMonID",SqlDbType.Int,pDM_BoMonInfo.DM_BoMonID));

            RunProcedure("sp_DM_BoMon_Delete", colParam);
        }
    }
}
