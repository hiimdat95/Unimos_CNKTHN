using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DiemDanh_ChiTiet : cDBase
    {
        public DataTable Get(KQHT_DiemDanh_ChiTietInfo pKQHT_DiemDanh_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DiemDanh_ChiTietID",SqlDbType.Int,pKQHT_DiemDanh_ChiTietInfo.KQHT_DiemDanh_ChiTietID));

            return RunProcedureGet("sp_KQHT_DiemDanh_ChiTiet_Get", colParam);            
        }

        public int Add(KQHT_DiemDanh_ChiTietInfo pKQHT_DiemDanh_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_DiemDanh",SqlDbType.Int,pKQHT_DiemDanh_ChiTietInfo.IDKQHT_DiemDanh));
            colParam.Add(CreateParam("@IDXL_Tuan",SqlDbType.BigInt,pKQHT_DiemDanh_ChiTietInfo.IDXL_Tuan));
            colParam.Add(CreateParam("@SoTiet",SqlDbType.Int,pKQHT_DiemDanh_ChiTietInfo.SoTiet));
            colParam.Add(CreateParam("@LyDo",SqlDbType.NVarChar,400,pKQHT_DiemDanh_ChiTietInfo.LyDo));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_DiemDanh_ChiTiet_Add", colParam);
        }
        
        public void Update(KQHT_DiemDanh_ChiTietInfo pKQHT_DiemDanh_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_DiemDanh",SqlDbType.Int,pKQHT_DiemDanh_ChiTietInfo.IDKQHT_DiemDanh));
            colParam.Add(CreateParam("@IDXL_Tuan",SqlDbType.BigInt,pKQHT_DiemDanh_ChiTietInfo.IDXL_Tuan));
            colParam.Add(CreateParam("@SoTiet", SqlDbType.Int, pKQHT_DiemDanh_ChiTietInfo.SoTiet));
            colParam.Add(CreateParam("@LyDo",SqlDbType.NVarChar,pKQHT_DiemDanh_ChiTietInfo.LyDo));
            colParam.Add(CreateParam("@KQHT_DiemDanh_ChiTietID",SqlDbType.Int,pKQHT_DiemDanh_ChiTietInfo.KQHT_DiemDanh_ChiTietID));

            RunProcedure("sp_KQHT_DiemDanh_ChiTiet_Update", colParam);
        }
        
        public void Delete(KQHT_DiemDanh_ChiTietInfo pKQHT_DiemDanh_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DiemDanh_ChiTietID",SqlDbType.Int,pKQHT_DiemDanh_ChiTietInfo.KQHT_DiemDanh_ChiTietID));

            RunProcedure("sp_KQHT_DiemDanh_ChiTiet_Delete", colParam);
        }
    }
}
