using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_TrinhDoChuyenMon : cDBase
    {
        public DataTable Get(DM_TrinhDoChuyenMonInfo pDM_TrinhDoChuyenMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_TrinhDoChuyenMonID",SqlDbType.Int,pDM_TrinhDoChuyenMonInfo.DM_TrinhDoChuyenMonID));

            return RunProcedureGet("sp_DM_TrinhDoChuyenMon_Get", colParam);            
        }

        public int Add(DM_TrinhDoChuyenMonInfo pDM_TrinhDoChuyenMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenTrinhDoChuyenMon",SqlDbType.NVarChar,pDM_TrinhDoChuyenMonInfo.TenTrinhDoChuyenMon));
            colParam.Add(CreateParam("@ParentID", SqlDbType.Int, pDM_TrinhDoChuyenMonInfo.ParentID));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_TrinhDoChuyenMon_Add", colParam);
        }
        
        public void Update(DM_TrinhDoChuyenMonInfo pDM_TrinhDoChuyenMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenTrinhDoChuyenMon",SqlDbType.NVarChar,pDM_TrinhDoChuyenMonInfo.TenTrinhDoChuyenMon));
            colParam.Add(CreateParam("@ParentID", SqlDbType.Int, pDM_TrinhDoChuyenMonInfo.ParentID));
            colParam.Add(CreateParam("@DM_TrinhDoChuyenMonID",SqlDbType.Int,pDM_TrinhDoChuyenMonInfo.DM_TrinhDoChuyenMonID));

            RunProcedure("sp_DM_TrinhDoChuyenMon_Update", colParam);
        }
        
        public void Delete(DM_TrinhDoChuyenMonInfo pDM_TrinhDoChuyenMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_TrinhDoChuyenMonID",SqlDbType.Int,pDM_TrinhDoChuyenMonInfo.DM_TrinhDoChuyenMonID));

            RunProcedure("sp_DM_TrinhDoChuyenMon_Delete", colParam);
        }
    }
}
