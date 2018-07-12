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
using DevExpress.XtraGrid.Views.Base;

namespace UnimOs.UI 
{
    public partial class frmNhapDiemTheoLopHocLai : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DataTable dtSinhVien, dtThanhPhan, dtHocLai, dtData;
        private KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo;
        private cBKQHT_DiemThanhPhan oBKQHT_DiemThanhPhan;
        private cBKQHT_CongThucDiem oBKQHT_CongThucDiem;
        private KQHT_CongThucDiemInfo pKQHT_CongThucDiemInfo;
        private cBKQHT_DiemThi oBKQHT_DiemThi;
        private KQHT_DiemThiInfo pKQHT_DiemThiInfo;
        private cBKQHT_LopHocLai oBKQHT_LopHocLai;
        private KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo;
        private cBKQHT_DiemTongKetMon oBKQHT_DiemTongKetMon;
        private int IDDM_Lop = 0, IDDM_MonHoc = 0;

        public frmNhapDiemTheoLopHocLai()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            oBKQHT_DiemThanhPhan = new cBKQHT_DiemThanhPhan();
            pKQHT_DiemThanhPhanInfo = new KQHT_DiemThanhPhanInfo();
            pKQHT_CongThucDiemInfo = new KQHT_CongThucDiemInfo();
            oBKQHT_CongThucDiem = new cBKQHT_CongThucDiem();
            oBKQHT_DiemThi = new cBKQHT_DiemThi();
            pKQHT_DiemThiInfo = new KQHT_DiemThiInfo();
            oBKQHT_LopHocLai = new cBKQHT_LopHocLai();
            pKQHT_DiemTongKetMonInfo = new KQHT_DiemTongKetMonInfo();
            oBKQHT_DiemTongKetMon = new cBKQHT_DiemTongKetMon();
        }
        private void frmNhapDiemTheoLopHocLai_Load(object sender, EventArgs e)
        {
            dtHocLai = oBKQHT_LopHocLai.GetByHocKyNamHoc(0, Program.HocKy, Program.IDNamHoc);
            grdLopHocLai.DataSource = dtHocLai;
            grvLopHocLai_FocusedRowChanged(null, null);
            if (dtHocLai.Rows.Count > 0)
                LoadSinhVien();
        }

        private void cmbLanThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSinhVien();

        }
        private void LoadSinhVien()
        {
            if (dtSinhVien != null)
                dtSinhVien.Clear();
            dtSinhVien = CreateTable();
            AddBand();
            XuLyTable();
            if (int.Parse(cmbLanThi.EditValue.ToString()) >= 2)
            {
                dtSinhVien.DefaultView.RowFilter = "DiemTK < 5";
                grdDiem.DataSource = dtSinhVien.DefaultView;
            }
            else
                grdDiem.DataSource = dtSinhVien;
            dtSinhVien.AcceptChanges();
            btnCapNhat.Enabled = true;
        }

        private DataTable CreateTable()
        {
            DataTable dtData = new DataTable();
            dtData.Columns.Add("SV_SinhVienID", typeof(int));
            dtData.Columns.Add("MaSinhVien", typeof(string));
            dtData.Columns.Add("HoVaTen", typeof(string));
            dtData.Columns.Add("TenLop", typeof(string));
            dtData.Columns.Add("IDXL_MonHocTrongKy", typeof(int));
            dtData.Columns.Add("CongThuc", typeof(string));
            dtData.Columns.Add("DiemTK", typeof(float));
            return dtData;
        }

        private void AddBand()
        {
            BandedGridColumn bgc, bgcThi;
            KQHT_ThanhPhanDiemInfo pKQHT_ThanPhanDiemInfo = new KQHT_ThanhPhanDiemInfo();
            cBKQHT_ThanhPhanDiem oBKQHT_ThanhPhanDiem = new cBKQHT_ThanhPhanDiem();
            dtThanhPhan = oBKQHT_ThanhPhanDiem.Get(pKQHT_ThanPhanDiemInfo);
            grbNhapDiem.Columns.Clear();
            grbDiemThi.Columns.Clear();
            if ((dtThanhPhan != null) && (dtThanhPhan.Rows.Count > 0))
            {

                foreach (DataRow dr in dtThanhPhan.Rows)
                {
                    dtSinhVien.Columns.Add(dr["KQHT_ThanhPhanDiemID"].ToString(), typeof(float));

                    if ((bool)(dr["Thi"]))
                    {
                        bgcThi = new BandedGridColumn();
                        grbDiemThi.Columns.Add(bgcThi);

                        SetColumnBandCaption(bgcThi, dr["KyHieu"].ToString(), dr["KQHT_ThanhPhanDiemID"].ToString(), 90, DevExpress.Utils.HorzAlignment.Default, false);
                        bgcThi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        bgcThi.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        bgvDiem.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgcThi });
                    }
                    else
                    {
                        bgc = new BandedGridColumn();
                        grbNhapDiem.Columns.Add(bgc);

                        SetColumnBandCaption(bgc, dr["KyHieu"].ToString(), dr["KQHT_ThanhPhanDiemID"].ToString(), 60, DevExpress.Utils.HorzAlignment.Default, false);
                        bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                        bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        bgc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        bgvDiem.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });
                    }
                  
                }
            }
        }

        private void XuLyTable()
        {
            if (dtThanhPhan.Rows.Count > 0)
            {
                //DataTable dtData = dtSinhVien;
                dtData = oBKQHT_LopHocLai.GetSinhVien(IDDM_Lop, 1);
               
                DataRow drNew;
                if (dtData.Rows.Count > 0)
                {
                    string SV_SinhVienID = dtData.Rows[0]["SV_SinhVienID"].ToString();
                    drNew = dtSinhVien.NewRow();
                    drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                    drNew["MaSinhVien"] = dtData.Rows[0]["MaSinhVien"].ToString();
                    drNew["HoVaTen"] = dtData.Rows[0]["HoVaTen"].ToString();
                    drNew["TenLop"] = dtData.Rows[0]["TenLop"].ToString();
                    drNew["IDXL_MonHocTrongKy"] = int.Parse(dtData.Rows[0]["IDXL_MonHocTrongKy"].ToString());
                    drNew["CongThuc"] = dtData.Rows[0]["CongThuc"].ToString();
                    drNew["DiemTK"] = dtData.Rows[0]["DiemTK"];

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
                            drNew["TenLop"] = dr["TenLop"].ToString();
                            drNew["IDXL_MonHocTrongKy"] = int.Parse(dr["IDXL_MonHocTrongKy"].ToString());
                            drNew["CongThuc"] = dr["CongThuc"].ToString();
                            drNew["DiemTK"] = dr["DiemTK"];

                            drNew[dr["KQHT_ThanhPhanDiemID"].ToString()] = dr["Diem"];
                        }
                        else
                        {
                            drNew[dr["KQHT_ThanhPhanDiemID"].ToString()] = dr["Diem"];

                        }
                    }
                    dtSinhVien.Rows.Add(drNew);
                }
            }
        }
        private void grvLopHocLai_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (grvLopHocLai.FocusedRowHandle >= 0)
            {
                IDDM_MonHoc = int.Parse(grvLopHocLai.GetDataRow(grvLopHocLai.FocusedRowHandle)["IDDM_MonHoc"].ToString());
                IDDM_Lop = int.Parse(grvLopHocLai.GetDataRow(grvLopHocLai.FocusedRowHandle)["KQHT_LopHocLaiID"].ToString());
            }
        }
        private void bgvDiem_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataTable dtDataTemp = dtSinhVien.GetChanges();
            if (dtDataTemp != null)
            {
                foreach (DataRow dr in dtDataTemp.Rows)
                {
                    if (dr.RowState == DataRowState.Modified)
                    {

                        // update vao bang KQHT_ThanhPhanDiem                          
                        for (int i = 0; i < grbNhapDiem.Columns.Count; i++)
                        {
                            if (grbNhapDiem.Columns[i].FieldName != "" && "" + dr[grbNhapDiem.Columns[i].FieldName] != "")
                            {
                                try
                                {
                                    pKQHT_DiemThanhPhanInfo.HocKy = Program.HocKy;
                                    pKQHT_DiemThanhPhanInfo.IDDM_NamHoc = Program.IDNamHoc;
                                    pKQHT_DiemThanhPhanInfo.IDDM_MonHoc = IDDM_MonHoc;
                                    pKQHT_DiemThanhPhanInfo.IDHT_User = Program.objUserCurrent.HT_UserID;
                                    pKQHT_DiemThanhPhanInfo.IDKQHT_ThanhPhanDiem = int.Parse(grbNhapDiem.Columns[i].FieldName);
                                    pKQHT_DiemThanhPhanInfo.LyDo = "";
                                    pKQHT_DiemThanhPhanInfo.Diem = float.Parse(dr[grbNhapDiem.Columns[i].FieldName].ToString());
                                    pKQHT_DiemThanhPhanInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                                    pKQHT_DiemThanhPhanInfo.NgayTao = DateTime.Now;
                                    pKQHT_DiemThanhPhanInfo.IDXL_MonHocTrongKy = int.Parse(dr["IDXL_MonHocTrongKy"].ToString());
                                    oBKQHT_DiemThanhPhan.Add(pKQHT_DiemThanhPhanInfo);

                                }

                                catch
                                {
                                    // error
                                }
                            }
                        }
                        // update vao bang KQHT_DiemThi                          
                        for (int i = 0; i < grbDiemThi.Columns.Count; i++)
                        {
                            if (grbDiemThi.Columns[i].FieldName != "" && "" + dr[grbDiemThi.Columns[i].FieldName] != "")
                            {
                                try
                                {
                                    pKQHT_DiemThiInfo.HocKy = Program.HocKy;
                                    pKQHT_DiemThiInfo.IDDM_NamHoc = Program.IDNamHoc;
                                    pKQHT_DiemThiInfo.IDDM_MonHoc = IDDM_MonHoc;
                                    pKQHT_DiemThiInfo.IDHT_User = Program.objUserCurrent.HT_UserID;
                                    pKQHT_DiemThiInfo.LyDo = "";
                                    pKQHT_DiemThiInfo.Diem = float.Parse(dr[grbDiemThi.Columns[i].FieldName].ToString());
                                    pKQHT_DiemThiInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                                    pKQHT_DiemThiInfo.NgayTao = DateTime.Now;
                                    pKQHT_DiemThiInfo.LanThi = int.Parse(cmbLanThi.EditValue.ToString());
                                    pKQHT_DiemThiInfo.IDXL_MonHocTrongKy = int.Parse(dr["IDXL_MonHocTrongKy"].ToString());
                                    oBKQHT_DiemThi.Add(pKQHT_DiemThiInfo);
                                }

                                catch
                                {
                                    // error
                                }
                            }
                        }
                        // update vao bang tong ket mon
                        if ("" + dr["DiemTK"] != "")
                        {
                            try
                            {
                                pKQHT_DiemTongKetMonInfo.HocKy = Program.HocKy;
                                pKQHT_DiemTongKetMonInfo.IDDM_NamHoc = Program.IDNamHoc;
                                pKQHT_DiemTongKetMonInfo.IDDM_MonHoc = IDDM_MonHoc;
                                pKQHT_DiemTongKetMonInfo.LyDo = "";
                                pKQHT_DiemTongKetMonInfo.Diem = float.Parse("0" + dr["DiemTK"]);
                                pKQHT_DiemTongKetMonInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                                pKQHT_DiemTongKetMonInfo.LanThi = int.Parse(cmbLanThi.EditValue.ToString());
                                pKQHT_DiemTongKetMonInfo.IDXL_MonHocTrongKy = int.Parse(dr["IDXL_MonHocTrongKy"].ToString());
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

        private void bgvDiem_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {

            float ID;
            if (float.TryParse(bgvDiem.FocusedColumn.FieldName, out ID))
            {
                if (e.Value != null)
                {
                    if (e.Value.ToString().Trim() == "")
                    {
                        e.Value = null;
                        e.Valid = true;
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

        private void bgvDiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (ThongBaoChon("Bạn có chắc chắn muốn xóa không?") == DialogResult.Yes)
                {
                    string TenCot = "";
                    int IDSV_SinhVien = 0;
                    int[] RowIndex = bgvDiem.GetSelectedRows();
                    for (int i = 0; i < RowIndex.Length; i++)
                    {
                        GridCell[] GridCells = bgvDiem.GetSelectedCells();

                        for (int j = 0; j < GridCells.Length; j++)
                        {

                            IDSV_SinhVien = int.Parse(bgvDiem.GetDataRow(i)["SV_SinhVienID"].ToString());
                            TenCot = GridCells[j].Column.FieldName;
                            try
                            {
                                oBKQHT_DiemThanhPhan.DeleteBy_SinhVien(IDSV_SinhVien, int.Parse(cmbLanThi.EditValue.ToString()), IDDM_MonHoc, Program.IDNamHoc, Program.HocKy, int.Parse(TenCot));
                            }
                            catch { }

                        }
                        // }
                    }
                    dtSinhVien.Rows.Clear();
                    XuLyTable();
                    dtSinhVien.AcceptChanges();
                }
            }

        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            if (dtSinhVien.Rows.Count > 0)
            {
                if ("" + dtSinhVien.Rows[0]["CongThuc"] != "")
                {
                    for (int i = 0; i < dtSinhVien.Rows.Count; i++)
                    {
                        DataRow[] dr = dtData.Select("SV_SinhVienID = " + dtSinhVien.Rows[i]["SV_SinhVienID"]);
                        dtSinhVien.Rows[i]["DiemTK"] = TestCongThuc(dr);
                    }
                    //bgvDiem.Columns["TK"].Visible = true;
                }
                else
                    ThongBao("Môn học chưa có công thức điểm!");
            }
        }
        private double TestCongThuc(DataRow[] drDiem)
        {
            double Value = 0; int SoSauDauPhay;
            try
            {
                MathParser parser = new MathParser();
                foreach (DataRow dr in drDiem)
                {
                    parser.CreateVar(dr["KyHieu"].ToString(), double.Parse("0" + dr["Diem"].ToString()), null);
                }
                string formula = null;
                formula = drDiem[0]["CongThuc"].ToString();
                parser.OptimizationOn = true;
                if (formula.IndexOf("R+(") == 0 | formula.IndexOf("R-(") == 0)
                {
                    SoSauDauPhay = int.Parse(formula.Substring(3, 1));
                    double tmp = 0;
                    if (formula.IndexOf("R+(") == 0)
                    {
                        formula = formula.Substring(5, formula.Length - 5);
                        parser.Expression = formula;
                        parser.Parse();
                        tmp = double.Parse(parser.Value.ToString());
                        Value = parser.Round(tmp, SoSauDauPhay, true);
                    }
                    else
                    {
                        formula = formula.Substring(5, formula.Length - 5);
                        parser.Expression = formula;
                        parser.Parse();
                        tmp = double.Parse(parser.Value.ToString());
                        Value = parser.Round(tmp, SoSauDauPhay, false);
                    }
                }
                else
                {
                    parser.Expression = formula;
                    parser.Parse();
                    Value = double.Parse(parser.Value.ToString());
                }
                return Value;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}