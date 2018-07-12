using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Business;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Diagnostics;
using System.IO;
using DevExpress.XtraGrid.Views.Base;
using System.Collections;

namespace UnimOs.Khoa
{
    public partial class frmNhapDiem_QCNghe : frmBase
    {
        private DM_LopInfo pDM_LopInfo;
        private cBXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private cBKQHT_DiemThi oBKQHT_DiemThi;
        private KQHT_DiemThiInfo pKQHT_DiemThiInfo;
        private cBKQHT_DiemThanhPhan oBKQHT_DiemThanhPhan;
        private KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo;
        private cBKQHT_DiemTongKetMon oBKQHT_DiemTongKetMon;
        private KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo;
        private cBKQHT_DiemDanh oBKQHT_DiemDanh;
        private KQHT_DiemDanhInfo pKQHT_DiemDanhInfo;
        private cBKQHT_DanhSachDuThi oBKQHT_DanhSachDuThi;
        private KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo;
        private cBKQHT_DanhSachKhongThi oBKQHT_DanhSachKhongThi;
        private cBKQHT_DaChuyenDiem oBKQHT_DaChuyenDiem;
        private DataTable dtMonHoc, dtSinhVien, dtThanhPhan, dtDaChuyenDiem, dtXLMonHoc;
        private DataRow drMonHoc;
        private int colWidth = 35, _DongBatDau = 12, _CotBatDau = 6, SoLanThi = 0, ColStart, ColEnd;
        private int IDDM_MonHoc, IDXL_MonHocTrongKy, IDKQHT_ThanhPhanTBHS = 0;
        private string IDThanhPhanThi = "", CongThucDiem = "";
        private bool IsNhapDiemTongKet, IsGiaoVuNhapDiem, IsLoadMonNhapDiem = false;
        private BandedGridColumn bgcTBHS;

        public frmNhapDiem_QCNghe()
        {
            InitializeComponent();
            pDM_LopInfo = new DM_LopInfo();
            oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
            oBKQHT_DiemThi = new cBKQHT_DiemThi();
            pKQHT_DiemThiInfo = new KQHT_DiemThiInfo();
            oBKQHT_DiemThanhPhan = new cBKQHT_DiemThanhPhan();
            pKQHT_DiemThanhPhanInfo = new KQHT_DiemThanhPhanInfo();
            oBKQHT_DiemTongKetMon = new cBKQHT_DiemTongKetMon();
            pKQHT_DiemTongKetMonInfo = new KQHT_DiemTongKetMonInfo();
            oBKQHT_DiemDanh = new cBKQHT_DiemDanh();
            pKQHT_DiemDanhInfo = new KQHT_DiemDanhInfo();
            oBKQHT_DanhSachDuThi = new cBKQHT_DanhSachDuThi();
            oBKQHT_DanhSachKhongThi = new cBKQHT_DanhSachKhongThi();
            oBKQHT_DaChuyenDiem = new cBKQHT_DaChuyenDiem();
            dtXLMonHoc = (new cBKQHT_XepLoaiMonHoc()).Get(new KQHT_XepLoaiMonHocInfo());
            repositoryItemCmbXepLoai.DataSource = dtXLMonHoc;

            grdSoTietNghi.Visible = false;
        }

        private void frmNhapDiem_Load(object sender, EventArgs e)
        {
            cBHT_ThamSoHeThong oBThamSo = new cBHT_ThamSoHeThong();
            IsNhapDiemTongKet = oBThamSo.GetGiaTriByMaThamSo("NhapDiemTongKet") == "1" ? true : false;
            IsGiaoVuNhapDiem = oBThamSo.GetGiaTriByMaThamSo("GiaoVuNhapDiem") == "1" ? true : false;
            if ((Program.objUserCurrent.IDDM_Khoa_GiaoVu > 0 || Program.objUserCurrent.Username == "giaovu") && !IsGiaoVuNhapDiem)
            {
                bgrvDiem.OptionsBehavior.Editable = false;
                SetButton(false);
            }
            LoadTreeLop(uctrlLop);
            uctrlLop.chkExpandAll.Checked = true;
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            IsLoadMonNhapDiem = false;
            LoadMonHocNhapDiem();
            grvMonHoc_FocusedRowChanged(null, null);
        }

        private void SetButton(bool status)
        {
            btnCapNhat.Enabled = status;
            btnNhapExcel.Enabled = status;
            btnChuyenDiem.Enabled = status;
        }

        private void LoadMonHocNhapDiem()
        {
            if (Program.objUserCurrent.IDDM_Khoa_GiaoVu > 0)
                dtMonHoc = oBXL_MonHocTrongKy.GetByLopKhoa(pDM_LopInfo.DM_LopID, Program.objUserCurrent.IDDM_Khoa_GiaoVu, Program.IDNamHoc, Program.HocKy);
            else
                dtMonHoc = oBXL_MonHocTrongKy.GetByIDGiaoVien(Program.objUserCurrent.NS_GiaoVienID, pDM_LopInfo.DM_LopID, Program.HocKy, Program.IDNamHoc);

            grdMonHoc.DataSource = dtMonHoc;
            IsLoadMonNhapDiem = true;
        }

