using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_KeHoachChiTiet : cDBase
    {
        public DataTable Get(XL_KeHoachChiTietInfo pXL_KeHoachChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_KeHoachChiTietID",SqlDbType.BigInt,pXL_KeHoachChiTietInfo.XL_KeHoachChiTietID));

            return RunProcedureGet("sp_XL_KeHoachChiTiet_Get", colParam);            
        }

        public int Add(XL_KeHoachChiTietInfo pXL_KeHoachChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_Tuan",SqlDbType.BigInt,pXL_KeHoachChiTietInfo.IDXL_Tuan));
            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pXL_KeHoachChiTietInfo.IDDM_Lop));
            colParam.Add(CreateParam("@IDXL_LopTachGop",SqlDbType.Int,pXL_KeHoachChiTietInfo.IDXL_LopTachGop));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy",SqlDbType.Int,pXL_KeHoachChiTietInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pXL_KeHoachChiTietInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pXL_KeHoachChiTietInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoTiet",SqlDbType.Int,pXL_KeHoachChiTietInfo.SoTiet));
            colParam.Add(CreateParam("@LoaiTiet",SqlDbType.Int,pXL_KeHoachChiTietInfo.LoaiTiet));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pXL_KeHoachChiTietInfo.GhiChu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_KeHoachChiTiet_Add", colParam);
        }
        
        public void Update(XL_KeHoachChiTietInfo pXL_KeHoachChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_Tuan",SqlDbType.BigInt,pXL_KeHoachChiTietInfo.IDXL_Tuan));
            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pXL_KeHoachChiTietInfo.IDDM_Lop));
            colParam.Add(CreateParam("@IDXL_LopTachGop",SqlDbType.Int,pXL_KeHoachChiTietInfo.IDXL_LopTachGop));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy",SqlDbType.Int,pXL_KeHoachChiTietInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pXL_KeHoachChiTietInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pXL_KeHoachChiTietInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoTiet",SqlDbType.Int,pXL_KeHoachChiTietInfo.SoTiet));
            colParam.Add(CreateParam("@LoaiTiet",SqlDbType.Int,pXL_KeHoachChiTietInfo.LoaiTiet));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pXL_KeHoachChiTietInfo.GhiChu));
            colParam.Add(CreateParam("@XL_KeHoachChiTietID",SqlDbType.BigInt,pXL_KeHoachChiTietInfo.XL_KeHoachChiTietID));

            RunProcedure("sp_XL_KeHoachChiTiet_Update", colParam);
        }
        
        public void Delete(XL_KeHoachChiTietInfo pXL_KeHoachChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_KeHoachChiTietID",SqlDbType.BigInt,pXL_KeHoachChiTietInfo.XL_KeHoachChiTietID));

            RunProcedure("sp_XL_KeHoachChiTiet_Delete", colParam);
        }
    }
}
