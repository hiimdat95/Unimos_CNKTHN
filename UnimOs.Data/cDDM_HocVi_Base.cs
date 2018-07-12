using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_HocVi : cDBase
    {
        public DataTable Get(DM_HocViInfo pDM_HocViInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_HocViID",SqlDbType.Int,pDM_HocViInfo.DM_HocViID));

            return RunProcedureGet("sp_DM_HocVi_Get", colParam);            
        }

        public int Add(DM_HocViInfo pDM_HocViInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenHocVi",SqlDbType.NVarChar,pDM_HocViInfo.TenHocVi));
            colParam.Add(CreateParam("@IDDM_LoaiChuyenMon", SqlDbType.Int, pDM_HocViInfo.IDDM_LoaiChuyenMon));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_HocVi_Add", colParam);
        }
        
        public void Update(DM_HocViInfo pDM_HocViInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenHocVi",SqlDbType.NVarChar,pDM_HocViInfo.TenHocVi));
            colParam.Add(CreateParam("@IDDM_LoaiChuyenMon", SqlDbType.Int, pDM_HocViInfo.IDDM_LoaiChuyenMon));
            colParam.Add(CreateParam("@DM_HocViID",SqlDbType.Int,pDM_HocViInfo.DM_HocViID));

            RunProcedure("sp_DM_HocVi_Update", colParam);
        }
        
        public void Delete(DM_HocViInfo pDM_HocViInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_HocViID",SqlDbType.Int,pDM_HocViInfo.DM_HocViID));

            RunProcedure("sp_DM_HocVi_Delete", colParam);
        }
    }
}
