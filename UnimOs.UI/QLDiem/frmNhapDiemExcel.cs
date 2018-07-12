using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Collections;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;
using DevExpress.XtraGrid.Columns;

namespace UnimOs.UI
{
    public partial class frmNhapDiemExcel : frmBase
    {
        private System.Data.OleDb.OleDbConnection cnnDuLieuNguon = new System.Data.OleDb.OleDbConnection();
        private DataTable dtDuLieuFile, dtDuLieuNguon, dtTruongAnhXa, dtAnhXa, dtDuLieuChuyenDuoc, dtDuLieuKhongChuyenDuoc;
        private Hashtable htbAnhXa;
        private cBHT_DuLieuNhap oBHT_DuLieuNhap;

        public frmNhapDiemExcel()
        {
            InitializeComponent();

            // Check quyền để cho phép hay không cho phép thực hiện thao tạc lưu dữ liệu
            SetQuyen(this, "" + this.Tag);

            oBHT_DuLieuNhap = new cBHT_DuLieuNhap();
            lciMonHoc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void frmNhapDiemExcel_Load(object sender, EventArgs e)
        {
            cmbLop.Properties.DataSource = new cBDM_Lop().GetTree(Program.NamHoc);
        }

        private bool ValidNhapDiem(string LoaiDiem)
        {
            if (cmbLop.ItemIndex < 0)
            {
                ThongBao("Bạn chưa chọn lớp học.");
                cmbLop.Focus();
                return false;
            }
            if (LoaiDiem == "DTP")
            {
                if (cmbMonHoc.ItemIndex < 0)
                {
                    ThongBao("Bạn chưa chọn môn học.");
                    cmbMonHoc.Focus();
                    return false;
                }
            }
            return true;
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            try
            {
                string LoaiNguon = rdgNguon.EditValue.ToString();
                OpenFileDialog odlg = new OpenFileDialog();
                if (LoaiNguon == "Excel")
                {
                    odlg.Filter = "Excel files(*.xls;*.xlsx)|*.xls;*.xlsx";
                }
                else if (LoaiNguon == "Access")
                {
                    odlg.Filter = "Access files (*.mdb;*.accdb)|*.mdb;*.accdb";
                }
                else if (LoaiNguon == "Foxpro")
                {
                    odlg.Filter = "Foxpro files (*.dbc;*.dbf)|*.dbc;*.dbf";
                }
                if (odlg.ShowDialog() == DialogResult.OK)
                {
                    string strFileName = odlg.FileName;
                    TaoKetNoiOleDB(cnnDuLieuNguon, LoaiNguon, strFileName);
                    HienThiDanhSachCacSheet(cnnDuLieuNguon, lstSheet);

                    grdDuLieuNguon.DataSource = null;
                    grvDuLieuNguon.Columns.Clear();

                    lstSheet_SelectedIndexChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                ThongBao(ex.Message);
            }
        }

        private void lstSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSheet.SelectedIndex < 0)
            {
                dtDuLieuNguon = null;
                dtTruongAnhXa = null;
                return;
            }
            try
            {
                grdDuLieuNguon.DataSource = null;
                grvDuLieuNguon.Columns.Clear();
                dtDuLieuFile = GetDuLieuOleDb(cnnDuLieuNguon, lstSheet.Items[lstSheet.SelectedIndex].ToString());

                if (!dtDuLieuFile.Columns.Contains("@stt"))
                    dtDuLieuFile.Columns.Add("@stt", typeof(int));
                for (int i = 0; i < dtDuLieuFile.Rows.Count; i++)
                    dtDuLieuFile.Rows[i]["@stt"] = i + 1;

                dtDuLieuNguon = dtDuLieuFile.Copy();

                grdDuLieuNguon.DataSource = dtDuLieuNguon;
                grvDuLieuNguon.Columns["@stt"].Visible = false;

                dtTruongAnhXa = TaoBangCotChuyenDoi(dtDuLieuNguon);
                if (dtTruongAnhXa != null && !dtTruongAnhXa.Columns.Contains("ID"))
                {
                    dtTruongAnhXa.Columns.Add("ID", typeof(object));
                }
                grdAnhXaTruongDuLieu.DataSource = dtTruongAnhXa;
                cmbConvertFont_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                ThongBao(ex.Message);
            }
        }

