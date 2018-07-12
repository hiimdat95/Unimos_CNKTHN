using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UnimOs.UI
{
    public partial class dlgQuyetDinhTotNghiep_DanhSoBang : frmBase
    {
        private Lib.Ini clsIni;
        private DataTable dtSinhVien;

        public dlgQuyetDinhTotNghiep_DanhSoBang(ref DataTable _dtSinhVien)
        {
            InitializeComponent();

            clsIni = new Lib.Ini(Application.StartupPath+"\\truongviet.ini");

            dtSinhVien = _dtSinhVien;
        }

        private void dlgQuyetDinhTotNghiep_DanhSoBang_Load(object sender, EventArgs e)
        {
            GetIni();
        }

        private void GetIni()
        {
            string str = "";
            str = clsIni.ReadValue("DANH_SO_BANG", "PhanDau");
            if (str != "")
                txtPhanDau.Text = str;
            str = clsIni.ReadValue("DANH_SO_BANG", "DoDaiTuTang");
            if (str != "")
                txtDoDai.EditValue = int.Parse(str);
            str = clsIni.ReadValue("DANH_SO_BANG", "PhanCuoi");
            if (str != "")
                txtPhanCuoi.Text = str;
        }

        private void SaveIni()
        {
            clsIni.WriteValue("DANH_SO_BANG", "PhanDau", "" + txtPhanDau.Text.Trim());
            clsIni.WriteValue("DANH_SO_BANG", "DoDaiTuTang", "" + txtDoDai.EditValue);
            clsIni.WriteValue("DANH_SO_BANG", "PhanCuoi", "" + txtPhanCuoi.Text.Trim());
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            int TuSo = int.Parse(txtTuSo.EditValue.ToString()), DoDai = int.Parse(txtDoDai.EditValue.ToString());
            string PhanDau = txtPhanDau.Text.Trim(), PhanCuoi = txtPhanCuoi.Text.Trim();

            foreach (DataRow dr in dtSinhVien.Rows)
            {
                dr["SoBang"] = PhanDau + TuSo.ToString().PadLeft(DoDai, '0') + PhanCuoi;
                TuSo++;
            }
            SaveIni();
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
