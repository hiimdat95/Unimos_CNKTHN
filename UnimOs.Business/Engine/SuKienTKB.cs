using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Collections;
using TruongViet.UnimOs.Entity;
using System.Data;

namespace TruongViet.UnimOs.Business
{
    public class SuKienTKB : cBBase
    {
        private ArrayList arrSuKienTKB;
        public SuKienTKB()
        {
            arrSuKienTKB = new ArrayList();
        }

        public void Add(XL_SuKienTKBInfo sk)
        {
            arrSuKienTKB.Add(sk);
        }

        public void Remove(int idx)
        {
            arrSuKienTKB.RemoveAt(idx);
        }

        public int Count
        {
            get { return arrSuKienTKB.Count; }
        }

        public DataTable ToTable(bool DaXep, bool ChuaXep)
        {
            DataTable dt = CreateTable();
            for (int i = 0; i < arrSuKienTKB.Count; i++)
            {
                XL_SuKienTKBInfo sk = (XL_SuKienTKBInfo)arrSuKienTKB[i];
                if (DaXep == true && ChuaXep == true)
                {
                    DataRow dr = dt.NewRow();
                    ToDataRow(dr, sk, i);
                    dt.Rows.Add(dr);
                }
                else if (DaXep == true && ChuaXep == false)
                {
                    if (sk.DaXepLich == true)
                    {
                        DataRow dr = dt.NewRow();
                        ToDataRow(dr, sk, i);
                        dt.Rows.Add(dr);
                    }
                }
                else if (DaXep == false && ChuaXep == true)
                {
                    if (sk.DaXepLich == false)
                    {
                        DataRow dr = dt.NewRow();
                        ToDataRow(dr, sk, i);
                        dt.Rows.Add(dr);
                    }
                }
            }
            return dt;
        }

        private void ToDataRow(DataRow dr, XL_SuKienTKBInfo sk, int i)
        {
            dr["STT"] = i + 1;
            dr["Chon"] = false;
            dr["Idx"] = sk.Idx;
            dr["XL_SuKienTKBID"] = sk.XL_SuKienTKBID;
            dr["IDDM_Lop"] = sk.IDDM_Lop;
            dr["TenLop"] = sk.TenLop;
            dr["IDXL_MonHocTrongKy"] = sk.IDXL_MonHocTrongKy;
            dr["IDDM_MonHoc"] = sk.IDDM_MonHoc;
            dr["TenMonHoc"] = sk.TenMon;
            dr["KyHieu"] = sk.KyHieu;
            dr["IDDM_PhongHoc"] = sk.IDDM_PhongHoc;
            dr["TenPhongHoc"] = sk.TenPhong;
            dr["IDNS_GiaoVien"] = sk.IDNS_GiaoVien;
            dr["TenGiaoVien"] = sk.TenGiaoVien;
            dr["TenVietTat"] = sk.TenVietTat;
            dr["CaHoc"] = GetCa((int)sk.CaHoc);
            dr["Thu"] = GetThu(sk.Thu);
            dr["TietDau"] = sk.TietDau == -1 ? "" : (sk.TietDau + 1).ToString();
            dr["SoTiet"] = sk.SoTiet;
            dr["LoaiTiet"] = (sk.LoaiTiet == LOAI_TIET.LY_THUYET ? "Lý thuyết" : (sk.LoaiTiet == LOAI_TIET.THUC_HANH ? "Thực hành" : "Khác"));
            dr["ThieuDuLieu"] = sk.ThieuDuLieu;
            dr["Changed"] = sk.Changed;
            dr["DaXepLich"] = sk.DaXepLich;
            dr["Locked"] = sk.Locked;
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Chon", typeof(bool));
            dt.Columns.Add("Idx", typeof(int));
            dt.Columns.Add("XL_SuKienTKBID", typeof(long));
            dt.Columns.Add("IDDM_Lop", typeof(int));
            dt.Columns.Add("TenLop", typeof(string));
            dt.Columns.Add("IDXL_MonHocTrongKy", typeof(long));
            dt.Columns.Add("IDDM_MonHoc", typeof(int));
            dt.Columns.Add("TenMonHoc", typeof(string));
            dt.Columns.Add("KyHieu", typeof(string));
            dt.Columns.Add("IDDM_PhongHoc", typeof(int));
            dt.Columns.Add("TenPhongHoc", typeof(string));
            dt.Columns.Add("IDNS_GiaoVien", typeof(int));
            dt.Columns.Add("TenGiaoVien", typeof(string));
            dt.Columns.Add("TenVietTat", typeof(string));
            dt.Columns.Add("CaHoc", typeof(string));
            dt.Columns.Add("Thu", typeof(string));
            dt.Columns.Add("TietDau", typeof(string));
            dt.Columns.Add("SoTiet", typeof(int));
            dt.Columns.Add("LoaiTiet", typeof(string));
            dt.Columns.Add("ThieuDuLieu", typeof(bool));
            dt.Columns.Add("Changed", typeof(bool));
            dt.Columns.Add("DaXepLich", typeof(bool));
            dt.Columns.Add("Locked", typeof(bool));
            return dt;
        }

