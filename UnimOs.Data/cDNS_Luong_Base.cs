using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_Luong : cDBase
    {
        public DataTable Get(NS_LuongInfo pNS_LuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_LuongID",SqlDbType.Int,pNS_LuongInfo.NS_LuongID));

            return RunProcedureGet("sp_NS_Luong_Get", colParam);            
        }

        public int Add(NS_LuongInfo pNS_LuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_LuongInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDNS_SoQuyetDinh", SqlDbType.Int, pNS_LuongInfo.IDNS_SoQuyetDinh));
            colParam.Add(CreateParam("@CongViecDamNhiem",SqlDbType.NVarChar,pNS_LuongInfo.CongViecDamNhiem));
            colParam.Add(CreateParam("@IDNS_NgachCongChuc",SqlDbType.Int,pNS_LuongInfo.IDNS_NgachCongChuc));
            colParam.Add(CreateParam("@BacLuong",SqlDbType.Int,pNS_LuongInfo.BacLuong));
            colParam.Add(CreateParam("@HeSoLuong",SqlDbType.Float,pNS_LuongInfo.HeSoLuong));
            colParam.Add(CreateParam("@PhanTramHuong",SqlDbType.Float,pNS_LuongInfo.PhanTramHuong));
            colParam.Add(CreateParam("@TuNgay",SqlDbType.DateTime,pNS_LuongInfo.TuNgay));
            colParam.Add(CreateParam("@DenNgay",SqlDbType.DateTime,pNS_LuongInfo.DenNgay));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_Luong_Add", colParam);
        }
        
        public void Update(NS_LuongInfo pNS_LuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_LuongInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDNS_SoQuyetDinh", SqlDbType.Int, pNS_LuongInfo.IDNS_SoQuyetDinh));
            colParam.Add(CreateParam("@CongViecDamNhiem",SqlDbType.NVarChar,pNS_LuongInfo.CongViecDamNhiem));
            colParam.Add(CreateParam("@IDNS_NgachCongChuc",SqlDbType.Int,pNS_LuongInfo.IDNS_NgachCongChuc));
            colParam.Add(CreateParam("@BacLuong",SqlDbType.Int,pNS_LuongInfo.BacLuong));
            colParam.Add(CreateParam("@HeSoLuong",SqlDbType.Float,pNS_LuongInfo.HeSoLuong));
            colParam.Add(CreateParam("@PhanTramHuong",SqlDbType.Float,pNS_LuongInfo.PhanTramHuong));
            colParam.Add(CreateParam("@TuNgay",SqlDbType.DateTime,pNS_LuongInfo.TuNgay));
            colParam.Add(CreateParam("@DenNgay",SqlDbType.DateTime,pNS_LuongInfo.DenNgay));
            colParam.Add(CreateParam("@NS_LuongID",SqlDbType.Int,pNS_LuongInfo.NS_LuongID));

            RunProcedure("sp_NS_Luong_Update", colParam);
        }
        
        public void Delete(NS_LuongInfo pNS_LuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_LuongID",SqlDbType.Int,pNS_LuongInfo.NS_LuongID));

            RunProcedure("sp_NS_Luong_Delete", colParam);
        }
    }
}
