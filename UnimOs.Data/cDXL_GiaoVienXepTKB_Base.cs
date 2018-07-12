using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_GiaoVienXepTKB : cDBase
    {
        public DataTable Get(XL_GiaoVienXepTKBInfo pXL_GiaoVienXepTKBInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_GiaoVienXepTKB",SqlDbType.Int,pXL_GiaoVienXepTKBInfo.XL_GiaoVienXepTKB));

            return RunProcedureGet("sp_XL_GiaoVienXepTKB_Get", colParam);            
        }

        public int Add(XL_GiaoVienXepTKBInfo pXL_GiaoVienXepTKBInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDHT_User",SqlDbType.Int,pXL_GiaoVienXepTKBInfo.IDHT_User));
            colParam.Add(CreateParam("@IDDM_GiaoVien",SqlDbType.Int,pXL_GiaoVienXepTKBInfo.IDDM_GiaoVien));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_GiaoVienXepTKB_Add", colParam);
        }
        
        public void Update(XL_GiaoVienXepTKBInfo pXL_GiaoVienXepTKBInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDHT_User",SqlDbType.Int,pXL_GiaoVienXepTKBInfo.IDHT_User));
            colParam.Add(CreateParam("@IDDM_GiaoVien",SqlDbType.Int,pXL_GiaoVienXepTKBInfo.IDDM_GiaoVien));
            colParam.Add(CreateParam("@XL_GiaoVienXepTKB",SqlDbType.Int,pXL_GiaoVienXepTKBInfo.XL_GiaoVienXepTKB));

            RunProcedure("sp_XL_GiaoVienXepTKB_Update", colParam);
        }
        
        public void Delete(XL_GiaoVienXepTKBInfo pXL_GiaoVienXepTKBInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_GiaoVienXepTKB",SqlDbType.Int,pXL_GiaoVienXepTKBInfo.XL_GiaoVienXepTKB));

            RunProcedure("sp_XL_GiaoVienXepTKB_Delete", colParam);
        }
    }
}
