using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.wsBusiness;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Entity.Model;
using System.Collections;
using System.Globalization;
using TruongViet.UnimOs.Data;
using UnimOs.wsBusiness.wsUnimOs;

namespace TruongViet.UnimOs.wsBusiness
{
    public class cBwsHT_DuLieuNhap : cBwsBase
    {
        string[] dateFormats = { "MMyy", "Myy", "dMMyy", "yy", "ddMMyy", "ddMyy", "dMMyyyy", "ddMMyyyy", "MM/yyyy", "M/yyyy", "d/M/yyyy", 
                                   "dd/MM/yy", "dd/M/yy", "dd/MM/yyyy", "dd/M/yyyy", "MM/dd/yyyy", "M/d/yyyy", "d/M/yyyy hh:mm:ss AM" };
        CultureInfo enUS = new CultureInfo("en-US");
        DateTimeStyles dateStyle = DateTimeStyles.None;

        public cBwsHT_DuLieuNhap()
        {

        }

        public DataTable TableLoaiNhap()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MALOAINHAP", typeof(string));
            dt.Columns.Add("TENLOAINHAP", typeof(string));

            dt.Rows.Add(new string[] { "Diem_DiemThanhPhan", "Nhập điểm môn học" });
            dt.Rows.Add(new string[] { "SV_SinhVien", "Nhập danh sách Sinh viên" });
            dt.Rows.Add(new string[] { "NS_GiaoVien", "Nhập danh sách giáo viên" });
            dt.Rows.Add(new string[] { "DM_MonHoc", "Nhập danh sách môn học" });
            dt.Rows.Add(new string[] { "DM_TinhHuyenXa", "Nhập danh sách tỉnh huyện xã" });
            dt.Rows.Add(new string[] { "SV_SinhVienNhapTruong", "Chuyển dữ liệu từ tuyển sinh" });

            return dt;
        }

