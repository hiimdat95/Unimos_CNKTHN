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
    public partial class frmQuyChe : frmBase
    {
        private cBKQHT_QuyChe oBKQHT_QuyChe;
        private KQHT_QuyCheInfo pKQHT_QuyCheInfo;
        List<KQHT_QuyCheInfo> lstQuyChe;
        private DataTable dtThamSo;
        int status = 0;
        private int index;
        private string Ma;

        public frmQuyChe()
        {
            InitializeComponent();
            pKQHT_QuyCheInfo = new KQHT_QuyCheInfo();
            oBKQHT_QuyChe = new cBKQHT_QuyChe();
            lstQuyChe = new List<KQHT_QuyCheInfo>();
            lstQuyChe = oBKQHT_QuyChe.GetList(pKQHT_QuyCheInfo);
        }

        private void frmQuyChe_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            bar2.Visible = true;
            try
            {

                SetControl(false);
                GetData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void GetData()
        {
            grdQuyChe.DataSource = oBKQHT_QuyChe.Get(pKQHT_QuyCheInfo);
            if (grvQuyChe.RowCount > 0)
            {
                SetControl(true);
            }
            else
            {
                SetControl(false);
            }
        }
        private void GetQuyChe_ThamSo(int mKQHT_QuyCheID)
        {
            dtThamSo = oBKQHT_QuyChe.GetThamSo(mKQHT_QuyCheID);
            if (dtThamSo != null)
            {
                grdThamSo.DataSource = dtThamSo;
            }
        }

        private void SetControl(bool val)
        {
            barbtnSuaQC.Enabled = val;
            barbtnXoaQC.Enabled = val;
        }

        private void barbtnThemQC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMa.Focus();
            panelTop.Visible = true;
            status = 0;
        }

        private void barbtnSuaQC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            status = 1;
            panelTop.Visible = true;
            txtMa.Text = pKQHT_QuyCheInfo.MaQuyChe;
            txtTenQuyChe.Text = pKQHT_QuyCheInfo.TenQuyChe;
        }

        private void barbtnXoaQC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    oBKQHT_QuyChe.Delete(pKQHT_QuyCheInfo);
                    pKQHT_QuyCheInfo.KQHT_QuyCheID = 0;
                    GetData();
                    lstQuyChe = oBKQHT_QuyChe.GetList(pKQHT_QuyCheInfo);
                    // ghi log
                    GhiLog("Xóa quy chế '" + pKQHT_QuyCheInfo.TenQuyChe + "'", "Xóa", this.Tag.ToString());
                    XoaThanhCong();
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }
        private void barbtnThamSo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvQuyChe.FocusedRowHandle >= 0)
            {
                dlgThamSo dlg = new dlgThamSo(int.Parse(grvQuyChe.GetDataRow(grvQuyChe.FocusedRowHandle)["KQHT_QuyCheID"].ToString()));
                dlg.ShowDialog();
                if (dlg.Tag.ToString() == "1")
                {
                    GetQuyChe_ThamSo(int.Parse(grvQuyChe.GetDataRow(grvQuyChe.FocusedRowHandle)["KQHT_QuyCheID"].ToString()));
                }
            }
        }
        // xu ly chuot phải
        private void pnThemQuyChe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnThemQC_ItemClick(null, null);
        }

        private void pnSuaQuyChe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnSuaQC_ItemClick(null, null);
        }

        private void pnXoaQuyChe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             barbtnXoaQC_ItemClick(null, null);
        }
        
        private void pnThamSo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvQuyChe.FocusedRowHandle >= 0)
            {
                dlgThamSo dlg = new dlgThamSo(int.Parse(grvQuyChe.GetDataRow(grvQuyChe.FocusedRowHandle)["KQHT_QuyCheID"].ToString()));
                dlg.ShowDialog();
                if (dlg.Tag.ToString() == "1")
                {
                    GetQuyChe_ThamSo(int.Parse(grvQuyChe.GetDataRow(grvQuyChe.FocusedRowHandle)["KQHT_QuyCheID"].ToString()));
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            Ma = pKQHT_QuyCheInfo.MaQuyChe;
            if (!Check_Valid()) return;
            try
            {
                if (status == 0)
                {
                   oBKQHT_QuyChe.Add(GetpQuyChe());                 
                    ThemThanhCong();                   
                    // ghi log
                    GhiLog("Thêm quy chế '" + pKQHT_QuyCheInfo.TenQuyChe + "'", "Thêm", this.Tag.ToString());
                   
                }
                else
                {
                    if (status == 1 || txtMa.Text == Ma)
                    {
                        oBKQHT_QuyChe.Update(GetpQuyChe());                       
                        SuaThanhCong();
                        panelTop.Visible = false;                       
                        // ghi log
                        GhiLog("Sửa thông tin quy chế '" + pKQHT_QuyCheInfo.TenQuyChe + "'", "Sửa", this.Tag.ToString());
                        
                    }
                }
                pKQHT_QuyCheInfo.KQHT_QuyCheID = 0;
                GetData();
                lstQuyChe = oBKQHT_QuyChe.GetList(pKQHT_QuyCheInfo);
                ClearText();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private KQHT_QuyCheInfo GetpQuyChe()
        {
            pKQHT_QuyCheInfo.MaQuyChe = txtMa.Text.Trim();
            pKQHT_QuyCheInfo.TenQuyChe= txtTenQuyChe.Text.Trim();
            return pKQHT_QuyCheInfo;
        }
        private void ClearText()
        {
            txtMa.Focus();
            txtMa.Text = "";
            txtTenQuyChe.Text = "";
        }
        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((DxErrorProvider != null)) DxErrorProvider.Dispose();
            //Mã và tên hệ không được rỗng
            if (txtMa.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtMa, "Mã quy chế không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMa;
            }
            if (txtTenQuyChe.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtTenQuyChe, "Tên quy chế không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenQuyChe;
            }
            if (status == 1 && txtMa.Text.Trim() == Ma)
            {
                return status == 1;
            }
            else
            {
                //Kiểm tra mã môn    
                if (lstQuyChe != null)
                {
                    for (int i = 0; i < lstQuyChe.Count; i++)
                    {
                        if (txtMa.Text == lstQuyChe[i].MaQuyChe)
                        {
                            DxErrorProvider.SetError(txtMa, "Mã quy chế bị trùng.");
                            if (CtrlErr == null) CtrlErr = txtMa;
                            txtMa.Text = "";
                            ThongBao("Mã bạn nhập đã bị trùng!");
                            break;
                        }
                    }
                }
            }
            //Kiểm tra cập nhật thành công
            if ((CtrlErr != null))
                return false;
            else
                return true;
        }

        private void grvQuyChe_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                SetControl(true);
                index = grvQuyChe.FocusedRowHandle;
                pKQHT_QuyCheInfo.KQHT_QuyCheID = (int)grvQuyChe.GetDataRow(index)["KQHT_QuyCheID"];
                pKQHT_QuyCheInfo.MaQuyChe = grvQuyChe.GetDataRow(index)["MaQuyChe"].ToString();
                pKQHT_QuyCheInfo.TenQuyChe = grvQuyChe.GetDataRow(index)["TenQuyChe"].ToString();
                GetQuyChe_ThamSo(pKQHT_QuyCheInfo.KQHT_QuyCheID);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void grvQuyChe_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None && grdQuyChe.ClientRectangle.Contains(e.X, e.Y))
            {
                popupMenu1.ShowPopup(MousePosition);
            }
        }

     
        
    }
}