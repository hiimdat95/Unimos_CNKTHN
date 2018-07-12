using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_DiaDiem : cDBase
    {
        public DataTable Get(DM_DiaDiemInfo pDM_DiaDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_DiaDiemID",SqlDbType.Int,pDM_DiaDiemInfo.DM_DiaDiemID));

            return RunProcedureGet("sp_DM_DiaDiem_Get", colParam);            
        }

        public int Add(DM_DiaDiemInfo pDM_DiaDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaDiaDiem",SqlDbType.NVarChar,pDM_DiaDiemInfo.MaDiaDiem));
            colParam.Add(CreateParam("@TenDiaDiem",SqlDbType.NVarChar,pDM_DiaDiemInfo.TenDiaDiem));
            colParam.Add(CreateParam("@MoTa", SqlDbType.NVarChar, pDM_DiaDiemInfo.MoTa));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_DiaDiem_Add", colParam);
        }
        
        public void Update(DM_DiaDiemInfo pDM_DiaDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaDiaDiem",SqlDbType.NVarChar,pDM_DiaDiemInfo.MaDiaDiem));
            colParam.Add(CreateParam("@TenDiaDiem",SqlDbType.NVarChar,pDM_DiaDiemInfo.TenDiaDiem));
            colParam.Add(CreateParam("@MoTa", SqlDbType.NVarChar, pDM_DiaDiemInfo.MoTa));
            colParam.Add(CreateParam("@DM_DiaDiemID",SqlDbType.Int,pDM_DiaDiemInfo.DM_DiaDiemID));

            RunProcedure("sp_DM_DiaDiem_Update", colParam);
        }
        
        public void Delete(DM_DiaDiemInfo pDM_DiaDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_DiaDiemID",SqlDbType.Int,pDM_DiaDiemInfo.DM_DiaDiemID));

            RunProcedure("sp_DM_DiaDiem_Delete", colParam);
        }
    }
}
