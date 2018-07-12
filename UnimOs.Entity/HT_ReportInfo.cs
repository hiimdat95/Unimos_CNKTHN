using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.UnimOs.Entity
{
    public struct HT_ReportInfo
    {

        private int mHT_ReportID;
        private string mReportName;
        private string mDetail;

        public int HT_ReportID{
        	set{ mHT_ReportID = value;}
        	get{ return mHT_ReportID;}
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
