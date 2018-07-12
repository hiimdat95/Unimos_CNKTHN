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
    public partial class frmBienLaiThuTien_Tree : frmBase
    {
        private cBTC_BienLaiThuTien oBTC_BienLaiThuTien;
        private TC_BienLaiThuTienInfo pTC_BienLaiThuTienInfo;
        private cBTC_BienLaiThuTien_ChiTiet oBTC_BienLaiThuTien_ChiTiet;
        private TC_BienLaiThuTien_ChiTietInfo pTC_BienLaiThuTien_ChiTietInfo;
        private cBTC_DinhMucThuSinhVien oBTC_DinhMuc;
        private cBSV_SinhVien_Lop oBSV_SinhVien_Lop;
        private cBDM_NamHoc oBNamHoc;
        private DM_NamHocInfo pNamHocInfo;
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private DataTable dtSinhVien, dtPhieuThu;
        private int IDSV_SinhVien = 0, IDDM_DiaDiem = 0, idxRowFocus = 0;
        private string MaSinhVien = "";
        private Lib.clsStringHelper clsStrHelper;

        public frmBienLaiThuTien_Tree()
        {
            InitializeComponent();
            oBTC_BienLaiThuTien = new cBTC_BienLaiThuTien();
            pTC_BienLaiThuTienInfo = new TC_BienLaiThuTienInfo();
            oBTC_BienLaiThuTien_ChiTiet = new cBTC_BienLaiThuTien_ChiTiet();
            oBSV_SinhVien_Lop = new cBSV_SinhVien_Lop();
            oBTC_DinhMuc = new cBTC_DinhMucThuSinhVien();
            clsStrHelper = new Lib.clsStringHelper();
            oBNamHoc = new cBDM_NamHoc();
            pNamHocInfo = new DM_NamHocInfo();
            oBDM_Lop = new cBDM_Lop();
        }

        private void frmBienLaiThuTien_Tree_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                LoadSinhVien();
            }
            else
            {
                grdSinhVien.DataSource = null;
            }
        }

        private void LoadSinhVien()
        {
            dtSinhVien = oBSV_SinhVien_Lop.Get_ThuChi(pDM_LopInfo.DM_LopID, Program.IDNamHoc, Program.HocKy);
            grdSinhVien.DataSource = dtSinhVien;
        }

        private void grvChiTiet_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvPhieuThu_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && grdPhieuThu.ClientRectangle.Contains(e.X, e.Y))
            {
                popupMenu1.ShowPopup(MousePosition);
            }
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            idxRowFocus = grvSinhVien.FocusedRowHandle;
            dlgBienLaiThuTienChiTiet dlg = new dlgBienLaiThuTienChiTiet(0, false, MaSinhVien);
            dlg.IDDM_Lop = pDM_LopInfo.DM_LopID;
            dlg.IDDM_DiaDiem = pDM_LopInfo.IDDM_DiaDiem;
            dlg.ShowDialog();
            if (dlg.Tag.ToString() == "1")
            {
                trlLop_FocusedNodeChanged(null, null);
                grvSinhVien.FocusedRowHandle = idxRowFocus;
                grvSinhVien_FocusedRowChanged(null, null);
            }
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvPhieuThu.FocusedRowHandle >= 0)
            {
                DataRow drPhieuThu = grvPhieuThu.GetDataRow(grvPhieuThu.FocusedRowHandle);
                if (bool.Parse(drPhieuThu["PhieuHuy"].ToString()) == false)
                {
                    idxRowFocus = grvSinhVien.FocusedRowHandle;
                    dlgBienLaiThuTienChiTiet dlg = new dlgBienLaiThuTienChiTiet(int.Parse(drPhieuThu["TC_BienLaiThuTienID"].ToString()), true, MaSinhVien);
                    dlg.IDDM_Lop = pDM_LopInfo.DM_LopID;
                    dlg.ShowDialog();
                    if (dlg.Tag.ToString() == "1")
                    {
                        trlLop_FocusedNodeChanged(null, null);
                        grvSinhVien.FocusedRowHandle = idxRowFocus;
                        grvSinhVien_FocusedRowChanged(null, null);
                    }
                }
                else
                    ThongBao("Phiếu đã hủy không thể sửa!");
            }
            else
                ThongBao("Bạn chưa chọn phiếu để sửa!");
        }

        private void barbtnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvPhieuThu.FocusedRowHandle >= 0)
            {
                DataRow drPhieuThu = grvPhieuThu.GetDataRow(grvPhieuThu.FocusedRowHandle);
                if (bool.Parse(drPhieuThu["PhieuHuy"].ToString()) != true)
                {
                    if (ThongBaoChon("Bạn có chắc chắn hủy phiếu ko?") == DialogResult.Yes)
                    {
                        oBTC_BienLaiThuTien.UpdatePhieuHuy(int.Parse(drPhieuThu["TC_BienLaiThuTienID"].ToString()), DateTime.Now, Program.objUserCurrent.HT_UserID, 1);
                        drPhieuThu["PhieuHuy"] = true;
                    }
                }
                else
                    ThongBao("Phiếu đã hủy!");
            }
            else
                ThongBao("Bạn chưa chọn phiếu để hủy!");
        }

        private void barbtnBoHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvPhieuThu.FocusedRowHandle >= 0)
            {
                DataRow drPhieuThu = grvPhieuThu.GetDataRow(grvPhieuThu.FocusedRowHandle);
                if (bool.Parse(drPhieuThu["PhieuHuy"].ToString()) == true)
                {
                    if (ThongBaoChon("Bạn có chắc chắn bỏ hủy phiếu ko?") == DialogResult.Yes)
                    {
                        oBTC_BienLaiThuTien.UpdatePhieuHuy(int.Parse(drPhieuThu["TC_BienLaiThuTienID"].ToString()), DateTime.Now, Program.objUserCurrent.HT_UserID, 0);
                        drPhieuThu["PhieuHuy"] = false;
                    }
                }
            }
            else
                ThongBao("Phiếu này không phải phiếu hủy!");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            barbtnThem_ItemClick(null, null);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            barbtnSua_ItemClick(null, null);
        }

        private void btnThuTienCaLop_Click(object sender, EventArgs e)
        {
            if (ThongBaoChon("Bạn đang thực hiện thu tiền cho cả lớp theo số tiền đã định mức cho sinh viên " +
                "\nBạn có chắc chắn với lựa chọn này không?") == DialogResult.Yes)
            {
                if (dtSinhVien.Rows.Count > 0)
                {
                    try
                    {
                        int _IDSV_SinhVien;
                        DataTable dtDinhMuc;
                        foreach (DataRow dr in dtSinhVien.Rows)
                        {
                            if (double.Parse("0" + dr["SoTienPhaiNop"]) > 0 && double.Parse("0" + dr["SoTienDaNop"]) == 0)
                            {
                                _IDSV_SinhVien = int.Parse(dr["IDSV_SinhVien"].ToString());
                                dtDinhMuc = oBTC_DinhMuc.GetBy_SinhVien(_IDSV_SinhVien, Program.IDNamHoc, Program.HocKy, 1, 1, 0);
                                LapBienLaiThuTien(dtDinhMuc, _IDSV_SinhVien);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ThongBaoLoi("Đã có lỗi xảy ra trong quá trình thực hiên.\n" + ex.Message);
                    }
                }
            }
        }

        private void LapBienLaiThuTien(DataTable dtDinhMuc, int IDSV_SinhVien)
        {
            // Them bien lai thu tien
            pTC_BienLaiThuTienInfo = new TC_BienLaiThuTienInfo();
            pTC_BienLaiThuTienInfo.GhiChu = "";
            pTC_BienLaiThuTienInfo.HocKy = Program.HocKy;
            pTC_BienLaiThuTienInfo.IDDM_NamHoc = Program.IDNamHoc;
            pTC_BienLaiThuTienInfo.IDHT_NguoiThu = Program.objUserCurrent.HT_UserID;
            pTC_BienLaiThuTienInfo.IDSV_SinhVien = IDSV_SinhVien;
            pTC_BienLaiThuTienInfo.IDDM_Lop = pDM_LopInfo.DM_LopID;
            pTC_BienLaiThuTienInfo.NgayThu = DateTime.Now;
            pTC_BienLaiThuTienInfo.NoiDung = "THU TIỀN HỌC KỲ " + Program.HocKy.ToString() + " NĂM HỌC " + Program.NamHoc;
            pTC_BienLaiThuTienInfo.PhieuThu = true;
            pTC_BienLaiThuTienInfo.Printed = false;
            pTC_BienLaiThuTienInfo.SoPhieu = GetSoPhieu(Program.HocKy, Program.IDNamHoc, IDSV_SinhVien, pDM_LopInfo.IDDM_DiaDiem);
            //dtDinhMuc.Columns[3].
            pTC_BienLaiThuTienInfo.SoTien = SumColumnValue(dtDinhMuc, "SoTien");
            pTC_BienLaiThuTienInfo.SoTienBangChu = clsStrHelper.ReadMoney(pTC_BienLaiThuTienInfo.SoTien) + " đồng";
            pTC_BienLaiThuTienInfo.PhieuHuy = false;
            pTC_BienLaiThuTienInfo.NgayHuy = DateTime.Parse("1/1/1900");
            int intTC_BienLaiThuTienID = oBTC_BienLaiThuTien.Add(pTC_BienLaiThuTienInfo);
            // them bien lai thu tien chi tiet
            foreach (DataRow mdr in dtDinhMuc.Rows)
            {
                if (float.Parse("0" + mdr["SoTien"].ToString()) > 0 && mdr["TC_LoaiThuChiID"].ToString() != "")
                {
                    pTC_BienLaiThuTien_ChiTietInfo = new TC_BienLaiThuTien_ChiTietInfo();
                    pTC_BienLaiThuTien_ChiTietInfo.IDTC_BienLaiThuTien = intTC_BienLaiThuTienID;
                    pTC_BienLaiThuTien_ChiTietInfo.IDTC_DinhMucThuSinhVien = int.Parse("0" + mdr["IDTC_DinhMucThuSinhVien"].ToString());
                    pTC_BienLaiThuTien_ChiTietInfo.IDTC_LoaiThuChi = int.Parse(mdr["TC_LoaiThuChiID"].ToString());
                    pTC_BienLaiThuTien_ChiTietInfo.LanThu = int.Parse("0" + mdr["LanThu"].ToString());
                    pTC_BienLaiThuTien_ChiTietInfo.NoiDung = mdr["NoiDung"].ToString();
                    pTC_BienLaiThuTien_ChiTietInfo.SoTien = float.Parse("0" + mdr["SoTien"].ToString());
                    oBTC_BienLaiThuTien_ChiTiet.Add(pTC_BienLaiThuTien_ChiTietInfo);
                }
            }
        }

        private void grvSinhVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int idx = grvSinhVien.FocusedRowHandle;
            if (idx >= 0)
            {
                IDSV_SinhVien = int.Parse(grvSinhVien.GetDataRow(idx)["IDSV_SinhVien"].ToString());
                MaSinhVien = grvSinhVien.GetDataRow(idx)["MaSinhVien"].ToString();
                grdDinhMuc.DataSource = oBTC_DinhMuc.GetBySinhVien(IDSV_SinhVien, Program.IDNamHoc, Program.HocKy, 0);
                dtPhieuThu = oBTC_BienLaiThuTien.GetBySinhVien(IDSV_SinhVien, Program.IDNamHoc, Program.HocKy);
                grdPhieuThu.DataSource = dtPhieuThu;
            }
            else
            {
                IDSV_SinhVien = 0;
                MaSinhVien = "";
            }
        }

        #region Xu ly popup
        private void menuThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnThem_ItemClick(null, null);
        }

        private void menuSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnSua_ItemClick(null, null);
        }

        private void menuHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnHuy_ItemClick(null, null);
        }

        private void menuBoHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnBoHuy_ItemClick(null, null);
        }
        #endregion
    }
}