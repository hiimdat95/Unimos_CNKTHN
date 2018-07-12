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
    public partial class dlgLuaChonMonThucHanh : frmBase
    {
        private DataTable dtMonKy, dtMonThucHanh;
        private int IDDM_Lop;

        public dlgLuaChonMonThucHanh()
        {
            InitializeComponent();
        }

        private void dlgLuaChonMonThucHanh_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            DM_LopInfo pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null && pDM_LopInfo.DM_LopID > 0)
            {
                IDDM_Lop = pDM_LopInfo.DM_LopID;
                LoadMonKy(IDDM_Lop);
                LoadMonThucHanh(IDDM_Lop);
            }
        }

        private void LoadMonKy(int IDDM_Lop)
        {
            dtMonKy = (new cBXL_MonHocTrongKy()).GetMonKyChuaThucHanh(IDDM_Lop, Program.IDNamHoc, Program.HocKy);
            grdMonHocTrongKy.DataSource = dtMonKy;
        }

        private void LoadMonThucHanh(int IDDM_Lop)
        {
            dtMonThucHanh = (new cBXL_KeHoachThucHanh()).GetMonThucHanh(0, IDDM_Lop, Program.IDNamHoc, Program.HocKy);
            grdMonThucHanh.DataSource = dtMonThucHanh;
        }

        private void grvMonHocTrongKy_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvMonThucHanh_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.Name == "gridColumnHienThi")
            {
                e.Appearance.BackColor = Color.FromArgb(int.Parse(grvMonThucHanh.GetDataRow(e.RowHandle)["MauNen"].ToString()));
                e.Appearance.ForeColor = Color.FromArgb(int.Parse(grvMonThucHanh.GetDataRow(e.RowHandle)["MauChu"].ToString()));
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dtMonKy != null)
            {
                if (grvMonHocTrongKy.FocusedRowHandle >= 0)
                {
                    DataRow dr = dtMonThucHanh.NewRow();
                    dlgThemMonThucHanh dlg = new dlgThemMonThucHanh(ref dr, IDDM_Lop, grvMonHocTrongKy.GetDataRow(grvMonHocTrongKy.FocusedRowHandle), EDIT_MODE.THEM);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        dtMonThucHanh.Rows.Add(dr);
                        ThemThanhCong();
                    }
                    return;
                }
            }
            ThongBao("Bạn chưa chọn môn học nào để tạo kế hoạch thực hành.");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtMonThucHanh != null)
            {
                if (grvMonThucHanh.FocusedRowHandle >= 0)
                {
                    DataRow drMonThucHanh = grvMonThucHanh.GetDataRow(grvMonThucHanh.FocusedRowHandle);
                    dlgThemMonThucHanh dlg = new dlgThemMonThucHanh(ref drMonThucHanh, IDDM_Lop, drMonThucHanh, EDIT_MODE.SUA);
                    if (dlg.ShowDialog() == DialogResult.OK)
                        SuaThanhCong();
                    return;
                }
            }
            ThongBao("Hiện chưa có môn thực hành nào trong lớp được chọn để sửa.");
        }
    }
}