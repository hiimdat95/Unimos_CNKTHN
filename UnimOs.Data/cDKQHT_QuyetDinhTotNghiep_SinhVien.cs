using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_QuyetDinhTotNghiep_SinhVien : cDBase
    {
        public DataTable GetByQuyetDinh(int IDKQHT_QuyetDinhTotNghiep)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_QuyetDinhTotNghiep", SqlDbType.Int, IDKQHT_QuyetDinhTotNghiep));

            return RunProcedureGet("sp_KQHT_QuyetDinhTotNghiep_SinhVien_GetByQuyetDinh", colParam);
        }

        public DataTable GetByIDDM_NamHoc(int IDDM_NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));

            return RunProcedureGet("sp_KQHT_QuyetDinhTotNghiep_SinhVien_GetByIDDM_NamHoc", colParam);
        }

        public DataTable GetNotIn(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));

            return RunProcedureGet("sp_KQHT_QuyetDinhTotNghiep_SinhVien_GetNotIn", colParam);
        }

        public DataTable GetBangDiem(string IDSV_SinhViens, int IDDM_NamHoc, string TenNamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhViens", SqlDbType.NVarChar, IDSV_SinhViens));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@TenNamHoc", SqlDbType.NVarChar, TenNamHoc));

            return RunProcedureGet("sp_KQHT_QuyetDinhTotNghiep_SinhVien_GetBangDiem", colParam);
        }

        public DataTable GetBangDiemLanCuoi(string IDSV_SinhViens, int IDDM_NamHoc, string TenNamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhViens", SqlDbType.NVarChar, IDSV_SinhViens));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@TenNamHoc", SqlDbType.NVarChar, TenNamHoc));

            return RunProcedureGet("sp_KQHT_QuyetDinhTotNghiep_SinhVien_GetBangDiemLanCuoi", colParam);
        }

        public void UpdateSoBang(int KQHT_QuyetDinhTotNghiep_SinhVienID, string SoBang)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SoBang", SqlDbType.NVarChar, SoBang));
            colParam.Add(CreateParam("@KQHT_QuyetDinhTotNghiep_SinhVienID", SqlDbType.BigInt, KQHT_QuyetDinhTotNghiep_SinhVienID));

            RunProcedure("sp_KQHT_QuyetDinhTotNghiep_SinhVien_UpdateSoBang", colParam);
        }
    }
}
