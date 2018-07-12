using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DiemTongKetMon : cDBase
    {
        public DataTable GetDanhSach(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi, int Kieu)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));
            colParam.Add(CreateParam("@Kieu", SqlDbType.Int, Kieu));

            return RunProcedureGet("sp_KQHT_DiemTongKetMon_GetDanhSach", colParam);            
        }

        public DataTable GetDanhSachNhapDiem(int IDDM_Lop, int IDDM_MonHoc, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));

            return RunProcedureGet("sp_KQHT_DiemTongKetMon_GetDanhSachNhapDiem", colParam);
        }

        public DataTable GetByLop(int IDDM_Lop, int IDDM_MonHoc, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_KQHT_DiemTongKetMon_GetByLop", colParam);
        }

        public DataTable ChoNhapLaiDiem_GetByLop(int IDKQHT_ChoNhapLaiDiem)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_ChoNhapLaiDiem", SqlDbType.Int, IDKQHT_ChoNhapLaiDiem));

            return RunProcedureGet("sp_KQHT_DiemTongKetMon_ChoNhapLaiDiem_GetByLop", colParam);
        }

        public DataTable GetMonKy(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));

            return RunProcedureGet("sp_KQHT_DiemTongKetMon_GetMonKy", colParam);
        }

        public DataTable GetSoMonCoDiemByLop(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_KQHT_DiemTongKetMon_GetSoMonCoDiemByLop", colParam);
        }

        public DataTable GetDiemThucTapTotNghiep(DM_LopInfo pDM_LopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));

            return RunProcedureGet("sp_KQHT_DiemTongKetMon_GetDiemThucTapTotNghiep", colParam);
        }

        public int AddByImport(KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo, string MaSinhVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaSinhVien", SqlDbType.NVarChar, MaSinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, pKQHT_DiemTongKetMonInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, pKQHT_DiemTongKetMonInfo.HocKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, pKQHT_DiemTongKetMonInfo.LanThi));
            colParam.Add(CreateParam("@Diem", SqlDbType.Real, pKQHT_DiemTongKetMonInfo.Diem));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, pKQHT_DiemTongKetMonInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_DiemTongKetMon_AddByImport", colParam);
        }

        public void DeleteByIDMonHocTrongKy(int IDSV_SinhVien, long IDXL_MonHocTrongKy, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.BigInt, IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));

            RunProcedure("sp_KQHT_DiemTongKetMon_DeleteByIDMonHocTrongKy", colParam);
        }
    }
}
