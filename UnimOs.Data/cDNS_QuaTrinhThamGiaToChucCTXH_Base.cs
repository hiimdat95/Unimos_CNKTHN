using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_QuaTrinhThamGiaToChucCTXH : cDBase
    {
        public DataTable Get(NS_QuaTrinhThamGiaToChucCTXHInfo pNS_QuaTrinhThamGiaToChucCTXHInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_QuaTrinhThamGiaToChucCTXHID",SqlDbType.Int,pNS_QuaTrinhThamGiaToChucCTXHInfo.NS_QuaTrinhThamGiaToChucCTXHID));

            return RunProcedureGet("sp_NS_QuaTrinhThamGiaToChucCTXH_Get", colParam);            
        }

        public int Add(NS_QuaTrinhThamGiaToChucCTXHInfo pNS_QuaTrinhThamGiaToChucCTXHInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_QuaTrinhThamGiaToChucCTXHInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@NgayThamGia",SqlDbType.DateTime,pNS_QuaTrinhThamGiaToChucCTXHInfo.NgayThamGia));
            colParam.Add(CreateParam("@TenToChuc",SqlDbType.NVarChar,pNS_QuaTrinhThamGiaToChucCTXHInfo.TenToChuc));
            colParam.Add(CreateParam("@CongViec",SqlDbType.NVarChar,pNS_QuaTrinhThamGiaToChucCTXHInfo.CongViec));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_QuaTrinhThamGiaToChucCTXH_Add", colParam);
        }
        
        public void Update(NS_QuaTrinhThamGiaToChucCTXHInfo pNS_QuaTrinhThamGiaToChucCTXHInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_QuaTrinhThamGiaToChucCTXHInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@NgayThamGia",SqlDbType.DateTime,pNS_QuaTrinhThamGiaToChucCTXHInfo.NgayThamGia));
            colParam.Add(CreateParam("@TenToChuc",SqlDbType.NVarChar,pNS_QuaTrinhThamGiaToChucCTXHInfo.TenToChuc));
            colParam.Add(CreateParam("@CongViec",SqlDbType.NVarChar,pNS_QuaTrinhThamGiaToChucCTXHInfo.CongViec));
            colParam.Add(CreateParam("@NS_QuaTrinhThamGiaToChucCTXHID",SqlDbType.Int,pNS_QuaTrinhThamGiaToChucCTXHInfo.NS_QuaTrinhThamGiaToChucCTXHID));

            RunProcedure("sp_NS_QuaTrinhThamGiaToChucCTXH_Update", colParam);
        }
        
        public void Delete(NS_QuaTrinhThamGiaToChucCTXHInfo pNS_QuaTrinhThamGiaToChucCTXHInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_QuaTrinhThamGiaToChucCTXHID",SqlDbType.Int,pNS_QuaTrinhThamGiaToChucCTXHInfo.NS_QuaTrinhThamGiaToChucCTXHID));

            RunProcedure("sp_NS_QuaTrinhThamGiaToChucCTXH_Delete", colParam);
        }
    }
}
