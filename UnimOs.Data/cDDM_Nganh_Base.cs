using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_Nganh : cDBase
    {
        public DataTable Get(DM_NganhInfo pDM_NganhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_NganhID",SqlDbType.Int,pDM_NganhInfo.DM_NganhID));

            return RunProcedureGet("sp_DM_Nganh_Get", colParam);            
        }

        public int Add(DM_NganhInfo pDM_NganhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Khoa",SqlDbType.Int,pDM_NganhInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@MaNganh",SqlDbType.NVarChar,pDM_NganhInfo.MaNganh));
            colParam.Add(CreateParam("@TenNganh",SqlDbType.NVarChar,pDM_NganhInfo.TenNganh));
            colParam.Add(CreateParam("@TenNganh_E",SqlDbType.NVarChar,pDM_NganhInfo.TenNganh_E));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_Nganh_Add", colParam);
        }
        
        public void Update(DM_NganhInfo pDM_NganhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Khoa",SqlDbType.Int,pDM_NganhInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@MaNganh",SqlDbType.NVarChar,pDM_NganhInfo.MaNganh));
            colParam.Add(CreateParam("@TenNganh",SqlDbType.NVarChar,pDM_NganhInfo.TenNganh));
            colParam.Add(CreateParam("@TenNganh_E",SqlDbType.NVarChar,pDM_NganhInfo.TenNganh_E));
            colParam.Add(CreateParam("@DM_NganhID",SqlDbType.Int,pDM_NganhInfo.DM_NganhID));

            RunProcedure("sp_DM_Nganh_Update", colParam);
        }
        
        public void Delete(DM_NganhInfo pDM_NganhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_NganhID",SqlDbType.Int,pDM_NganhInfo.DM_NganhID));

            RunProcedure("sp_DM_Nganh_Delete", colParam);
        }
    }
}
