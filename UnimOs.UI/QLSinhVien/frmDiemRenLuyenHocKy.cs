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

namespace UnimOs.UI
{
    public partial class frmDiemRenLuyenHocKy : frmBase
    {
        private cBSV_DiemRenLuyen oBSV_DiemRenLuyen;
        private cBSV_DiemRenLuyenTheoThang oBSV_DiemRenLuyenTheoThang;
        private SV_DiemRenLuyenTheoThangInfo pSV_DiemRenLuyenTheoThangInfo;
        private DM_LopInfo pDM_LopInfo;
        private DataTable dtDiemRenLuyen, dtXepLoaiRenLuyen, dtThang;

        public frmDiemRenLuyenHocKy()
        {
            InitializeComponent();

            pDM_LopInfo = new DM_LopInfo();
            oBSV_DiemRenLuyen = new cBSV_DiemRenLuyen();
            oBSV_DiemRenLuyenTheoThang = new cBSV_DiemRenLuyenTheoThang();
            pSV_DiemRenLuyenTheoThangInfo = new SV_DiemRenLuyenTheoThangInfo();
        }

        private void frmDiemRenLuyenHocKy_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
            dtXepLoaiRenLuyen = LoadXepLoaiRenLuyen();
            repositoryCmbXepLoaiKy.DataSource = dtXepLoaiRenLuyen;
            dtDiemRenLuyen = CreateTable();
            AddBand();
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            LoadDiemRenLuyen();
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SV_SinhVienID", typeof(int));
            dt.Columns.Add("MaSinhVien", typeof(string));
            dt.Columns.Add("HoVa", typeof(string));
            dt.Columns.Add("TenSV", typeof(string));
            dt.Columns.Add("SoDiemKy", typeof(double));
            dt.Columns.Add("XepLoaiRenLuyenKy", typeof(int));
            dt.Columns.Add("NhanXetKy", typeof(string));
            return dt;
        }

        private void LoadDiemRenLuyen()
        {
            XuLyTable();
            grdDiemRenLuyen.DataSource = dtDiemRenLuyen;
            dtDiemRenLuyen.AcceptChanges();
        }

