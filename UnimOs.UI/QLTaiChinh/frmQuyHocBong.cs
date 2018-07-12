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
    public partial class frmQuyHocBong : frmBase
    {
        private cBDM_LoaiQuy oBDM_LoaiQuy;
        private DM_LoaiQuyInfo pDM_LoaiQuyInfo;
        private cBTC_QuyHocBong oBTC_QuyHocBong;
        private TC_QuyHocBongInfo pTC_QuyHocBongInfo;
        private cBTC_PhanBoQuyHocBong oBTC_PhanBoQuyHocBong;
        private TC_PhanBoQuyHocBongInfo pTC_PhanBoQuyHocBongInfo;
        private int status;
        private DataTable dtLoaiQuy,dtDoiTuong;
        private DataRow drLoaiQuy, drDoiTuong;

        public frmQuyHocBong()
        {
            InitializeComponent();
            pDM_LoaiQuyInfo = new DM_LoaiQuyInfo();
            oBDM_LoaiQuy = new cBDM_LoaiQuy();
            pTC_QuyHocBongInfo = new TC_QuyHocBongInfo();
            oBTC_QuyHocBong = new cBTC_QuyHocBong();
            pTC_PhanBoQuyHocBongInfo = new TC_PhanBoQuyHocBongInfo();
            oBTC_PhanBoQuyHocBong = new cBTC_PhanBoQuyHocBong();
        }

        private void frmQuyHocBong_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            LoadCombo();
            GetLoaiQuy();
        }
        private void LoadCombo()
        {
            cmbHe.Properties.DataSource = LoadHe();
            cmbTrinhDo.Properties.DataSource = LoadTrinhDo();
            DataTable dtTemp = oBDM_LoaiQuy.Get(pDM_LoaiQuyInfo);
            cmbLoaiQuy.Properties.DataSource = dtTemp;
            if (dtTemp != null && dtTemp.Rows.Count > 0)
                cmbLoaiQuy.EditValue = dtTemp.Rows[0]["DM_LoaiQuyID"];
           
        }

        private void GetLoaiQuy()
        {
            pTC_QuyHocBongInfo.TC_QuyHocBongID = 0;
            dtLoaiQuy = oBTC_QuyHocBong.Get(pTC_QuyHocBongInfo);
            grdQuyHocBong.DataSource = dtLoaiQuy;
        }

        private void GetPhanBoHocBong(int IDTC_QuyHocBong)
        {
            dtDoiTuong = oBTC_PhanBoQuyHocBong.GetByQuyHocBong(IDTC_QuyHocBong, Program.IDNamHoc,Program.HocKy,0);
            grdDoiTuong.DataSource = dtDoiTuong;
            colPhanDacBiet.Visible = true;
            if (dtDoiTuong != null && dtDoiTuong.Rows.Count > 0)
                txtSoTienDaPhanBo.Text = double.Parse(dtDoiTuong.Rows[0]["TongTien"].ToString()).ToString("N0");
            else
                txtSoTienDaPhanBo.Text = "0";
        }

        private void GetInfo()
        {
            cmbLoaiQuy.EditValue = pTC_QuyHocBongInfo.IDDM_LoaiQuy;
            cmbHe.EditValue = pTC_QuyHocBongInfo.IDDM_He;
            cmbTrinhDo.EditValue = pTC_QuyHocBongInfo.IDDM_TrinhDo;
            chkHetHan.Checked = pTC_QuyHocBongInfo.HetHan;
            txtSoTien.Text = pTC_QuyHocBongInfo.SoTien.ToString();
            txtHocPhi.Text = pTC_QuyHocBongInfo.PhanTramHocPhi.ToString();
            if (txtSoTien.Text != "" && txtSoTien.Text != "0")
                rdNhapLieu.SelectedIndex = 0;
            else
                rdNhapLieu.SelectedIndex = 1;
        }

        private void SetInfo()
        {
            pTC_QuyHocBongInfo.IDDM_LoaiQuy = int.Parse(cmbLoaiQuy.EditValue.ToString());
            pTC_QuyHocBongInfo.IDDM_He = (cmbHe.EditValue == null ? 0 : int.Parse(cmbHe.EditValue.ToString()));
            pTC_QuyHocBongInfo.IDDM_TrinhDo = (cmbTrinhDo.EditValue == null ? 0 : int.Parse(cmbTrinhDo.EditValue.ToString()));
            pTC_QuyHocBongInfo.HetHan = chkHetHan.Checked;
            pTC_QuyHocBongInfo.SoTien = double.Parse("0" + txtSoTien.Text.Trim());
            pTC_QuyHocBongInfo.PhanTramHocPhi = double.Parse("0" + txtHocPhi.Text.Trim());
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (rdNhapLieu.SelectedIndex == 0 && (txtSoTien.Text == string.Empty || txtSoTien.Text.Trim() == "0"))
            {
                dxErrorProvider.SetError(txtSoTien, "Tên loại thu chi không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtSoTien;
            }
            if (rdNhapLieu.SelectedIndex == 1 && (txtHocPhi.Text == string.Empty || txtHocPhi.Text.Trim() == "0"))
            {
                dxErrorProvider.SetError(txtHocPhi, "Tên loại thu chi không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtHocPhi;
            }
            if (cmbLoaiQuy.EditValue == null)
            {
                dxErrorProvider.SetError(cmbLoaiQuy, "Tên loại thu chi không thể rỗng.");
                if (CtrlErr == null) CtrlErr = cmbLoaiQuy;
            }
            //Kiểm tra cập nhật thành công
            if ((CtrlErr != null))
                return false;
            else
                return true;
        }

        private void ClearText()
        {
            txtHocPhi.Text = "";
            txtSoTien.Text = "";
            chkHetHan.Checked = false;
        }

        private void rdNhapLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdNhapLieu.SelectedIndex == 0)
            {
                txtSoTien.Enabled = true;
                txtHocPhi.Enabled = false;
            }
            else
            {
                txtSoTien.Enabled = false;
                txtHocPhi.Enabled = true;
            }
        }

        private void cmbHe_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbHe.EditValue != null)
            {
                DataTable dtTrinhDo = LoadTrinhDoByIDHe(int.Parse(cmbHe.EditValue.ToString()));
                cmbTrinhDo.Properties.DataSource = dtTrinhDo;
                if (dtTrinhDo.Rows.Count > 0)
                    cmbTrinhDo.ItemIndex = 0;
            }
        }

        private void cmbHe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbHe.EditValue = null;
            }
        }

        private void cmbTrinhDo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbTrinhDo.EditValue = null;
            }
        }

        private void txtSoTienDaPhanBo_EditValueChanged(object sender, EventArgs e)
        {
            txtSoTienConLai.Text = (double.Parse("0" + txtSoTienQuy.Text.Replace(",", "")) - double.Parse("0" + txtSoTienDaPhanBo.Text.Replace(",", ""))).ToString("N0");
        }

        private void grvQuyHocBong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvQuyHocBong.FocusedRowHandle >= 0)
            {
                drLoaiQuy = grvQuyHocBong.GetDataRow(grvQuyHocBong.FocusedRowHandle);
                oBTC_QuyHocBong.ToInfo(ref pTC_QuyHocBongInfo, drLoaiQuy);
                txtSoTienQuy.Text = double.Parse(drLoaiQuy["SoTien"].ToString()).ToString("N0");
                GetPhanBoHocBong(pTC_QuyHocBongInfo.TC_QuyHocBongID);
            }
        }

        private void grvDoiTuong_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvDoiTuong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvDoiTuong.FocusedRowHandle >= 0)
            {
                drDoiTuong = grvDoiTuong.GetDataRow(grvDoiTuong.FocusedRowHandle);
            }
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearText();
            panelTop.Visible = true;
            cmbLoaiQuy.Focus();
            status = 0;
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            status = 1;
            panelTop.Visible = true;
            GetInfo();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                grvQuyHocBong_FocusedRowChanged(null, null);
                try
                {
                    oBTC_QuyHocBong.Delete(pTC_QuyHocBongInfo);
                    GetLoaiQuy();
                    XoaThanhCong();
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!Check_Valid()) return;
            try
            {
                SetInfo();
                if (status == 0)
                {
                    oBTC_QuyHocBong.Add(pTC_QuyHocBongInfo);
                    GetLoaiQuy();
                    ThemThanhCong();

                }
                else
                {
                    oBTC_QuyHocBong.Update(pTC_QuyHocBongInfo);
                    GetLoaiQuy();
                    SuaThanhCong();
                    panelTop.Visible = false;
                }
                ClearText();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearText();
            panelTop.Visible = false;
        }

        private void btnPhanTuDong_Click(object sender, EventArgs e)
        {
            if (chkKhoa.Checked == false && chkKhoaHoc.Checked == false && chkLop.Checked == false && chkNganh.Checked == false)
            {
                ThongBao("Bạn phải chọn phân theo Khoa, Khóa học, Ngành, Lớp!");
            }
            else
            {
                dtDoiTuong = oBTC_PhanBoQuyHocBong.GetDoiTuong((chkKhoa.Checked == true ? 1 : 0), (chkKhoaHoc.Checked == true ? 1 : 0),
                            (chkNganh.Checked == true ? 1 : 0), (chkLop.Checked == true ? 1 : 0));
                // tinh tien phan hoc bong

                if (dtDoiTuong != null && dtDoiTuong.Rows.Count > 0)
                {
                    int TongSinhVien = 0;
                    foreach (DataRow dr in dtDoiTuong.Rows)
                    {
                        TongSinhVien += int.Parse(dr["SoSinhVien"].ToString());
                    }
                    // chia tien cho tung doi tuong
                    foreach (DataRow dr in dtDoiTuong.Rows)
                    {
                        dr["SoTien"] = int.Parse(dr["SoSinhVien"].ToString())*(double.Parse("0" + txtSoTienConLai.Text.Replace(",", "").ToString()) / TongSinhVien);
                    }
                }
                dtDoiTuong.Columns.Add("TC_PhanBoQuyHocBongID", typeof(int));          
                grdDoiTuong.DataSource = dtDoiTuong;
                colPhanDacBiet.Visible = false;
            }
        }

        private void btnPhanDacBiet_Click(object sender, EventArgs e)
        {
            if (chkKhoa.Checked == false && chkKhoaHoc.Checked == false && chkLop.Checked == false && chkNganh.Checked == false)
            {
                ThongBao("Bạn phải chọn phân theo Khoa, Khóa học, Ngành, Lớp!");
            }
            else
            {
                dtDoiTuong = oBTC_PhanBoQuyHocBong.GetDoiTuong((chkKhoa.Checked == true ? 1 : 0), (chkKhoaHoc.Checked == true ? 1 : 0),
                            (chkNganh.Checked == true ? 1 : 0), (chkLop.Checked == true ? 1 : 0));
                dtDoiTuong.Columns.Add("TC_PhanBoQuyHocBongID", typeof(int));  
                frmPhanBoDacBiet frm = new frmPhanBoDacBiet(drLoaiQuy, ref dtDoiTuong, double.Parse("0" + txtSoTienDaPhanBo.Text.Replace(",","")));
                frm.ShowDialog();
             
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dtDoiTuong != null && dtDoiTuong.Rows.Count > 0)
            {
                if (ThongBaoChon("Tất cả các phân bổ tự động trước sẽ bị xóa! Bạn chắc chắn muốn lưu?") == DialogResult.Yes)
                {
                    try
                    {
                        oBTC_PhanBoQuyHocBong.DeleteBy_QuyHocBong(int.Parse(drLoaiQuy["TC_QuyHocBongID"].ToString()), Program.HocKy,Program.IDNamHoc);
                    }
                    catch { }

                    foreach (DataRow dr in dtDoiTuong.Rows)
                    {
                        pTC_PhanBoQuyHocBongInfo.HocKy = Program.HocKy;
                        pTC_PhanBoQuyHocBongInfo.IDDM_NamHoc = Program.IDNamHoc;
                        pTC_PhanBoQuyHocBongInfo.IDDM_Khoa = int.Parse(dr["DM_KhoaID"].ToString());
                        pTC_PhanBoQuyHocBongInfo.IDDM_Lop = int.Parse(dr["DM_LopID"].ToString());
                        pTC_PhanBoQuyHocBongInfo.IDDM_Nganh = int.Parse(dr["DM_NganhID"].ToString());
                        pTC_PhanBoQuyHocBongInfo.IDDM_KhoaHoc = int.Parse(dr["DM_KhoaHocID"].ToString());
                        pTC_PhanBoQuyHocBongInfo.IDTC_QuyHocBong = int.Parse(drLoaiQuy["TC_QuyHocBongID"].ToString());
                        pTC_PhanBoQuyHocBongInfo.PhanDacBiet = false;
                        pTC_PhanBoQuyHocBongInfo.SoSinhVien = int.Parse(dr["SoSinhVien"].ToString());
                        pTC_PhanBoQuyHocBongInfo.SoTien = double.Parse(dr["SoTien"].ToString());
                        dr["TC_PhanBoQuyHocBongID"] = oBTC_PhanBoQuyHocBong.Add(pTC_PhanBoQuyHocBongInfo);
                    }
                    ThongBao("Lưu thành công!");
                }
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvDoiTuong.FocusedRowHandle >= 0)
            {
                if (int.Parse("0" + grvDoiTuong.GetDataRow(grvDoiTuong.FocusedRowHandle)["TC_PhanBoQuyHocBongID"].ToString()) > 0)
                {
                    if (ThongBaoChon("Bạn chắc chắn muốn xóa?") == DialogResult.Yes)
                    {
                        try
                        {
                            pTC_PhanBoQuyHocBongInfo.TC_PhanBoQuyHocBongID = int.Parse("0" + grvDoiTuong.GetDataRow(grvDoiTuong.FocusedRowHandle)["TC_PhanBoQuyHocBongID"].ToString());
                            oBTC_PhanBoQuyHocBong.Delete(pTC_PhanBoQuyHocBongInfo);
                            grvDoiTuong.FocusedRowHandle = -1;
                            dtDoiTuong.Rows.Remove(drDoiTuong);
                        }
                        catch
                        {
                            ThongBao("Dữ liệu đang dùng không thể xóa!");
                        }
                    }
                }
                else
                    ThongBao("Bạn phải lưu dữ liệu trước khi xóa!");
            }
        }
    }
}