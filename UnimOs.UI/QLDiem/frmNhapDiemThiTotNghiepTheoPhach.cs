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
using DevExpress.XtraGrid.Views.BandedGrid;

namespace UnimOs.UI 
{
    public partial class frmNhapDiemThiTotNghiepTheoPhach : frmBase
    {
        private cBKQHT_ToChucThi oBKQHT_ToChucThi;
        private cBKQHT_DanhSachDuThi oBKQHT_DanhSachDuThi;
        private cBKQHT_DiemMonThiTotNghiep oBKQHT_DiemMonThiTotNghiep;
        private KQHT_DiemMonThiTotNghiepInfo pKQHT_DiemMonThiTotNghiepInfo;
        private clsDataTableHelper cls;
        private int IDDM_MonHoc, KQHT_ToChucThiID;
        private bool TotNghiep = false;
        private DataTable dtMonThiTotNghiep, dtDotThi, dtDanhSachDuThi;

        public frmNhapDiemThiTotNghiepTheoPhach()
        {
            InitializeComponent();
            oBKQHT_ToChucThi = new cBKQHT_ToChucThi();
            oBKQHT_DanhSachDuThi = new cBKQHT_DanhSachDuThi();
            oBKQHT_DiemMonThiTotNghiep = new cBKQHT_DiemMonThiTotNghiep();
            pKQHT_DiemMonThiTotNghiepInfo = new KQHT_DiemMonThiTotNghiepInfo();
            cls = new clsDataTableHelper();
        }

        private void frmNhapDiemTheoSBDVaSP_Load(object sender, EventArgs e)
        {
            dtMonThiTotNghiep = (new cBDM_MonHoc()).GetMonThiTotNghiep(Program.IDNamHoc);
            grdMonThi.DataSource = dtMonThiTotNghiep;
        }

