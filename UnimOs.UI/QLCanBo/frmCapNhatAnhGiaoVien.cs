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
    public partial class frmCapNhatAnhGiaoVien : frmBase
    {
        private cBNS_GiaoVien oBGiaoVien;
        public NS_GiaoVienInfo pGiaoVienInfo;
        private NS_DonViInfo pDonViInfo;
        private DataTable dtTree, dtGiaoVien;

        public frmCapNhatAnhGiaoVien()
        {
            InitializeComponent();
            oBGiaoVien = new cBNS_GiaoVien();
            pGiaoVienInfo = new NS_GiaoVienInfo();
            pDonViInfo = new NS_DonViInfo();
        }

        private void frmCapNhatAnhGiaoVien_Load(object sender, EventArgs e)
        {
            cBNS_DonVi oBDonVi = new cBNS_DonVi();
            dtTree = oBDonVi.Get_Tree();
            trvDonVi.DataSource = dtTree;
            trvDonVi.ExpandAll();
        }

        private bool CheckValid()
        {
            if (txtThuMucAnh.Text.Trim() == "")
            {
                ThongBao("Bạn cần phải chọn thư mục ảnh.");
                btnChonThuMuc.Focus();
                return false;
            }
            return true;
        }

        private void grvGiaoVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void LoadGiaoVien(int IDDonVi)
        {
            pGiaoVienInfo.IDNS_DonVi = IDDonVi;
            dtGiaoVien = oBGiaoVien.GetByIDNS_DonVi(IDDonVi);
            grdGiaoVien.DataSource = dtGiaoVien;
        }

        private void trvDonVi_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (trvDonVi.Nodes.Count > 0)
            {
                LoadGiaoVien(int.Parse(trvDonVi.FocusedNode["NS_DonViID"].ToString()));
                pDonViInfo.NS_DonViID = int.Parse(trvDonVi.FocusedNode["NS_DonViID"].ToString());
                pDonViInfo.MaDonVi = trvDonVi.FocusedNode["MaDonVi"].ToString();
                pDonViInfo.TenDonVi = trvDonVi.FocusedNode["TenDonVi"].ToString();
                pDonViInfo.ParentID = int.Parse(trvDonVi.FocusedNode["ParentID"].ToString());
                pDonViInfo.Level = int.Parse(trvDonVi.FocusedNode["Level"].ToString());
                pDonViInfo.IDDM_Khoa = int.Parse(trvDonVi.FocusedNode["IDDM_Khoa"].ToString());
                pDonViInfo.IDDM_BoMon = int.Parse(trvDonVi.FocusedNode["IDDM_BoMon"].ToString());
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid())
                return;
            if (dtGiaoVien == null || dtGiaoVien.Rows.Count <= 0)
            {
                ThongBao("Không có sinh viên nào để lưu.");
                return;
            }
            if (dtGiaoVien.Columns.Contains("FileAnh"))
            {
                oBGiaoVien.UpdateAnhGiaoVien(dtGiaoVien, txtThuMucAnh.Text.Trim());
                ThongBao("Cập nhật ảnh sinh viên thành công.");
            }
            else
            {
                btnGhepAnh_Click(null, null);
                oBGiaoVien.UpdateAnhGiaoVien(dtGiaoVien, txtThuMucAnh.Text.Trim());
                ThongBao("Cập nhật ảnh sinh viên thành công.");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                LookUpEdit cmb = sender as LookUpEdit;
                cmb.EditValue = null;
            }
        }

        private void btnChonThuMuc_Click(object sender, EventArgs e)
        {
            if (folderThuMucAnh.ShowDialog() == DialogResult.OK)
                txtThuMucAnh.Text = folderThuMucAnh.SelectedPath + "\\";
        }

        private void btnGhepAnh_Click(object sender, EventArgs e)
        {
            if (!CheckValid())
                return;
            if (dtGiaoVien == null)
            {
                ThongBao("Chưa có sinh viên nào");
                return;
            }
            if (!dtGiaoVien.Columns.Contains("FileAnh"))
                dtGiaoVien.Columns.Add("FileAnh", typeof(string));
            string FileName;
            foreach (DataRow dr in dtGiaoVien.Rows)
            {
                FileName = "";
                if (System.IO.File.Exists(txtThuMucAnh.Text + txtKyTuDauFile.Text + dr["MaGiaoVien"].ToString() + ".gif"))
                    FileName = txtKyTuDauFile.Text + dr["MaGiaoVien"].ToString() + ".gif";
                else if (System.IO.File.Exists(txtThuMucAnh.Text + txtKyTuDauFile.Text + dr["MaGiaoVien"].ToString() + ".jpg"))
                    FileName = txtKyTuDauFile.Text + dr["MaGiaoVien"].ToString() + ".jpg";
                else if (System.IO.File.Exists(txtThuMucAnh.Text + txtKyTuDauFile.Text + dr["MaGiaoVien"].ToString() + ".bmp"))
                    FileName = txtKyTuDauFile.Text + dr["MaGiaoVien"].ToString() + ".bmp";
                else if (System.IO.File.Exists(txtThuMucAnh.Text + txtKyTuDauFile.Text + dr["MaGiaoVien"].ToString() + ".png"))
                    FileName = txtKyTuDauFile.Text + dr["MaGiaoVien"].ToString() + ".png";
                if (FileName != "")
                    dr["FileAnh"] = FileName;
            }
        }
    }
}