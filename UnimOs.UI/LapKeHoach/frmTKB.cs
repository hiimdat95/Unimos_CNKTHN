using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TruongViet.UnimOs.Business;
using C1.Win.C1FlexGrid;
using TruongViet.UnimOs.Entity;
using System.Collections;
using Lib;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace UnimOs.UI
{
    public partial class frmTKB : frmBase
    {
        private clsTKB objTKB;
        private REPORT_TYPE rptType = REPORT_TYPE.THEO_SUKIEN;
        private int IDX;
        private ArrayList _mask;
        private DataTable dtTuan;
        private int TuanThu = 0;
        private int TuanID = 0;
        private CellRange cr1;
        private int colbegin = 3;
        private int colWidth = 40;
        private int DoiCho = 0;
        private bool Loaded = false, ChonTatCa = false;
        private clsStringHelper strHlp = new clsStringHelper();

        public frmTKB()
        {
            InitializeComponent();
        }

        #region FomatFG

        private void Allow_merge()
        {
            fg.Rows[0].AllowMerging = true;
            fg.Rows[1].AllowMerging = true;
            fg.Rows[2].AllowMerging = true;
            fg.Cols[0].AllowMerging = true;
            fg.Cols[1].AllowMerging = true;
            fg.Rows[0].TextAlign = TextAlignEnum.CenterCenter;
            fg.Rows[1].TextAlign = TextAlignEnum.CenterCenter;
            fg.Rows[2].TextAlign = TextAlignEnum.CenterCenter;
            fg.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            fg.Cols[2].Visible = false;
        }

        public static void Flexgrid_setup(C1FlexGrid fg)
        {
            // Định nghĩa các kiểu để hiển thị 
            Font Font_ = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point);
            CellStyle Normal_Style = default(CellStyle);
            CellStyle LyThuyet_Style = default(CellStyle);
            CellStyle ThucHanh_Style = default(CellStyle);
            CellStyle Chon_Style = default(CellStyle);
            CellStyle Free_Style = default(CellStyle);
            CellStyle SWap_Style = default(CellStyle);
            CellStyle TKB_Style = default(CellStyle);
            CellStyle TKB_Special = default(CellStyle);
            CellStyle ReadOnly_Style = default(CellStyle);

            //Fixed_Style
            Free_Style = fg.Styles.Add("Free_Style");
            Free_Style.BackColor = Color.Moccasin;


            // SWap_Style
            SWap_Style = fg.Styles.Add("SWap_Style");
            SWap_Style.BackColor = Color.Yellow;
            //Normal_Style
            Normal_Style = fg.Styles.Add("Normal_Style");
            Normal_Style.BackColor = Color.White;
            Normal_Style.ForeColor = Color.Black;
            Normal_Style.Font = Font_;
            Normal_Style.TextAlign = TextAlignEnum.CenterCenter;

            //LyThuyet_Style
            LyThuyet_Style = fg.Styles.Add("LyThuyet_Style");
            LyThuyet_Style.BackColor = Color.CornflowerBlue;
            LyThuyet_Style.ForeColor = Color.White;
            LyThuyet_Style.Font = Font_;
            LyThuyet_Style.TextAlign = TextAlignEnum.CenterCenter;
            LyThuyet_Style.ImageAlign = ImageAlignEnum.RightBottom;
            LyThuyet_Style.Border.Style = BorderStyleEnum.Raised;
            LyThuyet_Style.Border.Color = Color.Blue;

            //TKB_Style
            TKB_Style = fg.Styles.Add("TKB_Style");
            TKB_Style.BackColor = Color.CornflowerBlue;
            TKB_Style.ForeColor = Color.White;
            TKB_Style.Font = Font_;
            TKB_Style.TextAlign = TextAlignEnum.CenterCenter;
            TKB_Style.ImageAlign = ImageAlignEnum.RightBottom;
            TKB_Style.Border.Style = BorderStyleEnum.Raised;
            TKB_Style.Border.Color = Color.Blue;

            // TKB_Special: các sự kiện đặc biệt như chào cờ, sinh hoạt lớp
            TKB_Special = fg.Styles.Add("TKB_Special");
            TKB_Special.BackColor = Color.LemonChiffon;
            TKB_Special.ForeColor = Color.Blue;
            TKB_Special.Font = Font_;
            TKB_Special.TextAlign = TextAlignEnum.CenterCenter;
            TKB_Special.ImageAlign = ImageAlignEnum.RightBottom;
            TKB_Special.Border.Style = BorderStyleEnum.Raised;
            TKB_Special.Border.Color = Color.Blue;

            //ThucHanh_Style
            ThucHanh_Style = fg.Styles.Add("ThucHanh_Style");
            ThucHanh_Style.BackColor = Color.Peru;
            ThucHanh_Style.ForeColor = Color.White;
            ThucHanh_Style.Font = Font_;
            ThucHanh_Style.TextAlign = TextAlignEnum.CenterCenter;
            ThucHanh_Style.ImageAlign = ImageAlignEnum.RightBottom;
            ThucHanh_Style.Border.Style = BorderStyleEnum.Raised;
            ThucHanh_Style.Border.Color = Color.Blue;

            //Chon_Style
            Chon_Style = fg.Styles.Add("Chon_Style");
            Chon_Style.BackColor = Color.Tomato;
            Chon_Style.ForeColor = Color.White;
            Chon_Style.Font = Font_;
            Chon_Style.TextAlign = TextAlignEnum.CenterCenter;
            Chon_Style.ImageAlign = ImageAlignEnum.RightBottom;
            Chon_Style.Border.Style = BorderStyleEnum.Raised;
            Chon_Style.Border.Color = Color.Blue;

            //ReadOnly_Style
            ReadOnly_Style = fg.Styles.Add("ReadOnly_Style");
            ReadOnly_Style.BackColor = Color.Gainsboro;
            ReadOnly_Style.ForeColor = Color.Black;
            ReadOnly_Style.Font = Font_;
            ReadOnly_Style.TextAlign = TextAlignEnum.CenterCenter;
            ReadOnly_Style.ImageAlign = ImageAlignEnum.RightBottom;
            ReadOnly_Style.Border.Style = BorderStyleEnum.Raised;
        }

        public static void Format_fix_region(C1FlexGrid fg)
        {
            // fg.Styles.Fixed.BackColor = Color.DarkSeaGreen
            fg.Styles.Fixed.BackColor = Color.CornflowerBlue;
            fg.Styles.Fixed.Font = new Font("Tahoma", 8, FontStyle.Bold);
            fg.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter;
        }

        private void Set_WidHei()
        {
            try
            {
                int wid = 45;
                int hei = 60;

                for (int i = fg.Rows.Fixed; i <= fg.Rows.Count - 1; i++)
                {
                    fg.Rows[i].Height = hei;
                }
                for (int i = fg.Cols.Fixed; i <= fg.Cols.Count - 1; i++)
                {
                    fg.Cols[i].Width = wid;
                }
                fg.Cols[0].Width = 30;
                fg.Cols[1].Width = 100;
                fg.Cols[2].Width = 60;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void bbItemThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        #region LoadData
        private void frmTKB_Load(object sender, EventArgs e)
        {
            bar2.Visible = true;
            bar3.Visible = true;
            ShowTitle();
            Load_danhsach_tuan();
            Flexgrid_setup(fg);
            fg.AllowMerging = AllowMergingEnum.Custom;
            bar2.Visible = false;
        }
        private void Reload()
        {
            objTKB = new clsTKB(Program.IDNamHoc, Program.HocKy, TuanID, Program.pgrThamSo);
            show_sukien(objTKB.sks.ToTable(true, true));
            SoSuKienChuaXepLich();
        }
        public void Load_danhsach_tuan()
        {
            dtTuan = (new cBXL_Tuan()).GetByHocKy_NamHoc(Program.IDNamHoc, Program.HocKy);
            barDSTuan.ClearLinks();
            foreach (DataRow row in dtTuan.Rows)
            {
                BarButtonItem bbItem = new BarButtonItem();
                bbItem.ItemClick += new ItemClickEventHandler(bbItem_ItemClick);
                bbItem.Caption = "T" + row["TuanThu"].ToString();
                bbItem.Name = "bbItem_" + row["XL_TuanID"].ToString();
                bbItem.Hint = "Từ " + string.Format("{0:dd/MM/yyyy}", row["TuNgay"]) + 
                    " đến " + string.Format("{0:dd/MM/yyyy}", row["DenNgay"]);
                bbItem.Tag = row["XL_TuanID"];
                barDSTuan.ItemLinks.Add(bbItem, true);
            }
        }

        void bbItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            TuanID = int.Parse(e.Item.Tag.ToString());
            TuanThu = int.Parse(e.Item.Caption.Substring(1));
            ShowTitle();
            Reload();
            SetButton();
            bar2.Visible = true;
        }

        public void ShowTitle()
        {
            string str = "TKB NĂM HỌC: " + Program.NamHoc.ToUpper();
            if (Program.HocKy != 0) str += " - HỌC KỲ: " + Program.HocKy.ToString();
            if (TuanThu != 0)
            {
                str += " - TUẦN THỨ: " + TuanThu.ToString().ToUpper();
                DataRow[] arrDr = dtTuan.Select("XL_TuanID = " + TuanID.ToString());
                if(arrDr.Length>0)
                    str += " từ " + string.Format("{0:dd/MM/yyyy}", arrDr[0]["TuNgay"]) + 
                        " đến " + string.Format("{0:dd/MM/yyyy}", arrDr[0]["DenNgay"]);
            }
            bsItemTKB.Caption = str;
        }
        #endregion

        #region View TKB
        private void bbItemSuKien_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (objTKB == null) return;
            show_sukien(objTKB.sks.ToTable(true, true));
            SoSuKienChuaXepLich();
            SetButton();
        }
        private void SetButton()
        {
            if (rptType == REPORT_TYPE.THEO_GIAOVIEN)
            {
                bbItemGiaoVien.Border = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
                bbItemLop.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                bbItemSuKien.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                bbItemPhongHoc.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            }
            if (rptType == REPORT_TYPE.THEO_LOP)
            {
                bbItemGiaoVien.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                bbItemLop.Border = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
                bbItemSuKien.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                bbItemPhongHoc.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            }
            if (rptType == REPORT_TYPE.THEO_PHONG)
            {
                bbItemGiaoVien.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                bbItemLop.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                bbItemSuKien.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                bbItemPhongHoc.Border = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            }
            if (rptType == REPORT_TYPE.THEO_SUKIEN)
            {
                bbItemGiaoVien.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                bbItemLop.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                bbItemSuKien.Border = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
                bbItemPhongHoc.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            }
        }

        private void bbItemLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (objTKB == null) return;
            DataTable dt = objTKB.Baocao_TKB_Lop();
            Show_Lop(dt);
            SoSuKienChuaXepLich();
            SetButton();
        }

        private void bbItemGiaoVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (objTKB == null) return;
            DataTable dt = objTKB.Baocao_TKB_giaovien();
            show_giaovien(dt);
            SoSuKienChuaXepLich();
            SetButton();
        }

        private void bbItemPhongHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (objTKB == null) return;
            DataTable dt = objTKB.Baocao_TKB_phong();
            show_PhongHoc(dt);
            SoSuKienChuaXepLich();
            SetButton();
        }

        private void bbAuto_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (objTKB == null) return;
            objTKB.XepLichTuDong();
            show_sukien(objTKB.sks.ToTable(true, true));
            SoSuKienChuaXepLich();
        }

        private void show_sukien(DataTable dt)
        {
            rptType = REPORT_TYPE.THEO_SUKIEN;
            fg.AllowEditing = true;
            fg.Rows.Fixed = 1;
            fg.Cols.Fixed = 0;

            fg.DataSource = dt;

            fg.Rows[0].TextAlign = TextAlignEnum.CenterCenter;
            fg.Rows[0].Height = 20;

            fg.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            fg.Cols[0].Width = 30;

            // Ẩn các cột
            fg.Cols["XL_SuKienTKBID"].Visible = false;
            fg.Cols["Idx"].Visible = false;
            fg.Cols["IDDM_Lop"].Visible = false;
            fg.Cols["IDXL_MonHocTrongKy"].Visible = false;
            fg.Cols["IDDM_MonHoc"].Visible = false;
            fg.Cols["IDDM_PhongHoc"].Visible = false;
            fg.Cols["IDNS_GiaoVien"].Visible = false;
            //fg.Cols["Thu"].Visible = false;
            //fg.Cols["TietDau"].Visible = false;
            fg.Cols["Changed"].Visible = false;

            // Chiều rộng cột
            fg.Cols["TenLop"].Width = 120;
            // Tiêu đề cột
            fg.Cols["TenLop"].Caption = "Tên lớp";
            fg.Cols["TenMonHoc"].Caption = "Tên môn học";
            fg.Cols["TenGiaoVien"].Caption = "Họ tên GV";
            fg.Cols["TenPhongHoc"].Caption = "Phòng học";
            fg.Cols["TenVietTat"].Caption = "Tên viết tắt";
            fg.Cols["CaHoc"].Caption = "Ca học";
            fg.Cols["SoTiet"].Caption = "Số tiết";
            fg.Cols["Thu"].Caption = "Thứ";
            fg.Cols["TietDau"].Caption = "Tiết đầu";
            fg.Cols["LoaiTiet"].Caption = "Loại tiết";
            fg.Cols["ThieuDuLieu"].Caption = "Thiếu dữ liệu";
            fg.Cols["DaXepLich"].Caption = "Đã xếp lịch";
            fg.Cols["KyHieu"].Caption = "Ký hiệu";
            fg.Cols["Locked"].Caption = "Khóa";
            AllowEdit();
        }

        private void AllowEdit()
        {
            for (int i = 0; i < fg.Cols.Count; i++)
            {
                if (fg.Cols[i].Name != "Chon")
                    fg.Cols[i].AllowEditing = false;
                else
                    fg.Cols["Chon"].AllowEditing = true;
            }
        }

        public void show_PhongHoc(DataTable dt)
        {
            Loaded = false;
            Cursor currentCursor = System.Windows.Forms.Cursor.Current;
            try
            {
                CreateWaitDialog();
                Application.DoEvents();

                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

                rptType = REPORT_TYPE.THEO_PHONG;
                fg.AllowEditing = false;
                fg.Rows.Fixed = 3;
                fg.Cols.Fixed = 3;
                fg.DataSource = dt;
                // Fixed area
                fg.Cols["STT"].Visible = false;
                fg.Cols["TenPhongHoc"].Visible = false;
                fg.Cols["IDDM_PhongHoc"].Visible = false;

                fg.Cols[1].TextAlign = TextAlignEnum.LeftCenter;

                for (int i = fg.Rows.Fixed; i <= fg.Rows.Count - 1; i++)
                {
                    fg[i, 0] = dt.Rows[i - fg.Rows.Fixed]["STT"].ToString();
                    fg[i, 1] = dt.Rows[i - fg.Rows.Fixed]["TenPhongHoc"].ToString();
                    //fg[i, 2] = dt.Rows[i - fg.Rows.Fixed]["IDPhongHoc"].ToString();
                    fg.Rows[i].AllowMerging = true;
                }
                for (int i = 3; i <= dt.Columns.Count - 1; i++)
                {
                    string[] s = dt.Columns[i].ColumnName.Split('.');
                    fg[0, fg.Cols.Fixed + i] = objTKB.GetThu(int.Parse(s[0]));
                    fg[1, fg.Cols.Fixed + i] = objTKB.GetCa(int.Parse(s[1]));
                    fg[2, fg.Cols.Fixed + i] = int.Parse(s[2]);
                    fg.Cols[i].AllowMerging = false;
                }
                fg[0, 0] = "STT";
                fg[1, 0] = "STT";
                fg[2, 0] = "STT";
                fg[0, 1] = "Phòng học";
                fg[1, 1] = "Phòng học";
                fg[2, 1] = "Phòng học";
                fg[0, 2] = "IDDM_PhongHoc";
                fg[1, 2] = "IDDM_PhongHoc";
                fg[2, 2] = "IDDM_PhongHoc";
                Set_WidHei();
                fg.AllowMerging = AllowMergingEnum.Free;
                Allow_merge();
                CellRange cr = default(CellRange);
                for (int i = 3; i <= fg.Rows.Count - 1; i++)
                {
                    // dt.Rows.Count - 1
                    for (int j = fg.Cols.Fixed + 3; j <= fg.Cols.Count - 1; j++)
                    {
                        // dt.Columns.Count - 1
                        cr = fg.GetCellRange(i, j);
                        if (!(fg[i, j].ToString() == string.Empty))
                        {
                            cr.Style = fg.Styles["TKB_Style"];
                            string[] str = cr.Data.ToString().Split('@');
                            cr.Data = str[1];
                            cr.UserData = str[0];
                        }
                    }
                }

                //DataTable dtb = (DataTable)fg.DataSource;

                System.Windows.Forms.Cursor.Current = currentCursor;
                CloseWaitDialog();
                Loaded = true;
            }
            catch
            {
                System.Windows.Forms.Cursor.Current = currentCursor;
                CloseWaitDialog();

            }
        }

        public void show_giaovien(DataTable dt)
        {
            Loaded = false;
            Cursor currentCursor = System.Windows.Forms.Cursor.Current;
            try
            {
                CreateWaitDialog();
                Application.DoEvents();

                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

                rptType = REPORT_TYPE.THEO_GIAOVIEN;
                fg.AllowEditing = false;
                fg.Rows.Fixed = 3;
                fg.Cols.Fixed = 3;
                fg.DataSource = dt;
                // Fixed area
                fg.Cols["STT"].Visible = false;
                fg.Cols["TenGiaoVien"].Visible = false;
                fg.Cols["IDNS_GiaoVien"].Visible = false;

                fg.Cols[1].TextAlign = TextAlignEnum.LeftCenter;

                for (int i = fg.Rows.Fixed; i <= fg.Rows.Count - 1; i++)
                {
                    fg[i, 0] = dt.Rows[i - fg.Rows.Fixed]["STT"].ToString();
                    fg[i, 1] = EncodeString(dt.Rows[i - fg.Rows.Fixed]["TenGiaoVien"].ToString(), i);
                    //fg[i, 2] = dt.Rows[i - fg.Rows.Fixed]["IDGiaoVien"].ToString();
                    fg.Rows[i].AllowMerging = true;
                }
                for (int i = 3; i <= dt.Columns.Count - 1; i++)
                {
                    string[] s = dt.Columns[i].ColumnName.Split('.');
                    fg[0, fg.Cols.Fixed + i] = objTKB.GetThu(int.Parse(s[0]));
                    fg[1, fg.Cols.Fixed + i] = objTKB.GetCa(int.Parse(s[1]));
                    fg[2, fg.Cols.Fixed + i] = int.Parse(s[2]);
                    fg.Cols[i].AllowMerging = false;
                }
                fg[0, 0] = "STT";
                fg[1, 0] = "STT";
                fg[2, 0] = "STT";
                fg[0, 1] = "Giáo Viên";
                fg[1, 1] = "Giáo Viên";
                fg[2, 1] = "Giáo Viên";
                fg[0, 2] = "IDNS_GiaoVien";
                fg[1, 2] = "IDNS_GiaoVien";
                fg[2, 2] = "IDNS_GiaoVien";
                Set_WidHei();
                fg.AllowMerging = AllowMergingEnum.Free;
                Allow_merge();
                CellRange cr = default(CellRange);
                for (int i = 3; i <= fg.Rows.Count - 1; i++)
                {
                    for (int j = fg.Cols.Fixed + 3; j <= fg.Cols.Count - 1; j++)
                    {
                        cr = fg.GetCellRange(i, j);
                        if (!(fg[i, j].ToString() == string.Empty))
                        {
                            string[] str = cr.Data.ToString().Split('@');
                            if (str[0] == "-1")
                            {
                                cr.Style = fg.Styles["ReadOnly_Style"];
                            }
                            else
                            {
                                cr.Style = fg.Styles["TKB_Style"];
                            }
                            cr.Data = str[1];
                            cr.UserData = str[0];
                        }
                    }
                }
                System.Windows.Forms.Cursor.Current = currentCursor;
                CloseWaitDialog();
                Loaded = true;
            }
            catch
            {
                System.Windows.Forms.Cursor.Current = currentCursor;
                CloseWaitDialog();

            }
        }

        private void Show_Lop(DataTable dt)
        {
            Loaded = false;
            Cursor currentCursor = System.Windows.Forms.Cursor.Current;
            try
            {
                CreateWaitDialog();
                Application.DoEvents();
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

                rptType = REPORT_TYPE.THEO_LOP;
                fg.AllowEditing = false;
                fg.Rows.Fixed = 3;
                fg.Cols.Fixed = 3;
                fg.DataSource = dt;
                // Fixed area
                fg.Cols["STT"].Visible = false;
                fg.Cols["TenLop"].Visible = false;
                fg.Cols["IDDM_Lop"].Visible = false;

                fg.Cols[1].TextAlign = TextAlignEnum.LeftCenter;

                for (int i = fg.Rows.Fixed; i <= fg.Rows.Count - 1; i++)
                {
                    fg[i, 0] = dt.Rows[i - fg.Rows.Fixed]["STT"].ToString();
                    fg[i, 1] = dt.Rows[i - fg.Rows.Fixed]["TenLop"].ToString();
                    fg.Rows[i].AllowMerging = true;
                }
                for (int i = 3; i <= dt.Columns.Count - 1; i++)
                {
                    string[] s = dt.Columns[i].ColumnName.Split('.');
                    fg[0, fg.Cols.Fixed + i] = objTKB.GetThu(int.Parse(s[0]));
                    fg[1, fg.Cols.Fixed + i] = objTKB.GetCa(int.Parse(s[1]));
                    fg[2, fg.Cols.Fixed + i] = int.Parse(s[2]);
                    fg.Cols[i].AllowMerging = false;
                }

                fg[0, 0] = "STT";
                fg[1, 0] = "STT";
                fg[2, 0] = "STT";
                fg[0, 1] = "Tên lớp";
                fg[1, 1] = "Tên lớp";
                fg[2, 1] = "Tên lớp";
                fg[0, 2] = "IDDM_Lop";
                fg[1, 2] = "IDDM_Lop";
                fg[2, 2] = "IDDM_Lop";
                Set_WidHei();
                fg.AllowMerging = AllowMergingEnum.Free;
                Allow_merge();
                CellRange cr = default(CellRange);
                for (int i = 3; i <= fg.Rows.Count - 1; i++)
                {
                    for (int j = fg.Cols.Fixed + 3; j <= fg.Cols.Count - 1; j++)
                    {
                        cr = fg.GetCellRange(i, j);
                        if (!(fg[i, j].ToString() == string.Empty))
                        {
                            string[] str = cr.Data.ToString().Split('@');
                            if (str[0] == "-2")
                            {
                                cr.Style = fg.Styles["TKB_Special"];
                            }
                            else if(str[0] == "-1")
                            {
                                cr.Style = fg.Styles["ReadOnly_Style"];
                            }
                            else
                            {
                                cr.Style = fg.Styles["TKB_Style"];
                            }
                            cr.Data = str[1];
                            cr.UserData = str[0];
                        }
                    }
                }
                System.Windows.Forms.Cursor.Current = currentCursor;
                CloseWaitDialog();
                Loaded = true;
            }
            catch
            {
                System.Windows.Forms.Cursor.Current = currentCursor;
                CloseWaitDialog();
            }
        }
        #endregion

        #region Xử lý kéo thả

        /// <summary>
        /// Set các ô có thể kéo thả vào
        /// </summary>
        /// <param name="val"></param>
        private void SetMask(bool val)
        {
            try
            {
                DataTable dt = (DataTable)fg.DataSource;
                if (rptType == REPORT_TYPE.THEO_PHONG)
                {
                    for (int j = 0; j <= dt.Rows.Count - 1; j++)
                    {
                        if (int.Parse(dt.Rows[j]["IDD_PhongHoc"].ToString()) == objTKB.sks[IDX].IDDM_PhongHoc)
                        {
                            for (int i = 0; i <= _mask.Count - 1; i++)
                            {
                                Point p = (Point)_mask[i];
                                if (val)
                                {
                                    if ((fg[j + 3, p.X * Program.pgrThamSo.SO_TIET_NGAY + p.Y + 3 + fg.Cols.Fixed].ToString() == string.Empty))
                                    {
                                        fg.SetCellStyle(j + 3, p.X * Program.pgrThamSo.SO_TIET_NGAY + p.Y + 3 + fg.Cols.Fixed, fg.Styles["Free_Style"]);
                                    }
                                    else
                                    {
                                        fg.SetCellStyle(j + 3, p.X * Program.pgrThamSo.SO_TIET_NGAY + p.Y + 3 + fg.Cols.Fixed, fg.Styles["SWap_Style"]);
                                    }
                                }
                                else
                                {
                                    if ((fg[j + 3, p.X * Program.pgrThamSo.SO_TIET_NGAY + p.Y + 3 + fg.Cols.Fixed].ToString() == string.Empty))
                                    {
                                        fg.SetCellStyle(j + 3, p.X * Program.pgrThamSo.SO_TIET_NGAY + p.Y + 3 + fg.Cols.Fixed, fg.Styles["Normal_Style"]);
                                    }
                                }
                            }
                        }
                    }
                }
                if (rptType == REPORT_TYPE.THEO_GIAOVIEN)
                {
                    for (int j = 0; j <= dt.Rows.Count - 1; j++)
                    {
                        if (int.Parse(dt.Rows[j]["IDNS_GiaoVien"].ToString()) == objTKB.sks[IDX].IDNS_GiaoVien)
                        {
                            for (int i = 0; i <= _mask.Count - 1; i++)
                            {
                                Point p = (Point)_mask[i];
                                if (val)
                                {
                                    if ((fg[j + 3, p.X * Program.pgrThamSo.SO_TIET_NGAY + p.Y + 3 + fg.Cols.Fixed].ToString() == string.Empty))
                                    {
                                        fg.SetCellStyle(j + 3, p.X * Program.pgrThamSo.SO_TIET_NGAY + p.Y + 3 + fg.Cols.Fixed, fg.Styles["Free_Style"]);
                                    }
                                    else
                                    {
                                        fg.SetCellStyle(j + 3, p.X * Program.pgrThamSo.SO_TIET_NGAY + p.Y + 3 + fg.Cols.Fixed, fg.Styles["SWap_Style"]);                                    
                                    }
                                }
                                else
                                {
                                    if ((fg[j + 3, p.X * Program.pgrThamSo.SO_TIET_NGAY + p.Y + 3 + fg.Cols.Fixed].ToString() == string.Empty))
                                    {
                                        fg.SetCellStyle(j + 3, p.X * Program.pgrThamSo.SO_TIET_NGAY + p.Y + 3 + fg.Cols.Fixed, fg.Styles["Normal_Style"]);
                                    }
                                }
                            }
                        }
                    }
                }
                if (rptType == REPORT_TYPE.THEO_LOP)
                {
                    for (int j = 0; j <= dt.Rows.Count - 1; j++)
                    {
                        if (int.Parse(dt.Rows[j]["IDDM_Lop"].ToString()) == (int)objTKB.sks[IDX].IDDM_Lop)
                        {
                            for (int i = 0; i <= _mask.Count - 1; i++)
                            {
                                Point p = (Point)_mask[i];
                                if (val)
                                {
                                    if ((fg[j + 3, p.X * Program.pgrThamSo.SO_TIET_NGAY + p.Y + 3 + fg.Cols.Fixed].ToString() == string.Empty))
                                    {
                                        fg.SetCellStyle(j + 3, p.X * Program.pgrThamSo.SO_TIET_NGAY + p.Y + 3 + fg.Cols.Fixed, fg.Styles["Free_Style"]);
                                    }
                                    else
                                    {
                                        fg.SetCellStyle(j + 3, p.X * Program.pgrThamSo.SO_TIET_NGAY + p.Y + 3 + fg.Cols.Fixed, fg.Styles["SWap_Style"]);
                                    }
                                }
                                else
                                {
                                    if ((fg[j + 3, p.X * Program.pgrThamSo.SO_TIET_NGAY + p.Y + 3 + fg.Cols.Fixed].ToString() == string.Empty))
                                    {
                                        fg.SetCellStyle(j + 3, p.X * Program.pgrThamSo.SO_TIET_NGAY + p.Y + 3 + fg.Cols.Fixed, fg.Styles["Normal_Style"]);
                                    }
                                    else
                                    {
                                        fg.SetCellStyle(j + 3, p.X * Program.pgrThamSo.SO_TIET_NGAY + p.Y + 3 + fg.Cols.Fixed, fg.Styles["TKB_Style"]);
                                    }
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void fg_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                if (IDX == -1)
                    return;
                _mask = null;
                _mask = objTKB.List_free_cell(IDX);
                if (_mask != null)
                {
                    SetMask(true);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void fg_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (fg.HitTest().Column > 2 & fg.HitTest().Row > 2)
                {
                    if (rptType == REPORT_TYPE.THEO_SUKIEN) return;
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        if (!string.IsNullOrEmpty(cr1.Data.ToString()))
                        {
                            IDX = int.Parse(cr1.UserData.ToString());
                            if (IDX != -1)
                                fg.DoDragDrop(sender, DragDropEffects.Copy);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        private void fg_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (fg.HitTest().Column > 2 & fg.HitTest().Row > 2)
                {
                    cr1 = fg.GetCellRange(fg.MouseRow, fg.MouseCol);
                    DoiCho = 1;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void fg_SelChange(object sender, EventArgs e)
        {
            if (Loaded == false) return;

            if (objTKB == null) return;

            if (rptType == REPORT_TYPE.THEO_SUKIEN) return;

            if (fg.RowSel < 3) return;

            try
            {
                if (rptType == REPORT_TYPE.THEO_PHONG)
                {
                    int _ID = int.Parse(fg.Rows[fg.RowSel]["IDDM_PhongHoc"].ToString());
                    fgsk.DataSource = objTKB.Danhsach_SuKienChuaXepLich_Phong(_ID);
                }
                if (rptType == REPORT_TYPE.THEO_GIAOVIEN)
                {
                    int _ID = int.Parse(fg.Rows[fg.RowSel]["IDNS_GiaoVien"].ToString());
                    fgsk.DataSource = objTKB.Danhsach_SuKienChuaXepLich_GiaoVien(_ID);
                }
                if (rptType == REPORT_TYPE.THEO_LOP)
                {
                    int _ID = int.Parse(fg.Rows[fg.RowSel]["IDDM_Lop"].ToString());
                    fgsk.DataSource = objTKB.Danhsach_SuKienChuaXepLich_Lop(_ID);
                }
                Formatfgsk();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
        }

        private void fg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (rptType == REPORT_TYPE.THEO_SUKIEN) return;
                // Neu khong phai view theo Giao vien, Phong hoc, Lop thi khon cho xoa
                if (fg.RowSel == 0) return;
                if (fg.ColSel <= 1) return;
                if (fg[fg.RowSel, fg.ColSel].ToString() == string.Empty) return;
                CellRange cr = default(CellRange);
                cr = fg.GetCellRange(fg.RowSel, fg.ColSel);
                if (int.Parse(cr.UserData.ToString()) < 0) return;
                // Neu cell ko co du lieu thi return
                if (XtraMessageBox.Show("Chắc chắn bạn muốn xoá sự kiện này không?", "TVSchool question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        
                        string[] strThuCaTiet = null;
                        strThuCaTiet = (fg.Cols[fg.ColSel].Name.ToString()).Split('.');
                        int thu = int.Parse(strThuCaTiet[0]);
                        int tiet = int.Parse(strThuCaTiet[2]) - 1;
                        
                        int SoTiet = 0;
                        int TietDau = objTKB.HuyLich(int.Parse(cr.UserData.ToString()), thu, tiet, ref SoTiet);
                        //fg.SetCellStyle(fg.RowSel, fg.ColSel, fg.Styles["Normal_Style"]);
                        //cr.Data = "";
                        //cr.UserData = "";
                        // Nếu kết quả trả về lớn hơn 0 thì ta xóa các ô tiết cùng nhóm tiết
                        for (int c = fg.ColSel - (tiet - TietDau); c < (fg.ColSel - (tiet - TietDau)) + SoTiet; c++)
                        {
                            cr = fg.GetCellRange(fg.RowSel, c);
                            fg.SetCellStyle(fg.RowSel, c, fg.Styles["Normal_Style"]);
                            cr.Data = "";
                            cr.UserData = "";
                        }
                        if (rptType == REPORT_TYPE.THEO_PHONG)
                        {
                            int _ID = int.Parse(fg.Rows[fg.RowSel]["IDDM_PhongHoc"].ToString());
                            fgsk.DataSource = objTKB.Danhsach_SuKienChuaXepLich_Phong(_ID);
                        }
                        if (rptType == REPORT_TYPE.THEO_GIAOVIEN)
                        {
                            int _ID = int.Parse(fg.Rows[fg.RowSel]["IDNS_GiaoVien"].ToString());
                            fgsk.DataSource = objTKB.Danhsach_SuKienChuaXepLich_GiaoVien(_ID);
                        }
                        if (rptType == REPORT_TYPE.THEO_LOP)
                        {
                            int _ID = int.Parse(fg.Rows[fg.RowSel]["IDDM_Lop"].ToString());
                            fgsk.DataSource = objTKB.Danhsach_SuKienChuaXepLich_Lop(_ID);
                        }
                        Formatfgsk();
                        SoSuKienChuaXepLich();
                    }
                    catch (Exception ex)
                    {
                        ThongBao(ex.Message);
                    }
                }
            }
        }

        private void fg_DragLeave(object sender, EventArgs e)
        {
            if (_mask != null)
            {
                SetMask(false);
            }
        }

        private void fgsk_MouseDown(object sender, MouseEventArgs e)
        {
            DataTable dt = (DataTable)fgsk.DataSource;
            if (dt == null) return;
            if (dt.Rows.Count == 0) return;
            txtGiaoVien.Text = dt.Rows[fgsk.RowSel - 1]["TenGiaoVien"].ToString();
            txtLop.Text = dt.Rows[fgsk.RowSel - 1]["TenLop"].ToString();
            txtPhongHoc.Text = dt.Rows[fgsk.RowSel - 1]["TenPhong"].ToString();
            if (fgsk.MouseRow <= 0) return;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                DoiCho = 0;
                try
                {
                    IDX = int.Parse(fgsk[fgsk.MouseRow, "IDX"].ToString());
                    fgsk.DoDragDrop(sender, DragDropEffects.Copy);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString());
                }
            }
        }

        private void fg_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (rptType == REPORT_TYPE.THEO_SUKIEN) return;
                if (objTKB.sks[IDX].ThieuDuLieu == true)
                {
                    SetMask(false);
                    ThongBao("Sự kiện không đủ dữ liệu !");
                    return;
                }
                int _ID = 0;
                if (rptType == REPORT_TYPE.THEO_GIAOVIEN)
                {
                    _ID = int.Parse(fg.Rows[fg.MouseRow]["IDNS_GiaoVien"].ToString());
                    if (_ID != objTKB.sks[IDX].IDNS_GiaoVien)
                    {
                        SetMask(false);
                        ThongBao("Không thêt xếp lịch tai ô này !");
                        return;
                    }
                }

                if (rptType == REPORT_TYPE.THEO_LOP)
                {
                    _ID = int.Parse(fg.Rows[fg.MouseRow]["IDDM_Lop"].ToString());
                    if (_ID != objTKB.sks[IDX].IDDM_Lop)
                    {
                        SetMask(false);
                        ThongBao("Không thể xếp lịch tại ô này !");
                        return;
                    }
                }
                if (rptType == REPORT_TYPE.THEO_PHONG)
                {
                    _ID = int.Parse(fg.Rows[fg.MouseRow]["IDDM_PhongHoc"].ToString());
                    if (_ID != objTKB.sks[IDX].IDDM_PhongHoc)
                    {
                        SetMask(false);
                        ThongBao("không thể xếp lịch vào ô này !");
                        return;
                    }
                }
                if (fg.HitTest().Column < 2 | fg.HitTest().Row < 2)
                {
                    ThongBao("Bạn phải thả vào ô thứ và tiết !");
                    return;
                }
                CellRange cr = default(CellRange);
                cr = fg.GetCellRange(fg.MouseRow, fg.MouseCol);
                int SoTiet = 0;
                if (DoiCho == 1)
                {
                    // trường hợp đã xếp lịch và đổi chỗ 2 ô cho nhau
                    // Khi đổi chỗ 2 sự kiện đã xếp lịch thì phải hủy lịch tại 2 ô đó
                    // Hủy sự kiện gốc
                    string[] strThuCaTiet = null;
                    // Xác định thứ của ô cr1
                    strThuCaTiet = (fg.Cols[cr1.LeftCol].Name.ToString()).Split('.');
                    int thuGoc = int.Parse(strThuCaTiet[0]);
                    int tietGoc = int.Parse(strThuCaTiet[2]) - 1;
                    if (cr.Data.ToString() != string.Empty)
                    {
                        // Trường hợp đổi chỗ cho hai ô đã xếp lịch
                        int IDX1 = int.Parse(cr.UserData.ToString());
                        if (IDX1 != IDX)
                        {
                            int TietDau = objTKB.HuyLich(IDX, thuGoc, tietGoc, ref SoTiet);
                            // Hủy sự kiện đích
                            strThuCaTiet = null;
                            strThuCaTiet = (fg.Cols[cr.LeftCol].Name.ToString()).Split('.');

                            int thu1 = int.Parse(strThuCaTiet[0]);
                            int tiet1 = int.Parse(strThuCaTiet[2]) - 1;
                            int SoTiet1 = 0;
                            int TietDau1 = objTKB.HuyLich(IDX1, thu1, tiet1, ref SoTiet1);

                            // Kiểm tra xem có xếp lịch được tại hai ô đó không nếu một trong hai ô đó không xếp lịch được thì quay lại từ đầu                            
                            if (objTKB.ChoPhepXepLich(IDX, thu1, TietDau1) == "" & objTKB.ChoPhepXepLich(IDX1, thuGoc, TietDau) == "")
                            {
                                CellRange crSwap = default(CellRange);
                                objTKB.ChayXepLich(IDX, thu1, TietDau1);
                                objTKB.ChayXepLich(IDX1, thuGoc, TietDau);
                                int c = cr.LeftCol - (tiet1 - TietDau1);
                                int cGoc = cr1.LeftCol - (tietGoc - TietDau);
                                // Gán kết quả hiển thị các sự kiện đã được đổi chỗ lên grid
                                for (int i = c; i < c + SoTiet; i++)
                                {
                                    crSwap = fg.GetCellRange(cr.TopRow, i);
                                    LoadDuLieuChoCell(crSwap, IDX, _ID);
                                }
                                for (int i = cGoc; i < cGoc + SoTiet1; i++)
                                {
                                    crSwap = fg.GetCellRange(cr1.TopRow, i);
                                    LoadDuLieuChoCell(crSwap, IDX1, _ID);
                                }
                                // Xóa hiển thị tiết thừa sau khi đổi chỗ
                                if (SoTiet != SoTiet1)
                                {
                                    if (SoTiet < SoTiet1)
                                        crSwap = fg.GetCellRange(cr1.TopRow, c + SoTiet);
                                    else
                                        crSwap = fg.GetCellRange(cr.TopRow, cGoc + SoTiet1);

                                    crSwap.Data = "";
                                    crSwap.UserData = "";
                                    crSwap.Style = fg.Styles["Normal_Style"];
                                }
                                ThongBao("Đổi lịch thành công !");
                            }
                            else
                            {
                                objTKB.ChayXepLich(IDX, thuGoc, tietGoc);
                                objTKB.ChayXepLich(IDX1, thu1, tiet1);
                                ThongBao("Đổi lịch không thành công !");
                            }
                        }
                    }
                    else
                    {
                        //trường hợp kéo ô đã xếp lịch sang ô trống.
                        int TietDau = objTKB.HuyLich(IDX, int.Parse(strThuCaTiet[0]), int.Parse(strThuCaTiet[2]) - 1, ref SoTiet);
                        
                        // Thứ tiết của cell chuyển sự kiện đến
                        strThuCaTiet = null;
                        strThuCaTiet = (fg.Cols[fg.MouseCol].Name.ToString()).Split('.');

                        int thu = int.Parse(strThuCaTiet[0]);
                        int tiet = int.Parse(strThuCaTiet[2]) - 1;
                        string _return = objTKB.ChoPhepXepLich(IDX, thu, tiet);
                        if (_return == "")
                        {
                            // Xóa sự kiện đã xếp lịch
                            // Set Normal_Style
                            CellRange crTiet2 = default(CellRange);
                            for (int c = cr1.LeftCol - (tietGoc - TietDau); c < (cr1.LeftCol - (tietGoc - TietDau)) + SoTiet; c++)
                            {
                                crTiet2 = fg.GetCellRange(cr1.TopRow, c);
                                crTiet2.Data = "";
                                crTiet2.UserData = "";
                                crTiet2.Style = fg.Styles["Normal_Style"];
                            }

                            // Xếp lịch cho sự kiện được kéo tại ô mới.
                            // Set TKB_Style
                            objTKB.ChayXepLich(IDX, thu, tiet);
                            for (int i = 0; i < SoTiet; i++)
                            {
                                //Set Style cho ô tiết thứ 2
                                CellRange crTiet2New = default(CellRange);
                                crTiet2New = fg.GetCellRange(fg.MouseRow, fg.MouseCol + i);
                                LoadDuLieuChoCellTiet2(crTiet2New, IDX);
                                crTiet2New.Style = fg.Styles["TKB_Style"];
                            }
                        }
                        else
                        {
                            objTKB.ChayXepLich(IDX, thuGoc, tietGoc);
                            ThongBao(_return);
                        }
                    }
                }
                else
                {
                    //ArrayList arrThuCaTiet = new ArrayList();
                    string[] strThuCaTiet = null;
                    strThuCaTiet = (fg.Cols[fg.MouseCol].Name.ToString()).Split('.');
                    //foreach (string str in strThuCaTiet)
                    //{
                    //    arrThuCaTiet.Add(str);
                    //}
                    int thu = int.Parse(strThuCaTiet[0]);
                    int tiet = int.Parse(strThuCaTiet[2]) - 1;
                    string _return = objTKB.ChoPhepXepLich(IDX, thu, tiet);

                    if (_return == "")
                    {
                        objTKB.ChayXepLich(IDX, thu, objTKB.scE.arrTiet[0]);
                        CellRange crTiet = default(CellRange);
                        for (int j = 0; j < objTKB.scE.arrTiet.Length; j++)
                        {
                            crTiet = fg.GetCellRange(fg.MouseRow, fg.MouseCol + j);
                            if (j == 0)
                            {
                                LoadDuLieuChoCell(crTiet, IDX, _ID);
                            }
                            else
                            {
                                LoadDuLieuChoCellTiet2(crTiet, IDX);
                            }
                            //Set Style cho ô được chọn
                            crTiet.Style = fg.Styles["TKB_Style"];
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(_return);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            SetMask(false);
            DoiCho = 0;
            SoSuKienChuaXepLich();
        }

        private void fg_DragOver(object sender, DragEventArgs e)
        {
            if (fg.HitTest().Column > 2 & fg.HitTest().Row > 2)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        #endregion


        private void SoSuKienChuaXepLich()
        {
            bbItemSoSuKien.EditValue = objTKB.So_su_kien_chua_xep_lich().ToString() + " / " + objTKB.sks.Count.ToString();
            if (rptType != REPORT_TYPE.THEO_SUKIEN)
                dockPanelSuKienChuaXepLich.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            else
                dockPanelSuKienChuaXepLich.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
        }

        private void beItemZoom_EditValueChanged(object sender, EventArgs e)
        {
            for (int i = colbegin; i <= fg.Cols.Count - 1; i++)
            {
                //Tính giá trị tương ứng
                int value = (int)zoom.Value;
                fg.Cols[i].Width = int.Parse((colWidth * (double)((value / 10.0))).ToString());
            }
        }

        private void LoadDuLieuChoCell(CellRange cr, int idx, int _ID)
        {
            if (rptType == REPORT_TYPE.THEO_PHONG)
            {
                // Lấy dữ liệu theo IDX
                string[] strData = Thongtin_phong(idx).Split('@');
                cr.Data = strData[1];
                cr.UserData = strData[0];
                fgsk.DataSource = objTKB.Danhsach_SuKienChuaXepLich_Phong(_ID);
            }
            if (rptType == REPORT_TYPE.THEO_GIAOVIEN)
            {
                string[] strData = Thongtin_gv(idx).Split('@');
                cr.Data = strData[1];
                cr.UserData = strData[0];
                fgsk.DataSource = objTKB.Danhsach_SuKienChuaXepLich_GiaoVien(_ID);
            }
            if (rptType == REPORT_TYPE.THEO_LOP)
            {
                string[] strData = Thongtin_lop(idx).Split('@');
                cr.Data = strData[1];
                cr.UserData = strData[0];
                fgsk.DataSource = objTKB.Danhsach_SuKienChuaXepLich_Lop(_ID);
            }
            Formatfgsk();
        }

        private void LoadDuLieuChoCellTiet2(CellRange cr, int idx)
        {
            if (rptType == REPORT_TYPE.THEO_PHONG)
            {
                // Lấy dữ liệu theo IDX
                string[] strData = Thongtin_phong(idx).Split('@');
                cr.Data = strData[1];
                cr.UserData = strData[0];
            }
            if (rptType == REPORT_TYPE.THEO_GIAOVIEN)
            {
                string[] strData = Thongtin_gv(idx).Split('@');
                cr.Data = strData[1];
                cr.UserData = strData[0];
            }
            if (rptType == REPORT_TYPE.THEO_LOP)
            {
                string[] strData = Thongtin_lop(idx).Split('@');
                cr.Data = strData[1];
                cr.UserData = strData[0];
            }
        }

        private void Formatfgsk()
        {
            fgsk.Cols["IDX"].Visible = false;
            fgsk.Cols["TenMon"].Caption = "Môn học";
            fgsk.Cols["TenLop"].Caption = "Lớp";
            fgsk.Cols["TenPhong"].Caption = "Phòng học";
            fgsk.Cols["TenGiaoVien"].Caption = "Giáo viên";
            fgsk.Cols["SoTiet"].Caption = "Số tiết";
            fgsk.Cols["CaHoc"].Caption = "Buổi học";
        }

        public string Thongtin_phong(int idx)
        {
            XL_SuKienTKBInfo sk = (XL_SuKienTKBInfo)objTKB.sks[idx];
            return idx + "@" + sk.TenLop + "\n" + (sk.KyHieu == "" ? sk.TenMon : sk.KyHieu) +
                "\n" + (sk.TenVietTat == "" ? sk.TenGiaoVien : sk.TenVietTat);
            // return idx + "@" + sk.TenLop + "\n" + sk.TenMon + "\n" + strHlp.FormatTenVietTat(sk.TenGiaoVien);
        }
        public string Thongtin_lop(int idx)
        {
            XL_SuKienTKBInfo sk = (XL_SuKienTKBInfo)objTKB.sks[idx];
            return idx + "@" + (sk.KyHieu == "" ? sk.TenMon : sk.KyHieu) + "\n" + sk.TenPhong +
                    "\n" + (sk.TenVietTat == "" ? sk.TenGiaoVien : sk.TenVietTat);
            // return idx + "@" + sk.TenMon + "\n" + sk.TenPhong + "\n" + strHlp.FormatTenVietTat(sk.TenGiaoVien);
        }
        public string Thongtin_gv(int idx)
        {
            // Tất cả các hàm đều sử dụng hàm này để lấy thông tin về giáo viên 
            // bao gồm: Tên lớp ký hiệu tên phòng giảng.......
            XL_SuKienTKBInfo sk = (XL_SuKienTKBInfo)objTKB.sks[idx];
            return idx + "@" + sk.TenLop + "\n" + (sk.KyHieu == "" ? sk.TenMon : sk.KyHieu) + "\n" + sk.TenPhong;
            // return idx + "@" + sk.TenLop + "\n" + sk.TenMon + "\n" + sk.TenPhong;
        }

        private void bbInTKB_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTKB_Print frmPrint = new frmTKB_Print();
            frmPrint.WindowState = FormWindowState.Maximized;
            frmPrint.ShowDialog();
        }

        private void barbtnExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExportFlexGridToXls(fg);
        }

        private void bbHuyLich_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (objTKB != null)
            {
                objTKB.HuyLich();
                show_sukien(objTKB.sks.ToTable(true, true));
                SoSuKienChuaXepLich();
            }
        }

        private void bbLuuTKB_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (objTKB != null)
            {
                objTKB.LuuTKB();
            }
        }

        private void bbApDungNhieuTuan_ItemClick(object sender, ItemClickEventArgs e)
        {
            dlgApDungNhieuTuan dlg = new dlgApDungNhieuTuan(TuanThu);
            dlg.ShowDialog();
            if (int.Parse(dlg.Tag.ToString()) > 0)
            {
                dtTuan.DefaultView.RowFilter = "TuanThu > " + TuanThu.ToString() + " And TuanThu <= " + dlg.Tag.ToString();
                // Lưu lịch của tuần hiện tại
                if (objTKB != null)
                {
                    objTKB.LuuTKB();
                }
                // Khởi tạo lịch của tuần tiếp theo
                // Nếu tuần đó đã có lịch học thì hủy đi, và lưu lại theo lịch của tuần gốc để áp dụng
                for (int t = 0; t < dtTuan.DefaultView.Count; t++)
                {
                    clsTKB objTKB_New = new clsTKB(Program.IDNamHoc, Program.HocKy, int.Parse(dtTuan.DefaultView[t]["XL_TuanID"].ToString()), Program.pgrThamSo);
                    if (objTKB_New != null)
                    {
                        if (objTKB_New.mUpdate == true)
                        {
                            objTKB_New.HuyLich();
                        }
                        // Lưu lại thời khóa biểu tuần này giống với gốc được áp dụng
                        for (int i = 0; i < objTKB.sks.Count; i++)
                        {
                            if (objTKB.sks[i].DaXepLich == true)
                            {
                                for (int j = 0; j < objTKB_New.sks.Count; j++)
                                {
                                    if (objTKB_New.sks[j].DaXepLich == false)
                                    {
                                        if (ChoPhepApDung(objTKB.sks[i], objTKB_New.sks[j]) == true)
                                        {
                                            if (objTKB_New.ChoPhepXepLich(j, objTKB.sks[i].Thu, objTKB.sks[i].TietDau) == "")
                                            {
                                                ApDungSuKien(objTKB.sks[i], objTKB_New.sks[j]);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        objTKB_New.LuuTKB();
                    }
                }
                XtraMessageBox.Show("Đã áp dụng thành công.");
            }
        }

        private bool ChoPhepApDung(XL_SuKienTKBInfo sk, XL_SuKienTKBInfo skNew)
        {
            if (sk.IDDM_PhongHoc == skNew.IDDM_PhongHoc && sk.IDDM_MonHoc == skNew.IDDM_MonHoc 
                && sk.SoTiet == skNew.SoTiet && sk.CaHoc == skNew.CaHoc)
                return true;
            return false;
        }

        private void ApDungSuKien(XL_SuKienTKBInfo sk, XL_SuKienTKBInfo skNew)
        {
            skNew.Thu = sk.Thu;
            skNew.TietDau = sk.TietDau;
            skNew.DaXepLich = true;
        }

        private void fg_MouseUp(object sender, MouseEventArgs e)
        {
            if (rptType == REPORT_TYPE.THEO_SUKIEN)
            {
                if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && fg.ClientRectangle.Contains(e.X, e.Y))
                {
                    popupMenuSK.ShowPopup(MousePosition);
                }
            }
        }

        private void bbXoaSuKien_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CoChon() == true)
            {
                if (XtraMessageBox.Show("Bạn có chắc chắn xóa những sự kiện này không?", "THONG BAO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = fg.Rows.Count - 1; i >= fg.Rows.Fixed; i--)
                    {
                        if (bool.Parse(fg[i, "Chon"].ToString()) == true)
                            objTKB.Delete(int.Parse(fg[i, "STT"].ToString()) - 1);
                    }
                    if (objTKB.mUpdate == true)
                        Reload();
                    else
                    {
                        bbItemSuKien_ItemClick(null, null);
                    }
                    XtraMessageBox.Show("Đã xóa thành công.", "THONG BAO");
                }
            }
            else
                XtraMessageBox.Show("Bạn chưa chọn sự kiện nào.", "THONG BAO");
        }

        private bool CoChon()
        {
            for (int i = fg.Rows.Fixed; i < fg.Rows.Count; i++)
            {
                if (bool.Parse(fg[i, "Chon"].ToString()) == true)
                    return true;
            }
            return false;
        }

        private void popupChuaXepLich_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (objTKB == null) return;
            show_sukien(objTKB.sks.ToTable(false, true));
        }

        private void popupDaXepLich_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (objTKB == null) return;
            show_sukien(objTKB.sks.ToTable(true, false));
        }

        private void popupShowAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (objTKB == null) return;
            show_sukien(objTKB.sks.ToTable(true, true));
        }

        //private void fg_Paint(object sender, PaintEventArgs e)
        //{
        //    if (rptType == REPORT_TYPE.THEO_SUKIEN && Loaded == true)
        //    {
        //        if (((DataTable)fg.DataSource).Rows.Count > 0)
        //        {
        //            ArrayList _al = new ArrayList();
        //            CheckBox chk = new CheckBox();
        //            _al.Add(new HostedControl(fg, chk, 0, 2));
        //            foreach (HostedControl hosted in _al)
        //                hosted.UpdatePosition();
        //        }
        //    }
        //}

        private void barbtnChonTatCa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (fg.Rows.Count > fg.Rows.Fixed)
            {
                if (ChonTatCa == true)
                {
                    CheckAll(false);
                    ChonTatCa = false;
                    barbtnChonTatCa.Caption = "Chọn tất cả";
                }
                else
                {
                    CheckAll(true);
                    ChonTatCa = true;
                    barbtnChonTatCa.Caption = "Bỏ chọn tất cả";
                }
            }
            else
            {
                if (ChonTatCa == true)
                {
                    ChonTatCa = false;
                    barbtnChonTatCa.Caption = "Chọn tất cả";
                }
            }
        }

        private void CheckAll(bool state)
        {
            for (int i = fg.Rows.Fixed; i < fg.Rows.Count; i++)
            {
                fg[i, "Chon"] = state;
            }
        }

        private void fg_DoubleClick(object sender, EventArgs e)
        {
            if (rptType == REPORT_TYPE.THEO_SUKIEN && fg.RowSel >= 0)
            {
                int idx = int.Parse(fg[fg.RowSel, "Idx"].ToString());
                XL_SuKienTKBInfo sk = objTKB.sks[idx];

                dlgTKB_SuaSuKien dlg = new dlgTKB_SuaSuKien(dtTuan, ref sk, TuanID);
                dlg.cmbGiaoVien.Properties.DataSource = objTKB.DanhSachGiaoVien();
                dlg.cmbPhongHoc.Properties.DataSource = objTKB.DanhSachPhongHoc();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    objTKB.ChangeSuKien(ref sk);

                    bbItemSuKien_ItemClick(null, null);
                }
            }
        }
    }
}
