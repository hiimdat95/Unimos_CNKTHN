using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_PhanCongGiaoVien : cDBase
    {
        public void DeleteByMonHoc(int IDXL_MonHocTrongKy, string IDNS_GiaoViens)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@IDNS_GiaoViens", SqlDbType.VarChar,100, IDNS_GiaoViens));

            RunProcedure("sp_XL_PhanCongGiaoVien_DeleteByMonHoc", colParam);
        }

        public DataTable GetByMonHocTrongKy(int IDXL_MonHocTrongKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, IDXL_MonHocTrongKy));

            return RunProcedureGet("sp_XL_PhanCongGiaoVien_GetByMonHocTrongKy", colParam);
        }

        public DataTable GetGiaoVien(int IDXL_MonHocTrongKy, int IDNS_GiaoVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));

            return RunProcedureGet("sp_XL_PhanCongGiaoVien_GetGiaoVien", colParam);
        }

        public DataTable GetGiaoVienByMonHocTrongKy(int IDXL_MonHocTrongKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, IDXL_MonHocTrongKy));

            return RunProcedureGet("sp_XL_PhanCongGiaoVien_GetGiaoVienByMonHocTrongKy", colParam);
        }
    }
}
