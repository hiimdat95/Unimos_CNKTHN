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
using DevExpress.XtraGrid.Views.BandedGrid;

namespace UnimOs.UI
{
    public partial class frmChuongTrinhDaoTao : frmBase
    {
        private cBKQHT_ChuongTrinhDaoTao oBKQHT_ChuongTrinhDaoTao;
        private KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo;
        private cBKQHT_CTDT_ChiTiet oBKQHT_CTDT_ChiTiet;
        private KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTiet;
        private DataTable dtMonHoc, dtLopHoc;
        cBKQHT_CTDT_Lop oBKQHT_CTDT_Lop;
        KQHT_CTDT_LopInfo pKQHT_CTDT_LopInfo;
        private int SoHocKy = 0;

        public frmChuongTrinhDaoTao()
        {
            InitializeComponent();
            oBKQHT_ChuongTrinhDaoTao = new cBKQHT_ChuongTrinhDaoTao();
            pKQHT_ChuongTrinhDaoTaoInfo = new KQHT_ChuongTrinhDaoTaoInfo();
            oBKQHT_CTDT_ChiTiet = new cBKQHT_CTDT_ChiTiet();
            pKQHT_CTDT_LopInfo = new KQHT_CTDT_LopInfo();
            oBKQHT_CTDT_Lop = new cBKQHT_CTDT_Lop();
            SetButton(false);
        }

        private void frmChuongTrinhDaoTao_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            LoadCTDT();
        }

        private void LoadCTDT()
        {
            grdCTKhung.DataSource = oBKQHT_ChuongTrinhDaoTao.GetDanhSach(0);
        }

        private void LoadLopThuocCTDT()
        {
            dtLopHoc = oBKQHT_ChuongTrinhDaoTao.GetLop(pKQHT_ChuongTrinhDaoTaoInfo.KQHT_ChuongTrinhDaoTaoID);
            grdLop.DataSource = dtLopHoc;
        }

        private void SetButton(bool status)
        {
            barbtnSua.Enabled = status;
            barbtnThemKeThua.Enabled = status;
            barbtnXoa.Enabled = status;
            btnThemCT.Enabled = status;
            btnXoaCT.Enabled = status;
            btnCapNhat.Enabled = status;
            btnThemLop.Enabled = status;
            btnXoaLop.Enabled = status;
        }

        private DataTable CreateTable(int TuKy, int DenKy)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Chon", typeof(bool));
            dt.Columns.Add("TenKhoiKienThuc", typeof(string));
            dt.Columns.Add("IDKQHT_MonHoc_CT_KhoiKienThuc", typeof(int));
            dt.Columns.Add("IDDM_MonHoc", typeof(int));
            dt.Columns.Add("MaMonHoc", typeof(string));
            dt.Columns.Add("TenMonHoc", typeof(string));
            dt.Columns.Add("SHT", typeof(int));
            dt.Columns.Add("LT", typeof(int));
            dt.Columns.Add("TH", typeof(int));
            for (int i = TuKy; i <= DenKy; i++)
            {
                dt.Columns.Add("ID" + i.ToString(), typeof(int));
                dt.Columns.Add("SHT" + i.ToString(), typeof(float));
                dt.Columns.Add("LT" + i.ToString(), typeof(int));
                dt.Columns.Add("TH" + i.ToString(), typeof(int));
            }

