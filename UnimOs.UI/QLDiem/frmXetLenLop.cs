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
    public partial class frmXetLenLop : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private cBSV_SinhVien oBSV_SinhVien;
        private DataTable dtSinhVien;
        private cBKQHT_QuyChe oBKQHT_QuyChe;
        private cBDM_TrinhDo oBDM_TrinhDo;
        private DM_TrinhDoInfo pDM_TrinhDoInfo;
        private cBKQHT_DiemTongKetHocKy oBKQHT_DiemTongKetHocKy;
        public enum TrangThai { HocTiep = 0, NgungHoc = 1, ThoiHoc = 2 };

        public frmXetLenLop()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            oBSV_SinhVien = new cBSV_SinhVien();
            pDM_LopInfo = new DM_LopInfo();
            oBKQHT_DiemTongKetHocKy = new cBKQHT_DiemTongKetHocKy();
            pDM_TrinhDoInfo = new DM_TrinhDoInfo();
            oBDM_TrinhDo = new cBDM_TrinhDo();
        }

        private void frmXetLenLop_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
            repositoryTrangThai.DataSource = oBSV_SinhVien.CreateTableTrangThai();
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            LoadSinhVien_Lop();
        }

        private void LoadSinhVien_Lop()
        {
            dtSinhVien = oBSV_SinhVien.GetSinhVien_XetLenLop(pDM_LopInfo, Program.NamHoc, Program.IDNamHoc);
            grdSinhVien.DataSource = dtSinhVien;
        }

        private void grvSinhVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            if (dtSinhVien.Rows.Count > 0)
            {
                pDM_TrinhDoInfo.DM_TrinhDoID = pDM_LopInfo.IDDM_TrinhDo;
                DataTable dtTemp = oBDM_TrinhDo.Get(pDM_TrinhDoInfo);
                if (dtTemp.Rows.Count > 0)
                {
                    int IDKQHT_QuyChe = int.Parse(dtTemp.Rows[0]["IDKQHT_QuyChe"].ToString());
                    string MaQuyChe = dtTemp.Rows[0]["MaQuyChe"].ToString();
                    oBKQHT_QuyChe = new cBKQHT_QuyChe();
                    DataTable dtThamSo = oBKQHT_QuyChe.GetThamSo(IDKQHT_QuyChe);
                    if ( dtThamSo.Rows.Count >0)
                    {
                        float DiemTBNH = 0, HT_TBNH = 0, HT_SoDVHT = 0, TH_TBNH = 0, TH_TBNH2 = 0, TH_TBNH3 = 0, TH_TBNH4 = 0;
                        try
                        {
                            // Quy chế 25
                            // Get Tham so
                            DataRow[] dr = dtThamSo.Select("MaThamSo='HT_TBNH'");
                            if (dr.Length > 0)
                                HT_TBNH = float.Parse("0" + dr[0]["GiaTri"].ToString());
                            dr = dtThamSo.Select("MaThamSo='HT_DVHT'");
                            if (dr.Length > 0)
                                HT_SoDVHT = float.Parse("0" + dr[0]["GiaTri"].ToString());
                            dr = dtThamSo.Select("MaThamSo='TH_TBNH'");
                            if (dr.Length > 0)
                                TH_TBNH = float.Parse("0" + dr[0]["GiaTri"].ToString());
                            dr = dtThamSo.Select("MaThamSo='TH_TBNH2'");
                            if (dr.Length > 0)
                                TH_TBNH2 = float.Parse("0" + dr[0]["GiaTri"].ToString());
                            dr = dtThamSo.Select("MaThamSo='TH_TBNH3'");
                            if (dr.Length > 0)
                                TH_TBNH3 = float.Parse("0" + dr[0]["GiaTri"].ToString());
                            dr = dtThamSo.Select("MaThamSo='TH_TBNH4'");
                            if (dr.Length > 0)
                                TH_TBNH4 = float.Parse("0" + dr[0]["GiaTri"].ToString());

                            for (int i = 0; i < dtSinhVien.Rows.Count; i++)
                            {
                                if (dtSinhVien.Rows[i]["Diem"].ToString() == "")
                                {
                                    dtSinhVien.Rows[i]["GhiChu"] = "Chưa tổng kết điểm năm học";
                                }
                                else
                                {
                                    //xet hoc tiep
                                    DiemTBNH = float.Parse("0" + dtSinhVien.Rows[i]["Diem"].ToString());
                                    if (DiemTBNH >= HT_TBNH && float.Parse("0" + dtSinhVien.Rows[i]["SoHocTrinhNo"].ToString()) < HT_SoDVHT)
                                    {
                                        dtSinhVien.Rows[i]["TrangThai"] = 0;
                                        dtSinhVien.Rows[i]["GhiChu"] = "";
                                    }
                                        // thoi hoc
                                    else if (DiemTBNH < TH_TBNH)
                                    {
                                        dtSinhVien.Rows[i]["TrangThai"] = TRANGTHAISINHVIEN.THOIHOC;
                                        dtSinhVien.Rows[i]["GhiChu"] = "Điểm TBNH <" + TH_TBNH.ToString();
                                    }
                                    else if (DiemTBNH < TH_TBNH2 && int.Parse("0" + dtSinhVien.Rows[i]["NamHoc"].ToString()) == 2)
                                    {
                                        dtSinhVien.Rows[i]["TrangThai"] = TRANGTHAISINHVIEN.THOIHOC;
                                        dtSinhVien.Rows[i]["GhiChu"] = "Điểm TBNH thứ 2 <" + TH_TBNH2.ToString();
                                    }
                                    else if (DiemTBNH < TH_TBNH3 && int.Parse("0" + dtSinhVien.Rows[i]["NamHoc"].ToString()) == 3)
                                    {
                                        dtSinhVien.Rows[i]["TrangThai"] = TRANGTHAISINHVIEN.THOIHOC;
                                        dtSinhVien.Rows[i]["GhiChu"] = "Điểm TBNH  thứ 3<" + TH_TBNH3.ToString();
                                    }
                                    else if (DiemTBNH < TH_TBNH4 && int.Parse("0" + dtSinhVien.Rows[i]["NamHoc"].ToString()) >= 4)
                                    {
                                        dtSinhVien.Rows[i]["TrangThai"] = TRANGTHAISINHVIEN.THOIHOC;
                                        dtSinhVien.Rows[i]["GhiChu"] = "Điểm TBNH thứ 4 <" + TH_TBNH4.ToString();
                                    }
                                        // ngung hoc
                                    else
                                    {
                                        dtSinhVien.Rows[i]["TrangThai"] = TRANGTHAISINHVIEN.NGUNGHOC;
                                        if (DiemTBNH < HT_TBNH)
                                        {
                                            dtSinhVien.Rows[i]["GhiChu"] = "Điểm TBNH dưới mức cho phép";
                                        }
                                        else
                                            dtSinhVien.Rows[i]["GhiChu"] = "Số đơn vị học trình nợ vượt quá giới hạn";
                                    }
                                }
                            }
                        }
                        catch
                        {
                            ThongBao("Có lỗi trong quá trình xử lý!");
                        }
                    }
                    else
                        ThongBao("Quy chế chưa có tham số!");
                }
            }
        }


        private void btnCapNhat_Click_1(object sender, EventArgs e)
        {
            DataTable dtTemp = dtSinhVien.GetChanges();
            if (dtTemp != null)
            {
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    try
                    {
                        oBKQHT_DiemTongKetHocKy.UpdateTrangThai(int.Parse(dtSinhVien.Rows[i]["SV_SinhVienID"].ToString()), Program.IDNamHoc, Program.HocKy, int.Parse(dtSinhVien.Rows[i]["TrangThai"].ToString()), dtSinhVien.Rows[i]["GhiChu"].ToString());
                    }
                    catch (Exception exp)
                    {
                        ThongBao(exp.Message);
                    }
                }
                ThongBao("Lưu thông tin thành công!");
            }
        }

        private void grvSinhVien_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvSinhVien, "Chon", e);
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}