        private void AddBand()
        {
            BandedGridColumn bgc;
            GridBand grbThang;
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit RepositoryItemCmd;
            dtThang = new cBSV_ThangRenLuyenTrongKy().GetByHocKyNamHoc(Program.IDNamHoc, Program.HocKy);
            if (dtThang.Rows.Count > 0)
            {
                foreach (DataRow dr in dtThang.Rows)
                {
                    dtDiemRenLuyen.Columns.Add("SoDiem_" + dr["SV_ThangRenLuyenTrongKyID"], typeof(double));
                    dtDiemRenLuyen.Columns.Add("XepLoaiRenLuyen_" + dr["SV_ThangRenLuyenTrongKyID"], typeof(int));

                    grbThang = new GridBand();
                    grbTheoThang.Children.AddRange(new GridBand[] { grbThang });

                    // Add cột số điểm của tháng
                    bgc = new BandedGridColumn();
                    grbThang.Columns.Add(bgc);

                    SetColumnBandCaption(bgc, "Số điểm", "SoDiem_" + dr["SV_ThangRenLuyenTrongKyID"], 66, DevExpress.Utils.HorzAlignment.Default, false);
                    bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;

                    bgrvDiemRenLuyen.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });

                    // Add cột xếp loại của tháng
                    RepositoryItemCmd = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                    bgc = new BandedGridColumn();
                    bgc.OptionsColumn.AllowEdit = false;
                    grdDiemRenLuyen.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                        RepositoryItemCmd});
                    bgc.ColumnEdit = RepositoryItemCmd;

                    // repositoryItemLookUpEdit_XepLoaiRenLuyen
                    RepositoryItemCmd.AutoHeight = false;
                    RepositoryItemCmd.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenXepLoaiRenLuyen", 20, "Xếp loại")});
                    RepositoryItemCmd.Name = "RepositoryItemCmd" + dr["SV_ThangRenLuyenTrongKyID"];
                    RepositoryItemCmd.DataSource = dtXepLoaiRenLuyen;
                    RepositoryItemCmd.DisplayMember = "TenXepLoaiRenLuyen";
                    RepositoryItemCmd.ValueMember = "DM_XepLoaiRenLuyenID";
                    RepositoryItemCmd.NullText = "";

                    grbThang.Columns.Add(bgc);

                    SetColumnBandCaption(bgc, "Xếp loại", "XepLoaiRenLuyen_" + dr["SV_ThangRenLuyenTrongKyID"], 100, DevExpress.Utils.HorzAlignment.Default, false);
                    bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;

                    bgrvDiemRenLuyen.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });

                    SetBandCaption(grbThang, "Tháng " + dr["Thang"], 165);
                }
            }
            else
                grbTheoThang.Visible = false;
        }

        private void XuLyTable()
        {
            DataTable dtRenLuyenHocKy = oBSV_DiemRenLuyen.GetByLop(pDM_LopInfo.DM_LopID, Program.IDNamHoc);
            DataTable dtRenLuyenThang = oBSV_DiemRenLuyenTheoThang.GetByLop(pDM_LopInfo.DM_LopID, Program.IDNamHoc, Program.HocKy);
            DataRow drNew;
            DataRow[] drThang;
            dtDiemRenLuyen.Rows.Clear();
            try
            {
                if (dtRenLuyenHocKy.Rows.Count > 0)
                {
                    foreach (DataRow drKy in dtRenLuyenHocKy.Rows)
                    {
                        string SV_SinhVienID = drKy["SV_SinhVienID"].ToString(), Ho_Dem = "";

                        drNew = dtDiemRenLuyen.NewRow();
                        drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                        drNew["MaSinhVien"] = drKy["MaSinhVien"].ToString();
                        drNew["TenSV"] = GetTen(drKy["HoVaTen"].ToString(), ref Ho_Dem);
                        drNew["HoVa"] = Ho_Dem;
                        drNew["SoDiemKy"] = drKy["SoDiemKy" + Program.HocKy.ToString()];
                        drNew["XepLoaiRenLuyenKy"] = drKy["IDDM_XepLoaiRenLuyenKy" + Program.HocKy.ToString()];

                        drThang = dtRenLuyenThang.Select("IDSV_SinhVien = " + SV_SinhVienID);

                        foreach (DataRow dr in drThang)
                        {
                            drNew["SoDiem_" + dr["IDSV_ThangRenLuyenTrongKy"]] = dr["SoDiem"];
                            drNew["XepLoaiRenLuyen_" + dr["IDSV_ThangRenLuyenTrongKy"]] = dr["IDDM_XepLoaiRenLuyen"];
                        }
                        dtDiemRenLuyen.Rows.Add(drNew);
                    }
                }
            }
            catch
            { }
        }

        private void btnThemThang_Click(object sender, EventArgs e)
        {
            dlgThemThangRenLuyen dlg = new dlgThemThangRenLuyen(ref dtThang);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                int idxThang = dtThang.Rows.Count - 1;

                dtDiemRenLuyen.Columns.Add("SoDiem_" + dtThang.Rows[idxThang]["SV_ThangRenLuyenTrongKyID"], typeof(double));
                dtDiemRenLuyen.Columns.Add("XepLoaiRenLuyen_" + dtThang.Rows[idxThang]["SV_ThangRenLuyenTrongKyID"], typeof(int));

                GridBand grbThang = new GridBand();
                grbTheoThang.Children.AddRange(new GridBand[] { grbThang });
                DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit RepositoryItemCmd;

                // Add cột số điểm của tháng
                BandedGridColumn bgc = new BandedGridColumn();
                grbThang.Columns.Add(bgc);

                SetColumnBandCaption(bgc, "Số điểm", "SoDiem_" + dtThang.Rows[idxThang]["SV_ThangRenLuyenTrongKyID"], 65, DevExpress.Utils.HorzAlignment.Default, false);
                bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                bgc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                bgc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                bgrvDiemRenLuyen.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });

                // Add cột xếp loại của tháng
                RepositoryItemCmd = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                bgc = new BandedGridColumn();
                bgc.OptionsColumn.AllowEdit = false;
                grdDiemRenLuyen.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                        RepositoryItemCmd});
                bgc.ColumnEdit = RepositoryItemCmd;

                // repositoryItemLookUpEdit_XepLoaiRenLuyen
                RepositoryItemCmd.AutoHeight = false;
                RepositoryItemCmd.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                     new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenXepLoaiRenLuyen", 20, "Xếp loại")});
                RepositoryItemCmd.Name = "RepositoryItemCmd" + dtThang.Rows[idxThang]["SV_ThangRenLuyenTrongKyID"];
                RepositoryItemCmd.DataSource = dtXepLoaiRenLuyen;
                RepositoryItemCmd.DisplayMember = "TenXepLoaiRenLuyen";
                RepositoryItemCmd.ValueMember = "DM_XepLoaiRenLuyenID";
                RepositoryItemCmd.NullText = "";

                grbThang.Columns.Add(bgc);

                SetColumnBandCaption(bgc, "Xếp loại", "XepLoaiRenLuyen_" + dtThang.Rows[idxThang]["SV_ThangRenLuyenTrongKyID"], 100, DevExpress.Utils.HorzAlignment.Default, false);
                bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                bgc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                bgc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                bgrvDiemRenLuyen.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });

                SetBandCaption(grbThang, "Tháng " + dtThang.Rows[idxThang]["Thang"], 165);

                grbTheoThang.Visible = true;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataTable dtChange = dtDiemRenLuyen.GetChanges();
            if (dtChange == null)
            {
                ThongBao("Không có dữ liệu thay đổi.");
                return;
            }
            string IDSV_ThangRenLuyenTrongKy;
            try
            {
                foreach (DataColumn dc in dtChange.Columns)
                {
                    if (dc.ColumnName.IndexOf("SoDiem_") >= 0)
                    {
                        IDSV_ThangRenLuyenTrongKy = dc.ColumnName.Split('_')[1];
                        pSV_DiemRenLuyenTheoThangInfo.IDSV_ThangRenLuyenTrongKy = int.Parse(IDSV_ThangRenLuyenTrongKy);
                        foreach (DataRow dr in dtChange.Rows)
                        {
                            // Lưu điểm rèn luyện tháng
                            pSV_DiemRenLuyenTheoThangInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                            pSV_DiemRenLuyenTheoThangInfo.SoDiem = "" + dr["SoDiem_" + IDSV_ThangRenLuyenTrongKy] == "" ? -1 :
                                double.Parse(dr["SoDiem_" + IDSV_ThangRenLuyenTrongKy].ToString());
                            pSV_DiemRenLuyenTheoThangInfo.IDDM_XepLoaiRenLuyen = "" + dr["XepLoaiRenLuyen_" + IDSV_ThangRenLuyenTrongKy] == "" ? 0 :
                                int.Parse(dr["XepLoaiRenLuyen_" + IDSV_ThangRenLuyenTrongKy].ToString());
                            oBSV_DiemRenLuyenTheoThang.UpdateChange(pSV_DiemRenLuyenTheoThangInfo);
                        }
                    }
                    else if (dc.ColumnName == "SoDiemKy")
                    {
                        // Lưu điểm rèn luyện kỳ
                        foreach (DataRow dr in dtChange.Rows)
                        {
                            oBSV_DiemRenLuyen.UpdateChange(int.Parse(dr["SV_SinhVienID"].ToString()), Program.IDNamHoc, Program.HocKy,
                                "" + dr["SoDiemKy"] == "" ? -1 : double.Parse(dr["SoDiemKy"].ToString()),
                                "" + dr["XepLoaiRenLuyenKy"] == "" ? 0 : int.Parse(dr["XepLoaiRenLuyenKy"].ToString()), "" + dr["NhanXetKy"]);
                        }
                    }
                }
                dtDiemRenLuyen.AcceptChanges();
                ThongBao("Cập nhật thông tin điểm rèn luyện thành công.");
            }
            catch (Exception ex)
            {
                ThongBaoLoi(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToXls(bgrvDiemRenLuyen);
        }

        private void bgrvDiemRenLuyen_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void repositoryCmbXepLoaiKy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                (bgrvDiemRenLuyen.ActiveEditor as LookUpEdit).ClosePopup();
                (bgrvDiemRenLuyen.ActiveEditor as BaseEdit).EditValue = null;
            }
        }

        private void bgrvDiemRenLuyen_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "SoDiemKy")
            {
                DataRow dr = bgrvDiemRenLuyen.GetDataRow(e.RowHandle);
                if ("" + dr[e.Column.FieldName] != "")
                {
                    double Diem = (double)dr[e.Column.FieldName];
                    for (int j = 0; j < dtXepLoaiRenLuyen.Rows.Count; j++)
                    {
                        if (Diem >= double.Parse(dtXepLoaiRenLuyen.Rows[j]["TuDiem"].ToString()))
                        {
                            dr["XepLoaiRenLuyenKy"] = dtXepLoaiRenLuyen.Rows[j]["DM_XepLoaiRenLuyenID"];
                            break;
                        }
                    }
                }
            }
        }
    }
}