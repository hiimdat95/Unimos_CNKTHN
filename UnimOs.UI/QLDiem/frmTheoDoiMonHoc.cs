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

namespace UnimOs.UI
{
    public partial class frmTheoDoiMonHoc : frmBase
    {
        private cBDM_Lop oBDM_Lop;
        private DataTable dtMonKy, dtSinhVien;
        private cBXL_MonHocTrongKy oBXL_MonHocTrongKy;
        private KQHT_DiemDanhInfo pKQHT_DiemDanhInfo;
        private cBKQHT_DiemDanh oBKQHT_DiemDanh;
        private KQHT_DiemDanh_ChiTietInfo pKQHT_DiemDanh_ChiTietInfo;
        private cBKQHT_DiemDanh_ChiTiet oBKQHT_DiemDanh_ChiTiet;
        private int IDDM_Lop = 0;
        private DataRow drSinhVien;

        public frmTheoDoiMonHoc()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            oBXL_MonHocTrongKy = new cBXL_MonHocTrongKy();
            oBKQHT_DiemDanh = new cBKQHT_DiemDanh();
            pKQHT_DiemDanhInfo = new KQHT_DiemDanhInfo();
            oBKQHT_DiemDanh_ChiTiet = new cBKQHT_DiemDanh_ChiTiet();
            pKQHT_DiemDanh_ChiTietInfo = new KQHT_DiemDanh_ChiTietInfo();
        }

        private void frmTheoDoiMonHoc_Load(object sender, EventArgs e)
        {
            LoadTreeLop(uctrlLop);
            uctrlLop.trlLop.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(trlLop_FocusedNodeChanged);
            dtSinhVien = CreateTable();
            AddBand();
        }

