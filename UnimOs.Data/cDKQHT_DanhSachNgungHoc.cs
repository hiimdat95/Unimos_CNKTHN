using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DanhSachNgungHoc : cDBase
    {

        public DataTable GetSinhVien(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc)
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

            return RunProcedureGet("sp_KQHT_DanhSachNgungHoc_GetSinhVien", colParam);
        }
        public DataTable GetSinhVienTKTongTuThang(int nam, int tuthang, int denthang)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Nam", SqlDbType.Int, nam));
            colParam.Add(CreateParam("@TuThang", SqlDbType.Int, tuthang));
            colParam.Add(CreateParam("@DenThang", SqlDbType.Int, denthang));
           

            return RunProcedureGet("sp_Lop_ThongKe_GetSinhVien", colParam);
        }
        public DataTable GetSinhVienTKTongTuThangThem(int nam, int tuthang, int denthang)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Nam", SqlDbType.Int, nam));
            colParam.Add(CreateParam("@TuThang", SqlDbType.Int, tuthang));
            colParam.Add(CreateParam("@DenThang", SqlDbType.Int, denthang));


            return RunProcedureGet("sp_Lop_ThongKe_GetSinhVien_TheoThang_Them", colParam);
        }
        public DataTable GetSinhVienTKTongTuThangBot(int nam, int tuthang, int denthang)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Nam", SqlDbType.Int, nam));
            colParam.Add(CreateParam("@TuThang", SqlDbType.Int, tuthang));
            colParam.Add(CreateParam("@DenThang", SqlDbType.Int, denthang));


            return RunProcedureGet("sp_Lop_ThongKe_GetSinhVien_TheoThang_Bot", colParam);
        }
        public void DeleteQĐ(string SV_SinhVienIDs, int IDDM_Lop, int IDDM_NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_SinhVienIDs", SqlDbType.VarChar, 2000, SV_SinhVienIDs));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));

            RunProcedure("sp_KQHT_DanhSachNgungHoc_DeleteQD", colParam);
        }
    }
}
