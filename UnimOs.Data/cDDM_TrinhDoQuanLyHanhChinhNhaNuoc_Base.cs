using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_TrinhDoQuanLyHanhChinhNhaNuoc : cDBase
    {
        public DataTable Get(DM_TrinhDoQuanLyHanhChinhNhaNuocInfo pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_TrinhDoQuanLyHanhChinhNhaNuocID",SqlDbType.Int,pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.DM_TrinhDoQuanLyHanhChinhNhaNuocID));

            return RunProcedureGet("sp_DM_TrinhDoQuanLyHanhChinhNhaNuoc_Get", colParam);            
        }

        public int Add(DM_TrinhDoQuanLyHanhChinhNhaNuocInfo pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenTrinhDoQuanLyHanhChinhNhaNuoc",SqlDbType.NVarChar,pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.TenTrinhDoQuanLyHanhChinhNhaNuoc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_TrinhDoQuanLyHanhChinhNhaNuoc_Add", colParam);
        }
        
        public void Update(DM_TrinhDoQuanLyHanhChinhNhaNuocInfo pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenTrinhDoQuanLyHanhChinhNhaNuoc",SqlDbType.NVarChar,pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.TenTrinhDoQuanLyHanhChinhNhaNuoc));
            colParam.Add(CreateParam("@DM_TrinhDoQuanLyHanhChinhNhaNuocID",SqlDbType.Int,pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.DM_TrinhDoQuanLyHanhChinhNhaNuocID));

            RunProcedure("sp_DM_TrinhDoQuanLyHanhChinhNhaNuoc_Update", colParam);
        }
        
        public void Delete(DM_TrinhDoQuanLyHanhChinhNhaNuocInfo pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_TrinhDoQuanLyHanhChinhNhaNuocID",SqlDbType.Int,pDM_TrinhDoQuanLyHanhChinhNhaNuocInfo.DM_TrinhDoQuanLyHanhChinhNhaNuocID));

            RunProcedure("sp_DM_TrinhDoQuanLyHanhChinhNhaNuoc_Delete", colParam);
        }
    }
}
