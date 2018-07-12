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
    public partial class frmKhoaHoc : frmBase
    {
        private cBDM_KhoaHoc oBDM_KhoaHoc;
        private DM_KhoaHocInfo pDM_KhoaHocInfo;
        private DataTable dtKhoaHoc;
        private int idx;
        private bool UPDATE;

        public frmKhoaHoc()
        {
            InitializeComponent();
            oBDM_KhoaHoc = new cBDM_KhoaHoc();
            pDM_KhoaHocInfo = new DM_KhoaHocInfo();
            panelTop.Visible = false;
            SetControl(false);
        }

        private void frmKhoaHoc_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            DataTable dtTrinhDo = LoadTrinhDo();
            cmbTrinhDo.Properties.DataSource = dtTrinhDo;
            if (dtTrinhDo.Rows.Count > 0)
                cmbTrinhDo.ItemIndex = 0;
            DataTable dtNganh = LoadNganh();
            cmbNganh.Properties.DataSource = dtNganh;
            if (dtNganh.Rows.Count > 0)
                cmbNganh.ItemIndex = 0;

            LoadGrid();
        }

        private void LoadGrid()
        {
            dtKhoaHoc = oBDM_KhoaHoc.GetAll();
            grdKhoaHoc.DataSource = dtKhoaHoc;
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void ClearText()
        {
            txtTenKhoaHoc.Text = "";
            txtTuNam.Text = DateTime.Today.Year.ToString();
            txtDenNam.Text = (DateTime.Today.Year + 4).ToString();
            chkTrinhDo.Checked = false;
            chkNganh.Checked = false;
            chkChuyenNganh.Checked = false;
            CheckedChanged();
        }

        private void SetText()
        {
            txtTenKhoaHoc.Text = pDM_KhoaHocInfo.TenKhoaHoc;
            txtTuNam.Text = pDM_KhoaHocInfo.NamVaoTruong.ToString();
            txtDenNam.Text = pDM_KhoaHocInfo.NamRaTruong.ToString();
            if (pDM_KhoaHocInfo.IDDM_TrinhDo != -1)
            {
                cmbTrinhDo.EditValue = pDM_KhoaHocInfo.IDDM_TrinhDo;
                chkTrinhDo.Checked = true;
            }
            else
                chkTrinhDo.Checked = false;
            if (pDM_KhoaHocInfo.IDDM_Nganh != -1)
            {
                cmbNganh.EditValue = pDM_KhoaHocInfo.IDDM_Nganh;
                chkNganh.Checked = true;
            }
            else
                chkNganh.Checked = false;
            if (pDM_KhoaHocInfo.IDDM_ChuyenNganh != -1)
            {
                cmbChuyenNganh.EditValue = pDM_KhoaHocInfo.IDDM_ChuyenNganh;
                chkChuyenNganh.Checked = true;
            }
            else
                chkChuyenNganh.Checked = false;
            CheckedChanged();
        }

        private void GetpInfo()
        {
            pDM_KhoaHocInfo.TenKhoaHoc = txtTenKhoaHoc.Text.Trim();
            pDM_KhoaHocInfo.NamVaoTruong = int.Parse(txtTuNam.Text.Trim());
            pDM_KhoaHocInfo.NamRaTruong = int.Parse(txtDenNam.Text.Trim());
            if (chkTrinhDo.Checked)
                pDM_KhoaHocInfo.IDDM_TrinhDo = cmbTrinhDo.EditValue == null ? -1 : int.Parse(cmbTrinhDo.EditValue.ToString());
            else
                pDM_KhoaHocInfo.IDDM_TrinhDo = -1;
            if (chkNganh.Checked)
                pDM_KhoaHocInfo.IDDM_Nganh = cmbNganh.EditValue == null ? -1 : int.Parse(cmbNganh.EditValue.ToString());
            else
                pDM_KhoaHocInfo.IDDM_Nganh = -1;
            if (chkChuyenNganh.Checked)
                pDM_KhoaHocInfo.IDDM_ChuyenNganh = cmbChuyenNganh.EditValue == null ? -1 : int.Parse(cmbChuyenNganh.EditValue.ToString());
            else
                pDM_KhoaHocInfo.IDDM_ChuyenNganh = -1;
        }

        private void CheckedChanged()
        {
            chkTrinhDo_CheckedChanged(null, null);
            chkNganh_CheckedChanged(null, null);
            chkChuyenNganh_CheckedChanged(null, null);
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtTenKhoaHoc.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenKhoaHoc, "Tên khóa học không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenKhoaHoc;
            }
            if (txtDenNam.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtDenNam, "Đến năm không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtDenNam;
            }
            if (txtTuNam.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTuNam, "Từ năm không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTuNam;
            }
            //kiểm tra mã nhập vào có trùng với dữ liệu trước không.
            if (grvKhoaHoc.RowCount != 0)
            {
                for (int i = 0; i < grvKhoaHoc.RowCount; i++)
                {
                    if (UPDATE == true && (txtTenKhoaHoc.Text.Trim() != grvKhoaHoc.GetDataRow(grvKhoaHoc.FocusedRowHandle)[pDM_KhoaHocInfo.strTenKhoaHoc].ToString()))
                    {
                        if (txtTenKhoaHoc.Text.Trim() == grvKhoaHoc.GetDataRow(i)[pDM_KhoaHocInfo.strTenKhoaHoc].ToString())
                        {

                            if (CtrlErr == null) CtrlErr = txtTenKhoaHoc;
                            dxErrorProvider.SetError(txtTenKhoaHoc, "Tên khóa học đã bị trùng!");
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

        private void cmbNganh_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dtChuyenNganh = LoadChuyenNganh(int.Parse(cmbNganh.EditValue.ToString()));
            cmbChuyenNganh.Properties.DataSource = dtChuyenNganh;
            if (dtChuyenNganh.Rows.Count > 0)
                cmbChuyenNganh.ItemIndex = 0;
        }

        private void grvKhoaHoc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvKhoaHoc.DataRowCount > 0)
            {
                idx = grvKhoaHoc.FocusedRowHandle;
                pDM_KhoaHocInfo.DM_KhoaHocID = int.Parse(grvKhoaHoc.GetDataRow(idx)[pDM_KhoaHocInfo.strDM_KhoaHocID].ToString());
                pDM_KhoaHocInfo.TenKhoaHoc = grvKhoaHoc.GetDataRow(idx)[pDM_KhoaHocInfo.strTenKhoaHoc].ToString();
                pDM_KhoaHocInfo.NamVaoTruong = int.Parse(grvKhoaHoc.GetDataRow(idx)[pDM_KhoaHocInfo.strNamVaoTruong].ToString());
                pDM_KhoaHocInfo.NamRaTruong = int.Parse(grvKhoaHoc.GetDataRow(idx)[pDM_KhoaHocInfo.strNamRaTruong].ToString());
                pDM_KhoaHocInfo.IDDM_TrinhDo = int.Parse(grvKhoaHoc.GetDataRow(idx)[pDM_KhoaHocInfo.strIDDM_TrinhDo].ToString());
                pDM_KhoaHocInfo.IDDM_Nganh = int.Parse(grvKhoaHoc.GetDataRow(idx)[pDM_KhoaHocInfo.strIDDM_Nganh].ToString());
                pDM_KhoaHocInfo.IDDM_ChuyenNganh = int.Parse(grvKhoaHoc.GetDataRow(idx)[pDM_KhoaHocInfo.strIDDM_ChuyenNganh].ToString());
                SetControl(true);
            }
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
            ClearText();
            grdKhoaHoc.Enabled = false;
            UPDATE = false;
            txtTenKhoaHoc.Focus();
            panelTop.Visible = true;
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetText();
            grdKhoaHoc.Enabled = false;
            UPDATE = true;
            txtTenKhoaHoc.Focus();
            panelTop.Visible = true;
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    oBDM_KhoaHoc.Delete(pDM_KhoaHocInfo);
                    // ghi log
                    GhiLog("Xóa khóa học '" + pDM_KhoaHocInfo.TenKhoaHoc + "' khỏi CSDL ", "Xóa", this.Tag.ToString());
                    DataRow dr = grvKhoaHoc.GetDataRow(idx);
                    dtKhoaHoc.Rows.Remove(dr);
                    XoaThanhCong();
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private void SetTextToRow(DataRow dr)
        {
            if (chkTrinhDo.Checked)
                dr["TenTrinhDo"] = cmbTrinhDo.EditValue == null ? "" : cmbTrinhDo.Text;
            if (chkNganh.Checked)
                dr["TenNganh"] = cmbNganh.EditValue == null ? "" : cmbNganh.Text;
            if (chkChuyenNganh.Checked)
                dr["TenChuyenNganh"] = cmbChuyenNganh.EditValue == null ? "" : cmbChuyenNganh.Text;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            try
            {
                GetpInfo();
                if (UPDATE)
                {
                    int idxNew = idx;
                    oBDM_KhoaHoc.Update(pDM_KhoaHocInfo);
                    DataRow drNew = dtKhoaHoc.NewRow();
                    DataRow dr = grvKhoaHoc.GetDataRow(idx);
                    oBDM_KhoaHoc.ToDataRow(pDM_KhoaHocInfo, ref drNew);
                    SetTextToRow(drNew);
                    dtKhoaHoc.Rows.InsertAt(drNew, idxNew + 1);
                    dtKhoaHoc.Rows.Remove(dr);
                    grvKhoaHoc.FocusedRowHandle = idxNew;
                    btnHuy_Click(null, null);
                    // ghi log
                    GhiLog("Sửa khóa học '" + pDM_KhoaHocInfo.TenKhoaHoc + "' trong CSDL ", "Sửa", this.Tag.ToString());
                    SuaThanhCong();
                }
                else
                {
                    pDM_KhoaHocInfo.DM_KhoaHocID = oBDM_KhoaHoc.Add(pDM_KhoaHocInfo);
                    DataRow drNew = dtKhoaHoc.NewRow();
                    oBDM_KhoaHoc.ToDataRow(pDM_KhoaHocInfo, ref drNew);
                    SetTextToRow(drNew);
                    dtKhoaHoc.Rows.Add(drNew);
                    grvKhoaHoc.FocusedRowHandle = grvKhoaHoc.DataRowCount - 1;
                    // ghi log
                    GhiLog("Thêm khóa học '" + pDM_KhoaHocInfo.TenKhoaHoc + "' vào CSDL ", "Thêm", this.Tag.ToString());
                    ClearText();
                    txtTenKhoaHoc.Focus();
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
            grdKhoaHoc.Enabled = true;
            dxErrorProvider.ClearErrors();
        }
    }
}