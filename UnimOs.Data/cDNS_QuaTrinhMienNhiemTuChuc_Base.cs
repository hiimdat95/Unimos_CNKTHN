using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_QuaTrinhMienNhiemTuChuc : cDBase
    {
        public DataTable Get(NS_QuaTrinhMienNhiemTuChucInfo pNS_QuaTrinhMienNhiemTuChucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_QuaTrinhMienNhiemTuChucID",SqlDbType.Int,pNS_QuaTrinhMienNhiemTuChucInfo.NS_QuaTrinhMienNhiemTuChucID));

            return RunProcedureGet("sp_NS_QuaTrinhMienNhiemTuChuc_Get", colParam);            
        }

        public int Add(NS_QuaTrinhMienNhiemTuChucInfo pNS_QuaTrinhMienNhiemTuChucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, pNS_QuaTrinhMienNhiemTuChucInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pNS_QuaTrinhMienNhiemTuChucInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayRaQuyetDinh",SqlDbType.DateTime,pNS_QuaTrinhMienNhiemTuChucInfo.NgayRaQuyetDinh));
            colParam.Add(CreateParam("@NgayCoHieuLuc",SqlDbType.DateTime,pNS_QuaTrinhMienNhiemTuChucInfo.NgayCoHieuLuc));
            colParam.Add(CreateParam("@IDDM_CapQuyetDinh",SqlDbType.Int,pNS_QuaTrinhMienNhiemTuChucInfo.IDDM_CapQuyetDinh));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_QuaTrinhMienNhiemTuChuc_Add", colParam);
        }
        
        public void Update(NS_QuaTrinhMienNhiemTuChucInfo pNS_QuaTrinhMienNhiemTuChucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, pNS_QuaTrinhMienNhiemTuChucInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pNS_QuaTrinhMienNhiemTuChucInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayRaQuyetDinh",SqlDbType.DateTime,pNS_QuaTrinhMienNhiemTuChucInfo.NgayRaQuyetDinh));
            colParam.Add(CreateParam("@NgayCoHieuLuc",SqlDbType.DateTime,pNS_QuaTrinhMienNhiemTuChucInfo.NgayCoHieuLuc));
            colParam.Add(CreateParam("@IDDM_CapQuyetDinh",SqlDbType.Int,pNS_QuaTrinhMienNhiemTuChucInfo.IDDM_CapQuyetDinh));
            colParam.Add(CreateParam("@NS_QuaTrinhMienNhiemTuChucID",SqlDbType.Int,pNS_QuaTrinhMienNhiemTuChucInfo.NS_QuaTrinhMienNhiemTuChucID));

            RunProcedure("sp_NS_QuaTrinhMienNhiemTuChuc_Update", colParam);
        }
        
        public void Delete(NS_QuaTrinhMienNhiemTuChucInfo pNS_QuaTrinhMienNhiemTuChucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_QuaTrinhMienNhiemTuChucID",SqlDbType.Int,pNS_QuaTrinhMienNhiemTuChucInfo.NS_QuaTrinhMienNhiemTuChucID));

            RunProcedure("sp_NS_QuaTrinhMienNhiemTuChuc_Delete", colParam);
        }
    }
}
