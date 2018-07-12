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
    public partial class frmDanhSachThoiHoc : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private cBSV_SinhVien oBSV_SinhVien;
        private DataTable dtSinhVien;
        private cBKQHT_DiemTongKetHocKy oBKQHT_DiemTongKetHocKy;
        private cBKQHT_DanhSachNgungHoc oBKQHT_DanhSachNgungHoc;
        private cBKQHT_DanhSachHocTiep oBKQHT_DanhSachHocTiep;
        private KQHT_DanhSachHocTiepInfo pKQHT_DanhSachHocTiepInfo;

        public frmDanhSachThoiHoc()
        {
            InitializeComponent();

            oBDM_Lop = new cBDM_Lop();
            oBSV_SinhVien = new cBSV_SinhVien();
            pDM_LopInfo = new DM_LopInfo();
            oBKQHT_DiemTongKetHocKy = new cBKQHT_DiemTongKetHocKy();
            oBKQHT_DanhSachNgungHoc = new cBKQHT_DanhSachNgungHoc();
            oBKQHT_DanhSachHocTiep = new cBKQHT_DanhSachHocTiep();
            pKQHT_DanhSachHocTiepInfo = new KQHT_DanhSachHocTiepInfo();
        }

        private void frmDanhSachThoiHoc_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
            repTrangThai.DataSource = oBSV_SinhVien.CreateTableTrangThai();
            cmbTrangThai.Properties.DataSource = oBSV_SinhVien.CreateTableTrangThai();
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            LoadSinhVien_Lop();
        }

        private void LoadSinhVien_Lop()
        {
            int TrangThai;
            if (cmbTrangThai.EditValue == null)
                TrangThai = 0;
            else
                TrangThai = int.Parse("0" + cmbTrangThai.EditValue.ToString());
            if (rdOption.EditValue.ToString() == "0")
            {
                dtSinhVien = oBSV_SinhVien.GetSinhVien_XetLenLop(pDM_LopInfo, Program.NamHoc, Program.IDNamHoc);
                if (TrangThai != 0)
                {
                    dtSinhVien.DefaultView.RowFilter = "TrangThai=" + TrangThai.ToString();
                    grdSVThoiHoc.DataSource = dtSinhVien.DefaultView;
                }
                else
                    grdSVThoiHoc.DataSource = dtSinhVien;
            }
            else if (rdOption.EditValue.ToString() == "1")
            {
                dtSinhVien = oBKQHT_DanhSachNgungHoc.GetSinhVien(pDM_LopInfo, Program.NamHoc, Program.IDNamHoc);
                if (TrangThai != 0)
                {
                    dtSinhVien.DefaultView.RowFilter = "TrangThai=" + TrangThai.ToString();
                    grdSVThoiHoc.DataSource = dtSinhVien.DefaultView;
                }
                else
                    grdSVThoiHoc.DataSource = dtSinhVien;
            }
            else
            {
                dtSinhVien = oBKQHT_DanhSachHocTiep.GetSinhVien(pDM_LopInfo, Program.IDNamHoc);
                grdSVThoiHoc.DataSource = dtSinhVien;
            }
        }

        private void grvSVThoiHoc_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void cmbTrangThai_EditValueChanged(object sender, EventArgs e)
        {
            LoadSinhVien_Lop();
        }

        private void rdOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSinhVien_Lop();
            if (rdOption.EditValue.ToString() == "0")
            {
                btnEditQD.Enabled = false;
                btnDeleteQD.Enabled = false;
                btnHocTiep.Enabled = false;
                btnNhapQD.Enabled = true;
            }
            else
            {
                btnEditQD.Enabled = true;
                btnDeleteQD.Enabled = true;
                btnHocTiep.Enabled = true;
                btnNhapQD.Enabled = false;
            }

            if (rdOption.EditValue.ToString() == "1" ||rdOption.EditValue.ToString() == "2")
            {
                //gcTrangThai.Visible = false;
                grdLopCu.Visible = true;
                grdLopMoi.Visible = true;
            }
            else
            {
                //gcTrangThai.Visible = true;
                grdLopCu.Visible = false;
                grdLopMoi.Visible = false;
            }
        }

        private void cmbTrangThai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbTrangThai.EditValue = null;
        }

        private void btnNhapQD_Click(object sender, EventArgs e)
        {
            string SinhVienIDs = ""; ;
            DataTable dtTemp = dtSinhVien.GetChanges();
            if (dtTemp != null)
            {
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    if ((bool)dtTemp.Rows[i]["Chon"])
                    {
                        SinhVienIDs += dtTemp.Rows[i]["SV_SinhVienID"].ToString() + ",";
                    }
                }
            }
            if (SinhVienIDs != "")
            {
                dlgQuyetDinh dlg = new dlgQuyetDinh(SinhVienIDs.Substring(0, SinhVienIDs.Length - 1), "0", "", dtTemp.Rows[0]);
                dlg.ShowDialog();
                LoadSinhVien_Lop();
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
        }

        private void btnHocTiep_Click(object sender, EventArgs e)
        {
            string SinhVienIDs = "", KQHT_DanhSachNgungHocIDs = "";
            DataTable dtTemp = dtSinhVien.GetChanges();
            if (dtTemp != null)
            {
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    if ((bool)dtTemp.Rows[i]["Chon"])
                    {
                        SinhVienIDs += dtTemp.Rows[i]["SV_SinhVienID"].ToString() + ",";
                        KQHT_DanhSachNgungHocIDs += dtTemp.Rows[i]["KQHT_DanhSachNgungHocID"].ToString() + ",";
                    }
                }
            }
            if (SinhVienIDs != "")
            {
                dlgQuyetDinh dlg = new dlgQuyetDinh(SinhVienIDs + "0", "2", KQHT_DanhSachNgungHocIDs + "0", dtTemp.Rows[0]);
                dlg.ShowDialog();
                LoadSinhVien_Lop();
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvSVThoiHoc_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvSVThoiHoc, "Chon", e);
        }

        private void btnEditQD_Click(object sender, EventArgs e)
        {
            string SinhVienIDs = "", ChuoiIDs = "", strName = "";
            DataTable dtTemp = dtSinhVien.GetChanges();
            if (dtTemp != null)
            {
                if (rdOption.EditValue.ToString() == "1")
                    strName = "KQHT_DanhSachNgungHocID";
                else if (rdOption.EditValue.ToString() == "2")
                    strName = "KQHT_DanhSachHocTiepID";
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    if ((bool)dtTemp.Rows[i]["Chon"])
                    {
                        SinhVienIDs += dtTemp.Rows[i]["SV_SinhVienID"].ToString() + ",";
                        ChuoiIDs += dtTemp.Rows[i][strName].ToString() + ",";
                    }
                }
            }
            if (SinhVienIDs != "")
            {
                dlgQuyetDinh dlg = new dlgQuyetDinh(SinhVienIDs + "0",rdOption.EditValue.ToString(), ChuoiIDs + "0", dtTemp.Rows[0]);
                dlg.ShowDialog();
                LoadSinhVien_Lop();
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
        }

        private void btnDeleteQD_Click(object sender, EventArgs e)
        {
            string SinhVienIDs = "";
            DataTable dtTemp = dtSinhVien.GetChanges();
            // xoa quyet dinh
            if (dtTemp != null)
            {
                if (ThongBaoChon("Bạn có chắc chắn muốn xóa?") == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < dtTemp.Rows.Count; i++)
                        {
                            if ((bool)dtTemp.Rows[i]["Chon"])
                            {
                                SinhVienIDs += dtTemp.Rows[i]["SV_SinhVienID"].ToString() + ",";
                                // xoa quyet dinh xet hoc tiep
                                if (rdOption.EditValue.ToString() == "2")
                                {
                                    pKQHT_DanhSachHocTiepInfo.KQHT_DanhSachHocTiepID = int.Parse(dtTemp.Rows[i]["KQHT_DanhSachHocTiepID"].ToString());
                                    oBKQHT_DanhSachHocTiep.Delete(pKQHT_DanhSachHocTiepInfo);
                                }
                            }
                        }
                        if (SinhVienIDs != "" && rdOption.EditValue.ToString() == "1")
                        {
                            oBKQHT_DanhSachNgungHoc.DeleteQĐ(SinhVienIDs + "0", pDM_LopInfo.DM_LopID, Program.IDNamHoc);
                        }

                        ThongBao("Xóa quyết định thành công");
                        LoadSinhVien_Lop();
                    }
                    catch 
                    {
                        ThongBao("Dữ liệu đang dùng không thể xóa!");
                    }
                }
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
        }
    }
}