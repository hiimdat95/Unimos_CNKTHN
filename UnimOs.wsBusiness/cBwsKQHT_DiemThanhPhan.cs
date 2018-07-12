using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.wsBusiness;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Entity.Model;
using TruongViet.UnimOs.Data;
using UnimOs.wsBusiness.wsUnimOs;

namespace TruongViet.UnimOs.wsBusiness
{
    public class cBwsKQHT_DiemThanhPhan : cBwsBase
    {
        private cDKQHT_DiemThanhPhan oDKQHT_DiemThanhPhan;
        private KQHT_DiemThanhPhanInfo oKQHT_DiemThanhPhanInfo;
        private double SoTietNghiChoPhep = 0.2;

        public cBwsKQHT_DiemThanhPhan()
        {
            oDKQHT_DiemThanhPhan = new cDKQHT_DiemThanhPhan();
        }

        public DataTable Get(KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_DiemThanhPhan_GetResult>(client.cDKQHT_DiemThanhPhan_Get(GlobalVar.MaXacThuc, pKQHT_DiemThanhPhanInfo));
            }
        }

        public DataTable GetDanhSach(int IDDM_Lop, int IDDM_MonHoc, int XL_MonHocTrongKyID, int IDDM_NamHoc, int HocKy, int LanThi, int KQHT_ChoNhapLaiDiemID)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_DiemThanhPhan_GetDanhSachResult>(client.cDKQHT_DiemThanhPhan_GetDanhSach(GlobalVar.MaXacThuc, IDDM_Lop, IDDM_MonHoc, XL_MonHocTrongKyID, IDDM_NamHoc, HocKy, LanThi, KQHT_ChoNhapLaiDiemID));
            }
        }

        public DataTable ChoNhapLaiDiem_GetDanhSach(int IDKQHT_ChoNhapLaiDiem)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_DiemThanhPhan_ChoNhapLaiDiem_GetDanhSachResult>(client.cDKQHT_DiemThanhPhan_ChoNhapLaiDiem_GetDanhSach(GlobalVar.MaXacThuc, IDKQHT_ChoNhapLaiDiem));
            }
        }

        public DataTable GetTongHopTBHS(int IDXL_MonHocTrongKy, int IDDM_MonHoc, int IDDM_Lop, int IDDM_TrinhDo, int IDDM_NamHoc, int HocKy, int DiemLan)
        {
            return oDKQHT_DiemThanhPhan.GetTongHopTBHS(IDXL_MonHocTrongKy, IDDM_MonHoc, IDDM_Lop, IDDM_TrinhDo, IDDM_NamHoc, HocKy, DiemLan);
        }

        public DataTable KiemTraDiem(int IDSV_SinhVien, int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy)
        {
            using (var client = new UnimOsServiceClient())
            {
                return ConvertList.ToDataTable<sp_KQHT_DiemThanhPhan_KiemTraDiemResult>(client.cDKQHT_DiemThanhPhan_KiemTraDiem(GlobalVar.MaXacThuc, IDSV_SinhVien, IDDM_Lop, IDDM_MonHoc, IDDM_NamHoc, HocKy));
            }
        }

        public int Add(KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo)
        {
            int ID = 0;
            var client = new UnimOsServiceClient();
            ID = client.cDKQHT_DiemThanhPhan_Add(GlobalVar.MaXacThuc, pKQHT_DiemThanhPhanInfo);
            client.Close();
            mErrorMessage = oDKQHT_DiemThanhPhan.ErrorMessages;
            mErrorNumber = oDKQHT_DiemThanhPhan.ErrorNumber;
            return ID;
        }

        public int AddByImport(KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo, int LanThi, string MaSinhVien)
        {
            int ID = 0;
            var client = new UnimOsServiceClient();
            ID = client.cDKQHT_DiemThanhPhan_AddByImport(GlobalVar.MaXacThuc, pKQHT_DiemThanhPhanInfo, LanThi, MaSinhVien);
            client.Close();
            mErrorMessage = oDKQHT_DiemThanhPhan.ErrorMessages;
            mErrorNumber = oDKQHT_DiemThanhPhan.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_DiemThanhPhan_Update(GlobalVar.MaXacThuc, pKQHT_DiemThanhPhanInfo);
            client.Close();
            mErrorMessage = oDKQHT_DiemThanhPhan.ErrorMessages;
            mErrorNumber = oDKQHT_DiemThanhPhan.ErrorNumber;
        }

        public void Delete(KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_DiemThanhPhan_Delete(GlobalVar.MaXacThuc, pKQHT_DiemThanhPhanInfo);
            client.Close();
            mErrorMessage = oDKQHT_DiemThanhPhan.ErrorMessages;
            mErrorNumber = oDKQHT_DiemThanhPhan.ErrorNumber;
        }

        public void DeleteBy_SinhVien(int IDSV_SinhVien, int LanThi, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int IDKQHT_ThanhPhanDiem)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_DiemThanhPhan_DeleteBy_SinhVien(GlobalVar.MaXacThuc, IDSV_SinhVien, LanThi, IDDM_MonHoc, IDDM_NamHoc, HocKy, IDKQHT_ThanhPhanDiem);
            client.Close();
            mErrorMessage = oDKQHT_DiemThanhPhan.ErrorMessages;
            mErrorNumber = oDKQHT_DiemThanhPhan.ErrorNumber;
        }

        public void DeleteByInfo(KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo)
        {
            var client = new UnimOsServiceClient();
            client.cDKQHT_DiemThanhPhan_DeleteByInfo(GlobalVar.MaXacThuc, pKQHT_DiemThanhPhanInfo);
            client.Close();
            mErrorMessage = oDKQHT_DiemThanhPhan.ErrorMessages;
            mErrorNumber = oDKQHT_DiemThanhPhan.ErrorNumber;
        }

        public List<KQHT_DiemThanhPhanInfo> GetList(KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo)
        {
            List<KQHT_DiemThanhPhanInfo> oKQHT_DiemThanhPhanInfoList = new List<KQHT_DiemThanhPhanInfo>();
            DataTable dtb = Get(pKQHT_DiemThanhPhanInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oKQHT_DiemThanhPhanInfo = new KQHT_DiemThanhPhanInfo();

                    oKQHT_DiemThanhPhanInfo.KQHT_DiemThanhPhanID = long.Parse(dtb.Rows[i]["KQHT_DiemThanhPhanID"].ToString());
                    oKQHT_DiemThanhPhanInfo.IDSV_SinhVien = int.Parse(dtb.Rows[i]["IDSV_SinhVien"].ToString());
                    oKQHT_DiemThanhPhanInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
                    oKQHT_DiemThanhPhanInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oKQHT_DiemThanhPhanInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oKQHT_DiemThanhPhanInfo.IDKQHT_ThanhPhanDiem = int.Parse(dtb.Rows[i]["IDKQHT_ThanhPhanDiem"].ToString());
                    oKQHT_DiemThanhPhanInfo.Diem = double.Parse(dtb.Rows[i]["Diem"].ToString());
                    oKQHT_DiemThanhPhanInfo.LyDo = dtb.Rows[i]["LyDo"].ToString();
                    oKQHT_DiemThanhPhanInfo.IDHT_User = int.Parse(dtb.Rows[i]["IDHT_User"].ToString());
                    oKQHT_DiemThanhPhanInfo.NgayTao = DateTime.Parse(dtb.Rows[i]["NgayTao"].ToString());

                    oKQHT_DiemThanhPhanInfoList.Add(oKQHT_DiemThanhPhanInfo);
                }
            }
            return oKQHT_DiemThanhPhanInfoList;
        }

        public void ToDataRow(KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo, ref DataRow dr)
        {
            dr[pKQHT_DiemThanhPhanInfo.strKQHT_DiemThanhPhanID] = pKQHT_DiemThanhPhanInfo.KQHT_DiemThanhPhanID;
            dr[pKQHT_DiemThanhPhanInfo.strIDSV_SinhVien] = pKQHT_DiemThanhPhanInfo.IDSV_SinhVien;
            dr[pKQHT_DiemThanhPhanInfo.strIDDM_MonHoc] = pKQHT_DiemThanhPhanInfo.IDDM_MonHoc;
            dr[pKQHT_DiemThanhPhanInfo.strIDDM_NamHoc] = pKQHT_DiemThanhPhanInfo.IDDM_NamHoc;
            dr[pKQHT_DiemThanhPhanInfo.strHocKy] = pKQHT_DiemThanhPhanInfo.HocKy;
            dr[pKQHT_DiemThanhPhanInfo.strIDKQHT_ThanhPhanDiem] = pKQHT_DiemThanhPhanInfo.IDKQHT_ThanhPhanDiem;
            dr[pKQHT_DiemThanhPhanInfo.strDiem] = pKQHT_DiemThanhPhanInfo.Diem;
            dr[pKQHT_DiemThanhPhanInfo.strLyDo] = pKQHT_DiemThanhPhanInfo.LyDo;
            dr[pKQHT_DiemThanhPhanInfo.strIDHT_User] = pKQHT_DiemThanhPhanInfo.IDHT_User;
            dr[pKQHT_DiemThanhPhanInfo.strNgayTao] = pKQHT_DiemThanhPhanInfo.NgayTao;
        }

        public void ToInfo(ref KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo, DataRow dr)
        {
            pKQHT_DiemThanhPhanInfo.KQHT_DiemThanhPhanID = long.Parse(dr[pKQHT_DiemThanhPhanInfo.strKQHT_DiemThanhPhanID].ToString());
            pKQHT_DiemThanhPhanInfo.IDSV_SinhVien = int.Parse(dr[pKQHT_DiemThanhPhanInfo.strIDSV_SinhVien].ToString());
            pKQHT_DiemThanhPhanInfo.IDDM_MonHoc = int.Parse(dr[pKQHT_DiemThanhPhanInfo.strIDDM_MonHoc].ToString());
            pKQHT_DiemThanhPhanInfo.IDDM_NamHoc = int.Parse(dr[pKQHT_DiemThanhPhanInfo.strIDDM_NamHoc].ToString());
            pKQHT_DiemThanhPhanInfo.HocKy = int.Parse(dr[pKQHT_DiemThanhPhanInfo.strHocKy].ToString());
            pKQHT_DiemThanhPhanInfo.IDKQHT_ThanhPhanDiem = int.Parse(dr[pKQHT_DiemThanhPhanInfo.strIDKQHT_ThanhPhanDiem].ToString());
            pKQHT_DiemThanhPhanInfo.Diem = double.Parse(dr[pKQHT_DiemThanhPhanInfo.strDiem].ToString());
            pKQHT_DiemThanhPhanInfo.LyDo = dr[pKQHT_DiemThanhPhanInfo.strLyDo].ToString();
            pKQHT_DiemThanhPhanInfo.IDHT_User = int.Parse(dr[pKQHT_DiemThanhPhanInfo.strIDHT_User].ToString());
            pKQHT_DiemThanhPhanInfo.NgayTao = DateTime.Parse(dr[pKQHT_DiemThanhPhanInfo.strNgayTao].ToString());
        }

        public void TinhDiemTBHS(DataTable dtSV, DataRow drMonHoc, int IDDM_Lop, int IDDM_TrinhDo, int IDDM_NamHoc, int HocKy, int IDKQHT_ThanhPhanDiem, int LanThi, string CongThucDiem, int NS_GiaoVienID)
        {
            DataTable dtDiem = GetTongHopTBHS(int.Parse(drMonHoc["XL_MonHocTrongKyID"].ToString()), int.Parse(drMonHoc["DM_MonHocID"].ToString()), IDDM_Lop, IDDM_TrinhDo, IDDM_NamHoc, HocKy, LanThi);
            DataTable dtTPBatBuoc = (new cDKQHT_ThanhPhanDiemBatBuoc()).GetByTrinhDo(IDDM_TrinhDo);
            string TinhCaTietNghiCoPhep = (new cBwsHT_ThamSoHeThong()).GetGiaTriByMaThamSo("TinhCaTietNghiCoPhep");
            string LyDo;
            int SoTietNghi;
            double DiemThapNhat = double.Parse((new cBwsHT_ThamSoHeThong()).GetGiaTriByMaThamSo("DieuKienDiemDuThi"));
            DataRow[] arrDr, arrDrTPBatBuoc;

            KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo = new KQHT_DiemThanhPhanInfo();
            pKQHT_DiemThanhPhanInfo.IDDM_MonHoc = int.Parse(drMonHoc["DM_MonHocID"].ToString());
            pKQHT_DiemThanhPhanInfo.IDXL_MonHocTrongKy = int.Parse(drMonHoc["XL_MonHocTrongKyID"].ToString());
            pKQHT_DiemThanhPhanInfo.IDDM_NamHoc = IDDM_NamHoc;
            pKQHT_DiemThanhPhanInfo.HocKy = HocKy;
            pKQHT_DiemThanhPhanInfo.IDKQHT_ThanhPhanDiem = IDKQHT_ThanhPhanDiem;
            pKQHT_DiemThanhPhanInfo.IDHT_User = NS_GiaoVienID;
            pKQHT_DiemThanhPhanInfo.DiemThu = LanThi;
            pKQHT_DiemThanhPhanInfo.DiemLan = LanThi;

            cDKQHT_DanhSachKhongThi oDKQHT_DanhSachKhongThi = new cDKQHT_DanhSachKhongThi();
            KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo = new KQHT_DanhSachKhongThiInfo();
            pKQHT_DanhSachKhongThiInfo.IDDM_MonHoc = pKQHT_DiemThanhPhanInfo.IDDM_MonHoc;
            pKQHT_DanhSachKhongThiInfo.IDDM_NamHoc = IDDM_NamHoc;
            pKQHT_DanhSachKhongThiInfo.HocKy = HocKy;
            pKQHT_DanhSachKhongThiInfo.LanThi = LanThi;

            foreach (DataRow dr in dtSV.Rows)
            {
                LyDo = "";
                // Kiểm tra số tiết nghỉ
                SoTietNghi = int.Parse("0" + dr["KhongLyDo"]);
                if (TinhCaTietNghiCoPhep != "0")
                    SoTietNghi += int.Parse("0" + dr["CoLyDo"]);
                if (SoTietNghi > SoTietNghiChoPhep * int.Parse("0" + drMonHoc["SoTiet"]))
                {
                    LyDo = "Nghỉ quá số tiết quy định;";
                }
                // Kiểm tra số thành phần điểm
                arrDr = dtDiem.Select("IDSV_SinhVien = " + dr["SV_SinhVienID"]);
                if (arrDr.Length > 0)
                {
                    foreach (DataRow dr1 in arrDr)
                    {
                        arrDrTPBatBuoc = dtTPBatBuoc.Select("SoHocTrinh = " + drMonHoc["SoHocTrinh"] + " And IDKQHT_ThanhPhanDiem = " + dr1["IDKQHT_ThanhPhanDiem"]);
                        if (arrDrTPBatBuoc.Length > 0)
                        {
                            if (int.Parse("0" + dr1["SoDiem"]) < int.Parse("0" + arrDrTPBatBuoc[0]["SoDiemBatBuoc"]))
                            {
                                dr1["SoDiem"] = arrDrTPBatBuoc[0]["SoDiemBatBuoc"];
                                LyDo += "Số thành phần của " + dr1["KyHieu"] + " ít hơn quy định;";
                            }
                        }
                    }

                    // Được phép tổng hợp điểm hệ số
                    pKQHT_DiemThanhPhanInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                    pKQHT_DiemThanhPhanInfo.Diem = TestCongThuc(arrDr, CongThucDiem);

                    if (!(double.IsInfinity(pKQHT_DiemThanhPhanInfo.Diem) ||
                        double.IsNaN(pKQHT_DiemThanhPhanInfo.Diem) || double.IsNegativeInfinity(pKQHT_DiemThanhPhanInfo.Diem)))
                    {
                        dr[IDKQHT_ThanhPhanDiem.ToString() + "_" + LanThi.ToString()] = pKQHT_DiemThanhPhanInfo.Diem;
                        var client = new UnimOsServiceClient();
                        client.cDKQHT_DiemThanhPhan_Add(GlobalVar.MaXacThuc, pKQHT_DiemThanhPhanInfo);
                        client.Close();

                        pKQHT_DiemThanhPhanInfo.Diem = 0;
                    }

                    if (pKQHT_DiemThanhPhanInfo.Diem < DiemThapNhat)
                        LyDo += "Điểm TBHS < " + DiemThapNhat.ToString() + ";";
                }
                else
                {
                    LyDo = "Chưa có điểm thành phần";
                    pKQHT_DiemThanhPhanInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                    var client = new UnimOsServiceClient();
                    client.cDKQHT_DiemThanhPhan_DeleteByInfo(GlobalVar.MaXacThuc, pKQHT_DiemThanhPhanInfo);
                    client.Close();
                }

                if (LyDo != "")
                {
                    // Đưa SV vào danh sách không được thi
                    pKQHT_DanhSachKhongThiInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                    pKQHT_DanhSachKhongThiInfo.LyDo = LyDo;
                    pKQHT_DanhSachKhongThiInfo.LanThi = LanThi;
                    var client = new UnimOsServiceClient();
                    client.cDKQHT_DanhSachKhongThi_AddTuDong(GlobalVar.MaXacThuc, pKQHT_DanhSachKhongThiInfo);
                    client.Close();
                    dr["LyDo"] = LyDo;
                }
                else if ("" + dr["LyDo"] != "")
                {
                    pKQHT_DanhSachKhongThiInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                    pKQHT_DanhSachKhongThiInfo.LanThi = LanThi;
                    var client = new UnimOsServiceClient();
                    client.cDKQHT_DanhSachKhongThi_DeleteTuDong(GlobalVar.MaXacThuc, pKQHT_DanhSachKhongThiInfo);
                    client.Close();
                    dr["LyDo"] = "";
                }
            }

            var clien = new UnimOsServiceClient();
            clien.cDKQHT_DanhSachKhongThi_DeleteDanhSachDuThi(GlobalVar.MaXacThuc, pKQHT_DanhSachKhongThiInfo, pKQHT_DiemThanhPhanInfo.IDXL_MonHocTrongKy);
            clien.Close();
        }

        public void TinhDiemTBHS_QCNghe(DataTable dtSV, DataRow drMonHoc, int IDDM_Lop, int IDDM_TrinhDo, int IDDM_NamHoc, int HocKy, int IDKQHT_ThanhPhanDiem, int LanThi, string CongThucDiem, int NS_GiaoVienID)
        {
            DataTable dtDiem = GetTongHopTBHS(int.Parse(drMonHoc["XL_MonHocTrongKyID"].ToString()), int.Parse(drMonHoc["DM_MonHocID"].ToString()), IDDM_Lop, IDDM_TrinhDo, IDDM_NamHoc, HocKy, LanThi);
            DataTable dtTPBatBuoc = (new cDKQHT_ThanhPhanDiemBatBuoc()).GetByTrinhDo(IDDM_TrinhDo);
            string TinhCaTietNghiCoPhep = (new cBwsHT_ThamSoHeThong()).GetGiaTriByMaThamSo("TinhCaTietNghiCoPhep");
            string LyDo;
            //int SoTietNghi;
            double DiemThapNhat = double.Parse((new cBwsHT_ThamSoHeThong()).GetGiaTriByMaThamSo("DieuKienDiemDuThi"));
            DataRow[] arrDr, arrDrTPBatBuoc;

            KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo = new KQHT_DiemThanhPhanInfo();
            pKQHT_DiemThanhPhanInfo.IDDM_MonHoc = int.Parse(drMonHoc["DM_MonHocID"].ToString());
            pKQHT_DiemThanhPhanInfo.IDXL_MonHocTrongKy = int.Parse(drMonHoc["XL_MonHocTrongKyID"].ToString());
            pKQHT_DiemThanhPhanInfo.IDDM_NamHoc = IDDM_NamHoc;
            pKQHT_DiemThanhPhanInfo.HocKy = HocKy;
            pKQHT_DiemThanhPhanInfo.IDKQHT_ThanhPhanDiem = IDKQHT_ThanhPhanDiem;
            pKQHT_DiemThanhPhanInfo.IDHT_User = NS_GiaoVienID;
            pKQHT_DiemThanhPhanInfo.DiemThu = LanThi;
            pKQHT_DiemThanhPhanInfo.DiemLan = LanThi;

            cDKQHT_DanhSachKhongThi oDKQHT_DanhSachKhongThi = new cDKQHT_DanhSachKhongThi();
            KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo = new KQHT_DanhSachKhongThiInfo();
            pKQHT_DanhSachKhongThiInfo.IDDM_MonHoc = pKQHT_DiemThanhPhanInfo.IDDM_MonHoc;
            pKQHT_DanhSachKhongThiInfo.IDDM_NamHoc = IDDM_NamHoc;
            pKQHT_DanhSachKhongThiInfo.HocKy = HocKy;

            foreach (DataRow dr in dtSV.Rows)
            {
                LyDo = "";
                // Kiểm tra số tiết nghỉ
                //SoTietNghi = int.Parse("0" + dr["KhongLyDo"]);
                //if (TinhCaTietNghiCoPhep != "0")
                //    SoTietNghi += int.Parse("0" + dr["CoLyDo"]);
                //if (SoTietNghi > SoTietNghiChoPhep * int.Parse("0" + drMonHoc["SoTiet"]))
                //{
                //    LyDo = "Nghỉ quá số tiết quy định;";
                //}
                // Kiểm tra số tiết học lại
                if ("" + dr["SoTietHocLai"] != "")
                    LyDo = "Học lại " + dr["SoTietHocLai"] + " tiết";
                // Kiểm tra số thành phần điểm
                arrDr = dtDiem.Select("IDSV_SinhVien = " + dr["SV_SinhVienID"]);
                if (arrDr.Length > 0)
                {
                    foreach (DataRow dr1 in arrDr)
                    {
                        arrDrTPBatBuoc = dtTPBatBuoc.Select("SoHocTrinh = " + drMonHoc["SoHocTrinh"] + " And IDKQHT_ThanhPhanDiem = " + dr1["IDKQHT_ThanhPhanDiem"]);
                        if (arrDrTPBatBuoc.Length > 0)
                        {
                            if (int.Parse("0" + dr1["SoDiem"]) < int.Parse("0" + arrDrTPBatBuoc[0]["SoDiemBatBuoc"]))
                            {
                                dr1["SoDiem"] = arrDrTPBatBuoc[0]["SoDiemBatBuoc"];
                                LyDo += "Số thành phần của " + dr1["KyHieu"] + " ít hơn quy định;";
                            }
                        }
                    }
                    // Được phép tổng hợp điểm hệ số

                    pKQHT_DiemThanhPhanInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                    pKQHT_DiemThanhPhanInfo.Diem = TestCongThuc(arrDr, CongThucDiem);
                    dr[IDKQHT_ThanhPhanDiem.ToString() + "_" + LanThi.ToString()] = pKQHT_DiemThanhPhanInfo.Diem;
                    var client = new UnimOsServiceClient();
                    client.cDKQHT_DiemThanhPhan_Add(GlobalVar.MaXacThuc, pKQHT_DiemThanhPhanInfo);
                    client.Close();
                    if (pKQHT_DiemThanhPhanInfo.Diem < DiemThapNhat)
                        LyDo += "Điểm TBHS < " + DiemThapNhat.ToString() + ";";
                }
                else
                {
                    LyDo = "Chưa có điểm thành phần";
                    pKQHT_DiemThanhPhanInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                    var client = new UnimOsServiceClient();
                    client.cDKQHT_DiemThanhPhan_DeleteByInfo(GlobalVar.MaXacThuc, pKQHT_DiemThanhPhanInfo);
                    client.Close();
                }

                if (LyDo != "" || "" + dr["SoTietHocLai"] != "")
                {
                    // Đưa SV vào danh sách không được thi
                    pKQHT_DanhSachKhongThiInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                    pKQHT_DanhSachKhongThiInfo.LyDo = LyDo;
                    pKQHT_DanhSachKhongThiInfo.LanThi = LanThi;
                    if ("" + dr["SoTietHocLai"] != "")
                        pKQHT_DanhSachKhongThiInfo.SoTietHocLai = int.Parse("" + dr["SoTietHocLai"]);
                    else
                        pKQHT_DanhSachKhongThiInfo.SoTietHocLai = null;
                    var client = new UnimOsServiceClient();
                    client.cDKQHT_DanhSachKhongThi_AddTuDong(GlobalVar.MaXacThuc, pKQHT_DanhSachKhongThiInfo);
                    client.Close();
                    dr["LyDo"] = LyDo;
                }
                else if ("" + dr["LyDo"] != "" && "" + dr["SoTietHocLai"] == "")
                {
                    pKQHT_DanhSachKhongThiInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                    pKQHT_DanhSachKhongThiInfo.LanThi = LanThi;
                    var client = new UnimOsServiceClient();
                    client.cDKQHT_DanhSachKhongThi_DeleteTuDong(GlobalVar.MaXacThuc, pKQHT_DanhSachKhongThiInfo);
                    client.Close();
                    dr["LyDo"] = "";
                }
            }
        }

        private double TestCongThuc(DataRow[] drDiem, string CongThucDiem)
        {
            double Value = 0; int SoSauDauPhay;
            try
            {
                MathParser parser = new MathParser();
                foreach (DataRow dr in drDiem)
                {
                    parser.CreateVar(dr["KyHieu"].ToString(), double.Parse("0" + dr["TongDiem"]), null);
                    parser.CreateVar("Count" + dr["KyHieu"], int.Parse("0" + dr["SoDiem"]), null);
                }
                string formula = CongThucDiem;
                parser.OptimizationOn = true;
                if (formula.IndexOf("R+(") == 0 | formula.IndexOf("R-(") == 0)
                {
                    SoSauDauPhay = int.Parse(formula.Substring(3, 1));
                    double tmp = 0;
                    if (formula.IndexOf("R+(") == 0)
                    {
                        formula = formula.Substring(5, formula.Length - 5);
                        parser.Expression = formula;
                        parser.Parse();
                        tmp = double.Parse(parser.Value.ToString());
                        Value = parser.Round(tmp, SoSauDauPhay, true);
                    }
                    else
                    {
                        formula = formula.Substring(5, formula.Length - 5);
                        parser.Expression = formula;
                        parser.Parse();
                        tmp = double.Parse(parser.Value.ToString());
                        Value = parser.Round(tmp, SoSauDauPhay, false);
                    }
                }
                else
                {
                    parser.Expression = formula;
                    parser.Parse();
                    Value = double.Parse(parser.Value.ToString());
                }
                return Value;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public DataTable CreateTableReportMain()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TenMonHoc", typeof(string));
            dt.Columns.Add("TenLop", typeof(string));
            dt.Columns.Add("HocKy", typeof(int));
            dt.Columns.Add("NamHoc", typeof(string));
            dt.Columns.Add("SoTiet", typeof(int));
            dt.Columns.Add("LoaiGioi", typeof(string));
            dt.Columns.Add("LoaiKha", typeof(string));
            dt.Columns.Add("LoaiTrungBinh", typeof(string));
            dt.Columns.Add("LoaiYeu", typeof(string));
            dt.Columns.Add("LoaiKem", typeof(string));
            return dt;
        }

        public DataTable CreateTableReportSub_CDCNKT(DataTable dtDiem, DataTable dtThanhPhanDiem, int ColStart, int IDKQHT_ThanhPhanTBHS)
        {

            DataTable dtReport = new DataTable();
            dtReport.Columns.Add("MaSinhVien", typeof(string));
            dtReport.Columns.Add("HoVa", typeof(string));
            dtReport.Columns.Add("Ten", typeof(string));
            for (int i = 1; i <= 4; i++)
            {
                dtReport.Columns.Add("HS1_" + i.ToString(), typeof(double));
                dtReport.Columns.Add("HS2_" + i.ToString(), typeof(double));
            }
            for (int i = 1; i <= 2; i++)
            {
                dtReport.Columns.Add("THI_" + i.ToString(), typeof(double));
                dtReport.Columns.Add("TK_" + i.ToString(), typeof(double));
            }
            dtReport.Columns.Add("TBHS", typeof(double));
            dtReport.Columns.Add("CoLyDo", typeof(int));
            dtReport.Columns.Add("KhongLyDo", typeof(int));
            dtReport.Columns.Add("GhiChu", typeof(string));

            //Thực hiện đưa điểm từ bảng điểm vào bảng report
            DataRow drNew;
            string ColName;
            foreach (DataRow dr in dtDiem.Rows)
            {
                drNew = dtReport.NewRow();

                drNew["MaSinhVien"] = dr["MaSinhVien"];
                drNew["HoVa"] = dr["HoVa"];
                drNew["Ten"] = dr["TenSV"];
                drNew["CoLyDo"] = dr["CoLyDo"];
                drNew["KhongLyDo"] = dr["KhongLyDo"];
                for (int i = ColStart; i < dtDiem.Columns.Count; i++)
                {
                    ColName = dtDiem.Columns[i].ColumnName;
                    if (ColName.IndexOf('_') > 0 && ColName.IndexOf("IDKQHT_XepLoai") < 0)
                    {
                        string[] arrStr = ColName.Split('_');
                        if (int.Parse(arrStr[1]) <= 4)
                        {
                            if (arrStr[0] == "TK")
                            {
                                drNew[ColName] = dr[ColName];
                            }
                            else if (arrStr[0] == IDKQHT_ThanhPhanTBHS.ToString())
                            {
                                if ("" + dr[ColName] != "")
                                    drNew["TBHS"] = dr[ColName];
                            }
                            else
                            {
                                DataRow[] arrDr = dtThanhPhanDiem.Select("KQHT_ThanhPhanDiemID = " + arrStr[0]);
                                if (arrDr.Length > 0)
                                {
                                    drNew[arrDr[0]["KyHieu"].ToString() + "_" + arrStr[1]] = dr[ColName];
                                }
                            }
                        }
                    }
                }
                dtReport.Rows.Add(drNew);
            }

            return dtReport;
        }

        public DataTable CreateTableReportSub_QCNghe(DataTable dtDiem, DataTable dtThanhPhanDiem, int ColStart, int IDKQHT_ThanhPhanTBHS)
        {
            DataTable dtReport = new DataTable();
            dtReport.Columns.Add("MaSinhVien", typeof(string));
            dtReport.Columns.Add("HoVa", typeof(string));
            dtReport.Columns.Add("Ten", typeof(string));
            for (int i = 1; i <= 6; i++)
            {
                dtReport.Columns.Add("DK_" + i.ToString(), typeof(double));
                //dtReport.Columns.Add("HS2_" + i.ToString(), typeof(double));
            }
            for (int i = 1; i <= 3; i++)
            {
                dtReport.Columns.Add("THI_" + i.ToString(), typeof(double));
                dtReport.Columns.Add("TK_" + i.ToString(), typeof(double));
            }
            dtReport.Columns.Add("TBHS", typeof(double));
            dtReport.Columns.Add("SoTietHocLai", typeof(int));
            //dtReport.Columns.Add("CoLyDo", typeof(int));
            //dtReport.Columns.Add("KhongLyDo", typeof(int));
            dtReport.Columns.Add("GhiChu", typeof(string));

            //Thực hiện đưa điểm từ bảng điểm vào bảng report
            DataRow drNew;
            string ColName;
            foreach (DataRow dr in dtDiem.Rows)
            {
                drNew = dtReport.NewRow();

                drNew["MaSinhVien"] = dr["MaSinhVien"];
                drNew["HoVa"] = dr["HoVa"];
                drNew["Ten"] = dr["TenSV"];
                drNew["SoTietHocLai"] = dr["SoTietHocLai"];
                //drNew["CoLyDo"] = dr["CoLyDo"];
                //drNew["KhongLyDo"] = dr["KhongLyDo"];
                for (int i = ColStart; i < dtDiem.Columns.Count; i++)
                {
                    ColName = dtDiem.Columns[i].ColumnName;
                    if (ColName.IndexOf('_') > 0 && ColName.IndexOf("IDKQHT_XepLoai") < 0)
                    {
                        string[] arrStr = ColName.Split('_');
                        if (int.Parse(arrStr[1]) <= 4)
                        {
                            if (arrStr[0] == "DiemTK")
                            {
                                drNew[ColName] = dr[ColName];
                            }
                            else if (arrStr[0] == IDKQHT_ThanhPhanTBHS.ToString())
                            {
                                if ("" + dr[ColName] != "")
                                    drNew["TBHS"] = dr[ColName];
                            }
                            else
                            {
                                DataRow[] arrDr = dtThanhPhanDiem.Select("KQHT_ThanhPhanDiemID = " + arrStr[0]);
                                if (arrDr.Length > 0)
                                {
                                    drNew[arrDr[0]["KyHieu"].ToString() + "_" + arrStr[1]] = dr[ColName];
                                }
                            }
                        }
                    }
                }
                dtReport.Rows.Add(drNew);
            }
            return dtReport;
        }
    }
}
