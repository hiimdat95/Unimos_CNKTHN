using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Business;
using System.Data.SqlClient;

namespace UnimOs.UI
{
    public partial class frmNganhChuyenNganh : frmBase
    {
        private cBDM_Nganh oBDM_Nganh;
        private cBDM_ChuyenNganh oBDM_ChuyenNganh;
        private DM_NganhInfo pDM_NganhInfo;
        public DM_ChuyenNganhInfo pDM_ChuyenNganhInfo;
        private DataTable dtNganh, dtChuyenNganh;
        private int idxNganh, idxChuyenNganh;
        private string Ma;
        private bool Loaded = false, UPDATE, ShowPopup = false;

        public frmNganhChuyenNganh()
        {
            InitializeComponent();
            oBDM_Nganh = new cBDM_Nganh();
            pDM_NganhInfo = new DM_NganhInfo();
            oBDM_ChuyenNganh = new cBDM_ChuyenNganh();
            pDM_ChuyenNganhInfo = new DM_ChuyenNganhInfo();
            panelTop.Visible = false;
            SetControl(false);
        }

        private void frmNganhChuyenNganh_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            DataTable dtKhoa = LoadKhoa();
            cmbKhoa.Properties.DataSource = dtKhoa;
            Loaded = true;
            if (dtKhoa.Rows.Count > 0)
                cmbKhoa.ItemIndex = 0;
        }

        private void ClearText()
        {
            txtMaNganh.Text = "";
            txtTenNganh.Text = "";
            txtTenNganh_E.Text = "";
        }

        private void SetText()
        {
            txtMaNganh.Text = pDM_NganhInfo.MaNganh + "";
            txtTenNganh.Text = pDM_NganhInfo.TenNganh + "";
            txtTenNganh_E.Text = pDM_NganhInfo.TenNganh_E + "";
        }

        private void GetpNganh()
        {
            pDM_NganhInfo.IDDM_Khoa = int.Parse(cmbKhoa.EditValue.ToString());
            pDM_NganhInfo.MaNganh = txtMaNganh.Text.Trim();
            pDM_NganhInfo.TenNganh = txtTenNganh.Text.Trim();
            pDM_NganhInfo.TenNganh_E = txtTenNganh_E.Text.Trim();
        }

        private void SetControl(bool status)
        {
            barbtnSuaNganh.Enabled = status;
            barbtnXoaNganh.Enabled = status;
        }

        public void EditChuyenNganh(bool mUPDATE)
        {
            DataRow drNew;
            if (mUPDATE == true)
            {
                int idxNew = idxChuyenNganh;
                drNew = dtChuyenNganh.NewRow();
                oBDM_ChuyenNganh.ToDataRow(pDM_ChuyenNganhInfo, ref drNew);
                DataRow[] arrDr = dtChuyenNganh.Select(pDM_ChuyenNganhInfo.strDM_ChuyenNganhID + " = " + pDM_ChuyenNganhInfo.DM_ChuyenNganhID.ToString());
                dtChuyenNganh.Rows.InsertAt(drNew, idxNew + 1);
                dtChuyenNganh.Rows.Remove(arrDr[0]);
                grvChuyenNganh.FocusedRowHandle = idxNew;
            }
            else
            {
                drNew = dtChuyenNganh.NewRow();
                oBDM_ChuyenNganh.ToDataRow(pDM_ChuyenNganhInfo, ref drNew);
                dtChuyenNganh.Rows.Add(drNew);
                grvChuyenNganh.FocusedRowHandle = grvChuyenNganh.DataRowCount - 1;
            }
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtMaNganh.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtMaNganh, "Mã ngành không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMaNganh;
            }
            if (txtTenNganh.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenNganh, "Tên ngành không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenNganh;
            }
            //kiểm tra mã nhập vào có trùng với dữ liệu trước không.
            if (UPDATE == true && txtMaNganh.Text.Trim() == Ma)
            {
                UPDATE = true;
            }
            else
            {
                if (grvNganh.RowCount != 0)
                {
                    for (int i = 0; i < grvNganh.RowCount; i++)
                    {
                        if (txtMaNganh.Text.Trim() == grvNganh.GetDataRow(i)[pDM_NganhInfo.strMaNganh].ToString())
                        {

                            if (CtrlErr == null) CtrlErr = txtMaNganh;
                            txtMaNganh.Text = "";
                            txtMaNganh.Focus();
                            ThongBao("Mã ngành bạn nhập đã bị trùng");
                            break;
                        }
                    }
                }
            }
            if ((CtrlErr != null))
                return false;
            else
                return true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            Ma = pDM_NganhInfo.MaNganh;
            if (!CheckValid()) return;
            GetpNganh();
            try
            {
                if (UPDATE)
                {
                    int idxNew = idxNganh;
                    oBDM_Nganh.Update(pDM_NganhInfo);
                    btnHuy_Click(null, null);
                    DataRow[] arrDr = dtNganh.Select(pDM_NganhInfo.strDM_NganhID + " = " + pDM_NganhInfo.DM_NganhID.ToString());
                    DataRow drNew = dtNganh.NewRow();
                    oBDM_Nganh.ToDataRow(pDM_NganhInfo, ref drNew);
                    dtNganh.Rows.InsertAt(drNew, idxNew + 1);
                    dtNganh.Rows.Remove(arrDr[0]);
                    grvNganh.FocusedRowHandle = idxNew;
                    // ghi log
                    GhiLog("Sửa chuyên ngành '" + pDM_ChuyenNganhInfo.TenChuyenNganh + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    SuaThanhCong();
                }
                else
                {
                    pDM_NganhInfo.DM_NganhID = oBDM_Nganh.Add(pDM_NganhInfo);
                    DataRow dr = dtNganh.NewRow();
                    oBDM_Nganh.ToDataRow(pDM_NganhInfo, ref dr);
                    dtNganh.Rows.Add(dr);
                    grvNganh.FocusedRowHandle = grvNganh.DataRowCount - 1;
                    // ghi log
                    GhiLog("Thêm chuyên ngành '" + pDM_ChuyenNganhInfo.TenChuyenNganh + "' vào trong CSDL ", "Thêm", this.Tag.ToString());
                    ClearText();
                    txtMaNganh.Focus();
                }
            }
            catch (SqlException SqlEx)
            {
                ThongBao(SqlEx.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panelTop.Visible = false;
            cmbKhoa.Enabled = true;
            grdNganh.Enabled = true;
            dxErrorProvider.ClearErrors();
        }

        private void barbtnThemNganh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearText();
            UPDATE = false;
            panelTop.Visible = true;
            cmbKhoa.Enabled = false;
            txtMaNganh.Focus();
        }

        private void barbtnSuaNganh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UPDATE = true;
            SetText();
            panelTop.Visible = true;
            cmbKhoa.Enabled = false;
            grdNganh.Enabled = false;
        }

