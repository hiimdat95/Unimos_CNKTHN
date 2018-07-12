using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Entity.Model;


namespace UnimOs.Service
{
    // NOTE: If you change the interface name "IQLBanHangService" here, you must also update the reference to "IQLBanHangService" in Web.config.
    [ServiceContract]
    public interface IUnimOsService
    {
        [OperationContract(Name = "cDBase_RunQuery")]
        string cDBase_RunQuery(string MaXacThuc, string sqlConnection, string SQL);


        [OperationContract(Name = "cDHT_DongBo_GetDanhSachThayDoi")]
        List<sp_HT_DongBo_GetDanhSachThayDoiResult> cDHT_DongBo_GetDanhSachThayDoi(string MaXacThuc, string TenBang, string IDThayDoi);

        [OperationContract(Name = "cDHT_DongBo_GetDataChanged")]
        List<HT_DongBoInfo> cDHT_DongBo_GetDataChanged(string MaXacThuc, string TenBang, long IDThayDoi);

        [OperationContract(Name = "cDHT_DongBo_UpdateTrangThai")]
        void cDHT_DongBo_UpdateTrangThai(string MaXacThuc, bool DaDongBo, long HT_DongBoID);

        [OperationContract(Name = "cDHT_DongBo_Get")]
        List<sp_HT_DongBo_GetResult> cDHT_DongBo_Get(string MaXacThuc, HT_DongBoInfo pHT_DongBoInfo);

        [OperationContract(Name = "cDHT_DongBo_Add")]
        int cDHT_DongBo_Add(string MaXacThuc, HT_DongBoInfo pHT_DongBoInfo);

        [OperationContract(Name = "cDHT_DongBo_Update")]
        void cDHT_DongBo_Update(string MaXacThuc, HT_DongBoInfo pHT_DongBoInfo);

        [OperationContract(Name = "cDHT_DongBo_Delete")]
        void cDHT_DongBo_Delete(string MaXacThuc, HT_DongBoInfo pHT_DongBoInfo);
        [OperationContract(Name = "cDHT_Log_Search")]
        List<HT_LogInfo> cDHT_Log_Search(string MaXacThuc, int IDPhanHe, int IDChucNang, string SuKien, string NguoiDung, string NoiDung, DateTime dtTuNgay, DateTime dtDenNgay);

        [OperationContract(Name = "cDTC_BienLaiThuTien_GetSoPhieu")]
        List<sp_TC_BienLaiThuTien_GetSoPhieuResult> cDTC_BienLaiThuTien_GetSoPhieu(string MaXacThuc, int HocKy, int IDDM_NamHoc, int SV_SinhVienID, int IDDM_DiaDiem);

