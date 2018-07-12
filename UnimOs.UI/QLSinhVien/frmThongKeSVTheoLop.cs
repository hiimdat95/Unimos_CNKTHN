using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using Aspose.Cells;
using Aspose.Words;
namespace UnimOs.UI
{
    public partial class frmThongKeSVTheoLop : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private DataTable dtSinhVien;
        private SV_SinhVienInfo pSV_SinhVienInfo;
        private cBSV_SinhVien oBSV_SinhVien;
        private cBKQHT_DanhSachNgungHoc oBKQHT_DanhSachNgungHoc;
        private int IDDM_Lop;
        private DataRow drSinhVien;
        private Cells _range;
        private Worksheet _exSheet;

        private Dictionary<int, GridColumn> _grCols = new Dictionary<int, GridColumn>();

        class Thang
        {
            public int TuThang { get; set; }
            public int DenThang { get; set; }
        }
        class NamItem
        {
            public int Nam { get; set; }
        }

        public frmThongKeSVTheoLop()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            pDM_LopInfo = new DM_LopInfo();
            pSV_SinhVienInfo = new SV_SinhVienInfo();
            oBSV_SinhVien = new cBSV_SinhVien();
            oBKQHT_DanhSachNgungHoc = new cBKQHT_DanhSachNgungHoc();
            //repositoryItemLookUpEditGioiTinh.DataSource = LoadGioiTinhSV();

            //cboDanhSachHienThi.

