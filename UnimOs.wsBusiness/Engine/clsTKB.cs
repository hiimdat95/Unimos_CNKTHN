using System;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;
using System.Data;
using System.Collections;
using Lib;
using System.Drawing;

namespace TruongViet.UnimOs.wsBusiness
{
    public class clsTKB : cBwsBase
    {
        #region Variable
        private long intIDTuan;
        //private bool mTKBChanged;
        public bool mUpdate = false;
        private DataTable dtThamSo;

        private cBwsDM_Lop lps;
        private cBwsNS_GiaoVien gvs;
        private cBwsDM_PhongHoc phs;
        public SuKienTKB sks;
        private HT_ThamSoXepLichInfo objThamSoTKB;

        private SuKienKhacTKB sk_lp;
        private SuKienKhacTKB sk_gv;

        //private cBwsXL_SuKienTKB oBSuKienTKB;
        private XL_SuKienTKBInfo pSuKienTKBInfo;
        //private cBwsXL_KeHoachChiTiet oBKeHoachChiTiet;
        public SchoolEngine scE;
        private Hashtable htbPhong, htbPhanCongPhong;

        private int[] arrTietNhom, arrPhong;
        private int SoTietNhomMax = 0;
        #endregion

        #region Khởi tạo
        //public clsTKB(int IDNamHoc, int HocKy, long _IDTuan, HT_ThamSoXepLichInfo pThamSoTKB)
        //{
        //    intIDTuan = _IDTuan;
        //    // Lấy ra danh sách phòng học, lớp học, giao viên phục vụ cho việc xếp TKB
        //    lps = new cBwsDM_Lop(_IDTuan, pThamSoTKB);
        //    phs = new cBwsDM_PhongHoc(pThamSoTKB);
        //    gvs = new cBwsNS_GiaoVien(pThamSoTKB);
        //    objThamSoTKB = pThamSoTKB;
        //    oBSuKienTKB = new cBwsXL_SuKienTKB();
        //    pSuKienTKBInfo = new XL_SuKienTKBInfo();

        //    cBwsDM_MonHoc oBDM_MonHoc = new cBwsDM_MonHoc();
        //    htbPhong = oBDM_MonHoc.GetPhongHoc_MonHoc(2);
        //    htbPhanCongPhong = new Hashtable();

        //    string[] strTietNhom;
        //    // Lấy ra mảng tiết của các nhóm tiết
        //    strTietNhom = objThamSoTKB.SO_TIET_CAC_NHOM.Split(',');
        //    arrTietNhom = new int[strTietNhom.Length];
        //    for (int i = 0; i < strTietNhom.Length; i++)
        //    {
        //        arrTietNhom[i] = int.Parse(strTietNhom[i]);
        //        if (arrTietNhom[i] > SoTietNhomMax)
        //            SoTietNhomMax = arrTietNhom[i];
        //    }

        //    // Kiểm tra xem tuần đó đã chia sự kiện chưa 
        //    // Nếu rồi thì lấy trực tiếp trong bảng sự kiện
        //    // Nếu chưa thì sẽ đọc sự kiện trong kế hoạch và chia sự kiện cho phù hợp
        //    if (oBSuKienTKB.CheckExist(_IDTuan) == true)
        //    {
        //        mUpdate = true;
        //        DocSuKien(_IDTuan);
        //    }
        //    else
        //    {
        //        mUpdate = false;
        //        DocKeHoachChiTiet(_IDTuan);
        //    }
        //    DataTable dtThucHanh = new cBwsXL_KeHoachThucHanhChiTiet().GetByIDXL_Tuan(_IDTuan);
        //    DocKeHoachLop(dtThucHanh);
        //    if (objThamSoTKB.SUDUNG_BAOBAN_TRONG_XEPLICH == 1)
        //        DocKeHoachGiaoVien(dtThucHanh);
        //    scE = new SchoolEngine(IDNamHoc, intIDTuan, phs, gvs, lps, sks, sk_lp, sk_gv, objThamSoTKB, arrTietNhom);
        //}
        #endregion

