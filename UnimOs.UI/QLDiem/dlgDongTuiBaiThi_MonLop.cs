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
    public partial class dlgDongTuiBaiThi_MonLop : frmBase
    {
        private cBKQHT_DanhSachDuThi oBKQHT_DanhSachDuThi;
        private DataTable dtSinhVien;
        private bool DanhPhach = false;
        private long IDXL_MonHocTrongKy;
        private int LanThi, IDDM_Lop;

        public dlgDongTuiBaiThi_MonLop(DataTable _dtSinhVien, int _IDDM_Lop, long _IDXL_MonHocTrongKy, int _LanThi, string TenLop, string TenMon)
        {
            InitializeComponent();
            oBKQHT_DanhSachDuThi = new cBKQHT_DanhSachDuThi();
            LoadMucPhatQuyChe();

            dtSinhVien = _dtSinhVien;
            txtTenLop.Text = TenLop.Replace("Lớp: ", "");
            txtTenMon.Text = TenMon;
            IDXL_MonHocTrongKy = _IDXL_MonHocTrongKy;
            LanThi = _LanThi;
            IDDM_Lop = _IDDM_Lop;
            this.DialogResult = DialogResult.Cancel;
        }

        private void LoadMucPhatQuyChe()
        {
            DataTable dtMucPhatQuyChe = new DataTable();
            dtMucPhatQuyChe.Columns.Add("PhanTram", typeof(int));
            dtMucPhatQuyChe.Columns.Add("MucPhanTram", typeof(string));
            DataRow dr = dtMucPhatQuyChe.NewRow();
            dr["PhanTram"] = 25;
            dr["MucPhanTram"] = "25%";
            dtMucPhatQuyChe.Rows.Add(dr);

            dr = dtMucPhatQuyChe.NewRow();
            dr["PhanTram"] = 50;
            dr["MucPhanTram"] = "50%";
            dtMucPhatQuyChe.Rows.Add(dr);

            dr = dtMucPhatQuyChe.NewRow();
            dr["PhanTram"] = 100;
            dr["MucPhanTram"] = "100%";
            dtMucPhatQuyChe.Rows.Add(dr);
            
            repositoryItemMucPhatQuyChe.DataSource = dtMucPhatQuyChe;
        }

        private void dlgDongTuiBaiThi_Load(object sender, EventArgs e)
        {
            DataTable dt = oBKQHT_DanhSachDuThi.GetDanhSach(IDDM_Lop, IDXL_MonHocTrongKy, LanThi);
            if (!dtSinhVien.Columns.Contains("SoPhach"))
                    dtSinhVien.Columns.Add("SoPhach", typeof(string));
            if (!dtSinhVien.Columns.Contains("MucPhatQuyChe"))
                dtSinhVien.Columns.Add("MucPhatQuyChe", typeof(int));
            if (!dtSinhVien.Columns.Contains("LyDoViPhamQuyChe"))
                dtSinhVien.Columns.Add("LyDoViPhamQuyChe", typeof(string));

            if (dt.Rows.Count > 0)
            {
                DanhPhach = true;
                DataRow[] arrDr;
                foreach (DataRow dr in dt.Rows)
                {
                    arrDr = dtSinhVien.Select("SV_SinhVienID = " + dr["IDSV_SinhVien"]);
                    if (arrDr.Length > 0)
                    {
                        arrDr[0]["SoPhach"] = dr["SoPhach"];
                        arrDr[0]["MucPhatQuyChe"] = dr["MucPhatQuyChe"];
                        arrDr[0]["LyDoViPhamQuyChe"] = dr["LyDoViPhamQuyChe"];
                    }
                }
            }

            grdDSSinhVien.DataSource = dtSinhVien;
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
                try
                {
                    oBKQHT_DanhSachDuThi.UpdateSoPhachMonLop(dtSinhVien, IDXL_MonHocTrongKy, LanThi);
                    ThongBao("Đã cập nhật số phách cho Sinh viên.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    ThongBaoLoi("Lỗi khi lưu số phách: " + ex.Message);
                }
            }
            else
                ThongBao("Bạn chưa đánh số phách.");
        }

        private void grvDSSinhVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnInBangPhach_Click(object sender, EventArgs e)
        {
            if (dtSinhVien == null || dtSinhVien.Rows.Count <= 0)
                return;
            DataTable dtReport = dtSinhVien.Copy();
            dtReport.Columns.Add("GhiChu", typeof(string));
            dtReport.Columns.Add("TenMonHoc", typeof(string));
            dtReport.Rows[0]["TenLop"] = txtTenLop.Text;
            dtReport.Rows[0]["TenMonHoc"] = txtTenMon.Text;
            frmReport frm = new frmReport(dtReport, "rBangPhach");
            frm.ShowDialog();
        }

        private void grvDSSinhVien_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "SoPhach")
            {
                if (e.Value != null)
                {
                    DataRow[] arrDr = dtSinhVien.Select("SoPhach = '" + e.Value + "'");
                    if (arrDr.Length > 0)
                        grvDSSinhVien.GetDataRow(e.RowHandle)["SoPhach"] = null;
                }
            }
        }

        private void btnHuyPhach_Click(object sender, EventArgs e)
        {
            if (DanhPhach)
            {
                if (ThongBaoChon("Bạn có chắc chắn muốn huỷ phách của môn học này không ?") == DialogResult.Yes)
                {
                    try
                    {
                        oBKQHT_DanhSachDuThi.HuyPhachMonLop(IDXL_MonHocTrongKy, LanThi);
                        ThongBao("Đã huỷ phách cho môn học này thành công !");
                    }
                    catch (Exception ex)
                    {
                        ThongBaoLoi("Lỗi khi huỷ phách: " + ex.Message);
                    }
                    dlgDongTuiBaiThi_Load(null, null);
                }
            }
            else
                ThongBao("Bạn chưa đánh số phách.");
        }
    }
}