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
    public partial class frmKhenThuong : frmBase
    {
          private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private cBSV_SinhVien_KhenThuong oBSV_SinhVien_KhenThuong;
        private SV_SinhVien_KhenThuongInfo pSV_SinhVien_KhenThuongInfo;
        private DataTable dtSinhVien, dtKhenThuong, dtQuyetDinh;
        private DataRow drSinhVien, drQuyetDinh;
        private int IDDM_Lop = 0;

        public frmKhenThuong()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            pDM_LopInfo = new DM_LopInfo();
            oBSV_SinhVien_KhenThuong = new cBSV_SinhVien_KhenThuong();
            pSV_SinhVien_KhenThuongInfo = new SV_SinhVien_KhenThuongInfo();
            repositoryItemLookUpEdit_GioiTinh.DataSource = LoadGioiTinh();
            repositoryItemLookUpEdit_GioiTinh1.DataSource = LoadGioiTinh();
        }

        private void frmKhenThuong_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
            LoadLoaiKhenThuongReposity();
            dtQuyetDinh = new cBSV_QuyetDinhKhenThuong().GetByHocKyNamHoc(Program.IDNamHoc, Program.HocKy);
            grdDSQuyetDinh.DataSource = dtQuyetDinh;
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
                IDDM_Lop = pDM_LopInfo.DM_LopID;
            LoadSinhVien_Lop();
        }

        private void LoadLoaiKhenThuongReposity()
        {
            DataTable dtHanhVi = LoadLoaiKhenThuong();
            repositoryItemLookUpEdit_KhenThuong.DataSource = dtHanhVi;
            repositoryItemLookUpEdit_KhenThuong.ValueMember = "DM_LoaiKhenThuongID";
            repositoryItemLookUpEdit_KhenThuong.DisplayMember = "TenLoaiKhenThuong";
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

        //private void btnCapNhat_Click(object sender, EventArgs e)
        //{
        //    DataTable dtTemp = dtSinhVien.GetChanges();
        //    if (dtTemp == null)
        //    {
        //        ThongBao("Dữ liệu không thay đổi.");
        //        return;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < dtTemp.Rows.Count; i++)
        //        {
        //            if (("" + dtTemp.Rows[i]["SV_SinhVien_KhenThuongID"].ToString()) == "0")
        //            {
        //                // Thêm
        //                if (("" + dtTemp.Rows[i]["SoQuyetDinh"].ToString()) != "" && dtTemp.Rows[i]["IDDM_LoaiKhenThuong"].ToString() != "")
        //                {
        //                    pSV_SinhVien_KhenThuongInfo.IDSV_SinhVien = int.Parse(dtTemp.Rows[i]["SV_SinhVienID"].ToString());
        //                    pSV_SinhVien_KhenThuongInfo.IDDM_LoaiKhenThuong = "" + dtTemp.Rows[i]["IDDM_LoaiKhenThuong"].ToString() == "" ? 0 : int.Parse(dtTemp.Rows[i]["IDDM_LoaiKhenThuong"].ToString());
        //                    pSV_SinhVien_KhenThuongInfo.SoQuyetDinh = dtTemp.Rows[i]["SoQuyetDinh"].ToString();
        //                    pSV_SinhVien_KhenThuongInfo.NgayQuyetDinh = "" + dtTemp.Rows[i]["NgayQuyetDinh"].ToString() == "" ? DateTime.Today : DateTime.Parse(dtTemp.Rows[i]["NgayQuyetDinh"].ToString());
        //                    pSV_SinhVien_KhenThuongInfo.HocKy = Program.HocKy;
        //                    pSV_SinhVien_KhenThuongInfo.IDDM_NamHoc = Program.IDNamHoc;
        //                    pSV_SinhVien_KhenThuongInfo.NoiDungKhenThuong = dtTemp.Rows[i]["NoiDungKhenThuong"].ToString();

        //                    dtTemp.Rows[i]["SV_SinhVien_KhenThuongID"] = oBSV_SinhVien_KhenThuong.Add(pSV_SinhVien_KhenThuongInfo);
        //                }
        //            }
        //            else
        //            {
        //                //Sửa
        //                if (("" + dtTemp.Rows[i]["SoQuyetDinh"].ToString()) != "" && dtTemp.Rows[i]["IDDM_LoaiKhenThuong"].ToString() != "")
        //                {
        //                    pSV_SinhVien_KhenThuongInfo.SV_SinhVien_KhenThuongID = int.Parse(dtTemp.Rows[i]["SV_SinhVien_KhenThuongID"].ToString());
        //                    pSV_SinhVien_KhenThuongInfo.IDSV_SinhVien = int.Parse(dtTemp.Rows[i]["SV_SinhVienID"].ToString());
        //                    pSV_SinhVien_KhenThuongInfo.IDDM_LoaiKhenThuong = "" + dtTemp.Rows[i]["IDDM_LoaiKhenThuong"].ToString() == "" ? 0 : int.Parse(dtTemp.Rows[i]["IDDM_LoaiKhenThuong"].ToString());
        //                    pSV_SinhVien_KhenThuongInfo.SoQuyetDinh = dtTemp.Rows[i]["SoQuyetDinh"].ToString();
        //                    pSV_SinhVien_KhenThuongInfo.NgayQuyetDinh = "" + dtTemp.Rows[i]["NgayQuyetDinh"].ToString() == "" ? DateTime.Today : DateTime.Parse(dtTemp.Rows[i]["NgayQuyetDinh"].ToString());
        //                    pSV_SinhVien_KhenThuongInfo.HocKy = Program.HocKy;
        //                    pSV_SinhVien_KhenThuongInfo.IDDM_NamHoc = Program.IDNamHoc;
        //                    pSV_SinhVien_KhenThuongInfo.NoiDungKhenThuong = dtTemp.Rows[i]["NoiDungKhenThuong"].ToString();

        //                    oBSV_SinhVien_KhenThuong.Update(pSV_SinhVien_KhenThuongInfo);
        //                }
        //            }
        //        }
        //        ThongBao("Cập nhật thành công!");
        //        LoadSinhVien_Lop();
        //        dtSinhVien.AcceptChanges();
        //    }
        //}

        private void grvDSQuyetDinh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (dtQuyetDinh != null)
            {
                if (grvDSQuyetDinh.FocusedRowHandle >= 0)
                {
                    drQuyetDinh = grvDSQuyetDinh.GetDataRow(grvDSQuyetDinh.FocusedRowHandle);
                    dtKhenThuong = oBSV_SinhVien_KhenThuong.GetByQuyetDinh((int)drQuyetDinh[0]);
                    grdDanhSachKhenThuong.DataSource = dtKhenThuong;
                    return;
                }
            }
            drQuyetDinh = null;
            grdDanhSachKhenThuong.DataSource = null;
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
                if (grvDanhSachKhenThuong.FocusedRowHandle >= 0)
                {

                    try
                    {
                        pSV_SinhVien_KhenThuongInfo.SV_SinhVien_KhenThuongID = int.Parse(drSinhVien["SV_SinhVien_KhenThuongID"].ToString());
                        if (pSV_SinhVien_KhenThuongInfo.SV_SinhVien_KhenThuongID > 0)
                            oBSV_SinhVien_KhenThuong.Delete(pSV_SinhVien_KhenThuongInfo);
                        drSinhVien["IDDM_LoaiKhenThuong"] = 0;
                        drSinhVien["SoQuyetDinh"] = "";
                        drSinhVien["NoiDungKhenThuong"] = "";

                    }
                    catch
                    {

                    }
                }
            }
            CheckAll(grvDanhSachKhenThuong, "Chon", e);
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
                dlgQDKhenThuong dlg = new dlgQDKhenThuong(EDIT_MODE.THEM);
                dlg.drQuyetDinh = dtQuyetDinh.NewRow();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DataRow drNew;
                        dtQuyetDinh.Rows.Add(dlg.drQuyetDinh);
                        pSV_SinhVien_KhenThuongInfo.IDSV_QuyetDinhKhenThuong = int.Parse(dlg.drQuyetDinh["SV_QuyetDinhKhenThuongID"].ToString());
                        foreach (DataRow dr in arrDr)
                        {
                            pSV_SinhVien_KhenThuongInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                            pSV_SinhVien_KhenThuongInfo.SV_SinhVien_KhenThuongID = oBSV_SinhVien_KhenThuong.Add(pSV_SinhVien_KhenThuongInfo);
                            drNew = dtKhenThuong.NewRow();
                            drNew["Chon"] = false;
                            drNew["SV_SinhVien_KhenThuongID"] = pSV_SinhVien_KhenThuongInfo.SV_SinhVien_KhenThuongID;
                            drNew["SV_SinhVienID"] = pSV_SinhVien_KhenThuongInfo.IDSV_SinhVien;
                            drNew["MaSinhVien"] = dr["MaSinhVien"];
                            drNew["HoVaTen"] = dr["HoVaTen"];
                            drNew["Ten"] = dr["Ten"];
                            drNew["NgaySinh"] = dr["NgaySinh"];
                            drNew["GioiTinh"] = dr["GioiTinh"];
                            drNew["TenLop"] = dr["TenLop"];
                            dtKhenThuong.Rows.Add(drNew);
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
            if (dtKhenThuong == null) return;
            DataRow[] arrDr = dtKhenThuong.Select("Chon = 1");
            if (arrDr.Length > 0)
            {
                if (ThongBaoChon("Bạn có chắc chắn muốn xóa những sinh viên được chọn khỏi quyết định này không?") == DialogResult.Yes)
                {
                    foreach (DataRow dr in arrDr)
                    {
                        pSV_SinhVien_KhenThuongInfo.SV_SinhVien_KhenThuongID = int.Parse(dr["SV_SinhVien_KhenThuongID"].ToString());
                        oBSV_SinhVien_KhenThuong.Delete(pSV_SinhVien_KhenThuongInfo);
                    }
                    XoaThanhCong();
                }
            }
        }

        private void btnSuaQD_Click(object sender, EventArgs e)
        {
            dlgQDKhenThuong dlg = new dlgQDKhenThuong(EDIT_MODE.SUA);
            dlg.drQuyetDinh = drQuyetDinh;
            if (dlg.ShowDialog() == DialogResult.OK)
                SuaThanhCong();
        }

        private void btnXoaQD_Click(object sender, EventArgs e)
        {
            if (grvDSQuyetDinh.FocusedRowHandle < 0) return;
            if (ThongBaoChon("Hệ thống sẽ xóa quyết định này cùng với các sinh viên liên quan\nBạn có chắc chắn muốn xóa không?") == DialogResult.Yes)
            {
                SV_QuyetDinhKhenThuongInfo pSV_QuyetDinhKhenThuongInfo = new SV_QuyetDinhKhenThuongInfo();
                pSV_QuyetDinhKhenThuongInfo.SV_QuyetDinhKhenThuongID = int.Parse(drQuyetDinh["SV_QuyetDinhKhenThuongID"].ToString());
                new cBSV_QuyetDinhKhenThuong().Delete(pSV_QuyetDinhKhenThuongInfo);
                dtQuyetDinh.Rows.Remove(drQuyetDinh);
            }
        }
    }
}