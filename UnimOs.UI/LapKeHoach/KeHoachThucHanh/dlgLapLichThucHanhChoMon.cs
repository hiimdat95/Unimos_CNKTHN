using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using C1.Win.C1FlexGrid;
using TruongViet.UnimOs.Entity;

namespace UnimOs.UI
{
    public partial class dlgLapLichThucHanhChoMon : frmBase
    {
        private frmKeHoachThucHanh frm;
        private C1FlexGrid fg;
        private int RowBegin, ColBegin;
        private DataTable dtKeHoach;
        private DataRow drMon;
        private CellRange rgSelection;

        public dlgLapLichThucHanhChoMon(frmKeHoachThucHanh _frm)
        {
            InitializeComponent();
            frm = _frm;
            fg = _frm.fg;
            RowBegin = frm.RowBegin;
            ColBegin = frm.ColBegin;
            dtKeHoach = frm.dtKeHoach;
            rgSelection = fg.Selection;
        }

        private void dlgLapLichThucHanhChoMon_Load(object sender, EventArgs e)
        {
            dtKeHoach.DefaultView.RowFilter = "IDDM_Lop = " + fg[rgSelection.TopRow, 4].ToString();
            grdMonThucHanh.DataSource = dtKeHoach.DefaultView;

            cmbCaHoc.EditValue = fg[rgSelection.TopRow, 2];
            cmbCaHoc.Properties.ReadOnly = true;
            dtpTuNgay.EditValue = StringToDate(fg[6, fg.Selection.LeftCol < ColBegin ? ColBegin : fg.Selection.LeftCol].ToString().Substring(2));
        }

