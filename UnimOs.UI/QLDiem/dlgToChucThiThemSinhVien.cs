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
    public partial class dlgToChucThiThemSinhVien : frmBase
    {
        private cBSV_SinhVien oBSV_SinhVien;
        private DataTable dtDanhSach, dtDuThi;
        private bool Loaded = false;
        private string[] arrDaDangKy;
        private string strDaDangKy;
        private int IDDM_MonHoc, IDDM_Lop, LanThi, TotNghiep;

        public dlgToChucThiThemSinhVien(ref DataTable mdtDanhSach, int mIDDM_MonHoc, int mLanThi, bool mTotNghiep)
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
            LoadTreeLop(uctrlLop);
            LoadTreeLop(uctrlLopThiLai);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
            uctrlLopThiLai.trlLop.FocusedNodeChanged+= new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLopThiLai_FocusedNodeChanged);
            Loaded = true;
            //LoadSinhVien();
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (!Loaded) return;
            DM_LopInfo pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                IDDM_Lop = pDM_LopInfo.DM_LopID;
                LoadSinhVien();
            }
            else
                grdSinhVien.DataSource = null;
        }

        void trlLopThiLai_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (!Loaded) return;
            DM_LopInfo pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                IDDM_Lop = pDM_LopInfo.DM_LopID;
                LoadSinhVien();
            }
            else
                grdSinhVienThiLai.DataSource = null;
        }

        private void LoadSinhVien()
        {
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
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                dtDuThi = oBSV_SinhVien.GetDanhSachDuThi(IDDM_Lop, IDDM_MonHoc, Program.IDNamHoc, Program.HocKy, LanThi, strDaDangKy,TotNghiep);
                grdSinhVien.DataSource = dtDuThi;
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                dtDuThi = oBSV_SinhVien.GetDanhSachThiLai(IDDM_Lop, IDDM_MonHoc, Program.IDNamHoc, Program.HocKy, (LanThi==1?LanThi+1:LanThi), strDaDangKy, TotNghiep);
                grdSinhVienThiLai.DataSource = dtDuThi;
            }
            else
            {
                dtDuThi = oBSV_SinhVien.GetDanhSachDuThiKhoaTruoc(IDDM_MonHoc, Program.IDNamHoc, Program.HocKy, LanThi, strDaDangKy);
                grdTotNghiep.DataSource = dtDuThi;
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
                        drNew["IDSV_SinhVien"] = dr["IDSV_SinhVien"];
                        drNew["MaSinhVien"] = dr["MaSinhVien"];
                        drNew["HoVaTen"] = dr["HoVaTen"];
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
    }
}