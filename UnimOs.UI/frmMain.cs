using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.Gallery;
using DevExpress.Utils.Drawing;
using DevExpress.Utils;
using DevExpress.Tutorials.Controls;
using DevExpress.XtraBars;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;

namespace UnimOs.UI
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Biến toàn cục
        private DevExpress.Utils.WaitDialogForm dlg = null;
        private cBHT_User oBHT_User;

        #endregion

        #region Khởi tạo
        public frmMain()
        {
            InitializeComponent();
            this.ribbonMain.SelectedPage = this.ribbonPageQTHeThong;
            InitSkinGallery();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            //This set the style to use skin technology
            DevExpress.LookAndFeel.UserLookAndFeel.Default.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            //Here we specify the skin to use by its name           
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2007 Blue");
            oBHT_User = new cBHT_User();
        }
        #endregion

        #region SkinGallery
        void InitSkinGallery()
        {
            SimpleButton imageButton = new SimpleButton();
            foreach (SkinContainer cnt in SkinManager.Default.Skins)
            {
                imageButton.LookAndFeel.SetSkinStyle(cnt.SkinName);
                GalleryItem gItem = new GalleryItem();
                int groupIndex = 0;
                if (cnt.SkinName.IndexOf("Office") > -1) 
                    groupIndex = 1;
                rgbiSkins.Gallery.Groups[groupIndex].Items.Add(gItem);
                gItem.Caption = cnt.SkinName;
                gItem.Image = GetSkinImage(imageButton, 32, 17, 2);
                gItem.HoverImage = GetSkinImage(imageButton, 70, 36, 5);
                gItem.Caption = cnt.SkinName;
                gItem.Hint = cnt.SkinName;
                rgbiSkins.Gallery.Groups[1].Visible = true;
            }
        }
        Bitmap GetSkinImage(SimpleButton button, int width, int height, int indent)
        {
            Bitmap image = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(image))
            {
                StyleObjectInfoArgs info = new StyleObjectInfoArgs(new GraphicsCache(g));
                info.Bounds = new Rectangle(0, 0, width, height);
                button.LookAndFeel.Painter.GroupPanel.DrawObject(info);
                button.LookAndFeel.Painter.Border.DrawObject(info);
                info.Bounds = new Rectangle(indent, indent, width - indent * 2, height - indent * 2);
                button.LookAndFeel.Painter.Button.DrawObject(info);
            }
            return image;
        }
        private void rgbiSkins_Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(e.Item.Caption);
        }

        private void rgbiSkins_Gallery_InitDropDownGallery(object sender, DevExpress.XtraBars.Ribbon.InplaceGalleryEventArgs e)
        {
            e.PopupGallery.CreateFrom(rgbiSkins.Gallery);
            e.PopupGallery.AllowFilter = false;
            e.PopupGallery.ShowItemText = true;
            e.PopupGallery.ShowGroupCaption = true;
            e.PopupGallery.AllowHoverImages = false;
            foreach (GalleryItemGroup galleryGroup in e.PopupGallery.Groups)
                foreach (GalleryItem item in galleryGroup.Items)
                    item.Image = item.HoverImage;
            e.PopupGallery.ColumnCount = 2;
            e.PopupGallery.ImageSize = new Size(70, 36);
        }
        #endregion

        #region Phương thức
        public void CreateMDIForm(System.Windows.Forms.Form frm)
        {
            CreateWaitDialog();
            frm.MdiParent = this;
            frm.Show();
            this.xtraTabbedMdiManager.SelectedPage.Image = imageCollection2.Images[0];
            CloseWaitDialog();
        }

        public bool CheckFormExist(string tag)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Tag.ToString() == tag)
                {
                    try
                    {
                        frm.Select();
                    }
                    catch
                    {
                    }
                    return true;
                }
            }
            return false;
        }

        private void PageBringToFront(string PageName)
        {
            switch (PageName)
            { 
                case "ribbonPageDanhMuc":
                    this.ribbonMain.SelectedPage = this.ribbonPageDanhMuc;
                    break;
                case "ribbonPageQLSinhVien":
                    this.ribbonMain.SelectedPage = this.ribbonPageQLSinhVien;
                    break;
                case "ribbonPageQLCanBo":
                    this.ribbonMain.SelectedPage = this.ribbonPageQLCanBo;
                    break;
                case "ribbonPageQLDiem":
                    this.ribbonMain.SelectedPage = this.ribbonPageQLDiem;
                    break;
                case "ribbonPageXetTotNgiep":
                    this.ribbonMain.SelectedPage = this.ribbonPageXetTotNgiep;
                    break;
                case "ribbonPageTKB":
                    this.ribbonMain.SelectedPage = this.ribbonPageTKB;
                    break;
                case "ribbonPageQLGioGiang":
                    this.ribbonMain.SelectedPage = this.ribbonPageQLGioGiang;
                    break;
                case "ribbonPageQLTaiChinh":
                    this.ribbonMain.SelectedPage = this.ribbonPageQLTaiChinh;
                    break;
                case "ribbonPageQTHeThong":
                    this.ribbonMain.SelectedPage = this.ribbonPageQTHeThong;
                    break;
            }
        }

        private void LoadMenu(DataTable dtChucNang)
        {
            RibbonPage rPage;
            DataRow[] arrDrPage;
            arrDrPage = dtChucNang.Select("KieuRibbon = 'RPage'");
            foreach (DataRow dr in arrDrPage)
            {
                rPage = GetPageByName(dr["barbtnName"].ToString());
                if (rPage != null)
                {
                    rPage.Visible = true;
                    VisiblePageGroup(dtChucNang, dr["HT_ChucNangID"].ToString(), rPage);
                }
            }
        }

        private RibbonPage GetPageByName(string Name)
        {
            foreach (RibbonPage rp in this.ribbonMain.Pages)
            {
                if (rp.Name == Name)
                    return rp;
            }
            return null;
        }

        private void VisiblePageGroup(DataTable dtChucNang, string HT_ChucNangID, RibbonPage rGroup)
        {
            RibbonPageGroup rpGroup;
            DataRow[] arrDr = dtChucNang.Select("ParentID = " + HT_ChucNangID);
            foreach (DataRow dr in arrDr)
            {
                rpGroup = rGroup.Groups[dr["barbtnName"].ToString()];
                if (rpGroup != null)
                {
                    rpGroup.Visible = true;
                    VisibleBarItem(dtChucNang, dr["HT_ChucNangID"].ToString(), rpGroup);
                }
            }
        }

        private void VisibleBarItem(DataTable dtChucNang, string HT_ChucNangID, RibbonPageGroup rpGroup)
        {
            DataRow[] arrDr = dtChucNang.Select("ParentID = " + HT_ChucNangID);
            foreach (DataRow dr in arrDr)
            {
                for (int i = 0; i < rpGroup.ItemLinks.Count; i++)
                {
                    if (rpGroup.ItemLinks[i].Item.Name == dr["barbtnName"].ToString())
                    {
                        rpGroup.ItemLinks[i].Item.Visibility = BarItemVisibility.Always;
                    }
                }
            }
        }
        #endregion

        #region Wait Form
        public void CreateWaitDialog()
        {
            dlg = new DevExpress.Utils.WaitDialogForm("Đang tải dữ liệu, xin vui lòng chờ!", "Tải dữ liệu");
        }
        public void SetWaitDialogCaption(string fCaption)
        {
            if ((dlg != null)) dlg.Caption = fCaption;
        }
        public void CloseWaitDialog()
        {
            if ((dlg != null)) dlg.Close();
        }
        #endregion

        #region Sự kiện trên form
        private void frmMain_Load(object sender, System.EventArgs e)
        {
            //Code cho form phủ kín màn hình kể cả task bar
            //FormBorderStyle = FormBorderStyle.FixedSingle;
            //Rectangle formrect = Screen.GetBounds(this);
            //Location = formrect.Location;
            //Size = formrect.Size;

            //
            frmChonNamHoc frm = new frmChonNamHoc();
            frmLogIn frmLogin = new frmLogIn();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                frm.ShowDialog();
                bbHoTen.Caption = Program.objUserCurrent.FullName + " (" + Program.objUserCurrent.UserName + ")";
                bbNamHoc.Caption = "Năm học: " + Program.NamHoc + " - Học kỳ: " + Program.HocKy.ToString();
                // lay quyen user login
                GetQuyen_Login(Program.objUserCurrent.UserName);
                GetThongTinTruong();
                PageBringToFront(UnimOs.UI.Properties.Settings.Default.PageDefault);
            }
            if ("" + (new cBHT_ThamSoHeThong()).GetGiaTriByMaThamSo("ShowStartupForm") != "0")
            {
                frmStartPage frmStart = new frmStartPage();
                this.CreateMDIForm(frmStart);
            }
        }

        private void GetThongTinTruong()
        {
            DataTable dtTTTruong = new cBHT_ThongTinTruong().Get(new HT_ThongTinTruongInfo());
            foreach (DataRow dr in dtTTTruong.Rows)
            {
                if (dr["MaThongTin"].ToString() == "TenBo")
                    Program.TenBo = "" + dr["GiaTri"];
                else if (dr["MaThongTin"].ToString() == "TenTruong")
                    Program.TenTruong = "" + dr["GiaTri"];
                else if (dr["MaThongTin"].ToString() == "DiaChi")
                    Program.DiaChi = "" + dr["GiaTri"];
            }
        }

        private void GetQuyen_Login(string UserName)
        {
            Hashtable htb = new Hashtable();
            DataTable dtTemp = oBHT_User.GetChucNang(UserName);

            // Thuc hien hien thi cac menu da duoc phan quyen
            LoadMenu(dtTemp);

            // Thuc hien lay cac chuc nang duoc phan quyen vao Hashtable
            if (dtTemp != null && dtTemp.Rows.Count >0)
            {
                string[] arrBit;
                foreach (DataRow dr in dtTemp.Rows)
                {
                    if ("" + dr["Tag"] != "")
                    {
                        if (!htb.ContainsKey(dr["Tag"].ToString()))
                        {
                            arrBit = new string[4];

                            arrBit[0] = dr["barbtnName"].ToString();
                            if (bool.Parse(dr["Them"].ToString()) == false)
                                arrBit[1] = "" + dr["btnThem"];
                            if (bool.Parse(dr["Sua"].ToString()) == false)
                                arrBit[2] = "" + dr["btnSua"];
                            if (bool.Parse(dr["Xoa"].ToString()) == false)
                                arrBit[3] = "" + dr["btnXoa"];

                            htb.Add(dr["Tag"].ToString(), arrBit);
                        }
                    }
                }
            }
            Program.htTable = htb;
        }

        private void iAbout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.Utils.About.frmAbout dlg = new DevExpress.Utils.About.frmAbout("UnimOs Giải pháp quản lý tổng thể trường Đại học.");
            dlg.ShowDialog();
        }
        #endregion

        private void ribbonMain_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag == null)
                return;
            switch (e.Item.Tag.ToString())
            {
                #region Phân hệ danh mục
                case "barbtnHeDaoTao":
                    {
                        frmHeDaoTao frm = new frmHeDaoTao();
                        frm.ShowDialog();
                        break;
                    }
                case "barbtnTrinhDoDaoTao":
                    {
                        frmTrinhDo frm = new frmTrinhDo();
                        frm.ShowDialog();
                        break;
                    }
                case "barbtnKhoa":
                    {
                        frmKhoaBoMon frm = new frmKhoaBoMon();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnNganhChuyenNganh":
                    {
                        frmNganhChuyenNganh frm = new frmNganhChuyenNganh();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnDSLop":
                    {
                        frmLopHoc frm = new frmLopHoc();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnMonHoc":
                    {
                        frmMonHoc frm = new frmMonHoc();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnNamHoc":
                    {
                        frmNamHoc frm = new frmNamHoc();
                        frm.ShowDialog();
                        break;
                    }
                case "barbtnKhoaHoc":
                    {
                        frmKhoaHoc frm = new frmKhoaHoc();
                        frm.ShowDialog();
                        break;
                    }
                case "barbtnPhongHocDiaDiem":
                    {
                        frmPhongHoc frm = new frmPhongHoc();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                
                //            case "barbtnHanhKiem":
                //            {
                //                frmHanhKiem frm = new frmHanhKiem();
                //                frm.ShowDialog();
                //                break;
                //            }
                case "barbtnDanToc":
                    {
                        frmDanToc frm = new frmDanToc();
                        frm.ShowDialog();
                        break;
                    }
                case "barbtnTinhHuyenXa":
                    {
                        frmTinhHuyenXa frm = new frmTinhHuyenXa();
                        frm.ShowDialog();
                        break;
                    }
                case "barbtnXepLoaiTotNghiep":
                    {
                        frmXepLoaiTotNghiep frm = new frmXepLoaiTotNghiep();
                        frm.ShowDialog();
                        break;
                    }
                case "barbtnXepLoaiRenLuyen":
                    {
                        frmDM_XepLoaiRenLuyen frm = new frmDM_XepLoaiRenLuyen();
                        frm.ShowDialog();
                        break;
                    }
                case "barbtnCapKhenThuong":
                    {
                        frmDMCapKhenThuong frm = new frmDMCapKhenThuong(null, null, null, null);
                        frm.ShowDialog();
                        break;
                    }
                case "barbtnDoiTuongTroCap":
                    {
                        frmDoiTuongTroCap frm = new frmDoiTuongTroCap();
                        frm.ShowDialog();
                        break;
                    }
                case "barbtnDoiTuongMienGiam":
                    {
                        frmDoiTuongMienGiam frm = new frmDoiTuongMienGiam();
                        frm.ShowDialog();
                        break;
                    }

                case "barbtnThanhTichKhenThuong":
                    {
                        frmThanhTichKhenThuong frm = new frmThanhTichKhenThuong();
                        frm.ShowDialog();
                        break;
                    }
                case "barbtnHanhViViPham":
                    {
                        frmHanhViViPham frm = new frmHanhViViPham();
                        frm.ShowDialog();
                        break;
                    }
                case "barbtnThanhPhanDiem":
                    {
                        frmThanhPhanDiem frm = new frmThanhPhanDiem();
                        frm.ShowDialog();
                        break;
                    }
               
                case "barbtnTonGiao":
                    {
                        frmTonGiao frm = new frmTonGiao();
                        frm.ShowDialog();
                        break;
                    }
                case "barbtnGiayToNhapTruong":
                    {
                        frmGiayToNhapTruong frm = new frmGiayToNhapTruong();
                        frm.ShowDialog();
                        break;
                    }
                case "barbtnLoaiCongViec":
                    {
                        frmLoaiCongViec frm = new frmLoaiCongViec();
                        frm.ShowDialog();
                        break;
                    }

                #endregion

                #region Phân hệ quản lý sinh viên
                case "barbtnNhapTruong":
                    {
                        frmNhapDuLieuTuFile frm = new frmNhapDuLieuTuFile("SV_SinhVienNhapTruong");
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnGoiNhapHoc":
                    {
                        frmGoiNhapHoc frm = new frmGoiNhapHoc();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnPhanLop":
                    {
                        frmPhanLopSinhVien frm = new frmPhanLopSinhVien();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnLapMaSinhVien":
                    {
                        frmLapMaSinhVien frm = new frmLapMaSinhVien();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnCapNhatAnh":
                    {
                        frmCapNhatAnhSinhVien frm = new frmCapNhatAnhSinhVien();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnDSSVThoiHoc":
                    {
                        frmDanhSachThoiHoc frm = new frmDanhSachThoiHoc();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnNhapHocLai":
                    {
                        frmNhapHocLai frm = new frmNhapHocLai();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnKhenThuong":
                    {
                        frmKhenThuong frm = new frmKhenThuong();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnKyLuat":
                    {
                        frmKyLuat frm = new frmKyLuat();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "btnInDSXetHocBong":
                    {
                        frmDanhSachXemXetHocBong frm = new frmDanhSachXemXetHocBong();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnDanhSachLop":
                    {
                        frmDanhSachSinhVienLop frm = new frmDanhSachSinhVienLop();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnDTMienGiam":
                    {
                        frmDoiTuongMienGiamSinhVien frm = new frmDoiTuongMienGiamSinhVien();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }

                case "barbtnDTTroCap":
                    {
                        frmDoiTuongTroCapSinhVien frm = new frmDoiTuongTroCapSinhVien();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnDiemRenLuyenHocKy":
                    {
                        frmDiemRenLuyenHocKy frm = new frmDiemRenLuyenHocKy();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnDiemRenLuyenNamHoc":
                    {
                        frmDiemRenLuyenNamHoc frm = new frmDiemRenLuyenNamHoc();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnDiemRenLuyenToanKhoa":
                    {
                        ////frmDiemRenLuyenToanKhoa frm = new frmDiemRenLuyenToanKhoa();
                        //frmTongKetDiemToanKhoa frm = new frmTongKetDiemToanKhoa();
                        //if (!this.CheckFormExist(frm.Tag.ToString()))
                        //{
                        //    this.CreateMDIForm(frm);
                        //}
                        break;
                    }
                case "barbtnTKSVTheoLop":
                    {
                        ////frmDiemRenLuyenToanKhoa frm = new frmDiemRenLuyenToanKhoa();
                        frmThongKeSVTheoLop frm = new frmThongKeSVTheoLop();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                //            case "barbtnThiDuaCaNhan":
                //            {
                //                XtraMessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                break;
                //            }

                //            case "barbtnThiDuaTapThe":
                //            {
                //                XtraMessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                break;
                //            }

                //            case "barbtnTimKiem":
                //            {
                //                XtraMessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                break;
                //            }

                //            case "barbtnThongKe":
                //            {
                //                XtraMessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                break;
                //            }

                //            case "barbtnBaoCao":
                //            {
                //                XtraMessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                break;
                //            }

                #endregion

                #region Phân hệ quản lý cán bộ
                case "barbtnDanhSachCanBo":
                    {
                        frmDanhSachGiaoVien frm = new frmDanhSachGiaoVien();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnLapMaGiaoVien":
                    {
                        frmLapMaGiaoVien frm = new frmLapMaGiaoVien();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnCapNhatAnhGiaoVien":
                    {
                        frmCapNhatAnhGiaoVien frm = new frmCapNhatAnhGiaoVien();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnQuaTrinhBoiDuong":
                    {
                        frmQuaTrinhBoiDuong frm = new frmQuaTrinhBoiDuong();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
               case "barbtnQuaTrinhCongTac":
                    {
                        frmQuaTrinhCongTac frm = new frmQuaTrinhCongTac();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
               case "barbtnQuaTrinhThamGiaLLVT":
                    {
                        frmQuaTrinhThamGiaLLVT frm = new frmQuaTrinhThamGiaLLVT();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
               case "barbtnQuaTrinhThamGiaTCCTXH":
                    {
                        frmQuaTrinhThamGiaTCCTXH frm = new frmQuaTrinhThamGiaTCCTXH();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
               case "barbtnQuaTrinhBoNhiemChucVu":
                    {
                        frmQuaTrinhBoNhiemChucVu frm = new frmQuaTrinhBoNhiemChucVu();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
               case "barbtnQuaTrinhMienNhiemTuChuc":
                    {
                        frmQuaTrinhMienNhiemTuChuc frm = new frmQuaTrinhMienNhiemTuChuc();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
               case "barbtnQuaTrinhKhenThuong":
                    {
                        frmQuaTrinhKhenThuong frm = new frmQuaTrinhKhenThuong();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
             case "barbtnQuaTrinhKyLuat":
                    {
                        frmQuaTrinhKyLuat frm = new frmQuaTrinhKyLuat();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
             case "barbtnQuaTrinhLuanChuyen":
                    {
                        frmQuaTrinhLuanChuyen frm = new frmQuaTrinhLuanChuyen();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
             case "barbtnLuongCoBan":
                    {
                        frmDM_LuongCoBan frm = new frmDM_LuongCoBan();
                        frm.ShowDialog();
                        break;
                    }
             case "barbtnPhuCap":
                    {
                        frmPhuCap frm = new frmPhuCap();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
             case "barbtnNgachCongChuc":
                    {
                        frmDM_NgachCongChuc frm = new frmDM_NgachCongChuc(null, null);
                        frm.ShowDialog();
                        break;
                    }
             case "barbtnLuong":
                    {
                        frmLuong frm = new frmLuong();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
             case "barbtnNangBacChuyenNgach":
                    {
                        frmNangBacChuyenNgach frm = new frmNangBacChuyenNgach();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
             case "barbtnBangLuong":
                    {
                        frmBangLuong frm = new frmBangLuong();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
             case "barbtnCanhBaoHanNangLuongNghiHuu":
                    {
                        frmCanhBaoHanNangLuongNghiHuu frm = new frmCanhBaoHanNangLuongNghiHuu();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
             case "barbtnBaoCao":
                    {
                        frmBaoCaoDinhKy frm = new frmBaoCaoDinhKy();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
             case "barbtnTongHopCacQuaTrinh":
                    {
                        frmTongHopCacQuaTrinh frm = new frmTongHopCacQuaTrinh();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                #endregion

                #region Phân hệ lập kế hoạch
                case "barbtnCTKhoiKienThuc":
                    {
                        frmChuongTrinhKhoiKienThuc frm = new frmChuongTrinhKhoiKienThuc();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnCTDT":
                    {
                        frmChuongTrinhDaoTao frm = new frmChuongTrinhDaoTao();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnMonKy":
                    {
                        frmMonHocTrongKy frm = new frmMonHocTrongKy();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnKeHoachToanTruong":
                    {
                        frmKeHoachToanTruong frm = new frmKeHoachToanTruong();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnPhanBoPhongHoc":
                    {
                        frmPhanBoPhongHoc frm = new frmPhanBoPhongHoc();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnBaoBanGiangVien":
                    {
                        frmBaoBanGiaoVien frm = new frmBaoBanGiaoVien();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }

                case "barbtnCoDinhTietNghi":
                    {
                        frmTietNghiCoDinhLop frm = new frmTietNghiCoDinhLop();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }

                case "barbtnPhanCongGiangDay":
                    {
                        frmPhanCongGiangDay frm = new frmPhanCongGiangDay();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnLopTach":
                    {
                        frmLopTach frm = new frmLopTach();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnLopGop":
                    {
                        frmLopGop frm = new frmLopGop();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnKeHoachThucHanh":
                    {
                        frmKeHoachThucHanh frm = new frmKeHoachThucHanh();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnThemMonThucHanh":
                    {
                        dlgLuaChonMonThucHanh dlg = new dlgLuaChonMonThucHanh();
                        dlg.ShowDialog();
                        break;
                    }
                case "barbtnKeHoachMon":
                    {
                        frmKeHoachChiTiet frm = new frmKeHoachChiTiet();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnLapThoiKhoaBieuTuDong":
                    {
                        frmTKB frm = new frmTKB();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                //        case "barbtnKeHoachMon":
                //            {
                //                XtraMessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                break;
                //            }
                
                //        case "barbtnLapThoiKhoaBieuBangTay":
                //            {
                //                XtraMessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                break;
                //            }
                case "barbtnInTKBToanTruong":
                    {
                        frmTKB_Print frm = new frmTKB_Print();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                //        case "barbtnInTKBPhongHoc":
                //            {
                //                XtraMessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                break;
                //            }
                //        case "barbtnInTKBLopHoc":
                //            {
                //                XtraMessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                break;
                //            }
                //        case "barbtnInTKBGiaoVien":
                //            {
                //                XtraMessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                break;
                //            }
                #endregion

                #region Phân hệ quản lý điểm
                case "barbtnHoiDongMonHoc":
                    {
                        frmHoiDongMonHoc frm = new frmHoiDongMonHoc();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnTheoDoiMonHoc":
                    {
                        frmTheoDoiMonHoc frm = new frmTheoDoiMonHoc();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnDangKyTuChon":
                    {
                        frmDangKyTuChon frm = new frmDangKyTuChon();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnXetThiHetMon":
                    {
                        frmXetThiHetMon frm = new frmXetThiHetMon();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }

                case "barbtnNhapDiemTheoSoBD":
                    {
                        //frmNhapDiemTheoSBDVaSP frm = new frmNhapDiemTheoSBDVaSP();
                        frmNhapDiemTheoSoPhach frm = new frmNhapDiemTheoSoPhach();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnNhapDiemTheoLopToChucHocLai":
                    {
                        frmNhapDiemTheoLopHocLai frm = new frmNhapDiemTheoLopHocLai();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnNhapDiemTongKet":
                    {
                        frmNhapDiemTongKet frm = new frmNhapDiemTongKet();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnTongKetDiemMonHoc":
                    {
                        frmTongKetDiemMonHoc frm = new frmTongKetDiemMonHoc();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnTongHopDiemTheoKy":
                    {
                        frmTongKetDiemHocKy frm = new frmTongKetDiemHocKy();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnTongHopDiemTheoNam":
                    {
                        frmTongKetDiemNamHoc frm = new frmTongKetDiemNamHoc();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnToChucLopHocLai":
                    {
                        frmToChucLopHocLai frm = new frmToChucLopHocLai();
                        frm.ShowDialog();
                        break;
                    }
                case "barbtnNhapDiemHoiDongMonHoc":
                    {
                        frmNhapDiemHoiDongMonHoc frm = new frmNhapDiemHoiDongMonHoc();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnDangKyHocLai":
                    {
                        frmDangKyHocLai frm = new frmDangKyHocLai();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnDangKyThiLai":
                    {
                        frmDangKyThiLai frm = new frmDangKyThiLai();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnNhapDiem":
                    {
                        frmNhapDiem frm = new frmNhapDiem();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnDTNhapDiemThanhPhan":
                    {
                        frmDTNhapDiemThanhPhan_QCNghe frm = new frmDTNhapDiemThanhPhan_QCNghe();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnNhapDiem_KhaoThi":
                    {
                        frmNhapDiem_KhaoThi frm = new frmNhapDiem_KhaoThi();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnNhapDiemExcel":
                    {
                        frmNhapDiemExcel frm = new frmNhapDiemExcel();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnToChucThi":
                    {
                        frmToChucThiDaToChuc frm = new frmToChucThiDaToChuc();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnCongThucDiem":
                    {
                        frmCongThucDiem frm = new frmCongThucDiem();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnTrungBinhMonToanKhoa":
                    {
                        frmTongKetDiemToanKhoa frm = new frmTongKetDiemToanKhoa();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnTongHopDiemToanKhoa":
                    {
                        frmTongHopDiemThiTotNghiep frm = new frmTongHopDiemThiTotNghiep();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnTongHopDiemToanKhoa_QCNghe":
                    {
                        frmTongHopDiemThiTotNghiep_QCNghe frm = new frmTongHopDiemThiTotNghiep_QCNghe();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnXetLenLop":
                    {
                        frmXetLenLop frm = new frmXetLenLop();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnTongHopXepLoai":
                    {
                        frmTongHopXepLoai frm = new frmTongHopXepLoai();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnXetTotNghiep":
                    {
                        frmXetTotNghiepRaTruong frm = new frmXetTotNghiepRaTruong();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnCongThucDiemToanKhoa":
                    {
                        frmCongThucDiemToanKhoa frm = new frmCongThucDiemToanKhoa();
                        frm.ShowDialog();
                        break;
                    }
                case "barbtnMonThiTotNghiep_Lop":
                    {
                        frmLop_MonThiTotNghiep frm = new frmLop_MonThiTotNghiep();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnXetThiTotNghiep":
                    {
                        frmXetThiTotNghiep frm = new frmXetThiTotNghiep();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnToChucThiTotNghiep":
                    {
                        frmToChucThi_TotNghiep_DaToChuc frm = new frmToChucThi_TotNghiep_DaToChuc();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnNhapDiemThiTotNghiep":
                    {
                        //frmNhapDiemTheoSBDVaSP frm = new frmNhapDiemTheoSBDVaSP();
                        frmNhapDiemThiTotNghiepTheoPhach frm = new frmNhapDiemThiTotNghiepTheoPhach();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnQuyetDinhTotNghiep":
                    {
                        frmQuyetDinhTotNghiep frm = new frmQuyetDinhTotNghiep();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnQuyetDinhTotNghiep_QCNghe":
                    {
                        frmQuyetDinhTotNghiep_QCNghe frm = new frmQuyetDinhTotNghiep_QCNghe();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnDangKyThiLaiTotNghiep":
                    {
                        frmDangKyThiLaiTotNghiepKhoaTruoc frm = new frmDangKyThiLaiTotNghiepKhoaTruoc();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                #endregion

                #region Phân hệ quản lý tài chính
                case "barbtnLoaiQuy":
                    {
                        frmDM_LoaiQuy frm = new frmDM_LoaiQuy();
                        frm.ShowDialog();
                        break;
                    }
                case "barbtnLoaiThuChi":
                    {
                        frmDM_LoaiThuChi frm = new frmDM_LoaiThuChi();
                        frm.ShowDialog();
                        break;
                    }
                case "barbtnLoaiHocBong":
                    {
                        frmDM_LoaiHocBong frm = new frmDM_LoaiHocBong();
                        frm.ShowDialog();
                        break;
                    }
                case "barbtnQuyenHoaDon":
                    {
                        frmDM_QuyenHoaDon frm = new frmDM_QuyenHoaDon();
                        frm.ShowDialog();
                        break;
                    }
                case "barbtnDanhSachMienGiam":
                    {
                        frmDanhSachMienGiam frm = new frmDanhSachMienGiam();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnDanhSachTrocap":
                    {
                        frmDanhSachTroCap frm = new frmDanhSachTroCap();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnDinhMucThu":
                    {
                        frmDinhMucThu frm = new frmDinhMucThu();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnBienLaiThuTien":
                    {
                        frmBienLaiThuTien_Tree frm = new frmBienLaiThuTien_Tree();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnThuTienNhapHoc":
                    {
                        frmThuTienNhapHoc frm = new frmThuTienNhapHoc();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnBaoCaoDanhSachMienGiam":
                    {
                        frmBaoCaoDanhSachMienGiam frm = new frmBaoCaoDanhSachMienGiam();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnTongHopCacKhoanThuSinhVien":
                    {
                        frmTongHopThuChoSinhVien frm = new frmTongHopThuChoSinhVien();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
               case "barbtnTongHopThuChi":
                    {
                        frmTongHopThuChi frm = new frmTongHopThuChi();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }              
               case "barbtnPhanBoHocBong":
                    {
                        frmQuyHocBong frm = new frmQuyHocBong();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
               case "barbtnXetHocBong":
                    {
                        frmXetHocBong frm = new frmXetHocBong();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break ;
                    }
               case "barbtnTongHopHocBong":
                    {
                        frmTongHopChiHocBong frm = new frmTongHopChiHocBong();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break ;
                    }
               case "barbtnDanhSachHocBong":
                    {
                        frmDanhSachHocBong frm = new frmDanhSachHocBong();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
               case "barbtnChiHocBong":
                    {
                        frmDanhSachHocBong_ChamCong frm = new frmDanhSachHocBong_ChamCong();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                #endregion

                #region Phân hệ quản lý giờ giảng
                case "barbtnDinhMucTheoChucDanh":
                    {
                        frmDinhMucTheoChucDanh frm = new frmDinhMucTheoChucDanh();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnDinhMucGioGiangChoTungGiaoVien":
                    {
                        frmDinhMucGioGiangChoTungGiaoVien frm = new frmDinhMucGioGiangChoTungGiaoVien();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "BarbtnNhapCongViecGiaoVien":
                    {
                        frmNhapCongViecGiaoVien frm = new frmNhapCongViecGiaoVien();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barBtnTongHopGioGiang":
                    {
                        frmTongHopGioDay frm = new frmTongHopGioDay();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnGioGiangGiaoVien":
                    {
                        frmGioGiangGiaoVienHeSoLopDong frm = new frmGioGiangGiaoVienHeSoLopDong();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barBtnHeSoTheoTrinhDo":
                    {
                        frmHeSoLopDongTheoKhoa frm = new frmHeSoLopDongTheoKhoa();
                        frm.ShowDialog();
                        break;
                    }
                case "barBtnThongKeSinhVien":
                    {
                        frmThongKeSVTheoLop frm = new frmThongKeSVTheoLop();
                        frm.ShowDialog();
                        break;
                    }  
                #endregion

                #region Phân hệ quản trị hệ thống
                case "barbtnNhapDuLieuTuFile":
                    {
                        frmNhapDuLieuTuFile frm = new frmNhapDuLieuTuFile();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnThongTinTruong":
                    {
                        frmThongTinTruong frm = new frmThongTinTruong();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                    
                case "barbtnThamSoHeThong":
                    {
                        frmThamSoHeThong frm = new frmThamSoHeThong();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnThamSoQuyChe":
                    {
                        frmThamSoQuyChe frm = new frmThamSoQuyChe();
                        frm.ShowDialog();
                        break;
                    }
                case "barbtnChonNamHoc":
                    {
                        frmChonNamHoc frm = new frmChonNamHoc();
                        frm.ShowDialog();
                        bbNamHoc.Caption = "Năm học: " + Program.NamHoc + " - Học kỳ: " + Program.HocKy.ToString();
                        break;
                    }
                case "bbNamHoc":
                    {
                        frmChonNamHoc frm = new frmChonNamHoc();
                        frm.ShowDialog();
                        bbNamHoc.Caption = "Năm học: " + Program.NamHoc + " - Học kỳ: " + Program.HocKy.ToString();
                        break;
                    }
                case "barbtnQuyChe":
                    {
                        frmQuyChe frm = new frmQuyChe();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnDanhSachChucNang":
                    {
                        frmDanhSachChucNang frm = new frmDanhSachChucNang();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnDanhSachNguoiDung":
                    {
                        frmQuanLyNguoiDung frm = new frmQuanLyNguoiDung();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnUserGroup":
                    {
                        frmNhomNguoiDung frm = new frmNhomNguoiDung();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnLapTaiKhoanGiaoVien":
                    {
                        frmLapTaiKhoanGiaoVien frm = new frmLapTaiKhoanGiaoVien();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnLapTaiKhoanSinhVien":
                    {
                        frmLapTaiKhoanSinhVien frm = new frmLapTaiKhoanSinhVien();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnTraCuuLichSu":
                    {
                        frmTraCuuLog frm = new frmTraCuuLog();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnDongBoDuLieu":
                    {
                        frmDongBoDuLieu frm = new frmDongBoDuLieu();
                        frm.ShowDialog();
                    }
                    break;
                case "barbtnMayTinh":
                    {
                        System.Diagnostics.Process.Start("calc");
                    }
                    break;
                case "barbtnDoiMatKhau":
                    {
                        frmChangePassword frm = new frmChangePassword();
                        frm.ShowDialog();
                    }
                    break;
                case "barbtnTamThoat":
                    {
                        LogOut();
                    }
                    break;
                case "barbtnLogOut":
                    {
                        LogOut();
                    }
                    break;
                case "barbtnThoat":
                    {
                        Application.Exit();
                    }
                    break;
                #endregion

                #region Phân hệ trợ giúp
                // Phân Hệ Trợ Giúp
                case "barbtnWebsite":
                    {
                        CreatInternetBrowser();
                        break;
                    }
                case "barbtnHuongDanSuDung":
                    {
                        XtraMessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                case "barbtnTacGia":
                    {
                        XtraMessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                #endregion
            }
        }

        private void LogOut()
        {
            {
                foreach (Form frm in this.MdiChildren)
                {
                    if (frm.Name != "frmStartPage")
                        frm.Close();
                }
                frmLogIn frmLogin = new frmLogIn();
                if (frmLogin.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                }
                else
                {
                    //Cập nhật lại quyền
                    this.Close();
                    Application.Exit();
                }
            }
        }

        private void CreatInternetBrowser()
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            // Set các tham số
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "iexplore";
            proc.StartInfo.Arguments = "http://www.truongviet.vn";
            // Chạy tiến trình
            proc.Start();
            // Chờ xử lý tiến trình
            proc.WaitForExit();
            //Thoát
            MessageBox.Show("Cảm ơn bạn đã ghé thăm website của chúng tôi");
        }

        private void barbtnSetDefaultPage_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ribbonMain.SelectedPage.Name != UnimOs.UI.Properties.Settings.Default.PageDefault)
            {
                UnimOs.UI.Properties.Settings.Default.PageDefault = ribbonMain.SelectedPage.Name;
                UnimOs.UI.Properties.Settings.Default.Save();
            }
        }

        private void barBtnTongHopGioGiang_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barbtnNhapHocLai_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        

        
    }
}