        void trlLop_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            DM_LopInfo pDM_LopInfo = uctrlLop.GetNodeSelected();
            if (pDM_LopInfo != null)
            {
                IDDM_Lop = pDM_LopInfo.DM_LopID;
                LoadMonKy(IDDM_Lop);
            }
            else
            {
                btnCapNhat.Enabled = false;
                if (dtSinhVien != null)
                    dtSinhVien.Clear();
            }
        }

        private void cmbMonHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbMonHoc.EditValue != null)
            {
                LoadSinhVien();                
            }
            else
                btnCapNhat.Enabled = false;
        }
        private void LoadMonKy(int IDDM_Lop)
        {
            dtMonKy = oBXL_MonHocTrongKy.GetByLop(IDDM_Lop, Program.IDNamHoc, Program.HocKy);
            if (dtMonKy != null)
                cmbMonHoc.Properties.DataSource = dtMonKy;
            cmbMonHoc.EditValue = null;
            dtSinhVien.Clear();
        }
        private void LoadSinhVien()
        {
            XuLyTable();
            grdDiemDanh.DataSource = dtSinhVien;
            dtSinhVien.AcceptChanges();
            btnCapNhat.Enabled = true;
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
                        try
                        {
                            // update vao bang KQHT_DiemDanh
                            int KQHT_DiemDanhID = 0;
                            pKQHT_DiemDanhInfo.IDSV_SinhVien = int.Parse(dr["SV_SinhVienID"].ToString());
                            pKQHT_DiemDanhInfo.IDXL_MonHocTrongKy = int.Parse(cmbMonHoc.EditValue.ToString());
                            //pKQHT_DiemDanhInfo.TongTiet = int.Parse(dr["TongTiet"].ToString());
                            KQHT_DiemDanhID = oBKQHT_DiemDanh.Add(pKQHT_DiemDanhInfo);
                            // cap nhat chi tiet
                            for (int i = 0; i < grbTuan.Columns.Count; i++)
                            {
                                if ("" + dr[grbTuan.Columns[i].FieldName] != "")
                                {
                                    pKQHT_DiemDanh_ChiTietInfo.IDKQHT_DiemDanh = KQHT_DiemDanhID;
                                    pKQHT_DiemDanh_ChiTietInfo.IDXL_Tuan = int.Parse(grbTuan.Columns[i].FieldName);
                                    pKQHT_DiemDanh_ChiTietInfo.LyDo = "";
                                    pKQHT_DiemDanh_ChiTietInfo.SoTiet = int.Parse(dr[grbTuan.Columns[i].FieldName].ToString());
                                    oBKQHT_DiemDanh_ChiTiet.Add(pKQHT_DiemDanh_ChiTietInfo);
                                }
                            }
                        }
                        catch
                        {
                            // error
                        }
                    }
                }
                ThongBao("Cập nhật thành công!");
            }
            else
                ThongBao("Bạn cần thay đổi thông tin trước khi cập nhật!");
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SV_SinhVienID", typeof(int));
            dt.Columns.Add("MaSinhVien", typeof(string));
            dt.Columns.Add("HoVaTen", typeof(string));
            dt.Columns.Add("TongTiet", typeof(int));
            return dt;
        }
        private void AddBand()
        {
            BandedGridColumn bgc;
            DataRow[] drTuan = LoadTuan().Select("HocKy=" + Program.HocKy.ToString());

            foreach (DataRow dr in drTuan)
            {
                dtSinhVien.Columns.Add(dr["XL_TuanID"].ToString(), typeof(int));

                bgc = new BandedGridColumn();
                grbTuan.Columns.Add(bgc);

                SetColumnBandCaption(bgc,  dr["TuanThu"].ToString(),dr["XL_TuanID"].ToString(), 40, DevExpress.Utils.HorzAlignment.Default, false);
                bgc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                bgc.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                bgvDiemDanh.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { bgc });
            }           
        }
        private void XuLyTable()
        {
            if (dtSinhVien != null)
                dtSinhVien.Clear();
            DataTable dt = oBKQHT_DiemDanh.GetDanhSach(IDDM_Lop, int.Parse(cmbMonHoc.EditValue.ToString()), Program.IDNamHoc, Program.HocKy);
            DataRow drNew;
            if (dt.Rows.Count > 0)
            {
                string SV_SinhVienID = dt.Rows[0]["SV_SinhVienID"].ToString();
                drNew = dtSinhVien.NewRow();
                drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                drNew["MaSinhVien"] = dt.Rows[0]["MaSinhVien"].ToString();
                drNew["HoVaTen"] = dt.Rows[0]["HoVaTen"].ToString();
                drNew["TongTiet"] = dt.Rows[0]["TongTiet"];

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["SV_SinhVienID"].ToString() != SV_SinhVienID)
                    {
                        dtSinhVien.Rows.Add(drNew);

                        SV_SinhVienID = dr["SV_SinhVienID"].ToString();
                        drNew = dtSinhVien.NewRow();
                        drNew["TongTiet"] = dr["TongTiet"];
                        drNew["SV_SinhVienID"] = int.Parse(SV_SinhVienID);
                        drNew["MaSinhVien"] = dr["MaSinhVien"].ToString();
                        drNew["HoVaTen"] = dr["HoVaTen"].ToString();

                        drNew[dr["XL_TuanID"].ToString()] = dr["TongTiet"];
                    }
                    else
                    {
                        drNew[dr["XL_TuanID"].ToString()] = dr["TongTiet"];
                    }
                }
                dtSinhVien.Rows.Add(drNew);
                dtSinhVien.AcceptChanges();
            }
        }

        private void bgvDiemDanh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >=0)
            {
                drSinhVien = bgvDiemDanh.GetDataRow(e.FocusedRowHandle);
            }
        }

        private void bgvDiemDanh_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            drSinhVien["TongTiet"] = TinhTongTiet(drSinhVien);
        }
        private int TinhTongTiet( DataRow mdrSinhVien)
        {
            int Tong = 0;
            for (int i = 0; i < grbTuan.Columns.Count; i++)
            {
               Tong += int.Parse("0"  + drSinhVien[grbTuan.Columns[i].FieldName]);
            }
            return Tong;
        }

        private void bgvDiemDanh_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            ShowIndicator(e);
        }
    }
}