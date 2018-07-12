using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;

namespace UnimOs.UI
{
    public partial class frmToChucThi : frmBase
    {
        private cBKQHT_ToChucThi oBKQHT_ToChucThi;
        private KQHT_ToChucThiInfo pKQHT_ToChucThiInfo;
        private cBKQHT_DanhSachDuThi oBKQHT_DanhSachDuThi;
        private KQHT_DanhSachDuThiInfo pKQHT_DanhSachDuThiInfo;
        private cBDM_Lop oBDM_Lop;
        private cBDM_MonHoc oBDM_MonHoc;
        private DataTable dtDanhSach, dtPhongThi;
        private DataRow drPhongThi;
        private int IDKQHT_ToChucThi, IDDM_MonHoc;

        public frmToChucThi(int mIDKQHT_ToChucThi, int mIDDM_MonHoc, string TenMonHoc)
        {
            InitializeComponent();
            IDKQHT_ToChucThi = mIDKQHT_ToChucThi;
            IDDM_MonHoc = mIDDM_MonHoc;
            txtTenMonHoc.Text = TenMonHoc;
            oBDM_Lop = new cBDM_Lop();
            oBDM_MonHoc = new cBDM_MonHoc();
            oBKQHT_ToChucThi = new cBKQHT_ToChucThi();
            pKQHT_ToChucThiInfo = new KQHT_ToChucThiInfo();
            oBKQHT_DanhSachDuThi = new cBKQHT_DanhSachDuThi();
            pKQHT_DanhSachDuThiInfo = new KQHT_DanhSachDuThiInfo();
            DataTable dt = (new cBDM_PhongHoc()).GetAll();
            repositoryItemLookUpEditPhongThi.DataSource = dt;
            dtpNgayThi.EditValue = DateTime.Today;
        }

        private void frmToChucThi_Load(object sender, EventArgs e)
        {
            cBKQHT_DanhSachDuThi oBKQHT_DanhSachDuThi =new cBKQHT_DanhSachDuThi();
            dtDanhSach = oBKQHT_DanhSachDuThi.GetByIDToChucThi(IDKQHT_ToChucThi);
            grdSinhVienDuThi.DataSource = dtDanhSach;
            dtPhongThi = oBKQHT_ToChucThi.GetPhongThi(IDKQHT_ToChucThi);
            grdPhongThi.DataSource = dtPhongThi;
            if (IDKQHT_ToChucThi > 0)
            {
                pKQHT_ToChucThiInfo.KQHT_ToChucThiID = IDKQHT_ToChucThi;
                DataTable dt = oBKQHT_ToChucThi.Get(pKQHT_ToChucThiInfo);
                if (dt.Rows.Count > 0)
                    oBKQHT_ToChucThi.ToInfo(ref pKQHT_ToChucThiInfo, dt.Rows[0]);
                SetText();
            }
        }

        private void SetText()
        {
            dtpNgayThi.EditValue = pKQHT_ToChucThiInfo.NgayThi;
            cmbLanThi.EditValue = pKQHT_ToChucThiInfo.LanThi;
            cmbDotThi.EditValue = pKQHT_ToChucThiInfo.DotThi;
            cmbCaThi.SelectedIndex = pKQHT_ToChucThiInfo.CaThi;
            cmbNhomTiet.EditValue = pKQHT_ToChucThiInfo.NhomTiet;
        }

        private void GetpToChucThiInfo()
        {
            pKQHT_ToChucThiInfo.IDDM_MonHoc = IDDM_MonHoc;
            pKQHT_ToChucThiInfo.IDDM_NamHoc = Program.IDNamHoc;
            pKQHT_ToChucThiInfo.HocKy = Program.HocKy;
            pKQHT_ToChucThiInfo.LanThi = int.Parse(cmbLanThi.Text);
            pKQHT_ToChucThiInfo.DotThi = int.Parse(cmbDotThi.Text);
            pKQHT_ToChucThiInfo.CaThi = cmbCaThi.SelectedIndex;
            pKQHT_ToChucThiInfo.NhomTiet = int.Parse(cmbNhomTiet.Text);
            pKQHT_ToChucThiInfo.NgayThi = (DateTime)dtpNgayThi.EditValue;
            pKQHT_ToChucThiInfo.IDHT_User = Program.objUserCurrent.HT_UserID;
            pKQHT_ToChucThiInfo.TotNghiep = chkTotNghiep.Checked;
            pKQHT_ToChucThiInfo.DongTui = false;
        }