        #region Đọc kế hoạch lớp, lịch ngoại khóa lớp
        //private void DocKeHoachLop(DataTable dtThucHanh)
        //{
        //    string[] arrStr;
        //    sk_lp = new SuKienKhacTKB();
        //    // Đọc các kế hoạch lớp trong kế hoạch toàn trường
        //    cBwsXL_KeHoachTruong oBKeHoachTruong = new cBwsXL_KeHoachTruong();
        //    DataTable dtKeHoachTruong = oBKeHoachTruong.GetByIDTuan(intIDTuan);
        //    int idxLop;
        //    if (dtKeHoachTruong.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dtKeHoachTruong.Rows)
        //        {
        //            idxLop = lps.SearchIndexLop(int.Parse(dr["IDDM_Lop"].ToString()));
        //            if (idxLop > -1)
        //            {
        //                if (("" + dr["NgayNghi"]) == "CaTuan")
        //                {
        //                    for (int Thu = objThamSoTKB.THU_BAT_DAU; Thu <= objThamSoTKB.THU_KET_THUC; Thu++)
        //                    {
        //                        for (int i = 0; i < objThamSoTKB.SO_TIET_NGAY; i++)
        //                        {
        //                            XL_SuKienKhacLopInfo skk = new XL_SuKienKhacLopInfo();
        //                            skk.ID = 0;
        //                            skk.IDLop = int.Parse(dr["IDDM_Lop"].ToString());
        //                            skk.MoTa = dr["TenVietTat"].ToString();
        //                            skk.SoTiet = 1;
        //                            skk.TenLop = dr["TenLop"].ToString();
        //                            skk.Thu = Thu;
        //                            skk.Tiet = i;
        //                            // Thêm kế hoạch lớp
        //                            sk_lp.Add(skk);
        //                            lps[idxLop].TKB[skk.Thu, skk.Tiet] = sk_lp.Count - 1;
        //                            lps[idxLop].TKB[skk.Thu, skk.Tiet, true] = eLOAI_SK.LK_LOP;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    arrStr = ("" + dr["NgayNghi"]).Split(',');
        //                    if (arrStr.Length > 0)
        //                    {
        //                        foreach (string Thu in arrStr)
        //                        {
        //                            for (int i = 0; i < objThamSoTKB.SO_TIET_NGAY; i++)
        //                            {
        //                                XL_SuKienKhacLopInfo skk = new XL_SuKienKhacLopInfo();
        //                                skk.ID = 0;
        //                                skk.IDLop = int.Parse(dr["IDDM_Lop"].ToString());
        //                                skk.MoTa = dr["TenVietTat"].ToString();
        //                                skk.SoTiet = 1;
        //                                skk.TenLop = dr["TenLop"].ToString();
        //                                skk.Thu = int.Parse(Thu);
        //                                skk.Tiet = i;
        //                                // Thêm kế hoạch lớp
        //                                sk_lp.Add(skk);
        //                                lps[idxLop].TKB[skk.Thu, skk.Tiet] = sk_lp.Count - 1;
        //                                lps[idxLop].TKB[skk.Thu, skk.Tiet, true] = eLOAI_SK.LK_LOP;
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    if (dtThucHanh.Rows.Count > 0)
        //    {
        //        int Thu, TuTiet, DenTiet;
        //        foreach (DataRow dr in dtThucHanh.Rows)
        //        {
        //            idxLop = lps.SearchIndexLop(int.Parse(dr["IDDM_Lop"].ToString()));
        //            if (idxLop > -1)
        //            {
        //                Thu = (int)DateTime.Parse(dr["NgayThucHanh"].ToString()).DayOfWeek;
        //                if (dr["CaHoc"].ToString() == "0")
        //                {
        //                    TuTiet = 0;
        //                    DenTiet = objThamSoTKB.SO_TIET_CASANG - 1;
        //                }
        //                else if (dr["CaHoc"].ToString() == "1")
        //                {
        //                    TuTiet = objThamSoTKB.SO_TIET_CASANG;
        //                    DenTiet = objThamSoTKB.SO_TIET_CASANG + objThamSoTKB.SO_TIET_CACHIEU - 1;
        //                }
        //                else
        //                {
        //                    TuTiet = objThamSoTKB.SO_TIET_CASANG + objThamSoTKB.SO_TIET_CACHIEU;
        //                    DenTiet = objThamSoTKB.SO_TIET_NGAY - 1;
        //                }
        //                for (int i = TuTiet; i <= DenTiet; i++)
        //                {
        //                    XL_SuKienKhacLopInfo skk = new XL_SuKienKhacLopInfo();
        //                    skk.ID = 0;
        //                    skk.IDLop = int.Parse(dr["IDDM_Lop"].ToString());
        //                    skk.MoTa = GetTenThucHanhLop(dr);
        //                    skk.SoTiet = 1;
        //                    skk.TenLop = lps[idxLop].TenLop;
        //                    skk.Thu = Thu;
        //                    skk.Tiet = i;
        //                    // Thêm kế hoạch lớp
        //                    sk_lp.Add(skk);
        //                    lps[idxLop].TKB[skk.Thu, skk.Tiet] = sk_lp.Count - 1;
        //                    lps[idxLop].TKB[skk.Thu, skk.Tiet, true] = eLOAI_SK.LK_LOP;
        //                }
        //            }
        //        }
        //    }
        //}

        private string GetTenThucHanhLop(DataRow dr)
        {
            string Result = "TH: " + dr["KyHieu"] + " (" + dr["MaMonHoc"] + ")";
            if ("" + dr["ToThucHanh"] != "0")
                Result += "\nTổ " + dr["ToThucHanh"];
            if (int.Parse("0" + dr["IDDM_PhongHoc"]) > 0)
            {
                string TenPhong = phs.SearchTenPhong(int.Parse(dr["IDDM_PhongHoc"].ToString()));
                if (TenPhong != "")
                    Result += " - Phòng: " + TenPhong;
            }
            if (int.Parse("0" + dr["IDNS_GiaoVien"]) > 0)
            {
                string TenGiaoVien = gvs.SearchTenGV(int.Parse(dr["IDNS_GiaoVien"].ToString()));
                if (TenGiaoVien != "")
                    Result += "\nGiáo viên: " + TenGiaoVien;
            }
            return Result;
        }
        #endregion

        #region Đọc kế hoạch giáo viên, báo bận giáo viên
        //private void DocKeHoachGiaoVien(DataTable dtThucHanh)
        //{
        //    sk_gv = new SuKienKhacTKB();
        //    // Đọc kế hoạch báo bận giáo viên
        //    cBwsXL_BaoBanGiaoVien oBBaoBanGV = new cBwsXL_BaoBanGiaoVien();
        //    DataTable dtBaoBan = oBBaoBanGV.GetByIDTuan(intIDTuan);
        //    int idxGV;

        //    foreach (DataRow dr in dtBaoBan.Rows)
        //    {
        //        XL_BaoBanGiaoVienInfo skk = new XL_BaoBanGiaoVienInfo();
        //        skk.XL_BaoBanGiaoVienID = 0;
        //        skk.IDTuan = long.Parse(dr["IDTuan"].ToString());
        //        skk.IDNS_GiaoVien = int.Parse(dr["IDNS_GiaoVien"].ToString());
        //        skk.Thu = int.Parse(dr["Thu"].ToString());
        //        skk.Tiet = int.Parse(dr["Tiet"].ToString());
        //        skk.CaHoc = int.Parse(dr["CaHoc"].ToString());
        //        skk.MoTa = dr["MoTa"].ToString();
        //        sk_gv.Add(skk);
        //        idxGV = gvs.SearchIndexGV(skk.IDNS_GiaoVien);
        //        gvs[idxGV].TKB[skk.Thu, skk.Tiet] = sk_gv.Count - 1;
        //        gvs[idxGV].TKB[skk.Thu, skk.Tiet, true] = eLOAI_SK.LK_GV;
        //    }

