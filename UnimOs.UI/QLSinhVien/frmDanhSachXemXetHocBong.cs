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
using System.IO;
using System.Diagnostics;
using Aspose.Cells;

namespace UnimOs.UI
{
    public partial class frmDanhSachXemXetHocBong : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private cBDM_XepLoaiRenLuyen oBDM_XepLoaiRenLuyen;
        private DM_XepLoaiRenLuyenInfo pDM_XepLoaiRenLuyenInfo;
        private cBSV_SinhVien oBSV_SinhVien;
        private DataTable dtSinhVien, dtKhoaHoc, dtChiTiet;
        private Cells _range;
        private Worksheet _exSheet;
        private string xuatsac, gioi, kha, TBKha, trungbinh, Kem;

        public frmDanhSachXemXetHocBong()
        {
            InitializeComponent();
            pDM_XepLoaiRenLuyenInfo = new DM_XepLoaiRenLuyenInfo();
            oBDM_XepLoaiRenLuyen = new cBDM_XepLoaiRenLuyen();
            oBDM_Lop = new cBDM_Lop();
            pDM_LopInfo = new DM_LopInfo();
            oBSV_SinhVien = new cBSV_SinhVien();
        }

        private void frmDanhSachXemXetHocBong_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void LoadCombo()
        {
            cmbHe.Properties.DataSource = LoadHe();
            cmbTrinhDo.Properties.DataSource = LoadTrinhDo();
            cmbKhoa.Properties.DataSource = LoadKhoa();
            dtKhoaHoc = LoadKhoaHoc();
            cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;
            cmbLop.Properties.DataSource = oBDM_Lop.GetDanhSachLop(new DM_LopInfo(), Program.NamHoc);
        }

        private void LoadDanhSachLop()
        {
            pDM_LopInfo.DM_LopID = cmbLop.EditValue == null ? 0 : int.Parse(cmbLop.EditValue.ToString());
            pDM_LopInfo.IDDM_Khoa = cmbKhoa.EditValue == null ? 0 : int.Parse(cmbKhoa.EditValue.ToString());
            pDM_LopInfo.IDDM_He = cmbHe.EditValue == null ? 0 : int.Parse(cmbHe.EditValue.ToString());
            pDM_LopInfo.IDDM_TrinhDo = cmbTrinhDo.EditValue == null ? 0 : int.Parse(cmbTrinhDo.EditValue.ToString());
            pDM_LopInfo.IDDM_Nganh = cmbNganh.EditValue == null ? 0 : int.Parse(cmbNganh.EditValue.ToString());
            pDM_LopInfo.IDDM_KhoaHoc = cmbKhoaHoc.EditValue == null ? 0 : int.Parse(cmbKhoaHoc.EditValue.ToString());
            cmbLop.Properties.DataSource = oBDM_Lop.GetDanhSachLop(pDM_LopInfo, Program.NamHoc);
        }

