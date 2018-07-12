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
    public partial class frmToChucThi_TotNghiep_DaToChuc : frmBase
    {
        private DataTable dtDanhSachDuThi, dtDotThi, dtMonHoc;
        private cBKQHT_ToChucThi oBKQHT_ToChucThi;
        private clsDataTableHelper cls;
        private int IDDM_MonHoc, KQHT_ToChucThiID;
        private string TenMonHoc;

        public frmToChucThi_TotNghiep_DaToChuc()
        {
            InitializeComponent();
            oBKQHT_ToChucThi = new cBKQHT_ToChucThi();
            cls = new clsDataTableHelper();
        }

        private void frmToChucThiDaToChuc_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            dtMonHoc = (new cBDM_MonHoc()).GetMonThiTotNghiep(Program.IDNamHoc);
            grdMonThi.DataSource = dtMonHoc;
        }

        private void LoadDanhSachDotThi(int IDDM_MonHoc)
        {
            dtDotThi = oBKQHT_ToChucThi.GetDotThiByMonHoc(IDDM_MonHoc, Program.IDNamHoc, Program.HocKy);
            grdDotThi.DataSource = dtDotThi;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmToChucThi_TotNghiep frm = new frmToChucThi_TotNghiep(0, IDDM_MonHoc, dtMonHoc);
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
                frmToChucThi_TotNghiep frm = new frmToChucThi_TotNghiep(KQHT_ToChucThiID, IDDM_MonHoc, dtMonHoc);
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
                dtDanhSachDuThi = oBKQHT_ToChucThi.GetDanhSachByDotThi(KQHT_ToChucThiID);
                if (dtDanhSachDuThi.Rows.Count > 0)
                {
                    string HoVa = "";
                    foreach (DataRow dr in dtDanhSachDuThi.Rows)
                    {
                        dr["Ten"] = GetTen(dr["HoVaTen"].ToString(), ref HoVa);
                        dr["HoVa"] = HoVa;
                    }
                }
                grdDanhSachDuThi.DataSource = dtDanhSachDuThi;
            }
            else
            {
                grdDanhSachDuThi.DataSource = null;
            }
        }

        private void barbtnDongTui_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //string strFilter = "";
            //if (grvDotThi.RowCount > 0)
            //{
            //    int idx = grvDotThi.FocusedRowHandle;
            //    grvDotThi.FocusedRowHandle = -1;
            //    grvDotThi.FocusedRowHandle = idx;
            //    foreach (DataRow dr in dtDotThi.Rows)
            //    {
            //        if (bool.Parse(dr["Chon"].ToString()))
            //        {
            //            if (bool.Parse(dr["DongTui"].ToString()))
            //            {
            //                ThongBao("Các đợt thi bạn chọn có đợt đã được đóng túi bài thi.\n Hãy chọn lại các đợt chưa đóng túi bài thi.");
            //                return;
            //            }
            //            strFilter += (strFilter == "" ? "KQHT_ToChucThiID = " + dr["KQHT_ToChucThiID"].ToString() :
            //                " Or KQHT_ToChucThiID = " + dr["KQHT_ToChucThiID"].ToString());
            //        }
            //    }
            //}
            //if (strFilter != "")
            //{
            //    DataView dv = new DataView(dtDanhSachDuThi);
            //    dv.RowFilter = strFilter;
            //    dlgDongTuiBaiThi dlg = new dlgDongTuiBaiThi(dv, TenMonHoc);
            //    dlg.ShowDialog();
            //    if (dlg.Tag.ToString() != "")
            //    {
            //        foreach (DataRow dr in dtDotThi.Rows)
            //        {
            //            if (bool.Parse(dr["Chon"].ToString()))
            //            {
            //                oBKQHT_ToChucThi.UpdateDongTui(true, int.Parse(dr["KQHT_ToChucThiID"].ToString()));
            //                dr["DongTui"] = true;
            //            }
            //        }
            //    }
            //}
            if (grvDotThi.FocusedRowHandle >= 0)
            {
                dlgDongTuiBaiThi dlg = new dlgDongTuiBaiThi(dtDanhSachDuThi, TenMonHoc);
                dlg.ShowDialog();
                if (dlg.Tag.ToString() != "")
                {
                    DataRow dr = grvDotThi.GetDataRow(grvDotThi.FocusedRowHandle);
                    oBKQHT_ToChucThi.UpdateDongTui(true, int.Parse(dr["KQHT_ToChucThiID"].ToString()));
                    dr["DongTui"] = true;
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

        private void barbtnInDanhSachDuThi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdDanhSachDuThi.DataSource != null)
            {
                CreateWaitDialog("Đang tải dữ liệu, xin vui lòng chờ!", "Xuất báo cáo");
                DataTable dt = oBKQHT_ToChucThi.GetDanhSachDuThi_TotNghiep(KQHT_ToChucThiID);
                if (dt.Rows.Count > 0)
                {
                    string HoVa = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr["Ten"] = GetTen(dr["HoVaTen"].ToString(), ref HoVa);
                        dr["HoVa"] = HoVa;
                    }
                    frmReport frm = new frmReport(dt, "rDanhSachDuThi_TotNghiep");
                    frm.Show();
                    CloseWaitDialog();
                }
                else
                {
                    CloseWaitDialog();
                    ThongBao("Không có dữ liệu để in báo cáo.");
                }
            }
            else
                ThongBao("Bạn phải chọn khóa học.");
        }

        private void grvDanhSachDuThi_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
    }
}
