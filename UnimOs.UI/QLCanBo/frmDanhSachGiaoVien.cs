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
using System.Reflection;

namespace UnimOs.UI
{
    public partial class frmDanhSachGiaoVien : frmBase
    {
        private cBNS_DonVi oBDonVi;
        private NS_DonViInfo pDonViInfo;
        private cBNS_GiaoVien oBGiaoVien;
        public NS_GiaoVienInfo pGiaoVienInfo;
        private XL_GiaoVien_MonHocInfo pXL_GV_MHInfo;
        private cBXL_GiaoVien_MonHoc oBXL_GV_MH;
        private DataTable dtTree, dtGiaoVien, dtMonDay, dtSoYeuLyLich;
        DataRow drGiaoVien;
        private bool Loaded = false;
        private int idxGV;
        Lib.clsExportToWord clsWord = new Lib.clsExportToWord();

        public frmDanhSachGiaoVien()
        {
            InitializeComponent();
            oBGiaoVien = new cBNS_GiaoVien();
            pGiaoVienInfo = new NS_GiaoVienInfo();
            pDonViInfo = new NS_DonViInfo();
            oBXL_GV_MH = new cBXL_GiaoVien_MonHoc();
            pXL_GV_MHInfo = new XL_GiaoVien_MonHocInfo();
            repositoryItemLookUpEditGioiTinh.DataSource = LoadGioiTinh();
        }

        private void frmDanhSachGiaoVien_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            Loaded = true;
            trvDonVi_FocusedNodeChanged(null, null);
        }

        public void LoadGiaoVien(int IDDonVi)
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

        public void EditGiaoVien(EDIT_MODE edit)
        {
            DataRow drNew;
            if (edit == EDIT_MODE.SUA)
            {
                int idxNew = idxGV;
                drNew = dtGiaoVien.NewRow();
                oBGiaoVien.ToDataRow(pGiaoVienInfo, ref drNew);
                DataRow dr = grvGiaoVien.GetDataRow(idxGV);
                dtGiaoVien.Rows.InsertAt(drNew, idxNew + 1);
                dtGiaoVien.Rows.Remove(dr);
                grvGiaoVien.FocusedRowHandle = idxNew;
            }
            else
            {
                drNew = dtGiaoVien.NewRow();
                oBGiaoVien.ToDataRow(pGiaoVienInfo, ref drNew);
                dtGiaoVien.Rows.Add(drNew);
            }
        }

        private void trvDonVi_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
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

