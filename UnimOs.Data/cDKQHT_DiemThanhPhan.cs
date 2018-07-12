using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DiemThanhPhan : cDBase
    {
        public DataTable GetDanhSach(int IDDM_Lop, int IDDM_MonHoc, int XL_MonHocTrongKyID, int IDDM_NamHoc, int HocKy, int LanThi, int KQHT_ChoNhapLaiDiemID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, XL_MonHocTrongKyID));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));
            colParam.Add(CreateParam("@KQHT_ChoNhapLaiDiemID", SqlDbType.Int, KQHT_ChoNhapLaiDiemID));

            return RunProcedureGet("sp_KQHT_DiemThanhPhan_GetDanhSach", colParam);
        }

        public DataTable ChoNhapLaiDiem_GetDanhSach(int IDKQHT_ChoNhapLaiDiem)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_ChoNhapLaiDiem", SqlDbType.Int, IDKQHT_ChoNhapLaiDiem));

            return RunProcedureGet("sp_KQHT_DiemThanhPhan_ChoNhapLaiDiem_GetDanhSach", colParam);
        }

        public DataTable GetTongHopTBHS(int IDXL_MonHocTrongKy, int IDDM_MonHoc, int IDDM_Lop, int IDDM_TrinhDo, 
            int IDDM_NamHoc, int HocKy, int DiemLan)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@DiemLan", SqlDbType.Int, DiemLan));

            return RunProcedureGet("sp_KQHT_DiemThanhPhan_GetTongHopTBHS", colParam);
        }

        public DataTable KiemTraDiem(int IDSV_SinhVien, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_KQHT_DiemThanhPhan_KiemTraDiem", colParam);
        }

        public void DeleteBy_SinhVien(int IDSV_SinhVien, int LanThi, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int IDKQHT_ThanhPhanDiem)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@IDKQHT_ThanhPhanDiem", SqlDbType.Int, IDKQHT_ThanhPhanDiem));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));

            RunProcedure("sp_KQHT_DiemThanhPhan_DeleteBy_SinhVien", colParam);
        }

        public void DeleteByInfo(KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, pKQHT_DiemThanhPhanInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, pKQHT_DiemThanhPhanInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, pKQHT_DiemThanhPhanInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, pKQHT_DiemThanhPhanInfo.HocKy));
            colParam.Add(CreateParam("@IDKQHT_ThanhPhanDiem", SqlDbType.Int, pKQHT_DiemThanhPhanInfo.IDKQHT_ThanhPhanDiem));
            colParam.Add(CreateParam("@DiemThu", SqlDbType.Int, pKQHT_DiemThanhPhanInfo.DiemThu));
            colParam.Add(CreateParam("@DiemLan", SqlDbType.Int, pKQHT_DiemThanhPhanInfo.DiemLan));

            RunProcedure("sp_KQHT_DiemThanhPhan_DeleteByInfo", colParam);
        }

        public int AddByImport(KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo, int LanThi, string MaSinhVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaSinhVien", SqlDbType.NVarChar, MaSinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, pKQHT_DiemThanhPhanInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, pKQHT_DiemThanhPhanInfo.HocKy));
            colParam.Add(CreateParam("@IDKQHT_ThanhPhanDiem", SqlDbType.Int, pKQHT_DiemThanhPhanInfo.IDKQHT_ThanhPhanDiem));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));
            colParam.Add(CreateParam("@Diem", SqlDbType.Real, pKQHT_DiemThanhPhanInfo.Diem));
            colParam.Add(CreateParam("@IDHT_User", SqlDbType.Int, pKQHT_DiemThanhPhanInfo.IDHT_User));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, pKQHT_DiemThanhPhanInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_DiemThanhPhan_AddByImport", colParam);
        }
    }
}
