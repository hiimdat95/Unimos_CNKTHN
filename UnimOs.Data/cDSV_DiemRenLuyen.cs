using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_DiemRenLuyen : cDBase
    {
        public DataTable GetByLop(int IDDM_Lop, int IDDM_NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));

            return RunProcedureGet("sp_SV_DiemRenLuyen_GetByLop", colParam);
        }

        public void UpdateChange(int IDSV_SinhVien, int IDDM_NamHoc, int HocKy, double SoDiem, int IDDM_XepLoaiRenLuyen, string NhanXet)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@SoDiem", SqlDbType.Float, SoDiem));
            colParam.Add(CreateParam("@IDDM_XepLoaiRenLuyen", SqlDbType.Int, IDDM_XepLoaiRenLuyen));
            colParam.Add(CreateParam("@NhanXet", SqlDbType.NVarChar, NhanXet));

            RunProcedure("sp_SV_DiemRenLuyen_UpdateChange", colParam);
        }
    }
}
