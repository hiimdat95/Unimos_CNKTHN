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
    public partial class dlgChonLop : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        public DM_LopInfo pDM_LopInfo;
        private bool MultiCheck;

        public dlgChonLop(bool _MultiCheck)
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            pDM_LopInfo = new DM_LopInfo();
            MultiCheck = _MultiCheck;
        }

        private void dlgChonLop_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.chkExpandAll.Checked = true;
            if (MultiCheck)
                uctrlLop.trlLop.OptionsView.ShowCheckBoxes = true;
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (pDM_LopInfo != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                ThongBao("Bạn chưa chọn lớp nào !");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}