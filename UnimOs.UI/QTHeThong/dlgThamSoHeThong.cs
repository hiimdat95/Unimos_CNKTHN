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
    public partial class dlgThamSoHeThong : frmBase
    {
        private HT_ThamSoHeThongInfo pThamSoHeThongInfo;
        public bool Result = false;

        public dlgThamSoHeThong(HT_ThamSoHeThongInfo mThamSoHeThongInfo)
        {
            InitializeComponent();
            pThamSoHeThongInfo = mThamSoHeThongInfo;
        }

        private void dlgThamSoHeThong_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            txtMaThamSo.Text = pThamSoHeThongInfo.MaThamSoHeThong;
            txtTenThamSo.Text = pThamSoHeThongInfo.TenThamSoHeThong;
            txtGiaTri.Text = pThamSoHeThongInfo.GiaTri;
            txtGhiChu.Text = pThamSoHeThongInfo.GhiChu;
            chkTrangThai.Checked = pThamSoHeThongInfo.TrangThai;
        }

        private void GetData()
        {
            pThamSoHeThongInfo.MaThamSoHeThong = txtMaThamSo.Text;
            pThamSoHeThongInfo.TenThamSoHeThong = txtTenThamSo.Text;
            pThamSoHeThongInfo.GiaTri = txtGiaTri.Text;
            pThamSoHeThongInfo.GhiChu = txtGhiChu.Text;
            pThamSoHeThongInfo.TrangThai = chkTrangThai.Checked;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            cBHT_ThamSoHeThong oBThamSoHeThong = new cBHT_ThamSoHeThong();
            GetData();
            oBThamSoHeThong.Update(pThamSoHeThongInfo);
            Result = true;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Result = false;
            this.Close();
        }
    }
}