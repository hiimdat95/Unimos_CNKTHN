using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;
using DevExpress.XtraEditors;

namespace UnimOs.UI
{
    public partial class frmHeDaoTao : frmBase
    {
        private cBDM_He oBHe;
        private DM_HeInfo pDM_HeInfo;
        List<DM_HeInfo> lstHe;
        int status = 0;
        private int Index;
        private string Ma;

        public frmHeDaoTao()
        {
            InitializeComponent();
            oBHe = new cBDM_He();
            pDM_HeInfo = new DM_HeInfo();
            lstHe = new List<DM_HeInfo>();
            lstHe = oBHe.GetList(pDM_HeInfo);
        }
        private void frmHeDaoTao_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
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
            grdHeDaoTao.DataSource = oBHe.Get(pDM_HeInfo);
            if (grvHeDaoTao.RowCount > 0)
            {
                SetControl(true);
            }
            else
            {
                SetControl(false);
            }
        }

        private void SetControl(bool val)
        {
            barbtnSua.Enabled = val;
            barbtnXoa.Enabled = val;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMaHe.Focus();
            panelTop.Visible = true;
            status = 0;
        }

        private void grvHeDaoTao_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                SetControl(true);
                Index = grvHeDaoTao.FocusedRowHandle;
                pDM_HeInfo.DM_HeID = (int)grvHeDaoTao.GetDataRow(Index)["DM_HeID"];
                pDM_HeInfo.MaHe = grvHeDaoTao.GetDataRow(Index)["MaHe"].ToString();
                pDM_HeInfo.TenHe = grvHeDaoTao.GetDataRow(Index)["TenHe"].ToString();
                pDM_HeInfo.TenHe_E = grvHeDaoTao.GetDataRow(Index)["TenHe_E"].ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            status = 1;
            panelTop.Visible = true;
            txtMaHe.Text = pDM_HeInfo.MaHe;
            txtTenHe.Text = pDM_HeInfo.TenHe;
            txtTenHeE.Text = pDM_HeInfo.TenHe_E; 
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            Ma = pDM_HeInfo.MaHe;
            if (!Check_Valid()) return;
            try
            {
                if (status == 0)
                {
                   oBHe.Add(GetpHe());
                    // ghi log
                    GhiLog("Thêm hệ đào tạo '" + pDM_HeInfo.TenHe + "'", "Thêm", this.Tag.ToString());
                    ThemThanhCong();
                }
                else
                {
                    if(status == 1 || txtMaHe.Text == Ma)
                    {
                        oBHe.Update(GetpHe());
                        panelTop.Visible = false;
                        // ghi log
                        GhiLog("Sửa hệ đào tạo '" + pDM_HeInfo.TenHe + "'", "Sửa", this.Tag.ToString());
                        SuaThanhCong();
                    } 
               }
                pDM_HeInfo.DM_HeID = 0;
                GetData();
                lstHe = oBHe.GetList(pDM_HeInfo);
                ClearText();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private DM_HeInfo GetpHe()
        {
            pDM_HeInfo.MaHe = txtMaHe.Text.Trim();
            pDM_HeInfo.TenHe = txtTenHe.Text.Trim();
            pDM_HeInfo.TenHe_E = txtTenHeE.Text.Trim();
            return pDM_HeInfo;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DxErrorProvider.ClearErrors();           
            panelTop.Visible = false;
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    oBHe.Delete(pDM_HeInfo);
                    pDM_HeInfo.DM_HeID = 0;
                    GetData();
                    lstHe = oBHe.GetList(pDM_HeInfo);
                    // ghi log
                    GhiLog("Xóa hệ đào tạo '" + pDM_HeInfo.TenHe + "'", "Xóa", this.Tag.ToString());
                    XoaThanhCong();
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }
        private void ClearText()
        {
            txtMaHe.Text = "";
            txtTenHe.Text = "";
            txtTenHeE.Text = "";
        }
        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((DxErrorProvider != null)) DxErrorProvider.Dispose();
            //Mã và tên hệ không được rỗng
            if (txtMaHe.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtMaHe, "Mã hệ đào tạo không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMaHe;
            }
            if (txtTenHe.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtTenHe, "Tên hệ đào tạo không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenHe;
            }
            if (status == 1 && txtMaHe.Text.Trim() == Ma)
            {
                return status == 1;
            }
            else
            {
                //Kiểm tra mã môn    
                if (lstHe != null)
                {
                    for (int i = 0; i < lstHe.Count; i++)
                    {
                        if (txtMaHe.Text == lstHe[i].MaHe)
                        {
                            DxErrorProvider.SetError(txtMaHe, "Mã hệ bị trùng.");
                            if (CtrlErr == null) CtrlErr = txtMaHe;
                            txtMaHe.Text = "";
                            ThongBao("Mã bạn nhập đã bị trùng!");
                            break;
                        }
                    }
                }
            }
                //Kiểm tra cập nhật thành công
            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            else
                return true;
        }
        
    }
}
