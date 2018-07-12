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
    public partial class frmBienLaiThuTien : frmBase
    {
        private cBTC_BienLaiThuTien oBTC_BienLaiThuTien;
        private TC_BienLaiThuTienInfo pTC_BienLaiThuTienInfo;
        private cBDM_NamHoc oBNamHoc;
        private DM_NamHocInfo pNamHocInfo;
        private cBDM_Lop oBDM_Lop;
        private DataRow drSoPhieu;

        public frmBienLaiThuTien()
        {
            InitializeComponent();
            pTC_BienLaiThuTienInfo = new TC_BienLaiThuTienInfo();
            oBTC_BienLaiThuTien = new cBTC_BienLaiThuTien(); 
            oBNamHoc = new cBDM_NamHoc();
            pNamHocInfo = new DM_NamHocInfo();
            oBDM_Lop = new cBDM_Lop();
        }

        private void frmBienLaiThuTien_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            grdSoPhieu.DataSource = oBTC_BienLaiThuTien.GetNamHoc(Program.IDNamHoc,Program.HocKy);
            if (grdSoPhieu.DataSource != null && grvSoPhieu.DataRowCount > 0)
                grvSoPhieu_FocusedRowChanged(null, null);

            cmbNamHoc.Properties.DataSource = oBNamHoc.Get(pNamHocInfo);
            cmbNamHoc.EditValue = Program.IDNamHoc;

            DataTable dt = new DataTable();
            dt.Columns.Add("HocKy");
            DataRow dr = dt.NewRow();
            dr["HocKy"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["HocKy"] = 2;
            dt.Rows.Add(dr);
            cmbHocKy.Properties.DataSource = dt;
            cmbHocKy.EditValue = Program.HocKy.ToString();;

            cmbLop.Properties.DataSource = oBDM_Lop.GetDanhSachLop(new DM_LopInfo(), Program.NamHoc);
        }

        private void grvChiTiet_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvSoPhieu_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void cmbLop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbLop.EditValue = null;
        }

        private void cmbNamHoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbNamHoc.EditValue = null;
        }

        private void cmbHocKy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbHocKy.EditValue = null;
        }

      
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void grvSoPhieu_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && grdSoPhieu.ClientRectangle.Contains(e.X, e.Y))
            {
                popupMenu1.ShowPopup(MousePosition);
            }
        }
        private void grvSoPhieu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvSoPhieu.FocusedRowHandle >= 0)
            {
                drSoPhieu = grvSoPhieu.GetDataRow(grvSoPhieu.FocusedRowHandle);
                grdChiTiet.DataSource = oBTC_BienLaiThuTien.GetChiTiet(int.Parse(drSoPhieu["TC_BienLaiThuTienID"].ToString()));
            }
            else
                grdChiTiet.DataSource = null;
        }

        private void barbtnLoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelTop.Visible = true;
            txtSoPhieu.Focus();
           
        }

        private void barbtnBoLoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdSoPhieu.DataSource = oBTC_BienLaiThuTien.GetNamHoc(Program.IDNamHoc, Program.HocKy);
            if (grvSoPhieu.DataRowCount > 0)
                grvSoPhieu_FocusedRowChanged(null, null);
            panelTop.Visible = false;
        }

        private void btnLocSV_Click(object sender, EventArgs e)
        {
            grdSoPhieu.DataSource = oBTC_BienLaiThuTien.TimKiem(txtSoPhieu.Text.Trim(), int.Parse(rdThuChi.EditValue.ToString()), (chkPhieuHuy.Checked == true ? 1 : 0), txtMaSinhVien.Text.Trim(),
               (cmbLop.EditValue == null ? 0 : int.Parse(cmbLop.EditValue.ToString())), (cmbNamHoc.EditValue == null ? 0 : int.Parse(cmbNamHoc.EditValue.ToString())), (cmbHocKy.EditValue == null ? 0 : int.Parse(cmbHocKy.EditValue.ToString())));
            if (grdSoPhieu.DataSource != null && grvSoPhieu.DataRowCount > 0)
                grvSoPhieu_FocusedRowChanged(null, null);
        }

        private void btnHuyLoc_Click(object sender, EventArgs e)
        {
            panelTop.Visible = false;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgBienLaiThuTienChiTiet dlg = new dlgBienLaiThuTienChiTiet(0, false, "");
            dlg.ShowDialog();
            if (dlg.Tag.ToString() == "1")
                frmBienLaiThuTien_Load(null, null);
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvChiTiet.FocusedRowHandle >= 0)
            {
                if (bool.Parse(drSoPhieu["PhieuHuy"].ToString()) == false)
                {
                    dlgBienLaiThuTienChiTiet dlg = new dlgBienLaiThuTienChiTiet(0, true, "");
                    dlg.ShowDialog();
                    if (dlg.Tag.ToString() == "1")
                        frmBienLaiThuTien_Load(null, null);
                }
                else
                    ThongBaoChon("Phiếu đã hủy không thể sửa!");
            }
            else
                ThongBaoChon("Bạn chưa chọn phiếu để sửa!");
        }

        private void barbtnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvChiTiet.FocusedRowHandle >= 0)
            {
                if (bool.Parse(drSoPhieu["PhieuHuy"].ToString()) != true)
                {
                    if (ThongBaoChon("Bạn có chắc chắn hủy phiếu ko?") == DialogResult.Yes)
                    {
                        oBTC_BienLaiThuTien.UpdatePhieuHuy(int.Parse(grvSoPhieu.GetDataRow(grvSoPhieu.FocusedRowHandle)["TC_BienLaiThuTienID"].ToString()), DateTime.Now, Program.objUserCurrent.HT_UserID, 1);
                        drSoPhieu["PhieuHuy"] = true;
                    }
                }
                else
                    ThongBao("Phiếu đã hủy!");
            }
            else
                ThongBao("Bạn chưa chọn phiếu để hủy!");
        }

        private void barbtnBoHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvChiTiet.FocusedRowHandle >= 0 && bool.Parse(drSoPhieu["PhieuHuy"].ToString()) == true)
            {
                if (ThongBaoChon("Bạn có chắc chắn bỏ hủy phiếu ko?") == DialogResult.Yes)
                {
                    oBTC_BienLaiThuTien.UpdatePhieuHuy(int.Parse(grvSoPhieu.GetDataRow(grvSoPhieu.FocusedRowHandle)["TC_BienLaiThuTienID"].ToString()), DateTime.Now, Program.objUserCurrent.HT_UserID, 0);
                    drSoPhieu["PhieuHuy"] = false;
                }
            }
            else
                ThongBao("Phiếu này không phải phiếu hủy!");
        }

        private void menuThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnThem_ItemClick(null, null);
        }

        private void menuSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnSua_ItemClick(null, null);
        }

        private void menuHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnHuy_ItemClick(null, null);
        }

        private void menuBoHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnBoHuy_ItemClick(null, null);
        }


    }
}