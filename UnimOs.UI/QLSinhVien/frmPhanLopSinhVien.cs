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
    public partial class frmPhanLopSinhVien : frmBase
    {
        private cBSV_SinhVien oBSV_SinhVien;
        private cBSV_SinhVienNhapTruong oBSV_SinhVienNhapTruong;
        private int IDDM_Lop;
        private DataTable dtSinhVien, dtTrungTuyen;

        public frmPhanLopSinhVien()
        {
            InitializeComponent();
            oBSV_SinhVien = new cBSV_SinhVien();
            oBSV_SinhVienNhapTruong = new cBSV_SinhVienNhapTruong();
        }

        private void frmPhanLopSinhVien_Load(object sender, EventArgs e)
        {
            GetSVTrungTuyen();

            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);

            LoadTreeLop(uctrlLopTuDong);
            uctrlLopTuDong.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLopTuDong_FocusedNodeChanged);
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            DM_LopInfo pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                IDDM_Lop = pDM_LopInfo.DM_LopID;
                LoadSinhVien_Lop();
            }
        }

        void trlLopTuDong_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            
        }

        private void GetSVTrungTuyen()
        {
            dtTrungTuyen = oBSV_SinhVienNhapTruong.GetByNamHoc(Program.IDNamHoc);
            grdSVTrungTuyen.DataSource = dtTrungTuyen;

            grdSVTrungTuyenTuDong.DataSource = dtTrungTuyen;
        }

        private void LoadSinhVien_Lop()
        {
            dtSinhVien = oBSV_SinhVien.GetByLop(IDDM_Lop, 1);
            grdDanhSachSV.DataSource = dtSinhVien;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int[] rowSelected = grvSVTrungTuyen.GetSelectedRows();
            bool Error = false;
            for (int j = 0; j < rowSelected.Length; j++)
            {
                try
                {
                    oBSV_SinhVien.AddByPhanLop(int.Parse(grvSVTrungTuyen.GetDataRow(rowSelected[j])["SV_SinhVienNhapTruongID"].ToString()), IDDM_Lop);
                }
                catch
                {
                    Error = true;
                }
            }
            GetSVTrungTuyen();
            trlLop_FocusedNodeChanged(null, null);
            if (Error)
                ThongBaoLoi("Có lỗi khi phân lớp ở một số sinh viên.");
            else
                ThongBao("Phân lớp thành công cho toàn bộ sinh viên được chọn.");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void grvSVTrungTuyen_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvDanhSachSV_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
    }
}