using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_SinhVien_KhenThuong : cDBase
    {
        public DataTable Get(SV_SinhVien_KhenThuongInfo pSV_SinhVien_KhenThuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_SinhVien_KhenThuongID",SqlDbType.Int,pSV_SinhVien_KhenThuongInfo.SV_SinhVien_KhenThuongID));

            return RunProcedureGet("sp_SV_SinhVien_KhenThuong_Get", colParam);            
        }

        public int Add(SV_SinhVien_KhenThuongInfo pSV_SinhVien_KhenThuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_SinhVien_KhenThuongInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDSV_QuyetDinhKhenThuong",SqlDbType.Int,pSV_SinhVien_KhenThuongInfo.IDSV_QuyetDinhKhenThuong));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_SV_SinhVien_KhenThuong_Add", colParam);
        }
        
        public void Update(SV_SinhVien_KhenThuongInfo pSV_SinhVien_KhenThuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_SinhVien_KhenThuongInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDSV_QuyetDinhKhenThuong",SqlDbType.Int,pSV_SinhVien_KhenThuongInfo.IDSV_QuyetDinhKhenThuong));
            colParam.Add(CreateParam("@SV_SinhVien_KhenThuongID",SqlDbType.Int,pSV_SinhVien_KhenThuongInfo.SV_SinhVien_KhenThuongID));

            RunProcedure("sp_SV_SinhVien_KhenThuong_Update", colParam);
        }
        
        public void Delete(SV_SinhVien_KhenThuongInfo pSV_SinhVien_KhenThuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_SinhVien_KhenThuongID",SqlDbType.Int,pSV_SinhVien_KhenThuongInfo.SV_SinhVien_KhenThuongID));

            RunProcedure("sp_SV_SinhVien_KhenThuong_Delete", colParam);
        }
    }
}
