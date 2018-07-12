using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_HoiDongMon_SinhVien : cDBase
    {
        public DataTable Get(KQHT_HoiDongMon_SinhVienInfo pKQHT_HoiDongMon_SinhVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_HoiDongMon_SinhVienID",SqlDbType.Int,pKQHT_HoiDongMon_SinhVienInfo.KQHT_HoiDongMon_SinhVienID));

            return RunProcedureGet("sp_KQHT_HoiDongMon_SinhVien_Get", colParam);            
        }

        public int Add(KQHT_HoiDongMon_SinhVienInfo pKQHT_HoiDongMon_SinhVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_HoiDongMon",SqlDbType.Int,pKQHT_HoiDongMon_SinhVienInfo.IDKQHT_HoiDongMon));
            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_HoiDongMon_SinhVienInfo.IDSV_SinhVien));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_HoiDongMon_SinhVien_Add", colParam);
        }
        
        public void Update(KQHT_HoiDongMon_SinhVienInfo pKQHT_HoiDongMon_SinhVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_HoiDongMon",SqlDbType.Int,pKQHT_HoiDongMon_SinhVienInfo.IDKQHT_HoiDongMon));
            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_HoiDongMon_SinhVienInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@KQHT_HoiDongMon_SinhVienID",SqlDbType.Int,pKQHT_HoiDongMon_SinhVienInfo.KQHT_HoiDongMon_SinhVienID));

            RunProcedure("sp_KQHT_HoiDongMon_SinhVien_Update", colParam);
        }
        
        public void Delete(KQHT_HoiDongMon_SinhVienInfo pKQHT_HoiDongMon_SinhVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_HoiDongMon_SinhVienID",SqlDbType.Int,pKQHT_HoiDongMon_SinhVienInfo.KQHT_HoiDongMon_SinhVienID));

            RunProcedure("sp_KQHT_HoiDongMon_SinhVien_Delete", colParam);
        }
    }
}
