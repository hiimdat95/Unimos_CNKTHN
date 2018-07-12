using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DiemThanhPhan : cDBase
    {
        public DataTable Get(KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DiemThanhPhanID",SqlDbType.BigInt,pKQHT_DiemThanhPhanInfo.KQHT_DiemThanhPhanID));

            return RunProcedureGet("sp_KQHT_DiemThanhPhan_Get", colParam);            
        }

        public int Add(KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DiemThanhPhanInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_DiemThanhPhanInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_DiemThanhPhanInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_DiemThanhPhanInfo.HocKy));
            colParam.Add(CreateParam("@IDKQHT_ThanhPhanDiem",SqlDbType.Int,pKQHT_DiemThanhPhanInfo.IDKQHT_ThanhPhanDiem));
            colParam.Add(CreateParam("@DiemThu", SqlDbType.Int, pKQHT_DiemThanhPhanInfo.DiemThu));
            colParam.Add(CreateParam("@Diem",SqlDbType.Real,pKQHT_DiemThanhPhanInfo.Diem));
            colParam.Add(CreateParam("@LyDo",SqlDbType.NVarChar,pKQHT_DiemThanhPhanInfo.LyDo));
            colParam.Add(CreateParam("@IDHT_User",SqlDbType.Int,pKQHT_DiemThanhPhanInfo.IDHT_User));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, pKQHT_DiemThanhPhanInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@DiemLan", SqlDbType.Int, pKQHT_DiemThanhPhanInfo.DiemLan));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_DiemThanhPhan_Add", colParam);
        }
        
        public void Update(KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DiemThanhPhanInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_DiemThanhPhanInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_DiemThanhPhanInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_DiemThanhPhanInfo.HocKy));
            colParam.Add(CreateParam("@IDKQHT_ThanhPhanDiem",SqlDbType.Int,pKQHT_DiemThanhPhanInfo.IDKQHT_ThanhPhanDiem));
            colParam.Add(CreateParam("@DiemThu", SqlDbType.Int, pKQHT_DiemThanhPhanInfo.DiemThu));
            colParam.Add(CreateParam("@Diem",SqlDbType.Real,pKQHT_DiemThanhPhanInfo.Diem));
            colParam.Add(CreateParam("@LyDo",SqlDbType.NVarChar,pKQHT_DiemThanhPhanInfo.LyDo));
            colParam.Add(CreateParam("@IDHT_User",SqlDbType.Int,pKQHT_DiemThanhPhanInfo.IDHT_User));
            colParam.Add(CreateParam("@KQHT_DiemThanhPhanID",SqlDbType.BigInt,pKQHT_DiemThanhPhanInfo.KQHT_DiemThanhPhanID));

            RunProcedure("sp_KQHT_DiemThanhPhan_Update", colParam);
        }
        
        public void Delete(KQHT_DiemThanhPhanInfo pKQHT_DiemThanhPhanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DiemThanhPhanID",SqlDbType.BigInt,pKQHT_DiemThanhPhanInfo.KQHT_DiemThanhPhanID));

            RunProcedure("sp_KQHT_DiemThanhPhan_Delete", colParam);
        }
    }
}
