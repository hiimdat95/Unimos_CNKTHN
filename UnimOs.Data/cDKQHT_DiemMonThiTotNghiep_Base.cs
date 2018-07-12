using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DiemMonThiTotNghiep : cDBase
    {
        public DataTable Get(KQHT_DiemMonThiTotNghiepInfo pKQHT_DiemMonThiTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DiemMonThiTotNghiepID",SqlDbType.BigInt,pKQHT_DiemMonThiTotNghiepInfo.KQHT_DiemMonThiTotNghiepID));

            return RunProcedureGet("sp_KQHT_DiemMonThiTotNghiep_Get", colParam);            
        }

        public long Add(KQHT_DiemMonThiTotNghiepInfo pKQHT_DiemMonThiTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DiemMonThiTotNghiepInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDKQHT_MonThiTotNghiep_Lop",SqlDbType.Int,pKQHT_DiemMonThiTotNghiepInfo.IDKQHT_MonThiTotNghiep_Lop));
            colParam.Add(CreateParam("@LanThi",SqlDbType.Int,pKQHT_DiemMonThiTotNghiepInfo.LanThi));
            colParam.Add(CreateParam("@Diem",SqlDbType.Real,pKQHT_DiemMonThiTotNghiepInfo.Diem));
            colParam.Add(CreateParam("@IDKQHT_XepLoai",SqlDbType.Int,pKQHT_DiemMonThiTotNghiepInfo.IDKQHT_XepLoai));
            colParam.Add(CreateParamOut("@ID", SqlDbType.BigInt));

            return (long)RunProcedureOut("sp_KQHT_DiemMonThiTotNghiep_Add", colParam);
        }
        
        public void Update(KQHT_DiemMonThiTotNghiepInfo pKQHT_DiemMonThiTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DiemMonThiTotNghiepInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDKQHT_MonThiTotNghiep_Lop",SqlDbType.Int,pKQHT_DiemMonThiTotNghiepInfo.IDKQHT_MonThiTotNghiep_Lop));
            colParam.Add(CreateParam("@LanThi",SqlDbType.Int,pKQHT_DiemMonThiTotNghiepInfo.LanThi));
            colParam.Add(CreateParam("@Diem",SqlDbType.Real,pKQHT_DiemMonThiTotNghiepInfo.Diem));
            colParam.Add(CreateParam("@IDKQHT_XepLoai",SqlDbType.Int,pKQHT_DiemMonThiTotNghiepInfo.IDKQHT_XepLoai));
            colParam.Add(CreateParam("@KQHT_DiemMonThiTotNghiepID",SqlDbType.BigInt,pKQHT_DiemMonThiTotNghiepInfo.KQHT_DiemMonThiTotNghiepID));

            RunProcedure("sp_KQHT_DiemMonThiTotNghiep_Update", colParam);
        }
        
        public void Delete(KQHT_DiemMonThiTotNghiepInfo pKQHT_DiemMonThiTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DiemMonThiTotNghiepID",SqlDbType.BigInt,pKQHT_DiemMonThiTotNghiepInfo.KQHT_DiemMonThiTotNghiepID));

            RunProcedure("sp_KQHT_DiemMonThiTotNghiep_Delete", colParam);
        }
    }
}