            _grCols = new Dictionary<int, GridColumn>()
            {
                {0, tl},
                {1, g1},
                {2, g2},
                {3, g3},
                {4, g4},
                {5, g5},
                {6, g6},
                {7, g7},
                {8, g8},
                {9, g9},
                {10, g10},
                {11, g11},
                {12, g12}
            };
        }

        private void frmThongKeSVTheoLop_Load(object sender, EventArgs e)
        {
            //    LoadTreeLop(uctrlLop);
            //    uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);

            List<Thang> _listThang = new List<Thang>();
            for (int i = 1; i <= 12; i++)
            {
                _listThang.Add(new Thang() { TuThang = i, DenThang = i });
            }

            List<NamItem> _listNam = new List<NamItem>();
            for (int i = DateTime.Now.Year + 1; i >= DateTime.Now.Year - 5; i--)
            {
                _listNam.Add(new NamItem() { Nam = i });
            }

            cmbTuThang.Properties.DataSource = _listThang;
            cmbTuThang.EditValue = 1;
            cmbDenThang.Properties.DataSource = _listThang;
            cmbDenThang.EditValue = 12;

            cmbNam.Properties.DataSource = _listNam;
            cmbNam.EditValue = DateTime.Now.Year;
        }




        private void grvSinhVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }


        private void btnXuatDanhSach_Click(object sender, EventArgs e)
        {
            DataTable dbo = oBKQHT_DanhSachNgungHoc.GetSinhVienTKSoLuong((int)cmbNam.EditValue, (int)cmbTuThang.EditValue, (int)cmbDenThang.EditValue);
            if (dbo.Rows.Count > 0)
            {
                CreateWaitDialog("Đang xuất dữ liệu, xin vui lòng chờ.", "Xuất dữ liệu");
                try
                {
                    Workbook exBook = new Workbook();
                    exBook.Open(Application.StartupPath + "\\Template\\ThongKeSinhVien_Lop.xls", FileFormatType.Excel2003);

                    _exSheet = exBook.Worksheets[0];
                    _range = _exSheet.Cells;

                    //var fields = new string[] { "MaSinhVien", "HoVaTen", "NgaySinh", "NoiSinh", "ThuongTru", "KhenThuong", "KyLuat" };

                    _range["A2"].PutValue("Thống kê sĩ số lớp từ tháng " + cmbTuThang.EditValue + " đến tháng " + cmbDenThang.EditValue + " năm " + cmbNam.EditValue);

                    for (int i = 0; i <= ((int)cmbDenThang.EditValue - (int)cmbTuThang.EditValue); i++)
                    {
                        if (i <= ((int)cmbDenThang.EditValue - (int)cmbTuThang.EditValue) - 2)
                        {
                            _range.InsertColumn(3 + i);
                        }
                        _range[3, i + 2].PutValue("Tháng " + ((int)cmbTuThang.EditValue + i).ToString());


                    }
                    var rIndex = 4;
                    for (var i = 0; i < dbo.Rows.Count; i++)
                    {
                        if (i < dbo.Rows.Count - 2)
                        {
                            _range.InsertRow(rIndex + 1);
                        }
                        _range[rIndex, 0].PutValue(i + 1);
                        _range[rIndex, 1].PutValue(dbo.Rows[i]["TenLop"]);
                        for (int k = 0; k <= ((int)cmbDenThang.EditValue - (int)cmbTuThang.EditValue); k++)
                        {

                            _range[rIndex, k + 2].PutValue(dbo.Rows[i]["T" + ((int)cmbTuThang.EditValue + k).ToString()]);
                        }
                        rIndex++;
                    }

                    SaveFileDialog sDlg = new SaveFileDialog();
                    sDlg.Title = "Lưu file kết xuất";
                    sDlg.InitialDirectory = Application.StartupPath;
                    sDlg.FileName = "ThongKeSinhVien_Lop_" + DateTime.Now.ToString("yyyyMMddhhmm") + ".xls";

                    if (sDlg.ShowDialog() != DialogResult.Cancel)
                    {
                        exBook.Save(sDlg.FileName, Aspose.Cells.FileFormatType.Excel2003);

                        Process.Start(sDlg.FileName);
                    }
                }
                catch (Exception ex)
                {
                    ThongBaoLoi("Có lỗi khi xuất dữ liệu. " + ex.Message);
                }
                finally
                {
                    CloseWaitDialog();
                }
            }
            else
                ThongBao("Chưa có danh sách sinh viên.");
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            int tuThang = (int)cmbTuThang.EditValue;
            int denThang = (int)cmbDenThang.EditValue;

            DataTable dbo = oBKQHT_DanhSachNgungHoc.GetSinhVienTKSoLuong((int)cmbNam.EditValue, (int)cmbTuThang.EditValue, (int)cmbDenThang.EditValue);
            grdSinhVien.DataSource = dbo;

            grdSinhVien.SuspendLayout();
            grdSinhVien.BeginUpdate();
            //var listVisibleCol = new List<GridColumn> { _grCols[0] };
            //for (int i = tuThang; i <= denThang; i++)
            //{
            //    listVisibleCol.Add(_grCols[i]);
            //}

            //grvSinhVien.Columns.Clear();
            //grvSinhVien.Columns.AddRange(listVisibleCol.ToArray());

            //grvSinhVien.GridControl = grdSinhVien;

            foreach (GridColumn column in grvSinhVien.Columns)
            {
                var colName = (column.Name + "");
                if (!colName.StartsWith("g")) continue;

                if (int.Parse(colName.Replace("g", "")) < tuThang || int.Parse(colName.Replace("g", "")) > denThang)
                {
                    column.Visible = false;
                    //column.VisibleIndex = -1;
                }
                else
                {
                    column.Visible = true;
                    column.VisibleIndex = int.Parse(colName.Replace("g", ""));
                }
            }

            #region Bind lại vị trí cột 1 lần nữa thì nó mới hiển thị đúng vị trí - KHÔNG XÓA
            foreach (GridColumn column in grvSinhVien.Columns)
            {
                var colName = (column.Name + "");
                if (!colName.StartsWith("g")) continue;

                if (int.Parse(colName.Replace("g", "")) < tuThang || int.Parse(colName.Replace("g", "")) > denThang)
                {
                    column.Visible = false;
                    //column.VisibleIndex = -1;
                }
                else
                {
                    column.Visible = true;
                    column.VisibleIndex = int.Parse(colName.Replace("g", ""));
                }
            }

            #endregion

            grdSinhVien.EndUpdate();
            grdSinhVien.ResumeLayout();
        }
    }
}