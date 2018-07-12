using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_DanhHieuDuocPhongTang : cDBase
    {
        public DataTable Get(DM_DanhHieuDuocPhongTangInfo pDM_DanhHieuDuocPhongTangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_DanhHieuDuocPhongTangID",SqlDbType.Int,pDM_DanhHieuDuocPhongTangInfo.DM_DanhHieuDuocPhongTangID));

            return RunProcedureGet("sp_DM_DanhHieuDuocPhongTang_Get", colParam);            
        }

        public int Add(DM_DanhHieuDuocPhongTangInfo pDM_DanhHieuDuocPhongTangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenDanhHieuDuocPhongTang",SqlDbType.NVarChar,pDM_DanhHieuDuocPhongTangInfo.TenDanhHieuDuocPhongTang));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_DanhHieuDuocPhongTang_Add", colParam);
        }
        
        public void Update(DM_DanhHieuDuocPhongTangInfo pDM_DanhHieuDuocPhongTangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenDanhHieuDuocPhongTang",SqlDbType.NVarChar,pDM_DanhHieuDuocPhongTangInfo.TenDanhHieuDuocPhongTang));
            colParam.Add(CreateParam("@DM_DanhHieuDuocPhongTangID",SqlDbType.Int,pDM_DanhHieuDuocPhongTangInfo.DM_DanhHieuDuocPhongTangID));

            RunProcedure("sp_DM_DanhHieuDuocPhongTang_Update", colParam);
        }
        
        public void Delete(DM_DanhHieuDuocPhongTangInfo pDM_DanhHieuDuocPhongTangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_DanhHieuDuocPhongTangID",SqlDbType.Int,pDM_DanhHieuDuocPhongTangInfo.DM_DanhHieuDuocPhongTangID));

            RunProcedure("sp_DM_DanhHieuDuocPhongTang_Delete", colParam);
        }
    }
}
