using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_Lop : cDBase
    {
        public DataTable GetTree(string NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NamHoc", SqlDbType.NVarChar, NamHoc));

            return RunProcedureGet("sp_DM_Lop_GetTree", colParam);
        }

        public DataTable GetTreeByIDGiaoVien(string NamHoc, int IDNS_GiaoVien, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NamHoc", SqlDbType.NVarChar, NamHoc));
            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_DM_Lop_GetTreeByIDGiaoVien", colParam);
        }

        public DataTable GetTree_ThiSinhTuDo(string NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NamHoc", SqlDbType.NVarChar, NamHoc));

            return RunProcedureGet("sp_DM_Lop_GetTree_ThiSinhTuDo", colParam);
        }

        public DataTable GetLopGop(DM_LopInfo pDM_LopInfo, int IDDM_MonHoc,string NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar, NamHoc));

            return RunProcedureGet("sp_DM_Lop_GetLopGop", colParam);
        }

        public DataTable GetDanhSachLop(DM_LopInfo pDM_LopInfo, string NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar, NamHoc));

            return RunProcedureGet("sp_DM_Lop_GetDanhSachLop", colParam);
        }

        public DataTable GetTongHopXepLoai(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.VarChar, NamHoc));

            return RunProcedureGet("sp_DM_Lop_GetTongHopXepLoai", colParam);
        }

        public DataTable GetChon(int IDDM_TrinhDo, string NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, IDDM_TrinhDo));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.NVarChar, NamHoc));

            return RunProcedureGet("sp_DM_Lop_GetChon", colParam);
        }

        public DataTable GetKeHoachToanTruong(int IDNamHoc, string NamHoc, DM_LopInfo pDM_LopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDNamHoc));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.NVarChar, NamHoc));
            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));

            return RunProcedureGet("sp_DM_Lop_GetKeHoachToanTruong", colParam);
        }

        public DataTable GetPhanBoPhongHoc(int IDNamHoc, string NamHoc, int HocKy, int CaHoc, int TuTuan, int DenTuan)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDNamHoc));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.NVarChar, NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.NVarChar, HocKy));
            colParam.Add(CreateParam("@CaHoc", SqlDbType.Int, CaHoc));
            colParam.Add(CreateParam("@TuTuan", SqlDbType.Int, TuTuan));
            colParam.Add(CreateParam("@DenTuan", SqlDbType.Int, DenTuan));

            return RunProcedureGet("sp_DM_Lop_GetPhanBoPhongHoc", colParam);
        }
        
        public DataTable GetChuongTrinhDaoTao(int DM_LopID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_LopID", SqlDbType.Int, DM_LopID));

            return RunProcedureGet("sp_DM_Lop_GetChuongTrinhDaoTao", colParam);
        }
        public DataTable GetGetTongDiemThanhPhan(int IDXL_MonHocTrongKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, IDXL_MonHocTrongKy));

            return RunProcedureGet("sp_KQHT_DiemThangPhan_GetTong_byIDXL_MonHocTrongKy", colParam);
        }
        public DataTable GetByKhoa(int IDDM_Khoa, string @NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, IDDM_Khoa));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.NVarChar, NamHoc));

            return RunProcedureGet("sp_DM_Lop_GetByKhoa", colParam);
        }

        public DataTable Get_TKB(long IDXL_Tuan)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_Tuan", SqlDbType.BigInt, IDXL_Tuan));

            return RunProcedureGet("sp_DM_Lop_Get_TKB", colParam);
        }
    }
}
