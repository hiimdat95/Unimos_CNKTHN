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
    public partial class dlgDongTuiBaiThi : frmBase
    {
        private cBKQHT_DanhSachDuThi oBKQHT_DanhSachDuThi;
        private DataTable dtSinhVien;
        private bool DanhPhach = false;

        public dlgDongTuiBaiThi(DataTable mdtSinhVien, string TenMon)
        {
            InitializeComponent();
            oBKQHT_DanhSachDuThi = new cBKQHT_DanhSachDuThi();
            dtSinhVien = mdtSinhVien;
            txtTenMon.Text = TenMon;
            this.Tag = "";
        }

        private void dlgDongTuiBaiThi_Load(object sender, EventArgs e)
        {
            grdDSSinhVien.DataSource = dtSinhVien;
            dtSinhVien.AcceptChanges();
            txtDenSo.Text = (int.Parse(spintxtTuSo.EditValue.ToString()) + dtSinhVien.Rows.Count - 1).ToString();
        }

        private void spintxtTuSo_EditValueChanged(object sender, EventArgs e)
        {
            txtDenSo.Text = (int.Parse(spintxtTuSo.EditValue.ToString()) + dtSinhVien.Rows.Count - 1).ToString();
        }

        private void btnDanhSoPhach_Click(object sender, EventArgs e)
        {
            if (dtSinhVien.Rows.Count > 0)
            {
                int SoPhachLen = txtDenSo.Text.Trim().Length;
                clsRandom cls = new clsRandom();
                int[] SoPhach = cls.RandomKhongTrung(int.Parse(spintxtTuSo.EditValue.ToString()), int.Parse(spintxtTuSo.EditValue.ToString()) + dtSinhVien.Rows.Count - 1);
                for (int i = 0; i < dtSinhVien.Rows.Count; i++)
                {
                    dtSinhVien.Rows[i]["SoPhach"] = txtDauPhach.Text.Trim() + SoPhach[i].ToString().PadLeft(SoPhachLen, '0');
                }
                DanhPhach = true;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (DanhPhach)
            {
                for (int i = 0; i < dtSinhVien.Rows.Count; i++)
                {
                    oBKQHT_DanhSachDuThi.UpdateSoPhach(dtSinhVien.Rows[i]["SoPhach"].ToString(), int.Parse(spintxtTuiThiSo.EditValue.ToString()), float.Parse(dtSinhVien.Rows[i]["KQHT_DanhSachDuThiID"].ToString()));
                }
                ThongBao("Đã cập nhật số phách cho Sinh viên.");
                this.Tag = "1";
                //this.Close();
            }
            else
                ThongBao("Bạn chưa đánh số phách.");
        }

        private void grvDSSinhVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (dtSinhVien.GetChanges() != null)
            {
                if (ThongBaoChon("Dữ liệu đã thay đổi, bạn có muốn thoát không?") == DialogResult.Yes)
                    this.Close();
            }
        }

        private void btnInBangPhach_Click(object sender, EventArgs e)
        {
            DataTable dtReport = dtSinhVien.Copy();
            
            if (dtReport == null || dtReport.Rows.Count <= 0)
                return;

            dtReport.Columns.Add("TenMonHoc", typeof(string));
            dtReport.Columns.Add("NamHoc", typeof(string));
            foreach (DataRow dr in dtReport.Rows)
            {
                dr["TenMonHoc"] = txtTenMon.Text;
                dr["NamHoc"] = Program.NamHoc;
            }

            dtReport.DefaultView.Sort = "PhongThi, Ten, HoVa";

            frmReport frm = new frmReport(dtReport.DefaultView.ToTable(), "rBangPhach_ThiTotNghiep");
            frm.ShowDialog();
        }
    }
}