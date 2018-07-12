using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;

namespace UnimOs.UI
{
    public partial class frmDangKyHocLai : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DataTable dtLop, dtMonKy, dtSinhVien, dtHocLai;
        private cBXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private KQHT_DangKyHocLaiInfo pKQHT_DangKyHocLaiInfo;
        private cBKQHT_DangKyHocLai oBKQHT_DangKyHocLai;
        private cBKQHT_LopHocLai oBKQHT_LopHocLai;
        private int IDDM_Lop, IDDM_LopDangKy, IDDM_MonHoc, IDKQHT_LopHocLai;
        public frmDangKyHocLai()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
            oBKQHT_DangKyHocLai = new cBKQHT_DangKyHocLai();
            pKQHT_DangKyHocLaiInfo = new KQHT_DangKyHocLaiInfo();
            oBKQHT_LopHocLai = new cBKQHT_LopHocLai();
        }

        private void frmDangKyHocLai_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
            dtLop = oBDM_Lop.GetTree(Program.NamHoc);
            cmbLop.Properties.DataSource = dtLop;
            cmbNamHoc.Properties.DataSource = LoadNamHoc();
            GetLopHocLai();
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            DM_LopInfo pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                IDDM_Lop = pDM_LopInfo.DM_LopID;
                // load sinh vien
                if (rdSinhVien.SelectedIndex == 0)
                {
                    dtSinhVien = oBKQHT_DangKyHocLai.GetSinhVien(IDDM_Lop, 0, 0, IDDM_MonHoc, Program.IDNamHoc, Program.HocKy, 0);
                    dtSinhVien.DefaultView.RowFilter = "Diem <5";
                    grdSinhVien.DataSource = dtSinhVien.DefaultView;
                }
                else
                {
                    dtSinhVien = oBKQHT_DangKyHocLai.GetSinhVien(IDDM_Lop, 0, 0, IDDM_MonHoc, Program.IDNamHoc, Program.HocKy, 0);
                    grdSinhVien.DataSource = dtSinhVien;
                }
                btnCapNhat.Enabled = true;
            }
            else
                btnCapNhat.Enabled = false;
        }
       
        private void LoadMonKy(int IDDM_Lop)
        {
            dtMonKy = oBXL_MonHocTrongKy.GetByLop(IDDM_Lop, Program.IDNamHoc, Program.HocKy);
            cmbMonHoc.Properties.DataSource = dtMonKy;
            if (dtMonKy.Rows.Count > 0)
            {
                cmbMonHoc.ItemIndex = 0;
                LoadSinhVien();
            }
            else
            {
                grdSinhVien.DataSource = null;
                //grdTuChon.DataSource = null;
            }
        }

       
        private void cmbMonHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbMonHoc.EditValue != null)
            {
                IDDM_MonHoc = int.Parse(cmbMonHoc.EditValue.ToString());
                LoadSinhVien();
               // GetLopHocLai(int.Parse(cmbMonHoc.EditValue.ToString()));
            }
        }
        private void GetLopHocLai()
        {
            cmbLopMoThem.Properties.DataSource = oBKQHT_LopHocLai.GetByHocKyNamHoc(0, Program.HocKy, Program.IDNamHoc);
        }
        private void LoadSinhVien()
        {
            if (dtSinhVien != null)
                dtSinhVien.Clear();
            if (dtHocLai != null)
                dtHocLai.Clear();
            if (rdSinhVien.SelectedIndex == 0)
            {
                dtSinhVien = oBKQHT_DangKyHocLai.GetSinhVien(IDDM_Lop,0,0, IDDM_MonHoc, Program.IDNamHoc, Program.HocKy, 0);
                dtSinhVien.DefaultView.RowFilter = "Diem <5";
                grdSinhVien.DataSource = dtSinhVien.DefaultView;
            }
            else
            {
                dtSinhVien = oBKQHT_DangKyHocLai.GetSinhVien(IDDM_Lop,0,0, IDDM_MonHoc, Program.IDNamHoc, Program.HocKy, 0);
                grdSinhVien.DataSource = dtSinhVien;
            }
         
            if (rdLopDangKy.SelectedIndex == 0)
            {
                if (cmbLop.EditValue != null && cmbMonHoc.EditValue != null)
                    dtHocLai = oBKQHT_DangKyHocLai.GetSinhVien(IDDM_Lop,IDDM_LopDangKy,0, IDDM_MonHoc, Program.IDNamHoc, Program.HocKy, 1);
                else
                    dtHocLai = null;
            }
            else
            {
                if (cmbLopMoThem.EditValue != null && cmbMonHoc.EditValue != null)
                    dtHocLai = oBKQHT_DangKyHocLai.GetSinhVien(IDDM_Lop, 0, IDKQHT_LopHocLai, IDDM_MonHoc, Program.IDNamHoc, Program.HocKy, 1);
                else
                    dtHocLai = null;
            }
             grdTuChon.DataSource = dtHocLai;
        }

       
        private void cmbLopMoThem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbLopMoThem.EditValue = null;
        }

        private void rdSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMonHoc.EditValue != null)
                LoadSinhVien();
        }

        private void grvSinhVien_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvSinhVien, "Chon", e);
        }

        private void grvTuChon_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvTuChon, "Chon", e);
        }

        private void cmbLop_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbLop.EditValue != null)
            {
                IDDM_LopDangKy = int.Parse(cmbLop.EditValue.ToString());
                cmbMonHoc.Properties.DataSource = oBXL_MonHocTrongKy.GetByLop(IDDM_LopDangKy, Program.IDNamHoc, Program.HocKy);
                cmbMonHoc.EditValue = null;
            }
            if (dtSinhVien != null)
                dtSinhVien.Clear();
            if (dtHocLai != null)
                dtHocLai.Clear();
        }

        private void cmbLopMoThem_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbLopMoThem.EditValue != null)
            {
                cmbMonHoc.Properties.DataSource = oBXL_MonHocTrongKy.GetMonKy(0, Program.IDNamHoc, Program.HocKy);
                cmbMonHoc.EditValue = cmbLopMoThem.GetColumnValue("IDDM_MonHoc");
                IDDM_MonHoc = int.Parse(cmbLopMoThem.GetColumnValue("IDDM_MonHoc").ToString());
                IDKQHT_LopHocLai = int.Parse(cmbLopMoThem.EditValue.ToString());
            }
            LoadSinhVien();
        }

        private void cmbNamHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbNamHoc.EditValue != null)
            {
                if (cmbHocKy.EditValue != null)

                    dtSinhVien.DefaultView.RowFilter = "IDDM_NamHoc=" + cmbNamHoc.EditValue.ToString() + " and HocKy=" + cmbHocKy.EditValue.ToString();

                else
                    dtSinhVien.DefaultView.RowFilter = "IDDM_NamHoc=" + cmbNamHoc.EditValue.ToString();
                grdSinhVien.DataSource = dtSinhVien.DefaultView;
            }
        }

        private void cmbHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHocKy.EditValue != null)
            {
                if (cmbNamHoc.EditValue != null)
                    dtSinhVien.DefaultView.RowFilter = "IDDM_NamHoc=" + cmbNamHoc.EditValue.ToString() + " and HocKy=" + cmbHocKy.EditValue.ToString();
                else
                    dtSinhVien.DefaultView.RowFilter = "HocKy=" + cmbHocKy.EditValue.ToString();
                grdSinhVien.DataSource = dtSinhVien.DefaultView;
            }
        }

        private void cmbNamHoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbNamHoc.EditValue = null;
                dtSinhVien.DefaultView.RowFilter = "";
            }
        }

        private void cmbHocKy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbHocKy.EditValue = null;
                dtSinhVien.DefaultView.RowFilter = "";
            }
        }
        private void cmbLop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbLop.EditValue = null;
        }

        private void grvSinhVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvTuChon_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void rdLopDangKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdLopDangKy.EditValue.ToString() == "0")
            {
                cmbLop.Enabled = true;
                cmbLopMoThem.Enabled = false;
                btnThem.Enabled = false;
                cmbMonHoc.Enabled = true;
                grdSinhVien.DataSource = null;
                grdTuChon.DataSource = null;
                cmbLop.EditValue = null;
            }
            else
            {
                cmbLop.Enabled = false;
                cmbLopMoThem.Enabled = true;
                btnThem.Enabled = true;
                cmbMonHoc.Enabled = false;
                grdSinhVien.DataSource = null;
                grdTuChon.DataSource = null;
                cmbLopMoThem.EditValue = null;
            }
          //  LoadSinhVien();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int Count = dtSinhVien.Rows.Count;
            for (int i = 0; i < Count; i++)
            {
                if ((bool)dtSinhVien.Rows[i]["Chon"])
                {
                    dtSinhVien.Rows[i]["Chon"] = false;
                    dtSinhVien.Rows[i]["TienLePhi"] = float.Parse("0" + txtSoTien.Text);
                    if ((cmbLop.EditValue != null) && (cmbLop.Enabled == true))
                    {
                        dtSinhVien.Rows[i]["IDKQHT_LopHocLai"] = 0;
                        dtSinhVien.Rows[i]["IDDM_Lop"] = cmbLop.EditValue;
                        dtSinhVien.Rows[i]["TenLop"] = cmbLop.GetColumnValue("TenLop");
                    }
                    else if ((cmbLopMoThem.EditValue != null) && (cmbLopMoThem.Enabled == true))
                    {
                        dtSinhVien.Rows[i]["IDDM_Lop"] = 0;
                        dtSinhVien.Rows[i]["IDKQHT_LopHocLai"] = cmbLopMoThem.EditValue;
                        dtSinhVien.Rows[i]["TenLop"] = cmbLopMoThem.GetColumnValue("TenLop");
                    }
                    else
                    {
                        dtSinhVien.Rows[i]["IDDM_Lop"] = 0;
                        dtSinhVien.Rows[i]["TenLop"] = "";
                    }

                    dtHocLai.ImportRow(dtSinhVien.Rows[i]);
                    dtSinhVien.Rows.Remove(dtSinhVien.Rows[i]);
                    Count = Count - 1;
                    i = i - 1;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int Count = dtHocLai.Rows.Count;
            for (int i = 0; i < Count; i++)
            {
                if ((bool)dtHocLai.Rows[i]["Chon"])
                {
                    dtHocLai.Rows[i]["Chon"] = false;
                    dtSinhVien.ImportRow(dtHocLai.Rows[i]);
                    dtHocLai.Rows.Remove(dtHocLai.Rows[i]);
                    Count = Count - 1;
                    i = i - 1;
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //if (!Check_Valid()) return;
            if (cmbMonHoc.EditValue != null)
            {
                try
                {
                    oBKQHT_DangKyHocLai.DeleteByMonHoc(IDDM_Lop, int.Parse(cmbMonHoc.EditValue.ToString()), Program.IDNamHoc, Program.HocKy);
                }
                catch
                {
                    // ERROR
                }

                foreach (DataRow dr in dtHocLai.Rows)
                {
                    try
                    {
                        pKQHT_DangKyHocLaiInfo.IDHT_User = Program.objUserCurrent.HT_UserID;
                        pKQHT_DangKyHocLaiInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                        pKQHT_DangKyHocLaiInfo.IDDM_MonHoc = int.Parse(cmbMonHoc.EditValue.ToString());
                        pKQHT_DangKyHocLaiInfo.IDDM_NamHoc = Program.IDNamHoc;
                        pKQHT_DangKyHocLaiInfo.HocKy = Program.HocKy;
                        pKQHT_DangKyHocLaiInfo.SoTietHocLai = int.Parse("0" + txtSoTietHocLai.Text.Trim());
                        if (rdLopDangKy.SelectedIndex == 0)
                        {
                            pKQHT_DangKyHocLaiInfo.IDDM_LopDangKy = IDDM_LopDangKy;
                            pKQHT_DangKyHocLaiInfo.IDKQHT_LopHocLai = 0;
                        }
                        else
                        {
                            pKQHT_DangKyHocLaiInfo.IDDM_LopDangKy = 0;
                            pKQHT_DangKyHocLaiInfo.IDKQHT_LopHocLai = IDKQHT_LopHocLai;
                        }
                        pKQHT_DangKyHocLaiInfo.TienLePhi = float.Parse("0" + txtSoTien.Text.Trim());
                        pKQHT_DangKyHocLaiInfo.NgayDangKy = DateTime.Now;
                        pKQHT_DangKyHocLaiInfo.IDXL_MonHocTrongKy = int.Parse("0" + dr["IDXL_MonHocTrongKy"]);
                        oBKQHT_DangKyHocLai.Add(pKQHT_DangKyHocLaiInfo);
                    }
                    catch (Exception exp)
                    {
                        ThongBao(exp.Message);
                    }
                }
                ThongBao("Lưu thông tin thành công!");
            }
            else
                ThongBao("Bạn chưa chọn môn học nào!");
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
           frmToChucLopHocLai frm = new frmToChucLopHocLai();
                frm.ShowDialog();
                GetLopHocLai();
        }

      
    }
}
