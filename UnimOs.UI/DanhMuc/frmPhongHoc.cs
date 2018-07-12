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
using System.Data.SqlClient;

namespace UnimOs.UI
{
    public partial class frmPhongHoc : frmBase
    {
        private cBDM_DiaDiem oBDM_DiaDiem;
        private DM_DiaDiemInfo pDM_DiaDiemInfo;
        private cBDM_ToaNha oBDM_ToaNha;
        private DM_ToaNhaInfo pDM_ToaNhaInfo;
        private cBDM_PhongHoc oBDM_PhongHoc;
        public DM_PhongHocInfo pDM_PhongHocInfo;
        private bool UPDATE;
        private DataTable dtDiaDiem, dtToaNha, dtPhongHoc;
        private int idxDiaDiem, idxToaNha, idxPhongHoc;

        public frmPhongHoc()
        {
            InitializeComponent();
            oBDM_DiaDiem = new cBDM_DiaDiem();
            oBDM_ToaNha = new cBDM_ToaNha();
            oBDM_PhongHoc = new cBDM_PhongHoc();
            pDM_DiaDiemInfo = new DM_DiaDiemInfo();
            pDM_ToaNhaInfo = new DM_ToaNhaInfo();
            pDM_PhongHocInfo = new DM_PhongHocInfo();
        }

        private void frmPhongHoc_Load(object sender, EventArgs e)
        {
            panelDiaDiem.Visible = false;
            panelToaNha.Visible = false;
            LoadDiaDiem();
        }


        private void LoadDiaDiem()
        {
            pDM_DiaDiemInfo.DM_DiaDiemID = 0;
            dtDiaDiem = oBDM_DiaDiem.Get(pDM_DiaDiemInfo);
            grdDiaDiem.DataSource = dtDiaDiem;
        }

        private void GridEnable(bool status)
        {
            grdDiaDiem.Enabled = status;
            grdToaNha.Enabled = status;
            grdPhongHoc.Enabled = status;
        }

        #region Xử lý phần địa điểm
        private bool CheckValidDiaDiem()
        {
            return true;
        }

        private void SetTextDD()
        {
            if (!UPDATE)
            {
                txtMaDiaDiem.Text = "";
                txtTenDiaDiem.Text = "";
                txtGhiChu.Text = "";
            }
            else
            {
                txtMaDiaDiem.Text = pDM_DiaDiemInfo.MaDiaDiem;
                txtTenDiaDiem.Text = pDM_DiaDiemInfo.TenDiaDiem;
                txtGhiChu.Text = pDM_DiaDiemInfo.MoTa;
            }
        }

        private void GetpDM_DiaDiem()
        {
            pDM_DiaDiemInfo.MaDiaDiem = txtMaDiaDiem.Text.Trim();
            pDM_DiaDiemInfo.TenDiaDiem = txtTenDiaDiem.Text.Trim();
            pDM_DiaDiemInfo.MoTa = txtGhiChu.Text.Trim();
        }

