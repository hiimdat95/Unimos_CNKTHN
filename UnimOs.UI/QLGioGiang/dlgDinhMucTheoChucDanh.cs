using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;

namespace UnimOs.UI
{
    public partial class dlgDinhMucTheoChucDanh : frmBase
    {
        cBDM_ChucDanh oBDM_ChucDanh = new cBDM_ChucDanh();
        GG_DinhMucTheoChucDanhInfo info;
        cBGG_DinhMucTheoChucDanh oBGG_DinhMucTheoChucDanh;
        public dlgDinhMucTheoChucDanh(GG_DinhMucTheoChucDanhInfo _info,string ChucDanh)
        {
            InitializeComponent();
            info = _info;
            cmbChucDanh.Properties.DataSource = oBDM_ChucDanh.GetChucDanhChuaDinhMuc();
            if (info.GG_DinhMucTheoChucDanhID > 0)
            {
                cmbChucDanh.Properties.NullText = ChucDanh;
                cmbChucDanh.Properties.ReadOnly = true;
                //cmbChucDanh.Enabled = false;
                txtGioLamViec.Text = info.GioLamViec.ToString();
                txtHeSo.Text = info.HeSo.ToString();
                txtHeSoQuyDoi.Text = info.HeSoGioChuan.ToString();
                txtSoGioChuan.Text = info.GioChuanGiang.ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           oBGG_DinhMucTheoChucDanh = new cBGG_DinhMucTheoChucDanh();
           if (info.GG_DinhMucTheoChucDanhID > 0)
           {
               oBGG_DinhMucTheoChucDanh.Update(getInfo());
           }
           else
           {
               oBGG_DinhMucTheoChucDanh.Add(getInfo());
           }
           this.DialogResult = DialogResult.OK;
           this.Close();           
        }

        private GG_DinhMucTheoChucDanhInfo getInfo()
        {
            info.GioChuanGiang = double.Parse(txtSoGioChuan.Text);
            info.GioLamViec = double.Parse(txtGioLamViec.Text);
            info.HeSo = double.Parse(txtHeSo.Text);
            info.HeSoGioChuan = double.Parse(txtHeSoQuyDoi.Text);
            if (info.IDDM_ChucDanh <= 0)
            {
                info.IDDM_ChucDanh = (int)cmbChucDanh.EditValue;
            }
            return info;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtHeSoQuyDoi_Leave(object sender, EventArgs e)
        {
            txtSoGioChuan.Text = (double.Parse(txtGioLamViec.Text) / double.Parse(txtHeSoQuyDoi.Text)).ToString();
        }
    }
}
