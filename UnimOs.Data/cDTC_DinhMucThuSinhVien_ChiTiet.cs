using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_DinhMucThuSinhVien_ChiTiet : cDBase
    {
        public void DeleteBy_DinhMucThu(int IDTC_DinhMucThuSinhVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTC_DinhMucThuSinhVien", SqlDbType.Int, IDTC_DinhMucThuSinhVien));

            RunProcedure("sp_TC_DinhMucThuSinhVien_ChiTiet_DeleteBy_DinhMucThu", colParam);
        }
    }
}
