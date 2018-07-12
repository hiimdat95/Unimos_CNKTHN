using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DiemTongKetToanKhoa : cDBase
    {
        public DataTable GetDiemTotNghieps(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));

            return RunProcedureGet("sp_KQHT_DiemTongKetToanKhoa_GetDiemTotNghiep", colParam);
        }

        public DataTable GetTongHop(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));

            return RunProcedureGet("sp_KQHT_DiemTongKetToanKhoa_GetTongHop", colParam);
        }

        public DataTable GetDanhSach(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_KQHT_DiemTongKetToanKhoa_GetDanhSach", colParam);
        }

        public DataTable GetDanhSachNoMon(DM_LopInfo pDM_LopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));

            return RunProcedureGet("sp_KQHT_DiemTongKetToanKhoa_GetDanhSachNoMon", colParam);
        }
    }
}
