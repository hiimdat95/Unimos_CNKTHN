using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace UnimOs.UI
{
    public partial class frmTongHopGioDay : frmBase
    {
        private cBNS_DonVi oBDonVi;
        private NS_DonViInfo pDonViInfo;
        private cBNS_GiaoVien oBGiaoVien;
        public NS_GiaoVienInfo pGiaoVienInfo;
        private DataTable dtTree, dtGiaoVien;
        private bool Loaded = false;

        public frmTongHopGioDay()
        {
            InitializeComponent();
            oBGiaoVien = new cBNS_GiaoVien();
            pGiaoVienInfo = new NS_GiaoVienInfo();
            pDonViInfo = new NS_DonViInfo();
        }

        private void frmDanhSachGiaoVien_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            Loaded = true;
            trvDonVi_FocusedNodeChanged(null, null);
        }

        private void LoadGiaoVien(int IDDonVi)
        {
            pGiaoVienInfo.IDNS_DonVi = IDDonVi;
            dtGiaoVien = oBGiaoVien.TongHopGioGiang(IDDonVi,Program.IDNamHoc);
            grdGiaoVien.DataSource = dtGiaoVien;            
        }

        private void LoadTreeView()
        {
            oBDonVi = new cBNS_DonVi();
            dtTree = oBDonVi.Get_Tree();
            trvDonVi.DataSource = dtTree;
            trvDonVi.ExpandAll();

        }

        private void trvDonVi_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (Loaded == true)
            {
                if (trvDonVi.Nodes.Count > 0)
                {
                    LoadGiaoVien(int.Parse(trvDonVi.FocusedNode["NS_DonViID"].ToString()));
                    pDonViInfo.NS_DonViID = int.Parse(trvDonVi.FocusedNode["NS_DonViID"].ToString());
                    pDonViInfo.MaDonVi = trvDonVi.FocusedNode["MaDonVi"].ToString();
                    pDonViInfo.TenDonVi = trvDonVi.FocusedNode["TenDonVi"].ToString();
                    pDonViInfo.ParentID = int.Parse(trvDonVi.FocusedNode["ParentID"].ToString());
                    pDonViInfo.Level = int.Parse(trvDonVi.FocusedNode["Level"].ToString());
                    pDonViInfo.IDDM_Khoa = int.Parse(trvDonVi.FocusedNode["IDDM_Khoa"].ToString());
                    pDonViInfo.IDDM_BoMon = int.Parse(trvDonVi.FocusedNode["IDDM_BoMon"].ToString());
                }
            }
        }

        private void grvGiaoVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            if (dtGiaoVien.Rows.Count == 0) return;
            if (dtGiaoVien.Columns.Contains("TienVuotGio") == false)
            {
                dtGiaoVien.Columns.Add("TienVuotGio", typeof(double));
            }
            for (int i = 0; i < dtGiaoVien.Rows.Count; i++)
            {
                if (dtGiaoVien.Rows[i]["GioVuot"] + "" != "0" && dtGiaoVien.Rows[i]["GioVuot"] + "" != "")
                {
                    if (dtGiaoVien.Rows[i]["HeSo"] + "" != "")
                    {
                        dtGiaoVien.Rows[i]["TienVuotGio"] = (1 + (double)dtGiaoVien.Rows[i]["HeSo"]) * (double)dtGiaoVien.Rows[i]["GioVuot"] * double.Parse(txtSoTienDinhMuc.Text);
                    }
                    else
                    {
                        dtGiaoVien.Rows[i]["TienVuotGio"] = (double)dtGiaoVien.Rows[i]["GioVuot"] * double.Parse(txtSoTienDinhMuc.Text);
                    }
                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            XuatTheoTemplate();
        }
      
        private void XuatTheoTemplate()
        {
            if (dtGiaoVien == null && dtGiaoVien.Rows.Count == 0)
            {
                ThongBao("Không có dữ liệu để xuất ra excel!");
                return;
            }
            string DuongDan = Application.StartupPath;
            string strFileExcel = "";
            strFileExcel = DuongDan + "\\Template\\TongHopGioGiang.xls";
            if (!File.Exists(strFileExcel))
            {
                ThongBao("Không tìm thấy file " + strFileExcel + "! Đề nghị kiểm tra lại đường dẫn thư mục hiện tại!");
                return;
            }
            SaveFileDialog sv = new SaveFileDialog();
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
               XuatDuLieuRaExcel(dtGiaoVien, strTenFileExcelMoi);
                ThongBao("Xuất dữ liệu thành công!");
            }

        }

        private void XuatDuLieuRaExcel(DataTable dtChiTiet, string FileExcel)
        {
            CreateWaitDialog("Đang xuất dữ liệu ra file Excel", "Xin vui lòng chờ!");
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int i = 0;
            int DongBatDau = 5;
            Excel.Range cel;

            Excel.ApplicationClass excel = new Excel.ApplicationClass();
            try
            {
                excel.Application.Workbooks.Open(FileExcel, true, false, true, "", "", true, true, true, true, true, true, true, true, false);
             
                excel.Cells[3, 3] = trvDonVi.FocusedNode["TenDonVi"].ToString();
                cel = (Excel.Range)excel.Cells[3, 3];
                cel.Font.Bold = true;

               for (i = 0; i < dtGiaoVien.Rows.Count; i++)
                {
                     excel.Cells[i + DongBatDau + 1, 1] = i + 1;
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 1]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau + 1, 2] = dtChiTiet.Rows[i]["MaGiaoVien"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 2]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau + 1, 3] = dtGiaoVien.Rows[i]["HoTen"] + "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 3]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau + 1, 4] = dtGiaoVien.Rows[i]["GioQuyChuan"];
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 4]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau + 1, 5] = dtGiaoVien.Rows[i]["SoGioGiam"];
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 5]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau + 1, 6] = dtGiaoVien.Rows[i]["SoGioDinhMuc"];
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 6]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau + 1, 7] = dtGiaoVien.Rows[i]["GioVuot"];
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 7]);
                    cel.Borders.Value = 1;

                    excel.Cells[i + DongBatDau + 1, 8] = dtGiaoVien.Rows[i]["HeSo"];
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 8]);
                    cel.Borders.Value = 1;

                    if (dtGiaoVien.Columns.Contains("TienVuotGio") == true)
                    {
                        excel.Cells[i + DongBatDau + 1, 9] = dtGiaoVien.Rows[i]["TienVuotGio"];
                    }
                    else
                        excel.Cells[i + DongBatDau + 1, 9] = "";
                    cel = (Excel.Range)(excel.Cells[i + DongBatDau + 1, 9]);
                    cel.Borders.Value = 1;

                }
            }
            catch (Exception e)
            {
                CloseWaitDialog();
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ThongBaoLoi("Xuất dữ liệu không thành công! Hãy đóng file Excel Tổng hợp giờ giảng trước khi xuất dữ liệu. Thông báo lỗi: " + e.Message);
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

        private void grdGiaoVien_DoubleClick(object sender, EventArgs e)
        {
            cBGG_CongViecGiaoVien cbCongViec = new cBGG_CongViecGiaoVien();
            int ID = int.Parse(grvGiaoVien.GetDataRow(grvGiaoVien.FocusedRowHandle)["NS_GiaoVienID"].ToString());
            dlgChiTietGioGiang dlg = new dlgChiTietGioGiang(oBGiaoVien.ChiTietGioGiang(ID, Program.IDNamHoc), cbCongViec.Get(ID,Program.IDNamHoc));
            dlg.ShowDialog();
        }
    }
}
