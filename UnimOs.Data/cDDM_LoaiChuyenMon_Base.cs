using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_LoaiChuyenMon : cDBase
    {
        public DataTable Get(DM_LoaiChuyenMonInfo pDM_LoaiChuyenMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_LoaiChuyenMonID",SqlDbType.Int,pDM_LoaiChuyenMonInfo.DM_LoaiChuyenMonID));

            return RunProcedureGet("sp_DM_LoaiChuyenMon_Get", colParam);            
        }

        public int Add(DM_LoaiChuyenMonInfo pDM_LoaiChuyenMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaLoaiChuyenMon",SqlDbType.NVarChar,pDM_LoaiChuyenMonInfo.MaLoaiChuyenMon));
            colParam.Add(CreateParam("@TenLoaiChuyenMon",SqlDbType.NVarChar,pDM_LoaiChuyenMonInfo.TenLoaiChuyenMon));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_LoaiChuyenMon_Add", colParam);
        }
        
        public void Update(DM_LoaiChuyenMonInfo pDM_LoaiChuyenMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaLoaiChuyenMon",SqlDbType.NVarChar,pDM_LoaiChuyenMonInfo.MaLoaiChuyenMon));
            colParam.Add(CreateParam("@TenLoaiChuyenMon",SqlDbType.NVarChar,pDM_LoaiChuyenMonInfo.TenLoaiChuyenMon));
            colParam.Add(CreateParam("@DM_LoaiChuyenMonID",SqlDbType.Int,pDM_LoaiChuyenMonInfo.DM_LoaiChuyenMonID));

            RunProcedure("sp_DM_LoaiChuyenMon_Update", colParam);
        }
        
        public void Delete(DM_LoaiChuyenMonInfo pDM_LoaiChuyenMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_LoaiChuyenMonID",SqlDbType.Int,pDM_LoaiChuyenMonInfo.DM_LoaiChuyenMonID));

            RunProcedure("sp_DM_LoaiChuyenMon_Delete", colParam);
        }
    }
}
