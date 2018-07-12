using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_GiaoVien_MonHoc : cDBase
    {
        public DataTable Get(XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_GiaoVien_MonHocID",SqlDbType.Int,pXL_GiaoVien_MonHocInfo.XL_GiaoVien_MonHocID));

            return RunProcedureGet("sp_XL_GiaoVien_MonHoc_Get", colParam);            
        }

        public int Add(XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pXL_GiaoVien_MonHocInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pXL_GiaoVien_MonHocInfo.IDDM_MonHoc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_GiaoVien_MonHoc_Add", colParam);
        }
        
        public void Update(XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pXL_GiaoVien_MonHocInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pXL_GiaoVien_MonHocInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@XL_GiaoVien_MonHocID",SqlDbType.Int,pXL_GiaoVien_MonHocInfo.XL_GiaoVien_MonHocID));

            RunProcedure("sp_XL_GiaoVien_MonHoc_Update", colParam);
        }
        
        public void Delete(XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_GiaoVien_MonHocID",SqlDbType.Int,pXL_GiaoVien_MonHocInfo.XL_GiaoVien_MonHocID));

            RunProcedure("sp_XL_GiaoVien_MonHoc_Delete", colParam);
        }
    }
}
