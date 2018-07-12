using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_NhomNgach : cDBase
    {
        public DataTable GetBy_NS_NgachCongChucID(int NS_NgachCongChucID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_NgachCongChucID", SqlDbType.Int, NS_NgachCongChucID));

            return RunProcedureGet("sp_NS_NhomNgach_GetBy_NS_NgachCongChucID", colParam);
        }

    }
}
