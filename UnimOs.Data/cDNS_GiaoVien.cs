using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_GiaoVien : cDBase
    {
        public DataTable GetByIDNS_DonVi(int IDNS_DonVi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_DonVi", SqlDbType.Int, IDNS_DonVi));

            return RunProcedureGet("sp_NS_GiaoVien_GetByIDNS_DonVi", colParam);
        }

        public DataTable GetForLapTaiKhoan(int IDNS_DonVi, bool ChuaLapTaiKhoan)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_DonVi", SqlDbType.Int, IDNS_DonVi));
            colParam.Add(CreateParam("@ChuaLapTaiKhoan", SqlDbType.Bit, ChuaLapTaiKhoan));

            return RunProcedureGet("sp_NS_GiaoVien_GetForLapTaiKhoan", colParam);
        }

        public DataTable NangBacChuyenNgach_GetByIDNS_DonVi(int IDNS_DonVi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_DonVi", SqlDbType.Int, IDNS_DonVi));

            return RunProcedureGet("sp_NS_GiaoVien_NangBacChuyenNgach_GetByIDNS_DonVi", colParam);
        }

        public DataTable GetGiaoVien_DangGiangDay_ByIDNS_DonVi(int IDNS_DonVi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_DonVi", SqlDbType.Int, IDNS_DonVi));

            return RunProcedureGet("sp_NS_GiaoVien_DangGiangDay_GetByIDNS_DonVi", colParam);
        }

        public DataTable GetByIDNS_DonVi_ChucDanh(int IDNS_DonVi, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_DonVi", SqlDbType.Int, IDNS_DonVi));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_GG_GiaoVien_GetBy_DonVi_ChucDanh", colParam);
        }

        public DataTable TongHopGioGiang(int IDNS_DonVi, int NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_DonVi", SqlDbType.Int, IDNS_DonVi));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, NamHoc));

            return RunProcedureGet("sp_GG_TongHopGioGiang", colParam);
        }

        public DataTable ChiTietGioGiang(int IDNS_GiaoVien, int NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, NamHoc));

            return RunProcedureGet("sp_GG_ChiTietGioGiang", colParam);
        }

        public DataTable Get_TKB(int IDNS_DonVi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_DonVi", SqlDbType.Int, IDNS_DonVi));

            return RunProcedureGet("sp_NS_GiaoVien_Get_TKB", colParam);
        }

        public DataTable GetByUsername(string Username)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Username", SqlDbType.NVarChar, Username));

            return RunProcedureGet("sp_NS_GiaoVien_GetByUsername", colParam);
        }

        public DataTable TimKiem(NS_GiaoVienInfo pNS_GiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaGiaoVien", SqlDbType.NVarChar, pNS_GiaoVienInfo.MaGiaoVien));
            colParam.Add(CreateParam("@HoTen", SqlDbType.NVarChar, pNS_GiaoVienInfo.HoTen));

            return RunProcedureGet("sp_NS_GiaoVien_TimKiem", colParam);
        }

        public DataTable GetBaoCaoChatLuongCanBo(DateTime DenNgay)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DenNgay", SqlDbType.DateTime, DenNgay));

            return RunProcedureGet("sp_NS_GiaoVien_GetBaoCaoChatLuongCanBo", colParam);
        }

        public DataSet GetBaoCaoChatLuongDoiNguGiaoVien(DateTime DenNgay)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DenNgay", SqlDbType.DateTime, DenNgay));

            return RunProcedureGetDataSet("sp_NS_GiaoVien_GetBaoCaoChatLuongDoiNguGiaoVien", colParam);
        }

        public DataTable UpdateDanhSach(int IDNS_DonVi, string ChuoiNS_GiaoVienID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_DonVi", SqlDbType.Int, IDNS_DonVi));
            colParam.Add(CreateParam("@ChuoiNS_GiaoVienID", SqlDbType.VarChar, 1000, ChuoiNS_GiaoVienID));

            return RunProcedureGet("sp_NS_GiaoVien_Update_DanhSach", colParam);
        }

        public DataTable UpdatePassword(int IDNS_GiaoVien, string Password)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_GiaoVienID", SqlDbType.Int, IDNS_GiaoVien));
            colParam.Add(CreateParam("@Password", SqlDbType.NVarChar, Password));

            return RunProcedureGet("sp_NS_GiaoVien_UpdatePassword", colParam);
        }

        public string UpdateTaiKhoan(string Username, string Password, int NS_GiaoVienID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Username", SqlDbType.NVarChar, Username));
            colParam.Add(CreateParam("@Password", SqlDbType.NVarChar, Password));
            colParam.Add(CreateParam("@NS_GiaoVienID", SqlDbType.Int, NS_GiaoVienID));
            colParam.Add(CreateParamOut("@UsernameNew", SqlDbType.NVarChar, 50));

            return (string)RunProcedureOut("sp_NS_GiaoVien_UpdateTaiKhoan", colParam, "UsernameNew");
        }

        public void UpdateIDDM_Khoa_GiaoVu(int IDDM_Khoa_GiaoVu, int NS_GiaoVienID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Khoa_GiaoVu", SqlDbType.Int, IDDM_Khoa_GiaoVu));
            colParam.Add(CreateParam("@NS_GiaoVienID", SqlDbType.Int, NS_GiaoVienID));

            RunProcedure("sp_NS_GiaoVien_UpdateIDDM_Khoa_GiaoVu", colParam);
        }

        public void UpdateAnhGiaoVien(byte[] Anh, int NS_GiaoVienID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_GiaoVienID", SqlDbType.Int, NS_GiaoVienID));
            colParam.Add(CreateParam("@Anh", SqlDbType.Image, Anh.Length, Anh));

            RunProcedure("sp_NS_GiaoVien_UpdateAnhGiaoVien", colParam);
        }

        public void UpdateDonVi(int NS_GiaoVienID, int IDNS_DonVi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_GiaoVienID", SqlDbType.Int, NS_GiaoVienID));
            colParam.Add(CreateParam("@IDNS_DonVi", SqlDbType.Int, IDNS_DonVi));

            RunProcedure("sp_NS_GiaoVien_UpdateDonVi", colParam);
        }

        public DataTable GetHoSo(int NS_GiaoVienID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_GiaoVienID", SqlDbType.Int, NS_GiaoVienID));

            return RunProcedureGet("sp_NS_GiaoVien_GetHoSo", colParam);
        }

        public string CheckExistByMaGiaoVien(string MaGiaoViens)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaGiaoViens", SqlDbType.NVarChar, MaGiaoViens));
            colParam.Add(CreateParamOut("@ExistMaGiaoViens", SqlDbType.NVarChar, 4000));

            return (string)RunProcedureOut("sp_NS_GiaoVien_CheckExistByMaGiaoVien", colParam, "ExistMaGiaoViens");
        }

        public DataTable Get_QuaTrinhBoiDuong(int IDNS_GiaoVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));

            return RunProcedureGet("sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhBoiDuong", colParam);
        }

        public DataTable Get_QuaTrinhBoNhiemChucVu(int IDNS_GiaoVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));

            return RunProcedureGet("sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhBoNhiemChucVu", colParam);
        }

        public DataTable Get_QuaTrinhCongTac(int IDNS_GiaoVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));

            return RunProcedureGet("sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhCongTac", colParam);
        }

        public DataTable Get_QuaTrinhKhenThuong(int IDNS_GiaoVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));

            return RunProcedureGet("sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhKhenThuong", colParam);
        }

        public DataTable Get_QuaTrinhKyLuat(int IDNS_GiaoVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));

            return RunProcedureGet("sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhKyLuat", colParam);
        }

        public DataTable Get_QuaTrinhLuanChuyen(int IDNS_GiaoVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));

            return RunProcedureGet("sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhLuanChuyen", colParam);
        }

        public DataTable Get_QuaTrinhMienNhiemTuChuc(int IDNS_GiaoVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));

            return RunProcedureGet("sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhMienNhiemTuChuc", colParam);
        }

        public DataTable Get_QuaTrinhThamGiaLLVT(int IDNS_GiaoVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));

            return RunProcedureGet("sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhThamGiaLLVT", colParam);
        }

        public DataTable Get_QuaTrinhThamGiaTCCTXH(int IDNS_GiaoVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));

            return RunProcedureGet("sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhThamGiaTCCTXH", colParam);
        }

        public DataTable LocGiaoVien(int IDNS_DonVi, string HoTen)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_DonVi", SqlDbType.Int, IDNS_DonVi));
            colParam.Add(CreateParam("@HoTen", SqlDbType.NVarChar, HoTen));

            return RunProcedureGet("sp_NS_GiaoVien_LocGiaoVien", colParam);
        }

        public DataTable GetMaLonNhat(int DoDaiMa, string PhanDauMa, string PhanCuoiMa)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DoDaiMa", SqlDbType.Int, DoDaiMa));
            colParam.Add(CreateParam("@PhanDauMa", SqlDbType.NVarChar, PhanDauMa));
            colParam.Add(CreateParam("@PhanCuoiMa", SqlDbType.NVarChar, PhanCuoiMa));

            return RunProcedureGet("sp_NS_GiaoVien_GetMaLonNhat", colParam);
        }

        public int UpdateMaGiaoVien(string MaGiaoVien, int NS_GiaoVienID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaGiaoVien", SqlDbType.NVarChar, MaGiaoVien));
            colParam.Add(CreateParam("@NS_GiaoVienID", SqlDbType.Int, NS_GiaoVienID));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_GiaoVien_UpdateMaGiaoVien", colParam);
        }

        public DataTable Get_SoYeuLyLich(int NS_GiaoVienID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_GiaoVienID", SqlDbType.Int, NS_GiaoVienID));

            return RunProcedureGet("sp_NS_GiaoVien_Get_SoYeuLyLich", colParam);
        }

        public DataTable Get_CanhBaoHanNghiHuu(int HanCanhBao, DateTime TinhDenNgay)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HanCanhBao", SqlDbType.Int, HanCanhBao));
            colParam.Add(CreateParam("@TinhDenNgay", SqlDbType.DateTime, TinhDenNgay));

            return RunProcedureGet("sp_NS_GiaoVien_Get_CanhBaoHanNghiHuu", colParam);
        }

        public DataTable Get_CanhBaoHetNhiemKy(int HanCanhBao, DateTime TinhDenNgay)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HanCanhBao", SqlDbType.Int, HanCanhBao));
            colParam.Add(CreateParam("@TinhDenNgay", SqlDbType.DateTime, TinhDenNgay));

            return RunProcedureGet("sp_NS_GiaoVien_Get_CanhBaoHetNhiemKy", colParam);
        }
    }
}