        private void bgvSinhVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvMonThi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvMonThi.DataRowCount > 0 && grvMonThi.FocusedRowHandle >= 0)
            {
                IDDM_MonHoc = int.Parse(grvMonThi.GetDataRow(grvMonThi.FocusedRowHandle)["DM_MonHocID"].ToString());
                LoadDanhSachDotThi();
                grvDotThi_FocusedRowChanged(null, null);
            }
            else
            {
                grdDotThi.DataSource = null;
                grdSinhVien.DataSource = null;
            }
        }

        private void LoadDanhSachDotThi()
        {
            dtDotThi = oBKQHT_ToChucThi.GetDotThiByMonHoc(IDDM_MonHoc, Program.IDNamHoc, Program.HocKy);
            grdDotThi.DataSource = dtDotThi;
        }

        private void SetVisible(bool status)
        {
            grcMaSinhVien.Visible = status;
            grcHoVa.Visible = status;
            grcTen.Visible = status;
            grcTenLop.Visible = status;
        }

        private void grvDotThi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvDotThi.DataRowCount > 0 && grvDotThi.FocusedRowHandle >= 0)
            {
                if (!(bool)grvDotThi.GetDataRow(grvDotThi.FocusedRowHandle)["DongTui"])
                {
                    grdSinhVien.DataSource = null;
                    cmbPhongThi.Properties.DataSource = null;
                    ThongBao("Đợt thi này chưa đánh phách!");
                    return;
                }

                KQHT_ToChucThiID = int.Parse(grvDotThi.GetDataRow(grvDotThi.FocusedRowHandle)["KQHT_ToChucThiID"].ToString());
                dtDanhSachDuThi = oBKQHT_ToChucThi.GetDanhSachByDotThi(KQHT_ToChucThiID);
                GetPhongThi();

                if (dtDanhSachDuThi.Rows.Count > 0)
                {
                    string HoVa = "";
                    foreach (DataRow dr in dtDanhSachDuThi.Rows)
                    {
                        dr["Ten"] = GetTen(dr["HoVaTen"].ToString(), ref HoVa);
                        dr["HoVa"] = HoVa;
                    }
                }
                dtDanhSachDuThi.AcceptChanges();
                cmbPhongThi_EditValueChanged(null, null);
            }
            else
            {
                grdSinhVien.DataSource = null;
                cmbPhongThi.Properties.DataSource = null;
            }
        }

        // lay phong thi theo dot thi
        private void GetPhongThi()
        {
            // get phong thi theo dot thi
            DataTable dtPhongThi = cls.SelectDistinct(dtDanhSachDuThi, new string[] { "IDDM_PhongHoc", "PhongThi" });
            cmbPhongThi.Properties.DataSource = dtPhongThi;
        }

        private void cmbPhongThi_EditValueChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtDanhSachDuThi);
            if (cmbPhongThi.EditValue != null)
            {
                dv.RowFilter = "IDDM_PhongHoc = " + cmbPhongThi.EditValue.ToString();
            }
            if ((bool)dtDanhSachDuThi.Rows[0]["IsDaChuyen"])
            {
                dv.Sort = "Ten, HoVa";
                grcDiem.OptionsColumn.AllowEdit = true;
                SetVisible(true);
            }
            else
            {
                dv.Sort = "SoPhach";
                grcDiem.OptionsColumn.AllowEdit = true;
                SetVisible(false);
            }
            grdSinhVien.DataSource = dv;
        }

        private void cmbPhongThi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbPhongThi.EditValue = null;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dtDanhSachDuThi == null || dtDanhSachDuThi.Rows.Count <= 0)
                return;

            DataTable dtChange = dtDanhSachDuThi.GetChanges();
            if (dtChange == null)
            {
                ThongBao("Dữ liệu điểm không thay đổi.");
                return;
            }
            //if (grcMaSinhVien.Visible)
            //{
            //    ThongBao("Môn thi này đã ghép phách, bạn không có quyền thay đổi điểm !");
            //    return;
            //}

            double Diem;
            foreach (DataRow dr in dtChange.Rows)
            {
                try
                {
                    if ("" + dr["Diem"] == "")
                        Diem = -1;
                    else
                        Diem = double.Parse(dr["Diem"].ToString());
                    oBKQHT_DanhSachDuThi.UpdateDiem(Diem, double.Parse(dr["KQHT_DanhSachDuThiID"].ToString()));
                }
                catch
                { }
            }
            grvDotThi_FocusedRowChanged(null, null);
            SuaThanhCong();
        }

        private void bgvSinhVien_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.Value.ToString().Trim() == "")
                {
                    e.Value = null;
                    e.Valid = true;
                }
                else
                {
                    float diem;
                    if (float.TryParse(e.Value.ToString(), out diem))
                    {
                        if (diem < 0 || diem > 10)
                        {
                            e.Valid = false;
                            e.ErrorText = "Dữ liệu điểm nhập vào phải từ 0 đến 10.";
                        }
                    }
                    else
                    {
                        e.Valid = false;
                        e.ErrorText = "Dữ liệu điểm nhập vào phải là kiểu số.";
                    }
                }
            }
        }

        private void btnGhepPhach_Click(object sender, EventArgs e)
        {
            if (dtDanhSachDuThi == null || dtDanhSachDuThi.Rows.Count <= 0)
                return;
            DataTable dtChange = dtDanhSachDuThi.GetChanges();
            if (dtChange != null)
            {
                ThongBao("Dữ liệu đã thay đổi, bạn cần lưu lại trước khi ghép phách.");
                return;
            }
            if (ThongBaoChon("Sau khi ghép phách bạn sẽ không được thay đổi điểm số!\nBạn có chắc chắn muốn ghép phách không?") != DialogResult.Yes)
                return;

            pKQHT_DiemMonThiTotNghiepInfo.LanThi = 1;

            double Diem;
            foreach (DataRow dr in dtDanhSachDuThi.Rows)
            {
                try
                {
                    if ("" + dr["Diem"] == "")
                        Diem = -1;
                    else
                        Diem = double.Parse(dr["Diem"].ToString());

                    pKQHT_DiemMonThiTotNghiepInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                    pKQHT_DiemMonThiTotNghiepInfo.Diem = Diem;
                    oBKQHT_DiemMonThiTotNghiep.AddUpdate(pKQHT_DiemMonThiTotNghiepInfo, IDDM_MonHoc, int.Parse(dr["IDDM_Lop"].ToString()));
                }
                catch
                { }
            }
            oBKQHT_DanhSachDuThi.UpdateDaChuyenDiemByToChucThi(true, KQHT_ToChucThiID, pKQHT_DiemMonThiTotNghiepInfo.LanThi);
            ThongBao("Ghép phách thành công!");
            grvDotThi_FocusedRowChanged(null, null);
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            if (dtDanhSachDuThi == null || dtDanhSachDuThi.Rows.Count <= 0)
                return;
            if (!grcMaSinhVien.Visible)
            {
                ThongBao("Đợt thi này chưa ghép phách, bạn chưa thể in được danh sách !");
                return;
            }

            DataTable dtReport = dtDanhSachDuThi.Copy();

            if (dtReport == null || dtReport.Rows.Count <= 0)
                return;

            dtReport.Columns.Add("TenMonHoc", typeof(string));
            dtReport.Columns.Add("NamHoc", typeof(string));
            foreach (DataRow dr in dtReport.Rows)
            {
                dr["TenMonHoc"] = grvMonThi.GetDataRow(grvMonThi.FocusedRowHandle)["TenMonHoc"].ToString();
                dr["NamHoc"] = Program.NamHoc;
            }

            dtReport.DefaultView.Sort = "PhongThi, Ten, HoVa";

            frmReport frm = new frmReport(dtReport.DefaultView.ToTable(), "rBangPhach_ThiTotNghiep");
            frm.ShowDialog();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (dtDanhSachDuThi.GetChanges() != null)
            {
                if (ThongBaoChon("Dữ liệu đã thay đổi, bạn có chắc chắn muốn thoát không ?") != DialogResult.Yes)
                    return;
            }
            this.Close();
        }
    }
}