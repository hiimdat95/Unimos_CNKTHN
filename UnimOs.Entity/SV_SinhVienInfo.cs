using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public class SV_SinhVienInfo
    {

        private int mSV_SinhVienID;
        private string mMaSinhVien;
        private string mHoVaTen;
        private string mTen;
        private DateTime mNgaySinh;
        private string mSoBaoDanh;
        private string mSoCMND;
        private DateTime mNgayCapCMND;
        private int mIDTinhNoiCapCMND;
        private byte[] mAnh;
        private bool mGioiTinh;
        private int mThanhPhanXuatThan;
        private int mIDDM_DanToc;
        private int mIDDM_TonGiao;
        private int mIDDM_QuocTich;
        private string mNoiSinh;
        private int mIDDM_TinhHuyenXaNoiSinh;
        private string mQueQuan;
        private int mIDDM_TinhHuyenXaQueQuan;
        private string mThuongTru;
        private int mIDDM_TinhHuyenXaThuongTru;
        private DateTime mNgayVaoDoan;
        private DateTime mNgayVaoDang;
        private string mDienThoaiNhaRieng;
        private string mDienThoaiDiDong;
        private string mBaoTinCho;
        private string mDiaChiBaoTin;
        private string mEmail;
        private string mTenDangNhap;
        private string mMatKhau;
        private int mActive;
        private bool mXoa;

        public string strSV_SinhVienID = "SV_SinhVienID";
        public string strMaSinhVien = "MaSinhVien";
        public string strHoVaTen = "HoVaTen";
        public string strTen = "Ten";
        public string strNgaySinh = "NgaySinh";
        public string strSoBaoDanh = "SoBaoDanh";
        public string strSoCMND = "SoCMND";
        public string strNgayCapCMND = "NgayCapCMND";
        public string strIDTinhNoiCapCMND = "IDTinhNoiCapCMND";
        public string strAnh = "Anh";
        public string strGioiTinh = "GioiTinh";
        public string strThanhPhanXuatThan = "ThanhPhanXuatThan";
        public string strIDDM_DanToc = "IDDM_DanToc";
        public string strIDDM_TonGiao = "IDDM_TonGiao";
        public string strIDDM_QuocTich = "IDDM_QuocTich";
        public string strNoiSinh = "NoiSinh";
        public string strIDDM_TinhHuyenXaNoiSinh = "IDDM_TinhHuyenXaNoiSinh";
        public string strQueQuan = "QueQuan";
        public string strIDDM_TinhHuyenXaQueQuan = "IDDM_TinhHuyenXaQueQuan";
        public string strThuongTru = "ThuongTru";
        public string strIDDM_TinhHuyenXaThuongTru = "IDDM_TinhHuyenXaThuongTru";
        public string strNgayVaoDoan = "NgayVaoDoan";
        public string strNgayVaoDang = "NgayVaoDang";
        public string strDienThoaiNhaRieng = "DienThoaiNhaRieng";
        public string strDienThoaiDiDong = "DienThoaiDiDong";
        public string strBaoTinCho = "BaoTinCho";
        public string strDiaChiBaoTin = "DiaChiBaoTin";
        public string strEmail = "Email";
        public string strTenDangNhap = "TenDangNhap";
        public string strMatKhau = "MatKhau";
        public string strActive = "Active";
        public string strXoa = "Xoa";

        public SV_SinhVienInfo()
        { }

        public int SV_SinhVienID{
        	set{ mSV_SinhVienID = value;}
        	get{ return mSV_SinhVienID;}
        }
        public string MaSinhVien{
        	set{ mMaSinhVien = value;}
        	get{ return mMaSinhVien;}
        }
        public string HoVaTen{
        	set{ mHoVaTen = value;}
        	get{ return mHoVaTen;}
        }
        public string Ten{
        	set{ mTen = value;}
        	get{ return mTen;}
        }
        public DateTime NgaySinh{
        	set{ mNgaySinh = value;}
        	get{ return mNgaySinh;}
        }
        public string SoBaoDanh{
        	set{ mSoBaoDanh = value;}
        	get{ return mSoBaoDanh;}
        }
        public string SoCMND{
        	set{ mSoCMND = value;}
        	get{ return mSoCMND;}
        }
        public DateTime NgayCapCMND{
        	set{ mNgayCapCMND = value;}
        	get{ return mNgayCapCMND;}
        }
        public int IDTinhNoiCapCMND{
        	set{ mIDTinhNoiCapCMND = value;}
        	get{ return mIDTinhNoiCapCMND;}
        }
        public byte[] Anh{
        	set{ mAnh = value;}
        	get{ return mAnh;}
        }
        public bool GioiTinh{
        	set{ mGioiTinh = value;}
        	get{ return mGioiTinh;}
        }
        public int ThanhPhanXuatThan{
        	set{ mThanhPhanXuatThan = value;}
        	get{ return mThanhPhanXuatThan;}
        }
        public int IDDM_DanToc{
        	set{ mIDDM_DanToc = value;}
        	get{ return mIDDM_DanToc;}
        }
        public int IDDM_TonGiao{
        	set{ mIDDM_TonGiao = value;}
        	get{ return mIDDM_TonGiao;}
        }
        public int IDDM_QuocTich{
        	set{ mIDDM_QuocTich = value;}
        	get{ return mIDDM_QuocTich;}
        }
        public string NoiSinh{
        	set{ mNoiSinh = value;}
        	get{ return mNoiSinh;}
        }
        public int IDDM_TinhHuyenXaNoiSinh{
        	set{ mIDDM_TinhHuyenXaNoiSinh = value;}
        	get{ return mIDDM_TinhHuyenXaNoiSinh;}
        }
        public string QueQuan{
        	set{ mQueQuan = value;}
        	get{ return mQueQuan;}
        }
        public int IDDM_TinhHuyenXaQueQuan{
        	set{ mIDDM_TinhHuyenXaQueQuan = value;}
        	get{ return mIDDM_TinhHuyenXaQueQuan;}
        }
        public string ThuongTru{
        	set{ mThuongTru = value;}
        	get{ return mThuongTru;}
        }
        public int IDDM_TinhHuyenXaThuongTru{
        	set{ mIDDM_TinhHuyenXaThuongTru = value;}
        	get{ return mIDDM_TinhHuyenXaThuongTru;}
        }
        public DateTime NgayVaoDoan{
        	set{ mNgayVaoDoan = value;}
        	get{ return mNgayVaoDoan;}
        }
        public DateTime NgayVaoDang{
        	set{ mNgayVaoDang = value;}
        	get{ return mNgayVaoDang;}
        }
        public string DienThoaiNhaRieng{
        	set{ mDienThoaiNhaRieng = value;}
        	get{ return mDienThoaiNhaRieng;}
        }
        public string DienThoaiDiDong{
        	set{ mDienThoaiDiDong = value;}
        	get{ return mDienThoaiDiDong;}
        }
        public string BaoTinCho{
        	set{ mBaoTinCho = value;}
        	get{ return mBaoTinCho;}
        }
        public string DiaChiBaoTin{
        	set{ mDiaChiBaoTin = value;}
        	get{ return mDiaChiBaoTin;}
        }
        public string Email{
        	set{ mEmail = value;}
        	get{ return mEmail;}
        }
        public string TenDangNhap
        {
            set { mTenDangNhap = value; }
            get { return mTenDangNhap; }
        }
        public string MatKhau
        {
            set { mMatKhau = value; }
            get { return mMatKhau; }
        }
        public int Active{
        	set{ mActive = value;}
        	get{ return mActive;}
        }
        public bool Xoa{
        	set{ mXoa = value;}
        	get{ return mXoa;}
        }
    }
}
