using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_LoaiQuy : cDBase
    {
        public DataTable Get(DM_LoaiQuyInfo pDM_LoaiQuyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_LoaiQuyID",SqlDbType.Int,pDM_LoaiQuyInfo.DM_LoaiQuyID));

            return RunProcedureGet("sp_DM_LoaiQuy_Get", colParam);            
        }

        public int Add(DM_LoaiQuyInfo pDM_LoaiQuyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenLoaiQuy",SqlDbType.NVarChar,pDM_LoaiQuyInfo.TenLoaiQuy));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pDM_LoaiQuyInfo.GhiChu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_LoaiQuy_Add", colParam);
        }
        
        public void Update(DM_LoaiQuyInfo pDM_LoaiQuyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenLoaiQuy",SqlDbType.NVarChar,pDM_LoaiQuyInfo.TenLoaiQuy));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pDM_LoaiQuyInfo.GhiChu));
            colParam.Add(CreateParam("@DM_LoaiQuyID",SqlDbType.Int,pDM_LoaiQuyInfo.DM_LoaiQuyID));

            RunProcedure("sp_DM_LoaiQuy_Update", colParam);
        }
        
        public void Delete(DM_LoaiQuyInfo pDM_LoaiQuyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_LoaiQuyID",SqlDbType.Int,pDM_LoaiQuyInfo.DM_LoaiQuyID));

            RunProcedure("sp_DM_LoaiQuy_Delete", colParam);
        }
    }
}
