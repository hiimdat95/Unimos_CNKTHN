using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using C1.Win.C1FlexGrid;
using TruongViet.UnimOs.Business;
using TruongViet.UnimOs.Entity;
using Lib;

namespace UnimOs.UI 
{
    public partial class frmTietNghiCoDinhLop : frmBase
    {
        private cBXL_TietNghiCoDinhLop oBXL_TietNghiCoDinhLop;
        private XL_TietNghiCoDinhLopInfo pXL_TietNghiCoDinhLopInfo;
        private cBDM_Lop oBDM_Lop;
        private DM_LopInfo pDM_LopInfo;
        private DataTable dtLop, dtChiTiet, dtTietNghi;
        private string[] arrIDDM_Lop;
        private string TenLops = "";
        int ColWidth = 75, RowHeight = 30, RowBegin = 2, ColBegin = 4;
        public frmTietNghiCoDinhLop()
        {
            InitializeComponent();
            oBDM_Lop = new cBDM_Lop();
            pDM_LopInfo = new DM_LopInfo();
            pXL_TietNghiCoDinhLopInfo = new XL_TietNghiCoDinhLopInfo();
            oBXL_TietNghiCoDinhLop = new cBXL_TietNghiCoDinhLop();
        }

        private void frmTietNghiCoDinhLop_Load(object sender, EventArgs e)
        {
            dtLop = oBDM_Lop.GetTree(Program.NamHoc);
            grdDSLop.DataSource = dtLop;
            dtLop.AcceptChanges();
            if (fgChiTiet != null)
                FlexColorSetup(fgChiTiet);
            dtTietNghi = oBXL_TietNghiCoDinhLop.Get(pXL_TietNghiCoDinhLopInfo);
           
        }

     
        protected DataTable _CreateTableChiTiet()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CaHoc", typeof(string));
            dt.Columns.Add("Tiet", typeof(string));
            for (int i = Program.pgrThamSo.THU_BAT_DAU; i <= Program.pgrThamSo.THU_KET_THUC; i++)
            {
                dt.Columns.Add("T" + i.ToString(), typeof(string));
            }
            DataRow dr = dt.NewRow();
            dr["CaHoc"] = "Buổi học";
            dr["Tiet"] = "Tiết";
            clsStringHelper cls = new clsStringHelper();
            for (int i = Program.pgrThamSo.THU_BAT_DAU; i <= Program.pgrThamSo.THU_KET_THUC; i++)
            {
                dr["T" + i.ToString()] = cls.TenThu()[i];
            }
            dt.Rows.Add(dr);

            for (int i = 0; i < Program.pgrThamSo.SO_TIET_CASANG; i++)
            {
                dr = dt.NewRow();
                dr["CaHoc"] = "Sáng";
                dr["Tiet"] = (i + 1).ToString();
                dt.Rows.Add(dr);
            }
            for (int i = 0; i < Program.pgrThamSo.SO_TIET_CACHIEU; i++)
            {
                dr = dt.NewRow();
                dr["CaHoc"] = "Chiều";
                dr["Tiet"] = (i + 1).ToString();
                dt.Rows.Add(dr);
            }
            for (int i = 0; i < Program.pgrThamSo.SO_TIET_CATOI; i++)
            {
                dr = dt.NewRow();
                dr["CaHoc"] = "Tối";
                dr["Tiet"] = (i + 1).ToString();
                dt.Rows.Add(dr);
            }
            return dt;
        }

