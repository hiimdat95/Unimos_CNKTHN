using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_SinhVien_ThongTinKhac : cDBase
    {
        public DataTable Get(SV_SinhVien_ThongTinKhacInfo pSV_SinhVien_ThongTinKhacInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_SinhVien_ThongTinKhacID",SqlDbType.Int,pSV_SinhVien_ThongTinKhacInfo.SV_SinhVien_ThongTinKhacID));

            return RunProcedureGet("sp_SV_SinhVien_ThongTinKhac_Get", colParam);            
        }

        public int Add(SV_SinhVien_ThongTinKhacInfo pSV_SinhVien_ThongTinKhacInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_SinhVien_ThongTinKhacInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@KhenThuongKyLuat",SqlDbType.NVarChar,pSV_SinhVien_ThongTinKhacInfo.KhenThuongKyLuat));
            colParam.Add(CreateParam("@QuaTrinhHocTapCongTac",SqlDbType.NVarChar,pSV_SinhVien_ThongTinKhacInfo.QuaTrinhHocTapCongTac));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_SV_SinhVien_ThongTinKhac_Add", colParam);
        }
        
        public void Update(SV_SinhVien_ThongTinKhacInfo pSV_SinhVien_ThongTinKhacInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_SinhVien_ThongTinKhacInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@KhenThuongKyLuat",SqlDbType.NVarChar,pSV_SinhVien_ThongTinKhacInfo.KhenThuongKyLuat));
            colParam.Add(CreateParam("@QuaTrinhHocTapCongTac",SqlDbType.NVarChar,pSV_SinhVien_ThongTinKhacInfo.QuaTrinhHocTapCongTac));
            colParam.Add(CreateParam("@SV_SinhVien_ThongTinKhacID",SqlDbType.Int,pSV_SinhVien_ThongTinKhacInfo.SV_SinhVien_ThongTinKhacID));

            RunProcedure("sp_SV_SinhVien_ThongTinKhac_Update", colParam);
        }
        
        public void Delete(SV_SinhVien_ThongTinKhacInfo pSV_SinhVien_ThongTinKhacInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_SinhVien_ThongTinKhacID",SqlDbType.Int,pSV_SinhVien_ThongTinKhacInfo.SV_SinhVien_ThongTinKhacID));

            RunProcedure("sp_SV_SinhVien_ThongTinKhac_Delete", colParam);
        }
    }
}
