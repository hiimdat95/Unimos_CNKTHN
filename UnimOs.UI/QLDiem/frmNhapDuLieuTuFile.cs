using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace UnimOs.UI
{
    public partial class frmNhapDuLieuTuFile : frmBase
    {
        private System.Data.OleDb.OleDbConnection cnnDuLieuNguon = new System.Data.OleDb.OleDbConnection();
        private DataTable dtDuLieuFile, dtDuLieuNguon, dtTruongAnhXa, dtAnhXa, dtDuLieuChuyenDuoc, dtDuLieuKhongChuyenDuoc;
        private Hashtable htbAnhXa;
        private cBHT_DuLieuNhap oBHT_DuLieuNhap;
        private string LoaiNhap = "";
        //private string MaBatDauTu, PhanDauMa, PhanCuoiMa;
        //private int DoDaiTuTang, DoDaiMa;
        //private bool LapMaTuDong = false;

        public frmNhapDuLieuTuFile()
        {
            InitializeComponent();
            oBHT_DuLieuNhap = new cBHT_DuLieuNhap();
            lciChonLop.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutDonVi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //splitKetQua.SplitterPosition = ScreenWidth / 2;
        }

        public frmNhapDuLieuTuFile(string _LoaiNhap)
        {
            InitializeComponent();
            oBHT_DuLieuNhap = new cBHT_DuLieuNhap();
            lciChonLop.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutDonVi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //splitKetQua.SplitterPosition = ScreenWidth / 2;
            LoaiNhap = _LoaiNhap;
        }

        private void frmNhapDuLieuTuFile_Load(object sender, EventArgs e)
        {
            cBHT_DuLieuNhap oBHT_DuLieuNhap = new cBHT_DuLieuNhap();
            DataTable dtDuLieuNhap = oBHT_DuLieuNhap.TableLoaiNhap();
            cmbNhapDL.Properties.DataSource = dtDuLieuNhap;
            if (LoaiNhap != "")
            {
                cmbNhapDL.EditValue = LoaiNhap;
                cmbNhapDL.Properties.ReadOnly = true;
                if (LoaiNhap == "SV_SinhVienNhapTruong")
                    this.Text = cmbNhapDL.Text + " - Năm học: " + Program.NamHoc;
                else
                    this.Text = cmbNhapDL.Text;
            }
            cmbChonLop.Properties.DataSource = (new cBDM_Lop()).GetTree(Program.NamHoc);
            cmbDonVi.Properties.DataSource = LoadDonVi();
        }

        private void LoadDanhSachMonHoc(int IDDM_Lop)
        {
            DataTable dtMonHoc;
            dtMonHoc = new cBDM_MonHoc().GetMonKyByLop(IDDM_Lop, Program.IDNamHoc, Program.HocKy);
        }

        private bool CheckValid(string ID)
        {
            switch (ID)
            {
                case "Diem_DiemThanhPhan":
                    if (cmbChonLop.EditValue == null)
                    {
                        ThongBao("Bạn chưa chọn lớp nào!");
                        cmbChonLop.Focus();
                        return false;
                    }
                    break;
                case "SV_SinhVien":
                    if (cmbChonLop.EditValue == null)
                    {
                        ThongBao("Bạn chưa chọn lớp nào!");
                        cmbChonLop.Focus();
                        return false;
                    }
                    break;
                //case "DM_Khoi_Lop":
                //    break;
                case "NS_GiaoVien":
                    if (cmbDonVi.EditValue == null)
                    {
                        ThongBao("Bạn chưa chọn đơn vị nào!");
                        cmbDonVi.Focus();
                        return false;
                    }
                    break;
                //case "DM_MonHoc":
                //    break;
                //case "DM_LoaiDiem":
                //    break;
                //case "DM_ThanhPhanDiem":
                //    break;
                case "Diem_DiemThanhPhan_TheoLoaiDiem":
                    if (cmbChonLop.EditValue == null)
                    {
                        ThongBao("Bạn chưa chọn lớp nào!");
                        cmbChonLop.Focus();
                        return false;
                    }
                    break;
            }
            return true;
        }

        private void SetTextInfo(string ID)
        {
            switch (ID)
            {
                case "SV_SinhVienNhapTruong":
                    lblInfo.Text = cmbNhapDL.Text + " Năm học " + Program.NamHoc;
                    break;
                case "SV_SinhVien":
                    lblInfo.Text = cmbNhapDL.Text + " cho lớp " + cmbChonLop.Text;
                    break;
                //case "DM_Khoi_Lop":
                //    oBHT_DuLieuNhap.ChuyenDanhSachLop(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa, Program.IDDM_NamHoc_Truong);
                //    break;
                case "NS_GiaoVien":
                    lblInfo.Text = cmbNhapDL.Text + " cho đơn vị: " + cmbDonVi.Text;
                    break;
                case "DM_MonHoc":
                    lblInfo.Text = cmbNhapDL.Text;
                    break;
                //case "DM_LoaiDiem":
                //    oBHT_DuLieuNhap.ChuyenDanhSachLoaiDiem(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa, Program.IDDM_Truong);
                //    break;
                //case "DM_ThanhPhanDiem":
                //    oBHT_DuLieuNhap.ChuyenDanhSachThanhPhanDiem(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa, Program.IDDM_Truong);
                //    break;
                //case "Diem_DiemThanhPhan_TheoLoaiDiem":
                //    oBHT_DuLieuNhap.ChuyenDiemMonHocTheoLoaiDiem(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa, Program.IDDM_NamHoc_Truong, Program.IDDM_Truong);
                //    break;
                case "DM_TinhHuyenXa":
                    lblInfo.Text = cmbNhapDL.Text;
                    break;
            }
        }

        private void ChuyenDuLieuNhap(string ID)
        {
            switch (ID)
            {
                case "SV_SinhVienNhapTruong":
                    oBHT_DuLieuNhap.ChuyenDuLieuTuyenSinh(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa);
                    break;
                case "SV_SinhVien":
                    oBHT_DuLieuNhap.ChuyenDanhSachSinhVien(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa);
                    break;
                //case "DM_Khoi_Lop":
                //    oBHT_DuLieuNhap.ChuyenDanhSachLop(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa, Program.IDDM_NamHoc_Truong);
                //    break;
                case "NS_GiaoVien":
                    oBHT_DuLieuNhap.ChuyenDanhSachGiaoVien(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa);
                    break;
                case "DM_MonHoc":
                    oBHT_DuLieuNhap.ChuyenDanhSachMonHoc(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa);
                    break;
                //case "DM_LoaiDiem":
                //    oBHT_DuLieuNhap.ChuyenDanhSachLoaiDiem(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa, Program.IDDM_Truong);
                //    break;
                //case "DM_ThanhPhanDiem":
                //    oBHT_DuLieuNhap.ChuyenDanhSachThanhPhanDiem(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa, Program.IDDM_Truong);
                //    break;
                //case "Diem_DiemThanhPhan_TheoLoaiDiem":
                //    oBHT_DuLieuNhap.ChuyenDiemMonHocTheoLoaiDiem(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa, Program.IDDM_NamHoc_Truong, Program.IDDM_Truong);
                //    break;
                case "DM_TinhHuyenXa":
                    oBHT_DuLieuNhap.ChuyenDanhSachTinhHuyenXa(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa);
                    break;
            }
        }

        private void LuuDuLieu(string ID)
        {
            switch (ID)
            {
                case "SV_SinhVienNhapTruong":
                    oBHT_DuLieuNhap.LuuDuLieuTuyenSinh(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa, Program.IDNamHoc);
                    break;
                case "SV_SinhVien":
                    oBHT_DuLieuNhap.LuuDanhSachSinhVien(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa, int.Parse(cmbChonLop.EditValue.ToString()));
                    break;
                //case "DM_Khoi_Lop":
                //    oBHT_DuLieuNhap.LuuDanhSachLop(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa, Program.IDDM_NamHoc_Truong, Program.IDDM_Truong);
                //    break;
                case "NS_GiaoVien":
                    //if (!LapMaTuDong)
                        oBHT_DuLieuNhap.LuuDanhSachGiaoVien(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa, int.Parse(cmbDonVi.EditValue.ToString()));
                    //else
                    //    oBHT_DuLieuNhap.LuuDanhSachGiaoVien(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa, int.Parse(cmbDonVi.EditValue.ToString()), DoDaiTuTang, MaBatDauTu, PhanDauMa, PhanCuoiMa);
                    break;
                case "DM_MonHoc":
                    oBHT_DuLieuNhap.LuuDanhSachMonHoc(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa);
                    break;
                //case "DM_LoaiDiem":
                //    oBHT_DuLieuNhap.LuuDanhSachLoaiDiem(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa, Program.IDDM_Truong);
                //    break;
                //case "DM_ThanhPhanDiem":
                //    oBHT_DuLieuNhap.LuuDanhSachThanhPhanDiem(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa, Program.IDDM_Truong);
                //    break;
                //case "Diem_DiemThanhPhan_TheoLoaiDiem":
                //    oBHT_DuLieuNhap.LuuDiemMonHocTheoLoaiDiem(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa, 
                //        int.Parse(cmbChonMon.EditValue.ToString()), Program.IDDM_NamHoc_Truong, Program.HocKy, Program.objUserCurrent.IDGV_GIAOVIEN, Program.IDDM_Truong);
                //    break;
                case "DM_TinhHuyenXa":
                    oBHT_DuLieuNhap.LuuDanhSachTinhHuyenXa(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa);
                    break;
            }
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            try
            {
                string LoaiNguon = rdgNguon.EditValue.ToString();
                OpenFileDialog odlg = new OpenFileDialog();
                if (LoaiNguon == "Excel")
                {
                    odlg.Filter = "Excel files(*.xls;*.xlsx)|*.xls;*.xlsx";
                }
                else if (LoaiNguon == "Access")
                {
                    odlg.Filter = "Access files (*.mdb;*.accdb)|*.mdb;*.accdb";
                }
                else if (LoaiNguon == "Foxpro")
                {
                    odlg.Filter = "Foxpro files (*.dbc;*.dbf)|*.dbc;*.dbf";
                }
                if (odlg.ShowDialog() == DialogResult.OK)
                {
                    string strFileName = odlg.FileName;
                    TaoKetNoiOleDB(cnnDuLieuNguon, LoaiNguon, strFileName);
                    HienThiDanhSachCacSheet(cnnDuLieuNguon, lstSheet);

                    grdDuLieuNguon.DataSource = null;
                    grvDuLieuNguon.Columns.Clear();

                    lstSheet_SelectedIndexChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                ThongBao(ex.Message);
            }
        }

        private void cmbNhapDL_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbNhapDL.EditValue != null)
            {
                string str = cmbNhapDL.EditValue.ToString();
                switch (str)
                {
                    case "SV_SinhVienNhapTruong":
                        lciChonLop.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        layoutDonVi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        dtAnhXa = oBHT_DuLieuNhap.AnhXaSinhVienNhapTruong();
                        repositoryItemLookUpEditDuLieuDich.DataSource = dtAnhXa;
                        break;
                    //case "Diem_DiemThanhPhan":
                    //    lciChonLop.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    //    layoutDonVi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    //    dtAnhXa = oBHT_DuLieuNhap.AnhXaNhapDiem();
                    //    repositoryItemLookUpEditDuLieuDich.DataSource = dtAnhXa;
                    //    break;
                    case "SV_SinhVien":
                        lciChonLop.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        layoutDonVi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        dtAnhXa = oBHT_DuLieuNhap.AnhXaSinhVien();
                        repositoryItemLookUpEditDuLieuDich.DataSource = dtAnhXa;
                        break;
                    //case "DM_Khoi_Lop":
                    //    lciChonLop.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    //    lciChonMon.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    //    layoutDonVi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    //    dtAnhXa = oBHT_DuLieuNhap.AnhXaKhoiLop();
                    //    repositoryItemLookUpEditDuLieuDich.DataSource = dtAnhXa;
                    //    break;
                    case "NS_GiaoVien":
                        lciChonLop.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        layoutDonVi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        dtAnhXa = oBHT_DuLieuNhap.AnhXaGiaoVien();
                        repositoryItemLookUpEditDuLieuDich.DataSource = dtAnhXa;
                        break;
                    case "DM_MonHoc":
                        lciChonLop.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        layoutDonVi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        dtAnhXa = oBHT_DuLieuNhap.AnhXaMonHoc();
                        repositoryItemLookUpEditDuLieuDich.DataSource = dtAnhXa;
                        break;
                    case "DM_TinhHuyenXa":
                        lciChonLop.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        layoutDonVi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        dtAnhXa = oBHT_DuLieuNhap.AnhXaTinhHuyenXa();
                        repositoryItemLookUpEditDuLieuDich.DataSource = dtAnhXa;
                        break;
                }

                lstSheet_SelectedIndexChanged(null, null);
            }
        }

        private void lstSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSheet.SelectedIndex < 0)
            {
                dtDuLieuNguon = null;
                dtTruongAnhXa = null;
                return;
            }
            try
            {
                grdDuLieuNguon.DataSource = null;
                grvDuLieuNguon.Columns.Clear();
                dtDuLieuFile = GetDuLieuOleDb(cnnDuLieuNguon, lstSheet.Items[lstSheet.SelectedIndex].ToString());

                if (!dtDuLieuFile.Columns.Contains("@stt"))
                    dtDuLieuFile.Columns.Add("@stt", typeof(int));
                for (int i = 0; i < dtDuLieuFile.Rows.Count; i++)
                    dtDuLieuFile.Rows[i]["@stt"] = i + 1;

                dtDuLieuNguon = dtDuLieuFile.Copy();

                grdDuLieuNguon.DataSource = dtDuLieuNguon;
                grvDuLieuNguon.Columns["@stt"].Visible = false;

                dtTruongAnhXa = TaoBangCotChuyenDoi(dtDuLieuNguon);
                if (dtTruongAnhXa != null && !dtTruongAnhXa.Columns.Contains("ID"))
                {
                    dtTruongAnhXa.Columns.Add("ID", typeof(object));
                }
                grdAnhXaTruongDuLieu.DataSource = dtTruongAnhXa;
                cmbConvertFont_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                ThongBao(ex.Message);
            }
        }

        private void grvAnhXaTruongDuLieu_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "ID")
            {
                LookUpEdit edit = (LookUpEdit)view.ActiveEditor;
                DataTable dtThanhPhan = (DataTable)edit.Properties.LookUpData.DataSource;
                DataView dv = new DataView(dtThanhPhan);
                string strFilter = "";
                for (int i = 0; i < grvAnhXaTruongDuLieu.DataRowCount; i++)
                {
                    if (i != grvAnhXaTruongDuLieu.FocusedRowHandle)
                    {
                        if (grvAnhXaTruongDuLieu.GetDataRow(i)["ID"].ToString() != "")
                        {
                            strFilter += (strFilter == "" ? "ID <> '" + grvAnhXaTruongDuLieu.GetDataRow(i)["ID"].ToString() + "'" :
                                " And ID <> '" + grvAnhXaTruongDuLieu.GetDataRow(i)["ID"].ToString() + "'");
                        }
                    }
                }
                if (strFilter != "")
                    dv.RowFilter = strFilter;
                edit.Properties.LookUpData.DataSource = dv;
            }
        }

        private void repositoryItemLookUpEditDuLieuDich_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && grvAnhXaTruongDuLieu.ActiveEditor is LookUpEdit)
            {
                LookUpEdit edit = sender as LookUpEdit;
                edit.EditValue = null;
            }
        }

        private void btnThucHienNhapDiem_Click(object sender, EventArgs e)
        {
            if (cmbNhapDL.EditValue == null)
            {
                ThongBao("Bạn chưa chọn hình thức nhập dữ liệu.");
                cmbNhapDL.Focus();
                return;
            }
            if (dtDuLieuNguon == null)
            { 
                ThongBao("Bạn chưa chọn dữ liệu nguồn.");
                btnChonFile.Focus();
                return;
            }
            if (!CheckValid(cmbNhapDL.EditValue.ToString()))
                return;
            //LapMaTuDong = false;

            dtDuLieuKhongChuyenDuoc = dtDuLieuNguon.Clone();
            if (!dtDuLieuKhongChuyenDuoc.Columns.Contains("LyDo"))
                dtDuLieuKhongChuyenDuoc.Columns.Add("LyDo", typeof(string));
            grvDuLieuChuyenDuoc.Columns.Clear();
            grdDuLieuChuyenDuoc.DataSource = null;
            dtDuLieuChuyenDuoc = oBHT_DuLieuNhap.CreateTableChuyenDuoc(dtTruongAnhXa, ref htbAnhXa, cmbNhapDL.EditValue.ToString());
            // Kiểm tra trường dữ liệu ánh xạ đã có đủ các trường bắt buộc chưa
            string str = oBHT_DuLieuNhap.KiemTraCacTruongBatBuoc(htbAnhXa,cmbNhapDL.EditValue.ToString());
            if (str != "")
            {
                ThongBao(str);
                return;
            }
            if (dtDuLieuChuyenDuoc.Columns.Count >= 2)
            {
                GridColumn grc;
                DataRow[] arrDr;
                for (int i = 1; i < dtDuLieuChuyenDuoc.Columns.Count; i++)
                {
                    grc = new GridColumn();
                    arrDr = dtAnhXa.Select("ID = '" + dtDuLieuChuyenDuoc.Columns[i].ColumnName + "'");
                    SetColumnCaption(grc, arrDr[0]["TenTruongDuLieu"].ToString(), dtDuLieuChuyenDuoc.Columns[i].ColumnName, 85,
                            DevExpress.Utils.HorzAlignment.Default, false, dtDuLieuChuyenDuoc.Columns[i].ColumnName == "MaSinhVien" ? 0 : i + 5);
                    grvDuLieuChuyenDuoc.Columns.AddRange(new GridColumn[] { grc });
                }
                if (cmbNhapDL.EditValue.ToString() == "Diem_DiemThanhPhan" && dtDuLieuChuyenDuoc.Columns.Contains("MaSinhVien"))
                {
                    dtDuLieuChuyenDuoc.Columns.Add("HoVaTen", typeof(string));
                    grc = new GridColumn();
                    SetColumnCaption(grc, "Họ và tên", "HoVaTen", 85, DevExpress.Utils.HorzAlignment.Default, false, 1);
                    grvDuLieuChuyenDuoc.Columns.AddRange(new GridColumn[] { grc });
                    dtDuLieuChuyenDuoc.Columns.Add("TenLop", typeof(string));
                    grc = new GridColumn();
                    SetColumnCaption(grc, "Tên lớp", "TenLop", 85, DevExpress.Utils.HorzAlignment.Default, false, 2);
                    grvDuLieuChuyenDuoc.Columns.AddRange(new GridColumn[] { grc });
                }
                //else if (cmbNhapDL.EditValue.ToString() == "Diem_DiemThanhPhan" && !dtDuLieuChuyenDuoc.Columns.Contains("MaSinhVien"))
                //{
                //    ThongBao("Bạn chưa chọn trường ánh xạ với Mã sinh viên.");
                //    return;
                //}
                // Thực hiện kiểm tra quá trình nhập thông tin
                if(dtDuLieuNguon != null)
                    if (dtDuLieuNguon.Rows.Count > 0)
                    {
                        ChuyenDuLieuNhap(cmbNhapDL.EditValue.ToString());
                    }

                // Set lại DataSource
                grdDuLieuChuyenDuoc.DataSource = dtDuLieuChuyenDuoc;
                grvDuLieuKhongChuyenDuoc.Columns.Clear();
                grdDuLieuKhongChuyenDuoc.DataSource = dtDuLieuKhongChuyenDuoc;

                tabpageKetQua.PageEnabled = true;
                tabExcel.SelectedTabPage = tabpageKetQua;
                SetTextInfo(cmbNhapDL.EditValue.ToString());
            }
            else
                ThongBao("Chưa đủ các trường bắt buộc để nhập dữ liệu.");
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dtDuLieuChuyenDuoc != null)
            {
                if (dtDuLieuChuyenDuoc.Rows.Count > 0)
                {
                    CreateWaitDialog("Chuyển dữ liệu", "Đang thực hiện việc chuyển dữ liệu\nXin vui lòng chờ ...");
                    LuuDuLieu(cmbNhapDL.EditValue.ToString());
                    CloseWaitDialog();
                    ThongBao("Chuyển dữ liệu thành công.");
                    return;
                }
            }
            ThongBao("Không có dữ liệu để lưu.");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvDuLieuChuyenDuoc_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvDuLieuChuyenDuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (ThongBaoChon("Bạn có chắc chắn muốn xóa các dòng được chọn không?") == DialogResult.Yes)
                {
                    int[] rowSelected = grvDuLieuChuyenDuoc.GetSelectedRows();
                    for (int i = rowSelected.Length - 1; i >= 0; i--)
                    {
                        dtDuLieuChuyenDuoc.Rows.RemoveAt(rowSelected[i]);
                    }
                }
            }
        }

        private void btnLapMa_Click(object sender, EventArgs e)
        {
            //dlgLapMa dlg = new dlgLapMa();
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    DoDaiTuTang = dlg.DoDaiTuTang;
            //    DoDaiMa = dlg.DoDaiMa;
            //    MaBatDauTu = dlg.MaBatDauTu;
            //    PhanDauMa = dlg.PhanDauMa;
            //    PhanCuoiMa = dlg.PhanCuoiMa;
            //    LapMaTuDong = true;
            //}
        }

        private void cmbConvertFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grvDuLieuNguon.DataRowCount <= 0)
                return;
            if (cmbConvertFont.EditValue == null)
                return;

            CHUAN_BO_GO BoGo;
            Font font;
            if (cmbConvertFont.EditValue.ToString() == CHUAN_BO_GO.TCVN.ToString())
            {
                if (LaFontHeThong(".VnTime"))
                {
                    font = new System.Drawing.Font(".VnTime", 10);
                    BoGo = CHUAN_BO_GO.TCVN;
                }
                else
                {
                    ThongBao("Không tồn tại font '.Vntime' cho chuẩn bộ gõ TCVN");
                    return;
                }
            }
            else if (cmbConvertFont.EditValue.ToString() == CHUAN_BO_GO.VNI.ToString())
            {
                if (LaFontHeThong("VNI-Times"))
                {
                    font = new System.Drawing.Font("VNI-Times", 10);
                    BoGo = CHUAN_BO_GO.VNI;
                }
                else
                {
                    ThongBao("Không tồn tại font 'VNI-Times' cho chuẩn bộ gõ VNI");
                    return;
                }
            }
            else
            {
                if (LaFontHeThong("Tahoma"))
                {
                    font = new System.Drawing.Font("Tahoma", 8.25f);
                    BoGo = CHUAN_BO_GO.UNICODE;
                }
                else
                {
                    ThongBao("Không tồn tại font 'Tahoma' cho chuẩn bộ gõ UNICODE");
                    return;
                }
            }

            dtDuLieuNguon = dtDuLieuFile.Copy();
            oBHT_DuLieuNhap.ConvertToUnicode(ref dtDuLieuNguon, BoGo);
            grdDuLieuNguon.DataSource = dtDuLieuNguon;
        }

        private bool LaFontHeThong(string FontName)
        {
            for (int i = 0; i < FontFamily.Families.Length; i++)
            {
                if (FontFamily.Families[i].Name == FontName)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToXls(grvDuLieuNguon);
        }
    }
}