using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.wsBusiness;
using TruongViet.UnimOs.Entity;
using System.Data.SqlClient;

namespace UnimOs.Khoa
{
    public partial class frmMonHoc : frmBase
    {
        private cBwsDM_MonHoc oBDM_MonHoc;
        private DM_MonHocInfo pDM_MonHocInfo;
        private EDIT_MODE edit;
        private int idx;
        private DataTable dtMonHoc, dtPhong;
        private bool Active = false;
        private string strPhongThem;

        public frmMonHoc()
        {
            InitializeComponent();
            oBDM_MonHoc = new cBwsDM_MonHoc();
            pDM_MonHocInfo = new DM_MonHocInfo();
            SetControl(false);
            SetButton(false);
            radiogroupSuDungPhong.SelectedIndex = 1;
            grdPhong.Enabled = false;
            CheckedChanged();
        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            LoadCombo();
            LoadGrid();
        }

        private void LoadCombo()
        {
            DataTable dtTrinhDo = LoadTrinhDo();
            cmbTrinhDo.Properties.DataSource = dtTrinhDo;
            if (dtTrinhDo.Rows.Count > 0)
                cmbTrinhDo.ItemIndex = 0;

            DataTable dtNganh = LoadNganh();
            cmbNganh.Properties.DataSource = dtNganh;
            if (dtNganh.Rows.Count > 0)
                cmbNganh.ItemIndex = 0;

            DataTable dtBoMon = LoadBoMon();
            cmbBoMon.Properties.DataSource = dtBoMon;
            if (dtBoMon.Rows.Count > 0)
                cmbBoMon.ItemIndex = 0;

            DataTable dtHinhThucThi = LoadHinhThucThi();
            cmbHinhThucThi.Properties.DataSource = dtHinhThucThi;
            if (dtHinhThucThi.Rows.Count > 0)
                cmbHinhThucThi.ItemIndex = 0;

            DataTable dtKhoiKienThuc = LoadKhoiKienThuc();
            cmbKhoiKienThuc.Properties.DataSource = dtKhoiKienThuc;
            if (dtKhoiKienThuc.Rows.Count > 0)
                cmbKhoiKienThuc.ItemIndex = 0;
        }

