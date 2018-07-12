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
    public partial class frmDangKyThiLaiTotNghiepKhoaTruoc : frmBase
    {
        private cBKQHT_MonThiTotNghiep_Lop oBKQHT_MonThiTotNghiep_Lop;
        private cBDM_Lop oBDM_Lop;
        private cBKQHT_DangKyThiLaiTotNghiep oBKQHT_DangKyThiLaiTotNghiep;
        private KQHT_DangKyThiLaiTotNghiepInfo pKQHT_DangKyThiLaiTotNghiepInfo;
        private DataTable dtDanhSach, dtDangKy;
        private int IDDM_MonHoc = 0;
        private string ChuoiDangKy = "";
        private string[] arrDaDangKy;

        public frmDangKyThiLaiTotNghiepKhoaTruoc()
        {
            InitializeComponent();
            oBKQHT_MonThiTotNghiep_Lop = new cBKQHT_MonThiTotNghiep_Lop();
            oBDM_Lop = new cBDM_Lop();
            oBKQHT_DangKyThiLaiTotNghiep = new cBKQHT_DangKyThiLaiTotNghiep();
            pKQHT_DangKyThiLaiTotNghiepInfo = new KQHT_DangKyThiLaiTotNghiepInfo();
        }

        private void frmDangKyThiLaiTotNghiepKhoaTruoc_Load(object sender, EventArgs e)
        {
            cmbMonHoc.Properties.DataSource = oBKQHT_MonThiTotNghiep_Lop.GetAllMon(0);
            DataTable dtTemp = oBDM_Lop.GetDanhSachLop(new DM_LopInfo(), Program.NamHoc);
            repositoryLop.DataSource = dtTemp;
            repositoryLop1.DataSource = dtTemp;
            repositoryLop2.DataSource = dtTemp;
        }

        private void LoadSinhVien()
        {
            if (dtDangKy!= null && dtDangKy.Rows.Count > 0)
            {
                arrDaDangKy = new string[dtDangKy.Rows.Count];
                for (int i = 0; i < dtDangKy.Rows.Count; i++)
                {
                    arrDaDangKy[i] = dtDangKy.Rows[i]["SV_SinhVienID"].ToString();
                }
                ChuoiDangKy = String.Join(",", arrDaDangKy) + ",";
            }
            else
                ChuoiDangKy = "0";

            if (tabSinhVien.SelectedTabPageIndex == 1)
            {
                dtDanhSach = oBKQHT_DangKyThiLaiTotNghiep.GetThiLai(IDDM_MonHoc, Program.IDNamHoc);
                if (ChuoiDangKy != "0" && ChuoiDangKy != "")
                {
                    dtDanhSach.DefaultView.RowFilter = "SV_SinhVienID not in (" + ChuoiDangKy.Substring(0, ChuoiDangKy.Length - 1) + ")";
                    grdDanhSachThiLai.DataSource = dtDanhSach.DefaultView;
                }
                else
                    grdDanhSachThiLai.DataSource = dtDanhSach;
            }
            else
            {
                dtDanhSach = oBKQHT_DangKyThiLaiTotNghiep.GetChuaThi(IDDM_MonHoc, Program.IDNamHoc);
                if (ChuoiDangKy != "0" && ChuoiDangKy != "")
                {
                    dtDanhSach.DefaultView.RowFilter = "SV_SinhVienID not in (" + ChuoiDangKy.Substring(0, ChuoiDangKy.Length - 1) + ")";
                    grdDanhSach.DataSource = dtDanhSach.DefaultView;
                }
                else
                    grdDanhSach.DataSource = dtDanhSach;
            }

        }

        private void cmbMonHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbMonHoc.EditValue != null)
            {
                IDDM_MonHoc = int.Parse(cmbMonHoc.EditValue.ToString());
                dtDangKy = oBKQHT_DangKyThiLaiTotNghiep.GetByMon(IDDM_MonHoc, Program.IDNamHoc);
                grdThiLai.DataSource = dtDangKy;
                LoadSinhVien();
            }
        }

        private void grvDanhSach_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvDanhSach, "Chon", e);
        }

        private void grvDanhSach_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvThiLai_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvThiLai_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvThiLai, "Chon", e);
            if (e.KeyCode == Keys.Delete)
            {
                if (grvThiLai.FocusedRowHandle >= 0)
                {
                    DataRow dr = grvThiLai.GetDataRow(grvThiLai.FocusedRowHandle);
                    dr["IDDM_Lop"] = 0;
                }
            }
        }

        private void grvDanhSachThiLai_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvDanhSachThiLai, "Chon", e); 
        }

        private void grvDanhSachThiLai_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void tabSinhVien_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            LoadSinhVien();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // xoa truoc khi luu
            try
            {
                oBKQHT_DangKyThiLaiTotNghiep.DeleteByMon(IDDM_MonHoc, Program.IDNamHoc);
            }
            catch { }
            if (dtDangKy != null && dtDangKy.Rows.Count > 0 && IDDM_MonHoc != 0)
            {
               
                foreach (DataRow dr in dtDangKy.Rows)
                {
                    pKQHT_DangKyThiLaiTotNghiepInfo.HocKy = Program.HocKy;
                    pKQHT_DangKyThiLaiTotNghiepInfo.IDDM_Lop = int.Parse("0" + dr["IDDM_Lop"].ToString());
                    pKQHT_DangKyThiLaiTotNghiepInfo.IDDM_MonHoc = IDDM_MonHoc;
                    pKQHT_DangKyThiLaiTotNghiepInfo.IDDM_NamHoc = Program.IDNamHoc;
                    pKQHT_DangKyThiLaiTotNghiepInfo.IDSV_SinhVien = int.Parse("0" + dr["SV_SinhVienID"].ToString());
                    oBKQHT_DangKyThiLaiTotNghiep.Add(pKQHT_DangKyThiLaiTotNghiepInfo);
                }
                ThongBao("Lưu thông tin thành công!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int Count = dtDanhSach.Rows.Count;
            DataRow[] dr = dtDanhSach.Select("Chon=1");
            if (dr.Length > 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    if ((bool)dtDanhSach.Rows[i]["Chon"])
                    {
                        dtDanhSach.Rows[i]["Chon"] = false;
                        ChuoiDangKy += dtDanhSach.Rows[i]["SV_SinhVienID"].ToString() + ",";
                        dtDangKy.ImportRow(dtDanhSach.Rows[i]);
                        dtDanhSach.Rows.Remove(dtDanhSach.Rows[i]);
                        Count = Count - 1;
                        i = i - 1;
                    }
                }
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int Count = dtDangKy.Rows.Count;
            DataRow[] dr = dtDangKy.Select("Chon=1");
            if (dr.Length > 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    if ((bool)dtDangKy.Rows[i]["Chon"])
                    {
                        dtDangKy.Rows[i]["Chon"] = false;
                        ChuoiDangKy = ChuoiDangKy.Replace(dtDangKy.Rows[i]["SV_SinhVienID"].ToString() + ",", "");
                        dtDanhSach.ImportRow(dtDangKy.Rows[i]);
                        dtDangKy.Rows.Remove(dtDangKy.Rows[i]);
                        Count = Count - 1;
                        i = i - 1;
                    }
                }
           //     tabSinhVien_SelectedPageChanged(null, null);

            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
        }
    }
}