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
    public partial class dlgBienLaiThuTienNhapHoc :frmBase
    {
        private cBSV_SinhVienNhapTruong oBSV_SinhVienNhapTruong;
        private SV_SinhVienNhapTruongInfo pSV_SinhVienNhapTruongInfo;
        private cBTC_BienLaiThuTien oBTC_BienLaiThuTien;
        private TC_BienLaiThuTienInfo pTC_BienLaiThuTienInfo;
        private cBTC_BienLaiThuTien_ChiTiet oBTC_BienLaiThuTien_ChiTiet;
        private TC_BienLaiThuTien_ChiTietInfo pTC_BienLaiThuTien_ChiTietInfo;
        private cBTC_DinhMucThuSinhVien oBTC_DinhMucThuSinhVien;
        public string MaSinhVien;
        public int SV_SinhVienID = 0, IDDM_DiaDiem = 0;
        private bool Sua = false;
        private DataTable dtLoaiThuChi;
        private DataRow dr, drLoaiThuChi;
        private int TC_BienLaiThuTienID = 0;

        public dlgBienLaiThuTienNhapHoc(DataRow mdr, bool mSua)
        {
            InitializeComponent();
            oBSV_SinhVienNhapTruong = new cBSV_SinhVienNhapTruong();
            pTC_BienLaiThuTienInfo = new TC_BienLaiThuTienInfo();
            oBTC_BienLaiThuTien = new cBTC_BienLaiThuTien();
            pTC_BienLaiThuTien_ChiTietInfo = new TC_BienLaiThuTien_ChiTietInfo();
            oBTC_BienLaiThuTien_ChiTiet = new cBTC_BienLaiThuTien_ChiTiet();
            oBTC_DinhMucThuSinhVien = new cBTC_DinhMucThuSinhVien();
            pSV_SinhVienNhapTruongInfo = new SV_SinhVienNhapTruongInfo();
            dtpNgay.EditValue = DateTime.Now;
            Sua = mSua;
            dr = mdr;
        }

        private void dlgBienLaiThuTienNhapHoc_Load(object sender, EventArgs e)
        {
            txtNguoiThu.Text = Program.objUserCurrent.FullName;
            txtNoiDung.Text = "THU TIỀN NHẬP HỌC NĂM HỌC " + Program.NamHoc;
            txtHoVaTen.Text = dr["HoVaTenTS"].ToString();
            dtpNgay.EditValue = DateTime.Now;
            txtSoBD.Properties.ReadOnly = true;
            SV_SinhVienID = int.Parse(dr["SV_SinhVienNhapTruongID"].ToString());
            LaySoPhieu();
            LoadThongTin();
        }

        private void LaySoPhieu()
        {
            DataTable dtTemp = oBTC_BienLaiThuTien.GetSoPhieu(Program.HocKy, Program.IDNamHoc, SV_SinhVienID, IDDM_DiaDiem);
            if (dtTemp != null && dtTemp.Rows.Count > 0)
                txtSoPhieu.Text = GetSoPhieu(dtTemp.Rows[0]["SoPhieu"].ToString());
            else
                txtSoPhieu.Text = "1";
        }

        private void LoadThongTin()
        {
            pSV_SinhVienNhapTruongInfo.SV_SinhVienNhapTruongID = SV_SinhVienID;
            DataTable dtTemp = oBSV_SinhVienNhapTruong.Get(pSV_SinhVienNhapTruongInfo);
            if (Sua== false)
                 lbTotal.Text = "0";
            if (dtTemp != null && dtTemp.Rows.Count > 0)
            {
                txtHoVaTen.Text = dtTemp.Rows[0]["HoVaTenTS"].ToString();

                DataTable dtData;
                double TongTien = 0;

                DataTable dtDuLieu = LoadLoaiThuChi();
                dtDuLieu.DefaultView.RowFilter = "KhoanThu = 1";
                repositoryLoaiThuChi.DataSource = dtDuLieu.DefaultView;

                if (Sua == true)
                {
                    dtData = oBTC_DinhMucThuSinhVien.GetBy_SinhVien(0, Program.IDNamHoc, Program.HocKy, 1, 1, SV_SinhVienID);
                 //   repositoryLoaiThuChi.DataSource = dtData;
                    if (dtData.Rows.Count > 0)
                        TC_BienLaiThuTienID = int.Parse("0" + dtData.Rows[0]["TC_BienLaiThuTienID"].ToString());
                    pTC_BienLaiThuTienInfo.TC_BienLaiThuTienID = TC_BienLaiThuTienID;
                    dtLoaiThuChi = oBTC_BienLaiThuTien.GetChiTiet(pTC_BienLaiThuTienInfo.TC_BienLaiThuTienID);

                  //  repositoryLoaiThuChi.DataSource = oBTC_DinhMucThuSinhVien.GetBy_SinhVien(0, Program.IDNamHoc, Program.HocKy, 1, 0, SV_SinhVienID);
                }
                else
                {
                    dtData = oBTC_DinhMucThuSinhVien.GetBy_SinhVien(0, Program.IDNamHoc, Program.HocKy, 1, 0, SV_SinhVienID);
                    pTC_BienLaiThuTienInfo.TC_BienLaiThuTienID = 0;
                    dtLoaiThuChi = dtData;// oBTC_DinhMucThuSinhVien.GetBy_SinhVien(0, Program.IDNamHoc, Program.HocKy, 1, 0, SV_SinhVienID);

                }

                for (int i = 0; i < dtLoaiThuChi.Rows.Count; i++)
                {
                    TongTien += double.Parse("0" + dtLoaiThuChi.Rows[i]["SoTien"]);
                }
                grdLoaiThuChi.DataSource = dtLoaiThuChi;
                lbTotal.Text = TongTien.ToString("N0");
                pTC_BienLaiThuTienInfo.TC_BienLaiThuTienID = 0;
            }
        }

        private string GetSoPhieu(string SoPhieu)
        {
            string ChuoiTuTang = GetNumber(SoPhieu);
            string ChuoiMa = SoPhieu.Replace(ChuoiTuTang, "");
            if (ChuoiTuTang != "" && ChuoiTuTang.Substring(0, 1) == "0")
            {
                ChuoiTuTang = "1" + ChuoiTuTang.ToString();
                return ChuoiMa + (int.Parse("0" + ChuoiTuTang) + 1).ToString().Substring(1,ChuoiTuTang.Length-1);
            }
            else
                return ChuoiMa + (int.Parse("0" + ChuoiTuTang) + 1).ToString();
               
        }

        public string GetNumber(string strChuoi)
        {
            string strNumber = "";
            if (strChuoi != "")
            {
                while (strChuoi != "" && char.IsNumber(char.Parse(strChuoi.Substring(strChuoi.Length - 1, 1))) && strChuoi.Length > 0)
                {
                    strNumber = strChuoi.Substring(strChuoi.Length - 1, 1) + strNumber;
                    strChuoi = strChuoi.Substring(0, strChuoi.Length - 1);
                }
            }
            return strNumber;
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtSoBD.Text == string.Empty && SV_SinhVienID==0)
            {
                dxErrorProvider.SetError(txtSoBD, "Năm học không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtSoBD;
            }
            if (dtpNgay.Text == string.Empty)
            {
                dxErrorProvider.SetError(dtpNgay, "Ngày bắt đầu không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpNgay;
            }
            if (txtSoPhieu.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtSoPhieu, "Ngày kết thúc không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtSoPhieu;
            }
            if (txtNoiDung.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtNoiDung, "Ngày kết thúc không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtNoiDung;
            }
            //Kiểm tra thông tin thành công
            if ((CtrlErr != null))
            {
                CtrlErr.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        private void ClearText()
        {
            txtSoBD.Text = "";
            txtSoBD.Focus();
            txtHoVaTen.Text = "";
            SV_SinhVienID = 0;
            grdLoaiThuChi.DataSource = null;
        }
        private void lbTotal_TextChanged(object sender, EventArgs e)
        {
            if (lbTotal.Text != "" && lbTotal.Text != "0")
            {
                clsStringHelper cls = new clsStringHelper();
                lbTienBangChu.Text = cls.ReadMoney(double.Parse(lbTotal.Text.Trim()));
            }
            else
                lbTienBangChu.Text = "Không đồng";
        }

      private void grvLoaiThuChi_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "colTenLoaiThuChi")
            {
                if (e.Value != null)
                {
                    lbTotal.Text = (double.Parse("0" + lbTotal.Text.Trim()) - double.Parse("0" + grvLoaiThuChi.GetDataRow(grvLoaiThuChi.FocusedRowHandle)["SoTien"].ToString())).ToString("N0");
                    drLoaiThuChi["NoiDung"] = repositoryLoaiThuChi.GetDisplayText(e.Value);
                    drLoaiThuChi["SoTien"] = repositoryLoaiThuChi.GetDataSourceValue("SoTien", repositoryLoaiThuChi.GetDataSourceRowIndex("TC_LoaiThuChiID", e.Value));
                    lbTotal.Text = (double.Parse("0" + lbTotal.Text.Trim()) + double.Parse("0" + grvLoaiThuChi.GetDataRow(grvLoaiThuChi.FocusedRowHandle)["SoTien"].ToString())).ToString("N0");
                }
            }
            else if (e.Column.FieldName == "SoTien")
            {
                double TongTien = 0;
                foreach (DataRow mdr in dtLoaiThuChi.Rows)
                { 
                    TongTien+= double.Parse("0" + mdr["SoTien"].ToString());
                }
                lbTotal.Text = TongTien.ToString("N0");
            }
        }

        private void grvLoaiThuChi_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvLoaiThuChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (grvLoaiThuChi.FocusedRowHandle == grvLoaiThuChi.DataRowCount - 1 && grvLoaiThuChi.GetDataRow(grvLoaiThuChi.FocusedRowHandle)["SoTien"].ToString() !="")
                {
                    DataRow drNew = dtLoaiThuChi.NewRow();
                    dtLoaiThuChi.Rows.Add(drNew);
                    grvLoaiThuChi.FocusedColumn = colTenLoaiThuChi;
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (grvLoaiThuChi.FocusedRowHandle >= 0)
                {
                    lbTotal.Text = (double.Parse("0" + lbTotal.Text.Trim()) - double.Parse("0" + grvLoaiThuChi.GetDataRow(grvLoaiThuChi.FocusedRowHandle)["SoTien"].ToString())).ToString("N0");
                    try
                    {
                        dtLoaiThuChi.Rows.RemoveAt(grvLoaiThuChi.FocusedRowHandle);
                    }
                    catch { }
                }
            }

        }

        private void grdLoaiThuChi_Enter(object sender, EventArgs e)
        {
            if (grvLoaiThuChi.RowCount == 0 && dtLoaiThuChi != null)
            {
                DataRow drNew = dtLoaiThuChi.NewRow();
                dtLoaiThuChi.Rows.Add(drNew);
                grvLoaiThuChi.FocusedColumn = colTenLoaiThuChi;
            }
        }      

        private void grvLoaiThuChi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvLoaiThuChi.RowCount > 0)
            {
                drLoaiThuChi = grvLoaiThuChi.GetDataRow(grvLoaiThuChi.FocusedRowHandle);
            }
        }

        private void dlgBienLaiThuTienNhapHoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                btnLuu_Click(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {
                btnClose_Click(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.P)
            {

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!Check_Valid()) return;
            if (dtLoaiThuChi != null && dtLoaiThuChi.Rows.Count > 0)
            {
                if (Sua == false)
                {
                    // Them bien lai thu tien
                    pTC_BienLaiThuTienInfo.GhiChu = "";
                    pTC_BienLaiThuTienInfo.HocKy = Program.HocKy;
                    pTC_BienLaiThuTienInfo.IDDM_NamHoc = Program.IDNamHoc;
                    pTC_BienLaiThuTienInfo.IDHT_NguoiThu = Program.objUserCurrent.HT_UserID;
                    pTC_BienLaiThuTienInfo.IDSV_SinhVienNhapTruong = SV_SinhVienID;
                    pTC_BienLaiThuTienInfo.IDSV_SinhVien = 0;
                    pTC_BienLaiThuTienInfo.NgayThu = DateTime.Parse(dtpNgay.EditValue.ToString());
                    pTC_BienLaiThuTienInfo.NoiDung = txtNoiDung.Text.Trim();
                    pTC_BienLaiThuTienInfo.PhieuThu = true;
                    pTC_BienLaiThuTienInfo.Printed = false;
                    pTC_BienLaiThuTienInfo.SoPhieu = txtSoPhieu.Text.Trim();
                    pTC_BienLaiThuTienInfo.SoTien = float.Parse("0" + lbTotal.Text.Trim());
                    pTC_BienLaiThuTienInfo.SoTienBangChu = lbTienBangChu.Text;
                    pTC_BienLaiThuTienInfo.PhieuHuy = false;
                    pTC_BienLaiThuTienInfo.NgayHuy = DateTime.Parse("1/1/1900");
                    int intTC_BienLaiThuTienID = oBTC_BienLaiThuTien.Add(pTC_BienLaiThuTienInfo);
                    // them bien lai thu tien chi tiet
                    foreach (DataRow mdr in dtLoaiThuChi.Rows)
                    {
                        if (float.Parse("0" + mdr["SoTien"].ToString()) > 0 && mdr["TC_LoaiThuChiID"].ToString() != "")
                        {
                            pTC_BienLaiThuTien_ChiTietInfo.IDTC_BienLaiThuTien = intTC_BienLaiThuTienID;
                            pTC_BienLaiThuTien_ChiTietInfo.IDTC_DinhMucThuSinhVien = int.Parse("0" + mdr["IDTC_DinhMucThuSinhVien"].ToString());
                            pTC_BienLaiThuTien_ChiTietInfo.IDTC_LoaiThuChi = int.Parse(mdr["TC_LoaiThuChiID"].ToString());
                            pTC_BienLaiThuTien_ChiTietInfo.LanThu = int.Parse("0" + mdr["LanThu"].ToString());
                            pTC_BienLaiThuTien_ChiTietInfo.NoiDung = mdr["NoiDung"].ToString();
                            pTC_BienLaiThuTien_ChiTietInfo.SoTien = float.Parse("0" + mdr["SoTien"].ToString());
                            oBTC_BienLaiThuTien_ChiTiet.Add(pTC_BienLaiThuTien_ChiTietInfo);
                        }
                    }
                }
                else if (Sua == true && dr != null)
                {
                    // update bien lai thu tien
                    pTC_BienLaiThuTienInfo.IDSV_SinhVien = 0;
                    pTC_BienLaiThuTienInfo.GhiChu = "";
                    pTC_BienLaiThuTienInfo.HocKy = Program.HocKy;
                    pTC_BienLaiThuTienInfo.IDDM_NamHoc = Program.IDNamHoc;
                    pTC_BienLaiThuTienInfo.IDHT_NguoiThu = Program.objUserCurrent.HT_UserID;
                    pTC_BienLaiThuTienInfo.IDSV_SinhVienNhapTruong = SV_SinhVienID;
                    pTC_BienLaiThuTienInfo.NgayThu = DateTime.Parse(dtpNgay.EditValue.ToString());
                    pTC_BienLaiThuTienInfo.NoiDung = txtNoiDung.Text.Trim();
                    pTC_BienLaiThuTienInfo.PhieuThu = true;
                    pTC_BienLaiThuTienInfo.Printed = false;
                    pTC_BienLaiThuTienInfo.SoPhieu = txtSoPhieu.Text.Trim();
                    pTC_BienLaiThuTienInfo.SoTien = float.Parse("0" + lbTotal.Text.Trim());
                    pTC_BienLaiThuTienInfo.SoTienBangChu = lbTienBangChu.Text;
                    pTC_BienLaiThuTienInfo.PhieuHuy = false;
                    pTC_BienLaiThuTienInfo.NgayHuy = DateTime.Parse("1/1/1900");
                    pTC_BienLaiThuTienInfo.TC_BienLaiThuTienID = TC_BienLaiThuTienID;
                    oBTC_BienLaiThuTien.Update(pTC_BienLaiThuTienInfo);

                    try
                    {
                        oBTC_BienLaiThuTien_ChiTiet.DeleteBy_BienLaiThuTien(pTC_BienLaiThuTienInfo.TC_BienLaiThuTienID);
                    }
                    catch { }

                    // them bien lai thu tien chi tiet
                    foreach (DataRow mdr in dtLoaiThuChi.Rows)
                    {
                        if (float.Parse("0" + mdr["SoTien"].ToString()) > 0 && mdr["TC_LoaiThuChiID"].ToString() != "")
                        {
                            pTC_BienLaiThuTien_ChiTietInfo.IDTC_BienLaiThuTien = pTC_BienLaiThuTienInfo.TC_BienLaiThuTienID;
                            pTC_BienLaiThuTien_ChiTietInfo.IDTC_DinhMucThuSinhVien = int.Parse("0" + mdr["IDTC_DinhMucThuSinhVien"].ToString());
                            pTC_BienLaiThuTien_ChiTietInfo.IDTC_LoaiThuChi = int.Parse(mdr["TC_LoaiThuChiID"].ToString());
                            pTC_BienLaiThuTien_ChiTietInfo.LanThu = int.Parse("0" + mdr["LanThu"].ToString());
                            pTC_BienLaiThuTien_ChiTietInfo.NoiDung = mdr["NoiDung"].ToString();
                            pTC_BienLaiThuTien_ChiTietInfo.SoTien = float.Parse(mdr["SoTien"].ToString());
                            oBTC_BienLaiThuTien_ChiTiet.Add(pTC_BienLaiThuTien_ChiTietInfo);
                        }
                    }
                }
                this.Tag = "1";
                ThongBao("Lưu thông tin thành công!");
                if (chkInKhiLuu.Checked)
                    btnIn_Click(null, null);
                this.Tag = "1";
                this.Close();
                //if (Sua == false)
                //{
                //    LaySoPhieu();
                //    ClearText();
                //}

            }
            else
                ThongBao("Không có dữ liệu để lưu!");
        }
      
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            if (grvLoaiThuChi.DataRowCount == 0)
            {
                ThongBaoLoi("Không có dữ liệu để in");
                return;
            }
            DataTable dtMain = null, dtChiTiet = null;
            CreateTableReport(ref dtMain, ref dtChiTiet);
            frmReport frm = new frmReport(dtMain, dtChiTiet, "rBienLaiThuChiMain", "rBienLaiThuChiSub",
                new string[] { "Subreport1", "Subreport2", "Subreport3" });
            frm.ShowDialog();
        }



        private void CreateTableReport(ref DataTable dtMain, ref DataTable dtChiTiet)
        {
            dtMain = oBTC_BienLaiThuTien.CreateTableMain();
            DataRow drMain = dtMain.NewRow();

            drMain = dtMain.NewRow();
            //drMain["TenLop"] = txtTenLop.Text;
            drMain["HoVaTen"] = txtHoVaTen.Text;
            //drMain["MaSinhVien"] = txtMaSinhVien.Text;
            drMain["SoPhieu"] = txtSoPhieu.Text;
            //drMain["PhieuThu"] = (rdThuChi.SelectedIndex == 0 ? "THU" : "CHI");
            drMain["TongTien"] = lbTotal.Text;
            drMain["SoTienBangChu"] = lbTienBangChu.Text;
            drMain["NoiDungPhieu"] = txtNoiDung.Text;
            drMain["NgayThu"] = DateTime.Parse(dtpNgay.EditValue.ToString());
            drMain["FullName"] = txtNguoiThu.Text;
            dtMain.Rows.Add(drMain);

            dtChiTiet = oBTC_BienLaiThuTien_ChiTiet.CreateTableChiTiet();
            DataRow drCT;
            foreach (DataRow mdr in dtLoaiThuChi.Rows)
            {
                drCT = dtChiTiet.NewRow();
                drCT["NoiDung"] = mdr["NoiDung"];
                drCT["SoTien"] = mdr["SoTien"];
                drCT["LanThu"] = mdr["LanThu"];

                dtChiTiet.Rows.Add(drCT);
            }
        }
    }
}