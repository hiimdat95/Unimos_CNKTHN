using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_NamHoc : cDBase
    {
        public DataTable Get(DM_NamHocInfo pDM_NamHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_NamHocID",SqlDbType.Int,pDM_NamHocInfo.DM_NamHocID));

            return RunProcedureGet("sp_DM_NamHoc_Get", colParam);            
        }

        public int Add(DM_NamHocInfo pDM_NamHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenNamHoc",SqlDbType.NVarChar,pDM_NamHocInfo.TenNamHoc));
            colParam.Add(CreateParam("@TuNgay",SqlDbType.DateTime,pDM_NamHocInfo.TuNgay));
            colParam.Add(CreateParam("@DenNgay",SqlDbType.DateTime,pDM_NamHocInfo.DenNgay));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_NamHoc_Add", colParam);
        }
        
        public void Update(DM_NamHocInfo pDM_NamHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenNamHoc",SqlDbType.NVarChar,pDM_NamHocInfo.TenNamHoc));
            colParam.Add(CreateParam("@TuNgay",SqlDbType.DateTime,pDM_NamHocInfo.TuNgay));
            colParam.Add(CreateParam("@DenNgay",SqlDbType.DateTime,pDM_NamHocInfo.DenNgay));
            colParam.Add(CreateParam("@DM_NamHocID",SqlDbType.Int,pDM_NamHocInfo.DM_NamHocID));

            RunProcedure("sp_DM_NamHoc_Update", colParam);
        }
        
        public void Delete(DM_NamHocInfo pDM_NamHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_NamHocID",SqlDbType.Int,pDM_NamHocInfo.DM_NamHocID));

            RunProcedure("sp_DM_NamHoc_Delete", colParam);
        }
    }
}
