using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DangKyThiLai : cDBase
    {
        public DataTable Get(KQHT_DangKyThiLaiInfo pKQHT_DangKyThiLaiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DangKyThiLaiID",SqlDbType.Int,pKQHT_DangKyThiLaiInfo.KQHT_DangKyThiLaiID));

            return RunProcedureGet("sp_KQHT_DangKyThiLai_Get", colParam);            
        }

        public int Add(KQHT_DangKyThiLaiInfo pKQHT_DangKyThiLaiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DangKyThiLaiInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_DangKyThiLaiInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_DangKyThiLaiInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_DangKyThiLaiInfo.HocKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, pKQHT_DangKyThiLaiInfo.LanThi));
            colParam.Add(CreateParam("@IDKQHT_ToChucThi",SqlDbType.Int,pKQHT_DangKyThiLaiInfo.IDKQHT_ToChucThi));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pKQHT_DangKyThiLaiInfo.GhiChu));
            colParam.Add(CreateParam("@TienLePhi",SqlDbType.Money,pKQHT_DangKyThiLaiInfo.TienLePhi));
            colParam.Add(CreateParam("@IDHT_User",SqlDbType.Int,pKQHT_DangKyThiLaiInfo.IDHT_User));
            colParam.Add(CreateParam("@NgayDangKy",SqlDbType.DateTime,pKQHT_DangKyThiLaiInfo.NgayDangKy));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_DangKyThiLai_Add", colParam);
        }
        
        public void Update(KQHT_DangKyThiLaiInfo pKQHT_DangKyThiLaiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DangKyThiLaiInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_DangKyThiLaiInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_DangKyThiLaiInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_DangKyThiLaiInfo.HocKy));
            colParam.Add(CreateParam("@IDKQHT_ToChucThi",SqlDbType.Int,pKQHT_DangKyThiLaiInfo.IDKQHT_ToChucThi));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pKQHT_DangKyThiLaiInfo.GhiChu));
            colParam.Add(CreateParam("@TienLePhi",SqlDbType.Money,pKQHT_DangKyThiLaiInfo.TienLePhi));
            colParam.Add(CreateParam("@IDHT_User",SqlDbType.Int,pKQHT_DangKyThiLaiInfo.IDHT_User));
            colParam.Add(CreateParam("@NgayDangKy",SqlDbType.DateTime,pKQHT_DangKyThiLaiInfo.NgayDangKy));
            colParam.Add(CreateParam("@KQHT_DangKyThiLaiID",SqlDbType.Int,pKQHT_DangKyThiLaiInfo.KQHT_DangKyThiLaiID));

            RunProcedure("sp_KQHT_DangKyThiLai_Update", colParam);
        }
        
        public void Delete(KQHT_DangKyThiLaiInfo pKQHT_DangKyThiLaiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DangKyThiLaiID",SqlDbType.Int,pKQHT_DangKyThiLaiInfo.KQHT_DangKyThiLaiID));

            RunProcedure("sp_KQHT_DangKyThiLai_Delete", colParam);
        }
    }
}
