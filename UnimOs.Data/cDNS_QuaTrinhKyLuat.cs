using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_QuaTrinhKyLuat : cDBase
    {
        public DataTable GetBy_IDNS_GiaoVien(int IDNS_GiaoVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));

            return RunProcedureGet("sp_NS_QuaTrinhKyLuat_GetBy_IDNS_GiaoVien", colParam);
        }

        public void UpdateBy_NSQuaTrinhKyLuatID(bool XoaKyLuat, DateTime NgayXoa, string LyDoXoa, bool XoaTangSoThangTangLuong, int NS_QuaTrinhKyLuatID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XoaKyLuat", SqlDbType.Bit, XoaKyLuat));
            colParam.Add(CreateParam("@NgayXoa", SqlDbType.DateTime, NgayXoa));
            colParam.Add(CreateParam("@LyDoXoa", SqlDbType.NVarChar, LyDoXoa));
            colParam.Add(CreateParam("@XoaTangSoThangTangLuong", SqlDbType.Bit, XoaTangSoThangTangLuong));
            colParam.Add(CreateParam("@NS_QuaTrinhKyLuatID", SqlDbType.Int, NS_QuaTrinhKyLuatID));

            RunProcedure("sp_NS_QuaTrinhKyLuat_UpdateBy_NSQuaTrinhKyLuatID", colParam);
        }
    }
}
