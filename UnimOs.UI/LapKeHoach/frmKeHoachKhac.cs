using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;
using DevExpress.XtraEditors;

namespace UnimOs.UI
{
    public partial class frmKeHoachKhac : frmBase
    {
        private cBXL_KeHoachKhac oBKeHoachKhac;
        private XL_KeHoachKhacInfo pKeHoacKhacInfo;
        private DataTable dtKeHoachKhac;
        private EDIT_MODE edit;
        private int idx;

        public frmKeHoachKhac()
        {
            InitializeComponent();
            oBKeHoachKhac = new cBXL_KeHoachKhac();
            pKeHoacKhacInfo = new XL_KeHoachKhacInfo();
        }
        private void frmKeHoachKhac_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void GetData()
        {
            pKeHoacKhacInfo.XL_KeHoachKhacID = 0;
            dtKeHoachKhac = oBKeHoachKhac.GetCombo(pKeHoacKhacInfo);
            grdKeHoachKhac.DataSource = dtKeHoachKhac;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelTop.Visible = true;
            edit = EDIT_MODE.THEM;
            ClearText();
            txtTenKeHoachKhac.Focus();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            edit = EDIT_MODE.SUA;
            panelTop.Visible = true;
            SetText();
            txtTenKeHoachKhac.Focus();
        }

        private bool CheckValid()
        {
            //if (txtTenKeHoachKhac.Text == "")
            //{
            //    CanhBao("Bạn chưa nhập tên kế hoạch khác!");
            //    return false;
            //}
            //else if (txtTenVietTat.Text == "")
            //{
            //    CanhBao("Bạn chưa nhập tên viết tắt!");
            //    return false;
            //}
            return true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            try
            {
                GetpKeHoachKhac();
                DataRow drNew;
                if (edit == EDIT_MODE.THEM)
                {
                    pKeHoacKhacInfo.XL_KeHoachKhacID = oBKeHoachKhac.Add(pKeHoacKhacInfo);
                    drNew = dtKeHoachKhac.NewRow();
                    oBKeHoachKhac.ToDataRow(pKeHoacKhacInfo, ref drNew);
                    dtKeHoachKhac.Rows.Add(drNew);
                    ClearText();
                    txtTenKeHoachKhac.Focus();
                }
                else
                {
                    oBKeHoachKhac.Update(pKeHoacKhacInfo);
                    drNew = dtKeHoachKhac.NewRow();
                    oBKeHoachKhac.ToDataRow(pKeHoacKhacInfo, ref drNew);
                    DataRow dr = grvKeHoachKhac.GetDataRow(idx);
                    dtKeHoachKhac.Rows.InsertAt(drNew, idx + 1);
                    dtKeHoachKhac.Rows.Remove(dr);
                    panelTop.Visible = false;
                    SuaThanhCong();
                }
                GetData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void GetpKeHoachKhac()
        {
            pKeHoacKhacInfo.TenKeHoachKhac = txtTenKeHoachKhac.Text;
            pKeHoacKhacInfo.TenVietTat = txtTenVietTat.Text;
            pKeHoacKhacInfo.MauNen = cmbMauNen.Color.ToArgb();
            pKeHoacKhacInfo.MauChu = cmbMauChu.Color.ToArgb();
            pKeHoacKhacInfo.DuLieuChuan = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panelTop.Visible = false;
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                oBKeHoachKhac.Delete(pKeHoacKhacInfo);
                dtKeHoachKhac.Rows.Remove(grvKeHoachKhac.GetDataRow(idx));
                XtraMessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void SetText()
        {
            txtTenKeHoachKhac.Text = pKeHoacKhacInfo.TenKeHoachKhac;
            txtTenVietTat.Text = pKeHoacKhacInfo.TenVietTat;
            cmbMauChu.EditValue = pKeHoacKhacInfo.MauChu;
            cmbMauNen.EditValue = pKeHoacKhacInfo.MauNen;
        }

        private void ClearText()
        {
            txtTenKeHoachKhac.Text = "";
            txtTenVietTat.Text = "";
            
        }

        private void grvKeHoachKhac_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvKeHoachKhac_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.Name == "gridColumnHienThi")
            {
                e.Appearance.BackColor = Color.FromArgb(int.Parse(grvKeHoachKhac.GetDataRow(e.RowHandle)["MauNen"].ToString()));
                e.Appearance.ForeColor = Color.FromArgb(int.Parse(grvKeHoachKhac.GetDataRow(e.RowHandle)["MauChu"].ToString()));
            }
        }

        private void grvKeHoachKhac_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvKeHoachKhac.DataRowCount > 0)
            {
                idx = grvKeHoachKhac.FocusedRowHandle;
                DataRow dr=grvKeHoachKhac.GetDataRow(idx);
                pKeHoacKhacInfo.XL_KeHoachKhacID = int.Parse(dr[pKeHoacKhacInfo.strXL_KeHoachKhacID].ToString());
                pKeHoacKhacInfo.TenKeHoachKhac = dr[pKeHoacKhacInfo.strTenKeHoachKhac].ToString();
                pKeHoacKhacInfo.TenVietTat = dr[pKeHoacKhacInfo.strTenVietTat].ToString();
                pKeHoacKhacInfo.MauChu = int.Parse(dr[pKeHoacKhacInfo.strMauChu].ToString());
                pKeHoacKhacInfo.MauNen = int.Parse(dr[pKeHoacKhacInfo.strMauNen].ToString());
                pKeHoacKhacInfo.DuLieuChuan = bool.Parse(dr[pKeHoacKhacInfo.strDuLieuChuan].ToString());
            }
        }
    }
}