        //    if (dtThucHanh.Rows.Count > 0)
        //    {
        //        int Thu, TuTiet, DenTiet;
        //        foreach (DataRow dr in dtThucHanh.Rows)
        //        {
        //            if (int.Parse("0" + dr["IDNS_GiaoVien"]) > 0)
        //            {
        //                idxGV = gvs.SearchIndexGV(int.Parse(dr["IDNS_GiaoVien"].ToString()));
        //                if (idxGV > -1)
        //                {
        //                    Thu = (int)DateTime.Parse(dr["NgayThucHanh"].ToString()).DayOfWeek;
        //                    if (dr["CaHoc"].ToString() == "0")
        //                    {
        //                        TuTiet = 0;
        //                        DenTiet = objThamSoTKB.SO_TIET_CASANG - 1;
        //                    }
        //                    else if (dr["CaHoc"].ToString() == "1")
        //                    {
        //                        TuTiet = objThamSoTKB.SO_TIET_CASANG;
        //                        DenTiet = objThamSoTKB.SO_TIET_CASANG + objThamSoTKB.SO_TIET_CACHIEU - 1;
        //                    }
        //                    else
        //                    {
        //                        TuTiet = objThamSoTKB.SO_TIET_CASANG + objThamSoTKB.SO_TIET_CACHIEU;
        //                        DenTiet = objThamSoTKB.SO_TIET_NGAY - 1;
        //                    }
        //                    for (int i = TuTiet; i <= DenTiet; i++)
        //                    {
        //                        XL_BaoBanGiaoVienInfo skk = new XL_BaoBanGiaoVienInfo();
        //                        skk.XL_BaoBanGiaoVienID = 0;
        //                        skk.IDTuan = long.Parse(dr["IDXL_Tuan"].ToString());
        //                        skk.IDNS_GiaoVien = int.Parse(dr["IDNS_GiaoVien"].ToString());
        //                        skk.Thu = Thu;
        //                        skk.Tiet = i;
        //                        skk.CaHoc = int.Parse(dr["CaHoc"].ToString());
        //                        skk.MoTa = GetTenThucHanhGV(dr);
        //                        sk_gv.Add(skk);
        //                        gvs[idxGV].TKB[skk.Thu, skk.Tiet] = sk_gv.Count - 1;
        //                        gvs[idxGV].TKB[skk.Thu, skk.Tiet, true] = eLOAI_SK.LK_GV;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        //private string GetTenThucHanhGV(DataRow dr)
        //{
        //    string Result = "TH: " + dr["KyHieu"] + " (" + dr["MaMonHoc"] + ")";
        //    if ("" + dr["ToThucHanh"] != "0")
        //        Result += "\nTổ " + dr["ToThucHanh"];
        //    if (int.Parse("0" + dr["IDDM_PhongHoc"]) > 0)
        //    {
        //        string TenPhong = phs.SearchTenPhong(int.Parse(dr["IDDM_PhongHoc"].ToString()));
        //        if (TenPhong != "")
        //            Result += " - Phòng: " + TenPhong;
        //    }
        //    if (int.Parse("0" + dr["IDDM_Lop"]) > 0)
        //    {
        //        string TenLop = lps.SearchTenLop(int.Parse(dr["IDDM_Lop"].ToString()));
        //        if (TenLop != "")
        //            Result += "\nLớp: " + TenLop;
        //        else
        //            Result += "\n" + lps.GetTenLop(int.Parse(dr["IDDM_Lop"].ToString()));
        //    }
        //    return Result;
        //}
        #endregion

        #region Load Data
        //private void DocSuKien(long IDTuan)
        //{
        //    oBSuKienTKB = new cBwsXL_SuKienTKB();
        //    DataTable dt = oBSuKienTKB.Get_TKB(IDTuan);
        //    sks = new SuKienTKB();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        if (long.Parse(dr["XL_SuKienTKBID"].ToString()) > 0)
        //        {
        //            XL_SuKienTKBInfo sk = new XL_SuKienTKBInfo(true);
        //            sk.XL_SuKienTKBID = long.Parse(dr["XL_SuKienTKBID"].ToString());
        //            GanSuKien(sk, dr);
        //        }
        //        else
        //        {
        //            XL_SuKienTKBInfo sk = new XL_SuKienTKBInfo(true);
        //            GanSuKien(sk, dr);
        //            ChiaSuKien(sk);
        //        }
        //    }
        //    FillData();
        //}

        //private void DocKeHoachChiTiet(long IDXL_Tuan)
        //{
        //    oBKeHoachChiTiet = new cBwsXL_KeHoachChiTiet();
        //    DataTable dt = oBKeHoachChiTiet.Get_SuKienTKB(IDXL_Tuan);
        //    sks = new SuKienTKB();

        //    DataRow[] arrDr;
        //    string IDDM_Lop = "";
        //    int SoTiet, IDXL_MonHocTrongKy, count;
        //    List<CHIA_TIET> lst;
        //    XL_SuKienTKBInfo sk = new XL_SuKienTKBInfo(true), skClone;
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        IDXL_MonHocTrongKy = 0;
        //        count = 0;
        //        if (dt.Rows[i]["IDDM_Lop"].ToString() != IDDM_Lop)
        //        {
        //            IDDM_Lop = dt.Rows[i]["IDDM_Lop"].ToString();
        //            arrDr = dt.Select("IDDM_Lop = " + IDDM_Lop);
        //            SoTiet = int.Parse(dt.Compute("Sum(SoTiet)", "IDDM_Lop = " + IDDM_Lop).ToString());

        //            lst = lstChiaTiet32(arrDr, SoTiet);

