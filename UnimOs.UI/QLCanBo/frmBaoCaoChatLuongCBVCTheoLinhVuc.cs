using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;
using System.IO;
using System.Diagnostics;

namespace UnimOs.UI
{
    public partial class frmBaoCaoChatLuongCBVCTheoLinhVuc : frmBase
    {
        private cBNS_GiaoVien oBNS_GiaoVien;
        private DataTable dtBaoCao;
        private int count = 0, _ColStart;

        public frmBaoCaoChatLuongCBVCTheoLinhVuc()
        {
            InitializeComponent();

            dtpDenNgay.EditValue = DateTime.Now;
            oBNS_GiaoVien = new cBNS_GiaoVien();
        }

        private void frmBaoCaoChatLuongCBVCTheoLinhVuc_Load(object sender, EventArgs e)
        {

        }

        private void CreateTable()
        {
            dtBaoCao = new DataTable();
            dtBaoCao.Columns.Add("IDHinhThucHDLD", typeof(string));
            dtBaoCao.Columns.Add("IDNS_LinhVucCongTac", typeof(int));
            _ColStart = 2;
            for (int i = 0; i < bgrvBaoCao.Columns.Count; i++)
            {
                if (i < _ColStart)
                    dtBaoCao.Columns.Add(bgrvBaoCao.Columns[i].FieldName);
                else
                    dtBaoCao.Columns.Add(bgrvBaoCao.Columns[i].FieldName, typeof(int));
            }

            DataTable dtLinhVuc = (new cBNS_LinhVucCongTac()).Get(new NS_LinhVucCongTacInfo());
            if (dtLinhVuc.Rows.Count <= 0)
                return;

            DataRow drNew;
            int k;
            foreach (DataRow dr in bLoadHinhThucHDLD().Rows)
            {
                drNew = dtBaoCao.NewRow();
                drNew["IDHinhThucHDLD"] = dr["ID"];
                drNew["IDNS_LinhVucCongTac"] = 0;
                drNew["STT"] = dr["STT"].ToString();
                drNew["TenLinhVuc"] = dr["Ten"];
                dtBaoCao.Rows.Add(drNew);
                k = 0;
                foreach (DataRow drLinhVuc in dtLinhVuc.Rows)
                {
                    k++;
                    drNew = dtBaoCao.NewRow();
                    drNew["IDHinhThucHDLD"] = dr["ID"];
                    drNew["IDNS_LinhVucCongTac"] = drLinhVuc["NS_LinhVucCongTacID"];
                    drNew["STT"] = k.ToString();
                    drNew["TenLinhVuc"] = drLinhVuc["TenLinhVuc"];
                    dtBaoCao.Rows.Add(drNew);
                }
            }
            drNew = dtBaoCao.NewRow();
            drNew["IDHinhThucHDLD"] = "";
            drNew["IDNS_LinhVucCongTac"] = 0;
            drNew["TenLinhVuc"] = "Cộng";
            dtBaoCao.Rows.Add(drNew);
        }

