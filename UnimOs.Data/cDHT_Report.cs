using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;
using System.Collections;

namespace TruongViet.UnimOs.Data
{
    public partial class cDHT_Report : cDBase
    {
        public DataTable GetByName(HT_ReportInfo pReportInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@ReportName", SqlDbType.NVarChar, pReportInfo.ReportName));

            return RunProcedureGet("sp_HT_Report_GetByName", colParam); 
        }

        public DataTable GetByName(string ReportName)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@ReportName", SqlDbType.NVarChar, ReportName));

            return RunProcedureGet("sp_HT_Report_GetByName", colParam);
        }

        public DataTable GetByIDReportMain(int IDHT_Report)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_ReportID", SqlDbType.Int, IDHT_Report));

            return RunProcedureGet("sp_HT_Report_GetByIDReportMain", colParam);
        }

        public DataTable GetTenBaoCao()
        {
            ArrayList colParam = new ArrayList();

            return RunProcedureGet("sp_HT_Report_GetTenBaoCao", colParam);
        }

        public DataTable GetXtraReport(int HT_ReportID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_ReportID", SqlDbType.Int, HT_ReportID));

            return RunProcedureGet("sp_HT_Report_GetXtraReport", colParam);
        }
    }
}
