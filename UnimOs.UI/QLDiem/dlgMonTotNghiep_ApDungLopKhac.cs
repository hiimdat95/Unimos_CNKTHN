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
    public partial class dlgMonTotNghiep_ApDungLopKhac : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private DataTable dtKhoaHoc, dtLop, dtMon;
        private cBKQHT_MonThiTotNghiep_Lop oBKQHT_MonThiTotNghiep_Lop;
        private KQHT_MonThiTotNghiep_LopInfo pKQHT_MonThiTotNghiep_LopInfo;

        public dlgMonTotNghiep_ApDungLopKhac(DM_LopInfo mpDM_LopInfo, DataTable mdtMon)
        {
            InitializeComponent();
            pDM_LopInfo = new DM_LopInfo();
            oBDM_Lop = new cBDM_Lop();
            oBKQHT_MonThiTotNghiep_Lop = new cBKQHT_MonThiTotNghiep_Lop();
            pKQHT_MonThiTotNghiep_LopInfo = new KQHT_MonThiTotNghiep_LopInfo();
            pDM_LopInfo = mpDM_LopInfo;
            dtMon = mdtMon;
        }

        private void dlgMonTotNghiep_ApDungLopKhac_Load(object sender, EventArgs e)
        {
            LoadCombo();
            LoadDanhSachLop();
        }
        private void LoadCombo()
        {
            cmbHe.Properties.DataSource = LoadHe();
            cmbHe.EditValue = pDM_LopInfo.IDDM_He;
            cmbTrinhDo.Properties.DataSource = LoadTrinhDo();
            cmbTrinhDo.EditValue = pDM_LopInfo.IDDM_TrinhDo;
            cmbKhoa.Properties.DataSource = LoadKhoa();
            dtKhoaHoc = LoadKhoaHoc();
            cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;
            cmbKhoaHoc.EditValue = pDM_LopInfo.IDDM_KhoaHoc;
        }
        private void LoadDanhSachLop()
        {
            pDM_LopInfo.IDDM_Khoa = cmbKhoa.EditValue == null ? 0 : int.Parse(cmbKhoa.EditValue.ToString());
            pDM_LopInfo.IDDM_He = cmbHe.EditValue == null ? 0 : int.Parse(cmbHe.EditValue.ToString());
            pDM_LopInfo.IDDM_TrinhDo = cmbTrinhDo.EditValue == null ? 0 : int.Parse(cmbTrinhDo.EditValue.ToString());
            pDM_LopInfo.IDDM_Nganh = cmbNganh.EditValue == null ? 0 : int.Parse(cmbNganh.EditValue.ToString());
            pDM_LopInfo.IDDM_KhoaHoc = cmbKhoaHoc.EditValue == null ? 0 : int.Parse(cmbKhoaHoc.EditValue.ToString());
            dtLop = oBDM_Lop.GetDanhSachLop(pDM_LopInfo, Program.NamHoc);
            grdLop.DataSource = dtLop;
        }

        private void cmbHe_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dtTrinhDo = LoadTrinhDoByIDHe(int.Parse(cmbHe.EditValue.ToString()));
            cmbTrinhDo.Properties.DataSource = dtTrinhDo;
            if (dtTrinhDo.Rows.Count > 0)
                cmbTrinhDo.ItemIndex = 0;
            LoadDanhSachLop();
        }

        private void cmbTrinhDo_EditValueChanged(object sender, EventArgs e)
        {
            string strFilter = "";
            if (cmbTrinhDo.EditValue != null)
                strFilter = "IDDM_TrinhDo = " + cmbTrinhDo.EditValue.ToString();
            if (cmbNganh.EditValue != null)
                strFilter += strFilter == "" ? "IDDM_Nganh = " + cmbNganh.EditValue.ToString() : " And IDDM_Nganh = " + cmbNganh.EditValue.ToString();

            if (strFilter != "")
            {
                DataView dv = new DataView(dtKhoaHoc);
                dv.RowFilter = strFilter;
                cmbKhoaHoc.Properties.DataSource = dv;
            }
            else
                cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;

            LoadDanhSachLop();
        }

        private void cmbKhoa_EditValueChanged(object sender, EventArgs e)
        {
            cmbNganh.Properties.DataSource = LoadNganhByIDKhoa(int.Parse("0" + cmbKhoa.EditValue));
            LoadDanhSachLop();
        }

        private void cmbNganh_EditValueChanged(object sender, EventArgs e)
        {
            LoadDanhSachLop();
        }

        private void cmbKhoaHoc_EditValueChanged(object sender, EventArgs e)
        {
            LoadDanhSachLop();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = dtLop.GetChanges();
            if (dtTemp != null)
            {
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    try
                    {
                        oBKQHT_MonThiTotNghiep_Lop.Delete_ByLop(int.Parse(dtTemp.Rows[i]["DM_LopID"].ToString()));
                    }
                    catch
                    { }
                    for (int j = 0; j < dtMon.Rows.Count; j++)
                    {
                        pKQHT_MonThiTotNghiep_LopInfo.IDDM_Lop = int.Parse(dtTemp.Rows[i]["DM_LopID"].ToString());
                        pKQHT_MonThiTotNghiep_LopInfo.IDDM_MonHoc = int.Parse(dtMon.Rows[j]["DM_MonHocID"].ToString());
                        pKQHT_MonThiTotNghiep_LopInfo.SoHocTrinh = int.Parse(dtMon.Rows[j]["SoHocTrinh"].ToString());
                        pKQHT_MonThiTotNghiep_LopInfo.TinhDiem = bool.Parse(dtMon.Rows[j]["TinhDiem"].ToString());
                        pKQHT_MonThiTotNghiep_LopInfo.IDDM_NamHoc = Program.IDNamHoc;
                        oBKQHT_MonThiTotNghiep_Lop.Add(pKQHT_MonThiTotNghiep_LopInfo);
                    }
                }
                ThongBao("Áp dụng thành công!");
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 lớp!");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvLop_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvLop, "Chon", e);
        }
    }
}