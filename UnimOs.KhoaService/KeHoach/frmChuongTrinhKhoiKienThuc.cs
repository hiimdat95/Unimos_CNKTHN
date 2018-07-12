using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using TruongViet.UnimOs.wsBusiness;
using TruongViet.UnimOs.Entity;

namespace UnimOs.Khoa
{
    public partial class frmChuongTrinhKhoiKienThuc : frmBase
    {
        private cBwsKQHT_CT_KhoiKienThuc oBKQHT_CT_KhoiKienThuc;
        private KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo;
        private cBwsKQHT_MonHoc_CT_KhoiKienThuc oBKQHT_MonHoc_CT_KhoiKienThuc;
        private KQHT_MonHoc_CT_KhoiKienThucInfo pKQHT_MonHoc_CT_KhoiKienThucInfo;
        private DataTable dtCTDT, dtMonHoc;
        private int mMaxCTSo = 0;

        public frmChuongTrinhKhoiKienThuc()
        {
            InitializeComponent();
            oBKQHT_CT_KhoiKienThuc = new cBwsKQHT_CT_KhoiKienThuc();
            pKQHT_CT_KhoiKienThucInfo = new KQHT_CT_KhoiKienThucInfo();
            oBKQHT_MonHoc_CT_KhoiKienThuc = new cBwsKQHT_MonHoc_CT_KhoiKienThuc();
            pKQHT_MonHoc_CT_KhoiKienThucInfo = new KQHT_MonHoc_CT_KhoiKienThucInfo();
            SetButton(false);
        }

        private void frmChuongTrinhKhoiKienThuc_Load(object sender, EventArgs e)
        {
            repositorycmbHinhThucThi.DataSource = LoadHinhThucThi();
            LoadCTDT();
        }

        private void LoadCTDT()
        {
            dtCTDT = oBKQHT_CT_KhoiKienThuc.GetDanhSach(0);
            grdCTDT.DataSource = dtCTDT;
            if (dtCTDT.Rows.Count > 0)
                mMaxCTSo = int.Parse(dtCTDT.Rows[0]["CT_KhoiKienThucSo"].ToString());
        }

        private void SetButton(bool status)
        {
            btnMonHoc.Enabled = status;
            btnXoaMon.Enabled = status;
            btnCapNhat.Enabled = status;
        }

