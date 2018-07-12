using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services.Protocols;
using TruongViet.UnimOs.Entity.Model;

namespace UnimOs.Service
{
    // NOTE: If you change the class name "UnimOsService" here, you must also update the reference to "UnimOsService" in Web.config.
    // NOTE: If you change the class name "UnimOsService" here, you must also update the reference to "UnimOsService" in Web.config.
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class UnimOsService : IUnimOsService
    {

        public string cDBase_RunQuery(string MaXacThuc, string sqlConnection, string SQL)
        {
            if (MaXacThuc != "ABC") return null;
            cDBase oDBase = new cDBase();
            return oDBase.RunQuery(sqlConnection, SQL);
        }
        public void cDHT_DongBo_Delete(string MaXacThuc, HT_DongBoInfo pHT_DongBoInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDHT_DongBo oDHT_DongBo = new cDHT_DongBo();
            oDHT_DongBo.Delete(pHT_DongBoInfo);
        }
        public List<sp_HT_DongBo_GetResult> cDHT_DongBo_Get(string MaXacThuc, HT_DongBoInfo pHT_DongBoInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDHT_DongBo oDHT_DongBo = new cDHT_DongBo();
            DataTable dt = oDHT_DongBo.Get(pHT_DongBoInfo);
            return Convert.ToList<sp_HT_DongBo_GetResult>(dt);
        }
        public int cDHT_DongBo_Add(string MaXacThuc, HT_DongBoInfo pHT_DongBoInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDHT_DongBo oDHT_DongBo = new cDHT_DongBo();
            return oDHT_DongBo.Add(pHT_DongBoInfo);
        }

        public void cDHT_DongBo_Update(string MaXacThuc, HT_DongBoInfo pHT_DongBoInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDHT_DongBo oDHT_DongBo = new cDHT_DongBo();
            oDHT_DongBo.Update(pHT_DongBoInfo);
        }

        public List<sp_HT_DongBo_GetDanhSachThayDoiResult> cDHT_DongBo_GetDanhSachThayDoi(string MaXacThuc, string TenBang, string IDThayDoi)
        {
            if (MaXacThuc != "ABC") return null;
            cDHT_DongBo oDHT_DongBo = new cDHT_DongBo();
            DataTable dt = oDHT_DongBo.GetDanhSachThayDoi(TenBang, IDThayDoi);
            return Convert.ToList<sp_HT_DongBo_GetDanhSachThayDoiResult>(dt);
        }
        public List<HT_DongBoInfo> cDHT_DongBo_GetDataChanged(string MaXacThuc, string TenBang, long IDThayDoi)
        {
            if (MaXacThuc != "ABC") return null;
            cDHT_DongBo oDHT_DongBo = new cDHT_DongBo();
            DataTable dt = oDHT_DongBo.GetDataChanged(TenBang, IDThayDoi);
            return Convert.ToList<HT_DongBoInfo>(dt);
        }

        public void cDHT_DongBo_UpdateTrangThai(string MaXacThuc, bool DaDongBo, long HT_DongBoID)
        {
            if (MaXacThuc != "ABC") return;
            cDHT_DongBo oDHT_DongBo = new cDHT_DongBo();
            oDHT_DongBo.UpdateTrangThai(DaDongBo, HT_DongBoID);
        }



        public List<HT_LogInfo> cDHT_Log_Search(string MaXacThuc, int IDPhanHe, int IDChucNang, string SuKien, string NguoiDung, string NoiDung, DateTime dtTuNgay, DateTime dtDenNgay)
        {
            if (MaXacThuc != "ABC") return null;
            cDHT_Log oDHT_Log = new cDHT_Log();
            DataTable dt = oDHT_Log.Search(IDPhanHe, IDChucNang, SuKien, NguoiDung, NoiDung, dtTuNgay, dtDenNgay);
            return Convert.ToList<HT_LogInfo>(dt);
        }

        public List<sp_TC_BienLaiThuTien_GetSoPhieuResult> cDTC_BienLaiThuTien_GetSoPhieu(string MaXacThuc, int HocKy, int IDDM_NamHoc, int SV_SinhVienID, int IDDM_DiaDiem)
        {
            if (MaXacThuc != "ABC") return null;
            cDTC_BienLaiThuTien oDTC_BienLaiThuTien = new cDTC_BienLaiThuTien();
            DataTable dt = oDTC_BienLaiThuTien.GetSoPhieu(HocKy, IDDM_NamHoc, SV_SinhVienID, IDDM_DiaDiem);
            return Convert.ToList<sp_TC_BienLaiThuTien_GetSoPhieuResult>(dt);
        }

        public List<TC_BienLaiThuTienInfo> cDTC_BienLaiThuTien_GetNamHoc(string MaXacThuc, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDTC_BienLaiThuTien oDTC_BienLaiThuTien = new cDTC_BienLaiThuTien();
            DataTable dt = oDTC_BienLaiThuTien.GetNamHoc(IDDM_NamHoc, HocKy);
            return Convert.ToList<TC_BienLaiThuTienInfo>(dt);
        }

        public List<sp_TC_BienLaiThuTien_GetChiTietResult> cDTC_BienLaiThuTien_GetChiTiet(string MaXacThuc, int TC_BienLaiThuTienID)
        {
            if (MaXacThuc != "ABC") return null;
            cDTC_BienLaiThuTien oDTC_BienLaiThuTien = new cDTC_BienLaiThuTien();
            DataTable dt = oDTC_BienLaiThuTien.GetChiTiet(TC_BienLaiThuTienID);
            return Convert.ToList<sp_TC_BienLaiThuTien_GetChiTietResult>(dt);
        }

        //public DataRow cDTC_BienLaiThuTien_GetInfoByID(string MaXacThuc, int TC_BienLaiThuTienID)
        //{
        //    if (MaXacThuc != "ABC") return null;
        //    cDTC_BienLaiThuTien oDTC_BienLaiThuTien = new cDTC_BienLaiThuTien();
        //    return oDTC_BienLaiThuTien.GetInfoByID(TC_BienLaiThuTienID);
        //}

        public List<sp_TC_BienLaiThuTien_GetBySinhVienResult> cDTC_BienLaiThuTien_GetBySinhVien(string MaXacThuc, int IDSV_SinhVien, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDTC_BienLaiThuTien oDTC_BienLaiThuTien = new cDTC_BienLaiThuTien();
            DataTable dt = oDTC_BienLaiThuTien.GetBySinhVien(IDSV_SinhVien, IDDM_NamHoc, HocKy);
            return Convert.ToList<sp_TC_BienLaiThuTien_GetBySinhVienResult>(dt);
        }

        public List<TC_BienLaiThuTienInfo> cDTC_BienLaiThuTien_GetTongHop(string MaXacThuc, DM_LopInfo pDM_LopInfo, int IDDM_NamHoc, int IDTC_LoaiThuChi, int HocKy, int IDTC_QuyenHoaDon, bool TongHopTuDau)
        {
            if (MaXacThuc != "ABC") return null;
            cDTC_BienLaiThuTien oDTC_BienLaiThuTien = new cDTC_BienLaiThuTien();
            DataTable dt = oDTC_BienLaiThuTien.GetTongHop(pDM_LopInfo, IDDM_NamHoc, IDTC_LoaiThuChi, HocKy, IDTC_QuyenHoaDon, TongHopTuDau);
            return Convert.ToList<TC_BienLaiThuTienInfo>(dt);
        }

        public List<TC_BienLaiThuTienInfo> cDTC_BienLaiThuTien_GetThuChi(string MaXacThuc, int IDTC_LoaiThuChi, string TuNgay, string DenNgay, int IDDM_NamHoc, int HocKy, string IDDM_Lops)
        {
            if (MaXacThuc != "ABC") return null;
            cDTC_BienLaiThuTien oDTC_BienLaiThuTien = new cDTC_BienLaiThuTien();
            DataTable dt = oDTC_BienLaiThuTien.GetThuChi(IDTC_LoaiThuChi, TuNgay, DenNgay, IDDM_NamHoc, HocKy, IDDM_Lops);
            return Convert.ToList<TC_BienLaiThuTienInfo>(dt);
        }

        public List<TC_BienLaiThuTienInfo> cDTC_BienLaiThuTien_TimKiem(string MaXacThuc, string SoPhieu, int PhieuThu, int PhieuHuy, string MaSinhVien, int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDTC_BienLaiThuTien oDTC_BienLaiThuTien = new cDTC_BienLaiThuTien();
            DataTable dt = oDTC_BienLaiThuTien.TimKiem(SoPhieu, PhieuThu, PhieuHuy, MaSinhVien, IDDM_Lop, IDDM_NamHoc, HocKy);
            return Convert.ToList<TC_BienLaiThuTienInfo>(dt);
        }

        public void cDTC_BienLaiThuTien_UpdatePhieuHuy(string MaXacThuc, int TC_BienLaiThuTienID, DateTime dtNgayHuy, int IDNguoiHuy, int PhieuHuy)
        {
            if (MaXacThuc != "ABC") return;
            cDTC_BienLaiThuTien oDTC_BienLaiThuTien = new cDTC_BienLaiThuTien();
            oDTC_BienLaiThuTien.UpdatePhieuHuy(TC_BienLaiThuTienID, dtNgayHuy, IDNguoiHuy, PhieuHuy);
        }

        public List<sp_XL_KeHoachKhac_GetComboResult> cDXL_KeHoachKhac_GetCombo(string MaXacThuc, XL_KeHoachKhacInfo pXL_KeHoachKhacInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_KeHoachKhac oDXL_KeHoachKhac = new cDXL_KeHoachKhac();
            DataTable dt = oDXL_KeHoachKhac.GetCombo(pXL_KeHoachKhacInfo);
            return Convert.ToList<sp_XL_KeHoachKhac_GetComboResult>(dt);
        }

        public List<NS_NhomNgachInfo> cDNS_NhomNgach_GetBy_NS_NgachCongChucID(string MaXacThuc, int NS_NgachCongChucID)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_NhomNgach oDNS_NhomNgach = new cDNS_NhomNgach();
            DataTable dt = oDNS_NhomNgach.GetBy_NS_NgachCongChucID(NS_NgachCongChucID);
            return Convert.ToList<NS_NhomNgachInfo>(dt);
        }

        public List<sp_XL_Tuan_GetByIDNamHocResult> cDXL_Tuan_GetByIDNamHoc(string MaXacThuc, XL_TuanInfo pTuanInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_Tuan oDXL_Tuan = new cDXL_Tuan();
            DataTable dt = oDXL_Tuan.GetByIDNamHoc(pTuanInfo);
            return Convert.ToList<sp_XL_Tuan_GetByIDNamHocResult>(dt);
        }

        public List<sp_XL_Tuan_GetByTuanThuResult> cDXL_Tuan_GetByTuanThu(string MaXacThuc, XL_TuanInfo pTuanInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_Tuan oDXL_Tuan = new cDXL_Tuan();
            DataTable dt = oDXL_Tuan.GetByTuanThu(pTuanInfo);
            return Convert.ToList<sp_XL_Tuan_GetByTuanThuResult>(dt);
        }

        public List<sp_XL_Tuan_GetByNamHoc_HocKyResult> cDXL_Tuan_GetBy_NamHoc_HocKy(string MaXacThuc, int IDNamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_Tuan oDXL_Tuan = new cDXL_Tuan();
            DataTable dt = oDXL_Tuan.GetBy_NamHoc_HocKy(IDNamHoc, HocKy);
            return Convert.ToList<sp_XL_Tuan_GetByNamHoc_HocKyResult>(dt);
        }

