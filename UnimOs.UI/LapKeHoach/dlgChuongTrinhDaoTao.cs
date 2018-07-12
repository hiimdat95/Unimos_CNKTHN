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
    public partial class dlgChuongTrinhDaoTao : frmBase
    {
        public KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo;
        private EDIT_MODE edit;

        public dlgChuongTrinhDaoTao(KQHT_ChuongTrinhDaoTaoInfo mpKQHT_ChuongTrinhDaoTaoInfo, EDIT_MODE mEdit)
        {
            InitializeComponent();
            pKQHT_ChuongTrinhDaoTaoInfo = mpKQHT_ChuongTrinhDaoTaoInfo;
            edit = mEdit;
            this.Tag = "";
        }

        private void dlgChuongTrinhDaoTao_Load(object sender, EventArgs e)
        {
            DataTable dtTrinhDo = LoadTrinhDo();
            cmbTrinhDo.Properties.DataSource = dtTrinhDo;

            DataTable dtKhoaHoc = LoadKhoaHoc();
            cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;

            // Ngành
            ucmbNganh.cmb.Properties.DataSource = LoadNganh();
            ucmbNganh.cmb.Properties.Columns.AddRange((new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { 
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaNganh","Mã ngành"), 
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenNganh","Tên ngành")}));
            ucmbNganh.cmb.Properties.DisplayMember = "TenNganh";
            ucmbNganh.cmb.Properties.ValueMember = "DM_NganhID";
            ucmbNganh.cmb.EditValueChanged += new EventHandler(ucmbNganh_EditValueChanged);

            // Chuyên ngành
            ucmbChuyenNganh.cmb.Properties.Columns.AddRange((new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { 
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaChuyenNganh","Mã chuyên ngành"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenChuyenNganh","Tên chuyên ngành")}));
            ucmbChuyenNganh.cmb.Properties.DisplayMember = "TenChuyenNganh";
            ucmbChuyenNganh.cmb.Properties.ValueMember = "DM_ChuyenNganhID";

            if (edit == EDIT_MODE.SUA)
            {
                txtMa.Text = pKQHT_ChuongTrinhDaoTaoInfo.MaChuongTrinhDaoTao;
                txtTen.Text = pKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao;
              //  txtSo.Text = pKQHT_ChuongTrinhDaoTaoInfo.ChuongTrinhDaoTaoSo.ToString();
                txtSoHocKy.Text = pKQHT_ChuongTrinhDaoTaoInfo.SoHocKy.ToString();
                txtMoTa.Text = pKQHT_ChuongTrinhDaoTaoInfo.MoTa;
                cmbKhoaHoc.EditValue = pKQHT_ChuongTrinhDaoTaoInfo.IDDM_KhoaHoc;
                cmbTrinhDo.EditValue = pKQHT_ChuongTrinhDaoTaoInfo.IDDM_TrinhDo;
                ucmbNganh.cmb.EditValue = pKQHT_ChuongTrinhDaoTaoInfo.IDDM_Nganh;
                ucmbChuyenNganh.cmb.EditValue = pKQHT_ChuongTrinhDaoTaoInfo.IDDM_ChuyenNganh;
            }
            else
            {
                if (dtTrinhDo.Rows.Count > 0)
                    cmbTrinhDo.ItemIndex = 0;
                if (dtKhoaHoc.Rows.Count > 0)
                    cmbKhoaHoc.ItemIndex = 0;
            }
        }

        private void GetpInfo()
        {
            pKQHT_ChuongTrinhDaoTaoInfo.MaChuongTrinhDaoTao = txtMa.Text.Trim();
            pKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao = txtTen.Text.Trim();
            pKQHT_ChuongTrinhDaoTaoInfo.ChuongTrinhDaoTaoSo = int.Parse(txtSo.Text);
            pKQHT_ChuongTrinhDaoTaoInfo.SoHocKy = int.Parse(txtSoHocKy.Text);
            pKQHT_ChuongTrinhDaoTaoInfo.MoTa = txtMoTa.Text.Trim();
            pKQHT_ChuongTrinhDaoTaoInfo.IDDM_TrinhDo = int.Parse(cmbTrinhDo.EditValue.ToString());
            pKQHT_ChuongTrinhDaoTaoInfo.IDDM_KhoaHoc = int.Parse(cmbKhoaHoc.EditValue.ToString());
            pKQHT_ChuongTrinhDaoTaoInfo.IDDM_Nganh = ucmbNganh.cmb.EditValue == null ? -1 : int.Parse(ucmbNganh.cmb.EditValue.ToString());
            pKQHT_ChuongTrinhDaoTaoInfo.IDDM_ChuyenNganh = ucmbChuyenNganh.cmb.EditValue == null ? -1 : int.Parse(ucmbChuyenNganh.cmb.EditValue.ToString());
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtMa.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtMa, "Mã chương trình không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMa;
            }
            if (txtTen.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTen, "Tên chương trình không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTen;
            }

            if ((CtrlErr != null))
                return false;
            else
                return true;
        }

        void ucmbNganh_EditValueChanged(object sender, EventArgs e)
        {
            ucmbChuyenNganh.cmb.Properties.DataSource = LoadChuyenNganh(ucmbNganh.cmb.EditValue == null ? 0 : int.Parse(ucmbNganh.cmb.EditValue.ToString()));
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
                XtraMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
    }
}