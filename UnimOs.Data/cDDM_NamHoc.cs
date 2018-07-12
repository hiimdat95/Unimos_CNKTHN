using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_NamHoc : cDBase
    {
        public int GetKy2(DM_NamHocInfo pNamHocInfo)
        {
            DataTable dt;
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NamHocID", SqlDbType.Int, pNamHocInfo.DM_NamHocID));

            dt = RunProcedureGet("sp_DM_NamHoc_GetKy2", colParam);
            if (dt.Rows.Count > 0)
                return (int)dt.Rows[0]["TuanThu"];
            else
                return 0;
        }
    }
}
