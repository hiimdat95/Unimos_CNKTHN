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

namespace UnimOs.UI
{
    public partial class frmBaoCaoChatLuongDoiNguGV : frmBase
    {
        cBNS_GiaoVien oBNS_GiaoVien = new cBNS_GiaoVien();
        NS_GiaoVienInfo pNS_GiaoVienInfo = new NS_GiaoVienInfo();
        DataTable dtBaoCao;

        public frmBaoCaoChatLuongDoiNguGV()
        {
            InitializeComponent();
        }

        private void frmBaoCaoChatLuongDoiNguGV_Load(object sender, EventArgs e)
        {
            dtpDenNgay.EditValue = DateTime.Now;
        }

        private DataTable XuLyBaoCao()
        {
            DataSet ds = oBNS_GiaoVien.GetBaoCaoChatLuongDoiNguGiaoVien((DateTime)dtpDenNgay.EditValue);
            DataTable dtNganhDaoTao = ds.Tables[0];
            if (dtNganhDaoTao.Rows.Count <= 0)
            {
                ThongBao("Không có dữ liệu về ngành đào tạo");
                return null;
            }

            int STT = 0;
            foreach (DataRow dr in dtNganhDaoTao.Rows)
            {
                if (int.Parse(dr["ParentNganhDaoTaoID"].ToString()) == 0)
                    STT = 0;
                else
                {
                    STT++;
                    dr["STT"] = STT;
                }
            }
            DataRow drNew = dtNganhDaoTao.NewRow();
            drNew["TenNganhDaoTao"] = "Cộng";
            dtNganhDaoTao.Rows.Add(drNew);

            CreateTable(ref dtNganhDaoTao);

            DataTable dtTemp, dt = ds.Tables[1];
            if (dt.Rows.Count <= 0)
            {
                ThongBao("Không có thông tin Giáo viên về ngành đào tạo !");
                return null;
            }

            DataView dv;
            DataRow _dr;
            for (int i = 0; i < dtNganhDaoTao.Rows.Count - 1; i++)
            {
                _dr = dtNganhDaoTao.Rows[i];
                if (int.Parse(_dr["ParentNganhDaoTaoID"].ToString()) == 0)
                {
                    dv = new DataView(dt);
                    dv.RowFilter = "ParentNganhDaoTaoID = " + _dr["IDNganhDaoTao"];
                    if (dv.Count > 0)
                    {
                        dtTemp = dv.ToTable();
                        SetItemValue(dtTemp, ref _dr);
                    }
                }
                else
                {
                    dv = new DataView(dt);
                    dv.RowFilter = "IDNganhDaoTao = " + _dr["IDNganhDaoTao"];
                    if (dv.Count > 0)
                    {
                        dtTemp = dv.ToTable();
                        SetItemValue(dtTemp, ref _dr);
                    }
                }
            }

            _dr = dtNganhDaoTao.Rows[dtNganhDaoTao.Rows.Count - 1];
            SetItemValue(dt, ref _dr);

            return dtNganhDaoTao;
        }

        int count;
        private void SetItemValue(DataTable dtTemp, ref DataRow dr)
        {
            // Chia theo độ tuổi
            dr["TongSo"] = dtTemp.Rows.Count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "Tuoi < 30");
            if (count > 0)
                dr["Duoi30"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "30 < Tuoi And Tuoi <= 45");
            if (count > 0)
                dr["Tu30Den45"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "45 < Tuoi And Tuoi <= 55");
            if (count > 0)
                dr["Tu46Den55"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "Tuoi > 55");
            if (count > 0)
                dr["Tren55"] = count;

            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "");
            if (count > 0)
                dr["TrongNuoc"] = count;

