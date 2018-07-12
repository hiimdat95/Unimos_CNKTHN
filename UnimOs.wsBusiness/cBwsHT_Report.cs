using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.wsBusiness;
using System.Drawing;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Entity.Model;
using TruongViet.UnimOs.Data;
using UnimOs.wsBusiness.wsUnimOs;
using C1.Win.C1Report;
using System.IO;
using DevExpress.XtraReports.UI;

namespace TruongViet.UnimOs.wsBusiness
{
    public class cBwsHT_Report : cBwsBase
    {
        private HT_ReportInfo oReportInfo;
        private cDHT_Report oDHT_Report;

        public cBwsHT_Report()
        {
            oDHT_Report = new cDHT_Report();
        }

        //public DataTable Get(HT_ReportInfo pReportInfo)
        //{
        //    using (var client = new UnimOsServiceClient())
        //    {
        //        return ConvertList.ToDataTable<HT_ReportInfo>(client.cDHT_Report_Get(GlobalVar.MaXacThuc, pReportInfo));
        //    }
        //}

        //public void Add(HT_ReportInfo pReportInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDHT_Report_Add(GlobalVar.MaXacThuc, pReportInfo);
        //    client.Close();
        //    mErrorMessage = oDHT_Report.ErrorMessages;
        //    mErrorNumber = oDHT_Report.ErrorNumber;
        //}

        //public void Update(HT_ReportInfo pReportInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDHT_Report_Update(GlobalVar.MaXacThuc, pReportInfo);
        //    client.Close();
        //    mErrorMessage = oDHT_Report.ErrorMessages;
        //    mErrorNumber = oDHT_Report.ErrorNumber;
        //}

        //public void Delete(HT_ReportInfo pReportInfo)
        //{
        //    var client = new UnimOsServiceClient();
        //    client.cDHT_Report_Delete(GlobalVar.MaXacThuc, pReportInfo);
        //    client.Close();
        //    mErrorMessage = oDHT_Report.ErrorMessages;
        //    mErrorNumber = oDHT_Report.ErrorNumber;
        //}

        //public List<HT_ReportInfo> GetList(HT_ReportInfo pReportInfo)
        //{
        //    List<HT_ReportInfo> oReportInfoList = new List<HT_ReportInfo>();
        //    DataTable dtb = Get(pReportInfo);
        //    if (dtb != null)
        //    {
        //        for (int i = 0; i < dtb.Rows.Count; i++)
        //        {
        //            oReportInfo = new HT_ReportInfo();


        //            oReportInfo.HT_ReportID = int.Parse(dtb.Rows[i]["HT_ReportID"].ToString());
        //            oReportInfo.ReportName = dtb.Rows[i]["ReportName"].ToString();
        //            oReportInfo.Detail = dtb.Rows[i]["Detail"].ToString();

        //            oReportInfoList.Add(oReportInfo);
        //        }
        //    }
        //    return oReportInfoList.Count == 0 ? null : oReportInfoList;
        //}

        public bool LoadReport(C1Report c1r, string ReportName, string FolderPath)
        {
            // Nếu đã có file .xml trong thư mục báo cáo thì load trực tiếp
            // Nếu chưa có thì load trong DB sau đó save lại vào thư mục báo cáo
            string FullFileName = FolderPath + "\\Template\\" + ReportName + ".xml";
            if (!File.Exists(FullFileName))
            {
                oReportInfo.ReportName = ReportName;
                var client = new UnimOsServiceClient();
                DataTable dt = ConvertList.ToDataTable<sp_HT_Report_GetByNameResult>(client.cDHT_Report_GetByName(GlobalVar.MaXacThuc, oReportInfo));
                client.Close();
                if (dt.Rows.Count > 0)
                {
                    string Detail = dt.Rows[0]["Detail"].ToString();
                    if (Detail != "")
                    {
                        try
                        {
                            File.WriteAllText(FullFileName, Detail);
                        }
                        catch
                        {
                            return false;
                        }
                    }
                }
            }
            // Load report từ file
            System.Xml.XmlDocument Doc = new System.Xml.XmlDocument();
            c1r.Load(FullFileName, ReportName.Trim());
            return true;
        }

