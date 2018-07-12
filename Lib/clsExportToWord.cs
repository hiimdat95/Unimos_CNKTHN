using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Office.Interop.Word;

namespace Lib
{
    public class clsExportToWord
    {
        // Created by GiapDP
        // Date created 11/08/2010
        private object oMissing = System.Reflection.Missing.Value;
        private object oEndOfDoc = "\\endofdoc";
        private object oRng;
        private Paragraph oPara;
        private Table oTable;
        private Range wrdRng;
        private int SpaceAfter = 6;

        public clsExportToWord()
        { 
            
        }

        public void InitWord(ApplicationClass WordApp, ref Document aDoc, int Size)
        {
            object fileName = "";
            object newTemplate = true;
            object docType = 1;
            object isVisible = true;

            aDoc = WordApp.Documents.Add(ref fileName, ref newTemplate, ref docType, ref isVisible);
            aDoc.ActiveWindow.View.Type = Microsoft.Office.Interop.Word.WdViewType.wdPrintView;
            aDoc.ActiveWindow.Selection.Font.Name = "Times New Roman";
            aDoc.ActiveWindow.Selection.Font.Size = Size;

            aDoc.Activate();
        }

        public void OpenWord(ApplicationClass WordApp, ref Document aDoc, string _FileName)
        {
            object fileName = _FileName;
            object falseValue = false;
            object trueValue = true;

            aDoc = WordApp.Documents.Open(ref fileName, ref oMissing, ref falseValue, ref falseValue, ref oMissing, ref oMissing, ref oMissing,
              ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref trueValue, ref oMissing, ref oMissing); //, ref oMissing, ref oMissing

            aDoc.ActiveWindow.View.Type = Microsoft.Office.Interop.Word.WdViewType.wdPrintView;
            aDoc.Activate();
        }

        public void SaveAsWord(ref Document aDoc, string _FileName)
        {
            object fileName = _FileName;
            //object falseValue = false;
            //object trueValue = true;

            aDoc.SaveAs(ref fileName, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, 
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
        }

        public void AddClipboard(Document aDoc, string Content, bool PageBreak)
        {
            if (PageBreak)
            {
                oRng = aDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara = aDoc.Content.Paragraphs.Add(ref oRng);
                object objBreakType = WdBreakType.wdPageBreak;
                oPara.Range.InsertBreak(ref objBreakType);
            }
            oRng = aDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara = aDoc.Content.Paragraphs.Add(ref oRng);

            oPara.Range.Text = Content;
            oPara.Format.SpaceAfter = SpaceAfter;
            oPara.Range.InsertParagraphAfter();
        }

        public void AddText(Document aDoc, string Text, int Bold, int Italic, WdParagraphAlignment Alignment)
        {
            oRng = aDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara = aDoc.Content.Paragraphs.Add(ref oRng);
            oPara.Range.Text = Text;
            oPara.Range.Font.Bold = Bold;
            oPara.Range.Font.Italic = Italic;
            oPara.Format.Alignment = Alignment;
            oPara.Format.SpaceAfter = SpaceAfter;
            oPara.Range.InsertParagraphAfter();
        }

        public void AddText(Document aDoc, string Text, int Bold, int Italic, WdParagraphAlignment Alignment, float FontSize)
        {
            oRng = aDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara = aDoc.Content.Paragraphs.Add(ref oRng);
            oPara.Range.Text = Text;
            oPara.Range.Font.Size = FontSize;
            oPara.Range.Font.Bold = Bold;
            oPara.Range.Font.Italic = Italic;
            oPara.Format.Alignment = Alignment;
            oPara.Format.SpaceAfter = SpaceAfter;
            oPara.Range.InsertParagraphAfter();
        }

        public void AddTable(Document aDoc, DataTable dt, string[] Caption, string[] FieldName)
        {
            wrdRng = aDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = aDoc.Tables.Add(wrdRng, dt.Rows.Count + 1, FieldName.Length, ref oMissing, ref oMissing);
            oTable.Range.Font.Bold = 0;
            oTable.Range.Font.Italic = 0;
            oTable.Range.Font.Underline = 0;
            oTable.Range.ParagraphFormat.SpaceAfter = 2;
            oTable.Range.Cells.Borders.Enable = 1;

            int c;
            // Set Caption
            for (c = 1; c <= FieldName.Length; c++)
            {
                oTable.Cell(1, c).Range.Text = Caption[c - 1];
                //oTable.Cell(1,c).Width = aDoc
            }
            // Fill content
            for (int r = 1; r <= dt.Rows.Count; r++)
            {
                for (c = 1; c <= FieldName.Length; c++)
                {
                    if (dt.Columns.Contains(FieldName[c - 1]))
                        oTable.Cell(r + 1, c).Range.Text = GetText(dt.Rows[r - 1][FieldName[c - 1]], dt.Columns[FieldName[c - 1]].DataType.Name);
                }
            }
            oTable.Rows[1].Range.Font.Bold = 1;
        }

        public void AddTable(ApplicationClass WordApp, Document aDoc, DataTable dt, string[] Caption, string[] FieldName, Dictionary<int, float> colWidth)
        {
            wrdRng = aDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = aDoc.Tables.Add(wrdRng, dt.Rows.Count + 1, FieldName.Length, ref oMissing, ref oMissing);
            oTable.Range.Font.Bold = 0;
            oTable.Range.Font.Italic = 0;
            oTable.Range.Font.Underline = 0;
            oTable.Range.ParagraphFormat.SpaceAfter = 2;
            oTable.Range.Cells.Borders.Enable = 1;

            int c;
            // Set Caption
            for (c = 1; c <= FieldName.Length; c++)
            {
                oTable.Cell(1, c).Range.Text = Caption[c - 1];
                if (colWidth.ContainsKey(c))
                    oTable.Columns[c].Width = WordApp.CentimetersToPoints(colWidth[c]);
            }
            // Fill content
            for (int r = 1; r <= dt.Rows.Count; r++)
            {
                for (c = 1; c <= FieldName.Length; c++)
                {
                    if (dt.Columns.Contains(FieldName[c - 1]))
                        oTable.Cell(r + 1, c).Range.Text = GetText(dt.Rows[r - 1][FieldName[c - 1]], dt.Columns[FieldName[c - 1]].DataType.Name);
                }
            }
            oTable.Rows[1].Range.Font.Bold = 1;
        }

        private string GetText(object Value, string Type)
        {
            string str = "" + Value;
            switch (Type)
            { 
                case "DateTime":
                    if (str != "")
                        str = String.Format("{0:dd/MM/yyyy}", Value);
                    break;
            }
            return str;
        }
    }
}
