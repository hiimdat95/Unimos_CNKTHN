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

namespace UnimOs.Khoa
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
                if (cnt.SkinName.IndexOf("Office") > -1) groupIndex = 1;
                rgbiSkins.Gallery.Groups[groupIndex].Items.Add(gItem);
                gItem.Caption = cnt.SkinName;
                gItem.Image = GetSkinImage(imageButton, 32, 17, 2);
                gItem.HoverImage = GetSkinImage(imageButton, 70, 36, 5);
                gItem.Caption = cnt.SkinName;
                gItem.Hint = cnt.SkinName;
                rgbiSkins.Gallery.Groups[1].Visible = false;
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

                bbNamHoc.Caption = "Năm học: " + Program.NamHoc + " - Học kỳ: " + Program.HocKy.ToString();
                // lay quyen user login
                GetQuyen_Login(Program.objUserCurrent.Username);
                GetThongTinTruong();
                //PageBringToFront(UnimOs.Khoa.Properties.Settings.Default.PageDefault);
                if ("" + (new cBHT_ThamSoHeThong()).GetGiaTriByMaThamSo(" ") != "0")
                {
                    frmStartPage frmStart = new frmStartPage();
                    this.CreateMDIForm(frmStart);
                }
            }
            else
            {
                this.Close();
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

        private void LoadMenu(bool status)
        {
            ribbonPGChuongTrinhDaoTao.Visible = status;
            ribbonPGGioGiang.Visible = status;
            //if (status)
            //{
            //    barbtnChuongTrinhKhoiKienThuc.Visibility = BarItemVisibility.Always;
            //    barbtnChuongTrinhDaoTao.Visibility = BarItemVisibility.Always;
            //    barbtnDanhMucMonHoc.Visibility = BarItemVisibility.Always;
            //    barbtnMonHocTrongKy.Visibility = BarItemVisibility.Always;
            //    barbtnPhanCongGiangDay.Visibility = BarItemVisibility.Always;
            //}
            //else
            //{
            //    barbtnChuongTrinhKhoiKienThuc.Visibility = BarItemVisibility.Never;
            //    barbtnChuongTrinhDaoTao.Visibility = BarItemVisibility.Never;
            //    barbtnDanhMucMonHoc.Visibility = BarItemVisibility.Never;
            //    barbtnMonHocTrongKy.Visibility = BarItemVisibility.Never;
            //    barbtnPhanCongGiangDay.Visibility = BarItemVisibility.Never;
            //}
        }

        private void GetQuyen_Login(string UserName)
        {
            bbHoTen.Caption = Program.objUserCurrent.HoTen + " (" + Program.objUserCurrent.Username + ")";
            Hashtable htb = new Hashtable();
            DataTable dtTemp = oBHT_User.GetChucNang(UserName);
            if (Program.objUserCurrent.IDDM_Khoa_GiaoVu > 0)
                LoadMenu(true);
            else
                LoadMenu(false);
            // Thuc hien lay cac chuc nang duoc phan quyen vao Hashtable
            if (dtTemp != null && dtTemp.Rows.Count >0)
            {
                string[] arrBit;
                foreach (DataRow dr in dtTemp.Rows)
                {
                    if ("" + dr["Tag"] != "")
                    {
                        arrBit = new string[4];

                        arrBit[0] = dr["barbtnName"].ToString();
                        if (bool.Parse(dr["Them"].ToString()) == true)
                            arrBit[1] = "Them";
                        if (bool.Parse(dr["Sua"].ToString()) == true)
                            arrBit[2] = "Sua";
                        if (bool.Parse(dr["Xoa"].ToString()) == true)
                            arrBit[3] = "Xoa";

                        htb.Add(dr["Tag"].ToString(), arrBit);
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
                case "barbtnNhapDiemMonHoc":
                    {
                        frmNhapDiem frm = new frmNhapDiem();
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
                case "barbtnNhapDiemTheoSoPhach":
                    {
                        frmNhapDiemTheoSoPhach frm = new frmNhapDiemTheoSoPhach();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnChuongTrinhKhoiKienThuc":
                    {
                        frmChuongTrinhKhoiKienThuc frm = new frmChuongTrinhKhoiKienThuc();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnChuongTrinhDaoTao":
                    {
                        frmChuongTrinhDaoTao frm = new frmChuongTrinhDaoTao();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnMonHocTrongKy":
                    {
                        frmMonHocTrongKy frm = new frmMonHocTrongKy();
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
                case "barbtnKeHoachGiaoVien":
                    {
                        frmGioGiangGiaoVienHeSoLopDong frm = new frmGioGiangGiaoVienHeSoLopDong();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnDinhMucGioGiang":
                    {
                        frmDinhMucGioGiangChoTungGiaoVien frm = new frmDinhMucGioGiangChoTungGiaoVien();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnDanhMucMonHoc":
                    {
                        frmMonHoc frm = new frmMonHoc();
                        if (!this.CheckFormExist(frm.Tag.ToString()))
                        {
                            this.CreateMDIForm(frm);
                        }
                        break;
                    }
                case "barbtnChonNamHoc":
                    {
                        foreach (Form frm in this.MdiChildren)
                        {
                            if (frm.Name != "frmStartPage")
                                frm.Close();
                        }
                        frmChonNamHoc frmNamHoc = new frmChonNamHoc();
                        frmNamHoc.ShowDialog();
                        bbNamHoc.Caption = "Năm học: " + Program.NamHoc + " - Học kỳ: " + Program.HocKy.ToString();
                        break;
                    }
                case "bbNamHoc":
                    {
                        foreach (Form frm in this.MdiChildren)
                        {
                            if (frm.Name != "frmStartPage")
                                frm.Close();
                        }
                        frmChonNamHoc frmNamHoc = new frmChonNamHoc();
                        frmNamHoc.ShowDialog();
                        bbNamHoc.Caption = "Năm học: " + Program.NamHoc + " - Học kỳ: " + Program.HocKy.ToString();
                        break;
                    }
                case "barbtnMayTinh":
                    {
                        System.Diagnostics.Process.Start("calc");
                    }
                    break;
                case "barbtnDoiMatKhau":
                    {
                        if (Program.objUserCurrent.Username != "giaovu")
                        {
                            frmChangePassword frm = new frmChangePassword();
                            frm.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("Tài khoản dùng chung không thể đổi mật khẩu !");
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

                #region Phân hệ trợ giúp
                // Phân Hệ Trợ Giúp
                case "barbtnWebsite":
                    {
                        CreatInternetBrowser();
                        break;
                    }
                case "barbtnHuongDanSuDung":
                    {
                        try
                        {
                            System.Diagnostics.Process proc = new System.Diagnostics.Process();
                            // Set các tham số
                            proc.EnableRaisingEvents = false;
                            proc.StartInfo.FileName = Application.StartupPath + "\\Template\\HDSD_UnimOs_Khoa.pdf";
                            //proc.StartInfo.Arguments = "http://www.truongviet.vn";
                            // Chạy tiến trình
                            proc.Start();
                        }
                        catch
                        {
                            XtraMessageBox.Show("Không tìm thấy file HDSD_UnimOs_Khoa.pdf trong chương trình");
                        }
                        break;
                    }
                case "barbtnTacGia":
                    {
                        //XtraMessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                #endregion

            }
        }

        private void LogOut()
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name != "frmStartPage")
                    frm.Close();
            }
            frmLogIn frmLogin = new frmLogIn();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                //Cập nhật lại quyền
                GetQuyen_Login(Program.objUserCurrent.Username);
            }
            else
            {
                this.Close();
                Application.Exit();
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
    }
}
