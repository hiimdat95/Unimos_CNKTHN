using System;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;
using System.Data;
using System.Collections;

namespace TruongViet.UnimOs.Business
{
    public class SchoolEngine : cBBase
    {
        #region Khai báo biến
        private long intIDTuan;
        private SuKienTKB sks;
        private SuKienKhacTKB sk_lp;
        private SuKienKhacTKB sk_gv;
        private cBDM_Lop lps;
        private cBNS_GiaoVien gvs;
        private cBDM_PhongHoc phs;
        private HT_ThamSoXepLichInfo objThamSoTKB;

        public int[] arrTiet, arrNhomTiet;
        private bool IsTietNhomKhacNhau = false;
        #endregion

        #region Khởi tạo
        public SchoolEngine(int IDNamHoc, long _IDTuan, cBDM_PhongHoc arrPhongHoc, cBNS_GiaoVien arrGiaoVien, cBDM_Lop arrLop, SuKienTKB arrSuKien, SuKienKhacTKB mSk_lp, SuKienKhacTKB mSk_gv, HT_ThamSoXepLichInfo pThamSoTKB, int[] _arrNhomTiet)
        {
            intIDTuan = _IDTuan;
            sks = arrSuKien;
            lps = arrLop;
            gvs = arrGiaoVien;
            phs = arrPhongHoc;
            sk_lp = mSk_lp;
            sk_gv = mSk_gv;
            objThamSoTKB = pThamSoTKB;
            arrNhomTiet = _arrNhomTiet;
            if (arrNhomTiet.Length > 1)
            {
                if (arrNhomTiet[0] != arrNhomTiet[1])
                    IsTietNhomKhacNhau = true;
            }
        }
        #endregion

        #region Thực hiện thuật toán xếp lịch
        private void GetMinMax(int idx, ref int min, ref int max, ref int TuTiet, ref int DenTiet)
        {
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

            TuTiet = min;
            DenTiet = max;

            if (IsTietNhomKhacNhau)
            {
                // Nếu số tiết của sự kiện thuộc vào nhóm thứ nhất thì số tiết sẽ chạy từ min đến min + số tiết
                if (sks[idx].SoTiet == arrNhomTiet[0])
                    DenTiet = min + sks[idx].SoTiet - 1;
                else
                    TuTiet = min + sks[idx].SoTiet + 1;
            }
        }

        public bool XepLichTuDong()
        {
            if (lps.Count <= 0)
                return false;

            XL_SuKienTKBInfo objSK;
            // Xếp các môn học phải học ở phòng chuyên môn trước
            // Phải đảm bảo các yếu tố trong tham số hệ thống.

            for (int i = 0; i < sks.Count; i++)
            {
                objSK = sks[i];
                if (!objSK.ThieuDuLieu)
                {
                    if (objSK.Thu == -1 && objSK.TietDau == -1 && objSK.SoTiet != -1)
                    {
                        if (objSK.SuDungPhong == SU_DUNG_PHONG.DUOI_DAY && objSK.IDDM_PhongHoc > 0)
                        {
                            XepLichMonChuyenMon(i);
                        }
                    }
                }
            }

            // Xếp các môn học nhiều tiết liên tục trước
            int[] idxSKSapXep = SapXepSuKienTheoSoTiet();
            for (int i = 0; i < idxSKSapXep.Length; i++)
            {
                objSK = sks[idxSKSapXep[i]];
                if (!objSK.ThieuDuLieu)
                {
                    if (objSK.Thu == -1 && objSK.TietDau == -1 && objSK.SoTiet != -1)
                    {
                        XepTuDong(idxSKSapXep[i]);
                    }
                }
            }

            // Thực hiện xếp lịch 1 lần nữa
            for (int i = 0; i < sks.Count; i++)
            {
                objSK = sks[i];
                if (!objSK.ThieuDuLieu)
                {
                    if (objSK.Thu == -1 && objSK.TietDau == -1 && objSK.SoTiet != -1)
                    {
                        XepTuDong(i);
                    }
                }
            }

            // Thực hiện tìm và đổi chỗ các sự kiện chưa xếp được lịch để có lịch chuẩn.
            DataTable dtChuaXep = sks.ToTable(false, true);
            if (dtChuaXep.Rows.Count > 0)
            {
                for (int i = 0; i < dtChuaXep.Rows.Count; i++)
                {
                    XepLichBangCachDoiCho(int.Parse(dtChuaXep.Rows[i]["Idx"].ToString()));
                }
            }

            //// Thực hiện xếp lịch 1 lần nữa
            //for (int i = 0; i < sks.Count; i++)
            //{
            //    objSK = sks[i];
            //    if (!objSK.ThieuDuLieu)
            //    {
            //        if (objSK.Thu == -1 && objSK.TietDau == -1 && objSK.SoTiet != -1)
            //        {
            //            XepTuDong(i);
            //        }
            //    }
            //}

            return true;
        }

