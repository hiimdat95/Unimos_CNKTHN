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
    public partial class frmKhoaBoMon : frmBase
    {
        private EDIT_MODE edit;
        private cBDM_Khoa oBDM_Khoa;
        private cBDM_BoMon oBDM_BoMon;
        private DM_KhoaInfo pDM_KhoaInfo;
        public DM_BoMonInfo pDM_BoMonInfo;
        private DataTable dtKhoa, dtBoMon;
        private bool ShowPopup = false;
        private DataRow drKhoa, drBoMon;

        public frmKhoaBoMon()
        {
            InitializeComponent();
            oBDM_Khoa = new cBDM_Khoa();
            oBDM_BoMon = new cBDM_BoMon();
            pDM_KhoaInfo = new DM_KhoaInfo();
            pDM_BoMonInfo = new DM_BoMonInfo();
            panelTop.Visible = false;
        }

        private void frmKhoaBoMon_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            SetControl(false);
            LoadGrid();
        }

        private void LoadGrid()
        {
            dtKhoa = LoadKhoa();
            grdKhoa.DataSource = dtKhoa;
        }

        private void LoadBoMon(int IDDM_Khoa)
        {
            dtBoMon = oBDM_BoMon.GetByIDKhoa(IDDM_Khoa);
            grdBoMon.DataSource = dtBoMon;
        }

        private void GetpDM_Khoa()
        {
            pDM_KhoaInfo.MaKhoa = txtMaKhoa.Text.Trim();
            pDM_KhoaInfo.TenKhoa = txtTenKhoa.Text.Trim();
            pDM_KhoaInfo.TenKhoa_E = txtTenKhoa_E.Text.Trim();
        }

        private void ClearText()
        {
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";
            txtTenKhoa_E.Text = "";
            txtMaKhoa.Focus();
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtMaKhoa.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtMaKhoa, "Mã khoa không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMaKhoa;
            }
            if (txtTenKhoa.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenKhoa, "Tên khoa không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenKhoa;
            }
            
            //kiểm tra mã nhập vào có trùng với dữ liệu trước không.
            if (grvKhoa.RowCount != 0)
            {
                for (int i = 0; i < grvKhoa.RowCount; i++)
                {
                    if (txtMaKhoa.Text.Trim() == dtKhoa.Rows[i]["MaKhoa"].ToString() && (edit == EDIT_MODE.THEM ||
                        (dtKhoa.Rows[i]["DM_KhoaID"].ToString() != pDM_KhoaInfo.DM_KhoaID.ToString() && edit == EDIT_MODE.SUA)))
                    {
                        if (CtrlErr == null) CtrlErr = txtMaKhoa;
                        txtMaKhoa.Text = "";
                        dxErrorProvider.SetError(txtMaKhoa, "Mã khoa đã bị trùng.");
                        if (CtrlErr == null) CtrlErr = txtMaKhoa;
                        break;
                    }
                }
            }
            
            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            else
                return true;
        }

        public void EditBoMon(EDIT_MODE edit)
        {
            DataRow drNew;
            if (edit == EDIT_MODE.SUA)
            {
                oBDM_BoMon.ToDataRow(pDM_BoMonInfo, ref drBoMon);
            }
            else
            {
                drNew = dtBoMon.NewRow();
                oBDM_BoMon.ToDataRow(pDM_BoMonInfo, ref drNew);
                dtBoMon.Rows.Add(drNew);
            }
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            edit = EDIT_MODE.SUA;
            txtMaKhoa.Text = pDM_KhoaInfo.MaKhoa;
            txtTenKhoa.Text = pDM_KhoaInfo.TenKhoa;
            txtTenKhoa_E.Text = pDM_KhoaInfo.TenKhoa_E;
            grdKhoa.Enabled = false;
            panelTop.Visible = true;
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvKhoa.FocusedRowHandle < 0) return;
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    pDM_KhoaInfo.DM_KhoaID = int.Parse(drKhoa[pDM_KhoaInfo.strDM_KhoaID].ToString());
                    oBDM_Khoa.Delete(pDM_KhoaInfo);
                    dtKhoa.Rows.Remove(drKhoa);
                    // ghi log
                    GhiLog("Xóa khoa '" + pDM_KhoaInfo.TenKhoa + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
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
                GetpDM_Khoa();
                if (edit == EDIT_MODE.SUA)
                {
                    pDM_KhoaInfo.DM_KhoaID = int.Parse(drKhoa[pDM_KhoaInfo.strDM_KhoaID].ToString());
                    oBDM_Khoa.Update(pDM_KhoaInfo);
                    grdKhoa.Enabled = true;
                    oBDM_Khoa.ToDataRow(pDM_KhoaInfo, ref drKhoa);
                    panelTop.Visible = false;
                    // ghi log
                    GhiLog("Sửa khoa '" + pDM_KhoaInfo.TenKhoa + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    SuaThanhCong();
                }
                else
                {
                    pDM_KhoaInfo.DM_KhoaID = oBDM_Khoa.Add(pDM_KhoaInfo);
                    DataRow dr = dtKhoa.NewRow();
                    oBDM_Khoa.ToDataRow(pDM_KhoaInfo, ref dr);
                    dtKhoa.Rows.Add(dr);
                    ClearText();
                    // ghi log
                    GhiLog("Thêm khoa '" + pDM_KhoaInfo.TenKhoa + "' vào CSDL", "Thêm", this.Tag.ToString());
                    ThemThanhCong();
                    txtMaKhoa.Focus();
                }
            }
            catch(SqlException SqlEx)
            {
                XtraMessageBox.Show(SqlEx.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dxErrorProvider.ClearErrors();
            grdKhoa.Enabled = true;
            panelTop.Visible = false;
        }

        private void grvKhoa_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvKhoa.DataRowCount > 0)
            {
                SetControl(true);
                drKhoa = grvKhoa.GetDataRow(grvKhoa.FocusedRowHandle);
                LoadBoMon(int.Parse(drKhoa["DM_KhoaID"].ToString()));
            }
        }

        private void grdBoMon_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && grdBoMon.ClientRectangle.Contains(e.X, e.Y))
            {
                popupMenu.ShowPopup(MousePosition);
            }
        }

        private void barbtnThemBoMon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pDM_BoMonInfo.IDDM_Khoa = int.Parse(drKhoa["DM_KhoaID"].ToString());
            dlgBoMon dlg = new dlgBoMon(pDM_BoMonInfo, false, this);
            dlg.ShowDialog();
        }

        private void barbtnSuaBoMon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ShowPopup) return;
            oBDM_BoMon.ToInfo(ref pDM_BoMonInfo, drBoMon);
            dlgBoMon dlg = new dlgBoMon(pDM_BoMonInfo, true, this);
            dlg.ShowDialog();
        }

        private void barbtnXoaBoMon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ShowPopup) return;
            try
            {
                pDM_BoMonInfo.DM_BoMonID = int.Parse(drBoMon["DM_BoMonID"].ToString());
                oBDM_BoMon.Delete(pDM_BoMonInfo);
                dtBoMon.Rows.Remove(drBoMon);
                // ghi log
                GhiLog("Xóa bộ môn '" + pDM_BoMonInfo.TenBoMon + "' khỏi cơ sở dữ liệu", "Xóa", this.Tag.ToString());
            }
            catch
            {
                XoaThatBai();
            }
        }

        private void grvBoMon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvBoMon.DataRowCount > 0)
            {
                ShowPopup = true;
                drBoMon = grvBoMon.GetDataRow(grvBoMon.FocusedRowHandle);
            }
            else
                ShowPopup = false;
        }
    }
}