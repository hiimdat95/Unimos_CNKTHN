using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.wsBusiness;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Entity.Model;
using TruongViet.UnimOs.Data;
using UnimOs.wsBusiness.wsUnimOs;
using System.Drawing;
using System.IO;

namespace TruongViet.UnimOs.wsBusiness
{
    public class cBwsSV_SinhVien : cBwsBase
    {
        private cDSV_SinhVien oDSV_SinhVien;
        private SV_SinhVienInfo oSV_SinhVienInfo;

        public cBwsSV_SinhVien()
        {
            oDSV_SinhVien = new cDSV_SinhVien();
        }

        protected string GetTen(string pHoVaTen, ref string Ho_Dem)
        {
            pHoVaTen = pHoVaTen.Trim();
            if (pHoVaTen == "")
            {
                Ho_Dem = "";
                return "";
            }
            string[] arrTemp = pHoVaTen.Split(new char[] { ' ' });
            if (arrTemp.Length == 0)
            {
                Ho_Dem = "";
                return "";
            }
            else if (arrTemp.Length == 1)
            {
                Ho_Dem = "";
                return arrTemp[0];
            }
            else
            {
                Ho_Dem = pHoVaTen.Substring(0, pHoVaTen.ToString().Length - arrTemp[arrTemp.Length - 1].Length - 1);
                return arrTemp[arrTemp.Length - 1];
            }
        }

        public void TachCotHoVaTen(ref DataTable dt)
        {
            if (!dt.Columns.Contains("HoVa"))
                dt.Columns.Add("HoVa", typeof(string));
            string HoVa = "";
            foreach (DataRow dr in dt.Rows)
            {
                dr["Ten"] = GetTen(dr["HoVaTen"].ToString(), ref HoVa);
                dr["HoVa"] = HoVa;
            }
        }

