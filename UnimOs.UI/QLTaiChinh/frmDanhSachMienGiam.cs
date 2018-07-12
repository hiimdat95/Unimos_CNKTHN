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
    public partial class frmDanhSachMienGiam : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private cBDM_DoiTuongMienGiam oBDM_DoiTuongMienGiam;
        private DM_DoiTuongMienGiamInfo pDM_DoiTuongMienGiamInfo;
        private cBTC_LoaiThuChi oBTC_LoaiThuChi;
        private TC_LoaiThuChiInfo pTC_LoaiThuChiInfo;
        private cBTC_DanhSachMienGiam oBTC_DanhSachMienGiam;
        private TC_DanhSachMienGiamInfo pTC_DanhSachMienGiamInfo;
        private TC_DanhSachMienGiam_ChiTietInfo pTC_DanhSachMienGiam_ChiTietInfo;
        private cBTC_DanhSachMienGiam_ChiTiet  oBTC_DanhSachMienGiam_ChiTiet;
        public DataTable dtMienGiam, dtSinhVien, dtChiTiet;
        private string strID="";
        private int IDTC_LoaiThuChi = 0;

        public frmDanhSachMienGiam()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            pDM_DoiTuongMienGiamInfo = new DM_DoiTuongMienGiamInfo();
            oBDM_DoiTuongMienGiam = new cBDM_DoiTuongMienGiam();
            pTC_DanhSachMienGiamInfo = new TC_DanhSachMienGiamInfo();
            oBTC_DanhSachMienGiam = new cBTC_DanhSachMienGiam();
            pTC_LoaiThuChiInfo = new TC_LoaiThuChiInfo();
            oBTC_LoaiThuChi = new cBTC_LoaiThuChi();
            oBTC_DanhSachMienGiam_ChiTiet = new cBTC_DanhSachMienGiam_ChiTiet();
            pTC_DanhSachMienGiam_ChiTietInfo = new TC_DanhSachMienGiam_ChiTietInfo();
        }

        private void frmDanhSachMienGiam_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
            DataTable dtTemp = oBDM_DoiTuongMienGiam.Get(pDM_DoiTuongMienGiamInfo);
            cmbDoiTuong.Properties.DataSource= dtTemp;
            DataTable dtLoaiThuChi = LoadLoaiThuChi(Program.IDNamHoc, Program.HocKy);
            cmbLoaiThuChi.Properties.DataSource = dtLoaiThuChi;
            if (dtLoaiThuChi != null && dtLoaiThuChi.Rows.Count > 0)
            {
                cmbLoaiThuChi.EditValue = dtLoaiThuChi.Rows[0]["TC_LoaiThuChiID"];
            }
            repositoryMienGiam.DataSource = dtTemp;
            repositoryMienGiam1.DataSource = dtTemp;
        }
        //
        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            DM_LopInfo pDM_LopInfo = uctrlLop.GetNodeSelected();
            dtChiTiet = null;
            if (pDM_LopInfo != null)
            {
                dtSinhVien = oBTC_DanhSachMienGiam.GetNotInSinhVien(pDM_LopInfo.IDDM_Khoa, pDM_LopInfo.IDDM_He, pDM_LopInfo.IDDM_TrinhDo, pDM_LopInfo.IDDM_KhoaHoc, pDM_LopInfo.IDDM_Nganh, pDM_LopInfo.DM_LopID, Program.IDNamHoc, Program.HocKy, Program.NamHoc, IDTC_LoaiThuChi);
                grdSinhVien.DataSource = dtSinhVien.DefaultView;
                dtMienGiam = oBTC_DanhSachMienGiam.GetInSinhVien(pDM_LopInfo.IDDM_Khoa, pDM_LopInfo.IDDM_He, pDM_LopInfo.IDDM_TrinhDo, pDM_LopInfo.IDDM_KhoaHoc, pDM_LopInfo.IDDM_Nganh, pDM_LopInfo.DM_LopID, Program.IDNamHoc, Program.HocKy, IDTC_LoaiThuChi);
                grdMienGiam.DataSource = dtMienGiam;
                strID = "";
            }
            else
            {
                grdSinhVien.DataSource = null;
                grdMienGiam.DataSource = null;
                strID = "";
            }
        }

        private void cmbDoiTuong_EditValueChanged(object sender, EventArgs e)
        {
            if (dtSinhVien != null && dtMienGiam != null)
            {
                if (cmbDoiTuong.EditValue != null)
                {
                    dtSinhVien.DefaultView.RowFilter = "IDDM_DoiTuongMienGiam =" + cmbDoiTuong.EditValue.ToString();
                    strID = "";
                    txtThanhTien.Text = float.Parse(cmbDoiTuong.GetColumnValue("SoTienMienGiam").ToString()).ToString();
                    txtPhanTram.Text = cmbDoiTuong.GetColumnValue("PhanTramMienGiam").ToString();
                    if (txtPhanTram.Text.Trim() != "" && txtPhanTram.Text != "0" && cmbLoaiThuChi.EditValue != null)
                    {
                        txtThanhTien.Text = (float.Parse(cmbDoiTuong.GetColumnValue("PhanTramMienGiam").ToString()) / 100 * float.Parse(cmbLoaiThuChi.GetColumnValue("SoTien").ToString())).ToString();
                    }
                }
                else
                {
                    dtSinhVien.DefaultView.RowFilter = "";
                    strID = "";
                    txtPhanTram.Text = "";
                    txtThanhTien.Text = "";
                }
            }
        }

        private void txtPhanTram_TextChanged(object sender, EventArgs e)
        {
            if (txtPhanTram.Text.Trim() != "" && txtPhanTram.Text != "0" && cmbLoaiThuChi.EditValue != null)
            {
                txtThanhTien.Text = (float.Parse(txtPhanTram.Text.Trim()) / 100 * float.Parse(txtSoTien.Text.Trim())).ToString();
            }
        }
        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {
            if (txtPhanTram.Text.Trim() != "" && txtPhanTram.Text != "0" && cmbLoaiThuChi.EditValue != null)
            {
                txtThanhTien.Text = (float.Parse(txtPhanTram.Text.Trim()) / 100 * float.Parse(txtSoTien.Text.Trim())).ToString();
            }
        }
        private void grvSinhVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvSinhVien_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvSinhVien, "Chon", e);
        }

        private void grvTroCap_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvMienGiam, "Chon", e);
        }

        private void grvTroCap_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void cmbLoaiThuChi_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbLoaiThuChi.EditValue != null)
            {
                IDTC_LoaiThuChi = int.Parse(cmbLoaiThuChi.EditValue.ToString());
                txtSoTien.Text = float.Parse(cmbLoaiThuChi.GetColumnValue("SoTien").ToString()).ToString();
                trlLop_FocusedNodeChanged(null, null);
                cmbDoiTuong_EditValueChanged(null, null);
            }
        }

        private void grvMienGiam_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && grdMienGiam.ClientRectangle.Contains(e.X, e.Y))
            {
                popupMenu1.ShowPopup(MousePosition);
            }
        }

        private void barbtnThang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dtChiTiet = null;
            DataRow[] dr = dtMienGiam.Select("Chon=1");
            if (dr.Length > 0)
            {
                dlgDinhMuc dlg = new dlgDinhMuc(dr);
                dlg.ShowDialog();
                if (dlg.Tag.ToString() != "")
                {
                    dtChiTiet = dlg.dtChiTiet;
                    if (dtChiTiet != null && dtChiTiet.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtSinhVien.Rows.Count; i++)
                        {
                            DataRow[] adrChiTiet = dtChiTiet.Select(" IDSV_SinhVien =" + dtSinhVien.Rows[i]["SV_SinhVienID"].ToString());
                            dtSinhVien.Rows[i]["SoTienMienGiam"] = double.Parse("0" + txtThanhTien.Text) * adrChiTiet.Length;
                        }
                    }
                }
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 Sinh viên!");
        }

        private void barbtnXoaThang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn chắc chắn muốn xóa?") == DialogResult.Yes)
            {
                dtChiTiet = null;
                DataRow[] dr = dtMienGiam.Select("Chon=1");
                foreach (DataRow mdr in dr)
                {
                    mdr["SoTienMienGiam"] = double.Parse("0" + txtThanhTien.Text);
                    try
                    {
                        oBTC_DanhSachMienGiam_ChiTiet.DeleteBy_MienGiam(int.Parse(mdr["TC_DanhSachMienGiamID"].ToString())); ;
                    }
                    catch { }
                }
                ThongBao("Xóa định mức thu theo tháng thành công!");
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cmbLoaiThuChi.EditValue != null )
            {
                if (double.Parse("0" + txtThanhTien.Text) > 0)
                {
                    int Count = dtSinhVien.Rows.Count;
                    DataRow[] dr = dtSinhVien.Select("Chon=1");
                    if (dr.Length > 0)
                    {
                        // dinh muc thu chi tiet
                        dtChiTiet = null;
                        dlgDinhMuc dlg = new dlgDinhMuc(dr);
                        dlg.ShowDialog();
                        if (dlg.Tag.ToString() != "")
                        {
                            dtChiTiet = dlg.dtChiTiet;
                            for (int i = 0; i < Count; i++)
                            {
                                if ((bool)dtSinhVien.Rows[i]["Chon"])
                                {
                                    dtSinhVien.Rows[i]["Chon"] = false;
                                    if (txtThanhTien.Text != "" && txtThanhTien.Text != "0")
                                        dtSinhVien.Rows[i]["SoTienMienGiam"] = txtThanhTien.Text;
                                    else
                                    {
                                        if (dtSinhVien.Rows[i]["PhanTramMienGiam"].ToString() != "" && dtSinhVien.Rows[i]["PhanTramMienGiam"].ToString() != "0")
                                            dtSinhVien.Rows[i]["SoTienMienGiam"] = float.Parse(dtSinhVien.Rows[i]["PhanTramMienGiam"].ToString()) / 100 * float.Parse(cmbLoaiThuChi.GetColumnValue("SoTien").ToString());
                                        else
                                            dtSinhVien.Rows[i]["SoTienMienGiam"] = dtSinhVien.Rows[i]["SoTien"];
                                    }
                                    dtSinhVien.Rows[i]["TenLoaiThuChi"] = cmbLoaiThuChi.Text;
                                    dtSinhVien.Rows[i]["IDTC_LoaiThuChi"] = int.Parse(cmbLoaiThuChi.EditValue.ToString());
                                    if (dlg.Tag.ToString() == "1")
                                    {
                                        if (dtChiTiet != null && dtChiTiet.Rows.Count > 0)
                                        {
                                            DataRow[] adrChiTiet = dtChiTiet.Select(" IDSV_SinhVien =" + dtSinhVien.Rows[i]["SV_SinhVienID"].ToString());
                                            dtSinhVien.Rows[i]["SoTienMienGiam"] = double.Parse("0" + dtSinhVien.Rows[i]["SoTienMienGiam"].ToString()) * adrChiTiet.Length;
                                        }
                                    }
                                    //
                                    dtMienGiam.ImportRow(dtSinhVien.Rows[i]);
                                    dtSinhVien.Rows.Remove(dtSinhVien.Rows[i]);
                                    Count = Count - 1;
                                    i = i - 1;
                                }
                            }
                        }
                    }

                    else
                        ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
                }
                else
                    ThongBao("Bạn chưa nhập số tiền miễn giảm!");
            }
            else
                ThongBao("Chưa chọn loại thu chi!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int Count = dtMienGiam.Rows.Count;
            DataRow[] dr = dtMienGiam.Select("Chon=1");
            if (dr.Length > 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    if ((bool)dtMienGiam.Rows[i]["Chon"])
                    {
                        dtMienGiam.Rows[i]["Chon"] = false;
                        if (dtMienGiam.Rows[i]["TC_DanhSachMienGiamID"].ToString() != "0")
                        {
                            strID += dtMienGiam.Rows[i]["TC_DanhSachMienGiamID"].ToString() + ",";
                        }
                        dtSinhVien.ImportRow(dtMienGiam.Rows[i]);
                        dtMienGiam.Rows.Remove(dtMienGiam.Rows[i]);
                        Count = Count - 1;
                        i = i - 1;
                    }
                }
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
        }

        private void cmbDoiTuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbDoiTuong.EditValue = null;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if ((dtMienGiam != null && dtMienGiam.Rows.Count > 0) || (strID!=""))
            {
                // xoa trong CSDL cac sinh vien da bi xoa
                string[] arrID = strID.Split(',');
                for (int i = 0; i < arrID.Length; i++)
                {
                    try
                    {
                        pTC_DanhSachMienGiamInfo.TC_DanhSachMienGiamID = int.Parse("0" + arrID[i]);
                        oBTC_DanhSachMienGiam.Delete(pTC_DanhSachMienGiamInfo);
                    }
                    catch { }

                }
                int IDTC_DanhSachMienGiam = 0;
                if (dtMienGiam != null )
                {
                   
                    foreach (DataRow dr in dtMienGiam.Rows)
                    {
                        pTC_DanhSachMienGiamInfo.IDDM_NamHoc = Program.IDNamHoc;
                        pTC_DanhSachMienGiamInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                        pTC_DanhSachMienGiamInfo.HocKy = Program.HocKy;
                        pTC_DanhSachMienGiamInfo.GhiChu = dr["GhiChu"].ToString();
                        pTC_DanhSachMienGiamInfo.SoTienMienGiam = float.Parse("0" + dr["SoTienMienGiam"].ToString());
                        pTC_DanhSachMienGiamInfo.IDTC_LoaiThuChi = int.Parse(dr["IDTC_LoaiThuChi"].ToString());
                        IDTC_DanhSachMienGiam = oBTC_DanhSachMienGiam.Add(pTC_DanhSachMienGiamInfo);
                    }
                    // add dinh muc thu chi tiet theo thang
                    if (dtChiTiet != null && dtChiTiet.Rows.Count > 0)
                    {
                        DataRow[] adrChiTiet = dtChiTiet.Select(" IDSV_SinhVien =" + pTC_DanhSachMienGiamInfo.IDSV_SinhVien.ToString());
                        foreach (DataRow drChiTiet in adrChiTiet)
                        {
                            pTC_DanhSachMienGiam_ChiTietInfo.IDTC_DanhSachMienGiam = IDTC_DanhSachMienGiam;
                            pTC_DanhSachMienGiam_ChiTietInfo.SoTien = pTC_DanhSachMienGiamInfo.SoTienMienGiam / adrChiTiet.Length;//float.Parse(drChiTiet["SoTien"].ToString());
                            pTC_DanhSachMienGiam_ChiTietInfo.Thang = int.Parse(drChiTiet["Thang"].ToString());
                            oBTC_DanhSachMienGiam_ChiTiet.Add(pTC_DanhSachMienGiam_ChiTietInfo);
                        }
                    }
                
                }
               
                ThongBao("Cập nhật thành công!");
            }
            else
                ThongBao("Không có dữ liệu để lưu!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}