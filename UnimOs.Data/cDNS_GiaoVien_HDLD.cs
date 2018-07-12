using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_GiaoVien_HDLD : cDBase
    {
        public DataTable GetBy_NS_GiaoienID(int NS_GiaoVienID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_GiaoVienID", SqlDbType.Int, NS_GiaoVienID));

            return RunProcedureGet("sp_NS_GiaoVien_HDLD_GetBy_NS_GiaoienID", colParam);
        }
    }
}