        private void XuLyBaoCao()
        {
            DataTable dtTemp, dtData = oBNS_GiaoVien.GetBaoCaoChatLuongCanBo((DateTime)dtpDenNgay.EditValue);
            DataView dvTemp;
            DataRow dr;
            for (int i = 0; i < dtBaoCao.Rows.Count; i++)
            {
                dr = dtBaoCao.Rows[i];
                if (dr["IDHinhThucHDLD"].ToString() == "BCSN")
                {
                    // Nếu là dr thuộc Biên chế sự nghiệp
                    if (dr["IDNS_LinhVucCongTac"].ToString() == "0")
                    {
                        count = int.Parse(dtData.Compute("Count(NS_GiaoVienID)", "IDHinhThucHDLD <> 'BCSN'").ToString());
                        dr["TongSo"] = dtData.Rows.Count - count;
                        dvTemp = new DataView(dtData);
                        dvTemp.RowFilter = "IDHinhThucHDLD = 'BCSN'";
                        if (dvTemp.Count > 0)
                        {
                            dtTemp = dvTemp.ToTable();
                            SetItemValue(dtTemp, ref dr);
                        }
                    }
                    else
                    {
                        count = int.Parse(dtData.Compute("Count(NS_GiaoVienID)", "IDHinhThucHDLD = 'BCSN' And IDNS_LinhVucCongTac = " +
                            dr["IDNS_LinhVucCongTac"]).ToString());
                        if (count > 0)
                            dr["TongSo"] = count;
                        dvTemp = new DataView(dtData);
                        dvTemp.RowFilter = "IDHinhThucHDLD = 'BCSN' And IDNS_LinhVucCongTac = " + dr["IDNS_LinhVucCongTac"];
                        if (dvTemp.Count > 0)
                        {
                            dtTemp = dvTemp.ToTable();
                            SetItemValue(dtTemp, ref dr);
                        }
                    }
                }
                else if (dr["IDHinhThucHDLD"].ToString() != "")
                {
                    // Nếu không phải là Biên chế sự nghiệp
                    if (dr["IDNS_LinhVucCongTac"].ToString() == "0")
                    {
                        count = int.Parse(dtData.Compute("Count(NS_GiaoVienID)", "IDHinhThucHDLD = '" + dr["IDHinhThucHDLD"] + "'").ToString());
                        if (count > 0)
                            dr["TongSo"] = count;
                        dvTemp = new DataView(dtData);
                        dvTemp.RowFilter = "IDHinhThucHDLD = 'TLKP'";
                        if (dvTemp.Count > 0)
                        {
                            dtTemp = dvTemp.ToTable();
                            SetItemValue(dtTemp, ref dr);
                        }
                    }
                    else
                    {
                        count = int.Parse(dtData.Compute("Count(NS_GiaoVienID)", "IDHinhThucHDLD = '" + dr["IDHinhThucHDLD"] +
                            "' And IDNS_LinhVucCongTac = " + dr["IDNS_LinhVucCongTac"]).ToString());
                        if (count > 0)
                            dr["TongSo"] = count;
                        dvTemp = new DataView(dtData);
                        dvTemp.RowFilter = "IDHinhThucHDLD = 'TLKP' And IDNS_LinhVucCongTac = " + dr["IDNS_LinhVucCongTac"];
                        if (dvTemp.Count > 0)
                        {
                            dtTemp = dvTemp.ToTable();
                            SetItemValue(dtTemp, ref dr);
                        }
                    }
                }
                else
                {
                    // Nếu là dòng tổng cuối cùng
                    string str;
                    for (int j = 4; j < dtBaoCao.Columns.Count; j++)
                    {
                        str = dtBaoCao.Columns[j].ColumnName;
                        dr[str] = dtBaoCao.Compute("Sum(" + str + ")", "IDHinhThucHDLD <> '' And IDNS_LinhVucCongTac = 0");
                    }
                }
            }
        }

        private void SetItemValue(DataTable dtTemp, ref DataRow dr)
        {
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
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "LoaiCongChuc = 'B'");
            if (count > 0)
                dr["CS"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "LoaiCongChuc = 'C'");
            if (count > 0)
                dr["ConLai"] = count;

            // Chia theo chuyên môn
            dr["TongSoChuyenMon"] = dr["TongSo"];
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "MaLoaiChuyenMon = 'A' And TenHocVi = 'Tiến sỹ'");
            if (count > 0)
                dr["TienSy"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "MaLoaiChuyenMon = 'A' And TenHocVi = 'Thạc sỹ'");
            if (count > 0)
                dr["ThacSy"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "MaLoaiChuyenMon = 'A' And TenHocVi = 'Đại học'");
            if (count > 0)
                dr["DaiHoc"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "MaLoaiChuyenMon = 'A' And TenHocVi = 'Cao đẳng'");
            if (count > 0)
                dr["CaoDang"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "MaLoaiChuyenMon = 'B'");
            if (count > 0)
                dr["TrungHoc"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "MaLoaiChuyenMon <> 'A' And MaLoaiChuyenMon <> 'B'");
            if (count > 0)
                dr["ConLaiChuyenMon"] = count;

