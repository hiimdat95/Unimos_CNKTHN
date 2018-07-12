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
using DevExpress.Utils;

namespace UnimOs.UI
{
    public partial class frmXetThiHetMon : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private DataTable dtMonKy, dtSinhVien, dtSinhVienKhongThi, dtThanhPhan,dtKhoaHoc,  dtTrinhDo, dtLop;
        private cBXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private cBKQHT_DanhSachKhongThi oBKQHT_DanhSachKhongThi;
        private KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo;
        int IDDM_MonHoc;
        private WaitDialogForm dlg;

        public frmXetThiHetMon()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
            pKQHT_DanhSachKhongThiInfo = new KQHT_DanhSachKhongThiInfo();
            oBKQHT_DanhSachKhongThi = new cBKQHT_DanhSachKhongThi();
            pDM_LopInfo = new DM_LopInfo();
        }

        private void frmXetThiHetMon_Load(object sender, EventArgs e)
        {
            bar1.Visible = true;
            LoadCombo();
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
            LoadMonKy(0);
        }

        private void LoadCombo()
        {
            cmbHe.Properties.DataSource = LoadHe();
            dtTrinhDo = LoadTrinhDo();
            cmbTrinhDo.Properties.DataSource = dtTrinhDo;
            cmbKhoa.Properties.DataSource = LoadKhoa();
            dtKhoaHoc = LoadKhoaHoc();
            cmbKhoaHoc.Properties.DataSource = dtKhoaHoc;
        }

        private void LoadDanhSachLop()
        {
            pDM_LopInfo.IDDM_Khoa = cmbKhoa.EditValue == null ? 0 : int.Parse(cmbKhoa.EditValue.ToString());
            pDM_LopInfo.IDDM_He = cmbHe.EditValue == null ? 0 : int.Parse(cmbHe.EditValue.ToString());
            pDM_LopInfo.IDDM_TrinhDo = cmbTrinhDo.EditValue == null ? 0 : int.Parse(cmbTrinhDo.EditValue.ToString());
            pDM_LopInfo.IDDM_Nganh = cmbNganh.EditValue == null ? 0 : int.Parse(cmbNganh.EditValue.ToString());
            pDM_LopInfo.IDDM_KhoaHoc = cmbKhoaHoc.EditValue == null ? 0 : int.Parse(cmbKhoaHoc.EditValue.ToString());
            dtLop = oBDM_Lop.GetDanhSachLop(pDM_LopInfo, Program.NamHoc);
            cmbLop.Properties.DataSource = dtLop;
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                LoadMonKy(pDM_LopInfo.DM_LopID);
            }
            else
            {
                LoadMonKy(0);
            }
        }

        private void LoadMonKy(int IDDM_Lop)
        {
            if (IDDM_Lop > 0)
                dtMonKy = oBXL_MonHocTrongKy.GetByLop(IDDM_Lop, Program.IDNamHoc, Program.HocKy);
            else
                dtMonKy =null;
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

        private void LoadSinhVien()
        {
            grbTongHop.Visible = false;
            if (dtSinhVien != null)
            {
                dtSinhVien.Clear();
                dtSinhVien.Columns.Clear();
            }
            dtSinhVien = CreateTable();
            AddBand();
            XuLyTable();
            grdDiem.DataSource = dtSinhVien;
            dtSinhVien.AcceptChanges();
            TongHop();
        }

        private void LoadSinhVienKhongThi()
        {
            if (dtSinhVienKhongThi != null)
                dtSinhVienKhongThi.Clear();
            if (cmbMonHoc.EditValue != null)
            {
                dtSinhVienKhongThi = oBKQHT_DanhSachKhongThi.GetIn_SinhVien(pDM_LopInfo.DM_LopID, int.Parse(cmbMonHoc.EditValue.ToString()), Program.IDNamHoc, Program.HocKy, 0);
            }
            grdKhongThi.DataSource = dtSinhVienKhongThi;
            dtSinhVienKhongThi.AcceptChanges();
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SV_SinhVienID", typeof(int));
            dt.Columns.Add("MaSinhVien", typeof(string));
            dt.Columns.Add("HoVaTen", typeof(string));
            dt.Columns.Add("DiemTB", typeof(float));
            dt.Columns.Add("LyDo", typeof(string));
            dt.Columns.Add("Chon", typeof(bool));
            return dt;
        }

        private void AddBand()
        {
            BandedGridColumn bgc;
            KQHT_ThanhPhanDiemInfo pKQHT_ThanPhanDiemInfo = new KQHT_ThanhPhanDiemInfo();
            cBKQHT_ThanhPhanDiem oBKQHT_ThanhPhanDiem = new cBKQHT_ThanhPhanDiem();
            dtThanhPhan = oBKQHT_ThanhPhanDiem.Get(pKQHT_ThanPhanDiemInfo);
            grbNhapDiem.Columns.Clear();
            if ((dtThanhPhan != null) && (dtThanhPhan.Rows.Count > 0))
            {
                DataRow[] drThanhPhan = dtThanhPhan.Select("Thi=0");

                foreach (DataRow dr in drThanhPhan)
                {
                    dtSinhVien.Columns.Add(dr["KQHT_ThanhPhanDiemID"].ToString(), typeof(float));

                    bgc = new BandedGridColumn();
                    grbNhapDiem.Columns.Add(bgc);

                    SetColumnBandCaption(bgc, dr["KyHieu"].ToString(), dr["KQHT_ThanhPhanDiemID"].ToString(), 70, DevExpress.Utils.HorzAlignment.Default, false);
                    bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    bgc.OptionsColumn.AllowEdit = false;
                    bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    bgc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                    bgvDiem.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });
                }
            }
        }

        private void XuLyTable()
        {
            if (dtThanhPhan.Rows.Count > 0 && IDDM_MonHoc!=0)
            {
                DataTable dt;
                dt = oBKQHT_DanhSachKhongThi.GetNotIn_SinhVien(pDM_LopInfo.DM_LopID, IDDM_MonHoc, Program.IDNamHoc, Program.HocKy, 1);
                DataRow drNew;
                if (dt.Rows.Count > 0)
                {
                    string SV_SinhVienID = dt.Rows[0]["SV_SinhVienID"].ToString();
                    drNew = dtSinhVien.NewRow();
                    drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                    drNew["MaSinhVien"] = dt.Rows[0]["MaSinhVien"].ToString();
                    drNew["HoVaTen"] = dt.Rows[0]["HoVaTen"].ToString();
                    drNew["Chon"] = dt.Rows[0]["Chon"].ToString();

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["SV_SinhVienID"].ToString() != SV_SinhVienID)
                        {
                            dtSinhVien.Rows.Add(drNew);
                            SV_SinhVienID = dr["SV_SinhVienID"].ToString();
                            drNew = dtSinhVien.NewRow();

                            drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                            drNew["MaSinhVien"] = dr["MaSinhVien"].ToString();
                            drNew["HoVaTen"] = dr["HoVaTen"].ToString();
                            drNew["Chon"] = dt.Rows[0]["Chon"].ToString();

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

        private void LoadTongHopSinhVien()
        {
            if (dtLop != null && dtLop.Rows.Count > 0)
            {
                if (cmbLop.EditValue == null)
                {
                    foreach (DataRow drLop in dtLop.Rows)
                    {
                         dtMonKy = oBXL_MonHocTrongKy.GetByLop(int.Parse(drLop["DM_LopID"].ToString()), Program.IDNamHoc, Program.HocKy);
                        foreach (DataRow drMonKy in dtMonKy.Rows)
                        {
                            if (dtSinhVien != null)
                            {
                                dtSinhVien.Clear();
                                dtSinhVien.Columns.Clear();
                            }
                            dtSinhVien = CreateTable();
                            AddBand();
                            XuLyTable();
                            TongHop();
                            btnTongHop_Click(null, null);
                        }
                    }
                }
                else
                {
                   
                    dtMonKy = oBXL_MonHocTrongKy.GetByLop(int.Parse(cmbLop.EditValue.ToString()), Program.IDNamHoc, Program.HocKy);
                    foreach (DataRow drMonKy in dtMonKy.Rows)
                    {
                        if (dtSinhVien != null)
                        {
                            dtSinhVien.Clear();
                            dtSinhVien.Columns.Clear();
                        }
                        dtSinhVien = CreateTable();
                        AddBand();
                        IDDM_MonHoc = int.Parse(drMonKy["DM_MonHocID"].ToString());
                        XuLyTable();
                        TongHop();
                        btnTongHop_Click(null, null);
                    }
                }
            }
        }

        private void TongHop()
        {
            grbTongHop.Visible = true;
            MathParser parser = new MathParser();
            int TongHeSoTemp = 0;
            float TongSoDiem = 0;
            if (dtSinhVien != null && dtThanhPhan != null)
            {
                if (dtSinhVien.Rows.Count > 0 && dtThanhPhan.Rows.Count > 0)
                {
                    for (int i = 0; i < dtSinhVien.Rows.Count; i++)
                    {
                        TongSoDiem = 0;
                        TongHeSoTemp = 0;
                        for (int j = 0; j < grbNhapDiem.Columns.Count; j++)
                        {
                            if (dtSinhVien.Rows[i][grbNhapDiem.Columns[j].FieldName].ToString() != "")
                            {
                                TongHeSoTemp += 1;
                                TongSoDiem += float.Parse("0" + dtSinhVien.Rows[i][grbNhapDiem.Columns[j].FieldName].ToString());
                            }
                        }
                        if (TongHeSoTemp > 0)
                        {
                            dtSinhVien.Rows[i]["DiemTB"] = parser.Round(TongSoDiem / TongHeSoTemp, 1, true);
                            if (parser.Round(TongSoDiem / TongHeSoTemp, 1, true) < 3)
                            {
                                dtSinhVien.Rows[i]["LyDo"] = "Điểm TB thành phần < 3.0";
                            }
                        }
                        else
                            dtSinhVien.Rows[i]["LyDo"] = "Không có điểm thành phần nào";
                    }
                }
            }
        }

        private void cmbMonHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbMonHoc.EditValue != null)
                IDDM_MonHoc = int.Parse(cmbMonHoc.EditValue.ToString());
            else
                IDDM_MonHoc = 0;
            LoadSinhVien();
            LoadSinhVienKhongThi();
        }

        private void grvKhongThi_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void bgvDiem_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(bgvDiem, "Chon", e);
        }

        private void grvKhongThi_KeyDown(object sender, KeyEventArgs e)
        {
            CheckAll(grvKhongThi, "Chon", e);
        }

        private void bgvDiem_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
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
                cmbNganh.Properties.DataSource = LoadNganhByIDKhoa(int.Parse("0" + cmbKhoa.EditValue));
            }
            LoadDanhSachLop();
        }

        private void cmbNganh_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbNganh.EditValue != null)
            {
                pDM_LopInfo.IDDM_Nganh = int.Parse(cmbNganh.EditValue.ToString());
                LoadDanhSachLop();
            }
        }

        private void cmbKhoaHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbKhoaHoc.EditValue != null)
            {
                try
                {
                    pDM_LopInfo.IDDM_TrinhDo = int.Parse("0" + cmbKhoaHoc.GetColumnValue("IDDM_TrinhDo"));
                    LoadDanhSachLop();
                }
                catch
                {
                    pDM_LopInfo.IDDM_TrinhDo = 0;
                    pDM_LopInfo.IDDM_KhoaHoc = 0;
                }
            }
        }

        private void cmbLop_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbLop.EditValue != null)
            {
                pDM_LopInfo.DM_LopID = int.Parse(cmbLop.EditValue.ToString());
            }
        }
        private void cmbKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbKhoa.EditValue = null;
                pDM_LopInfo.IDDM_Khoa = 0;
            }
        }

        private void cmbNganh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbNganh.EditValue = null;
                pDM_LopInfo.IDDM_Nganh = 0;
            }

        }

        private void cmbKhoaHoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbKhoaHoc.EditValue = null;
                pDM_LopInfo.IDDM_KhoaHoc = 0;
            }
        }

        private void cmbLop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                cmbLop.EditValue = null;
                pDM_LopInfo.DM_LopID = 0;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = dtSinhVien.GetChanges();
            if (dtTemp != null)
            {
                for (int i = dtSinhVien.Rows.Count - 1; i >= 0; i--)
                {
                    if ((bool)(dtSinhVien.Rows[i]["Chon"]))
                    {
                        pKQHT_DanhSachKhongThiInfo.IDSV_SinhVien = int.Parse(dtSinhVien.Rows[i]["SV_SinhVienID"].ToString());
                        pKQHT_DanhSachKhongThiInfo.IDDM_MonHoc = int.Parse(cmbMonHoc.EditValue.ToString());
                        pKQHT_DanhSachKhongThiInfo.IDDM_NamHoc = Program.IDNamHoc;
                        pKQHT_DanhSachKhongThiInfo.HocKy = Program.HocKy;
                        pKQHT_DanhSachKhongThiInfo.LyDo = dtSinhVien.Rows[i]["LyDo"].ToString();
                        oBKQHT_DanhSachKhongThi.Add(pKQHT_DanhSachKhongThiInfo);

                        dtSinhVien.Rows.RemoveAt(i);
                    }
                }
                LoadSinhVienKhongThi();
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = dtSinhVienKhongThi.GetChanges();
            if (dtTemp != null)
            {
                if (ThongBaoChon("Bạn có chắc chắn muốn xóa?") == DialogResult.Yes)
                {
                    for (int i = dtSinhVienKhongThi.Rows.Count - 1; i >= 0; i--)
                    {
                        if ((bool)(dtSinhVienKhongThi.Rows[i]["Chon"]))
                        {
                            try
                            {
                                pKQHT_DanhSachKhongThiInfo.KQHT_DanhSachKhongThiID = int.Parse(dtSinhVienKhongThi.Rows[i]["KQHT_DanhSachKhongThiID"].ToString());
                                oBKQHT_DanhSachKhongThi.Delete(pKQHT_DanhSachKhongThiInfo);

                                dtSinhVienKhongThi.Rows.RemoveAt(i);
                            }
                            catch
                            { }
                        }
                    }
                    LoadSinhVien();
                }
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 sinh viên!");
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            if (dtSinhVien != null)
            {
                for (int i = dtSinhVien.Rows.Count - 1; i >= 0; i--)
                {
                    if (float.Parse("0" + dtSinhVien.Rows[i]["DiemTB"].ToString())<3)
                    {
                        pKQHT_DanhSachKhongThiInfo.IDSV_SinhVien = int.Parse(dtSinhVien.Rows[i]["SV_SinhVienID"].ToString());
                        pKQHT_DanhSachKhongThiInfo.IDDM_MonHoc = IDDM_MonHoc;
                        pKQHT_DanhSachKhongThiInfo.IDDM_NamHoc = Program.IDNamHoc;
                        pKQHT_DanhSachKhongThiInfo.HocKy = Program.HocKy;
                        pKQHT_DanhSachKhongThiInfo.LyDo = dtSinhVien.Rows[i]["LyDo"].ToString()!=""?dtSinhVien.Rows[i]["LyDo"].ToString():"Thiếu điểm thành phần";
                        oBKQHT_DanhSachKhongThi.Add(pKQHT_DanhSachKhongThiInfo);

                        dtSinhVien.Rows.RemoveAt(i);
                    }
                }
                if (e != null)
                    LoadSinhVienKhongThi();
                ThongBao("Tổng hợp thành công!");
            }
        }

        private void barbtnTongHop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.Visible = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = false;
        }

        private void btnLocSV_Click(object sender, EventArgs e)
        {
            this.dlg = new WaitDialogForm("Đang tổng hợp dữ liệu", "Tổng hợp dữ liệu. Xin vui lòng chờ.");
            LoadTongHopSinhVien();
            ThongBao("Tổng hợp dữ liệu thành công!");
            this.dlg.Close();
        }
      
    }
}