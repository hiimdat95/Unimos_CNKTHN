using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_LuongCoBan : cDBase
    {
        public int Add_Update(NS_LuongCoBanInfo pNS_LuongCoBanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@LuongCoBan", SqlDbType.Money, pNS_LuongCoBanInfo.LuongCoBan));
            colParam.Add(CreateParam("@TuNgay", SqlDbType.DateTime, pNS_LuongCoBanInfo.TuNgay));
            colParam.Add(CreateParam("@DenNgay", SqlDbType.DateTime, pNS_LuongCoBanInfo.DenNgay));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_LuongCoBan_Add_Update", colParam);
        }

        public DataTable Get_DenNgayInfo()
        {
            ArrayList colParam = new ArrayList();
            return RunProcedureGet("sp_NS_LuongCoBan_Get_DenNgayInfo", colParam);
        }
    }
}
