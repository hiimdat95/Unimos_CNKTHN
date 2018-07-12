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
    public partial class dlgTrangThaiChuyenDiem : frmBase
    {
        public int IDXL_MonHocTrongKy = 0;
        public int IDDM_Lop = 0, IDDM_MonHoc = 0, LanThi = 0;
        private cBKQHT_ChoNhapLaiDiem oBKQHT_ChoNhapLaiDiem;
        private DataTable dtDanhSach;

        public dlgTrangThaiChuyenDiem(bool DiemThanhPhan, bool ThiLan1, bool DiemThanhPhanL2, bool ThiLan2)
        {
            InitializeComponent();

            chkDiemThanhPhan.Checked = !DiemThanhPhan;
            chkDiemThanhPhan.Enabled = DiemThanhPhan;
            chkThiLan1.Checked = !ThiLan1;
            chkThiLan1.Enabled = ThiLan1;
            chkDiemThanhPhanL2.Checked = !DiemThanhPhanL2;
            chkDiemThanhPhanL2.Enabled = DiemThanhPhanL2;
            chkThiLan2.Checked = !ThiLan2;
            chkThiLan2.Enabled = ThiLan2;
        }

        private void dlgChuyenDiem_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
        }

        private void LoadDanhSach()
        {
            oBKQHT_ChoNhapLaiDiem = new cBKQHT_ChoNhapLaiDiem();
            dtDanhSach = oBKQHT_ChoNhapLaiDiem.GetDanhSach(IDXL_MonHocTrongKy, IDDM_Lop, IDDM_MonHoc, Program.IDNamHoc, Program.HocKy, LanThi);

            string HoDem = "";
            foreach (DataRow dr in dtDanhSach.Rows)
            {
                dr["Ten"] = GetTen(dr["HoVaTen"].ToString(), ref HoDem);
                dr["HoDem"] = HoDem;
            }

            grdDanhSach.DataSource = dtDanhSach;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (chkDiemThanhPhan.Checked || chkThiLan1.Checked || chkDiemThanhPhanL2.Checked || chkThiLan2.Checked)
            {
                DataRow[] arrDr = dtDanhSach.Select("Chon = 1");
                if (arrDr.Length > 0)
                {
                    cBKQHT_DaChuyenDiem oBKQHT_DaChuyenDiem = new cBKQHT_DaChuyenDiem();
                    KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo = new KQHT_DaChuyenDiemInfo();

                    pKQHT_DaChuyenDiemInfo.IDXL_MonHocTrongKy = IDXL_MonHocTrongKy;
                    
                    if (chkDiemThanhPhan.Enabled)
                        pKQHT_DaChuyenDiemInfo.DaNhapDiemThanhPhan = !chkDiemThanhPhan.Checked;
                    else
                        pKQHT_DaChuyenDiemInfo.DaNhapDiemThanhPhan = false;
                    
                    if (chkThiLan1.Enabled)
                        pKQHT_DaChuyenDiemInfo.DaNhapDiemThiL1 = !chkThiLan1.Checked;
                    else
                        pKQHT_DaChuyenDiemInfo.DaNhapDiemThiL1 = false;
                    
                    if (chkDiemThanhPhanL2.Enabled)
                        pKQHT_DaChuyenDiemInfo.DaNhapDiemThanhPhanL2 = !chkDiemThanhPhanL2.Checked;
                    else
                        pKQHT_DaChuyenDiemInfo.DaNhapDiemThanhPhanL2 = false;
                    
                    if (chkThiLan2.Enabled)
                        pKQHT_DaChuyenDiemInfo.DaNhapDiemThiL2 = !chkThiLan2.Checked;
                    else
                        pKQHT_DaChuyenDiemInfo.DaNhapDiemThiL2 = false;

                    try
                    {
                        // Update vao bang KQHT_DaChuyenDiem
                        oBKQHT_DaChuyenDiem.UpdateTrangThaiChuyen(pKQHT_DaChuyenDiemInfo);
                        
                        // Thêm thông tin về lần cho nhập lại điểm này vào bảng KQHT_ChoNhapLaiDiem 
                        cBKQHT_ChoNhapLaiDiem oBKQHT_ChoNhapLaiDiem = new cBKQHT_ChoNhapLaiDiem();
                        cBKQHT_ChoNhapLaiDiem_SinhVien oBKQHT_ChoNhapLaiDiem_SinhVien = new cBKQHT_ChoNhapLaiDiem_SinhVien();
                        KQHT_ChoNhapLaiDiem_SinhVienInfo pKQHT_ChoNhapLaiDiem_SinhVienInfo = new KQHT_ChoNhapLaiDiem_SinhVienInfo();

                        bool DiemThanhPhan_L2, DiemThi_L2, DiemThi_L1;

                        DiemThanhPhan_L2 = chkDiemThanhPhanL2.Enabled ? chkDiemThanhPhanL2.Checked : false;
                        DiemThi_L2 = chkThiLan2.Enabled ? chkThiLan2.Checked : false;
                        DiemThi_L1 = chkThiLan1.Enabled ? chkThiLan1.Checked : false;

                        pKQHT_ChoNhapLaiDiem_SinhVienInfo.IDKQHT_ChoNhapLaiDiem =
                            oBKQHT_ChoNhapLaiDiem.AddChuyenDiem(IDXL_MonHocTrongKy, Program.objUserCurrent.HT_UserID,
                                chkDiemThanhPhan.Checked, DiemThi_L1, DiemThanhPhan_L2, DiemThi_L2);

                        // Thêm chi tiết các sinh viên được chuyển lại điểm vào bảng KQHT_ChoNhapLaiDiem_SinhVien
                        foreach (DataRow dr in arrDr)
                        {
                            pKQHT_ChoNhapLaiDiem_SinhVienInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                            oBKQHT_ChoNhapLaiDiem_SinhVien.Add(pKQHT_ChoNhapLaiDiem_SinhVienInfo);
                        }

                        // Lưu lại điểm trước khi nhập lại của các sinh viên được chuyển lại điểm này
                        oBKQHT_ChoNhapLaiDiem.LuuDiemHienTai(pKQHT_ChoNhapLaiDiem_SinhVienInfo.IDKQHT_ChoNhapLaiDiem, IDXL_MonHocTrongKy);

                        ThongBao("Đã cập nhật trạng thái chuyển điểm thành công.");

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        ThongBaoLoi("Có lỗi khi cập nhật trạng thái chuyển điểm: " + ex.Message);
                    }
                }
                else
                    ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
            }
        }

        private void grvDanhSach_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvDanhSach_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvDanhSach, "Chon", e);
        }
    }
}