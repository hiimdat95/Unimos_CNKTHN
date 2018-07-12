using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_ChoNhapLaiDiem : cDBase
    {
        public DataTable GetDanhSach(int IDXL_MonHocTrongKy, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));

            return RunProcedureGet("sp_KQHT_ChoNhapLaiDiem_GetDanhSach", colParam);
        }

        public int AddChuyenDiem(int IDXL_MonHocTrongKy, int IDHT_User, bool DiemThanhPhan_L1, bool DiemThi_L1, bool DiemThanhPhan_L2, bool DiemThi_L2)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@IDHT_User", SqlDbType.Int, IDHT_User));
            colParam.Add(CreateParam("@DiemThanhPhan_L1", SqlDbType.Bit, DiemThanhPhan_L1));
            colParam.Add(CreateParam("@DiemThi_L1", SqlDbType.Bit, DiemThi_L1));
            colParam.Add(CreateParam("@DiemThanhPhan_L2", SqlDbType.Bit, DiemThanhPhan_L2));
            colParam.Add(CreateParam("@DiemThi_L2", SqlDbType.Bit, DiemThi_L2));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_ChoNhapLaiDiem_AddChuyenDiem", colParam);
        }

        public void LuuDiemHienTai(int IDKQHT_ChoNhapLaiDiem, int IDXL_MonHocTrongKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_ChoNhapLaiDiem", SqlDbType.Int, IDKQHT_ChoNhapLaiDiem));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, IDXL_MonHocTrongKy));

            RunProcedure("sp_KQHT_ChoNhapLaiDiem_LuuDiemHienTai", colParam);
        }
    }
}
