using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_DanhSachHocBong : cDBase
    {
        public DataTable GetDanhSachSinhVien(int IDDM_Lop, int IDDM_NamHoc, int HocKy, int Thang)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@Thang", SqlDbType.Int, Thang));

            return RunProcedureGet("sp_TC_DanhSachHocBong_GetDanhSachSinhVien", colParam);
        }

        public DataTable GetDanhSachLop(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int HocKy, int Thang, string NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@Thang", SqlDbType.Int, Thang));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar,20, NamHoc));

            return RunProcedureGet("sp_TC_DanhSachHocBong_GetDanhSachLop", colParam);
        }

        public DataTable GetInSinhVien(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_TC_DanhSachHocBong_GetInSinhVien", colParam);
        }

        public DataTable GetNotInSinhVien(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int HocKy, string NamHoc, string RenLuyenIDs, double DiemTBC)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar, 20, NamHoc));
            colParam.Add(CreateParam("@RenLuyenIDs", SqlDbType.NVarChar, 500, RenLuyenIDs));
            colParam.Add(CreateParam("@DiemTBC", SqlDbType.Float, DiemTBC));

            return RunProcedureGet("sp_TC_DanhSachHocBong_GetNotInSinhVien", colParam);
        }

        public DataTable GetThangInSinhVien(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int HocKy, string NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar, 20, NamHoc));

            return RunProcedureGet("sp_TC_DanhSachHocBong_GetThangInSinhVien", colParam);
        }

        public DataTable GetInSinhVienByKyTruoc(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int HocKy, string NamHoc, int Thang)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_DiaDiem", SqlDbType.Int, pDM_LopInfo.IDDM_DiaDiem));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar, 20, NamHoc));
            colParam.Add(CreateParam("@Thang", SqlDbType.Int, Thang));

            return RunProcedureGet("sp_TC_DanhSachHocBong_GetInSinhVienByKyTruoc", colParam);
        }

        public void DeleteInIDs(string IDTC_DanhSachHocBongs)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTC_DanhSachHocBongs", SqlDbType.NVarChar, IDTC_DanhSachHocBongs));

            RunProcedure("sp_TC_DanhSachHocBong_DeleteInIDs", colParam);
        }
    }
}
