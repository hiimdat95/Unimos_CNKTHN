using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.Entity;

namespace UnimOs.UI
{
    public partial class ucHeTrinhDo : DevExpress.XtraEditors.XtraUserControl
    {
        private DataTable dtHe, dtTrinhDo, dtKhoa, dtKhoaHoc, dtNganh, dtLop;
        public ucHeTrinhDo()
        {
            InitializeComponent();
        }

        public ucHeTrinhDo(DataTable _dtHe, DataTable _dtTrinhDo, DataTable _dtKhoa, DataTable _dtKhoaHoc, DataTable _dtNganh, DataTable _dtLop)
        {
            InitializeComponent();
            dtHe = _dtHe;
            dtTrinhDo = _dtTrinhDo;
            dtKhoa = _dtKhoa;
            dtKhoaHoc = _dtKhoaHoc;
            dtNganh = _dtNganh;
            dtLop = _dtLop;

            cmbHe.Properties.DataSource = dtHe;
            cmbTrinhDo.Properties.DataSource = dtTrinhDo;
            cmbKhoa.Properties.DataSource = dtKhoa;
            cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;
            cmbNganh.Properties.DataSource = dtNganh;
            cmbLop.Properties.DataSource = dtLop;
        }

        private void cmbHe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ((LookUpEdit)sender).ClosePopup();
                ((LookUpEdit)sender).EditValue = null;
            }
        }

        private void cmbHe_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbHe.EditValue != null)
            {
                DataView dv = new DataView(dtTrinhDo);
                dv.RowFilter = "IDDM_He = " + cmbHe.EditValue;
                cmbTrinhDo.Properties.DataSource = dv;
            }
            else
                cmbTrinhDo.Properties.DataSource = dtTrinhDo;
            cmbTrinhDo_EditValueChanged(null, null);
        }

        private void cmbTrinhDo_EditValueChanged(object sender, EventArgs e)
        {
            string Filter = "";
            if (cmbHe.EditValue != null)
                Filter += " And IDDM_He = " + cmbHe.EditValue;
            if (cmbTrinhDo.EditValue != null)
                Filter += " And IDDM_TrinhDo = " + cmbTrinhDo.EditValue;
            if (cmbKhoa.EditValue != null)
                Filter += " And IDDM_Khoa = " + cmbKhoa.EditValue;
            if (cmbKhoaHoc.EditValue != null)
                Filter += " And IDDM_KhoaHoc = " + cmbKhoaHoc.EditValue;
            if (cmbNganh.EditValue != null)
                Filter += " And IDDM_Nganh = " + cmbNganh.EditValue;
            if (Filter != "")
            {
                Filter = Filter.Substring(5);
                DataView dv = new DataView(dtLop);
                dv.RowFilter = Filter;
                cmbLop.Properties.DataSource = dv;
            }
            else
                cmbLop.Properties.DataSource = dtLop;
        }

        public string GetDM_LopFilter()
        {
            string Filter = "";
            if (cmbHe.EditValue != null)
                Filter = " And IDDM_He = " + cmbHe.EditValue;
            if (cmbTrinhDo.EditValue != null)
                Filter = " And IDDM_TrinhDo = " + cmbTrinhDo.EditValue;
            if (cmbKhoa.EditValue != null)
                Filter = " And IDDM_Khoa = " + cmbKhoa.EditValue;
            if (cmbKhoaHoc.EditValue != null)
                Filter = " And IDDM_KhoaHoc = " + cmbKhoaHoc.EditValue;
            if (cmbNganh.EditValue != null)
                Filter = " And IDDM_Nganh = " + cmbNganh.EditValue;
            if (cmbLop.EditValue != null)
                Filter = " And DM_LopID = " + cmbLop.EditValue;

            if (Filter != "")
                Filter = Filter.Substring(5);
            return Filter;
        }

        public DM_LopInfo GetDM_LopInfo()
        {
            DM_LopInfo pDM_LopInfo = new DM_LopInfo();
            if (cmbHe.EditValue != null)
                pDM_LopInfo.IDDM_He = int.Parse(cmbHe.EditValue.ToString());
            if (cmbTrinhDo.EditValue != null)
                pDM_LopInfo.IDDM_TrinhDo = int.Parse(cmbTrinhDo.EditValue.ToString());
            if (cmbKhoa.EditValue != null)
                pDM_LopInfo.IDDM_Khoa = int.Parse(cmbKhoa.EditValue.ToString());
            if (cmbKhoaHoc.EditValue != null)
                pDM_LopInfo.IDDM_KhoaHoc = int.Parse(cmbKhoaHoc.EditValue.ToString());
            if (cmbNganh.EditValue != null)
                pDM_LopInfo.IDDM_Nganh = int.Parse(cmbNganh.EditValue.ToString());
            if (cmbLop.EditValue != null)
                pDM_LopInfo.DM_LopID = int.Parse(cmbLop.EditValue.ToString());
            
            return pDM_LopInfo;
        }

        public string GetHeTrinhDo()
        {
            string HeTrinhDo = "";
            if (cmbHe.EditValue != null)
                HeTrinhDo = "HỆ: " + cmbHe.Text.ToUpper();
            if (cmbTrinhDo.EditValue != null)
                HeTrinhDo += (HeTrinhDo == "" ? "TRÌNH ĐỘ: " : " - TRÌNH ĐỘ: ") + cmbTrinhDo.Text.ToUpper();
            return HeTrinhDo;
        }
    }
}
