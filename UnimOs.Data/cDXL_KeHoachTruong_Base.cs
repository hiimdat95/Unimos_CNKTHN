using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_KeHoachTruong : cDBase
    {
        public DataTable Get(XL_KeHoachTruongInfo pXL_KeHoachTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_KeHoachTruongID",SqlDbType.Int,pXL_KeHoachTruongInfo.XL_KeHoachTruongID));

            return RunProcedureGet("sp_XL_KeHoachTruong_Get", colParam);            
        }

        public int Add(XL_KeHoachTruongInfo pXL_KeHoachTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_Tuan",SqlDbType.BigInt,pXL_KeHoachTruongInfo.IDXL_Tuan));
            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pXL_KeHoachTruongInfo.IDDM_Lop));
            colParam.Add(CreateParam("@IDXL_LopTachGop",SqlDbType.Int,pXL_KeHoachTruongInfo.IDXL_LopTachGop));
            colParam.Add(CreateParam("@CaHoc",SqlDbType.Int,pXL_KeHoachTruongInfo.CaHoc));
            colParam.Add(CreateParam("@IDDM_PhongHoc",SqlDbType.Int,pXL_KeHoachTruongInfo.IDDM_PhongHoc));
            colParam.Add(CreateParam("@IDXL_KeHoachKhac",SqlDbType.Int,pXL_KeHoachTruongInfo.IDXL_KeHoachKhac));
            colParam.Add(CreateParam("@NgayNghi",SqlDbType.NVarChar,pXL_KeHoachTruongInfo.NgayNghi));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_KeHoachTruong_Add", colParam);
        }
        
        public void Update(XL_KeHoachTruongInfo pXL_KeHoachTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_Tuan",SqlDbType.BigInt,pXL_KeHoachTruongInfo.IDXL_Tuan));
            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pXL_KeHoachTruongInfo.IDDM_Lop));
            colParam.Add(CreateParam("@IDXL_LopTachGop",SqlDbType.Int,pXL_KeHoachTruongInfo.IDXL_LopTachGop));
            colParam.Add(CreateParam("@CaHoc",SqlDbType.Int,pXL_KeHoachTruongInfo.CaHoc));
            colParam.Add(CreateParam("@IDDM_PhongHoc",SqlDbType.Int,pXL_KeHoachTruongInfo.IDDM_PhongHoc));
            colParam.Add(CreateParam("@IDXL_KeHoachKhac",SqlDbType.Int,pXL_KeHoachTruongInfo.IDXL_KeHoachKhac));
            colParam.Add(CreateParam("@NgayNghi",SqlDbType.NVarChar,pXL_KeHoachTruongInfo.NgayNghi));
            colParam.Add(CreateParam("@XL_KeHoachTruongID",SqlDbType.Int,pXL_KeHoachTruongInfo.XL_KeHoachTruongID));

            RunProcedure("sp_XL_KeHoachTruong_Update", colParam);
        }
        
        public void Delete(XL_KeHoachTruongInfo pXL_KeHoachTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_KeHoachTruongID",SqlDbType.Int,pXL_KeHoachTruongInfo.XL_KeHoachTruongID));

            RunProcedure("sp_XL_KeHoachTruong_Delete", colParam);
        }
    }
}
