using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_HoiDongMon_ChiTiet : cDBase
    {
        public DataTable Get(KQHT_HoiDongMon_ChiTietInfo pKQHT_HoiDongMon_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_HoiDongMon_ChiTietID",SqlDbType.Int,pKQHT_HoiDongMon_ChiTietInfo.KQHT_HoiDongMon_ChiTietID));

            return RunProcedureGet("sp_KQHT_HoiDongMon_ChiTiet_Get", colParam);            
        }

        public int Add(KQHT_HoiDongMon_ChiTietInfo pKQHT_HoiDongMon_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_HoiDongMon",SqlDbType.Int,pKQHT_HoiDongMon_ChiTietInfo.IDKQHT_HoiDongMon));
            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pKQHT_HoiDongMon_ChiTietInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@TyLe",SqlDbType.Real,pKQHT_HoiDongMon_ChiTietInfo.TyLe));
            colParam.Add(CreateParam("@HoTen",SqlDbType.NVarChar,pKQHT_HoiDongMon_ChiTietInfo.HoTen));
            colParam.Add(CreateParam("@ChucVu",SqlDbType.NVarChar,pKQHT_HoiDongMon_ChiTietInfo.ChucVu));
            colParam.Add(CreateParam("@DonViCongTac",SqlDbType.NVarChar,pKQHT_HoiDongMon_ChiTietInfo.DonViCongTac));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_HoiDongMon_ChiTiet_Add", colParam);
        }
        
        public void Update(KQHT_HoiDongMon_ChiTietInfo pKQHT_HoiDongMon_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_HoiDongMon",SqlDbType.Int,pKQHT_HoiDongMon_ChiTietInfo.IDKQHT_HoiDongMon));
            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pKQHT_HoiDongMon_ChiTietInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@TyLe",SqlDbType.Real,pKQHT_HoiDongMon_ChiTietInfo.TyLe));
            colParam.Add(CreateParam("@HoTen",SqlDbType.NVarChar,pKQHT_HoiDongMon_ChiTietInfo.HoTen));
            colParam.Add(CreateParam("@ChucVu",SqlDbType.NVarChar,pKQHT_HoiDongMon_ChiTietInfo.ChucVu));
            colParam.Add(CreateParam("@DonViCongTac",SqlDbType.NVarChar,pKQHT_HoiDongMon_ChiTietInfo.DonViCongTac));
            colParam.Add(CreateParam("@KQHT_HoiDongMon_ChiTietID",SqlDbType.Int,pKQHT_HoiDongMon_ChiTietInfo.KQHT_HoiDongMon_ChiTietID));

            RunProcedure("sp_KQHT_HoiDongMon_ChiTiet_Update", colParam);
        }
        
        public void Delete(KQHT_HoiDongMon_ChiTietInfo pKQHT_HoiDongMon_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_HoiDongMon_ChiTietID",SqlDbType.Int,pKQHT_HoiDongMon_ChiTietInfo.KQHT_HoiDongMon_ChiTietID));

            RunProcedure("sp_KQHT_HoiDongMon_ChiTiet_Delete", colParam);
        }
    }
}
