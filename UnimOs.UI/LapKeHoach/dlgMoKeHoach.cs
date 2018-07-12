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
    public partial class dlgMoKeHoach : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        public DM_LopInfo pDM_LopInfo;
        private DataTable dtKhoaHoc;
        private Lib.Ini clsIni;

        public dlgMoKeHoach()
        {
            InitializeComponent();
            clsIni = new Lib.Ini(Application.StartupPath + "\\truongviet.ini");
            this.DialogResult = DialogResult.Cancel;
            oBDM_Lop = new cBDM_Lop();
            pDM_LopInfo = new DM_LopInfo();
        }

        private void dlgMoKeHoach_Load(object sender, EventArgs e)
        {
            LoadCombo();
            SetIni();
        }

        private void LoadCombo()
        {
            cmbHe.Properties.DataSource = LoadHe();
            cmbTrinhDo.Properties.DataSource = LoadTrinhDo();
            cmbKhoa.Properties.DataSource = LoadKhoa();
            dtKhoaHoc = LoadKhoaHoc();
            cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;
        }

        private void LoadDanhSachLop()
        {
            pDM_LopInfo.IDDM_Khoa = cmbKhoa.EditValue == null ? 0 : int.Parse(cmbKhoa.EditValue.ToString());
            pDM_LopInfo.IDDM_He = cmbHe.EditValue == null ? 0 : int.Parse(cmbHe.EditValue.ToString());
            pDM_LopInfo.IDDM_TrinhDo = cmbTrinhDo.EditValue == null ? 0 : int.Parse(cmbTrinhDo.EditValue.ToString());
            pDM_LopInfo.IDDM_Nganh = cmbNganh.EditValue == null ? 0 : int.Parse(cmbNganh.EditValue.ToString());
            pDM_LopInfo.IDDM_KhoaHoc = cmbKhoaHoc.EditValue == null ? 0 : int.Parse(cmbKhoaHoc.EditValue.ToString());
            cmbLop.Properties.DataSource = oBDM_Lop.GetDanhSachLop(pDM_LopInfo, Program.NamHoc);
        }

        private void SetIni()
        {
            string str = "";
            str = clsIni.ReadValue("HE_TRINHDO", "IDDM_He");
            if (str != "")
                cmbHe.EditValue = int.Parse(str);
            str = clsIni.ReadValue("HE_TRINHDO", "IDDM_TrinhDo");
            if (str != "")
                cmbTrinhDo.EditValue = int.Parse(str);
            str = clsIni.ReadValue("HE_TRINHDO", "IDDM_Khoa");
            if (str != "")
                cmbKhoa.EditValue = int.Parse(str);
            str = clsIni.ReadValue("HE_TRINHDO", "IDDM_KhoaHoc");
            if (str != "")
                cmbKhoaHoc.EditValue = int.Parse(str);
            str = clsIni.ReadValue("HE_TRINHDO", "IDDM_Nganh");
            if (str != "")
                cmbNganh.EditValue = int.Parse(str);
            str = clsIni.ReadValue("HE_TRINHDO", "IDDM_Lop");
            if (str != "")
                cmbLop.EditValue = int.Parse(str);
            str = clsIni.ReadValue("HE_TRINHDO", "IDDM_DiaDiem");
        }

        private void SaveIni()
        {
            clsIni.WriteValue("HE_TRINHDO", "IDDM_He", "" + cmbHe.EditValue);
            clsIni.WriteValue("HE_TRINHDO", "IDDM_TrinhDo", "" + cmbTrinhDo.EditValue);
            clsIni.WriteValue("HE_TRINHDO", "IDDM_Khoa", "" + cmbKhoa.EditValue);
            clsIni.WriteValue("HE_TRINHDO", "IDDM_KhoaHoc", "" + cmbKhoaHoc.EditValue);
            clsIni.WriteValue("HE_TRINHDO", "IDDM_Nganh", "" + cmbNganh.EditValue);
            clsIni.WriteValue("HE_TRINHDO", "IDDM_Lop", "" + cmbLop.EditValue);
        }

        private void cmbHe_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dtTrinhDo = LoadTrinhDoByIDHe(int.Parse(cmbHe.EditValue.ToString()));
            cmbTrinhDo.Properties.DataSource = dtTrinhDo;
            if (dtTrinhDo.Rows.Count > 0)
                cmbTrinhDo.ItemIndex = 0;
            LoadDanhSachLop();
        }

        private void cmbKhoa_EditValueChanged(object sender, EventArgs e)
        {
            cmbNganh.Properties.DataSource = LoadNganhByIDKhoa(int.Parse("0" + cmbKhoa.EditValue));
            LoadDanhSachLop();
        }

        private void cmbTrinhDo_EditValueChanged(object sender, EventArgs e)
        {
            string strFilter = "";
            if (cmbTrinhDo.EditValue != null)
                strFilter = "IDDM_TrinhDo = " + cmbTrinhDo.EditValue.ToString();
            if (cmbNganh.EditValue != null)
                strFilter += strFilter == "" ? "IDDM_Nganh = " + cmbNganh.EditValue.ToString() : " And IDDM_Nganh = " + cmbNganh.EditValue.ToString();

            //if (strFilter != "")
            //{
            //    DataView dv = new DataView(dtKhoaHoc);
            //    dv.RowFilter = strFilter;
            //    cmbKhoaHoc.Properties.DataSource = dv;
            //}
            //else
            //    cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;

            LoadDanhSachLop();
        }

        private void cmbKhoaHoc_EditValueChanged(object sender, EventArgs e)
        {
            LoadDanhSachLop();
        }

        private void cmb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                LookUpEdit cmb = sender as LookUpEdit;
                cmb.EditValue = null;
            }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            pDM_LopInfo.IDDM_Khoa = cmbKhoa.EditValue == null ? 0 : int.Parse(cmbKhoa.EditValue.ToString());
            pDM_LopInfo.IDDM_He = cmbHe.EditValue == null ? 0 : int.Parse(cmbHe.EditValue.ToString());
            pDM_LopInfo.IDDM_TrinhDo = cmbTrinhDo.EditValue == null ? 0 : int.Parse(cmbTrinhDo.EditValue.ToString());
            pDM_LopInfo.IDDM_Nganh = cmbNganh.EditValue == null ? 0 : int.Parse(cmbNganh.EditValue.ToString());
            pDM_LopInfo.IDDM_KhoaHoc = cmbKhoaHoc.EditValue == null ? 0 : int.Parse(cmbKhoaHoc.EditValue.ToString());
            pDM_LopInfo.DM_LopID = cmbLop.EditValue == null ? 0 : int.Parse(cmbLop.EditValue.ToString());
            SaveIni();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}