using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_GiaoVien_MonHoc : cDBase
    {
        public DataTable GetDanhSach(XL_GiaoVien_MonHocInfo pXL_GiaoVien_MonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, pXL_GiaoVien_MonHocInfo.IDNS_GiaoVien));

            return RunProcedureGet("sp_XL_GiaoVien_MonHoc_GetDanhSach", colParam);
        }

        public DataTable GetByIDDM_MonHoc(int IDDM_MonHoc, string IDNS_GiaoVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.NVarChar, IDNS_GiaoVien));

            return RunProcedureGet("sp_XL_GiaoVien_MonHoc_GetByIDDM_MonHoc", colParam);
        }

        public DataTable GetByIDDM_MonHocs(string IDDM_MonHocs)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_MonHocs", SqlDbType.NVarChar, IDDM_MonHocs));

            return RunProcedureGet("sp_XL_GiaoVien_MonHoc_GetByIDDM_MonHocs", colParam);
        }

        public DataTable GetByMonLop(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_XL_GiaoVien_MonHoc_GetByMonLop", colParam);
        }
    }
}
