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
    public partial class frmNhapDiemThanhPhan : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DataTable dtMonKy, dtSinhVien, dtThanhPhan, dtData;
        private cBXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo;
        private cBKQHT_DiemThanhPhan oBKQHT_DiemThanhPhan;
        private cBKQHT_CongThucDiem oBKQHT_CongThucDiem;
        private KQHT_CongThucDiemInfo pKQHT_CongThucDiemInfo;
        private cBKQHT_DiemThi oBKQHT_DiemThi;
        private KQHT_DiemThiInfo pKQHT_DiemThiInfo;
        private int IDDM_Lop = 0;

        public frmNhapDiemThanhPhan()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
            oBKQHT_DiemThanhPhan = new cBKQHT_DiemThanhPhan();
            pKQHT_DiemThanhPhanInfo = new KQHT_DiemThanhPhanInfo();
            pKQHT_CongThucDiemInfo = new KQHT_CongThucDiemInfo();
            oBKQHT_CongThucDiem = new cBKQHT_CongThucDiem();
            oBKQHT_DiemThi = new cBKQHT_DiemThi();
            pKQHT_DiemThiInfo = new KQHT_DiemThiInfo();
            rdgTuDanhSach.Enabled = false;
        }

        private void frmNhapDiemThanhPhan_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
            LoadMonKy(0);
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            DM_LopInfo pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                IDDM_Lop = pDM_LopInfo.DM_LopID;
                LoadMonKy(IDDM_Lop);
                btnCapNhat.Enabled = true;
            }
            else
            {
                LoadMonKy(0);
                btnCapNhat.Enabled = false;
            }
        }

        private void LoadMonKy(int IDDM_Lop)
        {
            if (IDDM_Lop > 0)
                dtMonKy = oBXL_MonHocTrongKy.GetByLop(IDDM_Lop, Program.IDNamHoc, Program.HocKy);
            cmbMonHoc.Properties.DataSource = dtMonKy;
            if ((dtMonKy != null) && (dtMonKy.Rows.Count > 0))
            {
                cmbMonHoc.ItemIndex = 0;
                cmbMonHoc_EditValueChanged(null, null);
            }
            else
            {
                cmbMonHoc.EditValue = null;
                if (dtSinhVien != null)
                    dtSinhVien.Clear();
            }
        }

        private void rdNhapDiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMonHoc.EditValue != null)
            {
                LoadSinhVien(rdNhapDiem.EditValue.ToString());
            }
            if (rdNhapDiem.SelectedIndex == 0)
                cmbLanThi.Enabled = false;
            else
                cmbLanThi.Enabled = true;
        }

        private void cmbMonHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbMonHoc.EditValue != null)
            {
                LoadSinhVien(rdNhapDiem.EditValue.ToString());
            }
            else
                btnCapNhat.Enabled = false;
        }

        private void cmbLanThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLanThi.EditValue.ToString() == "1")
                rdgTuDanhSach.Enabled = false;
            else
                rdgTuDanhSach.Enabled = true;
            
            LoadSinhVien(rdNhapDiem.EditValue.ToString());
        }

        private void LoadSinhVien(string KieuNhap)
        {
            if (dtSinhVien != null)
                dtSinhVien.Clear();
            dtSinhVien = CreateTable();
            AddBand(KieuNhap);
            XuLyTable();
            grdDiem.DataSource = dtSinhVien;
            dtSinhVien.AcceptChanges();
            btnCapNhat.Enabled = true;
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SV_SinhVienID", typeof(int));
            dt.Columns.Add("MaSinhVien", typeof(string));
            dt.Columns.Add("HoVaTen", typeof(string));
            dt.Columns.Add("TenLop", typeof(string));
            return dt;
        }

        private void AddBand(string KieuNhap)
        {
            BandedGridColumn bgc;
            KQHT_ThanhPhanDiemInfo pKQHT_ThanPhanDiemInfo = new KQHT_ThanhPhanDiemInfo();
            cBKQHT_ThanhPhanDiem oBKQHT_ThanhPhanDiem = new cBKQHT_ThanhPhanDiem();
            dtThanhPhan = oBKQHT_ThanhPhanDiem.Get(pKQHT_ThanPhanDiemInfo);
            grbNhapDiem.Columns.Clear();
            if ((dtThanhPhan != null) && (dtThanhPhan.Rows.Count > 0))
            {
                DataRow[] drThanhPhan = dtThanhPhan.Select("Thi=" + KieuNhap);
                foreach (DataRow dr in drThanhPhan)
                {
                    dtSinhVien.Columns.Add(dr["KQHT_ThanhPhanDiemID"].ToString(), typeof(float));

                    bgc = new BandedGridColumn();
                    grbNhapDiem.Columns.Add(bgc);

                    SetColumnBandCaption(bgc, dr["KyHieu"].ToString(), dr["KQHT_ThanhPhanDiemID"].ToString(), 80, DevExpress.Utils.HorzAlignment.Default, false);
                    bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    bgc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                    bgvDiem.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });
                }
            }
        }

        private void XuLyTable()
        {
            if (dtThanhPhan.Rows.Count > 0)
            {
                if (rdNhapDiem.EditValue.ToString() == "1" && cmbLanThi.EditValue.ToString() != "1")
                {
                    if (rdgTuDanhSach.EditValue.ToString() == "THI_LAI")
                        dtData = oBKQHT_DiemThi.GetDanhSachThiLai(IDDM_Lop, int.Parse(cmbMonHoc.EditValue.ToString()), Program.IDNamHoc, Program.HocKy, int.Parse(cmbLanThi.EditValue.ToString()));
                    else
                        dtData = oBKQHT_DiemThi.GetDanhSachKhongQua(IDDM_Lop, int.Parse(cmbMonHoc.EditValue.ToString()), Program.IDNamHoc, Program.HocKy, int.Parse(cmbLanThi.EditValue.ToString()));
                }
                else
                {
                    if (rdNhapDiem.SelectedIndex == 0)
                        dtData = oBKQHT_DiemThanhPhan.GetDanhSach(IDDM_Lop, int.Parse(cmbMonHoc.EditValue.ToString()), int.Parse(cmbMonHoc.GetColumnValue("XL_MonHocTrongKyID").ToString()), Program.IDNamHoc, Program.HocKy, 1, 0);
                    else
                        dtData = oBKQHT_DiemThi.GetDanhSach(IDDM_Lop, int.Parse(cmbMonHoc.EditValue.ToString()), int.Parse(cmbMonHoc.GetColumnValue("XL_MonHocTrongKyID").ToString()), Program.IDNamHoc, Program.HocKy, int.Parse(cmbLanThi.EditValue.ToString()));
                }
                DataRow drNew;
                if (dtData.Rows.Count > 0)
                {
                    string SV_SinhVienID = dtData.Rows[0]["SV_SinhVienID"].ToString();
                    drNew = dtSinhVien.NewRow();
                    drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                    drNew["MaSinhVien"] = dtData.Rows[0]["MaSinhVien"].ToString();
                    drNew["HoVaTen"] = dtData.Rows[0]["HoVaTen"].ToString();
                    drNew["TenLop"] = dtData.Rows[0]["TenLop"].ToString();

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

                            if (bool.Parse(dr["Thi"].ToString()) == (rdNhapDiem.EditValue.ToString() == "0" ? false : true))
                                drNew[dr["KQHT_ThanhPhanDiemID"].ToString()] = dr["Diem"];
                        }
                        else
                        {
                            if (bool.Parse(dr["Thi"].ToString()) == (rdNhapDiem.EditValue.ToString() == "0" ? false : true))
                                drNew[dr["KQHT_ThanhPhanDiemID"].ToString()] = dr["Diem"];
                        }
                    }
                    dtSinhVien.Rows.Add(drNew);
                }
            }
        }

        private void bgvDiem_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = dtSinhVien.GetChanges();
            if (dtTemp != null)
            {
                foreach (DataRow dr in dtTemp.Rows)
                {
                    if (dr.RowState == DataRowState.Modified)
                    {
                        // update vao bang KQHT_ThanhPhanDiem                          
                        for (int i = 0; i < grbNhapDiem.Columns.Count; i++)
                        {
                            if ("" + dr[grbNhapDiem.Columns[i].FieldName] != "")
                            {
                                try
                                {
                                    if (rdNhapDiem.EditValue.ToString() == "0")
                                    {
                                        pKQHT_DiemThanhPhanInfo.HocKy = Program.HocKy;
                                        pKQHT_DiemThanhPhanInfo.IDDM_NamHoc = Program.IDNamHoc;
                                        pKQHT_DiemThanhPhanInfo.IDDM_MonHoc = int.Parse(cmbMonHoc.EditValue.ToString());
                                        pKQHT_DiemThanhPhanInfo.IDHT_User = Program.objUserCurrent.HT_UserID;
                                        pKQHT_DiemThanhPhanInfo.IDKQHT_ThanhPhanDiem = int.Parse(grbNhapDiem.Columns[i].FieldName);
                                        pKQHT_DiemThanhPhanInfo.LyDo = "";
                                        pKQHT_DiemThanhPhanInfo.Diem = float.Parse(dr[grbNhapDiem.Columns[i].FieldName].ToString());
                                        pKQHT_DiemThanhPhanInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                                        pKQHT_DiemThanhPhanInfo.NgayTao = DateTime.Now;
                                        pKQHT_DiemThanhPhanInfo.IDXL_MonHocTrongKy = int.Parse(cmbMonHoc.GetColumnValue("XL_MonHocTrongKyID").ToString());
                                        oBKQHT_DiemThanhPhan.Add(pKQHT_DiemThanhPhanInfo);
                                    }
                                    else
                                    {
                                        pKQHT_DiemThiInfo.HocKy = Program.HocKy;
                                        pKQHT_DiemThiInfo.IDDM_NamHoc = Program.IDNamHoc;
                                        pKQHT_DiemThiInfo.IDDM_MonHoc = int.Parse(cmbMonHoc.EditValue.ToString());
                                        pKQHT_DiemThiInfo.IDHT_User = Program.objUserCurrent.HT_UserID;
                                        pKQHT_DiemThiInfo.LyDo = "";
                                        pKQHT_DiemThiInfo.Diem = float.Parse(dr[grbNhapDiem.Columns[i].FieldName].ToString());
                                        pKQHT_DiemThiInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                                        pKQHT_DiemThiInfo.NgayTao = DateTime.Now;
                                        pKQHT_DiemThiInfo.LanThi = int.Parse(cmbLanThi.EditValue.ToString());
                                        pKQHT_DiemThiInfo.IDXL_MonHocTrongKy = int.Parse(cmbMonHoc.GetColumnValue("XL_MonHocTrongKyID").ToString());
                                        oBKQHT_DiemThi.Add(pKQHT_DiemThiInfo);
                                    }
                                }
                                catch
                                {
                                    // error
                                }
                            }
                        }
                    }
                }
                ThongBao("Cập nhật thành công!");
            }
            else
                ThongBao("Bạn cần thay đổi thông tin trước khi cập nhật!");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToXls(bgvDiem);
        }

        private void bgvDiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (ThongBaoChon("Bạn có chắc chắn muốn xóa không?Sau khi xóa dữ liệu sẽ được load lại!") == DialogResult.Yes)
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
                                oBKQHT_DiemThanhPhan.DeleteBy_SinhVien(IDSV_SinhVien, int.Parse(cmbLanThi.EditValue.ToString()), int.Parse(cmbMonHoc.EditValue.ToString()), Program.IDNamHoc, Program.HocKy, int.Parse(TenCot));

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
    }
}