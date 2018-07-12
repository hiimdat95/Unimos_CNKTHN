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
    public partial class dlgHoiDongThemSinhVien : frmBase
    {
        private cBSV_SinhVien oBSV_SinhVien;       
        private int IDKQHT_HoiDongMon, IDDM_MonHoc;
        private DataTable dtSinhVien,dtData;
        private cBKQHT_HoiDongMon_SinhVien oBKQHT_HoiDongMon_SinhVien;
        private KQHT_HoiDongMon_SinhVienInfo pKQHT_HoiDongMon_SinhVienInfo;

        public dlgHoiDongThemSinhVien(int mIDKQHT_HoiDongMon, DataTable mdtSinhVien, int mIDDM_MonHoc)
        {
            InitializeComponent();            
            oBSV_SinhVien = new cBSV_SinhVien();
            pKQHT_HoiDongMon_SinhVienInfo = new KQHT_HoiDongMon_SinhVienInfo();
            oBKQHT_HoiDongMon_SinhVien = new cBKQHT_HoiDongMon_SinhVien();
            dtSinhVien = mdtSinhVien;
            IDKQHT_HoiDongMon = mIDKQHT_HoiDongMon;
            IDDM_MonHoc = mIDDM_MonHoc;
        }

        private void dlgHoiDongThemSinhVien_Load(object sender, EventArgs e)
        {
            cBDM_Lop oBDM_Lop = new cBDM_Lop();
            grdDSLop.DataSource = oBDM_Lop.GetTree(Program.NamHoc);            
        }

        private void grvDSLop_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                dtData = oBSV_SinhVien.GetByLop_Mon(int.Parse(grvDSLop.GetDataRow(e.FocusedRowHandle)["DM_LopID"].ToString()), IDDM_MonHoc, Program.IDNamHoc, Program.HocKy, IDKQHT_HoiDongMon);
                if (dtData != null && dtData.Rows.Count == 0)
                {
                    dtData = oBKQHT_HoiDongMon_SinhVien.GetByThiTotNghiep(int.Parse(grvDSLop.GetDataRow(e.FocusedRowHandle)["DM_LopID"].ToString()), IDDM_MonHoc, Program.IDNamHoc, Program.HocKy, IDKQHT_HoiDongMon);
                }
                grdSinhVien.DataSource = dtData;
                dtData.AcceptChanges();
                if (dtData.Rows.Count > 0)
                    btnThem.Enabled = true;
                else
                    btnThem.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if ((dtData != null) && (dtData.Rows.Count >0))
            {
                int KQHT_HoiDongMon_SinhVienID = 0;
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    if ((bool)(dtData.Rows[i]["Chon"]))
                    {
                        pKQHT_HoiDongMon_SinhVienInfo.IDKQHT_HoiDongMon = IDKQHT_HoiDongMon;
                        pKQHT_HoiDongMon_SinhVienInfo.IDSV_SinhVien = int.Parse(dtData.Rows[i]["SV_SinhVienID"].ToString());
                        KQHT_HoiDongMon_SinhVienID = oBKQHT_HoiDongMon_SinhVien.Add(pKQHT_HoiDongMon_SinhVienInfo);
                        dtData.Rows[i]["Chon"] = false;
                        dtData.Rows[i]["KQHT_HoiDongMon_SinhVienID"] = KQHT_HoiDongMon_SinhVienID;
                        dtSinhVien.ImportRow(dtData.Rows[i]);
                        dtData.Rows.Remove(dtData.Rows[i]);
                        i--;
                    }
                }
               
            }
            else
                ThongBao("Bạn phải chọn ít nhất một sinh viên!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvSinhVien_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvSinhVien, "Chon", e);
        }
    }
}