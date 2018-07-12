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
    public partial class frmKyLuat : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private cBSV_SinhVien_KyLuat oBSV_SinhVien_KyLuat;
        private SV_SinhVien_KyLuatInfo pSV_SinhVien_KyLuatInfo;
        private DataTable dtSinhVien, dtQuyetDinh, dtKyLuat;
        private DataRow drSinhVien, drQuyetDinh;
        private int IDDM_Lop = 0;

        public frmKyLuat()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            pDM_LopInfo = new DM_LopInfo();
            oBSV_SinhVien_KyLuat = new cBSV_SinhVien_KyLuat();
            pSV_SinhVien_KyLuatInfo = new SV_SinhVien_KyLuatInfo();

            repositoryItemLookUpEdit_GioiTinh.DataSource = LoadGioiTinh();
            repositoryItemLookUpEdit_GioiTinh1.DataSource = LoadGioiTinh();
        }

        private void frmKyLuat_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
            LoadHanhViReposity();
            dtQuyetDinh = new cBSV_QuyetDinhKyLuat().GetByHocKyNamHoc(Program.IDNamHoc, Program.HocKy);
            grdDSQuyetDinh.DataSource = dtQuyetDinh;
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
                IDDM_Lop = pDM_LopInfo.DM_LopID;
            LoadSinhVien_Lop();
        }

        private void LoadHanhViReposity()
        {
            DataTable dtHanhVi = LoadHanhVi();
            repositoryItemLookUpEdit_HanhVi.DataSource = dtHanhVi;
            repositoryItemLookUpEdit_HanhVi.ValueMember = "DM_HanhViID";
            repositoryItemLookUpEdit_HanhVi.DisplayMember = "TenHanhVi";
        }

        private void LoadSinhVien_Lop()
        {
            dtSinhVien = new cBSV_SinhVien().GetSinhVien(pDM_LopInfo, Program.NamHoc, false);
            grdDanhSachHocSinh.DataSource = dtSinhVien;

            if (IDDM_Lop == 0)
            {
                colTenLop.Visible = true;
                grdTenLop.Visible = true;
            }
            else
            {
                colTenLop.Visible = false;
                grdTenLop.Visible = false;
            }
        }

        private void grvDSQuyetDinh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (dtQuyetDinh != null)
            {
                if (grvDSQuyetDinh.FocusedRowHandle >= 0)
                {
                    drQuyetDinh = grvDSQuyetDinh.GetDataRow(grvDSQuyetDinh.FocusedRowHandle);
                    dtKyLuat = oBSV_SinhVien_KyLuat.GetByQuyetDinh(int.Parse(drQuyetDinh["SV_QuyetDinhKyLuatID"].ToString()));
                    grdDanhSachKyLuat.DataSource = dtKyLuat;
                    return;
                }
            }
            drQuyetDinh = null;
            grdDanhSachKyLuat.DataSource = null;
        }

        private void grvDanhSachHocSinh_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvDanhSachKhenThuong_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F5)
            //{
            //    frmHanhViViPham frm = new frmHanhViViPham();
            //    frm.ShowDialog();
            //    LoadHanhVi();
            //}
            //Xóa dữ liệu trên Grid
            if (e.KeyCode == Keys.Delete)
            {
                if (grvDanhSachKyLuat.FocusedRowHandle >= 0)
                {

                    try
                    {
                        pSV_SinhVien_KyLuatInfo.SV_SinhVien_KyLuatID = int.Parse(drSinhVien["SV_SinhVien_KyLuatID"].ToString());
                        if (pSV_SinhVien_KyLuatInfo.SV_SinhVien_KyLuatID > 0)
                            oBSV_SinhVien_KyLuat.Delete(pSV_SinhVien_KyLuatInfo);
                        drSinhVien["IDDM_HanhVi"] = 0;
                        drSinhVien["SoQuyetDinh"] = "";
                        drSinhVien["NoiDung"] = "";

                    }
                    catch
                    {

                    }
                }
            }
            CheckAll(grvDanhSachKyLuat, "Chon", e);
        }

        private void grvDanhSachHocSinh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvDanhSachHocSinh.FocusedRowHandle >= 0)
            {
                drSinhVien = dtSinhVien.NewRow();
                drSinhVien = grvDanhSachHocSinh.GetDataRow(grvDanhSachHocSinh.FocusedRowHandle);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvDanhSachHocSinh_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvDanhSachHocSinh, "Chon", e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dtSinhVien == null) return;
            DataRow[] arrDr = dtSinhVien.Select("Chon = 1");
            if (arrDr.Length > 0)
            {
                dlgQDKyLuat dlg = new dlgQDKyLuat(EDIT_MODE.THEM);
                dlg.drQuyetDinh = dtQuyetDinh.NewRow();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DataRow drNew;
                        dtQuyetDinh.Rows.Add(dlg.drQuyetDinh);
                        pSV_SinhVien_KyLuatInfo.IDSV_QuyetDinhKyLuat = int.Parse(dlg.drQuyetDinh["SV_QuyetDinhKyLuatID"].ToString());
                        foreach (DataRow dr in arrDr)
                        {
                            pSV_SinhVien_KyLuatInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                            pSV_SinhVien_KyLuatInfo.NgayXoaKyLuat = DateTime.Parse("01/01/1900");
                            pSV_SinhVien_KyLuatInfo.SV_SinhVien_KyLuatID = oBSV_SinhVien_KyLuat.Add(pSV_SinhVien_KyLuatInfo);
                            drNew = dtKyLuat.NewRow();
                            drNew["Chon"] = false;
                            drNew["SV_SinhVien_KyLuatID"] = pSV_SinhVien_KyLuatInfo.SV_SinhVien_KyLuatID;
                            drNew["SV_SinhVienID"] = pSV_SinhVien_KyLuatInfo.IDSV_SinhVien;
                            drNew["MaSinhVien"] = dr["MaSinhVien"];
                            drNew["HoVaTen"] = dr["HoVaTen"];
                            drNew["Ten"] = dr["Ten"];
                            drNew["NgaySinh"] = dr["NgaySinh"];
                            drNew["GioiTinh"] = dr["GioiTinh"];
                            drNew["TenLop"] = dr["TenLop"];
                            dtKyLuat.Rows.Add(drNew);
                            dr["Chon"] = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        ThongBaoLoi(ex.Message);
                    }
                }
            }
            else
                ThongBao("Chưa chọn sinh viên nào để thêm.");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtKyLuat == null) return;
            DataRow[] arrDr = dtKyLuat.Select("Chon = 1");
            if (arrDr.Length > 0)
            {
                if (ThongBaoChon("Bạn có chắc chắn muốn xóa những sinh viên được chọn khỏi quyết định này không?") == DialogResult.Yes)
                {
                    foreach (DataRow dr in arrDr)
                    {
                        pSV_SinhVien_KyLuatInfo.SV_SinhVien_KyLuatID = int.Parse(dr["SV_SinhVien_KyLuatID"].ToString());
                        oBSV_SinhVien_KyLuat.Delete(pSV_SinhVien_KyLuatInfo);
                    }
                    XoaThanhCong();
                }
            }
        }

        private void btnSuaQD_Click(object sender, EventArgs e)
        {
            dlgQDKyLuat dlg = new dlgQDKyLuat(EDIT_MODE.SUA);
            dlg.drQuyetDinh = drQuyetDinh;
            if (dlg.ShowDialog() == DialogResult.OK)
                SuaThanhCong();
        }

        private void btnXoaQD_Click(object sender, EventArgs e)
        {
            if (grvDSQuyetDinh.FocusedRowHandle < 0) return;
            if (ThongBaoChon("Hệ thống sẽ xóa quyết định này cùng với các sinh viên liên quan\nBạn có chắc chắn muốn xóa không?") == DialogResult.Yes)
            {
                SV_QuyetDinhKyLuatInfo pSV_QuyetDinhKyLuatInfo = new SV_QuyetDinhKyLuatInfo();
                pSV_QuyetDinhKyLuatInfo.SV_QuyetDinhKyLuatID = int.Parse(drQuyetDinh["SV_QuyetDinhKyLuatID"].ToString());
                new cBSV_QuyetDinhKyLuat().Delete(pSV_QuyetDinhKyLuatInfo);
                dtQuyetDinh.Rows.Remove(drQuyetDinh);
            }
        }
    }
}