        private void barbtnXoaNganh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    oBDM_Nganh.Delete(pDM_NganhInfo);
                    DataRow dr = grvNganh.GetDataRow(grvNganh.FocusedRowHandle);
                    dtNganh.Rows.Remove(dr);
                    // ghi log
                    GhiLog("Xóa chuyên ngành '" + pDM_ChuyenNganhInfo.TenChuyenNganh + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    XoaThanhCong();
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private void grvNganh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvNganh.DataRowCount > 0)
            {
                SetControl(true);
                idxNganh = grvNganh.FocusedRowHandle;
                pDM_NganhInfo.DM_NganhID = int.Parse(grvNganh.GetDataRow(idxNganh)[pDM_NganhInfo.strDM_NganhID].ToString());
                pDM_NganhInfo.MaNganh = grvNganh.GetDataRow(idxNganh)[pDM_NganhInfo.strMaNganh].ToString();
                pDM_NganhInfo.TenNganh = grvNganh.GetDataRow(idxNganh)[pDM_NganhInfo.strTenNganh].ToString();
                pDM_NganhInfo.TenNganh_E = grvNganh.GetDataRow(idxNganh)[pDM_NganhInfo.strTenNganh_E].ToString();

                pDM_ChuyenNganhInfo.IDDM_Nganh = pDM_NganhInfo.DM_NganhID;
                dtChuyenNganh = oBDM_ChuyenNganh.GetByIDNganh(pDM_ChuyenNganhInfo.IDDM_Nganh);
                grdChuyenNganh.DataSource = dtChuyenNganh;
            }
        }

        private void grvChuyenNganh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvChuyenNganh.DataRowCount > 0)
            {
                ShowPopup = true;
                idxChuyenNganh = grvChuyenNganh.FocusedRowHandle;
                pDM_ChuyenNganhInfo.DM_ChuyenNganhID = int.Parse(grvChuyenNganh.GetDataRow(idxChuyenNganh)[pDM_ChuyenNganhInfo.strDM_ChuyenNganhID].ToString());
                pDM_ChuyenNganhInfo.MaChuyenNganh = grvChuyenNganh.GetDataRow(idxChuyenNganh)[pDM_ChuyenNganhInfo.strMaChuyenNganh].ToString();
                pDM_ChuyenNganhInfo.TenChuyenNganh = grvChuyenNganh.GetDataRow(idxChuyenNganh)[pDM_ChuyenNganhInfo.strTenChuyenNganh].ToString();
                pDM_ChuyenNganhInfo.TenChuyenNganh_E = grvChuyenNganh.GetDataRow(idxChuyenNganh)[pDM_ChuyenNganhInfo.strTenChuyenNganh_E].ToString();
            }
            else
                ShowPopup = false;
        }

        private void cmbKhoa_EditValueChanged(object sender, EventArgs e)
        {
            if (!Loaded) return;
            pDM_NganhInfo.DM_NganhID = cmbKhoa.EditValue == null ? 0 : int.Parse(cmbKhoa.EditValue.ToString());
            dtNganh = oBDM_Nganh.GetByIDKhoa(pDM_NganhInfo.DM_NganhID);
            grdNganh.DataSource = dtNganh;
        }

        private void grdChuyenNganh_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && grdChuyenNganh.ClientRectangle.Contains(e.X, e.Y))
            {
                popupMenu.ShowPopup(MousePosition);
            }
        }

        private void barbtnThemChuyenNganh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgChuyenNganh dlg = new dlgChuyenNganh(this, pDM_NganhInfo.TenNganh, false);
            dlg.ShowDialog();
        }

        private void barbtnSuaChuyenNganh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ShowPopup) return;
            dlgChuyenNganh dlg = new dlgChuyenNganh(this, pDM_NganhInfo.TenNganh, true);
            dlg.ShowDialog();
        }

        private void barbtnXoaChuyenNganh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ShowPopup) return;
            try
            {
                oBDM_ChuyenNganh.Delete(pDM_ChuyenNganhInfo);
                DataRow dr = grvChuyenNganh.GetDataRow(grvChuyenNganh.FocusedRowHandle);
                dtChuyenNganh.Rows.Remove(dr);
                XoaThanhCong();
            }
            catch
            {
                XoaThatBai();
            }
        }
    }
}