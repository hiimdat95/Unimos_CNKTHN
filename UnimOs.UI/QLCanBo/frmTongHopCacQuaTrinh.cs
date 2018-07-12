using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Office.Interop;

namespace UnimOs.UI
{
    public partial class frmTongHopCacQuaTrinh : frmBase
    {
        private cBNS_DonVi oBDonVi;
        private NS_DonViInfo pDonViInfo;
        private cBNS_GiaoVien oBGiaoVien;
        public NS_GiaoVienInfo pGiaoVienInfo;
        private bool Loaded = false;
        DataTable dtTree,dtGiaoVien, dtQuaTrinhBoiDuong, dtQuaTrinhCongTac, dtQuaTrinhLuanChuyen,
                  dtQuaTrinhThamGiaLLVT, dtQuaTrinhThamGiaTCCTXH, dtQuaTrinhBoNhiemChucVu,
                  dtQuaTrinhMienNhiemTuChuc, dtQuaTrinhKhenThuong, dtQuaTrinhKyLuat;
        DataRow drGiaoVien;
        private int idxGV, IDNS_GiaoVien = 0;
        private string QuaTrinhOnSelect = "QuaTrinhBoiDuong";
        private Lib.clsExportToWord clsWord;

        public frmTongHopCacQuaTrinh()
        {
            InitializeComponent();
            oBGiaoVien = new cBNS_GiaoVien();
            pGiaoVienInfo = new NS_GiaoVienInfo();
            pDonViInfo = new NS_DonViInfo();
            clsWord = new Lib.clsExportToWord();
        }

        private void frmTongHopCacQuaTrinh_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            Loaded = true;
            trvDonVi_FocusedNodeChanged(null, null);
        }

        private void LoadGiaoVien(int IDDonVi)
        {
            pGiaoVienInfo.IDNS_DonVi = IDDonVi;
            dtGiaoVien = oBGiaoVien.GetByIDNS_DonVi(IDDonVi);
            grdGiaoVien.DataSource = dtGiaoVien;
            grvGiaoVien_FocusedRowChanged(null, null);
        }

        private void LoadTreeView()
        {
            oBDonVi = new cBNS_DonVi();
            dtTree = oBDonVi.Get_Tree();
            trvDonVi.DataSource = dtTree;
            trvDonVi.ExpandAll();

        }

