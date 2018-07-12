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
    public partial class frmLapMaGiaoVien : frmBase
    {
        private cBNS_GiaoVien oBNS_GiaoVien;
        private NS_GiaoVienInfo pNS_GiaoVienInfo;
        private DataTable dtGiaoVien;

        public frmLapMaGiaoVien()
        {
            InitializeComponent();
            oBNS_GiaoVien = new cBNS_GiaoVien();
            pNS_GiaoVienInfo = new NS_GiaoVienInfo();
            repositoryItemcmdGioiTinh.DataSource = LoadGioiTinh();
        }

        private void frmLapMaGiaoVien_Load(object sender, EventArgs e)
        {
            cmbDonVi.Properties.DataSource = LoadDonVi();
        }

        private bool CheckValid()
        {
            return true;
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            if (txtDoDaiTuTang.Text.Trim() != "" && txtBatDauTu.Text.Trim() != "")
            {
                int DoDaiTuTang = int.Parse(txtDoDaiTuTang.Text.Trim());
                string MaGiaoVien, PhanDauMa = txtPhanDauMa.Text.Trim(), PhanCuoiMa = txtPhanCuoiMa.Text.Trim();

                MaGiaoVien = txtBatDauTu.Text.Trim();
                while (MaGiaoVien.Length < DoDaiTuTang)
                {
                    MaGiaoVien = "0" + MaGiaoVien;
                }
                MaGiaoVien = PhanDauMa + MaGiaoVien + PhanCuoiMa;
                txtDangMa.Text = MaGiaoVien;
            }
            else
                txtDangMa.Text = "";
        }

        private void grvGiaoVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnLocCanBo_Click(object sender, EventArgs e)
        {
            dtGiaoVien = oBNS_GiaoVien.LocGiaoVien(cmbDonVi.EditValue == null ? 0 : int.Parse(cmbDonVi.EditValue.ToString()), txtHoTen.Text.Trim());
            grdGiaoVien.DataSource = dtGiaoVien;
        }

        private void btnLapMa_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            if (dtGiaoVien != null && dtGiaoVien.Rows.Count > 0)
            {
                long TuTang;
                int DoDaiTuTang = int.Parse(txtDoDaiTuTang.Text.Trim());
                string MaGiaoVien, PhanDauMa = txtPhanDauMa.Text.Trim(), PhanCuoiMa = txtPhanCuoiMa.Text.Trim();
                string MaLonNhat = oBNS_GiaoVien.GetMaLonNhat(txtDangMa.Text.Length, PhanDauMa, PhanCuoiMa);

                if (MaLonNhat == "")
                {
                    TuTang = long.Parse(txtBatDauTu.Text) - 1;
                }
                else
                {
                    if (PhanCuoiMa.Length > 0)
                        MaLonNhat = MaLonNhat.Substring(MaLonNhat.Length - PhanCuoiMa.Length - 1);
                    TuTang = long.Parse(MaLonNhat.Substring(PhanDauMa.Length));
                }
                for (int i = 0; i < grvGiaoVien.DataRowCount; i++)
                {
                    TuTang++;
                    MaGiaoVien = TuTang.ToString();
                    while (MaGiaoVien.Length < DoDaiTuTang)
                    {
                        MaGiaoVien = "0" + MaGiaoVien;
                    }
                    MaGiaoVien = PhanDauMa + MaGiaoVien + PhanCuoiMa;
                    grvGiaoVien.GetDataRow(i)["MaGiaoVien"] = MaGiaoVien;
                }
            }
            else
                ThongBao("Chưa có cán bộ nào để lập mã.");
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dtGiaoVien == null)
            {
                ThongBao("Không có cán bộ nào để lưu.");
                return;
            }
            DataTable dtChange = dtGiaoVien.GetChanges();
            if (dtChange != null)
            {
                oBNS_GiaoVien.UpdateMaGiaoVien(ref dtChange);
                ThongBao("Cập nhật mã cán bộ thành công.");
            }
            else
                ThongBao("Không có sự thay đổi về mã cán bộ.");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (dtGiaoVien != null && dtGiaoVien.GetChanges() != null)
                if (ThongBaoChon("Dữ liệu đã thay đổi, bạn có thực sự muốn thoát không?") != DialogResult.Yes)
                    return;
            this.Close();
        }
    }
}