        private void cmbHe_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbHe.EditValue != null)
            {
                DataTable dtTrinhDo = LoadTrinhDoByIDHe(int.Parse(cmbHe.EditValue.ToString()));
                cmbTrinhDo.Properties.DataSource = dtTrinhDo;
                if (dtTrinhDo.Rows.Count > 0)
                    cmbTrinhDo.ItemIndex = 0;
            }
            LoadDanhSachLop();
        }

        private void cmbTrinhDo_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbTrinhDo.EditValue != null)
            {
                string strFilter = "";
                if (cmbTrinhDo.EditValue != null)
                    strFilter = "IDDM_TrinhDo = " + cmbTrinhDo.EditValue.ToString();
                if (cmbNganh.EditValue != null)
                    strFilter += strFilter == "" ? "IDDM_Nganh = " + cmbNganh.EditValue.ToString() : " And IDDM_Nganh = " + cmbNganh.EditValue.ToString();

                if (strFilter != "")
                {
                    DataView dv = new DataView(dtKhoaHoc);
                    dv.RowFilter = strFilter;
                    cmbKhoaHoc.Properties.DataSource = dv;
                }
                else
                    cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;
            }
            LoadDanhSachLop();
        }

        private void cmbKhoa_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.EditValue != null)
            {
                cmbNganh.Properties.DataSource = LoadNganhByIDKhoa(int.Parse(cmbKhoa.EditValue.ToString()));
            }
            LoadDanhSachLop();
        }

        private void cmbNganh_EditValueChanged(object sender, EventArgs e)
        {
            LoadDanhSachLop();
        }

        private void cmbKhoaHoc_EditValueChanged(object sender, EventArgs e)
        {
            LoadDanhSachLop();
        }

        private void cmbHe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbHe.EditValue = null;
        }

        private void cmbTrinhDo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbTrinhDo.EditValue = null;
        }

        private void cmbKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbKhoa.EditValue = null;
        }

        private void cmbNganh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbNganh.EditValue = null;
        }

        private void cmbKhoaHoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbKhoaHoc.EditValue = null;
        }

        private void cmbLop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbLop.EditValue = null;
        }

        private void grvDanhSach_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnLocSV_Click(object sender, EventArgs e)
        { DataTable xeploai=new DataTable();
            double DiemTBC = 0, DiemRenLuyen = 0;

            if (txtDiemTBC.Text.Trim() != "" && txtDiemRenLuyenTu.Text != "")
            {
                DiemRenLuyen = double.Parse("0" + txtDiemRenLuyenTu.Text.Trim());
                DiemTBC = double.Parse("0" + txtDiemTBC.Text.Trim());
                DataSet ds = oBSV_SinhVien.GetDSXetHocBong(pDM_LopInfo, Program.NamHoc, Program.HocKy, Program.IDNamHoc, DiemRenLuyen, DiemTBC);
                dtSinhVien = ds.Tables[0];
                dtChiTiet = ds.Tables[1];
                xeploai = ds.Tables[2];
                if (xeploai.Rows.Count > 0)
                {
                    for (int i = 0; i < xeploai.Rows.Count; i++)
                    {
                        if (xeploai.Rows[i]["XepLoai"].ToString() == "Xuất sắc")
                        {
                            xuatsac = xeploai.Rows[i]["Tong"].ToString();
                        }
                        else if (xeploai.Rows[i]["XepLoai"].ToString() == "Giỏi")
                        {
                            gioi = xeploai.Rows[i]["Tong"].ToString();
                        }
                        else if (xeploai.Rows[i]["XepLoai"].ToString() == "Khá")
                        {
                            kha = xeploai.Rows[i]["Tong"].ToString();
                        }
                        else if (xeploai.Rows[i]["XepLoai"].ToString() == "TB Khá")
                        {
                            TBKha = xeploai.Rows[i]["Tong"].ToString();
                        }
                        else if (xeploai.Rows[i]["XepLoai"].ToString() == "Trung bình")
                        {
                            trungbinh = xeploai.Rows[i]["Tong"].ToString();
                        }
                        else
                        {
                            Kem = xeploai.Rows[i]["Tong"].ToString();
                        }
                    }
                    txtXuatSac.Text = string.Format("{0:N2}%",
                        float.Parse("0" + (float.Parse("0" + xuatsac)*100/dtChiTiet.Rows.Count)));
                    txtGioi.Text = string.Format("{0:N2}%",
                        float.Parse("0" + (float.Parse("0" + gioi)*100/dtChiTiet.Rows.Count).ToString()));
                    txtKha.Text = string.Format("{0:N2}%",
                        float.Parse("0" + (float.Parse("0" + kha)*100/dtChiTiet.Rows.Count).ToString()));
                    txtTBKha.Text = string.Format("{0:N2}%",
                        float.Parse("0" + (float.Parse("0" + TBKha)*100/dtChiTiet.Rows.Count).ToString()));
                    txtTrungBinh.Text = string.Format("{0:N2}%",
                        float.Parse("0" + (float.Parse("0" + trungbinh)*100/dtChiTiet.Rows.Count)));
                    txtKem.Text = string.Format("{0:N2}%",
                        float.Parse("0" + (float.Parse("0" + Kem)*100/dtChiTiet.Rows.Count).ToString()));
                }
                else
                {
                    txtXuatSac.Text = "";
                    txtGioi.Text = "";
                    txtKha.Text = "";
                    txtTBKha.Text = "";
                    txtTrungBinh.Text = "";
                    txtKem.Text = "";
                }
                grdDanhSach.DataSource = dtSinhVien;
            }
            else
                ThongBao("Chưa nhập điều kiện xét học bổng!");
        }

        #region Xuất danh sách ra excel
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if ((grdDanhSach.DataSource as DataTable).Rows.Count > 0)
            {
                Dictionary<string, string> dic = GetDuLieuThayTheBaoCao();
                dic.Add("HocKy", Program.HocKy.ToString());
                dic.Add("NamHoc", Program.NamHoc);
                dic.Add("TenKhoaHoc", cmbKhoaHoc.Text);
                dic.Add("TenKhoa", cmbKhoa.Text);

                XuatExcelXtraGrid("BaoCaoXemXetHocBong.xls", string.Format("BaoCaoXetHocBong_{0}.xls", DateTime.Now.ToString("yyyyMMdd")), 0, grvDanhSach, 8, 10, dic);
            }
            else
                ThongBao("Bạn phải lọc dữ liệu trước khi xuất báo cáo !");
        }
        #endregion

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            if (dtSinhVien != null)
            {
                DataTable dtReport = dtSinhVien.Copy();
                dtReport.Columns.Add("NoiDungBaoCao", typeof(string));
                dtReport.Columns.Add("HeTrinhDo", typeof(string));
                dtReport.Rows[0]["NoiDungBaoCao"] = "Học kỳ: " + Program.HocKy.ToString() + " -  Năm học: " + Program.NamHoc;

                string HeTrinhDo = "";
                if (cmbHe.EditValue != null)
                    HeTrinhDo = "HỆ: " + cmbHe.Text.ToUpper();
                if (cmbTrinhDo.EditValue != null)
                    HeTrinhDo += HeTrinhDo == "" ? "" : " - TRÌNH ĐỘ: " + cmbTrinhDo.Text.ToUpper();
                dtReport.Rows[0]["HeTrinhDo"] = HeTrinhDo;

                frmReport frm = new frmReport(dtReport, dtReport, "rDanhSachXetHocBongChiTiet", "rDanhSachXetHocBong", new string[] { "Subreport1" });
                frm.Show();
            }
        }

        private void btnXuatChiTiet_Click(object sender, EventArgs e)
        {
            if (dtSinhVien != null && dtSinhVien.Rows.Count > 0)
            {
                CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");

                #region Xử lý table
                Lib.clsDataTableHelper clsTable = new Lib.clsDataTableHelper();
                DataTable dtMonHoc = clsTable.SelectDistinct(dtChiTiet, new string[] { "SapXep", "XL_MonHocTrongKyID", "MaMonHoc", "TenMonHoc", "SoHocTrinh" });

                foreach (DataRow dr in dtMonHoc.Rows)
                {
                    if (!dtSinhVien.Columns.Contains("DT_" + dr["XL_MonHocTrongKyID"]))
                    {
                        dtSinhVien.Columns.Add("DT_" + dr["XL_MonHocTrongKyID"], typeof(double));
                        dtSinhVien.Columns.Add("DTK_" + dr["XL_MonHocTrongKyID"], typeof(double));
                    }
                }

                DataRow[] arrDr;
                foreach (DataRow dr in dtSinhVien.Rows)
                {
                    arrDr = dtChiTiet.Select("SV_SinhVienID = " + dr["SV_SinhVienID"]);
                    foreach (DataRow _dr in arrDr)
                    {
                        dr["DT_" + _dr["XL_MonHocTrongKyID"]] = _dr["DiemThi"];
                        dr["DTK_" + _dr["XL_MonHocTrongKyID"]] = _dr["DiemTongKetMon"];
                    }
                }
                #endregion

                #region Chuẩn bị tệp excel để ghi dữ liệu
                Workbook exBook = new Workbook();
                exBook.Open(Application.StartupPath + "\\Template\\DanhSachXetHocBongChiTiet.xls", FileFormatType.Excel2003);
                _exSheet = exBook.Worksheets[0];
                _range = _exSheet.Cells;
                #endregion
                SaveFileDialog sv = new SaveFileDialog();
                sv.FileName = "DanhSachXetHocBongChiTiet -Lop"+cmbLop.Text.ToUpper()+ "- Ky" + Program.HocKy.ToString() + " -Nam " + Program.NamHoc + ".xls";
                sv.Filter = "Excel file (*.xls)|*.xls";
                sv.Title = "Xuất dữ liệu";
                
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    #region Đổ dữ liệu vào báo cáo
                    int DongBatDau = 9, DongFieldName = 5, CotBatDau = 9;
                    _range["B5"].PutValue("Xuất sắc:" +
                                          string.Format("{0:N2}%",
                                              float.Parse("0" + (float.Parse("0" + xuatsac)*100/dtChiTiet.Rows.Count))) +
                                          ". Giỏi:" + string.Format("{0:N2}%",
                        float.Parse("0" + (float.Parse("0" + gioi) * 100 / dtChiTiet.Rows.Count).ToString())) + ". Khá:" + string.Format("{0:N2}%",
                        float.Parse("0" + (float.Parse("0" + kha) * 100 / dtChiTiet.Rows.Count).ToString())) + ". TB Khá:" + string.Format("{0:N2}%",
                        float.Parse("0" + (float.Parse("0" + TBKha) * 100 / dtChiTiet.Rows.Count).ToString())) + ". Trung bình:" + string.Format("{0:N2}%",
                        float.Parse("0" + (float.Parse("0" + trungbinh) * 100 / dtChiTiet.Rows.Count))) + ". Kém:" + string.Format("{0:N2}%",
                        float.Parse("0" + (float.Parse("0" + Kem) * 100 / dtChiTiet.Rows.Count).ToString())));
                    // Thay thế dữ liệu trên file
                    Dictionary<string, string> DuLieuThayThe = GetDuLieuThayTheBaoCao();
                    DuLieuThayThe.Add("HocKy", Program.HocKy.ToString());
                    DuLieuThayThe.Add("NamHoc", Program.NamHoc);
                    if (cmbLop.Text != "")
                    {
                        DuLieuThayThe.Add("LopHoc", "LỚP " + cmbLop.Text.ToUpper());

                    }
                    else
                    {
                        DuLieuThayThe.Add("LopHoc", " ");

                    }

                    foreach (KeyValuePair<string, string> pair in DuLieuThayThe)
                    {
                        _exSheet.Replace(pair.Key, pair.Value);
                    }

                    Range rngCopy, rngPaste;
                    // Thêm tiêu đề cho các cột điểm môn học
                    //rngCopy = _exSheet.Cells.CreateRange(DongFieldName + 1, CotBatDau, 3, 2);
                    //rngPaste = _exSheet.Cells.CreateRange(DongFieldName + 1, CotBatDau, 3, 2);
                    if (cmbLop.Text != "")
                    {


                    }
                    // Set tiều đề cho môn cuối cùng trước, sau đó insert ngược
                    _range[DongFieldName, CotBatDau].PutValue("DT_" + dtMonHoc.Rows[dtMonHoc.Rows.Count - 1]["XL_MonHocTrongKyID"]);
                    _range[DongFieldName, CotBatDau + 1].PutValue("DTK_" + dtMonHoc.Rows[dtMonHoc.Rows.Count - 1]["XL_MonHocTrongKyID"]);
                    _range[DongFieldName + 1, CotBatDau].PutValue(dtMonHoc.Rows[dtMonHoc.Rows.Count - 1]["TenMonHoc"]);
                    _exSheet.Cells.Merge(DongFieldName + 1, CotBatDau, 1, 2);
                    _range[DongFieldName + 2, CotBatDau].PutValue((dtMonHoc.Rows.Count).ToString());
                    _exSheet.Cells.Merge(DongFieldName + 2, CotBatDau, 1, 2);
                    int stt = 1;
                    for (int i = dtMonHoc.Rows.Count - 2; i >= 0; i--)
                    {
                        _exSheet.Cells.InsertColumn(CotBatDau);
                        _exSheet.Cells.InsertColumn(CotBatDau);

                        //rngPaste.Copy(rngCopy);
                        //rngPaste.CopyStyle(rngCopy);

                        _range[DongFieldName, CotBatDau].PutValue("DT_" + dtMonHoc.Rows[i]["XL_MonHocTrongKyID"]);
                        _range[DongFieldName, CotBatDau + 1].PutValue("DTK_" + dtMonHoc.Rows[i]["XL_MonHocTrongKyID"]);
                        _range[DongFieldName + 1, CotBatDau].PutValue(dtMonHoc.Rows[i]["TenMonHoc"]);
                        _exSheet.Cells.Merge(DongFieldName + 1, CotBatDau, 1, 2);
                        _range[DongFieldName + 2, CotBatDau].PutValue((i + 1).ToString());
                        _exSheet.Cells.Merge(DongFieldName + 2, CotBatDau, 1, 2);
                        _range[DongFieldName + 3, CotBatDau].PutValue("Điểm thi");
                        _range[DongFieldName + 3, CotBatDau + 1].PutValue("ĐTK");
                        stt++;
                    }

                    _exSheet.Cells.DeleteColumn(CotBatDau - 1);

                    // Thêm các dòng và đưa style vào các dòng được thêm
                    rngCopy = _exSheet.Cells.CreateRange(DongBatDau + 1, 0, 1, 100);

                    int _count = dtSinhVien.Rows.Count, k, DongHienTai = DongBatDau;

                    if (_count > 3)
                        _range.InsertRows(DongBatDau + 1, _count - 3);
                    else
                        _range.DeleteRows(DongBatDau + 1, 3 - _count);

                    for (int i = 1; i < _count - 1; i++)
                    {
                        rngPaste = _exSheet.Cells.CreateRange(DongBatDau + i, 0, 1, 100);
                        rngPaste.Copy(rngCopy);
                        rngPaste.CopyStyle(rngCopy);
                        _exSheet.Cells.SetRowHeight(DongBatDau + i, rngCopy.RowHeight);
                    }

                    string _FieldName = "";

                    for (int i = 0; i < _count; i++)
                    {
                        k = 0;
                        _FieldName = ("" + _exSheet.Cells[DongFieldName, 0].Value).Trim();

                        while (_FieldName != "")
                        {
                            if (dtSinhVien.Columns.Contains(_FieldName) || _FieldName.ToUpper() == "STT")
                            {
                                if (_FieldName.ToUpper() == "STT")
                                    _range[DongHienTai, k].PutValue(i + 1);
                                else if (_FieldName.IndexOf("=") >= 0)
                                    _range[DongHienTai, k].Formula = _FieldName.Replace("[i]", (DongBatDau + i + 1).ToString()).Replace("'", "");
                                else
                                    _range[DongHienTai, k].PutValue(dtSinhVien.Rows[i][_FieldName]);
                            }
                            k++;
                            _FieldName = ("" + _exSheet.Cells[DongFieldName, k].Value).Trim();
                        }

                        _exSheet.AutoFitRow(DongHienTai);

                        DongHienTai++;
                    }

                    // Xóa dòng field name
                    _exSheet.Cells.DeleteRow(DongFieldName);
                    #endregion

                    #region Lưu và mở file excel

                    #region Lưu và mở file excel
                    string strTenFileExcelMoi = sv.FileName;
                    exBook.Save(strTenFileExcelMoi, FileFormatType.Excel2003);
                    CloseWaitDialog();
                    ThongBao("Xuất dữ liệu thành công.");

                    try
                    {
                        Process.Start(strTenFileExcelMoi);
                    }
                    catch (Exception ex)
                    {
                        ThongBaoLoi("Đã có lỗi: " + ex.Message);
                    }
                    #endregion
                    //if (!Directory.Exists(Program.DuongDanThuMucBaoCao))
                    //    Directory.CreateDirectory(Program.DuongDanThuMucBaoCao);

                    //string strTenFileExcelMoi = Program.DuongDanThuMucBaoCao + "\\" + string.Format("BaoCaoXetHocBongChiTiet_{0}.xls", DateTime.Now.ToString("yyyyMMdd"));
                    //exBook.Save(strTenFileExcelMoi, FileFormatType.Excel2003);
                    //CloseWaitDialog();

                   
                    #endregion
                }
                else
                    ThongBao("Không có dữ liệu để xuất Excel.");
            }
        }

        private void cmbLop_EditValueChanged(object sender, EventArgs e)
        {
            LoadDanhSachLop();
        }
    }
}