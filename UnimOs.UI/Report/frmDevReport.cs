using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System.Data.Common;
using TruongViet.UnimOs.Business;

namespace UnimOs.UI
{
    public partial class frmDevReport : frmBase
    {
        private cBHT_Report oBHT_Report;
        XtraReport rpt;

        public frmDevReport()
        {
            InitializeComponent();
        }

        public frmDevReport(DataTable dt, string ReportName, string[] FieldFormatNumber, string FormatType, string WaterMark)
        {
            InitializeComponent();
            rpt = new XtraReport();
            oBHT_Report = new cBHT_Report();

            oBHT_Report.LoadXtraReport(rpt, ReportName, dt, Application.StartupPath, FieldFormatNumber, FormatType);

            rpt.Watermark.Text = WaterMark;
            printControl1.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument();
        }

        public frmDevReport(DataTable dtMain, DataTable dtSub, int IDHT_ReportMain, string WaterMark)
        {
            InitializeComponent();
            rpt = new XtraReport();
            oBHT_Report = new cBHT_Report();

            oBHT_Report.LoadXtraReports(rpt, IDHT_ReportMain, dtMain, dtSub, Application.StartupPath);
            rpt.Watermark.Text = WaterMark;

            printControl1.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument();
        }

        public frmDevReport(DataTable dtMain, DataTable dtSub, string ReportMainName, string ReportSubName, 
            string[] FieldSubReport, string[] FieldFormatNumberMain, string[] FieldFormatNumberSub, string WaterMark)
        {
            InitializeComponent();
            rpt = new XtraReport();
            oBHT_Report = new cBHT_Report();

            oBHT_Report.LoadXtraReport(rpt, ReportMainName, dtMain, Application.StartupPath, FieldFormatNumberMain, "");

            XtraReport rptSub = new XtraReport();
            oBHT_Report.LoadXtraReport(rptSub, ReportSubName, dtSub, Application.StartupPath, FieldFormatNumberSub, "");
            
            if (FieldSubReport != null)
            {
                foreach (string str in FieldSubReport)
                {
                    XRSubreport xrs = (XRSubreport)rpt.FindControl(str, true);
                    if (xrs != null)
                        xrs.ReportSource = rptSub;
                }
            }
            rpt.Watermark.Text = WaterMark;
            printControl1.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument();
        }

        public frmDevReport(DataTable dt, string ReportName, string[] FieldFormatNumber, string FormatType, string GroupBandName, string GroupFieldName)
        {
            InitializeComponent();
            rpt = new XtraReport();
            oBHT_Report = new cBHT_Report();

            oBHT_Report.LoadXtraReport(rpt, ReportName, dt, Application.StartupPath, FieldFormatNumber, FormatType);

            GroupHeaderBand groupBand = (GroupHeaderBand)rpt.Bands[GroupBandName];
            GroupField groupField = new GroupField(GroupFieldName);
            groupBand.GroupFields.Add(groupField);
            
            printControl1.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument();
        }
    }
}

//foreach (Band band in rpt.Bands)
//{
//    if (!(band is DetailReportBand)) continue;

//    DetailReportBand detailReportBand = (DetailReportBand)band;

//    if (detailReportBand.Bands.Count > 0)
//    {
//        foreach (Band childBand in detailReportBand.Bands)
//        {
//            if (!(childBand is DetailReportBand)) continue;

//        }
//    }
//}
//foreach (DataColumn dc in dt.Columns)
//{
//    string sttt = dc.DataType.Name;
//    XRControl xrc = rpt.FindControl("xr" + dc.ColumnName, true);
//    if (xrc != null)
//    {
//        if (dc.DataType.Name == "DateTime")
//        {
//            xrc.Text = NgayThangFull((DateTime)dt.Rows[0][dc.ColumnName]);
//            //xrc.DataBindings.Add("Text", NgayThangFull((DateTime)dt.Rows[0][dc.ColumnName]), dc.ColumnName);
//        }
//        else
//            xrc.DataBindings.Add("Text", dt, dc.ColumnName);
//    }
//}