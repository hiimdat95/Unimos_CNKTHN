using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_PhongHoc_MonHoc : cDBase
    {
        public DataTable Get(XL_PhongHoc_MonHocInfo pXL_PhongHoc_MonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_PhongHoc_MonHocID",SqlDbType.Int,pXL_PhongHoc_MonHocInfo.XL_PhongHoc_MonHocID));

            return RunProcedureGet("sp_XL_PhongHoc_MonHoc_Get", colParam);            
        }

        public int Add(XL_PhongHoc_MonHocInfo pXL_PhongHoc_MonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pXL_PhongHoc_MonHocInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_PhongHoc",SqlDbType.Int,pXL_PhongHoc_MonHocInfo.IDDM_PhongHoc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_PhongHoc_MonHoc_Add", colParam);
        }
        
        public void Update(XL_PhongHoc_MonHocInfo pXL_PhongHoc_MonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pXL_PhongHoc_MonHocInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_PhongHoc",SqlDbType.Int,pXL_PhongHoc_MonHocInfo.IDDM_PhongHoc));
            colParam.Add(CreateParam("@XL_PhongHoc_MonHocID",SqlDbType.Int,pXL_PhongHoc_MonHocInfo.XL_PhongHoc_MonHocID));

            RunProcedure("sp_XL_PhongHoc_MonHoc_Update", colParam);
        }
        
        public void Delete(XL_PhongHoc_MonHocInfo pXL_PhongHoc_MonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_PhongHoc_MonHocID",SqlDbType.Int,pXL_PhongHoc_MonHocInfo.XL_PhongHoc_MonHocID));

            RunProcedure("sp_XL_PhongHoc_MonHoc_Delete", colParam);
        }
    }
}
