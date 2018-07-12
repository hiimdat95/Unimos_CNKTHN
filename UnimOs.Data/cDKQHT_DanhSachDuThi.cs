using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DanhSachDuThi : cDBase
    {
        public DataTable GetByIDToChucThi(int IDKQHT_ToChucThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_ToChucThi", SqlDbType.Int, IDKQHT_ToChucThi));

            return RunProcedureGet("sp_KQHT_DanhSachDuThi_GetByIDToChucThi", colParam);            
        }

        public DataTable GetDanhSach(int IDDM_Lop, long IDXL_MonHocTrongKy, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.BigInt, IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));

            return RunProcedureGet("sp_KQHT_DanhSachDuThi_GetDanhSach", colParam);
        }

        public DataTable GetNhapDiem(long IDXL_MonHocTrongKy, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.BigInt, IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));

            return RunProcedureGet("sp_KQHT_DanhSachDuThi_GetNhapDiem", colParam);
        }

        public DataTable GetDaChuyenDiemByMonHocTrongKy(long IDXL_MonHocTrongKy, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.BigInt, IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));

            return RunProcedureGet("sp_KQHT_DanhSachDuThi_GetDaChuyenDiemByMonHocTrongKy", colParam);
        }

        public void UpdateSoPhach(string SoPhach, int TuiThiSo, double KQHT_DanhSachDuThiID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SoPhach", SqlDbType.NVarChar, SoPhach));
            colParam.Add(CreateParam("@TuiThiSo", SqlDbType.Int, TuiThiSo));
            colParam.Add(CreateParam("@KQHT_DanhSachDuThiID", SqlDbType.BigInt, KQHT_DanhSachDuThiID));

            RunProcedure("sp_KQHT_DanhSachDuThi_UpdateSoPhach", colParam);
        }

        public void UpdateDiem(double Diem, double KQHT_DanhSachDuThiID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Diem", SqlDbType.Float, Diem));
            colParam.Add(CreateParam("@KQHT_DanhSachDuThiID", SqlDbType.BigInt, KQHT_DanhSachDuThiID));

            RunProcedure("sp_KQHT_DanhSachDuThi_UpdateDiem", colParam);
        }

        public void UpdateDaChuyenDiem(bool IsDaChuyen, double IDXL_MonHocTrongKy, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IsDaChuyen", SqlDbType.Bit, IsDaChuyen));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.BigInt, IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));

            RunProcedure("sp_KQHT_DanhSachDuThi_UpdateDaChuyenDiem", colParam);
        }

        public void UpdateDaChuyenDiemByToChucThi(bool IsDaChuyen, int IDKQHT_ToChucThi, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IsDaChuyen", SqlDbType.Bit, IsDaChuyen));
            colParam.Add(CreateParam("@IDKQHT_ToChucThi", SqlDbType.Int, IDKQHT_ToChucThi));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));

            RunProcedure("sp_KQHT_DanhSachDuThi_UpdateDaChuyenDiemByToChucThi", colParam);
        }

        public void UpdateSoPhachMonLop(int IDSV_SinhVien, string SoPhach, long IDXL_MonHocTrongKy, int LanThi, int MucPhatQuyChe, string LyDoViPhamQuyChe)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@SoPhach", SqlDbType.NVarChar, SoPhach));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.BigInt, IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));
            colParam.Add(CreateParam("@MucPhatQuyChe", SqlDbType.Int, MucPhatQuyChe));
            colParam.Add(CreateParam("@LyDoViPhamQuyChe", SqlDbType.NVarChar, LyDoViPhamQuyChe));

            RunProcedure("sp_KQHT_DanhSachDuThi_UpdateSoPhachMonLop", colParam);
        }

        public void HuyPhachMonLop(long IDXL_MonHocTrongKy, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.BigInt, IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));

            RunProcedure("sp_KQHT_DanhSachDuThi_HuyPhachMonLop", colParam);
        }
    }
}
