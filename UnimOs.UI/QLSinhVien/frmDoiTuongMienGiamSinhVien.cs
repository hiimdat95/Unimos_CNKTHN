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
using System.Diagnostics;
using System.IO;
using UnimOs.UI.Properties;

namespace UnimOs.UI
{
    public partial class frmDoiTuongMienGiamSinhVien : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private cBSV_DoiTuongMienGiam oBSV_DoiTuongMienGiam;
        private SV_DoiTuongMienGiamInfo pSV_DoiTuongMienGiamInfo;
        private DataTable dtSinhVien;
        private DataRow drSinhVien;
        DataTable dtMienGiam;

        Dictionary<int, string> dicDoiTuongMienGiam = new Dictionary<int, string>();

        int IDDM_Khoa, IDDM_He, IDDM_TrinhDo, IDDM_KhoaHoc, IDDM_Nganh, IDDM_Lop;

        public frmDoiTuongMienGiamSinhVien()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            pDM_LopInfo = new DM_LopInfo();
            oBSV_DoiTuongMienGiam = new cBSV_DoiTuongMienGiam();
            pSV_DoiTuongMienGiamInfo = new SV_DoiTuongMienGiamInfo();
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
                IDDM_Lop = pDM_LopInfo.DM_LopID;
            LoadSinhVien_Lop();
        }

        private void LoadSinhVien_Lop()
        {
            IDDM_Khoa = pDM_LopInfo.IDDM_Khoa;
            IDDM_He = pDM_LopInfo.IDDM_He;
            IDDM_TrinhDo = pDM_LopInfo.IDDM_TrinhDo;
            IDDM_Nganh = pDM_LopInfo.IDDM_Nganh;
            IDDM_KhoaHoc = pDM_LopInfo.IDDM_KhoaHoc;
            dtSinhVien = oBSV_DoiTuongMienGiam.GetSinhVien(IDDM_Khoa, IDDM_He, IDDM_TrinhDo, IDDM_KhoaHoc, IDDM_Nganh, IDDM_Lop, Program.IDNamHoc, Program.HocKy);
            grdDanhSachSinhVien.DataSource = dtSinhVien;
        }

        private void LoadDoiTuongMienGiam()
        {
            cBDM_DoiTuongMienGiam oBDM_DoiTuongMienGiam = new cBDM_DoiTuongMienGiam();
            DM_DoiTuongMienGiamInfo pDM_DoiTuongMienGiamInfo = new DM_DoiTuongMienGiamInfo();
            dtMienGiam = oBDM_DoiTuongMienGiam.Get(pDM_DoiTuongMienGiamInfo);
            repositoryItemLookUpEdit_DoiTuongMienGiam.DataSource = dtMienGiam;

            foreach (DataRow row in dtMienGiam.Rows)
            {
                dicDoiTuongMienGiam.Add((int)row["DM_DoiTuongMienGiamID"], row["TenDoiTuongMienGiam"] + "");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (grvDanhSachSinhVien.DataRowCount == 0)
            {
                ThongBao("Không có dữ liêu.");
                return;
            }
            DataTable dtTemp = dtSinhVien.GetChanges();
            bool CapNhat = false;
            if (dtTemp == null)
            {
                ThongBao("Dữ liệu không thay đổi.");
                return;
            }
            else
            {
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    if (("" + dtTemp.Rows[i]["SV_DoiTuongMienGiamID"].ToString()) == "")
                    {
                        // Thêm
                        if (dtTemp.Rows[i]["IDDM_DoiTuongMienGiam"].ToString() != "")
                        {
                            pSV_DoiTuongMienGiamInfo.IDSV_SinhVien = int.Parse(dtTemp.Rows[i]["SV_SinhVienID"].ToString());
                            pSV_DoiTuongMienGiamInfo.IDDM_DoiTuongMienGiam = "" + dtTemp.Rows[i]["IDDM_DoiTuongMienGiam"].ToString() == "" ? 0 : int.Parse(dtTemp.Rows[i]["IDDM_DoiTuongMienGiam"].ToString());
                            pSV_DoiTuongMienGiamInfo.GhiChu = dtTemp.Rows[i]["GhiChu"].ToString();
                            pSV_DoiTuongMienGiamInfo.HocKy = Program.HocKy;
                            pSV_DoiTuongMienGiamInfo.IDDM_NamHoc = Program.IDNamHoc;

                            dtTemp.Rows[i]["SV_DoiTuongMienGiamID"] = oBSV_DoiTuongMienGiam.Add(pSV_DoiTuongMienGiamInfo);
                            CapNhat = true;
                        }
                    }
                    else
                    {
                        //Sửa
                        if (dtTemp.Rows[i]["IDDM_DoiTuongMienGiam"].ToString() != "")
                        {
                            pSV_DoiTuongMienGiamInfo.SV_DoiTuongMienGiamID = int.Parse(dtTemp.Rows[i]["SV_DoiTuongMienGiamID"].ToString());
                            pSV_DoiTuongMienGiamInfo.IDSV_SinhVien = int.Parse(dtTemp.Rows[i]["SV_SinhVienID"].ToString());
                            pSV_DoiTuongMienGiamInfo.IDDM_DoiTuongMienGiam = "" + dtTemp.Rows[i]["IDDM_DoiTuongMienGiam"].ToString() == "" ? 0 : int.Parse(dtTemp.Rows[i]["IDDM_DoiTuongMienGiam"].ToString());
                            pSV_DoiTuongMienGiamInfo.GhiChu = dtTemp.Rows[i]["GhiChu"].ToString();
                            pSV_DoiTuongMienGiamInfo.HocKy = Program.HocKy;
                            pSV_DoiTuongMienGiamInfo.IDDM_NamHoc = Program.IDNamHoc;

                            oBSV_DoiTuongMienGiam.Update(pSV_DoiTuongMienGiamInfo);
                            CapNhat = true;
                        }
                    }
                }
                if (CapNhat == true)
                {
                    ThongBao("Cập nhật thành công!");
                }
                LoadSinhVien_Lop();
                dtSinhVien.AcceptChanges();
            }
        }

        private void grvDanhSachSinhVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (grvDanhSachSinhVien.FocusedRowHandle >= 0)
                {

                    try
                    {
                        pSV_DoiTuongMienGiamInfo.SV_DoiTuongMienGiamID = int.Parse(drSinhVien["SV_DoiTuongMienGiamID"].ToString());
                        if (pSV_DoiTuongMienGiamInfo.SV_DoiTuongMienGiamID > 0)
                        {
                            oBSV_DoiTuongMienGiam.Delete(pSV_DoiTuongMienGiamInfo);
                            LoadSinhVien_Lop();
                        }
                        drSinhVien["IDSV_SinhVien"] = 0;
                    }
                    catch
                    {

                    }

                }
            }
        }

        private void grvDanhSachSinhVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvDanhSachSinhVien.FocusedRowHandle >= 0)
            {
                drSinhVien = dtSinhVien.NewRow();
                drSinhVien = grvDanhSachSinhVien.GetDataRow(grvDanhSachSinhVien.FocusedRowHandle);
            }
        }

        private void grvDanhSachSinhVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDoiTuongMienGiamSinhVien_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
            LoadDoiTuongMienGiam();
        }

        private void frmDoiTuongMienGiamSinhVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmDoiTuongMienGiam frm = new frmDoiTuongMienGiam();
                frm.ShowDialog();
                LoadDoiTuongMienGiam();
            }
        }

        private void btnKetXuat_Click(object sender, EventArgs e)
        {
            if (grvDanhSachSinhVien.DataRowCount == 0)
            {
                ThongBao("Không có dữ liêu.");
                return;
            }
            DataTable dtTemp = dtSinhVien.GetChanges();
            if (dtTemp != null)
            {
                ThongBao("Dữ liệu đã bị thay đổi. Hay lưu lại trước khi kết xuất.");
                return;
            }


                CreateWaitDialog("Đang xuất dữ liệu, xin vui lòng chờ.", "Xuất dữ liệu");
                try
                {
                    MemoryStream ms = new MemoryStream(Resources.DanhSachMienGiam);

                    var book = new Aspose.Cells.Workbook();
                    book.Open(ms);


                    var sheet = book.Worksheets[0];
                    var cells = sheet.Cells;

                    cells["A2"].PutValue("Danh sách đối tượng miễn giảm lớp " + pDM_LopInfo.TenLop);

                    var rIndex = 5;

                    var svFilter = dtSinhVien.Select("IDDM_DoiTuongMienGiam > 0");

                    for (var i = 0; i < svFilter.Length; i++)
                    {
                        if (i < svFilter.Length - 2)
                        {
                            cells.InsertRow(rIndex + i + 1);
                        }

                        cells["A" + (rIndex + i)].PutValue(i + 1);
                        cells["B" + (rIndex + i)].PutValue(svFilter[i]["MaSinhVien"]);
                        cells["C" + (rIndex + i)].PutValue(svFilter[i]["HoVaTen"]);
                        cells["D" + (rIndex + i)].PutValue(svFilter[i]["NgaySinh"]);
                        cells["E" + (rIndex + i)].PutValue(dicDoiTuongMienGiam[(int)svFilter[i]["IDDM_DoiTuongMienGiam"]]);
                    }

                    SaveFileDialog sDlg = new SaveFileDialog();
                    sDlg.Title = "Lưu file kết xuất";
                    sDlg.InitialDirectory = Application.StartupPath;
                    sDlg.FileName = "DanhSachMienGiam_" + DateTime.Now.ToString("yyyyMMddhhmm") + ".xls";

                    if (sDlg.ShowDialog() != DialogResult.Cancel)
                    {
                        book.Save(sDlg.FileName, Aspose.Cells.FileFormatType.Excel2003);

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
    }
}