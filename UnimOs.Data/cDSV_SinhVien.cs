using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_SinhVien : cDBase
    {
        public DataTable GetByLop(int IDDM_Lop, int TrangThai)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@TrangThai", SqlDbType.Int, TrangThai));

            return RunProcedureGet("sp_SV_SinhVien_GetByLop", colParam);
        }

        public string GetNextMaSinhVien(int IDDM_Lop, string MaSinhVien, ref int DoDaiTuTang)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@MaSinhVien", SqlDbType.NVarChar, MaSinhVien));
            colParam.Add(CreateParamOut("@MaSinhVienNew", SqlDbType.NVarChar, 50));
            colParam.Add(CreateParamOut("@DoDaiTuTang", SqlDbType.Int));

            object[] obj = RunProcedureOut("sp_SV_SinhVien_GetNextMaSinhVien", colParam, new string[] { "MaSinhVienNew", "DoDaiTuTang" });
            if (obj.Length > 0)
            {
                DoDaiTuTang = (int)obj[1];
                return (string)obj[0];
            }
            return "";
        }

        public DataTable GetHoSo(int SV_SinhVienID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_SinhVienID", SqlDbType.Int, SV_SinhVienID));

            return RunProcedureGet("sp_SV_SinhVien_GetHoSo", colParam);
        }

        public DataTable GetDanhSachDuThi(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi, string DaDangKy, int TotNghiep)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));
            colParam.Add(CreateParam("@TotNghiep", SqlDbType.Int, TotNghiep));
            colParam.Add(CreateParam("@DaDangKy", SqlDbType.NVarChar, DaDangKy));

            return RunProcedureGet("sp_SV_SinhVien_GetDanhSachDuThi", colParam);
        }

        public DataTable GetDanhSachThiLai(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi, string DaDangKy, int TotNghiep)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));
            colParam.Add(CreateParam("@DaDangKy", SqlDbType.NVarChar, DaDangKy));
            colParam.Add(CreateParam("@TotNghiep", SqlDbType.Int, TotNghiep));

            return RunProcedureGet("sp_SV_SinhVien_GetDanhSachThiLai", colParam);
        }

        public DataTable GetDanhSachDuThiKhoaTruoc(int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi, string DaDangKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));
            colParam.Add(CreateParam("@DaDangKy", SqlDbType.NVarChar, DaDangKy));

            return RunProcedureGet("sp_SV_SinhVien_GetDanhSachDuThiKhoaTruoc", colParam);
        }

        public DataTable GetByLop_Mon(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int IDKQHT_HoiDongMon)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@IDKQHT_HoiDongMon", SqlDbType.Int, IDKQHT_HoiDongMon));

            return RunProcedureGet("sp_SV_SinhVien_GetByLop_Mon", colParam);
        }

        public DataTable GetDaTotNghiep(DM_LopInfo pDM_LopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));

            return RunProcedureGet("sp_SV_SinhVien_GetDaTotNghiep", colParam);
        }

        public DataTable GetSinhVien_XetLenLop(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar, NamHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));

            return RunProcedureGet("sp_SV_SinhVien_GetSinhVien_XetLenLop", colParam);
        }

        public DataSet GetDSXetHocBong(DM_LopInfo pDM_LopInfo, string NamHoc, int HocKy, int IDDM_NamHoc, double DiemRenLuyen, double DiemTBC)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar, NamHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@DiemRenLuyen", SqlDbType.Float, 500, DiemRenLuyen));
            colParam.Add(CreateParam("@DiemTBC", SqlDbType.Float, DiemTBC));

            return RunProcedureGetDataSet("sp_SV_SinhVien_GetDSXetHocBong", colParam);
        }

        public DataTable GetSinhVien_XetThiTotNghiep(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc, double PTDVHTNo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));
            colParam.Add(CreateParam("@PTDVHTNo", SqlDbType.Float, PTDVHTNo));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar, NamHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));

            return RunProcedureGet("sp_SV_SinhVien_GetSinhVien_XetThiTotNghiep", colParam);
        }

        public DataTable GetDanhSachXetThiTotNghiep(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar, NamHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));

            return RunProcedureGet("sp_SV_SinhVien_GetDanhSachXetThiTotNghiep", colParam);
        }

        public DataTable GetDanhSachDuThiTotNghiep(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar, NamHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));

            return RunProcedureGet("sp_SV_SinhVien_GetDanhSachDuThiTotNghiep", colParam);
        }

        public DataTable GetDanhSachDuThiTotNghiep_ToChucThi(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc, string DaDangKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar, NamHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@DaDangKy", SqlDbType.NVarChar, DaDangKy));

            return RunProcedureGet("sp_SV_SinhVien_GetDanhSachDuThiTotNghiep_ToChucThi", colParam);
        }

        public DataTable GetDanhSach_ToChucThi(DM_LopInfo pDM_LopInfo, string NamHoc, string DaDangKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar, NamHoc));
            colParam.Add(CreateParam("@DaDangKy", SqlDbType.NVarChar, DaDangKy));

            return RunProcedureGet("sp_SV_SinhVien_GetDanhSach_ToChucThi", colParam);
        }

        public DataTable GetThiSinhTuDo(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc, string DaDangKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar, NamHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@DaDangKy", SqlDbType.NVarChar, DaDangKy));

            return RunProcedureGet("sp_SV_SinhVien_GetThiSinhTuDo", colParam);
        }

        public DataTable GetDanhSachKhongDuThiTotNghiep(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar, NamHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));

            return RunProcedureGet("sp_SV_SinhVien_GetDanhSachKhongDuThiTotNghiep", colParam);
        }

        public DataTable GetTongHop_KhongThiTotNghiep(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc, double PTDVHTNo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));
            colParam.Add(CreateParam("@PTDVHTNo", SqlDbType.Float, PTDVHTNo));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar, NamHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));

            return RunProcedureGet("sp_SV_SinhVien_GetTongHop_KhongThiTotNghiep", colParam);
        }

        public DataTable KiemTraMaSV(string MaSinhVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaSinhVien", SqlDbType.NVarChar, MaSinhVien));

            return RunProcedureGet("sp_SV_SinhVien_KiemTraMaSV", colParam);
        }

        public DataTable TimKiem(SV_SinhVienInfo pSV_SinhVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaSinhVien", SqlDbType.NVarChar, pSV_SinhVienInfo.MaSinhVien));
            colParam.Add(CreateParam("@HoTen", SqlDbType.NVarChar, pSV_SinhVienInfo.HoVaTen));

            return RunProcedureGet("sp_SV_SinhVien_TimKiem", colParam);
        }

        public DataTable GetSinhVien(DM_LopInfo pDM_LopInfo, string NamHoc, bool ChuaTaoMa)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar, NamHoc));
            colParam.Add(CreateParam("@ChuaTaoMa", SqlDbType.Bit, ChuaTaoMa));

            return RunProcedureGet("sp_SV_SinhVien_GetSinhVien", colParam);
        }

        public DataTable GetSinhVienLapTaiKhoan(DM_LopInfo pDM_LopInfo, string NamHoc, string HoVaTen, string MaSinhVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar, NamHoc));
            colParam.Add(CreateParam("@HoVaTen", SqlDbType.NVarChar, HoVaTen));
            colParam.Add(CreateParam("@MaSinhVien", SqlDbType.NVarChar, MaSinhVien));

            return RunProcedureGet("sp_SV_SinhVien_GetSinhVienLapTaiKhoan", colParam);
        }

        public DataTable GetMaLonNhat(int DoDaiMa, string PhanDauMa, string PhanCuoiMa)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DoDaiMa", SqlDbType.Int, DoDaiMa));
            colParam.Add(CreateParam("@PhanDauMa", SqlDbType.NVarChar, PhanDauMa));
            colParam.Add(CreateParam("@PhanCuoiMa", SqlDbType.NVarChar, PhanCuoiMa));

            return RunProcedureGet("sp_SV_SinhVien_GetMaLonNhat", colParam);
        }

        public string CheckExistByMaSinhVien(string MaSinhViens)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaSinhViens", SqlDbType.NVarChar, MaSinhViens));
            colParam.Add(CreateParamOut("@ExistMaSinhViens", SqlDbType.NVarChar, 3000));

            return (string)RunProcedureOut("sp_SV_SinhVien_CheckExistByMaSinhVien", colParam, "ExistMaSinhViens");
        }

        public string CheckExistAndGetInfo(string MaSinhViens, ref string HoVaTens, ref string TenLops)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaSinhViens", SqlDbType.NVarChar, MaSinhViens));
            colParam.Add(CreateParamOut("@ExistMaSinhViens", SqlDbType.NVarChar, 2000));
            colParam.Add(CreateParamOut("@ExistHoVaTens", SqlDbType.NVarChar, 2000));
            colParam.Add(CreateParamOut("@ExistTenLops", SqlDbType.NVarChar, 4000));

            object[] result = RunProcedureOut("sp_SV_SinhVien_CheckExistAndGetInfo", colParam, new string[] { "ExistMaSinhViens", "ExistHoVaTens", "ExistTenLops" });
            HoVaTens = (string)result[1];
            TenLops = (string)result[2];
            return (string)result[0];
        }

        public int AddByPhanLop(int IDSV_SinhVienNhapTruong, int IDDM_Lop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVienNhapTruong", SqlDbType.Int, IDSV_SinhVienNhapTruong));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));
            
            return (int)RunProcedureOut("sp_SV_SinhVien_AddByPhanLop", colParam);
        }

        public void XetRaTruong(int IDSV_SinhVien, string SoBang, int TrangThaiSinhVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@SoBang", SqlDbType.NVarChar, 50, SoBang));
            colParam.Add(CreateParam("@TrangThaiSinhVien", SqlDbType.Int, TrangThaiSinhVien));

            RunProcedure("sp_SV_SinhVien_XetRaTruong", colParam);
        }

        public DataTable UpdateDanhSach(int IDDM_Lop, string ChuoiSV_SinhVienID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@SV_SinhVienIDs", SqlDbType.VarChar, 1000, ChuoiSV_SinhVienID));

            return RunProcedureGet("sp_SV_SinhVien_Update_DanhSach", colParam);
        }

        public DataTable UpdateTrangThaiSinhVien(int TrangThaiSinhVien, string ChuoiSV_SinhVienID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TrangThaiSinhVien", SqlDbType.Int, TrangThaiSinhVien));
            colParam.Add(CreateParam("@SV_SinhVienIDs", SqlDbType.VarChar, 1000, ChuoiSV_SinhVienID));

            return RunProcedureGet("sp_SV_SinhVien_Update_TrangThaiSinhVien", colParam);
        }

        public int UpdateMaSinhVien(string MaSinhVien, int SV_SinhVienID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaSinhVien", SqlDbType.NVarChar, MaSinhVien));
            colParam.Add(CreateParam("@SV_SinhVienID", SqlDbType.Int, SV_SinhVienID));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_SV_SinhVien_UpdateMaSinhVien", colParam);
        }

        public void UpdateTaiKhoan(string TenDangNhap, string MatKhau, int SV_SinhVienID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_SinhVienID", SqlDbType.Int, SV_SinhVienID));
            colParam.Add(CreateParam("@TenDangNhap", SqlDbType.NVarChar, TenDangNhap));
            colParam.Add(CreateParam("@MatKhau", SqlDbType.NVarChar, MatKhau));

            RunProcedure("sp_SV_SinhVien_UpdateTaiKhoan", colParam);
        }

        public void UpdateAnhSinhVien(byte[] Anh, int SV_SinhVienID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_SinhVienID", SqlDbType.Int, SV_SinhVienID));
            colParam.Add(CreateParam("@Anh", SqlDbType.Image, Anh.Length, Anh));

            RunProcedure("sp_SV_SinhVien_UpdateAnhSinhVien", colParam);
        }

        public void UpdateTheoLop(string MaSinhVien, string HoVaTen, string Ten, DateTime NgaySinh, bool GioiTinh, string NoiSinh, string ThuongTru, int SV_SinhVienID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaSinhVien", SqlDbType.NVarChar, MaSinhVien));
            colParam.Add(CreateParam("@HoVaTen", SqlDbType.NVarChar, HoVaTen));
            colParam.Add(CreateParam("@Ten", SqlDbType.NVarChar, Ten));
            colParam.Add(CreateParam("@NgaySinh", SqlDbType.DateTime, NgaySinh));
            colParam.Add(CreateParam("@GioiTinh", SqlDbType.Bit, GioiTinh));
            colParam.Add(CreateParam("@NoiSinh", SqlDbType.NVarChar, NoiSinh));
            colParam.Add(CreateParam("@ThuongTru", SqlDbType.NVarChar, ThuongTru));
            colParam.Add(CreateParam("@SV_SinhVienID", SqlDbType.Int, SV_SinhVienID));

            RunProcedure("sp_SV_SinhVien_UpdateTheoLop", colParam);
        }

        public void ChuyenLop(int IDSV_SinhVien, int IDDM_Lop_Cu, int IDDM_Lop_Moi, int TrangThaiSinhVien_Chuyen)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_Lop_Cu", SqlDbType.Int, IDDM_Lop_Cu));
            colParam.Add(CreateParam("@IDDM_Lop_Moi", SqlDbType.Int, IDDM_Lop_Moi));
            colParam.Add(CreateParam("@TrangThaiSinhVien_Chuyen", SqlDbType.Int, TrangThaiSinhVien_Chuyen));

            RunProcedure("sp_SV_SinhVien_ChuyenLop", colParam);
        }

        public DataTable GetBangDiemLanCuoi(int IDSV_SinhVien, int IDDM_NamHoc, string TenNamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@TenNamHoc", SqlDbType.NVarChar, TenNamHoc));

            return RunProcedureGet("sp_SV_SinhVien_GetBangDiemLanCuoi", colParam);
        }
    }
}