        public List<sp_XL_Tuan_GetByTuanThuResult> cDXL_Tuan_GetByTuanThu(string MaXacThuc, int IDNamHoc, int HocKy, int TuTuan)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_Tuan oDXL_Tuan = new cDXL_Tuan();
            DataTable dt = oDXL_Tuan.GetByTuanThu(IDNamHoc, HocKy, TuTuan);
            return Convert.ToList<sp_XL_Tuan_GetByTuanThuResult>(dt);
        }

        public void cDXL_Tuan_DeleteTuanThua(string MaXacThuc, XL_TuanInfo pTuanInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDXL_Tuan oDXL_Tuan = new cDXL_Tuan();
            oDXL_Tuan.DeleteTuanThua(pTuanInfo);
        }

        public List<sp_DM_Khoa_GetByIDBoMonResult> cDDM_Khoa_GetByIDBoMon(string MaXacThuc, int IDDM_BoMon)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_Khoa oDDM_Khoa = new cDDM_Khoa();
            DataTable dt = oDDM_Khoa.GetByIDBoMon(IDDM_BoMon);
            return Convert.ToList<sp_DM_Khoa_GetByIDBoMonResult>(dt);
        }

        public int cDDM_NamHoc_GetKy2(string MaXacThuc, DM_NamHocInfo pNamHocInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDDM_NamHoc oDDM_NamHoc = new cDDM_NamHoc();
            return oDDM_NamHoc.GetKy2(pNamHocInfo);
        }

        public List<sp_KQHT_QuyChe_GetThamSoResult> cDKQHT_QuyChe_GetThamSo(string MaXacThuc, int KQHT_QuyCheID)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_QuyChe oDKQHT_QuyChe = new cDKQHT_QuyChe();
            DataTable dt = oDKQHT_QuyChe.GetThamSo(KQHT_QuyCheID);
            return Convert.ToList<sp_KQHT_QuyChe_GetThamSoResult>(dt);
        }

        public List<sp_KQHT_QuyChe_GetThamSo_NotInResult> cDKQHT_QuyChe_GetThamSo_NotIn(string MaXacThuc, int KQHT_QuyCheID)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_QuyChe oDKQHT_QuyChe = new cDKQHT_QuyChe();
            DataTable dt = oDKQHT_QuyChe.GetThamSo_NotIn(KQHT_QuyCheID);
            return Convert.ToList<sp_KQHT_QuyChe_GetThamSo_NotInResult>(dt);
        }

        public string cDKQHT_QuyChe_GetByMaThamSo(string MaXacThuc, int IDDM_TrinhDo, string MaThamSo)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_QuyChe oDKQHT_QuyChe = new cDKQHT_QuyChe();
            return oDKQHT_QuyChe.GetByMaThamSo(IDDM_TrinhDo, MaThamSo);
        }

        public List<sp_DM_TrinhDo_GetByIDHeResult> cDDM_TrinhDo_GetByIDHe(string MaXacThuc, int IDDM_He)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_TrinhDo oDDM_TrinhDo = new cDDM_TrinhDo();
            DataTable dt = oDDM_TrinhDo.GetByIDHe(IDDM_He);
            return Convert.ToList<sp_DM_TrinhDo_GetByIDHeResult>(dt);
        }


        public List<sp_DM_Nganh_GetByIDKhoaResult> cDDM_Nganh_GetByIDKhoa(string MaXacThuc, int IDDM_Khoa)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_Nganh oDDM_Nganh = new cDDM_Nganh();
            DataTable dt = oDDM_Nganh.GetByIDKhoa(IDDM_Khoa);
            return Convert.ToList<sp_DM_Nganh_GetByIDKhoaResult>(dt);
        }



        public List<sp_DM_ChuyenNganh_GetByIDNganhResult> cDDM_ChuyenNganh_GetByIDNganh(string MaXacThuc, int IDDM_Nganh)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_ChuyenNganh oDDM_ChuyenNganh = new cDDM_ChuyenNganh();
            DataTable dt = oDDM_ChuyenNganh.GetByIDNganh(IDDM_Nganh);
            return Convert.ToList<sp_DM_ChuyenNganh_GetByIDNganhResult>(dt);
        }

        public List<sp_DM_BoMon_GetByIDKhoaResult> cDDM_BoMon_GetByIDKhoa(string MaXacThuc, int IDDM_Khoa)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_BoMon oDDM_BoMon = new cDDM_BoMon();
            DataTable dt = oDDM_BoMon.GetByIDKhoa(IDDM_Khoa);
            return Convert.ToList<sp_DM_BoMon_GetByIDKhoaResult>(dt);
        }


        public List<sp_NS_DonVi_GetByIDResult> cDNS_DonVi_GetByID(string MaXacThuc, int IDNS_DonVi)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_DonVi oDNS_DonVi = new cDNS_DonVi();
            DataTable dt = oDNS_DonVi.GetByID(IDNS_DonVi);
            return Convert.ToList<sp_NS_DonVi_GetByIDResult>(dt);
        }

        public List<sp_NS_DonVi_GetByIDDM_KhoaResult> cDNS_DonVi_GetByIDDM_Khoa(string MaXacThuc, int IDDM_Khoa)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_DonVi oDNS_DonVi = new cDNS_DonVi();
            DataTable dt = oDNS_DonVi.GetByIDDM_Khoa(IDDM_Khoa);
            return Convert.ToList<sp_NS_DonVi_GetByIDDM_KhoaResult>(dt);
        }

        public List<sp_DM_ChucVu_QuaTrinhBoNhiem_GetBy_IDNS_GiaoVienResult> cDDM_ChucVu_ChucVu_QuaTrinhBoNhiem_GetBy_IDNS_GiaoVien(string MaXacThuc, int IDNS_GiaoVien)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_ChucVu oDDM_ChucVu = new cDDM_ChucVu();
            DataTable dt = oDDM_ChucVu.ChucVu_QuaTrinhBoNhiem_GetBy_IDNS_GiaoVien(IDNS_GiaoVien);
            return Convert.ToList<sp_DM_ChucVu_QuaTrinhBoNhiem_GetBy_IDNS_GiaoVienResult>(dt);
        }

        public List<sp_DM_Lop_GetTreeResult> cDDM_Lop_GetTree(string MaXacThuc, string NamHoc)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_Lop oDDM_Lop = new cDDM_Lop();
            DataTable dt = oDDM_Lop.GetTree(NamHoc);
            return Convert.ToList<sp_DM_Lop_GetTreeResult>(dt);
        }

        public List<sp_DM_Lop_GetTreeByIDGiaoVienResult> cDDM_Lop_GetTreeByIDGiaoVien(string MaXacThuc, string NamHoc, int IDNS_GiaoVien, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_Lop oDDM_Lop = new cDDM_Lop();
            DataTable dt = oDDM_Lop.GetTreeByIDGiaoVien(NamHoc, IDNS_GiaoVien, IDDM_NamHoc, HocKy);
            return Convert.ToList<sp_DM_Lop_GetTreeByIDGiaoVienResult>(dt);
        }

        public List<sp_DM_Lop_GetTree_ThiSinhTuDoResult> cDDM_Lop_GetTree_ThiSinhTuDo(string MaXacThuc, string NamHoc)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_Lop oDDM_Lop = new cDDM_Lop();
            DataTable dt = oDDM_Lop.GetTree_ThiSinhTuDo(NamHoc);
            return Convert.ToList<sp_DM_Lop_GetTree_ThiSinhTuDoResult>(dt);
        }

        public List<sp_DM_Lop_GetLopGopResult> cDDM_Lop_GetLopGop(string MaXacThuc, DM_LopInfo pDM_LopInfo, int IDDM_MonHoc, string NamHoc)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_Lop oDDM_Lop = new cDDM_Lop();
            DataTable dt = oDDM_Lop.GetLopGop(pDM_LopInfo, IDDM_MonHoc, NamHoc);
            return Convert.ToList<sp_DM_Lop_GetLopGopResult>(dt);
        }

        public List<DM_LopInfo> cDDM_Lop_GetDanhSachLop(string MaXacThuc, DM_LopInfo pDM_LopInfo, string NamHoc)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_Lop oDDM_Lop = new cDDM_Lop();
            DataTable dt = oDDM_Lop.GetDanhSachLop(pDM_LopInfo, NamHoc);
            return Convert.ToList<DM_LopInfo>(dt);
        }

        public List<DM_LopInfo> cDDM_Lop_GetTongHopXepLoai(string MaXacThuc, DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_Lop oDDM_Lop = new cDDM_Lop();
            DataTable dt = oDDM_Lop.GetTongHopXepLoai(pDM_LopInfo, NamHoc, IDDM_NamHoc, HocKy);
            return Convert.ToList<DM_LopInfo>(dt);
        }

        public List<sp_DM_Lop_GetChonResult> cDDM_Lop_GetChon(string MaXacThuc, int IDDM_TrinhDo, string NamHoc)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_Lop oDDM_Lop = new cDDM_Lop();
            DataTable dt = oDDM_Lop.GetChon(IDDM_TrinhDo, NamHoc);
            return Convert.ToList<sp_DM_Lop_GetChonResult>(dt);
        }

        public List<DM_LopInfo> cDDM_Lop_GetKeHoachToanTruong(string MaXacThuc, int IDNamHoc, string NamHoc, DM_LopInfo pDM_LopInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_Lop oDDM_Lop = new cDDM_Lop();
            DataTable dt = oDDM_Lop.GetKeHoachToanTruong(IDNamHoc, NamHoc, pDM_LopInfo);
            return Convert.ToList<DM_LopInfo>(dt);
        }

        public List<DM_LopInfo> cDDM_Lop_GetPhanBoPhongHoc(string MaXacThuc, int IDNamHoc, string NamHoc, int HocKy, int CaHoc, int TuTuan, int DenTuan)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_Lop oDDM_Lop = new cDDM_Lop();
            DataTable dt = oDDM_Lop.GetPhanBoPhongHoc(IDNamHoc, NamHoc, HocKy, CaHoc, TuTuan, DenTuan);
            return Convert.ToList<DM_LopInfo>(dt);
        }

        public List<sp_DM_Lop_GetChuongTrinhDaoTaoResult> cDDM_Lop_GetChuongTrinhDaoTao(string MaXacThuc, int DM_LopID)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_Lop oDDM_Lop = new cDDM_Lop();
            DataTable dt = oDDM_Lop.GetChuongTrinhDaoTao(DM_LopID);
            return Convert.ToList<sp_DM_Lop_GetChuongTrinhDaoTaoResult>(dt);
        }

        public List<sp_KQHT_DiemThangPhan_GetTong_byIDXL_MonHocTrongKyResult> cDDM_Lop_GetGetTongDiemThanhPhan(string MaXacThuc, int IDXL_MonHocTrongKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_Lop oDDM_Lop = new cDDM_Lop();
            DataTable dt = oDDM_Lop.GetGetTongDiemThanhPhan(IDXL_MonHocTrongKy);
            return Convert.ToList<sp_KQHT_DiemThangPhan_GetTong_byIDXL_MonHocTrongKyResult>(dt);
        }

        public List<sp_DM_Lop_GetByKhoaResult> cDDM_Lop_GetByKhoa(string MaXacThuc, int IDDM_Khoa, string @NamHoc)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_Lop oDDM_Lop = new cDDM_Lop();
            DataTable dt = oDDM_Lop.GetByKhoa(IDDM_Khoa, @NamHoc);
            return Convert.ToList<sp_DM_Lop_GetByKhoaResult>(dt);
        }

        public List<sp_DM_Lop_Get_TKBResult> cDDM_Lop_Get_TKB(string MaXacThuc, long IDXL_Tuan)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_Lop oDDM_Lop = new cDDM_Lop();
            DataTable dt = oDDM_Lop.Get_TKB(IDXL_Tuan);
            return Convert.ToList<sp_DM_Lop_Get_TKBResult>(dt);
        }

        public List<sp_XL_MonHocTrongKy_GetToChucThiResult> cDXL_MonHocTrongKy_GetToChucThi(string MaXacThuc, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_MonHocTrongKy oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
            DataTable dt = oDXL_MonHocTrongKy.GetToChucThi(IDDM_NamHoc, HocKy);
            return Convert.ToList<sp_XL_MonHocTrongKy_GetToChucThiResult>(dt);
        }

        public List<sp_XL_MonHocTrongKy_GetMonKyResult> cDXL_MonHocTrongKy_GetMonKy(string MaXacThuc, int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_MonHocTrongKy oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
            DataTable dt = oDXL_MonHocTrongKy.GetMonKy(IDDM_Lop, IDDM_NamHoc, HocKy);
            return Convert.ToList<sp_XL_MonHocTrongKy_GetMonKyResult>(dt);
        }

        public List<sp_XL_MonHocTrongKy_GetMonKyToanKhoaByLopResult> cDXL_MonHocTrongKy_GetMonKyToanKhoaByLop(string MaXacThuc, int IDDM_Lop)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_MonHocTrongKy oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
            DataTable dt = oDXL_MonHocTrongKy.GetMonKyToanKhoaByLop(IDDM_Lop);
            return Convert.ToList<sp_XL_MonHocTrongKy_GetMonKyToanKhoaByLopResult>(dt);
        }

        public List<sp_XL_MonHocTrongKy_GetMonKyChuaThucHanhResult> cDXL_MonHocTrongKy_GetMonKyChuaThucHanh(string MaXacThuc, int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_MonHocTrongKy oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
            DataTable dt = oDXL_MonHocTrongKy.GetMonKyChuaThucHanh(IDDM_Lop, IDDM_NamHoc, HocKy);
            return Convert.ToList<sp_XL_MonHocTrongKy_GetMonKyChuaThucHanhResult>(dt);
        }

        public List<sp_XL_MonHocTrongKy_GetByLopResult> cDXL_MonHocTrongKy_GetByLop(string MaXacThuc, int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_MonHocTrongKy oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
            DataTable dt = oDXL_MonHocTrongKy.GetByLop(IDDM_Lop, IDDM_NamHoc, HocKy);
            return Convert.ToList<sp_XL_MonHocTrongKy_GetByLopResult>(dt);
        }

        public List<sp_XL_MonHocTrongKy_GetByLopKhoaResult> cDXL_MonHocTrongKy_GetByLopKhoa(string MaXacThuc, int IDDM_Lop, int IDKhoa_GiaoVu, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_MonHocTrongKy oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
            DataTable dt = oDXL_MonHocTrongKy.GetByLopKhoa(IDDM_Lop, IDKhoa_GiaoVu, IDDM_NamHoc, HocKy);
            return Convert.ToList<sp_XL_MonHocTrongKy_GetByLopKhoaResult>(dt);
        }

        public List<sp_XL_MonHocTrongKy_GetToanKhoaResult> cDXL_MonHocTrongKy_GetToanKhoa(string MaXacThuc, int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_MonHocTrongKy oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
            DataTable dt = oDXL_MonHocTrongKy.GetToanKhoa(IDDM_Lop, IDDM_NamHoc, HocKy);
            return Convert.ToList<sp_XL_MonHocTrongKy_GetToanKhoaResult>(dt);
        }

        public List<XL_MonHocTrongKyInfo> cDXL_MonHocTrongKy_GetByHocKyNamHoc(string MaXacThuc, int IDDM_Lop, int HocKy, int IDDM_NamHoc, int IDDM_Khoa, int IDDM_BoMon)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_MonHocTrongKy oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
            DataTable dt = oDXL_MonHocTrongKy.GetByHocKyNamHoc(IDDM_Lop, HocKy, IDDM_NamHoc, IDDM_Khoa, IDDM_BoMon);
            return Convert.ToList<XL_MonHocTrongKyInfo>(dt);
        }

        public List<sp_XL_MonHocTrongKy_GetByIDGiaoVienResult> cDXL_MonHocTrongKy_GetByIDGiaoVien(string MaXacThuc, int IDNS_GiaoVien, int IDDM_Lop, int HocKy, int IDDM_NamHoc)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_MonHocTrongKy oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
            DataTable dt = oDXL_MonHocTrongKy.GetByIDGiaoVien(IDNS_GiaoVien, IDDM_Lop, HocKy, IDDM_NamHoc);
            return Convert.ToList<sp_XL_MonHocTrongKy_GetByIDGiaoVienResult>(dt);
        }

        public List<sp_XL_MonHocTrongKy_GetNhapDuLieuByHocKyNamHocResult> cDXL_MonHocTrongKy_GetNhapDuLieuByHocKyNamHoc(string MaXacThuc, int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_MonHocTrongKy oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
            DataTable dt = oDXL_MonHocTrongKy.GetNhapDuLieuByHocKyNamHoc(IDDM_Lop, IDDM_NamHoc, HocKy);
            return Convert.ToList<sp_XL_MonHocTrongKy_GetNhapDuLieuByHocKyNamHocResult>(dt);
        }

        public List<sp_XL_MonHocTrongKy_GetAllByHocKyNamHocResult> cDXL_MonHocTrongKy_GetAllByHocKyNamHoc(string MaXacThuc, int IDDM_Lop, int HocKy, int IDDM_NamHoc)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_MonHocTrongKy oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
            DataTable dt = oDXL_MonHocTrongKy.GetAllByHocKyNamHoc(IDDM_Lop, HocKy, IDDM_NamHoc);
            return Convert.ToList<sp_XL_MonHocTrongKy_GetAllByHocKyNamHocResult>(dt);
        }

        public List<XL_MonHocTrongKyInfo> cDXL_MonHocTrongKy_GetByLopGop(string MaXacThuc, string IDDM_Lops, int HocKy, int IDDM_NamHoc, int SoLop)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_MonHocTrongKy oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
            DataTable dt = oDXL_MonHocTrongKy.GetByLopGop(IDDM_Lops, HocKy, IDDM_NamHoc, SoLop);
            return Convert.ToList<XL_MonHocTrongKyInfo>(dt);
        }

        public void cDXL_MonHocTrongKy_DeleteByHocKyNamHoc(string MaXacThuc, int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return;
            cDXL_MonHocTrongKy oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
            oDXL_MonHocTrongKy.DeleteByHocKyNamHoc(IDDM_Lop, IDDM_NamHoc, HocKy);
        }

        public void cDXL_MonHocTrongKy_DeleteMonHocNotIn(string MaXacThuc, int IDDM_Lop, int IDDM_NamHoc, int HocKy, string IDDM_MonHocs)
        {
            if (MaXacThuc != "ABC") return;
            cDXL_MonHocTrongKy oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
            oDXL_MonHocTrongKy.DeleteMonHocNotIn(IDDM_Lop, IDDM_NamHoc, HocKy, IDDM_MonHocs);
        }

        public void cDXL_MonHocTrongKy_UpdateTachGop(string MaXacThuc, int XL_MonHocTrongKyID, bool HocOLopTachGop)
        {
            if (MaXacThuc != "ABC") return;
            cDXL_MonHocTrongKy oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
            oDXL_MonHocTrongKy.UpdateTachGop(XL_MonHocTrongKyID, HocOLopTachGop);
        }

        public void cDXL_MonHocTrongKy_ApDungCacLopKhac(string MaXacThuc, int DM_LopID, int DM_LopIDNew, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return;
            cDXL_MonHocTrongKy oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
            oDXL_MonHocTrongKy.ApDungCacLopKhac(DM_LopID, DM_LopIDNew, IDDM_NamHoc, HocKy);
        }

        public List<sp_XL_MonHocTrongKy_GetDiemMonByIDSV_SinhVienAndIDDM_LopResult> cDXL_MonHocTrongKy_GetDiemMonByIDSV_SinhVienAndIDDM_Lop(string MaXacThuc, int IDSV_SinhVien, int IDDM_Lop)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_MonHocTrongKy oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
            DataTable dt = oDXL_MonHocTrongKy.GetDiemMonByIDSV_SinhVienAndIDDM_Lop(IDSV_SinhVien, IDDM_Lop);
            return Convert.ToList<sp_XL_MonHocTrongKy_GetDiemMonByIDSV_SinhVienAndIDDM_LopResult>(dt);
        }


        public List<sp_DM_PhongHoc_GetChonResult> cDDM_PhongHoc_GetChon(string MaXacThuc, int IDToaNha, string mPhongHoc)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_PhongHoc oDDM_PhongHoc = new cDDM_PhongHoc();
            DataTable dt = oDDM_PhongHoc.GetChon(IDToaNha, mPhongHoc);
            return Convert.ToList<sp_DM_PhongHoc_GetChonResult>(dt);
        }

        public List<sp_DM_PhongHoc_GetByIDToaNhaResult> cDDM_PhongHoc_GetByIDToaNha(string MaXacThuc, int IDDM_ToaNha)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_PhongHoc oDDM_PhongHoc = new cDDM_PhongHoc();
            DataTable dt = oDDM_PhongHoc.GetByIDToaNha(IDDM_ToaNha);
            return Convert.ToList<sp_DM_PhongHoc_GetByIDToaNhaResult>(dt);
        }

        public List<sp_DM_PhongHoc_GetKeHoachThucHanhResult> cDDM_PhongHoc_GetKeHoachThucHanh(string MaXacThuc, int IDDM_NamHoc, string NamHoc)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_PhongHoc oDDM_PhongHoc = new cDDM_PhongHoc();
            DataTable dt = oDDM_PhongHoc.GetKeHoachThucHanh(IDDM_NamHoc, NamHoc);
            return Convert.ToList<sp_DM_PhongHoc_GetKeHoachThucHanhResult>(dt);
        }

        public List<sp_DM_MonHoc_GetDanhSachResult> cDDM_MonHoc_GetDanhSach(string MaXacThuc, int IDDM_BoMon)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_MonHoc oDDM_MonHoc = new cDDM_MonHoc();
            DataTable dt = oDDM_MonHoc.GetDanhSach(IDDM_BoMon);
            return Convert.ToList<sp_DM_MonHoc_GetDanhSachResult>(dt);
        }

        public List<sp_DM_MonHoc_GetPhongHoc_MonHocResult> cDDM_MonHoc_GetPhongHoc_MonHoc(string MaXacThuc, int SuDungPhong)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_MonHoc oDDM_MonHoc = new cDDM_MonHoc();
            DataTable dt = oDDM_MonHoc.GetPhongHoc_MonHoc(SuDungPhong);
            return Convert.ToList<sp_DM_MonHoc_GetPhongHoc_MonHocResult>(dt);
        }

        public List<sp_DM_MonHoc_GetPhongChuyenMonResult> cDDM_MonHoc_GetPhongChuyenMon(string MaXacThuc, string IDDM_PhongHocs)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_MonHoc oDDM_MonHoc = new cDDM_MonHoc();
            DataTable dt = oDDM_MonHoc.GetPhongChuyenMon(IDDM_PhongHocs);
            return Convert.ToList<sp_DM_MonHoc_GetPhongChuyenMonResult>(dt);
        }

        public List<sp_DM_MonHoc_GetNotInIDCTKhoiKienThucResult> cDDM_MonHoc_GetNotInIDCTKhoiKienThuc(string MaXacThuc, int IDKQHT_CT_KhoiKienThuc)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_MonHoc oDDM_MonHoc = new cDDM_MonHoc();
            DataTable dt = oDDM_MonHoc.GetNotInIDCTKhoiKienThuc(IDKQHT_CT_KhoiKienThuc);
            return Convert.ToList<sp_DM_MonHoc_GetNotInIDCTKhoiKienThucResult>(dt);
        }

        public List<sp_DM_MonHoc_GetNotInIDGiaoVienResult> cDDM_MonHoc_GetNotInIDNSGiaoVien(string MaXacThuc, int IDNS_GiaoVien)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_MonHoc oDDM_MonHoc = new cDDM_MonHoc();
            DataTable dt = oDDM_MonHoc.GetNotInIDNSGiaoVien(IDNS_GiaoVien);
            return Convert.ToList<sp_DM_MonHoc_GetNotInIDGiaoVienResult>(dt);
        }

        public List<sp_DM_MonHoc_GetMonKyByLopResult> cDDM_MonHoc_GetMonKyByLop(string MaXacThuc, int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_MonHoc oDDM_MonHoc = new cDDM_MonHoc();
            DataTable dt = oDDM_MonHoc.GetMonKyByLop(IDDM_Lop, IDDM_NamHoc, HocKy);
            return Convert.ToList<sp_DM_MonHoc_GetMonKyByLopResult>(dt);
        }

        public List<sp_DM_MonHoc_GetMonThiTotNghiepResult> cDDM_MonHoc_GetMonThiTotNghiep(string MaXacThuc, int IDDM_NamHoc)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_MonHoc oDDM_MonHoc = new cDDM_MonHoc();
            DataTable dt = oDDM_MonHoc.GetMonThiTotNghiep(IDDM_NamHoc);
            return Convert.ToList<sp_DM_MonHoc_GetMonThiTotNghiepResult>(dt);
        }

        public string cDDM_MonHoc_CheckExistByMaMonHoc(string MaXacThuc, string MaMonHocs, bool MaMon)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_MonHoc oDDM_MonHoc = new cDDM_MonHoc();
            return oDDM_MonHoc.CheckExistByMaMonHoc(MaMonHocs, MaMon);
        }

        public int cDDM_MonHoc_AddByImport(string MaXacThuc, DM_MonHocInfo pDM_MonHocInfo, ref string Error)
        {
            if (MaXacThuc != "ABC") return 0;
            cDDM_MonHoc oDDM_MonHoc = new cDDM_MonHoc();
            return oDDM_MonHoc.AddByImport(pDM_MonHocInfo, ref Error);
        }

        public List<sp_NS_GiaoVien_GetByIDNS_DonViResult> cDNS_GiaoVien_GetByIDNS_DonVi(string MaXacThuc, int IDNS_DonVi)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.GetByIDNS_DonVi(IDNS_DonVi);
            return Convert.ToList<sp_NS_GiaoVien_GetByIDNS_DonViResult>(dt);
        }

        public List<sp_NS_GiaoVien_GetForLapTaiKhoanResult> cDNS_GiaoVien_GetForLapTaiKhoan(string MaXacThuc, int IDNS_DonVi, bool ChuaLapTaiKhoan)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.GetForLapTaiKhoan(IDNS_DonVi, ChuaLapTaiKhoan);
            return Convert.ToList<sp_NS_GiaoVien_GetForLapTaiKhoanResult>(dt);
        }

        public List<sp_NS_GiaoVien_NangBacChuyenNgach_GetByIDNS_DonViResult> cDNS_GiaoVien_NangBacChuyenNgach_GetByIDNS_DonVi(string MaXacThuc, int IDNS_DonVi)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.NangBacChuyenNgach_GetByIDNS_DonVi(IDNS_DonVi);
            return Convert.ToList<sp_NS_GiaoVien_NangBacChuyenNgach_GetByIDNS_DonViResult>(dt);
        }

        public List<sp_NS_GiaoVien_DangGiangDay_GetByIDNS_DonViResult> cDNS_GiaoVien_GetGiaoVien_DangGiangDay_ByIDNS_DonVi(string MaXacThuc, int IDNS_DonVi)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.GetGiaoVien_DangGiangDay_ByIDNS_DonVi(IDNS_DonVi);
            return Convert.ToList<sp_NS_GiaoVien_DangGiangDay_GetByIDNS_DonViResult>(dt);
        }

        public List<sp_GG_GiaoVien_GetBy_DonVi_ChucDanhResult> cDNS_GiaoVien_GetByIDNS_DonVi_ChucDanh(string MaXacThuc, int IDNS_DonVi, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.GetByIDNS_DonVi_ChucDanh(IDNS_DonVi, IDDM_NamHoc, HocKy);
            return Convert.ToList<sp_GG_GiaoVien_GetBy_DonVi_ChucDanhResult>(dt);
        }

        public List<NS_GiaoVienInfo> cDNS_GiaoVien_TongHopGioGiang(string MaXacThuc, int IDNS_DonVi, int NamHoc)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.TongHopGioGiang(IDNS_DonVi, NamHoc);
            return Convert.ToList<NS_GiaoVienInfo>(dt);
        }

        public List<NS_GiaoVienInfo> cDNS_GiaoVien_ChiTietGioGiang(string MaXacThuc, int IDNS_GiaoVien, int NamHoc)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.ChiTietGioGiang(IDNS_GiaoVien, NamHoc);
            return Convert.ToList<NS_GiaoVienInfo>(dt);
        }

        public List<sp_NS_GiaoVien_Get_TKBResult> cDNS_GiaoVien_Get_TKB(string MaXacThuc, int IDNS_DonVi)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.Get_TKB(IDNS_DonVi);
            return Convert.ToList<sp_NS_GiaoVien_Get_TKBResult>(dt);
        }

        public List<sp_NS_GiaoVien_GetByUserNameResult> cDNS_GiaoVien_GetByUsername(string MaXacThuc, string Username)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.GetByUsername(Username);
            return Convert.ToList<sp_NS_GiaoVien_GetByUserNameResult>(dt);
        }

        public List<NS_GiaoVienInfo> cDNS_GiaoVien_TimKiem(string MaXacThuc, NS_GiaoVienInfo pNS_GiaoVienInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.TimKiem(pNS_GiaoVienInfo);
            return Convert.ToList<NS_GiaoVienInfo>(dt);
        }

        public List<sp_NS_GiaoVien_GetBaoCaoChatLuongCanBoResult> cDNS_GiaoVien_GetBaoCaoChatLuongCanBo(string MaXacThuc, DateTime DenNgay)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.GetBaoCaoChatLuongCanBo(DenNgay);
            return Convert.ToList<sp_NS_GiaoVien_GetBaoCaoChatLuongCanBoResult>(dt);
        }

        public DataSet cDNS_GiaoVien_GetBaoCaoChatLuongDoiNguGiaoVien(string MaXacThuc, DateTime DenNgay)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            return oDNS_GiaoVien.GetBaoCaoChatLuongDoiNguGiaoVien(DenNgay);
        }

        public List<NS_GiaoVienInfo> cDNS_GiaoVien_UpdateDanhSach(string MaXacThuc, int IDNS_DonVi, string ChuoiNS_GiaoVienID)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.UpdateDanhSach(IDNS_DonVi, ChuoiNS_GiaoVienID);
            return Convert.ToList<NS_GiaoVienInfo>(dt);
        }

        public List<NS_GiaoVienInfo> cDNS_GiaoVien_UpdatePassword(string MaXacThuc, int IDNS_GiaoVien, string Password)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.UpdatePassword(IDNS_GiaoVien, Password);
            return Convert.ToList<NS_GiaoVienInfo>(dt);
        }

        public string cDNS_GiaoVien_UpdateTaiKhoan(string MaXacThuc, string Username, string Password, int NS_GiaoVienID)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            return oDNS_GiaoVien.UpdateTaiKhoan(Username, Password, NS_GiaoVienID);
        }

        public void cDNS_GiaoVien_UpdateIDDM_Khoa_GiaoVu(string MaXacThuc, int IDDM_Khoa_GiaoVu, int NS_GiaoVienID)
        {
            if (MaXacThuc != "ABC") return;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            oDNS_GiaoVien.UpdateIDDM_Khoa_GiaoVu(IDDM_Khoa_GiaoVu, NS_GiaoVienID);
        }

        public void cDNS_GiaoVien_UpdateAnhGiaoVien(string MaXacThuc, byte[] Anh, int NS_GiaoVienID)
        {
            if (MaXacThuc != "ABC") return;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            oDNS_GiaoVien.UpdateAnhGiaoVien(Anh, NS_GiaoVienID);
        }

        public void cDNS_GiaoVien_UpdateDonVi(string MaXacThuc, int NS_GiaoVienID, int IDNS_DonVi)
        {
            if (MaXacThuc != "ABC") return;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            oDNS_GiaoVien.UpdateDonVi(NS_GiaoVienID, IDNS_DonVi);
        }

        public List<sp_NS_GiaoVien_GetHoSoResult> cDNS_GiaoVien_GetHoSo(string MaXacThuc, int NS_GiaoVienID)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.GetHoSo(NS_GiaoVienID);
            return Convert.ToList<sp_NS_GiaoVien_GetHoSoResult>(dt);
        }

        public string cDNS_GiaoVien_CheckExistByMaGiaoVien(string MaXacThuc, string MaGiaoViens)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            return oDNS_GiaoVien.CheckExistByMaGiaoVien(MaGiaoViens);
        }

        public List<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhBoiDuongResult> cDNS_GiaoVien_Get_QuaTrinhBoiDuong(string MaXacThuc, int IDNS_GiaoVien)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.Get_QuaTrinhBoiDuong(IDNS_GiaoVien);
            return Convert.ToList<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhBoiDuongResult>(dt);
        }

        public List<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhBoNhiemChucVuResult> cDNS_GiaoVien_Get_QuaTrinhBoNhiemChucVu(string MaXacThuc, int IDNS_GiaoVien)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.Get_QuaTrinhBoNhiemChucVu(IDNS_GiaoVien);
            return Convert.ToList<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhBoNhiemChucVuResult>(dt);
        }

        public List<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhCongTacResult> cDNS_GiaoVien_Get_QuaTrinhCongTac(string MaXacThuc, int IDNS_GiaoVien)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.Get_QuaTrinhCongTac(IDNS_GiaoVien);
            return Convert.ToList<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhCongTacResult>(dt);
        }

        public List<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhKhenThuongResult> cDNS_GiaoVien_Get_QuaTrinhKhenThuong(string MaXacThuc, int IDNS_GiaoVien)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.Get_QuaTrinhKhenThuong(IDNS_GiaoVien);
            return Convert.ToList<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhKhenThuongResult>(dt);
        }

        public List<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhKyLuatResult> cDNS_GiaoVien_Get_QuaTrinhKyLuat(string MaXacThuc, int IDNS_GiaoVien)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.Get_QuaTrinhKyLuat(IDNS_GiaoVien);
            return Convert.ToList<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhKyLuatResult>(dt);
        }

        public List<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhLuanChuyenResult> cDNS_GiaoVien_Get_QuaTrinhLuanChuyen(string MaXacThuc, int IDNS_GiaoVien)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.Get_QuaTrinhLuanChuyen(IDNS_GiaoVien);
            return Convert.ToList<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhLuanChuyenResult>(dt);
        }

        public List<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhMienNhiemTuChucResult> cDNS_GiaoVien_Get_QuaTrinhMienNhiemTuChuc(string MaXacThuc, int IDNS_GiaoVien)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.Get_QuaTrinhMienNhiemTuChuc(IDNS_GiaoVien);
            return Convert.ToList<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhMienNhiemTuChucResult>(dt);
        }

        public List<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhThamGiaLLVTResult> cDNS_GiaoVien_Get_QuaTrinhThamGiaLLVT(string MaXacThuc, int IDNS_GiaoVien)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.Get_QuaTrinhThamGiaLLVT(IDNS_GiaoVien);
            return Convert.ToList<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhThamGiaLLVTResult>(dt);
        }

        public List<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhThamGiaTCCTXHResult> cDNS_GiaoVien_Get_QuaTrinhThamGiaTCCTXH(string MaXacThuc, int IDNS_GiaoVien)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.Get_QuaTrinhThamGiaTCCTXH(IDNS_GiaoVien);
            return Convert.ToList<sp_NS_TongHopCacQuaTrinh_Get_QuaTrinhThamGiaTCCTXHResult>(dt);
        }

        public List<NS_GiaoVienInfo> cDNS_GiaoVien_LocGiaoVien(string MaXacThuc, int IDNS_DonVi, string HoTen)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.LocGiaoVien(IDNS_DonVi, HoTen);
            return Convert.ToList<NS_GiaoVienInfo>(dt);
        }

        public List<sp_NS_GiaoVien_GetMaLonNhatResult> cDNS_GiaoVien_GetMaLonNhat(string MaXacThuc, int DoDaiMa, string PhanDauMa, string PhanCuoiMa)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.GetMaLonNhat(DoDaiMa, PhanDauMa, PhanCuoiMa);
            return Convert.ToList<sp_NS_GiaoVien_GetMaLonNhatResult>(dt);
        }

        public int cDNS_GiaoVien_UpdateMaGiaoVien(string MaXacThuc, string MaGiaoVien, int NS_GiaoVienID)
        {
            if (MaXacThuc != "ABC") return 0;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            return oDNS_GiaoVien.UpdateMaGiaoVien(MaGiaoVien, NS_GiaoVienID);
        }

        public List<sp_NS_GiaoVien_Get_SoYeuLyLichResult> cDNS_GiaoVien_Get_SoYeuLyLich(string MaXacThuc, int NS_GiaoVienID)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.Get_SoYeuLyLich(NS_GiaoVienID);
            return Convert.ToList<sp_NS_GiaoVien_Get_SoYeuLyLichResult>(dt);
        }

        public List<sp_NS_GiaoVien_Get_CanhBaoHanNghiHuuResult> cDNS_GiaoVien_Get_CanhBaoHanNghiHuu(string MaXacThuc, int HanCanhBao, DateTime TinhDenNgay)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.Get_CanhBaoHanNghiHuu(HanCanhBao, TinhDenNgay);
            return Convert.ToList<sp_NS_GiaoVien_Get_CanhBaoHanNghiHuuResult>(dt);
        }

        public List<sp_NS_GiaoVien_Get_CanhBaoHetNhiemKyResult> cDNS_GiaoVien_Get_CanhBaoHetNhiemKy(string MaXacThuc, int HanCanhBao, DateTime TinhDenNgay)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_GiaoVien oDNS_GiaoVien = new cDNS_GiaoVien();
            DataTable dt = oDNS_GiaoVien.Get_CanhBaoHetNhiemKy(HanCanhBao, TinhDenNgay);
            return Convert.ToList<sp_NS_GiaoVien_Get_CanhBaoHetNhiemKyResult>(dt);
        }

        public List<sp_KQHT_ThanhPhanDiem_GetByIDTrinhDoResult> cDKQHT_ThanhPhanDiem_GetByIDTrinhDo(string MaXacThuc, int IDDM_TrinhDo)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_ThanhPhanDiem oDKQHT_ThanhPhanDiem = new cDKQHT_ThanhPhanDiem();
            DataTable dt = oDKQHT_ThanhPhanDiem.GetByIDTrinhDo(IDDM_TrinhDo);
            return Convert.ToList<sp_KQHT_ThanhPhanDiem_GetByIDTrinhDoResult>(dt);
        }

        public List<sp_TC_LoaiThuChi_GetBy_IDNamHoc_HocKyResult> cDTC_LoaiThuChi_GetBy_IDNamHoc_HocKy(string MaXacThuc, int IDNamHoc, int HocKy, bool HasParent)
        {
            if (MaXacThuc != "ABC") return null;
            cDTC_LoaiThuChi oDTC_LoaiThuChi = new cDTC_LoaiThuChi();
            DataTable dt = oDTC_LoaiThuChi.GetBy_IDNamHoc_HocKy(IDNamHoc, HocKy, HasParent);
            return Convert.ToList<sp_TC_LoaiThuChi_GetBy_IDNamHoc_HocKyResult>(dt);
        }

        public List<sp_DM_TinhHuyenXa_GetByCapResult> cDDM_TinhHuyenXa_GetByCap(string MaXacThuc, int Level, int ParentID)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_TinhHuyenXa oDDM_TinhHuyenXa = new cDDM_TinhHuyenXa();
            DataTable dt = oDDM_TinhHuyenXa.GetByCap(Level, ParentID);
            return Convert.ToList<sp_DM_TinhHuyenXa_GetByCapResult>(dt);
        }

        public List<sp_DM_TinhHuyenXa_GetTinhResult> cDDM_TinhHuyenXa_GetTinh(string MaXacThuc, int DM_TinhHuyenXaID)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_TinhHuyenXa oDDM_TinhHuyenXa = new cDDM_TinhHuyenXa();
            DataTable dt = oDDM_TinhHuyenXa.GetTinh(DM_TinhHuyenXaID);
            return Convert.ToList<sp_DM_TinhHuyenXa_GetTinhResult>(dt);
        }

        public string cDDM_TinhHuyenXa_CheckExistByMa(string MaXacThuc, string Mas)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_TinhHuyenXa oDDM_TinhHuyenXa = new cDDM_TinhHuyenXa();
            return oDDM_TinhHuyenXa.CheckExistByMa(Mas);
        }

        public int cDDM_TinhHuyenXa_AddByImport(string MaXacThuc, DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo, string MaCha)
        {
            if (MaXacThuc != "ABC") return 0;
            cDDM_TinhHuyenXa oDDM_TinhHuyenXa = new cDDM_TinhHuyenXa();
            return oDDM_TinhHuyenXa.AddByImport(pDM_TinhHuyenXaInfo, MaCha);
        }


        public void cDHT_User_UpdateChucNang(string MaXacThuc, int HT_UserID, int IDHT_UserGroup)
        {
            if (MaXacThuc != "ABC") return;
            cDHT_User oDHT_User = new cDHT_User();
            oDHT_User.UpdateChucNang(HT_UserID, IDHT_UserGroup);
        }

        public List<sp_HT_User_GetChucNangResult> cDHT_User_GetChucNang(string MaXacThuc, string UserName)
        {
            if (MaXacThuc != "ABC") return null;
            cDHT_User oDHT_User = new cDHT_User();
            DataTable dt = oDHT_User.GetChucNang(UserName);
            return Convert.ToList<sp_HT_User_GetChucNangResult>(dt);
        }

        public List<sp_HT_User_GetByUserNameResult> cDHT_User_GetByUserName(string MaXacThuc, string UserName)
        {
            if (MaXacThuc != "ABC") return null;
            cDHT_User oDHT_User = new cDHT_User();
            DataTable dt = oDHT_User.GetByUserName(UserName);
            return Convert.ToList<sp_HT_User_GetByUserNameResult>(dt);
        }

        public List<sp_HT_ThamSoHeThong_GetByMaThamSoResult> cDHT_ThamSoHeThong_GetByMaThamSo(string MaXacThuc, string MaThamSoHeThong)
        {
            if (MaXacThuc != "ABC") return null;
            cDHT_ThamSoHeThong oDHT_ThamSoHeThong = new cDHT_ThamSoHeThong();
            DataTable dt = oDHT_ThamSoHeThong.GetByMaThamSo(MaThamSoHeThong);
            return Convert.ToList<sp_HT_ThamSoHeThong_GetByMaThamSoResult>(dt);
        }

        public List<sp_HT_ThamSoHeThong_GetByPhanHeResult> cDHT_ThamSoHeThong_GetByPhanHe(string MaXacThuc, int PhanHe)
        {
            if (MaXacThuc != "ABC") return null;
            cDHT_ThamSoHeThong oDHT_ThamSoHeThong = new cDHT_ThamSoHeThong();
            DataTable dt = oDHT_ThamSoHeThong.GetByPhanHe(PhanHe);
            return Convert.ToList<sp_HT_ThamSoHeThong_GetByPhanHeResult>(dt);
        }


        public List<sp_KQHT_ChuongTrinhDaoTao_GetDanhSachResult> cDKQHT_ChuongTrinhDaoTao_GetDanhSach(string MaXacThuc, int IDDM_TrinhDo)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_ChuongTrinhDaoTao oDKQHT_ChuongTrinhDaoTao = new cDKQHT_ChuongTrinhDaoTao();
            DataTable dt = oDKQHT_ChuongTrinhDaoTao.GetDanhSach(IDDM_TrinhDo);
            return Convert.ToList<sp_KQHT_ChuongTrinhDaoTao_GetDanhSachResult>(dt);
        }

        public List<sp_KQHT_ChuongTrinhDaoTao_GetChiTietResult> cDKQHT_ChuongTrinhDaoTao_GetChiTiet(string MaXacThuc, int KQHT_ChuongTrinhDaoTaoID)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_ChuongTrinhDaoTao oDKQHT_ChuongTrinhDaoTao = new cDKQHT_ChuongTrinhDaoTao();
            DataTable dt = oDKQHT_ChuongTrinhDaoTao.GetChiTiet(KQHT_ChuongTrinhDaoTaoID);
            return Convert.ToList<sp_KQHT_ChuongTrinhDaoTao_GetChiTietResult>(dt);
        }

        public List<sp_KQHT_ChuongTrinhDaoTao_GetLopResult> cDKQHT_ChuongTrinhDaoTao_GetLop(string MaXacThuc, int IDKQHT_ChuongTrinhDaoTao)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_ChuongTrinhDaoTao oDKQHT_ChuongTrinhDaoTao = new cDKQHT_ChuongTrinhDaoTao();
            DataTable dt = oDKQHT_ChuongTrinhDaoTao.GetLop(IDKQHT_ChuongTrinhDaoTao);
            return Convert.ToList<sp_KQHT_ChuongTrinhDaoTao_GetLopResult>(dt);
        }

        public List<sp_KQHT_ChuongTrinhDaoTao_GetMonKhungResult> cDKQHT_ChuongTrinhDaoTao_GetMonKhung(string MaXacThuc, int KQHT_ChuongTrinhDaoTaoID, int IDDM_Lop, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_ChuongTrinhDaoTao oDKQHT_ChuongTrinhDaoTao = new cDKQHT_ChuongTrinhDaoTao();
            DataTable dt = oDKQHT_ChuongTrinhDaoTao.GetMonKhung(KQHT_ChuongTrinhDaoTaoID, IDDM_Lop, HocKy);
            return Convert.ToList<sp_KQHT_ChuongTrinhDaoTao_GetMonKhungResult>(dt);
        }

        public List<sp_KQHT_ChuongTrinhDaoTao_GetMonChuaToChucResult> cDKQHT_ChuongTrinhDaoTao_GetMonChuaToChuc(string MaXacThuc, int KQHT_ChuongTrinhDaoTaoID, int IDDM_Lop, int CTDT_HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_ChuongTrinhDaoTao oDKQHT_ChuongTrinhDaoTao = new cDKQHT_ChuongTrinhDaoTao();
            DataTable dt = oDKQHT_ChuongTrinhDaoTao.GetMonChuaToChuc(KQHT_ChuongTrinhDaoTaoID, IDDM_Lop, CTDT_HocKy);
            return Convert.ToList<sp_KQHT_ChuongTrinhDaoTao_GetMonChuaToChucResult>(dt);
        }



        public List<sp_KQHT_MonHoc_CT_KhoiKienThuc_GetDanhSachResult> cDKQHT_MonHoc_CT_KhoiKienThuc_GetDanhSach(string MaXacThuc, int IDKQHT_CT_KhoiKienThuc)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_MonHoc_CT_KhoiKienThuc oDKQHT_MonHoc_CT_KhoiKienThuc = new cDKQHT_MonHoc_CT_KhoiKienThuc();
            DataTable dt = oDKQHT_MonHoc_CT_KhoiKienThuc.GetDanhSach(IDKQHT_CT_KhoiKienThuc);
            return Convert.ToList<sp_KQHT_MonHoc_CT_KhoiKienThuc_GetDanhSachResult>(dt);
        }



        public void cDXL_PhanCongGiaoVien_DeleteByMonHoc(string MaXacThuc, int IDXL_MonHocTrongKy, string IDNS_GiaoViens)
        {
            if (MaXacThuc != "ABC") return;
            cDXL_PhanCongGiaoVien oDXL_PhanCongGiaoVien = new cDXL_PhanCongGiaoVien();
            oDXL_PhanCongGiaoVien.DeleteByMonHoc(IDXL_MonHocTrongKy, IDNS_GiaoViens);
        }

        public List<sp_XL_PhanCongGiaoVien_GetByMonHocTrongKyResult> cDXL_PhanCongGiaoVien_GetByMonHocTrongKy(string MaXacThuc, int IDXL_MonHocTrongKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_PhanCongGiaoVien oDXL_PhanCongGiaoVien = new cDXL_PhanCongGiaoVien();
            DataTable dt = oDXL_PhanCongGiaoVien.GetByMonHocTrongKy(IDXL_MonHocTrongKy);
            return Convert.ToList<sp_XL_PhanCongGiaoVien_GetByMonHocTrongKyResult>(dt);
        }

        public List<sp_XL_PhanCongGiaoVien_GetGiaoVienResult> cDXL_PhanCongGiaoVien_GetGiaoVien(string MaXacThuc, int IDXL_MonHocTrongKy, int IDNS_GiaoVien)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_PhanCongGiaoVien oDXL_PhanCongGiaoVien = new cDXL_PhanCongGiaoVien();
            DataTable dt = oDXL_PhanCongGiaoVien.GetGiaoVien(IDXL_MonHocTrongKy, IDNS_GiaoVien);
            return Convert.ToList<sp_XL_PhanCongGiaoVien_GetGiaoVienResult>(dt);
        }

        public List<sp_XL_PhanCongGiaoVien_GetGiaoVienByMonHocTrongKyResult> cDXL_PhanCongGiaoVien_GetGiaoVienByMonHocTrongKy(string MaXacThuc, int IDXL_MonHocTrongKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_PhanCongGiaoVien oDXL_PhanCongGiaoVien = new cDXL_PhanCongGiaoVien();
            DataTable dt = oDXL_PhanCongGiaoVien.GetGiaoVienByMonHocTrongKy(IDXL_MonHocTrongKy);
            return Convert.ToList<sp_XL_PhanCongGiaoVien_GetGiaoVienByMonHocTrongKyResult>(dt);
        }

        public void cDKQHT_CTDT_ChiTiet_DeleteByHocKy(string MaXacThuc, KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_CTDT_ChiTiet oDKQHT_CTDT_ChiTiet = new cDKQHT_CTDT_ChiTiet();
            oDKQHT_CTDT_ChiTiet.DeleteByHocKy(pKQHT_CTDT_ChiTietInfo);
        }

        public List<sp_KQHT_CT_KhoiKienThuc_GetDanhSachResult> cDKQHT_CT_KhoiKienThuc_GetDanhSach(string MaXacThuc, int IDDM_KhoiKienThuc)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_CT_KhoiKienThuc oDKQHT_CT_KhoiKienThuc = new cDKQHT_CT_KhoiKienThuc();
            DataTable dt = oDKQHT_CT_KhoiKienThuc.GetDanhSach(IDDM_KhoiKienThuc);
            return Convert.ToList<sp_KQHT_CT_KhoiKienThuc_GetDanhSachResult>(dt);
        }

        public List<sp_KQHT_CT_KhoiKienThuc_GetChonResult> cDKQHT_CT_KhoiKienThuc_GetChon(string MaXacThuc, int IDKQHT_ChuongTrinhDaoTao)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_CT_KhoiKienThuc oDKQHT_CT_KhoiKienThuc = new cDKQHT_CT_KhoiKienThuc();
            DataTable dt = oDKQHT_CT_KhoiKienThuc.GetChon(IDKQHT_ChuongTrinhDaoTao);
            return Convert.ToList<sp_KQHT_CT_KhoiKienThuc_GetChonResult>(dt);
        }

        public int cDKQHT_CT_KhoiKienThuc_AddKeThua(string MaXacThuc, KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo, int IDKQHT_CT_KhoiKienThucGoc)
        {
            if (MaXacThuc != "ABC") return 0;
            cDKQHT_CT_KhoiKienThuc oDKQHT_CT_KhoiKienThuc = new cDKQHT_CT_KhoiKienThuc();
            return oDKQHT_CT_KhoiKienThuc.AddKeThua(pKQHT_CT_KhoiKienThucInfo, IDKQHT_CT_KhoiKienThucGoc);
        }

        public List<sp_XL_PhongHoc_MonHoc_GetByIDMonHocResult> cDXL_PhongHoc_MonHoc_GetByIDDM_MonHoc(string MaXacThuc, int IDDM_MonHoc)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_PhongHoc_MonHoc oDXL_PhongHoc_MonHoc = new cDXL_PhongHoc_MonHoc();
            DataTable dt = oDXL_PhongHoc_MonHoc.GetByIDDM_MonHoc(IDDM_MonHoc);
            return Convert.ToList<sp_XL_PhongHoc_MonHoc_GetByIDMonHocResult>(dt);
        }

        public void cDXL_PhongHoc_MonHoc_DeleteByMonPhong(string MaXacThuc, int IDDM_PhongHoc, int IDDM_MonHoc)
        {
            if (MaXacThuc != "ABC") return;
            cDXL_PhongHoc_MonHoc oDXL_PhongHoc_MonHoc = new cDXL_PhongHoc_MonHoc();
            oDXL_PhongHoc_MonHoc.DeleteByMonPhong(IDDM_PhongHoc, IDDM_MonHoc);
        }




        public List<sp_XL_GiaoVien_MonHoc_GetDanhSachResult> cDXL_GiaoVien_MonHoc_GetDanhSach(string MaXacThuc, XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_GiaoVien_MonHoc oDXL_GiaoVien_MonHoc = new cDXL_GiaoVien_MonHoc();
            DataTable dt = oDXL_GiaoVien_MonHoc.GetDanhSach(pXL_GiaoVien_MonHocInfo);
            return Convert.ToList<sp_XL_GiaoVien_MonHoc_GetDanhSachResult>(dt);
        }

        public List<sp_XL_GiaoVien_MonHoc_GetByIDDM_MonHocResult> cDXL_GiaoVien_MonHoc_GetByIDDM_MonHoc(string MaXacThuc, int IDDM_MonHoc, string IDNS_GiaoVien)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_GiaoVien_MonHoc oDXL_GiaoVien_MonHoc = new cDXL_GiaoVien_MonHoc();
            DataTable dt = oDXL_GiaoVien_MonHoc.GetByIDDM_MonHoc(IDDM_MonHoc, IDNS_GiaoVien);
            return Convert.ToList<sp_XL_GiaoVien_MonHoc_GetByIDDM_MonHocResult>(dt);
        }

        public List<XL_GiaoVien_MonHocInfo> cDXL_GiaoVien_MonHoc_GetByIDDM_MonHocs(string MaXacThuc, string IDDM_MonHocs)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_GiaoVien_MonHoc oDXL_GiaoVien_MonHoc = new cDXL_GiaoVien_MonHoc();
            DataTable dt = oDXL_GiaoVien_MonHoc.GetByIDDM_MonHocs(IDDM_MonHocs);
            return Convert.ToList<XL_GiaoVien_MonHocInfo>(dt);
        }

        public List<sp_XL_GiaoVien_MonHoc_GetByMonLopResult> cDXL_GiaoVien_MonHoc_GetByMonLop(string MaXacThuc, int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_GiaoVien_MonHoc oDXL_GiaoVien_MonHoc = new cDXL_GiaoVien_MonHoc();
            DataTable dt = oDXL_GiaoVien_MonHoc.GetByMonLop(IDDM_Lop, IDDM_NamHoc, HocKy);
            return Convert.ToList<sp_XL_GiaoVien_MonHoc_GetByMonLopResult>(dt);
        }






        public List<sp_KQHT_DiemThi_GetDanhSachResult> cDKQHT_DiemThi_GetDanhSach(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemThi oDKQHT_DiemThi = new cDKQHT_DiemThi();
            DataTable dt = oDKQHT_DiemThi.GetDanhSach(IDDM_Lop, IDDM_MonHoc, IDXL_MonHocTrongKy, IDDM_NamHoc, HocKy, LanThi);
            return Convert.ToList<sp_KQHT_DiemThi_GetDanhSachResult>(dt);
        }

        public List<sp_KQHT_DiemThi_GetByLopResult> cDKQHT_DiemThi_GetByLop(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemThi oDKQHT_DiemThi = new cDKQHT_DiemThi();
            DataTable dt = oDKQHT_DiemThi.GetByLop(IDDM_Lop, IDDM_MonHoc, IDXL_MonHocTrongKy, IDDM_NamHoc, HocKy);
            return Convert.ToList<sp_KQHT_DiemThi_GetByLopResult>(dt);
        }

        public List<sp_KQHT_DiemThi_ChoNhapLaiDiem_GetByLopResult> cDKQHT_DiemThi_ChoNhapLaiDiem_GetByLop(string MaXacThuc, int IDKQHT_ChoNhapLaiDiem)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemThi oDKQHT_DiemThi = new cDKQHT_DiemThi();
            DataTable dt = oDKQHT_DiemThi.ChoNhapLaiDiem_GetByLop(IDKQHT_ChoNhapLaiDiem);
            return Convert.ToList<sp_KQHT_DiemThi_ChoNhapLaiDiem_GetByLopResult>(dt);
        }

        public List<sp_KQHT_DiemThi_GetDanhSachThiLaiResult> cDKQHT_DiemThi_GetDanhSachThiLai(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemThi oDKQHT_DiemThi = new cDKQHT_DiemThi();
            DataTable dt = oDKQHT_DiemThi.GetDanhSachThiLai(IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi);
            return Convert.ToList<sp_KQHT_DiemThi_GetDanhSachThiLaiResult>(dt);
        }

        public List<sp_KQHT_DiemThi_GetDanhSachKhongQuaResult> cDKQHT_DiemThi_GetDanhSachKhongQua(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemThi oDKQHT_DiemThi = new cDKQHT_DiemThi();
            DataTable dt = oDKQHT_DiemThi.GetDanhSachKhongQua(IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi);
            return Convert.ToList<sp_KQHT_DiemThi_GetDanhSachKhongQuaResult>(dt);
        }

        public List<KQHT_DiemThiInfo> cDKQHT_DiemThi_GetSinhVien(string MaXacThuc, int KQHT_ToChucThiID)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemThi oDKQHT_DiemThi = new cDKQHT_DiemThi();
            DataTable dt = oDKQHT_DiemThi.GetSinhVien(KQHT_ToChucThiID);
            return Convert.ToList<KQHT_DiemThiInfo>(dt);
        }

        public void cDKQHT_DiemThi_DeleteByInfo(string MaXacThuc, KQHT_DiemThiInfo pKQHT_DiemThiInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DiemThi oDKQHT_DiemThi = new cDKQHT_DiemThi();
            oDKQHT_DiemThi.DeleteByInfo(pKQHT_DiemThiInfo);
        }

        public List<sp_KQHT_DiemThanhPhan_GetDanhSachResult> cDKQHT_DiemThanhPhan_GetDanhSach(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int XL_MonHocTrongKyID, int IDDM_NamHoc, int HocKy, int LanThi, int KQHT_ChoNhapLaiDiemID)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemThanhPhan oDKQHT_DiemThanhPhan = new cDKQHT_DiemThanhPhan();
            DataTable dt = oDKQHT_DiemThanhPhan.GetDanhSach(IDDM_Lop, IDDM_MonHoc, XL_MonHocTrongKyID, IDDM_NamHoc, HocKy, LanThi, KQHT_ChoNhapLaiDiemID);
            return Convert.ToList<sp_KQHT_DiemThanhPhan_GetDanhSachResult>(dt);
        }

        public List<sp_KQHT_DiemThanhPhan_ChoNhapLaiDiem_GetDanhSachResult> cDKQHT_DiemThanhPhan_ChoNhapLaiDiem_GetDanhSach(string MaXacThuc, int IDKQHT_ChoNhapLaiDiem)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemThanhPhan oDKQHT_DiemThanhPhan = new cDKQHT_DiemThanhPhan();
            DataTable dt = oDKQHT_DiemThanhPhan.ChoNhapLaiDiem_GetDanhSach(IDKQHT_ChoNhapLaiDiem);
            return Convert.ToList<sp_KQHT_DiemThanhPhan_ChoNhapLaiDiem_GetDanhSachResult>(dt);
        }

        public List<sp_KQHT_DiemThanhPhan_KiemTraDiemResult> cDKQHT_DiemThanhPhan_KiemTraDiem(string MaXacThuc, int IDSV_SinhVien, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemThanhPhan oDKQHT_DiemThanhPhan = new cDKQHT_DiemThanhPhan();
            DataTable dt = oDKQHT_DiemThanhPhan.KiemTraDiem(IDSV_SinhVien, IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy);
            return Convert.ToList<sp_KQHT_DiemThanhPhan_KiemTraDiemResult>(dt);
        }

        public void cDKQHT_DiemThanhPhan_DeleteBy_SinhVien(string MaXacThuc, int IDSV_SinhVien, int LanThi, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int IDKQHT_ThanhPhanDiem)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DiemThanhPhan oDKQHT_DiemThanhPhan = new cDKQHT_DiemThanhPhan();
            oDKQHT_DiemThanhPhan.DeleteBy_SinhVien(IDSV_SinhVien, LanThi, IDDM_MonHoc, IDDM_NamHoc, HocKy, IDKQHT_ThanhPhanDiem);
        }

        public void cDKQHT_DiemThanhPhan_DeleteByInfo(string MaXacThuc, KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DiemThanhPhan oDKQHT_DiemThanhPhan = new cDKQHT_DiemThanhPhan();
            oDKQHT_DiemThanhPhan.DeleteByInfo(pKQHT_DiemThanhPhanInfo);
        }

        public int cDKQHT_DiemThanhPhan_AddByImport(string MaXacThuc, KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo, int LanThi, string MaSinhVien)
        {
            if (MaXacThuc != "ABC") return 0;
            cDKQHT_DiemThanhPhan oDKQHT_DiemThanhPhan = new cDKQHT_DiemThanhPhan();
            return oDKQHT_DiemThanhPhan.AddByImport(pKQHT_DiemThanhPhanInfo, LanThi, MaSinhVien);
        }

        public List<sp_KQHT_DiemTongKetMon_GetDanhSachResult> cDKQHT_DiemTongKetMon_GetDanhSach(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi, int Kieu)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemTongKetMon oDKQHT_DiemTongKetMon = new cDKQHT_DiemTongKetMon();
            DataTable dt = oDKQHT_DiemTongKetMon.GetDanhSach(IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi, Kieu);
            return Convert.ToList<sp_KQHT_DiemTongKetMon_GetDanhSachResult>(dt);
        }

        public List<sp_KQHT_DiemTongKetMon_GetDanhSachNhapDiemResult> cDKQHT_DiemTongKetMon_GetDanhSachNhapDiem(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemTongKetMon oDKQHT_DiemTongKetMon = new cDKQHT_DiemTongKetMon();
            DataTable dt = oDKQHT_DiemTongKetMon.GetDanhSachNhapDiem(IDDM_Lop, IDDM_MonHoc, IDXL_MonHocTrongKy, IDDM_NamHoc, HocKy, LanThi);
            return Convert.ToList<sp_KQHT_DiemTongKetMon_GetDanhSachNhapDiemResult>(dt);
        }

        public List<sp_KQHT_DiemTongKetMon_GetByLopResult> cDKQHT_DiemTongKetMon_GetByLop(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemTongKetMon oDKQHT_DiemTongKetMon = new cDKQHT_DiemTongKetMon();
            DataTable dt = oDKQHT_DiemTongKetMon.GetByLop(IDDM_Lop, IDDM_MonHoc, IDXL_MonHocTrongKy, IDDM_NamHoc, HocKy);
            return Convert.ToList<sp_KQHT_DiemTongKetMon_GetByLopResult>(dt);
        }

        public List<sp_KQHT_DiemTongKetMon_ChoNhapLaiDiem_GetByLopResult> cDKQHT_DiemTongKetMon_ChoNhapLaiDiem_GetByLop(string MaXacThuc, int IDKQHT_ChoNhapLaiDiem)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemTongKetMon oDKQHT_DiemTongKetMon = new cDKQHT_DiemTongKetMon();
            DataTable dt = oDKQHT_DiemTongKetMon.ChoNhapLaiDiem_GetByLop(IDKQHT_ChoNhapLaiDiem);
            return Convert.ToList<sp_KQHT_DiemTongKetMon_ChoNhapLaiDiem_GetByLopResult>(dt);
        }

        public List<sp_KQHT_DiemTongKetMon_GetMonKyResult> cDKQHT_DiemTongKetMon_GetMonKy(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemTongKetMon oDKQHT_DiemTongKetMon = new cDKQHT_DiemTongKetMon();
            DataTable dt = oDKQHT_DiemTongKetMon.GetMonKy(IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi);
            return Convert.ToList<sp_KQHT_DiemTongKetMon_GetMonKyResult>(dt);
        }

        public List<sp_KQHT_DiemTongKetMon_GetSoMonCoDiemByLopResult> cDKQHT_DiemTongKetMon_GetSoMonCoDiemByLop(string MaXacThuc, int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemTongKetMon oDKQHT_DiemTongKetMon = new cDKQHT_DiemTongKetMon();
            DataTable dt = oDKQHT_DiemTongKetMon.GetSoMonCoDiemByLop(IDDM_Lop, IDDM_NamHoc, HocKy);
            return Convert.ToList<sp_KQHT_DiemTongKetMon_GetSoMonCoDiemByLopResult>(dt);
        }

        public List<KQHT_DiemTongKetMonInfo> cDKQHT_DiemTongKetMon_GetDiemThucTapTotNghiep(string MaXacThuc, DM_LopInfo pDM_LopInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemTongKetMon oDKQHT_DiemTongKetMon = new cDKQHT_DiemTongKetMon();
            DataTable dt = oDKQHT_DiemTongKetMon.GetDiemThucTapTotNghiep(pDM_LopInfo);
            return Convert.ToList<KQHT_DiemTongKetMonInfo>(dt);
        }

        public int cDKQHT_DiemTongKetMon_AddByImport(string MaXacThuc, KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo, string MaSinhVien)
        {
            if (MaXacThuc != "ABC") return 0;
            cDKQHT_DiemTongKetMon oDKQHT_DiemTongKetMon = new cDKQHT_DiemTongKetMon();
            return oDKQHT_DiemTongKetMon.AddByImport(pKQHT_DiemTongKetMonInfo, MaSinhVien);
        }

        public void cDKQHT_DiemTongKetMon_DeleteByIDMonHocTrongKy(string MaXacThuc, int IDSV_SinhVien, long IDXL_MonHocTrongKy, int LanThi)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DiemTongKetMon oDKQHT_DiemTongKetMon = new cDKQHT_DiemTongKetMon();
            oDKQHT_DiemTongKetMon.DeleteByIDMonHocTrongKy(IDSV_SinhVien, IDXL_MonHocTrongKy, LanThi);
        }

        public List<sp_KQHT_DiemDanh_GetDanhSachResult> cDKQHT_DiemDanh_GetDanhSach(string MaXacThuc, int IDDM_Lop, int IDXL_MonHocTrongKy, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemDanh oDKQHT_DiemDanh = new cDKQHT_DiemDanh();
            DataTable dt = oDKQHT_DiemDanh.GetDanhSach(IDDM_Lop, IDXL_MonHocTrongKy, IDDM_NamHoc, HocKy);
            return Convert.ToList<sp_KQHT_DiemDanh_GetDanhSachResult>(dt);
        }

        public List<sp_KQHT_DiemDanh_GetByLopResult> cDKQHT_DiemDanh_GetByLop(string MaXacThuc, int IDDM_Lop, int IDXL_MonHocTrongKy, int DiemLan)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemDanh oDKQHT_DiemDanh = new cDKQHT_DiemDanh();
            DataTable dt = oDKQHT_DiemDanh.GetByLop(IDDM_Lop, IDXL_MonHocTrongKy, DiemLan);
            return Convert.ToList<sp_KQHT_DiemDanh_GetByLopResult>(dt);
        }

        public List<sp_KQHT_DiemDanh_ChoNhapLaiDiem_GetByLopResult> cDKQHT_DiemDanh_ChoNhapLaiDiem_GetByLop(string MaXacThuc, int IDKQHT_ChoNhapLaiDiem)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemDanh oDKQHT_DiemDanh = new cDKQHT_DiemDanh();
            DataTable dt = oDKQHT_DiemDanh.ChoNhapLaiDiem_GetByLop(IDKQHT_ChoNhapLaiDiem);
            return Convert.ToList<sp_KQHT_DiemDanh_ChoNhapLaiDiem_GetByLopResult>(dt);
        }

        public void cDKQHT_DiemDanh_DeleteByInfo(string MaXacThuc, int IDSV_SinhVien, int IDXL_MonHocTrongKy, string LyDo, int DiemLan)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DiemDanh oDKQHT_DiemDanh = new cDKQHT_DiemDanh();
            oDKQHT_DiemDanh.DeleteByInfo(IDSV_SinhVien, IDXL_MonHocTrongKy, LyDo, DiemLan);
        }

        public List<sp_KQHT_DanhSachDuThi_GetByIDToChucThiResult> cDKQHT_DanhSachDuThi_GetByIDToChucThi(string MaXacThuc, int IDKQHT_ToChucThi)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DanhSachDuThi oDKQHT_DanhSachDuThi = new cDKQHT_DanhSachDuThi();
            DataTable dt = oDKQHT_DanhSachDuThi.GetByIDToChucThi(IDKQHT_ToChucThi);
            return Convert.ToList<sp_KQHT_DanhSachDuThi_GetByIDToChucThiResult>(dt);
        }

        public List<sp_KQHT_DanhSachDuThi_GetDanhSachResult> cDKQHT_DanhSachDuThi_GetDanhSach(string MaXacThuc, int IDDM_Lop, long IDXL_MonHocTrongKy, int LanThi)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DanhSachDuThi oDKQHT_DanhSachDuThi = new cDKQHT_DanhSachDuThi();
            DataTable dt = oDKQHT_DanhSachDuThi.GetDanhSach(IDDM_Lop, IDXL_MonHocTrongKy, LanThi);
            return Convert.ToList<sp_KQHT_DanhSachDuThi_GetDanhSachResult>(dt);
        }

        public List<sp_KQHT_DanhSachDuThi_GetNhapDiemResult> cDKQHT_DanhSachDuThi_GetNhapDiem(string MaXacThuc, long IDXL_MonHocTrongKy, int LanThi)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DanhSachDuThi oDKQHT_DanhSachDuThi = new cDKQHT_DanhSachDuThi();
            DataTable dt = oDKQHT_DanhSachDuThi.GetNhapDiem(IDXL_MonHocTrongKy, LanThi);
            return Convert.ToList<sp_KQHT_DanhSachDuThi_GetNhapDiemResult>(dt);
        }

        public List<sp_KQHT_DanhSachDuThi_GetDaChuyenDiemByMonHocTrongKyResult> cDKQHT_DanhSachDuThi_GetDaChuyenDiemByMonHocTrongKy(string MaXacThuc, long IDXL_MonHocTrongKy, int LanThi)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DanhSachDuThi oDKQHT_DanhSachDuThi = new cDKQHT_DanhSachDuThi();
            DataTable dt = oDKQHT_DanhSachDuThi.GetDaChuyenDiemByMonHocTrongKy(IDXL_MonHocTrongKy, LanThi);
            return Convert.ToList<sp_KQHT_DanhSachDuThi_GetDaChuyenDiemByMonHocTrongKyResult>(dt);
        }

        public void cDKQHT_DanhSachDuThi_UpdateSoPhach(string MaXacThuc, string SoPhach, int TuiThiSo, double KQHT_DanhSachDuThiID)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DanhSachDuThi oDKQHT_DanhSachDuThi = new cDKQHT_DanhSachDuThi();
            oDKQHT_DanhSachDuThi.UpdateSoPhach(SoPhach, TuiThiSo, KQHT_DanhSachDuThiID);
        }

        public void cDKQHT_DanhSachDuThi_UpdateDiem(string MaXacThuc, double Diem, double KQHT_DanhSachDuThiID)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DanhSachDuThi oDKQHT_DanhSachDuThi = new cDKQHT_DanhSachDuThi();
            oDKQHT_DanhSachDuThi.UpdateDiem(Diem, KQHT_DanhSachDuThiID);
        }

        public void cDKQHT_DanhSachDuThi_UpdateDaChuyenDiem(string MaXacThuc, bool IsDaChuyen, double IDXL_MonHocTrongKy, int LanThi)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DanhSachDuThi oDKQHT_DanhSachDuThi = new cDKQHT_DanhSachDuThi();
            oDKQHT_DanhSachDuThi.UpdateDaChuyenDiem(IsDaChuyen, IDXL_MonHocTrongKy, LanThi);
        }

        public void cDKQHT_DanhSachDuThi_UpdateDaChuyenDiemByToChucThi(string MaXacThuc, bool IsDaChuyen, int IDKQHT_ToChucThi, int LanThi)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DanhSachDuThi oDKQHT_DanhSachDuThi = new cDKQHT_DanhSachDuThi();
            oDKQHT_DanhSachDuThi.UpdateDaChuyenDiemByToChucThi(IsDaChuyen, IDKQHT_ToChucThi, LanThi);
        }

        public void cDKQHT_DanhSachDuThi_UpdateSoPhachMonLop(string MaXacThuc, int IDSV_SinhVien, string SoPhach, long IDXL_MonHocTrongKy, int LanThi, int MucPhatQuyChe, string LyDoViPhamQuyChe)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DanhSachDuThi oDKQHT_DanhSachDuThi = new cDKQHT_DanhSachDuThi();
            oDKQHT_DanhSachDuThi.UpdateSoPhachMonLop(IDSV_SinhVien, SoPhach, IDXL_MonHocTrongKy, LanThi, MucPhatQuyChe, LyDoViPhamQuyChe);
        }

        public void cDKQHT_DanhSachDuThi_HuyPhachMonLop(string MaXacThuc, long IDXL_MonHocTrongKy, int LanThi)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DanhSachDuThi oDKQHT_DanhSachDuThi = new cDKQHT_DanhSachDuThi();
            oDKQHT_DanhSachDuThi.HuyPhachMonLop(IDXL_MonHocTrongKy, LanThi);
        }

        public List<sp_KQHT_DaChuyenDiem_GetByIDMonHocTrongKyResult> cDKQHT_DaChuyenDiem_GetByIDMonHocTrongKy(string MaXacThuc, int IDXL_MonHocTrongKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DaChuyenDiem oDKQHT_DaChuyenDiem = new cDKQHT_DaChuyenDiem();
            DataTable dt = oDKQHT_DaChuyenDiem.GetByIDMonHocTrongKy(IDXL_MonHocTrongKy);
            return Convert.ToList<sp_KQHT_DaChuyenDiem_GetByIDMonHocTrongKyResult>(dt);
        }

        public int cDKQHT_DaChuyenDiem_AddChuyen(string MaXacThuc, KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDKQHT_DaChuyenDiem oDKQHT_DaChuyenDiem = new cDKQHT_DaChuyenDiem();
            return oDKQHT_DaChuyenDiem.AddChuyen(pKQHT_DaChuyenDiemInfo);
        }

        public void cDKQHT_DaChuyenDiem_UpdateTrangThaiChuyen(string MaXacThuc, KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DaChuyenDiem oDKQHT_DaChuyenDiem = new cDKQHT_DaChuyenDiem();
            oDKQHT_DaChuyenDiem.UpdateTrangThaiChuyen(pKQHT_DaChuyenDiemInfo);
        }

        public List<sp_KQHT_DaChuyenDiem_GetLichSuSuaDiemResult> cDKQHT_DaChuyenDiem_GetLichSuSuaDiem(string MaXacThuc, int IDXL_MonHocTrongKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DaChuyenDiem oDKQHT_DaChuyenDiem = new cDKQHT_DaChuyenDiem();
            DataTable dt = oDKQHT_DaChuyenDiem.GetLichSuSuaDiem(IDXL_MonHocTrongKy);
            return Convert.ToList<sp_KQHT_DaChuyenDiem_GetLichSuSuaDiemResult>(dt);
        }



        public List<sp_KQHT_MonThiTotNghiep_Lop_GetAllMonResult> cDKQHT_MonThiTotNghiep_Lop_GetAllMon(string MaXacThuc, int IDDM_NamHoc)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_MonThiTotNghiep_Lop oDKQHT_MonThiTotNghiep_Lop = new cDKQHT_MonThiTotNghiep_Lop();
            DataTable dt = oDKQHT_MonThiTotNghiep_Lop.GetAllMon(IDDM_NamHoc);
            return Convert.ToList<sp_KQHT_MonThiTotNghiep_Lop_GetAllMonResult>(dt);
        }

        public List<sp_KQHT_MonThiTotNghiep_Lop_GetIn_MonResult> cDKQHT_MonThiTotNghiep_Lop_GetIn_Mon(string MaXacThuc, int IDDM_Lop)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_MonThiTotNghiep_Lop oDKQHT_MonThiTotNghiep_Lop = new cDKQHT_MonThiTotNghiep_Lop();
            DataTable dt = oDKQHT_MonThiTotNghiep_Lop.GetIn_Mon(IDDM_Lop);
            return Convert.ToList<sp_KQHT_MonThiTotNghiep_Lop_GetIn_MonResult>(dt);
        }

        public List<sp_KQHT_MonThiTotNghiep_Lop_GetNotIn_MonResult> cDKQHT_MonThiTotNghiep_Lop_GetNotIn_Mon(string MaXacThuc, int IDDM_Lop)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_MonThiTotNghiep_Lop oDKQHT_MonThiTotNghiep_Lop = new cDKQHT_MonThiTotNghiep_Lop();
            DataTable dt = oDKQHT_MonThiTotNghiep_Lop.GetNotIn_Mon(IDDM_Lop);
            return Convert.ToList<sp_KQHT_MonThiTotNghiep_Lop_GetNotIn_MonResult>(dt);
        }

        public void cDKQHT_MonThiTotNghiep_Lop_Delete_ByLop(string MaXacThuc, int IDDM_Lop)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_MonThiTotNghiep_Lop oDKQHT_MonThiTotNghiep_Lop = new cDKQHT_MonThiTotNghiep_Lop();
            oDKQHT_MonThiTotNghiep_Lop.Delete_ByLop(IDDM_Lop);
        }



        public List<sp_KQHT_DanhSachKhongThi_GetIn_SinhVienResult> cDKQHT_DanhSachKhongThi_GetIn_SinhVien(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DanhSachKhongThi oDKQHT_DanhSachKhongThi = new cDKQHT_DanhSachKhongThi();
            DataTable dt = oDKQHT_DanhSachKhongThi.GetIn_SinhVien(IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi);
            return Convert.ToList<sp_KQHT_DanhSachKhongThi_GetIn_SinhVienResult>(dt);
        }

        public List<sp_KQHT_DanhSachKhongThi_GetNotIn_SinhVienResult> cDKQHT_DanhSachKhongThi_GetNotIn_SinhVien(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DanhSachKhongThi oDKQHT_DanhSachKhongThi = new cDKQHT_DanhSachKhongThi();
            DataTable dt = oDKQHT_DanhSachKhongThi.GetNotIn_SinhVien(IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi);
            return Convert.ToList<sp_KQHT_DanhSachKhongThi_GetNotIn_SinhVienResult>(dt);
        }

        public int cDKQHT_DanhSachKhongThi_AddTuDong(string MaXacThuc, KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDKQHT_DanhSachKhongThi oDKQHT_DanhSachKhongThi = new cDKQHT_DanhSachKhongThi();
            return oDKQHT_DanhSachKhongThi.AddTuDong(pKQHT_DanhSachKhongThiInfo);
        }

        public void cDKQHT_DanhSachKhongThi_DeleteTuDong(string MaXacThuc, KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DanhSachKhongThi oDKQHT_DanhSachKhongThi = new cDKQHT_DanhSachKhongThi();
            oDKQHT_DanhSachKhongThi.DeleteTuDong(pKQHT_DanhSachKhongThiInfo);
        }

        public void cDKQHT_DanhSachKhongThi_DeleteDanhSachDuThi(string MaXacThuc, KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo, int IDXL_MonHocTrongKy)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DanhSachKhongThi oDKQHT_DanhSachKhongThi = new cDKQHT_DanhSachKhongThi();
            oDKQHT_DanhSachKhongThi.DeleteDanhSachDuThi(pKQHT_DanhSachKhongThiInfo, IDXL_MonHocTrongKy);
        }



        public List<sp_GG_CongViecGiaoVien_GetResult> cDGG_CongViecGiaoVien_Get(string MaXacThuc, int IDNS_GiaoVien, int IDNamHoc)
        {
            if (MaXacThuc != "ABC") return null;
            cDGG_CongViecGiaoVien oDGG_CongViecGiaoVien = new cDGG_CongViecGiaoVien();
            DataTable dt = oDGG_CongViecGiaoVien.Get(IDNS_GiaoVien, IDNamHoc);
            return Convert.ToList<sp_GG_CongViecGiaoVien_GetResult>(dt);
        }

        public List<sp_GG_CongViecGiaoVien_GetAllByHocKyResult> cDGG_CongViecGiaoVien_GetByHocKy(string MaXacThuc, int IDDM_NamHoc, int HocKy, int IDNS_DonVi)
        {
            if (MaXacThuc != "ABC") return null;
            cDGG_CongViecGiaoVien oDGG_CongViecGiaoVien = new cDGG_CongViecGiaoVien();
            DataTable dt = oDGG_CongViecGiaoVien.GetByHocKy(IDDM_NamHoc, HocKy, IDNS_DonVi);
            return Convert.ToList<sp_GG_CongViecGiaoVien_GetAllByHocKyResult>(dt);
        }

        public List<sp_GG_CongViecGiaoVien_GetByIDDM_LoaiCongViecResult> cDGG_CongViecGiaoVien_GetByIDDM_LoaiCongViec(string MaXacThuc, int IDDM_LoaiCongViec, int IDNS_DonVi, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDGG_CongViecGiaoVien oDGG_CongViecGiaoVien = new cDGG_CongViecGiaoVien();
            DataTable dt = oDGG_CongViecGiaoVien.GetByIDDM_LoaiCongViec(IDDM_LoaiCongViec, IDNS_DonVi, IDDM_NamHoc, HocKy);
            return Convert.ToList<sp_GG_CongViecGiaoVien_GetByIDDM_LoaiCongViecResult>(dt);
        }

        public long cDGG_CongViecGiaoVien_UpdateAdd(string MaXacThuc, GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDGG_CongViecGiaoVien oDGG_CongViecGiaoVien = new cDGG_CongViecGiaoVien();
            return oDGG_CongViecGiaoVien.UpdateAdd(pGG_CongViecGiaoVienInfo);
        }

        public void cDGG_CongViecGiaoVien_DeleteNotIn(string MaXacThuc, int IDNS_GiaoVien, int IDDM_NamHoc, int HocKy, string IDCVNotIn)
        {
            if (MaXacThuc != "ABC") return;
            cDGG_CongViecGiaoVien oDGG_CongViecGiaoVien = new cDGG_CongViecGiaoVien();
            oDGG_CongViecGiaoVien.DeleteNotIn(IDNS_GiaoVien, IDDM_NamHoc, HocKy, IDCVNotIn);
        }

        public List<sp_GG_GiangDayGiaoVien_GetBangTongHopResult> cDGG_GiangDayGiaoVien_GetBangTongHop(string MaXacThuc, int IDNS_DonVi, string TenDonVi, int IDDM_NamHoc, string TenNamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDGG_GiangDayGiaoVien oDGG_GiangDayGiaoVien = new cDGG_GiangDayGiaoVien();
            DataTable dt = oDGG_GiangDayGiaoVien.GetBangTongHop(IDNS_DonVi, TenDonVi, IDDM_NamHoc, TenNamHoc, HocKy);
            return Convert.ToList<sp_GG_GiangDayGiaoVien_GetBangTongHopResult>(dt);
        }

        public long cDGG_GiangDayGiaoVien_UpdateAdd(string MaXacThuc, GG_GiangDayGiaoVienInfo pGG_GiangDayGiaoVienInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDGG_GiangDayGiaoVien oDGG_GiangDayGiaoVien = new cDGG_GiangDayGiaoVien();
            return oDGG_GiangDayGiaoVien.UpdateAdd(pGG_GiangDayGiaoVienInfo);
        }

        public void cDGG_GiangDayGiaoVien_DeleteNotIn(string MaXacThuc, int IDNS_GiaoVien, int IDDM_NamHoc, int HocKy, string IDGGNotIn)
        {
            if (MaXacThuc != "ABC") return;
            cDGG_GiangDayGiaoVien oDGG_GiangDayGiaoVien = new cDGG_GiangDayGiaoVien();
            oDGG_GiangDayGiaoVien.DeleteNotIn(IDNS_GiaoVien, IDDM_NamHoc, HocKy, IDGGNotIn);
        }


        public List<sp_HT_Report_GetByNameResult> cDHT_Report_GetByName(string MaXacThuc, HT_ReportInfo pReportInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDHT_Report oDHT_Report = new cDHT_Report();
            DataTable dt = oDHT_Report.GetByName(pReportInfo);
            return Convert.ToList<sp_HT_Report_GetByNameResult>(dt);
        }

        public List<sp_HT_Report_GetByNameResult> cDHT_Report_GetByName(string MaXacThuc, string ReportName)
        {
            if (MaXacThuc != "ABC") return null;
            cDHT_Report oDHT_Report = new cDHT_Report();
            DataTable dt = oDHT_Report.GetByName(ReportName);
            return Convert.ToList<sp_HT_Report_GetByNameResult>(dt);
        }

        public List<HT_ReportInfo> cDHT_Report_GetByIDReportMain(string MaXacThuc, int IDHT_Report)
        {
            if (MaXacThuc != "ABC") return null;
            cDHT_Report oDHT_Report = new cDHT_Report();
            DataTable dt = oDHT_Report.GetByIDReportMain(IDHT_Report);
            return Convert.ToList<HT_ReportInfo>(dt);
        }

        public List<HT_ReportInfo> cDHT_Report_GetXtraReport(string MaXacThuc, int HT_ReportID)
        {
            if (MaXacThuc != "ABC") return null;
            cDHT_Report oDHT_Report = new cDHT_Report();
            DataTable dt = oDHT_Report.GetXtraReport(HT_ReportID);
            return Convert.ToList<HT_ReportInfo>(dt);
        }



        public List<sp_GG_HeSoLopDongTheoKhoa_GetAllResult> cDGG_HeSoLopDongTheoKhoa_GetAll(string MaXacThuc, int GG_HeSoLopDongTheoKhoaID)
        {
            if (MaXacThuc != "ABC") return null;
            cDGG_HeSoLopDongTheoKhoa oDGG_HeSoLopDongTheoKhoa = new cDGG_HeSoLopDongTheoKhoa();
            DataTable dt = oDGG_HeSoLopDongTheoKhoa.GetAll(GG_HeSoLopDongTheoKhoaID);
            return Convert.ToList<sp_GG_HeSoLopDongTheoKhoa_GetAllResult>(dt);
        }
        public List<sp_GG_DinhMucGioDay_GetByIDNS_DonViResult> cDGG_DinhMucGioDay_GetByIDNS_DonVi(string MaXacThuc, int IDNS_DonVi, int IDDM_NamHoc, int HocKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDGG_DinhMucGioDay oDGG_DinhMucGioDay = new cDGG_DinhMucGioDay();
            DataTable dt = oDGG_DinhMucGioDay.GetByIDNS_DonVi(IDNS_DonVi, IDDM_NamHoc, HocKy);
            return Convert.ToList<sp_GG_DinhMucGioDay_GetByIDNS_DonViResult>(dt);
        }
        public List<sp_GG_CongViecGiaoVien_GetResult> cDGG_CongViecGiaoVien_Get(string MaXacThuc, GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDGG_CongViecGiaoVien oDGG_CongViecGiaoVien = new cDGG_CongViecGiaoVien();
            DataTable dt = oDGG_CongViecGiaoVien.Get(pGG_CongViecGiaoVienInfo);
            return Convert.ToList<sp_GG_CongViecGiaoVien_GetResult>(dt);
        }
        public SqlParameter cDBase_CreateParam(string MaXacThuc, string _TenThamSo, SqlDbType _KieuDuLieu, int _KichThuoc, object _GiaTri)
        {
            if (MaXacThuc != "ABC") return null;
            cDBase oDBase = new cDBase();
            return oDBase.CreateParam(_TenThamSo, _KieuDuLieu, _KichThuoc, _GiaTri);
        }

        public SqlParameter cDBase_CreateParamOut(string MaXacThuc, string _TenThamSo, SqlDbType _KieuDuLieu, int _KichThuoc)
        {
            if (MaXacThuc != "ABC") return null;
            cDBase oDBase = new cDBase();
            return oDBase.CreateParamOut(_TenThamSo, _KieuDuLieu, _KichThuoc);
        }

        public List<sp_SV_SinhVien_GetByLopResult> cDSV_SinhVien_GetByLop(string MaXacThuc, int IDDM_Lop, int TrangThai)
        {
            if (MaXacThuc != "ABC") return null;
            cDSV_SinhVien oDSV_SinhVien = new cDSV_SinhVien();
            DataTable dt = oDSV_SinhVien.GetByLop(IDDM_Lop, TrangThai);
            return Convert.ToList<sp_SV_SinhVien_GetByLopResult>(dt);
        }

        public string cDSV_SinhVien_GetNextMaSinhVien(string MaXacThuc, int IDDM_Lop, string MaSinhVien, ref int DoDaiTuTang)
        {
            if (MaXacThuc != "ABC") return null;
            cDSV_SinhVien oDSV_SinhVien = new cDSV_SinhVien();
            return oDSV_SinhVien.GetNextMaSinhVien(IDDM_Lop, MaSinhVien, ref DoDaiTuTang);
        }

        public List<sp_SV_SinhVien_GetHoSoResult> cDSV_SinhVien_GetHoSo(string MaXacThuc, int SV_SinhVienID)
        {
            if (MaXacThuc != "ABC") return null;
            cDSV_SinhVien oDSV_SinhVien = new cDSV_SinhVien();
            DataTable dt = oDSV_SinhVien.GetHoSo(SV_SinhVienID);
            return Convert.ToList<sp_SV_SinhVien_GetHoSoResult>(dt);
        }

        public List<SV_SinhVienInfo> cDSV_SinhVien_GetDanhSachDuThi(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi, string DaDangKy, int TotNghiep)
        {
            if (MaXacThuc != "ABC") return null;
            cDSV_SinhVien oDSV_SinhVien = new cDSV_SinhVien();
            DataTable dt = oDSV_SinhVien.GetDanhSachDuThi(IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi, DaDangKy, TotNghiep);
            return Convert.ToList<SV_SinhVienInfo>(dt);
        }

        public List<SV_SinhVienInfo> cDSV_SinhVien_GetDanhSachThiLai(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi, string DaDangKy, int TotNghiep)
        {
            if (MaXacThuc != "ABC") return null;
            cDSV_SinhVien oDSV_SinhVien = new cDSV_SinhVien();
            DataTable dt = oDSV_SinhVien.GetDanhSachThiLai(IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi, DaDangKy, TotNghiep);
            return Convert.ToList<SV_SinhVienInfo>(dt);
        }

        public List<SV_SinhVienInfo> cDSV_SinhVien_GetDanhSachDuThiKhoaTruoc(string MaXacThuc, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi, string DaDangKy)
        {
            if (MaXacThuc != "ABC") return null;
            cDSV_SinhVien oDSV_SinhVien = new cDSV_SinhVien();
            DataTable dt = oDSV_SinhVien.GetDanhSachDuThiKhoaTruoc(IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi, DaDangKy);
            return Convert.ToList<SV_SinhVienInfo>(dt);
        }

        public List<sp_SV_SinhVien_GetByLop_MonResult> cDSV_SinhVien_GetByLop_Mon(string MaXacThuc, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int IDKQHT_HoiDongMon)
        {
            if (MaXacThuc != "ABC") return null;
            cDSV_SinhVien oDSV_SinhVien = new cDSV_SinhVien();
            DataTable dt = oDSV_SinhVien.GetByLop_Mon(IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, IDKQHT_HoiDongMon);
            return Convert.ToList<sp_SV_SinhVien_GetByLop_MonResult>(dt);
        }
        public List<sp_SV_SinhVien_KiemTraMaSVResult> cDSV_SinhVien_KiemTraMaSV(string MaXacThuc, string MaSinhVien)
        {
            if (MaXacThuc != "ABC") return null;
            cDSV_SinhVien oDSV_SinhVien = new cDSV_SinhVien();
            DataTable dt = oDSV_SinhVien.KiemTraMaSV(MaSinhVien);
            return Convert.ToList<sp_SV_SinhVien_KiemTraMaSVResult>(dt);
        }



        public List<sp_SV_SinhVien_TimKiemResult> cDSV_SinhVien_TimKiem(string MaXacThuc, SV_SinhVienInfo pSV_SinhVienInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDSV_SinhVien oDSV_SinhVien = new cDSV_SinhVien();
            DataTable dt = oDSV_SinhVien.TimKiem(pSV_SinhVienInfo);
            return Convert.ToList<sp_SV_SinhVien_TimKiemResult>(dt);
        }

        public List<SV_SinhVienInfo> cDSV_SinhVien_GetSinhVien(string MaXacThuc, DM_LopInfo pDM_LopInfo, string NamHoc, bool ChuaTaoMa)
        {
            if (MaXacThuc != "ABC") return null;
            cDSV_SinhVien oDSV_SinhVien = new cDSV_SinhVien();
            DataTable dt = oDSV_SinhVien.GetSinhVien(pDM_LopInfo, NamHoc, ChuaTaoMa);
            return Convert.ToList<SV_SinhVienInfo>(dt);
        }
        public string cDSV_SinhVien_CheckExistByMaSinhVien(string MaXacThuc, string MaSinhViens)
        {
            if (MaXacThuc != "ABC") return null;
            cDSV_SinhVien oDSV_SinhVien = new cDSV_SinhVien();
            return oDSV_SinhVien.CheckExistByMaSinhVien(MaSinhViens);
        }

        public string cDSV_SinhVien_CheckExistAndGetInfo(string MaXacThuc, string MaSinhViens, ref string HoVaTens, ref string TenLops)
        {
            if (MaXacThuc != "ABC") return null;
            cDSV_SinhVien oDSV_SinhVien = new cDSV_SinhVien();
            return oDSV_SinhVien.CheckExistAndGetInfo(MaSinhViens, ref HoVaTens, ref TenLops);
        }


        public List<sp_DM_NamHoc_GetResult> cDDM_NamHoc_Get(string MaXacThuc, DM_NamHocInfo pDM_NamHocInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_NamHoc oDDM_NamHoc = new cDDM_NamHoc();
            DataTable dt = oDDM_NamHoc.Get(pDM_NamHocInfo);
            return Convert.ToList<sp_DM_NamHoc_GetResult>(dt);
        }
        public List<sp_DM_BoMon_GetResult> cDDM_BoMon_Get(string MaXacThuc, DM_BoMonInfo pDM_BoMonInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_BoMon oDDM_BoMon = new cDDM_BoMon();
            DataTable dt = oDDM_BoMon.Get(pDM_BoMonInfo);
            return Convert.ToList<sp_DM_BoMon_GetResult>(dt);
        }
        public List<sp_NS_DonVi_GetResult> cDNS_DonVi_Get(string MaXacThuc, NS_DonViInfo pNS_DonViInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDNS_DonVi oDNS_DonVi = new cDNS_DonVi();
            DataTable dt = oDNS_DonVi.Get(pNS_DonViInfo);
            return Convert.ToList<sp_NS_DonVi_GetResult>(dt);
        }
        public List<sp_DM_MonHoc_GetResult> cDDM_MonHoc_Get(string MaXacThuc, DM_MonHocInfo pDM_MonHocInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_MonHoc oDDM_MonHoc = new cDDM_MonHoc();
            DataTable dt = oDDM_MonHoc.Get(pDM_MonHocInfo);
            return Convert.ToList<sp_DM_MonHoc_GetResult>(dt);
        }
        public List<sp_KQHT_ThanhPhanDiem_GetResult> cDKQHT_ThanhPhanDiem_Get(string MaXacThuc, KQHT_ThanhPhanDiemInfo pKQHT_ThanhPhanDiemInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_ThanhPhanDiem oDKQHT_ThanhPhanDiem = new cDKQHT_ThanhPhanDiem();
            DataTable dt = oDKQHT_ThanhPhanDiem.Get(pKQHT_ThanhPhanDiemInfo);
            return Convert.ToList<sp_KQHT_ThanhPhanDiem_GetResult>(dt);
        }
        public List<sp_KQHT_DiemTongKetMon_GetResult> cDKQHT_DiemTongKetMon_Get(string MaXacThuc, KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemTongKetMon oDKQHT_DiemTongKetMon = new cDKQHT_DiemTongKetMon();
            DataTable dt = oDKQHT_DiemTongKetMon.Get(pKQHT_DiemTongKetMonInfo);
            return Convert.ToList<sp_KQHT_DiemTongKetMon_GetResult>(dt);
        }
        public List<sp_HT_ThamSoHeThong_GetResult> cDHT_ThamSoHeThong_Get(string MaXacThuc, HT_ThamSoHeThongInfo pHT_ThamSoHeThongInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDHT_ThamSoHeThong oDHT_ThamSoHeThong = new cDHT_ThamSoHeThong();
            DataTable dt = oDHT_ThamSoHeThong.Get(pHT_ThamSoHeThongInfo);
            return Convert.ToList<sp_HT_ThamSoHeThong_GetResult>(dt);
        }
        public int cDHT_ThamSoHeThong_Add(string MaXacThuc, HT_ThamSoHeThongInfo pHT_ThamSoHeThongInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDHT_ThamSoHeThong oDHT_ThamSoHeThong = new cDHT_ThamSoHeThong();
            return oDHT_ThamSoHeThong.Add(pHT_ThamSoHeThongInfo);
        }
        public int cDHT_Log_Add(string MaXacThuc, HT_LogInfo pHT_LogInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDHT_Log oDHT_Log = new cDHT_Log();
            return oDHT_Log.Add(pHT_LogInfo);
        }


        public List<sp_KQHT_DaChuyenDiem_GetResult> cDKQHT_DaChuyenDiem_Get(string MaXacThuc, KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DaChuyenDiem oDKQHT_DaChuyenDiem = new cDKQHT_DaChuyenDiem();
            DataTable dt = oDKQHT_DaChuyenDiem.Get(pKQHT_DaChuyenDiemInfo);
            return Convert.ToList<sp_KQHT_DaChuyenDiem_GetResult>(dt);
        }

        public int cDKQHT_DaChuyenDiem_Add(string MaXacThuc, KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDKQHT_DaChuyenDiem oDKQHT_DaChuyenDiem = new cDKQHT_DaChuyenDiem();
            return oDKQHT_DaChuyenDiem.Add(pKQHT_DaChuyenDiemInfo);
        }

        public void cDKQHT_DaChuyenDiem_Update(string MaXacThuc, KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DaChuyenDiem oDKQHT_DaChuyenDiem = new cDKQHT_DaChuyenDiem();
            oDKQHT_DaChuyenDiem.Update(pKQHT_DaChuyenDiemInfo);
        }

        public void cDKQHT_DaChuyenDiem_Delete(string MaXacThuc, KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DaChuyenDiem oDKQHT_DaChuyenDiem = new cDKQHT_DaChuyenDiem();
            oDKQHT_DaChuyenDiem.Delete(pKQHT_DaChuyenDiemInfo);
        }
        public void cDKQHT_DiemTongKetMon_Add(string MaXacThuc, KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DiemTongKetMon oDKQHT_DiemTongKetMon = new cDKQHT_DiemTongKetMon();
            oDKQHT_DiemTongKetMon.Add(pKQHT_DiemTongKetMonInfo);
        }


        public List<sp_KQHT_DiemThanhPhan_GetResult> cDKQHT_DiemThanhPhan_Get(string MaXacThuc, KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemThanhPhan oDKQHT_DiemThanhPhan = new cDKQHT_DiemThanhPhan();
            DataTable dt = oDKQHT_DiemThanhPhan.Get(pKQHT_DiemThanhPhanInfo);
            return Convert.ToList<sp_KQHT_DiemThanhPhan_GetResult>(dt);
        }

        public int cDKQHT_DiemThanhPhan_Add(string MaXacThuc, KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDKQHT_DiemThanhPhan oDKQHT_DiemThanhPhan = new cDKQHT_DiemThanhPhan();
            return oDKQHT_DiemThanhPhan.Add(pKQHT_DiemThanhPhanInfo);
        }

        public void cDKQHT_DiemThanhPhan_Update(string MaXacThuc, KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DiemThanhPhan oDKQHT_DiemThanhPhan = new cDKQHT_DiemThanhPhan();
            oDKQHT_DiemThanhPhan.Update(pKQHT_DiemThanhPhanInfo);
        }

        public void cDKQHT_DiemThanhPhan_Delete(string MaXacThuc, KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DiemThanhPhan oDKQHT_DiemThanhPhan = new cDKQHT_DiemThanhPhan();
            oDKQHT_DiemThanhPhan.Delete(pKQHT_DiemThanhPhanInfo);
        }



        public List<sp_KQHT_MonHoc_CT_KhoiKienThuc_GetResult> cDKQHT_MonHoc_CT_KhoiKienThuc_Get(string MaXacThuc, KQHT_MonHoc_CT_KhoiKienThucInfo pKQHT_MonHoc_CT_KhoiKienThucInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_MonHoc_CT_KhoiKienThuc oDKQHT_MonHoc_CT_KhoiKienThuc = new cDKQHT_MonHoc_CT_KhoiKienThuc();
            DataTable dt = oDKQHT_MonHoc_CT_KhoiKienThuc.Get(pKQHT_MonHoc_CT_KhoiKienThucInfo);
            return Convert.ToList<sp_KQHT_MonHoc_CT_KhoiKienThuc_GetResult>(dt);
        }

        public int cDKQHT_MonHoc_CT_KhoiKienThuc_Add(string MaXacThuc, KQHT_MonHoc_CT_KhoiKienThucInfo pKQHT_MonHoc_CT_KhoiKienThucInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDKQHT_MonHoc_CT_KhoiKienThuc oDKQHT_MonHoc_CT_KhoiKienThuc = new cDKQHT_MonHoc_CT_KhoiKienThuc();
            return oDKQHT_MonHoc_CT_KhoiKienThuc.Add(pKQHT_MonHoc_CT_KhoiKienThucInfo);
        }

        public void cDKQHT_MonHoc_CT_KhoiKienThuc_Update(string MaXacThuc, KQHT_MonHoc_CT_KhoiKienThucInfo pKQHT_MonHoc_CT_KhoiKienThucInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_MonHoc_CT_KhoiKienThuc oDKQHT_MonHoc_CT_KhoiKienThuc = new cDKQHT_MonHoc_CT_KhoiKienThuc();
            oDKQHT_MonHoc_CT_KhoiKienThuc.Update(pKQHT_MonHoc_CT_KhoiKienThucInfo);
        }

        public void cDKQHT_MonHoc_CT_KhoiKienThuc_Delete(string MaXacThuc, KQHT_MonHoc_CT_KhoiKienThucInfo pKQHT_MonHoc_CT_KhoiKienThucInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_MonHoc_CT_KhoiKienThuc oDKQHT_MonHoc_CT_KhoiKienThuc = new cDKQHT_MonHoc_CT_KhoiKienThuc();
            oDKQHT_MonHoc_CT_KhoiKienThuc.Delete(pKQHT_MonHoc_CT_KhoiKienThucInfo);
        }

        public List<sp_KQHT_CTDT_Lop_GetResult> cDKQHT_CTDT_Lop_Get(string MaXacThuc, KQHT_CTDT_LopInfo pKQHT_CTDT_LopInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_CTDT_Lop oDKQHT_CTDT_Lop = new cDKQHT_CTDT_Lop();
            DataTable dt = oDKQHT_CTDT_Lop.Get(pKQHT_CTDT_LopInfo);
            return Convert.ToList<sp_KQHT_CTDT_Lop_GetResult>(dt);
        }

        public int cDKQHT_CTDT_Lop_Add(string MaXacThuc, KQHT_CTDT_LopInfo pKQHT_CTDT_LopInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDKQHT_CTDT_Lop oDKQHT_CTDT_Lop = new cDKQHT_CTDT_Lop();
            return oDKQHT_CTDT_Lop.Add(pKQHT_CTDT_LopInfo);
        }

        public void cDKQHT_CTDT_Lop_Update(string MaXacThuc, KQHT_CTDT_LopInfo pKQHT_CTDT_LopInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_CTDT_Lop oDKQHT_CTDT_Lop = new cDKQHT_CTDT_Lop();
            oDKQHT_CTDT_Lop.Update(pKQHT_CTDT_LopInfo);
        }

        public void cDKQHT_CTDT_Lop_Delete(string MaXacThuc, KQHT_CTDT_LopInfo pKQHT_CTDT_LopInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_CTDT_Lop oDKQHT_CTDT_Lop = new cDKQHT_CTDT_Lop();
            oDKQHT_CTDT_Lop.Delete(pKQHT_CTDT_LopInfo);
        }



        public List<sp_KQHT_CTDT_CT_KhoiKienThuc_GetResult> cDKQHT_CTDT_CT_KhoiKienThuc_Get(string MaXacThuc, KQHT_CTDT_CT_KhoiKienThucInfo pKQHT_CTDT_CT_KhoiKienThucInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_CTDT_CT_KhoiKienThuc oDKQHT_CTDT_CT_KhoiKienThuc = new cDKQHT_CTDT_CT_KhoiKienThuc();
            DataTable dt = oDKQHT_CTDT_CT_KhoiKienThuc.Get(pKQHT_CTDT_CT_KhoiKienThucInfo);
            return Convert.ToList<sp_KQHT_CTDT_CT_KhoiKienThuc_GetResult>(dt);
        }

        public int cDKQHT_CTDT_CT_KhoiKienThuc_Add(string MaXacThuc, KQHT_CTDT_CT_KhoiKienThucInfo pKQHT_CTDT_CT_KhoiKienThucInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDKQHT_CTDT_CT_KhoiKienThuc oDKQHT_CTDT_CT_KhoiKienThuc = new cDKQHT_CTDT_CT_KhoiKienThuc();
            return oDKQHT_CTDT_CT_KhoiKienThuc.Add(pKQHT_CTDT_CT_KhoiKienThucInfo);
        }

        public void cDKQHT_CTDT_CT_KhoiKienThuc_Update(string MaXacThuc, KQHT_CTDT_CT_KhoiKienThucInfo pKQHT_CTDT_CT_KhoiKienThucInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_CTDT_CT_KhoiKienThuc oDKQHT_CTDT_CT_KhoiKienThuc = new cDKQHT_CTDT_CT_KhoiKienThuc();
            oDKQHT_CTDT_CT_KhoiKienThuc.Update(pKQHT_CTDT_CT_KhoiKienThucInfo);
        }

        public void cDKQHT_CTDT_CT_KhoiKienThuc_Delete(string MaXacThuc, KQHT_CTDT_CT_KhoiKienThucInfo pKQHT_CTDT_CT_KhoiKienThucInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_CTDT_CT_KhoiKienThuc oDKQHT_CTDT_CT_KhoiKienThuc = new cDKQHT_CTDT_CT_KhoiKienThuc();
            oDKQHT_CTDT_CT_KhoiKienThuc.Delete(pKQHT_CTDT_CT_KhoiKienThucInfo);
        }





        public List<sp_KQHT_ChuongTrinhDaoTao_GetResult> cDKQHT_ChuongTrinhDaoTao_Get(string MaXacThuc, KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_ChuongTrinhDaoTao oDKQHT_ChuongTrinhDaoTao = new cDKQHT_ChuongTrinhDaoTao();
            DataTable dt = oDKQHT_ChuongTrinhDaoTao.Get(pKQHT_ChuongTrinhDaoTaoInfo);
            return Convert.ToList<sp_KQHT_ChuongTrinhDaoTao_GetResult>(dt);
        }

        public int cDKQHT_ChuongTrinhDaoTao_Add(string MaXacThuc, KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDKQHT_ChuongTrinhDaoTao oDKQHT_ChuongTrinhDaoTao = new cDKQHT_ChuongTrinhDaoTao();
            return oDKQHT_ChuongTrinhDaoTao.Add(pKQHT_ChuongTrinhDaoTaoInfo);
        }

        public void cDKQHT_ChuongTrinhDaoTao_Update(string MaXacThuc, KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_ChuongTrinhDaoTao oDKQHT_ChuongTrinhDaoTao = new cDKQHT_ChuongTrinhDaoTao();
            oDKQHT_ChuongTrinhDaoTao.Update(pKQHT_ChuongTrinhDaoTaoInfo);
        }

        public void cDKQHT_ChuongTrinhDaoTao_Delete(string MaXacThuc, KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_ChuongTrinhDaoTao oDKQHT_ChuongTrinhDaoTao = new cDKQHT_ChuongTrinhDaoTao();
            oDKQHT_ChuongTrinhDaoTao.Delete(pKQHT_ChuongTrinhDaoTaoInfo);
        }


        public List<sp_GG_DinhMucGioDay_GetResult> cDGG_DinhMucGioDay_Get(string MaXacThuc, GG_DinhMucGioDayInfo pGG_DinhMucGioDayInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDGG_DinhMucGioDay oDGG_DinhMucGioDay = new cDGG_DinhMucGioDay();
            DataTable dt = oDGG_DinhMucGioDay.Get(pGG_DinhMucGioDayInfo);
            return Convert.ToList<sp_GG_DinhMucGioDay_GetResult>(dt);
        }

        public int cDGG_DinhMucGioDay_Add(string MaXacThuc, GG_DinhMucGioDayInfo pGG_DinhMucGioDayInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDGG_DinhMucGioDay oDGG_DinhMucGioDay = new cDGG_DinhMucGioDay();
            return oDGG_DinhMucGioDay.Add(pGG_DinhMucGioDayInfo);
        }

        public void cDGG_DinhMucGioDay_Update(string MaXacThuc, GG_DinhMucGioDayInfo pGG_DinhMucGioDayInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDGG_DinhMucGioDay oDGG_DinhMucGioDay = new cDGG_DinhMucGioDay();
            oDGG_DinhMucGioDay.Update(pGG_DinhMucGioDayInfo);
        }

        public void cDGG_DinhMucGioDay_Delete(string MaXacThuc, GG_DinhMucGioDayInfo pGG_DinhMucGioDayInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDGG_DinhMucGioDay oDGG_DinhMucGioDay = new cDGG_DinhMucGioDay();
            oDGG_DinhMucGioDay.Delete(pGG_DinhMucGioDayInfo);
        }


        public List<KQHT_CT_KhoiKienThucInfo> cDKQHT_CT_KhoiKienThuc_Get(string MaXacThuc, KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_CT_KhoiKienThuc oDKQHT_CT_KhoiKienThuc = new cDKQHT_CT_KhoiKienThuc();
            DataTable dt = oDKQHT_CT_KhoiKienThuc.Get(pKQHT_CT_KhoiKienThucInfo);
            return Convert.ToList<KQHT_CT_KhoiKienThucInfo>(dt);
        }

        public int cDKQHT_CT_KhoiKienThuc_Add(string MaXacThuc, KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDKQHT_CT_KhoiKienThuc oDKQHT_CT_KhoiKienThuc = new cDKQHT_CT_KhoiKienThuc();
            return oDKQHT_CT_KhoiKienThuc.Add(pKQHT_CT_KhoiKienThucInfo);
        }

        public void cDKQHT_CT_KhoiKienThuc_Update(string MaXacThuc, KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_CT_KhoiKienThuc oDKQHT_CT_KhoiKienThuc = new cDKQHT_CT_KhoiKienThuc();
            oDKQHT_CT_KhoiKienThuc.Update(pKQHT_CT_KhoiKienThucInfo);
        }

        public void cDKQHT_CT_KhoiKienThuc_Delete(string MaXacThuc, KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_CT_KhoiKienThuc oDKQHT_CT_KhoiKienThuc = new cDKQHT_CT_KhoiKienThuc();
            oDKQHT_CT_KhoiKienThuc.Delete(pKQHT_CT_KhoiKienThucInfo);
        }
        public List<sp_XL_PhongHoc_MonHoc_GetResult> cDXL_PhongHoc_MonHoc_Get(string MaXacThuc, XL_PhongHoc_MonHocInfo pXL_PhongHoc_MonHocInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_PhongHoc_MonHoc oDXL_PhongHoc_MonHoc = new cDXL_PhongHoc_MonHoc();
            DataTable dt = oDXL_PhongHoc_MonHoc.Get(pXL_PhongHoc_MonHocInfo);
            return Convert.ToList<sp_XL_PhongHoc_MonHoc_GetResult>(dt);
        }

        public int cDXL_PhongHoc_MonHoc_Add(string MaXacThuc, XL_PhongHoc_MonHocInfo pXL_PhongHoc_MonHocInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDXL_PhongHoc_MonHoc oDXL_PhongHoc_MonHoc = new cDXL_PhongHoc_MonHoc();
            return oDXL_PhongHoc_MonHoc.Add(pXL_PhongHoc_MonHocInfo);
        }

        public void cDXL_PhongHoc_MonHoc_Update(string MaXacThuc, XL_PhongHoc_MonHocInfo pXL_PhongHoc_MonHocInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDXL_PhongHoc_MonHoc oDXL_PhongHoc_MonHoc = new cDXL_PhongHoc_MonHoc();
            oDXL_PhongHoc_MonHoc.Update(pXL_PhongHoc_MonHocInfo);
        }

        public void cDXL_PhongHoc_MonHoc_Delete(string MaXacThuc, XL_PhongHoc_MonHocInfo pXL_PhongHoc_MonHocInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDXL_PhongHoc_MonHoc oDXL_PhongHoc_MonHoc = new cDXL_PhongHoc_MonHoc();
            oDXL_PhongHoc_MonHoc.Delete(pXL_PhongHoc_MonHocInfo);
        }


        public List<sp_KQHT_QuyChe_GetResult> cDKQHT_QuyChe_Get(string MaXacThuc, KQHT_QuyCheInfo pKQHT_QuyCheInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_QuyChe oDKQHT_QuyChe = new cDKQHT_QuyChe();
            DataTable dt = oDKQHT_QuyChe.Get(pKQHT_QuyCheInfo);
            return Convert.ToList<sp_KQHT_QuyChe_GetResult>(dt);
        }

        public int cDKQHT_QuyChe_Add(string MaXacThuc, KQHT_QuyCheInfo pKQHT_QuyCheInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDKQHT_QuyChe oDKQHT_QuyChe = new cDKQHT_QuyChe();
            return oDKQHT_QuyChe.Add(pKQHT_QuyCheInfo);
        }

        public void cDKQHT_QuyChe_Update(string MaXacThuc, KQHT_QuyCheInfo pKQHT_QuyCheInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_QuyChe oDKQHT_QuyChe = new cDKQHT_QuyChe();
            oDKQHT_QuyChe.Update(pKQHT_QuyCheInfo);
        }

        public void cDKQHT_QuyChe_Delete(string MaXacThuc, KQHT_QuyCheInfo pKQHT_QuyCheInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_QuyChe oDKQHT_QuyChe = new cDKQHT_QuyChe();
            oDKQHT_QuyChe.Delete(pKQHT_QuyCheInfo);
        }
        public List<sp_HT_ThongTinTruong_GetResult> cDHT_ThongTinTruong_Get(string MaXacThuc, HT_ThongTinTruongInfo pHT_ThongTinTruongInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDHT_ThongTinTruong oDHT_ThongTinTruong = new cDHT_ThongTinTruong();
            DataTable dt = oDHT_ThongTinTruong.Get(pHT_ThongTinTruongInfo);
            return Convert.ToList<sp_HT_ThongTinTruong_GetResult>(dt);
        }

        public int cDHT_ThongTinTruong_Add(string MaXacThuc, HT_ThongTinTruongInfo pHT_ThongTinTruongInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDHT_ThongTinTruong oDHT_ThongTinTruong = new cDHT_ThongTinTruong();
            return oDHT_ThongTinTruong.Add(pHT_ThongTinTruongInfo);
        }

        public void cDHT_ThongTinTruong_Update(string MaXacThuc, HT_ThongTinTruongInfo pHT_ThongTinTruongInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDHT_ThongTinTruong oDHT_ThongTinTruong = new cDHT_ThongTinTruong();
            oDHT_ThongTinTruong.Update(pHT_ThongTinTruongInfo);
        }

        public void cDHT_ThongTinTruong_Delete(string MaXacThuc, HT_ThongTinTruongInfo pHT_ThongTinTruongInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDHT_ThongTinTruong oDHT_ThongTinTruong = new cDHT_ThongTinTruong();
            oDHT_ThongTinTruong.Delete(pHT_ThongTinTruongInfo);
        }
        public List<sp_GG_HeSoLopDongTheoKhoa_GetResult> cDGG_HeSoLopDongTheoKhoa_Get(string MaXacThuc, GG_HeSoLopDongTheoKhoaInfo pGG_HeSoLopDongTheoKhoaInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDGG_HeSoLopDongTheoKhoa oDGG_HeSoLopDongTheoKhoa = new cDGG_HeSoLopDongTheoKhoa();
            DataTable dt = oDGG_HeSoLopDongTheoKhoa.Get(pGG_HeSoLopDongTheoKhoaInfo);
            return Convert.ToList<sp_GG_HeSoLopDongTheoKhoa_GetResult>(dt);
        }

        public int cDGG_HeSoLopDongTheoKhoa_Add(string MaXacThuc, GG_HeSoLopDongTheoKhoaInfo pGG_HeSoLopDongTheoKhoaInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDGG_HeSoLopDongTheoKhoa oDGG_HeSoLopDongTheoKhoa = new cDGG_HeSoLopDongTheoKhoa();
            return oDGG_HeSoLopDongTheoKhoa.Add(pGG_HeSoLopDongTheoKhoaInfo);
        }

        public void cDGG_HeSoLopDongTheoKhoa_Update(string MaXacThuc, GG_HeSoLopDongTheoKhoaInfo pGG_HeSoLopDongTheoKhoaInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDGG_HeSoLopDongTheoKhoa oDGG_HeSoLopDongTheoKhoa = new cDGG_HeSoLopDongTheoKhoa();
            oDGG_HeSoLopDongTheoKhoa.Update(pGG_HeSoLopDongTheoKhoaInfo);
        }

        public void cDGG_HeSoLopDongTheoKhoa_Delete(string MaXacThuc, GG_HeSoLopDongTheoKhoaInfo pGG_HeSoLopDongTheoKhoaInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDGG_HeSoLopDongTheoKhoa oDGG_HeSoLopDongTheoKhoa = new cDGG_HeSoLopDongTheoKhoa();
            oDGG_HeSoLopDongTheoKhoa.Delete(pGG_HeSoLopDongTheoKhoaInfo);
        }


        public List<sp_XL_PhanCongGiaoVien_GetResult> cDXL_PhanCongGiaoVien_Get(string MaXacThuc, XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_PhanCongGiaoVien oDXL_PhanCongGiaoVien = new cDXL_PhanCongGiaoVien();
            DataTable dt = oDXL_PhanCongGiaoVien.Get(pXL_PhanCongGiaoVienInfo);
            return Convert.ToList<sp_XL_PhanCongGiaoVien_GetResult>(dt);
        }

        public int cDXL_PhanCongGiaoVien_Add(string MaXacThuc, XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDXL_PhanCongGiaoVien oDXL_PhanCongGiaoVien = new cDXL_PhanCongGiaoVien();
            return oDXL_PhanCongGiaoVien.Add(pXL_PhanCongGiaoVienInfo);
        }

        public void cDXL_PhanCongGiaoVien_Update(string MaXacThuc, XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDXL_PhanCongGiaoVien oDXL_PhanCongGiaoVien = new cDXL_PhanCongGiaoVien();
            oDXL_PhanCongGiaoVien.Update(pXL_PhanCongGiaoVienInfo);
        }

        public void cDXL_PhanCongGiaoVien_Delete(string MaXacThuc, XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDXL_PhanCongGiaoVien oDXL_PhanCongGiaoVien = new cDXL_PhanCongGiaoVien();
            oDXL_PhanCongGiaoVien.Delete(pXL_PhanCongGiaoVienInfo);
        }


        public List<sp_KQHT_XepLoaiMonHoc_GetResult> cDKQHT_XepLoaiMonHoc_Get(string MaXacThuc, KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_XepLoaiMonHoc oDKQHT_XepLoaiMonHoc = new cDKQHT_XepLoaiMonHoc();
            DataTable dt = oDKQHT_XepLoaiMonHoc.Get(pKQHT_XepLoaiMonHocInfo);
            return Convert.ToList<sp_KQHT_XepLoaiMonHoc_GetResult>(dt);
        }

        public int cDKQHT_XepLoaiMonHoc_Add(string MaXacThuc, KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDKQHT_XepLoaiMonHoc oDKQHT_XepLoaiMonHoc = new cDKQHT_XepLoaiMonHoc();
            return oDKQHT_XepLoaiMonHoc.Add(pKQHT_XepLoaiMonHocInfo);
        }

        public void cDKQHT_XepLoaiMonHoc_Update(string MaXacThuc, KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_XepLoaiMonHoc oDKQHT_XepLoaiMonHoc = new cDKQHT_XepLoaiMonHoc();
            oDKQHT_XepLoaiMonHoc.Update(pKQHT_XepLoaiMonHocInfo);
        }

        public void cDKQHT_XepLoaiMonHoc_Delete(string MaXacThuc, KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_XepLoaiMonHoc oDKQHT_XepLoaiMonHoc = new cDKQHT_XepLoaiMonHoc();
            oDKQHT_XepLoaiMonHoc.Delete(pKQHT_XepLoaiMonHocInfo);
        }

        public List<sp_XL_MonHocTrongKy_GetResult> cDXL_MonHocTrongKy_Get(string MaXacThuc, XL_MonHocTrongKyInfo pXL_MonHocTrongKyInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_MonHocTrongKy oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
            DataTable dt = oDXL_MonHocTrongKy.Get(pXL_MonHocTrongKyInfo);
            return Convert.ToList<sp_XL_MonHocTrongKy_GetResult>(dt);
        }

        public int cDXL_MonHocTrongKy_Add(string MaXacThuc, XL_MonHocTrongKyInfo pXL_MonHocTrongKyInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDXL_MonHocTrongKy oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
            return oDXL_MonHocTrongKy.Add(pXL_MonHocTrongKyInfo);
        }

        public void cDXL_MonHocTrongKy_Update(string MaXacThuc, XL_MonHocTrongKyInfo pXL_MonHocTrongKyInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDXL_MonHocTrongKy oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
            oDXL_MonHocTrongKy.Update(pXL_MonHocTrongKyInfo);
        }

        public void cDXL_MonHocTrongKy_Delete(string MaXacThuc, XL_MonHocTrongKyInfo pXL_MonHocTrongKyInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDXL_MonHocTrongKy oDXL_MonHocTrongKy = new cDXL_MonHocTrongKy();
            oDXL_MonHocTrongKy.Delete(pXL_MonHocTrongKyInfo);
        }


        public List<sp_KQHT_DiemThi_GetResult> cDKQHT_DiemThi_Get(string MaXacThuc, KQHT_DiemThiInfo pKQHT_DiemThiInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemThi oDKQHT_DiemThi = new cDKQHT_DiemThi();
            DataTable dt = oDKQHT_DiemThi.Get(pKQHT_DiemThiInfo);
            return Convert.ToList<sp_KQHT_DiemThi_GetResult>(dt);
        }

        public int cDKQHT_DiemThi_Add(string MaXacThuc, KQHT_DiemThiInfo pKQHT_DiemThiInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDKQHT_DiemThi oDKQHT_DiemThi = new cDKQHT_DiemThi();
            return oDKQHT_DiemThi.Add(pKQHT_DiemThiInfo);
        }

        public void cDKQHT_DiemThi_Update(string MaXacThuc, KQHT_DiemThiInfo pKQHT_DiemThiInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DiemThi oDKQHT_DiemThi = new cDKQHT_DiemThi();
            oDKQHT_DiemThi.Update(pKQHT_DiemThiInfo);
        }

        public void cDKQHT_DiemThi_Delete(string MaXacThuc, KQHT_DiemThiInfo pKQHT_DiemThiInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DiemThi oDKQHT_DiemThi = new cDKQHT_DiemThi();
            oDKQHT_DiemThi.Delete(pKQHT_DiemThiInfo);
        }

        public List<sp_KQHT_DiemDanh_GetResult> cDKQHT_DiemDanh_Get(string MaXacThuc, KQHT_DiemDanhInfo pKQHT_DiemDanhInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_DiemDanh oDKQHT_DiemDanh = new cDKQHT_DiemDanh();
            DataTable dt = oDKQHT_DiemDanh.Get(pKQHT_DiemDanhInfo);
            return Convert.ToList<sp_KQHT_DiemDanh_GetResult>(dt);
        }

        public int cDKQHT_DiemDanh_Add(string MaXacThuc, KQHT_DiemDanhInfo pKQHT_DiemDanhInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDKQHT_DiemDanh oDKQHT_DiemDanh = new cDKQHT_DiemDanh();
            return oDKQHT_DiemDanh.Add(pKQHT_DiemDanhInfo);
        }

        public void cDKQHT_DiemDanh_Update(string MaXacThuc, KQHT_DiemDanhInfo pKQHT_DiemDanhInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DiemDanh oDKQHT_DiemDanh = new cDKQHT_DiemDanh();
            oDKQHT_DiemDanh.Update(pKQHT_DiemDanhInfo);
        }

        public void cDKQHT_DiemDanh_Delete(string MaXacThuc, KQHT_DiemDanhInfo pKQHT_DiemDanhInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_DiemDanh oDKQHT_DiemDanh = new cDKQHT_DiemDanh();
            oDKQHT_DiemDanh.Delete(pKQHT_DiemDanhInfo);
        }

        public List<sp_KQHT_CTDT_ChiTiet_GetResult> cDKQHT_CTDT_ChiTiet_Get(string MaXacThuc, KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDKQHT_CTDT_ChiTiet oDKQHT_CTDT_ChiTiet = new cDKQHT_CTDT_ChiTiet();
            DataTable dt = oDKQHT_CTDT_ChiTiet.Get(pKQHT_CTDT_ChiTietInfo);
            return Convert.ToList<sp_KQHT_CTDT_ChiTiet_GetResult>(dt);
        }

        public int cDKQHT_CTDT_ChiTiet_Add(string MaXacThuc, KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDKQHT_CTDT_ChiTiet oDKQHT_CTDT_ChiTiet = new cDKQHT_CTDT_ChiTiet();
            return oDKQHT_CTDT_ChiTiet.Add(pKQHT_CTDT_ChiTietInfo);
        }

        public void cDKQHT_CTDT_ChiTiet_Update(string MaXacThuc, KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_CTDT_ChiTiet oDKQHT_CTDT_ChiTiet = new cDKQHT_CTDT_ChiTiet();
            oDKQHT_CTDT_ChiTiet.Update(pKQHT_CTDT_ChiTietInfo);
        }

        public void cDKQHT_CTDT_ChiTiet_Delete(string MaXacThuc, KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDKQHT_CTDT_ChiTiet oDKQHT_CTDT_ChiTiet = new cDKQHT_CTDT_ChiTiet();
            oDKQHT_CTDT_ChiTiet.Delete(pKQHT_CTDT_ChiTietInfo);
        }
        public int cDDM_MonHoc_Add(string MaXacThuc, DM_MonHocInfo pDM_MonHocInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDDM_MonHoc oDDM_MonHoc = new cDDM_MonHoc();
            return oDDM_MonHoc.Add(pDM_MonHocInfo);
        }

        public void cDDM_MonHoc_Update(string MaXacThuc, DM_MonHocInfo pDM_MonHocInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDDM_MonHoc oDDM_MonHoc = new cDDM_MonHoc();
            oDDM_MonHoc.Update(pDM_MonHocInfo);
        }

        public void cDDM_MonHoc_Delete(string MaXacThuc, DM_MonHocInfo pDM_MonHocInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDDM_MonHoc oDDM_MonHoc = new cDDM_MonHoc();
            oDDM_MonHoc.Delete(pDM_MonHocInfo);
        }
        public List<sp_DM_TrinhDo_GetResult> cDDM_TrinhDo_Get(string MaXacThuc, DM_TrinhDoInfo pDM_TrinhDoInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_TrinhDo oDDM_TrinhDo = new cDDM_TrinhDo();
            DataTable dt = oDDM_TrinhDo.Get(pDM_TrinhDoInfo);
            return Convert.ToList<sp_DM_TrinhDo_GetResult>(dt);
        }


        public List<sp_DM_KhoiKienThuc_GetResult> cDDM_KhoiKienThuc_Get(string MaXacThuc, DM_KhoiKienThucInfo pDM_KhoiKienThucInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_KhoiKienThuc oDDM_KhoiKienThuc = new cDDM_KhoiKienThuc();
            DataTable dt = oDDM_KhoiKienThuc.Get(pDM_KhoiKienThucInfo);
            return Convert.ToList<sp_DM_KhoiKienThuc_GetResult>(dt);
        }

        public int cDDM_KhoiKienThuc_Add(string MaXacThuc, DM_KhoiKienThucInfo pDM_KhoiKienThucInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDDM_KhoiKienThuc oDDM_KhoiKienThuc = new cDDM_KhoiKienThuc();
            return oDDM_KhoiKienThuc.Add(pDM_KhoiKienThucInfo);
        }

        public void cDDM_KhoiKienThuc_Update(string MaXacThuc, DM_KhoiKienThucInfo pDM_KhoiKienThucInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDDM_KhoiKienThuc oDDM_KhoiKienThuc = new cDDM_KhoiKienThuc();
            oDDM_KhoiKienThuc.Update(pDM_KhoiKienThucInfo);
        }

        public void cDDM_KhoiKienThuc_Delete(string MaXacThuc, DM_KhoiKienThucInfo pDM_KhoiKienThucInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDDM_KhoiKienThuc oDDM_KhoiKienThuc = new cDDM_KhoiKienThuc();
            oDDM_KhoiKienThuc.Delete(pDM_KhoiKienThucInfo);
        }

        public List<sp_DM_HinhThucThi_GetResult> cDDM_HinhThucThi_Get(string MaXacThuc, DM_HinhThucThiInfo pDM_HinhThucThiInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_HinhThucThi oDDM_HinhThucThi = new cDDM_HinhThucThi();
            DataTable dt = oDDM_HinhThucThi.Get(pDM_HinhThucThiInfo);
            return Convert.ToList<sp_DM_HinhThucThi_GetResult>(dt);
        }

        public int cDDM_HinhThucThi_Add(string MaXacThuc, DM_HinhThucThiInfo pDM_HinhThucThiInfo)
        {
            if (MaXacThuc != "ABC") return 0;
            cDDM_HinhThucThi oDDM_HinhThucThi = new cDDM_HinhThucThi();
            return oDDM_HinhThucThi.Add(pDM_HinhThucThiInfo);
        }

        public void cDDM_HinhThucThi_Update(string MaXacThuc, DM_HinhThucThiInfo pDM_HinhThucThiInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDDM_HinhThucThi oDDM_HinhThucThi = new cDDM_HinhThucThi();
            oDDM_HinhThucThi.Update(pDM_HinhThucThiInfo);
        }

        public void cDDM_HinhThucThi_Delete(string MaXacThuc, DM_HinhThucThiInfo pDM_HinhThucThiInfo)
        {
            if (MaXacThuc != "ABC") return;
            cDDM_HinhThucThi oDDM_HinhThucThi = new cDDM_HinhThucThi();
            oDDM_HinhThucThi.Delete(pDM_HinhThucThiInfo);
        }
        public List<sp_DM_Nganh_GetResult> cDDM_Nganh_Get(string MaXacThuc, DM_NganhInfo pDM_NganhInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_Nganh oDDM_Nganh = new cDDM_Nganh();
            DataTable dt = oDDM_Nganh.Get(pDM_NganhInfo);
            return Convert.ToList<sp_DM_Nganh_GetResult>(dt);
        }
        public List<sp_DM_KhoaHoc_GetResult> cDDM_KhoaHoc_Get(string MaXacThuc, DM_KhoaHocInfo pDM_KhoaHocInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_KhoaHoc oDDM_KhoaHoc = new cDDM_KhoaHoc();
            DataTable dt = oDDM_KhoaHoc.Get(pDM_KhoaHocInfo);
            return Convert.ToList<sp_DM_KhoaHoc_GetResult>(dt);
        }

        public List<sp_DM_Khoa_GetResult> cDDM_Khoa_Get(string MaXacThuc, DM_KhoaInfo pDM_KhoaInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDDM_Khoa oDDM_Khoa = new cDDM_Khoa();
            DataTable dt = oDDM_Khoa.Get(pDM_KhoaInfo);
            return Convert.ToList<sp_DM_Khoa_GetResult>(dt);
        }
        public List<sp_XL_GiaoVien_MonHoc_GetResult> cDXL_GiaoVien_MonHoc_Get(string MaXacThuc, XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo)
        {
            if (MaXacThuc != "ABC") return null;
            cDXL_GiaoVien_MonHoc oDXL_GiaoVien_MonHoc = new cDXL_GiaoVien_MonHoc();
            DataTable dt = oDXL_GiaoVien_MonHoc.Get(pXL_GiaoVien_MonHocInfo);
            return Convert.ToList<sp_XL_GiaoVien_MonHoc_GetResult>(dt);
        }
    }
}