using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace UnimOs.UI
{
    public partial class frmNhapCongViecGiaoVien : frmBase
    {
        private cBNS_DonVi oBDonVi;
        private NS_DonViInfo pDonViInfo;
        private cBGG_CongViecGiaoVien oBGGCongViecGiaoVien;
        private GG_CongViecGiaoVienInfo pCongViecGiaoVienInfo;
        private cBDM_LoaiCongViec oBLoaiCongViec;
        private DataTable dtTree, dtCongViec, dtNhiemVu;
        private bool Loaded = false;
        private double HeSo;

        public frmNhapCongViecGiaoVien()
        {
            InitializeComponent();
            oBGGCongViecGiaoVien = new cBGG_CongViecGiaoVien();
            pCongViecGiaoVienInfo = new GG_CongViecGiaoVienInfo();
            pDonViInfo = new NS_DonViInfo();
            oBLoaiCongViec = new cBDM_LoaiCongViec();
            dtNhiemVu = oBLoaiCongViec.Get(new DM_LoaiCongViecInfo());
            cmbNhiemVu.Properties.DataSource = dtNhiemVu;
        }

        private void frmDanhSachGiaoVien_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            if (dtNhiemVu.Rows.Count > 0)
                cmbNhiemVu.EditValue = dtNhiemVu.Rows[0]["DM_LoaiCongViecID"];
            Loaded = true;
            trvDonVi_FocusedNodeChanged(null, null);
        }

        private void LoadTreeView()
        {
            oBDonVi = new cBNS_DonVi();
            dtTree = oBDonVi.Get_Tree();
            trvDonVi.DataSource = dtTree;
            trvDonVi.ExpandAll();
        }

        private void trvDonVi_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (Loaded == true)
            {
                if (trvDonVi.Nodes.Count > 0)
                {
                    dtCongViec = oBGGCongViecGiaoVien.GetByIDDM_LoaiCongViec(cmbNhiemVu.EditValue == null ? 0 : int.Parse(cmbNhiemVu.EditValue.ToString()),
                        int.Parse(trvDonVi.FocusedNode["NS_DonViID"].ToString()), Program.IDNamHoc, Program.HocKy);
                    grdCongViec.DataSource = dtCongViec;
                }
            }
        }

        private void grvGiaoVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cmbNhiemVu.EditValue + "" == "")
            {
                ThongBao("Phải chọn nhiệm vụ cho giáo viên");
                cmbNhiemVu.Focus();
                return;
            }
            if (dtCongViec.Rows.Count == 0) return;
            DataTable dtChange = dtCongViec.GetChanges();

            if (dtChange!=null)
            {
                for (int i = 0; i < dtChange.Rows.Count; i++)
                {
                    pCongViecGiaoVienInfo.IDNS_GiaoVien = int.Parse(dtChange.Rows[i]["NS_GiaoVienID"].ToString());
                    pCongViecGiaoVienInfo.IDDM_NamHoc = Program.IDNamHoc;
                    pCongViecGiaoVienInfo.HocKy = Program.HocKy;
                    pCongViecGiaoVienInfo.SoGio = int.Parse(dtChange.Rows[i]["SoGio"].ToString());
                    pCongViecGiaoVienInfo.GioQuyChuan = double.Parse(dtChange.Rows[i]["GioQuyChuan"].ToString());
                    pCongViecGiaoVienInfo.IDDM_LoaiCongViec = (int)cmbNhiemVu.EditValue;
                    if ("" + dtChange.Rows[i]["GG_CongViecGiaoVienID"] != "")
                    {
                        pCongViecGiaoVienInfo.GG_CongViecGiaoVienID = int.Parse(dtChange.Rows[i]["GG_CongViecGiaoVienID"].ToString());
                        oBGGCongViecGiaoVien.Update(pCongViecGiaoVienInfo);
                    }
                    else
                        oBGGCongViecGiaoVien.Add(pCongViecGiaoVienInfo);
                }
                trvDonVi_FocusedNodeChanged(null, null);
            }
        }

        private void cmbNhiemVu_EditValueChanged(object sender, EventArgs e)
        {
            trvDonVi_FocusedNodeChanged(null, null);
            if (cmbNhiemVu.EditValue != null)
            {
                HeSo = double.Parse(cmbNhiemVu.GetColumnValue("QuyChuan").ToString()) /
                    double.Parse(cmbNhiemVu.GetColumnValue("SoLuong").ToString());
                lblHeSo.Text = "Hệ số: " + Math.Round(HeSo, 2, MidpointRounding.AwayFromZero).ToString();
            }
        }

        private void grvCongViec_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "SoGio")
            {
                DataRow dr = grvCongViec.GetDataRow(grvCongViec.FocusedRowHandle);
                dr["GioQuyChuan"] = Math.Round(Math.Abs((int.Parse(dr["SoGio"].ToString()) * HeSo)), 2, MidpointRounding.AwayFromZero);
            }
        }
    }
}
