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
    public partial class frmDinhMucThu : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private cBTC_LoaiThuChi oBTC_LoaiThuChi;
        private TC_LoaiThuChiInfo pTC_LoaiThuChiInfo;
        private cBTC_DinhMucThuSinhVien oBTC_DinhMucThuSinhVien;
        private TC_DinhMucThuSinhVienInfo pTC_DinhMucThuSinhVienInfo;
        private cBTC_DinhMucThuSinhVien_ChiTiet oBTC_DinhMucThuSinhVien_ChiTiet;
        private TC_DinhMucThuSinhVien_ChiTietInfo pTC_DinhMucThuSinhVien_ChiTietInfo;
        private DM_LopInfo pDM_LopInfo;
        public DataTable dtDinhMuc, dtSinhVien, dtChiTiet;
        private string strID = "";
        private int IDTC_LoaiThuChi = 0;
        private bool IsGetKyTruoc = false;

        public frmDinhMucThu()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            pTC_DinhMucThuSinhVienInfo = new TC_DinhMucThuSinhVienInfo();
            oBTC_DinhMucThuSinhVien = new cBTC_DinhMucThuSinhVien();
            pTC_LoaiThuChiInfo = new TC_LoaiThuChiInfo();
            oBTC_LoaiThuChi = new cBTC_LoaiThuChi();
            oBTC_DinhMucThuSinhVien_ChiTiet = new cBTC_DinhMucThuSinhVien_ChiTiet();
            pTC_DinhMucThuSinhVien_ChiTietInfo = new TC_DinhMucThuSinhVien_ChiTietInfo();
        }

        private void frmDinhMucThu_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
            DataTable dtLoaiThuChi = LoadLoaiThuChi(Program.IDNamHoc, Program.HocKy);
            cmbLoaiThuChi.Properties.DataSource = dtLoaiThuChi;
            if (dtLoaiThuChi != null && dtLoaiThuChi.Rows.Count > 0)
            {
                cmbLoaiThuChi.EditValue = dtLoaiThuChi.Rows[0]["TC_LoaiThuChiID"];
            }
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            dtChiTiet = null;

            if (pDM_LopInfo != null)
            {
                LoadSinhVien();
                strID = "";
            }
            else
            {
                grdSinhVien.DataSource = null;
                grdDinhMuc.DataSource = null;
                strID = "";
            }
        }

        private void LoadSinhVien()
        {
            if (!IsGetKyTruoc)
                dtSinhVien = oBTC_DinhMucThuSinhVien.GetNotInSinhVien(pDM_LopInfo, Program.IDNamHoc, Program.HocKy, Program.NamHoc, IDTC_LoaiThuChi);
            else
                dtSinhVien = oBTC_DinhMucThuSinhVien.GetByKyTruoc(pDM_LopInfo, Program.IDNamHoc, Program.HocKy, Program.NamHoc, IDTC_LoaiThuChi);
            grdSinhVien.DataSource = dtSinhVien;
            dtDinhMuc = oBTC_DinhMucThuSinhVien.GetInSinhVien(pDM_LopInfo, Program.IDNamHoc, Program.HocKy, IDTC_LoaiThuChi);
            grdDinhMuc.DataSource = dtDinhMuc;
        }

        private void cmbLoaiThuChi_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbLoaiThuChi.EditValue != null)
            {
                IDTC_LoaiThuChi = int.Parse(cmbLoaiThuChi.EditValue.ToString());
                txtSoTien.Text = float.Parse("0" + cmbLoaiThuChi.GetColumnValue("SoTien")).ToString();
                if (pDM_LopInfo != null)
                {
                    dtChiTiet = null;
                    LoadSinhVien();
                }
            }
            else
            {
                grdDinhMuc.DataSource = null;
                grdSinhVien.DataSource = null;
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

        private void grvDinhMuc_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvDinhMuc_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvDinhMuc, "Chon", e);
        }

        private void grvDinhMuc_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && grdDinhMuc.ClientRectangle.Contains(e.X, e.Y))
            {
                popupMenu1.ShowPopup(MousePosition);
            }
        }

        private void barbtnDinhMucTheoThang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dtChiTiet = null;
            DataRow[] dr = dtDinhMuc.Select("Chon=1");
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
                            dtSinhVien.Rows[i]["SoTien"] = double.Parse("0" + txtSoTien.Text) * adrChiTiet.Length;
                            dtSinhVien.Rows[i]["SoTienPhaiNop"] = double.Parse("0" + dtSinhVien.Rows[i]["SoTien"].ToString()) - double.Parse("0" + dtSinhVien.Rows[i]["SoTienMienGiam"].ToString());
                        }
                    }
                }
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
        }

        private void barbtnXoaDinhMucTheoThang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn chắc chắn muốn xóa?") == DialogResult.Yes)
            {
                DataRow[] dr = dtDinhMuc.Select("Chon=1");
                foreach (DataRow mdr in dr)
                {
                    mdr["SoTienPhaiNop"] = double.Parse("0" + txtSoTien.Text) - double.Parse("0" + mdr["SoTienMienGiam"].ToString());
                    mdr["SoTien"] = double.Parse("0" + txtSoTien.Text);
                    try
                    {
                        oBTC_DinhMucThuSinhVien_ChiTiet.DeleteBy_DinhMucThu(int.Parse(mdr["TC_DinhMucThuSinhVienID"].ToString())); ;
                    }
                    catch { }
                }
                ThongBao("Xóa định mức thu theo tháng thành công!");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dtSinhVien == null || dtSinhVien.Rows.Count <= 0)
                return;
            if (cmbLoaiThuChi.EditValue != null)
            {
                int Count = dtSinhVien.Rows.Count;
                DataRow[] dr = dtSinhVien.Select("Chon=1");
                if (dr.Length > 0)
                {
                    // dinh muc thu chi tiet                    
                    dlgDinhMuc dlg = new dlgDinhMuc(dr);
                    dlg.ShowDialog();
                    if (dlg.Tag.ToString() != "")
                    {
                        for (int i = 0; i < Count; i++)
                        {
                            if ((bool)dtSinhVien.Rows[i]["Chon"])
                            {
                                dtSinhVien.Rows[i]["Chon"] = false;

                                if (dlg.Tag.ToString() == "1")
                                {
                                    dtChiTiet = dlg.dtChiTiet;
                                    if (dtChiTiet != null && dtChiTiet.Rows.Count > 0)
                                    {
                                        DataRow[] adrChiTiet = dtChiTiet.Select(" IDSV_SinhVien = " + dtSinhVien.Rows[i]["SV_SinhVienID"].ToString());
                                        if (!IsGetKyTruoc)
                                            dtSinhVien.Rows[i]["SoTien"] = double.Parse("0" + txtSoTien.Text) * adrChiTiet.Length;
                                        dtSinhVien.Rows[i]["SoTienPhaiNop"] = double.Parse("0" + dtSinhVien.Rows[i]["SoTien"].ToString()) - double.Parse("0" + dtSinhVien.Rows[i]["SoTienMienGiam"].ToString());
                                    }
                                }
                                else
                                {
                                    if (!IsGetKyTruoc)
                                        dtSinhVien.Rows[i]["SoTien"] = double.Parse("0" + txtSoTien.Text);
                                    dtSinhVien.Rows[i]["SoTienPhaiNop"] = double.Parse("0" + dtSinhVien.Rows[i]["SoTien"].ToString()) - double.Parse("0" + dtSinhVien.Rows[i]["SoTienMienGiam"].ToString());
                                }
                                //
                                dtDinhMuc.ImportRow(dtSinhVien.Rows[i]);
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
                ThongBao("Bạn phải chưa chọn loại thu chi!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtDinhMuc == null || dtDinhMuc.Rows.Count <= 0)
                return;
            int Count = dtDinhMuc.Rows.Count;
            DataRow[] dr = dtDinhMuc.Select("Chon=1");
            if (dr.Length > 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    if ((bool)dtDinhMuc.Rows[i]["Chon"])
                    {
                        dtDinhMuc.Rows[i]["Chon"] = false;
                        if (dtDinhMuc.Rows[i]["TC_DinhMucThuSinhVienID"].ToString() != "0")
                        {
                            strID += dtDinhMuc.Rows[i]["TC_DinhMucThuSinhVienID"].ToString() + ",";
                        }
                        dtSinhVien.ImportRow(dtDinhMuc.Rows[i]);
                        dtDinhMuc.Rows.Remove(dtDinhMuc.Rows[i]);
                        Count = Count - 1;
                        i = i - 1;
                    }
                }
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dtDinhMuc != null && (strID != "" || dtDinhMuc.Rows.Count > 0))
            {
                // xoa trong CSDL cac sinh vien da bi xoa
                string[] arrID = strID.Split(',');
                for (int i = 0; i < arrID.Length; i++)
                {
                    try
                    {
                        pTC_DinhMucThuSinhVienInfo.TC_DinhMucThuSinhVienID = int.Parse("0" + arrID[i]);
                        oBTC_DinhMucThuSinhVien.Delete(pTC_DinhMucThuSinhVienInfo);
                    }
                    catch { }

                }
                strID = "";
                foreach (DataRow dr in dtDinhMuc.Rows)
                {
                    pTC_DinhMucThuSinhVienInfo.IDDM_NamHoc = Program.IDNamHoc;
                    pTC_DinhMucThuSinhVienInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                    pTC_DinhMucThuSinhVienInfo.HocKy = Program.HocKy;
                    pTC_DinhMucThuSinhVienInfo.GhiChu = "";
                    pTC_DinhMucThuSinhVienInfo.IDTC_LoaiThuChi = IDTC_LoaiThuChi;
                    pTC_DinhMucThuSinhVienInfo.SoTienGiam = float.Parse("0" + dr["SoTienMienGiam"].ToString());
                    pTC_DinhMucThuSinhVienInfo.SoTienPhaiNop = float.Parse(dr["SoTienPhaiNop"].ToString());
                    dr["TC_DinhMucThuSinhVienID"] = oBTC_DinhMucThuSinhVien.Add(pTC_DinhMucThuSinhVienInfo);

                    // add dinh muc thu chi tiet theo thang
                    if (dtChiTiet != null && dtChiTiet.Rows.Count > 0)
                    {
                        DataRow[] adrChiTiet = dtChiTiet.Select(" IDSV_SinhVien =" + pTC_DinhMucThuSinhVienInfo.IDSV_SinhVien.ToString());
                        foreach (DataRow drChiTiet in adrChiTiet)
                        {
                            pTC_DinhMucThuSinhVien_ChiTietInfo.IDTC_DinhMucThuSinhVien = int.Parse(dr["TC_DinhMucThuSinhVienID"].ToString());
                            pTC_DinhMucThuSinhVien_ChiTietInfo.SoTien = (pTC_DinhMucThuSinhVienInfo.SoTienPhaiNop / adrChiTiet.Length);//float.Parse(drChiTiet["SoTien"].ToString());
                            pTC_DinhMucThuSinhVien_ChiTietInfo.Thang = int.Parse(drChiTiet["Thang"].ToString());
                            oBTC_DinhMucThuSinhVien_ChiTiet.Add(pTC_DinhMucThuSinhVien_ChiTietInfo);
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

        private void btnChonTheoKyTruoc_Click(object sender, EventArgs e)
        {
            IsGetKyTruoc = !IsGetKyTruoc;
            LoadSinhVien();
            if (IsGetKyTruoc)
                btnChonTheoKyTruoc.Text = "Chọn theo số tiền";
            else
                btnChonTheoKyTruoc.Text = "Chọn theo kỳ trước";
        }
    }
}