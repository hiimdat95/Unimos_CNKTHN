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
    public partial class dlgCT_KhoiKienThuc : frmBase
    {
        public KQHT_CT_KhoiKienThucInfo pCTDT;
        private EDIT_MODE edit;
        private int MaxCTSo;

        public dlgCT_KhoiKienThuc(KQHT_CT_KhoiKienThucInfo mpCTDT, EDIT_MODE mEdit, int mMaxCTSo)
        {
            InitializeComponent();
            pCTDT = mpCTDT;
            edit = mEdit;
            MaxCTSo = mMaxCTSo;

        }

        private void dlgCT_KhoiKienThuc_Load(object sender, EventArgs e)
        {
            DataTable dtKhoiKienThuc =  LoadKhoiKienThuc();
            cmbKhoiKienThuc.Properties.DataSource = dtKhoiKienThuc;

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
                txtTenCTDT.Text = pCTDT.TenCT_KhoiKienThuc;
               // txtSo.Text = pCTDT.CT_KhoiKienThucSo.ToString();
                cmbKhoiKienThuc.EditValue = pCTDT.IDDM_KhoiKienThuc;
                cmbKhoaHoc.EditValue = pCTDT.IDDM_KhoaHoc;
                cmbTrinhDo.EditValue = pCTDT.IDDM_TrinhDo;
                ucmbNganh.cmb.EditValue = pCTDT.IDDM_Nganh;
                ucmbChuyenNganh.cmb.EditValue = pCTDT.IDDM_ChuyenNganh;
            }
            else
            {
                //txtSo.Text = (MaxCTSo +1).ToString();
                if (dtKhoiKienThuc.Rows.Count > 0)
                    cmbKhoiKienThuc.ItemIndex = 0;
                if (dtTrinhDo.Rows.Count > 0)
                    cmbTrinhDo.ItemIndex = 0;
                if (dtKhoaHoc.Rows.Count > 0)
                    cmbKhoaHoc.ItemIndex = 0;
            }
        }

        private void GetpInfo()
        {
            pCTDT.TenCT_KhoiKienThuc = txtTenCTDT.Text.Trim();
            pCTDT.IDDM_KhoiKienThuc = int.Parse(cmbKhoiKienThuc.EditValue.ToString());
            pCTDT.IDDM_TrinhDo = int.Parse(cmbTrinhDo.EditValue.ToString());
            pCTDT.IDDM_KhoaHoc = int.Parse(cmbKhoaHoc.EditValue.ToString());
            pCTDT.IDDM_Nganh = ucmbNganh.cmb.EditValue == null ? -1 : int.Parse(ucmbNganh.cmb.EditValue.ToString());
            pCTDT.IDDM_ChuyenNganh = ucmbChuyenNganh.cmb.EditValue == null ? -1 : int.Parse(ucmbChuyenNganh.cmb.EditValue.ToString());
            pCTDT.CT_KhoiKienThucSo = int.Parse("0" + txtSo.Text);
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtTenCTDT.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenCTDT, "Tên chương trình không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenCTDT;
            }
            if (txtSo.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtSo, "Chương trình số không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtSo;
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