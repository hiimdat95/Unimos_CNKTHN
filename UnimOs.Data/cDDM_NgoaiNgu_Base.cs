using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_NgoaiNgu : cDBase
    {
        public DataTable Get(DM_NgoaiNguInfo pDM_NgoaiNguInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_NgoaiNguID",SqlDbType.Int,pDM_NgoaiNguInfo.DM_NgoaiNguID));

            return RunProcedureGet("sp_DM_NgoaiNgu_Get", colParam);            
        }

        public int Add(DM_NgoaiNguInfo pDM_NgoaiNguInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenNgoaiNgu",SqlDbType.NVarChar,pDM_NgoaiNguInfo.TenNgoaiNgu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_NgoaiNgu_Add", colParam);
        }
        
        public void Update(DM_NgoaiNguInfo pDM_NgoaiNguInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenNgoaiNgu",SqlDbType.NVarChar,pDM_NgoaiNguInfo.TenNgoaiNgu));
            colParam.Add(CreateParam("@DM_NgoaiNguID",SqlDbType.Int,pDM_NgoaiNguInfo.DM_NgoaiNguID));

            RunProcedure("sp_DM_NgoaiNgu_Update", colParam);
        }
        
        public void Delete(DM_NgoaiNguInfo pDM_NgoaiNguInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_NgoaiNguID",SqlDbType.Int,pDM_NgoaiNguInfo.DM_NgoaiNguID));

            RunProcedure("sp_DM_NgoaiNgu_Delete", colParam);
        }
    }
}
