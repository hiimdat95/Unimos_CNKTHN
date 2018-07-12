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
    public partial class dlgChuongTrinhDaoTaoKeThua : frmBase
    {
        public KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo;
        public dlgChuongTrinhDaoTaoKeThua(KQHT_ChuongTrinhDaoTaoInfo mpKQHT_ChuongTrinhDaoTaoInfo)
        {

            InitializeComponent();
            pKQHT_ChuongTrinhDaoTaoInfo = mpKQHT_ChuongTrinhDaoTaoInfo;
            this.Tag = "";
        }

        private void dlgChuongTrinhDaoTaoKeThua_Load(object sender, EventArgs e)
        {
            DataTable dtTrinhDo = LoadTrinhDo();
            cmbTrinhDo.Properties.DataSource = dtTrinhDo;
            cmbTrinhDoMoi.Properties.DataSource = dtTrinhDo;

            DataTable dtKhoaHoc = LoadKhoaHoc();
            cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;
            cmbKhoaHocMoi.Properties.DataSource = dtKhoaHoc;

            DataTable dtNganh = LoadNganh();
            cmbNganh.Properties.DataSource = dtNganh;
            cmbNganhMoi.Properties.DataSource = dtNganh;
            // do du lieu CTDT cu.
            txtMaCTDT.Text = pKQHT_ChuongTrinhDaoTaoInfo.MaChuongTrinhDaoTao;
            txtTenCTDT.Text = pKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao;
            //txtSo.Text = pKQHT_ChuongTrinhDaoTaoInfo.ChuongTrinhDaoTaoSo.ToString();
            txtHocKy.Text = pKQHT_ChuongTrinhDaoTaoInfo.SoHocKy.ToString();
            cmbKhoaHoc.EditValue = pKQHT_ChuongTrinhDaoTaoInfo.IDDM_KhoaHoc;
            cmbTrinhDo.EditValue = pKQHT_ChuongTrinhDaoTaoInfo.IDDM_TrinhDo;
            cmbNganh.EditValue = pKQHT_ChuongTrinhDaoTaoInfo.IDDM_Nganh;
            cmbChuyenNganh.EditValue = pKQHT_ChuongTrinhDaoTaoInfo.IDDM_ChuyenNganh;
            // do du lieu CTDT moi.
            txtMaCTDTMoi.Text = pKQHT_ChuongTrinhDaoTaoInfo.MaChuongTrinhDaoTao;
            txtTenCTDTMoi.Text = pKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao;
           // txtSoMoi.Text = pKQHT_ChuongTrinhDaoTaoInfo.ChuongTrinhDaoTaoSo.ToString();
            txtHocKyMoi.Text = pKQHT_ChuongTrinhDaoTaoInfo.SoHocKy.ToString();
            txtMoTa.Text = pKQHT_ChuongTrinhDaoTaoInfo.MoTa;
            cmbKhoaHocMoi.EditValue = pKQHT_ChuongTrinhDaoTaoInfo.IDDM_KhoaHoc;
            cmbTrinhDoMoi.EditValue = pKQHT_ChuongTrinhDaoTaoInfo.IDDM_TrinhDo;
            cmbNganhMoi.EditValue = pKQHT_ChuongTrinhDaoTaoInfo.IDDM_Nganh;
            cmbChuyenNganhMoi.EditValue = pKQHT_ChuongTrinhDaoTaoInfo.IDDM_ChuyenNganh;
        }
        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtMaCTDTMoi.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtMaCTDTMoi, "Mã chương trình không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMaCTDTMoi;
            }
            if (txtTenCTDTMoi.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenCTDTMoi, "Tên chương trình không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenCTDTMoi;
            }

            if ((CtrlErr != null))
                return false;
            else
                return true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
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

        private void cmbNganh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbNganh.EditValue = null;
        }

        private void cmbChuyenNganh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbChuyenNganh.EditValue = null;
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

        private void cmbChuyenNganh_EditValueChanged(object sender, EventArgs e)
        {
            cmbChuyenNganhMoi.Properties.DataSource = LoadChuyenNganh(cmbNganhMoi.EditValue == null ? 0 : int.Parse(cmbNganhMoi.EditValue.ToString()));
        }
        private void GetpInfo()
        {
            pKQHT_ChuongTrinhDaoTaoInfo.MaChuongTrinhDaoTao = txtMaCTDTMoi.Text.Trim();
            pKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao = txtTenCTDTMoi.Text.Trim();
            pKQHT_ChuongTrinhDaoTaoInfo.ChuongTrinhDaoTaoSo = int.Parse(txtSoMoi.Text);
            pKQHT_ChuongTrinhDaoTaoInfo.SoHocKy = int.Parse(txtHocKyMoi.Text);
            pKQHT_ChuongTrinhDaoTaoInfo.MoTa = txtMoTa.Text.Trim();
            pKQHT_ChuongTrinhDaoTaoInfo.IDDM_TrinhDo = int.Parse(cmbTrinhDoMoi.EditValue.ToString());
            pKQHT_ChuongTrinhDaoTaoInfo.IDDM_KhoaHoc = int.Parse(cmbKhoaHocMoi.EditValue.ToString());
            pKQHT_ChuongTrinhDaoTaoInfo.IDDM_Nganh = cmbNganhMoi.EditValue == null ? -1 : int.Parse(cmbNganhMoi.EditValue.ToString());
            pKQHT_ChuongTrinhDaoTaoInfo.IDDM_ChuyenNganh = cmbChuyenNganhMoi.EditValue == null ? -1 : int.Parse(cmbChuyenNganhMoi.EditValue.ToString());
        }
    }
}