        //            foreach (CHIA_TIET pChiaTiet in lst)
        //            {
        //                if (pChiaTiet.IDXL_MonHocTrongKy != IDXL_MonHocTrongKy)
        //                {
        //                    sk = new XL_SuKienTKBInfo(true);
        //                    GanSuKien(sk, arrDr[count]);
        //                    sk.SoTiet = pChiaTiet.SoTiet;

        //                    IDXL_MonHocTrongKy = pChiaTiet.IDXL_MonHocTrongKy;
        //                    count++;
        //                }
        //                else
        //                {
        //                    skClone = sk.Clone();
        //                    skClone.SoTiet = pChiaTiet.SoTiet;
        //                    skClone.Idx = sks.Count;
        //                    sks.Add(skClone);
        //                }
        //            }
        //            i += count - 1;
        //        }
        //        //XL_SuKienTKBInfo sk = new XL_SuKienTKBInfo(true);
        //        //GanSuKien(sk, dr);
        //        //ChiaSuKien(sk);
        //    }
        //}

        private List<CHIA_TIET> lstChiaTiet32(DataRow[] arrDr, int SoTiet)
        {
            List<CHIA_TIET> lst = new List<CHIA_TIET>();

            int Nhom3 = 0, Nhom2 = 0;
            // Thực hiện chia tiết
            int TietMon, IDXL_MonHocTrongKy;
            CHIA_TIET pChiaTiet;
            foreach (DataRow dr in arrDr)
            {
                IDXL_MonHocTrongKy = (int)dr["IDXL_MonHocTrongKy"];
                TietMon = (int)dr["SoTiet"];
                while (TietMon > 0)
                {
                    pChiaTiet = new CHIA_TIET();
                    pChiaTiet.IDXL_MonHocTrongKy = IDXL_MonHocTrongKy;
                    if (TietMon == 4)
                    {
                        pChiaTiet.SoTiet = 2;
                        lst.Add(pChiaTiet);
                        lst.Add(pChiaTiet);
                        TietMon -= 4;

                        Nhom2 += 2;
                    }
                    else
                    {
                        if (Nhom3 <= Nhom2 || TietMon == 3)
                        {
                            pChiaTiet.SoTiet = 3;
                            TietMon -= 3;
                            lst.Add(pChiaTiet);
                            Nhom3++;
                        }
                        else
                        {
                            pChiaTiet.SoTiet = 2;
                            TietMon -= 2;
                            lst.Add(pChiaTiet);
                            Nhom2++;
                        }
                    }
                }
            }

            return lst;
        }