        /// <summary>
        /// Thực hiện xếp lịch với sự kiện có chỉ số idx
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        private bool XepTuDong(int idx)
        {
            int min = 0, max = 4, TuTiet = 0, DenTiet = 4;
            
            GetMinMax(idx, ref min, ref max, ref TuTiet, ref DenTiet);

            for (int Tiet = TuTiet; Tiet <= DenTiet; Tiet++)
            {
                for (int Thu = objThamSoTKB.THU_BAT_DAU; Thu <= objThamSoTKB.THU_KET_THUC; Thu++)
                {
                    arrTiet = null;
                    if (ChoPhepXepLich(idx, Thu, Tiet, TuTiet, DenTiet) == "" && Xep1NhomTietTrongBuoi(idx, Thu, Tiet, min, max) == "")
                    {
                        ChayXepLich(idx, Thu, arrTiet[0]);
                        return true;
                    }
                }
            }
            return false;
        }

        // Xếp tự động loại trừ thứ đưa vào tham số
        private bool XepTuDong(int idx, int thu)
        {
            int min = 0, max = 4, TuTiet = 0, DenTiet = 4;

            GetMinMax(idx, ref min, ref max, ref TuTiet, ref DenTiet);

            for (int Tiet = TuTiet; Tiet <= DenTiet; Tiet++)
            {
                for (int Thu = objThamSoTKB.THU_BAT_DAU; Thu <= objThamSoTKB.THU_KET_THUC; Thu++)
                {
                    if (Thu != thu)
                    {
                        arrTiet = null;
                        if (ChoPhepXepLich(idx, Thu, Tiet, TuTiet, DenTiet) == "" && Xep1NhomTietTrongBuoi(idx, Thu, Tiet, min, max) == "")
                        {
                            ChayXepLich(idx, Thu, arrTiet[0]);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        // Thực hiện xếp lịch cho các môn học ở phòng chuyên môn
        private bool XepLichMonChuyenMon(int idx)
        {
            int min = 0, max = 4, TuTiet = 0, DenTiet = 4;

            GetMinMax(idx, ref min, ref max, ref TuTiet, ref DenTiet);

            for (int Thu = objThamSoTKB.THU_BAT_DAU; Thu <= objThamSoTKB.THU_KET_THUC; Thu++)
            {
                for (int Tiet = TuTiet; Tiet <= DenTiet; Tiet++)
                {
                    arrTiet = null;
                    if (ChoPhepXepLich(idx, Thu, Tiet, TuTiet, DenTiet) == "" && Xep1NhomTietTrongBuoi(idx, Thu, Tiet, min, max) == "")
                    {
                        ChayXepLich(idx, Thu, arrTiet[0]);
                        return true;
                    }
                }
            }
            return false;
        }

        // Tìm và đổi lịch
        private bool XepLichBangCachDoiCho(int idx)
        {
            XL_SuKienTKBInfo sk = sks[idx];
            int min = 0, max = 4, TuTiet = 0, DenTiet = 4;

            GetMinMax(idx, ref min, ref max, ref TuTiet, ref DenTiet);

            for (int Tiet = TuTiet; Tiet <= DenTiet; Tiet++)
            {
                for (int Thu = objThamSoTKB.THU_BAT_DAU; Thu <= objThamSoTKB.THU_KET_THUC; Thu++)
                {
                    // Nếu sự kiên idx có khả năng xếp vào ô thứ tiết thì sẽ thực hiện kiểm tra khả năng của sự kiện tại ô thứ tiết.
                    if (lps[sk.IdxLop].TKB[Thu, Tiet, true] != eLOAI_SK.LK_LOP)
                    {
                        int idxDangXet = lps[sk.IdxLop].TKB[Thu, Tiet];
                        if (idxDangXet >= 0)
                        {
                            int TietDau = HuyLich(idxDangXet, Thu, TuTiet, DenTiet);
                            arrTiet = null;
                            if (ChoPhepXepLich(idx, Thu, Tiet, TuTiet, DenTiet) == "" && Xep1NhomTietTrongBuoi(idx, Thu, Tiet, min, max) == "")
                            {
                                if (sks[idx].SoTiet + TietDau - 1 <= max)
                                {
                                    int[] arrTietDoiLich = arrTiet;
                                    if (XepTuDong(idxDangXet, Thu) == true)
                                    {
                                        ChayXepLich(idx, Thu, arrTietDoiLich[0]);
                                        return true;
                                    }
                                    else
                                        ChayXepLich(idxDangXet, Thu, TietDau);
                                }
                            }
                            else
                                ChayXepLich(idxDangXet, Thu, TietDau);
                        }
                    }
                }
            }
            return false;
        }

        // Kiểm tra sự kiện có được xếp vào ô thứ tiết hay không.
        public string ChoPhepXepLich(int idx, int Thu, int Tiet, int min, int max)
        {
            string strResult = "";
            if (min <= Tiet && Tiet <= max)
            {
                arrTiet = new int[sks[idx].SoTiet];
                int DaXep = 0;
                //for (int i = Tiet; i < ((Tiet + sks[idx].SoTiet) >= max ? max : Tiet + sks[idx].SoTiet); i++)
                for (int i = Tiet; i <= max; i++)
                {
                    strResult = ChoPhepXepLich(idx, Thu, i);
                    if (strResult != "")
                    {
                        DaXep = 0;
                        arrTiet = new int[sks[idx].SoTiet];
                    }
                    else
                    {
                        arrTiet[DaXep] = i;
                        DaXep++;
                        if (DaXep == sks[idx].SoTiet)
                            return "";
                    }
                }
                return "Không thể tìm thấy " + sks[idx].SoTiet.ToString() + " tiết liên tiếp phù hợp để xếp lịch" + (strResult != "" ? "" : " \nHoặc" + strResult);
            }
            return "Không xếp được vì trái ca";
        }

        /// <summary>
        /// Kiểm tra xem có được xếp lịch vào thứ tiến này ko
        /// </summary>
        /// <param name="idx">Chỉ số sự kiên</param>
        /// <param name="Thu">Thứ sẽ xếp</param>
        /// <param name="Tiet">Tiết sẽ xếp</param>
        /// <returns>Nếu trả lại "" là có thể xếp</returns>
        public string ChoPhepXepLich(int idx, int Thu, int Tiet)
        {
            string strResult = "";
            int idxLop;
            // Thực hiện kiểm tra thuộc tính môn học
            //if (sks[idx].IndexThuocTinhMon != -1)
            //{
            //    // Kiểm tra tiết có được xếp lịch của môn hay không
            //    strResult = TietXepLichPhuHop(idx, sks[idx].IndexThuocTinhMon, Tiet);
            //    if (strResult != "")
            //        return strResult;

            //    strResult = HocCachTietTrongBuoi(idx, sks[idx].IndexThuocTinhMon, Thu, Tiet);
            //    if (strResult != "")
            //        return strResult;

            //    strResult = XepCachNgay(idx, sks[idx].IndexThuocTinhMon, Thu, Tiet);
            //    if (strResult != "")
            //        return strResult;
            //}
            // Kiểm tra lớp đó có sự kiện xếp lịch hay chưa
            idxLop = sks[idx].IdxLop;
            if (idxLop != -1)
            {
                if (lps[idxLop].TKB[Thu, Tiet] != -1)
                {
                    if (lps[idxLop].TKB[Thu, Tiet, true] != eLOAI_SK.LK_LOP)
                    {
                        //SuKienTKBInfo sk = sks.FindSuKienByIDKhoiLop(lps[idxLop].IDKhoiLop, Thu, Tiet);
                        XL_SuKienTKBInfo sk;
                        try
                        {
                            sk = sks[lps[idxLop].TKB[Thu, Tiet]];
                        }
                        catch
                        {
                            return "Chỉ số sự kiện bị tràn";
                        }
                        strResult = "Trùng lịch lớp \n" + GetThu(Thu) + " - " + "Nhóm tiết " + (Tiet + 1).ToString() + "\nĐã xếp lịch Giáo viên '" + sk.TenGiaoVien + "' Phòng học '" + sk.TenPhong + "' Môn '" + sk.TenMon + "'";
                        return strResult;
                    }
                    else
                        return "Đã xếp lịch ngoại khóa hoặc là tiết chào cờ, sinh hoạt lớp";
                }
            }
            else
                return "Không có lớp trong sự kiện";

            int idxPhong;
            // Kiểm tra Phòng đó có sự kiện xếp lịch hay chưa
            idxPhong = sks[idx].IdxPhong;
            if (idxPhong != -1 && sks[idx].SuDungPhong != SU_DUNG_PHONG.KHONG_SD)
            {
                if (phs[idxPhong].TKB[Thu, Tiet] != -1)
                {
                    //SuKienTKBInfo sk = sks.FindSuKienByIDPhongHoc(phs[idxPhong].PhongHocID, Thu, Tiet);
                    XL_SuKienTKBInfo sk;
                    try
                    {
                        sk = sks[phs[idxPhong].TKB[Thu, Tiet]];
                    }
                    catch
                    {
                        return "Chỉ số sự kiện bị tràn";
                    }
                    strResult = "Trùng lịch phòng \n" + GetThu(Thu) + " - " + "Nhóm tiết " + (Tiet + 1).ToString() + "\nĐã xếp lịch lớp '" + sk.TenLop + "' Giáo viên '" + sk.TenGiaoVien + "' Môn '" + sk.TenMon + "'";
                    return strResult;
                }
            }
            else if (sks[idx].SuDungPhong != SU_DUNG_PHONG.KHONG_SD)
                return "Không có phòng trong sự kiện";

            int idxGiaoVien;
            // Kiểm tra Giáo viên đó có sự kiện xếp lịch hay chưa
            idxGiaoVien = sks[idx].IdxGiaoVien;
            if (idxGiaoVien != -1)
            {
                if (gvs[idxGiaoVien].TKB[Thu, Tiet] != -1)
                {
                    if (gvs[idxGiaoVien].TKB[Thu, Tiet, true] != eLOAI_SK.LK_GV)
                    {
                        XL_SuKienTKBInfo sk;
                        try
                        {
                            sk = sks[gvs[idxGiaoVien].TKB[Thu, Tiet]];
                        }
                        catch
                        {
                            return "Chỉ số sự kiện bị tràn";
                        }
                        strResult = "Trùng lịch giáo viên \n" + GetThu(Thu) + " - " + "Nhóm tiết " + (Tiet + 1).ToString() + "\nĐã xếp lịch lớp '" + sk.TenLop + "' Phòng học '" + sk.TenPhong + "' Môn '" + sk.TenMon + "'";
                        return strResult;
                    }
                    else
                        return "Đã báo bận cho giáo viên vào tiết này.";
                }
            }
            else
                return "Không có giáo viên trong sự kiện";

            return strResult;
        }

        //private string TietXepLichPhuHop(int idx, int idxThuocTinhMon, int tiet)
        //{
        //    if (sks[idx].CaHoc == CA_HOC.CA_SANG)
        //    {
        //        if (ttms[idxThuocTinhMon].arrTietXepLichSang.Length > 0)
        //        {
        //            if (ttms[idxThuocTinhMon].arrTietXepLichSang.Contains(tiet.ToString()) == false)
        //                return "Môn học này không cho xếp lịch vào tiết này.";
        //        }
        //        else
        //            return "Môn này không xếp lịch vào buổi sáng.";
        //    }
        //    else if (sks[idx].CaHoc == CA_HOC.CA_CHIEU)
        //    {
        //        tiet = tiet - objThamSoTKB.SO_TIET_CASANG;
        //        if (ttms[idxThuocTinhMon].arrTietXepLichChieu.Length > 0)
        //        {
        //            if (ttms[idxThuocTinhMon].arrTietXepLichChieu.Contains(tiet.ToString()) == false)
        //                return "Môn học này không cho xếp lịch vào tiết này.";
        //        }
        //        else
        //            return "Môn này không xếp lịch vào buổi chiều.";
        //    }
        //    else if (sks[idx].CaHoc == CA_HOC.CA_TOI)
        //    {
        //        tiet = tiet - (objThamSoTKB.SO_TIET_CASANG + objThamSoTKB.SO_TIET_CACHIEU);
        //        if (ttms[idxThuocTinhMon].arrTietXepLichToi.Length > 0)
        //        {
        //            if (ttms[idxThuocTinhMon].arrTietXepLichToi.Contains(tiet.ToString()) == false)
        //                return "Môn học này không cho xếp lịch vào tiết này.";
        //        }
        //        else
        //            return "Môn này không xếp lịch vào buổi tối.";
        //    }
        //    else
        //        return "Ca học không xác định.";
        //    return "";
        //}

        //private string HocCachTietTrongBuoi(int idx, int idxThuocTinhMon, int thu, int tiet)
        //{
        //    if (ttms[idxThuocTinhMon].HocCachTietTrongBuoi == true)
        //    {
        //        if (tiet != 0 || tiet != objThamSoTKB.SO_TIET_CASANG || tiet != (objThamSoTKB.SO_TIET_CASANG + objThamSoTKB.SO_TIET_CACHIEU))
        //        {
        //            if (lps[sks[idx].IdxLop].TKB[thu, tiet - 1] != -1 && lps[sks[idx].IdxLop].TKB[thu, tiet - 1, true] != eLOAI_SK.LK_LOP)
        //            {
        //                int idx1 = lps[sks[idx].IdxLop].TKB[thu, tiet - 1];
        //                if (sks[idx].IDDM_MonHoc == sks[idx1].IDDM_MonHoc)
        //                    return "Không được xếp các tiết liên tiếp trong buổi.";
        //            }
        //        }
        //    }
        //    return "";
        //}

        private string Xep1NhomTietTrongBuoi(int idx, int thu, int tiet, int min, int max)
        {
            for (int i = min; i <= max; i++)
            {
                if (i != tiet)
                {
                    if (lps[sks[idx].IdxLop].TKB[thu, i] != -1 && lps[sks[idx].IdxLop].TKB[thu, i, true] != eLOAI_SK.LK_LOP)
                    {
                        int idx1 = lps[sks[idx].IdxLop].TKB[thu, i];
                        if (sks[idx].IDDM_MonHoc == sks[idx1].IDDM_MonHoc)
                            return "Không được xếp hai nhóm tiết trong một buổi học.";
                    }
                }
            }
            return "";
        }

        //private string XepCachNgay(int idx, int idxThuocTinhMon, int thu, int tiet)
        //{
        //    if (ttms[idxThuocTinhMon].XepCachNgay == true)
        //    {
        //        if (thu != objThamSoTKB.THU_BAT_DAU)
        //        {
        //            if (lps[sks[idx].IdxLop].TKB[thu, tiet - 1] != -1 && lps[sks[idx].IdxLop].TKB[thu, tiet - 1, true] != eLOAI_SK.LK_LOP)
        //            {
        //                int idx1 = lps[sks[idx].IdxLop].TKB[thu - 1, tiet];
        //                if (sks[idx].IDDM_MonHoc == sks[idx1].IDDM_MonHoc)
        //                    return "Không được xếp các tiết trong các ngày liên tiếp.";
        //            }
        //        }
        //    }
        //    return "";
        //}

        /// <summary>
        /// Thực hiện gán thứ tiết vào cho sự kiện đã đủ điều kiện xếp lịch
        /// </summary>
        /// <param name="idx">Chỉ số sự kiên</param>
        /// <param name="Thu">Thứ được xếp</param>
        /// <param name="Tiet">Tiết được xếp</param>
        public void ChayXepLich(int idx, int Thu, int TietDau)
        {
            int idxPhong, idxLop, idxGiaoVien;
            idxPhong = sks[idx].IdxPhong;
            idxLop = sks[idx].IdxLop;
            idxGiaoVien = sks[idx].IdxGiaoVien;

            for (int i = TietDau; i < sks[idx].SoTiet + TietDau; i++)
            {
                if (idxPhong != -1)
                    phs[idxPhong].TKB[Thu, i] = sks[idx].Idx;
                lps[idxLop].TKB[Thu, i] = sks[idx].Idx;
                if (idxGiaoVien != -1)
                    gvs[idxGiaoVien].TKB[Thu, i] = sks[idx].Idx;
            }
            sks[idx].Thu = Thu;
            sks[idx].TietDau = TietDau;
            sks[idx].DaXepLich = true;
        }

        /// <summary>
        /// Hàm trả về một mảng index của sự kiện theo sự giảm dần của số tiết
        /// </summary>
        /// <returns></returns>
        private int[] SapXepSuKienTheoSoTiet()
        {
            int[] idx = new int[sks.Count];
            int i, idxTemp;
            for (i = 0; i < sks.Count; i++)
                idx[i] = i;
            for (i = 0; i < sks.Count - 1; i++)
            {
                for (int j = i + 1; j < sks.Count; j++)
                {
                    if (sks[idx[i]].SoTiet < sks[idx[i]].SoTiet)
                    {
                        idxTemp = idx[i];
                        idx[i] = idx[j];
                        idx[j] = idxTemp;
                    }
                }
            }
            return idx;
        }

        /// <summary>
        /// Hủy lịch phải hủy cả lịch lớp, phòng, giáo viên và sự kiện
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="thu"></param>
        /// <param name="tiet"></param>
        public int HuyLich(int idx, int thu, ref int SoTiet)
        {
            int idxLop, idxPhong, idxGV, result;
            idxLop = sks[idx].IdxLop;
            idxPhong = sks[idx].IdxPhong;
            idxGV = sks[idx].IdxGiaoVien;

            result = sks[idx].TietDau;
            SoTiet = sks[idx].SoTiet;
            // Hủy các thông tin liên quan đến sk đó
            for (int i = sks[idx].TietDau; i < sks[idx].TietDau + SoTiet; i++)
            {
                if (idxLop != -1)
                    lps[idxLop].TKB[thu, i] = -1;

                if (idxPhong != -1)
                    phs[idxPhong].TKB[thu, i] = -1;

                if (idxGV != -1)
                    gvs[idxGV].TKB[thu, i] = -1;
            }

            sks[idx].Thu = -1;
            sks[idx].TietDau = -1;
            sks[idx].DaXepLich = false;
            sks[idx].Changed = true;
            return result;
        }

        public int HuyLich(int idx, int thu, int min, int max)
        {
            int idxLop, idxPhong, idxGV, result;
            idxLop = sks[idx].IdxLop;
            idxPhong = sks[idx].IdxPhong;
            idxGV = sks[idx].IdxGiaoVien;

            // Hủy các thông tin liên quan đến sk
            result = sks[idx].TietDau;

            for (int i = sks[idx].TietDau; i < sks[idx].TietDau + sks[idx].SoTiet; i++)
            {
                if (idxLop != -1)
                    lps[idxLop].TKB[thu, i] = -1;

                if (idxPhong != -1)
                    phs[idxPhong].TKB[thu, i] = -1;

                if (idxGV != -1)
                    gvs[idxGV].TKB[thu, i] = -1;
            }
            sks[idx].Thu = -1;
            sks[idx].TietDau = -1;
            sks[idx].DaXepLich = false;
            sks[idx].Changed = true;
            return result;
        }
        #endregion
    }
}