        private void LoadGrid()
        {
            dtMonHoc = oBDM_MonHoc.GetDanhSach(0);
            grdMonHoc.DataSource = dtMonHoc;
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void SetButton(bool status)
        {
            btnCapNhat.Enabled = status;
            btnHuy.Enabled = status;
            Active = status;
        }

        private void CheckedChanged()
        {
            chkTrinhDo_CheckedChanged(null, null);
            chkNganh_CheckedChanged(null, null);
            chkChuyenNganh_CheckedChanged(null, null);
        }

        private void ClearText()
        {
            txtMaMon.Text = "";
            txtTenMon.Text = "";
            txtTenVietTat.Text = "";
            txtTenMon_E.Text = "";
            txtLyThuyet.Text = "0";
            txtThucHanh.Text = "0";
            txtKhac1.Text = "0";
            txtKhac2.Text = "0";
            txtTong.Text = "0";
            txtSoHocTrinh.Text = "0";
            radiogroupSuDungPhong.SelectedIndex = 1;
        }

        private void SetText()
        {
            txtMaMon.Text = pDM_MonHocInfo.MaMonHoc;
            txtTenMon.Text = pDM_MonHocInfo.TenMonHoc;
            txtTenVietTat.Text = pDM_MonHocInfo.TenVietTat;
            txtTenMon_E.Text = pDM_MonHocInfo.TenMonHoc_E;
            txtLyThuyet.Text = pDM_MonHocInfo.LyThuyet.ToString();
            txtThucHanh.Text = pDM_MonHocInfo.ThucHanh.ToString();
            txtKhac1.Text = pDM_MonHocInfo.LoaiTietKhac1.ToString();
            txtKhac2.Text = pDM_MonHocInfo.LoaiTietKhac2.ToString();
            txtTong.Text = pDM_MonHocInfo.SoTiet.ToString();
            txtSoHocTrinh.Text = pDM_MonHocInfo.SoHocTrinh.ToString();

            if (pDM_MonHocInfo.IDDM_TrinhDo != -1)
            {
                cmbTrinhDo.EditValue = pDM_MonHocInfo.IDDM_TrinhDo;
                chkTrinhDo.Checked = true;
            }
            else
                chkTrinhDo.Checked = false;

            if (pDM_MonHocInfo.IDDM_Nganh != -1)
            {
                cmbNganh.EditValue = pDM_MonHocInfo.IDDM_Nganh;
                chkNganh.Checked = true;
            }
            else
                chkNganh.Checked = false;

            if (pDM_MonHocInfo.IDDM_ChuyenNganh != -1)
            {
                cmbChuyenNganh.EditValue = pDM_MonHocInfo.IDDM_ChuyenNganh;
                chkChuyenNganh.Checked = true;
            }
            else
                chkChuyenNganh.Checked = false;

            cmbBoMon.EditValue = pDM_MonHocInfo.IDDM_BoMon;
            cmbKhoiKienThuc.EditValue = pDM_MonHocInfo.IDDM_KhoiKienThuc;
            cmbHinhThucThi.EditValue = pDM_MonHocInfo.IDDM_HinhThucThi;
            radiogroupSuDungPhong.SelectedIndex = pDM_MonHocInfo.SuDungPhong;

            chkXepLich.Checked = pDM_MonHocInfo.ChoPhepXepLich;
            txtMoTa.Text = "" + pDM_MonHocInfo.MoTa;
            chkTinhDiemToanKhoa.Checked = pDM_MonHocInfo.TinhDiemToanKhoa;
            CheckedChanged();
        }

        private void GetpDM_MonHocInfo()
        {
            pDM_MonHocInfo.MaMonHoc = txtMaMon.Text.Trim();
            pDM_MonHocInfo.TenMonHoc = txtTenMon.Text.Trim();
            pDM_MonHocInfo.TenVietTat = txtTenVietTat.Text.Trim();
            pDM_MonHocInfo.TenMonHoc_E = txtTenMon_E.Text.Trim();
            pDM_MonHocInfo.LyThuyet = int.Parse(txtLyThuyet.Text.Trim());
            pDM_MonHocInfo.ThucHanh = int.Parse(txtThucHanh.Text.Trim());
            pDM_MonHocInfo.LoaiTietKhac1 = int.Parse(txtKhac1.Text.Trim());
            pDM_MonHocInfo.LoaiTietKhac2 = int.Parse(txtKhac2.Text.Trim());
            pDM_MonHocInfo.SoTiet = int.Parse(txtTong.Text.Trim());
            pDM_MonHocInfo.SoHocTrinh = float.Parse(txtSoHocTrinh.Text.Trim());
            pDM_MonHocInfo.ChoPhepXepLich = chkXepLich.Checked;

            if (chkTrinhDo.Checked)
                pDM_MonHocInfo.IDDM_TrinhDo = cmbTrinhDo.EditValue == null ? -1 : int.Parse(cmbTrinhDo.EditValue.ToString());
            else
                pDM_MonHocInfo.IDDM_TrinhDo = -1;
            if (chkNganh.Checked)
                pDM_MonHocInfo.IDDM_Nganh = cmbNganh.EditValue == null ? -1 : int.Parse(cmbNganh.EditValue.ToString());
            else
                pDM_MonHocInfo.IDDM_Nganh = -1;
            if (chkChuyenNganh.Checked)
                pDM_MonHocInfo.IDDM_ChuyenNganh = cmbChuyenNganh.EditValue == null ? -1 : int.Parse(cmbChuyenNganh.EditValue.ToString());
            else
                pDM_MonHocInfo.IDDM_ChuyenNganh = -1;

            pDM_MonHocInfo.IDDM_BoMon = int.Parse(cmbBoMon.EditValue.ToString());
            pDM_MonHocInfo.IDDM_KhoiKienThuc = int.Parse(cmbKhoiKienThuc.EditValue.ToString());
            pDM_MonHocInfo.IDDM_HinhThucThi = int.Parse(cmbHinhThucThi.EditValue.ToString());
            pDM_MonHocInfo.SuDungPhong = radiogroupSuDungPhong.SelectedIndex;
            pDM_MonHocInfo.TinhDiemToanKhoa = chkTinhDiemToanKhoa.Checked;
        }

        private void SavePhongMon()
        {
            cBwsXL_PhongHoc_MonHoc oBXL_PhongHoc_MonHoc = new cBwsXL_PhongHoc_MonHoc();
            XL_PhongHoc_MonHocInfo pXL_PhongHoc_MonHocInfo = new XL_PhongHoc_MonHocInfo();
            pXL_PhongHoc_MonHocInfo.IDDM_MonHoc = pDM_MonHocInfo.DM_MonHocID;
            string[] arrPhong = strPhongThem.Split(',');
            foreach (string strIDPhongHoc in arrPhong)
            {
                pXL_PhongHoc_MonHocInfo.IDDM_PhongHoc = int.Parse(strIDPhongHoc);
                oBXL_PhongHoc_MonHoc.Add(pXL_PhongHoc_MonHocInfo);
            }
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtMaMon.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtMaMon, "Mã môn học không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMaMon;
            }
            if (txtTenMon.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenMon, "Tên môn học không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenMon;
            }
            if (cmbBoMon.Text == string.Empty)
            {
                dxErrorProvider.SetError(cmbBoMon, "Bộ môn không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbBoMon;
            }
            if (cmbHinhThucThi.Text == string.Empty)
            {
                dxErrorProvider.SetError(cmbHinhThucThi, "Hình thức không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbHinhThucThi;
            }
            if (cmbKhoiKienThuc.Text == string.Empty)
            {
                dxErrorProvider.SetError(cmbKhoiKienThuc, "Khối kiến thức không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbKhoiKienThuc;
            }        
          
            if ((CtrlErr != null))
                return false;
            else
                return true;
        }

        private void chkTrinhDo_CheckedChanged(object sender, EventArgs e)
        {
            cmbTrinhDo.Enabled = chkTrinhDo.Checked;
        }

        private void chkNganh_CheckedChanged(object sender, EventArgs e)
        {
            cmbNganh.Enabled = chkNganh.Checked;
            if (chkNganh.Checked == false)
                chkChuyenNganh.Checked = false;
            chkChuyenNganh.Enabled = chkNganh.Checked;
        }

        private void chkChuyenNganh_CheckedChanged(object sender, EventArgs e)
        {
            cmbChuyenNganh.Enabled = chkChuyenNganh.Checked;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            edit = EDIT_MODE.THEM;
            grdMonHoc.Enabled = false;
            pDM_MonHocInfo.DM_MonHocID = 0;
            SetButton(true);
            txtMaMon.Focus();
            strPhongThem = "";
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            edit = EDIT_MODE.SUA;
            grdMonHoc.Enabled = false;
            SetButton(true);
            txtMaMon.Focus();
            //SetText();
            if (radiogroupSuDungPhong.SelectedIndex == 2)
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    oBDM_MonHoc.Delete(pDM_MonHocInfo);
                    dtMonHoc.Rows.Remove(grvMonHoc.GetDataRow(idx));
                    // ghi log
                    GhiLog("Xóa môn học '" + pDM_MonHocInfo.TenMonHoc + "' khỏi cơ sở dữ liệu", "Xóa", this.Tag.ToString());
                    XoaThanhCong();
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            try
            {
                GetpDM_MonHocInfo();
                DataRow drNew;
                if (edit == EDIT_MODE.THEM)
                {
                    pDM_MonHocInfo.DM_MonHocID = oBDM_MonHoc.Add(pDM_MonHocInfo);

                    if (strPhongThem != "")
                    {
                        SavePhongMon();
                    }

                    drNew = dtMonHoc.NewRow();
                    oBDM_MonHoc.ToDataRow(pDM_MonHocInfo, ref drNew);

                    DataTable dtKhoa = new cBwsDM_Khoa().GetByIDBoMon(pDM_MonHocInfo.IDDM_BoMon);
                    drNew["TenKhoa"] = dtKhoa.Rows[0]["TenKhoa"].ToString();

                    drNew["TenBoMon"] = cmbBoMon.Text;
                    drNew["TenKhoiKienThuc"] = cmbKhoiKienThuc.Text;
                    dtMonHoc.Rows.Add(drNew);

                    // ghi log
                    GhiLog("Thêm môn học '" + pDM_MonHocInfo.TenMonHoc + "' khỏi cơ sở dữ liệu", "Thêm", this.Tag.ToString());

                    ClearText();
                    txtMaMon.Focus();
                }
                else
                {
                    oBDM_MonHoc.Update(pDM_MonHocInfo);
                    drNew = dtMonHoc.NewRow();

                    DataTable dtKhoa = new cBwsDM_Khoa().GetByIDBoMon(pDM_MonHocInfo.IDDM_BoMon);
                    drNew["TenKhoa"] = dtKhoa.Rows[0]["TenKhoa"].ToString();

                    drNew["TenBoMon"] = cmbBoMon.Text;
                    drNew["TenKhoiKienThuc"] = cmbKhoiKienThuc.Text;
                    oBDM_MonHoc.ToDataRow(pDM_MonHocInfo, ref drNew);
                    DataRow dr = grvMonHoc.GetDataRow(idx);
                    dtMonHoc.Rows.InsertAt(drNew, idx + 1);
                    dtMonHoc.Rows.Remove(dr);

                    // ghi log
                    GhiLog("Sửa môn học '" + pDM_MonHocInfo.TenMonHoc + "' trong cơ sở dữ liệu", "Sửa", this.Tag.ToString());

                    btnHuy_Click(null, null);
                    grdMonHoc.Enabled = true;

                    ThongBao("Cập nhật thành công.");
                }
            }
            catch (SqlException SqlEx)
            {
                ThongBao(SqlEx.Message); 
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dxErrorProvider.ClearErrors();
            grdMonHoc.Enabled = true;
            grvMonHoc_FocusedRowChanged(null, null);
            SetButton(false);
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void grvMonHoc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvMonHoc.DataRowCount > 0)
            {
                if (grvMonHoc.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    idx = grvMonHoc.FocusedRowHandle;
                    DataRow dr = grvMonHoc.GetDataRow(idx);

                    pDM_MonHocInfo.DM_MonHocID = int.Parse(dr[pDM_MonHocInfo.strDM_MonHocID].ToString());
                    pDM_MonHocInfo.MaMonHoc = dr[pDM_MonHocInfo.strMaMonHoc].ToString();
                    pDM_MonHocInfo.TenMonHoc = dr[pDM_MonHocInfo.strTenMonHoc].ToString();
                    pDM_MonHocInfo.TenVietTat = dr[pDM_MonHocInfo.strTenVietTat].ToString();
                    pDM_MonHocInfo.TenMonHoc_E = dr[pDM_MonHocInfo.strTenMonHoc_E].ToString();
                    pDM_MonHocInfo.LyThuyet = int.Parse(dr[pDM_MonHocInfo.strLyThuyet].ToString());
                    pDM_MonHocInfo.ThucHanh = int.Parse(dr[pDM_MonHocInfo.strThucHanh].ToString());
                    pDM_MonHocInfo.LoaiTietKhac1 = int.Parse("0" + dr[pDM_MonHocInfo.strLoaiTietKhac1]);
                    pDM_MonHocInfo.LoaiTietKhac2 = int.Parse("0" + dr[pDM_MonHocInfo.strLoaiTietKhac2]);
                    pDM_MonHocInfo.SoTiet = int.Parse(dr[pDM_MonHocInfo.strSoTiet].ToString());
                    pDM_MonHocInfo.SoHocTrinh = float.Parse(dr[pDM_MonHocInfo.strSoHocTrinh].ToString());
                    pDM_MonHocInfo.IDDM_TrinhDo = "" + dr[pDM_MonHocInfo.strIDDM_TrinhDo] == "" ? 0 : int.Parse(dr[pDM_MonHocInfo.strIDDM_TrinhDo].ToString());
                    pDM_MonHocInfo.IDDM_Nganh = "" + dr[pDM_MonHocInfo.strIDDM_Nganh] == "" ? 0 : int.Parse(dr[pDM_MonHocInfo.strIDDM_Nganh].ToString());
                    pDM_MonHocInfo.IDDM_ChuyenNganh = "" + dr[pDM_MonHocInfo.strIDDM_ChuyenNganh] == "" ? 0 : int.Parse(dr[pDM_MonHocInfo.strIDDM_ChuyenNganh].ToString());
                    pDM_MonHocInfo.IDDM_BoMon = int.Parse(dr[pDM_MonHocInfo.strIDDM_BoMon].ToString());
                    pDM_MonHocInfo.IDDM_KhoiKienThuc = int.Parse(dr[pDM_MonHocInfo.strIDDM_KhoiKienThuc].ToString());
                    pDM_MonHocInfo.IDDM_HinhThucThi = int.Parse(dr[pDM_MonHocInfo.strIDDM_HinhThucThi].ToString());
                    pDM_MonHocInfo.SuDungPhong = int.Parse(dr[pDM_MonHocInfo.strSuDungPhong].ToString());
                    pDM_MonHocInfo.ChoPhepXepLich = bool.Parse(dr[pDM_MonHocInfo.strChoPhepXepLich].ToString());
                    pDM_MonHocInfo.MoTa = txtMoTa.Text.Trim();
                    pDM_MonHocInfo.TinhDiemToanKhoa = bool.Parse(dr[pDM_MonHocInfo.strTinhDiemToanKhoa].ToString());

                    SetText();
                }
                else
                {
                    SetControl(false);
                }
            }
        }

        private void radiogroupSuDungPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radiogroupSuDungPhong.SelectedIndex == 2)
            {
                cBwsXL_PhongHoc_MonHoc oBXL_PhongHoc_MonHoc = new cBwsXL_PhongHoc_MonHoc();
                dtPhong = oBXL_PhongHoc_MonHoc.GetByIDDM_MonHoc(pDM_MonHocInfo.DM_MonHocID);
                grdPhong.DataSource = dtPhong;
                grdPhong.Enabled = true;
                if (Active == true)
                {
                    btnThem.Enabled = true;
                    btnXoa.Enabled = true;
                }
            }
            else
            {
                grdPhong.DataSource = null;
                grdPhong.Enabled = false;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string strPhongHoc = "";
            for (int i = 0; i < grvPhong.DataRowCount; i++)
            {
                strPhongHoc += grvPhong.GetDataRow(i)["IDDM_PhongHoc"].ToString() + ",";
            }
            if (strPhongHoc != "")
                strPhongHoc = strPhongHoc.Substring(0, strPhongHoc.Length - 1);
            dlgChonPhongHoc dlg = new dlgChonPhongHoc(strPhongHoc);
            dlg.ShowDialog();
            strPhongThem = dlg.Tag.ToString();
            if (strPhongThem != "")
            {
                if (edit == EDIT_MODE.SUA)
                    SavePhongMon();

                DataTable dtThem = oBDM_MonHoc.GetPhongChuyenMon(strPhongThem);
                DataRow drNew;
                foreach (DataRow dr in dtThem.Rows)
                {
                    drNew = dtPhong.NewRow();
                    drNew["IDDM_PhongHoc"] = dr["DM_PhongHocID"];
                    drNew["Chon"] = false;
                    drNew["TenPhongHoc"] = dr["TenPhongHoc"];
                    drNew["TenToaNha"] = dr["TenToaNha"];
                    drNew["SucChua"] = dr["SucChua"];
                    dtPhong.Rows.Add(drNew);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int IDDM_PhongHoc;
            if (edit == EDIT_MODE.THEM)
            {
                for (int i = 0; i < grvPhong.DataRowCount; i++)
                {
                    if (bool.Parse(grvPhong.GetDataRow(i)["Chon"].ToString()) == true)
                    {
                        IDDM_PhongHoc = int.Parse(grvPhong.GetDataRow(i)["IDDM_PhongHoc"].ToString());
                        dtPhong.Rows.Remove(grvPhong.GetDataRow(i));
                        string[] arr = strPhongThem.Split(',');
                        strPhongThem = "";
                        for (int j = 0; j < arr.Length; j++)
                        {
                            if (arr[j] == IDDM_PhongHoc.ToString())
                            {
                                arr[j] = "";
                            }
                            else
                                strPhongThem += arr[j] + ",";
                        }
                    }
                }
                strPhongThem = strPhongThem.Substring(0, strPhongThem.Length - 1);
            }
            else
            {
                cBwsXL_PhongHoc_MonHoc oBXL_PhongHoc_MonHoc = new cBwsXL_PhongHoc_MonHoc();
                for (int i = 0; i < grvPhong.DataRowCount; i++)
                {
                    if (bool.Parse(grvPhong.GetDataRow(i)["Chon"].ToString()) == true)
                    {
                        IDDM_PhongHoc = int.Parse(grvPhong.GetDataRow(i)["IDDM_PhongHoc"].ToString());
                        oBXL_PhongHoc_MonHoc.DeleteByMonPhong(IDDM_PhongHoc, pDM_MonHocInfo.DM_MonHocID);
                        dtPhong.Rows.Remove(grvPhong.GetDataRow(i));
                    }
                }
            }
        }

       
        private void txtTong_EditValueChanged(object sender, EventArgs e)
        {
            txtSoHocTrinh.Text = Math.Round((float.Parse(txtTong.Text) / 15), 1).ToString(); //float.Parse((int.Parse(txtTong.Text) / 15).ToString()).ToString();
        }

        private void txtLyThuyet_Leave(object sender, EventArgs e)
        {
            txtTong.Text = (int.Parse(txtKhac1.Text) + int.Parse(txtLyThuyet.Text) + int.Parse(txtKhac2.Text) + int.Parse(txtThucHanh.Text)).ToString();
        }

        private void txtThucHanh_Leave(object sender, EventArgs e)
        {
            txtTong.Text = (int.Parse(txtKhac1.Text) + int.Parse(txtLyThuyet.Text) + int.Parse(txtKhac2.Text) + int.Parse(txtThucHanh.Text)).ToString();
        }

        private void txtKhac1_Leave(object sender, EventArgs e)
        {
            txtTong.Text = (int.Parse(txtKhac1.Text) + int.Parse(txtLyThuyet.Text) + int.Parse(txtKhac2.Text) + int.Parse(txtThucHanh.Text)).ToString();
        }

        private void txtKhac2_Leave(object sender, EventArgs e)
        {
            txtTong.Text = (int.Parse(txtKhac1.Text) + int.Parse(txtLyThuyet.Text) + int.Parse(txtKhac2.Text) + int.Parse(txtThucHanh.Text)).ToString();
        }

        private void grvMonHoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                barbtnThem_ItemClick(null, null);
            }
            else if (e.KeyCode == Keys.F3)
            {
                barbtnSua_ItemClick(null, null);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                barbtnXoa_ItemClick(null, null);
            }
        }

        private void barbtnXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportToXls(grvMonHoc);
        }
    }
}