            // Chia theo trình độ chính trị
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "TenTrinhDoLyLuan = 'Cao cấp'");
            if (count > 0)
                dr["ChinhTriCaoCap"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "TenTrinhDoLyLuan = 'Trung cấp'");
            if (count > 0)
                dr["ChinhTriTrungCap"] = count;

            // Chia theo trình độ tin học
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "IDTrinhDoTinHoc = 'CN'");
            if (count > 0)
                dr["TinHocCuNhan"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "IDTrinhDoTinHoc = 'SC'");
            if (count > 0)
                dr["TinHocCoSo"] = count;

            // Chia theo trình độ ngoại ngữ
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "TenNgoaiNgu = 'Tiếng anh' And IDTrinhDoNgoaiNgu = 'CN'");
            if (count > 0)
                dr["AnhVanCuNhan"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "TenNgoaiNgu = 'Tiếng anh' And IDTrinhDoNgoaiNgu = 'SC'");
            if (count > 0)
                dr["AnhVanCoSo"] = count;

            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "TenNgoaiNgu <> 'Tiếng anh' And IDTrinhDoNgoaiNgu = 'CN'");
            if (count > 0)
                dr["NgoaiNguCuNhan"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "TenNgoaiNgu <> 'Tiếng anh' And IDTrinhDoNgoaiNgu = 'SC'");
            if (count > 0)
                dr["NgoaiNguCoSo"] = count;

            // Chia theo học hàm
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "TenHocHam = 'Giáo sư'");
            if (count > 0)
                dr["GiaoSu"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "TenHocHam = 'Phó giáo sư'");
            if (count > 0)
                dr["PhoGiaoSu"] = count;

            // Chia theo độ tuổi
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "Tuoi < 30");
            if (count > 0)
                dr["Duoi30"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "30 < Tuoi And Tuoi <= 50");
            if (count > 0)
                dr["Tu30Den50"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "50 < Tuoi And Tuoi <= 60");
            if (count > 0)
                dr["TongTren50Den60"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "(GioiTinh = 0 And Tuoi = 59) OR (GioiTinh = 1 And Tuoi = 54)");
            if (count > 0)
                dr["Nu54Nam59"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "(GioiTinh = 0 And Tuoi > 60) OR (GioiTinh = 1 And Tuoi > 55)");
            if (count > 0)
                dr["TrenTuoiNghiHuu"] = count;

            // Chia theo lĩnh vực khác
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "Not NgayVaoDang Is Null");
            if (count > 0)
                dr["DangVien"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "GioiTinh = 1");
            if (count > 0)
                dr["PhuNu"] = count;
            count = (int)dtTemp.Compute("Count(NS_GiaoVienID)", "IDDM_DanToc > 1");
            if (count > 0)
                dr["DanTocItNguoi"] = count;
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            if (dtpDenNgay.EditValue == null)
            {
                ThongBao("Bạn phải chọn đến ngày !");
                return;
            }
            CreateTable();
            XuLyBaoCao();
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
            string strFileExcel = DuongDan + "\\Template\\Temp_BaoCaoChatLuongCanBoTheoLinhVuc.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + "! Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                return;
            }
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Excel file (*.xls)|*.xls";
            sv.Title = "Xuất dữ liệu";
            sv.FileName = "Bao cao chat luong can bo theo linh vuc den ngay " + ((DateTime)dtpDenNgay.EditValue).ToString("yyyyMMdd") + ".xls";
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
            int DongBatDau = 10, SoCot = bgrvBaoCao.Columns.Count; //, ExcCotBatDau = 5, SoCot = 22;
            Excel.Range cel;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);

                excel.Cells[4, 1] = "(Có đến ngày " + dtpDenNgay.Text + ")";

                int count = dtBaoCao.Rows.Count;
                DataRow dr;
                for (int i = 0; i < count; i++)
                {
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 1]);
                    cel.EntireRow.Insert(Excel.XlDirection.xlUp, null);
                    dr = dtBaoCao.Rows[i];

                    for (int j = _ColStart; j < dtBaoCao.Columns.Count; j++)
                    {
                        if ("" + dr[dtBaoCao.Columns[j].ColumnName] != "")
                        {
                            excel.Cells[i + DongBatDau, j - _ColStart + 1] = dr[dtBaoCao.Columns[j].ColumnName].ToString();
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