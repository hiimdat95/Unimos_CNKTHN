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
    public partial class frmDinhMucTheoChucDanh : frmBase
    {
        cBGG_DinhMucTheoChucDanh oBGG_DinhMucTheoChucDanh = new cBGG_DinhMucTheoChucDanh();
        GG_DinhMucTheoChucDanhInfo Info;
        public frmDinhMucTheoChucDanh()
        {
            InitializeComponent();
            LoadData();
        
        }

        private void LoadData()
        {
            grdDinhMucTheoChucDanh.DataSource = oBGG_DinhMucTheoChucDanh.Get();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Info = new GG_DinhMucTheoChucDanhInfo();
            dlgDinhMucTheoChucDanh dlg = new dlgDinhMucTheoChucDanh(Info,"");
            if (dlg.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (grvDinhMucTheoChucDanh.FocusedRowHandle >= 0)
            {
                dlgDinhMucTheoChucDanh dlg = new dlgDinhMucTheoChucDanh(GetInfo(), grvDinhMucTheoChucDanh.GetDataRow(grvDinhMucTheoChucDanh.FocusedRowHandle)["TenChucDanh"].ToString());
                if (dlg.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private GG_DinhMucTheoChucDanhInfo GetInfo()
        { 
            Info = new GG_DinhMucTheoChucDanhInfo();
            DataRow dr = grvDinhMucTheoChucDanh.GetDataRow(grvDinhMucTheoChucDanh.FocusedRowHandle);
            Info.GG_DinhMucTheoChucDanhID = (int)dr["GG_DinhMucTheoChucDanhID"];
            Info.IDDM_ChucDanh = (int)dr["IDDM_ChucDanh"];
            Info.GioChuanGiang = (double)dr["GioChuanGiang"];
            Info.GioLamViec = (double)dr["GioLamViec"];
            Info.HeSo = (double)dr["HeSo"];
            Info.HeSoGioChuan = (double)dr["HeSoGioChuan"];
            return Info;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
    }
}
