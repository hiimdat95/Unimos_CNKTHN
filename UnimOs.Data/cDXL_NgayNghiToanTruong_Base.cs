using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_NgayNghiToanTruong : cDBase
    {
        public DataTable Get(XL_NgayNghiToanTruongInfo pXL_NgayNghiToanTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_NgayNghiToanTruongID",SqlDbType.Int,pXL_NgayNghiToanTruongInfo.XL_NgayNghiToanTruongID));

            return RunProcedureGet("sp_XL_NgayNghiToanTruong_Get", colParam);            
        }

        public int Add(XL_NgayNghiToanTruongInfo pXL_NgayNghiToanTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_KeHaochKhac",SqlDbType.Int,pXL_NgayNghiToanTruongInfo.IDXL_KeHaochKhac));
            colParam.Add(CreateParam("@IDXL_Tuan",SqlDbType.BigInt,pXL_NgayNghiToanTruongInfo.IDXL_Tuan));
            colParam.Add(CreateParam("@NgayNghi",SqlDbType.NVarChar,pXL_NgayNghiToanTruongInfo.NgayNghi));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pXL_NgayNghiToanTruongInfo.GhiChu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_NgayNghiToanTruong_Add", colParam);
        }
        
        public void Update(XL_NgayNghiToanTruongInfo pXL_NgayNghiToanTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_KeHaochKhac",SqlDbType.Int,pXL_NgayNghiToanTruongInfo.IDXL_KeHaochKhac));
            colParam.Add(CreateParam("@IDXL_Tuan",SqlDbType.BigInt,pXL_NgayNghiToanTruongInfo.IDXL_Tuan));
            colParam.Add(CreateParam("@NgayNghi",SqlDbType.NVarChar,pXL_NgayNghiToanTruongInfo.NgayNghi));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pXL_NgayNghiToanTruongInfo.GhiChu));
            colParam.Add(CreateParam("@XL_NgayNghiToanTruongID",SqlDbType.Int,pXL_NgayNghiToanTruongInfo.XL_NgayNghiToanTruongID));

            RunProcedure("sp_XL_NgayNghiToanTruong_Update", colParam);
        }
        
        public void Delete(XL_NgayNghiToanTruongInfo pXL_NgayNghiToanTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_NgayNghiToanTruongID",SqlDbType.Int,pXL_NgayNghiToanTruongInfo.XL_NgayNghiToanTruongID));

            RunProcedure("sp_XL_NgayNghiToanTruong_Delete", colParam);
        }
    }
}
