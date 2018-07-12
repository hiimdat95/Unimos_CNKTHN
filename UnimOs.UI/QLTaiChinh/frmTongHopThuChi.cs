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

namespace UnimOs.UI
{
    public partial class frmTongHopThuChi : frmBase
    {
        private cBTC_BienLaiThuTien oBTC_BienLaiThuTien;
        private DataTable dtTongHop;
        private DataTable dtHe, dtTrinhDo, dtKhoa, dtKhoaHoc, dtNganh, dtLop;
        private double TongThu = 0, TongChi = 0;

        public frmTongHopThuChi()
        {
            dtHe = LoadHe();
            dtTrinhDo = LoadTrinhDo();
            dtKhoa = LoadKhoa();
            dtKhoaHoc = LoadKhoaHoc();
            dtNganh = LoadNganh();
            dtLop = LoadLopTheoKhoa(0);
            InitializeComponent();
            oBTC_BienLaiThuTien = new cBTC_BienLaiThuTien();
            cmbCoSo.Properties.DataSource = bLoadDiaDiem();
        }

        private void frmTongHopThuChi_Load(object sender, EventArgs e)
        {
            dtpTuNgay.EditValue = Program.TuNgay;
            dtpDenNgay.EditValue = DateTime.Now;
            repositoryLoaiPhieu.DataSource = LoaiPhieu();
            //cmbLoaiThuChi.Properties.DataSource = LoadLoaiThuChi();
            GetComboLoaiThuChi();
        }

        private void GetComboLoaiThuChi()
        {
            DataTable dtTemp;
            if (rdDanhSach.SelectedIndex == 1)
            {
                 dtTemp = LoadLoaiThuChi(Program.IDNamHoc, Program.HocKy);
            }
            else
            {
                dtTemp = LoadLoaiThuChiTongHop();
            }
            cmbLoaiThuChi.Properties.DataSource = dtTemp;
            if (dtTemp.Rows.Count > 0)
                cmbLoaiThuChi.EditValue = dtTemp.Rows[0]["TC_LoaiThuChiID"];
        }

        private DataTable LoaiPhieu()
        {
            DataTable dtTemp = new DataTable (); DataRow dr;
            dtTemp.Columns.Add("TenLoaiPhieu", typeof(string));
            dtTemp.Columns.Add("LoaiPhieu", typeof(bool));
            dr = dtTemp.NewRow();
            dr["TenLoaiPhieu"] = "Phiếu thu";
            dr["LoaiPhieu"] = true;
            dtTemp.Rows.Add(dr);
            dr = dtTemp.NewRow();
            dr["TenLoaiPhieu"] = "Phiếu chi";
            dr["LoaiPhieu"] = false;
            dtTemp.Rows.Add(dr);
            return dtTemp;
        }

        private void rdDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdDanhSach.SelectedIndex == 0)
            {
                dtpTuNgay.Enabled = true;
                dtpDenNgay.Enabled = true;
            }
            else if (rdDanhSach.SelectedIndex == 1)
            {
                dtpTuNgay.Enabled = false;
                dtpDenNgay.Enabled = false;
            }
            else
            {
                dtpTuNgay.Enabled = false;
                dtpDenNgay.Enabled = false;
            }
            GetComboLoaiThuChi();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string TuNgay, DenNgay;
            int IDDM_NamHoc, HocKy;
            TuNgay = dtpTuNgay.EditValue.ToString();
            DenNgay = dtpDenNgay.EditValue.ToString();
            IDDM_NamHoc = Program.IDNamHoc;
            HocKy = Program.HocKy;
            if (rdDanhSach.SelectedIndex == 0)
            {
                IDDM_NamHoc = 0;
                HocKy = 0;
                TuNgay = ((DateTime)dtpTuNgay.EditValue).ToString("yyyy/MM/dd");
                DenNgay = ((DateTime)dtpDenNgay.EditValue).ToString("yyyy/MM/dd");
            }
            else if (rdDanhSach.SelectedIndex == 1)
            {
                TuNgay = "";
                DenNgay = "";
            }
            else
            {
                TuNgay = "";
                DenNgay = "";
                HocKy = 0;
            }
            string IDDM_Lops = ucLocHeTrinhDo.GetDM_LopFilter();
            if (cmbCoSo.EditValue != null)
                IDDM_Lops += (IDDM_Lops == "" ? "" : " And ") + "IDDM_DiaDiem = " + cmbCoSo.EditValue;

