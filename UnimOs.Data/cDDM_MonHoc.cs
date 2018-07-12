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
        public DataTable GetDanhSach(int IDDM_BoMon)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_BoMon", SqlDbType.Int, IDDM_BoMon));

            return RunProcedureGet("sp_DM_MonHoc_GetDanhSach", colParam);
        }

        public DataTable GetPhongHoc_MonHoc(int SuDungPhong)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SuDungPhong", SqlDbType.Int, SuDungPhong));

            return RunProcedureGet("sp_DM_MonHoc_GetPhongHoc_MonHoc", colParam);
        }

        public DataTable GetPhongChuyenMon(string IDDM_PhongHocs)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_PhongHocs", SqlDbType.NVarChar, IDDM_PhongHocs));

            return RunProcedureGet("sp_DM_MonHoc_GetPhongChuyenMon", colParam);
        }

        public DataTable GetNotInIDCTKhoiKienThuc(int IDKQHT_CT_KhoiKienThuc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_CT_KhoiKienThuc", SqlDbType.Int, IDKQHT_CT_KhoiKienThuc));

            return RunProcedureGet("sp_DM_MonHoc_GetNotInIDCTKhoiKienThuc", colParam);
        }

        public DataTable GetNotInIDNSGiaoVien(int IDNS_GiaoVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));

            return RunProcedureGet("sp_DM_MonHoc_GetNotInIDGiaoVien", colParam);
        }

        public DataTable GetMonKyByLop(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_DM_MonHoc_GetMonKyByLop", colParam);
        }

        public DataTable GetMonThiTotNghiep(int IDDM_NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));

            return RunProcedureGet("sp_DM_MonHoc_GetMonThiTotNghiep", colParam);
        }

        public string CheckExistByMaMonHoc(string MaMonHocs, bool MaMon)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaMonHocs", SqlDbType.NVarChar, MaMonHocs));
            colParam.Add(CreateParam("@MaMon", SqlDbType.Bit, MaMon));
            colParam.Add(CreateParamOut("@ExistMaMonHocs", SqlDbType.NVarChar, 4000));

            return (string)RunProcedureOut("sp_DM_MonHoc_CheckExistByMaMonHoc", colParam, "ExistMaMonHocs");
        }

        public int AddByImport(DM_MonHocInfo pDM_MonHocInfo, ref string Error)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaMonHoc", SqlDbType.NVarChar, pDM_MonHocInfo.MaMonHoc));
            colParam.Add(CreateParam("@TenMonHoc", SqlDbType.NVarChar, pDM_MonHocInfo.TenMonHoc));
            colParam.Add(CreateParam("@TenVietTat", SqlDbType.NVarChar, pDM_MonHocInfo.TenVietTat));
            colParam.Add(CreateParam("@SoTiet", SqlDbType.Int, pDM_MonHocInfo.SoTiet));
            colParam.Add(CreateParam("@LyThuyet", SqlDbType.Int, pDM_MonHocInfo.LyThuyet));
            colParam.Add(CreateParam("@ThucHanh", SqlDbType.Int, pDM_MonHocInfo.ThucHanh));
            colParam.Add(CreateParam("@SoHocTrinh", SqlDbType.Real, pDM_MonHocInfo.SoHocTrinh));
            colParam.Add(CreateParam("@SuDungPhong", SqlDbType.Int, pDM_MonHocInfo.SuDungPhong));
            colParam.Add(CreateParamOut("@Error", SqlDbType.NVarChar, 400));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            object[] obj = RunProcedureOut("sp_DM_MonHoc_AddByImport", colParam, new string[] { "Error", "ID" });
            Error = obj[0].ToString();
            return int.Parse(obj[1].ToString());
        }
    }
}
