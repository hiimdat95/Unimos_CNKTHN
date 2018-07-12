using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_SinhVien_GiayToNhapTruong : cDBase
    {
        public DataTable GetBySinhVien(int IDSV_SinhVienNhapTruong)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVienNhapTruong", SqlDbType.Int, IDSV_SinhVienNhapTruong));

            return RunProcedureGet("sp_SV_SinhVien_GiayToNhapTruong_GetBySinhVien", colParam);
        }

        public int AddGiayTo(SV_SinhVien_GiayToNhapTruongInfo pSV_SinhVien_GiayToNhapTruongInfo, bool DaNop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DaNop", SqlDbType.Bit, DaNop));
            colParam.Add(CreateParam("@IDSV_SinhVienNhapTruong", SqlDbType.Int, pSV_SinhVien_GiayToNhapTruongInfo.IDSV_SinhVienNhapTruong));
            colParam.Add(CreateParam("@IDDM_GiayToNhapTruong", SqlDbType.Int, pSV_SinhVien_GiayToNhapTruongInfo.IDDM_GiayToNhapTruong));
            colParam.Add(CreateParam("@GhiChu", SqlDbType.NVarChar, pSV_SinhVien_GiayToNhapTruongInfo.GhiChu));
            colParam.Add(CreateParam("@DaTra", SqlDbType.Bit, pSV_SinhVien_GiayToNhapTruongInfo.DaTra));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_SV_SinhVien_GiayToNhapTruong_AddGiayTo", colParam);
        }
    }
}
