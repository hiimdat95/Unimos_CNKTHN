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
    public partial class frmCongThucDiem : frmBase
    {
        private cBKQHT_CongThucDiem oBKQHT_CongThucDiem;
        private KQHT_CongThucDiemInfo pKQHT_CongThucDiemInfo;
        private DataTable dtCongThuc;
        private DataRow drCongThuc;
        private int IDDM_Lop = 0;

        public frmCongThucDiem()
        {
            InitializeComponent();
            oBKQHT_CongThucDiem = new cBKQHT_CongThucDiem();
            pKQHT_CongThucDiemInfo = new KQHT_CongThucDiemInfo();
        }

        private void frmCongThucDiem_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            DM_LopInfo pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                IDDM_Lop = pDM_LopInfo.DM_LopID;
            }
            dtCongThuc = oBKQHT_CongThucDiem.GetByHocKyNamHoc(IDDM_Lop, Program.IDNamHoc, Program.HocKy);
            grdCongThucDiemMon.DataSource = dtCongThuc;
        }

        private void grvCongThucDiemMon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                barbtnThem_ItemClick(null, null);
            }
            else if (e.KeyCode == Keys.F3)
            {
                barbtnSua_ItemClick(null, null);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                barbtnXoa_ItemClick(null, null);
            }
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IDDM_Lop > 0)
            {
                pKQHT_CongThucDiemInfo = new KQHT_CongThucDiemInfo();
                dlgCongThucDiem dlg = new dlgCongThucDiem(dtCongThuc, null, EDIT_MODE.THEM, IDDM_Lop);
                dlg.ShowDialog();
            }
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (drCongThuc != null)
            {
                pKQHT_CongThucDiemInfo = new KQHT_CongThucDiemInfo();
                oBKQHT_CongThucDiem.ToInfo(ref pKQHT_CongThucDiemInfo, drCongThuc);
                dlgCongThucDiem dlg = new dlgCongThucDiem(dtCongThuc, drCongThuc, EDIT_MODE.SUA, IDDM_Lop);
                dlg.ShowDialog();
            }
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (drCongThuc != null)
            {
                oBKQHT_CongThucDiem.ToInfo(ref pKQHT_CongThucDiemInfo, drCongThuc);
                oBKQHT_CongThucDiem.Delete(pKQHT_CongThucDiemInfo);
                dtCongThuc.Rows.Remove(drCongThuc);
                XoaThanhCong();
            }
            else
                ThongBao("Bạn chưa chọn công thức điểm nào.");
        }

        private void grvCongThucDiemMon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvCongThucDiemMon.DataRowCount > 0)
            {
                if (grvCongThucDiemMon.FocusedRowHandle >= 0)
                {
                    drCongThuc = grvCongThucDiemMon.GetDataRow(grvCongThucDiemMon.FocusedRowHandle);
                }
                else
                    drCongThuc = null;
            }
            else
                drCongThuc = null;
        }

        private void grdCongThucDiemMon_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && grdCongThucDiemMon.ClientRectangle.Contains(e.X, e.Y))
            {
                popupMenu.ShowPopup(MousePosition);
            }
        }
    }
}