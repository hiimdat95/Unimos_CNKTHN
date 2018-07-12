using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.Business;
using DevExpress.XtraTreeList.Nodes;

namespace UnimOs.UI
{
    public partial class dlgChonDonVi : frmBase
    {
        public int IDNS_DonVi;
        public string TenDonVi;

        public dlgChonDonVi()
        {
            InitializeComponent();

            this.DialogResult = DialogResult.Cancel;
            LoadTreeView();
        }

        private void dlgChonDonVi_Load(object sender, EventArgs e)
        {
            if (IDNS_DonVi > 0)
            {
                TreeListNode node = trvDonVi.FindNodeByFieldValue("NS_DonViID", IDNS_DonVi);
                trvDonVi.FocusedNode = node;
            }
        }

        private void LoadTreeView()
        {
            cBNS_DonVi oBDonVi = new cBNS_DonVi();
            DataTable dtTree = oBDonVi.Get_Tree();
            trvDonVi.DataSource = dtTree;
            trvDonVi.ExpandAll();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (IDNS_DonVi.ToString() != trvDonVi.FocusedNode["NS_DonViID"].ToString())
            {
                IDNS_DonVi = int.Parse(trvDonVi.FocusedNode["NS_DonViID"].ToString());
                this.DialogResult = DialogResult.Yes;
            }
            this.Close();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}