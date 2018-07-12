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
    public partial class frmThongTinTruong : frmBase
    {
        cBHT_ThongTinTruong oBHT_ThongTinTruong;
        HT_ThongTinTruongInfo pHT_ThongTinTruongInfo;
        DataTable dtThongTinTruong;
        string Ma;
        bool mStatus = false;

        public frmThongTinTruong()
        {
            InitializeComponent();
            oBHT_ThongTinTruong = new cBHT_ThongTinTruong();
            pHT_ThongTinTruongInfo = new HT_ThongTinTruongInfo();
            pnThongTin.Visible = false;
        }

        private void frmThongTinTruong_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetData();
        }
        private void GetData()
        {
            pHT_ThongTinTruongInfo.HT_ThongTinTruongID = 0;
            dtThongTinTruong = oBHT_ThongTinTruong.Get(pHT_ThongTinTruongInfo);
            if (dtThongTinTruong != null && dtThongTinTruong.Rows.Count > 0)
            {
                grdThongTinTruong.DataSource = dtThongTinTruong;
                dtThongTinTruong.AcceptChanges();
                SetControl(true);
            }
            else
            {
                grdThongTinTruong.DataSource = null;
                SetControl(false);
            }
            
        }
       
        private void SetControl(bool val)
        {
            barSua.Enabled = val;
            barXoa.Enabled = val;
        }

        private void grvThongTinTruong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                SetControl(true);
                oBHT_ThongTinTruong.ToInfo(ref pHT_ThongTinTruongInfo, grvThongTinTruong.GetDataRow(grvThongTinTruong.FocusedRowHandle));
            }
            catch (Exception exp)
            {
                XtraMessageBox.Show(exp.Message);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            Ma = pHT_ThongTinTruongInfo.MaThongTin;
            if (!Check_Valid()) return;
            if (mStatus == false)
            {
                // them
                oBHT_ThongTinTruong.Add(GetThongTinTruong());
                pHT_ThongTinTruongInfo.HT_ThongTinTruongID = 0;
                ThemThanhCong();
            }
            else
            {
                // sua
                oBHT_ThongTinTruong.Update(GetThongTinTruong());
                SuaThanhCong();
            }
            btnHuy_Click(null, null);
            GetData();
        }

        private void barThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnThongTin.Visible = true;
            mStatus = false;
            grdThongTinTruong.Enabled = false;
            ClearText();
        }

        private void barSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnThongTin.Visible = true;
            mStatus = true;
            txtMa.Text = pHT_ThongTinTruongInfo.MaThongTin;
            txtTen.Text = pHT_ThongTinTruongInfo.TenThongTin;
            txtGiaTri.Text = pHT_ThongTinTruongInfo.GiaTri;
            grdThongTinTruong.Enabled = false;
            txtTen.Focus();
        }

        private void barXoa_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grvThongTinTruong.FocusedRowHandle = -1;
            DataTable dtTemp = dtThongTinTruong.GetChanges();
            if (dtTemp != null)
            {
                if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataRow dr in dtTemp.Rows)
                        {

                            if ((bool)(dr["Chon"]))
                            {
                                pHT_ThongTinTruongInfo.HT_ThongTinTruongID = int.Parse(dr["HT_ThongTinTruongID"].ToString());
                                oBHT_ThongTinTruong.Delete(pHT_ThongTinTruongInfo);
                            }
                        }
                        pHT_ThongTinTruongInfo.HT_ThongTinTruongID = 0;
                        GetData();
                        XoaThanhCong();

                    }
                    catch
                    {
                        XoaThatBai();
                    }
                }
            }
            else
                ThongBao("Bạn chưa chọn thông tin trường nào!");
        }
      
        private HT_ThongTinTruongInfo GetThongTinTruong()
        {
            pHT_ThongTinTruongInfo.MaThongTin = txtMa.Text.Trim();
            pHT_ThongTinTruongInfo.TenThongTin = txtTen.Text.Trim();
            pHT_ThongTinTruongInfo.GiaTri= txtGiaTri.Text.Trim();
            return pHT_ThongTinTruongInfo;
        }

        private void ClearText()
        {
            txtGiaTri.Text = "";
            txtMa.Text = "";
            txtTen.Text = "";
            txtMa.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            grdThongTinTruong.Enabled = true;
            pnThongTin.Visible = false;
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtMa.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtMa, "Mã thông tin trường không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMa;
            }
            if (txtTen.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTen, "Tên thông tin trường không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTen;
            }
            if (txtGiaTri.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtGiaTri, "Giá trị thông tin trường không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtGiaTri;
            }
            if (mStatus == true && Ma.Trim() == txtMa.Text.Trim())
            {
                mStatus = true;
            }
            else
            {
                // kiem tra trung ma thong tin truong
                for (int i = 0; i < grvThongTinTruong.DataRowCount; i++)
                {
                    if (txtMa.Text.Trim() == grvThongTinTruong.GetDataRow(i)["MaThongTin"].ToString())
                    {
                        CtrlErr = txtMa;
                        dxErrorProvider.SetError(txtMa, "Mã thông tin trường bạn nhập đã bị trùng.");
                        ThongBao("Mã thông tin trường bạn nhập đã bị trùng");
                        break;
                    }
                }
            }
            // Kiểm tra thông tin thành công
            if ((CtrlErr != null))
            {
                CtrlErr.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void grvThongTinTruong_DoubleClick(object sender, EventArgs e)
        {
            if (grvThongTinTruong.FocusedRowHandle >= 0)
                barSua_ItemClick(null, null);
        }
    }
}