using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDHT_Report : cDBase
    {
        public DataTable Get(HT_ReportInfo pReportInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_ReportID",SqlDbType.Int,pReportInfo.HT_ReportID));

            return RunProcedureGet("sp_HT_Report_Get", colParam);            
        }

        public void Add(HT_ReportInfo pReportInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@ReportName",SqlDbType.NVarChar,pReportInfo.ReportName));
            colParam.Add(CreateParam("@Detail",SqlDbType.NText,pReportInfo.Detail));

            RunProcedure("sp_HT_Report_Add", colParam);
        }
        
        public void Update(HT_ReportInfo pReportInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@ReportName",SqlDbType.NVarChar,pReportInfo.ReportName));
            colParam.Add(CreateParam("@Detail",SqlDbType.NText,pReportInfo.Detail));
            colParam.Add(CreateParam("@HT_ReportID",SqlDbType.Int,pReportInfo.HT_ReportID));

            RunProcedure("sp_HT_Report_Update", colParam);
        }
        
        public void Delete(HT_ReportInfo pReportInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_ReportID", SqlDbType.Int, pReportInfo.HT_ReportID));

            RunProcedure("sp_HT_Report_Delete", colParam);
        }
    }
}
