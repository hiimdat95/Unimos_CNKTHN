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
using Lib;

namespace UnimOs.UI
{
    public partial class frmToChucThiDaToChuc : frmBase
    {
        private DataTable dtDanhSachDuThi, dtDotThi;
        private cBKQHT_ToChucThi oBKQHT_ToChucThi;
        private clsDataTableHelper cls;
        private int IDDM_MonHoc, KQHT_ToChucThiID;
        private string TenMonHoc;

        public frmToChucThiDaToChuc()
        {
            InitializeComponent();
            oBKQHT_ToChucThi = new cBKQHT_ToChucThi();
            cls = new clsDataTableHelper();
        }

        private void frmToChucThiDaToChuc_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            grdMonThi.DataSource = LoadMonHoc();
        }

        private void LoadDanhSachDotThi(int IDDM_MonHoc)
        {
            dtDanhSachDuThi = oBKQHT_ToChucThi.GetByMonHoc(IDDM_MonHoc, Program.IDNamHoc, Program.HocKy);
            if (dtDanhSachDuThi.Rows.Count > 0)
            {
                DataTable dt = cls.SelectDistinct(dtDanhSachDuThi, new string[] { "Chon", "KQHT_ToChucThiID", "LanThi", "DotThi", "NgayThi", 
                "CaThi", "NhomTiet", "TenLop", "DongTui"});
                dtDotThi = dt.Clone();
                string KQHT_ToChucThiID = "";
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["KQHT_ToChucThiID"].ToString() != KQHT_ToChucThiID)
                    {
                        dtDotThi.ImportRow(dr);
                    }
                    else
                        dtDotThi.Rows[dtDotThi.Rows.Count - 1]["TenLop"] = dtDotThi.Rows[dtDotThi.Rows.Count - 1]["TenLop"] + ", " + dr["TenLop"];
                    KQHT_ToChucThiID = dr["KQHT_ToChucThiID"].ToString();
                }
                dtDotThi.AcceptChanges();
                grdDotThi.DataSource = dtDotThi;
            }
            else
                grdDotThi.DataSource = null;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmToChucThi frm = new frmToChucThi(0, IDDM_MonHoc, TenMonHoc);
            frm.ShowDialog();
            grvMonThi_FocusedRowChanged(null, null);
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KQHT_ToChucThiID <= 0)
            {
                ThongBao("Bạn chưa chọn đợt thi nào.");
                return;
            }
            if (bool.Parse(grvDotThi.GetDataRow(grvDotThi.FocusedRowHandle)["DongTui"].ToString()))
            {
                ThongBao("Đợt thi của môn này đã đóng túi, bạn không thể sửa.");
                return;
            }
            else
            {
                frmToChucThi frm = new frmToChucThi(KQHT_ToChucThiID, IDDM_MonHoc, TenMonHoc);
                frm.ShowDialog();
                grvMonThi_FocusedRowChanged(null, null);
            }
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvDotThi.RowCount > 0)
            {
                if (bool.Parse(grvDotThi.GetDataRow(grvDotThi.FocusedRowHandle)["DongTui"].ToString()))
                {
                    ThongBao("Đợt thi của môn này đã đóng túi, bạn không thể xóa.");
                    return;
                }
                else
                {
                    if (ThongBaoChon("Bạn có chắc chắn muốn xóa đợt thi này không ?") == DialogResult.Yes)
                    {
                        KQHT_ToChucThiInfo pKQHT_ToChucThiInfo = new KQHT_ToChucThiInfo();
                        pKQHT_ToChucThiInfo.KQHT_ToChucThiID = KQHT_ToChucThiID;
                        oBKQHT_ToChucThi.Delete(pKQHT_ToChucThiInfo);
                        grvDotThi.DeleteSelectedRows();
                    }
                }
            }
        }

        private void grvMonThi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvMonThi.DataRowCount > 0 && grvMonThi.FocusedRowHandle >= 0)
            {
                IDDM_MonHoc = int.Parse(grvMonThi.GetDataRow(grvMonThi.FocusedRowHandle)["DM_MonHocID"].ToString());
                TenMonHoc = grvMonThi.GetDataRow(grvMonThi.FocusedRowHandle)["TenMonHoc"].ToString();
                LoadDanhSachDotThi(IDDM_MonHoc);
                grvDotThi_FocusedRowChanged(null, null);
            }
            else
            {
                grdDotThi.DataSource = null;
                grdDanhSachDuThi.DataSource = null;
            }
        }

        private void grvDotThi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvDotThi.DataRowCount > 0 && grvDotThi.FocusedRowHandle >= 0)
            {
                KQHT_ToChucThiID = int.Parse(grvDotThi.GetDataRow(grvDotThi.FocusedRowHandle)["KQHT_ToChucThiID"].ToString());
                DataView dv = new DataView(dtDanhSachDuThi);
                dv.RowFilter = "not IDSV_SinhVien is null And KQHT_ToChucThiID = " + KQHT_ToChucThiID.ToString();
                grdDanhSachDuThi.DataSource = dv;
            }
            else
                grdDanhSachDuThi.DataSource = null;
        }

        private void barbtnDongTui_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string strFilter = "";
            if (grvDotThi.RowCount > 0)
            {
                int idx = grvDotThi.FocusedRowHandle;
                grvDotThi.FocusedRowHandle = -1;
                grvDotThi.FocusedRowHandle = idx;
                foreach (DataRow dr in dtDotThi.Rows)
                {
                    if (bool.Parse(dr["Chon"].ToString()))
                    {
                        if (bool.Parse(dr["DongTui"].ToString()))
                        {
                            ThongBao("Các đợt thi bạn chọn có đợt đã được đóng túi bài thi.\n Hãy chọn lại các đợt chưa đóng túi bài thi.");
                            return;
                        }
                        strFilter += (strFilter == "" ? "KQHT_ToChucThiID = " + dr["KQHT_ToChucThiID"].ToString() :
                            " Or KQHT_ToChucThiID = " + dr["KQHT_ToChucThiID"].ToString());
                    }
                }
            }
            if (strFilter != "")
            {
                DataView dv = new DataView(dtDanhSachDuThi);
                dv.RowFilter = strFilter;
                dlgDongTuiBaiThi dlg = new dlgDongTuiBaiThi(dtDanhSachDuThi, TenMonHoc);
                dlg.ShowDialog();
                if (dlg.Tag.ToString() != "")
                {
                    foreach (DataRow dr in dtDotThi.Rows)
                    {
                        if (bool.Parse(dr["Chon"].ToString()))
                        {
                            oBKQHT_ToChucThi.UpdateDongTui(true, int.Parse(dr["KQHT_ToChucThiID"].ToString()));
                            dr["DongTui"] = true;
                        }
                    }
                }
            }
            else
            {
                ThongBao("Bạn chưa chọn đợt thi nào.");
                return;
            }
        }

        private void grdDotThi_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && grdDotThi.ClientRectangle.Contains(e.X, e.Y))
            {
                popupMenu.ShowPopup(MousePosition);
            }
        }
    }
}