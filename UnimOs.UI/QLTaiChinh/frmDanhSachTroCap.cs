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
    public partial class frmDanhSachTroCap : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private cBDM_DoiTuongTroCap oBDM_DoiTuongTroCap;
        private DM_DoiTuongTroCapInfo pDM_DoiTuongTroCapInfo;
        private cBTC_DanhSachTroCap oBTC_DanhSachTroCap;
        private TC_DanhSachTroCapInfo pTC_DanhSachTroCapInfo;
        private TC_DanhSachTroCap_ChiTietInfo pTC_DanhSachTroCap_ChiTietInfo;
        private cBTC_DanhSachTroCap_ChiTiet  oBTC_DanhSachTroCap_ChiTiet;
        public DataTable dtTroCap, dtSinhVien,dtChiTiet;
        private string strID="";

        public frmDanhSachTroCap()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            pDM_DoiTuongTroCapInfo = new DM_DoiTuongTroCapInfo();
            oBDM_DoiTuongTroCap = new cBDM_DoiTuongTroCap();
            pTC_DanhSachTroCapInfo = new TC_DanhSachTroCapInfo();
            oBTC_DanhSachTroCap = new cBTC_DanhSachTroCap();
            pTC_DanhSachTroCap_ChiTietInfo = new TC_DanhSachTroCap_ChiTietInfo();
            oBTC_DanhSachTroCap_ChiTiet = new cBTC_DanhSachTroCap_ChiTiet();
        }

        private void frmDanhSachTroCap_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);

            DataTable dtTemp = oBDM_DoiTuongTroCap.Get(pDM_DoiTuongTroCapInfo);
            cmbDoiTuong.Properties.DataSource = dtTemp;
            repositoryTroCap.DataSource = dtTemp;
            repositoryTroCap1.DataSource = dtTemp;
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            DM_LopInfo pDM_LopInfo = uctrlLop.GetNodeSelected();
            dtChiTiet = null;

            if (pDM_LopInfo != null)
            {
                dtSinhVien = oBTC_DanhSachTroCap.GetNotInSinhVien(pDM_LopInfo.IDDM_Khoa, pDM_LopInfo.IDDM_He, pDM_LopInfo.IDDM_TrinhDo, pDM_LopInfo.IDDM_KhoaHoc, pDM_LopInfo.IDDM_Nganh, pDM_LopInfo.DM_LopID, Program.IDNamHoc, Program.HocKy,Program.NamHoc);
                grdSinhVien.DataSource = dtSinhVien.DefaultView;
                dtTroCap = oBTC_DanhSachTroCap.GetInSinhVien(pDM_LopInfo.IDDM_Khoa, pDM_LopInfo.IDDM_He, pDM_LopInfo.IDDM_TrinhDo, pDM_LopInfo.IDDM_KhoaHoc, pDM_LopInfo.IDDM_Nganh, pDM_LopInfo.DM_LopID, Program.IDNamHoc, Program.HocKy);
                grdTroCap.DataSource = dtTroCap;
                strID = "";
            }
            else
            {
                grdSinhVien.DataSource = null;
                grdTroCap.DataSource = null;
                strID = "";
            }
        }

        private void cmbDoiTuong_EditValueChanged(object sender, EventArgs e)
        {
            if (dtSinhVien != null && dtTroCap != null)
            {
                if (cmbDoiTuong.EditValue != null)
                {
                    dtSinhVien.DefaultView.RowFilter = "IDDM_DoiTuongTroCap =" + cmbDoiTuong.EditValue.ToString();
                    strID = "";
                    txtSoTien.Text = float.Parse(cmbDoiTuong.GetColumnValue("SoTienTroCap").ToString()).ToString();
                }
                else
                {
                    dtSinhVien.DefaultView.RowFilter = "";
                    strID = "";
                    txtSoTien.Text = "0";
                }
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
            CheckAll(grvTroCap, "Chon", e);
        }

        private void grvTroCap_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvTroCap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && grdTroCap.ClientRectangle.Contains(e.X, e.Y))
            {
                popupMenu1.ShowPopup(MousePosition);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int Count = dtSinhVien.Rows.Count;
             DataRow[] dr = dtSinhVien.Select("Chon=1");
             if (dr.Length > 0)
             {
                 if (double.Parse("0" + txtSoTien.Text) > 0)
                 {
                     // dinh muc thu chi tiet
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
                                 if (txtSoTien.Text != "" && txtSoTien.Text != "0")
                                     dtSinhVien.Rows[i]["SoTien"] = txtSoTien.Text;
                                 else
                                     dtSinhVien.Rows[i]["SoTien"] = dtSinhVien.Rows[i]["SoTienTroCap"];
                                 if (dlg.Tag.ToString() == "1")
                                 {
                                     if (dtChiTiet != null && dtChiTiet.Rows.Count > 0)
                                     {
                                         DataRow[] adrChiTiet = dtChiTiet.Select(" IDSV_SinhVien =" + dtSinhVien.Rows[i]["SV_SinhVienID"].ToString());
                                         dtSinhVien.Rows[i]["SoTien"] = double.Parse("0" + dtSinhVien.Rows[i]["SoTien"].ToString()) * adrChiTiet.Length;
                                     }
                                 }
                                 //
                                 dtTroCap.ImportRow(dtSinhVien.Rows[i]);
                                 dtSinhVien.Rows.Remove(dtSinhVien.Rows[i]);
                                 Count = Count - 1;
                                 i = i - 1;
                             }
                         }
                     }
                 }
                 else
                     ThongBao("Bạn phải nhập số tiền trợ cấp!");
             }

             else
                 ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int Count = dtTroCap.Rows.Count;
            DataRow[] dr = dtTroCap.Select("Chon=1");
            if (dr.Length > 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    if ((bool)dtTroCap.Rows[i]["Chon"])
                    {
                        dtTroCap.Rows[i]["Chon"] = false;
                        if (dtTroCap.Rows[i]["TC_DanhSachTroCapID"].ToString() != "0")
                        {
                            strID += dtTroCap.Rows[i]["TC_DanhSachTroCapID"].ToString() + ",";
                        }
                        dtSinhVien.ImportRow(dtTroCap.Rows[i]);
                        dtTroCap.Rows.Remove(dtTroCap.Rows[i]);
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
        private void barbtnDinhMucTheoThang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dtChiTiet = null;
            DataRow[] dr = dtTroCap.Select("Chon=1");
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
                            dtSinhVien.Rows[i]["SoTien"] = double.Parse("0" + txtSoTien.Text.Trim()) * adrChiTiet.Length;
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
                dtChiTiet = null;
                DataRow[] dr = dtTroCap.Select("Chon=1");
                foreach (DataRow mdr in dr)
                {
                    mdr["SoTien"] = double.Parse("0" + txtSoTien.Text.Trim());
                    try
                    {
                        oBTC_DanhSachTroCap_ChiTiet.DeleteBy_TroCap(int.Parse(mdr["TC_DanhSachTroCapID"].ToString())); ;
                    }
                    catch { }
                }
                ThongBao("Xóa định mức thu theo tháng thành công!");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if ((dtTroCap != null && dtTroCap.Rows.Count > 0) || (strID !=""))
            {
                // xoa trong CSDL cac sinh vien da bi xoa
                string[] arrID = strID.Split(',');
                for (int i = 0; i < arrID.Length; i++)
                {
                    try
                    {
                        pTC_DanhSachTroCapInfo.TC_DanhSachTroCapID = int.Parse("0" + arrID[i]);
                        oBTC_DanhSachTroCap.Delete(pTC_DanhSachTroCapInfo);
                    }
                    catch { }

                }
                int IDTC_DanhSachTroCap = 0;
                foreach (DataRow dr in dtTroCap.Rows)
                    {
                        pTC_DanhSachTroCapInfo.IDDM_NamHoc = Program.IDNamHoc;
                        pTC_DanhSachTroCapInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                        pTC_DanhSachTroCapInfo.HocKy = Program.HocKy;
                        pTC_DanhSachTroCapInfo.GhiChu = dr["GhiChu"].ToString();
                        pTC_DanhSachTroCapInfo.SoTien = double.Parse(dr["SoTien"].ToString());
                        IDTC_DanhSachTroCap = oBTC_DanhSachTroCap.Add(pTC_DanhSachTroCapInfo);
                    }
                // add dinh muc thu chi tiet theo thang
                if (dtChiTiet != null && dtChiTiet.Rows.Count > 0)
                {
                    DataRow[] adrChiTiet = dtChiTiet.Select(" IDSV_SinhVien =" + pTC_DanhSachTroCapInfo.IDSV_SinhVien.ToString());
                    foreach (DataRow drChiTiet in adrChiTiet)
                    {
                        pTC_DanhSachTroCap_ChiTietInfo.IDTC_DanhSachTroCap = IDTC_DanhSachTroCap;
                        pTC_DanhSachTroCap_ChiTietInfo.SoTien = pTC_DanhSachTroCapInfo.SoTien / adrChiTiet.Length;//float.Parse(drChiTiet["SoTien"].ToString());
                        pTC_DanhSachTroCap_ChiTietInfo.Thang = int.Parse(drChiTiet["Thang"].ToString());
                        oBTC_DanhSachTroCap_ChiTiet.Add(pTC_DanhSachTroCap_ChiTietInfo);
                    }
                }
                ThongBao("Cập nhật thành công!");
            }
            else
                ThongBao("Không có dữ liệu để lưu!");
        }
     
    }
}