        public bool LoadXtraReport(XtraReport rpt, string ReportName, DataTable dtReport, string FolderPath, string FieldsFormatNumber)
        {
            // Nếu đã có file .xml trong thư mục báo cáo thì load trực tiếp
            // Nếu chưa có thì load trong DB sau đó save lại vào thư mục báo cáo
            string FullFileName = FolderPath + "\\Template\\" + ReportName + ".repx";
            if (!File.Exists(FullFileName))
            {
                var client = new UnimOsServiceClient();
                DataTable dt = ConvertList.ToDataTable<sp_HT_Report_GetByNameResult>(client.cDHT_Report_GetByName_2(GlobalVar.MaXacThuc, ReportName));
                client.Close();
                if (dt.Rows.Count > 0)
                {
                    string Detail = dt.Rows[0]["Detail"].ToString();
                    if (Detail != "")
                    {
                        try
                        {
                            File.WriteAllText(FullFileName, Detail);
                        }
                        catch
                        {
                            return false;
                        }
                    }
                }
            }
            // Load report từ file
            rpt.LoadLayout(FolderPath + "\\Template\\" + ReportName + ".repx");

            rpt.DataSource = dtReport;

            if (dtReport != null && FieldsFormatNumber != "")
            {
                string[] arrField = FieldsFormatNumber.Split(',');
                foreach (string str in arrField)
                {
                    XRControl xrc = rpt.FindControl(str, true);
                    if (xrc != null)
                    {
                        xrc.DataBindings.Add("Text", dtReport, str, "{0:n0}");
                    }
                }
            }
            return true;
        }

        public bool LoadXtraReport(XtraReport rpt, string ReportName, DataTable dtReport, string FolderPath, string[] FieldsFormatNumber, string FormatType)
        {
            // Nếu đã có file .xml trong thư mục báo cáo thì load trực tiếp
            // Nếu chưa có thì load trong DB sau đó save lại vào thư mục báo cáo
            string FullFileName = FolderPath + "\\Template\\" + ReportName + ".repx";
            if (!File.Exists(FullFileName))
            {
                var client = new UnimOsServiceClient();
                DataTable dt = ConvertList.ToDataTable<sp_HT_Report_GetByNameResult>(client.cDHT_Report_GetByName_2(GlobalVar.MaXacThuc, ReportName));
                client.Close();
                if (dt.Rows.Count > 0)
                {
                    string Detail = dt.Rows[0]["Detail"].ToString();
                    if (Detail != "")
                    {
                        try
                        {
                            File.WriteAllText(FullFileName, Detail);
                        }
                        catch
                        {
                            return false;
                        }
                    }
                }
            }
            // Load report từ file
            rpt.LoadLayout(FolderPath + "\\Template\\" + ReportName + ".repx");

            rpt.DataSource = dtReport;

            if (dtReport != null && FieldsFormatNumber != null)
            {
                foreach (string str in FieldsFormatNumber)
                {
                    XRControl xrc = rpt.FindControl(str, true);
                    if (xrc != null)
                    {
                        xrc.DataBindings.Add("Text", dtReport, str, "{" + FormatType + "}");
                    }
                }
            }
            return true;
        }

        public bool LoadXtraReports(XtraReport rpt, int IDHT_ReportMain, DataTable dtMain, DataTable dtSub, string FolderPath)
        {
            try
            {
                var client = new UnimOsServiceClient();
                DataTable dt = ConvertList.ToDataTable<HT_ReportInfo>(client.cDHT_Report_GetByIDReportMain(GlobalVar.MaXacThuc, IDHT_ReportMain));
                client.Close();
                if (dt.Rows.Count <= 0)
                    return false;
                if (!LoadXtraReport(rpt, dt.Rows[0]["ReportName"].ToString(), dtMain, FolderPath, "" + dt.Rows[0]["FieldsFormatNumber"]))
                    return false;
                XtraReport rptSub = new XtraReport();
                XRSubreport xrs;
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    if (!LoadXtraReport(rptSub, dt.Rows[i]["ReportName"].ToString(), dtSub, FolderPath, "" + dt.Rows[i]["FieldsFormatNumber"]))
                        return false;
                    xrs = (XRSubreport)rpt.FindControl("" + dt.Rows[i]["FieldSubReport"], true);
                    if (xrs != null)
                    {
                        xrs.ReportSource = rptSub;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
