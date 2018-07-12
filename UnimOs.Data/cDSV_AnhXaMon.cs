using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_AnhXaMon : cDBase
    {
        public DataTable GetMonLopCu(int IDSV_SinhVien, int IDDM_Lop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));

            return RunProcedureGet("sp_SV_AnhXaMon_GetMonLopCu", colParam);
        }
        public DataTable GetMonLopMoi(int IDSV_SinhVien, int IDDM_Lop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));

            return RunProcedureGet("sp_SV_AnhXaMon_GetMonLopMoi", colParam);
        }
        public DataTable GetChiTiet(int IDSV_SinhVien, int IDDM_Lop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));

            return RunProcedureGet("sp_SV_AnhXaMon_GetChiTiet", colParam);
        }
        public void ApDung(string ChuoiID, int IDSV_SinhVien, int IDDM_Lop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@ChuoiID", SqlDbType.VarChar,1000, ChuoiID));
            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));

            RunProcedure("sp_SV_AnhXaMon_ApDung", colParam);
        }
    }
}
