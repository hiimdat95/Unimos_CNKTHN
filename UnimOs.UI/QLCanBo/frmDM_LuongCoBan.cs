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
    public partial class frmDM_LuongCoBan : frmBase
    {
        private cBNS_LuongCoBan oBNS_LuongCoBan;
        private NS_LuongCoBanInfo pNS_LuongCoBanInfo;
        private DataTable dtNS_LuongCoBan;
        private DataRow drNS_LuongCoBan;
        private EDIT_MODE edit;

        public frmDM_LuongCoBan()
        {
            InitializeComponent();
            oBNS_LuongCoBan = new cBNS_LuongCoBan();
            pNS_LuongCoBanInfo = new NS_LuongCoBanInfo();
            SetControl(false);
        }

        private void GetLuongCoBan()
        {
            dtNS_LuongCoBan = oBNS_LuongCoBan.Get_DenNgayInfo();
            grdLuongCoBan.DataSource = dtNS_LuongCoBan;
        }

        private void SetControl(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void ClearText()
        {
            txtLuongCoBan.Text = "";
            dtpTuNgay.EditValue = null;
            dtpDenNgay.Checked = false;
            txtLuongCoBan.Focus();
        }
        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();

            if (txtLuongCoBan.Text == string.Empty)
            {
                dxErrorProvider.SetError(txtLuongCoBan, "Lương cơ bản không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtLuongCoBan;
            }
            else
            {
                if (double.Parse(txtLuongCoBan.Text) <= 0)
                {
                    dxErrorProvider.SetError(txtLuongCoBan, "Lương cơ bản phải lớn hơn 0.");
                    if (CtrlErr == null) CtrlErr = txtLuongCoBan;
                }
            }
            if (dtpTuNgay.EditValue == null)
            {
                dxErrorProvider.SetError(dtpTuNgay, "Từ ngày không thể rỗng.");
                if (CtrlErr == null) CtrlErr = dtpTuNgay;
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
        private void SetText()
        {
            txtLuongCoBan.Text = pNS_LuongCoBanInfo.LuongCoBan.ToString();
            if ("" + drNS_LuongCoBan[pNS_LuongCoBanInfo.strTuNgay] == "" || (DateTime.Parse(drNS_LuongCoBan[pNS_LuongCoBanInfo.strTuNgay].ToString()).ToString("dd/MM/yyyy")) == "01/01/1900")
                dtpTuNgay.EditValue = null;
            else
            {
                dtpTuNgay.EditValue = drNS_LuongCoBan[pNS_LuongCoBanInfo.strTuNgay];
            }
            if ("" + drNS_LuongCoBan[pNS_LuongCoBanInfo.strDenNgay] == "" || (DateTime.Parse(drNS_LuongCoBan[pNS_LuongCoBanInfo.strDenNgay].ToString()).ToString("dd/MM/yyyy")) == "31/12/9999")
            {
                dtpDenNgay.Value = DateTime.Today;
                dtpDenNgay.Checked = false;
            }
            else
            {
                dtpDenNgay.Value = DateTime.Parse(drNS_LuongCoBan[pNS_LuongCoBanInfo.strDenNgay].ToString());
                dtpDenNgay.Checked = true;
            }
            txtLuongCoBan.Focus();
        }

        private void GetpInfo()
        {
            pNS_LuongCoBanInfo.LuongCoBan = double.Parse(txtLuongCoBan.Text);
            if (dtpTuNgay.EditValue == null)
            {
                pNS_LuongCoBanInfo.TuNgay = DateTime.Parse("01/01/1900");
            }
            else
            {
                pNS_LuongCoBanInfo.TuNgay = DateTime.Parse(dtpTuNgay.EditValue.ToString());
            }
            pNS_LuongCoBanInfo.DenNgay = dtpDenNgay.Checked == false ? DateTime.ParseExact("31/12/9999", "dd/MM/yyyy", null) : dtpDenNgay.Value;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdLuongCoBan.Enabled = false;
            edit = EDIT_MODE.THEM;
            panelTop.Visible = true;
            ClearText();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdLuongCoBan.Enabled = false;
            edit = EDIT_MODE.SUA;
            panelTop.Visible = true;
            SetText();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn xóa?") == DialogResult.Yes)
            {
                try
                {
                    pNS_LuongCoBanInfo.NS_LuongCoBanID = int.Parse(drNS_LuongCoBan[pNS_LuongCoBanInfo.strNS_LuongCoBanID].ToString());
                    oBNS_LuongCoBan.Delete(pNS_LuongCoBanInfo);
                    // ghi log
                    GhiLog("Xóa lương cơ bản '" + pNS_LuongCoBanInfo.LuongCoBan + "' nghìn đồng khỏi CSDL ", "Xóa", this.Tag.ToString());
                    dtNS_LuongCoBan.Rows.Remove(drNS_LuongCoBan);
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
            if (!CheckValid()) return;
            try
            {
                GetpInfo();
                if (edit == EDIT_MODE.THEM)
                {
                    DataRow[] arrDr = dtNS_LuongCoBan.Select("TuNgay <= '" + pNS_LuongCoBanInfo.TuNgay.ToString("MM/dd/yyyy") + "' AND DenNgay>='" + pNS_LuongCoBanInfo.DenNgay.ToString("MM/dd/yyyy") + "'");
                    if (arrDr.Length > 0)
                    {
                        ThongBaoLoi("Đã có lương cơ bản chưa cập nhật thông tin đến ngày.\nHoặc từ ngày của lương cơ bản này nằm trong khoảng từ ngày và đến ngày của lương cơ bản thêm vào trước đó.\n Đề nghị kiểm tra và cập nhật lại thông tin lương cơ bản.");
                        return;
                    }
                    pNS_LuongCoBanInfo.NS_LuongCoBanID = oBNS_LuongCoBan.Add(pNS_LuongCoBanInfo);
                    GhiLog("Thêm lương cơ bản '" + pNS_LuongCoBanInfo.LuongCoBan + "' nghìn đồng vào CSDL ", "Thêm", this.Tag.ToString());
                    DataRow drNew = dtNS_LuongCoBan.NewRow();
                    oBNS_LuongCoBan.ToDataRow(pNS_LuongCoBanInfo, ref drNew);
                    dtNS_LuongCoBan.Rows.Add(drNew);
                    ClearText();
                }
                else
                {
                    DataRow[] arrDr = dtNS_LuongCoBan.Select("NS_LuongCoBanID <> " + drNS_LuongCoBan[pNS_LuongCoBanInfo.strNS_LuongCoBanID].ToString() + " AND TuNgay <= '" + pNS_LuongCoBanInfo.TuNgay.ToString("MM/dd/yyyy") + "' AND DenNgay>='" + pNS_LuongCoBanInfo.DenNgay.ToString("MM/dd/yyyy") + "'");
                    if (arrDr.Length > 0)
                    {
                        ThongBaoLoi("Đã có lương cơ bản chưa cập nhật thông tin đến ngày.\nHoặc từ ngày của lương cơ bản này nằm trong khoảng từ ngày và đến ngày của lương cơ bản thêm vào trước đó.\n Đề nghị kiểm tra và cập nhật lại thông tin lương cơ bản.");
                        return;
                    }
                    pNS_LuongCoBanInfo.NS_LuongCoBanID = int.Parse(drNS_LuongCoBan[pNS_LuongCoBanInfo.strNS_LuongCoBanID].ToString());
                    oBNS_LuongCoBan.Update(pNS_LuongCoBanInfo);
                    GhiLog("Sửa lương cơ bản '" + pNS_LuongCoBanInfo.LuongCoBan + "' nghìn đồng trong CSDL ", "Sửa", this.Tag.ToString());
                    oBNS_LuongCoBan.ToDataRow(pNS_LuongCoBanInfo, ref drNS_LuongCoBan);
                    SuaThanhCong();
                    btnHuy_Click(null, null);
                }
                GetLuongCoBan();
            }
            catch
            {
                ThongBaoLoi("Có lỗi trong quá trình thêm hoặc sửa hoặc ghi log.");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            grdLuongCoBan.Enabled = true;
            dxErrorProvider.ClearErrors();
            panelTop.Visible = false;
        }

        private void grvLuongCoBan_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvLuongCoBan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvLuongCoBan.FocusedRowHandle >= 0)
            {
                drNS_LuongCoBan = grvLuongCoBan.GetDataRow(grvLuongCoBan.FocusedRowHandle);
                oBNS_LuongCoBan.ToInfo(ref pNS_LuongCoBanInfo, drNS_LuongCoBan);
            }
            if (grvLuongCoBan != null)
                if (grvLuongCoBan.DataRowCount > 0 && grvLuongCoBan.FocusedRowHandle >= 0)
                {
                    SetControl(true);
                    drNS_LuongCoBan = grvLuongCoBan.GetDataRow(grvLuongCoBan.FocusedRowHandle);
                    return;
                }
            SetControl(false);
            drNS_LuongCoBan = null;
        }

        private void frmDM_LuongCoBan_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            GetLuongCoBan();
        }
    }
}