        private void grvDiaDiem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvDiaDiem.DataRowCount > 0)
            {
                idxDiaDiem = grvDiaDiem.FocusedRowHandle;
                pDM_DiaDiemInfo.DM_DiaDiemID = int.Parse(grvDiaDiem.GetDataRow(idxDiaDiem)[pDM_DiaDiemInfo.strDM_DiaDiemID].ToString());
                pDM_DiaDiemInfo.MaDiaDiem = grvDiaDiem.GetDataRow(idxDiaDiem)[pDM_DiaDiemInfo.strMaDiaDiem].ToString();
                pDM_DiaDiemInfo.TenDiaDiem = grvDiaDiem.GetDataRow(idxDiaDiem)[pDM_DiaDiemInfo.strTenDiaDiem].ToString();
                pDM_DiaDiemInfo.MoTa = "" + grvDiaDiem.GetDataRow(idxDiaDiem)[pDM_DiaDiemInfo.strMoTa];
                pDM_ToaNhaInfo.IDDM_DiaDiem = pDM_DiaDiemInfo.DM_DiaDiemID;
                dtToaNha = oBDM_ToaNha.GetByIDDiaDiem(pDM_ToaNhaInfo.IDDM_DiaDiem);
                grdToaNha.DataSource = dtToaNha;
                grvToaNha_FocusedRowChanged(null, null);
            }
        }

        private void grdDiaDiem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && grdDiaDiem.ClientRectangle.Contains(e.X, e.Y))
            {
                popupDiaDiem.ShowPopup(MousePosition);
            }
        }

        private void barbtnThemDiaDiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UPDATE = false;
            GridEnable(false);
            SetTextDD();
            panelDiaDiem.Visible = true;
            txtMaDiaDiem.Focus();
        }

        private void barbtnSuaDiaDiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvDiaDiem.DataRowCount <= 0) return;
            GridEnable(false);
            UPDATE = true;
            SetTextDD();
            panelDiaDiem.Visible = true;
        }

        private void barbtnXoaDiaDiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                if (grvDiaDiem.DataRowCount <= 0) return;
                try
                {
                    oBDM_DiaDiem.Delete(pDM_DiaDiemInfo);
                    DataRow dr = grvDiaDiem.GetDataRow(idxDiaDiem);
                    dtDiaDiem.Rows.Remove(dr);
                    XoaThanhCong();
                }
                catch
                {
                    ThongBao("Địa điểm này đã được sử dụng, bạn không thể xóa.");
                }
            }
        }

        private void btnCapNhatDD_Click(object sender, EventArgs e)
        {
            if (!CheckValidDiaDiem()) return;
            GetpDM_DiaDiem();
            try
            {
                if (UPDATE)
                {
                    int idxNew = idxDiaDiem;
                    oBDM_DiaDiem.Update(pDM_DiaDiemInfo);
                    DataRow dr = grvDiaDiem.GetDataRow(idxDiaDiem);
                    DataRow drNew = dtDiaDiem.NewRow();
                    oBDM_DiaDiem.ToDataRow(pDM_DiaDiemInfo, ref drNew);
                    dtDiaDiem.Rows.InsertAt(drNew, idxNew + 1);
                    dtDiaDiem.Rows.Remove(dr);
                    grvDiaDiem.FocusedRowHandle = idxNew;
                    btnHuyDD_Click(null, null);
                    SuaThanhCong();
                }
                else
                {
                    pDM_DiaDiemInfo.DM_DiaDiemID = oBDM_DiaDiem.Add(pDM_DiaDiemInfo);
                    DataRow drNew = dtDiaDiem.NewRow();
                    oBDM_DiaDiem.ToDataRow(pDM_DiaDiemInfo, ref drNew);
                    dtDiaDiem.Rows.Add(drNew);
                    grvDiaDiem.FocusedRowHandle = grvDiaDiem.DataRowCount - 1;
                    SetTextDD();
                    txtMaDiaDiem.Focus();
                }
            }
            catch (SqlException SqlEx)
            {
                ThongBaoLoi(SqlEx.Message);
            }
        }

        private void btnHuyDD_Click(object sender, EventArgs e)
        {
            panelDiaDiem.Visible = false;
            UPDATE = false;
            SetTextDD();
            GridEnable(true);
            dxErrorProvider.ClearErrors();
        }
        #endregion

        #region Xử lý phần tòa nhà
        private bool CheckValidToaNha()
        {
            return true;
        }

        private void SetTextTN()
        {
            if (!UPDATE)
            {
                txtMaToaNha.Text = "";
                txtTenToaNha.Text = "";
            }
            else
            {
                txtMaToaNha.Text = pDM_ToaNhaInfo.MaToaNha;
                txtTenToaNha.Text = pDM_ToaNhaInfo.TenToaNha;
            }
        }

        private void GetpDM_ToaNha()
        {
            pDM_ToaNhaInfo.MaToaNha = txtMaToaNha.Text.Trim();
            pDM_ToaNhaInfo.TenToaNha = txtTenToaNha.Text.Trim();
        }

        private void grvToaNha_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvToaNha.DataRowCount > 0)
            {
                idxToaNha = grvToaNha.FocusedRowHandle;
                pDM_ToaNhaInfo.DM_ToaNhaID = int.Parse(grvToaNha.GetDataRow(idxToaNha)[pDM_ToaNhaInfo.strDM_ToaNhaID].ToString());
                pDM_ToaNhaInfo.MaToaNha = grvToaNha.GetDataRow(idxToaNha)[pDM_ToaNhaInfo.strMaToaNha].ToString();
                pDM_ToaNhaInfo.TenToaNha = grvToaNha.GetDataRow(idxToaNha)[pDM_ToaNhaInfo.strTenToaNha].ToString();

                pDM_PhongHocInfo.IDDM_ToaNha = pDM_ToaNhaInfo.DM_ToaNhaID;
                dtPhongHoc = oBDM_PhongHoc.GetByIDToaNha(pDM_PhongHocInfo.IDDM_ToaNha);
                grdPhongHoc.DataSource = dtPhongHoc;
                grvPhongHoc.ExpandAllGroups();
            }
        }

        private void grdToaNha_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && grdToaNha.ClientRectangle.Contains(e.X, e.Y))
            {
                popupToaNha.ShowPopup(MousePosition);
            }
        }

        private void barbtnThemToaNha_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UPDATE = false;
            SetTextTN();
            GridEnable(false);
            panelToaNha.Visible = true;
            txtMaToaNha.Focus();
        }

        private void barbtnSuaToaNha_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvToaNha.DataRowCount <= 0) return;
            UPDATE = true;
            SetTextTN();
            GridEnable(false);
            panelToaNha.Visible = true;
        }

        private void barbtnXoaToaNha_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                if (grvToaNha.DataRowCount <= 0) return;
                try
                {
                    oBDM_ToaNha.Delete(pDM_ToaNhaInfo);
                    DataRow dr = grvToaNha.GetDataRow(idxToaNha);
                    dtToaNha.Rows.Remove(dr);
                    XoaThanhCong();
                }
                catch
                {
                    ThongBao("Tòa nhà này đã được sử dụng, bạn không thể xóa.");
                }
            }
        }

        private void btnCapNhatTN_Click(object sender, EventArgs e)
        {
            if (!CheckValidToaNha()) return;
            GetpDM_ToaNha();
            try
            {
                if (UPDATE)
                {
                    int idxNew = idxToaNha;
                    oBDM_ToaNha.Update(pDM_ToaNhaInfo);
                    DataRow dr = grvToaNha.GetDataRow(idxToaNha);
                    DataRow drNew = dtToaNha.NewRow();
                    oBDM_ToaNha.ToDataRow(pDM_ToaNhaInfo, ref drNew);
                    dtToaNha.Rows.InsertAt(drNew, idxNew + 1);
                    dtToaNha.Rows.Remove(dr);
                    grvToaNha.FocusedRowHandle = idxNew;
                    btnHuyTN_Click(null, null);
                    XtraMessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    pDM_ToaNhaInfo.DM_ToaNhaID = oBDM_ToaNha.Add(pDM_ToaNhaInfo);
                    DataRow drNew = dtToaNha.NewRow();
                    oBDM_ToaNha.ToDataRow(pDM_ToaNhaInfo, ref drNew);
                    dtToaNha.Rows.Add(drNew);
                    grvToaNha.FocusedRowHandle = grvToaNha.DataRowCount - 1;
                    SetTextTN();
                    txtMaToaNha.Focus();
                }
            }
            catch (SqlException SqlEx)
            {
                XtraMessageBox.Show(SqlEx.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuyTN_Click(object sender, EventArgs e)
        {
            panelToaNha.Visible = false;
            UPDATE = false;
            SetTextTN();
            GridEnable(true);
            dxErrorProvider.ClearErrors();
        }
        #endregion

        #region Xử lý phần phòng học
        public void EditPhongHoc(bool mUPDATE, string TenLoaiPhong, string TenTang)
        {
            DataRow drNew;
            if (mUPDATE == true)
            {
                int idxNew = idxPhongHoc;
                drNew = dtPhongHoc.NewRow();
                oBDM_PhongHoc.ToDataRow(pDM_PhongHocInfo, ref drNew);
                drNew["TenTang"] = TenTang;
                drNew["TenLoaiPhong"] = TenLoaiPhong;
                DataRow[] arrDr = dtPhongHoc.Select(pDM_PhongHocInfo.strDM_PhongHocID + " = " + pDM_PhongHocInfo.DM_PhongHocID.ToString());
                dtPhongHoc.Rows.InsertAt(drNew, idxNew + 1);
                dtPhongHoc.Rows.Remove(arrDr[0]);
                grvPhongHoc.FocusedRowHandle = idxNew;
            }
            else
            {
                drNew = dtPhongHoc.NewRow();
                oBDM_PhongHoc.ToDataRow(pDM_PhongHocInfo, ref drNew);
                drNew["TenTang"] = TenTang;
                drNew["TenLoaiPhong"] = TenLoaiPhong;
                dtPhongHoc.Rows.Add(drNew);
                grvPhongHoc.FocusedRowHandle = grvPhongHoc.DataRowCount - 1;
            }
        }

        private void grvPhongHoc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvPhongHoc.DataRowCount > 0)
            {
                idxPhongHoc = grvPhongHoc.FocusedRowHandle;
                pDM_PhongHocInfo.DM_PhongHocID = int.Parse(grvPhongHoc.GetDataRow(idxPhongHoc)[pDM_PhongHocInfo.strDM_PhongHocID].ToString());
                pDM_PhongHocInfo.TenPhongHoc = grvPhongHoc.GetDataRow(idxPhongHoc)[pDM_PhongHocInfo.strTenPhongHoc].ToString();
                pDM_PhongHocInfo.IDDM_Tang = int.Parse(grvPhongHoc.GetDataRow(idxPhongHoc)[pDM_PhongHocInfo.strIDDM_Tang].ToString());
                pDM_PhongHocInfo.SucChua = int.Parse(grvPhongHoc.GetDataRow(idxPhongHoc)[pDM_PhongHocInfo.strSucChua].ToString());
                pDM_PhongHocInfo.IDDM_LoaiPhong = int.Parse(grvPhongHoc.GetDataRow(idxPhongHoc)[pDM_PhongHocInfo.strIDDM_LoaiPhong].ToString());
            }
        }

        private void grdPhongHoc_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && grdPhongHoc.ClientRectangle.Contains(e.X, e.Y))
            {
                popupPhongHoc.ShowPopup(MousePosition);
            }
        }

        private void barbtnThemPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgPhongHoc dlg = new dlgPhongHoc(this, false);
            dlg.ShowDialog();
        }

        private void barbtnSuaPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvPhongHoc.DataRowCount <= 0) return;
            dlgPhongHoc dlg = new dlgPhongHoc(this, true);
            dlg.ShowDialog();
        }

        private void barbtnXoaPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvPhongHoc.FocusedRowHandle >= 0)
                if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
                {
                    try
                    {
                        oBDM_PhongHoc.Delete(pDM_PhongHocInfo);
                        DataRow drPhong = grvPhongHoc.GetDataRow(grvPhongHoc.FocusedRowHandle);
                        dtPhongHoc.Rows.Remove(drPhong);
                        XoaThanhCong();
                    }
                    catch
                    {
                        XoaThatBai();
                    }
                }
        }
        #endregion

        private void grvDiaDiem_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                e.Info.ImageIndex = -1;
            }
        }
    }
}