        private void GetpDangSachDuThiInfo(int IDSV_SinhVien, int IDDM_PhongHoc, int SoBaoDanh, int KQHT_DanhSachDuThiID)
        {
            pKQHT_DanhSachDuThiInfo.KQHT_DanhSachDuThiID = KQHT_DanhSachDuThiID;
            pKQHT_DanhSachDuThiInfo.IDKQHT_ToChucThi = pKQHT_ToChucThiInfo.KQHT_ToChucThiID;
            pKQHT_DanhSachDuThiInfo.IDSV_SinhVien = IDSV_SinhVien;
            pKQHT_DanhSachDuThiInfo.IDDM_PhongHoc = IDDM_PhongHoc;
            pKQHT_DanhSachDuThiInfo.SoBaoDanh = SoBaoDanh;
        }

        private bool CheckValid()
        {
            string strError = "";
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (grvSinhVienDuThi.DataRowCount <= 0)
            {
                strError = "Danh sách sinh viên";
            }
            if (grvPhongThi.DataRowCount <= 0)
            {
                if (strError != "")
                    strError += " và danh sách phòng học";
                else
                    strError = "Danh sách phòng học";
            }
            else
            {
                int SoSinhVien = 0;
                foreach (DataRow dr in dtPhongThi.Rows)
                {
                    SoSinhVien += int.Parse(dr["SoSinhVien"].ToString());
                }
                if (SoSinhVien != grvSinhVienDuThi.DataRowCount)
                {
                    ThongBao("Số sinh viên trong các phòng thi không thể khác số sinh viên dự thi.");
                    return false;
                }
            }
            if (strError != "")
                strError += " không được rỗng.";

            if ((CtrlErr != null) || strError != "")
            {
                if (strError != "")
                    ThongBao(strError);
                return false;
            }
            else
                return true;
        }

        private void btnThemSV_Click(object sender, EventArgs e)
        {
            dlgToChucThiThemSinhVien dlg = new dlgToChucThiThemSinhVien(ref dtDanhSach, IDDM_MonHoc, int.Parse(cmbLanThi.Text), chkTotNghiep.Checked);
            dlg.ShowDialog();
        }

