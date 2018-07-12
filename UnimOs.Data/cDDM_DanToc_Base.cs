using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_DanToc : cDBase
    {
        public DataTable Get(DM_DanTocInfo pDM_DanTocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_DanTocID",SqlDbType.Int,pDM_DanTocInfo.DM_DanTocID));

            return RunProcedureGet("sp_DM_DanToc_Get", colParam);            
        }

        public int Add(DM_DanTocInfo pDM_DanTocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaDanToc",SqlDbType.NVarChar,pDM_DanTocInfo.MaDanToc));
            colParam.Add(CreateParam("@TenDanToc",SqlDbType.NVarChar,pDM_DanTocInfo.TenDanToc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_DanToc_Add", colParam);
        }
        
        public void Update(DM_DanTocInfo pDM_DanTocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaDanToc",SqlDbType.NVarChar,pDM_DanTocInfo.MaDanToc));
            colParam.Add(CreateParam("@TenDanToc",SqlDbType.NVarChar,pDM_DanTocInfo.TenDanToc));
            colParam.Add(CreateParam("@DM_DanTocID",SqlDbType.Int,pDM_DanTocInfo.DM_DanTocID));

            RunProcedure("sp_DM_DanToc_Update", colParam);
        }
        
        public void Delete(DM_DanTocInfo pDM_DanTocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_DanTocID",SqlDbType.Int,pDM_DanTocInfo.DM_DanTocID));

            RunProcedure("sp_DM_DanToc_Delete", colParam);
        }
    }
}