        [OperationContract(Name = "cDTC_BienLaiThuTien_GetNamHoc")]
        List<TC_BienLaiThuTienInfo> cDTC_BienLaiThuTien_GetNamHoc(string MaXacThuc, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDTC_BienLaiThuTien_GetChiTiet")]
        List<sp_TC_BienLaiThuTien_GetChiTietResult> cDTC_BienLaiThuTien_GetChiTiet(string MaXacThuc, int TC_BienLaiThuTienID);

        //[OperationContract(Name = "cDTC_BienLaiThuTien_GetInfoByID")]
        //DataRow cDTC_BienLaiThuTien_GetInfoByID(string MaXacThuc, int TC_BienLaiThuTienID);

        [OperationContract(Name = "cDTC_BienLaiThuTien_GetBySinhVien")]
        List<sp_TC_BienLaiThuTien_GetBySinhVienResult> cDTC_BienLaiThuTien_GetBySinhVien(string MaXacThuc, int IDSV_SinhVien, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDTC_BienLaiThuTien_GetTongHop")]
        List<TC_BienLaiThuTienInfo> cDTC_BienLaiThuTien_GetTongHop(string MaXacThuc, DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int IDTC_LoaiThuChi, int HocKy, int IDTC_QuyenHoaDon, bool TongHopTuDau);

        [OperationContract(Name = "cDTC_BienLaiThuTien_GetThuChi")]
        List<TC_BienLaiThuTienInfo> cDTC_BienLaiThuTien_GetThuChi(string MaXacThuc, int IDTC_LoaiThuChi, string TuNgay, string DenNgay, int IDDM_NamHoc, int HocKy, string IDDM_Lops);

        [OperationContract(Name = "cDTC_BienLaiThuTien_TimKiem")]
        List<TC_BienLaiThuTienInfo> cDTC_BienLaiThuTien_TimKiem(string MaXacThuc, string SoPhieu, int PhieuThu, int PhieuHuy, string MaSinhVien, int IDDM_Lop, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDTC_BienLaiThuTien_UpdatePhieuHuy")]
        void cDTC_BienLaiThuTien_UpdatePhieuHuy(string MaXacThuc, int TC_BienLaiThuTienID, DateTime dtNgayHuy, int IDNguoiHuy, int PhieuHuy);

        [OperationContract(Name = "cDXL_KeHoachKhac_GetCombo")]
        List<sp_XL_KeHoachKhac_GetComboResult> cDXL_KeHoachKhac_GetCombo(string MaXacThuc, XL_KeHoachKhacInfo pXL_KeHoachKhacInfo);

        [OperationContract(Name = "cDNS_NhomNgach_GetBy_NS_NgachCongChucID")]
        List<NS_NhomNgachInfo> cDNS_NhomNgach_GetBy_NS_NgachCongChucID(string MaXacThuc, int NS_NgachCongChucID);

        [OperationContract(Name = "cDXL_Tuan_GetByIDNamHoc")]
        List<sp_XL_Tuan_GetByIDNamHocResult> cDXL_Tuan_GetByIDNamHoc(string MaXacThuc, XL_TuanInfo pTuanInfo);

        [OperationContract(Name = "cDXL_Tuan_GetByTuanThu")]
        List<sp_XL_Tuan_GetByTuanThuResult> cDXL_Tuan_GetByTuanThu(string MaXacThuc, XL_TuanInfo pTuanInfo);

        [OperationContract(Name = "cDXL_Tuan_GetBy_NamHoc_HocKy")]
        List<sp_XL_Tuan_GetByNamHoc_HocKyResult> cDXL_Tuan_GetBy_NamHoc_HocKy(string MaXacThuc, int IDNamHoc, int HocKy);

        [OperationContract(Name = "cDXL_Tuan_DeleteTuanThua")]
        void cDXL_Tuan_DeleteTuanThua(string MaXacThuc, XL_TuanInfo pTuanInfo);

        [OperationContract(Name = "cDDM_Khoa_GetByIDBoMon")]
        List<sp_DM_Khoa_GetByIDBoMonResult> cDDM_Khoa_GetByIDBoMon(string MaXacThuc, int IDDM_BoMon);

        [OperationContract(Name = "cDKQHT_QuyChe_GetThamSo")]
        List<sp_KQHT_QuyChe_GetThamSoResult> cDKQHT_QuyChe_GetThamSo(string MaXacThuc, int KQHT_QuyCheID);

        [OperationContract(Name = "cDKQHT_QuyChe_GetThamSo_NotIn")]
        List<sp_KQHT_QuyChe_GetThamSo_NotInResult> cDKQHT_QuyChe_GetThamSo_NotIn(string MaXacThuc, int KQHT_QuyCheID);

        [OperationContract(Name = "cDKQHT_QuyChe_GetByMaThamSo")]
        string cDKQHT_QuyChe_GetByMaThamSo(string MaXacThuc, int IDDM_TrinhDo, string MaThamSo);

        [OperationContract(Name = "cDDM_TrinhDo_GetByIDHe")]
        List<sp_DM_TrinhDo_GetByIDHeResult> cDDM_TrinhDo_GetByIDHe(string MaXacThuc, int IDDM_He);

        [OperationContract(Name = "cDDM_Nganh_GetByIDKhoa")]
        List<sp_DM_Nganh_GetByIDKhoaResult> cDDM_Nganh_GetByIDKhoa(string MaXacThuc, int IDDM_Khoa);

        [OperationContract(Name = "cDDM_ChuyenNganh_GetByIDNganh")]
        List<sp_DM_ChuyenNganh_GetByIDNganhResult> cDDM_ChuyenNganh_GetByIDNganh(string MaXacThuc, int IDDM_Nganh);

        [OperationContract(Name = "cDDM_BoMon_GetByIDKhoa")]
        List<sp_DM_BoMon_GetByIDKhoaResult> cDDM_BoMon_GetByIDKhoa(string MaXacThuc, int IDDM_Khoa);

        [OperationContract(Name = "cDNS_DonVi_GetByID")]
        List<sp_NS_DonVi_GetByIDResult> cDNS_DonVi_GetByID(string MaXacThuc, int IDNS_DonVi);

        [OperationContract(Name = "cDNS_DonVi_GetByIDDM_Khoa")]
        List<sp_NS_DonVi_GetByIDDM_KhoaResult> cDNS_DonVi_GetByIDDM_Khoa(string MaXacThuc, int IDDM_Khoa);

        [OperationContract(Name = "cDDM_ChucVu_ChucVu_QuaTrinhBoNhiem_GetBy_IDNS_GiaoVien")]
        List<sp_DM_ChucVu_QuaTrinhBoNhiem_GetBy_IDNS_GiaoVienResult> cDDM_ChucVu_ChucVu_QuaTrinhBoNhiem_GetBy_IDNS_GiaoVien(string MaXacThuc, int IDNS_GiaoVien);

        [OperationContract(Name = "cDDM_Lop_GetTree")]
        List<sp_DM_Lop_GetTreeResult> cDDM_Lop_GetTree(string MaXacThuc, string NamHoc);

        [OperationContract(Name = "cDDM_Lop_GetTreeByIDGiaoVien")]
        List<sp_DM_Lop_GetTreeByIDGiaoVienResult> cDDM_Lop_GetTreeByIDGiaoVien(string MaXacThuc, string NamHoc, int IDNS_GiaoVien, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDDM_Lop_GetTree_ThiSinhTuDo")]
        List<sp_DM_Lop_GetTree_ThiSinhTuDoResult> cDDM_Lop_GetTree_ThiSinhTuDo(string MaXacThuc, string NamHoc);

        [OperationContract(Name = "cDDM_Lop_GetLopGop")]
        List<sp_DM_Lop_GetLopGopResult> cDDM_Lop_GetLopGop(string MaXacThuc, DM_LopInfo pDM_LopInfo, int IDDM_MonHoc, string NamHoc);

        [OperationContract(Name = "cDDM_Lop_GetDanhSachLop")]
        List<DM_LopInfo> cDDM_Lop_GetDanhSachLop(string MaXacThuc, DM_LopInfo pDM_LopInfo, string NamHoc);

        [OperationContract(Name = "cDDM_Lop_GetTongHopXepLoai")]
        List<DM_LopInfo> cDDM_Lop_GetTongHopXepLoai(string MaXacThuc, DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDDM_Lop_GetChon")]
        List<sp_DM_Lop_GetChonResult> cDDM_Lop_GetChon(string MaXacThuc, int IDDM_TrinhDo, string NamHoc);

        [OperationContract(Name = "cDDM_Lop_GetKeHoachToanTruong")]
        List<DM_LopInfo> cDDM_Lop_GetKeHoachToanTruong(string MaXacThuc, int IDNamHoc, string NamHoc, DM_LopInfo pDM_LopInfo);

        [OperationContract(Name = "cDDM_Lop_GetPhanBoPhongHoc")]
        List<DM_LopInfo> cDDM_Lop_GetPhanBoPhongHoc(string MaXacThuc, int IDNamHoc, string NamHoc, int HocKy, int CaHoc, int TuTuan, int DenTuan);

        [OperationContract(Name = "cDDM_Lop_GetChuongTrinhDaoTao")]
        List<sp_DM_Lop_GetChuongTrinhDaoTaoResult> cDDM_Lop_GetChuongTrinhDaoTao(string MaXacThuc, int DM_LopID);

        [OperationContract(Name = "cDDM_Lop_GetGetTongDiemThanhPhan")]
        List<sp_KQHT_DiemThangPhan_GetTong_byIDXL_MonHocTrongKyResult> cDDM_Lop_GetGetTongDiemThanhPhan(string MaXacThuc, int IDXL_MonHocTrongKy);

        [OperationContract(Name = "cDDM_Lop_GetByKhoa")]
        List<sp_DM_Lop_GetByKhoaResult> cDDM_Lop_GetByKhoa(string MaXacThuc, int IDDM_Khoa, string @NamHoc);

        [OperationContract(Name = "cDDM_Lop_Get_TKB")]
        List<sp_DM_Lop_Get_TKBResult> cDDM_Lop_Get_TKB(string MaXacThuc, long IDXL_Tuan);

        [OperationContract(Name = "cDXL_MonHocTrongKy_GetToChucThi")]
        List<sp_XL_MonHocTrongKy_GetToChucThiResult> cDXL_MonHocTrongKy_GetToChucThi(string MaXacThuc, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDXL_MonHocTrongKy_GetMonKy")]
        List<sp_XL_MonHocTrongKy_GetMonKyResult> cDXL_MonHocTrongKy_GetMonKy(string MaXacThuc, int IDDM_Lop, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDXL_MonHocTrongKy_GetMonKyToanKhoaByLop")]
        List<sp_XL_MonHocTrongKy_GetMonKyToanKhoaByLopResult> cDXL_MonHocTrongKy_GetMonKyToanKhoaByLop(string MaXacThuc, int IDDM_Lop);

        [OperationContract(Name = "cDXL_MonHocTrongKy_GetMonKyChuaThucHanh")]
        List<sp_XL_MonHocTrongKy_GetMonKyChuaThucHanhResult> cDXL_MonHocTrongKy_GetMonKyChuaThucHanh(string MaXacThuc, int IDDM_Lop, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDXL_MonHocTrongKy_GetByLop")]
        List<sp_XL_MonHocTrongKy_GetByLopResult> cDXL_MonHocTrongKy_GetByLop(string MaXacThuc, int IDDM_Lop, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDXL_MonHocTrongKy_GetByLopKhoa")]
        List<sp_XL_MonHocTrongKy_GetByLopKhoaResult> cDXL_MonHocTrongKy_GetByLopKhoa(string MaXacThuc, int IDDM_Lop, int IDKhoa_GiaoVu, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDXL_MonHocTrongKy_GetToanKhoa")]
        List<sp_XL_MonHocTrongKy_GetToanKhoaResult> cDXL_MonHocTrongKy_GetToanKhoa(string MaXacThuc, int IDDM_Lop, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDXL_MonHocTrongKy_GetByHocKyNamHoc")]
        List<XL_MonHocTrongKyInfo> cDXL_MonHocTrongKy_GetByHocKyNamHoc(string MaXacThuc, int IDDM_Lop, int HocKy, int IDDM_NamHoc, int IDDM_Khoa, int IDDM_BoMon);

        [OperationContract(Name = "cDXL_MonHocTrongKy_GetByIDGiaoVien")]
        List<sp_XL_MonHocTrongKy_GetByIDGiaoVienResult> cDXL_MonHocTrongKy_GetByIDGiaoVien(string MaXacThuc, int IDNS_GiaoVien, int IDDM_Lop, int HocKy, int IDDM_NamHoc);

        [OperationContract(Name = "cDXL_MonHocTrongKy_GetNhapDuLieuByHocKyNamHoc")]
        List<sp_XL_MonHocTrongKy_GetNhapDuLieuByHocKyNamHocResult> cDXL_MonHocTrongKy_GetNhapDuLieuByHocKyNamHoc(string MaXacThuc, int IDDM_Lop, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDXL_MonHocTrongKy_GetAllByHocKyNamHoc")]
        List<sp_XL_MonHocTrongKy_GetAllByHocKyNamHocResult> cDXL_MonHocTrongKy_GetAllByHocKyNamHoc(string MaXacThuc, int IDDM_Lop, int HocKy, int IDDM_NamHoc);

        [OperationContract(Name = "cDXL_MonHocTrongKy_GetByLopGop")]
        List<XL_MonHocTrongKyInfo> cDXL_MonHocTrongKy_GetByLopGop(string MaXacThuc, string IDDM_Lops, int HocKy, int IDDM_NamHoc, int SoLop);

        [OperationContract(Name = "cDXL_MonHocTrongKy_DeleteByHocKyNamHoc")]
        void cDXL_MonHocTrongKy_DeleteByHocKyNamHoc(string MaXacThuc, int IDDM_Lop, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDXL_MonHocTrongKy_DeleteMonHocNotIn")]
        void cDXL_MonHocTrongKy_DeleteMonHocNotIn(string MaXacThuc, int IDDM_Lop, int IDDM_NamHoc, int HocKy, string IDDM_MonHocs);

        [OperationContract(Name = "cDXL_MonHocTrongKy_UpdateTachGop")]
        void cDXL_MonHocTrongKy_UpdateTachGop(string MaXacThuc, int XL_MonHocTrongKyID, bool HocOLopTachGop);

        [OperationContract(Name = "cDXL_MonHocTrongKy_ApDungCacLopKhac")]
        void cDXL_MonHocTrongKy_ApDungCacLopKhac(string MaXacThuc, int DM_LopID, int DM_LopIDNew, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDXL_MonHocTrongKy_GetDiemMonByIDSV_SinhVienAndIDDM_Lop")]
        List<sp_XL_MonHocTrongKy_GetDiemMonByIDSV_SinhVienAndIDDM_LopResult> cDXL_MonHocTrongKy_GetDiemMonByIDSV_SinhVienAndIDDM_Lop(string MaXacThuc, int IDSV_SinhVien, int IDDM_Lop);

        [OperationContract(Name = "cDDM_PhongHoc_GetChon")]
        List<sp_DM_PhongHoc_GetChonResult> cDDM_PhongHoc_GetChon(string MaXacThuc, int IDToaNha, string mPhongHoc);

        [OperationContract(Name = "cDDM_PhongHoc_GetByIDToaNha")]
        List<sp_DM_PhongHoc_GetByIDToaNhaResult> cDDM_PhongHoc_GetByIDToaNha(string MaXacThuc, int IDDM_ToaNha);

        [OperationContract(Name = "cDDM_PhongHoc_GetKeHoachThucHanh")]
        List<sp_DM_PhongHoc_GetKeHoachThucHanhResult> cDDM_PhongHoc_GetKeHoachThucHanh(string MaXacThuc, int IDDM_NamHoc, string NamHoc);

        [OperationContract(Name = "cDDM_MonHoc_GetDanhSach")]
        List<sp_DM_MonHoc_GetDanhSachResult> cDDM_MonHoc_GetDanhSach(string MaXacThuc, int IDDM_BoMon);

        [OperationContract(Name = "cDDM_MonHoc_GetPhongHoc_MonHoc")]
        List<sp_DM_MonHoc_GetPhongHoc_MonHocResult> cDDM_MonHoc_GetPhongHoc_MonHoc(string MaXacThuc, int SuDungPhong);

        [OperationContract(Name = "cDDM_MonHoc_GetPhongChuyenMon")]
        List<sp_DM_MonHoc_GetPhongChuyenMonResult> cDDM_MonHoc_GetPhongChuyenMon(string MaXacThuc, string IDDM_PhongHocs);

        [OperationContract(Name = "cDDM_MonHoc_GetNotInIDCTKhoiKienThuc")]
        List<sp_DM_MonHoc_GetNotInIDCTKhoiKienThucResult> cDDM_MonHoc_GetNotInIDCTKhoiKienThuc(string MaXacThuc, int IDKQHT_CT_KhoiKienThuc);

        [OperationContract(Name = "cDDM_MonHoc_GetNotInIDNSGiaoVien")]
        List<sp_DM_MonHoc_GetNotInIDGiaoVienResult> cDDM_MonHoc_GetNotInIDNSGiaoVien(string MaXacThuc, int IDNS_GiaoVien);

        [OperationContract(Name = "cDDM_MonHoc_GetMonKyByLop")]
        List<sp_DM_MonHoc_GetMonKyByLopResult> cDDM_MonHoc_GetMonKyByLop(string MaXacThuc, int IDDM_Lop, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDDM_MonHoc_GetMonThiTotNghiep")]
        List<sp_DM_MonHoc_GetMonThiTotNghiepResult> cDDM_MonHoc_GetMonThiTotNghiep(string MaXacThuc, int IDDM_NamHoc);

        [OperationContract(Name = "cDDM_MonHoc_CheckExistByMaMonHoc")]
        string cDDM_MonHoc_CheckExistByMaMonHoc(string MaXacThuc, string MaMonHocs, bool MaMon);

        [OperationContract(Name = "cDDM_MonHoc_AddByImport")]
        int cDDM_MonHoc_AddByImport(string MaXacThuc, DM_MonHocInfo pDM_MonHocInfo, ref string Error);

        [OperationContract(Name = "cDNS_GiaoVien_GetByIDNS_DonVi")]
        List<sp_NS_GiaoVien_GetByIDNS_DonViResult> cDNS_GiaoVien_GetByIDNS_DonVi(string MaXacThuc, int IDNS_DonVi);

        [OperationContract(Name = "cDNS_GiaoVien_GetForLapTaiKhoan")]
        List<sp_NS_GiaoVien_GetForLapTaiKhoanResult> cDNS_GiaoVien_GetForLapTaiKhoan(string MaXacThuc, int IDNS_DonVi, bool ChuaLapTaiKhoan);

        [OperationContract(Name = "cDNS_GiaoVien_NangBacChuyenNgach_GetByIDNS_DonVi")]
        List<sp_NS_GiaoVien_NangBacChuyenNgach_GetByIDNS_DonViResult> cDNS_GiaoVien_NangBacChuyenNgach_GetByIDNS_DonVi(string MaXacThuc, int IDNS_DonVi);

        [OperationContract(Name = "cDNS_GiaoVien_GetGiaoVien_DangGiangDay_ByIDNS_DonVi")]
        List<sp_NS_GiaoVien_DangGiangDay_GetByIDNS_DonViResult> cDNS_GiaoVien_GetGiaoVien_DangGiangDay_ByIDNS_DonVi(string MaXacThuc, int IDNS_DonVi);

        [OperationContract(Name = "cDNS_GiaoVien_GetByIDNS_DonVi_ChucDanh")]
        List<sp_GG_GiaoVien_GetBy_DonVi_ChucDanhResult> cDNS_GiaoVien_GetByIDNS_DonVi_ChucDanh(string MaXacThuc, int IDNS_DonVi, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDNS_GiaoVien_TongHopGioGiang")]
        List<NS_GiaoVienInfo> cDNS_GiaoVien_TongHopGioGiang(string MaXacThuc, int IDNS_DonVi, int NamHoc);

        [OperationContract(Name = "cDNS_GiaoVien_ChiTietGioGiang")]
        List<NS_GiaoVienInfo> cDNS_GiaoVien_ChiTietGioGiang(string MaXacThuc, int IDNS_GiaoVien, int NamHoc);

        [OperationContract(Name = "cDNS_GiaoVien_Get_TKB")]
        List<sp_NS_GiaoVien_Get_TKBResult> cDNS_GiaoVien_Get_TKB(string MaXacThuc, int IDNS_DonVi);

        [OperationContract(Name = "cDNS_GiaoVien_GetByUsername")]
        List<sp_NS_GiaoVien_GetByUserNameResult> cDNS_GiaoVien_GetByUsername(string MaXacThuc, string Username);

        [OperationContract(Name = "cDNS_GiaoVien_TimKiem")]
        List<NS_GiaoVienInfo> cDNS_GiaoVien_TimKiem(string MaXacThuc, NS_GiaoVienInfo pNS_GiaoVienInfo);

        [OperationContract(Name = "cDNS_GiaoVien_GetBaoCaoChatLuongCanBo")]
        List<sp_NS_GiaoVien_GetBaoCaoChatLuongCanBoResult> cDNS_GiaoVien_GetBaoCaoChatLuongCanBo(string MaXacThuc, DateTime DenNgay);

        [OperationContract(Name = "cDNS_GiaoVien_GetBaoCaoChatLuongDoiNguGiaoVien")]
        DataSet cDNS_GiaoVien_GetBaoCaoChatLuongDoiNguGiaoVien(string MaXacThuc, DateTime DenNgay);

        [OperationContract(Name = "cDNS_GiaoVien_UpdateDanhSach")]
        List<NS_GiaoVienInfo> cDNS_GiaoVien_UpdateDanhSach(string MaXacThuc, int IDNS_DonVi, string ChuoiNS_GiaoVienID);

        [OperationContract(Name = "cDNS_GiaoVien_UpdatePassword")]
        List<NS_GiaoVienInfo> cDNS_GiaoVien_UpdatePassword(string MaXacThuc, int IDNS_GiaoVien, string Password);

        [OperationContract(Name = "cDNS_GiaoVien_UpdateTaiKhoan")]
        string cDNS_GiaoVien_UpdateTaiKhoan(string MaXacThuc, string Username, string Password, int NS_GiaoVienID);

        [OperationContract(Name = "cDNS_GiaoVien_UpdateIDDM_Khoa_GiaoVu")]
        void cDNS_GiaoVien_UpdateIDDM_Khoa_GiaoVu(string MaXacThuc, int IDDM_Khoa_GiaoVu, int NS_GiaoVienID);

        [OperationContract(Name = "cDNS_GiaoVien_UpdateAnhGiaoVien")]
        void cDNS_GiaoVien_UpdateAnhGiaoVien(string MaXacThuc, byte[] Anh, int NS_GiaoVienID);

        [OperationContract(Name = "cDNS_GiaoVien_UpdateDonVi")]
        void cDNS_GiaoVien_UpdateDonVi(string MaXacThuc, int NS_GiaoVienID, int IDNS_DonVi);

        [OperationContract(Name = "cDNS_GiaoVien_GetHoSo")]
        List<sp_NS_GiaoVien_GetHoSoResult> cDNS_GiaoVien_GetHoSo(string MaXacThuc, int NS_GiaoVienID);

        [OperationContract(Name = "cDNS_GiaoVien_CheckExistByMaGiaoVien")]
        string cDNS_GiaoVien_CheckExistByMaGiaoVien(string MaXacThuc, string MaGiaoViens);

        [OperationContract(Name = "cDNS_GiaoVien_Get_QuaTrinhBoiDuong")]
        List<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhBoiDuongResult> cDNS_GiaoVien_Get_QuaTrinhBoiDuong(string MaXacThuc, int IDNS_GiaoVien);

        [OperationContract(Name = "cDNS_GiaoVien_Get_QuaTrinhBoNhiemChucVu")]
        List<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhBoNhiemChucVuResult> cDNS_GiaoVien_Get_QuaTrinhBoNhiemChucVu(string MaXacThuc, int IDNS_GiaoVien);

        [OperationContract(Name = "cDNS_GiaoVien_Get_QuaTrinhCongTac")]
        List<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhCongTacResult> cDNS_GiaoVien_Get_QuaTrinhCongTac(string MaXacThuc, int IDNS_GiaoVien);

        [OperationContract(Name = "cDNS_GiaoVien_Get_QuaTrinhKhenThuong")]
        List<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhKhenThuongResult> cDNS_GiaoVien_Get_QuaTrinhKhenThuong(string MaXacThuc, int IDNS_GiaoVien);

        [OperationContract(Name = "cDNS_GiaoVien_Get_QuaTrinhKyLuat")]
        List<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhKyLuatResult> cDNS_GiaoVien_Get_QuaTrinhKyLuat(string MaXacThuc, int IDNS_GiaoVien);

        [OperationContract(Name = "cDNS_GiaoVien_Get_QuaTrinhLuanChuyen")]
        List<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhLuanChuyenResult> cDNS_GiaoVien_Get_QuaTrinhLuanChuyen(string MaXacThuc, int IDNS_GiaoVien);

        [OperationContract(Name = "cDNS_GiaoVien_Get_QuaTrinhMienNhiemTuChuc")]
        List<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhMienNhiemTuChucResult> cDNS_GiaoVien_Get_QuaTrinhMienNhiemTuChuc(string MaXacThuc, int IDNS_GiaoVien);

        [OperationContract(Name = "cDNS_GiaoVien_Get_QuaTrinhThamGiaLLVT")]
        List<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhThamGiaLLVTResult> cDNS_GiaoVien_Get_QuaTrinhThamGiaLLVT(string MaXacThuc, int IDNS_GiaoVien);

        [OperationContract(Name = "cDNS_GiaoVien_Get_QuaTrinhThamGiaTCCTXH")]
        List<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhThamGiaTCCTXHResult> cDNS_GiaoVien_Get_QuaTrinhThamGiaTCCTXH(string MaXacThuc, int IDNS_GiaoVien);

        [OperationContract(Name = "cDNS_GiaoVien_LocGiaoVien")]
        List<NS_GiaoVienInfo> cDNS_GiaoVien_LocGiaoVien(string MaXacThuc, int IDNS_DonVi, string HoTen);

        [OperationContract(Name = "cDNS_GiaoVien_GetMaLonNhat")]
        List<sp_NS_GiaoVien_GetMaLonNhatResult> cDNS_GiaoVien_GetMaLonNhat(string MaXacThuc, int DoDaiMa, string PhanDauMa, string PhanCuoiMa);

        [OperationContract(Name = "cDNS_GiaoVien_UpdateMaGiaoVien")]
        int cDNS_GiaoVien_UpdateMaGiaoVien(string MaXacThuc, string MaGiaoVien, int NS_GiaoVienID);

        [OperationContract(Name = "cDNS_GiaoVien_Get_SoYeuLyLich")]
        List<sp_NS_GiaoVien_Get_SoYeuLyLichResult> cDNS_GiaoVien_Get_SoYeuLyLich(string MaXacThuc, int NS_GiaoVienID);

        [OperationContract(Name = "cDNS_GiaoVien_Get_CanhBaoHanNghiHuu")]
        List<sp_NS_GiaoVien_Get_CanhBaoHanNghiHuuResult> cDNS_GiaoVien_Get_CanhBaoHanNghiHuu(string MaXacThuc, int HanCanhBao, DateTime TinhDenNgay);

        [OperationContract(Name = "cDNS_GiaoVien_Get_CanhBaoHetNhiemKy")]
        List<sp_NS_GiaoVien_Get_CanhBaoHetNhiemKyResult> cDNS_GiaoVien_Get_CanhBaoHetNhiemKy(string MaXacThuc, int HanCanhBao, DateTime TinhDenNgay);

        [OperationContract(Name = "cDKQHT_ThanhPhanDiem_GetByIDTrinhDo")]
        List<sp_KQHT_ThanhPhanDiem_GetByIDTrinhDoResult> cDKQHT_ThanhPhanDiem_GetByIDTrinhDo(string MaXacThuc, int IDDM_TrinhDo);

        [OperationContract(Name = "cDTC_LoaiThuChi_GetBy_IDNamHoc_HocKy")]
        List<sp_TC_LoaiThuChi_GetBy_IDNamHoc_HocKyResult> cDTC_LoaiThuChi_GetBy_IDNamHoc_HocKy(string MaXacThuc, int IDNamHoc, int HocKy, bool HasParent);

        [OperationContract(Name = "cDDM_TinhHuyenXa_GetByCap")]
        List<sp_DM_TinhHuyenXa_GetByCapResult> cDDM_TinhHuyenXa_GetByCap(string MaXacThuc, int Level, int ParentID);

        [OperationContract(Name = "cDDM_TinhHuyenXa_GetTinh")]
        List<sp_DM_TinhHuyenXa_GetTinhResult> cDDM_TinhHuyenXa_GetTinh(string MaXacThuc, int DM_TinhHuyenXaID);

        [OperationContract(Name = "cDDM_TinhHuyenXa_CheckExistByMa")]
        string cDDM_TinhHuyenXa_CheckExistByMa(string MaXacThuc, string Mas);

        [OperationContract(Name = "cDDM_TinhHuyenXa_AddByImport")]
        int cDDM_TinhHuyenXa_AddByImport(string MaXacThuc, DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo, string MaCha);


        [OperationContract(Name = "cDHT_User_UpdateChucNang")]
        void cDHT_User_UpdateChucNang(string MaXacThuc, int HT_UserID, int IDHT_UserGroup);

        [OperationContract(Name = "cDHT_User_GetChucNang")]
        List<sp_HT_User_GetChucNangResult> cDHT_User_GetChucNang(string MaXacThuc, string UserName);

        [OperationContract(Name = "cDHT_User_GetByUserName")]
        List<sp_HT_User_GetByUserNameResult> cDHT_User_GetByUserName(string MaXacThuc, string UserName);


        [OperationContract(Name = "cDHT_ThamSoHeThong_GetByMaThamSo")]
        List<sp_HT_ThamSoHeThong_GetByMaThamSoResult> cDHT_ThamSoHeThong_GetByMaThamSo(string MaXacThuc, string MaThamSoHeThong);

        [OperationContract(Name = "cDHT_ThamSoHeThong_GetByPhanHe")]
        List<sp_HT_ThamSoHeThong_GetByPhanHeResult> cDHT_ThamSoHeThong_GetByPhanHe(string MaXacThuc, int PhanHe);



















        [OperationContract(Name = "cDKQHT_ChuongTrinhDaoTao_GetDanhSach")]
        List<sp_KQHT_ChuongTrinhDaoTao_GetDanhSachResult> cDKQHT_ChuongTrinhDaoTao_GetDanhSach(string MaXacThuc, int IDDM_TrinhDo);

        [OperationContract(Name = "cDKQHT_ChuongTrinhDaoTao_GetChiTiet")]
        List<sp_KQHT_ChuongTrinhDaoTao_GetChiTietResult> cDKQHT_ChuongTrinhDaoTao_GetChiTiet(string MaXacThuc, int KQHT_ChuongTrinhDaoTaoID);

        [OperationContract(Name = "cDKQHT_ChuongTrinhDaoTao_GetLop")]
        List<sp_KQHT_ChuongTrinhDaoTao_GetLopResult> cDKQHT_ChuongTrinhDaoTao_GetLop(string MaXacThuc, int IDKQHT_ChuongTrinhDaoTao);

        [OperationContract(Name = "cDKQHT_ChuongTrinhDaoTao_GetMonKhung")]
        List<sp_KQHT_ChuongTrinhDaoTao_GetMonKhungResult> cDKQHT_ChuongTrinhDaoTao_GetMonKhung(string MaXacThuc, int KQHT_ChuongTrinhDaoTaoID, int IDDM_Lop, int HocKy);

        [OperationContract(Name = "cDKQHT_ChuongTrinhDaoTao_GetMonChuaToChuc")]
        List<sp_KQHT_ChuongTrinhDaoTao_GetMonChuaToChucResult> cDKQHT_ChuongTrinhDaoTao_GetMonChuaToChuc(string MaXacThuc, int KQHT_ChuongTrinhDaoTaoID, int IDDM_Lop, int CTDT_HocKy);


        [OperationContract(Name = "cDKQHT_MonHoc_CT_KhoiKienThuc_GetDanhSach")]
        List<sp_KQHT_MonHoc_CT_KhoiKienThuc_GetDanhSachResult> cDKQHT_MonHoc_CT_KhoiKienThuc_GetDanhSach(string MaXacThuc, int IDKQHT_CT_KhoiKienThuc);


        [OperationContract(Name = "cDXL_PhanCongGiaoVien_DeleteByMonHoc")]
        void cDXL_PhanCongGiaoVien_DeleteByMonHoc(string MaXacThuc, int IDXL_MonHocTrongKy, string IDNS_GiaoViens);

        [OperationContract(Name = "cDXL_PhanCongGiaoVien_GetByMonHocTrongKy")]
        List<sp_XL_PhanCongGiaoVien_GetByMonHocTrongKyResult> cDXL_PhanCongGiaoVien_GetByMonHocTrongKy(string MaXacThuc, int IDXL_MonHocTrongKy);

        [OperationContract(Name = "cDXL_PhanCongGiaoVien_GetGiaoVien")]
        List<sp_XL_PhanCongGiaoVien_GetGiaoVienResult> cDXL_PhanCongGiaoVien_GetGiaoVien(string MaXacThuc, int IDXL_MonHocTrongKy, int IDNS_GiaoVien);

        [OperationContract(Name = "cDXL_PhanCongGiaoVien_GetGiaoVienByMonHocTrongKy")]
        List<sp_XL_PhanCongGiaoVien_GetGiaoVienByMonHocTrongKyResult> cDXL_PhanCongGiaoVien_GetGiaoVienByMonHocTrongKy(string MaXacThuc, int IDXL_MonHocTrongKy);






        [OperationContract(Name = "cDKQHT_CTDT_ChiTiet_DeleteByHocKy")]
        void cDKQHT_CTDT_ChiTiet_DeleteByHocKy(string MaXacThuc, KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo);



        [OperationContract(Name = "cDKQHT_CT_KhoiKienThuc_GetDanhSach")]
        List<sp_KQHT_CT_KhoiKienThuc_GetDanhSachResult> cDKQHT_CT_KhoiKienThuc_GetDanhSach(string MaXacThuc, int IDDM_KhoiKienThuc);

        [OperationContract(Name = "cDKQHT_CT_KhoiKienThuc_GetChon")]
        List<sp_KQHT_CT_KhoiKienThuc_GetChonResult> cDKQHT_CT_KhoiKienThuc_GetChon(string MaXacThuc, int IDKQHT_ChuongTrinhDaoTao);

        [OperationContract(Name = "cDKQHT_CT_KhoiKienThuc_AddKeThua")]
        int cDKQHT_CT_KhoiKienThuc_AddKeThua(string MaXacThuc, KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo, int IDKQHT_CT_KhoiKienThucGoc);




        [OperationContract(Name = "cDXL_PhongHoc_MonHoc_GetByIDDM_MonHoc")]
        List<sp_XL_PhongHoc_MonHoc_GetByIDMonHocResult> cDXL_PhongHoc_MonHoc_GetByIDDM_MonHoc(string MaXacThuc, int IDDM_MonHoc);

        [OperationContract(Name = "cDXL_PhongHoc_MonHoc_DeleteByMonPhong")]
        void cDXL_PhongHoc_MonHoc_DeleteByMonPhong(string MaXacThuc, int IDDM_PhongHoc, int IDDM_MonHoc);

        [OperationContract(Name = "cDXL_GiaoVien_MonHoc_GetDanhSach")]
        List<sp_XL_GiaoVien_MonHoc_GetDanhSachResult> cDXL_GiaoVien_MonHoc_GetDanhSach(string MaXacThuc, XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo);

        [OperationContract(Name = "cDXL_GiaoVien_MonHoc_GetByIDDM_MonHoc")]
        List<sp_XL_GiaoVien_MonHoc_GetByIDDM_MonHocResult> cDXL_GiaoVien_MonHoc_GetByIDDM_MonHoc(string MaXacThuc, int IDDM_MonHoc, string IDNS_GiaoVien);

        [OperationContract(Name = "cDXL_GiaoVien_MonHoc_GetByIDDM_MonHocs")]
        List<XL_GiaoVien_MonHocInfo> cDXL_GiaoVien_MonHoc_GetByIDDM_MonHocs(string MaXacThuc, string IDDM_MonHocs);

        [OperationContract(Name = "cDXL_GiaoVien_MonHoc_GetByMonLop")]
        List<sp_XL_GiaoVien_MonHoc_GetByMonLopResult> cDXL_GiaoVien_MonHoc_GetByMonLop(string MaXacThuc, int IDDM_Lop, int IDDM_NamHoc, int HocKy);


        [OperationContract(Name = "cDKQHT_DiemThi_GetDanhSach")]
        List<sp_KQHT_DiemThi_GetDanhSachResult> cDKQHT_DiemThi_GetDanhSach(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy, int LanThi);

        [OperationContract(Name = "cDKQHT_DiemThi_GetByLop")]
        List<sp_KQHT_DiemThi_GetByLopResult> cDKQHT_DiemThi_GetByLop(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDKQHT_DiemThi_ChoNhapLaiDiem_GetByLop")]
        List<sp_KQHT_DiemThi_ChoNhapLaiDiem_GetByLopResult> cDKQHT_DiemThi_ChoNhapLaiDiem_GetByLop(string MaXacThuc, int IDKQHT_ChoNhapLaiDiem);

        [OperationContract(Name = "cDKQHT_DiemThi_GetDanhSachThiLai")]
        List<sp_KQHT_DiemThi_GetDanhSachThiLaiResult> cDKQHT_DiemThi_GetDanhSachThiLai(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi);

        [OperationContract(Name = "cDKQHT_DiemThi_GetDanhSachKhongQua")]
        List<sp_KQHT_DiemThi_GetDanhSachKhongQuaResult> cDKQHT_DiemThi_GetDanhSachKhongQua(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi);

        [OperationContract(Name = "cDKQHT_DiemThi_GetSinhVien")]
        List<KQHT_DiemThiInfo> cDKQHT_DiemThi_GetSinhVien(string MaXacThuc, int KQHT_ToChucThiID);

        [OperationContract(Name = "cDKQHT_DiemThi_DeleteByInfo")]
        void cDKQHT_DiemThi_DeleteByInfo(string MaXacThuc, KQHT_DiemThiInfo pKQHT_DiemThiInfo);

        [OperationContract(Name = "cDKQHT_DiemThanhPhan_GetDanhSach")]
        List<sp_KQHT_DiemThanhPhan_GetDanhSachResult> cDKQHT_DiemThanhPhan_GetDanhSach(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int XL_MonHocTrongKyID, int IDDM_NamHoc, int HocKy, int LanThi, int KQHT_ChoNhapLaiDiemID);

        [OperationContract(Name = "cDKQHT_DiemThanhPhan_ChoNhapLaiDiem_GetDanhSach")]
        List<sp_KQHT_DiemThanhPhan_ChoNhapLaiDiem_GetDanhSachResult> cDKQHT_DiemThanhPhan_ChoNhapLaiDiem_GetDanhSach(string MaXacThuc, int IDKQHT_ChoNhapLaiDiem);

        [OperationContract(Name = "cDKQHT_DiemThanhPhan_KiemTraDiem")]
        List<sp_KQHT_DiemThanhPhan_KiemTraDiemResult> cDKQHT_DiemThanhPhan_KiemTraDiem(string MaXacThuc, int IDSV_SinhVien, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDKQHT_DiemThanhPhan_DeleteBy_SinhVien")]
        void cDKQHT_DiemThanhPhan_DeleteBy_SinhVien(string MaXacThuc, int IDSV_SinhVien, int LanThi, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int IDKQHT_ThanhPhanDiem);

        [OperationContract(Name = "cDKQHT_DiemThanhPhan_DeleteByInfo")]
        void cDKQHT_DiemThanhPhan_DeleteByInfo(string MaXacThuc, KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo);

        [OperationContract(Name = "cDKQHT_DiemThanhPhan_AddByImport")]
        int cDKQHT_DiemThanhPhan_AddByImport(string MaXacThuc, KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo, int LanThi, string MaSinhVien);

        [OperationContract(Name = "cDKQHT_DiemTongKetMon_GetDanhSach")]
        List<sp_KQHT_DiemTongKetMon_GetDanhSachResult> cDKQHT_DiemTongKetMon_GetDanhSach(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi, int Kieu);

        [OperationContract(Name = "cDKQHT_DiemTongKetMon_GetDanhSachNhapDiem")]
        List<sp_KQHT_DiemTongKetMon_GetDanhSachNhapDiemResult> cDKQHT_DiemTongKetMon_GetDanhSachNhapDiem(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy, int LanThi);

        [OperationContract(Name = "cDKQHT_DiemTongKetMon_GetByLop")]
        List<sp_KQHT_DiemTongKetMon_GetByLopResult> cDKQHT_DiemTongKetMon_GetByLop(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDKQHT_DiemTongKetMon_ChoNhapLaiDiem_GetByLop")]
        List<sp_KQHT_DiemTongKetMon_ChoNhapLaiDiem_GetByLopResult> cDKQHT_DiemTongKetMon_ChoNhapLaiDiem_GetByLop(string MaXacThuc, int IDKQHT_ChoNhapLaiDiem);

        [OperationContract(Name = "cDKQHT_DiemTongKetMon_GetMonKy")]
        List<sp_KQHT_DiemTongKetMon_GetMonKyResult> cDKQHT_DiemTongKetMon_GetMonKy(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi);

        [OperationContract(Name = "cDKQHT_DiemTongKetMon_GetSoMonCoDiemByLop")]
        List<sp_KQHT_DiemTongKetMon_GetSoMonCoDiemByLopResult> cDKQHT_DiemTongKetMon_GetSoMonCoDiemByLop(string MaXacThuc, int IDDM_Lop, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDKQHT_DiemTongKetMon_GetDiemThucTapTotNghiep")]
        List<KQHT_DiemTongKetMonInfo> cDKQHT_DiemTongKetMon_GetDiemThucTapTotNghiep(string MaXacThuc, DM_LopInfo pDM_LopInfo);

        [OperationContract(Name = "cDKQHT_DiemTongKetMon_AddByImport")]
        int cDKQHT_DiemTongKetMon_AddByImport(string MaXacThuc, KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo, string MaSinhVien);

        [OperationContract(Name = "cDKQHT_DiemTongKetMon_DeleteByIDMonHocTrongKy")]
        void cDKQHT_DiemTongKetMon_DeleteByIDMonHocTrongKy(string MaXacThuc, int IDSV_SinhVien, long IDXL_MonHocTrongKy, int LanThi);

        [OperationContract(Name = "cDKQHT_DiemDanh_GetDanhSach")]
        List<sp_KQHT_DiemDanh_GetDanhSachResult> cDKQHT_DiemDanh_GetDanhSach(string MaXacThuc, int IDDM_Lop, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDKQHT_DiemDanh_GetByLop")]
        List<sp_KQHT_DiemDanh_GetByLopResult> cDKQHT_DiemDanh_GetByLop(string MaXacThuc, int IDDM_Lop, int IDXL_MonHocTrongKy, int DiemLan);

        [OperationContract(Name = "cDKQHT_DiemDanh_ChoNhapLaiDiem_GetByLop")]
        List<sp_KQHT_DiemDanh_ChoNhapLaiDiem_GetByLopResult> cDKQHT_DiemDanh_ChoNhapLaiDiem_GetByLop(string MaXacThuc, int IDKQHT_ChoNhapLaiDiem);

        [OperationContract(Name = "cDKQHT_DiemDanh_DeleteByInfo")]
        void cDKQHT_DiemDanh_DeleteByInfo(string MaXacThuc, int IDSV_SinhVien, int IDXL_MonHocTrongKy, string LyDo, int DiemLan);

        [OperationContract(Name = "cDKQHT_DanhSachDuThi_GetByIDToChucThi")]
        List<sp_KQHT_DanhSachDuThi_GetByIDToChucThiResult> cDKQHT_DanhSachDuThi_GetByIDToChucThi(string MaXacThuc, int IDKQHT_ToChucThi);

        [OperationContract(Name = "cDKQHT_DanhSachDuThi_GetDanhSach")]
        List<sp_KQHT_DanhSachDuThi_GetDanhSachResult> cDKQHT_DanhSachDuThi_GetDanhSach(string MaXacThuc, int IDDM_Lop, long IDXL_MonHocTrongKy, int LanThi);

        [OperationContract(Name = "cDKQHT_DanhSachDuThi_GetNhapDiem")]
        List<sp_KQHT_DanhSachDuThi_GetNhapDiemResult> cDKQHT_DanhSachDuThi_GetNhapDiem(string MaXacThuc, long IDXL_MonHocTrongKy, int LanThi);

        [OperationContract(Name = "cDKQHT_DanhSachDuThi_GetDaChuyenDiemByMonHocTrongKy")]
        List<sp_KQHT_DanhSachDuThi_GetDaChuyenDiemByMonHocTrongKyResult> cDKQHT_DanhSachDuThi_GetDaChuyenDiemByMonHocTrongKy(string MaXacThuc, long IDXL_MonHocTrongKy, int LanThi);

        [OperationContract(Name = "cDKQHT_DanhSachDuThi_UpdateSoPhach")]
        void cDKQHT_DanhSachDuThi_UpdateSoPhach(string MaXacThuc, string SoPhach, int TuiThiSo, double KQHT_DanhSachDuThiID);

        [OperationContract(Name = "cDKQHT_DanhSachDuThi_UpdateDiem")]
        void cDKQHT_DanhSachDuThi_UpdateDiem(string MaXacThuc, double Diem, double KQHT_DanhSachDuThiID);

        [OperationContract(Name = "cDKQHT_DanhSachDuThi_UpdateDaChuyenDiem")]
        void cDKQHT_DanhSachDuThi_UpdateDaChuyenDiem(string MaXacThuc, bool IsDaChuyen, double IDXL_MonHocTrongKy, int LanThi);

        [OperationContract(Name = "cDKQHT_DanhSachDuThi_UpdateDaChuyenDiemByToChucThi")]
        void cDKQHT_DanhSachDuThi_UpdateDaChuyenDiemByToChucThi(string MaXacThuc, bool IsDaChuyen, int IDKQHT_ToChucThi, int LanThi);

        [OperationContract(Name = "cDKQHT_DanhSachDuThi_UpdateSoPhachMonLop")]
        void cDKQHT_DanhSachDuThi_UpdateSoPhachMonLop(string MaXacThuc, int IDSV_SinhVien, string SoPhach, long IDXL_MonHocTrongKy, int LanThi, int MucPhatQuyChe, string LyDoViPhamQuyChe);

        [OperationContract(Name = "cDKQHT_DanhSachDuThi_HuyPhachMonLop")]
        void cDKQHT_DanhSachDuThi_HuyPhachMonLop(string MaXacThuc, long IDXL_MonHocTrongKy, int LanThi);

        [OperationContract(Name = "cDKQHT_DaChuyenDiem_GetByIDMonHocTrongKy")]
        List<sp_KQHT_DaChuyenDiem_GetByIDMonHocTrongKyResult> cDKQHT_DaChuyenDiem_GetByIDMonHocTrongKy(string MaXacThuc, int IDXL_MonHocTrongKy);

        [OperationContract(Name = "cDKQHT_DaChuyenDiem_AddChuyen")]
        int cDKQHT_DaChuyenDiem_AddChuyen(string MaXacThuc, KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo);

        [OperationContract(Name = "cDKQHT_DaChuyenDiem_UpdateTrangThaiChuyen")]
        void cDKQHT_DaChuyenDiem_UpdateTrangThaiChuyen(string MaXacThuc, KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo);

        [OperationContract(Name = "cDKQHT_DaChuyenDiem_GetLichSuSuaDiem")]
        List<sp_KQHT_DaChuyenDiem_GetLichSuSuaDiemResult> cDKQHT_DaChuyenDiem_GetLichSuSuaDiem(string MaXacThuc, int IDXL_MonHocTrongKy);




        [OperationContract(Name = "cDKQHT_MonThiTotNghiep_Lop_GetAllMon")]
        List<sp_KQHT_MonThiTotNghiep_Lop_GetAllMonResult> cDKQHT_MonThiTotNghiep_Lop_GetAllMon(string MaXacThuc, int IDDM_NamHoc);

        [OperationContract(Name = "cDKQHT_MonThiTotNghiep_Lop_GetIn_Mon")]
        List<sp_KQHT_MonThiTotNghiep_Lop_GetIn_MonResult> cDKQHT_MonThiTotNghiep_Lop_GetIn_Mon(string MaXacThuc, int IDDM_Lop);

        [OperationContract(Name = "cDKQHT_MonThiTotNghiep_Lop_GetNotIn_Mon")]
        List<sp_KQHT_MonThiTotNghiep_Lop_GetNotIn_MonResult> cDKQHT_MonThiTotNghiep_Lop_GetNotIn_Mon(string MaXacThuc, int IDDM_Lop);

        [OperationContract(Name = "cDKQHT_MonThiTotNghiep_Lop_Delete_ByLop")]
        void cDKQHT_MonThiTotNghiep_Lop_Delete_ByLop(string MaXacThuc, int IDDM_Lop);

        [OperationContract(Name = "cDKQHT_DanhSachKhongThi_GetIn_SinhVien")]
        List<sp_KQHT_DanhSachKhongThi_GetIn_SinhVienResult> cDKQHT_DanhSachKhongThi_GetIn_SinhVien(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi);

        [OperationContract(Name = "cDKQHT_DanhSachKhongThi_GetNotIn_SinhVien")]
        List<sp_KQHT_DanhSachKhongThi_GetNotIn_SinhVienResult> cDKQHT_DanhSachKhongThi_GetNotIn_SinhVien(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi);

        [OperationContract(Name = "cDKQHT_DanhSachKhongThi_AddTuDong")]
        int cDKQHT_DanhSachKhongThi_AddTuDong(string MaXacThuc, KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo);

        [OperationContract(Name = "cDKQHT_DanhSachKhongThi_DeleteTuDong")]
        void cDKQHT_DanhSachKhongThi_DeleteTuDong(string MaXacThuc, KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo);

        [OperationContract(Name = "cDKQHT_DanhSachKhongThi_DeleteDanhSachDuThi")]
        void cDKQHT_DanhSachKhongThi_DeleteDanhSachDuThi(string MaXacThuc, KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo, int IDXL_MonHocTrongKy);

        [OperationContract(Name = "cDGG_DinhMucGioDay_GetByIDNS_DonVi")]
        List<sp_GG_DinhMucGioDay_GetByIDNS_DonViResult> cDGG_DinhMucGioDay_GetByIDNS_DonVi(string MaXacThuc, int IDNS_DonVi, int IDDM_NamHoc, int HocKy);





        [OperationContract(Name = "cDGG_CongViecGiaoVien_Get")]
        List<sp_GG_CongViecGiaoVien_GetResult> cDGG_CongViecGiaoVien_Get(string MaXacThuc, int IDNS_GiaoVien, int IDNamHoc);

        [OperationContract(Name = "cDGG_CongViecGiaoVien_GetByHocKy")]
        List<sp_GG_CongViecGiaoVien_GetAllByHocKyResult> cDGG_CongViecGiaoVien_GetByHocKy(string MaXacThuc, int IDDM_NamHoc, int HocKy, int IDNS_DonVi);

        [OperationContract(Name = "cDGG_CongViecGiaoVien_GetByIDDM_LoaiCongViec")]
        List<sp_GG_CongViecGiaoVien_GetByIDDM_LoaiCongViecResult> cDGG_CongViecGiaoVien_GetByIDDM_LoaiCongViec(string MaXacThuc, int IDDM_LoaiCongViec, int IDNS_DonVi, int IDDM_NamHoc, int HocKy);

        [OperationContract(Name = "cDGG_CongViecGiaoVien_UpdateAdd")]
        long cDGG_CongViecGiaoVien_UpdateAdd(string MaXacThuc, GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo);

        [OperationContract(Name = "cDGG_CongViecGiaoVien_DeleteNotIn")]
        void cDGG_CongViecGiaoVien_DeleteNotIn(string MaXacThuc, int IDNS_GiaoVien, int IDDM_NamHoc, int HocKy, string IDCVNotIn);

        [OperationContract(Name = "cDGG_GiangDayGiaoVien_GetBangTongHop")]
        List<sp_GG_GiangDayGiaoVien_GetBangTongHopResult> cDGG_GiangDayGiaoVien_GetBangTongHop(string MaXacThuc, int IDNS_DonVi, string TenDonVi, int IDDM_NamHoc, string TenNamHoc, int HocKy);

        [OperationContract(Name = "cDGG_GiangDayGiaoVien_UpdateAdd")]
        long cDGG_GiangDayGiaoVien_UpdateAdd(string MaXacThuc, GG_GiangDayGiaoVienInfo pGG_GiangDayGiaoVienInfo);

        [OperationContract(Name = "cDGG_GiangDayGiaoVien_DeleteNotIn")]
        void cDGG_GiangDayGiaoVien_DeleteNotIn(string MaXacThuc, int IDNS_GiaoVien, int IDDM_NamHoc, int HocKy, string IDGGNotIn);



        [OperationContract(Name = "cDGG_HeSoLopDongTheoKhoa_GetAll")]
        List<sp_GG_HeSoLopDongTheoKhoa_GetAllResult> cDGG_HeSoLopDongTheoKhoa_GetAll(string MaXacThuc, int GG_HeSoLopDongTheoKhoaID);


        [OperationContract(Name = "cDHT_Report_GetByName")]
        List<sp_HT_Report_GetByNameResult> cDHT_Report_GetByName(string MaXacThuc, HT_ReportInfo pReportInfo);

        [OperationContract(Name = "cDHT_Report_GetByIDReportMain")]
        List<HT_ReportInfo> cDHT_Report_GetByIDReportMain(string MaXacThuc, int IDHT_Report);

        [OperationContract(Name = "cDHT_Report_GetXtraReport")]
        List<HT_ReportInfo> cDHT_Report_GetXtraReport(string MaXacThuc, int HT_ReportID);

        [OperationContract(Name = "cDBase_CreateParam_2")]
        SqlParameter cDBase_CreateParam(string MaXacThuc, string _TenThamSo, SqlDbType _KieuDuLieu, int _KichThuoc, object _GiaTri);

        [OperationContract(Name = "cDBase_CreateParamOut_2")]
        SqlParameter cDBase_CreateParamOut(string MaXacThuc, string _TenThamSo, SqlDbType _KieuDuLieu, int _KichThuoc);

        [OperationContract(Name = "cDGG_CongViecGiaoVien_Get_2")]
        List<sp_GG_CongViecGiaoVien_GetResult> cDGG_CongViecGiaoVien_Get(string MaXacThuc, GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo);

        [OperationContract(Name = "cDHT_Report_GetByName_2")]
        List<sp_HT_Report_GetByNameResult> cDHT_Report_GetByName(string MaXacThuc, string ReportName);

        [OperationContract(Name = "cDXL_Tuan_GetByTuanThu_2")]
        List<sp_XL_Tuan_GetByTuanThuResult> cDXL_Tuan_GetByTuanThu(string MaXacThuc, int IDNamHoc, int HocKy, int TuTuan);

        [OperationContract(Name = "cDSV_SinhVien_GetByLop")]
        List<sp_SV_SinhVien_GetByLopResult> cDSV_SinhVien_GetByLop(string MaXacThuc, int IDDM_Lop, int TrangThai);

        [OperationContract(Name = "cDSV_SinhVien_GetNextMaSinhVien")]
        string cDSV_SinhVien_GetNextMaSinhVien(string MaXacThuc, int IDDM_Lop, string MaSinhVien, ref int DoDaiTuTang);

        [OperationContract(Name = "cDSV_SinhVien_GetHoSo")]
        List<sp_SV_SinhVien_GetHoSoResult> cDSV_SinhVien_GetHoSo(string MaXacThuc, int SV_SinhVienID);

        [OperationContract(Name = "cDSV_SinhVien_GetDanhSachDuThi")]
        List<SV_SinhVienInfo> cDSV_SinhVien_GetDanhSachDuThi(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi, string DaDangKy, int TotNghiep);

        [OperationContract(Name = "cDSV_SinhVien_GetDanhSachThiLai")]
        List<SV_SinhVienInfo> cDSV_SinhVien_GetDanhSachThiLai(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi, string DaDangKy, int TotNghiep);

        [OperationContract(Name = "cDSV_SinhVien_GetDanhSachDuThiKhoaTruoc")]
        List<SV_SinhVienInfo> cDSV_SinhVien_GetDanhSachDuThiKhoaTruoc(string MaXacThuc, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi, string DaDangKy);

        [OperationContract(Name = "cDSV_SinhVien_GetByLop_Mon")]
        List<sp_SV_SinhVien_GetByLop_MonResult> cDSV_SinhVien_GetByLop_Mon(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int IDKQHT_HoiDongMon);

        [OperationContract(Name = "cDSV_SinhVien_TimKiem")]
        List<sp_SV_SinhVien_TimKiemResult> cDSV_SinhVien_TimKiem(string MaXacThuc, SV_SinhVienInfo pSV_SinhVienInfo);

        [OperationContract(Name = "cDSV_SinhVien_KiemTraMaSV")]
        List<sp_SV_SinhVien_KiemTraMaSVResult> cDSV_SinhVien_KiemTraMaSV(string MaXacThuc, string MaSinhVien);

        [OperationContract(Name = "cDSV_SinhVien_GetSinhVien")]
        List<SV_SinhVienInfo> cDSV_SinhVien_GetSinhVien(string MaXacThuc, DM_LopInfo pDM_LopInfo, string NamHoc, bool ChuaTaoMa);

        [OperationContract(Name = "cDSV_SinhVien_CheckExistByMaSinhVien")]
        string cDSV_SinhVien_CheckExistByMaSinhVien(string MaXacThuc, string MaSinhViens);

        [OperationContract(Name = "cDSV_SinhVien_CheckExistAndGetInfo")]
        string cDSV_SinhVien_CheckExistAndGetInfo(string MaXacThuc, string MaSinhViens, ref string HoVaTens, ref string TenLops);
        [OperationContract(Name = "cDDM_NamHoc_GetKy2")]
        int cDDM_NamHoc_GetKy2(string MaXacThuc, DM_NamHocInfo pNamHocInfo);

        [OperationContract(Name = "cDDM_NamHoc_Get")]
        List<sp_DM_NamHoc_GetResult> cDDM_NamHoc_Get(string MaXacThuc, DM_NamHocInfo pDM_NamHocInfo);

        [OperationContract(Name = "cDDM_BoMon_Get")]
        List<sp_DM_BoMon_GetResult> cDDM_BoMon_Get(string MaXacThuc, DM_BoMonInfo pDM_BoMonInfo);

        [OperationContract(Name = "cDNS_DonVi_Get")]
        List<sp_NS_DonVi_GetResult> cDNS_DonVi_Get(string MaXacThuc, NS_DonViInfo pNS_DonViInfo);

        [OperationContract(Name = "cDDM_MonHoc_Get")]
        List<sp_DM_MonHoc_GetResult> cDDM_MonHoc_Get(string MaXacThuc, DM_MonHocInfo pDM_MonHocInfo);

        [OperationContract(Name = "cDKQHT_ThanhPhanDiem_Get")]
        List<sp_KQHT_ThanhPhanDiem_GetResult> cDKQHT_ThanhPhanDiem_Get(string MaXacThuc, KQHT_ThanhPhanDiemInfo pKQHT_ThanhPhanDiemInfo);

        [OperationContract(Name = "cDKQHT_DiemTongKetMon_Get")]
        List<sp_KQHT_DiemTongKetMon_GetResult> cDKQHT_DiemTongKetMon_Get(string MaXacThuc, KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo);

        [OperationContract(Name = "cDHT_ThamSoHeThong_Get")]
        List<sp_HT_ThamSoHeThong_GetResult> cDHT_ThamSoHeThong_Get(string MaXacThuc, HT_ThamSoHeThongInfo pHT_ThamSoHeThongInfo);

        [OperationContract(Name = "cDHT_ThamSoHeThong_Add")]
        int cDHT_ThamSoHeThong_Add(string MaXacThuc, HT_ThamSoHeThongInfo pHT_ThamSoHeThongInfo);

        [OperationContract(Name = "cDHT_Log_Add")]
        int cDHT_Log_Add(string MaXacThuc, HT_LogInfo pHT_LogInfo);



        [OperationContract(Name = "cDKQHT_DaChuyenDiem_Get")]
        List<sp_KQHT_DaChuyenDiem_GetResult> cDKQHT_DaChuyenDiem_Get(string MaXacThuc, KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo);

        [OperationContract(Name = "cDKQHT_DaChuyenDiem_Add")]
        int cDKQHT_DaChuyenDiem_Add(string MaXacThuc, KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo);

        [OperationContract(Name = "cDKQHT_DaChuyenDiem_Update")]
        void cDKQHT_DaChuyenDiem_Update(string MaXacThuc, KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo);

        [OperationContract(Name = "cDKQHT_DaChuyenDiem_Delete")]
        void cDKQHT_DaChuyenDiem_Delete(string MaXacThuc, KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo);
        [OperationContract(Name = "cDKQHT_DiemTongKetMon_Add")]
        void cDKQHT_DiemTongKetMon_Add(string MaXacThuc, KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo);




        [OperationContract(Name = "cDKQHT_DiemThanhPhan_Get")]
        List<sp_KQHT_DiemThanhPhan_GetResult> cDKQHT_DiemThanhPhan_Get(string MaXacThuc, KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo);

        [OperationContract(Name = "cDKQHT_DiemThanhPhan_Add")]
        int cDKQHT_DiemThanhPhan_Add(string MaXacThuc, KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo);

        [OperationContract(Name = "cDKQHT_DiemThanhPhan_Update")]
        void cDKQHT_DiemThanhPhan_Update(string MaXacThuc, KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo);

        [OperationContract(Name = "cDKQHT_DiemThanhPhan_Delete")]
        void cDKQHT_DiemThanhPhan_Delete(string MaXacThuc, KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo);


        

        [OperationContract(Name = "cDKQHT_MonHoc_CT_KhoiKienThuc_Get")]
        List<sp_KQHT_MonHoc_CT_KhoiKienThuc_GetResult> cDKQHT_MonHoc_CT_KhoiKienThuc_Get(string MaXacThuc, KQHT_MonHoc_CT_KhoiKienThucInfo pKQHT_MonHoc_CT_KhoiKienThucInfo);

        [OperationContract(Name = "cDKQHT_MonHoc_CT_KhoiKienThuc_Add")]
        int cDKQHT_MonHoc_CT_KhoiKienThuc_Add(string MaXacThuc, KQHT_MonHoc_CT_KhoiKienThucInfo pKQHT_MonHoc_CT_KhoiKienThucInfo);

        [OperationContract(Name = "cDKQHT_MonHoc_CT_KhoiKienThuc_Update")]
        void cDKQHT_MonHoc_CT_KhoiKienThuc_Update(string MaXacThuc, KQHT_MonHoc_CT_KhoiKienThucInfo pKQHT_MonHoc_CT_KhoiKienThucInfo);

        [OperationContract(Name = "cDKQHT_MonHoc_CT_KhoiKienThuc_Delete")]
        void cDKQHT_MonHoc_CT_KhoiKienThuc_Delete(string MaXacThuc, KQHT_MonHoc_CT_KhoiKienThucInfo pKQHT_MonHoc_CT_KhoiKienThucInfo);


        [OperationContract(Name = "cDKQHT_CTDT_Lop_Get")]
        List<sp_KQHT_CTDT_Lop_GetResult> cDKQHT_CTDT_Lop_Get(string MaXacThuc, KQHT_CTDT_LopInfo pKQHT_CTDT_LopInfo);

        [OperationContract(Name = "cDKQHT_CTDT_Lop_Add")]
        int cDKQHT_CTDT_Lop_Add(string MaXacThuc, KQHT_CTDT_LopInfo pKQHT_CTDT_LopInfo);

        [OperationContract(Name = "cDKQHT_CTDT_Lop_Update")]
        void cDKQHT_CTDT_Lop_Update(string MaXacThuc, KQHT_CTDT_LopInfo pKQHT_CTDT_LopInfo);

        [OperationContract(Name = "cDKQHT_CTDT_Lop_Delete")]
        void cDKQHT_CTDT_Lop_Delete(string MaXacThuc, KQHT_CTDT_LopInfo pKQHT_CTDT_LopInfo);

        [OperationContract(Name = "cDKQHT_CTDT_CT_KhoiKienThuc_Get")]
        List<sp_KQHT_CTDT_CT_KhoiKienThuc_GetResult> cDKQHT_CTDT_CT_KhoiKienThuc_Get(string MaXacThuc, KQHT_CTDT_CT_KhoiKienThucInfo pKQHT_CTDT_CT_KhoiKienThucInfo);

        [OperationContract(Name = "cDKQHT_CTDT_CT_KhoiKienThuc_Add")]
        int cDKQHT_CTDT_CT_KhoiKienThuc_Add(string MaXacThuc, KQHT_CTDT_CT_KhoiKienThucInfo pKQHT_CTDT_CT_KhoiKienThucInfo);

        [OperationContract(Name = "cDKQHT_CTDT_CT_KhoiKienThuc_Update")]
        void cDKQHT_CTDT_CT_KhoiKienThuc_Update(string MaXacThuc, KQHT_CTDT_CT_KhoiKienThucInfo pKQHT_CTDT_CT_KhoiKienThucInfo);

        [OperationContract(Name = "cDKQHT_CTDT_CT_KhoiKienThuc_Delete")]
        void cDKQHT_CTDT_CT_KhoiKienThuc_Delete(string MaXacThuc, KQHT_CTDT_CT_KhoiKienThucInfo pKQHT_CTDT_CT_KhoiKienThucInfo);



        [OperationContract(Name = "cDKQHT_ChuongTrinhDaoTao_Get")]
        List<sp_KQHT_ChuongTrinhDaoTao_GetResult> cDKQHT_ChuongTrinhDaoTao_Get(string MaXacThuc, KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo);

        [OperationContract(Name = "cDKQHT_ChuongTrinhDaoTao_Add")]
        int cDKQHT_ChuongTrinhDaoTao_Add(string MaXacThuc, KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo);

        [OperationContract(Name = "cDKQHT_ChuongTrinhDaoTao_Update")]
        void cDKQHT_ChuongTrinhDaoTao_Update(string MaXacThuc, KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo);

        [OperationContract(Name = "cDKQHT_ChuongTrinhDaoTao_Delete")]
        void cDKQHT_ChuongTrinhDaoTao_Delete(string MaXacThuc, KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo);

        

        [OperationContract(Name = "cDGG_DinhMucGioDay_Get")]
        List<sp_GG_DinhMucGioDay_GetResult> cDGG_DinhMucGioDay_Get(string MaXacThuc, GG_DinhMucGioDayInfo pGG_DinhMucGioDayInfo);

        [OperationContract(Name = "cDGG_DinhMucGioDay_Add")]
        int cDGG_DinhMucGioDay_Add(string MaXacThuc, GG_DinhMucGioDayInfo pGG_DinhMucGioDayInfo);

        [OperationContract(Name = "cDGG_DinhMucGioDay_Update")]
        void cDGG_DinhMucGioDay_Update(string MaXacThuc, GG_DinhMucGioDayInfo pGG_DinhMucGioDayInfo);

        [OperationContract(Name = "cDGG_DinhMucGioDay_Delete")]
        void cDGG_DinhMucGioDay_Delete(string MaXacThuc, GG_DinhMucGioDayInfo pGG_DinhMucGioDayInfo);



        [OperationContract(Name = "cDKQHT_CT_KhoiKienThuc_Get")]
        List<KQHT_CT_KhoiKienThucInfo> cDKQHT_CT_KhoiKienThuc_Get(string MaXacThuc, KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo);

        [OperationContract(Name = "cDKQHT_CT_KhoiKienThuc_Add")]
        int cDKQHT_CT_KhoiKienThuc_Add(string MaXacThuc, KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo);

        [OperationContract(Name = "cDKQHT_CT_KhoiKienThuc_Update")]
        void cDKQHT_CT_KhoiKienThuc_Update(string MaXacThuc, KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo);

        [OperationContract(Name = "cDKQHT_CT_KhoiKienThuc_Delete")]
        void cDKQHT_CT_KhoiKienThuc_Delete(string MaXacThuc, KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo);



        [OperationContract(Name = "cDXL_PhongHoc_MonHoc_Get")]
        List<sp_XL_PhongHoc_MonHoc_GetResult> cDXL_PhongHoc_MonHoc_Get(string MaXacThuc, XL_PhongHoc_MonHocInfo pXL_PhongHoc_MonHocInfo);

        [OperationContract(Name = "cDXL_PhongHoc_MonHoc_Add")]
        int cDXL_PhongHoc_MonHoc_Add(string MaXacThuc, XL_PhongHoc_MonHocInfo pXL_PhongHoc_MonHocInfo);

        [OperationContract(Name = "cDXL_PhongHoc_MonHoc_Update")]
        void cDXL_PhongHoc_MonHoc_Update(string MaXacThuc, XL_PhongHoc_MonHocInfo pXL_PhongHoc_MonHocInfo);

        [OperationContract(Name = "cDXL_PhongHoc_MonHoc_Delete")]
        void cDXL_PhongHoc_MonHoc_Delete(string MaXacThuc, XL_PhongHoc_MonHocInfo pXL_PhongHoc_MonHocInfo);


        [OperationContract(Name = "cDKQHT_QuyChe_Get")]
        List<sp_KQHT_QuyChe_GetResult> cDKQHT_QuyChe_Get(string MaXacThuc, KQHT_QuyCheInfo pKQHT_QuyCheInfo);

        [OperationContract(Name = "cDKQHT_QuyChe_Add")]
        int cDKQHT_QuyChe_Add(string MaXacThuc, KQHT_QuyCheInfo pKQHT_QuyCheInfo);

        [OperationContract(Name = "cDKQHT_QuyChe_Update")]
        void cDKQHT_QuyChe_Update(string MaXacThuc, KQHT_QuyCheInfo pKQHT_QuyCheInfo);

        [OperationContract(Name = "cDKQHT_QuyChe_Delete")]
        void cDKQHT_QuyChe_Delete(string MaXacThuc, KQHT_QuyCheInfo pKQHT_QuyCheInfo);


        [OperationContract(Name = "cDHT_ThongTinTruong_Get")]
        List<sp_HT_ThongTinTruong_GetResult> cDHT_ThongTinTruong_Get(string MaXacThuc, HT_ThongTinTruongInfo pHT_ThongTinTruongInfo);

        [OperationContract(Name = "cDHT_ThongTinTruong_Add")]
        int cDHT_ThongTinTruong_Add(string MaXacThuc, HT_ThongTinTruongInfo pHT_ThongTinTruongInfo);

        [OperationContract(Name = "cDHT_ThongTinTruong_Update")]
        void cDHT_ThongTinTruong_Update(string MaXacThuc, HT_ThongTinTruongInfo pHT_ThongTinTruongInfo);

        [OperationContract(Name = "cDHT_ThongTinTruong_Delete")]
        void cDHT_ThongTinTruong_Delete(string MaXacThuc, HT_ThongTinTruongInfo pHT_ThongTinTruongInfo);


        [OperationContract(Name = "cDGG_HeSoLopDongTheoKhoa_Get")]
        List<sp_GG_HeSoLopDongTheoKhoa_GetResult> cDGG_HeSoLopDongTheoKhoa_Get(string MaXacThuc, GG_HeSoLopDongTheoKhoaInfo pGG_HeSoLopDongTheoKhoaInfo);

        [OperationContract(Name = "cDGG_HeSoLopDongTheoKhoa_Add")]
        int cDGG_HeSoLopDongTheoKhoa_Add(string MaXacThuc, GG_HeSoLopDongTheoKhoaInfo pGG_HeSoLopDongTheoKhoaInfo);

        [OperationContract(Name = "cDGG_HeSoLopDongTheoKhoa_Update")]
        void cDGG_HeSoLopDongTheoKhoa_Update(string MaXacThuc, GG_HeSoLopDongTheoKhoaInfo pGG_HeSoLopDongTheoKhoaInfo);

        [OperationContract(Name = "cDGG_HeSoLopDongTheoKhoa_Delete")]
        void cDGG_HeSoLopDongTheoKhoa_Delete(string MaXacThuc, GG_HeSoLopDongTheoKhoaInfo pGG_HeSoLopDongTheoKhoaInfo);

        [OperationContract(Name = "cDXL_PhanCongGiaoVien_Get")]
        List<sp_XL_PhanCongGiaoVien_GetResult> cDXL_PhanCongGiaoVien_Get(string MaXacThuc, XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo);

        [OperationContract(Name = "cDXL_PhanCongGiaoVien_Add")]
        int cDXL_PhanCongGiaoVien_Add(string MaXacThuc, XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo);

        [OperationContract(Name = "cDXL_PhanCongGiaoVien_Update")]
        void cDXL_PhanCongGiaoVien_Update(string MaXacThuc, XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo);

        [OperationContract(Name = "cDXL_PhanCongGiaoVien_Delete")]
        void cDXL_PhanCongGiaoVien_Delete(string MaXacThuc, XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo);

        [OperationContract(Name = "cDKQHT_XepLoaiMonHoc_Get")]
        List<sp_KQHT_XepLoaiMonHoc_GetResult> cDKQHT_XepLoaiMonHoc_Get(string MaXacThuc, KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo);

        [OperationContract(Name = "cDKQHT_XepLoaiMonHoc_Add")]
        int cDKQHT_XepLoaiMonHoc_Add(string MaXacThuc, KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo);

        [OperationContract(Name = "cDKQHT_XepLoaiMonHoc_Update")]
        void cDKQHT_XepLoaiMonHoc_Update(string MaXacThuc, KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo);

        [OperationContract(Name = "cDKQHT_XepLoaiMonHoc_Delete")]
        void cDKQHT_XepLoaiMonHoc_Delete(string MaXacThuc, KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo);


        [OperationContract(Name = "cDXL_MonHocTrongKy_Get")]
        List<sp_XL_MonHocTrongKy_GetResult> cDXL_MonHocTrongKy_Get(string MaXacThuc, XL_MonHocTrongKyInfo pXL_MonHocTrongKyInfo);

        [OperationContract(Name = "cDXL_MonHocTrongKy_Add")]
        int cDXL_MonHocTrongKy_Add(string MaXacThuc, XL_MonHocTrongKyInfo pXL_MonHocTrongKyInfo);

        [OperationContract(Name = "cDXL_MonHocTrongKy_Update")]
        void cDXL_MonHocTrongKy_Update(string MaXacThuc, XL_MonHocTrongKyInfo pXL_MonHocTrongKyInfo);

        [OperationContract(Name = "cDXL_MonHocTrongKy_Delete")]
        void cDXL_MonHocTrongKy_Delete(string MaXacThuc, XL_MonHocTrongKyInfo pXL_MonHocTrongKyInfo);

        [OperationContract(Name = "cDKQHT_DiemThi_Get")]
        List<sp_KQHT_DiemThi_GetResult> cDKQHT_DiemThi_Get(string MaXacThuc, KQHT_DiemThiInfo pKQHT_DiemThiInfo);

        [OperationContract(Name = "cDKQHT_DiemThi_Add")]
        int cDKQHT_DiemThi_Add(string MaXacThuc, KQHT_DiemThiInfo pKQHT_DiemThiInfo);

        [OperationContract(Name = "cDKQHT_DiemThi_Update")]
        void cDKQHT_DiemThi_Update(string MaXacThuc, KQHT_DiemThiInfo pKQHT_DiemThiInfo);

        [OperationContract(Name = "cDKQHT_DiemThi_Delete")]
        void cDKQHT_DiemThi_Delete(string MaXacThuc, KQHT_DiemThiInfo pKQHT_DiemThiInfo);

        [OperationContract(Name = "cDKQHT_DiemDanh_Get")]
        List<sp_KQHT_DiemDanh_GetResult> cDKQHT_DiemDanh_Get(string MaXacThuc, KQHT_DiemDanhInfo pKQHT_DiemDanhInfo);

        [OperationContract(Name = "cDKQHT_DiemDanh_Add")]
        int cDKQHT_DiemDanh_Add(string MaXacThuc, KQHT_DiemDanhInfo pKQHT_DiemDanhInfo);

        [OperationContract(Name = "cDKQHT_DiemDanh_Update")]
        void cDKQHT_DiemDanh_Update(string MaXacThuc, KQHT_DiemDanhInfo pKQHT_DiemDanhInfo);

        [OperationContract(Name = "cDKQHT_DiemDanh_Delete")]
        void cDKQHT_DiemDanh_Delete(string MaXacThuc, KQHT_DiemDanhInfo pKQHT_DiemDanhInfo);

        [OperationContract(Name = "cDKQHT_CTDT_ChiTiet_Get")]
        List<sp_KQHT_CTDT_ChiTiet_GetResult> cDKQHT_CTDT_ChiTiet_Get(string MaXacThuc, KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo);

        [OperationContract(Name = "cDKQHT_CTDT_ChiTiet_Add")]
        int cDKQHT_CTDT_ChiTiet_Add(string MaXacThuc, KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo);

        [OperationContract(Name = "cDKQHT_CTDT_ChiTiet_Update")]
        void cDKQHT_CTDT_ChiTiet_Update(string MaXacThuc, KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo);

        [OperationContract(Name = "cDKQHT_CTDT_ChiTiet_Delete")]
        void cDKQHT_CTDT_ChiTiet_Delete(string MaXacThuc, KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo);

        [OperationContract(Name = "cDDM_MonHoc_Add")]
        int cDDM_MonHoc_Add(string MaXacThuc, DM_MonHocInfo pDM_MonHocInfo);

        [OperationContract(Name = "cDDM_MonHoc_Update")]
        void cDDM_MonHoc_Update(string MaXacThuc, DM_MonHocInfo pDM_MonHocInfo);

        [OperationContract(Name = "cDDM_MonHoc_Delete")]
        void cDDM_MonHoc_Delete(string MaXacThuc, DM_MonHocInfo pDM_MonHocInfo);
        [OperationContract(Name = "cDDM_TrinhDo_Get")]
        List<sp_DM_TrinhDo_GetResult> cDDM_TrinhDo_Get(string MaXacThuc, DM_TrinhDoInfo pDM_TrinhDoInfo);

        [OperationContract(Name = "cDDM_KhoiKienThuc_Get")]
        List<sp_DM_KhoiKienThuc_GetResult> cDDM_KhoiKienThuc_Get(string MaXacThuc, DM_KhoiKienThucInfo pDM_KhoiKienThucInfo);

        [OperationContract(Name = "cDDM_KhoiKienThuc_Add")]
        int cDDM_KhoiKienThuc_Add(string MaXacThuc, DM_KhoiKienThucInfo pDM_KhoiKienThucInfo);

        [OperationContract(Name = "cDDM_KhoiKienThuc_Update")]
        void cDDM_KhoiKienThuc_Update(string MaXacThuc, DM_KhoiKienThucInfo pDM_KhoiKienThucInfo);

        [OperationContract(Name = "cDDM_KhoiKienThuc_Delete")]
        void cDDM_KhoiKienThuc_Delete(string MaXacThuc, DM_KhoiKienThucInfo pDM_KhoiKienThucInfo);

        [OperationContract(Name = "cDDM_HinhThucThi_Get")]
        List<sp_DM_HinhThucThi_GetResult> cDDM_HinhThucThi_Get(string MaXacThuc, DM_HinhThucThiInfo pDM_HinhThucThiInfo);

        [OperationContract(Name = "cDDM_HinhThucThi_Add")]
        int cDDM_HinhThucThi_Add(string MaXacThuc, DM_HinhThucThiInfo pDM_HinhThucThiInfo);

        [OperationContract(Name = "cDDM_HinhThucThi_Update")]
        void cDDM_HinhThucThi_Update(string MaXacThuc, DM_HinhThucThiInfo pDM_HinhThucThiInfo);

        [OperationContract(Name = "cDDM_HinhThucThi_Delete")]
        void cDDM_HinhThucThi_Delete(string MaXacThuc, DM_HinhThucThiInfo pDM_HinhThucThiInfo);

        [OperationContract(Name = "cDDM_Nganh_Get")]
        List<sp_DM_Nganh_GetResult> cDDM_Nganh_Get(string MaXacThuc, DM_NganhInfo pDM_NganhInfo);

        [OperationContract(Name = "cDDM_KhoaHoc_Get")]
        List<sp_DM_KhoaHoc_GetResult> cDDM_KhoaHoc_Get(string MaXacThuc, DM_KhoaHocInfo pDM_KhoaHocInfo);

        [OperationContract(Name = "cDDM_Khoa_Get")]
        List<sp_DM_Khoa_GetResult> cDDM_Khoa_Get(string MaXacThuc, DM_KhoaInfo pDM_KhoaInfo);

        [OperationContract(Name = "cDXL_GiaoVien_MonHoc_Get")]
        List<sp_XL_GiaoVien_MonHoc_GetResult> cDXL_GiaoVien_MonHoc_Get(string MaXacThuc, XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo);
    }
}