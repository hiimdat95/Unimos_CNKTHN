using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_KeHoachTruong : cDBase
    {
        public DataTable GetByIDTuan(long IDXL_Tuan)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_Tuan", SqlDbType.BigInt, IDXL_Tuan));

            return RunProcedureGet("sp_XL_KeHoachTruong_GetByIDTuan", colParam);
        }
        public void UpdatePhongHoc(long IDXL_TuTuan, long IDXL_DenTuan, int IDDM_PhongHoc, int IDDM_Lop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_TuTuan", SqlDbType.BigInt, IDXL_TuTuan));
            colParam.Add(CreateParam("@IDXL_DenTuan", SqlDbType.BigInt, IDXL_DenTuan));
            colParam.Add(CreateParam("@IDDM_PhongHoc", SqlDbType.Int, IDDM_PhongHoc));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));

            RunProcedure("sp_XL_KeHoachTruong_UpdatePhongHoc", colParam);
        }
        public int CheckAddPhongHoc(long IDXL_TuTuan, long IDXL_DenTuan, int IDDM_PhongHoc, int IDDM_Lop, int CaHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_TuTuan", SqlDbType.BigInt, IDXL_TuTuan));
            colParam.Add(CreateParam("@IDXL_DenTuan", SqlDbType.BigInt, IDXL_DenTuan));
            colParam.Add(CreateParam("@IDDM_PhongHoc", SqlDbType.Int, IDDM_PhongHoc));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@CaHoc", SqlDbType.Int, CaHoc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_KeHoachTruong_CheckAddPhongHoc", colParam);
        }

        
    }
}
