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
    public partial class frmDangKyThiLai : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DataTable dtMonKy, dtSinhVien, dtThiLai, dtMonThiTotNghiep;
        private cBXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private KQHT_DangKyThiLaiInfo pKQHT_DangKyThiLaiInfo;
        private cBKQHT_DangKyThiLai oBKQHT_DangKyThiLai;
        private cBKQHT_DanhSachKhongThi oBKQHT_DanhSachKhongThi;
        private cBKQHT_MonThiTotNghiep_Lop oBKQHT_MonThiTotNghiep_Lop;
        private int IDDM_Lop;

        public frmDangKyThiLai()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
            oBKQHT_DangKyThiLai = new cBKQHT_DangKyThiLai();
            oBKQHT_DanhSachKhongThi = new cBKQHT_DanhSachKhongThi();
            pKQHT_DangKyThiLaiInfo = new KQHT_DangKyThiLaiInfo();
            oBKQHT_MonThiTotNghiep_Lop = new cBKQHT_MonThiTotNghiep_Lop();
        }

        private void frmDangKyThiLai_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            DM_LopInfo pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                IDDM_Lop = pDM_LopInfo.DM_LopID;
                LoadMonKy(IDDM_Lop);
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
                grdThiLai.DataSource = null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int Count = dtSinhVien.Rows.Count;
            for (int i = 0; i < Count; i++)
            {
                if ((bool)dtSinhVien.Rows[i]["Chon"])
                {
                    dtSinhVien.Rows[i]["Chon"] = false;
                    dtSinhVien.Rows[i]["TienLePhi"] = float.Parse("0" + txtLePhi.Text);                 
                    dtThiLai.ImportRow(dtSinhVien.Rows[i]);
                    dtSinhVien.Rows.Remove(dtSinhVien.Rows[i]);
                    Count = Count - 1;
                    i = i - 1;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int Count = dtThiLai.Rows.Count;
            for (int i = 0; i < Count; i++)
            {
                if ((bool)dtThiLai.Rows[i]["Chon"])
                {
                    dtThiLai.Rows[i]["Chon"] = false;
                    dtSinhVien.ImportRow(dtThiLai.Rows[i]);
                    dtThiLai.Rows.Remove(dtThiLai.Rows[i]);
                    Count = Count - 1;
                    i = i - 1;
                }
            }
        }

        private void cmbMonHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbMonHoc.EditValue != null)
            {
                LoadSinhVien();
            }
        }

        private void rdOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMonHoc.EditValue !=null)
                LoadSinhVien();
        }

        private void LoadSinhVien()
        {
            if (rdOption.EditValue.ToString() == "0")
            {
                dtSinhVien = oBKQHT_DangKyThiLai.GetSinhVien(IDDM_Lop, int.Parse(cmbMonHoc.EditValue.ToString()), Program.IDNamHoc, Program.HocKy, (chkTotNghiep.Checked== true?3:0), int.Parse(cmbLanThi.EditValue.ToString()));
                dtSinhVien.DefaultView.RowFilter = "Diem<5";
                grdSinhVien.DataSource = dtSinhVien.DefaultView;
            }
            else if (rdOption.EditValue.ToString() == "1")
            {
                dtSinhVien = oBKQHT_DangKyThiLai.GetSinhVien(IDDM_Lop, int.Parse(cmbMonHoc.EditValue.ToString()), Program.IDNamHoc, Program.HocKy, (chkTotNghiep.Checked == true ? 3 : 0), int.Parse(cmbLanThi.EditValue.ToString()));
                grdSinhVien.DataSource = dtSinhVien;
            }
            else
            {
                dtSinhVien = oBKQHT_DanhSachKhongThi.GetIn_SinhVien(IDDM_Lop, int.Parse(cmbMonHoc.EditValue.ToString()), Program.IDNamHoc, Program.HocKy, 1);
                grdSinhVien.DataSource = dtSinhVien;
            }
            dtThiLai = oBKQHT_DangKyThiLai.GetSinhVien(IDDM_Lop, int.Parse(cmbMonHoc.EditValue.ToString()), Program.IDNamHoc, Program.HocKy, 1, int.Parse(cmbLanThi.EditValue.ToString()));
            grdThiLai.DataSource = dtThiLai;
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (cmbMonHoc.EditValue != null)
            {
                try
                {
                    oBKQHT_DangKyThiLai.DeleteByMonHoc(IDDM_Lop, int.Parse(cmbMonHoc.EditValue.ToString()), Program.IDNamHoc, Program.HocKy,int.Parse(cmbLanThi.EditValue.ToString()));

                }
                catch
                {
                    // ERROR
                }

                foreach (DataRow dr in dtThiLai.Rows)
                {
                    try
                    {
                        pKQHT_DangKyThiLaiInfo.IDHT_User = Program.objUserCurrent.HT_UserID;
                        pKQHT_DangKyThiLaiInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                        pKQHT_DangKyThiLaiInfo.IDDM_MonHoc = int.Parse(cmbMonHoc.EditValue.ToString());
                        pKQHT_DangKyThiLaiInfo.IDDM_NamHoc = Program.IDNamHoc;
                        pKQHT_DangKyThiLaiInfo.HocKy = Program.HocKy;
                        pKQHT_DangKyThiLaiInfo.TienLePhi = float.Parse("0" + dr["TienLePhi"]);
                        pKQHT_DangKyThiLaiInfo.NgayDangKy = DateTime.Now;
                        pKQHT_DangKyThiLaiInfo.LanThi = int.Parse(cmbLanThi.EditValue.ToString());
                        oBKQHT_DangKyThiLai.Add(pKQHT_DangKyThiLaiInfo);
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
       
        private void grvSinhVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvThiLai_CustomDrawRowIndicator_1(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void cmbLanThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMonHoc.EditValue != null)
                LoadSinhVien();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdSinhVien_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvSinhVien, "Chon", e);
        }

        private void grvThiLai_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvThiLai, "Chon", e);
        }
        private void LoadMonThiTotNghiep()
        {
            dtMonThiTotNghiep = oBKQHT_MonThiTotNghiep_Lop.GetIn_Mon(IDDM_Lop);
            cmbMonHoc.Properties.DataSource = dtMonThiTotNghiep;
            if (dtMonThiTotNghiep.Rows.Count > 0)
            {
                cmbMonHoc.ItemIndex = 0;
                LoadSinhVien();
            }
            else
            {
                grdSinhVien.DataSource = null;
                grdThiLai.DataSource = null;
            }
        }

        private void chkTotNghiep_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTotNghiep.Checked == true)
            {
                LoadMonThiTotNghiep();
            }
            else
            {
                LoadMonKy(IDDM_Lop);
            }
        }

    }
}