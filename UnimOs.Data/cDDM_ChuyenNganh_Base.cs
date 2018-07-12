using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_ChuyenNganh : cDBase
    {
        public DataTable Get(DM_ChuyenNganhInfo pDM_ChuyenNganhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_ChuyenNganhID",SqlDbType.Int,pDM_ChuyenNganhInfo.DM_ChuyenNganhID));

            return RunProcedureGet("sp_DM_ChuyenNganh_Get", colParam);            
        }

        public int Add(DM_ChuyenNganhInfo pDM_ChuyenNganhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Nganh",SqlDbType.Int,pDM_ChuyenNganhInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@MaChuyenNganh",SqlDbType.NVarChar,pDM_ChuyenNganhInfo.MaChuyenNganh));
            colParam.Add(CreateParam("@TenChuyenNganh",SqlDbType.NVarChar,pDM_ChuyenNganhInfo.TenChuyenNganh));
            colParam.Add(CreateParam("@TenChuyenNganh_E",SqlDbType.NVarChar,pDM_ChuyenNganhInfo.TenChuyenNganh_E));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_ChuyenNganh_Add", colParam);
        }
        
        public void Update(DM_ChuyenNganhInfo pDM_ChuyenNganhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Nganh",SqlDbType.Int,pDM_ChuyenNganhInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@MaChuyenNganh",SqlDbType.NVarChar,pDM_ChuyenNganhInfo.MaChuyenNganh));
            colParam.Add(CreateParam("@TenChuyenNganh",SqlDbType.NVarChar,pDM_ChuyenNganhInfo.TenChuyenNganh));
            colParam.Add(CreateParam("@TenChuyenNganh_E",SqlDbType.NVarChar,pDM_ChuyenNganhInfo.TenChuyenNganh_E));
            colParam.Add(CreateParam("@DM_ChuyenNganhID",SqlDbType.Int,pDM_ChuyenNganhInfo.DM_ChuyenNganhID));

            RunProcedure("sp_DM_ChuyenNganh_Update", colParam);
        }
        
        public void Delete(DM_ChuyenNganhInfo pDM_ChuyenNganhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_ChuyenNganhID",SqlDbType.Int,pDM_ChuyenNganhInfo.DM_ChuyenNganhID));

            RunProcedure("sp_DM_ChuyenNganh_Delete", colParam);
        }
    }
}
