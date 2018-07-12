using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_PhuCap : cDBase
    {
        public DataTable Get(NS_PhuCapInfo pNS_PhuCapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_PhuCapID",SqlDbType.Int,pNS_PhuCapInfo.NS_PhuCapID));

            return RunProcedureGet("sp_NS_PhuCap_Get", colParam);            
        }

        public int Add(NS_PhuCapInfo pNS_PhuCapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_PhuCapInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDNS_LoaiPhuCap",SqlDbType.Int,pNS_PhuCapInfo.IDNS_LoaiPhuCap));
            colParam.Add(CreateParam("@HeSoPhuCap",SqlDbType.Float,pNS_PhuCapInfo.HeSoPhuCap));
            colParam.Add(CreateParam("@PhanTramHuong",SqlDbType.Float,pNS_PhuCapInfo.PhanTramHuong));
            colParam.Add(CreateParam("@PhuCapTuNgay",SqlDbType.DateTime,pNS_PhuCapInfo.PhuCapTuNgay));
            colParam.Add(CreateParam("@PhuCapDenNgay",SqlDbType.DateTime,pNS_PhuCapInfo.PhuCapDenNgay));
            colParam.Add(CreateParam("@TinhBHXH",SqlDbType.Bit,pNS_PhuCapInfo.TinhBHXH));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_PhuCap_Add", colParam);
        }
        
        public void Update(NS_PhuCapInfo pNS_PhuCapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_PhuCapInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDNS_LoaiPhuCap",SqlDbType.Int,pNS_PhuCapInfo.IDNS_LoaiPhuCap));
            colParam.Add(CreateParam("@HeSoPhuCap",SqlDbType.Float,pNS_PhuCapInfo.HeSoPhuCap));
            colParam.Add(CreateParam("@PhanTramHuong",SqlDbType.Float,pNS_PhuCapInfo.PhanTramHuong));
            colParam.Add(CreateParam("@PhuCapTuNgay",SqlDbType.DateTime,pNS_PhuCapInfo.PhuCapTuNgay));
            colParam.Add(CreateParam("@PhuCapDenNgay",SqlDbType.DateTime,pNS_PhuCapInfo.PhuCapDenNgay));
            colParam.Add(CreateParam("@TinhBHXH",SqlDbType.Bit,pNS_PhuCapInfo.TinhBHXH));
            colParam.Add(CreateParam("@NS_PhuCapID",SqlDbType.Int,pNS_PhuCapInfo.NS_PhuCapID));

            RunProcedure("sp_NS_PhuCap_Update", colParam);
        }
        
        public void Delete(NS_PhuCapInfo pNS_PhuCapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_PhuCapID",SqlDbType.Int,pNS_PhuCapInfo.NS_PhuCapID));

            RunProcedure("sp_NS_PhuCap_Delete", colParam);
        }
    }
}