        private void btnToChucThi_Click(object sender, EventArgs e)
        {
            if (CheckValid()== false) return;
            try
            {
                GetpToChucThiInfo();
                int SoSinhVien, Den = 0;
                // Nếu IDKQHT_ToChucThi <= 0 tức là thêm, còn không thì sửa
                if (IDKQHT_ToChucThi <= 0)
                {
                    pKQHT_ToChucThiInfo.KQHT_ToChucThiID = oBKQHT_ToChucThi.Add(pKQHT_ToChucThiInfo);
                    foreach (DataRow drPhong in dtPhongThi.Rows)
                    {
                        SoSinhVien = int.Parse(drPhong["SoSinhVien"].ToString());
                        int SoBaoDanh = 1;
                        for (int i = Den; i < Den + SoSinhVien; i++)
                        {
                            grvSinhVienDuThi.GetDataRow(i)["SoBaoDanh"] = SoBaoDanh;
                            // Thêm các sinh viên vào danh sách dự thi
                            GetpDangSachDuThiInfo(int.Parse(grvSinhVienDuThi.GetDataRow(i)["IDSV_SinhVien"].ToString()),
                                int.Parse(drPhong["IDDM_PhongHoc"].ToString()), SoBaoDanh, int.Parse(grvSinhVienDuThi.GetDataRow(i)["KQHT_DanhSachDuThiID"].ToString()));
                            grvSinhVienDuThi.GetDataRow(i)["KQHT_DanhSachDuThiID"] = oBKQHT_DanhSachDuThi.Add(pKQHT_DanhSachDuThiInfo);
                            SoBaoDanh++;
                        }
                        Den += SoSinhVien;
                    }
                    ThemThanhCong();
                }
                else
                { 
                    // Phần sửa tổ chức thi
                    oBKQHT_ToChucThi.Update(pKQHT_ToChucThiInfo);
                    foreach (DataRow drPhong in dtPhongThi.Rows)
                    {
                        SoSinhVien = int.Parse(drPhong["SoSinhVien"].ToString());
                        int SoBaoDanh = 1;
                        for (int i = Den; i < Den + SoSinhVien; i++)
                        {
                            grvSinhVienDuThi.GetDataRow(i)["SoBaoDanh"] = SoBaoDanh;
                            // Thêm các sinh viên vào danh sách dự thi
                            GetpDangSachDuThiInfo(int.Parse(grvSinhVienDuThi.GetDataRow(i)["IDSV_SinhVien"].ToString()),
                                int.Parse(drPhong["IDDM_PhongHoc"].ToString()), SoBaoDanh, int.Parse(grvSinhVienDuThi.GetDataRow(i)["KQHT_DanhSachDuThiID"].ToString()));
                            if (pKQHT_DanhSachDuThiInfo.KQHT_DanhSachDuThiID <= 0)
                                grvSinhVienDuThi.GetDataRow(i)["KQHT_DanhSachDuThiID"] = oBKQHT_DanhSachDuThi.Add(pKQHT_DanhSachDuThiInfo);
                            else
                                oBKQHT_DanhSachDuThi.Update(pKQHT_DanhSachDuThiInfo);
                            SoBaoDanh++;
                        }
                        Den += SoSinhVien;
                    }
                    SuaThanhCong();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ThongBao(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataRow dr;
            for (int i = 0; i < dtDanhSach.Rows.Count;i++ )
            {
                dr = dtDanhSach.Rows[i];
                if (bool.Parse(dr["Chon"].ToString()))
                {
                    if (int.Parse("" + dr["KQHT_DanhSachDuThiID"]) > 0)
                    {
                        oBKQHT_DanhSachDuThi.ToInfo(ref pKQHT_DanhSachDuThiInfo, dr);
                        oBKQHT_DanhSachDuThi.Delete(pKQHT_DanhSachDuThiInfo);
                        dtDanhSach.Rows.Remove(dr);
                    }
                    else
                        dtDanhSach.Rows.Remove(dr);
                    i--;
                }
            }
        }

        private void grdPhongThi_Enter(object sender, EventArgs e)
        {
            if (grvPhongThi.RowCount == 0)
            {
                DataRow drNew = dtPhongThi.NewRow();
                drNew["SoSinhVien"] = 0;
                dtPhongThi.Rows.Add(drNew);
                grvPhongThi.FocusedColumn = colPhongThi;
            }
        }

        private void grvPhongThi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (grvPhongThi.FocusedRowHandle == grvPhongThi.DataRowCount - 1 && grvPhongThi.FocusedColumn == colSoSV)
                {
                    DataRow drNew = dtPhongThi.NewRow();
                    drNew["SoSinhVien"] = 0;
                    dtPhongThi.Rows.Add(drNew);
                    grvPhongThi.FocusedColumn = colPhongThi;
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (grvPhongThi.FocusedRowHandle >= 0)
                    dtPhongThi.Rows.Remove(drPhongThi);
            }
        }

        private void grvPhongThi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvPhongThi.RowCount > 0)
            {
                drPhongThi = grvPhongThi.GetDataRow(grvPhongThi.FocusedRowHandle);
            }
        }

        private void grvSinhVienDuThi_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
    }
}
