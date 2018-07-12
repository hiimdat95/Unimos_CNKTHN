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
    public partial class frmThamSoQuyChe : frmBase
    {
        private cBKQHT_ThamSoQuyChe oBKQHT_ThamSoQuyChe;
        private KQHT_ThamSoQuyCheInfo pKQHT_ThamSoQuyCheInfo;
        string Ma;
        bool mStatus = false;
        private DataTable dtThamSo;

        public frmThamSoQuyChe()
        {
            InitializeComponent();
            pKQHT_ThamSoQuyCheInfo = new KQHT_ThamSoQuyCheInfo();
            oBKQHT_ThamSoQuyChe = new cBKQHT_ThamSoQuyChe();
        }

        private void frmThamSoQuyChe_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetData();
        }
        private void GetData()
        {
            pKQHT_ThamSoQuyCheInfo.KQHT_ThamSoQuyCheID = 0;
            dtThamSo = oBKQHT_ThamSoQuyChe.Get(pKQHT_ThamSoQuyCheInfo);
            if (dtThamSo != null && dtThamSo.Rows.Count > 0)
            {
                grdThamSo.DataSource = dtThamSo;
                grvThamSo_FocusedRowChanged(null, null);
                dtThamSo.AcceptChanges();
                SetControl(true);
            }
            else
            {
                grdThamSo.DataSource = null;
                SetControl(false);
            }

        }
        private void SetControl(bool val)
        {
            barbtnSua.Enabled = val;
            barbtnXoa.Enabled = val;
        }
        private void grvThamSo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                SetControl(true);
                oBKQHT_ThamSoQuyChe.ToInfo(ref pKQHT_ThamSoQuyCheInfo, grvThamSo.GetDataRow(grvThamSo.FocusedRowHandle));
            }
            catch (Exception exp)
            {
                XtraMessageBox.Show(exp.Message);
            }
        }
        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ((dtThamSo != null) && (dtThamSo.Rows.Count >0))
            {
                if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
                {
                    try
                    {
                        oBKQHT_ThamSoQuyChe.Delete(pKQHT_ThamSoQuyCheInfo);
                        pKQHT_ThamSoQuyCheInfo.KQHT_ThamSoQuyCheID = 0;
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
                ThongBao("Bạn chưa chọn tham số nào!");
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelTop.Visible = true;
            mStatus = false;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelTop.Visible = true;
            mStatus = true;
            txtMa.Text = pKQHT_ThamSoQuyCheInfo.MaThamSo;
            txtTenQuyChe.Text = pKQHT_ThamSoQuyCheInfo.TenThamSo;
            txtKieuTruong.Text = pKQHT_ThamSoQuyCheInfo.KieuTruong;
            txtGiaTriMacDinh.Text = pKQHT_ThamSoQuyCheInfo.GiaTriMacDinh;
        }
        private void ClearText()
        {
            txtMa.Text = "";
            txtTenQuyChe.Text = "";
            txtKieuTruong.Text = "";
            txtGiaTriMacDinh.Text = "";
            txtMa.Focus();
        }
        private KQHT_ThamSoQuyCheInfo GetThamSo()
        {
            pKQHT_ThamSoQuyCheInfo.MaThamSo = txtMa.Text.Trim();
            pKQHT_ThamSoQuyCheInfo.TenThamSo = txtTenQuyChe.Text.Trim();
            pKQHT_ThamSoQuyCheInfo.KieuTruong = txtKieuTruong.Text.Trim();
            pKQHT_ThamSoQuyCheInfo.GiaTriMacDinh = txtGiaTriMacDinh.Text.Trim();
            return pKQHT_ThamSoQuyCheInfo;
        }
        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (txtMa.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtMa, "Mã tham số không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMa;
            }
            if (txtTenQuyChe.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenQuyChe, "Tên quy chế không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenQuyChe;
            }           
            if (mStatus == true && Ma.Trim() == txtMa.Text.Trim())
            {
                mStatus = true;
            }
            else
            {
                // kiem tra trung ma tham so
                for (int i = 0; i < grvThamSo.DataRowCount; i++)
                {
                    if (txtMa.Text.Trim() == grvThamSo.GetDataRow(i)["MaThamSo"].ToString())
                    {
                        CtrlErr = txtMa;
                        dxErrorProvider.SetError(txtMa, "Mã tham số bạn nhập đã bị trùng.");
                        ThongBao("Mã tham số bạn nhập đã bị trùng");
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            Ma = pKQHT_ThamSoQuyCheInfo.MaThamSo;
            if (!Check_Valid()) return;
            if (mStatus == false)
            {
                // them
                oBKQHT_ThamSoQuyChe.Add(GetThamSo());
                pKQHT_ThamSoQuyCheInfo.KQHT_ThamSoQuyCheID = 0;
                ThemThanhCong();
                ClearText();
                GetData();

            }
            else
            {
                // sua
                oBKQHT_ThamSoQuyChe.Update(GetThamSo());
                SuaThanhCong();
                GetData();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panelTop.Visible = false;
        }

        
    }
}