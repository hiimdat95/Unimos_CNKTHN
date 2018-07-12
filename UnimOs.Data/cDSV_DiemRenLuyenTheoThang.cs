using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_DiemRenLuyenTheoThang : cDBase
    {
        public DataTable GetByLop(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_SV_DiemRenLuyenTheoThang_GetByLop", colParam);
        }

        public void UpdateChange(SV_DiemRenLuyenTheoThangInfo pSV_DiemRenLuyenTheoThangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, pSV_DiemRenLuyenTheoThangInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDSV_ThangRenLuyenTrongKy", SqlDbType.Int, pSV_DiemRenLuyenTheoThangInfo.IDSV_ThangRenLuyenTrongKy));
            colParam.Add(CreateParam("@SoDiem", SqlDbType.Float, pSV_DiemRenLuyenTheoThangInfo.SoDiem));
            colParam.Add(CreateParam("@IDDM_XepLoaiRenLuyen", SqlDbType.Int, pSV_DiemRenLuyenTheoThangInfo.IDDM_XepLoaiRenLuyen));
            colParam.Add(CreateParam("@NhanXet", SqlDbType.NVarChar, pSV_DiemRenLuyenTheoThangInfo.NhanXet));

            RunProcedure("sp_SV_DiemRenLuyenTheoThang_UpdateChange", colParam);
        }
    }
}
