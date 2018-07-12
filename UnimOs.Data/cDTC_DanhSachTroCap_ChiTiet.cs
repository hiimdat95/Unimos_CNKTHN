using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_DanhSachTroCap_ChiTiet : cDBase
    {
        public void DeleteBy_TroCap(int IDTC_DanhSachTroCap)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTC_DanhSachTroCap", SqlDbType.Int, IDTC_DanhSachTroCap));

            RunProcedure("sp_TC_DinhMucThuSinhVien_ChiTiet_DeleteBy_TroCap", colParam);
        }
    }
}
