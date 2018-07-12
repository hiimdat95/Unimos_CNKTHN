using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DiemThi : cDBase
    {
        public DataTable GetDanhSach(int IDDM_Lop, int IDDM_MonHoc,int IDXL_MonHocTrongKy,int IDDM_NamHoc, int HocKy, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_KQHT_DiemThi_GetDanhSach", colParam);
        }

        public DataTable GetByLop(int IDDM_Lop, int IDDM_MonHoc, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_KQHT_DiemThi_GetByLop", colParam);
        }

        public DataTable ChoNhapLaiDiem_GetByLop(int IDKQHT_ChoNhapLaiDiem)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_ChoNhapLaiDiem", SqlDbType.Int, IDKQHT_ChoNhapLaiDiem));

            return RunProcedureGet("sp_KQHT_DiemThi_ChoNhapLaiDiem_GetByLop", colParam);
        }

        public DataTable GetDanhSachThiLai(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_KQHT_DiemThi_GetDanhSachThiLai", colParam);
        }

        public DataTable GetDanhSachKhongQua(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_KQHT_DiemThi_GetDanhSachKhongQua", colParam);
        }

        public DataTable GetSinhVien(int KQHT_ToChucThiID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_ToChucThiID", SqlDbType.Int, KQHT_ToChucThiID));

            return RunProcedureGet("sp_KQHT_DiemThi_GetSinhVien", colParam);     
        }

        public void DeleteByInfo(KQHT_DiemThiInfo pKQHT_DiemThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, pKQHT_DiemThiInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, pKQHT_DiemThiInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, pKQHT_DiemThiInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, pKQHT_DiemThiInfo.HocKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, pKQHT_DiemThiInfo.LanThi));

            RunProcedure("sp_KQHT_DiemThi_DeleteByInfo", colParam);
        }
    }
}
