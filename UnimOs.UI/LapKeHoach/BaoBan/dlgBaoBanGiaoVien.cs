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

namespace UnimOs.UI
{
    public partial class dlgBaoBanGiaoVien : frmBase
    {
        DataTable dtChiTiet, dtBaoBan, dtTuan;
        DataView dtGiaoVien;
        int ColWidth = 75, RowHeight = 30, RowBegin = 2, ColBegin = 4;
        int IDGiaoVien, IDTuTuan, IDDenTuan;
        cBXL_BaoBanGiaoVien oBBaoBanGV;
        XL_BaoBanGiaoVienInfo pBaoBanGVInfo;
        public bool Changed = false;

        public dlgBaoBanGiaoVien(DataView mdtGiaoVien, DataTable mdtChiTiet, ref DataTable mdtBaoBan, DataTable mdtTuan, int mIDGiaoVien, int mIDTuTuan, int mIDDenTuan)
        {
            InitializeComponent();
            dtGiaoVien = mdtGiaoVien;
            dtChiTiet = mdtChiTiet;
            dtBaoBan = mdtBaoBan;
            dtTuan = mdtTuan;
            IDGiaoVien = mIDGiaoVien;
            IDTuTuan = mIDTuTuan;
            IDDenTuan = mIDDenTuan;
            oBBaoBanGV = new cBXL_BaoBanGiaoVien();
            pBaoBanGVInfo = new XL_BaoBanGiaoVienInfo();
        }

        private void dlgBaoBanGiaoVien_Load(object sender, EventArgs e)
        {
            FlexColorSetup(fgChiTiet);
            cmbGiaoVien.Properties.DataSource = dtGiaoVien;
            cmbGiaoVien.EditValue = IDGiaoVien;

            cmbTuTuan.Properties.DataSource = dtTuan.DefaultView;
            cmbTuTuan.EditValue = (long)IDTuTuan;

            cmbDenTuan.Properties.DataSource = dtTuan.DefaultView;
            cmbDenTuan.EditValue = (long)IDDenTuan;

            ShowBaoBanChiTiet(fgChiTiet, dtChiTiet, ColBegin);
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

        private void LuuBaoBan()
        {
            string strFilter = "IDTuan = " + pBaoBanGVInfo.IDTuan.ToString() + " And NS_GiaoVienID = " + pBaoBanGVInfo.IDNS_GiaoVien.ToString()
                + " And Thu = " + pBaoBanGVInfo.Thu.ToString() + " And Tiet = " + pBaoBanGVInfo.Tiet.ToString() + " And CaHoc = " + pBaoBanGVInfo.CaHoc.ToString();
            DataRow[] arrDr = dtBaoBan.Select(strFilter);
            if (arrDr.Length > 0)
            {
                oBBaoBanGV.Update(pBaoBanGVInfo);
            }
            else
            {
                pBaoBanGVInfo.XL_BaoBanGiaoVienID = oBBaoBanGV.Add(pBaoBanGVInfo);
                AddTodtBaoBan();
            }
        }

        private void XoaBaoBan()
        {
            string strFilter = "IDTuan = " + pBaoBanGVInfo.IDTuan.ToString() + " And IDNS_GiaoVien = " + pBaoBanGVInfo.IDNS_GiaoVien.ToString()
                + " And Thu = " + pBaoBanGVInfo.Thu.ToString() + " And Tiet = " + pBaoBanGVInfo.Tiet.ToString() + " And CaHoc = " + pBaoBanGVInfo.CaHoc.ToString();
            DataRow[] arrDr = dtBaoBan.Select(strFilter);
            if (arrDr.Length > 0)
            {
                pBaoBanGVInfo.XL_BaoBanGiaoVienID = int.Parse(arrDr[0]["XL_BaoBanGiaoVienID"].ToString());
                oBBaoBanGV.Delete(pBaoBanGVInfo);
                dtBaoBan.Rows.Remove(arrDr[0]);
            }
        }

        private void AddTodtBaoBan()
        {
            DataRow dr = dtBaoBan.NewRow();
            dr["NS_GiaoVienID"] = pBaoBanGVInfo.IDNS_GiaoVien;
            dr["IDTuan"] = pBaoBanGVInfo.IDTuan;
            dr["XL_BaoBanGiaoVienID"] = pBaoBanGVInfo.XL_BaoBanGiaoVienID;
            dr["Thu"] = pBaoBanGVInfo.Thu;
            dr["Tiet"] = pBaoBanGVInfo.Tiet;
            dr["CaHoc"] = pBaoBanGVInfo.CaHoc;
            dr["MoTa"] = pBaoBanGVInfo.MoTa;
            dtBaoBan.Rows.Add(dr);
        }

        private void GetInfo(int r, int c)
        {
            pBaoBanGVInfo.Thu = int.Parse(fgChiTiet.Rows[2][c].ToString().Remove(0, 1)) - 1;
            pBaoBanGVInfo.Tiet = int.Parse(fgChiTiet.Rows[r]["Tiet"].ToString()) - 1;
            pBaoBanGVInfo.CaHoc = fgChiTiet.Rows[r]["CaHoc"].ToString() == "Sáng" ? 0 : (fgChiTiet.Rows[r]["CaHoc"].ToString() == "Chiều" ? 1 : 2);
            pBaoBanGVInfo.MoTa = txtMoTa.Text;
        }

        private void cmbGiaoVien_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMoTa.Text.Trim() != "")
            {
                Changed = true;
                CellRange rg = fgChiTiet.Selection;
                pBaoBanGVInfo.IDNS_GiaoVien = int.Parse(cmbGiaoVien.EditValue.ToString());
                int r1 = rg.TopRow, c1 = rg.LeftCol;
                if (r1 < RowBegin)
                    r1 = RowBegin;
                if (c1 < ColBegin)
                    c1 = ColBegin;
                for (int t = int.Parse(cmbTuTuan.EditValue.ToString()); t <= int.Parse(cmbDenTuan.EditValue.ToString()); t++)
                {
                    pBaoBanGVInfo.IDTuan = t;
                    for (int r = r1; r <= rg.BottomRow; r++)
                    {
                        for (int c = c1; c <= rg.RightCol; c++)
                        {
                            GetInfo(r, c);
                            LuuBaoBan();
                            fgChiTiet[r, c] = txtMoTa.Text;
                            fgChiTiet.SetCellStyle(r, c, fgChiTiet.Styles["MyCellStyleBaoBan"]);
                        }
                    }
                }
            }
            else
            {
                ThongBao("Bạn cần mô tả kế hoạch nghỉ");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            CellRange rg = fgChiTiet.Selection;
            pBaoBanGVInfo.IDNS_GiaoVien = int.Parse(cmbGiaoVien.EditValue.ToString());

            int r1 = rg.TopRow, c1 = rg.LeftCol;
            if (rg.TopRow < 2)
                r1 = 2;
            if (rg.LeftCol < 4)
                c1 = 4;
            for (int t = int.Parse(cmbTuTuan.EditValue.ToString()); t <= int.Parse(cmbDenTuan.EditValue.ToString()); t++)
            {
                Changed = true;
                pBaoBanGVInfo.IDTuan = t;
                for (int r = r1; r <= rg.BottomRow; r++)
                {
                    for (int c = c1; c <= rg.RightCol; c++)
                    {
                        GetInfo(r, c);
                        XoaBaoBan();
                        fgChiTiet[r, c] = "";
                        fgChiTiet.SetCellStyle(r, c, (CellStyle)null);
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fgChiTiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnXoa_Click(null, null);
            }
        }
    }
}