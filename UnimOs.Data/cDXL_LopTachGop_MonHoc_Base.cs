using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_LopTachGop_MonHoc : cDBase
    {
        public DataTable Get(XL_LopTachGop_MonHocInfo pXL_LopTachGop_MonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_LopTachGop_MonHocID",SqlDbType.Int,pXL_LopTachGop_MonHocInfo.XL_LopTachGop_MonHocID));

            return RunProcedureGet("sp_XL_LopTachGop_MonHoc_Get", colParam);            
        }

        public int Add(XL_LopTachGop_MonHocInfo pXL_LopTachGop_MonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_LopTachGop",SqlDbType.Int,pXL_LopTachGop_MonHocInfo.IDXL_LopTachGop));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy",SqlDbType.Int,pXL_LopTachGop_MonHocInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pXL_LopTachGop_MonHocInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDDM_PhongHoc",SqlDbType.Int,pXL_LopTachGop_MonHocInfo.IDDM_PhongHoc));
            colParam.Add(CreateParam("@CaHoc",SqlDbType.Int,pXL_LopTachGop_MonHocInfo.CaHoc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_LopTachGop_MonHoc_Add", colParam);
        }
        
        public void Update(XL_LopTachGop_MonHocInfo pXL_LopTachGop_MonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_LopTachGop",SqlDbType.Int,pXL_LopTachGop_MonHocInfo.IDXL_LopTachGop));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy",SqlDbType.Int,pXL_LopTachGop_MonHocInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pXL_LopTachGop_MonHocInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDDM_PhongHoc",SqlDbType.Int,pXL_LopTachGop_MonHocInfo.IDDM_PhongHoc));
            colParam.Add(CreateParam("@CaHoc",SqlDbType.Int,pXL_LopTachGop_MonHocInfo.CaHoc));
            colParam.Add(CreateParam("@XL_LopTachGop_MonHocID",SqlDbType.Int,pXL_LopTachGop_MonHocInfo.XL_LopTachGop_MonHocID));

            RunProcedure("sp_XL_LopTachGop_MonHoc_Update", colParam);
        }
        
        public void Delete(XL_LopTachGop_MonHocInfo pXL_LopTachGop_MonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_LopTachGop_MonHocID",SqlDbType.Int,pXL_LopTachGop_MonHocInfo.XL_LopTachGop_MonHocID));

            RunProcedure("sp_XL_LopTachGop_MonHoc_Delete", colParam);
        }
    }
}
