using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_CTDT_ChiTiet : cDBase
    {
        public DataTable Get(KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_CTDT_ChiTietID",SqlDbType.BigInt,pKQHT_CTDT_ChiTietInfo.KQHT_CTDT_ChiTietID));

            return RunProcedureGet("sp_KQHT_CTDT_ChiTiet_Get", colParam);            
        }

        public int Add(KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_MonHoc_CT_KhoiKienThuc",SqlDbType.Int,pKQHT_CTDT_ChiTietInfo.IDKQHT_MonHoc_CT_KhoiKienThuc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_CTDT_ChiTietInfo.HocKy));
            colParam.Add(CreateParam("@SoTiet",SqlDbType.Int,pKQHT_CTDT_ChiTietInfo.SoTiet));
            colParam.Add(CreateParam("@LyThuyet",SqlDbType.Int,pKQHT_CTDT_ChiTietInfo.LyThuyet));
            colParam.Add(CreateParam("@ThucHanh",SqlDbType.Int,pKQHT_CTDT_ChiTietInfo.ThucHanh));
            colParam.Add(CreateParam("@LoaiTietKhac1",SqlDbType.Int,pKQHT_CTDT_ChiTietInfo.LoaiTietKhac1));
            colParam.Add(CreateParam("@LoaiTietKhac2",SqlDbType.Int,pKQHT_CTDT_ChiTietInfo.LoaiTietKhac2));
            colParam.Add(CreateParam("@SoHocTrinh",SqlDbType.Real,pKQHT_CTDT_ChiTietInfo.SoHocTrinh));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_CTDT_ChiTiet_Add", colParam);
        }
        
        public void Update(KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_MonHoc_CT_KhoiKienThuc",SqlDbType.Int,pKQHT_CTDT_ChiTietInfo.IDKQHT_MonHoc_CT_KhoiKienThuc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_CTDT_ChiTietInfo.HocKy));
            colParam.Add(CreateParam("@SoTiet",SqlDbType.Int,pKQHT_CTDT_ChiTietInfo.SoTiet));
            colParam.Add(CreateParam("@LyThuyet",SqlDbType.Int,pKQHT_CTDT_ChiTietInfo.LyThuyet));
            colParam.Add(CreateParam("@ThucHanh",SqlDbType.Int,pKQHT_CTDT_ChiTietInfo.ThucHanh));
            colParam.Add(CreateParam("@LoaiTietKhac1",SqlDbType.Int,pKQHT_CTDT_ChiTietInfo.LoaiTietKhac1));
            colParam.Add(CreateParam("@LoaiTietKhac2",SqlDbType.Int,pKQHT_CTDT_ChiTietInfo.LoaiTietKhac2));
            colParam.Add(CreateParam("@SoHocTrinh",SqlDbType.Real,pKQHT_CTDT_ChiTietInfo.SoHocTrinh));
            colParam.Add(CreateParam("@KQHT_CTDT_ChiTietID",SqlDbType.BigInt,pKQHT_CTDT_ChiTietInfo.KQHT_CTDT_ChiTietID));

            RunProcedure("sp_KQHT_CTDT_ChiTiet_Update", colParam);
        }
        
        public void Delete(KQHT_CTDT_ChiTietInfo pKQHT_CTDT_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_CTDT_ChiTietID",SqlDbType.BigInt,pKQHT_CTDT_ChiTietInfo.KQHT_CTDT_ChiTietID));

            RunProcedure("sp_KQHT_CTDT_ChiTiet_Delete", colParam);
        }
    }
}
