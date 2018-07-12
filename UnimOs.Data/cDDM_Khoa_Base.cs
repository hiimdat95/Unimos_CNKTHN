using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_Khoa : cDBase
    {
        public DataTable Get(DM_KhoaInfo pDM_KhoaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_KhoaID",SqlDbType.Int,pDM_KhoaInfo.DM_KhoaID));

            return RunProcedureGet("sp_DM_Khoa_Get", colParam);            
        }

        public int Add(DM_KhoaInfo pDM_KhoaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaKhoa",SqlDbType.NVarChar,pDM_KhoaInfo.MaKhoa));
            colParam.Add(CreateParam("@TenKhoa",SqlDbType.NVarChar,pDM_KhoaInfo.TenKhoa));
            colParam.Add(CreateParam("@TenKhoa_E",SqlDbType.NVarChar,pDM_KhoaInfo.TenKhoa_E));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_Khoa_Add", colParam);
        }
        
        public void Update(DM_KhoaInfo pDM_KhoaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaKhoa",SqlDbType.NVarChar,pDM_KhoaInfo.MaKhoa));
            colParam.Add(CreateParam("@TenKhoa",SqlDbType.NVarChar,pDM_KhoaInfo.TenKhoa));
            colParam.Add(CreateParam("@TenKhoa_E",SqlDbType.NVarChar,pDM_KhoaInfo.TenKhoa_E));
            colParam.Add(CreateParam("@DM_KhoaID",SqlDbType.Int,pDM_KhoaInfo.DM_KhoaID));

            RunProcedure("sp_DM_Khoa_Update", colParam);
        }
        
        public void Delete(DM_KhoaInfo pDM_KhoaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_KhoaID",SqlDbType.Int,pDM_KhoaInfo.DM_KhoaID));

            RunProcedure("sp_DM_Khoa_Delete", colParam);
        }
    }
}