        private void trvDonVi_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && trvDonVi.ClientRectangle.Contains(e.X, e.Y))
            {
                popupMenuTree.ShowPopup(MousePosition);
            }
        }
        private void SetButton(bool mbool)
        {
            btnThemMon.Enabled = mbool;
            btnXoaMon.Enabled = mbool;
        }
        private void grvGiaoVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvGiaoVien.DataRowCount > 0)
            {
                SetButton(true);
                idxGV = grvGiaoVien.FocusedRowHandle;
                DataRow dr = grvGiaoVien.GetDataRow(idxGV);
                oBGiaoVien.ToInfo(ref pGiaoVienInfo, dr);
                LoadGiaoVien_MonHoc(int.Parse(grvGiaoVien.GetDataRow(idxGV)[pGiaoVienInfo.strNS_GiaoVienID].ToString()));
                drGiaoVien = grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle);
            }
            else
            {
                grdMonDay.DataSource = null;
                SetButton(false);
            }
        }
        private void LoadGiaoVien_MonHoc(int mIDNS_GiaoVien)
        {
            pXL_GV_MHInfo.IDNS_GiaoVien = mIDNS_GiaoVien;
            dtMonDay = oBXL_GV_MH.GetDanhSach(pXL_GV_MHInfo);
            grdMonDay.DataSource = dtMonDay;
        }

        private void grdGiaoVien_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && grdGiaoVien.ClientRectangle.Contains(e.X, e.Y))
            {
                popupMenuGV.ShowPopup(MousePosition);
            }
        }

        #region Xử lý chuột phải
        private void barbtnThemParent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgDonVi frm = new dlgDonVi(dtTree, pDonViInfo, trvDonVi.FocusedNode == null ? 0 : int.Parse(trvDonVi.FocusedNode["ParentIDs"].ToString()), EDIT_MODE.THEM, true);
            frm.ShowDialog();
            //if ((int)frm.Tag == 1)
            //    LoadTreeView();
        }

        private void barbtnchildren_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (trvDonVi.FocusedNode == null)
            {
                ThongBao("Bạn chưa chọn đơn vị nào.");
                return;
            }
            dlgDonVi frm = new dlgDonVi(dtTree, pDonViInfo, int.Parse(trvDonVi.FocusedNode["ID"].ToString()), EDIT_MODE.THEM, false);
            frm.ShowDialog();
            //if ((int)frm.Tag == 1)
            //    LoadTreeView();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (trvDonVi.FocusedNode == null)
            {
                ThongBao("Bạn chưa chọn đơn vị nào.");
                return;
            }
            dlgDonVi frm = new dlgDonVi(dtTree, pDonViInfo, 0, EDIT_MODE.SUA, false);
            frm.ShowDialog();
            if ((int)frm.Tag == 1)
                LoadTreeView();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn muốn xóa?") == DialogResult.Yes)
            {
                if (trvDonVi.FocusedNode == null)
                {
                    ThongBao("Bạn chưa chọn đơn vị nào.");
                    return;
                }
                else
                {
                    try
                    {
                        if (trvDonVi.FocusedNode.Nodes.Count > 0)
                        {
                            ThongBao("Bạn chưa xóa hết đơn vị trực thuộc!");
                        }
                        else
                        {
                            if (grvGiaoVien.RowCount > 0)
                            {
                                //if (ThongBaoChon("Bạn có chắc chắn xóa hết giáo viên ra khỏi đơn vị?") == DialogResult.Yes)
                                //{
                                //    pDonViInfo.NS_DonViID = int.Parse(trvDonVi.FocusedNode["NS_DonViID"].ToString());
                                //    oBDonVi.Delete(pDonViInfo);
                                //    LoadTreeView();
                                //}
                                XoaThatBai();
                            }
                            else
                            {
                                pDonViInfo.NS_DonViID = int.Parse(trvDonVi.FocusedNode["NS_DonViID"].ToString());
                                oBDonVi.Delete(pDonViInfo);
                                // Ghi Log
                                GhiLog("Xóa đơn vị  '" + pDonViInfo.TenDonVi + "'", "Xóa", this.Tag.ToString());
                                LoadTreeView();
                            }
                        }
                        // XoaThanhCong();
                    }
                    catch
                    {
                        XoaThatBai();
                    }
                }
            }
        }

        private void barbtnThemGiaoVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgThemSuaGiaoVien frm = new dlgThemSuaGiaoVien(this, pDonViInfo.NS_DonViID, EDIT_MODE.THEM);
            frm.ShowDialog();
        }

        private void barbtnSuaGiaoVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvGiaoVien.FocusedRowHandle >= 0)
            {
                frmHoSoGiaoVien dlg = new frmHoSoGiaoVien(dtGiaoVien, ref drGiaoVien, this);
                dlg.ShowDialog();
            }
        }

        private void barbtnChuyenDonVi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgChonDonVi dlg = new dlgChonDonVi();
            dlg.IDNS_DonVi = pDonViInfo.NS_DonViID;
            if (dlg.ShowDialog() == DialogResult.Yes)
            {
                try
                {
                    oBGiaoVien.UpdateDonVi(pGiaoVienInfo.NS_GiaoVienID, dlg.IDNS_DonVi);
                    ThongBao("Đã chuyển thành công !");
                }
                catch(Exception ex)
                {
                    ThongBaoLoi("Lỗi khi chuyển.\n" + ex.Message);
                }
                trvDonVi_FocusedNodeChanged(null, null);
            }
        }

        private void barbtnXoaGiaoVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {

                try
                {
                    pGiaoVienInfo.NS_GiaoVienID = int.Parse(grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle)["NS_GiaoVienID"].ToString());
                    oBGiaoVien.Delete(pGiaoVienInfo);
                    // Ghi Log
                    GhiLog("Xóa giáo viên  '" + pGiaoVienInfo.HoTen + "'", "Xóa", this.Tag.ToString());
                    dtGiaoVien.Rows.Remove(grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle));
                    XoaThanhCong();
                }
                catch
                {
                    XoaThatBai();
                }

            }
        }
        private void barTimKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgTimKiemGiaoVien frm = new dlgTimKiemGiaoVien(pDonViInfo.NS_DonViID);
            frm.ShowDialog();
            if (frm.Tag.ToString() == "1")
                trvDonVi_FocusedNodeChanged(null, null);
        }
        #endregion

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (grvGiaoVien.FocusedRowHandle >= 0)
            {
                dlgChonMonHoc frm = new dlgChonMonHoc(int.Parse(grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle)[pGiaoVienInfo.strNS_GiaoVienID].ToString()), grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle)[pGiaoVienInfo.strHoTen].ToString());
                frm.ShowDialog();
                if (frm.Tag.ToString() == "1")
                    grvGiaoVien_FocusedRowChanged(null, null);
            }
            else
                ThongBao("Bạn chưa chọn giáo viên nào!");
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn muốn xóa!") == DialogResult.Yes)
            {
                bool Chon = false;
                string TenMonHocs = "";
                try
                {
                    for (int i = 0; i < dtMonDay.Rows.Count; i++)
                    {
                        if (bool.Parse(dtMonDay.Rows[i]["Chon"].ToString()) == true)
                        {
                            Chon = true;
                            pXL_GV_MHInfo.XL_GiaoVien_MonHocID = int.Parse(dtMonDay.Rows[i]["XL_GiaoVien_MonHocID"].ToString());
                            oBXL_GV_MH.Delete(pXL_GV_MHInfo);
                            TenMonHocs += dtMonDay.Rows[i]["TenMonHoc"].ToString() + ",";
                        }
                    }
                    if (Chon == false)
                        ThongBao("Bạn chưa chọn môn nào.");
                    else
                    {
                        // Ghi Log
                        GhiLog("Xóa các môn học '" + TenMonHocs + "' đã phân công cho giáo viên '" + grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle)["HoTen"].ToString() + "'", "Xóa", this.Tag.ToString());
                        grvGiaoVien_FocusedRowChanged(null, null);
                        XoaThanhCong();
                    }
                }
                catch (Exception ex)
                {
                    ThongBao(ex.Message);
                }
            }
        }

        private void grvGiaoVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnLyLich_Click(object sender, EventArgs e)
        {
            if (grvGiaoVien.FocusedRowHandle >= 0)
            {
                frmHoSoGiaoVien frm = new frmHoSoGiaoVien(dtGiaoVien, ref drGiaoVien, this);
                frm.ShowDialog();
            }
        }

        #region In sơ yếu lý lịch
        private void barbtnInSoYeuLyLich_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvGiaoVien.DataRowCount > 0)
            {
                int NS_GiaoVienID = int.Parse(grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle)["NS_GiaoVienID"].ToString());
                    dtSoYeuLyLich = oBGiaoVien.Get_SoYeuLyLich(NS_GiaoVienID);
                    if (dtSoYeuLyLich.Rows.Count > 0)
                    {
                        CreateWaitDialog("Đang xuất dữ liệu, xin vui lòng chờ.", "Xuất dữ liệu");
                        try
                        {
                            // Khoi tao ban word.
                            Microsoft.Office.Interop.Word.ApplicationClass WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                            Microsoft.Office.Interop.Word.Document aDoc = null;
                            clsWord.InitWord(WordApp, ref aDoc, 11);
                            // Insert du lieu vao ban word.
                            // Tieu de trang
                            clsWord.AddText(aDoc, "Mẫu 2a-BNV/2007", 0, 1, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter);
                            clsWord.AddText(aDoc, "(ban hành kèm theo Quyết định số 06/2007/QĐ-BNV ngày 18/6/2007 của Bộ trưởng Bộ Nội vụ)", 0, 1, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter);
                            clsWord.AddText(aDoc, "Cơ quan, đơn vị có thẩm quyền quản lý CBCC: " + Program.TenTruong + ", Số hiệu cán bộ, công chức: " + dtSoYeuLyLich.Rows[0]["MaGiaoVien"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "Cơ quan, đơn vị sử dụng CBCC: " + Program.TenTruong, 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "SƠ YẾU LÝ LỊCH CÁN BỘ, CÔNG CHỨC", 1, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter);
                            // Noi dung trang
                            clsWord.AddText(aDoc, "\t\t\t1. Họ và tên khai sinh (viết chữ in hoa): " + dtSoYeuLyLich.Rows[0]["HoTen"].ToString().ToUpper(), 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "\t\t\t2. Tên gọi khác : " + dtSoYeuLyLich.Rows[0]["Ten"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "\t\t\t3. Sinh ngày: " + ("" + dtSoYeuLyLich.Rows[0]["NgaySinh"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgaySinh"].ToString()).Day.ToString()) +
                                                               " Tháng " + ("" + dtSoYeuLyLich.Rows[0]["NgaySinh"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgaySinh"].ToString()).Month.ToString()) +
                                                               " năm " + ("" + dtSoYeuLyLich.Rows[0]["NgaySinh"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgaySinh"].ToString()).Year.ToString()) +
                                                               ", Giới tính(nam, nữ): " + dtSoYeuLyLich.Rows[0]["TenGioiTinh"]
                                                , 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "\t\t\t4. Nơi sinh: " + dtSoYeuLyLich.Rows[0]["DiaChiNoiO"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "\t\t\t5. Quê quán: ", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "6. Dân tộc: " + dtSoYeuLyLich.Rows[0]["TenDanToc"] + "\t\t" + "7. Tôn giáo: " + dtSoYeuLyLich.Rows[0]["TenTonGiao"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "8. Nơi đăng ký hộ khẩu thường trú: " + dtSoYeuLyLich.Rows[0]["DiaChiThuongTru"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "(Số nhà, đường phố, thành phố; xóm, thôn, xã, huyện, tỉnh)", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "9. Nơi ở hiện nay: ", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "(Số nhà, đường phố, thành phố; xóm, thôn, xã, huyện, tỉnh)", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "10. Nghề nghiệp khi được tuyển dụng: " + dtSoYeuLyLich.Rows[0]["NgheNghiepTuyenDung"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "11. Ngày tuyển dụng: " + ("" + dtSoYeuLyLich.Rows[0]["NgayTuyenDung"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgayTuyenDung"].ToString()).ToString("dd/MM/yyyy")) +
                                                  ", Cơ quan tuyển dụng: " + Program.TenTruong, 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "12. Chức vụ (chức danh) hiện tại: " + dtSoYeuLyLich.Rows[0]["TenChucDanh"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "(Về chính quyền hoặc Đảng, đoàn thể, kể cả chức vụ kiêm nhiệm)" + dtSoYeuLyLich.Rows[0]["NgheNghiepTuyenDung"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "13. Công việc chính được giao: ", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "14. Ngạch công chức (viên chức): " + dtSoYeuLyLich.Rows[0]["TenNgachCongChuc"] + ", Mã ngạch: " + dtSoYeuLyLich.Rows[0]["MaNgachCongChuc"]
                                                , 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "Bậc lương: " + dtSoYeuLyLich.Rows[0]["BacLuong"] + ", Hệ số: " + dtSoYeuLyLich.Rows[0]["HeSoLuong"] +
                                                  ", Ngày hưởng: " + ("" + dtSoYeuLyLich.Rows[0]["TuNgay"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["TuNgay"].ToString()).ToString("dd/MM/yyyy")) +
                                                  ", Phụ cấp chức vụ: " + dtSoYeuLyLich.Rows[0]["PhuCapChucVu"] + ", Phụ cấp khác: " + dtSoYeuLyLich.Rows[0]["PhuCapKhac"]
                                                , 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "15.1. Trình độ giáo dục phổ thông (đã tốt nghiệp lớp mấy/ thuộc hệ nào): " + dtSoYeuLyLich.Rows[0]["TrinhDoPhoThong"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "15.2. Trình độ chuyên môn cao nhất: " + dtSoYeuLyLich.Rows[0]["TenTrinhDoChuyenMon"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "(TSKH, TS, Ths, cử nhân, kỹ sư, cao đẳng, trung cấp, sơ cấp; chuyên ngành)", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "15.3. Lý luận chính trị: " + dtSoYeuLyLich.Rows[0]["TenTrinhDoLyLuan"] + "\t\t" + "15.4. Quản lý nhà nước: " + dtSoYeuLyLich.Rows[0]["TenTrinhDoQuanLyHanhChinhNhaNuoc"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "(Tên ngoại ngữ + Trình độ A, B, C, D,…)" + "\t\t" + "(Trình độ A, B, C,…)", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "16. Ngày vào Đảng cộng sản Việt Nam: " + ("" + dtSoYeuLyLich.Rows[0]["NgayVaoDang"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgayVaoDang"].ToString()).ToString("dd/MM/yyyy")) +
                                                  ", Ngày chính thức: " + ("" + dtSoYeuLyLich.Rows[0]["NgayVaoDangChinhThuc"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgayVaoDangChinhThuc"].ToString()).ToString("dd/MM/yyyy")), 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "17. Ngày tham gia tổ chức chính trị - xã hội: " + ("" + dtSoYeuLyLich.Rows[0]["NgayThamGia"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgayThamGia"].ToString()).ToString("dd/MM/yyyy")) +
                                                  ", Tên tổ chức: " + dtSoYeuLyLich.Rows[0]["TenToChuc"] + ", Công việc: " + dtSoYeuLyLich.Rows[0]["CongViec"]
                                                , 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "(Ngày tham gia tổ chức: Đoàn, Hội,…. Và làm việc gì trong tổ chức đó)", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "18. Ngày nhập ngũ: " + ("" + dtSoYeuLyLich.Rows[0]["NgayNhapNgu"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgayNhapNgu"].ToString()).ToString("dd/MM/yyyy")) +
                                                  ", Ngày xuất ngũ: " + ("" + dtSoYeuLyLich.Rows[0]["NgayXuatNgu"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgayXuatNgu"].ToString()).ToString("dd/MM/yyyy")) +
                                                  ", Quân hàm cao nhất: " + dtSoYeuLyLich.Rows[0]["TenQuanHam"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "19. Danh hiệu được phong tặng cao nhất: " + dtSoYeuLyLich.Rows[0]["TenDanhHieuDuocPhongTang"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "(Anh hùng lao động, anh hùng lực lượng vũ trang; nhà giáo, thầy thuốc, nghệ sĩ nhân dân, ưu tú,…)", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "20. Sở trường công tác: " + dtSoYeuLyLich.Rows[0]["SoTruongCongTac"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "21. Khen thưởng: " + dtSoYeuLyLich.Rows[0]["NoiDungKhenThuong"] + ", Năm: " + ("" + dtSoYeuLyLich.Rows[0]["NgayKhenThuong"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgayKhenThuong"].ToString()).Year.ToString()) + "\t\t" +
                                                  "22. Kỷ luật: " + dtSoYeuLyLich.Rows[0]["NoiDungKyLuat"] + ", Năm: " + ("" + dtSoYeuLyLich.Rows[0]["NgayKyLuat"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgayKyLuat"].ToString()).Year.ToString()), 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "(Hình thức cao nhất, năm nào)" + "\t" + "(Về đảng, chính quyền, đoàn thể hình thức cao nhất, năm nào)", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "23. Tình trạng sức khỏe: " + dtSoYeuLyLich.Rows[0]["TinhTrangSucKhoe"] + ", Chiều cao: " + dtSoYeuLyLich.Rows[0]["ChieuCao"] + ", Cân nặng: " + dtSoYeuLyLich.Rows[0]["CanNang"] + " kg" + ", Nhóm máu: " + dtSoYeuLyLich.Rows[0]["NhomMau"]
                                                , 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "24. Là thương binh hạng: " + "\t/\t" + ", Là con gia đình chính sách():", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "(Con thương binh, con liệt sĩ, người nhiễm chất độc da cam Dioxin)", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "25. Số chứng minh nhân dân: " + dtSoYeuLyLich.Rows[0]["SoCMND"] +
                                                  ", Ngày cấp: " + ("" + dtSoYeuLyLich.Rows[0]["NgayCap"] == "" ? "" : DateTime.Parse(dtSoYeuLyLich.Rows[0]["NgayCap"].ToString()).ToString("dd/MM/yyyy"))
                                                , 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "26. Số sổ BHXH: " + dtSoYeuLyLich.Rows[0]["SoSoBaoHiemXaHoi"], 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            // Insert qua trinh boi duong vao bang                    
                            clsWord.AddText(aDoc, "27. Đào tạo, bồi dưỡng về chuyên môn, nghiệp vụ, lý luận chính trị, ngoại ngữ, tin học", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            DataTable dtBoiDuong = oBGiaoVien.Get_QuaTrinhBoiDuong(NS_GiaoVienID);
                            clsWord.AddTable(aDoc, dtBoiDuong, new string[] { "Tên trường", "Chuyên ngành đào tạo", "Từ ngày", "Đến ngày", "Hình thức đào tạo", "Văn bằng chứng chỉ" },
                                                               new string[] { "NoiBoiDuong", "Ten", "TuNgay", "DenNgay", "TenHinhThucDaoTao", "TenXepLoaiChungChi" });
                            clsWord.AddText(aDoc, "Ghi chú: Hình thức đào tạo: chính quy, tại chức, chuyên tu, bồi dưỡng…………./ Văn bằng: TSKH, TS, Ths, Cử nhân, Kỹ sư, ", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            // Insert qua trinh cong tac vao bang                    
                            clsWord.AddText(aDoc, "28. Tóm tắt quá trình công tác", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            DataTable dtCongTac = oBGiaoVien.Get_QuaTrinhCongTac(NS_GiaoVienID);
                            clsWord.AddTable(aDoc, dtCongTac, new string[] { "Từ ngày", "Đến ngày", "Nội dung công tác", "Chức vụ đảm nhiệm", "Nơi công tác", "Tên nước" },
                                                               new string[] { "TuNgay", "DenNgay", "NoiDungCongTac", "ChucVuDamNhiem", "NoiCongTac", "TenNuoc" });
                            // Lịch sử bản thân
                            clsWord.AddText(aDoc, "29. Đặc điểm lịch sử bản thân", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "- Khai rõ: bị bắt, bị tù (từ ngày tháng năm nào đến ngày tháng năm nào, ở đâu), đã khai báo cho ai, những vấn đề gì? Bản thân có làm việc trong chế độ cũ (cơ quan, đơn vị nào, địa điểm, chức danh, chức vụ, thời gian làm việc…):", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "- Thời gian hoặc có quan hệ với các tổ chức chính trị, kinh tế, xã hội nào ở nước ngoài (làm gì, tổ chức nào, đặt trụ sở ở đâu…?):", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "- Có thân nhân (Cha, Mẹ, Vợ, chồng, con, anh chị em ruột) ở nước ngoài (làm gì, địa chỉ…):", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            // Quan hệ gia đình
                            cBNS_GiaoVien_QuanHeGiaDinh oBNS_GiaVien_QuanHeGiaDinh = new cBNS_GiaoVien_QuanHeGiaDinh();
                            DataTable dtGiaDinh = oBNS_GiaVien_QuanHeGiaDinh.GetBy_IDNS_GiaoVien(NS_GiaoVienID);
                            clsWord.AddTable(aDoc, dtGiaDinh, new string[] { "Mỗi quan hệ", "Họ và tên", "Năm sinh", "Địa chỉ", "Nghề nghiệp", "Thông tin khác" },
                                                               new string[] { "TenMoiQuanHe", "HoVaTen", "NamSinh", "DiaChiQueQuan", "NgheNghiep", "ThongTinKhac" });
                            // Tieu de cuoi
                            clsWord.AddText(aDoc, "30. Nhận xét, đánh giá của cơ quan, đơn vị quản lý và sử dụng cán bộ công chức", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "\t\t\tNgười khai" + "\t\t\t" + "……., Ngày…… tháng…… năm 20….", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "Tôi xin cam đoan những lời khai trên đây là đúng sự thật" + "\t" + "Thủ trưởng cơ quan, đơn vị quản lý và sử dụng CBCC", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            clsWord.AddText(aDoc, "\t\t(Ký tên, ghi rõ họ tên)" + "\t\t\t\t" + "(Ký tên, đóng dấu)", 0, 0, Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft);
                            WordApp.Visible = true;
                            CloseWaitDialog();
                            //ThongBao("Xuất dữ liệu ra word thành công.");
                        }
                        catch(Exception ex)
                        {
                            CloseWaitDialog();
                            ThongBaoLoi("Đang xuất dữ liệu, lỗi khi tắt chức năng này. " + ex.Message);
                        }
                    }
            }
        }
        #endregion

        private void barbtnHopDongLaoDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgHopDongLaoDong dlg = new dlgHopDongLaoDong(int.Parse(grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle)["NS_GiaoVienID"].ToString()));
            dlg.ShowDialog();
        }

        private void barbtnQuyetDinhNghiViec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgGiaoVienNghiViec dlg = new dlgGiaoVienNghiViec(int.Parse(grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle)["NS_GiaoVienID"].ToString()));
            dlg.ShowDialog();
        }
    }
}