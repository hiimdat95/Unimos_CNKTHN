using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DangKyHocLai : cDBase
    {
        public DataTable Get(KQHT_DangKyHocLaiInfo pKQHT_DangKyHocLaiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DangKyHocLaiID",SqlDbType.Int,pKQHT_DangKyHocLaiInfo.KQHT_DangKyHocLaiID));

            return RunProcedureGet("sp_KQHT_DangKyHocLai_Get", colParam);            
        }

        public int Add(KQHT_DangKyHocLaiInfo pKQHT_DangKyHocLaiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DangKyHocLaiInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_DangKyHocLaiInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_DangKyHocLaiInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_DangKyHocLaiInfo.HocKy));
            colParam.Add(CreateParam("@IDDM_LopDangKy",SqlDbType.Int,pKQHT_DangKyHocLaiInfo.IDDM_LopDangKy));
            colParam.Add(CreateParam("@IDKQHT_LopHocLai", SqlDbType.Int, pKQHT_DangKyHocLaiInfo.IDKQHT_LopHocLai));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pKQHT_DangKyHocLaiInfo.GhiChu));
            colParam.Add(CreateParam("@TienLePhi",SqlDbType.Money,pKQHT_DangKyHocLaiInfo.TienLePhi));
            colParam.Add(CreateParam("@IDHT_User",SqlDbType.Int,pKQHT_DangKyHocLaiInfo.IDHT_User));
            colParam.Add(CreateParam("@NgayDangKy",SqlDbType.DateTime,pKQHT_DangKyHocLaiInfo.NgayDangKy));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, pKQHT_DangKyHocLaiInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@SoTietHocLai", SqlDbType.Int, pKQHT_DangKyHocLaiInfo.SoTietHocLai));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_DangKyHocLai_Add", colParam);
        }
        
        public void Update(KQHT_DangKyHocLaiInfo pKQHT_DangKyHocLaiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DangKyHocLaiInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_DangKyHocLaiInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_DangKyHocLaiInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_DangKyHocLaiInfo.HocKy));
            colParam.Add(CreateParam("@IDDM_LopDangKy",SqlDbType.Int,pKQHT_DangKyHocLaiInfo.IDDM_LopDangKy));
            colParam.Add(CreateParam("@IDKQHT_LopHocLai", SqlDbType.Int, pKQHT_DangKyHocLaiInfo.IDKQHT_LopHocLai));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pKQHT_DangKyHocLaiInfo.GhiChu));
            colParam.Add(CreateParam("@TienLePhi",SqlDbType.Money,pKQHT_DangKyHocLaiInfo.TienLePhi));
            colParam.Add(CreateParam("@IDHT_User",SqlDbType.Int,pKQHT_DangKyHocLaiInfo.IDHT_User));
            colParam.Add(CreateParam("@NgayDangKy",SqlDbType.DateTime,pKQHT_DangKyHocLaiInfo.NgayDangKy));
            colParam.Add(CreateParam("@SoTietHocLai", SqlDbType.Int, pKQHT_DangKyHocLaiInfo.SoTietHocLai));
            colParam.Add(CreateParam("@KQHT_DangKyHocLaiID",SqlDbType.Int,pKQHT_DangKyHocLaiInfo.KQHT_DangKyHocLaiID));

            RunProcedure("sp_KQHT_DangKyHocLai_Update", colParam);
        }
        
        public void Delete(KQHT_DangKyHocLaiInfo pKQHT_DangKyHocLaiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DangKyHocLaiID",SqlDbType.Int,pKQHT_DangKyHocLaiInfo.KQHT_DangKyHocLaiID));

            RunProcedure("sp_KQHT_DangKyHocLai_Delete", colParam);
        }
    }
}
