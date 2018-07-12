using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_PhanCongGiaoVien : cDBase
    {
        public DataTable Get(XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_PhanCongGiaoVienID",SqlDbType.Int,pXL_PhanCongGiaoVienInfo.XL_PhanCongGiaoVienID));

            return RunProcedureGet("sp_XL_PhanCongGiaoVien_Get", colParam);            
        }

        public int Add(XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_MonHocTrongKy",SqlDbType.Int,pXL_PhanCongGiaoVienInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pXL_PhanCongGiaoVienInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoTiet",SqlDbType.Int,pXL_PhanCongGiaoVienInfo.SoTiet));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_PhanCongGiaoVien_Add", colParam);
        }
        
        public void Update(XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_MonHocTrongKy",SqlDbType.Int,pXL_PhanCongGiaoVienInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pXL_PhanCongGiaoVienInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoTiet",SqlDbType.Int,pXL_PhanCongGiaoVienInfo.SoTiet));
            colParam.Add(CreateParam("@XL_PhanCongGiaoVienID",SqlDbType.Int,pXL_PhanCongGiaoVienInfo.XL_PhanCongGiaoVienID));

            RunProcedure("sp_XL_PhanCongGiaoVien_Update", colParam);
        }
        
        public void Delete(XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_PhanCongGiaoVienID",SqlDbType.Int,pXL_PhanCongGiaoVienInfo.XL_PhanCongGiaoVienID));

            RunProcedure("sp_XL_PhanCongGiaoVien_Delete", colParam);
        }
    }
}
