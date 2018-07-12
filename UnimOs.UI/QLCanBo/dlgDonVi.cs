using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;
using DevExpress.XtraEditors;

namespace UnimOs.UI
{
    public partial class dlgDonVi : frmBase
    {
        private cBNS_DonVi oBDonVi;
        private NS_DonViInfo pDonViInfo;
        private EDIT_MODE EditMode;
        private bool InsertParent;
        private DataTable dtTree, dtBoMon;
        private int ParentIDs, Level;

        public dlgDonVi(DataTable mdtTree ,NS_DonViInfo mDonViInfo, int mParentIDs, EDIT_MODE mEditMode, bool mInsertParent)
        {
            InitializeComponent();
            pDonViInfo = mDonViInfo;
            Level = pDonViInfo.Level;
            dtTree = mdtTree;
            ParentIDs = mParentIDs;
            EditMode = mEditMode;
            InsertParent = mInsertParent;

            uccmbKhoa.cmb.Properties.Columns.AddRange((new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { 
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaKhoa","Mã Khoa"), 
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenKhoa","Tên Khoa")}));
            uccmbKhoa.cmb.Properties.DisplayMember = "TenKhoa";
            uccmbKhoa.cmb.Properties.ValueMember = "DM_KhoaID";
            uccmbKhoa.cmb.Properties.DataSource = LoadKhoa();
            uccmbKhoa.cmb.EditValueChanged += new EventHandler(cmb_EditValueChanged);

            dtBoMon = LoadBoMon();
            uccmbBoMon.cmb.Properties.Columns.AddRange((new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { 
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaBoMon","Mã bộ môn"), 
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenBoMon","Tên bộ môn")}));
            uccmbBoMon.cmb.Properties.DisplayMember = "TenBoMon";
            uccmbBoMon.cmb.Properties.ValueMember = "DM_BoMonID";
            uccmbBoMon.cmb.Properties.DataSource = dtBoMon;
        }

        void cmb_EditValueChanged(object sender, EventArgs e)
        {
            if (uccmbKhoa.cmb.EditValue != null)
            {
                DataTable dtTemp = dtBoMon.Copy();
                dtTemp.DefaultView.RowFilter = "IDDM_Khoa = " + uccmbKhoa.cmb.EditValue.ToString();
                uccmbBoMon.cmb.Properties.DataSource = dtTemp.DefaultView;
            }
            else
                uccmbBoMon.cmb.Properties.DataSource = dtBoMon;
        }
        
        private void dlgDonVi_Load(object sender, EventArgs e)
        {
            
            if (EditMode == EDIT_MODE.SUA)
            {
                txtMaDV.Text = pDonViInfo.MaDonVi;
                txtTenDV.Text = pDonViInfo.TenDonVi;
                uccmbKhoa.cmb.EditValue = pDonViInfo.IDDM_Khoa;
                uccmbBoMon.cmb.EditValue = pDonViInfo.IDDM_BoMon;
            }
           
        }
        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtMaDV.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtMaDV, "Mã đơn vị không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMaDV;
            }
            if (txtTenDV.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenDV, "Tên đơn vị không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenDV;
            }          
            if ((CtrlErr != null))
                return false;
            else
                return true;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            Tag = 0;
            Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            Tag = 1;
            oBDonVi = new cBNS_DonVi();
            ReadTextBox();
            DataRow drNew;
            if (EditMode == EDIT_MODE.SUA)
            {
                oBDonVi.Update(pDonViInfo);
                GhiLog("Sửa đơn vị '" + pDonViInfo.TenDonVi + "'", "Sửa", this.Tag.ToString());
                SuaThanhCong();
                this.Close();
            }
            else if (EditMode == EDIT_MODE.THEM && InsertParent == true)
            {
                pDonViInfo.NS_DonViID = oBDonVi.Add(pDonViInfo);
                drNew = dtTree.NewRow();
                oBDonVi.ToDataRow(pDonViInfo, ref drNew);
                drNew["ParentIDs"] = ParentIDs;
                dtTree.Rows.Add(drNew);
                // ghi log
                GhiLog("Thêm đơn vị '" + pDonViInfo.TenDonVi + "'", "Thêm", this.Tag.ToString());
                //ThemThanhCong();
            }
            else if (EditMode == EDIT_MODE.THEM && InsertParent == false)
            {
                pDonViInfo.ParentID = pDonViInfo.NS_DonViID;
                pDonViInfo.Level = Level + 1;
                int NS_DonViID = oBDonVi.Add(pDonViInfo);
                drNew = dtTree.NewRow();
                oBDonVi.ToDataRow(pDonViInfo, ref drNew);
                drNew["ParentID"] = NS_DonViID;
                drNew["ParentIDs"] = ParentIDs;
                dtTree.Rows.Add(drNew);
                GhiLog("Thêm đơn vị '" + pDonViInfo.TenDonVi + "'", "Thêm", this.Tag.ToString());
                //ThemThanhCong();
            }
            ClearText();
        }

        private void ClearText()
        {
            txtMaDV.Text = "";
            txtTenDV.Text = "";
            txtMaDV.Focus();
        }

        private void ReadTextBox()
        {
            pDonViInfo.MaDonVi = txtMaDV.Text.Trim();
            pDonViInfo.TenDonVi = txtTenDV.Text.Trim();
            pDonViInfo.IDDM_Khoa = uccmbKhoa.cmb.EditValue == null ? -1 : int.Parse(uccmbKhoa.cmb.EditValue.ToString());
            pDonViInfo.IDDM_BoMon = uccmbBoMon.cmb.EditValue == null ? -1 : int.Parse(uccmbBoMon.cmb.EditValue.ToString());
        }
    }
}