        private void grvDuLieuNguon_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvAnhXaTruongDuLieu_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "ID")
            {
                LookUpEdit edit = (LookUpEdit)view.ActiveEditor;
                DataTable dtThanhPhan = (DataTable)edit.Properties.LookUpData.DataSource;
                DataView dv = new DataView(dtThanhPhan);
                string strFilter = "";
                for (int i = 0; i < grvAnhXaTruongDuLieu.DataRowCount; i++)
                {
                    if (i != grvAnhXaTruongDuLieu.FocusedRowHandle)
                    {
                        if (grvAnhXaTruongDuLieu.GetDataRow(i)["ID"].ToString() != "")
                        {
                            strFilter += (strFilter == "" ? "ID <> '" + grvAnhXaTruongDuLieu.GetDataRow(i)["ID"].ToString() + "'" :
                                " And ID <> '" + grvAnhXaTruongDuLieu.GetDataRow(i)["ID"].ToString() + "'");
                        }
                    }
                }
                if (strFilter != "")
                    dv.RowFilter = strFilter;
                edit.Properties.LookUpData.DataSource = dv;
            }
        }

        private void repositoryItemLookUpEditDuLieuDich_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && grvAnhXaTruongDuLieu.ActiveEditor is LookUpEdit)
            {
                LookUpEdit edit = sender as LookUpEdit;
                edit.EditValue = null;
            }
        }

        private void btnThucHienNhapDiem_Click(object sender, EventArgs e)
        {
            if (dtDuLieuNguon == null)
            {
                ThongBao("Bạn chưa chọn dữ liệu nguồn.");
                btnChonFile.Focus();
                return;
            }
            if (!ValidNhapDiem(rdgLoaiDiem.EditValue.ToString()))
                return;

            dtDuLieuKhongChuyenDuoc = dtDuLieuNguon.Clone();
            if (!dtDuLieuKhongChuyenDuoc.Columns.Contains("LyDo"))
                dtDuLieuKhongChuyenDuoc.Columns.Add("LyDo", typeof(string));
            grvDuLieuChuyenDuoc.Columns.Clear();
            grdDuLieuChuyenDuoc.DataSource = null;
            dtDuLieuChuyenDuoc = oBHT_DuLieuNhap.CreateTableChuyenDuoc(dtTruongAnhXa, ref htbAnhXa, rdgLoaiDiem.EditValue.ToString());
            // Kiểm tra trường dữ liệu ánh xạ đã có đủ các trường bắt buộc chưa
            string str = oBHT_DuLieuNhap.KiemTraCacTruongBatBuoc(htbAnhXa, rdgLoaiDiem.EditValue.ToString());
            if (str != "")
            {
                ThongBao(str);
                return;
            }
            if (dtDuLieuChuyenDuoc.Columns.Count >= 2)
            {
                GridColumn grc;
                DataRow[] arrDr;
                
                for (int i = 1; i < dtDuLieuChuyenDuoc.Columns.Count; i++)
                {
                    grc = new GridColumn();
                    arrDr = dtAnhXa.Select("ID = '" + dtDuLieuChuyenDuoc.Columns[i].ColumnName + "'");
                    SetColumnCaption(grc, arrDr[0]["TenTruongDuLieu"].ToString(), dtDuLieuChuyenDuoc.Columns[i].ColumnName, 85,
                            DevExpress.Utils.HorzAlignment.Default, false, dtDuLieuChuyenDuoc.Columns[i].ColumnName == "MaSinhVien" ? 0 : i + 5);
                    grvDuLieuChuyenDuoc.Columns.AddRange(new GridColumn[] { grc });
                }

                dtDuLieuChuyenDuoc.Columns.Add("HoVaTen", typeof(string));
                grc = new GridColumn();
                SetColumnCaption(grc, "Họ và tên", "HoVaTen", 85, DevExpress.Utils.HorzAlignment.Default, false, 1);
                grvDuLieuChuyenDuoc.Columns.AddRange(new GridColumn[] { grc });
                dtDuLieuChuyenDuoc.Columns.Add("TenLop", typeof(string));
                grc = new GridColumn();
                SetColumnCaption(grc, "Tên lớp", "TenLop", 85, DevExpress.Utils.HorzAlignment.Default, false, 2);
                grvDuLieuChuyenDuoc.Columns.AddRange(new GridColumn[] { grc });

                // Thực hiện kiểm tra quá trình nhập thông tin
                if(dtDuLieuNguon != null)
                    if (dtDuLieuNguon.Rows.Count > 0)
                    {
                        if (rdgLoaiDiem.EditValue.ToString() == "DTP")
                            oBHT_DuLieuNhap.ChuyenDiemThanhPhan(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa);
                        else
                            oBHT_DuLieuNhap.ChuyenDiemTongKet(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa);
                    }

                // Set lại DataSource
                grdDuLieuChuyenDuoc.DataSource = dtDuLieuChuyenDuoc;
                grvDuLieuKhongChuyenDuoc.Columns.Clear();
                grdDuLieuKhongChuyenDuoc.DataSource = dtDuLieuKhongChuyenDuoc;

                tabpageKetQua.PageEnabled = true;
                tabExcel.SelectedTabPage = tabpageKetQua;
                lblInfo.Text = "Nhập điểm cho lớp " + cmbLop.EditValue + 
                    (rdgLoaiDiem.EditValue.ToString() == "DTP" ? " - môn học " + cmbMonHoc.Text : "") + " - lần thi " + cmbLanThi.EditValue;
            }
            else
                ThongBao("Chưa đủ các trường bắt buộc để nhập dữ liệu.");
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (grvDuLieuChuyenDuoc != null && grvDuLieuChuyenDuoc.DataRowCount > 0)
            {
                CreateWaitDialog("Chuyển dữ liệu", "Đang thực hiện việc chuyển dữ liệu\nXin vui lòng chờ ...");
                if (rdgLoaiDiem.EditValue.ToString() == "DTP")
                {
                    oBHT_DuLieuNhap.LuuDiemThanhPhan(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa,
                        int.Parse(cmbMonHoc.EditValue.ToString()), int.Parse(cmbLanThi.EditValue.ToString()),
                        Program.IDNamHoc, Program.HocKy, Program.objUserCurrent.HT_UserID);
                }
                else
                {
                    oBHT_DuLieuNhap.LuuDiemTongKet(ref dtDuLieuChuyenDuoc, ref dtDuLieuKhongChuyenDuoc, dtDuLieuNguon, htbAnhXa,
                        int.Parse(cmbLanThi.EditValue.ToString()), Program.IDNamHoc, Program.HocKy);
                }
                CloseWaitDialog();
                ThongBao("Chuyển dữ liệu thành công.");
                return;
            }
            ThongBao("Không có dữ liệu để lưu.");
        }

        private void rdgLoaiDiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLop.ItemIndex >= 0)
            {
                if (rdgLoaiDiem.EditValue.ToString() == "DTP")
                {
                    dtAnhXa = oBHT_DuLieuNhap.AnhXaNhapDiemThanhPhan();
                    repositoryItemLookUpEditDuLieuDich.DataSource = dtAnhXa;
                    lciMonHoc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                else
                {
                    dtAnhXa = oBHT_DuLieuNhap.AnhXaNhapDiemTongKet(int.Parse(cmbLop.EditValue.ToString()), Program.IDNamHoc, Program.HocKy);
                    repositoryItemLookUpEditDuLieuDich.DataSource = dtAnhXa;
                    lciMonHoc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
            }
        }

        private void cmbLop_EditValueChanged(object sender, EventArgs e)
        {
            rdgLoaiDiem_SelectedIndexChanged(null, null);
            cmbMonHoc.Properties.DataSource = new cBXL_MonHocTrongKy().GetByHocKyNamHoc(int.Parse(cmbLop.EditValue.ToString()), Program.HocKy, Program.IDNamHoc, 0, 0);
        }

        private void cmbConvertFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grvDuLieuNguon.DataRowCount <= 0)
                return;
            if (cmbConvertFont.EditValue == null)
                return;

            CHUAN_BO_GO BoGo;
            Font font;
            if (cmbConvertFont.EditValue.ToString() == CHUAN_BO_GO.TCVN.ToString())
            {
                if (LaFontHeThong(".VnTime"))
                {
                    font = new System.Drawing.Font(".VnTime", 10);
                    BoGo = CHUAN_BO_GO.TCVN;
                }
                else
                {
                    ThongBao("Không tồn tại font '.Vntime' cho chuẩn bộ gõ TCVN");
                    return;
                }
            }
            else if (cmbConvertFont.EditValue.ToString() == CHUAN_BO_GO.VNI.ToString())
            {
                if (LaFontHeThong("VNI-Times"))
                {
                    font = new System.Drawing.Font("VNI-Times", 10);
                    BoGo = CHUAN_BO_GO.VNI;
                }
                else
                {
                    ThongBao("Không tồn tại font 'VNI-Times' cho chuẩn bộ gõ VNI");
                    return;
                }
            }
            else
            {
                if (LaFontHeThong("Tahoma"))
                {
                    font = new System.Drawing.Font("Tahoma", 8.25f);
                    BoGo = CHUAN_BO_GO.UNICODE;
                }
                else
                {
                    ThongBao("Không tồn tại font 'Tahoma' cho chuẩn bộ gõ UNICODE");
                    return;
                }
            }

            dtDuLieuNguon = dtDuLieuFile.Copy();
            oBHT_DuLieuNhap.ConvertToUnicode(ref dtDuLieuNguon, BoGo);
            grdDuLieuNguon.DataSource = dtDuLieuNguon;
        }

        private bool LaFontHeThong(string FontName)
        {
            for (int i = 0; i < FontFamily.Families.Length; i++)
            {
                if (FontFamily.Families[i].Name == FontName)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}