            // Chia ngạch công chức viên chức
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "LoaiCongChuc = 'A3'");
            if (count > 0)
                dr["CVCC"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "LoaiCongChuc = 'A2'");
            if (count > 0)
                dr["CVC"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "LoaiCongChuc = 'A1'");
            if (count > 0)
                dr["CV"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "LoaiCongChuc = 'C' Or LoaiCongChuc = 'B'");
            if (count > 0)
                dr["ConLai"] = count;

            // Chia theo trình độ chính trị
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "TenTrinhDoLyLuan = 'Cao cấp'");
            if (count > 0)
                dr["CTCaoCap"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "TenTrinhDoLyLuan = 'Trung cấp'");
            if (count > 0)
                dr["CTTrungCap"] = count;

            // Chia theo trình độ ngoại ngữ
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "TenNgoaiNgu = 'Tiếng anh' And IDTrinhDoNgoaiNgu = 'CN'");
            if (count > 0)
                dr["CuNhanAnh"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "TenNgoaiNgu = 'Tiếng anh' And IDTrinhDoNgoaiNgu = 'SC'");
            if (count > 0)
                dr["SoCapAnh"] = count;

            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "TenNgoaiNgu <> 'Tiếng anh' And IDTrinhDoNgoaiNgu = 'CN'");
            if (count > 0)
                dr["CuNhanKhac"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "TenNgoaiNgu <> 'Tiếng anh' And IDTrinhDoNgoaiNgu = 'SC'");
            if (count > 0)
                dr["SoCapKhac"] = count;

            // Chia theo trình độ quản lý hành chính nhà nước
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "LoaiTrinhDoQuanLyHanhChinhNhaNuoc = 'Cử nhân'");
            if (count > 0)
                dr["CuNhanQLNN"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "LoaiTrinhDoQuanLyHanhChinhNhaNuoc = 'Bồi dưỡng'");
            if (count > 0)
                dr["BoiDuongQLNN"] = count;

            // Chia theo thâm niên công tác
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "ThamNienCongTac < 5");
            if (count > 0)
                dr["Duoi5Nam"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "ThamNienCongTac >= 5");
            if (count > 0)
                dr["Tren5Nam"] = count;

            // Chia theo lĩnh vực khác
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "Not NgayVaoDang Is Null");
            if (count > 0)
                dr["DangVien"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "GioiTinh = 1");
        }

        private void CreateTable(ref DataTable dt)
        {
            for (int i = 2; i < bgrvBaoCao.Columns.Count; i++)
            {
                dt.Columns.Add(bgrvBaoCao.Columns[i].FieldName, typeof(int));
            }
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            dtBaoCao = XuLyBaoCao();
            if (dtBaoCao == null)
                return;

            grdBaoCao.DataSource = dtBaoCao;
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            XuatTheoTemplate();
        }

        #region Xuat theo template
        private void XuatTheoTemplate()
        {
            if (dtBaoCao.Rows.Count == 0)
            {
                ThongBao("Không có dữ liệu để xuất ra excel!");
                return;
            }
            string DuongDan = Application.StartupPath;
            string strFileExcel = DuongDan + "\\Template\\Temp_BaoCaoChatLuongDoiNguGiaoVien.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + "! Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                return;
            }
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Excel file (*.xls)|*.xls";
            sv.Title = "Xuất dữ liệu";
            sv.FileName = "Bao cao chat luong doi ngu giao vien den ngay " + ((DateTime)dtpDenNgay.EditValue).ToString("yyyyMMdd") + ".xls";
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
                XuatDuLieuRaExcel(strTenFileExcelMoi);
                ThongBao("Xuất dữ liệu thành công!");
            }
        }

        private void XuatDuLieuRaExcel(string FileExcel)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int DongBatDau = 10, _ColStart = 4, SoCot = bgrvBaoCao.Columns.Count; //, ExcCotBatDau = 5, SoCot = 22;
            Excel.Range cel;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);

                excel.Cells[4, 5] = "(Có đến ngày " + dtpDenNgay.Text + ")";

                int count = dtBaoCao.Rows.Count;
                DataRow dr;
                for (int i = 0; i < count; i++)
                {
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 1]);
                    cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);

                    dr = dtBaoCao.Rows[i];

                    excel.Cells[i + DongBatDau, 1] = "" + dr["STT"];
                    excel.Cells[i + DongBatDau, 2] = "" + dr["TenNganhDaoTao"].ToString();

                    for (int j = _ColStart; j < dtBaoCao.Columns.Count; j++)
                    {
                        if ("" + dr[dtBaoCao.Columns[j].ColumnName] != "")
                        {
                            excel.Cells[i + DongBatDau, j - _ColStart + 3] = dr[dtBaoCao.Columns[j].ColumnName].ToString();
                            //cel = (Excel.Range)excel.Cells[i + DongBatDau, j - _ColStart];
                        }
                    }
                }

                // Set style
                cel = excel.get_Range(excel.Cells[DongBatDau, 1], excel.Cells[DongBatDau + count - 1, SoCot]);
                cel.Borders.LineStyle = Excel.XlLineStyle.xlDot;
                cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;

                cel = excel.get_Range(excel.Cells[DongBatDau, 1], excel.Cells[DongBatDau + count - 1, 1]);
                cel.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;

                for (int j = 1; j <= SoCot; j++)
                {
                    cel = excel.get_Range(excel.Cells[DongBatDau, j], excel.Cells[DongBatDau + count - 1, j]);
                    cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
                    cel.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                }

                cel = excel.get_Range(excel.Cells[DongBatDau, 1], excel.Cells[DongBatDau + count - 1, SoCot]);
                cel.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            catch (Exception e)
            {
                CloseWaitDialog();
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ThongBaoLoi("Xuất dữ liệu không thành công! Hãy đóng file Excel Phiếu báo điểm trước khi xuất dữ liệu. Thông báo lỗi: " + e.Message);
                return;
            }
            finally
            {
                excel.Application.Workbooks[1].Save();
                excel.Application.Workbooks.Close();
                excel.Application.Quit();
                excel.Quit();
                Process.Start(FileExcel);
                CloseWaitDialog();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
        #endregion
    }
}