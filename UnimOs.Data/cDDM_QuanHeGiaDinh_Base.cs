using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_QuanHeGiaDinh : cDBase
    {
        public DataTable Get(DM_QuanHeGiaDinhInfo pDM_QuanHeGiaDinhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_QuanHeGiaDinhID",SqlDbType.Int,pDM_QuanHeGiaDinhInfo.DM_QuanHeGiaDinhID));

            return RunProcedureGet("sp_DM_QuanHeGiaDinh_Get", colParam);            
        }

        public int Add(DM_QuanHeGiaDinhInfo pDM_QuanHeGiaDinhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenMoiQuanHe",SqlDbType.NVarChar,pDM_QuanHeGiaDinhInfo.TenMoiQuanHe));
            colParam.Add(CreateParam("@Bo",SqlDbType.Bit,pDM_QuanHeGiaDinhInfo.Bo));
            colParam.Add(CreateParam("@Me",SqlDbType.Bit,pDM_QuanHeGiaDinhInfo.Me));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_QuanHeGiaDinh_Add", colParam);
        }
        
        public void Update(DM_QuanHeGiaDinhInfo pDM_QuanHeGiaDinhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenMoiQuanHe",SqlDbType.NVarChar,pDM_QuanHeGiaDinhInfo.TenMoiQuanHe));
            colParam.Add(CreateParam("@Bo",SqlDbType.Bit,pDM_QuanHeGiaDinhInfo.Bo));
            colParam.Add(CreateParam("@Me",SqlDbType.Bit,pDM_QuanHeGiaDinhInfo.Me));
            colParam.Add(CreateParam("@DM_QuanHeGiaDinhID",SqlDbType.Int,pDM_QuanHeGiaDinhInfo.DM_QuanHeGiaDinhID));

            RunProcedure("sp_DM_QuanHeGiaDinh_Update", colParam);
        }
        
        public void Delete(DM_QuanHeGiaDinhInfo pDM_QuanHeGiaDinhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_QuanHeGiaDinhID",SqlDbType.Int,pDM_QuanHeGiaDinhInfo.DM_QuanHeGiaDinhID));

            RunProcedure("sp_DM_QuanHeGiaDinh_Delete", colParam);
        }
    }
}
