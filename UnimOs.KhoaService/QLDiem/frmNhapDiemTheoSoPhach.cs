using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.wsBusiness;
using TruongViet.UnimOs.Entity;
using Lib;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace UnimOs.Khoa 
{
    public partial class frmNhapDiemTheoSoPhach : frmBase
    {
        private DM_LopInfo pDM_LopInfo;
        private cBwsXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private cBwsKQHT_DiemThi oBKQHT_DiemThi;
        private KQHT_DiemThiInfo pKQHT_DiemThiInfo;
        private cBwsKQHT_DanhSachDuThi oBKQHT_DanhSachDuThi;
        private DataTable dtMonHoc, dtSinhVien;
        private bool IsLoadMonNhapDiem, IsGiaoVuNhapDiem;
        private int IDXL_MonHocTrongKy, IDDM_MonHoc;

        public frmNhapDiemTheoSoPhach()
        {
            InitializeComponent();
            oBXL_MonHocTrongKy = new cBwsXL_MonHocTrongKy();
            pKQHT_DiemThiInfo = new KQHT_DiemThiInfo();
            oBKQHT_DiemThi = new cBwsKQHT_DiemThi();
            oBKQHT_DanhSachDuThi = new cBwsKQHT_DanhSachDuThi();
        }

        private void frmNhapDiemTheoSBDVaSP_Load(object sender, EventArgs e)
        {
            cBwsHT_ThamSoHeThong oBThamSo = new cBwsHT_ThamSoHeThong();
            IsGiaoVuNhapDiem = oBThamSo.GetGiaTriByMaThamSo("GiaoVuNhapDiemPhach") == "1" ? true : false;
            if ((Program.objUserCurrent.IDDM_Khoa_GiaoVu > 0 || Program.objUserCurrent.Username == "giaovu") && !IsGiaoVuNhapDiem)
            {
                grvSinhVien.OptionsBehavior.Editable = false;
                btnCapNhat.Enabled = false;
                btnGhepPhach.Enabled = false;
            }
            LoadTreeLop(uctrlLop);
            uctrlLop.chkExpandAll.Checked = true;
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            IsLoadMonNhapDiem = false;
            LoadMonHocNhapDiem();
            grvMonHoc_FocusedRowChanged(null, null);
        }

        private void LoadMonHocNhapDiem()
        {
            if (Program.objUserCurrent.IDDM_Khoa_GiaoVu > 0)
                dtMonHoc = oBXL_MonHocTrongKy.GetByLopKhoa(pDM_LopInfo.DM_LopID, Program.objUserCurrent.IDDM_Khoa_GiaoVu, Program.IDNamHoc, Program.HocKy);
            else
                dtMonHoc = oBXL_MonHocTrongKy.GetByIDGiaoVien(Program.objUserCurrent.NS_GiaoVienID, pDM_LopInfo.DM_LopID, Program.HocKy, Program.IDNamHoc);

            grdMonHoc.DataSource = dtMonHoc;
            IsLoadMonNhapDiem = true;
        }

        private void grvSinhVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvMonHoc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!IsLoadMonNhapDiem)
                return;
            if (grvMonHoc.FocusedRowHandle >= 0)
            {
                IDXL_MonHocTrongKy = int.Parse(grvMonHoc.GetDataRow(grvMonHoc.FocusedRowHandle)["XL_MonHocTrongKyID"].ToString());
                IDDM_MonHoc = int.Parse(grvMonHoc.GetDataRow(grvMonHoc.FocusedRowHandle)["DM_MonHocID"].ToString());
                dtSinhVien = oBKQHT_DanhSachDuThi.GetNhapDiem(IDXL_MonHocTrongKy, int.Parse(cmbLanThi.Text));
                if (dtSinhVien.Rows.Count > 0)
                {
                    if ((bool)dtSinhVien.Rows[0]["IsDaChuyen"])
                    {
                        string HoDem = "";
                        foreach (DataRow dr in dtSinhVien.Rows)
                        {
                            dr["TenSV"] = GetTen(dr["HoVaTen"].ToString(), ref HoDem);
                            dr["HoVa"] = HoDem;
                        }
                        btnGhepPhach.Enabled = false;
                        btnCapNhat.Enabled = false;
                        grcMaSV.Visible = true;
                        grcHoVa.Visible = true;
                        grcTenSV.Visible = true;
                        grcMaSV.VisibleIndex = 0;
                        grcHoVa.VisibleIndex = 1;
                        grcTenSV.VisibleIndex = 2;
                    }
                    else
                    {
                        btnGhepPhach.Enabled = true;
                        btnCapNhat.Enabled = true;
                        grcMaSV.Visible = false;
                        grcHoVa.Visible = false;
                        grcTenSV.Visible = false;
                    }
                }
                else
                {
                    btnGhepPhach.Enabled = true;
                    btnCapNhat.Enabled = true;
                    grcMaSV.Visible = false;
                    grcHoVa.Visible = false;
                    grcTenSV.Visible = false;
                }
                grdSinhVien.DataSource = dtSinhVien;
                dtSinhVien.AcceptChanges();
            }
            else
            {
                btnGhepPhach.Enabled = true;
                btnCapNhat.Enabled = true;
                grcMaSV.Visible = false;
                grcHoVa.Visible = false;
                grcTenSV.Visible = false;
                IDXL_MonHocTrongKy = 0;
                IDDM_MonHoc = 0;
                grdSinhVien.DataSource = null;
            }
            btnInDanhSach.Enabled = !btnGhepPhach.Enabled;
        }

        private void grvSinhVien_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
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

        private void cmbLanThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            grvMonHoc_FocusedRowChanged(null, null);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dtSinhVien == null || dtSinhVien.Rows.Count <= 0)
                return;
            DataTable dtChange = dtSinhVien.GetChanges();
            if (dtChange == null)
                return;
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
            grvMonHoc_FocusedRowChanged(null, null);
        }

        private void btnGhepPhach_Click(object sender, EventArgs e)
        {
            if (dtSinhVien == null || dtSinhVien.Rows.Count <= 0)
                return;
            DataTable dtChange = dtSinhVien.GetChanges();
            if (dtChange != null)
            {
                ThongBao("Dữ liệu đã thay đổi, bạn cần lưu lại trước khi ghép phách.");
                return;
            }
            if (ThongBaoChon("Sau khi ghép phách bạn sẽ không được thay đổi điểm số!\nBạn có chắc chắn muốn ghép phách không?") != DialogResult.Yes)
                return;
            pKQHT_DiemThiInfo.IDXL_MonHocTrongKy = IDXL_MonHocTrongKy;
            pKQHT_DiemThiInfo.IDDM_MonHoc = IDDM_MonHoc;
            pKQHT_DiemThiInfo.IDDM_NamHoc = Program.IDNamHoc;
            pKQHT_DiemThiInfo.HocKy = Program.HocKy;
            pKQHT_DiemThiInfo.IDHT_User = Program.objUserCurrent.NS_GiaoVienID;
            pKQHT_DiemThiInfo.LanThi = int.Parse(cmbLanThi.Text);
            double Diem;
            foreach (DataRow dr in dtSinhVien.Rows)
            {
                try
                {
                    if ("" + dr["Diem"] == "")
                        Diem = -1;
                    else
                        Diem = double.Parse(dr["Diem"].ToString()) -
                            (double.Parse(dr["Diem"].ToString()) * double.Parse("0" + dr["MucPhatQuyChe"]) / 100);

                    pKQHT_DiemThiInfo.Diem = Math.Round(Diem, 0, MidpointRounding.AwayFromZero);
                    pKQHT_DiemThiInfo.IDSV_SinhVien = int.Parse(dr["IDSV_SinhVien"].ToString());
                    oBKQHT_DiemThi.Add(pKQHT_DiemThiInfo);
                }
                catch
                { }
            }
            oBKQHT_DanhSachDuThi.UpdateDaChuyenDiem(true, IDXL_MonHocTrongKy, pKQHT_DiemThiInfo.LanThi);
            grvMonHoc_FocusedRowChanged(null, null);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            if (dtSinhVien == null || dtSinhVien.Rows.Count <= 0)
                return;
            DataTable dtReport = dtSinhVien.Copy();
            dtReport.Columns.Add("TenLop", typeof(string));
            dtReport.Columns.Add("TenMonHoc", typeof(string));
            dtReport.Rows[0]["TenLop"] = pDM_LopInfo.TenLop;
            dtReport.Rows[0]["TenMonHoc"] = grvMonHoc.GetDataRow(grvMonHoc.FocusedRowHandle)["TenMonHoc"];
            frmReport frm = new frmReport(dtReport, "rBangPhach");
            frm.ShowDialog();
        }
    }
}