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

namespace UnimOs.UI
{
    public partial class frmDM_NgachCongChuc : frmBase
    {
        private cBNS_NgachCongChuc oBNS_NgachCongChuc;
        private NS_NgachCongChucInfo pNS_NgachCongChucInfo;
        private DataTable dtNgachCongChuc;
        private DataRow drNgachCongChuc;
        private EDIT_MODE edit;
        public int IDNS_NhomNgach;
        public frmLuong ofrmLuong;
        public frmNangBacChuyenNgach ofrmNangBacChuyenNgach;

        public frmDM_NgachCongChuc(frmLuong _frmLuong, frmNangBacChuyenNgach _frmNangBacChuyenNgach)
        {
            InitializeComponent();
            oBNS_NgachCongChuc = new cBNS_NgachCongChuc();
            pNS_NgachCongChucInfo = new NS_NgachCongChucInfo();
            SetControl(false);
            ofrmLuong = _frmLuong;
            ofrmNangBacChuyenNgach = _frmNangBacChuyenNgach;
        }

        private void GetNgachCongChuc()
        {
            cmbNhomNgach.Properties.DataSource = LoadNhomNgach();
            reposNhomNgach.DataSource = LoadNhomNgach();
            pNS_NgachCongChucInfo.NS_NgachCongChucID = 0;
            dtNgachCongChuc = oBNS_NgachCongChuc.Get(pNS_NgachCongChucInfo);
            grdNgachCongChuc.DataSource = dtNgachCongChuc;
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void ClearText()
        {
            txtMaNgach.Text = "";
            txtTenNgach.Text = "";
            cmbNhomNgach.EditValue = null;
            cmbNhomNgach.Focus();
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (cmbNhomNgach.EditValue == null)
            {
                dxErrorProvider.SetError(cmbNhomNgach, "Nhóm ngạch không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbNhomNgach;
            }
            if (txtMaNgach.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtMaNgach, "Mã ngạch không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMaNgach;
            }
            if (txtTenNgach.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtTenNgach, "Tên ngạch không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenNgach;
            }
            if (edit == EDIT_MODE.SUA && txtMaNgach.Text == (string)grvNgachCongChuc.GetDataRow(grvNgachCongChuc.FocusedRowHandle)["MaNgachCongChuc"])
            {
                return edit == EDIT_MODE.SUA;
            }
            else
            {
                //kiểm tra mã nhập vào có trùng với dữ liệu trước không.
                DataTable dt = new DataTable();
                dt = (DataTable)grdNgachCongChuc.DataSource;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (txtMaNgach.Text == (string)dt.Rows[i]["MaNgachCongChuc"])
                        {
                            dxErrorProvider.SetError(txtMaNgach, "Mã ngạch công chức đã bị trùng.");
                            if (CtrlErr == null) CtrlErr = txtMaNgach;
                            txtMaNgach.Text = "";
                            ThongBaoLoi("Mã ngạch công chức đã bị trùng.");
                            break;
                        }
                    }
                }
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

        private void SetText()
        {
            txtMaNgach.Text = pNS_NgachCongChucInfo.MaNgachCongChuc;
            txtTenNgach.Text = pNS_NgachCongChucInfo.TenNgachCongChuc;
            cmbNhomNgach.EditValue = int.Parse("0" + pNS_NgachCongChucInfo.IDNS_NhomNgach);
            cmbNhomNgach.Focus();
        }

        private void GetpInfo()
        {
            pNS_NgachCongChucInfo.MaNgachCongChuc = txtMaNgach.Text;
            pNS_NgachCongChucInfo.TenNgachCongChuc = txtTenNgach.Text;
            pNS_NgachCongChucInfo.IDNS_NhomNgach = int.Parse("0" + cmbNhomNgach.EditValue);
        }


        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdNgachCongChuc.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdNgachCongChuc.Enabled = false;
            edit = EDIT_MODE.SUA;
            panelTop.Visible = true;
            SetText();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    pNS_NgachCongChucInfo.NS_NgachCongChucID = int.Parse(drNgachCongChuc[pNS_NgachCongChucInfo.strNS_NgachCongChucID].ToString());
                    oBNS_NgachCongChuc.Delete(pNS_NgachCongChucInfo);
                    // ghi log
                    GhiLog("Xóa ngạch công chức '" + pNS_NgachCongChucInfo.TenNgachCongChuc + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtNgachCongChuc.Rows.Remove(drNgachCongChuc);
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
                GetpInfo();
                if (edit == EDIT_MODE.THEM)
                {
                    pNS_NgachCongChucInfo.NS_NgachCongChucID = oBNS_NgachCongChuc.Add(pNS_NgachCongChucInfo);
                    GhiLog("Thêm ngạch công chức '" + pNS_NgachCongChucInfo.TenNgachCongChuc + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtNgachCongChuc.NewRow();
                    oBNS_NgachCongChuc.ToDataRow(pNS_NgachCongChucInfo, ref drNew);
                    dtNgachCongChuc.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    pNS_NgachCongChucInfo.NS_NgachCongChucID = int.Parse(drNgachCongChuc[pNS_NgachCongChucInfo.strNS_NgachCongChucID].ToString());
                    oBNS_NgachCongChuc.Update(pNS_NgachCongChucInfo);
                    GhiLog("Sửa ngạch công chức '" + pNS_NgachCongChucInfo.TenNgachCongChuc + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    oBNS_NgachCongChuc.ToDataRow(pNS_NgachCongChucInfo, ref drNgachCongChuc);
                    SuaThanhCong();
                    btnHuy_Click(null, null);
                }
            }
            catch
            {
                ThongBaoLoi("Có lỗi trong quá trình thêm hoặc sửa hoặc ghi log.");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            grdNgachCongChuc.Enabled = true;
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void grvNgachCongChuc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvNgachCongChuc.FocusedRowHandle >= 0)
            {
                drNgachCongChuc = grvNgachCongChuc.GetDataRow(grvNgachCongChuc.FocusedRowHandle);
                oBNS_NgachCongChuc.ToInfo(ref pNS_NgachCongChucInfo, drNgachCongChuc);
                if (ofrmLuong != null)
                {
                    ofrmLuong.IDNS_NgachCongChuc = int.Parse(drNgachCongChuc[pNS_NgachCongChucInfo.strNS_NgachCongChucID].ToString());
                }
                if (ofrmNangBacChuyenNgach != null)
                {
                    ofrmNangBacChuyenNgach.IDNS_NgachCongChuc = int.Parse(drNgachCongChuc[pNS_NgachCongChucInfo.strNS_NgachCongChucID].ToString());
                }
            }
            if (grvNgachCongChuc != null)
                if (grvNgachCongChuc.DataRowCount > 0 && grvNgachCongChuc.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drNgachCongChuc = grvNgachCongChuc.GetDataRow(grvNgachCongChuc.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drNgachCongChuc = null;
        }

        private void frmDM_NgachCongChuc_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetNgachCongChuc();
        }

        private void cmbNhomNgach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDM_NhomNgach frm = new frmDM_NhomNgach(this);
                frm.ShowDialog();
                if (IDNS_NhomNgach > 0)
                {
                    cmbNhomNgach.Properties.DataSource = LoadNhomNgach();
                    reposNhomNgach.DataSource = LoadNhomNgach();
                    cmbNhomNgach.EditValue = IDNS_NhomNgach;

                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                cmbNhomNgach.EditValue = null;
            }
        }

        private void grvNgachCongChuc_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
    }
}