using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_DinhMucThuSinhVien : cDBase
    {
        public DataTable GetBy_SinhVien(int IDSV_SinhVien, int IDDM_NamHoc, int HocKy, int PhieuThu, int Type, int IDSV_SinhVienNhapTruong)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@PhieuThu", SqlDbType.Int, PhieuThu));
            colParam.Add(CreateParam("@Type", SqlDbType.Int, Type));
            colParam.Add(CreateParam("@IDSV_SinhVienNhapTruong", SqlDbType.Int, IDSV_SinhVienNhapTruong));

            return RunProcedureGet("sp_TC_DinhMucThuSinhVien_GetBy_SinhVien", colParam);
        }

        public DataTable GetBySinhVien(int IDSV_SinhVien, int IDDM_NamHoc, int HocKy, int IDTC_LoaiThuChi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@IDTC_LoaiThuChi", SqlDbType.Int, IDTC_LoaiThuChi));

            return RunProcedureGet("sp_TC_DinhMucThuSinhVien_GetBySinhVien", colParam);
        }

        public DataTable GetChuaNopBy_SinhVien(int IDSV_SinhVien, int IDDM_NamHoc, int HocKy, int IDTC_LoaiThuChi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@IDTC_LoaiThuChi", SqlDbType.Int, IDTC_LoaiThuChi));

            return RunProcedureGet("sp_TC_DinhMucThuSinhVien_GetChuaNopBy_SinhVien", colParam);
        }

        public DataTable GetInSinhVien(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int HocKy, int IDTC_LoaiThuChi)
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
            colParam.Add(CreateParam("@IDTC_LoaiThuChi", SqlDbType.Int, IDTC_LoaiThuChi));

            return RunProcedureGet("sp_TC_DinhMucThuSinhVien_GetInSinhVien", colParam);
        }

        public DataTable GetNotInSinhVien(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int HocKy, string NamHoc, int IDTC_LoaiThuChi)
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
            colParam.Add(CreateParam("@IDTC_LoaiThuChi", SqlDbType.Int, IDTC_LoaiThuChi));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar,20, NamHoc));

            return RunProcedureGet("sp_TC_DinhMucThuSinhVien_GetNotInSinhVien", colParam);
        }

        public DataTable GetByKyTruoc(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int HocKy, string NamHoc, int IDTC_LoaiThuChi)
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
            colParam.Add(CreateParam("@IDTC_LoaiThuChi", SqlDbType.Int, IDTC_LoaiThuChi));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar, 20, NamHoc));

            return RunProcedureGet("sp_TC_DinhMucThuSinhVien_GetByKyTruoc", colParam);
        }
    }
}
