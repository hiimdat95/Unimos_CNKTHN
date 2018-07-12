using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_PhongHoc_MonHoc : cDBase
    {
        public DataTable GetByIDDM_MonHoc(int IDDM_MonHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));

            return RunProcedureGet("sp_XL_PhongHoc_MonHoc_GetByIDMonHoc", colParam);
        }

        public void DeleteByMonPhong(int IDDM_PhongHoc, int IDDM_MonHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_PhongHoc", SqlDbType.Int, IDDM_PhongHoc));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));

            RunProcedure("sp_XL_PhongHoc_MonHoc_DeleteByMonPhong", colParam);
        }
    }
}
