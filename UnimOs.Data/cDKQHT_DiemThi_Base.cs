using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DiemThi : cDBase
    {
        public DataTable Get(KQHT_DiemThiInfo pKQHT_DiemThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DiemThiID",SqlDbType.Int,pKQHT_DiemThiInfo.KQHT_DiemThiID));

            return RunProcedureGet("sp_KQHT_DiemThi_Get", colParam);            
        }

        public int Add(KQHT_DiemThiInfo pKQHT_DiemThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DiemThiInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_DiemThiInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_DiemThiInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_DiemThiInfo.HocKy));
            colParam.Add(CreateParam("@LanThi",SqlDbType.Int,pKQHT_DiemThiInfo.LanThi));
            colParam.Add(CreateParam("@Diem",SqlDbType.Real,pKQHT_DiemThiInfo.Diem));
            colParam.Add(CreateParam("@LyDo",SqlDbType.NVarChar,pKQHT_DiemThiInfo.LyDo));
            colParam.Add(CreateParam("@IDHT_User",SqlDbType.Int,pKQHT_DiemThiInfo.IDHT_User));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, pKQHT_DiemThiInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_DiemThi_Add", colParam);
        }
        
        public void Update(KQHT_DiemThiInfo pKQHT_DiemThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DiemThiInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_DiemThiInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_DiemThiInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_DiemThiInfo.HocKy));
            colParam.Add(CreateParam("@LanThi",SqlDbType.Int,pKQHT_DiemThiInfo.LanThi));
            colParam.Add(CreateParam("@Diem",SqlDbType.Real,pKQHT_DiemThiInfo.Diem));
            colParam.Add(CreateParam("@LyDo",SqlDbType.NVarChar,pKQHT_DiemThiInfo.LyDo));
            colParam.Add(CreateParam("@IDHT_User",SqlDbType.Int,pKQHT_DiemThiInfo.IDHT_User));
            colParam.Add(CreateParam("@KQHT_DiemThiID",SqlDbType.Int,pKQHT_DiemThiInfo.KQHT_DiemThiID));

            RunProcedure("sp_KQHT_DiemThi_Update", colParam);
        }
        
        public void Delete(KQHT_DiemThiInfo pKQHT_DiemThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DiemThiID",SqlDbType.Int,pKQHT_DiemThiInfo.KQHT_DiemThiID));

            RunProcedure("sp_KQHT_DiemThi_Delete", colParam);
        }
    }
}
