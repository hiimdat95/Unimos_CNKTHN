using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using TruongViet.UnimOs.wsBusiness;
using TruongViet.UnimOs.Entity;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace UnimOs.Khoa
{
    public partial class frmDinhMucGioGiangChoTungGiaoVien : frmBase
    {
        private cBwsNS_DonVi oBDonVi;
        private NS_DonViInfo pDonViInfo;
        private cBwsNS_GiaoVien oBGiaoVien;
        public NS_GiaoVienInfo pGiaoVienInfo;
        private cBwsGG_DinhMucGioDay oBGGDinhMucGioDay;
        private GG_DinhMucGioDayInfo pDinhMucGioDayInfo;
        private DataTable dtTree, dtGiaoVien;
        private bool Loaded = false;

        public frmDinhMucGioGiangChoTungGiaoVien()
        {
            InitializeComponent();
            oBGiaoVien = new cBwsNS_GiaoVien();
            pGiaoVienInfo = new NS_GiaoVienInfo();
            pDonViInfo = new NS_DonViInfo();
        }

        private void frmDanhSachGiaoVien_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            trvDonVi.FocusedNode = trvDonVi.FindNodeByFieldValue("NS_DonViID", 
                (new cBwsNS_DonVi()).GetByIDDM_Khoa(Program.objUserCurrent.IDDM_Khoa_GiaoVu));
            Loaded = true;
            trvDonVi_FocusedNodeChanged(null, null);
        }

        private void LoadGiaoVien(int IDDonVi)
        {
            pGiaoVienInfo.IDNS_DonVi = IDDonVi;
            dtGiaoVien = oBGiaoVien.GetByIDNS_DonVi_ChucDanh(IDDonVi, Program.IDNamHoc, Program.HocKy);
            grdGiaoVien.DataSource = dtGiaoVien;
            grvGiaoVien_FocusedRowChanged(null, null);
        }

        private void LoadTreeView()
        {
            oBDonVi = new cBwsNS_DonVi();
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
                    LoadGiaoVien(int.Parse(trvDonVi.FocusedNode["NS_DonViID"].ToString()));
                    pDonViInfo.NS_DonViID = int.Parse(trvDonVi.FocusedNode["NS_DonViID"].ToString());
                    pDonViInfo.MaDonVi = trvDonVi.FocusedNode["MaDonVi"].ToString();
                    pDonViInfo.TenDonVi = trvDonVi.FocusedNode["TenDonVi"].ToString();
                    pDonViInfo.ParentID = int.Parse(trvDonVi.FocusedNode["ParentID"].ToString());
                    pDonViInfo.Level = int.Parse(trvDonVi.FocusedNode["Level"].ToString());
                    pDonViInfo.IDDM_Khoa = int.Parse(trvDonVi.FocusedNode["IDDM_Khoa"].ToString());
                    pDonViInfo.IDDM_BoMon = int.Parse(trvDonVi.FocusedNode["IDDM_BoMon"].ToString());
                }
            }
        }

        private void grvGiaoVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

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
            if (dtGiaoVien.Rows.Count == 0) return;
            DataTable dtChange = dtGiaoVien.GetChanges();

            if (dtChange!=null)
            {
                oBGGDinhMucGioDay = new cBwsGG_DinhMucGioDay();
                pDinhMucGioDayInfo = new GG_DinhMucGioDayInfo();
                for (int i = 0; i < dtChange.Rows.Count; i++)
                {
                    pDinhMucGioDayInfo.IDNS_GiaoVien = int.Parse(dtChange.Rows[i]["NS_GiaoVienID"].ToString());                    
                    pDinhMucGioDayInfo.IDDM_NamHoc = Program.IDNamHoc;
                    pDinhMucGioDayInfo.HocKy = Program.HocKy;
                    if (dtChange.Rows[i]["SoGioDinhMuc"] + "" != "")
                    {
                        pDinhMucGioDayInfo.SoGioDinhMuc = double.Parse(dtChange.Rows[i]["SoGioDinhMuc"].ToString());
                    }
                    if (dtChange.Rows[i]["SoGioGiam"] + "" != "")
                    {
                        pDinhMucGioDayInfo.SoGioGiam = double.Parse(dtChange.Rows[i]["SoGioGiam"].ToString());
                    }
                    if (dtChange.Rows[i]["GG_DinhMucGioDayID"] + "" != "")
                    {
                        pDinhMucGioDayInfo.GG_DinhMucGioDayID = int.Parse(dtChange.Rows[i]["GG_DinhMucGioDayID"].ToString());
                        oBGGDinhMucGioDay.Update(pDinhMucGioDayInfo);
                    }
                    else
                        oBGGDinhMucGioDay.Add(pDinhMucGioDayInfo);
                }
                trvDonVi_FocusedNodeChanged(null, null);
            }
        }

        private void btnGioGiangTheoChucDanh_Click(object sender, EventArgs e)
        {
            cBwsGG_DinhMucTheoChucDanh oBGioGiangTheoChucDanh = new cBwsGG_DinhMucTheoChucDanh();
            DataTable dtGioGiangTheoChucDanh = oBGioGiangTheoChucDanh.Get();
            if(dtGioGiangTheoChucDanh.Rows.Count ==0) return;
            if(dtGiaoVien.Rows.Count ==0) return;
            for (int i = 0; i < dtGiaoVien.Rows.Count; i++ )
            {
                if (dtGiaoVien.Rows[i]["DM_ChucDanhID"] + "" != "")
                {
                    for (int j = 0; j < dtGioGiangTheoChucDanh.Rows.Count; j++)
                    {
                        if (dtGioGiangTheoChucDanh.Rows[j]["DM_ChucDanhID"] + "" != "")
                        {
                            if (dtGiaoVien.Rows[i]["DM_ChucDanhID"].ToString() == dtGioGiangTheoChucDanh.Rows[j]["DM_ChucDanhID"].ToString())
                            {
                                dtGiaoVien.Rows[i]["SoGioDinhMuc"] = dtGioGiangTheoChucDanh.Rows[j]["GioChuanGiang"];
                            }
                        }
                    }
                }
            }
            grdGiaoVien.RefreshDataSource();
        }
    }
}
