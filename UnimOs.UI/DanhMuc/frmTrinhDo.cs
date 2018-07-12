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
    public partial class frmTrinhDo : frmBase
    {        
        private cBDM_TrinhDo oBTrinhDo;
        private DM_TrinhDoInfo pTrinhDoInfo;
        List<DM_TrinhDoInfo> LstTrinhDo;
        int status = 0;
        int index;
        private string Ma;
        public frmTrinhDo()
        {
            InitializeComponent();
            oBTrinhDo = new cBDM_TrinhDo();
            pTrinhDoInfo = new DM_TrinhDoInfo();
            LstTrinhDo = new List<DM_TrinhDoInfo>();
            LstTrinhDo = oBTrinhDo.GetList(pTrinhDoInfo);
        }
        private void frmTrinhDo_Load(object sender, EventArgs e)
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

        private void SetControl(bool val)
        {
            barbtnSua.Enabled = val;
            barbtnXoa.Enabled = val;
        }

        private void GetData()
        {
            grdTrinhDo.DataSource = oBTrinhDo.Get(pTrinhDoInfo);
            cmbQuyChe.Properties.DataSource = LoadQuyChe();
            GetHe();
            if (grvTrinhDo.RowCount > 0)
            {
                SetControl(true);
            }
            else
            {
                SetControl(false);
            }
        }

        private void GetHe()
        {
            cBDM_He oBHe = new cBDM_He();
            DM_HeInfo pHeInfo = new DM_HeInfo();
            pHeInfo.DM_HeID = 0;
            DataTable dt = oBHe.Get(pHeInfo);
            cmbIDTrinhDo.Properties.DataSource = dt;
            cmbIDTrinhDo.Properties.DisplayMember = "TenHe";
            cmbIDTrinhDo.Properties.ValueMember = "DM_HeID";
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelTop.Visible = true;
            status = 0;
            ClearText();
        }

        private void ClearText()
        {
            cmbIDTrinhDo.EditValue = -1;
            cmbQuyChe.EditValue = -1;
            txtMaTrinhDo.Text = "";
            txtTenTrinhDo.Text = "";
            txtTenTrinhDo_E.Text = "";
        }

        private void grvHeDaoTao_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (grvTrinhDo.DataRowCount > 0)
                {
                    SetControl(true);
                    index = grvTrinhDo.FocusedRowHandle;
                    pTrinhDoInfo.DM_TrinhDoID = (int)grvTrinhDo.GetDataRow(index)["DM_TrinhDoID"];
                    pTrinhDoInfo.IDDM_He = (int)grvTrinhDo.GetDataRow(index)["IDDM_He"];
                    pTrinhDoInfo.MaTrinhDo = grvTrinhDo.GetDataRow(index)["MaTrinhDo"].ToString();
                    pTrinhDoInfo.TenTrinhDo = grvTrinhDo.GetDataRow(index)["TenTrinhDo"].ToString();
                    pTrinhDoInfo.IDKQHT_QuyChe = (int)grvTrinhDo.GetDataRow(index)["IDKQHT_QuyChe"];
                }
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
            cmbIDTrinhDo.EditValue = pTrinhDoInfo.IDDM_He;
            cmbQuyChe.EditValue = pTrinhDoInfo.IDKQHT_QuyChe;
            txtMaTrinhDo.Text = pTrinhDoInfo.MaTrinhDo;
            txtTenTrinhDo.Text = pTrinhDoInfo.TenTrinhDo;
            txtTenTrinhDo_E.Text = pTrinhDoInfo.TenTrinhDo_E;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                Ma = pTrinhDoInfo.MaTrinhDo;
                if (!Check_Valid()) return;
                if (status == 0)
                {
                    oBTrinhDo.Add(GetpTrinhDo());
                    // ghi log
                    GhiLog("Thêm trình độ '" + pTrinhDoInfo.TenTrinhDo + "'", "Thêm", this.Tag.ToString());
                    ThemThanhCong();
                }
                else
                {
                    if (status == 1 || txtMaTrinhDo.Text == Ma)
                    {
                        oBTrinhDo.Update(GetpTrinhDo());
                        // ghi log
                        GhiLog("Sửa trình độ '" + pTrinhDoInfo.TenTrinhDo + "'", "Sửa", this.Tag.ToString());
                        SuaThanhCong();
                    }
                }
                pTrinhDoInfo.DM_TrinhDoID = 0;
                GetData();
                LstTrinhDo = oBTrinhDo.GetList(pTrinhDoInfo);
                ClearText();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    if (pTrinhDoInfo.DM_TrinhDoID > 0)
                    {
                        oBTrinhDo.Delete(pTrinhDoInfo);
                        pTrinhDoInfo.DM_TrinhDoID = 0;
                        GetData();
                        LstTrinhDo = oBTrinhDo.GetList(pTrinhDoInfo);
                        // ghi log
                        GhiLog("Xóa trình độ '" + pTrinhDoInfo.TenTrinhDo + "'", "Xóa", this.Tag.ToString());
                        XoaThanhCong();
                    }
                    else
                        CanhBao("Bạn chưa chọn trình độ nào!");
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private DM_TrinhDoInfo GetpTrinhDo()
        {
            pTrinhDoInfo.IDDM_He = int.Parse(cmbIDTrinhDo.EditValue.ToString());
            pTrinhDoInfo.IDKQHT_QuyChe = int.Parse(cmbQuyChe.EditValue.ToString());
            pTrinhDoInfo.MaTrinhDo = txtMaTrinhDo.Text.Trim();
            pTrinhDoInfo.TenTrinhDo = txtTenTrinhDo.Text.Trim();
            pTrinhDoInfo.TenTrinhDo_E = txtTenTrinhDo_E.Text.Trim();
            return pTrinhDoInfo;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panelTop.Visible = false;
            ClearText();
            DxErrorProvider.ClearErrors();
        }

        private bool Check_Valid()
        {
            Control CtrlErr = null;
            if ((DxErrorProvider != null)) DxErrorProvider.Dispose();
            //Hệ trình độ đào tạo không được rỗng
            if (cmbIDTrinhDo.ItemIndex == -1)
            {
                DxErrorProvider.SetError(cmbIDTrinhDo, "Hệ trình độ đào tạo là trường bắt buộc phải chọn.");
                if (CtrlErr == null) CtrlErr = cmbIDTrinhDo;
            }
            // Quy chế đào tạo bắt buộc phải chọn
            if (cmbQuyChe.ItemIndex == -1)
            {
                DxErrorProvider.SetError(cmbQuyChe, "Bạn phải chọn một quy chế đào tạo cho trình độ này.");
                if (CtrlErr == null) CtrlErr = cmbQuyChe;
            }
            //Mã trình độ đào tạo không được rỗng
            if (txtMaTrinhDo.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtMaTrinhDo, "Mã trình độ đào tạo không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtMaTrinhDo;
            }
            if (txtTenTrinhDo.Text == string.Empty)
            {
                DxErrorProvider.SetError(txtTenTrinhDo, "Tên trình độ đào tạo không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTenTrinhDo;
            }
            if (status == 1 && txtMaTrinhDo.Text.Trim() == Ma)
            {
                return status == 1;
            }
            else
            {
                //kiểm tra mã nhập vào có trùng với dữ liệu trước không.
                if (LstTrinhDo != null)
                {
                    for (int i = 0; i < LstTrinhDo.Count; i++)
                    {
                        if (txtMaTrinhDo.Text.Trim() == LstTrinhDo[i].MaTrinhDo)
                        {
                            DxErrorProvider.SetError(txtMaTrinhDo, "Mã trình độ bị trùng.");
                            if (CtrlErr == null) CtrlErr = txtMaTrinhDo;
                            txtMaTrinhDo.Text = "";
                            break;
                        }
                    }
                }
            }
            //Kiểm tra thông tin thành công
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
