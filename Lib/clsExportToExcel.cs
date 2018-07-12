using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;
using System.Collections;
using System.Drawing;
using C1.C1Excel;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace Lib
{
    public class clsExportToExcel
    {
        Excel.Application oXL = null;
        Excel._Workbook oWB = null;
        Excel._Worksheet oSheet = null;
        Excel.Range oRng = null;

        public const double hei_rate = 1;
        public const double wid_rate = 0.114;
        private bool _officeXP = false;

        public clsExportToExcel()
        {

        }

        #region Common function
        private object ReturnValue(object obj)
        {
            switch (obj.GetType().FullName)
            {
                case "System.Int64":
                    obj = Convert.ToInt32(obj);
                    break;
                case "System.String":
                    // ngay thang
                    string[] s = obj.ToString().Split('/');
                    if (s.Length == 2)
                        obj = "'" + obj;
                    string[] s1 = obj.ToString().Split('-');
                    if (s1.Length == 2)
                        obj = "'" + obj;
                    if (!OfficeXP)
                        obj = obj.ToString().Replace("\r", string.Empty);
                    break;
            }
            return obj;
        }

        public bool OfficeXP
        {
            get { return _officeXP; }
            set { _officeXP = value; }
        }

        private char TimChu(int col)
        {
            return (char)(col + (int)'A' - 1);
        }

        public string TinhToaDo(int row, int col)
        {
            string result = null;
            if (col <= ((int)'Z' - (int)'A' + 1))
            {
                result = TimChu(col) + row.ToString();
            }
            else
            {
                int b = col % 26;
                if (b == 0)
                    b = 26;
                int a = Convert.ToInt32((col - b) / 26);
                result = TimChu(a).ToString() + TimChu(b).ToString() + row.ToString();
            }
            return result;
        }

        public void AddObject(Excel._Worksheet oSheet, ref Excel.Range oRng, object Cell1, object Cell2, object Value, int CellBorder, bool AutoFit)
        {
            oRng = oSheet.get_Range(Cell1, Cell2);
            oRng.Value2 = Value;
            if (AutoFit)
                oRng.EntireColumn.AutoFit();
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Cells.Borders.Value = CellBorder;
        }
        #endregion

        #region FlextGrid to Excel
        public void MergeExcel(string FileName, C1.Win.C1FlexGrid.C1FlexGrid fg)
        {
            try
            {
                oXL = new Excel.Application();
                oWB = (Excel._Workbook)(oXL.Workbooks.Open(FileName, Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));

                oSheet = (Excel._Worksheet)oWB.ActiveSheet;
                oSheet.UsedRange.Cells.Borders.Value = 1;
                // Thực hiện Merge 
                C1.Win.C1FlexGrid.CellRange cr;
                object obj;
                for (int i = 0; i < fg.Rows.Count; i++)
                {
                    if (fg.Rows[i].Visible)
                    {
                        for (int j = 0; j < fg.Cols.Count; j++)
                        {
                            if (fg.Cols[j].Visible)
                            {
                                cr = fg.GetMergedRange(i, j);
                                if ((!cr.IsSingleCell && (cr.r1 == i)) && (cr.c1 == j))
                                {
                                    oRng = oSheet.get_Range(TinhToaDo(cr.r1 + 1, cr.c1 + 1), TinhToaDo(cr.r2 + 1, cr.c2 + 1));
                                    obj = fg[i, j];
                                    oRng.Value2 = string.Empty;
                                    oRng.Merge(Missing.Value);
                                    oRng.Value2 = ReturnValue(obj);
                                }
                            }
                        }
                    }
                }
                // Xóa các cột, hàng đã bị ẩn
                for (int i = oSheet.UsedRange.Rows.Count - 1; i > 0; i--)
                {
                    oRng = oSheet.get_Range("A" + i.ToString(), Missing.Value);
                    if ((bool)oRng.EntireRow.Hidden == true)
                        oRng.EntireRow.Delete(Excel.XlDirection.xlToRight);
                }
                for (int i = oSheet.UsedRange.Columns.Count - 1; i > 0; i--)
                {
                    oRng = oSheet.get_Range(TinhToaDo(1, i), Missing.Value);
                    if ((bool)oRng.EntireColumn.Hidden == true)
                        oRng.EntireColumn.Delete(Excel.XlDirection.xlDown);
                }
                oWB.Save();
                oXL.Visible = true;
            }
            catch (Exception ex)
            {
                //oXL.Quit();
                throw ex;
            }
        }
        #endregion

        #region XtraGrid to Excel
        public void XtraGridTo(GridView grv, int DongBatDau, int CotBatDau)
        {
            try
            {
                oXL = new Excel.Application();
                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;
                //oSheet.UsedRange.Cells.Borders.Value = 1;
                int SoCotGroup = 0;
                foreach (GridColumn grc in grv.Columns)
                {
                    if (grc.GroupIndex >= 0)
                        SoCotGroup++;
                }

                // Mở file Excel
                oXL.Visible = true;
            }
            catch (Exception ex)
            {
                oXL.Quit();
                throw ex;
            }
        }
        #endregion
    }
}