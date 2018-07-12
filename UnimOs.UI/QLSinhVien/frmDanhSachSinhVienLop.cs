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
using System.IO;
using UnimOs.UI.Properties;
using System.Diagnostics;

namespace UnimOs.UI
{
    public partial class frmDanhSachSinhVienLop : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private DataTable dtSinhVien;
        private SV_SinhVienInfo pSV_SinhVienInfo;
        private cBSV_SinhVien oBSV_SinhVien;
        private int IDDM_Lop;
        private DataRow drSinhVien;

        public frmDanhSachSinhVienLop()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            pDM_LopInfo = new DM_LopInfo();
            pSV_SinhVienInfo = new SV_SinhVienInfo();
            oBSV_SinhVien = new cBSV_SinhVien();
            repositoryItemLookUpEditGioiTinh.DataSource = LoadGioiTinhSV();

            //cboDanhSachHienThi.
        }

        private void frmDanhSachSinhVienLop_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
                IDDM_Lop = pDM_LopInfo.DM_LopID;
            LoadSinhVien_Lop();
            btnCapNhat.Enabled = false;
            SetEditable(false);
        }

        private void SetEditable(bool status)
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn grc in grvSinhVien.Columns)
            {
                if (grc.FieldName != "Chon")
                    grc.OptionsColumn.AllowEdit = status;
            }
        }

        private void grvSinhVien_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && grdSinhVien.ClientRectangle.Contains(e.X, e.Y))
            {
                popupMenu.ShowPopup(MousePosition);
            }
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgSinhVien dlg = new dlgSinhVien(dtSinhVien, drSinhVien, IDDM_Lop, EDIT_MODE.THEM);
            dlg.ShowDialog();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvSinhVien.FocusedRowHandle >= 0)
            {
                frmHoSoSinhVien dlg = new frmHoSoSinhVien(dtSinhVien, ref drSinhVien);
                dlg.ShowDialog();
            }
        }

        private void barbtnTimKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgTimKiemSinhVien frm = new dlgTimKiemSinhVien(dtSinhVien, IDDM_Lop);
            frm.ShowDialog();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dtSinhVien != null)
            {
                DataView dv = new DataView(dtSinhVien);
                dv.RowFilter = "Chon=1";
                if (dv.Count > 0)
                {
                    if (ThongBaoChon("Bạn có chắc chắn muốn xóa những sinh viên được chọn không?") == DialogResult.Yes)
                    {
                        int ChuaXoa = 0;
                        for (int i = 0; i < dv.Count; i++)
                        {
                            try
                            {
                                pSV_SinhVienInfo.SV_SinhVienID = int.Parse(dv[i]["SV_SinhVienID"].ToString());
                                oBSV_SinhVien.Delete(pSV_SinhVienInfo);
                            }
                            catch
                            {
                                ChuaXoa++;
                            }
                        }
                        trlLop_FocusedNodeChanged(null, null);
                        if (ChuaXoa > 0)
                            ThongBao("Còn " + ChuaXoa.ToString() + " sinh viên chưa xóa được.");
                        else
                            XoaThanhCong();
                    }
                }
            }
        }

        private void barbtnChuyenLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvSinhVien.FocusedRowHandle >= 0)
            {
                dlgChonLop dlg = new dlgChonLop(false);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    int IDSV_SinhVien = int.Parse(grvSinhVien.GetDataRow(grvSinhVien.FocusedRowHandle)["SV_SinhVienID"].ToString());
                    oBSV_SinhVien.ChuyenLop(IDSV_SinhVien, pDM_LopInfo.DM_LopID, dlg.pDM_LopInfo.DM_LopID, (int)TRANGTHAISINHVIEN.CHUYENLOP);

                    // Thực hiện chuyển điểm từ lớp cũ sang lớp mới
                    // Hiển thị form để ánh xạ giữa môn học của chương trình đào tạo này so với môn học của chương trình đạo tạo kia
                    dlgChuyenLop_ChuyenDiem _dlgChuyenDiem = new dlgChuyenLop_ChuyenDiem();
                    _dlgChuyenDiem.IDSV_SinhVien = IDSV_SinhVien;
                    _dlgChuyenDiem.IDDM_LopCu = pDM_LopInfo.DM_LopID;
                    _dlgChuyenDiem.IDDM_LopMoi = dlg.pDM_LopInfo.DM_LopID;
                    _dlgChuyenDiem.ShowDialog();

                    LoadSinhVien_Lop();
                }
            }
        }

        private void LoadSinhVien_Lop()
        {
            int trangThaiLayDanhSach = 1;

            switch (cboDanhSachHienThi.SelectedIndex)
            {
                case 0:
                    trangThaiLayDanhSach = 1;
                    break;
                case 1:
                    trangThaiLayDanhSach = 2;
                    break;
                case 2:
                    trangThaiLayDanhSach = 0;
                    break;
            }

            dtSinhVien = oBSV_SinhVien.GetByLop(IDDM_Lop, trangThaiLayDanhSach);
            if (!dtSinhVien.Columns.Contains("HoVa"))
                dtSinhVien.Columns.Add("HoVa", typeof(string));
            string HoDem = "";
            foreach (DataRow dr in dtSinhVien.Rows)
            {
                GetTen(dr["HoVaTen"].ToString(), ref HoDem);
                dr["HoVa"] = HoDem;

                if (dr["KhenThuong"] + "" != "")
                {
                    dr["KhenThuong"] = string.Join("\n", dr["KhenThuong"].ToString().Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                }
                if (dr["KyLuat"] + "" != "")
                {
                    dr["KyLuat"] = string.Join("\n", dr["KyLuat"].ToString().Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                }
            }
            dtSinhVien.AcceptChanges();
            grdSinhVien.DataSource = dtSinhVien;
            lblSySo.Text = "Sỹ số: " + dtSinhVien.Rows.Count.ToString();
        }

        private void grvSinhVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvSinhVien.FocusedRowHandle >= 0)
            {
                drSinhVien = grvSinhVien.GetDataRow(e.FocusedRowHandle);
                //oBSV_SinhVien.ToInfo(ref pSV_SinhVienInfo, drSinhVien);
            }
        }

        private void grvSinhVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnLyLich_Click(object sender, EventArgs e)
        {
            if (grvSinhVien.FocusedRowHandle >= 0)
            {
                frmHoSoSinhVien frm = new frmHoSoSinhVien(dtSinhVien, ref drSinhVien);
                frm.ShowDialog();
            }
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            if (grvSinhVien.DataRowCount > 0)
            {
                CreateWaitDialog("Đang xuất dữ liệu, xin vui lòng chờ.", "Xuất dữ liệu");
                try
                {
                    Lib.clsExportToWord cls = new Lib.clsExportToWord();
                    Microsoft.Office.Interop.Word.ApplicationClass WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                    Microsoft.Office.Interop.Word.Document aDoc = null;
                    cls.InitWord(WordApp, ref aDoc, 12);

                    cls.AddText(aDoc, "Danh sách sinh viên " + pDM_LopInfo.TenLop + ( cboDanhSachHienThi.SelectedIndex == 1 ? " (đã bị xóa tên)" : "" ), 1, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter, 16);

                    cls.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft, 12);
                    cls.AddTable(aDoc, dtSinhVien, new string[] { "Mã sinh viên", "Họ và tên", "Ngày sinh", "Nơi sinh", "Thường trú", "Khen thưởng","Kỷ luật" },
                        new string[] { "MaSinhVien", "HoVaTen", "NgaySinh", "NoiSinh", "ThuongTru", "KhenThuong", "KyLuat" });

                    WordApp.Visible = true;
                    CloseWaitDialog();
                }
                catch (Exception ex)
                {
                    CloseWaitDialog();
                    ThongBaoLoi("Có lỗi khi xuất dữ liệu. " + ex.Message);
                }
            }
            else
                ThongBao("Chưa có danh sách sinh viên.");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grvSinhVien.DataRowCount > 0)
            {
                btnCapNhat.Enabled = true;
                SetEditable(true);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DateTime NgaySinh;
            bool GioiTinh;
            DataTable dtChanged = dtSinhVien.GetChanges();
            if (dtChanged != null)
            {
                try
                {
                    foreach (DataRow dr in dtChanged.Rows)
                    {
                        NgaySinh = ("" + dr["NgaySinh"] == "" ? DateTime.Parse("01/01/1900") : DateTime.Parse(dr["NgaySinh"].ToString()));
                        GioiTinh = ("" + dr["GioiTinh"] != "" ? bool.Parse(dr["GioiTinh"].ToString()) : false);
                        oBSV_SinhVien.UpdateTheoLop("" + dr["MaSinhVien"], "" + dr["HoVa"] + " " + dr["Ten"], "" + dr["Ten"], NgaySinh, GioiTinh, "" + dr["NoiSinh"],
                            "" + dr["ThuongTru"], int.Parse(dr["SV_SinhVienID"].ToString()));
                    }
                    SuaThanhCong();
                }
                catch (Exception ex)
                {
                    ThongBaoLoi("Có lỗi trong quá trình cập nhật.\n" + ex.Message);
                }
            }
            btnCapNhat.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvSinhVien_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvSinhVien, "Chon", e);
        }

        private void cboDanhSachHienThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSinhVien_Lop();
        }

        private void btnXuatDanhSach_Click(object sender, EventArgs e)
        {
            if (grvSinhVien.DataRowCount > 0)
            {
                CreateWaitDialog("Đang xuất dữ liệu, xin vui lòng chờ.", "Xuất dữ liệu");
                try
                {
                    MemoryStream ms = new MemoryStream(Resources.DanhSachSinhVien);

                    var book = new Aspose.Cells.Workbook();
                    book.Open(ms);


                    var sheet = book.Worksheets[0];
                    var cells = sheet.Cells;

                    var fields = new string[] { "MaSinhVien", "HoVaTen", "NgaySinh", "NoiSinh", "ThuongTru", "KhenThuong", "KyLuat" };

                    cells["A2"].PutValue("Danh sách sinh viên " + pDM_LopInfo.TenLop + (cboDanhSachHienThi.SelectedIndex == 1 ? " (đã bị xóa tên)" : ""));

                    var rIndex = 5;
                    for (var i = 0; i < dtSinhVien.Rows.Count; i++)
                    {
                        if (i < dtSinhVien.Rows.Count - 2)
                        {
                            cells.InsertRow(rIndex + i+1);
                        }

                        cells["A" + (rIndex + i)].PutValue(i + 1);

                        for (var j = 0; j < fields.Length; j++)
                        {
                            cells[rIndex + i - 1, j + 1].PutValue(dtSinhVien.Rows[i][fields[j]]);
                        }
                    }

                    SaveFileDialog sDlg = new SaveFileDialog();
                    sDlg.Title = "Lưu file kết xuất";
                    sDlg.InitialDirectory = Application.StartupPath;
                    sDlg.FileName = "DanhSachSinhVien_" + DateTime.Now.ToString("yyyyMMddhhmm") + ".xls";

                    if (sDlg.ShowDialog() != DialogResult.Cancel)
                    {
                        book.Save(sDlg.FileName, Aspose.Cells.FileFormatType.Excel2003);

                        Process.Start(sDlg.FileName);
                    }
                }
                catch (Exception ex)
                {
                    ThongBaoLoi("Có lỗi khi xuất dữ liệu. " + ex.Message);
                }
                finally
                {
                    CloseWaitDialog();
                }
            }
            else
                ThongBao("Chưa có danh sách sinh viên.");
        }
    }
}