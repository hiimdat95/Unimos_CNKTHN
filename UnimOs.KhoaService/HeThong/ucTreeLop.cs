using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using TruongViet.UnimOs.Entity;

namespace UnimOs.Khoa
{
    public partial class ucTreeLop : DevExpress.XtraEditors.XtraUserControl
    {
        public ucTreeLop()
        {
            InitializeComponent();
        }

        private void chkExpandAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpandAll.Checked)
                trlLop.ExpandAll();
            else
                trlLop.CollapseAll();
        }

        public DM_LopInfo GetNodeSelected()
        {
            if (trlLop.Nodes.Count > 0)
            {
                DM_LopInfo pDM_LopInfo = new DM_LopInfo();
                TreeListNode node = trlLop.FocusedNode;
                pDM_LopInfo.TenLop = node["TenLop"].ToString();
                pDM_LopInfo.DM_LopID = int.Parse(node["IDDM_Lop"].ToString());
                pDM_LopInfo.IDDM_Khoa = int.Parse(node["IDDM_Khoa"].ToString());
                pDM_LopInfo.IDDM_He = int.Parse(node["IDDM_He"].ToString());
                pDM_LopInfo.IDDM_TrinhDo = int.Parse(node["IDDM_TrinhDo"].ToString());
                pDM_LopInfo.IDDM_KhoaHoc = int.Parse(node["IDDM_KhoaHoc"].ToString());
                pDM_LopInfo.IDDM_Nganh = int.Parse(node["IDDM_Nganh"].ToString());
                pDM_LopInfo.IDDM_ChuyenNganh = int.Parse(node["IDDM_ChuyenNganh"].ToString());
                pDM_LopInfo.IDDM_DiaDiem = int.Parse(node["IDDM_DiaDiem"].ToString());
                return pDM_LopInfo;
            }
            else
                return null;
        }

        private void trlLop_AfterExpand(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                e.Node.ExpandAll();
            }
        }
    }
}
