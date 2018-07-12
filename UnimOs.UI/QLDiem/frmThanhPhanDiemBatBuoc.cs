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
    public partial class frmThanhPhanDiemBatBuoc : frmBase
    {
        private cBKQHT_ThanhPhanDiemBatBuoc oBKQHT_ThanhPhanDiemBatBuoc;
        private KQHT_ThanhPhanDiemBatBuocInfo pKQHT_ThanhPhanDiemBatBuocInfo;
        private int IDDM_TrinhDo, IDKQHT_ThanhPhanDiem;
        private DataTable dtSoDiemBatBuoc;
        private DataRow drSoDiemBatBuoc;
        private EDIT_MODE edit;

        public frmThanhPhanDiemBatBuoc(int _IDDM_TrinhDo, int _IDKQHT_ThanhPhanDiem)
        {
            InitializeComponent();
            oBKQHT_ThanhPhanDiemBatBuoc = new cBKQHT_ThanhPhanDiemBatBuoc();
            pKQHT_ThanhPhanDiemBatBuocInfo = new KQHT_ThanhPhanDiemBatBuocInfo();
            IDDM_TrinhDo = _IDDM_TrinhDo;
            IDKQHT_ThanhPhanDiem = _IDKQHT_ThanhPhanDiem;
            this.panelTop.Visible = false;
        }

        private void frmThanhPhanDiemBatBuoc_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            cmbThanhPhanDiem.Properties.DataSource = (new cBKQHT_ThanhPhanDiem()).GetByIDTrinhDo(IDDM_TrinhDo);
            cmbThanhPhanDiem.EditValue = IDKQHT_ThanhPhanDiem;
        }

        private void cmbThanhPhanDiem_EditValueChanged(object sender, EventArgs e)
        {
            IDKQHT_ThanhPhanDiem = (cmbThanhPhanDiem.EditValue == null ? 0 : int.Parse(cmbThanhPhanDiem.EditValue.ToString()));
            dtSoDiemBatBuoc = oBKQHT_ThanhPhanDiemBatBuoc.GetByIDThanhPhanDiem(IDKQHT_ThanhPhanDiem);
            grdSoDiem.DataSource = dtSoDiemBatBuoc;
            grvSoDiem_FocusedRowChanged(null, null);
        }

        private void SetBarButton(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnXoa.Enabled = status;
        }

        private void SetText()
        {
            txtSoHocTrinh.EditValue = pKQHT_ThanhPhanDiemBatBuocInfo.SoHocTrinh;
            txtSoTiet.EditValue = pKQHT_ThanhPhanDiemBatBuocInfo.SoTiet;
            txtSoDiem.EditValue = pKQHT_ThanhPhanDiemBatBuocInfo.SoDiemBatBuoc;
        }

        private bool CheckValid()
        {
            DataRow[] arrDr;
            arrDr = dtSoDiemBatBuoc.Select("SoHocTrinh = " + txtSoHocTrinh.EditValue.ToString());
            if (arrDr.Length > 0)
            {
                ThongBao("Số học trình này đã định mức số điểm bắt buộc.");
                return false;
            }
            return true;
        }

        private void GetpInfo()
        {
            pKQHT_ThanhPhanDiemBatBuocInfo.IDKQHT_ThanhPhanDiem = IDKQHT_ThanhPhanDiem;
            pKQHT_ThanhPhanDiemBatBuocInfo.SoHocTrinh = int.Parse(txtSoHocTrinh.EditValue.ToString());
            pKQHT_ThanhPhanDiemBatBuocInfo.SoTiet = int.Parse(txtSoTiet.EditValue.ToString());
            pKQHT_ThanhPhanDiemBatBuocInfo.SoDiemBatBuoc = int.Parse(txtSoDiem.EditValue.ToString());
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;

            GetpInfo();
            if (edit == EDIT_MODE.THEM)
            {
                pKQHT_ThanhPhanDiemBatBuocInfo.KQHT_ThanhPhanDiemBatBuocID = oBKQHT_ThanhPhanDiemBatBuoc.Add(pKQHT_ThanhPhanDiemBatBuocInfo);
                DataRow drNew = dtSoDiemBatBuoc.NewRow();
                oBKQHT_ThanhPhanDiemBatBuoc.ToDataRow(pKQHT_ThanhPhanDiemBatBuocInfo, ref drNew);
                dtSoDiemBatBuoc.Rows.Add(drNew);
                txtSoHocTrinh.EditValue = int.Parse(txtSoHocTrinh.EditValue.ToString()) + 1;
                txtSoHocTrinh.Focus();
            }
            else
            {
                oBKQHT_ThanhPhanDiemBatBuoc.Update(pKQHT_ThanhPhanDiemBatBuocInfo);
                oBKQHT_ThanhPhanDiemBatBuoc.ToDataRow(pKQHT_ThanhPhanDiemBatBuocInfo, ref drSoDiemBatBuoc);
                panelTop.Visible = false;
                grdSoDiem.Enabled = true;
                SuaThanhCong();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            grdSoDiem.Enabled = true;
            this.panelTop.Visible = false;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            edit = EDIT_MODE.THEM;
            grdSoDiem.Enabled = false;
            panelTop.Visible = true;
            txtSoHocTrinh.Focus();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            edit = EDIT_MODE.SUA;
            grdSoDiem.Enabled = false;
            panelTop.Visible = true;
            SetText(); 
            txtSoHocTrinh.Focus();
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn muốn xóa không ?") == DialogResult.Yes)
            {
                try
                {
                    pKQHT_ThanhPhanDiemBatBuocInfo.KQHT_ThanhPhanDiemBatBuocID = int.Parse(drSoDiemBatBuoc[pKQHT_ThanhPhanDiemBatBuocInfo.strKQHT_ThanhPhanDiemBatBuocID].ToString());
                    oBKQHT_ThanhPhanDiemBatBuoc.Delete(pKQHT_ThanhPhanDiemBatBuocInfo);
                    dtSoDiemBatBuoc.Rows.Remove(drSoDiemBatBuoc);
                    XoaThanhCong();
                }
                catch
                {
                    XoaThatBai();
                }
            }
        }

        private void txtSoHocTrinh_EditValueChanged(object sender, EventArgs e)
        {
            txtSoTiet.EditValue = 15 * int.Parse(txtSoHocTrinh.EditValue.ToString());
        }

        private void grvSoDiem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvSoDiem.FocusedRowHandle >= 0)
            {
                drSoDiemBatBuoc = grvSoDiem.GetDataRow(grvSoDiem.FocusedRowHandle);
            }
        }
    }
}