            return dt;
        }

        private void LoadCTDTChiTiet(int IDKQHT_ChuongTrinhDaoTao, int SoHocKy)
        {
            dtMonHoc = CreateTable(1, SoHocKy);
            DataTable dt = oBKQHT_ChuongTrinhDaoTao.GetChiTiet(IDKQHT_ChuongTrinhDaoTao);
            if (dt.Rows.Count > 0)
            {
                string IDDM_MonHoc = dt.Rows[0]["IDDM_MonHoc"].ToString();
                DataRow drNew = dtMonHoc.NewRow();
                drNew["Chon"] = false;
                drNew["TenKhoiKienThuc"] = dt.Rows[0]["TenKhoiKienThuc"].ToString();
                drNew["IDKQHT_MonHoc_CT_KhoiKienThuc"] = int.Parse(dt.Rows[0]["KQHT_MonHoc_CT_KhoiKienThucID"].ToString());
                drNew["IDDM_Monhoc"] = int.Parse(IDDM_MonHoc);
                drNew["MaMonHoc"] = dt.Rows[0]["MaMonHoc"].ToString();
                drNew["TenMonHoc"] = dt.Rows[0]["TenMonHoc"].ToString();
                drNew["SHT"] = float.Parse(dt.Rows[0]["SHT"].ToString());
                drNew["LT"] = int.Parse(dt.Rows[0]["LT"].ToString());
                drNew["TH"] = int.Parse(dt.Rows[0]["TH"].ToString());
                foreach (DataRow dr in dt.Rows)
                {
                    if (IDDM_MonHoc != dr["IDDM_MonHoc"].ToString())
                    {
                        dtMonHoc.Rows.Add(drNew);
                        IDDM_MonHoc = dr["IDDM_MonHoc"].ToString();
                        drNew = dtMonHoc.NewRow();
                        drNew["Chon"] = false;
                        drNew["TenKhoiKienThuc"] = dr["TenKhoiKienThuc"].ToString();
                        drNew["IDKQHT_MonHoc_CT_KhoiKienThuc"] = int.Parse(dr["KQHT_MonHoc_CT_KhoiKienThucID"].ToString());
                        drNew["IDDM_Monhoc"] = int.Parse(IDDM_MonHoc);
                        drNew["MaMonHoc"] = dr["MaMonHoc"].ToString();
                        drNew["TenMonHoc"] = dr["TenMonHoc"].ToString();
                        drNew["SHT"] = float.Parse(dr["SHT"].ToString());
                        drNew["LT"] = int.Parse(dr["LT"].ToString());
                        drNew["TH"] = int.Parse(dr["TH"].ToString());

                        if (int.Parse("0" + dr["HocKy"]) > 0)
                        {
                            try
                            {
                                drNew["ID" + dr["HocKy"].ToString()] = int.Parse(dr["KQHT_CTDT_ChiTietID"].ToString());
                                drNew["SHT" + dr["HocKy"].ToString()] = float.Parse(dr["SoHocTrinh"].ToString());
                                drNew["LT" + dr["HocKy"].ToString()] = int.Parse(dr["LyThuyet"].ToString());
                                drNew["TH" + dr["HocKy"].ToString()] = int.Parse(dr["ThucHanh"].ToString());
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        if (int.Parse("0" + dr["HocKy"]) > 0)
                        {
                            try
                            {
                                drNew["ID" + dr["HocKy"].ToString()] = int.Parse(dr["KQHT_CTDT_ChiTietID"].ToString());
                                drNew["SHT" + dr["HocKy"].ToString()] = float.Parse(dr["SoHocTrinh"].ToString());
                                drNew["LT" + dr["HocKy"].ToString()] = int.Parse(dr["LyThuyet"].ToString());
                                drNew["TH" + dr["HocKy"].ToString()] = int.Parse(dr["ThucHanh"].ToString());
                            }catch {}
                        }
                    }
                }
                dtMonHoc.Rows.Add(drNew);
            }
            dtMonHoc.AcceptChanges();
            grdMonHoc.DataSource = dtMonHoc;
        }

        #region Tạo các cột trên grid
        private void AddBands(int TuKy, int DenKy)
        {
            grbMonHoc.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            if (TuKy <= 2 && DenKy >= 1)
            {
                // Add band cho năm thứ 1
                GridBand grbNam1 = new GridBand();
                grvMonHoc.Bands.AddRange(new GridBand[] { grbNam1 });
                SetBandCaption(grbNam1, "Năm thứ 1", 220);

                if (TuKy >= 1)
                {
                    GridBand grbKy1 = new GridBand();
                    grbNam1.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
                grbKy1});
                    SetBandCaption(grbKy1, "Kỳ 1", 110);

                    BandedGridColumn bgcSHT1 = new BandedGridColumn();
                    BandedGridColumn bgcLT1 = new BandedGridColumn();
                    BandedGridColumn bgcTH1 = new BandedGridColumn();

                    grbKy1.Columns.Add(bgcSHT1);
                    SetColumnBandCaption(bgcSHT1, "SHT", "SHT1", 40, DevExpress.Utils.HorzAlignment.Default, false);
                    grbKy1.Columns.Add(bgcLT1);
                    SetColumnBandCaption(bgcLT1, "LT", "LT1", 35, DevExpress.Utils.HorzAlignment.Default, false);
                    grbKy1.Columns.Add(bgcTH1);
                    SetColumnBandCaption(bgcTH1, "TH", "TH1", 35, DevExpress.Utils.HorzAlignment.Default, false);
                    grvMonHoc.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgcSHT1, bgcLT1, bgcTH1 });
                }
                if (DenKy >= 2)
                {
                    GridBand grbKy2 = new GridBand();
                    grbNam1.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            grbKy2});
                    SetBandCaption(grbKy2, "Kỳ 2", 110);

                    BandedGridColumn bgcSHT2 = new BandedGridColumn();
                    BandedGridColumn bgcLT2 = new BandedGridColumn();
                    BandedGridColumn bgcTH2 = new BandedGridColumn();

                    grbKy2.Columns.Add(bgcSHT2);
                    grbKy2.Columns.Add(bgcLT2);
                    grbKy2.Columns.Add(bgcTH2);

                    SetColumnBandCaption(bgcSHT2, "SHT", "SHT2", 40, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcLT2, "LT", "LT2", 35, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcTH2, "TH", "TH2", 35, DevExpress.Utils.HorzAlignment.Default, false);

                    grvMonHoc.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgcSHT2, bgcLT2, bgcTH2 });
                }
            }

            if (TuKy <= 4 && DenKy >= 3)
            {
                // Add band cho năm thứ 2
                GridBand grbNam2 = new GridBand();

                grvMonHoc.Bands.AddRange(new GridBand[] { grbNam2 });
                SetBandCaption(grbNam2, "Năm thứ 2", 220);

                if (TuKy <= 3)
                {
                    GridBand grbKy3 = new GridBand();
                    grbNam2.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
                grbKy3});
                    SetBandCaption(grbKy3, "Kỳ 3", 110);
                    BandedGridColumn bgcSHT3 = new BandedGridColumn();
                    BandedGridColumn bgcLT3 = new BandedGridColumn();
                    BandedGridColumn bgcTH3 = new BandedGridColumn();

                    grbKy3.Columns.Add(bgcSHT3);
                    grbKy3.Columns.Add(bgcLT3);
                    grbKy3.Columns.Add(bgcTH3);

                    SetColumnBandCaption(bgcSHT3, "SHT", "SHT3", 40, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcLT3, "LT", "LT3", 35, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcTH3, "TH", "TH3", 35, DevExpress.Utils.HorzAlignment.Default, false);

                    grvMonHoc.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgcSHT3, bgcLT3, bgcTH3 });
                }
                if (DenKy >= 4)
                {
                    GridBand grbKy4 = new GridBand();
                    grbNam2.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
                grbKy4});
                    SetBandCaption(grbKy4, "Kỳ 4", 110);
                    BandedGridColumn bgcSHT4 = new BandedGridColumn();
                    BandedGridColumn bgcLT4 = new BandedGridColumn();
                    BandedGridColumn bgcTH4 = new BandedGridColumn();

                    grbKy4.Columns.Add(bgcSHT4);
                    grbKy4.Columns.Add(bgcLT4);
                    grbKy4.Columns.Add(bgcTH4);

                    SetColumnBandCaption(bgcSHT4, "SHT", "SHT4", 40, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcLT4, "LT", "LT4", 35, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcTH4, "TH", "TH4", 35, DevExpress.Utils.HorzAlignment.Default, false);

                    grvMonHoc.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgcSHT4, bgcLT4, bgcTH4 });
                }
            }

            if (TuKy <= 6 && DenKy >= 5)
            {
                // Add band cho năm thứ 3
                GridBand grbNam3 = new GridBand();
                grvMonHoc.Bands.AddRange(new GridBand[] { grbNam3 });
                SetBandCaption(grbNam3, "Năm thứ 3", 220);

                if (TuKy <= 5)
                {
                    GridBand grbKy5 = new GridBand();
                    grbNam3.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            grbKy5});
                    SetBandCaption(grbKy5, "Kỳ 5", 110);

                    BandedGridColumn bgcSHT5 = new BandedGridColumn();
                    BandedGridColumn bgcLT5 = new BandedGridColumn();
                    BandedGridColumn bgcTH5 = new BandedGridColumn();

                    grbKy5.Columns.Add(bgcSHT5);
                    grbKy5.Columns.Add(bgcLT5);
                    grbKy5.Columns.Add(bgcTH5);

                    SetColumnBandCaption(bgcSHT5, "SHT", "SHT5", 40, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcLT5, "LT", "LT5", 35, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcTH5, "TH", "TH5", 35, DevExpress.Utils.HorzAlignment.Default, false);
                    grvMonHoc.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgcSHT5, bgcLT5, bgcTH5 });
                }
                if (DenKy >= 6)
                {
                    GridBand grbKy6 = new GridBand();
                    grbNam3.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            grbKy6});
                    SetBandCaption(grbKy6, "Kỳ 6", 110);
                    BandedGridColumn bgcSHT6 = new BandedGridColumn();
                    BandedGridColumn bgcLT6 = new BandedGridColumn();
                    BandedGridColumn bgcTH6 = new BandedGridColumn();

                    grbKy6.Columns.Add(bgcSHT6);
                    grbKy6.Columns.Add(bgcLT6);
                    grbKy6.Columns.Add(bgcTH6);

                    SetColumnBandCaption(bgcSHT6, "SHT", "SHT6", 40, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcLT6, "LT", "LT6", 35, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcTH6, "TH", "TH6", 35, DevExpress.Utils.HorzAlignment.Default, false);

                    grvMonHoc.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgcSHT6, bgcLT6, bgcTH6 });
                }
            }

            if (TuKy <= 8 && DenKy >= 7)
            {
                // Add band cho năm thứ 4
                GridBand grbNam4 = new GridBand();

                grvMonHoc.Bands.AddRange(new GridBand[] { grbNam4 });
                SetBandCaption(grbNam4, "Năm thứ 4", 220);
                if (TuKy <= 7)
                {
                    GridBand grbKy7 = new GridBand();
                    grbNam4.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            grbKy7});
                    SetBandCaption(grbKy7, "Kỳ 7", 110);
                    BandedGridColumn bgcSHT7 = new BandedGridColumn();
                    BandedGridColumn bgcLT7 = new BandedGridColumn();
                    BandedGridColumn bgcTH7 = new BandedGridColumn();

                    grbKy7.Columns.Add(bgcSHT7);
                    grbKy7.Columns.Add(bgcLT7);
                    grbKy7.Columns.Add(bgcTH7);

                    SetColumnBandCaption(bgcSHT7, "SHT", "SHT7", 40, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcLT7, "LT", "LT7", 35, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcTH7, "TH", "TH7", 35, DevExpress.Utils.HorzAlignment.Default, false);
                    grvMonHoc.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgcSHT7, bgcLT7, bgcTH7 });
                }
                if (DenKy >= 8)
                {
                    GridBand grbKy8 = new GridBand();
                    grbNam4.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            grbKy8});
                    SetBandCaption(grbKy8, "Kỳ 8", 110);
                    BandedGridColumn bgcSHT8 = new BandedGridColumn();
                    BandedGridColumn bgcLT8 = new BandedGridColumn();
                    BandedGridColumn bgcTH8 = new BandedGridColumn();

                    grbKy8.Columns.Add(bgcSHT8);
                    grbKy8.Columns.Add(bgcLT8);
                    grbKy8.Columns.Add(bgcTH8);

                    SetColumnBandCaption(bgcSHT8, "SHT", "SHT8", 40, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcLT8, "LT", "LT8", 35, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcTH8, "TH", "TH8", 35, DevExpress.Utils.HorzAlignment.Default, false);

                    grvMonHoc.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgcSHT8, bgcLT8, bgcTH8 });
                }
            }

            if (TuKy <= 10 && DenKy >= 9)
            {
                // Add band cho năm thứ 5
                GridBand grbNam5 = new GridBand();

                grvMonHoc.Bands.AddRange(new GridBand[] { grbNam5 });
                SetBandCaption(grbNam5, "Năm thứ 5", 220);
                if (TuKy <= 9)
                {
                    GridBand grbKy9 = new GridBand();
                    grbNam5.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            grbKy9});
                    SetBandCaption(grbKy9, "Kỳ 9", 110);

                    BandedGridColumn bgcSHT9 = new BandedGridColumn();
                    BandedGridColumn bgcLT9 = new BandedGridColumn();
                    BandedGridColumn bgcTH9 = new BandedGridColumn();

                    grbKy9.Columns.Add(bgcSHT9);
                    grbKy9.Columns.Add(bgcLT9);
                    grbKy9.Columns.Add(bgcTH9);

                    SetColumnBandCaption(bgcSHT9, "SHT", "SHT9", 40, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcLT9, "LT", "LT9", 35, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcTH9, "TH", "TH9", 35, DevExpress.Utils.HorzAlignment.Default, false);

                    grvMonHoc.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgcSHT9, bgcLT9, bgcTH9 });
                }
                if (DenKy >= 10)
                {
                    GridBand grbKy10 = new GridBand();
                    grbNam5.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            grbKy10});
                    SetBandCaption(grbKy10, "Kỳ 10", 110);

                    BandedGridColumn bgcSHT10 = new BandedGridColumn();
                    BandedGridColumn bgcLT10 = new BandedGridColumn();
                    BandedGridColumn bgcTH10 = new BandedGridColumn();

                    grbKy10.Columns.Add(bgcSHT10);
                    grbKy10.Columns.Add(bgcLT10);
                    grbKy10.Columns.Add(bgcTH10);

                    SetColumnBandCaption(bgcSHT10, "SHT", "SHT10", 40, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcLT10, "LT", "LT10", 35, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcTH10, "TH", "TH10", 35, DevExpress.Utils.HorzAlignment.Default, false);

                    grvMonHoc.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgcSHT10, bgcLT10, bgcTH10 });
                }
            }

            if (TuKy <= 12 && DenKy >= 11)
            {
                // Add band cho năm thứ 6
                GridBand grbNam6 = new GridBand();

                grvMonHoc.Bands.AddRange(new GridBand[] { grbNam6 });
                SetBandCaption(grbNam6, "Năm thứ 6", 220);
                if (TuKy <= 11)
                {
                    GridBand grbKy11 = new GridBand();
                    grbNam6.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            grbKy11});
                    SetBandCaption(grbKy11, "Kỳ 11", 110);

                    BandedGridColumn bgcSHT11 = new BandedGridColumn();
                    BandedGridColumn bgcLT11 = new BandedGridColumn();
                    BandedGridColumn bgcTH11 = new BandedGridColumn();

                    grbKy11.Columns.Add(bgcSHT11);
                    grbKy11.Columns.Add(bgcLT11);
                    grbKy11.Columns.Add(bgcTH11);

                    SetColumnBandCaption(bgcSHT11, "SHT", "SHT11", 40, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcLT11, "LT", "LT11", 35, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcTH11, "TH", "TH11", 35, DevExpress.Utils.HorzAlignment.Default, false);

                    grvMonHoc.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgcSHT11, bgcLT11, bgcTH11 });
                }
                if (DenKy >= 12)
                {
                    GridBand grbKy12 = new GridBand();
                    grbNam6.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            grbKy12});
                    SetBandCaption(grbKy12, "Kỳ 12", 110);

                    BandedGridColumn bgcSHT12 = new BandedGridColumn();
                    BandedGridColumn bgcLT12 = new BandedGridColumn();
                    BandedGridColumn bgcTH12 = new BandedGridColumn();

                    grbKy12.Columns.Add(bgcSHT12);
                    grbKy12.Columns.Add(bgcLT12);
                    grbKy12.Columns.Add(bgcTH12);

                    SetColumnBandCaption(bgcSHT12, "SHT", "SHT12", 40, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcLT12, "LT", "LT12", 35, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcTH12, "TH", "TH12", 35, DevExpress.Utils.HorzAlignment.Default, false);

                    grvMonHoc.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgcSHT12, bgcLT12, bgcTH12 });
                }
            }

            if (TuKy <= 14 && DenKy >= 13)
            {
                // Add band cho năm thứ 7
                GridBand grbNam7 = new GridBand();

                grvMonHoc.Bands.AddRange(new GridBand[] { grbNam7 });
                SetBandCaption(grbNam7, "Năm thứ 7", 220);
                if (TuKy <= 13)
                {
                    GridBand grbKy13 = new GridBand();
                    grbNam7.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            grbKy13});
                    SetBandCaption(grbKy13, "Kỳ 13", 110);

                    BandedGridColumn bgcSHT13 = new BandedGridColumn();
                    BandedGridColumn bgcLT13 = new BandedGridColumn();
                    BandedGridColumn bgcTH13 = new BandedGridColumn();

                    grbKy13.Columns.Add(bgcSHT13);
                    grbKy13.Columns.Add(bgcLT13);
                    grbKy13.Columns.Add(bgcTH13);

                    SetColumnBandCaption(bgcSHT13, "SHT", "SHT13", 40, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcLT13, "LT", "LT13", 35, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcTH13, "TH", "TH13", 35, DevExpress.Utils.HorzAlignment.Default, false);

                    grvMonHoc.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgcSHT13, bgcLT13, bgcTH13 });
                }
                if (DenKy >= 14)
                {
                    GridBand grbKy14 = new GridBand();
                    grbNam7.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            grbKy14});
                    SetBandCaption(grbKy14, "Kỳ 14", 110);

                    BandedGridColumn bgcSHT14 = new BandedGridColumn();
                    BandedGridColumn bgcLT14 = new BandedGridColumn();
                    BandedGridColumn bgcTH14 = new BandedGridColumn();

                    grbKy14.Columns.Add(bgcSHT14);
                    grbKy14.Columns.Add(bgcLT14);
                    grbKy14.Columns.Add(bgcTH14);

                    SetColumnBandCaption(bgcSHT14, "SHT", "SHT14", 40, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcLT14, "LT", "LT14", 35, DevExpress.Utils.HorzAlignment.Default, false);
                    SetColumnBandCaption(bgcTH14, "TH", "TH14", 35, DevExpress.Utils.HorzAlignment.Default, false);

                    grvMonHoc.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgcSHT14, bgcLT14, bgcTH14 });
                }
            }
        }
        #endregion

        private void grvCTKhung_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvCTKhung.DataRowCount > 0)
            {
                if (grvCTKhung.FocusedRowHandle >= 0)
                {
                    DataRow dr = grvCTKhung.GetDataRow(grvCTKhung.FocusedRowHandle);
                    pKQHT_ChuongTrinhDaoTaoInfo.KQHT_ChuongTrinhDaoTaoID = int.Parse(dr[pKQHT_ChuongTrinhDaoTaoInfo.strKQHT_ChuongTrinhDaoTaoID].ToString());
                    pKQHT_ChuongTrinhDaoTaoInfo.MaChuongTrinhDaoTao = dr[pKQHT_ChuongTrinhDaoTaoInfo.strMaChuongTrinhDaoTao].ToString();
                    pKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao = dr[pKQHT_ChuongTrinhDaoTaoInfo.strTenChuongTrinhDaoTao].ToString();
                    pKQHT_ChuongTrinhDaoTaoInfo.IDDM_TrinhDo = int.Parse(dr[pKQHT_ChuongTrinhDaoTaoInfo.strIDDM_TrinhDo].ToString());
                    pKQHT_ChuongTrinhDaoTaoInfo.IDDM_KhoaHoc = int.Parse(dr[pKQHT_ChuongTrinhDaoTaoInfo.strIDDM_KhoaHoc].ToString());
                    pKQHT_ChuongTrinhDaoTaoInfo.IDDM_Nganh = int.Parse(dr[pKQHT_ChuongTrinhDaoTaoInfo.strIDDM_Nganh].ToString());
                    pKQHT_ChuongTrinhDaoTaoInfo.IDDM_ChuyenNganh = int.Parse(dr[pKQHT_ChuongTrinhDaoTaoInfo.strIDDM_ChuyenNganh].ToString());
                    pKQHT_ChuongTrinhDaoTaoInfo.ChuongTrinhDaoTaoSo = int.Parse(dr[pKQHT_ChuongTrinhDaoTaoInfo.strChuongTrinhDaoTaoSo].ToString());
                    pKQHT_ChuongTrinhDaoTaoInfo.SoHocKy = int.Parse(dr[pKQHT_ChuongTrinhDaoTaoInfo.strSoHocKy].ToString());
                    pKQHT_ChuongTrinhDaoTaoInfo.MoTa = dr[pKQHT_ChuongTrinhDaoTaoInfo.strMoTa].ToString();

                    SetButton(true);
                    LoadLopThuocCTDT();
                    lblCTDT.Text = "Tên CTĐT: " + pKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao;
                    // Load danh sách chi tiết các môn của chương trình khung
                    if (pKQHT_ChuongTrinhDaoTaoInfo.SoHocKy != SoHocKy)
                    {
                        for (int i = grvMonHoc.Bands.Count - 1; i >= 2; i--)
                        {
                            grvMonHoc.Bands.RemoveAt(i);
                        }
                        AddBands(1, pKQHT_ChuongTrinhDaoTaoInfo.SoHocKy);
                        SoHocKy = pKQHT_ChuongTrinhDaoTaoInfo.SoHocKy;
                    }
                    LoadCTDTChiTiet(pKQHT_ChuongTrinhDaoTaoInfo.KQHT_ChuongTrinhDaoTaoID, pKQHT_ChuongTrinhDaoTaoInfo.SoHocKy);
                }
                else
                {
                    grdLop.DataSource = null;
                    grdMonHoc.DataSource = null;
                    SetButton(false);
                }
            }
        }

        private void barbtnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgChuongTrinhDaoTao dlg = new dlgChuongTrinhDaoTao(pKQHT_ChuongTrinhDaoTaoInfo, EDIT_MODE.THEM);
            dlg.ShowDialog();
            if (dlg.Tag.ToString() == "1")
            {
                try
                {
                    pKQHT_ChuongTrinhDaoTaoInfo = dlg.pKQHT_ChuongTrinhDaoTaoInfo;
                    int KQHT_ChuongTrinhDaoTaoID  = oBKQHT_ChuongTrinhDaoTao.Add(pKQHT_ChuongTrinhDaoTaoInfo);
                    // ghi log
                    GhiLog("Thêm chương trình đào tạo '" + pKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao + "'", "Thêm", this.Tag.ToString());
                    LoadCTDT();
                    dlgChonCTKhoiKienThuc dlgKienThuc = new dlgChonCTKhoiKienThuc(KQHT_ChuongTrinhDaoTaoID);
                    dlgKienThuc.ShowDialog();
                    ThemThanhCong();
                }
                catch (Exception ex)
                {
                    ThongBao(ex.Message);
                }
            }
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            dlgChonCTKhoiKienThuc dlg = new dlgChonCTKhoiKienThuc(pKQHT_ChuongTrinhDaoTaoInfo.KQHT_ChuongTrinhDaoTaoID);
            dlg.ShowDialog();
            if (dlg.Tag.ToString() == "1")
            {
                LoadCTDTChiTiet(pKQHT_ChuongTrinhDaoTaoInfo.KQHT_ChuongTrinhDaoTaoID, pKQHT_ChuongTrinhDaoTaoInfo.SoHocKy);
                // ghi log
                GhiLog("Thêm chương trình khối kiến thức vào chương trình đào tạo '" + pKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao + "'", "Thêm", this.Tag.ToString());
                ThemThanhCong();
            }
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            if (grvCTKhung.FocusedRowHandle >= 0)
            {
                dlgXoaKhoiKienThuc dlg = new dlgXoaKhoiKienThuc(pKQHT_ChuongTrinhDaoTaoInfo.KQHT_ChuongTrinhDaoTaoID);
                dlg.ShowDialog();
                if (dlg.Tag.ToString() == "1")
                {
                    //LoadCTDTChiTiet(pKQHT_ChuongTrinhDaoTaoInfo.KQHT_ChuongTrinhDaoTaoID, pKQHT_ChuongTrinhDaoTaoInfo.SoHocKy);
                    // ghi log
                    GhiLog("Xóa chương trình khối kiến thức khỏi chương trình đào tạo '" + pKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao + "'", "Xóa", this.Tag.ToString());
                    grvCTKhung_FocusedRowChanged(null, null);
                    //XoaThanhCong();
                }
            }
            
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (grvMonHoc.DataRowCount > 0)
            {
                DataTable dtTemp = dtMonHoc.GetChanges();
                string ErrMonHoc = "";
                if (dtTemp != null)
                {
                    try
                    {
                        foreach (DataRow dr in dtTemp.Rows)
                        {
                            ErrMonHoc = dr["TenMonHoc"].ToString();
                            for (int j = 1; j <= pKQHT_ChuongTrinhDaoTaoInfo.SoHocKy; j++)
                            {
                                pKQHT_CTDT_ChiTiet = new KQHT_CTDT_ChiTietInfo();
                                pKQHT_CTDT_ChiTiet.IDKQHT_MonHoc_CT_KhoiKienThuc = int.Parse(dr["IDKQHT_MonHoc_CT_KhoiKienThuc"].ToString());
                                pKQHT_CTDT_ChiTiet.HocKy = j;
                                // Nếu IDj khác null thì update, hoặc xóa khi các số liệu còn lại bằng 0
                                // Ngược lại thì insert nếu một trong các các số liệu còn lại > 0
                                if (int.Parse("0" + dr["ID" + j.ToString()]) != 0)
                                {
                                    pKQHT_CTDT_ChiTiet.KQHT_CTDT_ChiTietID = int.Parse(dr["ID" + j.ToString()].ToString());
                                    // Nếu tất cả các số liệu đều null hoặc bằng 0 thì xóa, ngược lại thì update
                                    if (float.Parse("0" + dr["SHT" + j.ToString()]) == 0 && int.Parse("0" + dr["LT" + j.ToString()]) == 0 && int.Parse("0" + dr["TH" + j.ToString()]) == 0)
                                    {
                                        oBKQHT_CTDT_ChiTiet.DeleteByHocKy(pKQHT_CTDT_ChiTiet);
                                    }
                                    else
                                    {
                                        pKQHT_CTDT_ChiTiet.SoTiet = 0;

                                        pKQHT_CTDT_ChiTiet.SoHocTrinh = dr["SHT" + j.ToString()] == null ? 0 : float.Parse(dr["SHT" + j.ToString()].ToString());
                                        if (int.Parse("0" + dr["LT" + j.ToString()]) != 0)
                                        {
                                            pKQHT_CTDT_ChiTiet.LyThuyet = int.Parse(dr["LT" + j.ToString()].ToString());
                                            pKQHT_CTDT_ChiTiet.SoTiet += pKQHT_CTDT_ChiTiet.LyThuyet;
                                        }
                                        if (int.Parse("0" + dr["TH" + j.ToString()]) != 0)
                                        {
                                            pKQHT_CTDT_ChiTiet.ThucHanh = int.Parse(dr["TH" + j.ToString()].ToString());
                                            pKQHT_CTDT_ChiTiet.SoTiet += pKQHT_CTDT_ChiTiet.ThucHanh;
                                        }
                                        oBKQHT_CTDT_ChiTiet.Update(pKQHT_CTDT_ChiTiet);
                                    }
                                }
                                else
                                {
                                    if (float.Parse("0" + dr["SHT" + j.ToString()]) != 0 || int.Parse("0" + dr["LT" + j.ToString()]) != 0 || int.Parse("0" + dr["TH" + j.ToString()]) != 0)
                                    {
                                        pKQHT_CTDT_ChiTiet.SoTiet = 0;

                                        pKQHT_CTDT_ChiTiet.SoHocTrinh = float.Parse("0" + dr["SHT" + j.ToString()]) == 0 ? 0 : float.Parse(dr["SHT" + j.ToString()].ToString());
                                        if (int.Parse("0" + dr["LT" + j.ToString()]) != 0)
                                        {
                                            pKQHT_CTDT_ChiTiet.LyThuyet = int.Parse(dr["LT" + j.ToString()].ToString());
                                            pKQHT_CTDT_ChiTiet.SoTiet += pKQHT_CTDT_ChiTiet.LyThuyet;
                                        }
                                        if (int.Parse("0" + dr["TH" + j.ToString()]) != 0)
                                        {
                                            pKQHT_CTDT_ChiTiet.ThucHanh = int.Parse(dr["TH" + j.ToString()].ToString());
                                            pKQHT_CTDT_ChiTiet.SoTiet += pKQHT_CTDT_ChiTiet.ThucHanh;
                                        }
                                        oBKQHT_CTDT_ChiTiet.Add(pKQHT_CTDT_ChiTiet);
                                    }
                                }
                            }
                        }
                        // ghi log
                        //GhiLog("Cập nhật thông tin môn học trong chương trình đào tạo  '" + pKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao + "'", "Cập nhật", this.Tag.ToString());
                        //LoadCTDTChiTiet(pKQHT_ChuongTrinhDaoTaoInfo.KQHT_ChuongTrinhDaoTaoID, pKQHT_ChuongTrinhDaoTaoInfo.SoHocKy);
                    }
                    catch 
                    {
                        ThongBaoLoi("Có lỗi khi cập nhật, có thể là môn học '" + ErrMonHoc + "' đã được sử dụng trong môn học trong kỳ.");
                    }
                    // ghi log
                    GhiLog("Cập nhật thông tin môn học trong chương trình đào tạo  '" + pKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao + "'", "Cập nhật", this.Tag.ToString());
                    LoadCTDTChiTiet(pKQHT_ChuongTrinhDaoTaoInfo.KQHT_ChuongTrinhDaoTaoID, pKQHT_ChuongTrinhDaoTaoInfo.SoHocKy);
                }
            }
        }
        private void btnThemLop_Click(object sender, EventArgs e)
        {
            dlgCTDTChonLopHoc dlg = new dlgCTDTChonLopHoc(pKQHT_ChuongTrinhDaoTaoInfo.IDDM_TrinhDo, pKQHT_ChuongTrinhDaoTaoInfo.KQHT_ChuongTrinhDaoTaoID, pKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao);
            dlg.ShowDialog();
            if (dlg.Tag.ToString() == "1")
            {
                LoadLopThuocCTDT();
                // ghi log
                GhiLog("Thêm lớp cho chương trình đào tạo  '" + pKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao + "'", "Thêm", this.Tag.ToString());
            }
        }

        private void btnXoaLop_Click(object sender, EventArgs e)
        {
            if (grvLop.FocusedRowHandle >= 0)
            {
                if (ThongBaoChon("Bạn có chắc chắn muốn xóa ?") == DialogResult.Yes)
                {
                    try
                    {
                        pKQHT_CTDT_LopInfo.KQHT_CTDT_LopID = int.Parse(grvLop.GetDataRow(grvLop.FocusedRowHandle)["KQHT_CTDT_LopID"].ToString());
                        oBKQHT_CTDT_Lop.Delete(pKQHT_CTDT_LopInfo);
                        // ghi log
                        GhiLog("Xóa lớp khỏi chương trình đào tạo  '" + pKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao + "'", "Xóa", this.Tag.ToString());
                        dtLopHoc.Rows.Remove(dtLopHoc.Rows[grvLop.FocusedRowHandle]);
                    }
                    catch
                    {
                        XoaThatBai();
                    }
                }
            }
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvCTKhung.FocusedRowHandle >= 0)
            {
                if (ThongBaoChon("Bạn có chắc chắn muốn xóa ?") == DialogResult.Yes)
                {
                    if (grvLop.RowCount == 0)
                    {
                        try
                        {
                            pKQHT_ChuongTrinhDaoTaoInfo.KQHT_ChuongTrinhDaoTaoID = int.Parse(grvCTKhung.GetDataRow(grvCTKhung.FocusedRowHandle)["KQHT_ChuongTrinhDaoTaoID"].ToString());
                            oBKQHT_ChuongTrinhDaoTao.Delete(pKQHT_ChuongTrinhDaoTaoInfo);
                            // ghi log
                            GhiLog("Xóa chương trình đào tạo  '" + pKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao + "'", "Xóa", this.Tag.ToString());
                            LoadCTDT();
                        }
                        catch
                        {
                            XoaThatBai();
                        }
                    }
                    else
                    {
                        ThongBao("Bạn hãy xóa hết lớp trước khi xóa CTĐT");
                    }
                }
            }
        }

        private void barbtnThemKeThua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgChuongTrinhDaoTaoKeThua dlg = new dlgChuongTrinhDaoTaoKeThua(pKQHT_ChuongTrinhDaoTaoInfo);
            dlg.ShowDialog();
            if (dlg.Tag.ToString() == "1")
            {
                try
                {
                    pKQHT_ChuongTrinhDaoTaoInfo = dlg.pKQHT_ChuongTrinhDaoTaoInfo;
                    int KQHT_ChuongTrinhDaoTaoID = oBKQHT_ChuongTrinhDaoTao.Add(pKQHT_ChuongTrinhDaoTaoInfo);
                    LoadCTDT();
                    dlgChonCTKhoiKienThuc dlgKienThuc = new dlgChonCTKhoiKienThuc(KQHT_ChuongTrinhDaoTaoID);
                    dlgKienThuc.ShowDialog();
                    // ghi log
                    GhiLog("Thêm chương trình đào tạo  '" + pKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao + "'", "Thêm", this.Tag.ToString());
                    ThemThanhCong();
                }
                catch (Exception ex)
                {
                    ThongBao(ex.Message);
                }
            }
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dlgChuongTrinhDaoTao dlg = new dlgChuongTrinhDaoTao(pKQHT_ChuongTrinhDaoTaoInfo,EDIT_MODE.SUA);
            dlg.ShowDialog();
            if (dlg.Tag.ToString() == "1")
            {
                try
                {
                    pKQHT_ChuongTrinhDaoTaoInfo = dlg.pKQHT_ChuongTrinhDaoTaoInfo;
                    oBKQHT_ChuongTrinhDaoTao.Update(pKQHT_ChuongTrinhDaoTaoInfo);
                    // ghi log
                    GhiLog("Sửa chương trình đào tạo  '" + pKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao + "'", "Sửa", this.Tag.ToString());
                    LoadCTDT();
                    SuaThanhCong();
                }
                catch (Exception ex)
                {
                    ThongBao(ex.Message);
                }
            }
        }

        private void grvMonHoc_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.IndexOf("SHT") >= 0 && e.Column.FieldName.Length > 3)
            {
                string HocKy = e.Column.FieldName.Substring(3);
                DataRow dr = grvMonHoc.GetDataRow(e.RowHandle);
                if ("" + dr["LT" + HocKy] == "" && "" + dr["TH" + HocKy] == "")
                {
                    dr["LT" + HocKy] = dr["LT"];
                    dr["TH" + HocKy] = dr["TH"];
                }
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToXls(grvMonHoc);
        }
    }
}