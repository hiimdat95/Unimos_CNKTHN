using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class NS_GiaoVien_ThongTinInfo
    {

        private int mNS_GiaoVien_ThongTinID;
        private int mIDNS_GiaoVien;
        private string mNgheNghiepTuyenDung;
        private DateTime mNgayTuyenDung;
        private bool mIsGiaoVienChinhTri;
        private int mIDDM_ChucDanh;
        private int mIDDM_HocHam;
        private int mIDDM_HocVi;
        private string mTrinhDoPhoThong;
        private string mIDTrinhDoTinHoc;
        private string mTrinhDoTinHoc;
        private int mIDDM_TrinhDoChuyenMon;
        private int mIDDM_TrinhDoLyLuan;
        private int mIDDM_QuanLyHanhChinhNhaNuoc;
        private DateTime mNgayVaoDang;
        private DateTime mNgayVaoDangChinhThuc;
        private int mIDDM_DanhHieuDuocPhongTang;
        private string mSoTruongCongTac;
        private string mTinhTrangSucKhoe;
        private double mChieuCao;
        private double mCanNang;
        private string mNhomMau;
        private string mSoSoBaoHiemXaHoi;

        public string strNS_GiaoVien_ThongTinID = "NS_GiaoVien_ThongTinID";
        public string strIDNS_GiaoVien = "IDNS_GiaoVien";
        public string strNgheNghiepTuyenDung = "NgheNghiepTuyenDung";
        public string strNgayTuyenDung = "NgayTuyenDung";
        public string strIsGiaoVienChinhTri = "IsGiaoVienChinhTri";
        public string strIDDM_ChucDanh = "IDDM_ChucDanh";
        public string strIDDM_HocHam = "IDDM_HocHam";
        public string strIDDM_HocVi = "IDDM_HocVi";
        public string strTrinhDoPhoThong = "TrinhDoPhoThong";
        public string strTrinhDoTinHoc = "TrinhDoTinHoc";
        public string strIDTrinhDoTinHoc = "IDTrinhDoTinHoc";
        public string strIDDM_TrinhDoChuyenMon = "IDDM_TrinhDoChuyenMon";
        public string strIDDM_TrinhDoLyLuan = "IDDM_TrinhDoLyLuan";
        public string strIDDM_QuanLyHanhChinhNhaNuoc = "IDDM_QuanLyHanhChinhNhaNuoc";
        public string strNgayVaoDang = "NgayVaoDang";
        public string strNgayVaoDangChinhThuc = "NgayVaoDangChinhThuc";
        public string strIDDM_DanhHieuDuocPhongTang = "IDDM_DanhHieuDuocPhongTang";
        public string strSoTruongCongTac = "SoTruongCongTac";
        public string strTinhTrangSucKhoe = "TinhTrangSucKhoe";
        public string strChieuCao = "ChieuCao";
        public string strCanNang = "CanNang";
        public string strNhomMau = "NhomMau";
        public string strSoSoBaoHiemXaHoi = "SoSoBaoHiemXaHoi";

        public NS_GiaoVien_ThongTinInfo()
        { }

        public int NS_GiaoVien_ThongTinID{
        	set{ mNS_GiaoVien_ThongTinID = value;}
        	get{ return mNS_GiaoVien_ThongTinID;}
        }
        public int IDNS_GiaoVien{
        	set{ mIDNS_GiaoVien = value;}
        	get{ return mIDNS_GiaoVien;}
        }
        public string NgheNghiepTuyenDung{
        	set{ mNgheNghiepTuyenDung = value;}
        	get{ return mNgheNghiepTuyenDung;}
        }
        public DateTime NgayTuyenDung{
        	set{ mNgayTuyenDung = value;}
        	get{ return mNgayTuyenDung;}
        }
        public bool IsGiaoVienChinhTri
        {
            set { mIsGiaoVienChinhTri = value; }
            get { return mIsGiaoVienChinhTri; }
        }
        public int IDDM_ChucDanh{
        	set{ mIDDM_ChucDanh = value;}
        	get{ return mIDDM_ChucDanh;}
        }
        public int IDDM_HocHam{
        	set{ mIDDM_HocHam = value;}
        	get{ return mIDDM_HocHam;}
        }
        public int IDDM_HocVi{
            set { mIDDM_HocVi = value; }
            get { return mIDDM_HocVi; }
        }
        public string TrinhDoPhoThong{
        	set{ mTrinhDoPhoThong = value;}
        	get{ return mTrinhDoPhoThong;}
        }
        public string IDTrinhDoTinHoc
        {
            set { mIDTrinhDoTinHoc = value; }
            get { return mIDTrinhDoTinHoc; }
        }
        public string TrinhDoTinHoc{
        	set{ mTrinhDoTinHoc = value;}
        	get{ return mTrinhDoTinHoc;}
        }
        public int IDDM_TrinhDoChuyenMon{
        	set{ mIDDM_TrinhDoChuyenMon = value;}
        	get{ return mIDDM_TrinhDoChuyenMon;}
        }
        public int IDDM_TrinhDoLyLuan{
        	set{ mIDDM_TrinhDoLyLuan = value;}
        	get{ return mIDDM_TrinhDoLyLuan;}
        }
        public int IDDM_QuanLyHanhChinhNhaNuoc{
        	set{ mIDDM_QuanLyHanhChinhNhaNuoc = value;}
        	get{ return mIDDM_QuanLyHanhChinhNhaNuoc;}
        }
        public DateTime NgayVaoDang{
        	set{ mNgayVaoDang = value;}
        	get{ return mNgayVaoDang;}
        }
        public DateTime NgayVaoDangChinhThuc{
        	set{ mNgayVaoDangChinhThuc = value;}
        	get{ return mNgayVaoDangChinhThuc;}
        }
        public int IDDM_DanhHieuDuocPhongTang{
        	set{ mIDDM_DanhHieuDuocPhongTang = value;}
        	get{ return mIDDM_DanhHieuDuocPhongTang;}
        }
        public string SoTruongCongTac{
        	set{ mSoTruongCongTac = value;}
        	get{ return mSoTruongCongTac;}
        }
        public string TinhTrangSucKhoe{
        	set{ mTinhTrangSucKhoe = value;}
        	get{ return mTinhTrangSucKhoe;}
        }
        public double ChieuCao{
        	set{ mChieuCao = value;}
        	get{ return mChieuCao;}
        }
        public double CanNang{
        	set{ mCanNang = value;}
        	get{ return mCanNang;}
        }
        public string NhomMau{
        	set{ mNhomMau = value;}
        	get{ return mNhomMau;}
        }
        public string SoSoBaoHiemXaHoi{
        	set{ mSoSoBaoHiemXaHoi = value;}
        	get{ return mSoSoBaoHiemXaHoi;}
        }
    }
}
