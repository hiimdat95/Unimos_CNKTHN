using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_BienLaiThuTien : cDBase
    {
        public DataTable GetSoPhieu(int HocKy, int IDDM_NamHoc, int SV_SinhVienID, int IDDM_DiaDiem)
        {
            ArrayList colParam = new ArrayList();
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@SV_SinhVienID", SqlDbType.Int, SV_SinhVienID));
            colParam.Add(CreateParam("@IDDM_DiaDiem", SqlDbType.Int, IDDM_DiaDiem));

            return RunProcedureGet("sp_TC_BienLaiThuTien_GetSoPhieu", colParam);
        }

        public DataTable GetNamHoc(int IDDM_NamHoc,int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_TC_BienLaiThuTien_GetNamHoc", colParam);
        }

        public DataTable GetChiTiet(int TC_BienLaiThuTienID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_BienLaiThuTienID", SqlDbType.Int, TC_BienLaiThuTienID));

            return RunProcedureGet("sp_TC_BienLaiThuTien_GetChiTiet", colParam);
        }

        public DataRow GetInfoByID(int TC_BienLaiThuTienID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_BienLaiThuTienID", SqlDbType.Int, TC_BienLaiThuTienID));

            DataTable dt = RunProcedureGet("sp_TC_BienLaiThuTien_GetInfoByID", colParam);
            if (dt.Rows.Count <= 0)
                return null;
            else
                return dt.Rows[0];
        }

        public DataTable GetBySinhVien(int IDSV_SinhVien, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_TC_BienLaiThuTien_GetBySinhVien", colParam);
        }

        public DataTable GetTongHop(DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int IDTC_LoaiThuChi, int HocKy, int IDTC_QuyenHoaDon, bool TongHopTuDau)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He", SqlDbType.Int, pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc", SqlDbType.Int, pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh", SqlDbType.Int, pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pDM_LopInfo.DM_LopID));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@IDTC_LoaiThuChi", SqlDbType.Int, IDTC_LoaiThuChi));
            colParam.Add(CreateParam("@IDTC_QuyenHoaDon", SqlDbType.Int, IDTC_QuyenHoaDon));
            colParam.Add(CreateParam("@TongHopTuDau", SqlDbType.Bit, TongHopTuDau));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_TC_BienLaiThuTien_GetTongHopThu", colParam);
        }

        public DataTable GetThuChi(int IDTC_LoaiThuChi, string TuNgay, string DenNgay, int IDDM_NamHoc, int HocKy, string IDDM_Lops)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTC_LoaiThuChi", SqlDbType.Int, IDTC_LoaiThuChi));
            colParam.Add(CreateParam("@TuNgay", SqlDbType.VarChar,20, TuNgay));
            colParam.Add(CreateParam("@DenNgay",SqlDbType.VarChar,20, DenNgay));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@IDDM_Lops", SqlDbType.NVarChar, IDDM_Lops));

            return RunProcedureGet("sp_TC_BienLaiThuTien_GetThuChi", colParam);
        }

        public DataTable TimKiem(string SoPhieu, int PhieuThu, int PhieuHuy, string MaSinhVien, int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SoPhieu", SqlDbType.NVarChar, 50, SoPhieu));
            colParam.Add(CreateParam("@PhieuThu", SqlDbType.Int, PhieuThu));
            colParam.Add(CreateParam("@PhieuHuy", SqlDbType.Int, PhieuHuy));
            colParam.Add(CreateParam("@MaSinhVien", SqlDbType.NVarChar,50, MaSinhVien));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_TC_BienLaiThuTien_TimKiem", colParam);
        }

        public void UpdatePhieuHuy(int TC_BienLaiThuTienID, DateTime dtNgayHuy, int IDNguoiHuy, int PhieuHuy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_BienLaiThuTienID", SqlDbType.Int, TC_BienLaiThuTienID));
            colParam.Add(CreateParam("@NgayHuy", SqlDbType.DateTime, dtNgayHuy));
            colParam.Add(CreateParam("@IDNguoiHuy", SqlDbType.Int, IDNguoiHuy));
            colParam.Add(CreateParam("@PhieuHuy", SqlDbType.Int, PhieuHuy));

            RunProcedure("sp_TC_BienLaiThuTien_UpdatePhieuHuy", colParam);
        }
    }
}
