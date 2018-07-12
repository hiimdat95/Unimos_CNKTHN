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
    public partial class dlgBienLaiThuTienChiTiet : frmBase
    {
        private cBSV_SinhVien oBSV_SinhVien;
        private SV_SinhVienInfo pSV_SinhVienInfo;
        private cBTC_BienLaiThuTien oBTC_BienLaiThuTien;
        private TC_BienLaiThuTienInfo pTC_BienLaiThuTienInfo;
        private cBTC_BienLaiThuTien_ChiTiet oBTC_BienLaiThuTien_ChiTiet;
        private TC_BienLaiThuTien_ChiTietInfo pTC_BienLaiThuTien_ChiTietInfo;
        private cBTC_DinhMucThuSinhVien oBTC_DinhMucThuSinhVien;
        public string MaSinhVien;
        public int SV_SinhVienID = 0, IDTC_BienLaiThuTien, IDDM_Lop, IDDM_DiaDiem;
        private bool Sua = false;
        private DataTable dtLoaiThuChi;
        private DataRow dr, drLoaiThuChi;

        public dlgBienLaiThuTienChiTiet(int _IDTC_BienLaiThuTien, bool mSua, string _MaSinhVien)
        {
            InitializeComponent();
            oBSV_SinhVien = new cBSV_SinhVien();
            pTC_BienLaiThuTienInfo = new TC_BienLaiThuTienInfo();
            oBTC_BienLaiThuTien = new cBTC_BienLaiThuTien();
            pTC_BienLaiThuTien_ChiTietInfo = new TC_BienLaiThuTien_ChiTietInfo();
            oBTC_BienLaiThuTien_ChiTiet = new cBTC_BienLaiThuTien_ChiTiet();
            oBTC_DinhMucThuSinhVien = new cBTC_DinhMucThuSinhVien();
            pSV_SinhVienInfo = new SV_SinhVienInfo();
            dtpNgay.EditValue = DateTime.Now;
            Sua = mSua;
            IDTC_BienLaiThuTien = _IDTC_BienLaiThuTien;
            MaSinhVien = _MaSinhVien;

            chkInKhiLuu.Checked = Properties.Settings.Default.TC_InKhiLuu;
        }

        private void dlgBienLaiThuTienChiTiet_Load(object sender, EventArgs e)
        {
            if (IDTC_BienLaiThuTien > 0)
            {
                dr = oBTC_BienLaiThuTien.GetInfoByID(IDTC_BienLaiThuTien);
                if (dr != null)
                {
                    txtSoPhieu.Text = dr["SoPhieu"].ToString();
                    txtNguoiThu.Text = dr["FullName"].ToString();
                    txtNoiDung.Text = dr["NoiDung"].ToString();
                    txtMaSinhVien.Text = dr["MaSinhVien"].ToString();
                    dtpNgay.EditValue = dr["NgayThu"];
                    lbTotal.Text = double.Parse(dr["SoTien"].ToString()).ToString("N0");
                    txtSoPhieu.Properties.ReadOnly = true;
                    txtMaSinhVien.Properties.ReadOnly = true;
                    btnChonThuMuc.Enabled = false;
                    if (bool.Parse(dr["PhieuThu"].ToString()) == true)
                        rdThuChi.SelectedIndex = 0;
                    else
                        rdThuChi.SelectedIndex = 1;
                    SV_SinhVienID = int.Parse(dr["IDSV_SinhVien"].ToString());
                    LoadThongTin();
                }
                else
                {
                    ThongBao("Không có thông tin cho phiếu này!");
                    this.Close();
                }
            }
            else if (Sua == false)
            {
                txtMaSinhVien.Text = MaSinhVien;
                txtSoPhieu.Text = GetSoPhieu(Program.HocKy, Program.IDNamHoc, SV_SinhVienID, IDDM_DiaDiem);
                txtNguoiThu.Text = Program.objUserCurrent.FullName;
                txtNoiDung.Text = "HỌC KỲ " + Program.HocKy.ToString() + " NĂM HỌC " + Program.NamHoc;
                btnChonThuMuc.Enabled = true;
            }
        }

        private void txtMaSinhVien_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dtTemp = oBSV_SinhVien.KiemTraMaSV(txtMaSinhVien.Text.Trim());
            if (dtTemp != null && dtTemp.Rows.Count > 0 && txtMaSinhVien.Text.Trim() != "" && Sua == false)
            {
                SV_SinhVienID = int.Parse(dtTemp.Rows[0]["SV_SinhVienID"].ToString());
                txtSoPhieu.Text = GetSoPhieu(Program.HocKy, Program.IDNamHoc, SV_SinhVienID, IDDM_DiaDiem);
                LoadThongTin();
            }
            else if (txtMaSinhVien.Text.Trim() != "")
            {
                txtTenLop.Text = "";
                txtHoVaTen.Text = "";
                SV_SinhVienID = 0;
                grdLoaiThuChi.DataSource = null;
            }
        }

        private void LoadThongTin()
        {
            pSV_SinhVienInfo.SV_SinhVienID = SV_SinhVienID;
            DataTable dtTemp = oBSV_SinhVien.Get(pSV_SinhVienInfo);
            if (Sua == false)
                lbTotal.Text = "0";
            if (dtTemp != null && dtTemp.Rows.Count > 0)
            {
                txtTenLop.Text = dtTemp.Rows[0]["TenLop"].ToString();
                txtHoVaTen.Text = dtTemp.Rows[0]["HoVaTen"].ToString();

                repositoryLoaiThuChi.DataSource = oBTC_DinhMucThuSinhVien.GetBy_SinhVien(SV_SinhVienID, Program.IDNamHoc,
                    Program.HocKy, int.Parse(rdThuChi.EditValue.ToString()), 0, 0);

                //if (Sua == false)
                //{
                //    dtLoaiThuChi = oBTC_DinhMucThuSinhVien.GetBy_SinhVien(SV_SinhVienID, Program.IDNamHoc, Program.HocKy, int.Parse(rdThuChi.EditValue.ToString()));
                //    grdLoaiThuChi.DataSource = dtLoaiThuChi;
                //}
                //else
                //{
                if (Sua == true)
                {
                    pTC_BienLaiThuTienInfo.TC_BienLaiThuTienID = int.Parse("0" + dr["TC_BienLaiThuTienID"].ToString());
                    dtLoaiThuChi = oBTC_BienLaiThuTien.GetChiTiet(pTC_BienLaiThuTienInfo.TC_BienLaiThuTienID);
                    grdLoaiThuChi.DataSource = dtLoaiThuChi;
                }
                else
                {
                    double TongTien = 0;
                    pTC_BienLaiThuTienInfo.TC_BienLaiThuTienID = 0;
                    dtLoaiThuChi = oBTC_DinhMucThuSinhVien.GetBy_SinhVien(SV_SinhVienID,
                        Program.IDNamHoc, Program.HocKy, int.Parse(rdThuChi.EditValue.ToString()), 1, 0);
                    TongTien = SumColumnValue(dtLoaiThuChi, "SoTien");
                    grdLoaiThuChi.DataSource = dtLoaiThuChi;

                    lbTotal.Text = TongTien.ToString("N0");
                }
                pTC_BienLaiThuTienInfo.TC_BienLaiThuTienID = 0;
                // }
            }
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtMaSinhVien.Text == string.Empty && SV_SinhVienID == 0)
            {
                dxErrorProvider.SetError(txtMaSinhVien, "Năm học không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMaSinhVien;
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
            txtMaSinhVien.Text = "";
            txtMaSinhVien.Focus();
            txtHoVaTen.Text = "";
            txtTenLop.Text = "";
            SV_SinhVienID = 0;
            grdLoaiThuChi.DataSource = null;
        }

        private void lbTotal_TextChanged(object sender, EventArgs e)
        {
            if (lbTotal.Text != "" && lbTotal.Text != "0")
            {
                clsStringHelper cls = new clsStringHelper();
                lbTienBangChu.Text = cls.ReadMoney(double.Parse("0" + lbTotal.Text.Trim())) + " đồng";
            }
            else
                lbTienBangChu.Text = "Không đồng";
        }

        private void btnChonThuMuc_Click(object sender, EventArgs e)
        {
            dlgLocSinhVien dlg = new dlgLocSinhVien(this, txtMaSinhVien.Text.Trim());
            dlg.ShowDialog();
            txtMaSinhVien.Text = MaSinhVien;
            if (txtMaSinhVien.Text == "")
                LoadThongTin();
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
                    TongTien += double.Parse("0" + mdr["SoTien"].ToString());
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
                if (grvLoaiThuChi.FocusedRowHandle == grvLoaiThuChi.DataRowCount - 1 && grvLoaiThuChi.GetDataRow(grvLoaiThuChi.FocusedRowHandle)["SoTien"].ToString() != "")
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
                    try
                    {
                        lbTotal.Text = (double.Parse("0" + lbTotal.Text.Trim()) - double.Parse("0" + grvLoaiThuChi.GetDataRow(grvLoaiThuChi.FocusedRowHandle)["SoTien"].ToString())).ToString("N0");
                        dtLoaiThuChi.Rows.RemoveAt(grvLoaiThuChi.FocusedRowHandle);
                    }
                    catch { }
                }
            }
            //   grvLoaiThuChi_FocusedRowChanged(null, null);
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

        private void dlgBienLaiThuTienChiTiet_KeyDown(object sender, KeyEventArgs e)
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
                btnIn_Click(null, null);
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
                    pTC_BienLaiThuTienInfo.IDSV_SinhVien = SV_SinhVienID;
                    pTC_BienLaiThuTienInfo.IDDM_Lop = IDDM_Lop;
                    pTC_BienLaiThuTienInfo.NgayThu = DateTime.Parse(dtpNgay.EditValue.ToString());
                    pTC_BienLaiThuTienInfo.NoiDung = txtNoiDung.Text.Trim();
                    pTC_BienLaiThuTienInfo.PhieuThu = (rdThuChi.SelectedIndex == 0 ? true : false);
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
                    pTC_BienLaiThuTienInfo.GhiChu = "";
                    pTC_BienLaiThuTienInfo.HocKy = Program.HocKy;
                    pTC_BienLaiThuTienInfo.IDDM_NamHoc = Program.IDNamHoc;
                    pTC_BienLaiThuTienInfo.IDHT_NguoiThu = Program.objUserCurrent.HT_UserID;
                    pTC_BienLaiThuTienInfo.IDSV_SinhVien = SV_SinhVienID;
                    pTC_BienLaiThuTienInfo.NgayThu = DateTime.Parse(dtpNgay.EditValue.ToString());
                    pTC_BienLaiThuTienInfo.NoiDung = txtNoiDung.Text.Trim();
                    pTC_BienLaiThuTienInfo.PhieuThu = (rdThuChi.SelectedIndex == 0 ? true : false);
                    pTC_BienLaiThuTienInfo.Printed = false;
                    pTC_BienLaiThuTienInfo.SoPhieu = txtSoPhieu.Text.Trim();
                    pTC_BienLaiThuTienInfo.SoTien = float.Parse("0" + lbTotal.Text.Trim());
                    pTC_BienLaiThuTienInfo.SoTienBangChu = lbTienBangChu.Text;
                    pTC_BienLaiThuTienInfo.PhieuHuy = false;
                    pTC_BienLaiThuTienInfo.NgayHuy = DateTime.Parse("1/1/1900");
                    pTC_BienLaiThuTienInfo.TC_BienLaiThuTienID = int.Parse(dr["TC_BienLaiThuTienID"].ToString());
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
                {
                    btnIn_Click(null, null);
                    this.Close();
                }
                if (Sua == false)
                {
                    GetSoPhieu(Program.HocKy, Program.IDNamHoc, SV_SinhVienID, IDDM_DiaDiem);
                    ClearText();
                }
            }
            else
                ThongBao("Không có dữ liệu để lưu!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
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
            drMain["TenLop"] = txtTenLop.Text;
            drMain["HoVaTen"] = txtHoVaTen.Text;
            drMain["MaSinhVien"] = txtMaSinhVien.Text;
            drMain["SoPhieu"] = txtSoPhieu.Text;
            drMain["PhieuThu"] = (rdThuChi.SelectedIndex == 0 ? "THU" : "CHI");
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

        private void chkInKhiLuu_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TC_InKhiLuu = chkInKhiLuu.Checked;
            Properties.Settings.Default.Save();
        }
    }
}