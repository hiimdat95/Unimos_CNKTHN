using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public struct ReportInfo
    {

        private int mReportID;
        private string mReportName;
        private string mDetail;

        public int ReportID{
        	set{ mReportID = value;}
        	get{ return mReportID;}
        }
        public string ReportName{
        	set{ mReportName = value;}
        	get{ return mReportName;}
        }
        public string Detail{
        	set{ mDetail = value;}
        	get{ return mDetail;}
        }
    }
}
