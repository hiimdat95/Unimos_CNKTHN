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
using Lib;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace UnimOs.UI 
{
    public partial class frmNhapDiemTheoSoBDVaPhach : frmBase
    {
        private cBXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private cBKQHT_ToChucThi oBKQHT_ToChucThi;
        private cBKQHT_CongThucDiem oBKQHT_CongThucDiem;
        private cBKQHT_DiemThi oBKQHT_DiemThi;
        private KQHT_DiemThiInfo pKQHT_DiemThiInfo;
        private KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo;
        private cBKQHT_DiemTongKetMon oBKQHT_DiemTongKetMon;
        private clsDataTableHelper cls;
        private int IDDM_MonHoc, KQHT_ToChucThiID;
        private bool TotNghiep = false;
        private DataTable dtMonKy, dtDotThi, dtDanhSachDuThi, dtThanhPhan,dtSinhVien,dtData;

        public frmNhapDiemTheoSoBDVaPhach()
        {
            InitializeComponent();
            oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
            oBKQHT_ToChucThi = new cBKQHT_ToChucThi();
            oBKQHT_CongThucDiem = new cBKQHT_CongThucDiem();
            pKQHT_DiemThiInfo = new KQHT_DiemThiInfo();
            oBKQHT_DiemThi = new cBKQHT_DiemThi();
            oBKQHT_DiemTongKetMon = new cBKQHT_DiemTongKetMon();
            pKQHT_DiemTongKetMonInfo = new KQHT_DiemTongKetMonInfo();
            cls = new clsDataTableHelper();
        }

        private void frmNhapDiemTheoSBDVaSP_Load(object sender, EventArgs e)
        {
            dtMonKy = oBXL_MonHocTrongKy.GetToChucThi(Program.IDNamHoc, Program.HocKy);
            grdMonThi.DataSource = dtMonKy;
        }

        private void bgvSinhVien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }

        private void grvMonThi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvMonThi.DataRowCount > 0 && grvMonThi.FocusedRowHandle >= 0)
            {
                IDDM_MonHoc = int.Parse(grvMonThi.GetDataRow(grvMonThi.FocusedRowHandle)["DM_MonHocID"].ToString());
                //TenMonHoc = grvMonThi.GetDataRow(grvMonThi.FocusedRowHandle)["TenMonHoc"].ToString();
                LoadDanhSachDotThi();
                grvDotThi_FocusedRowChanged(null, null);
            }
            else
            {
                grdDotThi.DataSource = null;
                grdSinhVien.DataSource = null;
            }
        }
        private void LoadDanhSachDotThi()
        {
            dtDanhSachDuThi = oBKQHT_ToChucThi.GetByMonHoc(IDDM_MonHoc, Program.IDNamHoc, Program.HocKy);
            if (dtDanhSachDuThi.Rows.Count > 0)
            {
                DataTable dt = cls.SelectDistinct(dtDanhSachDuThi, new string[] { "KQHT_ToChucThiID", "LanThi", "DotThi", "NgayThi", 
                "CaThi", "TenLop","IDDM_Lops","IDDM_Lop","TotNghiep"});
                dtDotThi = dt.Clone();
                string strKQHT_ToChucThiID = "";
           
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["KQHT_ToChucThiID"].ToString() != strKQHT_ToChucThiID)
                    {
                        dtDotThi.ImportRow(dr);
                    }
                    else
                    {
                        dtDotThi.Rows[dtDotThi.Rows.Count - 1]["TenLop"] = dtDotThi.Rows[dtDotThi.Rows.Count - 1]["TenLop"] + ", " + dr["TenLop"];
                        dtDotThi.Rows[dtDotThi.Rows.Count - 1]["IDDM_Lops"] = dtDotThi.Rows[dtDotThi.Rows.Count - 1]["IDDM_Lops"] + ", " + dr["IDDM_Lop"];
                    }
                    strKQHT_ToChucThiID = dr["KQHT_ToChucThiID"].ToString();
                }
                dtDotThi.AcceptChanges();
                grdDotThi.DataSource = dtDotThi;
            }
            else
                grdDotThi.DataSource = null;
        }

        private void grvDotThi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            if (grvDotThi.DataRowCount > 0 && grvDotThi.FocusedRowHandle >= 0)
            {
                KQHT_ToChucThiID = int.Parse(grvDotThi.GetDataRow(grvDotThi.FocusedRowHandle)["KQHT_ToChucThiID"].ToString());
                TotNghiep = bool.Parse(grvDotThi.GetDataRow(grvDotThi.FocusedRowHandle)["TotNghiep"].ToString());
                dtData = oBKQHT_DiemThi.GetSinhVien(KQHT_ToChucThiID);
                // get diem thi
                dtSinhVien = CreateTable();

                XuLyTable();
                grdSinhVien.DataSource = dtSinhVien;
                if (rdNhapDiem.SelectedIndex== 0)
                    GetPhongThi();
                else
                    GetTuiThi();

            }
            else
            {
                grdSinhVien.DataSource = null;
                cmbTuiThi.Properties.DataSource = null;
                cmbPhongThi.Properties.DataSource = null;
            }
        }
        // lay phong thi theo dot thi
        private void GetPhongThi()
        {
            // get phong thi theo dot thi
            DataTable dtPhongThi = oBKQHT_ToChucThi.GetPhongThi(KQHT_ToChucThiID);
            cmbPhongThi.Properties.DataSource = dtPhongThi;
            if (dtPhongThi.Rows.Count > 0)
            {
                cmbPhongThi.ItemIndex = 0;
                cmbPhongThi_EditValueChanged(null, null);
            }
        }
        // lay tui thi khi chon nhap diem theo so phach
        private void GetTuiThi()
        {
            // get tui thi
            Lib.clsDataTableHelper cls = new Lib.clsDataTableHelper();

            DataTable dtTuiThi = cls.SelectDistinct(dtData, new string[] { "TuiThiSo" });
            cmbTuiThi.Properties.DataSource = dtTuiThi;
            if (dtTuiThi.Rows.Count > 0)
            {
                cmbTuiThi.ItemIndex = 0;
                cmbTuiThi_EditValueChanged(null, null);
            }
        }
     
        private void rdNhapDiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdNhapDiem.EditValue.ToString() == "0")
            {
                GetPhongThi();
                colSBD.Visible = true;
                colSoPhach.Visible = false;
                cmbPhongThi.Enabled = true;
                cmbTuiThi.Enabled = false;
            }
            else
            {
                GetTuiThi();
                colSBD.Visible = false;
                colSoPhach.Visible = true;
                cmbPhongThi.Enabled = false;
                cmbTuiThi.Enabled = true;
            }
        }
        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SV_SinhVienID", typeof(int));
            dt.Columns.Add("SoBaoDanh", typeof(string));
            dt.Columns.Add("SoPhach", typeof(string));
            dt.Columns.Add("IDDM_PhongHoc", typeof(int));
            dt.Columns.Add("TuiThiSo", typeof(int));
            dt.Columns.Add("Diem", typeof(float));
            dt.Columns.Add("XL_MonHocTrongKyID", typeof(int));
            return dt;
        }
        private void AddBand(string IDDM_Lops)
        {
            BandedGridColumn bgc;
            if (IDDM_Lops.IndexOf(",") == 0)
                IDDM_Lops = IDDM_Lops.Substring(1, IDDM_Lops.Length-1);
            if (IDDM_Lops.IndexOf(",") == IDDM_Lops.Length - 1)
                IDDM_Lops = IDDM_Lops.Substring(0, IDDM_Lops.Length - 1);

            dtThanhPhan = oBKQHT_CongThucDiem.GetDiemThi(IDDM_Lops, Program.IDNamHoc, Program.HocKy, IDDM_MonHoc);
            grbThi.Columns.Clear();
            if ((dtThanhPhan != null) && (dtThanhPhan.Rows.Count > 0))
            {
                foreach (DataRow dr in dtThanhPhan.Rows)
                {
                    dtSinhVien.Columns.Add(dr["KQHT_ThanhPhanDiemID"].ToString(), typeof(float));

                    bgc = new BandedGridColumn();
                    grbThi.Columns.Add(bgc);

                    SetColumnBandCaption(bgc, dr["KyHieu"].ToString(), dr["KQHT_ThanhPhanDiemID"].ToString(), 80, DevExpress.Utils.HorzAlignment.Default, false);
                    bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    bgc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                    bgvSinhVien.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });
                }
            }
        }
        private void XuLyTable()
        {
           // if (dtThanhPhan.Rows.Count > 0)
           // {
                DataRow drNew;
                if (dtData.Rows.Count > 0)
                {
                    string SV_SinhVienID = dtData.Rows[0]["IDSV_SinhVien"].ToString();
                    drNew = dtSinhVien.NewRow();
                    drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                    drNew["SoBaoDanh"] = dtData.Rows[0]["SoBaoDanh"].ToString();
                    drNew["SoPhach"] = dtData.Rows[0]["SoPhach"].ToString();
                    drNew["IDDM_PhongHoc"] = dtData.Rows[0]["IDDM_PhongHoc"].ToString();
                    drNew["TuiThiSo"] = dtData.Rows[0]["TuiThiSo"].ToString();
                    drNew["XL_MonHocTrongKyID"] = dtData.Rows[0]["XL_MonHocTrongKyID"];

                    foreach (DataRow dr in dtData.Rows)
                    {
                        if (dr["IDSV_SinhVien"].ToString() != SV_SinhVienID)
                        {
                            dtSinhVien.Rows.Add(drNew);

                            SV_SinhVienID = dr["IDSV_SinhVien"].ToString();
                            drNew = dtSinhVien.NewRow();

                            drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                            drNew["SoBaoDanh"] = dr["SoBaoDanh"].ToString();
                            drNew["SoPhach"] = dr["SoPhach"].ToString();
                            drNew["IDDM_PhongHoc"] = dr["IDDM_PhongHoc"];
                            drNew["TuiThiSo"] = dr["TuiThiSo"];
                            drNew["XL_MonHocTrongKyID"] = dr["XL_MonHocTrongKyID"];


                           //drNew[dr["KQHT_ThanhPhanDiemID"].ToString()] = dr["Diem"];                           
                            drNew["Diem"] = dr["Diem"];                           
                        }
                        else
                        {
                            drNew["Diem"] = dr["Diem"];
                           
                        }
                    }
                    dtSinhVien.Rows.Add(drNew);
                }
           // }
        }

        private void cmbPhongThi_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbPhongThi.EditValue != null)
            {
                DataView dv = new DataView(dtSinhVien);
                dv.RowFilter = "IDDM_PhongHoc =" + cmbPhongThi.EditValue.ToString();
                grdSinhVien.DataSource = dv;
            }
        }

        private void cmbPhongThi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cmbPhongThi.EditValue = null;
        }

        private void cmbTuiThi_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbTuiThi.EditValue != null)
            {
                DataView dv = new DataView(dtSinhVien);
                dv.RowFilter = "TuiThiSo =" + cmbTuiThi.EditValue.ToString();
                grdSinhVien.DataSource = dv;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = dtSinhVien.GetChanges();
            if (dtTemp != null)
            {
                foreach (DataRow dr in dtTemp.Rows)
                {
                    // update vao bang KQHT_ThanhPhanDiem                          
                    for (int i = 0; i < grbThi.Columns.Count; i++)
                    {

                        if ("" + dr[grbThi.Columns[i].FieldName] != "")
                        {
                            try
                            {
                               
                                pKQHT_DiemThiInfo.Diem = float.Parse(dr[grbThi.Columns[i].FieldName].ToString());
                                pKQHT_DiemThiInfo.HocKy = Program.HocKy;
                                pKQHT_DiemThiInfo.IDDM_NamHoc = Program.IDNamHoc;
                                pKQHT_DiemThiInfo.IDDM_MonHoc = int.Parse(grvMonThi.GetDataRow(grvMonThi.FocusedRowHandle)["DM_MonHocID"].ToString());
                                pKQHT_DiemThiInfo.IDHT_User = Program.objUserCurrent.HT_UserID;
                                pKQHT_DiemThiInfo.LyDo = "";
                                pKQHT_DiemThiInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                                pKQHT_DiemThiInfo.NgayTao = DateTime.Now;
                                pKQHT_DiemThiInfo.LanThi = int.Parse(grvDotThi.GetDataRow(grvDotThi.FocusedRowHandle)["LanThi"].ToString());
                                pKQHT_DiemThiInfo.IDXL_MonHocTrongKy =(TotNghiep==true?0: int.Parse(dr["XL_MonHocTrongKyID"].ToString())); 
                                oBKQHT_DiemThi.Add(pKQHT_DiemThiInfo);
                                // neu la mon tot nghiep add luon vao bang TongKetMon
                                if (TotNghiep == true )
                                {
                                    pKQHT_DiemTongKetMonInfo.Diem = float.Parse(dr[grbThi.Columns[i].FieldName].ToString());
                                    pKQHT_DiemTongKetMonInfo.HocKy = Program.HocKy;
                                    pKQHT_DiemTongKetMonInfo.IDDM_NamHoc = Program.IDNamHoc;
                                    pKQHT_DiemTongKetMonInfo.IDDM_MonHoc = int.Parse(grvMonThi.GetDataRow(grvMonThi.FocusedRowHandle)["DM_MonHocID"].ToString());
                                    pKQHT_DiemTongKetMonInfo.LyDo = "";
                                    pKQHT_DiemTongKetMonInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                                    pKQHT_DiemTongKetMonInfo.LanThi = int.Parse(grvDotThi.GetDataRow(grvDotThi.FocusedRowHandle)["LanThi"].ToString());
                                    oBKQHT_DiemTongKetMon.Add(pKQHT_DiemTongKetMonInfo);
                                }
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

        private void bgvSinhVien_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            //float ID;
            //if (float.TryParse(bgvSinhVien.FocusedColumn.FieldName, out ID))
           // {
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
           // }
        }
    }
}