using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_PhanBoQuyHocBong : cDBase
    {
        public DataTable GetByQuyHocBong(int IDTC_QuyHocBong, int IDDM_NamHoc, int HOcKy, int PhanDacBiet)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTC_QuyHocBong", SqlDbType.Int, IDTC_QuyHocBong));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HOcKy", SqlDbType.Int, HOcKy));
            colParam.Add(CreateParam("@PhanDacBiet", SqlDbType.Int, PhanDacBiet));

            return RunProcedureGet("sp_TC_PhanBoQuyHocBong_GetByQuyHocBong", colParam);
        }

        public DataTable GetDoiTuong(int KHoa, int KhoaHOc, int Nganh, int Lop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KHoa", SqlDbType.Int, KHoa));
            colParam.Add(CreateParam("@KhoaHOc", SqlDbType.Int, KhoaHOc));
            colParam.Add(CreateParam("@Nganh", SqlDbType.Int, Nganh));
            colParam.Add(CreateParam("@Lop", SqlDbType.Int, Lop));

            return RunProcedureGet("sp_TC_PhanBoQuyHocBong_GetDoiTuong", colParam);
        }

        public void DeleteBy_QuyHocBong(int IDTC_QuyHocBong, int HocKy, int IDDM_NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTC_QuyHocBong", SqlDbType.Int, IDTC_QuyHocBong));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));

            RunProcedure("sp_TC_PhanBoQuyHocBong_DeleteBy_QuyHocBong", colParam);
        }
    }
}
