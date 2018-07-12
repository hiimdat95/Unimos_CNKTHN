using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_PhongHoc : cDBase
    {
        public DataTable Get(DM_PhongHocInfo pDM_PhongHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_PhongHocID",SqlDbType.Int,pDM_PhongHocInfo.DM_PhongHocID));

            return RunProcedureGet("sp_DM_PhongHoc_Get", colParam);            
        }

        public int Add(DM_PhongHocInfo pDM_PhongHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenPhongHoc",SqlDbType.NVarChar,pDM_PhongHocInfo.TenPhongHoc));
            colParam.Add(CreateParam("@IDDM_ToaNha",SqlDbType.Int,pDM_PhongHocInfo.IDDM_ToaNha));
            colParam.Add(CreateParam("@IDDM_Tang",SqlDbType.Int,pDM_PhongHocInfo.IDDM_Tang));
            colParam.Add(CreateParam("@SucChua",SqlDbType.Int,pDM_PhongHocInfo.SucChua));
            colParam.Add(CreateParam("@IDDM_LoaiPhong",SqlDbType.Int,pDM_PhongHocInfo.IDDM_LoaiPhong));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_PhongHoc_Add", colParam);
        }
        
        public void Update(DM_PhongHocInfo pDM_PhongHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenPhongHoc",SqlDbType.NVarChar,pDM_PhongHocInfo.TenPhongHoc));
            colParam.Add(CreateParam("@IDDM_ToaNha",SqlDbType.Int,pDM_PhongHocInfo.IDDM_ToaNha));
            colParam.Add(CreateParam("@IDDM_Tang",SqlDbType.Int,pDM_PhongHocInfo.IDDM_Tang));
            colParam.Add(CreateParam("@SucChua",SqlDbType.Int,pDM_PhongHocInfo.SucChua));
            colParam.Add(CreateParam("@IDDM_LoaiPhong",SqlDbType.Int,pDM_PhongHocInfo.IDDM_LoaiPhong));
            colParam.Add(CreateParam("@DM_PhongHocID",SqlDbType.Int,pDM_PhongHocInfo.DM_PhongHocID));

            RunProcedure("sp_DM_PhongHoc_Update", colParam);
        }
        
        public void Delete(DM_PhongHocInfo pDM_PhongHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_PhongHocID",SqlDbType.Int,pDM_PhongHocInfo.DM_PhongHocID));

            RunProcedure("sp_DM_PhongHoc_Delete", colParam);
        }
    }
}
