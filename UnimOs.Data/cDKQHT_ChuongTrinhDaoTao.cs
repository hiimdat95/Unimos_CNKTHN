using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_ChuongTrinhDaoTao : cDBase
    {
        public DataTable GetDanhSach(int IDDM_TrinhDo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, IDDM_TrinhDo));

            return RunProcedureGet("sp_KQHT_ChuongTrinhDaoTao_GetDanhSach", colParam);
        }

        public DataTable GetChiTiet(int KQHT_ChuongTrinhDaoTaoID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_ChuongTrinhDaoTaoID", SqlDbType.Int, KQHT_ChuongTrinhDaoTaoID));

            return RunProcedureGet("sp_KQHT_ChuongTrinhDaoTao_GetChiTiet", colParam);
        }

        public DataTable GetLop(int IDKQHT_ChuongTrinhDaoTao)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_ChuongTrinhDaoTao", SqlDbType.Int, IDKQHT_ChuongTrinhDaoTao));

            return RunProcedureGet("sp_KQHT_ChuongTrinhDaoTao_GetLop", colParam);
        }

        public DataTable GetMonKhung(int KQHT_ChuongTrinhDaoTaoID, int IDDM_Lop, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_ChuongTrinhDaoTaoID", SqlDbType.Int, KQHT_ChuongTrinhDaoTaoID));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_KQHT_ChuongTrinhDaoTao_GetMonKhung", colParam);
        }
        public DataTable GetMonChuaToChuc(int KQHT_ChuongTrinhDaoTaoID, int IDDM_Lop,int CTDT_HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_ChuongTrinhDaoTaoID", SqlDbType.Int, KQHT_ChuongTrinhDaoTaoID));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@CTDT_HocKy", SqlDbType.Int, CTDT_HocKy));

            return RunProcedureGet("sp_KQHT_ChuongTrinhDaoTao_GetMonChuaToChuc", colParam);
        }
    }
}
