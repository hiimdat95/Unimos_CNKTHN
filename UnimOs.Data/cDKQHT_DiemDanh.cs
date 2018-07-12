using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DiemDanh : cDBase
    {
        public DataTable GetDanhSach(int IDDM_Lop, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_KQHT_DiemDanh_GetDanhSach", colParam);
        }

        public DataTable GetByLop(int IDDM_Lop, int IDXL_MonHocTrongKy, int DiemLan)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@DiemLan", SqlDbType.Int, DiemLan));
           
            return RunProcedureGet("sp_KQHT_DiemDanh_GetByLop", colParam);
        }

        public DataTable ChoNhapLaiDiem_GetByLop(int IDKQHT_ChoNhapLaiDiem)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_ChoNhapLaiDiem", SqlDbType.Int, IDKQHT_ChoNhapLaiDiem));

            return RunProcedureGet("sp_KQHT_DiemDanh_ChoNhapLaiDiem_GetByLop", colParam);
        }

        public void DeleteByInfo(int IDSV_SinhVien, int IDXL_MonHocTrongKy, string LyDo, int DiemLan)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@LyDo", SqlDbType.NVarChar, LyDo));
            colParam.Add(CreateParam("@DiemLan", SqlDbType.Int, DiemLan));

            RunProcedure("sp_KQHT_DiemDanh_DeleteByInfo", colParam);
        }
    }
}
