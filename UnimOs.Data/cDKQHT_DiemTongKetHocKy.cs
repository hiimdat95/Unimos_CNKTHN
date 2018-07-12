using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DiemTongKetHocKy : cDBase
    {
        public DataTable GetDanhSach(int IDDM_Lop,  int IDDM_NamHoc, int HocKy, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));

            return RunProcedureGet("sp_KQHT_DiemTongKetHocKy_GetDanhSach", colParam);
        }

        public DataTable GetDiemThiTN(int IDSV_SinhVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));

            return RunProcedureGet("sp_KQHT_DiemThiTN_GetIDSV_SinhVien", colParam);
        }
        public DataTable GetDiemTongKet(int IDSV_SinhVien, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_KQHT_DiemTongKet_GetBySinhVien", colParam);
        }
        public DataTable GetDiemTongKet_KQHT(int IDSV_SinhVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));


            return RunProcedureGet("sp_KQHT_DiemTongKet_GetBySinhVien_KQHT", colParam);
        }
        
        public void UpdateTrangThai(int IDSV_SinhVien, int IDDM_NamHoc, int HocKy, int TrangThai, string GhiChu)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@GhiChu", SqlDbType.NVarChar, GhiChu));
            colParam.Add(CreateParam("@TrangThai", SqlDbType.Int, TrangThai));

            RunProcedure("sp_KQHT_DiemTongKetHocKy_UpdateTrangThai", colParam);
        }
        
    }
}