        protected void _ShowBaoBanChiTiet(C1FlexGrid fgChiTiet, DataTable dt, int ColBegin)
        {
            fgChiTiet.DataSource = dt;
            fgChiTiet.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.FixedOnly;
            // Gán cột fix
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                fgChiTiet[fgChiTiet.Rows.Fixed + i, 0] = dt.Rows[i]["CaHoc"].ToString();
                fgChiTiet[fgChiTiet.Rows.Fixed + i, 1] = dt.Rows[i]["Tiet"].ToString();
            }
            // Gán row fix
            fgChiTiet[0, 0] = dt.Rows[0]["CaHoc"].ToString();
            fgChiTiet[0, 1] = dt.Rows[0]["Tiet"].ToString();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                fgChiTiet[0, fgChiTiet.Cols.Fixed + i] = dt.Rows[0][i].ToString();
            }

            fgChiTiet.Cols[0].Width = 55;
            fgChiTiet.Cols[1].Width = 25;
            fgChiTiet.Cols[0].AllowMerging = true;
            fgChiTiet.Cols[1].AllowMerging = true;
            fgChiTiet.Cols["CaHoc"].Visible = false;
            fgChiTiet.Cols["Tiet"].Visible = false;
            fgChiTiet.Rows[1].Visible = false;

            SetStyles(fgChiTiet, ColBegin);
            for (int i = fgChiTiet.Cols.Fixed; i < fgChiTiet.Cols.Count; i++)
            {
                fgChiTiet.Cols[i].Width = ColWidth;
            }
            for (int i = fgChiTiet.Rows.Fixed; i < fgChiTiet.Rows.Count; i++)
            {
                fgChiTiet.Rows[i].Height = RowHeight;
            }
            SetStyles(fgChiTiet, ColBegin);
        }

        private void grdDSLop_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ModifierKeys == Keys.None )
            {
                popupTietNghi.ShowPopup(MousePosition);
            }
        }

       private void barbtnTietNghi_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                    
            DataRow[] arrdr = dtLop.Select("Chon = True");
            if (arrdr.Length >0 || grvDSLop.FocusedRowHandle >=0)
            {
                TenLops = "";
                int i=0;
                arrIDDM_Lop = new string[arrdr.Length];
                foreach (DataRow dr in arrdr)
                {
                    if ((bool)(dr["Chon"]))
                    {
                        arrIDDM_Lop[i] = dr["DM_LopID"].ToString();
                        TenLops += dr["TenLop"].ToString() + ",";
                        i += 1;

                    }
                }
            }
            else
                ThongBao("Bạn phải chọn ít nhất 1 lớp!");
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtThongTin.Text.Trim() != "")
            {
                CellRange rg = fgChiTiet.Selection;
                int r1 = rg.TopRow, c1 = rg.LeftCol;
                if (r1 < RowBegin)
                    r1 = RowBegin;
                if (c1 < ColBegin)
                    c1 = ColBegin;
                for (int i = 0; i < arrIDDM_Lop.Length; i++)
                {
                    pXL_TietNghiCoDinhLopInfo.IDDM_Lop = int.Parse(arrIDDM_Lop[i]);
                    for (int r = r1; r <= rg.BottomRow; r++)
                    {
                        for (int c = c1; c <= rg.RightCol; c++)
                        {
                            GetInfo(r, c);
                            CapNhatTietNghiLop();
                            fgChiTiet[r, c] = txtThongTin.Text;
                            fgChiTiet.SetCellStyle(r, c, fgChiTiet.Styles["MyCellStyleBaoBan"]);
                        }
                    }
                }
                // Ghi Log
                        GhiLog("Cập nhật tiết nghỉ cho các lớp '" + TenLops + "'", "Cập nhật", this.Tag.ToString());
            }
            else
            {
                ThongBao("Bạn cần mô tả kế hoạch nghỉ");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ThongBaoChon("Bạn có chắc chắn muốn xóa?") == DialogResult.Yes)
            {
                CellRange rg = fgChiTiet.Selection;
                int r1 = rg.TopRow, c1 = rg.LeftCol;
                if (rg.TopRow < 2)
                    r1 = 2;
                if (rg.LeftCol < 4)
                    c1 = 4;
                for (int i = 0; i < arrIDDM_Lop.Length; i++)
                {
                    pXL_TietNghiCoDinhLopInfo.IDDM_Lop = int.Parse(arrIDDM_Lop[i]);
                    for (int r = r1; r <= rg.BottomRow; r++)
                    {
                        for (int c = c1; c <= rg.RightCol; c++)
                        {
                            GetInfo(r, c);
                            XoaTietNghi();
                            fgChiTiet[r, c] = "";
                            fgChiTiet.SetCellStyle(r, c, (CellStyle)null);
                        }
                    }
                }
                // Ghi Log
                GhiLog("Xóa tiết thông tin tiết nghỉ '" + txtThongTin.Text +  "' cho các lớp '" + TenLops + "'", "Xóa", this.Tag.ToString());
            }
        }
        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            txtThongTin.Text = "";

        }

        private void GetInfo(int r, int c)
        {
           pXL_TietNghiCoDinhLopInfo.Thu = int.Parse(fgChiTiet.Rows[1][c].ToString().Remove(0, 1)) - 1;
           pXL_TietNghiCoDinhLopInfo.Tiet = int.Parse(fgChiTiet.Rows[r]["Tiet"].ToString()) - 1;
           pXL_TietNghiCoDinhLopInfo.Nghi = true;
           pXL_TietNghiCoDinhLopInfo.MoTa = txtThongTin.Text;
           pXL_TietNghiCoDinhLopInfo.CaHoc = fgChiTiet.Rows[r]["CaHoc"].ToString() == "Sáng" ? 0 : (fgChiTiet.Rows[r]["CaHoc"].ToString() == "Chiều" ? 1 : 2);
        }
        private void CapNhatTietNghiLop()
        {
            string strFilter = " IDDM_Lop = " + pXL_TietNghiCoDinhLopInfo.IDDM_Lop.ToString()
                + " And Thu = " + pXL_TietNghiCoDinhLopInfo.Thu.ToString() + " And Tiet = " + pXL_TietNghiCoDinhLopInfo.Tiet.ToString();
            DataRow[] arrDr = dtTietNghi.Select(strFilter);
            DataRow drNew = dtTietNghi.NewRow();
            if (arrDr.Length > 0)
            {
                pXL_TietNghiCoDinhLopInfo.XL_TietNghiCoDinhLopID = int.Parse(arrDr[0]["XL_TietNghiCoDinhLopID"].ToString());
                oBXL_TietNghiCoDinhLop.Update(pXL_TietNghiCoDinhLopInfo);
                oBXL_TietNghiCoDinhLop.ToDataRow(pXL_TietNghiCoDinhLopInfo, ref drNew);
                dtTietNghi.Rows.Remove(arrDr[0]);
                dtTietNghi.Rows.Add(drNew);
            }
            else
            {
                pXL_TietNghiCoDinhLopInfo.XL_TietNghiCoDinhLopID = oBXL_TietNghiCoDinhLop.Add(pXL_TietNghiCoDinhLopInfo);
                oBXL_TietNghiCoDinhLop.ToDataRow(pXL_TietNghiCoDinhLopInfo, ref drNew);
                dtTietNghi.Rows.Add(drNew);
            }
        }
      
        private void ShowButton(bool mStatus)
        {
            btnCapNhat.Enabled = mStatus;
            btnXoa.Enabled = mStatus;           
        }
        private void grvDSLop_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvDSLop.FocusedRowHandle >= 0)
            {
                string IDDM_Lop = grvDSLop.GetDataRow(grvDSLop.FocusedRowHandle)["DM_LopID"].ToString();
                TenLops = grvDSLop.GetDataRow(grvDSLop.FocusedRowHandle)["DM_LopID"].ToString();
                arrIDDM_Lop = new string[1];
                arrIDDM_Lop[0] = IDDM_Lop;
                ShowButton(true);
                dtChiTiet = _CreateTableChiTiet();
                if (dtTietNghi == null)
                {
                    _ShowBaoBanChiTiet(fgChiTiet, dtChiTiet, ColBegin);
                }
                else
                {
                    DataTable dtCopy = dtTietNghi.Copy();
                    dtCopy.DefaultView.RowFilter = "IDDM_Lop = " + IDDM_Lop;
                    try
                    {
                        foreach (DataRowView dr in dtCopy.DefaultView)
                        {
                            if ((CA_HOC)dr["CaHoc"] == CA_HOC.CA_SANG)
                            {
                                dtChiTiet.Rows[int.Parse(dr["Tiet"].ToString()) + 1]["T" + dr["Thu"].ToString()] = dr["MoTa"].ToString();
                            }
                            else if ((CA_HOC)dr["CaHoc"] == CA_HOC.CA_CHIEU)
                            {
                                dtChiTiet.Rows[int.Parse(dr["Tiet"].ToString()) + 1 + Program.pgrThamSo.SO_TIET_CASANG]["T" + dr["Thu"].ToString()] = dr["MoTa"].ToString();
                            }
                            else if ((CA_HOC)dr["CaHoc"] == CA_HOC.CA_TOI)
                            {
                                dtChiTiet.Rows[int.Parse(dr["Tiet"].ToString()) + 1 + Program.pgrThamSo.SO_TIET_CASANG + Program.pgrThamSo.SO_TIET_CACHIEU]["T" + dr["Thu"].ToString()] = dr["MoTa"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }
                    _ShowBaoBanChiTiet(fgChiTiet, dtChiTiet, 4);
                }
            }
            else
            {
                ShowButton(false);
                
            }
        }
        private void XoaTietNghi()
        {
            string strFilter = " IDDM_Lop = " + pXL_TietNghiCoDinhLopInfo.IDDM_Lop.ToString()
                + " And Thu = " + pXL_TietNghiCoDinhLopInfo.Thu.ToString() + " And Tiet = " + pXL_TietNghiCoDinhLopInfo.Tiet.ToString();
            DataRow[] arrDr = dtTietNghi.Select(strFilter);
            if (arrDr.Length > 0)
            {
                pXL_TietNghiCoDinhLopInfo.XL_TietNghiCoDinhLopID = int.Parse(arrDr[0]["XL_TietNghiCoDinhLopID"].ToString());
                oBXL_TietNghiCoDinhLop.Delete(pXL_TietNghiCoDinhLopInfo);
                dtTietNghi.Rows.Remove(arrDr[0]);
            }
        }

        private void fgChiTiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (grvDSLop.FocusedRowHandle >= 0)
                {
                    btnXoa_Click(null, null);
                }
            }
        }
    }
}