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
        public DataTable Get(KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_ChuongTrinhDaoTaoID",SqlDbType.Int,pKQHT_ChuongTrinhDaoTaoInfo.KQHT_ChuongTrinhDaoTaoID));

            return RunProcedureGet("sp_KQHT_ChuongTrinhDaoTao_Get", colParam);            
        }

        public int Add(KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaChuongTrinhDaoTao",SqlDbType.NVarChar,pKQHT_ChuongTrinhDaoTaoInfo.MaChuongTrinhDaoTao));
            colParam.Add(CreateParam("@TenChuongTrinhDaoTao",SqlDbType.NVarChar,pKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao));
            colParam.Add(CreateParam("@IDDM_TrinhDo",SqlDbType.Int,pKQHT_ChuongTrinhDaoTaoInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Nganh",SqlDbType.Int,pKQHT_ChuongTrinhDaoTaoInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_ChuyenNganh",SqlDbType.Int,pKQHT_ChuongTrinhDaoTaoInfo.IDDM_ChuyenNganh));
            colParam.Add(CreateParam("@IDDM_KhoaHoc",SqlDbType.Int,pKQHT_ChuongTrinhDaoTaoInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@ChuongTrinhDaoTaoSo",SqlDbType.Int,pKQHT_ChuongTrinhDaoTaoInfo.ChuongTrinhDaoTaoSo));
            colParam.Add(CreateParam("@SoHocKy",SqlDbType.Int,pKQHT_ChuongTrinhDaoTaoInfo.SoHocKy));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NText,pKQHT_ChuongTrinhDaoTaoInfo.MoTa));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_ChuongTrinhDaoTao_Add", colParam);
        }
        
        public void Update(KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaChuongTrinhDaoTao",SqlDbType.NVarChar,pKQHT_ChuongTrinhDaoTaoInfo.MaChuongTrinhDaoTao));
            colParam.Add(CreateParam("@TenChuongTrinhDaoTao",SqlDbType.NVarChar,pKQHT_ChuongTrinhDaoTaoInfo.TenChuongTrinhDaoTao));
            colParam.Add(CreateParam("@IDDM_TrinhDo",SqlDbType.Int,pKQHT_ChuongTrinhDaoTaoInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Nganh",SqlDbType.Int,pKQHT_ChuongTrinhDaoTaoInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_ChuyenNganh",SqlDbType.Int,pKQHT_ChuongTrinhDaoTaoInfo.IDDM_ChuyenNganh));
            colParam.Add(CreateParam("@IDDM_KhoaHoc",SqlDbType.Int,pKQHT_ChuongTrinhDaoTaoInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@ChuongTrinhDaoTaoSo",SqlDbType.Int,pKQHT_ChuongTrinhDaoTaoInfo.ChuongTrinhDaoTaoSo));
            colParam.Add(CreateParam("@SoHocKy",SqlDbType.Int,pKQHT_ChuongTrinhDaoTaoInfo.SoHocKy));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NText,pKQHT_ChuongTrinhDaoTaoInfo.MoTa));
            colParam.Add(CreateParam("@KQHT_ChuongTrinhDaoTaoID",SqlDbType.Int,pKQHT_ChuongTrinhDaoTaoInfo.KQHT_ChuongTrinhDaoTaoID));

            RunProcedure("sp_KQHT_ChuongTrinhDaoTao_Update", colParam);
        }
        
        public void Delete(KQHT_ChuongTrinhDaoTaoInfo pKQHT_ChuongTrinhDaoTaoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_ChuongTrinhDaoTaoID",SqlDbType.Int,pKQHT_ChuongTrinhDaoTaoInfo.KQHT_ChuongTrinhDaoTaoID));

            RunProcedure("sp_KQHT_ChuongTrinhDaoTao_Delete", colParam);
        }
    }
}
