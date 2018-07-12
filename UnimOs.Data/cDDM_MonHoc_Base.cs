using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_MonHoc : cDBase
    {
        public DataTable Get(DM_MonHocInfo pDM_MonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_MonHocID",SqlDbType.Int,pDM_MonHocInfo.DM_MonHocID));

            return RunProcedureGet("sp_DM_MonHoc_Get", colParam);
        }

        public int Add(DM_MonHocInfo pDM_MonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaMonHoc",SqlDbType.NVarChar,pDM_MonHocInfo.MaMonHoc));
            colParam.Add(CreateParam("@TenMonHoc",SqlDbType.NVarChar,pDM_MonHocInfo.TenMonHoc));
            colParam.Add(CreateParam("@TenMonHoc_E",SqlDbType.NVarChar,pDM_MonHocInfo.TenMonHoc_E));
            colParam.Add(CreateParam("@TenVietTat", SqlDbType.NVarChar, pDM_MonHocInfo.TenVietTat));
            colParam.Add(CreateParam("@SoTiet",SqlDbType.Int,pDM_MonHocInfo.SoTiet));
            colParam.Add(CreateParam("@LyThuyet",SqlDbType.Int,pDM_MonHocInfo.LyThuyet));
            colParam.Add(CreateParam("@ThucHanh",SqlDbType.Int,pDM_MonHocInfo.ThucHanh));
            colParam.Add(CreateParam("@LoaiTietKhac1",SqlDbType.Int,pDM_MonHocInfo.LoaiTietKhac1));
            colParam.Add(CreateParam("@LoaiTietKhac2",SqlDbType.Int,pDM_MonHocInfo.LoaiTietKhac2));
            colParam.Add(CreateParam("@SoHocTrinh",SqlDbType.Real,pDM_MonHocInfo.SoHocTrinh));
            colParam.Add(CreateParam("@ChoPhepXepLich",SqlDbType.Bit,pDM_MonHocInfo.ChoPhepXepLich));
            colParam.Add(CreateParam("@SuDungPhong",SqlDbType.Int,pDM_MonHocInfo.SuDungPhong));
            colParam.Add(CreateParam("@IDDM_TrinhDo",SqlDbType.Int,pDM_MonHocInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Nganh",SqlDbType.Int,pDM_MonHocInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_ChuyenNganh",SqlDbType.Int,pDM_MonHocInfo.IDDM_ChuyenNganh));
            colParam.Add(CreateParam("@IDDM_BoMon",SqlDbType.Int,pDM_MonHocInfo.IDDM_BoMon));
            colParam.Add(CreateParam("@IDDM_KhoiKienThuc",SqlDbType.Int,pDM_MonHocInfo.IDDM_KhoiKienThuc));
            colParam.Add(CreateParam("@IDDM_HinhThucThi",SqlDbType.Int,pDM_MonHocInfo.IDDM_HinhThucThi));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NText,pDM_MonHocInfo.MoTa));
            colParam.Add(CreateParam("@TinhDiemToanKhoa", SqlDbType.Bit, pDM_MonHocInfo.TinhDiemToanKhoa));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_MonHoc_Add", colParam);
        }
        
        public void Update(DM_MonHocInfo pDM_MonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaMonHoc",SqlDbType.NVarChar,pDM_MonHocInfo.MaMonHoc));
            colParam.Add(CreateParam("@TenMonHoc",SqlDbType.NVarChar,pDM_MonHocInfo.TenMonHoc));
            colParam.Add(CreateParam("@TenMonHoc_E",SqlDbType.NVarChar,pDM_MonHocInfo.TenMonHoc_E));
            colParam.Add(CreateParam("@TenVietTat", SqlDbType.NVarChar, pDM_MonHocInfo.TenVietTat));
            colParam.Add(CreateParam("@SoTiet",SqlDbType.Int,pDM_MonHocInfo.SoTiet));
            colParam.Add(CreateParam("@LyThuyet",SqlDbType.Int,pDM_MonHocInfo.LyThuyet));
            colParam.Add(CreateParam("@ThucHanh",SqlDbType.Int,pDM_MonHocInfo.ThucHanh));
            colParam.Add(CreateParam("@LoaiTietKhac1",SqlDbType.Int,pDM_MonHocInfo.LoaiTietKhac1));
            colParam.Add(CreateParam("@LoaiTietKhac2",SqlDbType.Int,pDM_MonHocInfo.LoaiTietKhac2));
            colParam.Add(CreateParam("@SoHocTrinh",SqlDbType.Real,pDM_MonHocInfo.SoHocTrinh));
            colParam.Add(CreateParam("@ChoPhepXepLich",SqlDbType.Bit,pDM_MonHocInfo.ChoPhepXepLich));
            colParam.Add(CreateParam("@SuDungPhong",SqlDbType.Int,pDM_MonHocInfo.SuDungPhong));
            colParam.Add(CreateParam("@IDDM_TrinhDo",SqlDbType.Int,pDM_MonHocInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Nganh",SqlDbType.Int,pDM_MonHocInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_ChuyenNganh",SqlDbType.Int,pDM_MonHocInfo.IDDM_ChuyenNganh));
            colParam.Add(CreateParam("@IDDM_BoMon",SqlDbType.Int,pDM_MonHocInfo.IDDM_BoMon));
            colParam.Add(CreateParam("@IDDM_KhoiKienThuc",SqlDbType.Int,pDM_MonHocInfo.IDDM_KhoiKienThuc));
            colParam.Add(CreateParam("@IDDM_HinhThucThi",SqlDbType.Int,pDM_MonHocInfo.IDDM_HinhThucThi));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NText,pDM_MonHocInfo.MoTa));
            colParam.Add(CreateParam("@TinhDiemToanKhoa", SqlDbType.Bit, pDM_MonHocInfo.TinhDiemToanKhoa));
            colParam.Add(CreateParam("@DM_MonHocID",SqlDbType.Int,pDM_MonHocInfo.DM_MonHocID));

            RunProcedure("sp_DM_MonHoc_Update", colParam);
        }
        
        public void Delete(DM_MonHocInfo pDM_MonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_MonHocID",SqlDbType.Int,pDM_MonHocInfo.DM_MonHocID));

            RunProcedure("sp_DM_MonHoc_Delete", colParam);
        }
    }
}
