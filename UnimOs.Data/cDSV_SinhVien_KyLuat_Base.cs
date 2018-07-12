using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_SinhVien_KyLuat : cDBase
    {
        public DataTable Get(SV_SinhVien_KyLuatInfo pSV_SinhVien_KyLuatInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_SinhVien_KyLuatID",SqlDbType.Int,pSV_SinhVien_KyLuatInfo.SV_SinhVien_KyLuatID));

            return RunProcedureGet("sp_SV_SinhVien_KyLuat_Get", colParam);            
        }

        public int Add(SV_SinhVien_KyLuatInfo pSV_SinhVien_KyLuatInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_SinhVien_KyLuatInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDSV_QuyetDinhKyLuat",SqlDbType.Int,pSV_SinhVien_KyLuatInfo.IDSV_QuyetDinhKyLuat));
            colParam.Add(CreateParam("@XoaKyLuat",SqlDbType.Bit,pSV_SinhVien_KyLuatInfo.XoaKyLuat));
            colParam.Add(CreateParam("@NgayXoaKyLuat",SqlDbType.DateTime,pSV_SinhVien_KyLuatInfo.NgayXoaKyLuat));
            colParam.Add(CreateParam("@LyDoXoaKyLuat",SqlDbType.NVarChar,pSV_SinhVien_KyLuatInfo.LyDoXoaKyLuat));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_SV_SinhVien_KyLuat_Add", colParam);
        }
        
        public void Update(SV_SinhVien_KyLuatInfo pSV_SinhVien_KyLuatInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_SinhVien_KyLuatInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDSV_QuyetDinhKyLuat",SqlDbType.Int,pSV_SinhVien_KyLuatInfo.IDSV_QuyetDinhKyLuat));
            colParam.Add(CreateParam("@XoaKyLuat",SqlDbType.Bit,pSV_SinhVien_KyLuatInfo.XoaKyLuat));
            colParam.Add(CreateParam("@NgayXoaKyLuat",SqlDbType.DateTime,pSV_SinhVien_KyLuatInfo.NgayXoaKyLuat));
            colParam.Add(CreateParam("@LyDoXoaKyLuat",SqlDbType.NVarChar,pSV_SinhVien_KyLuatInfo.LyDoXoaKyLuat));
            colParam.Add(CreateParam("@SV_SinhVien_KyLuatID",SqlDbType.Int,pSV_SinhVien_KyLuatInfo.SV_SinhVien_KyLuatID));

            RunProcedure("sp_SV_SinhVien_KyLuat_Update", colParam);
        }
        
        public void Delete(SV_SinhVien_KyLuatInfo pSV_SinhVien_KyLuatInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_SinhVien_KyLuatID",SqlDbType.Int,pSV_SinhVien_KyLuatInfo.SV_SinhVien_KyLuatID));

            RunProcedure("sp_SV_SinhVien_KyLuat_Delete", colParam);
        }
    }
}
