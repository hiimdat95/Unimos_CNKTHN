using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_KhoaHoc : cDBase
    {
        public DataTable Get(DM_KhoaHocInfo pDM_KhoaHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_KhoaHocID",SqlDbType.Int,pDM_KhoaHocInfo.DM_KhoaHocID));

            return RunProcedureGet("sp_DM_KhoaHoc_Get", colParam);            
        }

        public int Add(DM_KhoaHocInfo pDM_KhoaHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenKhoaHoc",SqlDbType.NVarChar,pDM_KhoaHocInfo.TenKhoaHoc));
            colParam.Add(CreateParam("@IDDM_TrinhDo",SqlDbType.Int,pDM_KhoaHocInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Nganh",SqlDbType.Int,pDM_KhoaHocInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_ChuyenNganh",SqlDbType.Int,pDM_KhoaHocInfo.IDDM_ChuyenNganh));
            colParam.Add(CreateParam("@NamVaoTruong",SqlDbType.Int,pDM_KhoaHocInfo.NamVaoTruong));
            colParam.Add(CreateParam("@NamRaTruong",SqlDbType.Int,pDM_KhoaHocInfo.NamRaTruong));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_KhoaHoc_Add", colParam);
        }
        
        public void Update(DM_KhoaHocInfo pDM_KhoaHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenKhoaHoc",SqlDbType.NVarChar,pDM_KhoaHocInfo.TenKhoaHoc));
            colParam.Add(CreateParam("@IDDM_TrinhDo",SqlDbType.Int,pDM_KhoaHocInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Nganh",SqlDbType.Int,pDM_KhoaHocInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_ChuyenNganh",SqlDbType.Int,pDM_KhoaHocInfo.IDDM_ChuyenNganh));
            colParam.Add(CreateParam("@NamVaoTruong",SqlDbType.Int,pDM_KhoaHocInfo.NamVaoTruong));
            colParam.Add(CreateParam("@NamRaTruong",SqlDbType.Int,pDM_KhoaHocInfo.NamRaTruong));
            colParam.Add(CreateParam("@DM_KhoaHocID",SqlDbType.Int,pDM_KhoaHocInfo.DM_KhoaHocID));

            RunProcedure("sp_DM_KhoaHoc_Update", colParam);
        }
        
        public void Delete(DM_KhoaHocInfo pDM_KhoaHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_KhoaHocID",SqlDbType.Int,pDM_KhoaHocInfo.DM_KhoaHocID));

            RunProcedure("sp_DM_KhoaHoc_Delete", colParam);
        }
    }
}