        private void grvCTDT_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvCTDT.DataRowCount > 0)
            {
                if (grvCTDT.FocusedRowHandle >= 0)
                {
                    SetButton(true);
                    DataRow dr = grvCTDT.GetDataRow(grvCTDT.FocusedRowHandle);
                    pKQHT_CT_KhoiKienThucInfo.KQHT_CT_KhoiKienThucID = int.Parse(dr[pKQHT_CT_KhoiKienThucInfo.strKQHT_CT_KhoiKienThucID].ToString());
                    pKQHT_CT_KhoiKienThucInfo.TenCT_KhoiKienThuc = dr[pKQHT_CT_KhoiKienThucInfo.strTenCT_KhoiKienThuc].ToString();
                    pKQHT_CT_KhoiKienThucInfo.IDDM_KhoiKienThuc = int.Parse(dr[pKQHT_CT_KhoiKienThucInfo.strIDDM_KhoiKienThuc].ToString());
                    pKQHT_CT_KhoiKienThucInfo.CT_KhoiKienThucSo = int.Parse(dr[pKQHT_CT_KhoiKienThucInfo.strCT_KhoiKienThucSo].ToString());
                    pKQHT_CT_KhoiKienThucInfo.IDDM_TrinhDo = int.Parse(dr[pKQHT_CT_KhoiKienThucInfo.strIDDM_TrinhDo].ToString());
                    pKQHT_CT_KhoiKienThucInfo.IDDM_KhoaHoc = int.Parse(dr[pKQHT_CT_KhoiKienThucInfo.strIDDM_KhoaHoc].ToString());
                    pKQHT_CT_KhoiKienThucInfo.IDDM_Nganh = int.Parse(dr[pKQHT_CT_KhoiKienThucInfo.strIDDM_Nganh].ToString());
                    pKQHT_CT_KhoiKienThucInfo.IDDM_ChuyenNganh = int.Parse(dr[pKQHT_CT_KhoiKienThucInfo.strIDDM_ChuyenNganh].ToString());
                    pKQHT_CT_KhoiKienThucInfo.MoTa = "" + dr[pKQHT_CT_KhoiKienThucInfo.strMoTa].ToString();

                    dtMonHoc = oBKQHT_MonHoc_CT_KhoiKienThuc.GetDanhSachMon(pKQHT_CT_KhoiKienThucInfo.KQHT_CT_KhoiKienThucID);
                    grdMonHoc.DataSource = dtMonHoc;
                }
                else
                {
                    grdMonHoc.DataSource = null;
                    SetButton(false);
                }
            }
        }

        private void barbtnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //dlgCT_KhoiKienThuc dlg = new dlgCT_KhoiKienThuc(pKQHT_CT_KhoiKienThucInfo, EDIT_MODE.THEM, mMaxCTSo);
            //dlg.ShowDialog();
            //if (dlg.Tag.ToString() == "1")
            //{
            //    try
            //    {
            //        pKQHT_CT_KhoiKienThucInfo = dlg.pCTDT;
            //        pKQHT_CT_KhoiKienThucInfo.KQHT_CT_KhoiKienThucID = oBKQHT_CT_KhoiKienThuc.Add(pKQHT_CT_KhoiKienThucInfo);
            //        DataRow drNew = dtCTDT.NewRow();
            //        oBKQHT_CT_KhoiKienThuc.ToDataRow(pKQHT_CT_KhoiKienThucInfo, ref drNew);
            //        drNew["TenTrinhDo"] = dlg.cmbTrinhDo.Text;
            //        DM_HeInfo pDM_HeInfo = new DM_HeInfo();
            //        pDM_HeInfo.DM_HeID = int.Parse(dlg.cmbTrinhDo.GetColumnValue("IDDM_He").ToString());
            //        drNew["TenHe"] = new cBwsDM_He().Get(pDM_HeInfo).Rows[0]["TenHe"].ToString();
            //        drNew["TenKhoiKienThuc"] = dlg.cmbKhoiKienThuc.Text;
            //        drNew["TenNganh"] = dlg.ucmbNganh.cmb.Text;
            //        drNew["TenChuyenNganh"] = dlg.ucmbChuyenNganh.cmb.Text;
            //        drNew["TenKhoaHoc"] = dlg.cmbKhoaHoc.Text;
            //        dtCTDT.Rows.Add(drNew);
            //        //LoadCTDT();
            //        dlgCTDTChonMonHoc dlgMon = new dlgCTDTChonMonHoc(pKQHT_CT_KhoiKienThucInfo.KQHT_CT_KhoiKienThucID, pKQHT_CT_KhoiKienThucInfo.TenCT_KhoiKienThuc, ref dtMonHoc);
            //        dlgMon.ShowDialog();
            //        // Ghi Log
            //        GhiLog("Thêm chương trình khối kiến thức '" + pKQHT_CT_KhoiKienThucInfo.TenCT_KhoiKienThuc + "'", "Thêm", this.Tag.ToString());
            //        ThemThanhCong();
            //    }
            //    catch (Exception ex)
            //    {
            //        ThongBao(ex.Message);
            //    }
            //}
        }

        private void barbtnThemKeThua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (grvCTDT.FocusedRowHandle >= 0)
            //{
            //    int IDKQHT_CT_KhoiKienThucGoc = pKQHT_CT_KhoiKienThucInfo.KQHT_CT_KhoiKienThucID;
            //    dlgCT_KhoiKienThucKeThua frm = new dlgCT_KhoiKienThucKeThua(pKQHT_CT_KhoiKienThucInfo, mMaxCTSo);
            //    frm.ShowDialog();
            //    if (frm.Tag.ToString() == "1")
            //    {
            //        try
            //        {
            //            pKQHT_CT_KhoiKienThucInfo = frm.pKQHT_CT_KhoiKienThucInfo;
            //            pKQHT_CT_KhoiKienThucInfo.KQHT_CT_KhoiKienThucID = oBKQHT_CT_KhoiKienThuc.AddKeThua(pKQHT_CT_KhoiKienThucInfo, IDKQHT_CT_KhoiKienThucGoc);
            //            LoadCTDT();
            //            //dlgCTDTChonMonHoc dlgMon = new dlgCTDTChonMonHoc(pKQHT_CT_KhoiKienThucInfo.KQHT_CT_KhoiKienThucID, pKQHT_CT_KhoiKienThucInfo.TenCT_KhoiKienThuc, ref dtMonHoc);
            //            //dlgMon.ShowDialog();
            //            // Ghi Log
            //            GhiLog("Thêm chương trình khối kiến thức '" + pKQHT_CT_KhoiKienThucInfo.TenCT_KhoiKienThuc + "'", "Thêm", this.Tag.ToString());
            //            ThemThanhCong();
            //        }
            //        catch (Exception ex)
            //        {
            //            ThongBao(ex.Message);
            //        }
            //    }
            //}
            //else
            //    ThongBao("Bạn chưa chọn chương trình khối kiến thức nào.");
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (grvCTDT.FocusedRowHandle >= 0)
            //{
            //    dlgCT_KhoiKienThuc dlg = new dlgCT_KhoiKienThuc(pKQHT_CT_KhoiKienThucInfo, EDIT_MODE.SUA, mMaxCTSo);
            //    dlg.ShowDialog();
            //    if (dlg.Tag.ToString() == "1")
            //    {
            //        try
            //        {
            //            pKQHT_CT_KhoiKienThucInfo = dlg.pCTDT;
            //            oBKQHT_CT_KhoiKienThuc.Update(pKQHT_CT_KhoiKienThucInfo);
            //            // Ghi Log
            //            GhiLog("Sửa chương trình khối kiến thức '" + pKQHT_CT_KhoiKienThucInfo.TenCT_KhoiKienThuc + "'", "Sửa", this.Tag.ToString());
            //            LoadCTDT();
            //            SuaThanhCong();
            //        }
            //        catch (Exception ex)
            //        {
            //            ThongBao(ex.Message);
            //        }
            //    }
            //}
            //else
            //    ThongBao("Bạn chưa chọn chương trình khối kiến thức nào.");
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (grvCTDT.FocusedRowHandle >= 0)
            //{
            //    if (ThongBaoChon("Bạn có chắc chắn muốn xóa?") == DialogResult.Yes)
            //    {
            //        try
            //        {
            //            oBKQHT_CT_KhoiKienThuc.Delete(pKQHT_CT_KhoiKienThucInfo);
            //            grvCTDT.GetDataRow(grvCTDT.FocusedRowHandle).Delete();
            //            // Ghi Log
            //            GhiLog("Xóa chương trình khối kiến thức '" + pKQHT_CT_KhoiKienThucInfo.TenCT_KhoiKienThuc + "'", "Xóa", this.Tag.ToString());
            //            XoaThanhCong();
            //        }
            //        catch
            //        {
            //            XoaThatBai();
            //        }
            //    }
            //}
            //else
            //    ThongBao("Bạn chưa chọn chương trình khối kiến thức nào.");
        }

        private void btnMonHoc_Click(object sender, EventArgs e)
        {
            if (grvCTDT.FocusedRowHandle >= 0)
            {
                dlgCTDTChonMonHoc dlg = new dlgCTDTChonMonHoc(pKQHT_CT_KhoiKienThucInfo.KQHT_CT_KhoiKienThucID, pKQHT_CT_KhoiKienThucInfo.TenCT_KhoiKienThuc, ref dtMonHoc);
                dlg.ShowDialog();
                if (dlg.DialogResult == DialogResult.OK)
                {
                    // Ghi Log
                    GhiLog("Thêm môn học vào chương trình khối kiến thức '" + pKQHT_CT_KhoiKienThucInfo.TenCT_KhoiKienThuc + "'", "Thêm", this.Tag.ToString());
                    //grvCTDT_FocusedRowChanged(null, null);
                }
            }
            else
                ThongBao("Bạn chưa chọn chương trình khối kiến thức nào.");
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (grvCTDT.FocusedRowHandle >= 0)
            {
                if (ThongBaoChon("Bạn có chắc chắn muốn xóa!") == DialogResult.Yes)
                {
                    bool Chon = false;
                    int mSoRows = dtMonHoc.Rows.Count;
                    string TenMonHocs = "";
                    try
                    {
                        for (int i = 0; i < mSoRows; i++)
                        {
                            if (bool.Parse(dtMonHoc.Rows[i]["Chon"].ToString()) == true)
                            {
                                Chon = true;
                                pKQHT_MonHoc_CT_KhoiKienThucInfo.KQHT_MonHoc_CT_KhoiKienThucID = int.Parse(dtMonHoc.Rows[i]["KQHT_MonHoc_CT_KhoiKienThucID"].ToString());
                                oBKQHT_MonHoc_CT_KhoiKienThuc.Delete(pKQHT_MonHoc_CT_KhoiKienThucInfo);
                                TenMonHocs += dtMonHoc.Rows[i]["TenMonHoc"] + ",";
                                dtMonHoc.Rows.Remove(dtMonHoc.Rows[i]);
                                mSoRows = mSoRows - 1;
                                i = i - 1;
                            }
                        }
                        if (Chon == false)
                            ThongBao("Bạn chưa chọn môn nào.");
                        else
                        {
                            // Ghi Log
                            GhiLog("Xóa các môn học " + TenMonHocs + " khỏi chương trình khối kiến thức '" + pKQHT_CT_KhoiKienThucInfo.TenCT_KhoiKienThuc + "'", "Xóa", this.Tag.ToString());
                            XoaThanhCong();
                        }
                    }
                    catch
                    {
                        XoaThatBai();
                    }
                }
            }
            else
                ThongBao("Bạn chưa chọn chương trình khối kiến thức nào.");
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = dtMonHoc.GetChanges();
            if (dtTemp != null)
            {
                bool mStatus = true;
                foreach (DataRow dr in dtTemp.Rows)
                {
                    if (dr.RowState == DataRowState.Modified)
                    {
                        try
                        {
                            pKQHT_MonHoc_CT_KhoiKienThucInfo.KQHT_MonHoc_CT_KhoiKienThucID = int.Parse(dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strKQHT_MonHoc_CT_KhoiKienThucID].ToString());
                            pKQHT_MonHoc_CT_KhoiKienThucInfo.IDDM_HinhThucThi = int.Parse(dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strIDDM_HinhThucThi].ToString());
                            pKQHT_MonHoc_CT_KhoiKienThucInfo.IDDM_MonHoc = int.Parse(dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strIDDM_MonHoc].ToString());
                            pKQHT_MonHoc_CT_KhoiKienThucInfo.IDKQHT_CT_KhoiKienThuc = int.Parse(dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strIDKQHT_CT_KhoiKienThuc].ToString());
                            pKQHT_MonHoc_CT_KhoiKienThucInfo.LoaiTietKhac1 = int.Parse(dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strLoaiTietKhac1].ToString());
                            pKQHT_MonHoc_CT_KhoiKienThucInfo.LoaiTietKhac2 = int.Parse(dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strLoaiTietKhac2].ToString());
                            pKQHT_MonHoc_CT_KhoiKienThucInfo.LyThuyet = int.Parse(dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strLyThuyet].ToString());
                            pKQHT_MonHoc_CT_KhoiKienThucInfo.ThucHanh = int.Parse(dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strThucHanh].ToString());
                            pKQHT_MonHoc_CT_KhoiKienThucInfo.SoTiet = pKQHT_MonHoc_CT_KhoiKienThucInfo.LoaiTietKhac1 + pKQHT_MonHoc_CT_KhoiKienThucInfo.LoaiTietKhac2 + pKQHT_MonHoc_CT_KhoiKienThucInfo.LyThuyet + pKQHT_MonHoc_CT_KhoiKienThucInfo.ThucHanh;
                            pKQHT_MonHoc_CT_KhoiKienThucInfo.SoHocTrinh = double.Parse(dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strSoHocTrinh].ToString());
                            pKQHT_MonHoc_CT_KhoiKienThucInfo.ChoPhepXepLich = bool.Parse(dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strChoPhepXepLich].ToString());
                            pKQHT_MonHoc_CT_KhoiKienThucInfo.TuChon = bool.Parse(dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strTuChon].ToString());
                            pKQHT_MonHoc_CT_KhoiKienThucInfo.TinhDiemToanKhoa = bool.Parse(dr[pKQHT_MonHoc_CT_KhoiKienThucInfo.strTinhDiemToanKhoa].ToString());
                            oBKQHT_MonHoc_CT_KhoiKienThuc.Update(pKQHT_MonHoc_CT_KhoiKienThucInfo);
                        }
                        catch
                        {
                            mStatus = false;
                        }
                    }
                }
                if (mStatus == true)
                {
                    // Ghi Log
                    GhiLog("Cập nhật chương trình khối kiến thức '" + pKQHT_CT_KhoiKienThucInfo.TenCT_KhoiKienThuc + "'", "Cập nhật", this.Tag.ToString());
                    grvCTDT_FocusedRowChanged(null, null);
                    ThongBao("Cập nhật thành công.");
                }
                else
                {
                    ThongBao("Lỗi trong quá trình cập nhật.");
                }
            }
        }

        private void grvMonHoc_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }        

        private void grdMonHoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.W)
            {
                this.Close();
            }
        }
    }
}