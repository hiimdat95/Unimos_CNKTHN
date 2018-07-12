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
    public partial class frmXetHocBong : frmBase
    {
        private cBTC_QuyHocBong oBTC_QuyHocBong;
        private TC_QuyHocBongInfo pTC_QuyHocBongInfo;
        private cBTC_PhanBoQuyHocBong oBTC_PhanBoQuyHocBong;
        private TC_PhanBoQuyHocBongInfo pTC_PhanBoQuyHocBongInfo;
        private DataTable dtDoiTuongPhanBo;

        public frmXetHocBong()
        {
            InitializeComponent();
            pTC_QuyHocBongInfo = new TC_QuyHocBongInfo();
            oBTC_QuyHocBong = new cBTC_QuyHocBong();
            pTC_PhanBoQuyHocBongInfo = new TC_PhanBoQuyHocBongInfo();
            oBTC_PhanBoQuyHocBong = new cBTC_PhanBoQuyHocBong();
        }

        private void frmXetHocBong_Load(object sender, EventArgs e)
        {
            LoadCombo();
           // GetDoiTuong();
        }
        private void LoadCombo()
        {
            cmbHe.Properties.DataSource = LoadHe();
            cmbTrinhDo.Properties.DataSource = LoadTrinhDo();
            DataTable dtTemp = oBTC_QuyHocBong.Get(pTC_QuyHocBongInfo);
            cmbLoaiQuy.Properties.DataSource = dtTemp;
            if (dtTemp != null && dtTemp.Rows.Count > 0)
                cmbLoaiQuy.EditValue = dtTemp.Rows[0]["TC_QuyHocBongID"];

        }

        private void GetDoiTuong()
        {
            dtDoiTuongPhanBo = oBTC_PhanBoQuyHocBong.GetByQuyHocBong(int.Parse(cmbLoaiQuy.EditValue.ToString()), Program.IDNamHoc, Program.HocKy, 1);
            cmbDoiTuong.Properties.DataSource = dtDoiTuongPhanBo;
        }
    }
}