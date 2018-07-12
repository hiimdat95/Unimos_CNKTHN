using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_XepLoaiChungChi : cDBase
    {
        public DataTable Get(DM_XepLoaiChungChiInfo pDM_XepLoaiChungChiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_XepLoaiChungChiID",SqlDbType.Int,pDM_XepLoaiChungChiInfo.DM_XepLoaiChungChiID));

            return RunProcedureGet("sp_DM_XepLoaiChungChi_Get", colParam);            
        }

        public int Add(DM_XepLoaiChungChiInfo pDM_XepLoaiChungChiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenXepLoaiChungChi",SqlDbType.NVarChar,pDM_XepLoaiChungChiInfo.TenXepLoaiChungChi));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_XepLoaiChungChi_Add", colParam);
        }
        
        public void Update(DM_XepLoaiChungChiInfo pDM_XepLoaiChungChiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenXepLoaiChungChi",SqlDbType.NVarChar,pDM_XepLoaiChungChiInfo.TenXepLoaiChungChi));
            colParam.Add(CreateParam("@DM_XepLoaiChungChiID",SqlDbType.Int,pDM_XepLoaiChungChiInfo.DM_XepLoaiChungChiID));

            RunProcedure("sp_DM_XepLoaiChungChi_Update", colParam);
        }
        
        public void Delete(DM_XepLoaiChungChiInfo pDM_XepLoaiChungChiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_XepLoaiChungChiID",SqlDbType.Int,pDM_XepLoaiChungChiInfo.DM_XepLoaiChungChiID));

            RunProcedure("sp_DM_XepLoaiChungChi_Delete", colParam);
        }
    }
}