        private void trvDonVi_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (Loaded == true)
            {
                if (trvDonVi.Nodes.Count > 0)
                {
                    LoadGiaoVien(int.Parse(trvDonVi.FocusedNode["NS_DonViID"].ToString()));
                    pDonViInfo.NS_DonViID = int.Parse(trvDonVi.FocusedNode["NS_DonViID"].ToString());
                    pDonViInfo.MaDonVi = trvDonVi.FocusedNode["MaDonVi"].ToString();
                    pDonViInfo.TenDonVi = trvDonVi.FocusedNode["TenDonVi"].ToString();
                    pDonViInfo.ParentID = int.Parse(trvDonVi.FocusedNode["ParentID"].ToString());
                    pDonViInfo.Level = int.Parse(trvDonVi.FocusedNode["Level"].ToString());
                    pDonViInfo.IDDM_Khoa = int.Parse(trvDonVi.FocusedNode["IDDM_Khoa"].ToString());
                    pDonViInfo.IDDM_BoMon = int.Parse(trvDonVi.FocusedNode["IDDM_BoMon"].ToString());
                }
            }
        }

        private void grvGiaoVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvGiaoVien.DataRowCount > 0)
            {
                idxGV = grvGiaoVien.FocusedRowHandle;
                IDNS_GiaoVien = int.Parse("0" + grvGiaoVien.GetDataRow(idxGV)["NS_GiaoVienID"].ToString());
                DataRow dr = grvGiaoVien.GetDataRow(idxGV);
                oBGiaoVien.ToInfo(ref pGiaoVienInfo, dr);
                drGiaoVien = grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle);
                Load_GiaoVien_QuaTrinhBoiDuong();
                Load_GiaoVien_QuaTrinhBoNhiemChucVu();
                Load_GiaoVien_QuaTrinhCongTac();
                Load_GiaoVien_QuaTrinhKhenThuong();
                Load_GiaoVien_QuaTrinhKyLuat();
                Load_GiaoVien_QuaTrinhLuanChuyen();
                Load_GiaoVien_QuaTrinhMienNhiemTuChuc();
                Load_GiaoVien_QuaTrinhThamGiaLLVT();
                Load_GiaoVien_QuaTrinhThamGiaTCCTXH();
            }
        }

        #region LoadDuLieuCacQuaTrinh.

        private void Load_GiaoVien_QuaTrinhBoiDuong()
        {
            dtQuaTrinhBoiDuong = oBGiaoVien.Get_QuaTrinhBoiDuong(IDNS_GiaoVien);
            grdQuaTrinhBoiDuong.DataSource = dtQuaTrinhBoiDuong;
        }

        private void Load_GiaoVien_QuaTrinhBoNhiemChucVu()
        {
            dtQuaTrinhBoNhiemChucVu = oBGiaoVien.Get_QuaTrinhBoNhiemChucVu(IDNS_GiaoVien);
            grdQuaTrinhBoNhiemChucVu.DataSource = dtQuaTrinhBoNhiemChucVu;
        }

        private void Load_GiaoVien_QuaTrinhCongTac()
        {
            dtQuaTrinhCongTac = oBGiaoVien.Get_QuaTrinhCongTac(IDNS_GiaoVien);
            grdQuaTrinhCongTac.DataSource = dtQuaTrinhCongTac;
        }

        private void Load_GiaoVien_QuaTrinhKhenThuong()
        {
            dtQuaTrinhKhenThuong = oBGiaoVien.Get_QuaTrinhKhenThuong(IDNS_GiaoVien);
            grdQuaTrinhKhenThuong.DataSource = dtQuaTrinhKhenThuong;
        }

        private void Load_GiaoVien_QuaTrinhKyLuat()
        {
            dtQuaTrinhKyLuat = oBGiaoVien.Get_QuaTrinhKyLuat(IDNS_GiaoVien);
            grdQuaTrinhKyLuat.DataSource = dtQuaTrinhKyLuat;
        }

        private void Load_GiaoVien_QuaTrinhLuanChuyen()
        {
            dtQuaTrinhLuanChuyen = oBGiaoVien.Get_QuaTrinhLuanChuyen(IDNS_GiaoVien);
            grdQuaTrinhLuanChuyen.DataSource = dtQuaTrinhLuanChuyen;
        }

        private void Load_GiaoVien_QuaTrinhMienNhiemTuChuc()
        {
            dtQuaTrinhMienNhiemTuChuc = oBGiaoVien.Get_QuaTrinhMienNhiemTuChuc(IDNS_GiaoVien);
            grdQuaTrinhMienNhiemTuChuc.DataSource = dtQuaTrinhMienNhiemTuChuc;
        }

        private void Load_GiaoVien_QuaTrinhThamGiaLLVT()
        {
            dtQuaTrinhThamGiaLLVT = oBGiaoVien.Get_QuaTrinhThamGiaLLVT(IDNS_GiaoVien);
            grdQuaTrinhThamGiaLLVT.DataSource = dtQuaTrinhThamGiaLLVT;
        }

        private void Load_GiaoVien_QuaTrinhThamGiaTCCTXH()
        {
            dtQuaTrinhThamGiaTCCTXH = oBGiaoVien.Get_QuaTrinhThamGiaTCCTXH(IDNS_GiaoVien);
            grdQuaTrinhThamGiaTCCTXH.DataSource = dtQuaTrinhThamGiaTCCTXH;
        }
        #endregion

        private void tabTongHopCacQuaTrinh_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tabTongHopCacQuaTrinh.SelectedTabPage == tabpageQuaTrinhBoiDuong)
            {
                QuaTrinhOnSelect = "QuaTrinhBoiDuong";
            }
            if (tabTongHopCacQuaTrinh.SelectedTabPage == tabpageQuaTrinhBoNhiemChucVu)
            {
                QuaTrinhOnSelect = "QuaTrinhBoNhiemChucVu";
            }
            if (tabTongHopCacQuaTrinh.SelectedTabPage == tabpageQuaTrinhCongTac)
            {
                QuaTrinhOnSelect = "QuaTrinhCongTac";
            }
            if (tabTongHopCacQuaTrinh.SelectedTabPage == tabpageQuaTrinhKhenThuong)
            {
                QuaTrinhOnSelect = "QuaTrinhKhenThuong";
            }
            if (tabTongHopCacQuaTrinh.SelectedTabPage == tabpageQuaTrinhKyLuat)
            {
                QuaTrinhOnSelect = "QuaTrinhKyLuat";
            }
            if (tabTongHopCacQuaTrinh.SelectedTabPage == tabpageQuaTrinhLuanChuyen)
            {
                QuaTrinhOnSelect = "QuaTrinhLuanChuyen";
            }
            if (tabTongHopCacQuaTrinh.SelectedTabPage == tabpageQuaTrinhMienNhiemTuChuc)
            {
                QuaTrinhOnSelect = "QuaTrinhMienNhiemTuChuc";
            }
            if (tabTongHopCacQuaTrinh.SelectedTabPage == tabpageQuaTrinhThamGiaLLVT)
            {
                QuaTrinhOnSelect = "QuaTrinhThamGiaLLVT";
            }
            if (tabTongHopCacQuaTrinh.SelectedTabPage == tabpageQuaTrinhThamGiaTCCTXH)
            {
                QuaTrinhOnSelect = "QuaTrinhThamGiaTCCTXH";
            }
        }

        private void btnInMoiQuaTrinh_Click(object sender, EventArgs e)
        {
            switch (QuaTrinhOnSelect)
            {
                case "QuaTrinhBoiDuong":
                    {
                        if (grvQuaTrinhBoiDuong.DataRowCount == 0)
                        {
                            ThongBao("Không có dữ liệu để in");
                            return;
                        }
                        ExportToWordQuaTrinhBoiDuong();
                        break;
                    }
                case "QuaTrinhBoNhiemChucVu":
                    {
                        if (grvQuaTrinhBoNhiemChucVu.DataRowCount == 0)
                        {
                            ThongBao("Không có dữ liệu để in");
                            return;
                        }
                        ExportToWordQuaTrinhBoNhiemChucVu();
                        break;
                    }
                case "QuaTrinhCongTac":
                    {
                        if (grvQuaTrinhCongTac.DataRowCount == 0)
                        {
                            ThongBao("Không có dữ liệu để in");
                            return;
                        }
                        ExportToWordQuaTrinhCongTac();
                        break;
                    }
                case "QuaTrinhKhenThuong":
                    {
                        if (grvQuaTrinhKhenThuong.DataRowCount == 0)
                        {
                            ThongBao("Không có dữ liệu để in");
                            return;
                        }
                        ExportToWordQuaTrinhKhenThuong();
                        break;
                    }
                case "QuaTrinhKyLuat":
                    {
                        if (grvQuaTrinhKyLuat.DataRowCount == 0)
                        {
                            ThongBao("Không có dữ liệu để in");
                            return;
                        }
                        ExportToWordQuaTrinhKyLuat();
                        break;
                    }
                case "QuaTrinhLuanChuyen":
                    {
                        if (grvQuaTrinhLuanChuyen.DataRowCount == 0)
                        {
                            ThongBao("Không có dữ liệu để in");
                            return;
                        }
                        ExportToWordQuaTrinhLuanChuyen();
                        break;
                    }
                case "QuaTrinhMienNhiemTuChuc":
                    {
                        if (grvQuaTrinhMienNhiemTuChuc.DataRowCount == 0)
                        {
                            ThongBao("Không có dữ liệu để in");
                            return;
                        }
                        ExportToWordQuaTrinhMienNhiemTuChuc();
                        break;
                    }
                case "QuaTrinhThamGiaLLVT":
                    {
                        if (grvQuaTrinhThamGiaLLVT.DataRowCount == 0)
                        {
                            ThongBao("Không có dữ liệu để in");
                            return;
                        }
                        ExportToWordQuaTrinhThamGiaLLVT();
                        break;
                    }
                case "QuaTrinhThamGiaTCCTXH":
                    {
                        if (grvQuaTrinhThamGiaTCCTXH.DataRowCount == 0)
                        {
                            ThongBao("Không có dữ liệu để in");
                            return;
                        }
                        ExportToWordQuaTrinhThamGiaTCCTXH();
                        break;
                    }
            }
        }

        #region ExportToWord
        private void ExportToWordQuaTrinhBoiDuong()
        {
            CreateWaitDialog("Đang xuất dữ liệu, xin vui lòng chờ.", "Xuất dữ liệu");
            try
            {
                Microsoft.Office.Interop.Word.ApplicationClass WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                Microsoft.Office.Interop.Word.Document aDoc = null;
                clsWord.InitWord(WordApp, ref aDoc, 13);
                //Tiêu đề chính
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                WordApp.Selection.Font.Bold = 1;
                WordApp.Selection.TypeText("TỔNG HỢP QUÁ TRÌNH BỒI DƯỠNG");
                //Tiêu đề phụ
                WordApp.Selection.TypeParagraph();
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                WordApp.Selection.TypeText("DANH SÁCH CHI TIẾT CÁC LẦN ĐI BỒI DƯỠNG");
                for (int i = 0; i < dtQuaTrinhBoiDuong.Rows.Count; i++)
                {
                    WordApp.Selection.Font.Bold = 0;
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                    WordApp.Selection.TypeText("\t" + (i + 1) + "." + 
                                                  " Từ ngày: " + DateTime.Parse(dtQuaTrinhBoiDuong.Rows[i]["TuNgay"].ToString()).ToString("dd/MM/yyyy") +
                                                  " đến ngày: " + dtQuaTrinhBoiDuong.Rows[i]["BoiDuongDenNgay"] +
                                               "\n" + "\t\t" + 
                                                  "Nơi bồi dưỡng: " + dtQuaTrinhBoiDuong.Rows[i]["NoiBoiDuong"] +
                                               "\n" + "\t\t" +
                                                  "Nội dung bồi dưỡng: " + dtQuaTrinhBoiDuong.Rows[i]["NoiDungBoiDuong"] + 
                                               "\n" + "\t\t" +
                                                  "Văn bằng, chứng chỉ: " + dtQuaTrinhBoiDuong.Rows[i]["Ten"] +
                                               "\n" + "\t\t" +
                                                  "Xếp loại: " + dtQuaTrinhBoiDuong.Rows[i]["TenXepLoaiChungChi"] + 
                                               "\n" + "\t\t" +
                                                  "Hình thức đào tạo: " + dtQuaTrinhBoiDuong.Rows[i]["TenHinhThucDaoTao"]);
                }
                WordApp.Visible = true;
                CloseWaitDialog();
            }
            catch (Exception ex)
            {
                CloseWaitDialog();
                ThongBaoLoi("File word đang được mở. Đề nghị đóng file này trước khi xuất dữ liệu! Thông báo lỗi: " + ex.Message);
                return;
            }
            finally { }
        }

        private void ExportToWordQuaTrinhBoNhiemChucVu()
        {
            CreateWaitDialog("Đang xuất dữ liệu, xin vui lòng chờ.", "Xuất dữ liệu");
            try
            {
                Microsoft.Office.Interop.Word.ApplicationClass WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                Microsoft.Office.Interop.Word.Document aDoc = null;
                clsWord.InitWord(WordApp, ref aDoc, 13);
                //Tiêu đề chính
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                WordApp.Selection.Font.Bold = 1;
                WordApp.Selection.TypeText("TỔNG HỢP QUÁ TRÌNH BỔ NHIỆM CHỨC VỤ");
                //Tiêu đề phụ
                WordApp.Selection.TypeParagraph();
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                WordApp.Selection.TypeText("DANH SÁCH CHI TIẾT CÁC LẦN ĐƯỢC BỔ NHIỆM CHỨC VỤ");
                for (int i = 0; i < dtQuaTrinhBoNhiemChucVu.Rows.Count; i++)
                {
                    WordApp.Selection.Font.Bold = 0;
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                    WordApp.Selection.TypeText("\t" + (i + 1) + ". " +
                                                  "Số quyết định: " + dtQuaTrinhBoNhiemChucVu.Rows[i]["SoQuyetDinh"] +
                                               "\n" + "\t\t" +
                                                  "Ngày ra quyết định: " + DateTime.Parse(dtQuaTrinhBoNhiemChucVu.Rows[i]["NgayRaQuyetDinh"].ToString()).ToString("dd/MM/yyyy") +
                                               "\n" + "\t\t" +
                                                  "Cấp quyết định: " + dtQuaTrinhBoNhiemChucVu.Rows[i]["TenCapQuyetDinh"] +
                                               "\n" + "\t\t" +
                                                  "Chức vụ bổ nhiệm: " + dtQuaTrinhBoNhiemChucVu.Rows[i]["TenChucVu"] +
                                               "\n" + "\t\t" +
                                                  "Hình thức chức vụ: " + dtQuaTrinhBoNhiemChucVu.Rows[i]["TrangThai"] +
                                               "\n" + "\t\t" +
                                                  "Ngày có hiệu lực: " + DateTime.Parse(dtQuaTrinhBoNhiemChucVu.Rows[i]["NgayCoHieuLuc"].ToString()).ToString("dd/MM/yyyy") +
                                                  "\n" + "\t\t" +
                                                  "Ngày hết hiệu lực: " + ("" + dtQuaTrinhBoNhiemChucVu.Rows[i]["NgayHetHieuLuc1"]  ==  "" ? "" : DateTime.Parse(dtQuaTrinhBoNhiemChucVu.Rows[i]["NgayHetHieuLuc1"].ToString()).ToString("dd/MM/yyyy")));
                }
                WordApp.Visible = true;
                CloseWaitDialog();
            }
            catch (Exception ex)
            {
                CloseWaitDialog();
                ThongBaoLoi("File word đang được mở. Đề nghị đóng file này trước khi xuất dữ liệu! Thông báo lỗi: " + ex.Message);
                return;
            }
            finally { }
        }

        private void ExportToWordQuaTrinhCongTac()
        {
            CreateWaitDialog("Đang xuất dữ liệu, xin vui lòng chờ.", "Xuất dữ liệu");
            try
            {
                Microsoft.Office.Interop.Word.ApplicationClass WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                Microsoft.Office.Interop.Word.Document aDoc = null;
                clsWord.InitWord(WordApp, ref aDoc, 13);
                //Tiêu đề chính
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                WordApp.Selection.Font.Bold = 1;
                WordApp.Selection.TypeText("TỔNG HỢP QUÁ TRÌNH CÔNG TÁC");
                //Tiêu đề phụ
                WordApp.Selection.TypeParagraph();
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                WordApp.Selection.TypeText("DANH SÁCH CHI TIẾT CÁC LẦN ĐI CÔNG TÁC");
                for (int i = 0; i < dtQuaTrinhCongTac.Rows.Count; i++)
                {
                    WordApp.Selection.Font.Bold = 0;
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                    WordApp.Selection.TypeText("\t" + (i + 1) + "." +
                                                  " Từ ngày: " + DateTime.Parse(dtQuaTrinhCongTac.Rows[i]["TuNgay"].ToString()).ToString("dd/MM/yyyy") +
                                                  " đến ngày: " + dtQuaTrinhCongTac.Rows[i]["DenNgayCongTac"] +
                                               "\n" + "\t\t" +
                                                  "Nơi công tác: " + dtQuaTrinhCongTac.Rows[i]["NoiCongTac"] +
                                               "\n" + "\t\t" +
                                                  "Nội dung công tác: " + dtQuaTrinhCongTac.Rows[i]["NoiDungCongTac"] +
                                               "\n" + "\t\t" +
                                                  "Chức vụ đảm nhiệm: " + dtQuaTrinhCongTac.Rows[i]["ChucVuDamNhiem"] +
                                               "\n" + "\t\t" +
                                                  "Mã nước đi công tác: " + dtQuaTrinhCongTac.Rows[i]["MaNuoc"] +
                                               "\n" + "\t\t" +
                                                  "Tên nước đi công tác: " + dtQuaTrinhCongTac.Rows[i]["TenNuoc"]);
                }
                WordApp.Visible = true;
                CloseWaitDialog();
            }
            catch (Exception ex)
            {
                CloseWaitDialog();
                ThongBaoLoi("File word đang được mở. Đề nghị đóng file này trước khi xuất dữ liệu! Thông báo lỗi: " + ex.Message);
                return;
            }
            finally { }
        }

        private void ExportToWordQuaTrinhKhenThuong()
        {
            CreateWaitDialog("Đang xuất dữ liệu, xin vui lòng chờ.", "Xuất dữ liệu");
            try
            {
                Microsoft.Office.Interop.Word.ApplicationClass WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                Microsoft.Office.Interop.Word.Document aDoc = null;
                clsWord.InitWord(WordApp, ref aDoc, 13);
                //Tiêu đề chính
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                WordApp.Selection.Font.Bold = 1;
                WordApp.Selection.TypeText("TỔNG HỢP QUÁ TRÌNH KHEN THƯỞNG");
                //Tiêu đề phụ
                WordApp.Selection.TypeParagraph();
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                WordApp.Selection.TypeText("DANH SÁCH CHI TIẾT CÁC LẦN ĐƯỢC KHEN THƯỞNG");
                for (int i = 0; i < dtQuaTrinhKhenThuong.Rows.Count; i++)
                {
                    WordApp.Selection.Font.Bold = 0;
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                    WordApp.Selection.TypeText("\t" + (i + 1) + ". " +
                                               "Số quyết định: " + dtQuaTrinhKhenThuong.Rows[i]["SoQuyetDinh"] +
                                               "\n" + "\t\t" +
                                                  "Ngày ra quyết định: " + DateTime.Parse(dtQuaTrinhKhenThuong.Rows[i]["NgayQuyetDinh"].ToString()).ToString("dd/MM/yyyy") +
                                               "\n" + "\t\t" +
                                                  "Ngày có hiệu lực: " + DateTime.Parse(dtQuaTrinhKhenThuong.Rows[i]["NgayCoHieuLuc"].ToString()).ToString("dd/MM/yyyy") +
                                               "\n" + "\t\t" +
                                                  "Cấp khen thưởng: " + dtQuaTrinhKhenThuong.Rows[i]["TenCapKhenThuong"] +
                                               "\n" + "\t\t" +
                                                  "Nội dung: " + dtQuaTrinhKhenThuong.Rows[i]["NoiDung"] +
                                               "\n" + "\t\t" +
                                                  "Giảm số tháng tăng lương: " + dtQuaTrinhKhenThuong.Rows[i]["GiamSoThangTangLuong"] +
                                               "\n" + "\t\t" +
                                                  "số tiền thưởng: " + double.Parse("0" + dtQuaTrinhKhenThuong.Rows[i]["SoTien"].ToString()).ToString("#,###"));
                }
                WordApp.Visible = true;
                CloseWaitDialog();
            }
            catch (Exception ex)
            {
                CloseWaitDialog();
                ThongBaoLoi("File word đang được mở. Đề nghị đóng file này trước khi xuất dữ liệu! Thông báo lỗi: " + ex.Message);
                return;
            }
            finally { }
        }

        private void ExportToWordQuaTrinhKyLuat()
        {
            CreateWaitDialog("Đang xuất dữ liệu, xin vui lòng chờ.", "Xuất dữ liệu");
            try
            {
                Microsoft.Office.Interop.Word.ApplicationClass WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                Microsoft.Office.Interop.Word.Document aDoc = null;
                clsWord.InitWord(WordApp, ref aDoc, 13);
                //Tiêu đề chính
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                WordApp.Selection.Font.Bold = 1;
                WordApp.Selection.TypeText("TỔNG HỢP QUÁ TRÌNH KỶ LUẬT");
                //Tiêu đề phụ
                WordApp.Selection.TypeParagraph();
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                WordApp.Selection.TypeText("DANH SÁCH CHI TIẾT CÁC LẦN BỊ KỶ LUẬT");
                for (int i = 0; i < dtQuaTrinhKyLuat.Rows.Count; i++)
                {
                    WordApp.Selection.Font.Bold = 0;
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                    WordApp.Selection.TypeText("\t" + (i + 1) + ". " +
                                               "Số quyết định: " + dtQuaTrinhKyLuat.Rows[i]["SoQuyetDinh"] +
                                               "\n" + "\t\t" +
                                                  "Ngày ra quyết định: " + DateTime.Parse(dtQuaTrinhKyLuat.Rows[i]["NgayQuyetDinh"].ToString()).ToString("dd/MM/yyyy") +
                                               "\n" + "\t\t" +
                                                  "Ngày có hiệu lực: " + DateTime.Parse(dtQuaTrinhKyLuat.Rows[i]["NgayCoHieuLuc"].ToString()).ToString("dd/MM/yyyy") +
                                               "\n" + "\t\t" +
                                                  "Ngày hết hiệu lực: " + DateTime.Parse(dtQuaTrinhKyLuat.Rows[i]["NgayHetHieuLuc"].ToString()).ToString("dd/MM/yyyy") +
                                               "\n" + "\t\t" +
                                                  "Cấp kỷ luật: " + dtQuaTrinhKyLuat.Rows[i]["TenCapKyLuat"] +
                                               "\n" + "\t\t" +
                                                  "Nội dung: " + dtQuaTrinhKyLuat.Rows[i]["NoiDung"] +
                                               "\n" + "\t\t" +
                                                  "Tăng số tháng tăng lương: " + dtQuaTrinhKyLuat.Rows[i]["TangSoThangTangLuong"]);
                                             
                }
                WordApp.Visible = true;
                CloseWaitDialog();
            }
            catch (Exception ex)
            {
                CloseWaitDialog();
                ThongBaoLoi("File word đang được mở. Đề nghị đóng file này trước khi xuất dữ liệu! Thông báo lỗi: " + ex.Message);
                return;
            }
            finally { }
        }

        private void ExportToWordQuaTrinhLuanChuyen()
        {
            CreateWaitDialog("Đang xuất dữ liệu, xin vui lòng chờ.", "Xuất dữ liệu");
            try
            {
                Microsoft.Office.Interop.Word.ApplicationClass WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                Microsoft.Office.Interop.Word.Document aDoc = null;
                clsWord.InitWord(WordApp, ref aDoc, 13);
                //Tiêu đề chính
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                WordApp.Selection.Font.Bold = 1;
                WordApp.Selection.TypeText("TỔNG HỢP QUÁ TRÌNH LUÂN CHUYỂN");
                //Tiêu đề phụ
                WordApp.Selection.TypeParagraph();
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                WordApp.Selection.TypeText("DANH SÁCH CHI TIẾT CÁC LẦN LUÂN CHUYỂN");
                for (int i = 0; i < dtQuaTrinhLuanChuyen.Rows.Count; i++)
                {
                    WordApp.Selection.Font.Bold = 0;
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                    WordApp.Selection.TypeText("\t" + (i + 1) + ". " +
                                                  "Số quyết định: " + dtQuaTrinhLuanChuyen.Rows[i]["SoQuyetDinh"] +
                                               "\n" + "\t\t" +
                                                  "Ngày ra quyết định: " + DateTime.Parse(dtQuaTrinhLuanChuyen.Rows[i]["NgayQuyetDinh"].ToString()).ToString("dd/MM/yyyy") +
                                               "\n" + "\t\t" +
                                                  "Ngày có hiệu lực: " + DateTime.Parse(dtQuaTrinhLuanChuyen.Rows[i]["NgayCoHieuLuc"].ToString()).ToString("dd/MM/yyyy") +
                                               "\n" + "\t\t" +
                                                  "Loại luân chuyển: " + dtQuaTrinhLuanChuyen.Rows[i]["TenLoaiLuanChuyen"] +
                                               "\n" + "\t\t" +
                                                  "Đơn vị cũ: " + dtQuaTrinhLuanChuyen.Rows[i]["TenDonViCu"] +
                                               "\n" + "\t\t" +
                                                  "Đơn vị mới: " + dtQuaTrinhLuanChuyen.Rows[i]["TenDonViMoi"] +
                                               "\n" + "\t\t" +
                                                  "Nội dung: " + dtQuaTrinhLuanChuyen.Rows[i]["NoiDung"]);
                }
                WordApp.Visible = true;
                CloseWaitDialog();
            }
            catch (Exception ex)
            {
                CloseWaitDialog();
                ThongBaoLoi("File word đang được mở. Đề nghị đóng file này trước khi xuất dữ liệu! Thông báo lỗi: " + ex.Message);
                return;
            }
            finally { }
        }

        private void ExportToWordQuaTrinhMienNhiemTuChuc()
        {
            CreateWaitDialog("Đang xuất dữ liệu, xin vui lòng chờ.", "Xuất dữ liệu");
            try
            {
                Microsoft.Office.Interop.Word.ApplicationClass WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                Microsoft.Office.Interop.Word.Document aDoc = null;
                clsWord.InitWord(WordApp, ref aDoc, 13);
                //Tiêu đề chính
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                WordApp.Selection.Font.Bold = 1;
                WordApp.Selection.TypeText("TỔNG HỢP QUÁ TRÌNH MIỄN NHIỆM TỪ CHỨC");
                //Tiêu đề phụ
                WordApp.Selection.TypeParagraph();
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                WordApp.Selection.TypeText("DANH SÁCH CHI TIẾT CÁC LẦN MIỄN NHIỆM TỪ CHỨC");
                for (int i = 0; i < dtQuaTrinhMienNhiemTuChuc.Rows.Count; i++)
                {
                    WordApp.Selection.Font.Bold = 0;
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                    WordApp.Selection.TypeText("\t" + (i + 1) + ". " +
                                               "Số quyết định: " + dtQuaTrinhMienNhiemTuChuc.Rows[i]["SoQuyetDinh"] +
                                               "\n" + "\t\t" +
                                                  "Ngày ra quyết định: " + DateTime.Parse(dtQuaTrinhMienNhiemTuChuc.Rows[i]["NgayRaQuyetDinh"].ToString()).ToString("dd/MM/yyyy") +
                                               "\n" + "\t\t" +
                                                  "Ngày có hiệu lực: " + DateTime.Parse(dtQuaTrinhMienNhiemTuChuc.Rows[i]["NgayCoHieuLuc"].ToString()).ToString("dd/MM/yyyy") +
                                               "\n" + "\t\t" +
                                                  "Cấp quyết định: " + dtQuaTrinhMienNhiemTuChuc.Rows[i]["TenCapQuyetDinh"] +
                                               "\n" + "\t\t" +
                                                  "Chức vụ miễn nhiệm: " + dtQuaTrinhMienNhiemTuChuc.Rows[i]["TenChucVuMienNhiem"]);
                }
                WordApp.Visible = true;
                CloseWaitDialog();
            }
            catch (Exception ex)
            {
                CloseWaitDialog();
                ThongBaoLoi("File word đang được mở. Đề nghị đóng file này trước khi xuất dữ liệu! Thông báo lỗi: " + ex.Message);
                return;
            }
            finally { }
        }

        private void ExportToWordQuaTrinhThamGiaLLVT()
        {
            CreateWaitDialog("Đang xuất dữ liệu, xin vui lòng chờ.", "Xuất dữ liệu");
            try
            {
                Microsoft.Office.Interop.Word.ApplicationClass WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                Microsoft.Office.Interop.Word.Document aDoc = null;
                clsWord.InitWord(WordApp, ref aDoc, 13);
                //Tiêu đề chính
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                WordApp.Selection.Font.Bold = 1;
                WordApp.Selection.TypeText("TỔNG HỢP QUÁ TRÌNH THAM GIA LỰC LƯỢNG VŨ TRANG");
                //Tiêu đề phụ
                WordApp.Selection.TypeParagraph();
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                WordApp.Selection.TypeText("DANH SÁCH CHI TIẾT CÁC LẦN THAM GIA LỰC LƯỢNG VŨ TRANG");
                for (int i = 0; i < dtQuaTrinhThamGiaLLVT.Rows.Count; i++)
                {
                    WordApp.Selection.Font.Bold = 0;
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                    WordApp.Selection.TypeText("\t" + (i + 1) + ". " +
                                                  "Ngày nhập ngũ: " + DateTime.Parse(dtQuaTrinhThamGiaLLVT.Rows[i]["NgayNhapNgu"].ToString()).ToString("dd/MM/yyyy") +
                                                  " ngày xuất ngũ: " + dtQuaTrinhThamGiaLLVT.Rows[i]["DenNgayXuatNgu"] +
                                               "\n" + "\t\t" +
                                                  "Quân hàm: " + dtQuaTrinhThamGiaLLVT.Rows[i]["TenQuanHam"] +
                                               "\n" + "\t\t" +
                                                  "Đơn vị: " + dtQuaTrinhThamGiaLLVT.Rows[i]["DonVi"] +
                                               "\n" + "\t\t" +
                                                  "Chức vụ: " + dtQuaTrinhThamGiaLLVT.Rows[i]["ChucVu"]);
                }
                WordApp.Visible = true;
                CloseWaitDialog();
            }
            catch (Exception ex)
            {
                CloseWaitDialog();
                ThongBaoLoi("File word đang được mở. Đề nghị đóng file này trước khi xuất dữ liệu! Thông báo lỗi: " + ex.Message);
                return;
            }
            finally { }
        }

        private void ExportToWordQuaTrinhThamGiaTCCTXH()
        {
            CreateWaitDialog("Đang xuất dữ liệu, xin vui lòng chờ.", "Xuất dữ liệu");
            try
            {
                Microsoft.Office.Interop.Word.ApplicationClass WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                Microsoft.Office.Interop.Word.Document aDoc = null;
                clsWord.InitWord(WordApp, ref aDoc, 13);
                //Tiêu đề chính
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                WordApp.Selection.Font.Bold = 1;
                WordApp.Selection.TypeText("TỔNG HỢP QUÁ TRÌNH THAM GIA TỔ CHỨC CHÍNH TRỊ XÃ HỘI");
                //Tiêu đề phụ
                WordApp.Selection.TypeParagraph();
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                WordApp.Selection.TypeText("DANH SÁCH CHI TIẾT CÁC LẦN THAM GIA TỔ CHỨC CHÍNH TRỊ XÃ HỘI");
                for (int i = 0; i < dtQuaTrinhThamGiaTCCTXH.Rows.Count; i++)
                {
                    WordApp.Selection.Font.Bold = 0;
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                    WordApp.Selection.TypeText("\t" + (i + 1) + ". " +
                                                  "Ngày tham gia: " + DateTime.Parse(dtQuaTrinhThamGiaTCCTXH.Rows[i]["NgayThamGia"].ToString()).ToString("dd/MM/yyyy") +
                                               "\n" + "\t\t" +
                                                  "Tên tổ chức: " + dtQuaTrinhThamGiaTCCTXH.Rows[i]["TenToChuc"] +
                                               "\n" + "\t\t" +
                                                  "Công việc: " + dtQuaTrinhThamGiaTCCTXH.Rows[i]["CongViec"]);
                }
                WordApp.Visible = true;
                CloseWaitDialog();
            }
            catch (Exception ex)
            {
                CloseWaitDialog();
                ThongBaoLoi("File word đang được mở. Đề nghị đóng file này trước khi xuất dữ liệu! Thông báo lỗi: " + ex.Message);
                return;
            }
            finally { }
        }

        #endregion

        private void btnInCacQuaTrinh_Click(object sender, EventArgs e)
        {
            CreateWaitDialog("Đang xuất dữ liệu, xin vui lòng chờ.", "Xuất dữ liệu");
            try
            {
                Microsoft.Office.Interop.Word.ApplicationClass WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                Microsoft.Office.Interop.Word.Document aDoc = null;
                clsWord.InitWord(WordApp, ref aDoc, 13);
                #region Quá trình bồi dưỡng.
                if (dtQuaTrinhBoiDuong.Rows.Count > 0)
                {
                    //Tiêu đề chính
                    WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    WordApp.Selection.Font.Bold = 1;
                    WordApp.Selection.TypeText("TỔNG HỢP QUÁ TRÌNH BỒI DƯỠNG");
                    //Tiêu đề phụ
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    WordApp.Selection.TypeText("DANH SÁCH CHI TIẾT CÁC LẦN ĐI BỒI DƯỠNG");
                    for (int i = 0; i < dtQuaTrinhBoiDuong.Rows.Count; i++)
                    {
                        WordApp.Selection.Font.Bold = 0;
                        WordApp.Selection.TypeParagraph();
                        WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                        WordApp.Selection.TypeText("\t" + (i + 1) + "." +
                                                      " Từ ngày: " + DateTime.Parse(dtQuaTrinhBoiDuong.Rows[i]["TuNgay"].ToString()).ToString("dd/MM/yyyy") +
                                                      " đến ngày: " + dtQuaTrinhBoiDuong.Rows[i]["BoiDuongDenNgay"] +
                                                   "\n" + "\t\t" +
                                                      "Nơi bồi dưỡng: " + dtQuaTrinhBoiDuong.Rows[i]["NoiBoiDuong"] +
                                                   "\n" + "\t\t" +
                                                      "Nội dung bồi dưỡng: " + dtQuaTrinhBoiDuong.Rows[i]["NoiDungBoiDuong"] +
                                                   "\n" + "\t\t" +
                                                      "Văn bằng, chứng chỉ: " + dtQuaTrinhBoiDuong.Rows[i]["Ten"] +
                                                   "\n" + "\t\t" +
                                                      "Xếp loại: " + dtQuaTrinhBoiDuong.Rows[i]["TenXepLoaiChungChi"] +
                                                   "\n" + "\t\t" +
                                                      "Hình thức đào tạo: " + dtQuaTrinhBoiDuong.Rows[i]["TenHinhThucDaoTao"]);
                    }
                }
                #endregion

                #region Quá trình bổ nhiệm chức vụ.
                if (dtQuaTrinhBoNhiemChucVu.Rows.Count > 0)
                {
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                    WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    WordApp.Selection.Font.Bold = 1;
                    WordApp.Selection.TypeText("TỔNG HỢP QUÁ TRÌNH BỔ NHIỆM CHỨC VỤ");
                    //Tiêu đề phụ
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    WordApp.Selection.TypeText("DANH SÁCH CHI TIẾT CÁC LẦN ĐƯỢC BỔ NHIỆM CHỨC VỤ");
                    for (int i = 0; i < dtQuaTrinhBoNhiemChucVu.Rows.Count; i++)
                    {
                        WordApp.Selection.Font.Bold = 0;
                        WordApp.Selection.TypeParagraph();
                        WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                        WordApp.Selection.TypeText("\t" + (i + 1) + ". " +
                                                      "Số quyết định: " + dtQuaTrinhBoNhiemChucVu.Rows[i]["SoQuyetDinh"] +
                                                   "\n" + "\t\t" +
                                                      "Ngày ra quyết định: " + DateTime.Parse(dtQuaTrinhBoNhiemChucVu.Rows[i]["NgayRaQuyetDinh"].ToString()).ToString("dd/MM/yyyy") +
                                                   "\n" + "\t\t" +
                                                      "Cấp quyết định: " + dtQuaTrinhBoNhiemChucVu.Rows[i]["TenCapQuyetDinh"] +
                                                   "\n" + "\t\t" +
                                                      "Chức vụ bổ nhiệm: " + dtQuaTrinhBoNhiemChucVu.Rows[i]["TenChucVu"] +
                                                   "\n" + "\t\t" +
                                                      "Hình thức chức vụ: " + dtQuaTrinhBoNhiemChucVu.Rows[i]["TrangThai"] +
                                                   "\n" + "\t\t" +
                                                      "Ngày có hiệu lực: " + DateTime.Parse(dtQuaTrinhBoNhiemChucVu.Rows[i]["NgayCoHieuLuc"].ToString()).ToString("dd/MM/yyyy") +
                                                      "\n" + "\t\t" +
                                                      "Ngày hết hiệu lực: " + ("" + dtQuaTrinhBoNhiemChucVu.Rows[i]["NgayHetHieuLuc1"] == "" ? "" : DateTime.Parse(dtQuaTrinhBoNhiemChucVu.Rows[i]["NgayHetHieuLuc1"].ToString()).ToString("dd/MM/yyyy")));
                    }
                }
                #endregion 

                #region Quá trình công tác.
                if (dtQuaTrinhCongTac.Rows.Count > 0)
                {
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                    WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    WordApp.Selection.Font.Bold = 1;
                    WordApp.Selection.TypeText("TỔNG HỢP QUÁ TRÌNH CÔNG TÁC");
                    //Tiêu đề phụ
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    WordApp.Selection.TypeText("DANH SÁCH CHI TIẾT CÁC LẦN ĐI CÔNG TÁC");
                    for (int i = 0; i < dtQuaTrinhCongTac.Rows.Count; i++)
                    {
                        WordApp.Selection.Font.Bold = 0;
                        WordApp.Selection.TypeParagraph();
                        WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                        WordApp.Selection.TypeText("\t" + (i + 1) + "." +
                                                      " Từ ngày: " + DateTime.Parse(dtQuaTrinhCongTac.Rows[i]["TuNgay"].ToString()).ToString("dd/MM/yyyy") +
                                                      " đến ngày: " + dtQuaTrinhCongTac.Rows[i]["DenNgayCongTac"] +
                                                   "\n" + "\t\t" +
                                                      "Nơi công tác: " + dtQuaTrinhCongTac.Rows[i]["NoiCongTac"] +
                                                   "\n" + "\t\t" +
                                                      "Nội dung công tác: " + dtQuaTrinhCongTac.Rows[i]["NoiDungCongTac"] +
                                                   "\n" + "\t\t" +
                                                      "Chức vụ đảm nhiệm: " + dtQuaTrinhCongTac.Rows[i]["ChucVuDamNhiem"] +
                                                   "\n" + "\t\t" +
                                                      "Mã nước đi công tác: " + dtQuaTrinhCongTac.Rows[i]["MaNuoc"] +
                                                   "\n" + "\t\t" +
                                                      "Tên nước đi công tác: " + dtQuaTrinhCongTac.Rows[i]["TenNuoc"]);
                    }
                }
                #endregion

                #region Quá trình khen thưởng.
                if (dtQuaTrinhKhenThuong.Rows.Count > 0)
                {
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                    WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    WordApp.Selection.Font.Bold = 1;
                    WordApp.Selection.TypeText("TỔNG HỢP QUÁ TRÌNH KHEN THƯỞNG");
                    //Tiêu đề phụ
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    WordApp.Selection.TypeText("DANH SÁCH CHI TIẾT CÁC LẦN ĐƯỢC KHEN THƯỞNG");
                    for (int i = 0; i < dtQuaTrinhKhenThuong.Rows.Count; i++)
                    {
                        WordApp.Selection.Font.Bold = 0;
                        WordApp.Selection.TypeParagraph();
                        WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                        WordApp.Selection.TypeText("\t" + (i + 1) + ". " +
                                                   "Số quyết định: " + dtQuaTrinhKhenThuong.Rows[i]["SoQuyetDinh"] +
                                                   "\n" + "\t\t" +
                                                      "Ngày ra quyết định: " + DateTime.Parse(dtQuaTrinhKhenThuong.Rows[i]["NgayQuyetDinh"].ToString()).ToString("dd/MM/yyyy") +
                                                   "\n" + "\t\t" +
                                                      "Ngày có hiệu lực: " + DateTime.Parse(dtQuaTrinhKhenThuong.Rows[i]["NgayCoHieuLuc"].ToString()).ToString("dd/MM/yyyy") +
                                                   "\n" + "\t\t" +
                                                      "Cấp khen thưởng: " + dtQuaTrinhKhenThuong.Rows[i]["TenCapKhenThuong"] +
                                                   "\n" + "\t\t" +
                                                      "Nội dung: " + dtQuaTrinhKhenThuong.Rows[i]["NoiDung"] +
                                                   "\n" + "\t\t" +
                                                      "Giảm số tháng tăng lương: " + dtQuaTrinhKhenThuong.Rows[i]["GiamSoThangTangLuong"] +
                                                   "\n" + "\t\t" +
                                                      "số tiền thưởng: " + double.Parse("0" + dtQuaTrinhKhenThuong.Rows[i]["SoTien"].ToString()).ToString("#,###"));
                    }
                }
                #endregion

                #region Quá trình kỷ luật.
                if (dtQuaTrinhKyLuat.Rows.Count > 0)
                {
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                    WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    WordApp.Selection.Font.Bold = 1;
                    WordApp.Selection.TypeText("TỔNG HỢP QUÁ TRÌNH KỶ LUẬT");
                    //Tiêu đề phụ
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    WordApp.Selection.TypeText("DANH SÁCH CHI TIẾT CÁC LẦN BỊ KỶ LUẬT");
                    for (int i = 0; i < dtQuaTrinhKyLuat.Rows.Count; i++)
                    {
                        WordApp.Selection.Font.Bold = 0;
                        WordApp.Selection.TypeParagraph();
                        WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                        WordApp.Selection.TypeText("\t" + (i + 1) + ". " +
                                                   "Số quyết định: " + dtQuaTrinhKyLuat.Rows[i]["SoQuyetDinh"] +
                                                   "\n" + "\t\t" +
                                                      "Ngày ra quyết định: " + DateTime.Parse(dtQuaTrinhKyLuat.Rows[i]["NgayQuyetDinh"].ToString()).ToString("dd/MM/yyyy") +
                                                   "\n" + "\t\t" +
                                                      "Ngày có hiệu lực: " + DateTime.Parse(dtQuaTrinhKyLuat.Rows[i]["NgayCoHieuLuc"].ToString()).ToString("dd/MM/yyyy") +
                                                   "\n" + "\t\t" +
                                                      "Ngày hết hiệu lực: " + DateTime.Parse(dtQuaTrinhKyLuat.Rows[i]["NgayHetHieuLuc"].ToString()).ToString("dd/MM/yyyy") +
                                                   "\n" + "\t\t" +
                                                      "Cấp kỷ luật: " + dtQuaTrinhKyLuat.Rows[i]["TenCapKyLuat"] +
                                                   "\n" + "\t\t" +
                                                      "Nội dung: " + dtQuaTrinhKyLuat.Rows[i]["NoiDung"] +
                                                   "\n" + "\t\t" +
                                                      "Tăng số tháng tăng lương: " + dtQuaTrinhKyLuat.Rows[i]["TangSoThangTangLuong"]);

                    }
                }
                #endregion

                #region Quá trình luân chuyển.
                if (dtQuaTrinhLuanChuyen.Rows.Count > 0)
                {
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                    WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    WordApp.Selection.Font.Bold = 1;
                    WordApp.Selection.TypeText("TỔNG HỢP QUÁ TRÌNH LUÂN CHUYỂN");
                    //Tiêu đề phụ
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    WordApp.Selection.TypeText("DANH SÁCH CHI TIẾT CÁC LẦN LUÂN CHUYỂN");
                    for (int i = 0; i < dtQuaTrinhLuanChuyen.Rows.Count; i++)
                    {
                        WordApp.Selection.Font.Bold = 0;
                        WordApp.Selection.TypeParagraph();
                        WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                        WordApp.Selection.TypeText("\t" + (i + 1) + ". " +
                                                      "Số quyết định: " + dtQuaTrinhLuanChuyen.Rows[i]["SoQuyetDinh"] +
                                                   "\n" + "\t\t" +
                                                      "Ngày ra quyết định: " + DateTime.Parse(dtQuaTrinhLuanChuyen.Rows[i]["NgayQuyetDinh"].ToString()).ToString("dd/MM/yyyy") +
                                                   "\n" + "\t\t" +
                                                      "Ngày có hiệu lực: " + DateTime.Parse(dtQuaTrinhLuanChuyen.Rows[i]["NgayCoHieuLuc"].ToString()).ToString("dd/MM/yyyy") +
                                                   "\n" + "\t\t" +
                                                      "Loại luân chuyển: " + dtQuaTrinhLuanChuyen.Rows[i]["TenLoaiLuanChuyen"] +
                                                   "\n" + "\t\t" +
                                                      "Đơn vị cũ: " + dtQuaTrinhLuanChuyen.Rows[i]["TenDonViCu"] +
                                                   "\n" + "\t\t" +
                                                      "Đơn vị mới: " + dtQuaTrinhLuanChuyen.Rows[i]["TenDonViMoi"] +
                                                   "\n" + "\t\t" +
                                                      "Nội dung: " + dtQuaTrinhLuanChuyen.Rows[i]["NoiDung"]);
                    }
                }
                #endregion

                #region Quá trình miễn nhiệm từ chức.
                if (dtQuaTrinhMienNhiemTuChuc.Rows.Count > 0)
                {
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                    WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    WordApp.Selection.Font.Bold = 1;
                    WordApp.Selection.TypeText("TỔNG HỢP QUÁ TRÌNH MIỄN NHIỆM TỪ CHỨC");
                    //Tiêu đề phụ
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    WordApp.Selection.TypeText("DANH SÁCH CHI TIẾT CÁC LẦN MIỄN NHIỆM TỪ CHỨC");
                    for (int i = 0; i < dtQuaTrinhMienNhiemTuChuc.Rows.Count; i++)
                    {
                        WordApp.Selection.Font.Bold = 0;
                        WordApp.Selection.TypeParagraph();
                        WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                        WordApp.Selection.TypeText("\t" + (i + 1) + ". " +
                                                   "Số quyết định: " + dtQuaTrinhMienNhiemTuChuc.Rows[i]["SoQuyetDinh"] +
                                                   "\n" + "\t\t" +
                                                      "Ngày ra quyết định: " + DateTime.Parse(dtQuaTrinhMienNhiemTuChuc.Rows[i]["NgayRaQuyetDinh"].ToString()).ToString("dd/MM/yyyy") +
                                                   "\n" + "\t\t" +
                                                      "Ngày có hiệu lực: " + DateTime.Parse(dtQuaTrinhMienNhiemTuChuc.Rows[i]["NgayCoHieuLuc"].ToString()).ToString("dd/MM/yyyy") +
                                                   "\n" + "\t\t" +
                                                      "Cấp quyết định: " + dtQuaTrinhMienNhiemTuChuc.Rows[i]["TenCapQuyetDinh"] +
                                                   "\n" + "\t\t" +
                                                      "Chức vụ miễn nhiệm: " + dtQuaTrinhMienNhiemTuChuc.Rows[i]["TenChucVuMienNhiem"]);
                    }
                }
                #endregion

                #region Quá trình tham gia LLVT.
                if (dtQuaTrinhThamGiaLLVT.Rows.Count > 0)
                {
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                    WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    WordApp.Selection.Font.Bold = 1;
                    WordApp.Selection.TypeText("TỔNG HỢP QUÁ TRÌNH THAM GIA LỰC LƯỢNG VŨ TRANG");
                    //Tiêu đề phụ
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    WordApp.Selection.TypeText("DANH SÁCH CHI TIẾT CÁC LẦN THAM GIA LỰC LƯỢNG VŨ TRANG");
                    for (int i = 0; i < dtQuaTrinhThamGiaLLVT.Rows.Count; i++)
                    {
                        WordApp.Selection.Font.Bold = 0;
                        WordApp.Selection.TypeParagraph();
                        WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                        WordApp.Selection.TypeText("\t" + (i + 1) + ". " +
                                                      "Ngày nhập ngũ: " + DateTime.Parse(dtQuaTrinhThamGiaLLVT.Rows[i]["NgayNhapNgu"].ToString()).ToString("dd/MM/yyyy") +
                                                      " ngày xuất ngũ: " + dtQuaTrinhThamGiaLLVT.Rows[i]["DenNgayXuatNgu"] +
                                                   "\n" + "\t\t" +
                                                      "Quân hàm: " + dtQuaTrinhThamGiaLLVT.Rows[i]["TenQuanHam"] +
                                                   "\n" + "\t\t" +
                                                      "Đơn vị: " + dtQuaTrinhThamGiaLLVT.Rows[i]["DonVi"] +
                                                   "\n" + "\t\t" +
                                                      "Chức vụ: " + dtQuaTrinhThamGiaLLVT.Rows[i]["ChucVu"]);
                    }
                }
                #endregion

                #region Quá trình tham gia TCCTXH.
                if (dtQuaTrinhThamGiaTCCTXH.Rows.Count > 0)
                {
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                    WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    WordApp.Selection.Font.Bold = 1;
                    WordApp.Selection.TypeText("TỔNG HỢP QUÁ TRÌNH THAM GIA TỔ CHỨC CHÍNH TRỊ XÃ HỘI");
                    //Tiêu đề phụ
                    WordApp.Selection.TypeParagraph();
                    WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    WordApp.Selection.TypeText("DANH SÁCH CHI TIẾT CÁC LẦN THAM GIA TỔ CHỨC CHÍNH TRỊ XÃ HỘI");
                    for (int i = 0; i < dtQuaTrinhThamGiaTCCTXH.Rows.Count; i++)
                    {
                        WordApp.Selection.Font.Bold = 0;
                        WordApp.Selection.TypeParagraph();
                        WordApp.Selection.ParagraphFormat.SpaceBefore = (float)5;
                        WordApp.Selection.TypeText("\t" + (i + 1) + ". " +
                                                      "Ngày tham gia: " + DateTime.Parse(dtQuaTrinhThamGiaTCCTXH.Rows[i]["NgayThamGia"].ToString()).ToString("dd/MM/yyyy") +
                                                   "\n" + "\t\t" +
                                                      "Tên tổ chức: " + dtQuaTrinhThamGiaTCCTXH.Rows[i]["TenToChuc"] +
                                                   "\n" + "\t\t" +
                                                      "Công việc: " + dtQuaTrinhThamGiaTCCTXH.Rows[i]["CongViec"]);
                    }
                }
                #endregion
                
                WordApp.Visible = true;
                CloseWaitDialog();
            }
            catch (Exception ex)
            {
                CloseWaitDialog();
                ThongBaoLoi("File word đang được mở. Đề nghị đóng file này trước khi xuất dữ liệu! Thông báo lỗi: " + ex.Message);
                return;
            }
            finally { }
        }
    }
}