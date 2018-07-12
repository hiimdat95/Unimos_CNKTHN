using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_LopHocLai : cDBase
    {
        public DataTable Get(KQHT_LopHocLaiInfo pKQHT_LopHocLaiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_LopHocLaiID", SqlDbType.Int, pKQHT_LopHocLaiInfo.KQHT_LopHocLaiID));

            return RunProcedureGet("sp_KQHT_LopHocLai_Get", colParam);            
        }

        public int Add(KQHT_LopHocLaiInfo pKQHT_LopHocLaiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenLop",SqlDbType.NVarChar,pKQHT_LopHocLaiInfo.TenLop));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_LopHocLaiInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_LopHocLaiInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_LopHocLaiInfo.HocKy));
            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pKQHT_LopHocLaiInfo.IDNS_GiaoVien));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_LopHocLai_Add", colParam);
        }
        
        public void Update(KQHT_LopHocLaiInfo pKQHT_LopHocLaiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenLop",SqlDbType.NVarChar,pKQHT_LopHocLaiInfo.TenLop));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_LopHocLaiInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_LopHocLaiInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_LopHocLaiInfo.HocKy));
            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pKQHT_LopHocLaiInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@KQHT_LopHocLaiID", SqlDbType.Int, pKQHT_LopHocLaiInfo.KQHT_LopHocLaiID));

            RunProcedure("sp_KQHT_LopHocLai_Update", colParam);
        }
        
        public void Delete(KQHT_LopHocLaiInfo pKQHT_LopHocLaiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_LopHocLaiID", SqlDbType.Int, pKQHT_LopHocLaiInfo.KQHT_LopHocLaiID));

            RunProcedure("sp_KQHT_LopHocLai_Delete", colParam);
        }
    }
}
