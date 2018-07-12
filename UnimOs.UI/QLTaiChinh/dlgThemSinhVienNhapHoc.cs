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
    public partial class dlgThemSinhVienNhapHoc : frmBase
    {
        private SV_SinhVienNhapTruongInfo pSV_SinhVienNhapTruongInfo;
        private cBSV_SinhVienNhapTruong oBSV_SinhVienNhapTruong;
        public dlgThemSinhVienNhapHoc()
        {
            InitializeComponent();
            pSV_SinhVienNhapTruongInfo = new SV_SinhVienNhapTruongInfo();
            oBSV_SinhVienNhapTruong = new cBSV_SinhVienNhapTruong();
            this.DialogResult = DialogResult.Cancel;
        }

        private void dlgThemSinhVienNhapHoc_Load(object sender, EventArgs e)
        {
            cmbGioiTinh.Properties.DataSource = LoadGioiTinh();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtHoVaTen.Text.Trim() != "")
            {
                pSV_SinhVienNhapTruongInfo.GioiTinhTS= (cmbGioiTinh.EditValue ==  null?0: int.Parse(cmbGioiTinh.EditValue.ToString()));
                pSV_SinhVienNhapTruongInfo.HoVaTenTS = txtHoVaTen.Text.Trim();
                pSV_SinhVienNhapTruongInfo.SoBaoDanhTS = txtSoBaoDanh.Text.Trim();
                pSV_SinhVienNhapTruongInfo.ThuongTruTS = txtThuongTru.Text.Trim();
                pSV_SinhVienNhapTruongInfo.NoiSinhTS = txtNoiSinh.Text.Trim();
                pSV_SinhVienNhapTruongInfo.DaXetDuyet = false;
                pSV_SinhVienNhapTruongInfo.NgayNhapTruong = DateTime.Now;
                pSV_SinhVienNhapTruongInfo.IDDM_NamHoc = Program.IDNamHoc;
                pSV_SinhVienNhapTruongInfo.IDNguoiTiepNhan = Program.objUserCurrent.HT_UserID;
                pSV_SinhVienNhapTruongInfo.KhoiThi = txtKhoiThi.Text.Trim();
                pSV_SinhVienNhapTruongInfo.NganhThi = txtNganhThi.Text.Trim();
                if (dtpNgaySinh.EditValue != null)
                    pSV_SinhVienNhapTruongInfo.NgaySinhTS = DateTime.Parse(dtpNgaySinh.EditValue.ToString());
                else
                    pSV_SinhVienNhapTruongInfo.NgaySinhTS = DateTime.Parse("1/1/1900");
               
                oBSV_SinhVienNhapTruong.Add(pSV_SinhVienNhapTruongInfo);
                ThongBao("Thêm mới sinh viên nhập học thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                ThongBao("Bắt buộc phải nhập họ và tên cho sinh viên!");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}