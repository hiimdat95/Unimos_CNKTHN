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
    public partial class frmGoiNhapHoc : frmBase
    {
        private cBSV_SinhVienNhapTruong oBSV_SinhVienNhapTruong;
        private SV_SinhVienNhapTruongInfo pSV_SinhVienNhapTruongInfo;
        private cBSV_SinhVien_GiayToNhapTruong oBSV_SinhVien_GiayToNhapTruong;
        private SV_SinhVien_GiayToNhapTruongInfo pSV_SinhVien_GiayToNhapTruongInfo;
        private System.Data.DataTable dtSinhVien;
        private DataRow drSinhVien;

        public frmGoiNhapHoc()
        {
            InitializeComponent();
            this.Text += " - NAM HOC: " + Program.NamHoc;
            oBSV_SinhVienNhapTruong = new cBSV_SinhVienNhapTruong();
            pSV_SinhVienNhapTruongInfo = new SV_SinhVienNhapTruongInfo();
            oBSV_SinhVien_GiayToNhapTruong = new cBSV_SinhVien_GiayToNhapTruong();
            pSV_SinhVien_GiayToNhapTruongInfo = new SV_SinhVien_GiayToNhapTruongInfo();
            repositoryItemLookUpEditGioiTinh.DataSource = LoadGioiTinh();
            dtpNgayNhapHoc.EditValue = DateTime.Now;
            cmbTrinhDo.Properties.DataSource = LoadTrinhDo();
            cmbKhoaHoc.Properties.DataSource = LoadKhoaHoc();
        }

        private void frmGoiNhapHoc_Load(object sender, EventArgs e)
        {
            dtSinhVien = oBSV_SinhVienNhapTruong.GetByNamHoc(Program.IDNamHoc);
            grdSVTrungTuyen.DataSource = dtSinhVien;
        }

        private void GetpNhapTruong(DataRow drSV)
        {
            pSV_SinhVienNhapTruongInfo.SV_SinhVienNhapTruongID = int.Parse(drSV["SV_SinhVienNhapTruongID"].ToString());
            pSV_SinhVienNhapTruongInfo.NgayNhapTruong = (DateTime)dtpNgayNhapHoc.EditValue;
            pSV_SinhVienNhapTruongInfo.IDNguoiTiepNhan = Program.objUserCurrent.HT_UserID;
        }

        private void GetpGiayTo(DataRow dr)
        {
            pSV_SinhVien_GiayToNhapTruongInfo.IDDM_GiayToNhapTruong = int.Parse(dr["DM_GiayToNhapTruongID"].ToString());
            pSV_SinhVien_GiayToNhapTruongInfo.GhiChu = "" + dr["GhiChu"];
            pSV_SinhVien_GiayToNhapTruongInfo.DaTra = false;
        }

        private void grvSVTrungTuyen_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvSVTrungTuyen_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvSVTrungTuyen.FocusedRowHandle >= 0)
            {
                drSinhVien = grvSVTrungTuyen.GetDataRow(grvSVTrungTuyen.FocusedRowHandle);
                pSV_SinhVien_GiayToNhapTruongInfo.IDSV_SinhVienNhapTruong = int.Parse(drSinhVien["SV_SinhVienNhapTruongID"].ToString());
                grdGiayTo.DataSource = oBSV_SinhVien_GiayToNhapTruong.GetBySinhVien(pSV_SinhVien_GiayToNhapTruongInfo.IDSV_SinhVienNhapTruong);
            }
            if (grvSVTrungTuyen.FocusedRowHandle < 0 && bool.Parse(drSinhVien["NhapHoc"].ToString()) == false)
            {
                btnHuy.Enabled = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int[] rowSelected = grvSVTrungTuyen.GetSelectedRows();
            bool Error = false;
            for (int j = 0; j < rowSelected.Length; j++)
            {
                try
                {
                    GetpNhapTruong(grvSVTrungTuyen.GetDataRow(rowSelected[j]));
                    oBSV_SinhVienNhapTruong.UpdateNhapTruong(pSV_SinhVienNhapTruongInfo);
                    // Update các giấy tờ đã nộp
                    pSV_SinhVien_GiayToNhapTruongInfo.IDSV_SinhVienNhapTruong = pSV_SinhVienNhapTruongInfo.SV_SinhVienNhapTruongID;
                    for (int i = 0; i < grvGiayTo.DataRowCount; i++)
                    {
                        GetpGiayTo(grvGiayTo.GetDataRow(i));
                        oBSV_SinhVien_GiayToNhapTruong.AddGiayTo(pSV_SinhVien_GiayToNhapTruongInfo, bool.Parse(grvGiayTo.GetDataRow(i)["DaNop"].ToString()));
                    }
                    grvSVTrungTuyen.GetDataRow(rowSelected[j])["NhapHoc"] = true;
                }
                catch
                {
                    Error = true;
                }
            }
            if(Error)
                ThongBaoLoi("Có lỗi khi lưu ở một số sinh viên.");
            else
                ThongBao("Nhập học thành công cho toàn bộ sinh viên được chọn.");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {

        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            if (grvSVTrungTuyen.DataRowCount > 0)
            {
                Lib.clsExportToWord cls = new Lib.clsExportToWord();
                Microsoft.Office.Interop.Word.ApplicationClass WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                Microsoft.Office.Interop.Word.Document aDoc = null;
                cls.InitWord(WordApp, ref aDoc, 12);

                cls.AddText(aDoc, "Danh sách sinh viên trúng tuyển ", 1, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter, 16);

                cls.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft, 12);

                cls.AddTable(aDoc, dtSinhVien, new string[] { "SBD", "Họ và tên", "Ngày sinh", "Giới tính", "Khối thi", "Ngành thi" },
                    new string[] { "SoBaoDanhTS", "HoVaTenTS", "NgaySinhTS", "GioiTinhTS", "KhoiThi", "NganhThi" });
                WordApp.Visible = true;
            }
            else
                ThongBao("Chưa có danh sách sinh viên trúng tuyển.");
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToXls(grvSVTrungTuyen);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInGiayBao_Click(object sender, EventArgs e)
        {
            if (grvSVTrungTuyen != null && grvSVTrungTuyen.DataRowCount > 0)
            {
                if (cmbTrinhDo.ItemIndex >= 0 && cmbKhoaHoc.ItemIndex >= 0)
                {
                    DataTable dtTrungTuyen = dtSinhVien.Clone();
                    for (int i = 0; i < grvSVTrungTuyen.DataRowCount; i++)
                    {
                        dtTrungTuyen.ImportRow(grvSVTrungTuyen.GetDataRow(i));
                    }
                    oBSV_SinhVienNhapTruong.XuLyGiayBao(ref dtTrungTuyen, Program.NamHoc, cmbTrinhDo.Text + " - Khóa: " + cmbKhoaHoc.Text);
                    frmReport frm = new frmReport(dtTrungTuyen, "rGiayBaoNhapHoc");
                    frm.Show();
                }
                else
                    ThongBao("Bạn cần chọn Trình độ và khóa học.");
            }
            else
                ThongBao("Chưa có sinh viên nào trong danh sách.");
        }
    }
}