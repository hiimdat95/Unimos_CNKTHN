using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_SuKienTKB : cDBase
    {
        public DataTable Get(XL_SuKienTKBInfo pXL_SuKienTKBInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_SuKienTKBID",SqlDbType.BigInt,pXL_SuKienTKBInfo.XL_SuKienTKBID));

            return RunProcedureGet("sp_XL_SuKienTKB_Get", colParam);            
        }

        public int Add(XL_SuKienTKBInfo pXL_SuKienTKBInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_Tuan",SqlDbType.BigInt,pXL_SuKienTKBInfo.IDXL_Tuan));
            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pXL_SuKienTKBInfo.IDDM_Lop));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, pXL_SuKienTKBInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pXL_SuKienTKBInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_PhongHoc",SqlDbType.Int,pXL_SuKienTKBInfo.IDDM_PhongHoc));
            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pXL_SuKienTKBInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@CaHoc",SqlDbType.Int,pXL_SuKienTKBInfo.CaHoc));
            colParam.Add(CreateParam("@Thu",SqlDbType.Int,pXL_SuKienTKBInfo.Thu));
            colParam.Add(CreateParam("@TietDau",SqlDbType.Int,pXL_SuKienTKBInfo.TietDau));
            colParam.Add(CreateParam("@SoTiet",SqlDbType.Int,pXL_SuKienTKBInfo.SoTiet));
            colParam.Add(CreateParam("@LoaiTiet",SqlDbType.Int,pXL_SuKienTKBInfo.LoaiTiet));
            colParam.Add(CreateParam("@DaXepLich",SqlDbType.Bit,pXL_SuKienTKBInfo.DaXepLich));
            colParam.Add(CreateParam("@Locked",SqlDbType.Bit,pXL_SuKienTKBInfo.Locked));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_SuKienTKB_Add", colParam);
        }
        
        public void Update(XL_SuKienTKBInfo pXL_SuKienTKBInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_Tuan",SqlDbType.BigInt,pXL_SuKienTKBInfo.IDXL_Tuan));
            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pXL_SuKienTKBInfo.IDDM_Lop));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, pXL_SuKienTKBInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pXL_SuKienTKBInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_PhongHoc",SqlDbType.Int,pXL_SuKienTKBInfo.IDDM_PhongHoc));
            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pXL_SuKienTKBInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@CaHoc",SqlDbType.Int,pXL_SuKienTKBInfo.CaHoc));
            colParam.Add(CreateParam("@Thu",SqlDbType.Int,pXL_SuKienTKBInfo.Thu));
            colParam.Add(CreateParam("@TietDau",SqlDbType.Int,pXL_SuKienTKBInfo.TietDau));
            colParam.Add(CreateParam("@SoTiet",SqlDbType.Int,pXL_SuKienTKBInfo.SoTiet));
            colParam.Add(CreateParam("@LoaiTiet",SqlDbType.Int,pXL_SuKienTKBInfo.LoaiTiet));
            colParam.Add(CreateParam("@DaXepLich",SqlDbType.Bit,pXL_SuKienTKBInfo.DaXepLich));
            colParam.Add(CreateParam("@Locked",SqlDbType.Bit,pXL_SuKienTKBInfo.Locked));
            colParam.Add(CreateParam("@XL_SuKienTKBID",SqlDbType.BigInt,pXL_SuKienTKBInfo.XL_SuKienTKBID));

            RunProcedure("sp_XL_SuKienTKB_Update", colParam);
        }
        
        public void Delete(XL_SuKienTKBInfo pXL_SuKienTKBInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_SuKienTKBID",SqlDbType.BigInt,pXL_SuKienTKBInfo.XL_SuKienTKBID));

            RunProcedure("sp_XL_SuKienTKB_Delete", colParam);
        }
    }
}
