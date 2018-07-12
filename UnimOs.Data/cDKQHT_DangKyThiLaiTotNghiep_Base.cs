using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DangKyThiLaiTotNghiep : cDBase
    {
        public DataTable Get(KQHT_DangKyThiLaiTotNghiepInfo pKQHT_DangKyThiLaiTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DangKyThiLaiTotNghiepID",SqlDbType.Int,pKQHT_DangKyThiLaiTotNghiepInfo.KQHT_DangKyThiLaiTotNghiepID));

            return RunProcedureGet("sp_KQHT_DangKyThiLaiTotNghiep_Get", colParam);            
        }

        public int Add(KQHT_DangKyThiLaiTotNghiepInfo pKQHT_DangKyThiLaiTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_DangKyThiLaiTotNghiepInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DangKyThiLaiTotNghiepInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_DangKyThiLaiTotNghiepInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_DangKyThiLaiTotNghiepInfo.HocKy));
            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pKQHT_DangKyThiLaiTotNghiepInfo.IDDM_Lop));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_DangKyThiLaiTotNghiep_Add", colParam);
        }
        
        public void Update(KQHT_DangKyThiLaiTotNghiepInfo pKQHT_DangKyThiLaiTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_DangKyThiLaiTotNghiepInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DangKyThiLaiTotNghiepInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_DangKyThiLaiTotNghiepInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_DangKyThiLaiTotNghiepInfo.HocKy));
            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pKQHT_DangKyThiLaiTotNghiepInfo.IDDM_Lop));
            colParam.Add(CreateParam("@KQHT_DangKyThiLaiTotNghiepID",SqlDbType.Int,pKQHT_DangKyThiLaiTotNghiepInfo.KQHT_DangKyThiLaiTotNghiepID));

            RunProcedure("sp_KQHT_DangKyThiLaiTotNghiep_Update", colParam);
        }
        
        public void Delete(KQHT_DangKyThiLaiTotNghiepInfo pKQHT_DangKyThiLaiTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DangKyThiLaiTotNghiepID",SqlDbType.Int,pKQHT_DangKyThiLaiTotNghiepInfo.KQHT_DangKyThiLaiTotNghiepID));

            RunProcedure("sp_KQHT_DangKyThiLaiTotNghiep_Delete", colParam);
        }
    }
}