        public DataTable GetByLop(int IDDM_LopID, int TrangThai)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_SV_SinhVien_GetByLopResult>(client.cDSV_SinhVien_GetByLop(GlobalVar.MaXacThuc, IDDM_LopID, TrangThai));
            }
        }

        public string GetNextMaSinhVien(int IDDM_Lop, string MaSinhVien)
        {
            int DoDaiTuTang = 0;
            var client = new UnimOsServiceClient();
            MaSinhVien = client.cDSV_SinhVien_GetNextMaSinhVien(GlobalVar.MaXacThuc, IDDM_Lop, MaSinhVien, ref DoDaiTuTang);
            client.Close();
            if (MaSinhVien != "")
            {
                string TuTang = MaSinhVien.Substring(MaSinhVien.Length - DoDaiTuTang);
                int Next;
                if (int.TryParse(TuTang, out Next))
                {
                    Next++;
                    MaSinhVien = MaSinhVien.Substring(0, MaSinhVien.Length - DoDaiTuTang) + Next.ToString().PadLeft(DoDaiTuTang, '0');
                    return MaSinhVien;
                }
            }
            return "";
        }

        public DataTable GetHoSo(int SV_SinhVienID)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_SV_SinhVien_GetHoSoResult>(client.cDSV_SinhVien_GetHoSo(GlobalVar.MaXacThuc, SV_SinhVienID));
            }
        }

        public DataTable GetByLop_Mon(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int IDKQHT_HoiDongMon)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_SV_SinhVien_GetByLop_MonResult>(client.cDSV_SinhVien_GetByLop_Mon(GlobalVar.MaXacThuc, IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, IDKQHT_HoiDongMon));
            }
        }

        public DataTable GetDanhSachDuThi(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi, string DaDangKy, int TotNghiep)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<SV_SinhVienInfo>(client.cDSV_SinhVien_GetDanhSachDuThi(GlobalVar.MaXacThuc, IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi, DaDangKy, TotNghiep));
            }
        }

        //public DataTable GetDaTotNghiep(DM_LopInfo pDM_LopInfo)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<SV_SinhVienInfo>(client.cDSV_SinhVien_GetDaTotNghiep(GlobalVar.MaXacThuc, pDM_LopInfo));
        //    }
        //}

        //public DataTable GetSinhVien_XetLenLop(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<SV_SinhVienInfo>(client.cDSV_SinhVien_GetSinhVien_XetLenLop(GlobalVar.MaXacThuc, pDM_LopInfo, NamHoc, IDDM_NamHoc));
        //    }
        //}

        //public DataSet GetDSXetHocBong(DM_LopInfo pDM_LopInfo, string NamHoc, int HocKy, int IDDM_NamHoc, double DiemRenLuyen, double DiemTBC)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return client.cDSV_SinhVien_GetDSXetHocBong(GlobalVar.MaXacThuc, pDM_LopInfo, NamHoc, HocKy, IDDM_NamHoc, DiemRenLuyen, DiemTBC);
        //    }
        //}

        //public DataTable GetSinhVien_XetThiTotNghiep(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc, double PTDVHTNo)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<SV_SinhVienInfo>(client.cDSV_SinhVien_GetSinhVien_XetThiTotNghiep(GlobalVar.MaXacThuc, pDM_LopInfo, NamHoc, IDDM_NamHoc, PTDVHTNo));
        //    }
        //}

        //public DataTable GetDanhSachXetThiTotNghiep(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<SV_SinhVienInfo>(client.cDSV_SinhVien_GetDanhSachXetThiTotNghiep(GlobalVar.MaXacThuc, pDM_LopInfo, NamHoc, IDDM_NamHoc));
        //    }
        //}

        //public DataTable GetDanhSachDuThiTotNghiep(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<SV_SinhVienInfo>(client.cDSV_SinhVien_GetDanhSachDuThiTotNghiep(GlobalVar.MaXacThuc, pDM_LopInfo, NamHoc, IDDM_NamHoc));
        //    }
        //}

        //public DataTable GetDanhSachDuThiTotNghiep_ToChucThi(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc, string DaDangKy)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<SV_SinhVienInfo>(client.cDSV_SinhVien_GetDanhSachDuThiTotNghiep_ToChucThi(GlobalVar.MaXacThuc, pDM_LopInfo, NamHoc, IDDM_NamHoc, DaDangKy));
        //    }
        //}

        //public DataTable GetDanhSachKhongDuThiTotNghiep(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<SV_SinhVienInfo>(client.cDSV_SinhVien_GetDanhSachKhongDuThiTotNghiep(GlobalVar.MaXacThuc, pDM_LopInfo, NamHoc, IDDM_NamHoc));
        //    }
        //}

        //public DataTable GetTongHop_KhongThiTotNghiep(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc, double PTDVHTNo)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<SV_SinhVienInfo>(client.cDSV_SinhVien_GetTongHop_KhongThiTotNghiep(GlobalVar.MaXacThuc, pDM_LopInfo, NamHoc, IDDM_NamHoc, PTDVHTNo));
        //    }
        //}

        //public DataTable GetDanhSach_ToChucThi(DM_LopInfo pDM_LopInfo, string NamHoc, string DaDangKy)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<SV_SinhVienInfo>(client.cDSV_SinhVien_GetDanhSach_ToChucThi(GlobalVar.MaXacThuc, pDM_LopInfo, NamHoc, DaDangKy));
        //    }
        //}

        //public DataTable GetThiSinhTuDo(DM_LopInfo pDM_LopInfo, string NamHoc, int IDDM_NamHoc, string DaDangKy)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<SV_SinhVienInfo>(client.cDSV_SinhVien_GetThiSinhTuDo(GlobalVar.MaXacThuc, pDM_LopInfo, NamHoc, IDDM_NamHoc, DaDangKy));
        //    }
        //}

        public DataTable GetDanhSachThiLai(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi, string DaDangKy, int TotNghiep)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<SV_SinhVienInfo>(client.cDSV_SinhVien_GetDanhSachThiLai(GlobalVar.MaXacThuc, IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi, DaDangKy, TotNghiep));
            }
        }

        public DataTable GetDanhSachDuThiKhoaTruoc(int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi, string DaDangKy)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<SV_SinhVienInfo>(client.cDSV_SinhVien_GetDanhSachDuThiKhoaTruoc(GlobalVar.MaXacThuc, IDDM_MonHoc, IDDM_NamHoc, HocKy, LanThi, DaDangKy));
            }
        }

        //public void XetRaTruong(int IDSV_SinhVien, string SoBang, int TrangThaiSinhVien)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDSV_SinhVien_XetRaTruong(GlobalVar.MaXacThuc, IDSV_SinhVien, SoBang, TrangThaiSinhVien);
        //    client.Close();
        //}

        public DataTable TimKiem(SV_SinhVienInfo pSV_SinhVienInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_SV_SinhVien_TimKiemResult>(client.cDSV_SinhVien_TimKiem(GlobalVar.MaXacThuc, pSV_SinhVienInfo));
            }
        }

        //public DataTable UpdateDanhSach(int IDDM_Lop, string ChuoiSV_SinhVienID)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<SV_SinhVienInfo>(client.cDSV_SinhVien_UpdateDanhSach(GlobalVar.MaXacThuc, IDDM_Lop, ChuoiSV_SinhVienID));
        //    }
        //}

        //public DataTable UpdateTrangThaiSinhVien(int TrangThaiSinhVien, string ChuoiSV_SinhVienID)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<SV_SinhVienInfo>(client.cDSV_SinhVien_UpdateTrangThaiSinhVien(GlobalVar.MaXacThuc, TrangThaiSinhVien, ChuoiSV_SinhVienID));
        //    }
        //}

        //public void UpdateTheoLop(string MaSinhVien, string HoVaTen, string Ten, DateTime NgaySinh, bool GioiTinh, string NoiSinh, string ThuongTru, int SV_SinhVienID)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDSV_SinhVien_UpdateTheoLop(GlobalVar.MaXacThuc, MaSinhVien, HoVaTen, Ten, NgaySinh, GioiTinh, NoiSinh, ThuongTru, SV_SinhVienID);
        //    client.Close();
        //    mErrorMessage = oDSV_SinhVien.ErrorMessages;
        //    mErrorNumber = oDSV_SinhVien.ErrorNumber;
        //}

        //public DataTable Get(SV_SinhVienInfo pSV_SinhVienInfo)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<SV_SinhVienInfo>(client.cDSV_SinhVien_Get(GlobalVar.MaXacThuc, pSV_SinhVienInfo));
        //    }
        //}

        public DataTable KiemTraMaSV(string MaSinhVien)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_SV_SinhVien_KiemTraMaSVResult>(client.cDSV_SinhVien_KiemTraMaSV(GlobalVar.MaXacThuc, MaSinhVien));
            }
        }

        public DataTable GetSinhVien(DM_LopInfo pDM_LopInfo, string NamHoc, bool ChuaTaoMa)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<SV_SinhVienInfo>(client.cDSV_SinhVien_GetSinhVien(GlobalVar.MaXacThuc, pDM_LopInfo, NamHoc, ChuaTaoMa));
            }
        }

        //public DataTable GetSinhVienLapTaiKhoan(DM_LopInfo pDM_LopInfo, string NamHoc, string HoVaTen, string MaSinhVien)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<SV_SinhVienInfo>(client.cDSV_SinhVien_GetSinhVienLapTaiKhoan(GlobalVar.MaXacThuc, pDM_LopInfo, NamHoc, HoVaTen, MaSinhVien));
        //    }
        //}

        //public string GetMaLonNhat(int DoDaiMa, string PhanDauMa, string PhanCuoiMa)
        //{
        //    var client = new UnimOsServiceClient();
        //    DataTable dt = ConvertList.ToDataTable<SV_SinhVienInfo>(client.cDSV_SinhVien_GetMaLonNhat(GlobalVar.MaXacThuc, DoDaiMa, PhanDauMa, PhanCuoiMa));
        //    client.Close();
        //    if (dt.Rows.Count > 0)
        //        return dt.Rows[0]["MaSinhVien"].ToString();
        //    else
        //        return "";
        //}

        public string CheckExistByMaSinhVien(string MaSinhViens)
        {
            using (var client = new UnimOsServiceClient())
            {
                return client.cDSV_SinhVien_CheckExistByMaSinhVien(GlobalVar.MaXacThuc, MaSinhViens);
            }
        }

        public string CheckExistAndGetInfo(string MaSinhViens, ref string HoVaTens, ref string TenLops)
        {
            using (var client = new UnimOsServiceClient())
            {
                return client.cDSV_SinhVien_CheckExistAndGetInfo(GlobalVar.MaXacThuc, MaSinhViens, ref HoVaTens, ref TenLops);
            }
        }

        public DataTable CreateTableTrangThai()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TenTrangThai", typeof(string));
            dt.Columns.Add("TrangThai", typeof(int));

            DataRow dr = dt.NewRow();
            dr["TrangThai"] = 0;
            dr["TenTrangThai"] = " ";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TrangThai"] = 1;
            dr["TenTrangThai"] = "Học tiếp";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TrangThai"] = 2;
            dr["TenTrangThai"] = "Đã tốt nghiệp";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TrangThai"] = 3;
            dr["TenTrangThai"] = "Bảo lưu";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TrangThai"] = 4;
            dr["TenTrangThai"] = "Chuyển trường";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TrangThai"] = 5;
            dr["TenTrangThai"] = "Ngừng học";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TrangThai"] = 6;
            dr["TenTrangThai"] = "Thôi học";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TrangThai"] = 7;
            dr["TenTrangThai"] = "Bị đuổi học";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["TrangThai"] = 8;
            dr["TenTrangThai"] = "Chuyển lớp";
            dt.Rows.Add(dr);

            return dt;
        }

        //public int Add(SV_SinhVienInfo pSV_SinhVienInfo)
        //{
        //    int ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDSV_SinhVien_Add(GlobalVar.MaXacThuc, pSV_SinhVienInfo);
        //    client.Close();
        //    mErrorMessage = oDSV_SinhVien.ErrorMessages;
        //    mErrorNumber = oDSV_SinhVien.ErrorNumber;
        //    return ID;
        //}

        //public int AddByPhanLop(int IDSV_SinhVienNhapTruong, int IDDM_Lop)
        //{
        //    int ID = 0;
        //    var client = new UnimOsServiceClient();
        //    ID = client.cDSV_SinhVien_AddByPhanLop(GlobalVar.MaXacThuc, IDSV_SinhVienNhapTruong, IDDM_Lop);
        //    client.Close();
        //    mErrorMessage = oDSV_SinhVien.ErrorMessages;
        //    mErrorNumber = oDSV_SinhVien.ErrorNumber;
        //    return ID;
        //}

        //public void Update(SV_SinhVienInfo pSV_SinhVienInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDSV_SinhVien_Update(GlobalVar.MaXacThuc, pSV_SinhVienInfo);
        //    client.Close();
        //    mErrorMessage = oDSV_SinhVien.ErrorMessages;
        //    mErrorNumber = oDSV_SinhVien.ErrorNumber;
        //}

        //public int UpdateMaSinhVien(string MaSinhVien, int SV_SinhVienID)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return client.cDSV_SinhVien_UpdateMaSinhVien(GlobalVar.MaXacThuc, MaSinhVien, SV_SinhVienID);
        //    }
        //}

        //public void UpdateMaSinhVien(ref DataTable dtSinhVien)
        //{
        //    if (!dtSinhVien.Columns.Contains("GhiChu"))
        //        dtSinhVien.Columns.Add("GhiChu", typeof(string));
        //    foreach (DataRow dr in dtSinhVien.Rows)
        //    {
        //        if (UpdateMaSinhVien(dr["MaSinhVien"].ToString(), int.Parse(dr["SV_SinhVienID"].ToString())) > 0)
        //            dr["GhiChu"] = "Mã này đã được sử dụng cho sinh viên khác";
        //    }
        //}

        //public void UpdateTaiKhoan(DataTable dtSinhVien)
        //{
        //    foreach (DataRow dr in dtSinhVien.Rows)
        //    {
        //        var client = new UnimOsServiceClient();
        //        client.cDSV_SinhVien_UpdateTaiKhoan(GlobalVar.MaXacThuc, dr["TenDangNhap"].ToString(), dr["MatKhau"].ToString(), int.Parse(dr["SV_SinhVienID"].ToString()));
        //        client.Close();
        //    }
        //}

        //public void UpdateAnhSinhVien(byte[] Anh, int SV_SinhVienID)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDSV_SinhVien_UpdateAnhSinhVien(GlobalVar.MaXacThuc, Anh, SV_SinhVienID);
        //    client.Close();
        //}

        //public void UpdateAnhSinhVien(DataTable dtSinhVien, string ThuMucAnh)
        //{
        //    Image img;
        //    byte[] Anh;
        //    foreach (DataRow dr in dtSinhVien.Rows)
        //    {
        //        if ("" + dr["FileAnh"] != "")
        //        {
        //            MemoryStream ms = new MemoryStream();
        //            img = Image.FromFile(ThuMucAnh + dr["FileAnh"].ToString());
        //            img.Save(ms, img.RawFormat);
        //            Anh = ms.GetBuffer();
        //            UpdateAnhSinhVien(Anh, int.Parse(dr["SV_SinhVienID"].ToString()));
        //        }
        //    }
        //}

        //public void ChuyenLop(int IDSV_SinhVien, int IDDM_Lop_Cu, int IDDM_Lop_Moi, int TrangThaiSinhVien_Chuyen)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDSV_SinhVien_ChuyenLop(GlobalVar.MaXacThuc, IDSV_SinhVien, IDDM_Lop_Cu, IDDM_Lop_Moi, TrangThaiSinhVien_Chuyen);
        //    client.Close();
        //}

        //public DataTable GetBangDiemLanCuoi(int IDSV_SinhVien, int IDDM_NamHoc, string TenNamHoc)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<SV_SinhVienInfo>(client.cDSV_SinhVien_GetBangDiemLanCuoi(GlobalVar.MaXacThuc, IDSV_SinhVien, IDDM_NamHoc, TenNamHoc));
        //    }
        //}

        //public void Delete(SV_SinhVienInfo pSV_SinhVienInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDSV_SinhVien_Delete(GlobalVar.MaXacThuc, pSV_SinhVienInfo);
        //    client.Close();
        //    mErrorMessage = oDSV_SinhVien.ErrorMessages;
        //    mErrorNumber = oDSV_SinhVien.ErrorNumber;
        //}

        //public List<SV_SinhVienInfo> GetList(SV_SinhVienInfo pSV_SinhVienInfo)
        //{
        //    List<SV_SinhVienInfo> oSV_SinhVienInfoList = new List<SV_SinhVienInfo>();
        //    DataTable dtb = Get(pSV_SinhVienInfo);
        //    if (dtb != null)
        //    {
        //        for (int i = 0; i < dtb.Rows.Count; i++)
        //        {
        //            oSV_SinhVienInfo = new SV_SinhVienInfo();

        //            oSV_SinhVienInfo.SV_SinhVienID = int.Parse(dtb.Rows[i]["SV_SinhVienID"].ToString());
        //            oSV_SinhVienInfo.MaSinhVien = dtb.Rows[i]["MaSinhVien"].ToString();
        //            oSV_SinhVienInfo.HoVaTen = dtb.Rows[i]["HoVaTen"].ToString();
        //            oSV_SinhVienInfo.Ten = dtb.Rows[i]["Ten"].ToString();
        //            oSV_SinhVienInfo.NgaySinh = DateTime.Parse(dtb.Rows[i]["NgaySinh"].ToString());
        //            oSV_SinhVienInfo.SoCMND = "" + dtb.Rows[i]["SoCMND"];
        //            oSV_SinhVienInfo.NgayCapCMND = DateTime.Parse(dtb.Rows[i]["NgayCapCMND"].ToString());
        //            oSV_SinhVienInfo.IDTinhNoiCapCMND = int.Parse(dtb.Rows[i]["IDTinhNoiCapCMND"].ToString());
        //            oSV_SinhVienInfo.Anh = (byte[])(dtb.Rows[i]["Anh"]);
        //            oSV_SinhVienInfo.GioiTinh = bool.Parse(dtb.Rows[i]["GioiTinh"].ToString());
        //            oSV_SinhVienInfo.IDDM_DanToc = int.Parse(dtb.Rows[i]["IDDM_DanToc"].ToString());
        //            oSV_SinhVienInfo.IDDM_TonGiao = int.Parse(dtb.Rows[i]["IDDM_TonGiao"].ToString());
        //            oSV_SinhVienInfo.IDDM_QuocTich = int.Parse(dtb.Rows[i]["IDDM_QuocTich"].ToString());
        //            oSV_SinhVienInfo.NoiSinh = dtb.Rows[i]["NoiSinh"].ToString();
        //            oSV_SinhVienInfo.IDDM_TinhHuyenXaNoiSinh = int.Parse(dtb.Rows[i]["IDDM_TinhHuyenXaNoiSinh"].ToString());
        //            oSV_SinhVienInfo.QueQuan = dtb.Rows[i]["QueQuan"].ToString();
        //            oSV_SinhVienInfo.IDDM_TinhHuyenXaQueQuan = int.Parse(dtb.Rows[i]["IDDM_TinhHuyenXaQueQuan"].ToString());
        //            oSV_SinhVienInfo.ThuongTru = dtb.Rows[i]["ThuongTru"].ToString();
        //            oSV_SinhVienInfo.IDDM_TinhHuyenXaThuongTru = int.Parse(dtb.Rows[i]["IDDM_TinhHuyenXaThuongTru"].ToString());
        //            oSV_SinhVienInfo.NgayVaoDoan = DateTime.Parse(dtb.Rows[i]["NgayVaoDoan"].ToString());
        //            oSV_SinhVienInfo.NgayVaoDang = DateTime.Parse(dtb.Rows[i]["NgayVaoDang"].ToString());
        //            oSV_SinhVienInfo.DienThoaiNhaRieng = dtb.Rows[i]["DienThoaiNhaRieng"].ToString();
        //            oSV_SinhVienInfo.DienThoaiDiDong = dtb.Rows[i]["DienThoaiDiDong"].ToString();
        //            oSV_SinhVienInfo.Email = dtb.Rows[i]["Email"].ToString();
        //            oSV_SinhVienInfo.Active = int.Parse(dtb.Rows[i]["Active"].ToString());
        //            oSV_SinhVienInfo.Xoa = bool.Parse(dtb.Rows[i]["Xoa"].ToString());

        //            oSV_SinhVienInfoList.Add(oSV_SinhVienInfo);
        //        }
        //    }
        //    return oSV_SinhVienInfoList;
        //}

        public void ToDataRow(SV_SinhVienInfo pSV_SinhVienInfo, ref DataRow dr)
        {

            dr[pSV_SinhVienInfo.strSV_SinhVienID] = pSV_SinhVienInfo.SV_SinhVienID;
            dr[pSV_SinhVienInfo.strMaSinhVien] = pSV_SinhVienInfo.MaSinhVien;
            dr[pSV_SinhVienInfo.strHoVaTen] = pSV_SinhVienInfo.HoVaTen;
            dr[pSV_SinhVienInfo.strTen] = pSV_SinhVienInfo.Ten;
            dr[pSV_SinhVienInfo.strNgaySinh] = pSV_SinhVienInfo.NgaySinh;
            dr[pSV_SinhVienInfo.strSoCMND] = pSV_SinhVienInfo.SoCMND;
            dr[pSV_SinhVienInfo.strNgayCapCMND] = pSV_SinhVienInfo.NgayCapCMND;
            dr[pSV_SinhVienInfo.strIDTinhNoiCapCMND] = pSV_SinhVienInfo.IDTinhNoiCapCMND;
            // dr[pSV_SinhVienInfo.strAnh] = pSV_SinhVienInfo.Anh;
            dr[pSV_SinhVienInfo.strGioiTinh] = pSV_SinhVienInfo.GioiTinh;
            dr[pSV_SinhVienInfo.strIDDM_DanToc] = pSV_SinhVienInfo.IDDM_DanToc;
            dr[pSV_SinhVienInfo.strIDDM_TonGiao] = pSV_SinhVienInfo.IDDM_TonGiao;
            dr[pSV_SinhVienInfo.strIDDM_QuocTich] = pSV_SinhVienInfo.IDDM_QuocTich;
            dr[pSV_SinhVienInfo.strNoiSinh] = pSV_SinhVienInfo.NoiSinh;
            dr[pSV_SinhVienInfo.strIDDM_TinhHuyenXaNoiSinh] = pSV_SinhVienInfo.IDDM_TinhHuyenXaNoiSinh;
            dr[pSV_SinhVienInfo.strQueQuan] = pSV_SinhVienInfo.QueQuan;
            dr[pSV_SinhVienInfo.strIDDM_TinhHuyenXaQueQuan] = pSV_SinhVienInfo.IDDM_TinhHuyenXaQueQuan;
            dr[pSV_SinhVienInfo.strThuongTru] = pSV_SinhVienInfo.ThuongTru;
            dr[pSV_SinhVienInfo.strIDDM_TinhHuyenXaThuongTru] = pSV_SinhVienInfo.IDDM_TinhHuyenXaThuongTru;
            dr[pSV_SinhVienInfo.strNgayVaoDoan] = pSV_SinhVienInfo.NgayVaoDoan;
            dr[pSV_SinhVienInfo.strNgayVaoDang] = pSV_SinhVienInfo.NgayVaoDang;
            dr[pSV_SinhVienInfo.strDienThoaiNhaRieng] = pSV_SinhVienInfo.DienThoaiNhaRieng;
            dr[pSV_SinhVienInfo.strDienThoaiDiDong] = pSV_SinhVienInfo.DienThoaiDiDong;
            dr[pSV_SinhVienInfo.strEmail] = pSV_SinhVienInfo.Email;
            dr[pSV_SinhVienInfo.strActive] = pSV_SinhVienInfo.Active;
            dr[pSV_SinhVienInfo.strXoa] = pSV_SinhVienInfo.Xoa;
        }

        public void ToInfo(ref SV_SinhVienInfo pSV_SinhVienInfo, DataRow dr)
        {
            pSV_SinhVienInfo.SV_SinhVienID = int.Parse(dr[pSV_SinhVienInfo.strSV_SinhVienID].ToString());
            pSV_SinhVienInfo.MaSinhVien = dr[pSV_SinhVienInfo.strMaSinhVien].ToString();
            pSV_SinhVienInfo.HoVaTen = dr[pSV_SinhVienInfo.strHoVaTen].ToString();
            pSV_SinhVienInfo.Ten = dr[pSV_SinhVienInfo.strTen].ToString();
            if (dr[pSV_SinhVienInfo.strNgaySinh].ToString() != "")
                pSV_SinhVienInfo.NgaySinh = DateTime.Parse(dr[pSV_SinhVienInfo.strNgaySinh].ToString());
            pSV_SinhVienInfo.SoCMND = "" + dr[pSV_SinhVienInfo.strSoCMND];
            if (dr[pSV_SinhVienInfo.strNgayCapCMND].ToString() != "")
                pSV_SinhVienInfo.NgayCapCMND = DateTime.Parse(dr[pSV_SinhVienInfo.strNgayCapCMND].ToString());
            if ("" + dr[pSV_SinhVienInfo.strIDTinhNoiCapCMND] != "")
                pSV_SinhVienInfo.IDTinhNoiCapCMND = int.Parse(dr[pSV_SinhVienInfo.strIDTinhNoiCapCMND].ToString());
            //  if (dr[pSV_SinhVienInfo.strAnh] != null)
            //  pSV_SinhVienInfo.Anh = (byte[])(dr[pSV_SinhVienInfo.strAnh]);
            pSV_SinhVienInfo.GioiTinh = bool.Parse(dr[pSV_SinhVienInfo.strGioiTinh].ToString());
            pSV_SinhVienInfo.IDDM_DanToc = int.Parse("0" + dr[pSV_SinhVienInfo.strIDDM_DanToc]);
            pSV_SinhVienInfo.IDDM_TonGiao = int.Parse("0" + dr[pSV_SinhVienInfo.strIDDM_TonGiao]);
            pSV_SinhVienInfo.IDDM_QuocTich = int.Parse("0" + dr[pSV_SinhVienInfo.strIDDM_QuocTich]);
            pSV_SinhVienInfo.NoiSinh = dr[pSV_SinhVienInfo.strNoiSinh].ToString();
            pSV_SinhVienInfo.IDDM_TinhHuyenXaNoiSinh = int.Parse("0" + dr[pSV_SinhVienInfo.strIDDM_TinhHuyenXaNoiSinh]);
            pSV_SinhVienInfo.QueQuan = "" + dr[pSV_SinhVienInfo.strQueQuan];
            pSV_SinhVienInfo.IDDM_TinhHuyenXaQueQuan = int.Parse("0" + dr[pSV_SinhVienInfo.strIDDM_TinhHuyenXaQueQuan]);
            pSV_SinhVienInfo.ThuongTru = "" + dr[pSV_SinhVienInfo.strThuongTru];
            pSV_SinhVienInfo.IDDM_TinhHuyenXaThuongTru = int.Parse("0" + dr[pSV_SinhVienInfo.strIDDM_TinhHuyenXaThuongTru]);
            if (dr[pSV_SinhVienInfo.strNgayVaoDoan].ToString() != "")
                pSV_SinhVienInfo.NgayVaoDoan = DateTime.Parse(dr[pSV_SinhVienInfo.strNgayVaoDoan].ToString());
            if (dr[pSV_SinhVienInfo.strNgayVaoDang].ToString() != "")
                pSV_SinhVienInfo.NgayVaoDang = DateTime.Parse(dr[pSV_SinhVienInfo.strNgayVaoDang].ToString());
            pSV_SinhVienInfo.DienThoaiNhaRieng = dr[pSV_SinhVienInfo.strDienThoaiNhaRieng].ToString();
            pSV_SinhVienInfo.DienThoaiDiDong = dr[pSV_SinhVienInfo.strDienThoaiDiDong].ToString();
            pSV_SinhVienInfo.Email = dr[pSV_SinhVienInfo.strEmail].ToString();
            pSV_SinhVienInfo.Active = int.Parse(dr[pSV_SinhVienInfo.strActive].ToString());
            pSV_SinhVienInfo.Xoa = bool.Parse(dr[pSV_SinhVienInfo.strXoa].ToString());
        }

        public void ToInfo(ref SV_SinhVienInfo pSV_SinhVienInfo, DataRow dr, DataTable dt)
        {
            if (dt.Columns.Contains(pSV_SinhVienInfo.strMaSinhVien))
                pSV_SinhVienInfo.MaSinhVien = dr[pSV_SinhVienInfo.strMaSinhVien].ToString();
            if (dt.Columns.Contains(pSV_SinhVienInfo.strHoVaTen))
            {
                pSV_SinhVienInfo.HoVaTen = dr[pSV_SinhVienInfo.strHoVaTen].ToString();
                pSV_SinhVienInfo.Ten = GetTen(dr[pSV_SinhVienInfo.strHoVaTen].ToString());
            }
            if (dt.Columns.Contains(pSV_SinhVienInfo.strNgaySinh))
            {
                if ("" + dr[pSV_SinhVienInfo.strNgaySinh] != "")
                    pSV_SinhVienInfo.NgaySinh = DateTime.Parse(dr[pSV_SinhVienInfo.strNgaySinh].ToString());
                else
                    pSV_SinhVienInfo.NgaySinh = DateTime.Parse("1/1/1900");
            }
            else
                pSV_SinhVienInfo.NgaySinh = DateTime.Parse("1/1/1900");
            if (dt.Columns.Contains(pSV_SinhVienInfo.strGioiTinh))
                pSV_SinhVienInfo.GioiTinh = "" + dr[pSV_SinhVienInfo.strGioiTinh] == "NAM" ? false : true;
            if (dt.Columns.Contains(pSV_SinhVienInfo.strIDDM_DanToc))
                pSV_SinhVienInfo.IDDM_DanToc = int.Parse("0" + dr[pSV_SinhVienInfo.strIDDM_DanToc]);
            if (dt.Columns.Contains(pSV_SinhVienInfo.strNoiSinh))
                pSV_SinhVienInfo.NoiSinh = dr[pSV_SinhVienInfo.strNoiSinh].ToString();
            if (dt.Columns.Contains(pSV_SinhVienInfo.strQueQuan))
                pSV_SinhVienInfo.QueQuan = dr[pSV_SinhVienInfo.strQueQuan].ToString();
            if (dt.Columns.Contains(pSV_SinhVienInfo.strThuongTru))
                pSV_SinhVienInfo.ThuongTru = dr[pSV_SinhVienInfo.strThuongTru].ToString();
            pSV_SinhVienInfo.NgayCapCMND = DateTime.Parse("1/1/1900");
            pSV_SinhVienInfo.NgayVaoDoan = DateTime.Parse("1/1/1900");
            pSV_SinhVienInfo.NgayVaoDang = DateTime.Parse("1/1/1900");
            pSV_SinhVienInfo.Active = 1;
        }

        public bool KiemTraThongTinNhapDiemExcel(ref DataRow drSinhVien, ref DataRow drNew, ref DataRow dr, string MaSinhVien, bool DiemThanhPhan, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy)
        {
            DataTable dtSinhVien = KiemTraMaSV(MaSinhVien);
            if (dtSinhVien.Rows.Count < 0)
            {
                dr["LyDo"] = "Mã sinh viên không tồn tại.";
                return false;
            }
            if (DiemThanhPhan)
            {
                drSinhVien = dtSinhVien.Rows[0];
                DataTable dtKiemTraDiem = (new cBwsKQHT_DiemThanhPhan()).KiemTraDiem(int.Parse(drSinhVien["IDSV_SinhVien"].ToString()),
                    int.Parse(drSinhVien["IDDM_Lop"].ToString()), IDDM_MonHoc, IDDM_NamHoc, HocKy);
                if (dtKiemTraDiem.Rows.Count <= 0)
                {

                }
                else
                {

                }
            }
            else
            {

            }
            return true;
        }
    }
}
