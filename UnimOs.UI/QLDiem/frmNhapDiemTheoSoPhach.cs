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
    public partial class frmNhapDiemTheoSoPhach : frmBase
    {
        private DM_LopInfo pDM_LopInfo;
        private cBXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private cBKQHT_DiemThi oBKQHT_DiemThi;
        private KQHT_DiemThiInfo pKQHT_DiemThiInfo;
        private cBKQHT_DanhSachDuThi oBKQHT_DanhSachDuThi;
        private DataTable dtMonHoc, dtSinhVien;
        private bool IsLoadMonNhapDiem, IsGiaoVuNhapDiem;
        private int IDXL_MonHocTrongKy, IDDM_MonHoc;

        public frmNhapDiemTheoSoPhach()
        {
            InitializeComponent();
            oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
            pKQHT_DiemThiInfo = new KQHT_DiemThiInfo();
            oBKQHT_DiemThi = new cBKQHT_DiemThi();
            oBKQHT_DanhSachDuThi = new cBKQHT_DanhSachDuThi();
        }

        private void frmNhapDiemTheoSBDVaSP_Load(object sender, EventArgs e)
        {
            cBHT_ThamSoHeThong oBThamSo = new cBHT_ThamSoHeThong();
            IsGiaoVuNhapDiem = oBThamSo.GetGiaTriByMaThamSo("GiaoVuNhapDiem") == "1" ? true : false;
            if (!IsGiaoVuNhapDiem)
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
            dtMonHoc = oBXL_MonHocTrongKy.GetByLop(pDM_LopInfo.DM_LopID, Program.IDNamHoc, Program.HocKy);

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
                        grcMaSV.Visible = false;
                        grcHoVa.Visible = false;
                        grcTenSV.Visible = false;
                    }
                }
                else
                {
                    btnGhepPhach.Enabled = true;
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
                grcMaSV.Visible = false;
                grcHoVa.Visible = false;
                grcTenSV.Visible = false;
                IDXL_MonHocTrongKy = 0;
                IDDM_MonHoc = 0;
                grdSinhVien.DataSource = null;
            }
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
            pKQHT_DiemThiInfo.IDHT_User = Program.objUserCurrent.HT_UserID;
            pKQHT_DiemThiInfo.LanThi = int.Parse(cmbLanThi.Text);
            double Diem;
            foreach (DataRow dr in dtSinhVien.Rows)
            {
                try
                {
                    if ("" + dr["Diem"] == "")
                        Diem = -1;
                    else
                        Diem = double.Parse(dr["Diem"].ToString());

                    pKQHT_DiemThiInfo.Diem = Diem;
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
            dtSinhVien.Columns.Add("TenLop", typeof(string));
            dtSinhVien.Columns.Add("TenMonHoc", typeof(string));
            dtSinhVien.Rows[0]["TenLop"] = pDM_LopInfo.TenLop;
            dtSinhVien.Rows[0]["TenMonHoc"] = grvMonHoc.GetDataRow(grvMonHoc.FocusedRowHandle)["TenMonHoc"];
            frmReport frm = new frmReport(dtSinhVien, "rBangPhach");
            frm.ShowDialog();
        }
    }
}