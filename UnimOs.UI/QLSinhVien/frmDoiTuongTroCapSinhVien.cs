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
using DevExpress.XtraGrid.Views.BandedGrid;

namespace UnimOs.UI
{
    public partial class frmDoiTuongTroCapSinhVien : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private cBSV_DoiTuongTroCap oBSV_DoiTuongTroCap;
        private SV_DoiTuongTroCapInfo pSV_DoiTuongTroCapInfo;
        private DataTable dtSinhVien;
        private DataRow drSinhVien;
        int IDDM_Khoa, IDDM_He, IDDM_TrinhDo, IDDM_KhoaHoc, IDDM_Nganh, IDDM_Lop;

        public frmDoiTuongTroCapSinhVien()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            pDM_LopInfo = new DM_LopInfo();
            oBSV_DoiTuongTroCap = new cBSV_DoiTuongTroCap();
            pSV_DoiTuongTroCapInfo = new SV_DoiTuongTroCapInfo();
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
                IDDM_Lop = pDM_LopInfo.DM_LopID;
            LoadSinhVien_Lop();
        }

        private void LoadSinhVien_Lop()
        {
            IDDM_Khoa = pDM_LopInfo.IDDM_Khoa;
            IDDM_He = pDM_LopInfo.IDDM_He;
            IDDM_TrinhDo = pDM_LopInfo.IDDM_TrinhDo;
            IDDM_Nganh = pDM_LopInfo.IDDM_Nganh;
            IDDM_KhoaHoc = pDM_LopInfo.IDDM_KhoaHoc;
            dtSinhVien = oBSV_DoiTuongTroCap.GetSinhVien(IDDM_Khoa, IDDM_He, IDDM_TrinhDo, IDDM_KhoaHoc, IDDM_Nganh, IDDM_Lop, Program.IDNamHoc, Program.HocKy);
            grdDanhSachSinhVien.DataSource = dtSinhVien;
        }

        private void frmDoiTuongTroCapSinhVien_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
            LoadDoiTuongTroCap();
        }

        private void LoadDoiTuongTroCap()
        {
            cBDM_DoiTuongTroCap oBDM_DoiTuongTroCap = new cBDM_DoiTuongTroCap();
            DM_DoiTuongTroCapInfo pDM_DoiTuongTroCapInfo = new DM_DoiTuongTroCapInfo();
            DataTable dtTroCap = oBDM_DoiTuongTroCap.Get(pDM_DoiTuongTroCapInfo);
            repositoryItemLookUpEdit_DoiTuongTroCap.DataSource = dtTroCap;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (grvDanhSachSinhVien.DataRowCount == 0)
            {
                ThongBao("Không có dữ liêu.");
                return;
            }
            DataTable dtTemp = dtSinhVien.GetChanges();
            bool TrangThai = false;
            if (dtTemp == null)
            {
                ThongBao("Dữ liệu không thay đổi.");
                return;
            }
            else
            {
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    if (("" + dtTemp.Rows[i]["SV_DoiTuongTroCapID"].ToString()) == "")
                    {
                        // Thêm
                        if (dtTemp.Rows[i]["IDDM_DoiTuongTroCap"].ToString() != "")
                        {
                            pSV_DoiTuongTroCapInfo.IDSV_SinhVien = int.Parse(dtTemp.Rows[i]["SV_SinhVienID"].ToString());
                            pSV_DoiTuongTroCapInfo.IDDM_DoiTuongTroCap = "" + dtTemp.Rows[i]["IDDM_DoiTuongTroCap"].ToString() == "" ? 0 : int.Parse(dtTemp.Rows[i]["IDDM_DoiTuongTroCap"].ToString());
                            pSV_DoiTuongTroCapInfo.GhiChu = dtTemp.Rows[i]["GhiChu"].ToString();
                            pSV_DoiTuongTroCapInfo.HocKy = Program.HocKy;
                            pSV_DoiTuongTroCapInfo.IDDM_NamHoc = Program.IDNamHoc;

                            dtTemp.Rows[i]["SV_DoiTuongTroCapID"] = oBSV_DoiTuongTroCap.Add(pSV_DoiTuongTroCapInfo);
                            TrangThai = true;
                        }
                    }
                    else
                    {
                        //Sửa
                        if (dtTemp.Rows[i]["IDDM_DoiTuongTroCap"].ToString() != "")
                        {
                            pSV_DoiTuongTroCapInfo.SV_DoiTuongTroCapID = int.Parse(dtTemp.Rows[i]["SV_DoiTuongTroCapID"].ToString());
                            pSV_DoiTuongTroCapInfo.IDSV_SinhVien = int.Parse(dtTemp.Rows[i]["SV_SinhVienID"].ToString());
                            pSV_DoiTuongTroCapInfo.IDDM_DoiTuongTroCap = "" + dtTemp.Rows[i]["IDDM_DoiTuongTroCap"].ToString() == "" ? 0 : int.Parse(dtTemp.Rows[i]["IDDM_DoiTuongTroCap"].ToString());
                            pSV_DoiTuongTroCapInfo.GhiChu = dtTemp.Rows[i]["GhiChu"].ToString();
                            pSV_DoiTuongTroCapInfo.HocKy = Program.HocKy;
                            pSV_DoiTuongTroCapInfo.IDDM_NamHoc = Program.IDNamHoc;

                            oBSV_DoiTuongTroCap.Update(pSV_DoiTuongTroCapInfo);
                            TrangThai = true;
                        }
                    }
                }
                if (TrangThai == true)
                {
                    ThongBao("Cập nhật thành công!");
                }
                LoadSinhVien_Lop();
                dtSinhVien.AcceptChanges();
            }
        }

        private void grvDanhSachSinhVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (grvDanhSachSinhVien.FocusedRowHandle >= 0)
                {

                    try
                    {
                        pSV_DoiTuongTroCapInfo.SV_DoiTuongTroCapID = int.Parse(drSinhVien["SV_DoiTuongTroCapID"].ToString());
                        if (pSV_DoiTuongTroCapInfo.SV_DoiTuongTroCapID > 0)
                        {
                            oBSV_DoiTuongTroCap.Delete(pSV_DoiTuongTroCapInfo);
                            LoadSinhVien_Lop();
                        }
                        drSinhVien["IDSV_SinhVien"] = 0;
                    }
                    catch
                    {

                    }

                }
            }
        }

        private void grvDanhSachSinhVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvDanhSachSinhVien.FocusedRowHandle >= 0)
            {
                drSinhVien = dtSinhVien.NewRow();
                drSinhVien = grvDanhSachSinhVien.GetDataRow(grvDanhSachSinhVien.FocusedRowHandle);
            }
        }

        private void grvDanhSachSinhVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDoiTuongTroCapSinhVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDoiTuongTroCap frm = new frmDoiTuongTroCap();
                frm.ShowDialog();
                LoadDoiTuongTroCap();
            }
        }
    }
}