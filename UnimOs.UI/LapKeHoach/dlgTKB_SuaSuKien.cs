using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.Entity;

namespace UnimOs.UI
{
    public partial class dlgTKB_SuaSuKien : frmBase
    {
        private bool Loaded = false;
        private XL_SuKienTKBInfo sk;
        public dlgTKB_SuaSuKien(DataTable _dtTuan, ref XL_SuKienTKBInfo _sk, int IDXL_Tuan)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            sk = _sk;
            EditTable(_dtTuan);
            lblLop.Text = sk.TenLop;
            lblMonHoc.Text = sk.TenMon;
            cmbTuTuan.Properties.DataSource = _dtTuan;
            cmbDenTuan.Properties.DataSource = _dtTuan;

            cmbGiaoVien.EditValue = sk.IDNS_GiaoVien;
            cmbPhongHoc.EditValue = sk.IDDM_PhongHoc;
            cmbBuoiHoc.SelectedIndex = (int)sk.CaHoc;

            cmbTuTuan.EditValue = IDXL_Tuan;
            cmbDenTuan.EditValue = IDXL_Tuan;
            Loaded = true;
        }

        private void EditTable(DataTable dtTuan)
        {
            if (!dtTuan.Columns.Contains("TenTuan"))
                dtTuan.Columns.Add("TenTuan", typeof(string));
            foreach (DataRow dr in dtTuan.Rows)
            {
                dr["TenTuan"] = dr["TuanThu"].ToString() + " (" + string.Format("{0:dd/MM/yyyy}", dr["TuNgay"]) + 
                    " - " + string.Format("{0:dd/MM/yyyy}", dr["DenNgay"]) + ")";
            }
        }

        private bool CheckValid()
        {
            return true;
        }

        private void chkApDung_CheckedChanged(object sender, EventArgs e)
        {
            cmbTuTuan.Properties.ReadOnly = !chkApDung.Checked;
            cmbDenTuan.Properties.ReadOnly = !chkApDung.Checked;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            sk.CaHoc = (CA_HOC)cmbBuoiHoc.SelectedIndex;
            sk.IDNS_GiaoVien = cmbGiaoVien.EditValue == null ? 0 : int.Parse(cmbGiaoVien.EditValue.ToString());
            sk.TenGiaoVien = cmbGiaoVien.Text;
            sk.TenVietTat = cmbGiaoVien.EditValue == null ? "" : "" + cmbGiaoVien.GetColumnValue("TenVietTat");
            sk.IDDM_PhongHoc = cmbPhongHoc.EditValue == null ? 0 : int.Parse(cmbPhongHoc.EditValue.ToString());
            sk.TenPhong = cmbPhongHoc.EditValue == null ? "" : cmbPhongHoc.Text;
            sk.Changed = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTuTuan_EditValueChanged(object sender, EventArgs e)
        {
            if (Loaded)
            {
                if (cmbTuTuan.ItemIndex > cmbDenTuan.ItemIndex)
                    cmbDenTuan.ItemIndex = cmbTuTuan.ItemIndex;
                else if (cmbDenTuan.ItemIndex < cmbTuTuan.ItemIndex)
                    cmbTuTuan.ItemIndex = cmbDenTuan.ItemIndex;
            }
        }
    }
}