using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;
using Lib;

namespace UnimOs.UI
{
    public partial class frmDanhSachHocBong : frmBase
    {
        private cBTC_DanhSachHocBong oBTC_DanhSachHocBong;
        private TC_DanhSachHocBongInfo pTC_DanhSachHocBongInfo;
        private cBTC_DanhSachHocBong_ChiTiet oBTC_DanhSachHocBong_ChiTiet;
        private TC_DanhSachHocBong_ChiTietInfo pTC_DanhSachHocBong_ChiTietInfo;
        private DM_LopInfo pDM_LopInfo;
        //private cBTC_BienLaiThuTien oBTC_BienLaiThuTien;
        //private TC_BienLaiThuTienInfo pTC_BienLaiThuTienInfo;
        //private cBTC_BienLaiThuTien_ChiTiet oBTC_BienLaiThuTien_ChiTiet;
        //private TC_BienLaiThuTien_ChiTietInfo pTC_BienLaiThuTien_ChiTietInfo;
        public DataTable dtTroCap, dtSinhVien, dtChiTiet;
        private string strID="";

        public frmDanhSachHocBong()
        {
            InitializeComponent();
            pTC_DanhSachHocBongInfo = new TC_DanhSachHocBongInfo();
            oBTC_DanhSachHocBong = new cBTC_DanhSachHocBong();
            oBTC_DanhSachHocBong_ChiTiet = new cBTC_DanhSachHocBong_ChiTiet();
            pTC_DanhSachHocBong_ChiTietInfo = new TC_DanhSachHocBong_ChiTietInfo();
            pDM_LopInfo = new DM_LopInfo();
            //pTC_BienLaiThuTien_ChiTietInfo = new TC_BienLaiThuTien_ChiTietInfo();
            //oBTC_BienLaiThuTien_ChiTiet = new cBTC_BienLaiThuTien_ChiTiet();
            //pTC_BienLaiThuTienInfo = new TC_BienLaiThuTienInfo();
            //oBTC_BienLaiThuTien = new cBTC_BienLaiThuTien();
        }

