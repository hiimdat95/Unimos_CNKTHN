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

namespace UnimOs.Khoa
{
    public partial class frmReport : frmBase
    {        
        private cBHT_Report oBReport;

        public frmReport()
        {
            InitializeComponent();          
        }

        public frmReport(DataTable dt, string ReportName)
        {
            InitializeComponent();
            try
            {
                oBReport = new cBHT_Report();
                if (oBReport.LoadReport(c1r, ReportName, Application.StartupPath) == true)
                {
                    c1r.DataSource.RecordSource = "";
                    c1r.DataSource.Recordset = dt;
                    if (c1r.Fields.Count > 0)
                    {
                        c1PrintPreview.Document = c1r.Document;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public frmReport(DataTable dt, DataTable dtSub, string ReportName, string ReportSub, string[] FieldSub)
        {
            InitializeComponent();
            try
            {
                oBReport = new cBHT_Report();
                if (oBReport.LoadReport(c1r, ReportName, Application.StartupPath) == true)
                {
                    C1.Win.C1Report.C1Report c1rSub = new C1.Win.C1Report.C1Report();
                    if (oBReport.LoadReport(c1rSub, ReportSub, Application.StartupPath) == true)
                    {
                        c1rSub.DataSource.RecordSource = "";
                        if (dtSub != null)
                        {
                            c1rSub.DataSource.Recordset = dtSub;
                        }
                        foreach (string str in FieldSub)
                        {
                            c1r.Fields[str].Subreport = c1rSub;
                        }
                    }
                    c1r.DataSource.RecordSource = "";
                    c1r.DataSource.Recordset = dt;
                    if (c1r.Fields.Count > 0)
                    {
                        c1PrintPreview.Document = c1r.Document;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}