        private void grvMonHoc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!IsLoadMonNhapDiem)
                return;
            //chkNhapDiemLan2.Checked = false;
            if (grvMonHoc.FocusedRowHandle >= 0)
            {
                drMonHoc = grvMonHoc.GetDataRow(grvMonHoc.FocusedRowHandle);
                IDDM_MonHoc = int.Parse(drMonHoc["DM_MonHocID"].ToString());
                IDXL_MonHocTrongKy = int.Parse(drMonHoc["XL_MonHocTrongKyID"].ToString());
                dtDaChuyenDiem = oBKQHT_DaChuyenDiem.GetByIDMonHocTrongKy(IDXL_MonHocTrongKy);
                if (dtDaChuyenDiem.Rows.Count > 0)
                {
                    chkDiemThanhPhan.Checked = bool.Parse(dtDaChuyenDiem.Rows[0]["DaNhapDiemThanhPhan"].ToString());
                    chkThiLan1.Checked = bool.Parse(dtDaChuyenDiem.Rows[0]["DaNhapDiemThiL1"].ToString());
                    chkDiemThanhPhanL2.Checked = bool.Parse(dtDaChuyenDiem.Rows[0]["DaNhapDiemThanhPhanL2"].ToString());
                    chkThiLan2.Checked = bool.Parse(dtDaChuyenDiem.Rows[0]["DaNhapDiemThiL2"].ToString());
                }
                else
                {
                    chkDiemThanhPhan.Checked = false;
                    chkThiLan1.Checked = false;
                    chkDiemThanhPhanL2.Checked = false;
                    chkThiLan2.Checked = false;
                }
            }
            else
            {
                drMonHoc = null;
                IDDM_MonHoc = 0;
                IDXL_MonHocTrongKy = 0;
            }
            LoadSinhVien();
            if (chkNhapDiemLan2.Checked)
                bgcTBHS.FieldName = IDKQHT_ThanhPhanTBHS.ToString() + "_2";
            else
                bgcTBHS.FieldName = IDKQHT_ThanhPhanTBHS.ToString() + "_1";
            chkDiemThanhPhan_CheckedChanged(null, null);
        }

        private void LoadSinhVien()
        {
            if (dtSinhVien != null)
                dtSinhVien.Clear();
            dtSinhVien = CreateTable();
            AddBand();
            XuLyTable();
            if (chkDiemThanhPhan.Checked)
            {
                if (dtSinhVien.Columns.Contains("LyDo"))
                {
                    DataRow[] arrDr = dtSinhVien.Select("LyDo <> ''");
                    lblDuThi.Text = "Đủ điều kiện dự thi: " + (dtSinhVien.Rows.Count - arrDr.Length).ToString() +
                        "/" + dtSinhVien.Rows.Count.ToString();
                }
            }
            else
                lblDuThi.Text = "Chưa chuyển điểm thành phần";
            grdDiem.DataSource = dtSinhVien;
            dtSinhVien.AcceptChanges();
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SV_SinhVienID", typeof(int));
            dt.Columns.Add("MaSinhVien", typeof(string));
            dt.Columns.Add("HoVa", typeof(string));
            dt.Columns.Add("TenSV", typeof(string));
            dt.Columns.Add("NgaySinh", typeof(DateTime));
            dt.Columns.Add("TenLop", typeof(string));
            dt.Columns.Add("CoLyDo", typeof(int));
            dt.Columns.Add("KhongLyDo", typeof(int));
            dt.Columns.Add("SoTietHocLai", typeof(int));
            ColStart = 9;
            ColEnd = ColStart;
            return dt;
        }

        private void AddBand()
        {
            GridBand grb;
            BandedGridColumn bgc;
            KQHT_ThanhPhanDiemInfo pKQHT_ThanPhanDiemInfo = new KQHT_ThanhPhanDiemInfo();
            cBKQHT_ThanhPhanDiem oBKQHT_ThanhPhanDiem = new cBKQHT_ThanhPhanDiem();
            dtThanhPhan = oBKQHT_ThanhPhanDiem.GetByIDTrinhDo(pDM_LopInfo.IDDM_TrinhDo);
            grbDiem.Children.Clear();

            if ((dtThanhPhan != null) && (dtThanhPhan.Rows.Count > 0))
            {
                int bandWidth = 0;
                foreach (DataRow dr in dtThanhPhan.Rows)
                {
                    if ("" + dr["CongThucDiem"] == "")
                    {
                        bandWidth = 0;
                        // Begin Add band TenThanhPhanDiem
                        grb = new GridBand();
                        grbDiem.Children.AddRange(new GridBand[] { grb });
                        if (!bool.Parse(dr["Thi"].ToString()))
                        {
                            // Nếu không phải là thành phần thi
                            if (int.Parse(dr["SoDiem"].ToString()) == 1)
                            {
                                dtSinhVien.Columns.Add(dr["KQHT_ThanhPhanDiemID"].ToString() + "_1", typeof(double));
                                ColEnd++;
                                bgc = new BandedGridColumn();
                                grb.Columns.Add(bgc);

                                SetColumnBandCaption(bgc, "" + dr["KyHieu"], "" + dr["KQHT_ThanhPhanDiemID"] + "_1",
                                    colWidth, DevExpress.Utils.HorzAlignment.Default, false);

                                bandWidth += colWidth;

                                bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                                bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                                bgrvDiem.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });
                            }
                            else
                            {
                                for (int i = 1; i <= int.Parse(dr["SoDiem"].ToString()); i++)
                                {
                                    dtSinhVien.Columns.Add(dr["KQHT_ThanhPhanDiemID"].ToString() + "_" + i.ToString(), typeof(double));
                                    ColEnd++;
                                    bgc = new BandedGridColumn();
                                    grb.Columns.Add(bgc);

                                    SetColumnBandCaption(bgc, i.ToString(),
                                        "" + dr["KQHT_ThanhPhanDiemID"] + "_" + i.ToString(), colWidth, DevExpress.Utils.HorzAlignment.Default, false);

                                    bandWidth += colWidth;

                                    bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                                    bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                                    bgrvDiem.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });
                                }
                            }
                        }
                        else
                        {
                            // Nếu là thành phần thi
                            IDThanhPhanThi = dr["KQHT_ThanhPhanDiemID"].ToString();
                            SoLanThi = int.Parse(dr["SoLanThi"].ToString());
                            for (int i = 1; i <= SoLanThi; i++)
                            {
                                dtSinhVien.Columns.Add(dr["KQHT_ThanhPhanDiemID"].ToString() + "_" + i.ToString(), typeof(double));
                                ColEnd++;
                                bgc = new BandedGridColumn();
                                grb.Columns.Add(bgc);

                                SetColumnBandCaption(bgc, "L" + i.ToString(),
                                    "" + dr["KQHT_ThanhPhanDiemID"] + "_" + i.ToString(), colWidth, DevExpress.Utils.HorzAlignment.Default, false);
                                bandWidth += colWidth;
                                bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                                bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                                //bgc.OptionsColumn.AllowEdit = !oBKQHT_DanhSachDuThi.GetDaChuyenDiemByMonHocTrongKy(IDXL_MonHocTrongKy, i);
                                bgrvDiem.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });
                            }
                        }
                        SetBandCaption(grb, dr["TenThanhPhan"].ToString(), bandWidth);
                        // End Add band TenThanhPhanDiem
                    }
                    else
                    {
                        CongThucDiem = dr["CongThucDiem"].ToString();
                        IDKQHT_ThanhPhanTBHS = int.Parse(dr["KQHT_ThanhPhanDiemID"].ToString());
                    }
                }

                if (IDKQHT_ThanhPhanTBHS > 0)
                {
                    grbDKDuThi.Columns.Clear();
                    DataRow[] arrDr = dtThanhPhan.Select("KQHT_ThanhPhanDiemID = " + IDKQHT_ThanhPhanTBHS.ToString());
                    dtSinhVien.Columns.Add(IDKQHT_ThanhPhanTBHS.ToString() + "_1", typeof(double));
                    bgcTBHS = new BandedGridColumn();
                    grbDKDuThi.Columns.Add(bgcTBHS);

                    SetColumnBandCaption(bgcTBHS, "" + arrDr[0]["KyHieu"],
                        "" + arrDr[0]["KQHT_ThanhPhanDiemID"] + "_1", colWidth + 20, DevExpress.Utils.HorzAlignment.Default, false);

                    bandWidth += colWidth;

                    bgcTBHS.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    bgcTBHS.OptionsColumn.AllowEdit = false;
                    bgcTBHS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    bgcTBHS.DisplayFormat.FormatString = "n1";
                    bgrvDiem.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgcTBHS });

                    grbDKDuThi.Columns.Add(grcLyDo);
                    bgrvDiem.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { grcLyDo });
                }
                //// Tạo cột và hiển thị cột điểm tổng kết
                //if (IsNhapDiemTongKet)
                //{
                //    if (SoLanThi > 0)
                //    {
                //        grb = new GridBand();
                //        grbDiem.Children.AddRange(new GridBand[] { grb });
                //        bandWidth = 0;
                //        for (int i = 1; i <= SoLanThi; i++)
                //        {
                //            dtSinhVien.Columns.Add("TK_" + i.ToString(), typeof(double));
                //            ColEnd++;
                //            bgc = new BandedGridColumn();
                //            grb.Columns.Add(bgc);
                //            SetColumnBandCaption(bgc, "L" + i.ToString(), "TK_" + i.ToString(), colWidth, DevExpress.Utils.HorzAlignment.Default, false);
                //            bandWidth += colWidth;
                //            bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                //            bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                //            bgrvDiem.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });
                //        }
                //        SetBandCaption(grb, "Tổng kết", bandWidth);
                //    }
                //}
                // Add cột lý do không được dự thi vào
                dtSinhVien.Columns.Add("LyDo", typeof(string));
                // Add cột điểm trung bình môn học
                for (int i = 1; i <= SoLanThi; i++)
                {
                    dtSinhVien.Columns.Add("TK_" + i.ToString(), typeof(double));
                    dtSinhVien.Columns.Add("IDKQHT_XepLoai_" + i.ToString(), typeof(int));
                    if (i > 1)
                        dtSinhVien.Columns.Add(IDKQHT_ThanhPhanTBHS.ToString() + "_" + i.ToString(), typeof(double));
                }
            }
        }

        private void XuLyTable()
        {
            if (dtThanhPhan.Rows.Count > 0)
            {
                // Lấy điểm thành phần để hiển thị lên grid
                DataTable dtData = oBKQHT_DiemThanhPhan.GetDanhSach(pDM_LopInfo.DM_LopID, IDDM_MonHoc, IDXL_MonHocTrongKy,
                    Program.IDNamHoc, Program.HocKy, chkNhapDiemLan2.Checked ? 2 : 1, 0);
                DataRow drNew;
                if (dtData.Rows.Count > 0)
                {
                    // Thực hiện đưa danh sách và nhập các điểm thành phần (không có điểm thi) lên grid
                    string Ho_Dem = "";
                    string SV_SinhVienID = dtData.Rows[0]["SV_SinhVienID"].ToString();
                    drNew = dtSinhVien.NewRow();
                    drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                    drNew["MaSinhVien"] = dtData.Rows[0]["MaSinhVien"].ToString();
                    drNew["TenSV"] = GetTen(dtData.Rows[0]["HoVaTen"].ToString(), ref Ho_Dem);
                    drNew["HoVa"] = Ho_Dem;
                    drNew["NgaySinh"] = dtData.Rows[0]["NgaySinh"];
                    drNew["TenLop"] = dtData.Rows[0]["TenLop"].ToString();
                    drNew["LyDo"] = "" + dtData.Rows[0]["LyDo"];
                    drNew["SoTietHocLai"] = dtData.Rows[0]["SoTietHocLai"];
                    foreach (DataRow dr in dtData.Rows)
                    {
                        if (dr["SV_SinhVienID"].ToString() != SV_SinhVienID)
                        {
                            dtSinhVien.Rows.Add(drNew);

                            SV_SinhVienID = dr["SV_SinhVienID"].ToString();
                            drNew = dtSinhVien.NewRow();

                            drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                            drNew["MaSinhVien"] = dr["MaSinhVien"].ToString();
                            drNew["TenSV"] = GetTen(dr["HoVaTen"].ToString(), ref Ho_Dem);
                            drNew["HoVa"] = Ho_Dem;
                            drNew["NgaySinh"] = dr["NgaySinh"];
                            drNew["TenLop"] = dr["TenLop"].ToString();
                            drNew["LyDo"] = "" + dr["LyDo"];
                            drNew["SoTietHocLai"] = dr["SoTietHocLai"];

                            if ("" + dr["Diem"] != "")
                            {
                                drNew[dr["IDKQHT_ThanhPhanDiem"].ToString() + "_" + dr["DiemThu"]] = double.Parse(dr["Diem"].ToString());
                            }
                        }
                        else
                        {
                            if ("" + dr["Diem"] != "")
                                drNew[dr["IDKQHT_ThanhPhanDiem"].ToString() + "_" + dr["DiemThu"]] = double.Parse(dr["Diem"].ToString());
                        }
                    }
                    dtSinhVien.Rows.Add(drNew);
                }
                if (IDDM_MonHoc > 0)
                {
                    DataRow[] arrDr;
                    // Lấy điểm thi để hiển thị lên grid
                    if (IDThanhPhanThi != "")
                    {
                        dtData = oBKQHT_DiemThi.GetByLop(pDM_LopInfo.DM_LopID, IDDM_MonHoc, IDXL_MonHocTrongKy, Program.IDNamHoc, Program.HocKy);
                        if (dtData.Rows.Count > 0)
                        {
                            foreach (DataRow drSV in dtSinhVien.Rows)
                            {
                                arrDr = dtData.Select("IDSV_SinhVien = " + drSV["SV_SinhVienID"]);
                                if (arrDr.Length > 0)
                                {
                                    foreach (DataRow dr in arrDr)
                                    {
                                        if (int.Parse(dr["LanThi"].ToString()) <= SoLanThi)
                                            drSV[IDThanhPhanThi + "_" + dr["LanThi"]] = double.Parse(dr["Diem"].ToString());
                                    }
                                }
                            }
                        }
                    }
                    // Lấy điểm tổng kết để hiển thị lên grid
                    if (chkThiLan1.Checked || chkThiLan2.Checked)
                    {
                        dtData = oBKQHT_DiemTongKetMon.GetByLop(pDM_LopInfo.DM_LopID, IDDM_MonHoc, IDXL_MonHocTrongKy, Program.IDNamHoc, Program.HocKy);
                        if (dtData.Rows.Count > 0)
                        {
                            foreach (DataRow drSV in dtSinhVien.Rows)
                            {
                                arrDr = dtData.Select("IDSV_SinhVien = " + drSV["SV_SinhVienID"]);
                                if (arrDr.Length > 0)
                                {
                                    foreach (DataRow dr in arrDr)
                                    {
                                        if (int.Parse(dr["LanThi"].ToString()) <= SoLanThi)
                                        {
                                            drSV["TK_" + dr["LanThi"]] = double.Parse(dr["Diem"].ToString());
                                            drSV["IDKQHT_XepLoai_" + dr["LanThi"]] = dr["IDKQHT_XepLoai"];
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //// Lấy điểm danh để hiển thị lên grid
                    //dtData = oBKQHT_DiemDanh.GetByLop(pDM_LopInfo.DM_LopID, IDXL_MonHocTrongKy);
                    //if (dtData.Rows.Count > 0)
                    //{
                    //    foreach (DataRow drSV in dtSinhVien.Rows)
                    //    {
                    //        arrDr = dtData.Select("IDSV_SinhVien = " + drSV["SV_SinhVienID"]);
                    //        if (arrDr.Length > 0)
                    //        {
                    //            foreach (DataRow dr in arrDr)
                    //            {
                    //                if ("" + dr["CoLyDo"] != "")
                    //                    drSV["CoLyDo"] = int.Parse(dr["CoLyDo"].ToString());
                    //                if ("" + dr["KhongLyDo"] != "")
                    //                    drSV["KhongLyDo"] = int.Parse(dr["KhongLyDo"].ToString());
                    //            }
                    //        }
                    //    }
                    //}
                }
            }
        }

        private void bgvDiem_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void bgrvDiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (ThongBaoChon("Bạn có chắc chắn muốn xóa không?") == DialogResult.Yes)
                {
                    string TenCot = "";
                    int IDSV_SinhVien = 0;
                    int[] RowIndex = bgrvDiem.GetSelectedRows();

                    for (int i = 0; i < RowIndex.Length; i++)
                    {
                        DevExpress.XtraGrid.Columns.GridColumn[] GridCols = bgrvDiem.GetSelectedCells(RowIndex[i]);
                        for (int j = 0; j < GridCols.Length; j++)
                        {
                            IDSV_SinhVien = int.Parse(bgrvDiem.GetDataRow(RowIndex[i])["SV_SinhVienID"].ToString());
                            TenCot = GridCols[j].FieldName;
                            try
                            {
                                XoaDiemBySinhVien(IDSV_SinhVien, TenCot);
                                bgrvDiem.GetDataRow(RowIndex[i])[TenCot] = DBNull.Value;
                            }
                            catch { }
                        }
                    }
                    //dtSinhVien.AcceptChanges();
                }
            }
        }

        private void XoaDiemBySinhVien(int IDSV_SinhVien, string TenCot)
        {
            string ThanhPhanID;
            string[] arrThanhPhan;
            DataRow[] arrDr;

            if (TenCot.IndexOf("_") >= 0 && TenCot != "SV_SinhVienID")
            {
                arrThanhPhan = TenCot.Split('_');
                ThanhPhanID = arrThanhPhan[0];
                if (ThanhPhanID != "DiemTK")
                {
                    arrDr = dtThanhPhan.Select("KQHT_ThanhPhanDiemID = " + ThanhPhanID);
                    if (arrDr.Length > 0)
                    {
                        if (bool.Parse(arrDr[0]["Thi"].ToString()))
                        {
                            // Xóa điểm thi
                            if (!chkThiLan1.Checked)
                            {
                                // Nếu chưa chuyển điểm thi cho phòng đào tạo thì mới lưu
                                pKQHT_DiemThiInfo.IDDM_MonHoc = IDDM_MonHoc;
                                pKQHT_DiemThiInfo.IDDM_NamHoc = Program.IDNamHoc;
                                pKQHT_DiemThiInfo.HocKy = Program.HocKy;
                                pKQHT_DiemThiInfo.LanThi = int.Parse(arrThanhPhan[1]);
                                pKQHT_DiemThiInfo.IDSV_SinhVien = IDSV_SinhVien;

                                oBKQHT_DiemThi.DeleteByInfo(pKQHT_DiemThiInfo);
                            }
                        }
                        else
                        {
                            // Xóa điểm thành phần
                            if (!chkDiemThanhPhan.Checked)
                            {
                                // Nếu chưa chuyển điểm thành phần cho phòng đào tạo thì mới lưu
                                pKQHT_DiemThanhPhanInfo.IDDM_MonHoc = IDDM_MonHoc;
                                pKQHT_DiemThanhPhanInfo.IDXL_MonHocTrongKy = IDXL_MonHocTrongKy;
                                pKQHT_DiemThanhPhanInfo.IDDM_NamHoc = Program.IDNamHoc;
                                pKQHT_DiemThanhPhanInfo.HocKy = Program.HocKy;
                                pKQHT_DiemThanhPhanInfo.IDKQHT_ThanhPhanDiem = int.Parse(ThanhPhanID);
                                pKQHT_DiemThanhPhanInfo.DiemThu = int.Parse(arrThanhPhan[1]);
                                pKQHT_DiemThanhPhanInfo.IDSV_SinhVien = IDSV_SinhVien;

                                oBKQHT_DiemThanhPhan.DeleteByInfo(pKQHT_DiemThanhPhanInfo);
                            }
                        }
                    }
                }
            }
            // Xóa số tiết nghỉ
            if (!chkDiemThanhPhan.Checked)
            {
                if (TenCot == "CoLyDo" || TenCot == "KhongLyDo")
                {
                    oBKQHT_DiemDanh.DeleteByInfo(IDSV_SinhVien, IDXL_MonHocTrongKy, TenCot, chkNhapDiemLan2.Checked ? 2 : 1);
                }
            }
        }

        private void bgrvDiem_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (bgrvDiem.FocusedColumn.FieldName.IndexOf("_") >= 0 && bgrvDiem.FocusedColumn.FieldName != "SV_SinhVienID")
            {
                if (e.Value != null)
                {
                    if (e.Value.ToString().Trim() == "")
                    {
                        if ("" + bgrvDiem.GetDataRow(bgrvDiem.FocusedRowHandle)[bgrvDiem.FocusedColumn.FieldName] != "")
                        {
                            e.Valid = false;
                            e.ErrorText = "Nếu muốn xóa bạn phải bấm phím Delete.";
                        }
                    }
                    else
                    {
                        float diem;
                        if (float.TryParse(e.Value.ToString(), out diem))
                        {
                            if (diem < 0 || diem > 10)
                            {
                                e.Valid = false;
                                e.ErrorText = "Dữ liệu điểm nhập vào phải từ 0 đến 10.";
                            }
                        }
                        else
                        {
                            e.Valid = false;
                            e.ErrorText = "Dữ liệu điểm nhập vào phải là kiểu số.";
                        }
                    }
                }
            }
        }

        private void chkDiemThanhPhan_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkNhapDiemLan2.Checked)
            {
                btnDanhSachDuThi.Enabled = chkDiemThanhPhan.Checked;
                grbDKDuThi.Visible = chkDiemThanhPhan.Checked;
            }
            else
            {
                btnDanhSachDuThi.Enabled = true;
            }
        }

        private void chkThiLan1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThiLan1.Checked)
            {
                lciNhapDiemLan2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
                lciNhapDiemLan2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void chkNhapDiemLan2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNhapDiemLan2.Checked)
            {
                LoadSinhVien();
                bgcTBHS.FieldName = IDKQHT_ThanhPhanTBHS.ToString() + "_2";
            }
            else
            {
                LoadSinhVien();
                bgcTBHS.FieldName = IDKQHT_ThanhPhanTBHS.ToString() + "_1";
            }
            chkDiemThanhPhan_CheckedChanged(null, null);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (bgrvDiem.DataSource == null)
                this.Close();
            if (dtSinhVien.GetChanges() != null)
            {
                if (ThongBaoChon("Dữ liệu đã thay đổi, bạn có chắc chắn muốn thoát không?") != DialogResult.Yes)
                    return;
            }
            this.Close();
        }

        private void btnChuyenDiem_Click(object sender, EventArgs e)
        {
            if (grvMonHoc.DataSource == null)
                return;
            DataTable dtChange = dtSinhVien.GetChanges();
            if (dtChange != null)
            {
                btnCapNhat_Click(null, null);
            }

            dlgChuyenDiem dlg = new dlgChuyenDiem(chkDiemThanhPhan.Checked, chkThiLan1.Checked, chkDiemThanhPhanL2.Checked, chkThiLan2.Checked, chkNhapDiemLan2.Checked);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string msg = "", CongThucDiemTBM = "";
                KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo = new KQHT_DaChuyenDiemInfo();
                pKQHT_DaChuyenDiemInfo.IDXL_MonHocTrongKy = IDXL_MonHocTrongKy;
                try
                {
                    DataTable dt = ((DataView)bgrvDiem.DataSource).ToTable();
                    CongThucDiemTBM = (new cBKQHT_QuyChe()).GetByMaThamSo(pDM_LopInfo.IDDM_TrinhDo, "TBM_CONGTHUC");
                    if (chkDiemThanhPhan.Checked != dlg.chkDiemThanhPhan.Checked)
                    {
                        oBKQHT_DiemThanhPhan.TinhDiemTBHS_QCNghe(dt, drMonHoc, pDM_LopInfo.DM_LopID, pDM_LopInfo.IDDM_TrinhDo,
                            Program.IDNamHoc, Program.HocKy, IDKQHT_ThanhPhanTBHS, 1, CongThucDiem, Program.objUserCurrent.NS_GiaoVienID);
                        msg = " và tổng hợp trung bình hệ số";
                        chkDiemThanhPhan.Checked = dlg.chkDiemThanhPhan.Checked;
                        pKQHT_DaChuyenDiemInfo.DaNhapDiemThanhPhan = chkDiemThanhPhan.Checked;
                        pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemTP = Program.objUserCurrent.NS_GiaoVienID;
                    }
                    if (chkDiemThanhPhanL2.Checked != dlg.chkDiemThanhPhanL2.Checked)
                    {
                        oBKQHT_DiemThanhPhan.TinhDiemTBHS_QCNghe(dt, drMonHoc, pDM_LopInfo.DM_LopID, pDM_LopInfo.IDDM_TrinhDo,
                            Program.IDNamHoc, Program.HocKy, IDKQHT_ThanhPhanTBHS, 2, CongThucDiem, Program.objUserCurrent.NS_GiaoVienID);
                        msg = " và tổng hợp trung bình hệ số";
                        chkDiemThanhPhanL2.Checked = dlg.chkDiemThanhPhanL2.Checked;
                        pKQHT_DaChuyenDiemInfo.DaNhapDiemThanhPhanL2 = chkDiemThanhPhanL2.Checked;
                        pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemTP = Program.objUserCurrent.NS_GiaoVienID;
                    }
                    if (CongThucDiemTBM != "")
                    {
                        if (chkThiLan1.Checked != dlg.chkThiLan1.Checked)
                        {
                            oBKQHT_DiemTongKetMon.TinhDiemTBM(dt, dtXLMonHoc, drMonHoc, pDM_LopInfo.DM_LopID, pDM_LopInfo.IDDM_TrinhDo, IDThanhPhanThi, 
                                IDKQHT_ThanhPhanTBHS, 1, CongThucDiemTBM, Program.IDNamHoc, Program.HocKy, Program.objUserCurrent.NS_GiaoVienID);
                            msg += ", tính điểm lần 1";
                            chkThiLan1.Checked = dlg.chkThiLan1.Checked;
                            pKQHT_DaChuyenDiemInfo.DaNhapDiemThiL1 = chkThiLan1.Checked;
                            pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemThiL1 = Program.objUserCurrent.NS_GiaoVienID;

                        }
                        if (chkThiLan2.Checked != dlg.chkThiLan2.Checked)
                        {
                            oBKQHT_DiemTongKetMon.TinhDiemTBM(dt, dtXLMonHoc, drMonHoc, pDM_LopInfo.DM_LopID, pDM_LopInfo.IDDM_TrinhDo, IDThanhPhanThi, 
                                IDKQHT_ThanhPhanTBHS, 2, CongThucDiemTBM, Program.IDNamHoc, Program.HocKy, Program.objUserCurrent.NS_GiaoVienID);
                            msg += ", tính điểm lần 2";
                            chkThiLan2.Checked = dlg.chkThiLan2.Checked;
                            pKQHT_DaChuyenDiemInfo.DaNhapDiemThiL2 = chkThiLan2.Checked;
                            pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemThiL2 = Program.objUserCurrent.NS_GiaoVienID;
                        }
                    }
                    else if (msg == "")
                    {
                        ThongBao("Chưa có công thức điểm tổng kết môn học trong tham số quy chế !");
                        return;
                    }
                    oBKQHT_DaChuyenDiem.AddChuyen(pKQHT_DaChuyenDiemInfo);
                    grvMonHoc_FocusedRowChanged(null, null);
                    //chkNhapDiemLan2_CheckedChanged(null, null);
                    ThongBao("Đã chuyển điểm" + msg + " thành công.");
                }
                catch (Exception ex)
                {
                    ThongBaoLoi("Có lỗi khi cập nhật việc chuyển điểm: " + ex.Message);
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dtSinhVien == null)
            {
                ThongBao("Chưa có dữ liệu.");
                return;
            }
            DataTable dtTemp = dtSinhVien.GetChanges();
            if (dtTemp != null)
            {
                string ThanhPhanID;
                string[] arrThanhPhan;
                DataRow[] arrDr;

                pKQHT_DiemTongKetMonInfo.IDDM_MonHoc = IDDM_MonHoc;
                pKQHT_DiemTongKetMonInfo.IDXL_MonHocTrongKy = IDXL_MonHocTrongKy;
                pKQHT_DiemTongKetMonInfo.IDDM_NamHoc = Program.IDNamHoc;
                pKQHT_DiemTongKetMonInfo.HocKy = Program.HocKy;

                pKQHT_DiemThiInfo.IDDM_MonHoc = IDDM_MonHoc;
                pKQHT_DiemThiInfo.IDXL_MonHocTrongKy = IDXL_MonHocTrongKy;
                pKQHT_DiemThiInfo.IDDM_NamHoc = Program.IDNamHoc;
                pKQHT_DiemThiInfo.HocKy = Program.HocKy;
                pKQHT_DiemThiInfo.IDHT_User = Program.objUserCurrent.NS_GiaoVienID;

                pKQHT_DiemThanhPhanInfo.IDDM_MonHoc = IDDM_MonHoc;
                pKQHT_DiemThanhPhanInfo.IDXL_MonHocTrongKy = IDXL_MonHocTrongKy;
                pKQHT_DiemThanhPhanInfo.IDDM_NamHoc = Program.IDNamHoc;
                pKQHT_DiemThanhPhanInfo.HocKy = Program.HocKy;
                pKQHT_DiemThanhPhanInfo.IDHT_User = Program.objUserCurrent.NS_GiaoVienID;

                foreach (DataColumn dc in dtTemp.Columns)
                {
                    // Nhập các loại điểm
                    if (dc.ColumnName.IndexOf("_") >= 0 && dc.ColumnName != "SV_SinhVienID" && dc.ColumnName.IndexOf("IDKQHT_XepLoai") < 0)
                    {
                        arrThanhPhan = dc.ColumnName.Split('_');
                        ThanhPhanID = arrThanhPhan[0];
                        if (ThanhPhanID == "DiemTK")
                        {
                            // Lưu điểm tổng kết
                            pKQHT_DiemTongKetMonInfo.LanThi = int.Parse(arrThanhPhan[1]);

                            foreach (DataRow dr in dtTemp.Rows)
                            {
                                if ("" + dr[dc.ColumnName] != "")
                                {
                                    try
                                    {
                                        pKQHT_DiemTongKetMonInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                                        pKQHT_DiemTongKetMonInfo.Diem = double.Parse(dr[dc.ColumnName].ToString());
                                        oBKQHT_DiemTongKetMon.Add(pKQHT_DiemTongKetMonInfo);
                                    }
                                    catch
                                    { }
                                }
                            }
                        }
                        else
                        {
                            arrDr = dtThanhPhan.Select("KQHT_ThanhPhanDiemID = " + ThanhPhanID);
                            if (arrDr.Length > 0)
                            {
                                if (bool.Parse(arrDr[0]["Thi"].ToString()))
                                {
                                    // Lưu điểm thi lần 1
                                    if (!chkThiLan1.Checked && arrThanhPhan[1] == "1")
                                    {
                                        // Nếu chưa chuyển điểm thi cho phòng đào tạo thì mới lưu
                                        pKQHT_DiemThiInfo.LanThi = int.Parse(arrThanhPhan[1]);

                                        foreach (DataRow dr in dtTemp.Rows)
                                        {
                                            if ("" + dr[dc.ColumnName] != "")
                                            {
                                                try
                                                {
                                                    pKQHT_DiemThiInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                                                    pKQHT_DiemThiInfo.Diem = double.Parse(dr[dc.ColumnName].ToString());
                                                    oBKQHT_DiemThi.Add(pKQHT_DiemThiInfo);
                                                }
                                                catch
                                                { }
                                            }
                                        }
                                    }
                                    // Lưu điểm thi lần 2
                                    if (!chkThiLan2.Checked && arrThanhPhan[1] == "2")
                                    {
                                        // Nếu chưa chuyển điểm thi cho phòng đào tạo thì mới lưu
                                        pKQHT_DiemThiInfo.LanThi = int.Parse(arrThanhPhan[1]);

                                        foreach (DataRow dr in dtTemp.Rows)
                                        {
                                            if ("" + dr[dc.ColumnName] != "")
                                            {
                                                try
                                                {
                                                    pKQHT_DiemThiInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                                                    pKQHT_DiemThiInfo.Diem = double.Parse(dr[dc.ColumnName].ToString());
                                                    oBKQHT_DiemThi.Add(pKQHT_DiemThiInfo);
                                                }
                                                catch
                                                { }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // Lưu điểm thành phần
                                    if ((!chkDiemThanhPhan.Checked && !chkNhapDiemLan2.Checked) ||
                                        (!chkDiemThanhPhanL2.Checked && chkNhapDiemLan2.Checked))
                                    {
                                        // Nếu chưa chuyển điểm thành phần cho phòng đào tạo thì mới lưu
                                        pKQHT_DiemThanhPhanInfo.IDKQHT_ThanhPhanDiem = int.Parse(ThanhPhanID);
                                        pKQHT_DiemThanhPhanInfo.DiemThu = int.Parse(arrThanhPhan[1]);

                                        foreach (DataRow dr in dtTemp.Rows)
                                        {
                                            if ("" + dr[dc.ColumnName] != "")
                                            {
                                                try
                                                {
                                                    pKQHT_DiemThanhPhanInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                                                    pKQHT_DiemThanhPhanInfo.Diem = double.Parse(dr[dc.ColumnName].ToString());
                                                    oBKQHT_DiemThanhPhan.Add(pKQHT_DiemThanhPhanInfo);
                                                }
                                                catch
                                                { }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                // Lưu số tiết nghỉ
                if ((!chkDiemThanhPhan.Checked && !chkNhapDiemLan2.Checked) ||
                    (!chkDiemThanhPhanL2.Checked && chkNhapDiemLan2.Checked))
                {
                    pKQHT_DanhSachKhongThiInfo = new KQHT_DanhSachKhongThiInfo();
                    pKQHT_DanhSachKhongThiInfo.IDDM_MonHoc = IDDM_MonHoc;
                    pKQHT_DanhSachKhongThiInfo.IDDM_NamHoc = Program.IDNamHoc;
                    pKQHT_DanhSachKhongThiInfo.HocKy = Program.HocKy;
                    if (!chkNhapDiemLan2.Checked)
                        pKQHT_DanhSachKhongThiInfo.LanThi = 1;
                    else
                        pKQHT_DanhSachKhongThiInfo.LanThi = 2;

                    foreach (DataRow dr in dtTemp.Rows)
                    {
                        // Lưu số tiết học lại
                        if ("" + dr["SoTietHocLai"] != "")
                        {
                            pKQHT_DanhSachKhongThiInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                            pKQHT_DanhSachKhongThiInfo.SoTietHocLai = int.Parse(dr["SoTietHocLai"].ToString());
                            pKQHT_DanhSachKhongThiInfo.LyDo = "" + dr["LyDo"];
                            try
                            {
                                oBKQHT_DanhSachKhongThi.AddTuDong(pKQHT_DanhSachKhongThiInfo);
                            }
                            catch
                            { }
                        }
                        //if ("" + dr["CoLyDo"] != "" || "" + dr["KhongLyDo"] != "")
                        //{
                        //    pKQHT_DiemDanhInfo = new KQHT_DiemDanhInfo();
                        //    pKQHT_DiemDanhInfo.IDXL_MonHocTrongKy = IDXL_MonHocTrongKy;
                        //    pKQHT_DiemDanhInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                        //    if ("" + dr["CoLyDo"] != "")
                        //        pKQHT_DiemDanhInfo.CoLyDo = int.Parse(dr["CoLyDo"].ToString());
                        //    if ("" + dr["KhongLyDo"] != "")
                        //        pKQHT_DiemDanhInfo.KhongLyDo = int.Parse(dr["KhongLyDo"].ToString());
                        //    try
                        //    {
                        //        oBKQHT_DiemDanh.Add(pKQHT_DiemDanhInfo);
                        //    }
                        //    catch
                        //    { }
                        //}
                    }
                }
                dtSinhVien.AcceptChanges();
                ThongBao("Cập nhật thành công!");
            }
            else
                ThongBao("Không có sự thay đổi trên dữ liệu!");
        }

        private void btnInPhieuDiem_Click(object sender, EventArgs e)
        {
            DataTable dtMain = oBKQHT_DiemThanhPhan.CreateTableReportMain();
            DataRow dr = dtMain.NewRow();
            dr["TenMonHoc"] = drMonHoc["TenMonHoc"];
            dr["TenLop"] = pDM_LopInfo.TenLop.Replace("Lớp: ", "");
            dr["HocKy"] = Program.HocKy;
            dr["NamHoc"] = Program.NamHoc;
            dr["SoTiet"] = drMonHoc["SoTiet"];
            dtMain.Rows.Add(dr);
            DataTable dtSub = oBKQHT_DiemThanhPhan.CreateTableReportSub_QCNghe(dtSinhVien, dtThanhPhan, ColStart, IDKQHT_ThanhPhanTBHS);
            frmReport frm = new frmReport(dtMain, dtSub, "rBangKetQuaHocTap_QCNghe", "rBangKetQuaHocTap_QCNghe_Sub", new string[] { "SubReport1" });
            frm.Show();
        }

        #region Xuat bang ket qua hoc tap
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dtSinhVien == null || dtSinhVien.Rows.Count == 0)
            {
                ThongBao("Không có dữ liệu để xuất ra excel!");
                return;
            }
            XuatPhieuNhapDiem();
        }

        private void XuatPhieuNhapDiem()
        {
            string strFileExcel = Application.StartupPath + "\\Template\\Temp_PhieuNhapDiem_QCNghe.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + "! Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                return;
            }

            SaveFileDialog sv = new SaveFileDialog();
            sv.FileName = "PhieuNhapDiem_" + pDM_LopInfo.TenLop.Replace("Lớp: ", "") + ".xls";
            sv.Filter = "Excel file (*.xls)|*.xls";
            sv.Title = "Xuất dữ liệu";
            if (sv.ShowDialog() == DialogResult.OK)
            {
                string strTenFileExcelMoi = sv.FileName;
                try
                {
                    File.Copy(strFileExcel, strTenFileExcelMoi, true);
                }
                catch (Exception ex)
                {
                    ThongBaoLoi("File excel đang được mở. Đề nghị đóng file này trước khi xuất dữ liệu! Thông báo lỗi: " + ex.Message);
                    return;
                }
                finally { }
                DataTable dt = ((DataView)bgrvDiem.DataSource).ToTable();
                XuatPhieuNhapRaExcel(dt, strTenFileExcelMoi);
                ThongBao("Xuất dữ liệu thành công!");
            }
        }

        private void XuatPhieuNhapRaExcel(DataTable dtChiTiet, string FileExcel)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int DongBatDau = _DongBatDau, CotBatDau = _CotBatDau, SoCot = ColStart;
            Excel.Range cel;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);

                //// Ten mon
                //cel = (Excel.Range)excel.Cells[5, 2];
                //excel.Cells[5, 2] = cel.Text + " " + drMonHoc["TenMonHoc"].ToString();

                //cel = (Excel.Range)excel.Cells[5, 5];
                excel.Cells[5, 5] = "'- " + pDM_LopInfo.TenLop;

                cel = (Excel.Range)excel.Cells[6, 2];
                excel.Cells[6, 2] = cel.Text + " " + Program.HocKy.ToString();

                cel = (Excel.Range)excel.Cells[6, 5];
                excel.Cells[6, 5] = cel.Text + " " + Program.NamHoc;

                //cel = (Excel.Range)excel.Cells[7, 2];
                //excel.Cells[7, 2] = cel.Text + " " + drMonHoc["SoTiet"];

                //cel = (Excel.Range)excel.Cells[7, 5];
                //excel.Cells[7, 5] = cel.Text + " " + drMonHoc["SoTiet"];

                // Insert columns
                string strFieldName = "";
                if (grbDiem.Children.Count > 0)
                {
                    int CotDau = CotBatDau;
                    for (int i = 0; i < grbDiem.Children.Count; i++)
                    {
                        foreach (BandedGridColumn bgc in grbDiem.Children[i].Columns)
                        {
                            cel = (Excel.Range)(excel.Cells[11, CotBatDau]);
                            cel.EntireColumn.Insert(Excel.XlDirection.xlToRight, null);
                            SoCot++;
                            excel.Cells[11, CotBatDau] = bgc.Caption;
                            strFieldName += bgc.FieldName + ",";
                            CotBatDau++;
                        }
                        excel.Cells[10, CotDau] = grbDiem.Children[i].Caption;
                        cel = excel.get_Range(excel.Cells[10, CotDau], excel.Cells[10, CotBatDau - 1]);
                        cel.Merge(null);
                        cel.Borders.Value = 1;
                        CotDau = CotBatDau;
                    }
                    excel.Cells[9, 6] = "ĐIỂM";
                    cel = excel.get_Range(excel.Cells[9, 6], excel.Cells[9, CotBatDau - 1]);
                    cel.Merge(null);
                    cel.Borders.Value = 1;
                }

                for (int i = 6; i < CotBatDau; i++)
                {
                    cel = (Excel.Range)(excel.Cells[11, i]);
                    cel.ColumnWidth = 3.57;
                }

                for (int i = 0; i < dtChiTiet.Rows.Count; i++)
                {
                    // Insert rows
                    cel = (Excel.Range)(excel.Cells[DongBatDau + i + 1, 1]);
                    cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);

                    for (int l = 1; l <= (_CotBatDau + strFieldName.Substring(0, strFieldName.Length - 1).Split(',').Length - 1 + 2); l++)
                    {
                        cel = (Excel.Range)(excel.Cells[DongBatDau + i, l]);
                        cel.Borders.Value = 1;
                    }

                    excel.Cells[i + DongBatDau, 1] = i + 1;

                    excel.Cells[i + DongBatDau, 2] = "" + dtChiTiet.Rows[i]["MaSinhVien"];

                    excel.Cells[i + DongBatDau, 3] = "" + dtChiTiet.Rows[i]["HoVa"];

                    excel.Cells[i + DongBatDau, 4] = "" + dtChiTiet.Rows[i]["TenSV"];

                    if (chkNhapDiemLan2.Checked)
                    {
                        string[] arrStr = strFieldName.Remove(strFieldName.Length - 1).Split(',');
                        for (int j = 0; j < arrStr.Length; j++)
                        {
                            if ("" + dtChiTiet.Rows[i][arrStr[j]] != "")
                            {
                                excel.Cells[i + DongBatDau, _CotBatDau + j] = dtChiTiet.Rows[i][arrStr[j]] + "";
                            }
                        }
                    }
                }
                excel.Visible = true;
                //Process.Start(FileExcel);
            }
            catch (Exception e)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ThongBaoLoi("Xuất dữ liệu không thành công! Hãy đóng file Excel Phiếu báo điểm trước khi xuất dữ liệu. Thông báo lỗi: " + e.Message);
                return;
            }
            finally
            {
                excel.Application.Workbooks[1].Save();
                //excel.Application.Workbooks.Close();
                //excel.Application.Quit();
                //excel.Quit();
                CloseWaitDialog();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
        #endregion

        #region Nhập dữ liệu điểm từ file Excel
        private void btnNhapExcel_Click(object sender, EventArgs e)
        {
            // Bảng nhập điểm lấy luôn bảng điểm đã hiển thị trên grid
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel file (*.xls)|*.xls";
            ofd.Title = "Nhập điểm từ file Excel";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                NhapDiemTuFileExcel(ofd.FileName);
            }
        }

        private void NhapDiemTuFileExcel(string FileExcel)
        {
            Lib.clsExportToExcel clsExcel = new Lib.clsExportToExcel();
            CreateWaitDialog("Đang nhập dữ liệu từ file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Range cel;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                if (!dtSinhVien.Columns.Contains("GhiChu"))
                {
                    dtSinhVien.Columns.Add("GhiChu", typeof(string));
                    grcGhiChu.Visible = true;
                }
                else
                {
                    dtSinhVien.Columns.Remove("GhiChu");
                    dtSinhVien.Columns.Add("GhiChu", typeof(string));
                }
                DataRow[] arrDr;
                double diem;
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);
                int i = _DongBatDau;
                cel = (Excel.Range)(excel.Cells[i, 2]);
                while ("" + cel.Text != "")
                {
                    arrDr = dtSinhVien.Select("MaSinhVien = '" + ("" + cel.Text).Trim() + "'");
                    if (arrDr.Length > 0)
                    {
                        // Chuyển dữ liệu điểm
                        for (int j = 0; j < ColEnd - ColStart; j++)
                        {
                            cel = (Excel.Range)(excel.Cells[i, _CotBatDau + j]);
                            if (("" + cel.Text).Trim() != "")
                            {
                                if (double.TryParse(cel.Text.ToString().Trim(), out diem))
                                {
                                    if (0 <= diem && diem <= 10.0)
                                    {
                                        arrDr[0][ColStart + j] = diem;
                                    }
                                    else
                                    {
                                        arrDr[0]["GhiChu"] = "" + arrDr[0]["GhiChu"] + "Ô " + clsExcel.TinhToaDo(i, j + _CotBatDau) + " có giá trị vượt quá giới hạn cho phép; ";
                                    }
                                }
                                else
                                {
                                    arrDr[0]["GhiChu"] = "" + arrDr[0]["GhiChu"] + "Ô " + clsExcel.TinhToaDo(i, j + _CotBatDau) + " có giá trị không đúng định dạng kiểu số; ";
                                }
                            }
                        }
                        // Chuyển dữ liệu số tiết học lại
                        cel = (Excel.Range)(excel.Cells[i, _CotBatDau + ColEnd - ColStart]);
                        int SoTiet;
                        if (("" + cel.Text).Trim() != "")
                        {
                            if (int.TryParse(cel.Text.ToString().Trim(), out SoTiet))
                            {
                                arrDr[0]["SoTietHocLai"] = SoTiet;
                            }
                            else
                            {
                                arrDr[0]["GhiChu"] = "" + arrDr[0]["GhiChu"] + "Ô số tiết học lại có giá trị không đúng định dạng kiểu số nguyên; ";
                            }
                        }
                        //// Chuyển dữ liệu số tiết nghỉ
                        //// Có lý do
                        //cel = (Excel.Range)(excel.Cells[i, _CotBatDau + ColEnd - ColStart]);
                        //int SoTiet;
                        //if (("" + cel.Text).Trim() != "")
                        //{
                        //    if (int.TryParse(cel.Text.ToString().Trim(), out SoTiet))
                        //    {
                        //        arrDr[0]["CoLyDo"] = SoTiet;
                        //    }
                        //    else
                        //    {
                        //        arrDr[0]["GhiChu"] = "" + arrDr[0]["GhiChu"] + "Ô có lý do có giá trị không đúng định dạng kiểu số nguyên; ";
                        //    }
                        //}
                        //// Không lý do
                        //cel = (Excel.Range)(excel.Cells[i, _CotBatDau + ColEnd - ColStart + 1]);
                        //if (("" + cel.Text).Trim() != "")
                        //{
                        //    if (int.TryParse(cel.Text.ToString().Trim(), out SoTiet))
                        //    {
                        //        arrDr[0]["KhongLyDo"] = SoTiet;
                        //    }
                        //    else
                        //    {
                        //        arrDr[0]["GhiChu"] = "" + arrDr[0]["GhiChu"] + "Ô K LD có giá trị không đúng định dạng kiểu số nguyên; ";
                        //    }
                        //}
                    }
                    i++;
                    cel = (Excel.Range)(excel.Cells[i, 2]);
                }
                bgrvDiem.RefreshData();
            }
            catch (Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ThongBaoLoi("Nhập dữ liệu không thành công! Hãy đóng file Excel Phiếu báo điểm trước khi nhập dữ liệu. Thông báo lỗi: " + ex.Message);
            }
            finally
            {
                excel.Application.Workbooks.Close();
                excel.Application.Quit();
                excel.Quit();
                CloseWaitDialog();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
        #endregion

        #region Xuất danh sách dự thi ra Excel
        private void btnDanhSachDuThi_Click(object sender, EventArgs e)
        {
            if (dtSinhVien == null || dtSinhVien.Rows.Count == 0)
            {
                ThongBao("Không có dữ liệu để xuất ra excel!");
                return;
            }
            XuatDanhSachDuThi();
        }

        private void XuatDanhSachDuThi()
        {
            string strFileExcel = Application.StartupPath + "\\Template\\Temp_DanhSachDuThi_SS.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + "! Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                return;
            }

            SaveFileDialog sv = new SaveFileDialog();
            if (chkNhapDiemLan2.Checked)
                sv.FileName = "DSDT_" + pDM_LopInfo.TenLop.Replace("Lớp: ", "") + "_" + drMonHoc["MaMonHoc"] + "_L2.xls";
            else
                sv.FileName = "DSDT_" + pDM_LopInfo.TenLop.Replace("Lớp: ", "") + "_" + drMonHoc["MaMonHoc"] + ".xls";
            sv.Filter = "Excel file (*.xls)|*.xls";
            sv.Title = "Xuất dữ liệu";
            if (sv.ShowDialog() == DialogResult.OK)
            {
                string strTenFileExcelMoi = sv.FileName;
                try
                {
                    File.Copy(strFileExcel, strTenFileExcelMoi, true);
                }
                catch (Exception ex)
                {
                    ThongBaoLoi("File excel đang được mở. Đề nghị đóng file này trước khi xuất dữ liệu! Thông báo lỗi: " + ex.Message);
                    return;
                }
                finally { }
                DataTable dt = ((DataView)bgrvDiem.DataSource).ToTable();
                XuatDanhSachDuThiRaExcel(dt, strTenFileExcelMoi);
                ThongBao("Xuất dữ liệu thành công!");
            }
        }

        private void XuatDanhSachDuThiRaExcel(DataTable dtChiTiet, string FileExcel)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int DongBatDau = 11, SoCot = 9, SoDongThem = 0;
            Excel.Range cel;
            DataTable dtKhongThi;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);

                if (chkNhapDiemLan2.Checked)
                {
                    cel = (Excel.Range)excel.Cells[3, 1];
                    excel.Cells[3, 1] = cel.Text + " LẦN 2";
                }
                // Ten mon
                cel = (Excel.Range)excel.Cells[4, 2];
                excel.Cells[4, 2] = cel.Text + drMonHoc["TenMonHoc"].ToString();

                cel = (Excel.Range)excel.Cells[4, 7];
                excel.Cells[4, 7] = cel.Text + pDM_LopInfo.TenLop.Replace("Lớp: ", "");

                cel = (Excel.Range)excel.Cells[5, 2];
                excel.Cells[5, 2] = cel.Text + " " + Program.HocKy.ToString();

                cel = (Excel.Range)excel.Cells[5, 7];
                excel.Cells[5, 7] = cel.Text + " " + Program.NamHoc;

                //cel = (Excel.Range)excel.Cells[7, 2];
                //excel.Cells[7, 2] = cel.Text + " " + drMonHoc["SoTiet"];

                //cel = (Excel.Range)excel.Cells[7, 5];
                //excel.Cells[7, 5] = cel.Text + " " + drMonHoc["SoTiet"];
                dtKhongThi = dtChiTiet.Clone();
                foreach (DataRow dr in dtChiTiet.Rows)
                {
                    if (("" + dr["LyDo"]).Trim() == "")
                    {
                        // Insert rows
                        cel = (Excel.Range)(excel.Cells[DongBatDau + SoDongThem + 1, 1]);
                        cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                        excel.Cells[SoDongThem + DongBatDau, 1] = SoDongThem + 1;
                        excel.Cells[SoDongThem + DongBatDau, 2] = "" + dr["MaSinhVien"];
                        excel.Cells[SoDongThem + DongBatDau, 3] = "" + dr["HoVa"];
                        excel.Cells[SoDongThem + DongBatDau, 4] = "" + dr["TenSV"];

                        SoDongThem++;
                    }
                    else
                        dtKhongThi.ImportRow(dr);
                }

                // Set style
                cel = excel.get_Range(excel.Cells[DongBatDau, 1], excel.Cells[DongBatDau + SoDongThem - 1, SoCot]);
                cel.Borders.LineStyle = Excel.XlLineStyle.xlDot;
                cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;

                cel = excel.get_Range(excel.Cells[DongBatDau, 1], excel.Cells[DongBatDau + SoDongThem - 1, 1]);
                cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                for (int i = 1; i <= SoCot; i++)
                {
                    cel = excel.get_Range(excel.Cells[DongBatDau, i], excel.Cells[DongBatDau + SoDongThem - 1, i]);
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    if (i != 3)
                        cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    else
                        cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                }
                cel = excel.get_Range(excel.Cells[DongBatDau + SoDongThem - 1, 1], excel.Cells[DongBatDau + SoDongThem - 1, SoCot]);
                cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;

                // Danh sách sinh viên không đủ điều kiện dự thi
                if (dtKhongThi.Rows.Count > 0)
                {
                    int STT = 1;
                    DongBatDau = DongBatDau + SoDongThem + 3;
                    SoDongThem = 0;
                    foreach (DataRow dr in dtKhongThi.Rows)
                    {
                        // Insert rows
                        cel = (Excel.Range)(excel.Cells[DongBatDau + SoDongThem + 1, 1]);
                        cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                        excel.Cells[SoDongThem + DongBatDau, 1] = STT;
                        excel.Cells[SoDongThem + DongBatDau, 2] = "" + dr["MaSinhVien"];
                        excel.Cells[SoDongThem + DongBatDau, 3] = "" + dr["HoVa"];
                        excel.Cells[SoDongThem + DongBatDau, 4] = "" + dr["TenSV"];
                        excel.Cells[SoDongThem + DongBatDau, 5] = "" + dr["LyDo"];
                        cel = excel.get_Range(excel.Cells[DongBatDau + SoDongThem, 5], excel.Cells[DongBatDau + SoDongThem, 9]);
                        cel.Merge(null);
                        cel.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        STT++;
                        SoDongThem++;
                    }

                    // Set style
                    cel = excel.get_Range(excel.Cells[DongBatDau, 1], excel.Cells[DongBatDau + SoDongThem - 1, SoCot]);
                    cel.Borders.LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;

                    cel = excel.get_Range(excel.Cells[DongBatDau, 1], excel.Cells[DongBatDau + SoDongThem - 1, 1]);
                    cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    for (int i = 1; i <= SoCot; i++)
                    {
                        cel = excel.get_Range(excel.Cells[DongBatDau, i], excel.Cells[DongBatDau + SoDongThem - 1, i]);
                        cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                        if (i != 3)
                            cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                        else
                            cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                    }
                    cel = excel.get_Range(excel.Cells[DongBatDau + SoDongThem - 1, 1], excel.Cells[DongBatDau + SoDongThem - 1, SoCot]);
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                }
                else
                {
                    // Xóa 2 dòng danh sách không đủ điều kiện dự thi
                    cel = (Excel.Range)(excel.Cells[DongBatDau + SoDongThem + 1, 1]);
                    cel.EntireRow.Delete(Excel.XlDirection.xlDown);
                    cel = (Excel.Range)(excel.Cells[DongBatDau + SoDongThem + 1, 1]);
                    cel.EntireRow.Delete(Excel.XlDirection.xlDown);
                    cel = (Excel.Range)(excel.Cells[DongBatDau + SoDongThem + 1, 1]);
                    cel.EntireRow.Delete(Excel.XlDirection.xlDown);
                }

                excel.Visible = true;
                //Process.Start(FileExcel);
            }
            catch (Exception e)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                excel.Application.Workbooks.Close();
                excel.Application.Quit();
                excel.Quit();
                ThongBaoLoi("Xuất dữ liệu không thành công! Hãy đóng file Excel Phiếu báo điểm trước khi xuất dữ liệu. Thông báo lỗi: " + e.Message);
                CloseWaitDialog();
                this.Cursor = System.Windows.Forms.Cursors.Default;
                return;
            }
            finally
            {
                excel.Application.Workbooks[1].Save();
                CloseWaitDialog();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
        #endregion
    }
}