            dtTongHop = oBTC_BienLaiThuTien.GetThuChi(cmbLoaiThuChi.EditValue == null ? 0 : int.Parse(cmbLoaiThuChi.EditValue.ToString()), 
                TuNgay, DenNgay, IDDM_NamHoc, HocKy, IDDM_Lops);
            grdTongHop.DataSource = dtTongHop;

            if (dtTongHop != null && dtTongHop.Rows.Count > 0)
            {
                TongThu = 0; 
                TongChi = 0;
                string HoDem = "";
                dtTongHop.Columns.Add("HoVa", typeof(string));
                foreach (DataRow dr in dtTongHop.Rows)
                {
                    GetTen("" + dr["HoVaTen"], ref HoDem);
                    dr["HoVa"] = HoDem;
                    if (bool.Parse(dr["PhieuThu"].ToString()) == true)
                    {
                        TongThu += double.Parse(dr["SoTienChiTiet"].ToString());
                    }
                    else
                    {
                        TongChi += double.Parse(dr["SoTienChiTiet"].ToString());
                    }
                }
                lblTongChi.Text = lblTongChi.Text.Substring(0, lblTongChi.Text.IndexOf(":") + 1) + " " + double.Parse(TongChi.ToString()).ToString("N0") + " đồng";
                lblTongThu.Text = lblTongThu.Text.Substring(0, lblTongThu.Text.IndexOf(":") + 1) + " " +  double.Parse(TongThu.ToString()).ToString("N0") + " đồng";
            }
            else
            {
                lblTongChi.Text = lblTongChi.Text.Substring(0, lblTongChi.Text.IndexOf(":") + 1) + " 0 đồng";
                lblTongThu.Text = lblTongThu.Text.Substring(0, lblTongThu.Text.IndexOf(":") + 1) + " 0 đồng";
            }
        }

        private void grvTongHop_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            if (cmbLoaiThuChi.EditValue != null && grvTongHop.DataRowCount > 0)
            {
                DataTable dtReport = dtTongHop.Copy();
                dtReport.Columns.Add("TenLoaiThuChi", typeof(string));
                dtReport.Columns.Add("NoiDungBaoCao", typeof(string));
                dtReport.Columns.Add("HeTrinhDo", typeof(string));
                dtReport.Columns.Add("TongTienBangChu", typeof(string));
                dtReport.Rows[0]["TenLoaiThuChi"] = cmbLoaiThuChi.Text.ToUpper();
                if (rdDanhSach.EditValue.ToString() == "0")
                    dtReport.Rows[0]["NoiDungBaoCao"] = "Từ " + dtpTuNgay.Text + " đến " + dtpDenNgay.Text;
                else if (rdDanhSach.EditValue.ToString() == "1")
                    dtReport.Rows[0]["NoiDungBaoCao"] = "Học kỳ: " + Program.HocKy.ToString() + " -  Năm học: " + Program.NamHoc;
                else
                    dtReport.Rows[0]["NoiDungBaoCao"] = "Năm học: " + Program.NamHoc;
                string HeTrinhDo = "";
                if (ucLocHeTrinhDo.cmbHe.EditValue != null)
                    HeTrinhDo = "HỆ: " + ucLocHeTrinhDo.cmbHe.Text.ToUpper();
                if (ucLocHeTrinhDo.cmbTrinhDo.EditValue != null)
                    HeTrinhDo += (HeTrinhDo == "" ? "TRÌNH ĐỘ: " : " - TRÌNH ĐỘ: ") + ucLocHeTrinhDo.cmbTrinhDo.Text.ToUpper();
                if (cmbCoSo.EditValue != null)
                    HeTrinhDo += (HeTrinhDo == "" ? "TẠI: " : " - TẠI: ") + cmbCoSo.Text.ToUpper();
                dtReport.Rows[0]["HeTrinhDo"] = HeTrinhDo;
                Lib.clsStringHelper cls = new Lib.clsStringHelper();
                dtReport.Rows[dtReport.Rows.Count - 1]["TongTienBangChu"] = cls.ReadMoney(TongThu) + " đồng.";

                frmReport frm = new frmReport(dtReport, dtReport, "rBangKeThuChi", "rBangTongHopThuChi", new string[] { "Subreport1" });
                frm.Show();
            }
            else
                ThongBao("Chưa chọn loại thu chi.");
        }

        private void cmbCoSo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbCoSo.ClosePopup();
                cmbCoSo.EditValue = null;
            }
        }

        private void cmbLoaiThuChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbLoaiThuChi.ClosePopup();
                cmbLoaiThuChi.EditValue = null;
            }
        }
    }
}