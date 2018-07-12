using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Business;

namespace UnimOs.UI
{
    public partial class dlgCT_KhoiKienThucKeThua : frmBase 
    {
       public KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo;
       private int MaxCTSo;
        public dlgCT_KhoiKienThucKeThua(KQHT_CT_KhoiKienThucInfo mKQHT_CT_KhoiKienThucInfo, int mMaxCTSo)
        {
            InitializeComponent();
          
            pKQHT_CT_KhoiKienThucInfo = mKQHT_CT_KhoiKienThucInfo;
            MaxCTSo = mMaxCTSo;
            this.Tag = "";
        }

        private void dlgCT_KhoiKienThucKeThua_Load(object sender, EventArgs e)
        {
            DataTable dtKhoiKienThuc = LoadKhoiKienThuc();
            cmbKhoiKienThuc.Properties.DataSource = dtKhoiKienThuc;
            cmbKhoiKienThucMoi.Properties.DataSource = dtKhoiKienThuc;

            DataTable dtTrinhDo = LoadTrinhDo();
            cmbTrinhDo.Properties.DataSource = dtTrinhDo;
            cmbTrinhDoMoi.Properties.DataSource = dtTrinhDo;

            DataTable dtKhoaHoc = LoadKhoaHoc();
            cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;
            cmbKhoaHocMoi.Properties.DataSource = dtKhoaHoc;

            DataTable dtNganh = LoadNganh();
            cmbNganh.Properties.DataSource = dtNganh;
            cmbNganhMoi.Properties.DataSource = dtNganh;
            // do du lieu vao khoi kien thuc
            txtTenCT.Text = pKQHT_CT_KhoiKienThucInfo.TenCT_KhoiKienThuc;
        //    txtCTSo.Text = pKQHT_CT_KhoiKienThucInfo.CT_KhoiKienThucSo.ToString();
            txtSoHocTrinh.Text = pKQHT_CT_KhoiKienThucInfo.TongSoHocTrinh.ToString();
            cmbKhoiKienThuc.EditValue = pKQHT_CT_KhoiKienThucInfo.IDDM_KhoiKienThuc;
            cmbKhoaHoc.EditValue = pKQHT_CT_KhoiKienThucInfo.IDDM_KhoaHoc;
            cmbTrinhDo.EditValue = pKQHT_CT_KhoiKienThucInfo.IDDM_TrinhDo;
            cmbNganh.EditValue = pKQHT_CT_KhoiKienThucInfo.IDDM_Nganh;
            cmbChuyenNganh.EditValue = pKQHT_CT_KhoiKienThucInfo.IDDM_ChuyenNganh;
            // do du lieu vao khoi kien thuc ke thua
            txtTenCTMoi.Text = pKQHT_CT_KhoiKienThucInfo.TenCT_KhoiKienThuc;
          //  txtCTSoMoi.Text = (MaxCTSo+1).ToString();
            txtSoHocTrinhMoi.Text = pKQHT_CT_KhoiKienThucInfo.TongSoHocTrinh.ToString();
            cmbKhoiKienThucMoi.EditValue = pKQHT_CT_KhoiKienThucInfo.IDDM_KhoiKienThuc;
            cmbKhoaHocMoi.EditValue = pKQHT_CT_KhoiKienThucInfo.IDDM_KhoaHoc;
            cmbTrinhDoMoi.EditValue = pKQHT_CT_KhoiKienThucInfo.IDDM_TrinhDo;
            cmbNganhMoi.EditValue = pKQHT_CT_KhoiKienThucInfo.IDDM_Nganh;
            cmbChuyenNganhMoi.EditValue = pKQHT_CT_KhoiKienThucInfo.IDDM_ChuyenNganh;
           
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void cmbNganhMoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbNganhMoi.EditValue = null;
        }

        private void cmbChuyenNganhMoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbChuyenNganhMoi.EditValue = null;
        }

        private void cmbNganh_EditValueChanged(object sender, EventArgs e)
        {
            cmbChuyenNganh.Properties.DataSource = LoadChuyenNganh(cmbNganh.EditValue == null ? 0 : int.Parse(cmbNganh.EditValue.ToString()));
        }

        private void cmbNganhMoi_EditValueChanged(object sender, EventArgs e)
        {
            cmbChuyenNganhMoi.Properties.DataSource = LoadChuyenNganh(cmbNganhMoi.EditValue == null ? 0 : int.Parse(cmbNganhMoi.EditValue.ToString()));
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtTenCTMoi.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenCTMoi, "Tên chương trình không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenCTMoi;
            }
            if (txtCTSoMoi.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtCTSoMoi, "Chương trình số không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtCTSoMoi;
            }

            if ((CtrlErr != null))
                return false;
            else
                return true;
        }
        private void GetpInfo()
        {
            pKQHT_CT_KhoiKienThucInfo.TenCT_KhoiKienThuc = txtTenCTMoi.Text.Trim();
            pKQHT_CT_KhoiKienThucInfo.IDDM_KhoiKienThuc = int.Parse(cmbKhoiKienThucMoi.EditValue.ToString());
            pKQHT_CT_KhoiKienThucInfo.IDDM_TrinhDo = int.Parse(cmbTrinhDoMoi.EditValue.ToString());
            pKQHT_CT_KhoiKienThucInfo.IDDM_KhoaHoc = int.Parse(cmbKhoaHocMoi.EditValue.ToString());
            pKQHT_CT_KhoiKienThucInfo.IDDM_Nganh = cmbNganhMoi.EditValue == null ? -1 : int.Parse(cmbNganhMoi.EditValue.ToString());
            pKQHT_CT_KhoiKienThucInfo.IDDM_ChuyenNganh = cmbChuyenNganhMoi.EditValue == null ? -1 : int.Parse(cmbChuyenNganhMoi.EditValue.ToString());
            pKQHT_CT_KhoiKienThucInfo.CT_KhoiKienThucSo = int.Parse("0" + txtCTSoMoi.Text);
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            try
            {
                GetpInfo();              
                this.Tag = "1";
                this.Close();
            }
            catch (Exception ex)
            {
                ThongBao(ex.Message);
            }
        }
    }
}