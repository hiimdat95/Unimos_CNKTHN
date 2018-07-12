using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_QuaTrinhThamGiaLucLuongVuTrang : cDBase
    {
        public DataTable Get(NS_QuaTrinhThamGiaLucLuongVuTrangInfo pNS_QuaTrinhThamGiaLucLuongVuTrangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_QuaTrinhThamGiaLucLuongVuTrangID",SqlDbType.Int,pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NS_QuaTrinhThamGiaLucLuongVuTrangID));

            return RunProcedureGet("sp_NS_QuaTrinhThamGiaLucLuongVuTrang_Get", colParam);            
        }

        public int Add(NS_QuaTrinhThamGiaLucLuongVuTrangInfo pNS_QuaTrinhThamGiaLucLuongVuTrangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@NgayNhapNgu",SqlDbType.DateTime,pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NgayNhapNgu));
            colParam.Add(CreateParam("@NgayXuatNgu",SqlDbType.DateTime,pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NgayXuatNgu));
            colParam.Add(CreateParam("@IDDM_QuanHam",SqlDbType.Int,pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.IDDM_QuanHam));
            colParam.Add(CreateParam("@DonVi",SqlDbType.NVarChar,pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.DonVi));
            colParam.Add(CreateParam("@ChucVu",SqlDbType.NVarChar,pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.ChucVu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_QuaTrinhThamGiaLucLuongVuTrang_Add", colParam);
        }
        
        public void Update(NS_QuaTrinhThamGiaLucLuongVuTrangInfo pNS_QuaTrinhThamGiaLucLuongVuTrangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@NgayNhapNgu",SqlDbType.DateTime,pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NgayNhapNgu));
            colParam.Add(CreateParam("@NgayXuatNgu",SqlDbType.DateTime,pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NgayXuatNgu));
            colParam.Add(CreateParam("@IDDM_QuanHam",SqlDbType.Int,pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.IDDM_QuanHam));
            colParam.Add(CreateParam("@DonVi",SqlDbType.NVarChar,pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.DonVi));
            colParam.Add(CreateParam("@ChucVu",SqlDbType.NVarChar,pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.ChucVu));
            colParam.Add(CreateParam("@NS_QuaTrinhThamGiaLucLuongVuTrangID",SqlDbType.Int,pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NS_QuaTrinhThamGiaLucLuongVuTrangID));

            RunProcedure("sp_NS_QuaTrinhThamGiaLucLuongVuTrang_Update", colParam);
        }
        
        public void Delete(NS_QuaTrinhThamGiaLucLuongVuTrangInfo pNS_QuaTrinhThamGiaLucLuongVuTrangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_QuaTrinhThamGiaLucLuongVuTrangID",SqlDbType.Int,pNS_QuaTrinhThamGiaLucLuongVuTrangInfo.NS_QuaTrinhThamGiaLucLuongVuTrangID));

            RunProcedure("sp_NS_QuaTrinhThamGiaLucLuongVuTrang_Delete", colParam);
        }
    }
}
