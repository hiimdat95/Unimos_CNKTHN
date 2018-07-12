using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_CTDT_ChiTiet : cDBase
    {
        public void DeleteByHocKy(KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_CTDT_ChiTietID", SqlDbType.BigInt, pKQHT_CTDT_ChiTietInfo.KQHT_CTDT_ChiTietID));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, pKQHT_CTDT_ChiTietInfo.HocKy));

            RunProcedure("sp_KQHT_CTDT_ChiTiet_DeleteByHocKy", colParam);
        }
    }
}
