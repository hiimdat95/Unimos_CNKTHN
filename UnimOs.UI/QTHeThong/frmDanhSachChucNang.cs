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
    public partial class frmDanhSachChucNang : frmBase
    {
        private DataTable dtChucNang;
        private cBHT_ChucNang oBHT_ChucNang;
        private HT_ChucNangInfo pHT_ChucNangInfo;

        public frmDanhSachChucNang()
        {
            InitializeComponent();
            oBHT_ChucNang = new cBHT_ChucNang();
            pHT_ChucNangInfo = new HT_ChucNangInfo();
        }

        private void frmDanhSachChucNang_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            dtChucNang = oBHT_ChucNang.GetNotIn(1, 0);
            trlChucNang.DataSource = dtChucNang;
            trlChucNang.ExpandAll();
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int HT_ChucNangID = 0;
            if (trlChucNang.AllNodesCount > 0)
                HT_ChucNangID = int.Parse(trlChucNang.FocusedNode["HT_ChucNangID"].ToString());
            dlgThemChucNang dlg = new dlgThemChucNang(trlChucNang, dtChucNang, HT_ChucNangID, TruongViet.UnimOs.Entity.EDIT_MODE.THEM);
            dlg.ShowDialog();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int HT_ChucNangID = 0;
            if (trlChucNang.AllNodesCount > 0)
                HT_ChucNangID = int.Parse(trlChucNang.FocusedNode["HT_ChucNangID"].ToString());
            dlgThemChucNang dlg = new dlgThemChucNang(trlChucNang, dtChucNang, HT_ChucNangID, TruongViet.UnimOs.Entity.EDIT_MODE.SUA);
            dlg.ShowDialog();
        }

        private void frmDanhSachChucNang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
                barbtnSua_ItemClick(null, null);
            else if (e.KeyCode == Keys.F3)
                barbtnThem_ItemClick(null, null);
            else if (e.KeyCode == Keys.Delete)
                barbtnXoa_ItemClick(null, null);
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (trlChucNang.AllNodesCount <= 0) return;

            pHT_ChucNangInfo.HT_ChucNangID = int.Parse(trlChucNang.FocusedNode["HT_ChucNangID"].ToString());
            // Kiểm tra xem chức năng được chọn có chức năng con hay ko. Nếu có thì thông báo
            foreach (DataRow dr in dtChucNang.Rows)
            {
                if (int.Parse(dr["ParentID"].ToString()) == pHT_ChucNangInfo.HT_ChucNangID)
                {
                    ThongBao("Chức năng bạn chọn có chức năng con. Cần phải xóa các chức năng con trước.");
                    return;
                }
            }
            oBHT_ChucNang.Delete(pHT_ChucNangInfo);
            DataRow[] drDel = dtChucNang.Select("HT_ChucNangID = " + pHT_ChucNangInfo.HT_ChucNangID.ToString());
            dtChucNang.Rows.Remove(drDel[0]);
        }
    }
}