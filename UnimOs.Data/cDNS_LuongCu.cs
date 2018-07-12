using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_LuongCu : cDBase
    {
        public int Add_InfoFull(NS_LuongCuInfo pNS_LuongCuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, pNS_LuongCuInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@CongViecDamNhiem", SqlDbType.NVarChar, pNS_LuongCuInfo.CongViecDamNhiem));
            colParam.Add(CreateParam("@IDNS_NgachCongChuc", SqlDbType.Int, pNS_LuongCuInfo.IDNS_NgachCongChuc));
            colParam.Add(CreateParam("@BacLuong", SqlDbType.Int, pNS_LuongCuInfo.BacLuong));
            colParam.Add(CreateParam("@HeSoLuong", SqlDbType.Float, pNS_LuongCuInfo.HeSoLuong));
            colParam.Add(CreateParam("@PhanTramHuong", SqlDbType.Float, pNS_LuongCuInfo.PhanTramHuong));
            colParam.Add(CreateParam("@TuNgay", SqlDbType.DateTime, pNS_LuongCuInfo.TuNgay));
            colParam.Add(CreateParam("@DenNgay", SqlDbType.DateTime, pNS_LuongCuInfo.DenNgay));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_LuongCu_Add_InfoFull", colParam);
        }
    }
}
