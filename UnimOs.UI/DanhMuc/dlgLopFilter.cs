using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.Entity;

namespace UnimOs.UI
{
    public partial class dlgLopFilter : frmBase
    {
        private DataTable dtHe, dtTrinhDo, dtKhoa, dtKhoaHoc, dtNganh, dtLop;
        private Lib.Ini clsIni;
        public DM_LopInfo pDM_LopInfo;
        public string HeTrinhDo = "";

        public dlgLopFilter()
        {
            dtHe = LoadHe();
            dtTrinhDo = LoadTrinhDo();
            dtKhoa = LoadKhoa();
            dtKhoaHoc = LoadKhoaHoc();
            dtNganh = LoadNganh();
            dtLop = LoadLopTheoKhoa(0);
            InitializeComponent();

            clsIni = new Lib.Ini(Application.StartupPath + "\\truongviet.ini");
            this.DialogResult = DialogResult.Cancel;
            cmbCoSo.Properties.DataSource = bLoadDiaDiem();

            SetIni();
        }

        private void SetIni()
        {
            string str = "";
            str = clsIni.ReadValue("HE_TRINHDO", "IDDM_He");
            if (str != "")
                ucHeTrinhDo1.cmbHe.EditValue = int.Parse(str);
            str = clsIni.ReadValue("HE_TRINHDO", "IDDM_TrinhDo");
            if (str != "")
                ucHeTrinhDo1.cmbTrinhDo.EditValue = int.Parse(str);
            str = clsIni.ReadValue("HE_TRINHDO", "IDDM_Khoa");
            if (str != "")
                ucHeTrinhDo1.cmbKhoa.EditValue = int.Parse(str);
            str = clsIni.ReadValue("HE_TRINHDO", "IDDM_KhoaHoc");
            if (str != "")
                ucHeTrinhDo1.cmbKhoaHoc.EditValue = int.Parse(str);
            str = clsIni.ReadValue("HE_TRINHDO", "IDDM_Nganh");
            if (str != "")
                ucHeTrinhDo1.cmbNganh.EditValue = int.Parse(str);
            str = clsIni.ReadValue("HE_TRINHDO", "IDDM_Lop");
            if (str != "")
                ucHeTrinhDo1.cmbLop.EditValue = int.Parse(str);
            str = clsIni.ReadValue("HE_TRINHDO", "IDDM_DiaDiem");
            if (str != "")
                cmbCoSo.EditValue = int.Parse(str);
        }

        private void SaveIni()
        {
            clsIni.WriteValue("HE_TRINHDO", "IDDM_He", "" + ucHeTrinhDo1.cmbHe.EditValue);
            clsIni.WriteValue("HE_TRINHDO", "IDDM_TrinhDo", "" + ucHeTrinhDo1.cmbTrinhDo.EditValue);
            clsIni.WriteValue("HE_TRINHDO", "IDDM_Khoa", "" + ucHeTrinhDo1.cmbKhoa.EditValue);
            clsIni.WriteValue("HE_TRINHDO", "IDDM_KhoaHoc", "" + ucHeTrinhDo1.cmbKhoaHoc.EditValue);
            clsIni.WriteValue("HE_TRINHDO", "IDDM_Nganh", "" + ucHeTrinhDo1.cmbNganh.EditValue);
            clsIni.WriteValue("HE_TRINHDO", "IDDM_Lop", "" + ucHeTrinhDo1.cmbLop.EditValue);
            clsIni.WriteValue("HE_TRINHDO", "IDDM_DiaDiem", "" + cmbCoSo.EditValue);
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            pDM_LopInfo = ucHeTrinhDo1.GetDM_LopInfo();
            HeTrinhDo = ucHeTrinhDo1.GetHeTrinhDo();
            if (cmbCoSo.EditValue != null)
            {
                pDM_LopInfo.IDDM_DiaDiem = int.Parse(cmbCoSo.EditValue.ToString());
                HeTrinhDo += (HeTrinhDo == "" ? "TẠI: " : " - TẠI: ") + cmbCoSo.Text.ToUpper();
            }
            SaveIni();
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCoSo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbCoSo.ClosePopup();
                cmbCoSo.EditValue = null;
            }
        }
    }
}