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
    public partial class dlgToChucThi_TotNghiep_ThemSinhVien : frmBase
    {
        private cBSV_SinhVien oBSV_SinhVien;
        private DM_LopInfo pDM_LopInfo;
        private DataTable dtDanhSach, dtDuThi;
        private bool Loaded = false;
        private string[] arrDaDangKy;
        private string strDaDangKy;
        private int IDDM_MonHoc, IDDM_Lop, LanThi, TotNghiep;

        public dlgToChucThi_TotNghiep_ThemSinhVien(ref DataTable mdtDanhSach, int mIDDM_MonHoc, int mLanThi, bool mTotNghiep)
        {
            InitializeComponent();
            oBSV_SinhVien = new cBSV_SinhVien();
            dtDanhSach = mdtDanhSach;
            IDDM_MonHoc = mIDDM_MonHoc;
            LanThi = mLanThi;
            if (mTotNghiep == true)
            {
                TotNghiep = 1;
                tabThiLaiTotNghep.PageVisible = true;
            }
            else
            {
                TotNghiep = 0;
                tabThiLaiTotNghep.PageVisible = false;
            }
        }

        private void dlgToChucThiThemSinhVien_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLopDSLop);
            LoadTreeLop(uctrlLopDuThi);
            trlLopTuDo.trlLop.DataSource = (new cBDM_Lop()).GetTreeThiSinhTuDo(Program.NamHoc);
            uctrlLopDSLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(uctrlLopDSLop_FocusedNodeChanged);
            uctrlLopDuThi.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(uctrlLopDuThi_FocusedNodeChanged);
            trlLopTuDo.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
            Loaded = true;
            //LoadSinhVien();
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (!Loaded) return;
            pDM_LopInfo = trlLopTuDo.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                IDDM_Lop = pDM_LopInfo.DM_LopID;
                LoadSinhVien();
            }
            else
                grdSinhVien.DataSource = null;
        }

        void uctrlLopDSLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (!Loaded) return;
            pDM_LopInfo = uctrlLopDSLop.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                IDDM_Lop = pDM_LopInfo.DM_LopID;
                LoadSinhVien();
            }
            else
                grdSinhVien.DataSource = null;
        }

        void uctrlLopDuThi_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (!Loaded) return;
            pDM_LopInfo = uctrlLopDuThi.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                IDDM_Lop = pDM_LopInfo.DM_LopID;
                LoadSinhVien();
            }
            else
                grdSinhVienDuThi.DataSource = null;
        }

        private void LoadSinhVien()
        {
            if (pDM_LopInfo == null)
                return;
            if (dtDanhSach.Rows.Count > 0)
            {
                arrDaDangKy = new string[dtDanhSach.Rows.Count];
                for (int i = 0; i < dtDanhSach.Rows.Count; i++)
                {
                    arrDaDangKy[i] = dtDanhSach.Rows[i]["IDSV_SinhVien"].ToString();
                }
                strDaDangKy = String.Join(",", arrDaDangKy);
            }
            else
                strDaDangKy = "0";
            
            if (xtraTabControl1.SelectedTabPage.Name == "tabThemTuDanhSachDuThi")
            {
                layoutThemThiSinhTuDo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                dtDuThi = oBSV_SinhVien.GetDanhSachDuThiTotNghiep_ToChucThi(pDM_LopInfo, Program.NamHoc, Program.IDNamHoc, strDaDangKy);
                oBSV_SinhVien.TachCotHoVaTen(ref dtDuThi);
                grdSinhVienDuThi.DataSource = dtDuThi;
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "tabThemTuLop")
            {
                layoutThemThiSinhTuDo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                dtDuThi = oBSV_SinhVien.GetDanhSach_ToChucThi(pDM_LopInfo, Program.NamHoc, strDaDangKy);
                oBSV_SinhVien.TachCotHoVaTen(ref dtDuThi);
                grdSinhVien.DataSource = dtDuThi;
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "tabThiLaiTotNghep")
            {
                layoutThemThiSinhTuDo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                dtDuThi = oBSV_SinhVien.GetDanhSachDuThiKhoaTruoc(IDDM_MonHoc, Program.IDNamHoc, Program.HocKy, LanThi, strDaDangKy);
                oBSV_SinhVien.TachCotHoVaTen(ref dtDuThi);
                grdTotNghiep.DataSource = dtDuThi;
            }
            else
            {
                layoutThemThiSinhTuDo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                dtDuThi = oBSV_SinhVien.GetThiSinhTuDo(pDM_LopInfo, Program.NamHoc, Program.IDNamHoc, strDaDangKy);
                oBSV_SinhVien.TachCotHoVaTen(ref dtDuThi);
                grdThiSinhTuDo.DataSource = dtDuThi;
            }
        }

        private void grvSinhVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bool Chon = false;
            if (dtDuThi != null)
            {
                DataRow drNew;
                for (int i = 0; i < dtDuThi.Rows.Count; i++)
                {
                    DataRow dr = dtDuThi.Rows[i];
                    if (bool.Parse(dr["Chon"].ToString()))
                    {
                        drNew = dtDanhSach.NewRow();
                        drNew["Chon"] = false;
                        drNew["KQHT_DanhSachDuThiID"] = 0;
                        drNew["IDSV_SinhVien"] = dr["SV_SinhVienID"];
                        drNew["MaSinhVien"] = dr["MaSinhVien"];
                        drNew["HoVa"] = dr["HoVa"];
                        drNew["Ten"] = dr["Ten"];
                        drNew["NgaySinh"] = dr["NgaySinh"];
                        drNew["TenLop"] = dr["TenLop"];
                        dtDanhSach.Rows.Add(drNew);

                        dtDuThi.Rows.Remove(dr);
                        i--;
                        Chon = true;
                    }
                }
            }
            if (!Chon)
                ThongBao("Bạn chưa chọn Sinh viên nào !");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvSinhVienThiLai_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvSinhVien_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvSinhVien, "Chon", e);
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            LoadSinhVien();
        }

        private void grvTotNghiep_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvTotNghiep, "Chon", e);
        }

        private void grvTotNghiep_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvSinhVienDuThi_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvSinhVienDuThi, "Chon", e);
        }

        private void btnThemSinhVienTuDo_Click(object sender, EventArgs e)
        {
            dlgToChucThi_ThiSinhTuDo dlg = new dlgToChucThi_ThiSinhTuDo(dtDuThi, null, pDM_LopInfo.DM_LopID, EDIT_MODE.THEM);
            dlg.ShowDialog();
            trlLopTuDo.trlLop.DataSource = (new cBDM_Lop()).GetTreeThiSinhTuDo(Program.NamHoc);
        }

        private void grvThiSinhTuDo_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
    }
}