        public XL_SuKienTKBInfo this[int idx]
        {
            set { arrSuKienTKB[idx] = value; }
            get { return (XL_SuKienTKBInfo)arrSuKienTKB[idx]; }
        }

        public XL_SuKienTKBInfo FindSuKienByIdxSuKien(int idx)
        {
            if (idx < arrSuKienTKB.Count)
            {
                XL_SuKienTKBInfo sk = (XL_SuKienTKBInfo)arrSuKienTKB[idx];
                if (idx == sk.Idx)
                    return sk;
            }
            if (idx <= arrSuKienTKB.Count / 2)
            {
                for (int i = 0; i < arrSuKienTKB.Count; i++)
                {
                    XL_SuKienTKBInfo sk1 = (XL_SuKienTKBInfo)arrSuKienTKB[i];
                    if (idx == sk1.Idx)
                        return sk1;
                }
            }
            else
            {
                for (int i = arrSuKienTKB.Count - 1; i >= 0; i--)
                {
                    XL_SuKienTKBInfo sk1 = (XL_SuKienTKBInfo)arrSuKienTKB[i];
                    if (idx == sk1.Idx)
                        return sk1;
                }
            }
            return null;
        }

        public XL_SuKienTKBInfo FindSuKienByIDPhongHoc(int IDPhongHoc, int Thu, int Tiet)
        {
            for (int i = 0; i < arrSuKienTKB.Count; i++)
            {
                XL_SuKienTKBInfo sk = (XL_SuKienTKBInfo)arrSuKienTKB[i];
                if (sk.IDDM_PhongHoc == IDPhongHoc && sk.Thu == Thu && sk.TietDau == Tiet)
                    return sk;
            }
            return null;
        }

        public XL_SuKienTKBInfo FindSuKienByIDKhoiLop(int IDDM_Lop, int Thu, int Tiet)
        {
            for (int i = 0; i < arrSuKienTKB.Count; i++)
            {
                XL_SuKienTKBInfo sk = (XL_SuKienTKBInfo)arrSuKienTKB[i];
                if (sk.IDDM_Lop == IDDM_Lop && sk.Thu == Thu && sk.TietDau == Tiet)
                    return sk;
            }
            return null;
        }

        public XL_SuKienTKBInfo FindSuKienByIDGiaoVien(int IDGiaoVien, int Thu, int Tiet)
        {
            for (int i = 0; i < arrSuKienTKB.Count; i++)
            {
                XL_SuKienTKBInfo sk = (XL_SuKienTKBInfo)arrSuKienTKB[i];
                if (sk.IDNS_GiaoVien == IDGiaoVien && sk.Thu == Thu && sk.TietDau == Tiet)
                    return sk;
            }
            return null;
        }
    }

    // Khai báo đối tượng về các sự kiện khác như là ngoại khóa lớp, báo bận giáo viên, phòng học.

    // 
    public class SuKienKhacTKB
    {
        private ArrayList mSuKienKhac;

        public SuKienKhacTKB()
        {
            mSuKienKhac = new ArrayList();
        }

        public void Add(object sk)
        {
            mSuKienKhac.Add(sk);
        }
        
        public int Count
        {
            get { return mSuKienKhac.Count; }
        }

        public object this[int idx, bool mObject]
        {
            set { mSuKienKhac[idx] = value; }
            get { return (object)mSuKienKhac[idx]; }
        }

        public XL_SuKienKhacLopInfo this[int idx]
        {
            set { mSuKienKhac[idx] = value; }
            get { return (XL_SuKienKhacLopInfo)mSuKienKhac[idx]; }
        }
    }
}
