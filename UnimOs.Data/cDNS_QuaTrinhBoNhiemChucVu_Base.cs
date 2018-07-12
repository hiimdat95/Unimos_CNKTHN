using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_QuaTrinhBoNhiemChucVu : cDBase
    {
        public DataTable Get(NS_QuaTrinhBoNhiemChucVuInfo pNS_QuaTrinhBoNhiemChucVuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_QuaTrinhBoNhiemChucVuID",SqlDbType.Int,pNS_QuaTrinhBoNhiemChucVuInfo.NS_QuaTrinhBoNhiemChucVuID));

            return RunProcedureGet("sp_NS_QuaTrinhBoNhiemChucVu_Get", colParam);            
        }

        public int Add(NS_QuaTrinhBoNhiemChucVuInfo pNS_QuaTrinhBoNhiemChucVuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_QuaTrinhBoNhiemChucVuInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pNS_QuaTrinhBoNhiemChucVuInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayRaQuyetDinh",SqlDbType.DateTime,pNS_QuaTrinhBoNhiemChucVuInfo.NgayRaQuyetDinh));
            colParam.Add(CreateParam("@IDDM_CapQuyetDinh",SqlDbType.Int,pNS_QuaTrinhBoNhiemChucVuInfo.IDDM_CapQuyetDinh));
            colParam.Add(CreateParam("@IDDM_ChucVuBoNhiem",SqlDbType.Int,pNS_QuaTrinhBoNhiemChucVuInfo.IDDM_ChucVuBoNhiem));
            colParam.Add(CreateParam("@NgayCoHieuLuc",SqlDbType.DateTime,pNS_QuaTrinhBoNhiemChucVuInfo.NgayCoHieuLuc));
            colParam.Add(CreateParam("@NgayHetHieuLuc",SqlDbType.DateTime,pNS_QuaTrinhBoNhiemChucVuInfo.NgayHetHieuLuc));
            colParam.Add(CreateParam("@LaChucVuKiemNhiem",SqlDbType.Bit,pNS_QuaTrinhBoNhiemChucVuInfo.LaChucVuKiemNhiem));
            colParam.Add(CreateParam("@IDNS_MienNhiemTuChuc",SqlDbType.Int,pNS_QuaTrinhBoNhiemChucVuInfo.IDNS_MienNhiemTuChuc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_QuaTrinhBoNhiemChucVu_Add", colParam);
        }
        
        public void Update(NS_QuaTrinhBoNhiemChucVuInfo pNS_QuaTrinhBoNhiemChucVuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_QuaTrinhBoNhiemChucVuInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pNS_QuaTrinhBoNhiemChucVuInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayRaQuyetDinh",SqlDbType.DateTime,pNS_QuaTrinhBoNhiemChucVuInfo.NgayRaQuyetDinh));
            colParam.Add(CreateParam("@IDDM_CapQuyetDinh",SqlDbType.Int,pNS_QuaTrinhBoNhiemChucVuInfo.IDDM_CapQuyetDinh));
            colParam.Add(CreateParam("@IDDM_ChucVuBoNhiem",SqlDbType.Int,pNS_QuaTrinhBoNhiemChucVuInfo.IDDM_ChucVuBoNhiem));
            colParam.Add(CreateParam("@NgayCoHieuLuc",SqlDbType.DateTime,pNS_QuaTrinhBoNhiemChucVuInfo.NgayCoHieuLuc));
            colParam.Add(CreateParam("@NgayHetHieuLuc",SqlDbType.DateTime,pNS_QuaTrinhBoNhiemChucVuInfo.NgayHetHieuLuc));
            colParam.Add(CreateParam("@LaChucVuKiemNhiem",SqlDbType.Bit,pNS_QuaTrinhBoNhiemChucVuInfo.LaChucVuKiemNhiem));
            colParam.Add(CreateParam("@IDNS_MienNhiemTuChuc",SqlDbType.Int,pNS_QuaTrinhBoNhiemChucVuInfo.IDNS_MienNhiemTuChuc));
            colParam.Add(CreateParam("@NS_QuaTrinhBoNhiemChucVuID",SqlDbType.Int,pNS_QuaTrinhBoNhiemChucVuInfo.NS_QuaTrinhBoNhiemChucVuID));

            RunProcedure("sp_NS_QuaTrinhBoNhiemChucVu_Update", colParam);
        }
        
        public void Delete(NS_QuaTrinhBoNhiemChucVuInfo pNS_QuaTrinhBoNhiemChucVuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_QuaTrinhBoNhiemChucVuID",SqlDbType.Int,pNS_QuaTrinhBoNhiemChucVuInfo.NS_QuaTrinhBoNhiemChucVuID));

            RunProcedure("sp_NS_QuaTrinhBoNhiemChucVu_Delete", colParam);
        }
    }
}
