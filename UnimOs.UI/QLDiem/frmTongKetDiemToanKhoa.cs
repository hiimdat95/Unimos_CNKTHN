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
    public partial class frmTongKetDiemToanKhoa : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DataTable dtSinhVien, dtMonHoc, dtData, dtXepLoai;
        private cBXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private cBKQHT_DiemTongKetToanKhoa oBKQHT_DiemTongKetToanKhoa;
        private KQHT_DiemTongKetToanKhoaInfo pKQHT_DiemTongKetToanKhoaInfo;
        private KQHT_XepLoaiTotNghiepInfo pKQHT_XepLoaiTotNghiepInfo;
        private cBKQHT_XepLoaiTotNghiep oBKQHT_XepLoaiTotNghiep;
        private int IDDM_Lop = 0, NamHocBatDau = 0, NamHocKetThuc = 0;

        public frmTongKetDiemToanKhoa()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
            pKQHT_DiemTongKetToanKhoaInfo = new KQHT_DiemTongKetToanKhoaInfo();
            oBKQHT_DiemTongKetToanKhoa = new cBKQHT_DiemTongKetToanKhoa();
            pKQHT_XepLoaiTotNghiepInfo = new KQHT_XepLoaiTotNghiepInfo();
            oBKQHT_XepLoaiTotNghiep = new cBKQHT_XepLoaiTotNghiep();
        }

        private void frmTongKetDiemToanKhoa_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
            dtXepLoai = oBKQHT_XepLoaiTotNghiep.Get(pKQHT_XepLoaiTotNghiepInfo);
            repositoryXepLoai.DataSource = dtXepLoai;
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            DM_LopInfo pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                IDDM_Lop = pDM_LopInfo.DM_LopID;
                DataTable dtTemp = oBDM_Lop.Get(pDM_LopInfo);
                NamHocKetThuc = DateTime.Parse(dtTemp.Rows[0]["NgayRa"].ToString()).Year;
                NamHocBatDau = DateTime.Parse(dtTemp.Rows[0]["NgayVao"].ToString()).Year;
                dtSinhVien = CreateTable();
                AddBand();
                XuLyTable();
                grdDiem.DataSource = dtSinhVien;
                dtSinhVien.AcceptChanges();
                btnCapNhat.Enabled = true;
            }
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SV_SinhVienID", typeof(int));
            dt.Columns.Add("MaSinhVien", typeof(string));
            dt.Columns.Add("HoVaTen", typeof(string));
            dt.Columns.Add("DiemTK", typeof(float));
            dt.Columns.Add("Diem", typeof(float));
            dt.Columns.Add("KQHT_XepLoaiTotNghiepID", typeof(int));
            return dt;
        }

        private void AddBand()
        {
            BandedGridColumn bgc; GridBand grb, grbHK;
            DataTable dtTemp = LoadNamHoc();
            int IDNamHoc = 0, BandWidth = 0, SoNam = NamHocKetThuc - NamHocBatDau;
            grbMonHoc.Children.Clear();
            // add band Năm Học
            for (int j = 0; j < SoNam; j++)
            {
                BandWidth = 0;
                grb = new GridBand();
                SetBandCaption(grb, "Năm học thứ " + (j + 1).ToString(), 50);
                grbMonHoc.Children.AddRange(new GridBand[] { grb });
                DataRow[] adr = dtTemp.Select(" TenNamHoc='" + ((NamHocBatDau + j) + "-" + (NamHocBatDau + j + 1)) + "'");
                if (adr.Length > 0)
                {
                    IDNamHoc = int.Parse(adr[0]["DM_NamHocID"].ToString());
                    // add band Học Kỳ
                    for (int i = 1; i <= 2; i++)
                    {
                        grbHK = new GridBand();
                        SetBandCaption(grbHK, "Học kỳ " + i.ToString(), 50);
                        grb.Children.AddRange(new GridBand[] { grbHK });
                        // add band Môn Học
                        dtMonHoc = oBXL_MonHocTrongKy.GetMonKy(IDDM_Lop, IDNamHoc, i);
                        foreach (DataRow dr in dtMonHoc.Rows)
                        {
                            bgc = new BandedGridColumn();
                            grbHK.Columns.Add(bgc);
                            bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            bgc.DisplayFormat.FormatString = "n1";
                            SetColumnBandCaption(bgc, dr["TenMonHoc"].ToString(), "C" + "_" + dr["XL_MonHocTrongKyID"].ToString(), 110, DevExpress.Utils.HorzAlignment.Center, false);
                            bgvDiem.Columns.AddRange(new BandedGridColumn[] { bgc });
                            BandWidth += 100;
                            dtSinhVien.Columns.Add("C" + "_" + dr["XL_MonHocTrongKyID"].ToString(), typeof(float));
                        }
                    }
                }
            }

        }

        private void XuLyTable()
        {
            dtData = oBKQHT_DiemTongKetToanKhoa.GetDanhSach(IDDM_Lop, Program.IDNamHoc, Program.HocKy);
            DataRow drNew;

            try
            {
                if (dtData.Rows.Count > 0)
                {
                    string SV_SinhVienID = dtData.Rows[0]["SV_SinhVienID"].ToString();

                    drNew = dtSinhVien.NewRow();
                    drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                    drNew["MaSinhVien"] = dtData.Rows[0]["MaSinhVien"].ToString();
                    drNew["HoVaTen"] = dtData.Rows[0]["HoVaTen"].ToString();
                    if (dtData.Rows[0]["DiemTongKet"].ToString() != "")
                        grbDiemTK.Visible = true;
                    else
                        grbDiemTK.Visible = false;
                    drNew["DiemTK"] = dtData.Rows[0]["DiemTBMH"];
                    drNew["Diem"] = dtData.Rows[0]["DiemTongKet"];
                    drNew["KQHT_XepLoaiTotNghiepID"] = dtData.Rows[0]["IDDM_XepLoai"];

                    foreach (DataRow dr in dtData.Rows)
                    {
                        if (dr["SV_SinhVienID"].ToString() != SV_SinhVienID)
                        {

                            dtSinhVien.Rows.Add(drNew);

                            SV_SinhVienID = dr["SV_SinhVienID"].ToString();
                            drNew = dtSinhVien.NewRow();

                            drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                            drNew["MaSinhVien"] = dr["MaSinhVien"].ToString();
                            drNew["HoVaTen"] = dr["HoVaTen"].ToString();
                            drNew["DiemTK"] = dr["DiemTBMH"];
                            drNew["Diem"] = dr["DiemTongKet"];
                            drNew["KQHT_XepLoaiTotNghiepID"] = dr["IDDM_XepLoai"];

                            if ("" + dr["IDXL_MonHocTrongKy"] != "")
                            {
                                drNew["C" + "_" + dr["IDXL_MonHocTrongKy"].ToString()] = dr["Diem"];
                            }
                        }
                        else
                        {
                            if ("" + dr["IDXL_MonHocTrongKy"] != "")
                            {
                                drNew["C" + "_" + dr["IDXL_MonHocTrongKy"].ToString()] = dr["Diem"];
                            }
                        }
                    }
                    dtSinhVien.Rows.Add(drNew);
                }
                else
                    grbDiemTK.Visible = false;
            }
            catch
            { }
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            grbDiemTK.Visible = true;
            MathParser parser = new MathParser();
            double TongHeSoTemp = 0;
            double TongSoDiem = 0;
            DataTable dtTemp = oBXL_MonHocTrongKy.GetToanKhoa(IDDM_Lop, 0, 0);
            if (dtSinhVien.Rows.Count > 0)
            {
                for (int i = 0; i < dtSinhVien.Rows.Count; i++)
                {
                    TongSoDiem = 0;
                    TongHeSoTemp = 0;
                    for (int h = 0; h < grbMonHoc.Children.Count; h++)
                    {
                        for (int k = 0; k < grbMonHoc.Children[h].Children.Count; k++)
                        {
                            for (int j = 0; j < grbMonHoc.Children[h].Children[k].Columns.Count; j++)
                            {
                                DataRow[] dr = dtTemp.Select("XL_MonHocTrongKyID=" + grbMonHoc.Children[h].Children[k].Columns[j].FieldName.Substring(grbMonHoc.Children[h].Children[k].Columns[j].FieldName.IndexOf("_") + 1));
                                if (dr.Length > 0 && dtSinhVien.Rows[i][grbMonHoc.Children[h].Children[k].Columns[j].FieldName].ToString() != "")
                                {
                                    TongHeSoTemp += double.Parse("0" + dr[0]["SoHocTrinh"].ToString());
                                    TongSoDiem += double.Parse("0" + dtSinhVien.Rows[i][grbMonHoc.Children[h].Children[k].Columns[j].FieldName].ToString()) * double.Parse("0" + dr[0]["SoHocTrinh"].ToString());
                                }
                            }
                        }
                        dtSinhVien.Rows[i]["DiemTK"] = parser.Round(TongSoDiem / TongHeSoTemp, 1, true);
                        //if (dtSinhVien.Rows[i]["DiemTK"] != "")
                        //{
                        //    DiemTK = float.Parse(dtSinhVien.Rows[i]["DiemTK"].ToString());
                        //    for (int j = 0; j < dtXepLoai.Rows.Count; j++)
                        //    {
                        //        if (DiemTK >= float.Parse(dtXepLoai.Rows[j]["TuDiem"].ToString()))
                        //        {
                        //            dtSinhVien.Rows[i]["KQHT_XepLoaiTotNghiepID"] = dtXepLoai.Rows[j]["KQHT_XepLoaiTotNghiepID"];
                        //            break;
                        //        }
                        //    }
                        //}
                    }
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = dtSinhVien.GetChanges();
            if (dtTemp != null)
            {
                foreach (DataRow dr in dtTemp.Rows)
                {
                    if (dr.RowState == DataRowState.Modified)
                    {
                        try
                        {
                            pKQHT_DiemTongKetToanKhoaInfo.GhiChu = "";
                            pKQHT_DiemTongKetToanKhoaInfo.DiemTBMH = double.Parse("0" + dr["DiemTK"].ToString());
                            pKQHT_DiemTongKetToanKhoaInfo.Diem = double.Parse("0" + dr["Diem"].ToString());
                            pKQHT_DiemTongKetToanKhoaInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                            pKQHT_DiemTongKetToanKhoaInfo.IDDM_XepLoai = int.Parse("0" + dr["KQHT_XepLoaiTotNghiepID"].ToString());
                            pKQHT_DiemTongKetToanKhoaInfo.LanCuoi = true;
                            pKQHT_DiemTongKetToanKhoaInfo.LanThi = 1;
                            pKQHT_DiemTongKetToanKhoaInfo.IDDM_NamHoc = Program.IDNamHoc;
                            oBKQHT_DiemTongKetToanKhoa.Add(pKQHT_DiemTongKetToanKhoaInfo);
                        }
                        catch
                        {
                            // error
                        }
                    }
                }
                ThongBao("Cập nhật thành công!");
            }
            else
                ThongBao("Bạn cần thay đổi thông tin trước khi cập nhật!");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bgvDiem_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToXls(bgvDiem);
        }

    }
}