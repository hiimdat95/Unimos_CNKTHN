using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DiemTongKetMon : cDBase
    {
        public DataTable Get(KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DiemTongKetMonID", SqlDbType.BigInt, pKQHT_DiemTongKetMonInfo.KQHT_DiemTongKetMonID));

            return RunProcedureGet("sp_KQHT_DiemTongKetMon_Get", colParam);            
        }

        public void Add(KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DiemTongKetMonInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_DiemTongKetMonInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_DiemTongKetMonInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_DiemTongKetMonInfo.HocKy));
            colParam.Add(CreateParam("@LanThi",SqlDbType.Int,pKQHT_DiemTongKetMonInfo.LanThi));
            colParam.Add(CreateParam("@Diem",SqlDbType.Real,pKQHT_DiemTongKetMonInfo.Diem));
            colParam.Add(CreateParam("@LyDo",SqlDbType.NVarChar,pKQHT_DiemTongKetMonInfo.LyDo));
            colParam.Add(CreateParam("@IDKQHT_XepLoai",SqlDbType.Int,pKQHT_DiemTongKetMonInfo.IDKQHT_XepLoai));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, pKQHT_DiemTongKetMonInfo.IDXL_MonHocTrongKy));

            RunProcedure("sp_KQHT_DiemTongKetMon_Add", colParam);
        }
        
        public void Update(KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DiemTongKetMonInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_DiemTongKetMonInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_DiemTongKetMonInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_DiemTongKetMonInfo.HocKy));
            colParam.Add(CreateParam("@LanThi",SqlDbType.Int,pKQHT_DiemTongKetMonInfo.LanThi));
            colParam.Add(CreateParam("@Diem",SqlDbType.Real,pKQHT_DiemTongKetMonInfo.Diem));
            colParam.Add(CreateParam("@LyDo",SqlDbType.NVarChar,pKQHT_DiemTongKetMonInfo.LyDo));
            colParam.Add(CreateParam("@IDKQHT_XepLoai",SqlDbType.Int,pKQHT_DiemTongKetMonInfo.IDKQHT_XepLoai));
            colParam.Add(CreateParam("@KQHT_DiemTongKetMonID",SqlDbType.BigInt,pKQHT_DiemTongKetMonInfo.KQHT_DiemTongKetMonID));

            RunProcedure("sp_KQHT_DiemTongKetMon_Update", colParam);
        }
        
        public void Delete(KQHT_DiemTongKetMonInfo pKQHT_DiemTongKetMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DiemTongKetMonID",SqlDbType.BigInt,pKQHT_DiemTongKetMonInfo.KQHT_DiemTongKetMonID));

            RunProcedure("sp_KQHT_DiemTongKetMon_Delete", colParam);
        }
    }
}