        private void radioCachXepLich_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioCachXepLich.EditValue.ToString() == "CHON_NGAY")
                clbThu.Enabled = true;
            else
                clbThu.Enabled = false;
        }

        private void grvMonThucHanh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvMonThucHanh.FocusedRowHandle >= 0)
            {
                drMon = grvMonThucHanh.GetDataRow(grvMonThucHanh.FocusedRowHandle);
                txtSoBuoiHoc.Properties.MaxValue = decimal.Parse(drMon["SoBuoiCon"].ToString());
                txtSoBuoiHoc.EditValue = drMon["SoBuoiCon"];
            }
            else
                drMon = null;
        }

        private bool CheckValid()
        {
            return true;
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (!CheckValid()) return;
            try
            {
                int rowTo1, rowTo2, column = ColBegin, SoBuoiThucHanh = int.Parse(txtSoBuoiHoc.Text);
                bool XepLichTo2 = false;
                // Lấy giá trị hàng bắt đầu
                if (fg[rgSelection.TopRow, 3].ToString() == "1")
                {
                    rowTo1 = rgSelection.TopRow;
                    rowTo2 = rowTo1 + 1;
                }
                else
                {
                    rowTo2 = rgSelection.TopRow;
                    rowTo1 = rowTo2 - 1;
                    XepLichTo2 = true;
                }
                // Lấy giá trị cột bắt đầu.
                for (int c = ColBegin; c < fg.Cols.Count; c++)
                {
                    if (StringToDate(fg[6, c].ToString().Substring(2)).Date == ((DateTime)dtpTuNgay.EditValue).Date)
                    {
                        column = c;
                        break;
                    }
                }
                CellRange rg1, rg2;

                if (radioCachXepLich.EditValue.ToString() == "LIEN_TIEP")
                {
                    if (drMon["SoTo"].ToString() == "1")
                    {
                        while (column <= fg.Cols.Count && SoBuoiThucHanh > 0)
                        {
                            rg1 = fg.GetCellRange(rowTo1, column);
                            rg2 = fg.GetCellRange(rowTo2, column);
                            if (rg1.UserData == null && rg2.UserData == null)
                            {
                                frm.SetCellKeHoach(rowTo1, column, 0, int.Parse(drMon["XL_KeHoachThucHanhID"].ToString()), int.Parse(drMon["IDDM_MonHoc"].ToString()),
                                    int.Parse(drMon["IDXL_KeHoachThucHanhKyHieu"].ToString()), drMon["KyHieu"].ToString(),
                                    int.Parse("0" + drMon["IDNS_GiaoVien"]), "" + drMon["HoTen"], "" + drMon["TenVietTat"],
                                    int.Parse("0" + drMon["IDDM_PhongHoc"]), drMon["TenPhongHoc"].ToString(),
                                    cmbCaHoc.SelectedIndex == 0 ? CA_HOC.CA_SANG : (cmbCaHoc.SelectedIndex == 1 ? CA_HOC.CA_CHIEU : CA_HOC.CA_TOI),
                                    0, StringToDate(fg[6, column].ToString().Substring(2)).Date);

                                frm.SetCellKeHoach(rowTo2, column, 0, int.Parse(drMon["XL_KeHoachThucHanhID"].ToString()), int.Parse(drMon["IDDM_MonHoc"].ToString()),
                                    int.Parse(drMon["IDXL_KeHoachThucHanhKyHieu"].ToString()), drMon["KyHieu"].ToString(),
                                    int.Parse("0" + drMon["IDNS_GiaoVien"]), "" + drMon["HoTen"], "" + drMon["TenVietTat"],
                                    int.Parse("0" + drMon["IDDM_PhongHoc"]), drMon["TenPhongHoc"].ToString(),
                                    cmbCaHoc.SelectedIndex == 0 ? CA_HOC.CA_SANG : (cmbCaHoc.SelectedIndex == 1 ? CA_HOC.CA_CHIEU : CA_HOC.CA_TOI),
                                    0, StringToDate(fg[6, column].ToString().Substring(2)).Date);
                                SoBuoiThucHanh--;
                                drMon["SoBuoiCon"] = int.Parse(drMon["SoBuoiCon"].ToString()) - 1;
                            }
                            column++;
                        }
                    }
                    else if (drMon["SoTo"].ToString() == "2")
                    {

                    }
                }
                else if (radioCachXepLich.EditValue.ToString() == "CACH_NGAY")
                {
                    if (drMon["SoTo"].ToString() == "2")
                    {
                        if (XepLichTo2 != true)
                        {
                            while (column <= fg.Cols.Count && SoBuoiThucHanh > 0)
                            {
                                rg1 = fg.GetCellRange(rowTo1, column);
                                if (rg1.UserData == null)
                                {
                                    frm.SetCellKeHoach(rowTo1, column, 0, int.Parse(drMon["XL_KeHoachThucHanhID"].ToString()), int.Parse(drMon["IDDM_MonHoc"].ToString()),
                                        int.Parse(drMon["IDXL_KeHoachThucHanhKyHieu"].ToString()), drMon["KyHieu"].ToString(),
                                        int.Parse("0" + drMon["IDNS_GiaoVien"]), "" + drMon["HoTen"], "" + drMon["TenVietTat"],
                                        int.Parse("0" + drMon["IDDM_PhongHoc"]), drMon["TenPhongHoc"].ToString(),
                                        cmbCaHoc.SelectedIndex == 0 ? CA_HOC.CA_SANG : (cmbCaHoc.SelectedIndex == 1 ? CA_HOC.CA_CHIEU : CA_HOC.CA_TOI),
                                        1, StringToDate(fg[6, column].ToString().Substring(2)).Date);

                                    column++;

                                    while (column <= fg.Cols.Count)
                                    {
                                        rg2 = fg.GetCellRange(rowTo2, column);
                                        if (rg2.UserData == null)
                                        {
                                            frm.SetCellKeHoach(rowTo2, column, 0, int.Parse(drMon["XL_KeHoachThucHanhID"].ToString()), int.Parse(drMon["IDDM_MonHoc"].ToString()),
                                                int.Parse(drMon["IDXL_KeHoachThucHanhKyHieu"].ToString()), drMon["KyHieu"].ToString(),
                                                int.Parse("0" + drMon["IDNS_GiaoVien"]), "" + drMon["HoTen"], "" + drMon["TenVietTat"],
                                                int.Parse("0" + drMon["IDDM_PhongHoc"]), drMon["TenPhongHoc"].ToString(),
                                                cmbCaHoc.SelectedIndex == 0 ? CA_HOC.CA_SANG : (cmbCaHoc.SelectedIndex == 1 ? CA_HOC.CA_CHIEU : CA_HOC.CA_TOI),
                                                2, StringToDate(fg[6, column].ToString().Substring(2)).Date);

                                            break;
                                        }
                                        else
                                            column++;
                                    }
                                    SoBuoiThucHanh--;
                                    drMon["SoBuoiCon"] = int.Parse(drMon["SoBuoiCon"].ToString()) - 1;
                                }
                                column++;
                            }
                        }
                        else
                        {
                            while (column <= fg.Cols.Count && SoBuoiThucHanh > 0)
                            {
                                rg2 = fg.GetCellRange(rowTo2, column);
                                if (rg2.UserData == null)
                                {
                                    frm.SetCellKeHoach(rowTo2, column, 0, int.Parse(drMon["XL_KeHoachThucHanhID"].ToString()), int.Parse(drMon["IDDM_MonHoc"].ToString()),
                                        int.Parse(drMon["IDXL_KeHoachThucHanhKyHieu"].ToString()), drMon["KyHieu"].ToString(),
                                        int.Parse("0" + drMon["IDNS_GiaoVien"]), "" + drMon["HoTen"], "" + drMon["TenVietTat"],
                                        int.Parse("0" + drMon["IDDM_PhongHoc"]), drMon["TenPhongHoc"].ToString(),
                                        cmbCaHoc.SelectedIndex == 0 ? CA_HOC.CA_SANG : (cmbCaHoc.SelectedIndex == 1 ? CA_HOC.CA_CHIEU : CA_HOC.CA_TOI),
                                        2, StringToDate(fg[6, column].ToString().Substring(2)).Date);

                                    column++;

                                    while (column <= fg.Cols.Count)
                                    {
                                        rg1 = fg.GetCellRange(rowTo1, column);
                                        if (rg1.UserData == null)
                                        {
                                            frm.SetCellKeHoach(rowTo1, column, 0, int.Parse(drMon["XL_KeHoachThucHanhID"].ToString()), int.Parse(drMon["IDDM_MonHoc"].ToString()),
                                                int.Parse(drMon["IDXL_KeHoachThucHanhKyHieu"].ToString()), drMon["KyHieu"].ToString(),
                                                int.Parse("0" + drMon["IDNS_GiaoVien"]), "" + drMon["HoTen"], "" + drMon["TenVietTat"],
                                                int.Parse("0" + drMon["IDDM_PhongHoc"]), drMon["TenPhongHoc"].ToString(),
                                                cmbCaHoc.SelectedIndex == 0 ? CA_HOC.CA_SANG : (cmbCaHoc.SelectedIndex == 1 ? CA_HOC.CA_CHIEU : CA_HOC.CA_TOI),
                                                1, StringToDate(fg[6, column].ToString().Substring(2)).Date);

                                            break;
                                        }
                                        else
                                            column++;
                                    }
                                    SoBuoiThucHanh--;
                                    drMon["SoBuoiCon"] = int.Parse(drMon["SoBuoiCon"].ToString()) - 1;
                                }
                                column++;
                            }
                        }
                    }
                    else if (drMon["SoTo"].ToString() == "1")
                    {
                        while (column <= fg.Cols.Count && SoBuoiThucHanh > 0)
                        {
                            rg1 = fg.GetCellRange(rowTo1, column);
                            rg2 = fg.GetCellRange(rowTo2, column);
                            if (rg1.UserData == null && rg2.UserData == null)
                            {
                                frm.SetCellKeHoach(rowTo1, column, 0, int.Parse(drMon["XL_KeHoachThucHanhID"].ToString()), int.Parse(drMon["IDDM_MonHoc"].ToString()),
                                    int.Parse(drMon["IDXL_KeHoachThucHanhKyHieu"].ToString()), drMon["KyHieu"].ToString(),
                                    int.Parse("0" + drMon["IDNS_GiaoVien"]), "" + drMon["HoTen"], "" + drMon["TenVietTat"],
                                    int.Parse("0" + drMon["IDDM_PhongHoc"]), drMon["TenPhongHoc"].ToString(),
                                    cmbCaHoc.SelectedIndex == 0 ? CA_HOC.CA_SANG : (cmbCaHoc.SelectedIndex == 1 ? CA_HOC.CA_CHIEU : CA_HOC.CA_TOI),
                                    0, StringToDate(fg[6, column].ToString().Substring(2)).Date);

                                frm.SetCellKeHoach(rowTo2, column, 0, int.Parse(drMon["XL_KeHoachThucHanhID"].ToString()), int.Parse(drMon["IDDM_MonHoc"].ToString()),
                                    int.Parse(drMon["IDXL_KeHoachThucHanhKyHieu"].ToString()), drMon["KyHieu"].ToString(),
                                    int.Parse("0" + drMon["IDNS_GiaoVien"]), "" + drMon["HoTen"], "" + drMon["TenVietTat"],
                                    int.Parse("0" + drMon["IDDM_PhongHoc"]), drMon["TenPhongHoc"].ToString(),
                                    cmbCaHoc.SelectedIndex == 0 ? CA_HOC.CA_SANG : (cmbCaHoc.SelectedIndex == 1 ? CA_HOC.CA_CHIEU : CA_HOC.CA_TOI),
                                    0, StringToDate(fg[6, column].ToString().Substring(2)).Date);
                                SoBuoiThucHanh--;
                                drMon["SoBuoiCon"] = int.Parse(drMon["SoBuoiCon"].ToString()) - 1;
                            }
                            column += 2;
                        }
                    }
                }
                else
                {
                    if (clbThu.CheckedItems.Count <= 0)
                        return;
                    string strThu = ",";
                    for (int i = 0; i < clbThu.CheckedItems.Count; i++)
                    {
                        if (clbThu.CheckedItems[i].ToString() == "CN")
                            strThu += "0,";
                        else
                            strThu += (int.Parse(clbThu.CheckedItems[i].ToString()) - 1).ToString() + ",";
                    }
                    if (drMon["SoTo"].ToString() == "1")
                    {
                        DateTime Ngay;
                        while (column <= fg.Cols.Count && SoBuoiThucHanh > 0)
                        {
                            Ngay = DateTime.ParseExact(fg[6, column].ToString().Substring(2), "yyyyMMdd", null);
                            if (strThu.IndexOf("," + ((int)Ngay.DayOfWeek).ToString() + ",") >= 0)
                            {
                                rg1 = fg.GetCellRange(rowTo1, column);
                                rg2 = fg.GetCellRange(rowTo2, column);
                                if (rg1.UserData == null && rg2.UserData == null)
                                {
                                    frm.SetCellKeHoach(rowTo1, column, 0, int.Parse(drMon["XL_KeHoachThucHanhID"].ToString()), int.Parse(drMon["IDDM_MonHoc"].ToString()),
                                        int.Parse(drMon["IDXL_KeHoachThucHanhKyHieu"].ToString()), drMon["KyHieu"].ToString(),
                                        int.Parse("0" + drMon["IDNS_GiaoVien"]), "" + drMon["HoTen"], "" + drMon["TenVietTat"],
                                        int.Parse("0" + drMon["IDDM_PhongHoc"]), drMon["TenPhongHoc"].ToString(),
                                        cmbCaHoc.SelectedIndex == 0 ? CA_HOC.CA_SANG : (cmbCaHoc.SelectedIndex == 1 ? CA_HOC.CA_CHIEU : CA_HOC.CA_TOI),
                                        0, StringToDate(fg[6, column].ToString().Substring(2)).Date);

                                    frm.SetCellKeHoach(rowTo2, column, 0, int.Parse(drMon["XL_KeHoachThucHanhID"].ToString()), int.Parse(drMon["IDDM_MonHoc"].ToString()),
                                        int.Parse(drMon["IDXL_KeHoachThucHanhKyHieu"].ToString()), drMon["KyHieu"].ToString(),
                                        int.Parse("0" + drMon["IDNS_GiaoVien"]), "" + drMon["HoTen"], "" + drMon["TenVietTat"],
                                        int.Parse("0" + drMon["IDDM_PhongHoc"]), drMon["TenPhongHoc"].ToString(),
                                        cmbCaHoc.SelectedIndex == 0 ? CA_HOC.CA_SANG : (cmbCaHoc.SelectedIndex == 1 ? CA_HOC.CA_CHIEU : CA_HOC.CA_TOI),
                                        0, StringToDate(fg[6, column].ToString().Substring(2)).Date);
                                    SoBuoiThucHanh--;
                                    drMon["SoBuoiCon"] = int.Parse(drMon["SoBuoiCon"].ToString()) - 1;
                                }
                            }
                            column++;
                        }
                    }
                    else if (drMon["SoTo"].ToString() == "2")
                    {

                    }
                }
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

        private void grvMonThucHanh_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
    }
}