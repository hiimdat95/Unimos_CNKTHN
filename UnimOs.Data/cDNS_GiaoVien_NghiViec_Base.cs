using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_GiaoVien_NghiViec : cDBase
    {
        public DataTable Get(NS_GiaoVien_NghiViecInfo pNS_GiaoVien_NghiViecInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_GiaoVien_NghiViecID",SqlDbType.Int,pNS_GiaoVien_NghiViecInfo.NS_GiaoVien_NghiViecID));

            return RunProcedureGet("sp_NS_GiaoVien_NghiViec_Get", colParam);            
        }

        public int Add(NS_GiaoVien_NghiViecInfo pNS_GiaoVien_NghiViecInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_GiaoVien_NghiViecInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pNS_GiaoVien_NghiViecInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@IDNS_HinhThucNghiViec",SqlDbType.NVarChar,pNS_GiaoVien_NghiViecInfo.IDNS_HinhThucNghiViec));
            colParam.Add(CreateParam("@NgayCoHieuLuc",SqlDbType.DateTime,pNS_GiaoVien_NghiViecInfo.NgayCoHieuLuc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_GiaoVien_NghiViec_Add", colParam);
        }
        
        public void Update(NS_GiaoVien_NghiViecInfo pNS_GiaoVien_NghiViecInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_GiaoVien_NghiViecInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pNS_GiaoVien_NghiViecInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@IDNS_HinhThucNghiViec",SqlDbType.NVarChar,pNS_GiaoVien_NghiViecInfo.IDNS_HinhThucNghiViec));
            colParam.Add(CreateParam("@NgayCoHieuLuc",SqlDbType.DateTime,pNS_GiaoVien_NghiViecInfo.NgayCoHieuLuc));
            colParam.Add(CreateParam("@NS_GiaoVien_NghiViecID",SqlDbType.Int,pNS_GiaoVien_NghiViecInfo.NS_GiaoVien_NghiViecID));

            RunProcedure("sp_NS_GiaoVien_NghiViec_Update", colParam);
        }
        
        public void Delete(NS_GiaoVien_NghiViecInfo pNS_GiaoVien_NghiViecInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_GiaoVien_NghiViecID",SqlDbType.Int,pNS_GiaoVien_NghiViecInfo.NS_GiaoVien_NghiViecID));

            RunProcedure("sp_NS_GiaoVien_NghiViec_Delete", colParam);
        }
    }
}