        private void frmDanhSachHocBong_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
            chkRenLuyen.Properties.DataSource = (new cBDM_XepLoaiRenLuyen()).Get(new DM_XepLoaiRenLuyenInfo());
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                dtSinhVien = oBTC_DanhSachHocBong.GetNotInSinhVien(pDM_LopInfo, Program.IDNamHoc, Program.HocKy, Program.NamHoc, 
                    "" + chkRenLuyen.EditValue, txtDiemTBC.Text == "" ? 0 : double.Parse(txtDiemTBC.Text));
                string HoDem = "";
                foreach (DataRow dr in dtSinhVien.Rows)
                {
                    dr["TenSV"] = GetTen(dr["HoVaTen"].ToString(), ref HoDem);
                    dr["HoVa"] = HoDem;
                }
                grdSinhVien.DataSource = dtSinhVien;
                dtTroCap = oBTC_DanhSachHocBong.GetInSinhVien(pDM_LopInfo, Program.IDNamHoc, Program.HocKy);
                foreach (DataRow dr in dtTroCap.Rows)
                {
                    dr["TenSV"] = GetTen(dr["HoVaTen"].ToString(), ref HoDem);
                    dr["HoVa"] = HoDem;
                }
                grdTroCap.DataSource = dtTroCap;
                strID = "";
            }
            else
            {
                grdSinhVien.DataSource = null;
                grdTroCap.DataSource = null;
                strID = "";
            }
        }

        private void btnLocSV_Click(object sender, EventArgs e)
        {
            trlLop_FocusedNodeChanged(null, null);
        }
       
        private void grvSinhVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvSinhVien_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvSinhVien, "Chon", e);
        }

        private void grvTroCap_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvTroCap, "Chon", e);
        }

        private void grvTroCap_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoTienThang.Text.Trim() == "")
            {
                ThongBao("Bạn phải nhập số tiền!");
                return;
            }
            int Count = dtSinhVien.Rows.Count;
            DataRow[] dr = dtSinhVien.Select("Chon = 1");
            if (dr.Length > 0)
            {
                // dinh muc thu chi tiet
                dtChiTiet = null;
                dlgDinhMuc dlg = new dlgDinhMuc(dr);
                dlg.ShowDialog();
                if (dlg.Tag.ToString() != "")
                {
                    for (int i = 0; i < Count; i++)
                    {
                        if ((bool)dtSinhVien.Rows[i]["Chon"])
                        {
                            dtSinhVien.Rows[i]["Chon"] = false;
                            if (dlg.Tag.ToString() == "1")
                            {
                                dtChiTiet = dlg.dtChiTiet;
                                if (dtChiTiet != null && dtChiTiet.Rows.Count > 0)
                                {
                                    DataRow[] adrChiTiet = dtChiTiet.Select("IDSV_SinhVien = " + dtSinhVien.Rows[i]["SV_SinhVienID"].ToString());
                                    dtSinhVien.Rows[i]["SoTienThang"] = Math.Abs(double.Parse(txtSoTienThang.Text));
                                    dtSinhVien.Rows[i]["SoTienKy"] = Math.Abs(double.Parse(txtSoTienThang.Text) * adrChiTiet.Length);
                                }
                            }
                            else
                                dtSinhVien.Rows[i]["SoTienKy"] = Math.Abs(double.Parse(txtSoTienThang.Text));
                            //
                            dtTroCap.ImportRow(dtSinhVien.Rows[i]);
                            dtSinhVien.Rows.Remove(dtSinhVien.Rows[i]);
                            Count = Count - 1;
                            i = i - 1;
                        }
                    }
                }
            }
            else
                ThongBao("Bạn phải chưa chọn sinh viên hoặc chưa nhập số tiền!");
        }

        //private string LaySoPhieu(int IDSV_SinhVien)
        //{
        //    DataTable dtTemp = oBTC_BienLaiThuTien.GetSoPhieu(Program.HocKy, Program.IDNamHoc, IDSV_SinhVien);
        //    if (dtTemp != null && dtTemp.Rows.Count > 0)
        //        return GetSoPhieu(dtTemp.Rows[0]["SoPhieu"].ToString());
        //    else
        //        return "1";
        //}

        //private string GetSoPhieu(string SoPhieu)
        //{
        //    string ChuoiTuTang = GetNumber(SoPhieu);
        //    string ChuoiMa = SoPhieu.Replace(ChuoiTuTang, "");
        //    if (ChuoiTuTang != "" && ChuoiTuTang.Substring(0, 1) == "0")
        //    {
        //        ChuoiTuTang = "1" + ChuoiTuTang.ToString();
        //        return ChuoiMa + (int.Parse("0" + ChuoiTuTang) + 1).ToString().Substring(1, ChuoiTuTang.Length - 1);
        //    }
        //    else
        //        return ChuoiMa + (int.Parse("0" + ChuoiTuTang) + 1).ToString();

        //}

        //public string GetNumber(string strChuoi)
        //{
        //    string strNumber = "";
        //    if (strChuoi != "")
        //    {
        //        while (strChuoi != "" && char.IsNumber(char.Parse(strChuoi.Substring(strChuoi.Length - 1, 1))) && strChuoi.Length > 0)
        //        {
        //            strNumber = strChuoi.Substring(strChuoi.Length - 1, 1) + strNumber;
        //            strChuoi = strChuoi.Substring(0, strChuoi.Length - 1);
        //        }
        //    }
        //    return strNumber;
        //}

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int Count = dtTroCap.Rows.Count;
            DataRow[] dr = dtTroCap.Select("Chon = 1");
            if (dr.Length > 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    if ((bool)dtTroCap.Rows[i]["Chon"])
                    {
                        dtTroCap.Rows[i]["Chon"] = false;
                        if (dtTroCap.Rows[i]["TC_DanhSachHocBongID"].ToString() != "0")
                        {
                            strID += dtTroCap.Rows[i]["TC_DanhSachHocBongID"].ToString() + ",";
                        }
                        dtSinhVien.ImportRow(dtTroCap.Rows[i]);
                        dtTroCap.Rows.Remove(dtTroCap.Rows[i]);
                        Count = Count - 1;
                        i = i - 1;
                    }
                }
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (strID != "")
            {
                strID = strID.Substring(0, strID.Length - 1);
                // xoa trong CSDL cac sinh vien da bi xoa
                try
                {
                    oBTC_DanhSachHocBong.DeleteInIDs(strID);
                }
                catch { }
            }
            if(dtTroCap != null && dtTroCap.Rows.Count > 0)
            {
                DataTable dtChange = dtTroCap.GetChanges();
                pTC_DanhSachHocBongInfo.IDDM_NamHoc = Program.IDNamHoc;
                pTC_DanhSachHocBongInfo.HocKy = Program.HocKy;
                pTC_DanhSachHocBongInfo.IDTC_PhanBoQuyHocBong = 0;

                foreach (DataRow dr in dtChange.Rows)
                {
                    pTC_DanhSachHocBongInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                    pTC_DanhSachHocBongInfo.SoTienKy = double.Parse("0" + dr["SoTienKy"]);

                    if (dtChiTiet != null && dtChiTiet.Rows.Count > 0)
                    {
                        DataRow[] adrChiTiet = dtChiTiet.Select(" IDSV_SinhVien = " + pTC_DanhSachHocBongInfo.IDSV_SinhVien.ToString());
                        pTC_DanhSachHocBongInfo.SoTienThang = double.Parse(dr["SoTienThang"].ToString());
                        pTC_DanhSachHocBongInfo.TC_DanhSachHocBongID = oBTC_DanhSachHocBong.Add(pTC_DanhSachHocBongInfo);
                        // add dinh muc thu chi tiet theo thang
                        foreach (DataRow drChiTiet in adrChiTiet)
                        {
                            pTC_DanhSachHocBong_ChiTietInfo.IDTC_DanhSachHocBong = pTC_DanhSachHocBongInfo.TC_DanhSachHocBongID;
                            pTC_DanhSachHocBong_ChiTietInfo.SoTien = double.Parse(dr["SoTienThang"].ToString());
                            pTC_DanhSachHocBong_ChiTietInfo.Thang = int.Parse(drChiTiet["Thang"].ToString());
                            oBTC_DanhSachHocBong_ChiTiet.Add(pTC_DanhSachHocBong_ChiTietInfo);
                        }
                    }
                    else
                    {
                        pTC_DanhSachHocBongInfo.TC_DanhSachHocBongID = oBTC_DanhSachHocBong.Add(pTC_DanhSachHocBongInfo);
                    }
                }
                dtTroCap.AcceptChanges();
            }
            ThongBao("Cập nhật thành công!");
            //else
            //    ThongBao("Không có dữ liệu để lưu!");
        }

        private void barbtnThang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dtChiTiet = null;
            DataRow[] dr = dtTroCap.Select("Chon = 1");
            if (dr.Length > 0)
            {
                dlgDinhMuc dlg = new dlgDinhMuc(dr);
                dlg.ShowDialog();
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn chắc chắn muốn xóa?") == DialogResult.Yes)
            {
                dtChiTiet = null;
                DataRow[] dr = dtTroCap.Select("Chon=1");
                foreach (DataRow mdr in dr)
                {
                    try
                    {
                     //   oBTC_DanhSachHocBong_ChiTiet.DeleteBy_TroCap(int.Parse(mdr["TC_DanhSachHocBongID"].ToString())); ;
                    }
                    catch { }
                }
                ThongBao("Xóa định mức thu theo tháng thành công!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void btnLapPhieuChi_Click(object sender, EventArgs e)
        //{
        //    if (cmbLoaiThuChi.EditValue != null)
        //    {
        //        DataRow[] dr = dtTroCap.Select("Chon=1");
        //        if (dr.Length > 0)
        //        {
        //            string SoPhieu = LaySoPhieu(int.Parse(dr[0]["SV_SinhVienID"].ToString()));
        //            clsStringHelper cls = new clsStringHelper();
        //            foreach (DataRow mdr in dr)
        //            {
        //                pTC_BienLaiThuTienInfo.GhiChu = "";
        //                pTC_BienLaiThuTienInfo.HocKy = Program.HocKy;
        //                pTC_BienLaiThuTienInfo.IDDM_NamHoc = Program.IDNamHoc;
        //                pTC_BienLaiThuTienInfo.IDHT_NguoiThu = Program.objUserCurrent.HT_UserID;
        //                pTC_BienLaiThuTienInfo.IDSV_SinhVien =int.Parse(mdr["SV_SinhVienID"].ToString());
        //                pTC_BienLaiThuTienInfo.NgayThu = DateTime.Now;
        //                pTC_BienLaiThuTienInfo.NoiDung = "CHI TRẢ HỌC BỔNG KỲ " + Program.HocKy.ToString() + " NĂM HỌC " + Program.NamHoc;
        //                pTC_BienLaiThuTienInfo.PhieuThu = false;
        //                pTC_BienLaiThuTienInfo.Printed = true;
        //                pTC_BienLaiThuTienInfo.SoPhieu = SoPhieu;
        //                pTC_BienLaiThuTienInfo.SoTien = float.Parse("0" + mdr["SoTienKy"].ToString());
        //                pTC_BienLaiThuTienInfo.SoTienBangChu = cls.ReadMoney(pTC_BienLaiThuTienInfo.SoTien);
        //                pTC_BienLaiThuTienInfo.PhieuHuy = false;
        //                pTC_BienLaiThuTienInfo.NgayHuy = DateTime.Parse("1/1/1900");
        //                int intTC_BienLaiThuTienID = oBTC_BienLaiThuTien.Add(pTC_BienLaiThuTienInfo);
        //                // them bien lai thu tien chi tiet

        //                pTC_BienLaiThuTien_ChiTietInfo.IDTC_BienLaiThuTien = intTC_BienLaiThuTienID;
        //                try
        //                {
        //                    pTC_BienLaiThuTien_ChiTietInfo.IDTC_DinhMucThuSinhVien = int.Parse("0" + mdr["IDTC_DinhMucThuSinhVien"].ToString());
        //                }
        //                catch
        //                { 
        //                    pTC_BienLaiThuTien_ChiTietInfo.IDTC_DinhMucThuSinhVien = 0;
        //                }
        //                pTC_BienLaiThuTien_ChiTietInfo.IDTC_LoaiThuChi = int.Parse(cmbLoaiThuChi.EditValue.ToString());
        //                pTC_BienLaiThuTien_ChiTietInfo.NoiDung = cmbLoaiThuChi.Text;
        //                pTC_BienLaiThuTien_ChiTietInfo.SoTien = float.Parse("0" + mdr["SoTienKy"].ToString());
        //                oBTC_BienLaiThuTien_ChiTiet.Add(pTC_BienLaiThuTien_ChiTietInfo);
        //                SoPhieu = GetSoPhieu(SoPhieu);

        //                // in phieu
        //                frmReport frm = new frmReport(CreateTable_ChiTiet(mdr), "rBienLaiThuChi");
        //                frm.ShowDialog();
        //            }
        //        }
        //        else
        //            ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
        //    }
        //    else
        //        ThongBao("Bạn chưa chọn loại chi!");
        //}

        //private DataTable CreateTable_ChiTiet(DataRow mdr)
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("TenLop");
        //    dt.Columns.Add("HoVaTen");
        //    dt.Columns.Add("MaSinhVien");
        //    dt.Columns.Add("SoPhieu");
        //    dt.Columns.Add("PhieuThu");
        //    dt.Columns.Add("TongTien");
        //    dt.Columns.Add("SoTienBangChu");
        //    dt.Columns.Add("NoiDungPhieu");
        //    dt.Columns.Add("NgayThu");
        //    dt.Columns.Add("SoTien");
        //    dt.Columns.Add("NoiDung");
        //    dt.Columns.Add("LanThu");
        //    dt.Columns.Add("FullName");
        //    DataRow drCT=dt.NewRow();
        //    drCT["TenLop"] =  mdr["TenLop"];
        //    drCT["HoVaTen"] = mdr["HoVaTen"];
        //    drCT["MaSinhVien"] = mdr["MaSinhVien"];
        //    drCT["SoPhieu"] = pTC_BienLaiThuTienInfo.SoPhieu;
        //    drCT["PhieuThu"] = "CHI";
        //    drCT["TongTien"] = pTC_BienLaiThuTienInfo.SoTien;
        //    drCT["SoTienBangChu"] = pTC_BienLaiThuTienInfo.SoTienBangChu;
        //    drCT["NoiDungPhieu"] = pTC_BienLaiThuTienInfo.NoiDung;
        //    drCT["NgayThu"] = pTC_BienLaiThuTienInfo.NgayThu;
        //    drCT["SoTien"] = pTC_BienLaiThuTien_ChiTietInfo.SoTien;
        //    drCT["NoiDung"] = pTC_BienLaiThuTien_ChiTietInfo.NoiDung;
        //    drCT["LanThu"] = "";
        //    drCT["FullName"] = Program.objUserCurrent.FullName;
        //    dt.Rows.Add(drCT);
        //    return dt;
        //}
    }
}