using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_PhongHoc : cDBase
    {
        public DataTable Get_TKB()
        {
            ArrayList colParam = new ArrayList();

            //colParam.Add(CreateParam("@PhongHocID", SqlDbType.Int, 0));

            return RunProcedureGet("sp_DM_PhongHoc_Get_TKB", colParam);
        }

        public DataTable GetAll()
        {
            ArrayList colParam = new ArrayList();

            return RunProcedureGet("sp_DM_PhongHoc_GetAll", colParam);
        }

        public DataTable GetChon(int IDToaNha, string mPhongHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_ToaNha", SqlDbType.Int, IDToaNha));
            colParam.Add(CreateParam("@IDPhongHocNotIn", SqlDbType.NVarChar, mPhongHoc));

            return RunProcedureGet("sp_DM_PhongHoc_GetChon", colParam);
        }

        public DataTable GetTreePhongHoc()
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@pIDToaNha", SqlDbType.Int, 0));

            return RunProcedureGet("sp_DM_PhongHoc_GetByToaNha", colParam);
        }

        public DataTable GetByIDToaNha(int IDDM_ToaNha)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_ToaNha", SqlDbType.Int, IDDM_ToaNha));

            return RunProcedureGet("sp_DM_PhongHoc_GetByIDToaNha", colParam);
        }

        public DataTable GetKeHoachThucHanh(int IDDM_NamHoc, string NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@NamHoc", SqlDbType.NVarChar, NamHoc));

            return RunProcedureGet("sp_DM_PhongHoc_GetKeHoachThucHanh", colParam);
        }
    }
}