        #region Thiết lập các trường ánh xạ
        public DataTable CreateTableAnhXa()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("TenTruongDuLieu", typeof(string));
            dt.Columns.Add("KieuDuLieu", typeof(string));
            return dt;
        }

        public DataTable AnhXaNhapDiemThanhPhan()
        {
            DataTable dt = new cBwsKQHT_ThanhPhanDiem().GetNhapDuLieu();
            DataRow dr = dt.NewRow();
            dr["ID"] = "MaSinhVien";
            dr["TenTruongDuLieu"] = "Mã sinh viên";
            dr["KieuDuLieu"] = "System.String";
            dt.Rows.InsertAt(dr, 0);

            return dt;
        }

        public DataTable AnhXaNhapDiemTongKet(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            DataTable dt = new cBwsXL_MonHocTrongKy().GetNhapDuLieuByHocKyNamHoc(IDDM_Lop, IDDM_NamHoc, HocKy);
            DataRow dr = dt.NewRow();
            dr["ID"] = "MaSinhVien";
            dr["TenTruongDuLieu"] = "Mã sinh viên";
            dr["KieuDuLieu"] = "System.String";
            dt.Rows.InsertAt(dr, 0);

            return dt;
        }

        //public DataTable AnhXaNhapDiemTheoLoaiDiem(DM_LOAIDIEMInfo pDM_LoaiDiemInfo)
        //{
        //    DataTable dt = new cBDM_LOAIDIEM().GetNhapDuLieu(pDM_LoaiDiemInfo);
        //    DataRow dr = dt.NewRow();
        //    dr["ID"] = "MaSinhVien";
        //    dr["TenTruongDuLieu"] = "Mã học sinh";
        //    dr["KieuDuLieu"] = "System.String";
        //    dt.Rows.InsertAt(dr, 0);

        //    return dt;
        //}

        public DataTable AnhXaSinhVienNhapTruong()
        {
            DataTable dt = CreateTableAnhXa();
            dt.Rows.Add(new string[] { "HoVaTen", "Tên sinh viên", "System.String" });
            dt.Rows.Add(new string[] { "Ho", "Họ", "System.String" });
            dt.Rows.Add(new string[] { "Ten", "Tên", "System.String" });
            dt.Rows.Add(new string[] { "NgaySinh", "Ngày sinh", "System.DateTime" });
            dt.Rows.Add(new string[] { "SoBaoDanh", "Số báo danh", "System.String" });
            dt.Rows.Add(new string[] { "NoiSinh", "Nơi sinh", "System.String" });
            dt.Rows.Add(new string[] { "ThuongTru", "Thường trú", "System.String" });
            dt.Rows.Add(new string[] { "GioiTinh", "Giới tính", "System.String" });
            dt.Rows.Add(new string[] { "KhoiThi", "Khối thi", "System.String" });
            dt.Rows.Add(new string[] { "NganhThi", "Ngành thi", "System.String" });
            dt.Rows.Add(new string[] { "DanToc", "Dân tộc", "System.String" });
            dt.Rows.Add(new string[] { "DoiTuong", "Đối tượng", "System.String" });
            dt.Rows.Add(new string[] { "NamTotNghiep", "Năm tốt nghiệp", "System.String" });
            dt.Rows.Add(new string[] { "KhuVuc", "Khu vực", "System.String" });
            dt.Rows.Add(new string[] { "DiemMon1", "Điểm môn 1", "System.Double" });
            dt.Rows.Add(new string[] { "DiemMon2", "Điểm môn 2", "System.Double" });
            dt.Rows.Add(new string[] { "DiemMon3", "Điểm môn 3", "System.Double" });
            dt.Rows.Add(new string[] { "DiemMon4", "Điểm môn 4", "System.Double" });
            dt.Rows.Add(new string[] { "TongDiemLamTron", "Tổng điểm làm tròn", "System.Double" });

            return dt;
        }

        public DataTable AnhXaSinhVien()
        {
            DataTable dt = CreateTableAnhXa();
            dt.Rows.Add(new string[] { "MaSinhVien", "Mã sinh viên", "System.String" });
            dt.Rows.Add(new string[] { "HoVaTen", "Họ và tên", "System.String" });
            dt.Rows.Add(new string[] { "Ho", "Họ", "System.String" });
            dt.Rows.Add(new string[] { "Ten", "Tên", "System.String" });
            dt.Rows.Add(new string[] { "NgaySinh", "Ngày sinh", "System.DateTime" });
            dt.Rows.Add(new string[] { "GioiTinh", "Giới tính", "System.String" });
            dt.Rows.Add(new string[] { "DanToc", "Dân tộc", "System.String" });
            dt.Rows.Add(new string[] { "NoiSinh", "Nơi sinh", "System.String" });
            dt.Rows.Add(new string[] { "QueQuan", "Quê quán", "System.String" });
            dt.Rows.Add(new string[] { "ThuongTru", "Thường trú", "System.String" });

            return dt;
        }

        public DataTable AnhXaKhoiLop()
        {
            DataTable dt = CreateTableAnhXa();
            dt.Rows.Add(new string[] { "TenLop", "Tên lớp", "System.String" });
            dt.Rows.Add(new string[] { "TenKhoi", "Tến khối", "System.String" });
            dt.Rows.Add(new string[] { "TenNienKhoa", "Niên khóa", "System.String" });
            return dt;
        }

        public DataTable AnhXaGiaoVien()
        {
            DataTable dt = CreateTableAnhXa();
            dt.Rows.Add(new string[] { "MaGiaoVien", "Mã giáo viên", "System.String" });
            dt.Rows.Add(new string[] { "HoVaTen", "Tên giáo viên", "System.String" });
            dt.Rows.Add(new string[] { "NgaySinh", "Ngày sinh", "System.DateTime" });
            dt.Rows.Add(new string[] { "GioiTinh", "Giới tính", "System.String" });
            dt.Rows.Add(new string[] { "DiaChiThuongTru", "Địa chỉ thường trú", "System.String" });
            dt.Rows.Add(new string[] { "DiaChiNoiO", "Địa chỉ nơi ở", "System.String" });
            dt.Rows.Add(new string[] { "DienThoai", "Số điện thoại", "System.String" });
            dt.Rows.Add(new string[] { "EMail", "Email", "System.String" });
            return dt;
        }

        public DataTable AnhXaMonHoc()
        {
            DataTable dt = CreateTableAnhXa();
            dt.Rows.Add(new string[] { "MaMonHoc", "Mã môn học", "System.String" });
            dt.Rows.Add(new string[] { "TenMonHoc", "Tên môn học", "System.String" });
            dt.Rows.Add(new string[] { "TenVietTat", "Tên viết tắt", "System.String" });
            dt.Rows.Add(new string[] { "SoHocTrinh", "Số đơn vị học trình", "System.Double" });
            dt.Rows.Add(new string[] { "SoTiet", "Số tiết", "System.Int16" });
            dt.Rows.Add(new string[] { "LyThuyet", "Lý thuyết", "System.Int16" });
            dt.Rows.Add(new string[] { "ThucHanh", "Thực hành", "System.Int16" });
            return dt;
        }

        public DataTable AnhXaLoaiDiem()
        {
            DataTable dt = CreateTableAnhXa();
            dt.Rows.Add(new string[] { "KyHieu", "Ký hiệu", "System.String" });
            dt.Rows.Add(new string[] { "TenLoaiDiem", "Tên loại điểm", "System.String" });
            return dt;
        }

        public DataTable AnhXaThanhPhanDiem()
        {
            DataTable dt = CreateTableAnhXa();
            dt.Rows.Add(new string[] { "MaThanhPhanDiem", "Mã thành phần điểm", "System.String" });
            dt.Rows.Add(new string[] { "TenThanhPhanDiem", "Tên thành phần điểm", "System.String" });
            dt.Rows.Add(new string[] { "TenLoaiDiem", "Loại điểm", "System.String" });
            return dt;
        }

        public DataTable AnhXaTinhHuyenXa()
        {
            DataTable dt = CreateTableAnhXa();
            dt.Rows.Add(new string[] { "MaTinhHuyenXa", "Mã", "System.String" });
            dt.Rows.Add(new string[] { "TenTinhHuyenXa", "Tên", "System.String" });
            dt.Rows.Add(new string[] { "MaParent", "Trực thuộc mã", "System.String" });
            return dt;
        }

        public DataTable CreateTableChuyenDuoc(DataTable dtTruongAnhXa, ref Hashtable htb, string ID)
        {
            DataTable dt = new DataTable();
            htb = new Hashtable();
            dt.Columns.Add("@stt", typeof(int));
            if (ID == "SV_SinhVien" || ID == "SV_SinhVienNhapTruong")
            {
                foreach (DataRow dr in dtTruongAnhXa.Rows)
                {
                    if ("" + dr["ID"] != "")
                    {
                        if (dr["ID"].ToString() == "Ho" || dr["ID"].ToString() == "Ten")
                        {
                            htb.Add(dr["ID"].ToString(), dr["TenTruong"].ToString());
                            if (!dt.Columns.Contains("HoVaTen"))
                                dt.Columns.Add("HoVaTen", typeof(string));
                        }
                        else
                        {
                            dt.Columns.Add(dr["ID"].ToString(), typeof(string));
                            htb.Add(dr["ID"].ToString(), dr["TenTruong"].ToString());
                        }
                    }
                }
            }
            else
            {
                foreach (DataRow dr in dtTruongAnhXa.Rows)
                {
                    if ("" + dr["ID"] != "")
                    {
                        dt.Columns.Add(dr["ID"].ToString(), typeof(string));
                        htb.Add(dr["ID"].ToString(), dr["TenTruong"].ToString());
                    }
                }
            }
            return dt;
        }

        public string KiemTraCacTruongBatBuoc(Hashtable htbAnhXa, string KieuNhapDuLieu)
        {
            string str = "";
            switch (KieuNhapDuLieu)
            {
                case "SV_SinhVienNhapTruong":
                    if (!(htbAnhXa.ContainsKey("HoVaTen") || (htbAnhXa.ContainsKey("Ho") && htbAnhXa.ContainsKey("Ten"))))
                    {
                        str = "Bạn chưa chọn trường ánh xạ của Họ và tên";
                    }
                    break;
                case "DTP":
                case "DTK":
                    if (!htbAnhXa.ContainsKey("MaSinhVien"))
                        str = "Bạn chưa chọn trường ánh xạ của Mã sinh viên";
                    break;
                case "SV_SinhVien":
                    if (!(htbAnhXa.ContainsKey("HoVaTen") || (htbAnhXa.ContainsKey("Ho") && htbAnhXa.ContainsKey("Ten"))))
                    {
                        str = "Bạn chưa chọn trường ánh xạ của Họ và tên";
                    }
                    break;
                case "NS_GiaoVien":
                    if (!htbAnhXa.ContainsKey("HoVaTen"))
                        str = "Bạn chưa chọn trường ánh xạ của Họ và tên";
                    break;
                case "DM_MonHoc":
                    //if (!htbAnhXa.ContainsKey("MaMonHoc"))
                    //    str = "Bạn chưa chọn trường ánh xạ của Mã môn học";
                    if (!htbAnhXa.ContainsKey("TenMonHoc"))
                    {
                        if (str != "")
                            str += ", tên môn học";
                        else
                            str = "Bạn chưa chọn trường ánh xạ của tên môn học";
                    }
                    break;
            }
            return str;
        }
        #endregion

        #region Chuyển dữ liệu tuyển sinh
        public void ChuyenDuLieuTuyenSinh(ref DataTable dtDuLieuChuyenDuoc, ref DataTable dtDuLieuKhongChuyenDuoc, DataTable dtDuLieuNguon, Hashtable htb)
        {
            if (!dtDuLieuNguon.Columns.Contains("LyDo"))
                dtDuLieuNguon.Columns.Add("LyDo", typeof(string));
            DataRow drNew;
            bool BoQua;

            DateTime date;
            // Kiểm tra dữ liệu trên file có đúng ko
            if (htb.ContainsKey("HoVaTen"))
            {
                foreach (DataRow dr in dtDuLieuNguon.Rows)
                {
                    BoQua = false;
                    drNew = dtDuLieuChuyenDuoc.NewRow();
                    for (int i = 0; i < dtDuLieuChuyenDuoc.Columns.Count; i++)
                    {
                        if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "HoVaTen")
                        {
                            if ("" + dr[htb["HoVaTen"].ToString()] != "")
                                drNew["HoVaTen"] = dr[htb["HoVaTen"].ToString()].ToString();
                            else
                            {
                                BoQua = true;
                                dr["LyDo"] = "Không có họ tên học sinh.";
                                break;
                            }
                        }
                        else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "NgaySinh")
                        {
                            if ("" + dr[htb["NgaySinh"].ToString()] != "")
                            {
                                if (DateTime.TryParseExact("" + dr[htb["NgaySinh"].ToString()].ToString(), dateFormats, enUS, dateStyle, out date))
                                    drNew["NgaySinh"] = date.Date;
                                else
                                {
                                    BoQua = true;
                                    dr["LyDo"] = "Định dạng ngày sinh không đúng.";
                                    break;
                                }
                            }
                        }
                        else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName != "ID" && dtDuLieuChuyenDuoc.Columns[i].ColumnName != "@stt")
                        {
                            drNew[dtDuLieuChuyenDuoc.Columns[i].ColumnName] = ("" + dr[htb[dtDuLieuChuyenDuoc.Columns[i].ColumnName].ToString()]).Trim();
                        }
                    }

                    // Nếu mã học sinh đang kiểm tra đã có thì cũng ko được
                    if (BoQua)
                    {
                        dtDuLieuKhongChuyenDuoc.ImportRow(dr);
                    }
                    else
                    {
                        dtDuLieuChuyenDuoc.Rows.Add(drNew);
                    }
                }
            }
            else if (htb.ContainsKey("Ho"))
            {
                foreach (DataRow dr in dtDuLieuNguon.Rows)
                {
                    BoQua = false;
                    drNew = dtDuLieuChuyenDuoc.NewRow();
                    for (int i = 0; i < dtDuLieuChuyenDuoc.Columns.Count; i++)
                    {
                        if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "HoVaTen")
                        {
                            if ("" + dr[htb["Ho"].ToString()] != "" || "" + dr[htb["Ten"].ToString()] != "")
                                drNew["HoVaTen"] = ("" + dr[htb["Ho"].ToString()] + " " + dr[htb["Ten"].ToString()]).Trim();
                            else
                            {
                                BoQua = true;
                                dr["LyDo"] = "Không có họ tên sinh viên.";
                                break;
                            }
                        }
                        else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "NgaySinh")
                        {
                            if ("" + dr[htb["NgaySinh"].ToString()] != "")
                            {
                                if (DateTime.TryParseExact("" + dr[htb["NgaySinh"].ToString()].ToString(), dateFormats, enUS, dateStyle, out date))
                                    drNew["NgaySinh"] = date.Date;
                                else
                                {
                                    BoQua = true;
                                    dr["LyDo"] = "Định dạng ngày sinh không đúng.";
                                    break;
                                }
                            }
                        }
                        else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName != "ID" && dtDuLieuChuyenDuoc.Columns[i].ColumnName != "@stt")
                        {
                            drNew[dtDuLieuChuyenDuoc.Columns[i].ColumnName] = ("" + dr[htb[dtDuLieuChuyenDuoc.Columns[i].ColumnName].ToString()]).Trim();
                        }
                    }
                    // Nếu mã học sinh đang kiểm tra đã có thì cũng ko được
                    if (BoQua)
                    {
                        dtDuLieuKhongChuyenDuoc.ImportRow(dr);
                    }
                    else
                    {
                        dtDuLieuChuyenDuoc.Rows.Add(drNew);
                    }
                }
            }
        }

        //public void LuuDuLieuTuyenSinh(ref DataTable dtDuLieuChuyenDuoc, ref DataTable dtDuLieuKhongChuyenDuoc, DataTable dtDuLieuNguon, Hashtable htb, int IDDM_NamHoc)
        //{
        //    cBwsSV_SinhVienNhapTruong cBwsSV_SinhVienNhapTruong = new cBwsSV_SinhVienNhapTruong();
        //    SV_SinhVienNhapTruongInfo pSV_SinhVienNhapTruongInfo;
        //    DataRow[] arrDr;
        //    for (int i = 0; i < dtDuLieuChuyenDuoc.Rows.Count; i++)
        //    {
        //        pSV_SinhVienNhapTruongInfo = new SV_SinhVienNhapTruongInfo();
        //        pSV_SinhVienNhapTruongInfo.IDDM_NamHoc = IDDM_NamHoc;
        //        try
        //        {
        //            cBwsSV_SinhVienNhapTruong.ToInfo(ref pSV_SinhVienNhapTruongInfo, dtDuLieuChuyenDuoc.Rows[i], dtDuLieuChuyenDuoc);
        //            cBwsSV_SinhVienNhapTruong.Add(pSV_SinhVienNhapTruongInfo);
        //        }
        //        catch
        //        {
        //            arrDr = dtDuLieuNguon.Select("@stt = " + dtDuLieuChuyenDuoc.Rows[i]["@stt"]);
        //            if (arrDr.Length > 0)
        //            {
        //                arrDr[0]["LyDo"] = "Có lỗi khi thêm vào Database.";
        //                dtDuLieuKhongChuyenDuoc.ImportRow(arrDr[0]);
        //            }
        //            dtDuLieuChuyenDuoc.Rows.RemoveAt(i);
        //            i--;
        //        }
        //    }
        //}
        #endregion

        #region Nhập danh sách Sinh Viên
        //public void ChuyenDanhSachSinhVien(ref DataTable dtDuLieuChuyenDuoc, ref DataTable dtDuLieuKhongChuyenDuoc, DataTable dtDuLieuNguon, Hashtable htb)
        //{
        //    if (!dtDuLieuNguon.Columns.Contains("LyDo"))
        //        dtDuLieuNguon.Columns.Add("LyDo", typeof(string));
        //    DataRow drNew;
        //    bool BoQua;
        //    string MaSinhVien = "";
        //    // Kiểm tra dữ liệu trên file có đúng ko
        //    if (htb.ContainsKey("HoVaTen"))
        //    {
        //        foreach (DataRow dr in dtDuLieuNguon.Rows)
        //        {
        //            BoQua = false;
        //            drNew = dtDuLieuChuyenDuoc.NewRow();
        //            for (int i = 0; i < dtDuLieuChuyenDuoc.Columns.Count; i++)
        //            {
        //                if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "HoVaTen")
        //                {
        //                    if ("" + dr[htb["HoVaTen"].ToString()] != "")
        //                        drNew["HoVaTen"] = dr[htb["HoVaTen"].ToString()].ToString().Trim();
        //                    else
        //                    {
        //                        BoQua = true;
        //                        dr["LyDo"] = "Không có họ tên sinh viên.";
        //                        break;
        //                    }
        //                }
        //                else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "NgaySinh")
        //                {
        //                    if ("" + dr[htb["NgaySinh"].ToString()] != "")
        //                    {
        //                        DateTime date;
        //                        if (DateTime.TryParseExact(dr[htb["NgaySinh"].ToString()].ToString(), dateFormats, enUS, dateStyle, out date))
        //                            drNew["NgaySinh"] = date.Date;
        //                        else
        //                        {
        //                            BoQua = true;
        //                            dr["LyDo"] = "Định dạng ngày sinh không đúng.";
        //                            break;
        //                        }
        //                    }
        //                }
        //                else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "GioiTinh")
        //                {
        //                    if ("" + dr[htb["GioiTinh"].ToString()] != "")
        //                    { 
        //                        if(dr[htb["GioiTinh"].ToString()].ToString().ToUpper() == "NỮ")
        //                        {
        //                            drNew["GioiTinh"] = "NỮ";
        //                        }
        //                        else
        //                            drNew["GioiTinh"] = "NAM";
        //                    }
        //                }
        //                else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "@stt")
        //                {
        //                    drNew["@stt"] = dr["@stt"];
        //                }
        //                else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName != "ID")
        //                {
        //                    drNew[dtDuLieuChuyenDuoc.Columns[i].ColumnName] = ("" + dr[htb[dtDuLieuChuyenDuoc.Columns[i].ColumnName].ToString()]).Trim();
        //                }
        //            }
        //            // Nếu mã học sinh đang kiểm tra đã có thì cũng ko được
        //            if (htb.ContainsKey("MaSinhVien"))
        //            {
        //                if (!BoQua && ("" + dr[htb["MaSinhVien"].ToString()] != ""))
        //                {
        //                    if (("," + MaSinhVien + ",").IndexOf("," + dr[htb["MaSinhVien"].ToString()] + ",") >= 0)
        //                    {
        //                        BoQua = true;
        //                        dr["LyDo"] = "Trong file đầu vào, mã học sinh này đã bị trùng.";
        //                    }
        //                }
        //            }
        //            if (BoQua)
        //            {
        //                dtDuLieuKhongChuyenDuoc.ImportRow(dr);
        //            }
        //            else
        //            {
        //                dtDuLieuChuyenDuoc.Rows.Add(drNew);
        //                if (htb.ContainsKey("MaSinhVien") && "" + dr[htb["MaSinhVien"].ToString()] != "")
        //                    MaSinhVien += MaSinhVien == "" ? dr[htb["MaSinhVien"].ToString()].ToString() : "," + dr[htb["MaSinhVien"].ToString()];
        //            }
        //        }
        //    }
        //    else if (htb.ContainsKey("Ho"))
        //    {
        //        foreach (DataRow dr in dtDuLieuNguon.Rows)
        //        {
        //            BoQua = false;
        //            drNew = dtDuLieuChuyenDuoc.NewRow();
        //            for (int i = 0; i < dtDuLieuChuyenDuoc.Columns.Count; i++)
        //            {
        //                if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "HoVaTen")
        //                {
        //                    if ("" + dr[htb["Ho"].ToString()] != "" || "" + dr[htb["Ten"].ToString()] != "")
        //                        drNew["HoVaTen"] = (("" + dr[htb["Ho"].ToString()]).Trim() + " " + dr[htb["Ten"].ToString()]).Trim();
        //                    else
        //                    {
        //                        BoQua = true;
        //                        dr["LyDo"] = "Không có họ tên sinh viên.";
        //                        break;
        //                    }
        //                }
        //                else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "NgaySinh")
        //                {
        //                    if ("" + dr[htb["NgaySinh"].ToString()] != "")
        //                    {
        //                        DateTime date;
        //                        if (DateTime.TryParseExact(dr[htb["NgaySinh"].ToString()].ToString(), dateFormats, enUS, dateStyle, out date))
        //                            drNew["NgaySinh"] = date.Date;
        //                        else
        //                        {
        //                            BoQua = true;
        //                            dr["LyDo"] = "Định dạng ngày sinh không đúng.";
        //                            break;
        //                        }
        //                    }
        //                }
        //                else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "GioiTinh")
        //                {
        //                    if ("" + dr[htb["GioiTinh"].ToString()] != "")
        //                    {
        //                        if (dr[htb["GioiTinh"].ToString()].ToString().ToUpper() == "NỮ")
        //                        {
        //                            drNew["GioiTinh"] = "NỮ";
        //                        }
        //                        else
        //                            drNew["GioiTinh"] = "NAM";
        //                    }
        //                }
        //                else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "@stt")
        //                {
        //                    drNew["@stt"] = dr["@stt"];
        //                }
        //                else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName != "ID")
        //                {
        //                    drNew[dtDuLieuChuyenDuoc.Columns[i].ColumnName] = ("" + dr[htb[dtDuLieuChuyenDuoc.Columns[i].ColumnName].ToString()]).Trim();
        //                }
        //            }
        //            // Nếu mã học sinh đang kiểm tra đã có thì cũng ko được
        //            if (htb.ContainsKey("MaSinhVien"))
        //            {
        //                if (!BoQua && ("" + dr[htb["MaSinhVien"].ToString()] != ""))
        //                {
        //                    if (("," + MaSinhVien + ",").IndexOf("," + dr[htb["MaSinhVien"].ToString()] + ",") >= 0)
        //                    {
        //                        BoQua = true;
        //                        dr["LyDo"] = "Trong file đầu vào, mã học sinh này đã bị trùng.";
        //                    }
        //                }
        //            }
        //            if (BoQua)
        //            {
        //                dtDuLieuKhongChuyenDuoc.ImportRow(dr);
        //            }
        //            else
        //            {
        //                dtDuLieuChuyenDuoc.Rows.Add(drNew);
        //                if (htb.ContainsKey("MaSinhVien") && "" + dr[htb["MaSinhVien"].ToString()] != "")
        //                    MaSinhVien += MaSinhVien == "" ? dr[htb["MaSinhVien"].ToString()].ToString() : "," + dr[htb["MaSinhVien"].ToString()];
        //            }
        //        }
        //    }
        //    // Đưa tất cả những mã học sinh có thể import vào để kiểm tra nhập vào DB
        //    if (MaSinhVien != "")
        //    {
        //        cBwsSV_SinhVien oBSV_SinhVien = new cBwsSV_SinhVien();
        //        string MaSinhVienDaTonTai = oBSV_SinhVien.CheckExistByMaSinhVien(MaSinhVien);
        //        if (MaSinhVienDaTonTai != "")
        //        {
        //            string[] arrMaSinhVienDaTonTai = MaSinhVienDaTonTai.Split(',');
        //            DataRow[] drFilter, drFilterNguon;
        //            foreach (string str in arrMaSinhVienDaTonTai)
        //            {
        //                drFilterNguon = dtDuLieuNguon.Select("[" + htb["MaSinhVien"].ToString() + "] = '" + str + "'");
        //                drFilter = dtDuLieuChuyenDuoc.Select("MaSinhVien = '" + str + "'");
        //                if (drFilterNguon.Length > 0)
        //                {
        //                    drFilterNguon[0]["LyDo"] = "Mã học sinh đã tồn tại trong chương trình.";
        //                    dtDuLieuKhongChuyenDuoc.ImportRow(drFilterNguon[0]);
        //                    dtDuLieuChuyenDuoc.Rows.Remove(drFilter[0]);
        //                }
        //            }
        //        }
        //    }
        //}

        //public void LuuDanhSachSinhVien(ref DataTable dtDuLieuChuyenDuoc, ref DataTable dtDuLieuKhongChuyenDuoc, DataTable dtDuLieuNguon, Hashtable htb, int IDDM_Lop)
        //{
        //    cBwsSV_SinhVien oBSV_SinhVien = new cBwsSV_SinhVien();
        //    SV_SinhVienInfo pSV_SinhVienInfo;
        //    cBwsSV_SinhVien_Lop oBSV_SinhVien_Lop = new cBwsSV_SinhVien_Lop();
        //    SV_SinhVien_LopInfo pSV_SinhVien_LopInfo = new SV_SinhVien_LopInfo();
        //    pSV_SinhVien_LopInfo.IDDM_Lop = IDDM_Lop;
        //    pSV_SinhVien_LopInfo.TrangThaiSinhVien = (int)TRANGTHAISINHVIEN.DANGHOC;
        //    DataRow[] arrDr;
        //    for (int i = 0; i < dtDuLieuChuyenDuoc.Rows.Count; i++)
        //    {
        //        if ("" + dtDuLieuChuyenDuoc.Rows[i]["HoVaTen"] != "")
        //        {
        //            pSV_SinhVienInfo = new SV_SinhVienInfo();
        //            try
        //            {
        //                oBSV_SinhVien.ToInfo(ref pSV_SinhVienInfo, dtDuLieuChuyenDuoc.Rows[i], dtDuLieuChuyenDuoc);
        //                pSV_SinhVien_LopInfo.IDSV_SinhVien = oBSV_SinhVien.Add(pSV_SinhVienInfo);
        //                oBSV_SinhVien_Lop.Add(pSV_SinhVien_LopInfo);
        //            }
        //            catch
        //            {
        //                arrDr = dtDuLieuNguon.Select("@stt = " + dtDuLieuChuyenDuoc.Rows[i]["@stt"]);
        //                if (arrDr.Length > 0)
        //                {
        //                    arrDr[0]["LyDo"] = "Có lỗi khi thêm vào Database.";
        //                    dtDuLieuKhongChuyenDuoc.ImportRow(arrDr[0]);
        //                }
        //                dtDuLieuChuyenDuoc.Rows.RemoveAt(i);
        //                i--;
        //            }
        //        }
        //        else
        //        {
        //            arrDr = dtDuLieuNguon.Select("@stt = " + dtDuLieuChuyenDuoc.Rows[i]["@stt"]);
        //            if (arrDr.Length > 0)
        //            {
        //                arrDr[0]["LyDo"] = "Không có mã học sinh.";
        //                dtDuLieuKhongChuyenDuoc.ImportRow(arrDr[0]);
        //            }
        //            dtDuLieuChuyenDuoc.Rows.RemoveAt(i);
        //            i--;
        //        }
        //    }
        //}

        //public void LuuDanhSachHocSinh(ref DataTable dtDuLieuChuyenDuoc, ref DataTable dtDuLieuKhongChuyenDuoc, DataTable dtDuLieuNguon,
        //    Hashtable htb, int IDDM_Lop, int IDDM_TRUONG, int DoDaiMa, int DoDaiTuTang, string MaBatDauTu, string PhanDauMa, string PhanCuoiMa)
        //{
        //    cBSV_SinhVien oBSV_SinhVien = new cBSV_SinhVien();
        //    SV_SinhVienInfo pSV_SinhVienInfo;
        //    cBSV_SinhVien_Lop oBSV_SinhVien_Lop = new cBSV_SinhVien_Lop();
        //    SV_SinhVien_LopInfo pSV_SinhVien_LopInfo = new SV_SinhVien_LopInfo();
        //    pSV_SinhVien_LopInfo.IDDM_Lop = IDDM_Lop;
        //    pSV_SinhVien_LopInfo.TrangThaiSinhVien = (int)TRANGTHAISINHVIEN.DANGHOC;
        //    DataRow[] arrDr;
        //    string MaSinhVien = "";
        //    for (int i = 0; i < dtDuLieuChuyenDuoc.Rows.Count; i++)
        //    {
        //        pSV_SinhVienInfo = new SV_SinhVienInfo();
        //        try
        //        {
        //            oBSV_SinhVien.ToInfo(ref pSV_SinhVienInfo, dtDuLieuChuyenDuoc.Rows[i], dtDuLieuChuyenDuoc);
        //            pSV_SinhVien_LopInfo.IDSV_SinhVien = oBSV_SinhVien.AddSinhMaTuDong(pSV_SinhVienInfo, ref MaSinhVien, DoDaiMa, DoDaiTuTang, MaBatDauTu, PhanDauMa, PhanCuoiMa);
        //            dtDuLieuChuyenDuoc.Rows[i]["MaSinhVien"] = MaSinhVien;
        //            oBSV_SinhVien_Lop.Add(pSV_SinhVien_LopInfo);
        //        }
        //        catch
        //        {
        //            arrDr = dtDuLieuNguon.Select("[" + htb["MaSinhVien"].ToString() + "]='" + dtDuLieuChuyenDuoc.Rows[i]["MaSinhVien"] + "' And " + htb["HoVaTen"] + "= '" + dtDuLieuChuyenDuoc.Rows[i]["HoVaTen"] + "'");
        //            if (arrDr.Length > 0)
        //            {
        //                arrDr[0]["LyDo"] = "Có lỗi khi thêm vào Database.";
        //                dtDuLieuKhongChuyenDuoc.ImportRow(arrDr[0]);
        //            }
        //            dtDuLieuChuyenDuoc.Rows.RemoveAt(i);
        //            i--;
        //        }
        //    }
        //}
        #endregion

        /*
        #region Nhập danh sách Lớp
        public void ChuyenDanhSachLop(ref DataTable dtDuLieuChuyenDuoc, ref DataTable dtDuLieuKhongChuyenDuoc, DataTable dtDuLieuNguon, Hashtable htb, int IDDM_NamHoc_Truong)
        { 
            if (!dtDuLieuNguon.Columns.Contains("LyDo"))
                dtDuLieuNguon.Columns.Add("LyDo", typeof(string));
            DataRow drNew;
            bool BoQua;
            string TenLops = "", TenKhois = "", TenNienKhoas = "";

            cBwsDM_KHOI_LOP oBDM_Khoi_Lop = new cBwsDM_KHOI_LOP();
            DM_KHOI_LOPInfo pDM_Khoi_LopInfo = new DM_KHOI_LOPInfo();
            pDM_Khoi_LopInfo.IDDM_NAMHOC_TRUONG = IDDM_NamHoc_Truong;
            // Kiểm tra dữ liệu trên file có đúng ko
            foreach (DataRow dr in dtDuLieuNguon.Rows)
            {
                BoQua = false;
                drNew = dtDuLieuChuyenDuoc.NewRow();
                for (int i = 0; i < dtDuLieuChuyenDuoc.Columns.Count; i++)
                {
                    if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "TenKhoi")
                    {
                        if ("" + dr[htb["TenKhoi"].ToString()] != "")
                            drNew["TenKhoi"] = dr[htb["TenKhoi"].ToString()].ToString();
                        else
                        {
                            BoQua = true;
                            dr["LyDo"] = "Không có tên khối.";
                            break;
                        }
                    }
                    else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "TenLop")
                    {
                        if ("" + dr[htb["TenLop"].ToString()] != "")
                            drNew["TenLop"] = dr[htb["TenLop"].ToString()].ToString();
                        else
                        {
                            BoQua = true;
                            dr["LyDo"] = "Không có tên lớp.";
                            break;
                        }
                    }
                    else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "TenNienKhoa")
                    {
                        if ("" + dr[htb["TenNienKhoa"].ToString()] != "")
                            drNew["TenNienKhoa"] = dr[htb["TenNienKhoa"].ToString()].ToString();
                        else
                        {
                            BoQua = true;
                            dr["LyDo"] = "Không có tên niên khóa.";
                            break;
                        }
                    }
                }
                // Nếu tên lớp thuộc khối đang kiểm tra đã có thì cũng ko được
                if (!BoQua)
                {
                    if (("," + TenLops + ",").IndexOf("," + dr[htb["TenLop"].ToString()] + ",") >= 0)
                    {
                        BoQua = true;
                        dr["LyDo"] = "Trong file đầu vào, tên lớp này đã bị trùng.";
                    }
                }
                if (BoQua)
                {
                    dtDuLieuKhongChuyenDuoc.ImportRow(dr);
                }
                else
                {
                    dtDuLieuChuyenDuoc.Rows.Add(drNew);
                    TenLops += TenLops == "" ? dr[htb["TenLop"].ToString()].ToString() : "," + dr[htb["TenLop"].ToString()];
                    TenKhois += TenKhois == "" ? dr[htb["TenKhoi"].ToString()].ToString() : "," + dr[htb["TenKhoi"].ToString()];
                    TenNienKhoas += TenNienKhoas == "" ? dr[htb["TenNienKhoa"].ToString()].ToString() : "," + dr[htb["TenNienKhoa"].ToString()];
                }
            }
            // Đưa tất cả những tên lớp có thể import vào để kiểm tra nhập vào DB
            if (TenLops != "")
            {
                string KhoiLopDaTonTai = oBDM_Khoi_Lop.CheckExistByKhoiLop(pDM_Khoi_LopInfo, TenLops, TenKhois, TenNienKhoas);
                if (KhoiLopDaTonTai != "")
                {
                    string[] arrKhoiLopDaTonTai = KhoiLopDaTonTai.Split(',');
                    DataRow[] drFilter, drFilterNguon;
                    foreach (string str in arrKhoiLopDaTonTai)
                    {
                        drFilterNguon = dtDuLieuNguon.Select("[" + htb["TenLop"] + "] = '" + str + "'");
                        drFilter = dtDuLieuChuyenDuoc.Select("TenLop = '" + str + "'");
                        if (drFilterNguon.Length > 0)
                        {
                            drFilterNguon[0]["LyDo"] = "Tên lớp đã tồn tại trong chương trình.";
                            dtDuLieuKhongChuyenDuoc.ImportRow(drFilterNguon[0]);
                            dtDuLieuChuyenDuoc.Rows.Remove(drFilter[0]);
                        }
                    }
                }
            }
        }

        public void LuuDanhSachLop(ref DataTable dtDuLieuChuyenDuoc, ref DataTable dtDuLieuKhongChuyenDuoc, DataTable dtDuLieuNguon, Hashtable htb, int IDDM_NamHoc_Truong, int IDDM_Truong)
        {
            cBwsDM_KHOI_LOP oBDM_Khoi_Lop = new cBwsDM_KHOI_LOP();
            cBwsDM_LOP oBDM_Lop = new cBwsDM_LOP();
            DM_LOPInfo pDM_LopInfo = new DM_LOPInfo();
            pDM_LopInfo.IDDM_TRUONG = IDDM_Truong;

            DM_KHOI_LOPInfo pDM_Khoi_LopInfo = new DM_KHOI_LOPInfo();
            pDM_Khoi_LopInfo.IDDM_NAMHOC_TRUONG = IDDM_NamHoc_Truong;

            DataRow[] arrDr;
            for (int i = 0; i < dtDuLieuChuyenDuoc.Rows.Count; i++)
            {
                try
                {
                    pDM_Khoi_LopInfo.IDDM_LOP = oBDM_Lop.AddByImport(pDM_LopInfo, dtDuLieuChuyenDuoc.Rows[i]["TenNienKhoa"].ToString());
                    pDM_Khoi_LopInfo.TENLOP = dtDuLieuChuyenDuoc.Rows[i]["TenLop"].ToString();
                    oBDM_Khoi_Lop.AddByImport(pDM_Khoi_LopInfo, dtDuLieuChuyenDuoc.Rows[i]["TenKhoi"].ToString(), IDDM_Truong);
                }
                catch
                {
                    arrDr = dtDuLieuNguon.Select("[" + htb["TenLop"].ToString() + "]='" + dtDuLieuChuyenDuoc.Rows[i]["TenLop"] + "' And [" + htb["TenKhoi"] + "]='" + dtDuLieuChuyenDuoc.Rows[i]["TenKhoi"] + "'");
                    if (arrDr.Length > 0)
                    {
                        arrDr[0]["LyDo"] = "Có lỗi khi thêm vào Database.";
                        dtDuLieuKhongChuyenDuoc.ImportRow(arrDr[0]);
                    }
                    dtDuLieuChuyenDuoc.Rows.RemoveAt(i);
                    i--;
                }
            }
        }
        #endregion
        */
        #region Nhập danh sách Giáo viên
        public void ChuyenDanhSachGiaoVien(ref DataTable dtDuLieuChuyenDuoc, ref DataTable dtDuLieuKhongChuyenDuoc, DataTable dtDuLieuNguon, Hashtable htb)
        {
            if (!dtDuLieuNguon.Columns.Contains("LyDo"))
                dtDuLieuNguon.Columns.Add("LyDo", typeof(string));
            DataRow drNew;
            bool BoQua;
            string MaGiaoVien = "";
            // Kiểm tra dữ liệu trên file có đúng ko
            foreach (DataRow dr in dtDuLieuNguon.Rows)
            {
                BoQua = false;
                drNew = dtDuLieuChuyenDuoc.NewRow();
                for (int i = 0; i < dtDuLieuChuyenDuoc.Columns.Count; i++)
                {
                    //if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "MaGiaoVien")
                    //{
                    //    if ("" + dr[htb["MaGiaoVien"].ToString()] != "")
                    //        drNew["MaGiaoVien"] = dr[htb["MaGiaoVien"].ToString()].ToString();
                    //    else
                    //    {
                    //        BoQua = true;
                    //        dr["LyDo"] = "Không có mã giáo viên.";
                    //        break;
                    //    }
                    //}
                    //else 
                    if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "HoVaTen")
                    {
                        if ("" + dr[htb["HoVaTen"].ToString()] != "")
                            drNew["HoVaTen"] = dr[htb["HoVaTen"].ToString()].ToString();
                        else
                        {
                            BoQua = true;
                            dr["LyDo"] = "Không có họ tên giáo viên.";
                            break;
                        }
                    }
                    else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "NgaySinh")
                    {
                        if ("" + dr[htb["NgaySinh"].ToString()] != "")
                        {
                            DateTime date;
                            if (DateTime.TryParseExact(dr[htb["NgaySinh"].ToString()].ToString(), dateFormats, enUS, dateStyle, out date))
                                drNew["NgaySinh"] = date.Date;
                            else
                            {
                                BoQua = true;
                                dr["LyDo"] = "Định dạng ngày sinh không đúng.";
                                break;
                            }
                        }
                    }
                    else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "@stt")
                    {
                        drNew["@stt"] = dr["@stt"];
                    }
                    else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName != "ID")
                    {
                        drNew[dtDuLieuChuyenDuoc.Columns[i].ColumnName] = ("" + dr[htb[dtDuLieuChuyenDuoc.Columns[i].ColumnName].ToString()]).Trim();
                    }
                }
                // Nếu mã giáo viên đang kiểm tra đã có thì cũng ko được
                if (!BoQua)
                {
                    if (htb.ContainsKey("MaGiaoVien"))
                        if (("," + MaGiaoVien + ",").IndexOf("," + dr[htb["MaGiaoVien"].ToString()] + ",") >= 0)
                        {
                            BoQua = true;
                            dr["LyDo"] = "Trong file đầu vào, mã giáo viên này đã bị trùng.";
                        }
                }
                if (BoQua)
                {
                    dtDuLieuKhongChuyenDuoc.ImportRow(dr);
                }
                else
                {
                    dtDuLieuChuyenDuoc.Rows.Add(drNew);
                    if (htb.ContainsKey("MaGiaoVien"))
                        if ("" + dr[htb["MaGiaoVien"].ToString()] != "")
                            MaGiaoVien += MaGiaoVien == "" ? dr[htb["MaGiaoVien"].ToString()].ToString() : "," + dr[htb["MaGiaoVien"].ToString()];
                }
            }
            // Đưa tất cả những mã giáo viên có thể import vào để kiểm tra nhập vào DB
            if (MaGiaoVien != "")
            {
                cBwsNS_GiaoVien oBNS_GiaoVien = new cBwsNS_GiaoVien();
                string MaGiaoVienDaTonTai = oBNS_GiaoVien.CheckExistByMaGiaoViens(MaGiaoVien);
                if (MaGiaoVienDaTonTai != "")
                {
                    string[] arrMaGiaoVienDaTonTai = MaGiaoVienDaTonTai.Split(',');
                    DataRow[] drFilter, drFilterNguon;
                    foreach (string str in arrMaGiaoVienDaTonTai)
                    {
                        drFilterNguon = dtDuLieuNguon.Select("[" + htb["MaGiaoVien"].ToString() + "] = '" + str + "'");
                        drFilter = dtDuLieuChuyenDuoc.Select("MaGiaoVien = '" + str + "'");
                        if (drFilterNguon.Length > 0)
                        {
                            drFilterNguon[0]["LyDo"] = "Mã giáo viên đã tồn tại trong chương trình.";
                            dtDuLieuKhongChuyenDuoc.ImportRow(drFilterNguon[0]);
                            dtDuLieuChuyenDuoc.Rows.Remove(drFilter[0]);
                        }
                    }
                }
            }
        }

        //public void LuuDanhSachGiaoVien(ref DataTable dtDuLieuChuyenDuoc, ref DataTable dtDuLieuKhongChuyenDuoc, DataTable dtDuLieuNguon, Hashtable htb, int IDNS_DonVi)
        //{
        //    cBwsNS_GiaoVien oBNS_GiaoVien = new cBwsNS_GiaoVien();
        //    NS_GiaoVienInfo pNS_GiaoVienInfo = new NS_GiaoVienInfo();

        //    DataRow[] arrDr;
        //    for (int i = 0; i < dtDuLieuChuyenDuoc.Rows.Count; i++)
        //    {
        //        try
        //        {
        //            oBNS_GiaoVien.ToInfo(ref pNS_GiaoVienInfo, dtDuLieuChuyenDuoc.Rows[i], dtDuLieuChuyenDuoc);
        //            pNS_GiaoVienInfo.IDNS_DonVi = IDNS_DonVi;
        //            pNS_GiaoVienInfo.TrangThaiGiaoVien = 1;
        //            oBNS_GiaoVien.Add(pNS_GiaoVienInfo);
        //        }
        //        catch
        //        {
        //            arrDr = dtDuLieuNguon.Select("@stt = " + dtDuLieuChuyenDuoc.Rows[i]["@stt"]);
        //            if (arrDr.Length > 0)
        //            {
        //                arrDr[0]["LyDo"] = "Có lỗi khi thêm vào Database.";
        //                dtDuLieuKhongChuyenDuoc.ImportRow(arrDr[0]);
        //            }
        //            dtDuLieuChuyenDuoc.Rows.RemoveAt(i);
        //            i--;
        //        }
        //    }
        //}

        //public void LuuDanhSachGiaoVien(ref DataTable dtDuLieuChuyenDuoc, ref DataTable dtDuLieuKhongChuyenDuoc, 
        //    DataTable dtDuLieuNguon, Hashtable htb, int IDDM_DonVi, long DoDaiTuTang, string MaBatDauTu, string PhanDauMa, string PhanCuoiMa)
        //{
        //    cBNS_GiaoVien oBGV_GiaoVien = new cBNS_GiaoVien();
        //    NS_GiaoVienInfo pNS_GiaoVienInfo = new NS_GiaoVienInfo();

        //    DataRow[] arrDr;
        //    for (int i = 0; i < dtDuLieuChuyenDuoc.Rows.Count; i++)
        //    {
        //        if ("" + dtDuLieuChuyenDuoc.Rows[i]["MaGiaoVien"] != "")
        //        {
        //            try
        //            {
        //                oBGV_GiaoVien.ToInfo(ref pNS_GiaoVienInfo, dtDuLieuChuyenDuoc.Rows[i], dtDuLieuChuyenDuoc);
        //                pNS_GiaoVienInfo.IDDM_DONVI = IDDM_DonVi;
        //                oBGV_GiaoVien.Add(pNS_GiaoVienInfo);
        //            }
        //            catch
        //            {
        //                arrDr = dtDuLieuNguon.Select("[" + htb["MaGiaoVien"].ToString() + "]='" + dtDuLieuChuyenDuoc.Rows[i]["MaGiaoVien"] + "'");
        //                if (arrDr.Length > 0)
        //                {
        //                    arrDr[0]["LyDo"] = "Có lỗi khi thêm vào Database.";
        //                    dtDuLieuKhongChuyenDuoc.ImportRow(arrDr[0]);
        //                }
        //                dtDuLieuChuyenDuoc.Rows.RemoveAt(i);
        //                i--;
        //            }
        //        }
        //        else
        //        {
        //            arrDr = dtDuLieuNguon.Select("[" + htb["HoVaTen"].ToString() + "]='" + dtDuLieuChuyenDuoc.Rows[i]["HoVaTen"] + "'");
        //            if (arrDr.Length > 0)
        //            {
        //                arrDr[0]["LyDo"] = "Không có mã giáo viên.";
        //                dtDuLieuKhongChuyenDuoc.ImportRow(arrDr[0]);
        //            }
        //            dtDuLieuChuyenDuoc.Rows.RemoveAt(i);
        //            i--;
        //        }
        //    }
        //}
        #endregion

        #region Nhập danh sách Môn học
        public void ChuyenDanhSachMonHoc(ref DataTable dtDuLieuChuyenDuoc, ref DataTable dtDuLieuKhongChuyenDuoc, DataTable dtDuLieuNguon, Hashtable htb)
        {
            if (!dtDuLieuNguon.Columns.Contains("LyDo"))
                dtDuLieuNguon.Columns.Add("LyDo", typeof(string));
            DataRow drNew;
            bool BoQua;
            string MaMonHoc = "", CheckTrung = "";
            int SoTiet;
            double SoThuc;
            // Kiểm tra dữ liệu trên file có đúng ko
            foreach (DataRow dr in dtDuLieuNguon.Rows)
            {
                BoQua = false;
                drNew = dtDuLieuChuyenDuoc.NewRow();
                for (int i = 0; i < dtDuLieuChuyenDuoc.Columns.Count; i++)
                {
                    if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "MaMonHoc")
                    {
                        CheckTrung = "MaMonHoc";
                        if ("" + dr[htb["MaMonHoc"].ToString()] != "")
                            drNew["MaMonHoc"] = dr[htb["MaMonHoc"].ToString()].ToString();
                        else
                        {
                            BoQua = true;
                            dr["LyDo"] = "Không có mã học sinh.";
                            break;
                        }
                    }
                    else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "TenMonHoc")
                    {
                        if (CheckTrung == "")
                            CheckTrung = "TenMonHoc";
                        if ("" + dr[htb["TenMonHoc"].ToString()] != "")
                            drNew["TenMonHoc"] = dr[htb["TenMonHoc"].ToString()].ToString();
                        else
                        {
                            BoQua = true;
                            dr["LyDo"] = "Không có tên môn học.";
                            break;
                        }
                    }
                    else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "SoTiet")
                    {
                        if ("" + dr[htb["SoTiet"].ToString()] != "")
                        {
                            if (int.TryParse(dr[htb["SoTiet"].ToString()].ToString(), out SoTiet))
                            {
                                drNew["SoTiet"] = SoTiet;
                            }
                            else
                            {
                                BoQua = true;
                                dr["LyDo"] = "Số tiết không đúng kiểu số nguyên.";
                                break;
                            }
                        }
                    }
                    else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "LyThuyet")
                    {
                        if ("" + dr[htb["LyThuyet"].ToString()] != "")
                        {
                            if (int.TryParse(dr[htb["LyThuyet"].ToString()].ToString(), out SoTiet))
                            {
                                drNew["LyThuyet"] = SoTiet;
                            }
                            else
                            {
                                BoQua = true;
                                dr["LyDo"] = "Số tiết lý thuyết không đúng kiểu số nguyên.";
                                break;
                            }
                        }
                    }
                    else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "ThucHanh")
                    {
                        if ("" + dr[htb["ThucHanh"].ToString()] != "")
                        {
                            if (int.TryParse(dr[htb["ThucHanh"].ToString()].ToString(), out SoTiet))
                            {
                                drNew["ThucHanh"] = SoTiet;
                            }
                            else
                            {
                                BoQua = true;
                                dr["LyDo"] = "Số tiết thực hành không đúng kiểu số nguyên.";
                                break;
                            }
                        }
                    }
                    else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "SoHocTrinh")
                    {
                        if ("" + dr[htb["SoHocTrinh"].ToString()] != "")
                        {
                            if (double.TryParse(dr[htb["SoHocTrinh"].ToString()].ToString(), out SoThuc))
                            {
                                drNew["SoHocTrinh"] = Math.Round(SoThuc, 1);
                            }
                            else
                            {
                                BoQua = true;
                                dr["LyDo"] = "Số học trình không đúng kiểu số.";
                                break;
                            }
                        }
                    }
                    else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "@stt")
                    {
                        drNew["@stt"] = dr["@stt"];
                    }
                    else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName != "ID")
                    {
                        drNew[dtDuLieuChuyenDuoc.Columns[i].ColumnName] = ("" + dr[htb[dtDuLieuChuyenDuoc.Columns[i].ColumnName].ToString()]).Trim();
                    }
                }
                // Nếu mã học sinh đang kiểm tra đã có thì cũng ko được
                if (!BoQua)
                {
                    if (("," + MaMonHoc + ",").IndexOf("," + dr[htb[CheckTrung].ToString()] + ",") >= 0)
                    {
                        BoQua = true;
                        dr["LyDo"] = "Trong file đầu vào, mã môn học hoặc tên môn học này đã bị trùng.";
                    }
                }
                if (BoQua)
                {
                    dtDuLieuKhongChuyenDuoc.ImportRow(dr);
                }
                else
                {
                    dtDuLieuChuyenDuoc.Rows.Add(drNew);
                    MaMonHoc += MaMonHoc == "" ? dr[htb[CheckTrung].ToString()].ToString().Trim() : "," + dr[htb[CheckTrung].ToString()].ToString().Trim();
                }
            }
            // Đưa tất cả những mã học sinh có thể import vào để kiểm tra nhập vào DB
            if (MaMonHoc != "")
            {
                cDDM_MonHoc oDDM_MonHoc = new cDDM_MonHoc();
                var client = new UnimOsServiceClient();
                string MaMonHocDaTonTai = client.cDDM_MonHoc_CheckExistByMaMonHoc(GlobalVar.MaXacThuc, MaMonHoc, CheckTrung == "MaMonHoc" ? true : false);
                client.Close();
                if (MaMonHocDaTonTai != "")
                {
                    string[] arrMaMonHocDaTonTai = MaMonHocDaTonTai.Split(',');
                    DataRow[] drFilter, drFilterNguon;
                    foreach (string str in arrMaMonHocDaTonTai)
                    {
                        drFilterNguon = dtDuLieuNguon.Select("[" + htb[CheckTrung] + "] = '" + str + "'");
                        drFilter = dtDuLieuChuyenDuoc.Select(CheckTrung + " = '" + str + "'");
                        if (drFilterNguon.Length > 0)
                        {
                            drFilterNguon[0]["LyDo"] = (CheckTrung == "MaMonHoc" ? "Mã môn học" : "Tên môn học") + " đã tồn tại trong chương trình.";
                            dtDuLieuKhongChuyenDuoc.ImportRow(drFilterNguon[0]);
                            dtDuLieuChuyenDuoc.Rows.Remove(drFilter[0]);
                        }
                    }
                }
            }
        }

        public void LuuDanhSachMonHoc(ref DataTable dtDuLieuChuyenDuoc, ref DataTable dtDuLieuKhongChuyenDuoc, DataTable dtDuLieuNguon, Hashtable htb)
        {
            cBwsDM_MonHoc oBDM_MonHoc = new cBwsDM_MonHoc();
            DM_MonHocInfo pDM_MonHocInfo = new DM_MonHocInfo();
            DataRow[] arrDr;
            string Error = "";
            for (int i = 0; i < dtDuLieuChuyenDuoc.Rows.Count; i++)
            {
                try
                {
                    if (Error == "")
                    {
                        oBDM_MonHoc.ToInfo(ref pDM_MonHocInfo, dtDuLieuChuyenDuoc.Rows[i], dtDuLieuChuyenDuoc);
                        int ID = oBDM_MonHoc.AddByImport(pDM_MonHocInfo, ref Error);
                    }

                    if (Error != "")
                    {
                        arrDr = dtDuLieuNguon.Select("@stt = " + dtDuLieuChuyenDuoc.Rows[i]["@stt"]);
                        if (arrDr.Length > 0)
                        {
                            arrDr[0]["LyDo"] = Error;
                            dtDuLieuKhongChuyenDuoc.ImportRow(arrDr[0]);
                        }
                        dtDuLieuChuyenDuoc.Rows.RemoveAt(i);
                        i--;
                    }
                }
                catch
                {
                    arrDr = dtDuLieuNguon.Select("@stt = " + dtDuLieuChuyenDuoc.Rows[i]["@stt"]);
                    if (arrDr.Length > 0)
                    {
                        arrDr[0]["LyDo"] = "Có lỗi khi thêm vào Database.";
                        dtDuLieuKhongChuyenDuoc.ImportRow(arrDr[0]);
                    }
                    dtDuLieuChuyenDuoc.Rows.RemoveAt(i);
                    i--;
                }
            }
        }
        #endregion

        #region Nhập Điểm thành phần
        public void ChuyenDiemThanhPhan(ref DataTable dtDuLieuChuyenDuoc, ref DataTable dtDuLieuKhongChuyenDuoc, DataTable dtDuLieuNguon, Hashtable htb)
        {
            if (!dtDuLieuNguon.Columns.Contains("LyDo"))
                dtDuLieuNguon.Columns.Add("LyDo", typeof(string));
            DataRow drNew;
            bool BoQua, CoDiem;
            string MaSinhVien = "";
            double diem;
            // Kiểm tra dữ liệu trên file có đúng ko
            foreach (DataRow dr in dtDuLieuNguon.Rows)
            {
                BoQua = false;
                CoDiem = false;
                drNew = dtDuLieuChuyenDuoc.NewRow();
                for (int i = 0; i < dtDuLieuChuyenDuoc.Columns.Count; i++)
                {
                    if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "MaSinhVien")
                    {
                        if ("" + dr[htb["MaSinhVien"].ToString()] != "")
                            drNew["MaSinhVien"] = dr[htb["MaSinhVien"].ToString()].ToString();
                        else
                        {
                            BoQua = true;
                            dr["LyDo"] = "Không có mã học sinh.";
                            break;
                        }
                    }
                    else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "@stt")
                    {
                        drNew["@stt"] = dr["@stt"];
                    }
                    else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName != "ID")// && dtDuLieuChuyenDuoc.Columns[i].ColumnName != "@stt")
                    {
                        if (dtDuLieuChuyenDuoc.Columns[i].ColumnName != "HoVaTen" && dtDuLieuChuyenDuoc.Columns[i].ColumnName != "TenLop")
                        {
                            if (("" + dr[htb[dtDuLieuChuyenDuoc.Columns[i].ColumnName].ToString()]).Trim() != "")
                            {
                                if (double.TryParse(("" + dr[htb[dtDuLieuChuyenDuoc.Columns[i].ColumnName].ToString()]).Trim(), out diem))
                                {
                                    if (0 <= diem && diem <= 10.0)
                                    {
                                        drNew[dtDuLieuChuyenDuoc.Columns[i].ColumnName] = diem;
                                        CoDiem = true;
                                    }
                                    //else
                                    //{
                                    //    BoQua = true;
                                    //    dr["LyDo"] = "Dữ liệu điểm cột '" + htb[dtDuLieuChuyenDuoc.Columns[i].ColumnName] + "' vượt quá giới hạn về điểm.";
                                    //    break;
                                    //}
                                }
                                //else
                                //{
                                //    BoQua = true;
                                //    dr["LyDo"] = "Dữ liệu điểm cột '" + htb[dtDuLieuChuyenDuoc.Columns[i].ColumnName] + "' không đúng định dạng kiểu số.";
                                //    break;
                                //}
                            }
                        }
                    }
                }
                // Nếu mã học sinh đang kiểm tra đã có thì cũng ko được
                if (!BoQua)
                {
                    if (("," + MaSinhVien + ",").IndexOf("," + dr[htb["MaSinhVien"].ToString()] + ",") >= 0)
                    {
                        BoQua = true;
                        dr["LyDo"] = "Trong file đầu vào, mã học sinh này đã bị trùng.";
                    }
                }
                if (!CoDiem && !BoQua)
                {
                    BoQua = true;
                    dr["LyDo"] = "Dữ liệu điểm của hàng này không có.";
                }
                if (BoQua)
                {
                    dtDuLieuKhongChuyenDuoc.ImportRow(dr);
                }
                else
                {
                    dtDuLieuChuyenDuoc.Rows.Add(drNew);
                    MaSinhVien += MaSinhVien == "" ? dr[htb["MaSinhVien"].ToString()].ToString() : "," + dr[htb["MaSinhVien"].ToString()];
                }
            }
            // Đưa tất cả những mã học sinh có thể import vào để kiểm tra nhập vào DB
            if (MaSinhVien != "")
            {
                cBwsSV_SinhVien oBSV_SinhVien = new cBwsSV_SinhVien();

                string HoVaTens = "", TenLops = "";
                string MaSinhVienDaTonTai = oBSV_SinhVien.CheckExistAndGetInfo(MaSinhVien, ref HoVaTens, ref TenLops);
                string[] arrMaSinhVien = MaSinhVien.Split(','), arrHoVaTen = HoVaTens.Split(','), arrTenLop = TenLops.Split(',');
                DataRow[] drFilter, drFilterNguon;
                int idx = 0;
                foreach (string str in arrMaSinhVien)
                {
                    // Nếu những mã học sinh đã tồn tại không có mã str thì tức là mã học sinh này không tồn tại.
                    // Nếu ngược lại thì sẽ gán họ tên và lớp của học sinh đó vào bảng dữ liệu chuyển được
                    if (("," + MaSinhVienDaTonTai + ",").IndexOf("," + str + ",") < 0)
                    {
                        drFilterNguon = dtDuLieuNguon.Select("[" + htb["MaSinhVien"].ToString() + "] = '" + str + "'");
                        if (drFilterNguon.Length > 0)
                        {
                            drFilter = dtDuLieuChuyenDuoc.Select("MaSinhVien = '" + str + "'");
                            drFilterNguon[0]["LyDo"] = "Mã học sinh này không tồn tại trong chương trình.";
                            dtDuLieuKhongChuyenDuoc.ImportRow(drFilterNguon[0]);
                            dtDuLieuChuyenDuoc.Rows.Remove(drFilter[0]);
                        }
                    }
                    else
                    {
                        drFilter = dtDuLieuChuyenDuoc.Select("MaSinhVien = '" + str + "'");
                        drFilter[0]["HoVaTen"] = arrHoVaTen[idx];
                        drFilter[0]["TenLop"] = arrTenLop[idx];
                        idx++;
                    }
                }
            }
        }

        public void LuuDiemThanhPhan(ref DataTable dtDuLieuChuyenDuoc, ref DataTable dtDuLieuKhongChuyenDuoc, DataTable dtDuLieuNguon, Hashtable htb, int IDXL_MonHocTrongKy, int LanThi, int IDDM_NamHoc, int HocKy, int IDGV_GiaoVien)
        {
            cBwsKQHT_DiemThanhPhan oBKQHT_DiemThanhPhan = new cBwsKQHT_DiemThanhPhan();
            KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo = new KQHT_DiemThanhPhanInfo();
            pKQHT_DiemThanhPhanInfo.IDDM_NamHoc = IDDM_NamHoc;
            pKQHT_DiemThanhPhanInfo.HocKy = HocKy;
            pKQHT_DiemThanhPhanInfo.IDXL_MonHocTrongKy = IDXL_MonHocTrongKy;
            pKQHT_DiemThanhPhanInfo.IDHT_User = IDGV_GiaoVien;

            DataRow[] arrDr;
            for (int i = 0; i < dtDuLieuChuyenDuoc.Rows.Count; i++)
            {
                try
                {
                    for (int j = 0; j < dtDuLieuChuyenDuoc.Columns.Count; j++)
                    {
                        if (dtDuLieuChuyenDuoc.Columns[j].ColumnName.IndexOf("C_") >= 0)
                        {
                            pKQHT_DiemThanhPhanInfo.IDKQHT_ThanhPhanDiem = int.Parse(dtDuLieuChuyenDuoc.Columns[j].ColumnName.Substring(2,
                                    dtDuLieuChuyenDuoc.Columns[j].ColumnName.Length - 2));
                            if ("" + dtDuLieuChuyenDuoc.Rows[i][dtDuLieuChuyenDuoc.Columns[j].ColumnName].ToString().Trim() != "")
                            {
                                pKQHT_DiemThanhPhanInfo.Diem = double.Parse(dtDuLieuChuyenDuoc.Rows[i][dtDuLieuChuyenDuoc.Columns[j].ColumnName].ToString());
                                oBKQHT_DiemThanhPhan.AddByImport(pKQHT_DiemThanhPhanInfo, LanThi, dtDuLieuChuyenDuoc.Rows[i]["MaSinhVien"].ToString());
                            }
                            else
                            {
                                pKQHT_DiemThanhPhanInfo.Diem = -1;
                                oBKQHT_DiemThanhPhan.AddByImport(pKQHT_DiemThanhPhanInfo, LanThi, dtDuLieuChuyenDuoc.Rows[i]["MaSinhVien"].ToString());
                            }
                        }
                    }
                }
                catch
                {
                    arrDr = dtDuLieuNguon.Select("@stt = " + dtDuLieuChuyenDuoc.Rows[i]["@stt"]);
                    if (arrDr.Length > 0)
                    {
                        arrDr[0]["LyDo"] = "Có lỗi khi thêm vào Database.";
                        dtDuLieuKhongChuyenDuoc.ImportRow(arrDr[0]);
                    }
                    dtDuLieuChuyenDuoc.Rows.RemoveAt(i);
                    i--;
                }
            }
        }
        #endregion

        #region Nhập Điểm tổng kết
        public void ChuyenDiemTongKet(ref DataTable dtDuLieuChuyenDuoc, ref DataTable dtDuLieuKhongChuyenDuoc, DataTable dtDuLieuNguon, Hashtable htb)
        {
            if (!dtDuLieuNguon.Columns.Contains("LyDo"))
                dtDuLieuNguon.Columns.Add("LyDo", typeof(string));
            DataRow drNew;
            bool BoQua, CoDiem;
            string MaSinhVien = "";
            double diem;
            // Kiểm tra dữ liệu trên file có đúng ko
            foreach (DataRow dr in dtDuLieuNguon.Rows)
            {
                BoQua = false;
                CoDiem = false;
                drNew = dtDuLieuChuyenDuoc.NewRow();
                for (int i = 0; i < dtDuLieuChuyenDuoc.Columns.Count; i++)
                {
                    if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "MaSinhVien")
                    {
                        if ("" + dr[htb["MaSinhVien"].ToString()] != "")
                            drNew["MaSinhVien"] = dr[htb["MaSinhVien"].ToString()].ToString();
                        else
                        {
                            BoQua = true;
                            dr["LyDo"] = "Không có mã học sinh.";
                            break;
                        }
                    }
                    else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "@stt")
                    {
                        drNew["@stt"] = dr["@stt"];
                    }
                    else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName != "ID")// && dtDuLieuChuyenDuoc.Columns[i].ColumnName != "@stt")
                    {
                        if (dtDuLieuChuyenDuoc.Columns[i].ColumnName != "HoVaTen" && dtDuLieuChuyenDuoc.Columns[i].ColumnName != "TenLop")
                        {
                            if (("" + dr[htb[dtDuLieuChuyenDuoc.Columns[i].ColumnName].ToString()]).Trim() != "")
                            {
                                if (double.TryParse(("" + dr[htb[dtDuLieuChuyenDuoc.Columns[i].ColumnName].ToString()]).Trim(), out diem))
                                {
                                    if (0 <= diem && diem <= 10.0)
                                    {
                                        drNew[dtDuLieuChuyenDuoc.Columns[i].ColumnName] = diem;
                                        CoDiem = true;
                                    }
                                    //else
                                    //{
                                    //    BoQua = true;
                                    //    dr["LyDo"] = "Dữ liệu điểm cột '" + htb[dtDuLieuChuyenDuoc.Columns[i].ColumnName] + "' vượt quá giới hạn về điểm.";
                                    //    break;
                                    //}
                                }
                                //else
                                //{
                                //    BoQua = true;
                                //    dr["LyDo"] = "Dữ liệu điểm cột '" + htb[dtDuLieuChuyenDuoc.Columns[i].ColumnName] + "' không đúng định dạng kiểu số.";
                                //    break;
                                //}
                            }
                        }
                    }
                }
                // Nếu mã học sinh đang kiểm tra đã có thì cũng ko được
                if (!BoQua)
                {
                    if (("," + MaSinhVien + ",").IndexOf("," + dr[htb["MaSinhVien"].ToString()] + ",") >= 0)
                    {
                        BoQua = true;
                        dr["LyDo"] = "Trong file đầu vào, mã học sinh này đã bị trùng.";
                    }
                }
                if (!CoDiem && !BoQua)
                {
                    BoQua = true;
                    dr["LyDo"] = "Dữ liệu điểm của hàng này không có.";
                }
                if (BoQua)
                {
                    dtDuLieuKhongChuyenDuoc.ImportRow(dr);
                }
                else
                {
                    dtDuLieuChuyenDuoc.Rows.Add(drNew);
                    MaSinhVien += MaSinhVien == "" ? dr[htb["MaSinhVien"].ToString()].ToString() : "," + dr[htb["MaSinhVien"].ToString()];
                }
            }
            // Đưa tất cả những mã học sinh có thể import vào để kiểm tra nhập vào DB
            if (MaSinhVien != "")
            {
                cBwsSV_SinhVien oBSV_SinhVien = new cBwsSV_SinhVien();

                string HoVaTens = "", TenLops = "";
                string MaSinhVienDaTonTai = oBSV_SinhVien.CheckExistAndGetInfo(MaSinhVien, ref HoVaTens, ref TenLops);
                string[] arrMaSinhVien = MaSinhVien.Split(','), arrHoVaTen = HoVaTens.Split(','), arrTenLop = TenLops.Split(',');
                DataRow[] drFilter, drFilterNguon;
                int idx = 0;
                foreach (string str in arrMaSinhVien)
                {
                    // Nếu những mã học sinh đã tồn tại không có mã str thì tức là mã học sinh này không tồn tại.
                    // Nếu ngược lại thì sẽ gán họ tên và lớp của học sinh đó vào bảng dữ liệu chuyển được
                    if (("," + MaSinhVienDaTonTai + ",").IndexOf("," + str + ",") < 0)
                    {
                        drFilterNguon = dtDuLieuNguon.Select("[" + htb["MaSinhVien"].ToString() + "] = '" + str + "'");
                        if (drFilterNguon.Length > 0)
                        {
                            drFilter = dtDuLieuChuyenDuoc.Select("MaSinhVien = '" + str + "'");
                            drFilterNguon[0]["LyDo"] = "Mã học sinh này không tồn tại trong chương trình.";
                            dtDuLieuKhongChuyenDuoc.ImportRow(drFilterNguon[0]);
                            dtDuLieuChuyenDuoc.Rows.Remove(drFilter[0]);
                        }
                    }
                    else
                    {
                        drFilter = dtDuLieuChuyenDuoc.Select("MaSinhVien = '" + str + "'");
                        drFilter[0]["HoVaTen"] = arrHoVaTen[idx];
                        drFilter[0]["TenLop"] = arrTenLop[idx];
                        idx++;
                    }
                }
            }
        }

        public void LuuDiemTongKet(ref DataTable dtDuLieuChuyenDuoc, ref DataTable dtDuLieuKhongChuyenDuoc, DataTable dtDuLieuNguon,
            Hashtable htb, int LanThi, int IDDM_NamHoc, int HocKy)
        {
            cBwsKQHT_DiemTongKetMon oBKQHT_DiemTongKetMon = new cBwsKQHT_DiemTongKetMon();
            KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo = new KQHT_DiemTongKetMonInfo();
            pKQHT_DiemTongKetMonInfo.IDDM_NamHoc = IDDM_NamHoc;
            pKQHT_DiemTongKetMonInfo.HocKy = HocKy;
            pKQHT_DiemTongKetMonInfo.LanThi = LanThi;

            DataRow[] arrDr;
            for (int i = 0; i < dtDuLieuChuyenDuoc.Rows.Count; i++)
            {
                try
                {
                    for (int j = 0; j < dtDuLieuChuyenDuoc.Columns.Count; j++)
                    {
                        if (dtDuLieuChuyenDuoc.Columns[j].ColumnName.IndexOf("C_") >= 0)
                        {
                            pKQHT_DiemTongKetMonInfo.IDXL_MonHocTrongKy = int.Parse(dtDuLieuChuyenDuoc.Columns[j].ColumnName.Substring(2,
                                    dtDuLieuChuyenDuoc.Columns[j].ColumnName.Length - 2));
                            if ("" + dtDuLieuChuyenDuoc.Rows[i][dtDuLieuChuyenDuoc.Columns[j].ColumnName].ToString().Trim() != "")
                            {
                                pKQHT_DiemTongKetMonInfo.Diem = double.Parse(dtDuLieuChuyenDuoc.Rows[i][dtDuLieuChuyenDuoc.Columns[j].ColumnName].ToString());
                                oBKQHT_DiemTongKetMon.AddByImport(pKQHT_DiemTongKetMonInfo, dtDuLieuChuyenDuoc.Rows[i]["MaSinhVien"].ToString());
                            }
                            else
                            {
                                pKQHT_DiemTongKetMonInfo.Diem = -1;
                                oBKQHT_DiemTongKetMon.AddByImport(pKQHT_DiemTongKetMonInfo, dtDuLieuChuyenDuoc.Rows[i]["MaSinhVien"].ToString());
                            }
                        }
                    }
                }
                catch
                {
                    arrDr = dtDuLieuNguon.Select("@stt = " + dtDuLieuChuyenDuoc.Rows[i]["@stt"]);
                    if (arrDr.Length > 0)
                    {
                        arrDr[0]["LyDo"] = "Có lỗi khi thêm vào Database.";
                        dtDuLieuKhongChuyenDuoc.ImportRow(arrDr[0]);
                    }
                    dtDuLieuChuyenDuoc.Rows.RemoveAt(i);
                    i--;
                }
            }
        }
        #endregion

        #region Nhập danh sách tỉnh huyện xã
        public void ChuyenDanhSachTinhHuyenXa(ref DataTable dtDuLieuChuyenDuoc, ref DataTable dtDuLieuKhongChuyenDuoc, DataTable dtDuLieuNguon, Hashtable htb)
        {
            if (!dtDuLieuNguon.Columns.Contains("LyDo"))
                dtDuLieuNguon.Columns.Add("LyDo", typeof(string));
            DataRow drNew;
            bool BoQua;
            string Ma = "";

            dtDuLieuChuyenDuoc.Columns.Add("Cap", typeof(int));
            if (!dtDuLieuChuyenDuoc.Columns.Contains("MaParent"))
                dtDuLieuChuyenDuoc.Columns.Add("MaParent", typeof(string));
            // Kiểm tra dữ liệu trên file có đúng ko
            foreach (DataRow dr in dtDuLieuNguon.Rows)
            {
                BoQua = false;
                drNew = dtDuLieuChuyenDuoc.NewRow();
                for (int i = 0; i < dtDuLieuChuyenDuoc.Columns.Count; i++)
                {
                    if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "TenTinhHuyenXa")
                    {
                        if ("" + dr[htb["TenTinhHuyenXa"].ToString()] != "")
                            drNew["TenTinhHuyenXa"] = dr[htb["TenTinhHuyenXa"].ToString()].ToString();
                        else
                        {
                            BoQua = true;
                            dr["LyDo"] = "Không có tên tỉnh huyện xã.";
                            break;
                        }
                    }
                    else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "MaTinhHuyenXa")
                    {
                        if ("" + dr[htb["MaTinhHuyenXa"].ToString()] != "")
                            drNew["MaTinhHuyenXa"] = dr[htb["MaTinhHuyenXa"].ToString()].ToString();
                        else
                        {
                            BoQua = true;
                            dr["LyDo"] = "Không có mã tỉnh huyện xã.";
                            break;
                        }
                    }
                    else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName == "MaParent")
                    {
                        if (htb.ContainsKey("MaParent") && "" + dr[htb["MaParent"].ToString()] != "")
                            drNew["MaParent"] = dr[htb["MaParent"].ToString()].ToString();
                        else
                        {
                            drNew["Cap"] = 0;
                        }
                    }
                    //else if (dtDuLieuChuyenDuoc.Columns[i].ColumnName != "ID")
                    //{
                    //    drNew[dtDuLieuChuyenDuoc.Columns[i].ColumnName] = ("" + dr[htb[dtDuLieuChuyenDuoc.Columns[i].ColumnName].ToString()]).Trim();
                    //}
                }
                // Nếu mã học sinh đang kiểm tra đã có thì cũng ko được
                if (!BoQua)
                {
                    if (("," + Ma + ",").IndexOf("," + dr[htb["MaTinhHuyenXa"].ToString()] + ",") >= 0)
                    {
                        BoQua = true;
                        dr["LyDo"] = "Trong file đầu vào, mã này đã bị trùng.";
                    }
                }
                if (BoQua)
                {
                    dtDuLieuKhongChuyenDuoc.ImportRow(dr);
                }
                else
                {
                    dtDuLieuChuyenDuoc.Rows.Add(drNew);
                    Ma += Ma == "" ? dr[htb["MaTinhHuyenXa"].ToString()].ToString() : "," + dr[htb["MaTinhHuyenXa"].ToString()];
                }
            }
            // Đưa tất cả những mã có thể import vào để kiểm tra nhập vào DB
            if (Ma != "")
            {
                cBwsDM_TinhHuyenXa oBDM_TinhHuyenXa = new cBwsDM_TinhHuyenXa();
                DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo = new DM_TinhHuyenXaInfo();
                string MaDaTonTai = "", MaDangXet;
                while (Ma.Length > 4000)
                {
                    MaDangXet = Ma.Substring(0, 4000);
                    MaDangXet = MaDangXet.Substring(0, MaDangXet.LastIndexOf(','));

                    MaDaTonTai += MaDaTonTai != "" ? "," + oBDM_TinhHuyenXa.CheckExistByMa(MaDangXet) : oBDM_TinhHuyenXa.CheckExistByMa(MaDangXet);

                    Ma = Ma.Substring(MaDangXet.Length + 1);
                }
                if (Ma.Length > 0)
                    MaDaTonTai += MaDaTonTai != "" ? "," + oBDM_TinhHuyenXa.CheckExistByMa(Ma) : oBDM_TinhHuyenXa.CheckExistByMa(Ma);
                if (MaDaTonTai != "")
                {
                    string[] arrMaDaTonTai = MaDaTonTai.Split(',');
                    DataRow[] drFilter, drFilterNguon;
                    foreach (string str in arrMaDaTonTai)
                    {
                        drFilterNguon = dtDuLieuNguon.Select("[" + htb["MaTinhHuyenXa"] + "] = '" + str + "'");
                        drFilter = dtDuLieuChuyenDuoc.Select("MaTinhHuyenXa = '" + str + "'");
                        if (drFilterNguon.Length > 0)
                        {
                            drFilterNguon[0]["LyDo"] = "Mã tỉnh huyện xã đã tồn tại trong chương trình.";
                            dtDuLieuKhongChuyenDuoc.ImportRow(drFilterNguon[0]);
                            dtDuLieuChuyenDuoc.Rows.Remove(drFilter[0]);
                        }
                    }
                }
            }
        }

        public void LuuDanhSachTinhHuyenXa(ref DataTable dtDuLieuChuyenDuoc, ref DataTable dtDuLieuKhongChuyenDuoc, DataTable dtDuLieuNguon, Hashtable htb)
        {
            cBwsDM_TinhHuyenXa oBDM_TinhHuyenXa = new cBwsDM_TinhHuyenXa();
            DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo = new DM_TinhHuyenXaInfo();
            DataRow[] arrDr;
            string MaCha;
            for (int i = 0; i < dtDuLieuChuyenDuoc.Rows.Count; i++)
            {
                try
                {
                    pDM_TinhHuyenXaInfo.Ten = dtDuLieuChuyenDuoc.Rows[i]["TenTinhHuyenXa"].ToString();
                    pDM_TinhHuyenXaInfo.Ma = dtDuLieuChuyenDuoc.Rows[i]["MaTinhHuyenXa"].ToString();
                    MaCha = dtDuLieuChuyenDuoc.Rows[i]["MaParent"].ToString();
                    oBDM_TinhHuyenXa.AddByImport(pDM_TinhHuyenXaInfo, MaCha);
                }
                catch
                {
                    arrDr = dtDuLieuNguon.Select("[" + htb["MaTinhHuyenXa"].ToString() + "]='" + dtDuLieuChuyenDuoc.Rows[i]["MaTinhHuyenXa"] + "'");
                    if (arrDr.Length > 0)
                    {
                        arrDr[0]["LyDo"] = "Có lỗi khi thêm vào Database.";
                        dtDuLieuKhongChuyenDuoc.ImportRow(arrDr[0]);
                    }
                    dtDuLieuChuyenDuoc.Rows.RemoveAt(i);
                    i--;
                }
            }
        }
        #endregion

        #region Convert Font
        public void ConvertToUnicode(ref DataTable dtDuLieuNguon, CHUAN_BO_GO BoGo)
        {
            for (int i = 0; i < dtDuLieuNguon.Rows.Count; i++)
            {
                for (int j = 0; j < dtDuLieuNguon.Columns.Count; j++)
                {
                    if ("" + dtDuLieuNguon.Rows[i][j] != "")
                    {
                        dtDuLieuNguon.Rows[i][j] = ChuyenThanhUnicode(BoGo, dtDuLieuNguon.Rows[i][j].ToString());
                    }
                }
            }
        }

        private string ChuyenThanhUnicode(CHUAN_BO_GO BoGo, string str)
        {
            ConvertDB.ConvertFont ChuyenDoi = new ConvertDB.ConvertFont();
            if (BoGo == CHUAN_BO_GO.TCVN)
            {
                ChuyenDoi.Convert(ref str, ConvertDB.FontIndex.iTCV, ConvertDB.FontIndex.iUNI);
            }
            else if (BoGo == CHUAN_BO_GO.VNI)
            {
                ChuyenDoi.Convert(ref str, ConvertDB.FontIndex.iVNI, ConvertDB.FontIndex.iUNI);
            }
            return str;
        }
        #endregion
    }
}
