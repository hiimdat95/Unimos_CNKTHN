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
    public partial class frmDangKyTuChon : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DataTable dtMonKy, dtSinhVien, dtTuChon;
        private cBXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private KQHT_DangKyMonChonInfo pKQHT_DangKyMonChonInfo;
        private cBKQHT_DangKyMonChon oBKQHT_DangKyMonChon;
        private int IDDM_Lop;

        public frmDangKyTuChon()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
            pKQHT_DangKyMonChonInfo = new KQHT_DangKyMonChonInfo();
            oBKQHT_DangKyMonChon = new cBKQHT_DangKyMonChon();
            txtHocKy.Text = Program.HocKy.ToString();
            txtNamHoc.Text = Program.NamHoc;
        }

        private void frmDangKyTuChon_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            DM_LopInfo pDM_LopInfo = uctrlLop.GetNodeSelected();
            if(pDM_LopInfo!=null)
            {
                IDDM_Lop = pDM_LopInfo.DM_LopID;
                LoadMonKy(IDDM_Lop, 1);
                btnCapNhat.Enabled = true;
            }
            else
            {
                btnCapNhat.Enabled = false;
            }
        }

        private void LoadMonKy(int IDDM_Lop, int TuChon)
        {
            dtMonKy = oBXL_MonHocTrongKy.GetByLop(IDDM_Lop, Program.IDNamHoc, Program.HocKy);
            if (dtMonKy != null)
            {
                DataTable dtTemp = new DataTable();
                dtTemp = dtMonKy.Copy();
                dtTemp.DefaultView.RowFilter = "TuChon =" + TuChon.ToString();
                cmbMonHoc.Properties.DataSource = dtTemp.DefaultView;
                if (dtTemp.DefaultView.Count > 0)
                    cmbMonHoc.ItemIndex = 0;
                else
                {
                    grdSinhVien.DataSource = null;
                    grdTuChon.DataSource = null;
                }
            }
        }

        private void chkTuChon_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTuChon.Checked)
                LoadMonKy(IDDM_Lop, 1);
            else
                LoadMonKy(IDDM_Lop, 0);
        }

        private void cmbMonHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbMonHoc.EditValue != null)
            {
                LoadSinhVien(int.Parse(cmbMonHoc.EditValue.ToString()));
            }
        }
        private void LoadSinhVien(int IDXL_MonHocTrongKy)
        {
            dtSinhVien = oBKQHT_DangKyMonChon.GetSinhVien(IDDM_Lop, IDXL_MonHocTrongKy, Program.IDNamHoc, Program.HocKy, 0);
            grdSinhVien.DataSource = dtSinhVien;
            dtTuChon = oBKQHT_DangKyMonChon.GetSinhVien(IDDM_Lop, IDXL_MonHocTrongKy, Program.IDNamHoc, Program.HocKy, 1);
            grdTuChon.DataSource = dtTuChon;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int Count = dtSinhVien.Rows.Count;
            for (int i = 0; i < Count; i++)
            {
                if ((bool)dtSinhVien.Rows[i]["Chon"])
                {
                    dtSinhVien.Rows[i]["Chon"] = false;
                    dtTuChon.ImportRow(dtSinhVien.Rows[i]);
                    dtSinhVien.Rows.Remove(dtSinhVien.Rows[i]);
                    Count = Count - 1;
                    i = i - 1;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int Count = dtTuChon.Rows.Count;
            for (int i = 0; i < Count; i++)
            {
                if ((bool)dtTuChon.Rows[i]["Chon"])
                {
                    dtTuChon.Rows[i]["Chon"] = false;
                    dtSinhVien.ImportRow(dtTuChon.Rows[i]);
                    dtTuChon.Rows.Remove(dtTuChon.Rows[i]);
                    Count = Count - 1;
                    i = i - 1;
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (cmbMonHoc.EditValue != null)
            {
                try
                {
                    pKQHT_DangKyMonChonInfo.IDXL_MonHocTrongKy = int.Parse(cmbMonHoc.EditValue.ToString());
                    oBKQHT_DangKyMonChon.DeleteByMonHoc(pKQHT_DangKyMonChonInfo);

                }
                catch
                {
                    // ERROR
                }
                foreach (DataRow dr in dtTuChon.Rows)
                {
                    try
                    {
                        pKQHT_DangKyMonChonInfo.IDHT_User = Program.objUserCurrent.HT_UserID;
                        pKQHT_DangKyMonChonInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                        pKQHT_DangKyMonChonInfo.IDXL_MonHocTrongKy = int.Parse(cmbMonHoc.EditValue.ToString());
                        oBKQHT_DangKyMonChon.Add(pKQHT_DangKyMonChonInfo);
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

        private void grvTuChon_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
    }
}