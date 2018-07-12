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
    public partial class frmThanhPhanDiem : frmBase
    {
        private cBKQHT_ThanhPhanDiem oBKQHT_ThanhPhanDiem;
        private KQHT_ThanhPhanDiemInfo pKQHT_ThanhPhanDiemInfo;
        private DataTable dtThanhPhan;
        private DataRow drThanhPhan;
        private EDIT_MODE edit;

        public frmThanhPhanDiem()
        {
            InitializeComponent();
            oBKQHT_ThanhPhanDiem = new cBKQHT_ThanhPhanDiem();
            pKQHT_ThanhPhanDiemInfo = new KQHT_ThanhPhanDiemInfo();
            SetBarButton(false);
            panelTop.Visible = false;
        }

        private void frmThanhPhanDiem_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            DataTable dtTrinhDo = LoadTrinhDo();
            cmbTrinhDo.Properties.DataSource = dtTrinhDo;
            if (dtTrinhDo.Rows.Count > 0)
                cmbTrinhDo.EditValue = dtTrinhDo.Rows[0]["DM_TrinhDoID"];
            dtThanhPhan = oBKQHT_ThanhPhanDiem.GetByIDTrinhDo(cmbTrinhDo.EditValue == null ? 0 : int.Parse(cmbTrinhDo.EditValue.ToString()));
            grdThanhPhanDiem.DataSource = dtThanhPhan;
        }

        private void SetBarButton(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
            barbtnSoDiemBatBuoc.Enabled = status;
        }

        private void SetText()
        {
            txtKyHieu.Text = pKQHT_ThanhPhanDiemInfo.KyHieu;
            txtTen.Text = pKQHT_ThanhPhanDiemInfo.TenThanhPhan;
            chkThi.Checked = pKQHT_ThanhPhanDiemInfo.Thi;
            txtSoDiem.EditValue = pKQHT_ThanhPhanDiemInfo.SoDiem;
            if (chkThi.Checked)
                txtSoLanThi.EditValue = pKQHT_ThanhPhanDiemInfo.SoLanThi;
            if (pKQHT_ThanhPhanDiemInfo.STT != null)
                txtSTT.EditValue = pKQHT_ThanhPhanDiemInfo.STT;
        }

        private void ClearText()
        {
            txtKyHieu.Text = "";
            txtTen.Text = "";
            chkThi.Checked = false;
        }

        private bool CheckValid()
        {
            Control CtrlErr = null;
            if ((dxErrorProvider != null)) dxErrorProvider.Dispose();
            //Thông tin không được rỗng
            if (cmbTrinhDo.EditValue == null)
            {
                dxErrorProvider.SetError(cmbTrinhDo, "Bạn phải chọn trình độ đào tạo.");
                if (CtrlErr == null) CtrlErr = cmbTrinhDo;
            }
            if (txtKyHieu.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtKyHieu, "Ký hiệu không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtKyHieu;
            }
            if (txtTen.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTen, "Tên thành phần không thể rỗng.");
                if (CtrlErr == null) CtrlErr = txtTen;
            }
            if (edit == EDIT_MODE.THEM || (txtKyHieu.Text.Trim() != pKQHT_ThanhPhanDiemInfo.KyHieu && edit == EDIT_MODE.SUA))
            {
                //kiểm tra ký hiệu nhập vào có trùng với dữ liệu trước không.
                if (dtThanhPhan.Rows.Count > 0)
                {
                    for (int i = 0; i < dtThanhPhan.Rows.Count; i++)
                    {
                        if (txtKyHieu.Text.Trim() == dtThanhPhan.Rows[i][pKQHT_ThanhPhanDiemInfo.strKyHieu].ToString())
                        {

                            if (CtrlErr == null) CtrlErr = txtKyHieu;
                            txtKyHieu.Text = "";
                            txtKyHieu.Focus();
                            ThongBao("Ký hiệu bạn nhập đã bị trùng!");
                            break;
                        }
                    }
                }
            }
            if (CtrlErr != null)
            {
                CtrlErr.Focus();
                return false;
            }
            else
                return true;
        }

        private void GetpInfo()
        {
            pKQHT_ThanhPhanDiemInfo.IDDM_TrinhDo = int.Parse(cmbTrinhDo.EditValue.ToString());
            pKQHT_ThanhPhanDiemInfo.KyHieu = txtKyHieu.Text.Trim();
            pKQHT_ThanhPhanDiemInfo.TenThanhPhan = txtTen.Text.Trim();
            pKQHT_ThanhPhanDiemInfo.Thi = chkThi.Checked;
            pKQHT_ThanhPhanDiemInfo.SoDiem = int.Parse(txtSoDiem.EditValue.ToString());
            if (chkThi.Checked)
                pKQHT_ThanhPhanDiemInfo.SoLanThi = int.Parse(txtSoLanThi.EditValue.ToString());
            else
                pKQHT_ThanhPhanDiemInfo.SoLanThi = null;

            pKQHT_ThanhPhanDiemInfo.STT = int.Parse(txtSTT.EditValue.ToString());
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;

            GetpInfo();
            if (edit == EDIT_MODE.THEM)
            {
                pKQHT_ThanhPhanDiemInfo.KQHT_ThanhPhanDiemID = oBKQHT_ThanhPhanDiem.Add(pKQHT_ThanhPhanDiemInfo);
                DataRow drNew = dtThanhPhan.NewRow();
                oBKQHT_ThanhPhanDiem.ToDataRow(pKQHT_ThanhPhanDiemInfo, ref drNew);
                dtThanhPhan.Rows.Add(drNew);
                ClearText();
                txtKyHieu.Focus();
            }
            else
            {
                oBKQHT_ThanhPhanDiem.Update(pKQHT_ThanhPhanDiemInfo);
                oBKQHT_ThanhPhanDiem.ToDataRow(pKQHT_ThanhPhanDiemInfo, ref drThanhPhan);
                panelTop.Visible = false;
                grdThanhPhanDiem.Enabled = true;
                SuaThanhCong();
            }
        }

        private void cmbTrinhDo_EditValueChanged(object sender, EventArgs e)
        {
            dtThanhPhan = oBKQHT_ThanhPhanDiem.GetByIDTrinhDo(int.Parse(cmbTrinhDo.EditValue.ToString()));
            grdThanhPhanDiem.DataSource = dtThanhPhan;
        }

        private void chkThi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThi.Checked)
                layoutSoLanThi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            else
                layoutSoLanThi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panelTop.Visible = false;
            grdThanhPhanDiem.Enabled = true;
        }

        private void grvThanhPhanDiem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvThanhPhanDiem.DataRowCount > 0)
            {
                if (grvThanhPhanDiem.FocusedRowHandle >= 0)
                {
                    drThanhPhan = grvThanhPhanDiem.GetDataRow(grvThanhPhanDiem.FocusedRowHandle);
                    oBKQHT_ThanhPhanDiem.ToInfo(ref pKQHT_ThanhPhanDiemInfo, drThanhPhan);
                    SetBarButton(true);
                }
            }
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            edit = EDIT_MODE.THEM;
            grdThanhPhanDiem.Enabled = false;
            panelTop.Visible = true;
            ClearText();
            txtKyHieu.Focus();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            edit = EDIT_MODE.SUA;
            grdThanhPhanDiem.Enabled = false;
            panelTop.Visible = true;
            SetText();
            txtKyHieu.Focus();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn muốn xóa không ?") == DialogResult.Yes)
            {
                try
                {
                    oBKQHT_ThanhPhanDiem.Delete(pKQHT_ThanhPhanDiemInfo);
                    dtThanhPhan.Rows.Remove(drThanhPhan);
                    XoaThanhCong();
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private void barbtnSoDiemBatBuoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThanhPhanDiemBatBuoc frm = new frmThanhPhanDiemBatBuoc(int.Parse(cmbTrinhDo.EditValue.ToString()), pKQHT_ThanhPhanDiemInfo.KQHT_ThanhPhanDiemID);
            frm.ShowDialog();
        }
    }
}