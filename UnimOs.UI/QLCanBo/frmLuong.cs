using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace UnimOs.UI
{
    public partial class frmLuong : frmBase
    {
        private cBNS_DonVi oBDonVi;
        private NS_DonViInfo pDonViInfo;
        private cBNS_GiaoVien oBGiaoVien;
        public NS_GiaoVienInfo pGiaoVienInfo;
        public cBNS_SoQuyetDinh oBSoQuyetDinh;
        public NS_SoQuyetDinhInfo pSoQuyetDinhInfo;
        public cBNS_Luong oBLuong;
        public NS_LuongInfo pNS_LuongInfo;
        public cBNS_NhomNgach oBNS_NhomNgach;
        public NS_NhomNgachInfo pNS_NhomNgachInfo;
        private DataTable dtTree, dtGiaoVien, dtLuong, dtNhomNgach;
        DataRow drGiaoVien, drLuong;
        private bool Loaded = false;
        private int idxGV;
        private EDIT_MODE edit;
        public int IDNS_NgachCongChuc;
        private int TrangThaiChonBac = -1;

        public frmLuong()
        {
            InitializeComponent();
            oBGiaoVien = new cBNS_GiaoVien();
            pGiaoVienInfo = new NS_GiaoVienInfo();
            pDonViInfo = new NS_DonViInfo();
            oBSoQuyetDinh = new cBNS_SoQuyetDinh();
            pSoQuyetDinhInfo = new NS_SoQuyetDinhInfo();
            oBLuong = new cBNS_Luong();
            pNS_LuongInfo = new NS_LuongInfo();
            oBNS_NhomNgach = new cBNS_NhomNgach();
            pNS_NhomNgachInfo = new NS_NhomNgachInfo();
            SetButton(false);
            btnThem.Enabled = true;
            SetControl(true);
            dtpDenNgay.Enabled = false;
            btnLuu.Enabled = false;
            cmbBacLuong_SelectedIndexChanged(null, null);
        }

        private void LoadPhuCap()
        {
            dtLuong = oBLuong.GetBy_IDNS_GiaoVien(int.Parse(grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle)["NS_GiaoVienID"].ToString()));
            grdLuong.DataSource = dtLuong;
        }

        private void LoadCombo()
        {
            cmbNgachCongChuc.Properties.DataSource = LoadNgachCongChuc();
            reposNgachCongChuc.DataSource = LoadNgachCongChuc();
        }

        private void LoadGiaoVien(int IDDonVi)
        {
            pGiaoVienInfo.IDNS_DonVi = IDDonVi;
            dtGiaoVien = oBGiaoVien.GetByIDNS_DonVi(IDDonVi);
            grdGiaoVien.DataSource = dtGiaoVien;
            grvGiaoVien_FocusedRowChanged(null, null);
        }

        private void LoadTreeView()
        {
            oBDonVi = new cBNS_DonVi();
            dtTree = oBDonVi.Get_Tree();
            trvDonVi.DataSource = dtTree;
            trvDonVi.ExpandAll();

        }

        private void trvDonVi_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (Loaded == true)
            {
                if (trvDonVi.Nodes.Count > 0)
                {
                    LoadGiaoVien(int.Parse(trvDonVi.FocusedNode["NS_DonViID"].ToString()));
                    pDonViInfo.NS_DonViID = int.Parse(trvDonVi.FocusedNode["NS_DonViID"].ToString());
                    pDonViInfo.MaDonVi = trvDonVi.FocusedNode["MaDonVi"].ToString();
                    pDonViInfo.TenDonVi = trvDonVi.FocusedNode["TenDonVi"].ToString();
                    pDonViInfo.ParentID = int.Parse(trvDonVi.FocusedNode["ParentID"].ToString());
                    pDonViInfo.Level = int.Parse(trvDonVi.FocusedNode["Level"].ToString());
                    pDonViInfo.IDDM_Khoa = int.Parse(trvDonVi.FocusedNode["IDDM_Khoa"].ToString());
                    pDonViInfo.IDDM_BoMon = int.Parse(trvDonVi.FocusedNode["IDDM_BoMon"].ToString());
                }
            }
        }

        private void SetControl(bool mbool)
        {
            txtSoQuyetDinh.Properties.ReadOnly = mbool;
            dtpNgayRaQuyetDinh.Properties.ReadOnly = mbool;
            txtCongViecDamNhiem.Properties.ReadOnly = mbool;
            cmbNgachCongChuc.Properties.ReadOnly = mbool;
            cmbBacLuong.Properties.ReadOnly = mbool;
            txtHeSoLuong.Properties.ReadOnly = mbool;
            txtPhanTramHuong.Properties.ReadOnly = mbool;
            dtpTuNgay.Properties.ReadOnly = mbool;
            txtSoQuyetDinh.Focus();
        }

        private void SetButton(bool status)
        {
            btnThem.Enabled = status;
            btnSua.Enabled = status;
            btnXoa.Enabled = status;
        }

        private void SetGrvTrv(bool status)
        {
            trvDonVi.Enabled = status;
            grdGiaoVien.Enabled = status;
            grdLuong.Enabled = status;
        }

        private void ClearText()
        {
            txtSoQuyetDinh.Text = "";
            dtpNgayRaQuyetDinh.EditValue = null;
            txtCongViecDamNhiem.Text = "";
            cmbNgachCongChuc.EditValue = null;
            cmbBacLuong.SelectedIndex = -1;
            txtHeSoLuong.Text = "";
            dtpTuNgay.EditValue = null;
            dtpDenNgay.Checked = false;
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            if (txtSoQuyetDinh.Text == "")
            {
                dxErrorProvider.SetError(txtSoQuyetDinh, "Số quyết định không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtSoQuyetDinh;
            }
            if (dtpNgayRaQuyetDinh.EditValue == null)
            {
                dxErrorProvider.SetError(dtpNgayRaQuyetDinh, "Ngày ra quyết định không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpNgayRaQuyetDinh;
            }
            if (cmbNgachCongChuc.EditValue == null)
            {
                dxErrorProvider.SetError(cmbNgachCongChuc, "Ngạch công chức không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbNgachCongChuc;
            }
            if (cmbBacLuong.SelectedIndex == -1)
            {
                dxErrorProvider.SetError(cmbBacLuong, "Bậc lương không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbBacLuong;
            }
            if (double.Parse("0" + txtHeSoLuong.Text) <= 0)
            {
                dxErrorProvider.SetError(txtHeSoLuong, "Hệ số lương phải lớn hơn 0.");
                if (CtrlErr == null) CtrlErr = txtHeSoLuong;
            }
            if (double.Parse("0" + txtPhanTramHuong.Text) <= 0)
            {
                dxErrorProvider.SetError(txtPhanTramHuong, "Phần trăm được hưởng phải lớn hơn 0.");
                if (CtrlErr == null) CtrlErr = txtPhanTramHuong;
            }
            if (dtpTuNgay.EditValue == null)
            {
                dxErrorProvider.SetError(dtpTuNgay, "Từ ngày không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpTuNgay;
            }

            //Kiểm tra cập nhật thành công
            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            else
                return true;
        }

        private void SetTextMain()
        {
            txtSoQuyetDinh.Text = "" + grvLuong.GetDataRow(grvLuong.FocusedRowHandle)[pSoQuyetDinhInfo.strSoQuyetDinh];
            if ("" + grvLuong.GetDataRow(grvLuong.FocusedRowHandle)[pSoQuyetDinhInfo.strNgayQuyetDinh] == "" || (DateTime.Parse(grvLuong.GetDataRow(grvLuong.FocusedRowHandle)[pSoQuyetDinhInfo.strNgayQuyetDinh].ToString()).ToString("dd/MM/yyyy")) == "01/01/1900")
                dtpNgayRaQuyetDinh.EditValue = null;
            else
            {
                dtpNgayRaQuyetDinh.EditValue = grvLuong.GetDataRow(grvLuong.FocusedRowHandle)[pSoQuyetDinhInfo.strNgayQuyetDinh];
            }
            txtSoQuyetDinh.Focus();
        }

        private void SetText()
        {
            txtCongViecDamNhiem.Text = "" + pNS_LuongInfo.CongViecDamNhiem;
            cmbNgachCongChuc.EditValue = int.Parse("0" + pNS_LuongInfo.IDNS_NgachCongChuc);
            cmbBacLuong.SelectedIndex = int.Parse(pNS_LuongInfo.BacLuong.ToString()) - 1;
            txtHeSoLuong.Text = pNS_LuongInfo.HeSoLuong.ToString();
            txtPhanTramHuong.Text = pNS_LuongInfo.PhanTramHuong.ToString();
            if ("" + drLuong[pNS_LuongInfo.strTuNgay] == "" || (DateTime.Parse(drLuong[pNS_LuongInfo.strTuNgay].ToString()).ToString("dd/MM/yyyy")) == "01/01/1900")
                dtpTuNgay.EditValue = null;
            else
            {
                dtpTuNgay.EditValue = drLuong[pNS_LuongInfo.strTuNgay];
            }
            if ("" + drLuong[pNS_LuongInfo.strDenNgay] == "" || (DateTime.Parse(drLuong[pNS_LuongInfo.strDenNgay].ToString()).ToString("dd/MM/yyyy")) == "31/12/9999")
            {
                dtpDenNgay.Value = DateTime.Today;
                dtpDenNgay.Checked = false;
            }
            else
            {
                dtpDenNgay.Value = DateTime.Parse(drLuong[pNS_LuongInfo.strDenNgay].ToString());
                dtpDenNgay.Checked = true;
            }
        }

        private void GetpInfoMain()
        {
            pSoQuyetDinhInfo.SoQuyetDinh = txtSoQuyetDinh.Text;
            if (dtpNgayRaQuyetDinh.EditValue == null)
            {
                pSoQuyetDinhInfo.NgayQuyetDinh = DateTime.Parse("01/01/1900");
            }
            else
            {
                pSoQuyetDinhInfo.NgayQuyetDinh = DateTime.Parse(dtpNgayRaQuyetDinh.EditValue.ToString());
            }
        }

        private NS_LuongInfo GetpInfo(int IDNS_SoQuyetDinh)
        {
            pNS_LuongInfo.IDNS_GiaoVien = int.Parse(drGiaoVien[pGiaoVienInfo.strNS_GiaoVienID].ToString());
            pNS_LuongInfo.IDNS_SoQuyetDinh = IDNS_SoQuyetDinh;
            pNS_LuongInfo.CongViecDamNhiem = txtCongViecDamNhiem.Text;
            pNS_LuongInfo.IDNS_NgachCongChuc = int.Parse("0" + cmbNgachCongChuc.EditValue);
            pNS_LuongInfo.BacLuong = int.Parse(cmbBacLuong.SelectedIndex.ToString()) + 1;
            pNS_LuongInfo.HeSoLuong = double.Parse("0" + txtHeSoLuong.Text);
            pNS_LuongInfo.PhanTramHuong = double.Parse("0" + txtPhanTramHuong.Text);
            if (dtpTuNgay.EditValue == null)
            {
                pNS_LuongInfo.TuNgay = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_LuongInfo.TuNgay = DateTime.Parse(dtpTuNgay.EditValue.ToString());
            }
            pNS_LuongInfo.DenNgay = dtpDenNgay.Checked == false ? DateTime.ParseExact("31/12/9999", "dd/MM/yyyy", null) : dtpDenNgay.Value;
            return pNS_LuongInfo;
        }


        private void grvGiaoVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvGiaoVien.DataRowCount > 0)
            {
                idxGV = grvGiaoVien.FocusedRowHandle;
                DataRow dr = grvGiaoVien.GetDataRow(idxGV);
                oBGiaoVien.ToInfo(ref pGiaoVienInfo, dr);
                drGiaoVien = grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle);
                LoadPhuCap();
                ClearText();
                grvLuong_FocusedRowChanged(null, null);
                if (grvLuong.DataRowCount > 0)
                {
                    SetButton(true);
                }
                else
                {
                    SetButton(false);
                    btnThem.Enabled = true;
                }
            }
            else
            {
                SetButton(false);
                btnThem.Enabled = true;
                grdLuong.DataSource = null;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetGrvTrv(false);
            SetButton(false);
            SetControl(false);
            dtpDenNgay.Enabled = true;
            btnLuu.Enabled = true;
            edit = EDIT_MODE.THEM;
            ClearText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetGrvTrv(false);
            SetButton(false);
            SetControl(false);
            dtpDenNgay.Enabled = true;
            btnLuu.Enabled = true;
            edit = EDIT_MODE.SUA;
            SetTextMain();
            SetText();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    pNS_LuongInfo.NS_LuongID = int.Parse(drLuong[pNS_LuongInfo.strNS_LuongID].ToString());
                    oBLuong.Delete(pNS_LuongInfo);
                    int NS_SoQuyetDinhID = int.Parse("0" + grvLuong.GetDataRow(grvLuong.FocusedRowHandle)[pSoQuyetDinhInfo.strNS_SoQuyetDinhID].ToString());
                    pNS_LuongInfo.NS_LuongID = 0;
                    DataTable dt = oBLuong.Get(pNS_LuongInfo);
                    DataRow[] arrDr = dt.Select("IDNS_SoQuyetDinh = " + NS_SoQuyetDinhID);
                    if(arrDr.Length == 0)
                    {
                        pSoQuyetDinhInfo.NS_SoQuyetDinhID = NS_SoQuyetDinhID;
                        oBSoQuyetDinh.Delete(pSoQuyetDinhInfo);
                    }
                    // ghi log
                    GhiLog("Xóa lương giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " bậc lương " + pNS_LuongInfo.BacLuong + "' khỏi CSDL ", "Xóa", this.Tag.ToString());                   
                    dtLuong.Rows.Remove(drLuong);
                    if (grvLuong.DataRowCount > 0)
                    {
                        SetTextMain();
                    }
                    else
                    {
                        ClearText();
                    }
                    XoaThanhCong();
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!Check_Valid()) return;
            try
            {
                GetpInfoMain();
                if (dtpTuNgay.EditValue == null)
                {
                    pNS_LuongInfo.TuNgay = DateTime.Parse("01/01/1900");
                }
                else
                {
                    pNS_LuongInfo.TuNgay = DateTime.Parse(dtpTuNgay.EditValue.ToString());
                }
                pNS_LuongInfo.DenNgay = dtpDenNgay.Checked == false ? DateTime.ParseExact("31/12/9999", "dd/MM/yyyy", null) : dtpDenNgay.Value;
                if (edit == EDIT_MODE.THEM)
                {
                    DataRow[] arrDr = dtLuong.Select("TuNgay <= '" + pNS_LuongInfo.TuNgay.ToString("MM/dd/yyyy") + "' AND DenNgay>='" + pNS_LuongInfo.DenNgay.ToString("MM/dd/yyyy") + "'");
                    if (arrDr.Length > 0)
                    {
                        ThongBaoLoi("Đã có lương chưa cập nhật thông tin đến ngày.\nHoặc từ ngày của lương này nằm trong khoảng từ ngày và đến ngày của lương thêm vào trước đó.\n Đề nghị kiểm tra và cập nhật lại thông tin lương.");
                        return;
                    }
                    int IDNS_SoQuyetDinh = oBSoQuyetDinh.Add(pSoQuyetDinhInfo);
                    pNS_LuongInfo.NS_LuongID = oBLuong.Add(GetpInfo(IDNS_SoQuyetDinh));
                    GhiLog("Thêm lương giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " bậc lương " + pNS_LuongInfo.BacLuong + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    drLuong = dtLuong.NewRow();
                    oBLuong.ToDataRow(pNS_LuongInfo, ref drLuong);
                    dtLuong.Rows.Add(drLuong);
                }
                else
                {
                    DataRow[] arrDr = dtLuong.Select("NS_LuongID <> " + drLuong[pNS_LuongInfo.strNS_LuongID].ToString() + " AND TuNgay <= '" + pNS_LuongInfo.TuNgay.ToString("MM/dd/yyyy") + "' AND DenNgay>='" + pNS_LuongInfo.DenNgay.ToString("MM/dd/yyyy") + "'");
                    if (arrDr.Length > 0)
                    {
                        ThongBaoLoi("Đã có lương chưa cập nhật thông tin đến ngày.\nHoặc từ ngày của lương này nằm trong khoảng từ ngày và đến ngày của lương thêm vào trước đó.\n Đề nghị kiểm tra và cập nhật lại thông tin lương.");
                        return;
                    }
                    pSoQuyetDinhInfo.NS_SoQuyetDinhID = int.Parse(grvLuong.GetDataRow(grvLuong.FocusedRowHandle)[pSoQuyetDinhInfo.strNS_SoQuyetDinhID].ToString());
                    oBSoQuyetDinh.Update(pSoQuyetDinhInfo);
                    int IDNS_SoQuyetDinh = pSoQuyetDinhInfo.NS_SoQuyetDinhID;
                    pNS_LuongInfo.NS_LuongID = int.Parse(drLuong[pNS_LuongInfo.strNS_LuongID].ToString());
                    oBLuong.Update(GetpInfo(IDNS_SoQuyetDinh));
                    GhiLog("Sửa lương giáo viên '" + drGiaoVien[pGiaoVienInfo.strHoTen] + " hệ số phụ cấp " + pNS_LuongInfo.BacLuong + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    oBLuong.ToDataRow(pNS_LuongInfo, ref drLuong);
                    SuaThanhCong();
                    btnHuy_Click(null, null);
                }
            }
            catch
            {
                ThongBaoLoi("Có lỗi trong quá trình thêm hoặc sửa hoặc ghi log.");
            }
            grvGiaoVien_FocusedRowChanged(null, null);
            ClearText();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetGrvTrv(true);
            dxErrorProvider.ClearErrors();
            SetControl(true);
            dtpDenNgay.Enabled = false;
            btnLuu.Enabled = false;
            grvLuong_FocusedRowChanged(null, null);
        }

        private void frmPhuCap_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            Loaded = true;
            trvDonVi_FocusedNodeChanged(null, null);
            LoadCombo();
        }

        private void grvLuong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvLuong.FocusedRowHandle >= 0)
            {
                drLuong = grvLuong.GetDataRow(grvLuong.FocusedRowHandle);
                oBLuong.ToInfo(ref pNS_LuongInfo, drLuong);
                SetTextMain();
                SetText();
            }
            if (grvLuong != null)
                if (grvLuong.DataRowCount > 0 && grvLuong.FocusedRowHandle >= 0)
                {
                    SetButton(true);
                    drLuong = grvLuong.GetDataRow(grvLuong.FocusedRowHandle);
                    return;
                }
            SetButton(false);
            btnThem.Enabled = true;
            drLuong = null;
        }

        private void grvLuong_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void cmbNgachCongChuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDM_NgachCongChuc frm = new frmDM_NgachCongChuc(this, null);
                frm.ShowDialog();
                if (IDNS_NgachCongChuc > 0)
                {
                    cmbNgachCongChuc.Properties.DataSource = LoadNgachCongChuc();
                    reposNgachCongChuc.DataSource = LoadNgachCongChuc();
                    cmbNgachCongChuc.EditValue = IDNS_NgachCongChuc;

                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbNgachCongChuc.EditValue = null;
            }
        }

        private void cmbBacLuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNgachCongChuc.EditValue != null)
            {
                TrangThaiChonBac = cmbBacLuong.SelectedIndex;
                switch (TrangThaiChonBac)
                {
                    case -1:
                        {
                            break;
                        }
                    case 0:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_1"].ToString();
                            break;
                        }
                    case 1:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_2"].ToString();
                            break;
                        }
                    case 2:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_3"].ToString();
                            break;
                        }
                    case 3:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_4"].ToString();
                            break;
                        }
                    case 4:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_5"].ToString();
                            break;
                        }
                    case 5:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_6"].ToString();
                            break;
                        }
                    case 6:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_7"].ToString();
                            break;
                        }
                    case 7:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_8"].ToString();
                            break;
                        }
                    case 8:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_9"].ToString();
                            break;
                        }
                    case 9:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_10"].ToString();
                            break;
                        }
                    case 10:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_11"].ToString();
                            break;
                        }
                    case 11:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_12"].ToString();
                            break;
                        }
                    case 12:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_13"].ToString();
                            break;
                        }
                    case 13:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_14"].ToString();
                            break;
                        }
                    case 14:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_15"].ToString();
                            break;
                        }
                    case 15:
                        {
                            txtHeSoLuong.Text = dtNhomNgach.Rows[0]["HeSoLuongBac_16"].ToString();
                            break;
                        }
                }
            }
        }

        private void cmbNgachCongChuc_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbNgachCongChuc.EditValue != null)
            {
                dtNhomNgach = oBNS_NhomNgach.GetBy_NS_NgachCongChucID(int.Parse(cmbNgachCongChuc.EditValue.ToString()));
            }
            cmbBacLuong_SelectedIndexChanged(null, null);
        }
    }
}