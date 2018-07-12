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
    public partial class frmNhapDiemHoiDongMonHoc : frmBase
    {
        private cBKQHT_HoiDongMon oBKQHT_HoiDongMon;
        private KQHT_HoiDongMonInfo pKQHT_HoiDongMonInfo;
        private cBKQHT_HoiDongMon_Diem oBKQHT_HoiDongMon_Diem;
        private KQHT_HoiDongMon_DiemInfo pKQHT_HoiDongMon_DiemInfo;
        private cBKQHT_DiemTongKetMon oBKQHT_DiemTongKetMon;
        private KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo;
        private DataTable dtHoiDong,dtChiTiet,dtGiangVien;
        private int KQHT_HoiDongMonID = 0, IDDM_MonHoc=0;


        public frmNhapDiemHoiDongMonHoc()
        {
            InitializeComponent();
            oBKQHT_HoiDongMon = new cBKQHT_HoiDongMon();
            pKQHT_HoiDongMonInfo = new KQHT_HoiDongMonInfo();
            pKQHT_HoiDongMon_DiemInfo = new KQHT_HoiDongMon_DiemInfo();
            oBKQHT_HoiDongMon_Diem = new cBKQHT_HoiDongMon_Diem();
            pKQHT_DiemTongKetMonInfo = new KQHT_DiemTongKetMonInfo();
            oBKQHT_DiemTongKetMon = new cBKQHT_DiemTongKetMon();
        }

        private void frmNhapDiemHoiDongMonHoc_Load(object sender, EventArgs e)
        {
            dtHoiDong = oBKQHT_HoiDongMon.GetByNamHocHocKy(Program.IDNamHoc, Program.HocKy);
            grdHoiDong.DataSource = dtHoiDong;
        }

        private void grvHoiDong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvHoiDong.FocusedRowHandle >= 0)
            {
                KQHT_HoiDongMonID = int.Parse(grvHoiDong.GetDataRow(grvHoiDong.FocusedRowHandle)["KQHT_HoiDongMonID"].ToString());
                IDDM_MonHoc = int.Parse(grvHoiDong.GetDataRow(grvHoiDong.FocusedRowHandle)["IDDM_MonHoc"].ToString());
                dtChiTiet = CreateTable();
                AddBand();
                XuLyTable();
                grdGiangVien.DataSource = dtChiTiet;
                dtChiTiet.AcceptChanges();
                
                if ((bgvGiangVien.DataRowCount >0) && (grbGiangVien.Columns.Count >0))
                    btnCapNhat.Enabled = true;
                else
                    btnCapNhat.Enabled = false;
            }
            else
            {
                btnCapNhat.Enabled = false;
                if (dtChiTiet != null)
                    dtChiTiet.Clear();
            }
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SV_SinhVienID", typeof(int));
            dt.Columns.Add("MaSinhVien", typeof(string));
            dt.Columns.Add("HoVaTen", typeof(string));
            dt.Columns.Add("DiemTK", typeof(float));
            return dt;
        }
        private void AddBand()
        {
            BandedGridColumn bgc;
            dtGiangVien = oBKQHT_HoiDongMon.GetGiangVien(KQHT_HoiDongMonID);
            grbGiangVien.Columns.Clear();
            if ((dtGiangVien != null) && (dtGiangVien.Rows.Count > 0))
            {
                foreach (DataRow dr in dtGiangVien.Rows)
                {
                    dtChiTiet.Columns.Add(dr["KQHT_HoiDongMon_ChiTietID"].ToString() + "_" + dr["TyLe"].ToString(), typeof(int));

                    bgc = new BandedGridColumn();
                    grbGiangVien.Columns.Add(bgc);

                    SetColumnBandCaption(bgc, dr["TenGiangVien"].ToString(), dr["KQHT_HoiDongMon_ChiTietID"].ToString() + "_" + dr["TyLe"].ToString(), 130, DevExpress.Utils.HorzAlignment.Default, false);
                    bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    bgc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                    bgvGiangVien.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });
                }
            }
        }
        private void XuLyTable()
        {
            if (dtGiangVien.Rows.Count > 0)
            {
                DataTable dt = oBKQHT_HoiDongMon_Diem.GetDanhSach(KQHT_HoiDongMonID);
                DataRow drNew;
                if (dt.Rows.Count > 0)
                {
                    string SV_SinhVienID = dt.Rows[0]["SV_SinhVienID"].ToString();
                    drNew = dtChiTiet.NewRow();
                    drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                    drNew["MaSinhVien"] = dt.Rows[0]["MaSinhVien"].ToString();
                    drNew["HoVaTen"] = dt.Rows[0]["HoVaTen"].ToString();
                    drNew["DiemTK"] = dt.Rows[0]["DiemTK"];

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["SV_SinhVienID"].ToString() != SV_SinhVienID)
                        {
                            dtChiTiet.Rows.Add(drNew);

                            SV_SinhVienID = dr["SV_SinhVienID"].ToString();
                            drNew = dtChiTiet.NewRow();

                            drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                            drNew["MaSinhVien"] = dr["MaSinhVien"].ToString();
                            drNew["HoVaTen"] = dr["HoVaTen"].ToString();
                            drNew["DiemTK"] = dr["DiemTK"];

                            if (dr["KQHT_HoiDongMon_ChiTietID"].ToString() != "")
                                drNew[dr["KQHT_HoiDongMon_ChiTietID"].ToString() + "_" + dr["TyLe"].ToString()] = dr["Diem"];
                        }
                        else
                        {
                            if (dr["KQHT_HoiDongMon_ChiTietID"].ToString() !="")
                                drNew[dr["KQHT_HoiDongMon_ChiTietID"].ToString() + "_" + dr["TyLe"].ToString()] = dr["Diem"];
                        }
                    }
                    dtChiTiet.Rows.Add(drNew);
                }
            }
        }

        private void bgvGiangVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvHoiDong_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = dtChiTiet.GetChanges();
            if (dtTemp != null)
            {
                foreach (DataRow dr in dtTemp.Rows)
                {
                    if (dr.RowState == DataRowState.Modified)
                    {

                        // update vao bang KQHT_HoiDongMon_Diem                          
                        for (int i = 0; i < grbGiangVien.Columns.Count; i++)
                        {

                            if ("" + dr[grbGiangVien.Columns[i].FieldName] != "")
                            {
                                try
                                {
                                    pKQHT_HoiDongMon_DiemInfo.Diem = float.Parse(dr[grbGiangVien.Columns[i].FieldName].ToString());
                                    pKQHT_HoiDongMon_DiemInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                                    pKQHT_HoiDongMon_DiemInfo.IDKQHT_HoiDongMon_ChiTiet = int.Parse(grbGiangVien.Columns[i].FieldName.Substring(0, grbGiangVien.Columns[i].FieldName.IndexOf("_")));
                                    oBKQHT_HoiDongMon_Diem.Add(pKQHT_HoiDongMon_DiemInfo);
                                }

                                catch
                                {
                                    // error
                                }
                            }
                        }
                        if ("" + dr["DiemTK"] != "")
                            {
                                try
                                {
                                    pKQHT_DiemTongKetMonInfo.Diem = float.Parse("0" + dr["DiemTK"]);
                                    pKQHT_DiemTongKetMonInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                                    pKQHT_DiemTongKetMonInfo.IDDM_MonHoc = IDDM_MonHoc;
                                    pKQHT_DiemTongKetMonInfo.IDDM_NamHoc = Program.IDNamHoc;
                                    pKQHT_DiemTongKetMonInfo.HocKy = Program.HocKy;
                                    pKQHT_DiemTongKetMonInfo.LanThi = 1;
                                    oBKQHT_DiemTongKetMon.Add(pKQHT_DiemTongKetMonInfo);
                                }

                                catch
                                {
                                    // error
                                }
                            }
                       
                    }
                }
                ThongBao("Cập nhật thành công!");
            }
            else
                ThongBao("Bạn cần thay đổi thông tin trước khi cập nhật!");
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            if (dtChiTiet != null && dtGiangVien != null)
            {
                int TyLe = 0;
                float TongDiem = 0;
                MathParser parser = new MathParser();
                //DataRow[] dr;
                for (int i = 0; i < dtChiTiet.Rows.Count; i++)
                {
                    TongDiem = 0;
                    TyLe = 0;
                    for (int j = 0; j < grbGiangVien.Columns.Count; j++)
                    {
                      //  dr = dtChiTiet.Select(" SV_SinhVienID = " + dtChiTiet.Rows[i]["SV_SinhVienID"].ToString());// + " and KQHT_HoiDongMon_ChiTietID =" + dtGiangVien.Rows[j]["KQHT_HoiDongMon_ChiTietID"].ToString());
                        TongDiem += int.Parse(grbGiangVien.Columns[j].FieldName.Substring(grbGiangVien.Columns[j].FieldName.IndexOf("_") + 1)) *  float.Parse("0" + dtChiTiet.Rows[i][grbGiangVien.Columns[j].FieldName].ToString());
                        TyLe += int.Parse(grbGiangVien.Columns[j].FieldName.Substring(grbGiangVien.Columns[j].FieldName.IndexOf("_") + 1));
                    }
                    if (TongDiem >0 && TyLe>0)
                        dtChiTiet.Rows[i]["DiemTK"] = parser.Round(TongDiem / TyLe, 1, true);
                }
            }
        }
    }
}