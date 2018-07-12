using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_HoiDongMon_Diem : cDBase
    {
        public DataTable Get(KQHT_HoiDongMon_DiemInfo pKQHT_HoiDongMon_DiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_HoiDongMon_DiemID",SqlDbType.BigInt,pKQHT_HoiDongMon_DiemInfo.KQHT_HoiDongMon_DiemID));

            return RunProcedureGet("sp_KQHT_HoiDongMon_Diem_Get", colParam);            
        }

        public int Add(KQHT_HoiDongMon_DiemInfo pKQHT_HoiDongMon_DiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_HoiDongMon_ChiTiet",SqlDbType.Int,pKQHT_HoiDongMon_DiemInfo.IDKQHT_HoiDongMon_ChiTiet));
            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_HoiDongMon_DiemInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@Diem",SqlDbType.Real,pKQHT_HoiDongMon_DiemInfo.Diem));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_HoiDongMon_Diem_Add", colParam);
        }
        
        public void Update(KQHT_HoiDongMon_DiemInfo pKQHT_HoiDongMon_DiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_HoiDongMon_ChiTiet",SqlDbType.Int,pKQHT_HoiDongMon_DiemInfo.IDKQHT_HoiDongMon_ChiTiet));
            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_HoiDongMon_DiemInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@Diem",SqlDbType.Real,pKQHT_HoiDongMon_DiemInfo.Diem));
            colParam.Add(CreateParam("@KQHT_HoiDongMon_DiemID",SqlDbType.BigInt,pKQHT_HoiDongMon_DiemInfo.KQHT_HoiDongMon_DiemID));

            RunProcedure("sp_KQHT_HoiDongMon_Diem_Update", colParam);
        }
        
        public void Delete(KQHT_HoiDongMon_DiemInfo pKQHT_HoiDongMon_DiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_HoiDongMon_DiemID",SqlDbType.BigInt,pKQHT_HoiDongMon_DiemInfo.KQHT_HoiDongMon_DiemID));

            RunProcedure("sp_KQHT_HoiDongMon_Diem_Delete", colParam);
        }
    }
}
