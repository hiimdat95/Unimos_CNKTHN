using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_DanhSachMienGiam_ChiTiet : cDBase
    {
        public void DeleteBy_MienGiam(int IDTC_DanhSachMienGiam)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTC_DanhSachMienGiam", SqlDbType.Int, IDTC_DanhSachMienGiam));

            RunProcedure("sp_TC_DinhMucThuSinhVien_ChiTiet_DeleteBy_MienGiam", colParam);
        }
    }
}
