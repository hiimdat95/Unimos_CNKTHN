using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_PhongHocXepTKB : cDBase
    {
        public DataTable Get(XL_PhongHocXepTKBInfo pXL_PhongHocXepTKBInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_PhongHocXepTKBID",SqlDbType.Int,pXL_PhongHocXepTKBInfo.XL_PhongHocXepTKBID));

            return RunProcedureGet("sp_XL_PhongHocXepTKB_Get", colParam);            
        }

        public int Add(XL_PhongHocXepTKBInfo pXL_PhongHocXepTKBInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDHT_User",SqlDbType.Int,pXL_PhongHocXepTKBInfo.IDHT_User));
            colParam.Add(CreateParam("@IDDM_PhongHoc",SqlDbType.Int,pXL_PhongHocXepTKBInfo.IDDM_PhongHoc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_PhongHocXepTKB_Add", colParam);
        }
        
        public void Update(XL_PhongHocXepTKBInfo pXL_PhongHocXepTKBInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDHT_User",SqlDbType.Int,pXL_PhongHocXepTKBInfo.IDHT_User));
            colParam.Add(CreateParam("@IDDM_PhongHoc",SqlDbType.Int,pXL_PhongHocXepTKBInfo.IDDM_PhongHoc));
            colParam.Add(CreateParam("@XL_PhongHocXepTKBID",SqlDbType.Int,pXL_PhongHocXepTKBInfo.XL_PhongHocXepTKBID));

            RunProcedure("sp_XL_PhongHocXepTKB_Update", colParam);
        }
        
        public void Delete(XL_PhongHocXepTKBInfo pXL_PhongHocXepTKBInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_PhongHocXepTKBID",SqlDbType.Int,pXL_PhongHocXepTKBInfo.XL_PhongHocXepTKBID));

            RunProcedure("sp_XL_PhongHocXepTKB_Delete", colParam);
        }
    }
}
