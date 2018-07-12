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
        public void UpdateHoSo(SV_SinhVien_ThongTinKhacInfo pSV_SinhVien_ThongTinKhacInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, pSV_SinhVien_ThongTinKhacInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@KhenThuongKyLuat", SqlDbType.NVarChar, pSV_SinhVien_ThongTinKhacInfo.KhenThuongKyLuat));
            colParam.Add(CreateParam("@QuaTrinhHocTapCongTac", SqlDbType.NVarChar, pSV_SinhVien_ThongTinKhacInfo.QuaTrinhHocTapCongTac));

            RunProcedure("sp_SV_SinhVien_ThongTinKhac_UpdateHoSo", colParam);
        }
    }
}
