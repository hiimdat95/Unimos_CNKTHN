using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_VanBangChungChi : cDBase
    {
        public DataTable Get(DM_VanBangChungChiInfo pDM_VanBangChungChiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_VanBangChungChiID",SqlDbType.Int,pDM_VanBangChungChiInfo.DM_VanBangChungChiID));

            return RunProcedureGet("sp_DM_VanBangChungChi_Get", colParam);            
        }

        public int Add(DM_VanBangChungChiInfo pDM_VanBangChungChiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Ten",SqlDbType.NVarChar,pDM_VanBangChungChiInfo.Ten));
            colParam.Add(CreateParam("@VanBang",SqlDbType.Bit,pDM_VanBangChungChiInfo.VanBang));
            colParam.Add(CreateParam("@ChungChi",SqlDbType.Bit,pDM_VanBangChungChiInfo.ChungChi));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_VanBangChungChi_Add", colParam);
        }
        
        public void Update(DM_VanBangChungChiInfo pDM_VanBangChungChiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Ten",SqlDbType.NVarChar,pDM_VanBangChungChiInfo.Ten));
            colParam.Add(CreateParam("@VanBang",SqlDbType.Bit,pDM_VanBangChungChiInfo.VanBang));
            colParam.Add(CreateParam("@ChungChi",SqlDbType.Bit,pDM_VanBangChungChiInfo.ChungChi));
            colParam.Add(CreateParam("@DM_VanBangChungChiID",SqlDbType.Int,pDM_VanBangChungChiInfo.DM_VanBangChungChiID));

            RunProcedure("sp_DM_VanBangChungChi_Update", colParam);
        }
        
        public void Delete(DM_VanBangChungChiInfo pDM_VanBangChungChiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_VanBangChungChiID",SqlDbType.Int,pDM_VanBangChungChiInfo.DM_VanBangChungChiID));

            RunProcedure("sp_DM_VanBangChungChi_Delete", colParam);
        }
    }
}
