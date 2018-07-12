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
    public partial class frmHoiDongMonHoc : frmBase
    {
        private cBKQHT_HoiDongMon oBKQHT_HoiDongMon;
        private KQHT_HoiDongMonInfo pKQHT_HoiDongMonInfo;
        private cBKQHT_HoiDongMon_ChiTiet oBKQHT_HoiDongMon_ChiTiet;
        private KQHT_HoiDongMon_ChiTietInfo pKQHT_HoiDongMon_ChiTietInfo;
        private DataTable dtHoiDong, dtChiTiet,dtSinhVien;
        private DataRow drHoiDong, drChiTiet;
        private cBKQHT_HoiDongMon_SinhVien oBKQHT_HoiDongMon_SinhVien;
        private KQHT_HoiDongMon_SinhVienInfo pKQHT_HoiDongMon_SinhVienInfo;
        private EDIT_MODE edit;

        public frmHoiDongMonHoc()
        {
            InitializeComponent();
            oBKQHT_HoiDongMon = new cBKQHT_HoiDongMon();
            pKQHT_HoiDongMonInfo = new KQHT_HoiDongMonInfo();
            oBKQHT_HoiDongMon_ChiTiet = new cBKQHT_HoiDongMon_ChiTiet();
            pKQHT_HoiDongMon_ChiTietInfo = new KQHT_HoiDongMon_ChiTietInfo();
            pKQHT_HoiDongMon_SinhVienInfo = new KQHT_HoiDongMon_SinhVienInfo();
            oBKQHT_HoiDongMon_SinhVien = new cBKQHT_HoiDongMon_SinhVien();
            panelTop.Visible = false;
            SetBarButton(false);
            cmbMonHoc.Properties.DataSource = LoadMonHoc();
            repositoryItemLookUpEditGV.DataSource = LoadGiaoVien();
        }

        private void frmHoiDongMonHoc_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            dtHoiDong = oBKQHT_HoiDongMon.GetByNamHocHocKy(Program.IDNamHoc, Program.HocKy);
            grdHoiDong.DataSource = dtHoiDong;
        }

        private void LoadChiTiet(int IDKQHT_HoiDongMon)
        {
            dtChiTiet = oBKQHT_HoiDongMon_ChiTiet.GetByIDHoiDong(IDKQHT_HoiDongMon);
            grdChiTiet.DataSource = dtChiTiet;
        }

        private void LoadSinhVien(int IDKQHT_HoiDongMon)
        {
            dtSinhVien = oBKQHT_HoiDongMon.GetSinhVien(IDKQHT_HoiDongMon);
            grdSinhVien.DataSource = dtSinhVien;
            dtSinhVien.AcceptChanges();
        }

        private void SetBarButton(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void SetText()
        {
            txtTenHoiDong.Text = pKQHT_HoiDongMonInfo.TenHoiDong;
            cmbMonHoc.EditValue = pKQHT_HoiDongMonInfo.IDDM_MonHoc;
        }

        private void ClearText()
        {
            txtTenHoiDong.Text = "";
            cmbMonHoc.EditValue = -1;
        }

        private void GetpInfo()
        {
            pKQHT_HoiDongMonInfo.TenHoiDong = txtTenHoiDong.Text.Trim();
            pKQHT_HoiDongMonInfo.IDDM_MonHoc = int.Parse(cmbMonHoc.EditValue.ToString());
            pKQHT_HoiDongMonInfo.IDDM_NamHoc = Program.IDNamHoc;
            pKQHT_HoiDongMonInfo.HocKy = Program.HocKy;
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtTenHoiDong.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenHoiDong, "Tên hội đồng không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenHoiDong;
            }
            if (cmbMonHoc.ItemIndex == -1)
            {
                dxErrorProvider.SetError(cmbMonHoc, "Bạn phải chọn môn học.");
                if (CtrlErr == null) CtrlErr = cmbMonHoc;
            }

            if ((CtrlErr != null))
                return false;
            else
                return true;
        }

        private void grvHoiDong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvHoiDong.DataRowCount > 0)
            {
                if (grvHoiDong.FocusedRowHandle >= 0)
                {
                    drHoiDong = grvHoiDong.GetDataRow(grvHoiDong.FocusedRowHandle);
                    oBKQHT_HoiDongMon.ToInfo(ref pKQHT_HoiDongMonInfo, drHoiDong);
                    SetBarButton(true);
                    LoadChiTiet(pKQHT_HoiDongMonInfo.KQHT_HoiDongMonID);
                    LoadSinhVien(pKQHT_HoiDongMonInfo.KQHT_HoiDongMonID);
                }
            }
            else
            {
                LoadChiTiet(0);
                LoadSinhVien(0);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            GetpInfo();
            if (edit == EDIT_MODE.THEM)
            {
                pKQHT_HoiDongMonInfo.KQHT_HoiDongMonID = oBKQHT_HoiDongMon.Add(pKQHT_HoiDongMonInfo);
                DataRow drNew = dtHoiDong.NewRow();
                oBKQHT_HoiDongMon.ToDataRow(pKQHT_HoiDongMonInfo, ref drNew);
                drNew["TenMonHoc"] = cmbMonHoc.Text;
                dtHoiDong.Rows.Add(drNew);
                ClearText();
                txtTenHoiDong.Focus();
            }
            else
            {
                oBKQHT_HoiDongMon.Update(pKQHT_HoiDongMonInfo);
                oBKQHT_HoiDongMon.ToDataRow(pKQHT_HoiDongMonInfo, ref drHoiDong);
                drHoiDong["TenMonHoc"] = cmbMonHoc.Text;
                panelTop.Visible = false;
                grdHoiDong.Enabled = true;
                SuaThanhCong();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panelTop.Visible = false;
            grdHoiDong.Enabled = true;
        }

        private void grvHoiDong_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            grdHoiDong.Enabled = false;
            ClearText();
            txtTenHoiDong.Focus();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            edit = EDIT_MODE.SUA;
            panelTop.Visible = true;
            grdHoiDong.Enabled = false;
            SetText();
            txtTenHoiDong.Focus();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn với lựa chọn xóa không ?") == DialogResult.Yes)
            {
                try
                {
                    oBKQHT_HoiDongMon.Delete(pKQHT_HoiDongMonInfo);
                    dtHoiDong.Rows.Remove(drHoiDong);
                    XoaThanhCong();
                }
                catch (Exception)
                {
                    XoaThatBai();
                }
            }
        }

        private void grdChiTiet_Enter(object sender, EventArgs e)
        {
            if (dtChiTiet != null)
            {
                if (bgrvChiTiet.RowCount == 0)
                {
                    DataRow drNew = dtChiTiet.NewRow();
                    drNew["KQHT_HoiDongMon_ChiTietID"] = -1;
                    drNew["IDKQHT_HoiDongMon"] = pKQHT_HoiDongMonInfo.KQHT_HoiDongMonID;
                    drNew["TyLe"] = 1;
                    dtChiTiet.Rows.Add(drNew);
                    bgrvChiTiet.FocusedColumn = colGiangVien;
                }
            }
        }

        private void bgrvChiTiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (bgrvChiTiet.FocusedRowHandle == bgrvChiTiet.DataRowCount - 1 &&
                    ("" + drChiTiet["IDNS_GiaoVien"] != "" || "" + drChiTiet["HoTen"] != ""))
                {
                    DataRow drNew = dtChiTiet.NewRow();
                    drNew["KQHT_HoiDongMon_ChiTietID"] = -1;
                    drNew["IDKQHT_HoiDongMon"] = pKQHT_HoiDongMonInfo.KQHT_HoiDongMonID;
                    drNew["TyLe"] = 1;
                    dtChiTiet.Rows.Add(drNew);
                    bgrvChiTiet.FocusedColumn = colGiangVien;
                }
                else
                    bgrvChiTiet.FocusedRowHandle += 1;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (bgrvChiTiet.FocusedRowHandle >= 0)
                    dtChiTiet.Rows.Remove(drChiTiet);
            }
        }

        private void bgrvChiTiet_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (bgrvChiTiet.DataRowCount > 0)
            {
                if (bgrvChiTiet.FocusedRowHandle >= 0)
                {
                    drChiTiet = bgrvChiTiet.GetDataRow(bgrvChiTiet.FocusedRowHandle);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataTable dtChanged = dtChiTiet.GetChanges();
            if (dtChanged == null) return;
            DataRowState state;
            
            foreach (DataRow dr in dtChanged.Rows)
            {
                if ("" + dr["IDNS_GiaoVien"] != "" || "" + dr["HoTen"] != "")
                {
                    state = dr.RowState;
                    switch (state)
                    {
                        case DataRowState.Added:
                            oBKQHT_HoiDongMon_ChiTiet.ToInfo(ref pKQHT_HoiDongMon_ChiTietInfo, dr);
                            pKQHT_HoiDongMon_ChiTietInfo.IDKQHT_HoiDongMon = pKQHT_HoiDongMonInfo.KQHT_HoiDongMonID;
                            pKQHT_HoiDongMon_ChiTietInfo.KQHT_HoiDongMon_ChiTietID = oBKQHT_HoiDongMon_ChiTiet.Add(pKQHT_HoiDongMon_ChiTietInfo);
                            break;
                        case DataRowState.Modified:
                            oBKQHT_HoiDongMon_ChiTiet.ToInfo(ref pKQHT_HoiDongMon_ChiTietInfo, dr);
                            pKQHT_HoiDongMon_ChiTietInfo.IDKQHT_HoiDongMon = pKQHT_HoiDongMonInfo.KQHT_HoiDongMonID;
                            oBKQHT_HoiDongMon_ChiTiet.Update(pKQHT_HoiDongMon_ChiTietInfo);
                            break;
                        case DataRowState.Deleted:
                            if (dr["KQHT_HoiDongMon_ChiTietID"].ToString() != "-1")
                            {
                                pKQHT_HoiDongMon_ChiTietInfo.KQHT_HoiDongMon_ChiTietID = int.Parse(dr["KQHT_HoiDongMon_ChiTietID"].ToString());
                                pKQHT_HoiDongMon_ChiTietInfo.IDKQHT_HoiDongMon = pKQHT_HoiDongMonInfo.KQHT_HoiDongMonID;
                                oBKQHT_HoiDongMon_ChiTiet.Delete(pKQHT_HoiDongMon_ChiTietInfo);
                            }
                            break;
                    }
                }
            }
            ThongBao("Cập nhật thành công!");
            grvHoiDong_FocusedRowChanged(null, null);
        }

        private void grvSinhVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnThemSV_Click(object sender, EventArgs e)
        {
            dlgHoiDongThemSinhVien dlg = new dlgHoiDongThemSinhVien(pKQHT_HoiDongMonInfo.KQHT_HoiDongMonID, dtSinhVien, pKQHT_HoiDongMonInfo.IDDM_MonHoc);
            dlg.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if ((dtSinhVien != null) && (dtSinhVien.Rows.Count >0))
            {
                if (ThongBaoChon("Bạn có chắc chắn muốn xóa?") == DialogResult.Yes)
                {
                    for (int i = 0; i < dtSinhVien.Rows.Count;i++ )
                    {
                       
                        if ((bool)(dtSinhVien.Rows[i]["Chon"]))
                        {
                            pKQHT_HoiDongMon_SinhVienInfo.KQHT_HoiDongMon_SinhVienID = int.Parse(dtSinhVien.Rows[i]["KQHT_HoiDongMon_SinhVienID"].ToString());
                            oBKQHT_HoiDongMon_SinhVien.Delete(pKQHT_HoiDongMon_SinhVienInfo);
                            dtSinhVien.Rows.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
            else
                ThongBao("Bạn phải chọn ít nhất một sinh viên!");
        }

    }
}