        private void GanSuKien(XL_SuKienTKBInfo sk, DataRow dr)
        {
            sk.Idx = sks.Count;
            sk.IDXL_Tuan = intIDTuan;
            sk.IDDM_Lop = int.Parse(dr["IDDM_Lop"].ToString());
            sk.IdxLop = lps.SearchIndexLop(sk.IDDM_Lop);
            sk.TenLop = dr["TenLop"].ToString();
            sk.IDXL_MonHocTrongKy = int.Parse("0" + dr["IDXL_MonHocTrongKy"].ToString());
            sk.IDDM_MonHoc = int.Parse("0" + dr["IDDM_MonHoc"].ToString());
            sk.SuDungPhong = (SU_DUNG_PHONG)dr["SuDungPhong"];
            sk.TenMon = dr["TenMonHoc"].ToString();
            sk.KyHieu = dr["KyHieu"].ToString();

            sk.CaHoc = "" + dr["CaHoc"] == "" ? CA_HOC.KHONG_XAC_DINH : (CA_HOC)dr["CaHoc"];

            if (sk.SuDungPhong != SU_DUNG_PHONG.KHONG_SD)
            {
                if (sk.SuDungPhong == SU_DUNG_PHONG.DUOI_DAY && sk.IDDM_PhongHoc > 0)
                {
                    if (htbPhong.ContainsKey(sk.IDDM_MonHoc))
                    {
                        arrPhong = (int[])htbPhong[sk.IDDM_MonHoc];
                        for (int i = 0; i < arrPhong.Length; i++)
                        {
                            if (htbPhanCongPhong.ContainsKey(sk.IDDM_PhongHoc.ToString() + "_" + sk.CaHoc.ToString()))
                            {
                                if (int.Parse(htbPhanCongPhong[arrPhong[i].ToString() + "_" + sk.CaHoc.ToString()].ToString()) < objThamSoTKB.SO_NHOMTIET_CA)
                                {
                                    sk.IDDM_PhongHoc = arrPhong[i];
                                    sk.IdxPhong = phs.SearchIndexPhong(sk.IDDM_PhongHoc);
                                    sk.TenPhong = phs[sk.IdxPhong].TenPhongHoc;

                                    htbPhanCongPhong[arrPhong[i].ToString() + "_" + sk.CaHoc.ToString()] = int.Parse(htbPhanCongPhong[arrPhong[i].ToString() + "_" + sk.CaHoc.ToString()].ToString()) + 1;
                                    break;
                                }
                            }
                            else
                            {
                                sk.IDDM_PhongHoc = arrPhong[i];
                                sk.IdxPhong = phs.SearchIndexPhong(sk.IDDM_PhongHoc);
                                sk.TenPhong = phs[sk.IdxPhong].TenPhongHoc;

                                htbPhanCongPhong.Add(sk.IDDM_PhongHoc.ToString() + "_" + sk.CaHoc.ToString(), 1);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if ("" + dr["IDDM_PhongHoc"] != "")
                    {
                        sk.IDDM_PhongHoc = int.Parse(dr["IDDM_PhongHoc"].ToString());
                        sk.IdxPhong = phs.SearchIndexPhong(sk.IDDM_PhongHoc);
                        sk.TenPhong = dr["TenPhongHoc"].ToString();
                    }
                }
            }
            sk.IDNS_GiaoVien = int.Parse(dr["IDNS_GiaoVien"].ToString());
            sk.IdxGiaoVien = gvs.SearchIndexGV(sk.IDNS_GiaoVien);
            sk.TenGiaoVien = dr["HoTen"].ToString();
            sk.TenVietTat = dr["TenVietTat"].ToString();
            sk.Thu = int.Parse(dr["Thu"].ToString());
            sk.TietDau = int.Parse(dr["TietDau"].ToString());
            sk.SoTiet = int.Parse(dr["SoTiet"].ToString());
            sk.LoaiTiet = (LOAI_TIET)dr["LoaiTiet"];
            sk.DaXepLich = bool.Parse(dr["DaXepLich"].ToString());
            sk.Locked = false;
            sks.Add(sk);
        }

        private void ChiaSuKien(XL_SuKienTKBInfo sk)
        {
            while (sk.SoTiet > SoTietNhomMax)
            {
                XL_SuKienTKBInfo skNew = sk.Clone();
                if (SoTietNhomMax != 4)
                {
                    if (sk.SoTiet == 4)
                    {
                        sks[sks.Count - 1].SoTiet = 2;
                        skNew.Idx = sks.Count;
                        skNew.SoTiet -= 2;
                    }
                    else
                    {
                        sks[sks.Count - 1].SoTiet = SoTietNhomMax;
                        skNew.Idx = sks.Count;
                        skNew.SoTiet -= SoTietNhomMax;
                    }
                    sks.Add(skNew);
                    sk = skNew;
                }
                else
                {
                    if (sk.SoTiet > SoTietNhomMax)
                    {
                        sks[sks.Count - 1].SoTiet = SoTietNhomMax;
                        skNew.Idx = sks.Count;
                        skNew.SoTiet -= SoTietNhomMax;
                        sks.Add(skNew);
                        sk = skNew;
                    }
                }
            }
        }

        private void FillData()
        {
            try
            {
                int idxGV, idxLop, idxPhong;
                for (int i = 0; i < sks.Count; i++)
                {
                    if (sks[i].Thu != -1)
                    {
                        idxGV = sks[i].IdxGiaoVien;
                        idxPhong = sks[i].IdxPhong;
                        idxLop = sks[i].IdxLop;
                        // Gán giá trị cho tất cả các tiết của sự kiện
                        for (int j = sks[i].TietDau; j < sks[i].TietDau + sks[i].SoTiet; j++)
                        {
                            if (idxGV != -1)
                                gvs[idxGV].TKB[sks[i].Thu, j] = i;
                            if (idxPhong != -1)
                                phs[idxPhong].TKB[sks[i].Thu, j] = i;
                            if (idxLop != -1)
                                lps[idxLop].TKB[sks[i].Thu, j] = i;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DocThamSoXepLich()
        {
            // Đọc tham số hệ thống
            HT_ThamSoHeThongInfo pThamSoHeThongInfo = new HT_ThamSoHeThongInfo();
            pThamSoHeThongInfo.HT_ThamSoHeThongID = 0;
            dtThamSo = new cBwsHT_ThamSoHeThong().Get(pThamSoHeThongInfo);

        }
        #endregion

        #region ViewTKB

        public DataTable Baocao_TKB_Lop()
        {
            DataTable dt = new DataTable();
            int col = 0;
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("TenLop", typeof(string));
            dt.Columns.Add("IDDM_Lop", typeof(string));
            for (int i = objThamSoTKB.THU_BAT_DAU; i <= objThamSoTKB.THU_KET_THUC; i++)
            {
                for (int k = 0; k <= 2; k++)
                {
                    // Chay theo ca hoc 0- sang 1-chieu -2 toi
                    if (k == 0)
                    {
                        for (int j = 1; j <= objThamSoTKB.SO_TIET_CASANG; j++)
                        {
                            dt.Columns.Add(i.ToString() + "." + k.ToString() + "." + j.ToString(), typeof(string));
                        }
                    }
                    if (k == 1)
                    {
                        for (int j = 1; j <= objThamSoTKB.SO_TIET_CACHIEU; j++)
                        {
                            dt.Columns.Add(i.ToString() + "." + k.ToString() + "." + (objThamSoTKB.SO_TIET_CASANG + j).ToString(), typeof(string));
                        }
                    }
                    if (k == 2)
                    {
                        for (int j = 1; j <= objThamSoTKB.SO_TIET_CATOI; j++)
                        {
                            dt.Columns.Add(i.ToString() + "." + k.ToString() + "." + (objThamSoTKB.SO_TIET_CASANG + objThamSoTKB.SO_TIET_CACHIEU + j).ToString(), typeof(string));
                        }
                    }
                }
            }

            for (int i = 0; i <= lps.Count - 1; i++)
            {
                DataRow row = dt.NewRow();
                row["STT"] = i + 1;
                row["TenLop"] = lps[i].TenLop;
                row["IDDM_Lop"] = lps[i].IDDM_Lop;
                for (int thu = objThamSoTKB.THU_BAT_DAU; thu <= objThamSoTKB.THU_KET_THUC; thu++)
                {
                    for (int tiet = 0; tiet <= objThamSoTKB.SO_TIET_NGAY - 1; tiet++)
                    {
                        if (lps[i].TKB[thu, tiet] != -1)
                        {
                            col = CalCol(thu, tiet, 3);
                            row[col] = ThongTinLop(i, thu, tiet);
                        }
                    }
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        public DataTable Baocao_TKB_phong()
        {
            DataTable dt = new DataTable();
            int col = 0;
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("TenPhongHoc", typeof(string));
            dt.Columns.Add("IDDM_PhongHoc", typeof(int));
            for (int i = objThamSoTKB.THU_BAT_DAU; i <= objThamSoTKB.THU_KET_THUC; i++)
            {
                for (int k = 0; k <= 2; k++)
                {
                    // Chay theo ca hoc 0- sang 1-chieu -2 toi
                    if (k == 0)
                    {
                        for (int j = 1; j <= objThamSoTKB.SO_TIET_CASANG; j++)
                        {
                            dt.Columns.Add(i.ToString() + "." + k.ToString() + "." + j.ToString(), typeof(string));
                        }
                    }
                    if (k == 1)
                    {
                        for (int j = 1; j <= objThamSoTKB.SO_TIET_CACHIEU; j++)
                        {
                            dt.Columns.Add(i.ToString() + "." + k.ToString() + "." + (objThamSoTKB.SO_TIET_CASANG + j).ToString(), typeof(string));
                        }
                    }
                    if (k == 2)
                    {
                        for (int j = 1; j <= objThamSoTKB.SO_TIET_CATOI; j++)
                        {
                            dt.Columns.Add(i.ToString() + "." + k.ToString() + "." + (objThamSoTKB.SO_TIET_CASANG + objThamSoTKB.SO_TIET_CACHIEU + j).ToString(), typeof(string));
                        }
                    }
                }
            }

            for (int i = 0; i <= phs.Count - 1; i++)
            {
                DataRow row = dt.NewRow();
                row["STT"] = i + 1;
                row["TenPhongHoc"] = phs[i].TenPhongHoc;
                row["IDDM_PhongHoc"] = phs[i].DM_PhongHocID;
                for (int thu = objThamSoTKB.THU_BAT_DAU; thu <= objThamSoTKB.THU_KET_THUC; thu++)
                {
                    for (int tiet = 0; tiet <= objThamSoTKB.SO_TIET_NGAY - 1; tiet++)
                    {
                        if (phs[i].TKB[thu, tiet] != -1)
                        {
                            col = CalCol(thu, tiet, 3);
                            row[col] = ThongTinPhong(i, thu, tiet);
                        }
                    }
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        public DataTable Baocao_TKB_giaovien()
        {
            DataTable dt = new DataTable();
            int col = 0;
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("TenGiaoVien", typeof(string));
            dt.Columns.Add("IDNS_GiaoVien", typeof(int));
            for (int i = objThamSoTKB.THU_BAT_DAU; i <= objThamSoTKB.THU_KET_THUC; i++)
            {
                for (int k = 0; k <= 2; k++)
                {
                    // Chay theo ca hoc 0- sang 1-chieu -2 toi
                    if (k == 0)
                    {
                        for (int j = 1; j <= objThamSoTKB.SO_TIET_CASANG; j++)
                        {
                            dt.Columns.Add(i.ToString() + "." + k.ToString() + "." + j.ToString(), typeof(string));
                        }
                    }
                    if (k == 1)
                    {
                        for (int j = 1; j <= objThamSoTKB.SO_TIET_CACHIEU; j++)
                        {
                            dt.Columns.Add(i.ToString() + "." + k.ToString() + "." + (objThamSoTKB.SO_TIET_CASANG + j).ToString(), typeof(string));
                        }
                    }
                    if (k == 2)
                    {
                        for (int j = 1; j <= objThamSoTKB.SO_TIET_CATOI; j++)
                        {
                            dt.Columns.Add(i.ToString() + "." + k.ToString() + "." + (objThamSoTKB.SO_TIET_CASANG + objThamSoTKB.SO_TIET_CACHIEU + j).ToString(), typeof(string));
                        }
                    }
                }
            }

            for (int i = 0; i <= gvs.Count - 1; i++)
            {
                DataRow row = dt.NewRow();
                row["STT"] = i + 1;
                row["TenGiaoVien"] = gvs[i].HoTen;
                row["IDNS_GiaoVien"] = gvs[i].NS_GiaoVienID;
                for (int thu = objThamSoTKB.THU_BAT_DAU; thu <= objThamSoTKB.THU_KET_THUC; thu++)
                {
                    for (int tiet = 0; tiet <= objThamSoTKB.SO_TIET_NGAY - 1; tiet++)
                    {
                        if (gvs[i].TKB[thu, tiet] != -1)
                        {
                            col = CalCol(thu, tiet, 3);
                            row[col] = ThongTinGV(i, thu, tiet);
                        }
                    }
                }

                //If row(col).ToString <> "" Then dt.Rows.Add(row)
                dt.Rows.Add(row);
            }
            //End If
            return dt;
        }


        public DataTable Danhsach_SuKienChuaXepLich_Phong(int _IDPhong)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("TenMon", typeof(string));
            dt.Columns.Add("TenLop", typeof(string));
            dt.Columns.Add("TenPhong", typeof(string));
            dt.Columns.Add("TenGiaoVien", typeof(string));
            dt.Columns.Add("SoTiet", typeof(int));
            dt.Columns.Add("CaHoc", typeof(string));
            dt.Columns.Add("IDX", typeof(int));
            int j = 0;
            for (int i = 0; i <= sks.Count - 1; i++)
            {
                if (sks[i].IDDM_PhongHoc == _IDPhong)
                {
                    if (sks[i].DaXepLich == false)
                    {
                        j = j + 1;
                        DataRow row = dt.NewRow();
                        row["STT"] = j;
                        row["TenMon"] = sks[i].TenMon;
                        row["TenLop"] = sks[i].TenLop;
                        row["TenGiaoVien"] = sks[i].TenGiaoVien;
                        row["TenPhong"] = sks[i].TenPhong;
                        row["SoTiet"] = sks[i].SoTiet < 1 ? 1 : sks[i].SoTiet;
                        row["CaHoc"] = sks[i].CaHoc == CA_HOC.CA_SANG ? "Sáng" : (sks[i].CaHoc == CA_HOC.CA_CHIEU ? "Chiều" :
                            (sks[i].CaHoc == CA_HOC.CA_TOI ? "Tối" : "Không xác định"));
                        row["IDX"] = i;
                        dt.Rows.Add(row);
                    }
                }
            }
            return dt;
        }

        public DataTable Danhsach_SuKienChuaXepLich_GiaoVien(int _IDNS_GiaoVien)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("TenMon", typeof(string));
            dt.Columns.Add("TenLop", typeof(string));
            dt.Columns.Add("TenPhong", typeof(string));
            dt.Columns.Add("TenGiaoVien", typeof(string));
            dt.Columns.Add("SoTiet", typeof(int));
            dt.Columns.Add("CaHoc", typeof(string));
            dt.Columns.Add("IDX", typeof(int));
            int j = 0;
            for (int i = 0; i <= sks.Count - 1; i++)
            {
                if (sks[i].IDNS_GiaoVien == _IDNS_GiaoVien)
                {
                    if (sks[i].DaXepLich == false)
                    {
                        j = j + 1;
                        DataRow row = dt.NewRow();
                        row["STT"] = j;
                        row["TenMon"] = sks[i].TenMon;
                        row["TenLop"] = sks[i].TenLop;
                        row["TenGiaoVien"] = sks[i].TenGiaoVien;
                        row["TenPhong"] = sks[i].TenPhong;
                        row["SoTiet"] = sks[i].SoTiet < 1 ? 1 : sks[i].SoTiet;
                        row["CaHoc"] = sks[i].CaHoc == CA_HOC.CA_SANG ? "Sáng" : (sks[i].CaHoc == CA_HOC.CA_CHIEU ? "Chiều" :
                            (sks[i].CaHoc == CA_HOC.CA_TOI ? "Tối" : "Không xác định"));
                        row["IDX"] = i;
                        dt.Rows.Add(row);
                    }
                }
            }
            return dt;
        }

        public DataTable Danhsach_SuKienChuaXepLich_Lop(int _IDLop)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("TenMon", typeof(string));
            dt.Columns.Add("TenLop", typeof(string));
            dt.Columns.Add("TenPhong", typeof(string));
            dt.Columns.Add("TenGiaoVien", typeof(string));
            dt.Columns.Add("SoTiet", typeof(int));
            dt.Columns.Add("CaHoc", typeof(string));
            dt.Columns.Add("IDX", typeof(int));
            int j = 0;
            for (int i = 0; i <= sks.Count - 1; i++)
            {
                if (sks[i].IDDM_Lop == _IDLop)
                {
                    if (sks[i].DaXepLich == false)
                    {
                        j = j + 1;
                        DataRow row = dt.NewRow();
                        row["STT"] = j;
                        row["TenMon"] = sks[i].TenMon;
                        row["TenLop"] = sks[i].TenLop;
                        row["TenGiaoVien"] = sks[i].TenGiaoVien;
                        row["TenPhong"] = sks[i].TenPhong;
                        row["SoTiet"] = sks[i].SoTiet < 1 ? 1 : sks[i].SoTiet;
                        row["CaHoc"] = sks[i].CaHoc == CA_HOC.CA_SANG ? "Sáng" : (sks[i].CaHoc == CA_HOC.CA_CHIEU ? "Chiều" :
                            (sks[i].CaHoc == CA_HOC.CA_TOI ? "Tối" : "Không xác định"));
                        row["IDX"] = i;
                        dt.Rows.Add(row);
                    }
                }
            }
            return dt;
        }

        public string ThongTinPhong(int idx, int Thu, int Tiet)
        {
            if (phs[idx].TKB[Thu, Tiet] == -1)
                return "";
            XL_SuKienTKBInfo sk = sks.FindSuKienByIdxSuKien(phs[idx].TKB[Thu, Tiet]);
            return phs[idx].TKB[Thu, Tiet] + "@" + sk.TenLop + "\n" + (sk.KyHieu == "" ? sk.TenMon : sk.KyHieu) +
                "\n" + (sk.TenVietTat == "" ? sk.TenGiaoVien : sk.TenVietTat);
        }

        public string ThongTinGV(int idx, int Thu, int Tiet)
        {
            if (gvs[idx].TKB[Thu, Tiet] == -1)
                return "";
            if (gvs[idx].TKB[Thu, Tiet, true] == eLOAI_SK.LK_GV)
            {
                XL_BaoBanGiaoVienInfo skk = (XL_BaoBanGiaoVienInfo)sk_gv[gvs[idx].TKB[Thu, Tiet], true];
                return "-1@" + skk.MoTa;
            }
            else
            {
                XL_SuKienTKBInfo sk = sks.FindSuKienByIdxSuKien(gvs[idx].TKB[Thu, Tiet]);
                return gvs[idx].TKB[Thu, Tiet] + "@" + sk.TenLop + "\n" + (sk.KyHieu == "" ? sk.TenMon : sk.KyHieu) + "\n" + sk.TenPhong;
            }
        }

        public string ThongTinLop(int idx, int Thu, int Tiet)
        {
            if (lps[idx].TKB[Thu, Tiet] == -1)
                return "";
            if (lps[idx].TKB[Thu, Tiet, true] == eLOAI_SK.LK_LOP)
            {
                XL_SuKienKhacLopInfo skk = sk_lp[lps[idx].TKB[Thu, Tiet]];
                return "-1@" + skk.MoTa;
            }
            else
            {
                XL_SuKienTKBInfo sk = sks.FindSuKienByIdxSuKien(lps[idx].TKB[Thu, Tiet]);
                return lps[idx].TKB[Thu, Tiet] + "@" + (sk.KyHieu == "" ? sk.TenMon : sk.KyHieu) + "\n" + sk.TenPhong +
                    "\n" + (sk.TenVietTat == "" ? sk.TenGiaoVien : sk.TenVietTat);
            }
        }

        private int CalCol(int Thu, int Tiet, int OffSet)
        {
            return (Thu - 1) * objThamSoTKB.SO_TIET_NGAY + Tiet + OffSet;
        }
        #endregion

        public ArrayList List_free_cell(int idx)
        {
            ArrayList mask = new ArrayList();
            //int[] arrTiet = null;
            int min = 0, max = 4;
            if (sks[idx].CaHoc == CA_HOC.CA_SANG)
            {
                min = 0;
                max = objThamSoTKB.SO_TIET_CASANG - 1;
            }
            else if (sks[idx].CaHoc == CA_HOC.CA_CHIEU)
            {
                min = objThamSoTKB.SO_TIET_CASANG;
                max = objThamSoTKB.SO_TIET_CASANG + objThamSoTKB.SO_TIET_CACHIEU - 1;
            }
            for (int thu = objThamSoTKB.THU_BAT_DAU; thu <= objThamSoTKB.THU_KET_THUC; thu++)
            {
                for (int tiet = min; tiet <= max; tiet++)
                {
                    if (scE.ChoPhepXepLich(idx, thu, tiet, min, max) == "")
                    {
                        mask.Add(new Point(thu - 1, tiet));
                    }
                }
            }
            return mask;
        }

        public void XepLichTuDong()
        {
            scE.XepLichTuDong();
        }

        public string ChoPhepXepLich(int idx, int thu, int tiet)
        {
            int min = 0, max = 4;
            if (sks[idx].CaHoc == CA_HOC.CA_SANG)
            {
                min = 0;
                max = objThamSoTKB.SO_TIET_CASANG - 1;
            }
            else if (sks[idx].CaHoc == CA_HOC.CA_CHIEU)
            {
                min = objThamSoTKB.SO_TIET_CASANG;
                max = objThamSoTKB.SO_TIET_CASANG + objThamSoTKB.SO_TIET_CACHIEU - 1;
            }
            return scE.ChoPhepXepLich(idx, thu, tiet, min, max);
        }

        public void ChayXepLich(int idx, int thu, int TietDau)
        {
            scE.ChayXepLich(idx, thu, TietDau);
        }

        public int HuyLich(int idx, int thu, int tiet, ref int SoTiet)
        {
            return scE.HuyLich(idx, thu, ref SoTiet);
        }

        public void HuyLich()
        {
            int SoTiet = 0;
            for (int idx = 0; idx < sks.Count; idx++)
            {
                if (sks[idx].DaXepLich == true)
                {
                    //for (int thu = objThamSoTKB.THU_BAT_DAU; thu <= objThamSoTKB.THU_KET_THUC; thu++)
                    //{
                    //    for (int tiet = 0; tiet <= objThamSoTKB.SO_TIET_NGAY - 1; tiet++)
                    //    {
                    scE.HuyLich(idx, sks[idx].Thu, ref SoTiet);
                    //    }
                    //}
                }
            }
        }

        public int So_su_kien_chua_xep_lich()
        {
            int SoSk = 0;
            for (int i = 0; i <= sks.Count - 1; i++)
            {
                if (sks[i].DaXepLich == false)
                {
                    SoSk = SoSk + 1;
                }
            }

            return SoSk;
        }

        #region Lưu thời khóa biểu
        //public void LuuTKB()
        //{
        //    for (int i = 0; i < sks.Count; i++)
        //    {
        //        if (sks[i].XL_SuKienTKBID > 0)
        //            Update(i);
        //        else
        //            Insert(i);
        //    }
        //    mUpdate = true;
        //}

        //private void Insert(int idx)
        //{
        //    int ID = oBSuKienTKB.Add(sks[idx]);
        //    sks[idx].XL_SuKienTKBID = ID;
        //}

        //private void Update(int idx)
        //{
        //    oBSuKienTKB.Update(sks[idx]);
        //}

        //public void Delete(int idx)
        //{
        //    if (sks[idx].XL_SuKienTKBID > 0)
        //    {
        //        pSuKienTKBInfo.XL_SuKienTKBID = sks[idx].XL_SuKienTKBID;
        //        //if (sks[idx].DaXepLich == true)
        //        //{
        //        //    HuyLich(idx, sks[idx].Thu, sks[idx].Tiet);
        //        //}
        //        oBSuKienTKB.Delete(pSuKienTKBInfo);
        //        //sks.Remove(idx);
        //    }
        //    else
        //    {
        //        if (sks[idx].DaXepLich == true)
        //        {
        //            int SoTiet = 0;
        //            HuyLich(idx, sks[idx].Thu, sks[idx].TietDau, ref SoTiet);
        //        }
        //        sks.Remove(idx);
        //    }
        //}
        #endregion

        #region Danh sach giao vien, phong hoc
        public DataTable DanhSachGiaoVien()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NS_GiaoVienID", typeof(int));
            dt.Columns.Add("MaGiaoVien", typeof(string));
            dt.Columns.Add("TenGiaoVien", typeof(string));
            dt.Columns.Add("TenVietTat", typeof(string));
            DataRow dr;
            for (int i = 0; i < gvs.Count; i++)
            {
                dr = dt.NewRow();
                dr["NS_GiaoVienID"] = gvs[i].NS_GiaoVienID;
                dr["MaGiaoVien"] = gvs[i].MaGiaoVien;
                dr["TenGiaoVien"] = gvs[i].HoTen;
                dr["TenVietTat"] = gvs[i].TenVietTat;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public DataTable DanhSachPhongHoc()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DM_PhongHocID", typeof(int));
            dt.Columns.Add("TenPhongHoc", typeof(string));
            dt.Columns.Add("SucChua", typeof(string));
            DataRow dr;
            for (int i = 0; i < phs.Count; i++)
            {
                dr = dt.NewRow();
                dr["DM_PhongHocID"] = phs[i].DM_PhongHocID;
                dr["TenPhongHoc"] = phs[i].TenPhongHoc;
                dr["SucChua"] = phs[i].SucChua;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public void ChangeSuKien(ref XL_SuKienTKBInfo sk)
        {
            if (sk.IDNS_GiaoVien > 0)
                sk.IdxGiaoVien = gvs.SearchIndexGV(sk.IDNS_GiaoVien);
            if (sk.IDDM_PhongHoc > 0)
                sk.IdxPhong = phs.SearchIndexPhong(sk.IDDM_PhongHoc);
        }
        #endregion
    }
}

public struct CHIA_TIET
{
    public int IDXL_MonHocTrongKy;
    public int SoTiet;

    public CHIA_TIET(int ID, int Value)
    {
        IDXL_MonHocTrongKy = ID;
        SoTiet = Value;
    }
}
