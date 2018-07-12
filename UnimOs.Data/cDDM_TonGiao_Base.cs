using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_TonGiao : cDBase
    {
        public DataTable Get(DM_TonGiaoInfo pDM_TonGiaoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_TonGiaoID",SqlDbType.Int,pDM_TonGiaoInfo.DM_TonGiaoID));

            return RunProcedureGet("sp_DM_TonGiao_Get", colParam);            
        }

        public int Add(DM_TonGiaoInfo pDM_TonGiaoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaTonGiao",SqlDbType.NVarChar,pDM_TonGiaoInfo.MaTonGiao));
            colParam.Add(CreateParam("@TenTonGiao",SqlDbType.NVarChar,pDM_TonGiaoInfo.TenTonGiao));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_TonGiao_Add", colParam);
        }
        
        public void Update(DM_TonGiaoInfo pDM_TonGiaoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaTonGiao",SqlDbType.NVarChar,pDM_TonGiaoInfo.MaTonGiao));
            colParam.Add(CreateParam("@TenTonGiao",SqlDbType.NVarChar,pDM_TonGiaoInfo.TenTonGiao));
            colParam.Add(CreateParam("@DM_TonGiaoID",SqlDbType.Int,pDM_TonGiaoInfo.DM_TonGiaoID));

            RunProcedure("sp_DM_TonGiao_Update", colParam);
        }
        
        public void Delete(DM_TonGiaoInfo pDM_TonGiaoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_TonGiaoID",SqlDbType.Int,pDM_TonGiaoInfo.DM_TonGiaoID));

            RunProcedure("sp_DM_TonGiao_Delete", colParam);
        }
    }
}
