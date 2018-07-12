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
    public partial class dlgLocSinhVien : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private cBSV_SinhVien oBSV_SinhVien;
        private SV_SinhVienInfo pSV_SinhVienInfo;
        private DataTable dtSinhVien;
        private dlgBienLaiThuTienChiTiet dlg ;
        private string MaSinhVien;


        public dlgLocSinhVien(dlgBienLaiThuTienChiTiet mdlg, string mMaSinhVien)
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            oBSV_SinhVien = new cBSV_SinhVien();
            pDM_LopInfo = new DM_LopInfo();
            dlg = mdlg;
            MaSinhVien = mMaSinhVien;
        }

        private void dlgLocSinhVien_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
            if (MaSinhVien != "")
            {
                pSV_SinhVienInfo = new SV_SinhVienInfo();
                pSV_SinhVienInfo.MaSinhVien = MaSinhVien;
                pSV_SinhVienInfo.HoVaTen = "";
                dtSinhVien = oBSV_SinhVien.TimKiem(pSV_SinhVienInfo);
                grdSinhVien.DataSource = dtSinhVien;
            }
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            DM_LopInfo pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                dtSinhVien = oBSV_SinhVien.GetSinhVien(pDM_LopInfo, Program.NamHoc, false);
                grdSinhVien.DataSource = dtSinhVien;
            }
            else
                grdSinhVien.DataSource = null;
        }
       
        private void btnChon_Click(object sender, EventArgs e)
        {
            if (grvSinhVien.FocusedRowHandle >= 0)
            {
                this.dlg.SV_SinhVienID = int.Parse(grvSinhVien.GetDataRow(grvSinhVien.FocusedRowHandle)["SV_SinhVienID"].ToString());
                this.dlg.MaSinhVien = grvSinhVien.GetDataRow(grvSinhVien.FocusedRowHandle)["MaSinhVien"].ToString();
                this.Close();
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void grvSinhVien_CustomDrawRowIndicator_1(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
    }
}