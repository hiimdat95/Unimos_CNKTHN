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
using DevExpress.XtraGrid.Views.Grid;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace UnimOs.UI
{
    public partial class frmPhanCongGiangDay : frmBase
    {
        private cBXL_PhanCongGiaoVien oBXL_PhanCongGiaoVien;
        private XL_PhanCongGiaoVienInfo pXL_PhanCongGiaoVienInfo;
        private cBXL_GiaoVien_MonHoc oBXL_GiaoVien_MonHoc;
        private XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo;
        private cBNS_GiaoVien oBNS_GiaoVien;
        private DataTable dtPhanCong, dtGiaoVienMonHoc, dtGiaoVien;
        private Hashtable htb = new Hashtable();
        private int rowIndex = -1, IDNS_GiaoVien = -1;
        private string HoTen = "";
        public string XoaIDNS_GiaoVien = "", XoaHoTens = "";

        public frmPhanCongGiangDay()
        {
            InitializeComponent();
            repositoryHinhThucThi.DataSource = LoadHinhThucThi();
            oBXL_GiaoVien_MonHoc = new cBXL_GiaoVien_MonHoc();
            pXL_GiaoVien_MonHocInfo = new XL_GiaoVien_MonHocInfo();
            oBXL_PhanCongGiaoVien = new cBXL_PhanCongGiaoVien();
            pXL_PhanCongGiaoVienInfo = new XL_PhanCongGiaoVienInfo();
            oBNS_GiaoVien = new cBNS_GiaoVien();
        }

        private void frmPhanCongGiangDay_Load(object sender, EventArgs e)
        {
            cBNS_GiaoVien oBNS_GiaoVien = new cBNS_GiaoVien();
            NS_GiaoVienInfo pNS_GiaoVienInfo = new NS_GiaoVienInfo();
            pNS_GiaoVienInfo.NS_GiaoVienID = 0;
            LoadCombo();
            uccmbDonVi.cmb.EditValue = (new cBNS_DonVi()).GetByIDDM_Khoa(0);
            uccmbDonVi.cmb.Enabled = false;
            uccmbKhoa.cmb.EditValue = 0;
            uccmbKhoa.cmb.Enabled = false;
            LoadGrid();
            pXL_GiaoVien_MonHocInfo.XL_GiaoVien_MonHocID = 0;
            dtGiaoVienMonHoc = oBXL_GiaoVien_MonHoc.Get(pXL_GiaoVien_MonHocInfo);
        }

        private void LoadGrid()
        {
            cBXL_MonHocTrongKy oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();

            int IDDM_Khoa, IDDM_BoMon;
            IDDM_Khoa = uccmbKhoa.cmb.EditValue == null ? 0 : int.Parse(uccmbKhoa.cmb.EditValue.ToString());
            IDDM_BoMon = uccmbBoMon.cmb.EditValue == null ? 0 : int.Parse(uccmbBoMon.cmb.EditValue.ToString());
            DataTable dtMon = oBXL_MonHocTrongKy.GetByHocKyNamHoc(0, Program.HocKy, Program.IDNamHoc, IDDM_Khoa, IDDM_BoMon);
            dtPhanCong = XuLyTable(dtMon);
            grdPhanCong.DataSource = dtPhanCong;
        }

        private DataTable XuLyTable(DataTable dtMon)
        {
            DataTable dt = CreateTable();
            if (dtMon.Rows.Count > 0)
            {
                DataRow drNew, dr0 = dtMon.Rows[0];
                string XL_MonHocTrongKyID = dr0["XL_MonHocTrongKyID"].ToString();

                DataRow[] arrDr;
                drNew = dt.NewRow();
                drTodrNew(ref drNew, dr0);
                foreach (DataRow dr in dtMon.Rows)
                {
                    if (dr["XL_MonHocTrongKyID"].ToString() != XL_MonHocTrongKyID)
                    {
                        dt.Rows.Add(drNew);
                        drNew = dt.NewRow();
                        XL_MonHocTrongKyID = dr["XL_MonHocTrongKyID"].ToString();
                        drTodrNew(ref drNew, dr);
                        if ("" + dr["IDNS_GiaoVien"] != "")
                        {
                            arrDr = dtGiaoVien.Select("IDNS_GiaoVien = " + dr["IDNS_GiaoVien"]);
                            if (arrDr.Length > 0)
                            {
                                arrDr[0]["TongSoTiet"] = int.Parse("0" + arrDr[0]["TongSoTiet"]) + int.Parse("0" + dr["SoTietPhanCong"]);
                            }

                            drNew["IDNS_GiaoViens"] = dr["IDNS_GiaoVien"].ToString();
                            drNew["HoTens"] = dr["HoTen"];
                            drNew["SoTiets"] = dr["SoTiet"];
                        }
                        else
                        {
                            drNew["IDNS_GiaoViens"] = "";
                            drNew["HoTens"] = "";
                            drNew["SoTiets"] = "";
                        }
                    }
                    else
                    {
                        if ("" + dr["IDNS_GiaoVien"] != "")
                        {
                            arrDr = dtGiaoVien.Select("IDNS_GiaoVien = " + dr["IDNS_GiaoVien"]);
                            if (arrDr.Length > 0)
                            {
                                arrDr[0]["TongSoTiet"] = int.Parse("0" + arrDr[0]["TongSoTiet"]) + int.Parse("0" + dr["SoTietPhanCong"]);
                            }

                            drNew["IDNS_GiaoViens"] = ("" + drNew["IDNS_GiaoViens"] == "" ? dr["IDNS_GiaoVien"].ToString() :
                                drNew["IDNS_GiaoViens"] + "," + dr["IDNS_GiaoVien"]);
                            drNew["HoTens"] = ("" + drNew["HoTens"] == "" ? dr["HoTen"].ToString() : drNew["HoTens"] + ", " + dr["HoTen"]);
                            drNew["SoTiets"] = ("" + drNew["SoTiets"] == "" ? dr["SoTiet"].ToString() : drNew["SoTiets"] + ", " + dr["SoTiet"]);
                        }
                        else
                        {
                            drNew["IDNS_GiaoViens"] = "";
                            drNew["HoTens"] = "";
                            drNew["SoTiets"] = "";
                        }
                    }
                }
                dt.Rows.Add(drNew);
            }
            return dt;
        }

        private void drTodrNew(ref DataRow drNew, DataRow dr)
        {
            drNew["XL_MonHocTrongKyID"] = dr["XL_MonHocTrongKyID"];
            drNew["IDDM_MonHoc"] = dr["IDDM_MonHoc"];
            drNew["TenKhoa"] = dr["TenKhoa"];
            drNew["TenBoMon"] = dr["TenBoMon"];
            drNew["MaMonHoc"] = dr["MaMonHoc"];
            drNew["TenMonHoc"] = dr["TenMonHoc"];
            drNew["TenLop"] = dr["TenLop"];
            drNew["SoHocTrinh"] = dr["SoHocTrinh"];
            drNew["SoTiet"] = dr["SoTiet"];
            drNew["LyThuyet"] = dr["LyThuyet"];
            drNew["ThucHanh"] = dr["ThucHanh"];
            drNew["IDDM_HinhThucThi"] = dr["IDDM_HinhThucThi"];
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("XL_MonHocTrongKyID", typeof(int));
            dt.Columns.Add("IDDM_MonHoc", typeof(int));
            dt.Columns.Add("TenKhoa", typeof(string));
            dt.Columns.Add("TenBoMon", typeof(string));
            dt.Columns.Add("MaMonHoc", typeof(string));
            dt.Columns.Add("TenMonHoc", typeof(string));
            dt.Columns.Add("TenLop", typeof(string));
            dt.Columns.Add("SoHocTrinh", typeof(float));
            dt.Columns.Add("SoTiet", typeof(int));
            dt.Columns.Add("LyThuyet", typeof(int));
            dt.Columns.Add("ThucHanh", typeof(int));
            dt.Columns.Add("IDDM_HinhThucThi", typeof(int));
            dt.Columns.Add("HoTens", typeof(string));
            dt.Columns.Add("IDNS_GiaoViens", typeof(string));
            dt.Columns.Add("SoTiets", typeof(string));

            return dt;
        }

        private void LoadCombo()
        {
            // Bộ môn
            uccmbBoMon.cmb.Properties.Columns.AddRange((new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { 
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaBoMon","Mã bộ môn"), 
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenBoMon","Tên bộ môn")}));
            uccmbBoMon.cmb.Properties.DisplayMember = "TenBoMon";
            uccmbBoMon.cmb.Properties.ValueMember = "DM_BoMonID";
            uccmbBoMon.cmb.EditValueChanged += new EventHandler(cmbBoMon_EditValueChanged);

            // Khoa
            uccmbKhoa.cmb.Properties.Columns.AddRange((new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { 
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaKhoa","Mã khoa"), 
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenKhoa","Tên Khoa")}));
            uccmbKhoa.cmb.Properties.DisplayMember = "TenKhoa";
            uccmbKhoa.cmb.Properties.ValueMember = "DM_KhoaID";
            uccmbKhoa.cmb.EditValueChanged += new EventHandler(cmbKhoa_EditValueChanged);
            uccmbKhoa.cmb.Properties.DataSource = LoadKhoa();

            // Đơn vị
            uccmbDonVi.cmb.Properties.Columns.AddRange((new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]{
               new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenDonVi","Tên đơn vị")}));
            uccmbDonVi.cmb.Properties.DisplayMember = "TenDonVi";
            uccmbDonVi.cmb.Properties.ValueMember = "NS_DonViID";
            uccmbDonVi.cmb.EditValueChanged += new EventHandler(cmb_EditValueChanged);
            uccmbDonVi.cmb.Properties.DataSource = LoadDonVi();
        }

        void cmb_EditValueChanged(object sender, EventArgs e)
        {
            int IDNS_DonVi = uccmbDonVi.cmb.EditValue == null ? 0 : int.Parse(uccmbDonVi.cmb.EditValue.ToString());
            dtGiaoVien = oBNS_GiaoVien.Get_Tree(IDNS_DonVi);
            dtGiaoVien.Columns.Add("TongSoTiet", typeof(int));
            trvlstGiaoVien.DataSource = dtGiaoVien;
            trvlstGiaoVien.ExpandAll();
        }

        void cmbKhoa_EditValueChanged(object sender, EventArgs e)
        {
            uccmbBoMon.cmb.EditValue = null;
            if (uccmbKhoa.cmb.EditValue != null)
                uccmbBoMon.cmb.Properties.DataSource = LoadBoMonTheoKhoa(int.Parse(uccmbKhoa.cmb.EditValue.ToString()));
            else
                uccmbBoMon.cmb.Properties.DataSource = null;
            LoadGrid();
        }

        void cmbBoMon_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void GetpXL_PhanCongGiaoVienInfo(int IDXL_MonHocTrongKy)
        {
            pXL_PhanCongGiaoVienInfo.IDNS_GiaoVien = IDNS_GiaoVien;
            pXL_PhanCongGiaoVienInfo.IDXL_MonHocTrongKy = IDXL_MonHocTrongKy;
        }

        private bool CheckMonDayGiaoVien(string IDDM_MonHoc)
        {
            DataRow[] dr = dtGiaoVienMonHoc.Select("IDNS_GiaoVien= " + IDNS_GiaoVien.ToString() + " and IDDM_MonHoc = " + IDDM_MonHoc);
            if (dr.Length > 0)
                return true;
            return false;
        }

        private void grvPhanCong_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void trvlstGiaoVien_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                // Nếu node đang focus là giáo viên thì cho phép kéo thả
                IDNS_GiaoVien = int.Parse(trvlstGiaoVien.FocusedNode["IDNS_GiaoVien"].ToString());
                HoTen = trvlstGiaoVien.FocusedNode["Ten"].ToString();
                if (IDNS_GiaoVien > 0)
                {
                    trvlstGiaoVien.OptionsBehavior.DragNodes = true;
                }
                else
                {
                    trvlstGiaoVien.OptionsBehavior.DragNodes = false;
                }
            }
            catch (Exception ex)
            {
                ThongBao(ex.Message);
            }
        }

        private void trvlstGiaoVien_DragOver(object sender, DragEventArgs e)
        {
            if (IDNS_GiaoVien > 0)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void trvlstGiaoVien_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (IDNS_GiaoVien > 0)
                    {
                        trvlstGiaoVien.DoDragDrop(sender, DragDropEffects.Copy);
                    }
                }
            }

            catch (Exception ex)
            {
                ThongBao(ex.Message);
            }
        }

        private void grdPhanCong_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                GridHitInfo hi = grvPhanCong.CalcHitInfo(grdPhanCong.PointToClient(new Point(e.X, e.Y)));
                if (hi.InRow)
                {
                    e.Effect = DragDropEffects.Copy;
                    rowIndex = hi.RowHandle;
                    if ("" + dtPhanCong.Rows[rowIndex]["HoTens"] != "")
                    {
                        popupGiaoVien.ShowPopup(MousePosition);
                    }
                    else
                    {
                        if (!CheckMonDayGiaoVien(dtPhanCong.Rows[rowIndex]["IDDM_MonHoc"].ToString()))
                        {
                            if (ThongBaoChon("Môn học này không có trong danh sách các môn có thể dạy của giảng viên: " + HoTen + "\nBạn có đồng ý với lựa chọn này không?") != DialogResult.Yes)
                                return;
                        }
                        GetpXL_PhanCongGiaoVienInfo(int.Parse(dtPhanCong.Rows[rowIndex]["XL_MonHocTrongKyID"].ToString()));

                        pXL_PhanCongGiaoVienInfo.SoTiet = int.Parse(dtPhanCong.Rows[rowIndex]["SoTiet"].ToString());
                        oBXL_PhanCongGiaoVien.Add(pXL_PhanCongGiaoVienInfo);

                        DataRow[] arrDr = dtGiaoVien.Select("IDNS_GiaoVien = " + IDNS_GiaoVien);
                        if (arrDr.Length > 0)
                        {
                            arrDr[0]["TongSoTiet"] = int.Parse("0" + arrDr[0]["TongSoTiet"]) + pXL_PhanCongGiaoVienInfo.SoTiet;
                        }
                        // ghi log
                        GhiLog("Thêm giáo viên '" + HoTen + "' vào lớp '" + dtPhanCong.Rows[rowIndex]["TenLop"].ToString() + "' dạy môn học '" + dtPhanCong.Rows[rowIndex]["TenMonHoc"].ToString() + "'", "Thêm", this.Tag.ToString());
                        dtPhanCong.Rows[rowIndex]["IDNS_GiaoViens"] = IDNS_GiaoVien.ToString();
                        dtPhanCong.Rows[rowIndex]["HoTens"] = HoTen;
                        dtPhanCong.Rows[rowIndex]["SoTiets"] = pXL_PhanCongGiaoVienInfo.SoTiet.ToString();
                    }

                    //DataRow[] arrDr = dtPhanCong.Select("IDNS_GiaoVien = " + IDNS_GiaoVien.ToString());
                    //if (arrDr.Length > 0)
                    //{
                    //    arrDr[0]["SoTiet"] = int.Parse("0" + arrDr[0]["SoTiet"]) + int.Parse(dtPhanCong.Rows[hi.RowHandle]["SoTietTuan"].ToString());
                    //}
                }
            }
            catch (Exception ex)
            {
                ThongBao(ex.Message);
            }
        }

        private void grdPhanCong_DragOver(object sender, DragEventArgs e)
        {
            //Lấy thông tin hit
            GridHitInfo hi = grvPhanCong.CalcHitInfo(grdPhanCong.PointToClient(new Point(e.X, e.Y)));
            if (hi.InRow)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else e.Effect = DragDropEffects.None;
        }

        private void barbtnThemVao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ((dtPhanCong.Rows[rowIndex]["IDNS_GiaoViens"].ToString() + ",").IndexOf(IDNS_GiaoVien.ToString() + ",") < 0)
            {
                try
                {
                    if (!CheckMonDayGiaoVien(dtPhanCong.Rows[rowIndex]["IDDM_MonHoc"].ToString()))
                    {
                        if (ThongBaoChon("Môn học này không có trong danh sách các môn dạy của giảng viên: " + HoTen + "\nBạn có đồng ý với lựa chọn này không?") != DialogResult.Yes)
                            return;
                    }
                    DataRow drPhanCong = dtPhanCong.Rows[rowIndex];
                    dlgPhanCongGiaoVien_SoTiet dlg = new dlgPhanCongGiaoVien_SoTiet(ref drPhanCong, IDNS_GiaoVien, ref dtGiaoVien);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        // Ghi log
                        GhiLog("Thêm giáo viên '" + HoTen + "' vào lớp '" + dtPhanCong.Rows[rowIndex]["TenLop"].ToString() + "' dạy môn học '" + dtPhanCong.Rows[rowIndex]["TenMonHoc"].ToString() + "'", "Thêm", this.Tag.ToString());
                    }
                }
                catch (Exception ex)
                {
                    ThongBao(ex.Message);
                }
            }
            else
                ThongBao("Giảng viên này đã được phân công vào môn này.");
        }

        private void barbtnThayThe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dtPhanCong.Rows[rowIndex]["IDNS_GiaoViens"].ToString() != IDNS_GiaoVien.ToString())
            {
                try
                {
                    if (!CheckMonDayGiaoVien(dtPhanCong.Rows[rowIndex]["IDDM_MonHoc"].ToString()))
                    {
                        if (ThongBaoChon("Môn học này không có trong danh sách các môn dạy của giảng viên: " + HoTen.ToUpper() + "\nBạn có đồng ý với lựa chọn này không?") != DialogResult.Yes)
                            return;
                    }
                    // Xóa các giảng viên đang có và thêm giảng viên thay thế vào
                    oBXL_PhanCongGiaoVien.DeleteByMonHoc(int.Parse(dtPhanCong.Rows[rowIndex]["XL_MonHocTrongKyID"].ToString()), "");

                    GetpXL_PhanCongGiaoVienInfo(int.Parse(dtPhanCong.Rows[rowIndex]["XL_MonHocTrongKyID"].ToString()));
                    // Lấy số tiết của môn để đưa vào phân công giáo viên
                    pXL_PhanCongGiaoVienInfo.SoTiet = int.Parse(dtPhanCong.Rows[rowIndex]["SoTiet"].ToString());

                    oBXL_PhanCongGiaoVien.Add(pXL_PhanCongGiaoVienInfo);
                    // Trừ đi số tiết kỳ của GV bị thay thế
                    DataRow[] arrDr = dtGiaoVien.Select("IDNS_GiaoVien = " + dtPhanCong.Rows[rowIndex]["IDNS_GiaoViens"]);
                    if (arrDr.Length > 0)
                    {
                        arrDr[0]["TongSoTiet"] = int.Parse("0" + arrDr[0]["TongSoTiet"]) - pXL_PhanCongGiaoVienInfo.SoTiet;
                    }
                    // Cộng thêm số tiết vào số tiết kỳ của GV
                    arrDr = dtGiaoVien.Select("IDNS_GiaoVien = " + IDNS_GiaoVien);
                    if (arrDr.Length > 0)
                    {
                        arrDr[0]["TongSoTiet"] = int.Parse("0" + arrDr[0]["TongSoTiet"]) + pXL_PhanCongGiaoVienInfo.SoTiet;
                    }
                    // ghi log
                    GhiLog("Thay thế giáo viên '" + HoTen + "' vào lớp '" + dtPhanCong.Rows[rowIndex]["TenLop"].ToString() + "' dạy môn học '" + dtPhanCong.Rows[rowIndex]["TenMonHoc"].ToString() + "'", "Thêm", this.Tag.ToString());
                    // Thiết lập lại giá trị hiển thị
                    dtPhanCong.Rows[rowIndex]["IDNS_GiaoViens"] = IDNS_GiaoVien.ToString();
                    dtPhanCong.Rows[rowIndex]["HoTens"] = HoTen;
                }
                catch (Exception ex)
                {
                    ThongBao(ex.Message);
                }
            }
        }

        private void grvPhanCong_KeyDown(object sender, KeyEventArgs e)
        {

            if (grvPhanCong.DataRowCount > 0 && grvPhanCong.FocusedRowHandle >= 0)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (grvPhanCong.GetDataRow(grvPhanCong.FocusedRowHandle)["IDNS_GiaoViens"].ToString() != "")
                    {
                        if (ThongBaoChon("Bạn có chắc chắn muốn bỏ giáo viên?") != DialogResult.Yes)
                            return;
                    }
                    try
                    {
                        if (grvPhanCong.GetDataRow(grvPhanCong.FocusedRowHandle)["IDNS_GiaoViens"].ToString().IndexOf(",") < 0)
                        {
                            oBXL_PhanCongGiaoVien.DeleteByMonHoc(int.Parse(grvPhanCong.GetDataRow(grvPhanCong.FocusedRowHandle)["XL_MonHocTrongKyID"].ToString()), "");
                            DataRow[] arrDr = dtGiaoVien.Select("IDNS_GiaoVien = " + grvPhanCong.GetDataRow(grvPhanCong.FocusedRowHandle)["IDNS_GiaoViens"]);
                            if (arrDr.Length > 0)
                            {
                                arrDr[0]["TongSoTiet"] = int.Parse("0" + arrDr[0]["TongSoTiet"]) - int.Parse(grvPhanCong.GetDataRow(grvPhanCong.FocusedRowHandle)["SoTiets"].ToString());
                            }
                            dtPhanCong.Rows[grvPhanCong.FocusedRowHandle]["IDNS_GiaoViens"] = "";
                            dtPhanCong.Rows[grvPhanCong.FocusedRowHandle]["HoTens"] = "";
                            // ghi log
                            GhiLog("Xóa giáo viên '" + dtPhanCong.Rows[grvPhanCong.FocusedRowHandle]["HoTens"] + "' khỏi lớp '" + grvPhanCong.GetDataRow(grvPhanCong.FocusedRowHandle)["TenLop"].ToString() + "' dạy môn học '" + grvPhanCong.GetDataRow(grvPhanCong.FocusedRowHandle)["TenMonHoc"].ToString() + "'", "Xóa", this.Tag.ToString());
                        }
                        else
                        {
                            dlgPhanCongGiangDay_XoaGiangVien dlg = new dlgPhanCongGiangDay_XoaGiangVien(grvPhanCong.GetDataRow(grvPhanCong.FocusedRowHandle)["HoTens"].ToString(), grvPhanCong.GetDataRow(grvPhanCong.FocusedRowHandle)["IDNS_GiaoViens"].ToString(), grvPhanCong.GetDataRow(grvPhanCong.FocusedRowHandle)["SoTiets"].ToString());
                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                oBXL_PhanCongGiaoVien.DeleteByMonHoc(int.Parse(grvPhanCong.GetDataRow(grvPhanCong.FocusedRowHandle)["XL_MonHocTrongKyID"].ToString()), dlg.Tag.ToString().Substring(0, dlg.Tag.ToString().Length - 1));
                                // ghi log
                                GhiLog("Xóa giáo viên khỏi lớp '" + grvPhanCong.GetDataRow(grvPhanCong.FocusedRowHandle)["TenLop"].ToString() + "' dạy môn học '" + grvPhanCong.GetDataRow(grvPhanCong.FocusedRowHandle)["TenMonHoc"].ToString() + "'", "Xóa", this.Tag.ToString());
                                dtPhanCong.Rows[grvPhanCong.FocusedRowHandle]["IDNS_GiaoViens"] = (dlg.IDNS_GiaoViens == "," || dlg.IDNS_GiaoViens == "" ? "" : dlg.IDNS_GiaoViens.Substring(0, dlg.IDNS_GiaoViens.Length - 1));
                                dtPhanCong.Rows[grvPhanCong.FocusedRowHandle]["HoTens"] = (dlg.HoTens == "" || dlg.HoTens == "," ? "" : dlg.HoTens.Substring(0, dlg.HoTens.Length - 1));
                            }
                        }
                    }
                    catch
                    {
                        XoaThatBai();
                    }
                }
            }
        }
    }
}