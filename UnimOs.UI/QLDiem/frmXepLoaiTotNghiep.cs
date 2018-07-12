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
    public partial class frmXepLoaiTotNghiep : frmBase
    {
        private int status;
        private cBKQHT_XepLoaiTotNghiep oBKQHT_XepLoaiTotNghiep;
        private KQHT_XepLoaiTotNghiepInfo pKQHT_XepLoaiTotNghiepInfo;
        private DataTable dtXepLoai;
        private DataRow drXepLoai;

        public frmXepLoaiTotNghiep()
        {
            InitializeComponent();
            pKQHT_XepLoaiTotNghiepInfo = new KQHT_XepLoaiTotNghiepInfo();
            oBKQHT_XepLoaiTotNghiep = new cBKQHT_XepLoaiTotNghiep();
        }

        private void frmXepLoaiTotNghiep_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            bar2.Visible = true;
            GetXepLoai();
        }

        private void GetXepLoai()
        {
            pKQHT_XepLoaiTotNghiepInfo.KQHT_XepLoaiTotNghiepID = 0;
            dtXepLoai = oBKQHT_XepLoaiTotNghiep.Get(pKQHT_XepLoaiTotNghiepInfo);
            grdXepLoai.DataSource = dtXepLoai;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearText();
            panelTop.Visible = true;
            txtMaXepLoai.Focus();
            status = 0;
        }

        private void ClearText()
        {
            txtMaXepLoai.Text = "";
            txtXepLoai.Text = "";
            txtDiem.Text = "";
            txtMaXepLoai.Focus();
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtMaXepLoai.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtMaXepLoai, "Mã xếp loại không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtXepLoai;
            }
            if (txtXepLoai.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtXepLoai, "Tên xếp loại không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtXepLoai;
            }
            if (txtDiem.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtDiem, "Điểm không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtDiem;
            }
            //Kiểm tra cập nhật thành công
            if ((CtrlErr != null))
                return false;
            else
                return true;
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            status = 1;
            panelTop.Visible = true;
            GetInfo();
        }
        private void GetInfo()
        {
            txtXepLoai.Text = pKQHT_XepLoaiTotNghiepInfo.TenXepLoai;
            txtMaXepLoai.Text = pKQHT_XepLoaiTotNghiepInfo.MaXepLoai;
            txtDiem.Text = pKQHT_XepLoaiTotNghiepInfo.TuDiem.ToString();
            chkHaXepLoai.Checked = pKQHT_XepLoaiTotNghiepInfo.HaXepLoaiThiLaiQuaMucPhanTram;
        }

        private void SetInfo()
        {
            pKQHT_XepLoaiTotNghiepInfo.TenXepLoai = txtXepLoai.Text;
            pKQHT_XepLoaiTotNghiepInfo.MaXepLoai = txtMaXepLoai.Text;
            pKQHT_XepLoaiTotNghiepInfo.TuDiem = float.Parse("0" + txtDiem.Text);
            pKQHT_XepLoaiTotNghiepInfo.HaXepLoaiThiLaiQuaMucPhanTram = chkHaXepLoai.Checked;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!Check_Valid()) return;
            try
            {
                SetInfo();
                if (status == 0)
                {
                    oBKQHT_XepLoaiTotNghiep.Add(pKQHT_XepLoaiTotNghiepInfo);
                    ThemThanhCong();
                    drXepLoai = dtXepLoai.NewRow();
                    oBKQHT_XepLoaiTotNghiep.ToDataRow(pKQHT_XepLoaiTotNghiepInfo, ref drXepLoai);
                    dtXepLoai.Rows.Add(drXepLoai);
                }
                else
                {
                    oBKQHT_XepLoaiTotNghiep.Update(pKQHT_XepLoaiTotNghiepInfo);
                    SuaThanhCong();
                    oBKQHT_XepLoaiTotNghiep.ToDataRow(pKQHT_XepLoaiTotNghiepInfo,ref  drXepLoai);
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
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void grvLop_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvXepLoai.FocusedRowHandle >= 0)
            {
                drXepLoai = grvXepLoai.GetDataRow(grvXepLoai.FocusedRowHandle);
                oBKQHT_XepLoaiTotNghiep.ToInfo(ref pKQHT_XepLoaiTotNghiepInfo, drXepLoai);
            }
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    grvLop_FocusedRowChanged(null, null);
                    oBKQHT_XepLoaiTotNghiep.Delete(pKQHT_XepLoaiTotNghiepInfo);
                    XoaThanhCong();
                    GetXepLoai();
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private void grvXepLoai_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
    }
}