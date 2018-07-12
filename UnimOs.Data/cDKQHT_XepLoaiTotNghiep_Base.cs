using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_XepLoaiTotNghiep : cDBase
    {
        public DataTable Get(KQHT_XepLoaiTotNghiepInfo pKQHT_XepLoaiTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_XepLoaiTotNghiepID",SqlDbType.Int,pKQHT_XepLoaiTotNghiepInfo.KQHT_XepLoaiTotNghiepID));

            return RunProcedureGet("sp_KQHT_XepLoaiTotNghiep_Get", colParam);            
        }

        public int Add(KQHT_XepLoaiTotNghiepInfo pKQHT_XepLoaiTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenXepLoai",SqlDbType.NVarChar,pKQHT_XepLoaiTotNghiepInfo.TenXepLoai));
            colParam.Add(CreateParam("@TuDiem",SqlDbType.Float,pKQHT_XepLoaiTotNghiepInfo.TuDiem));
            colParam.Add(CreateParam("@MaXepLoai",SqlDbType.NVarChar,pKQHT_XepLoaiTotNghiepInfo.MaXepLoai));
            colParam.Add(CreateParam("@HaXepLoaiThiLaiQuaMucPhanTram", SqlDbType.Bit, pKQHT_XepLoaiTotNghiepInfo.HaXepLoaiThiLaiQuaMucPhanTram));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_XepLoaiTotNghiep_Add", colParam);
        }
        
        public void Update(KQHT_XepLoaiTotNghiepInfo pKQHT_XepLoaiTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenXepLoai",SqlDbType.NVarChar,pKQHT_XepLoaiTotNghiepInfo.TenXepLoai));
            colParam.Add(CreateParam("@TuDiem",SqlDbType.Float,pKQHT_XepLoaiTotNghiepInfo.TuDiem));
            colParam.Add(CreateParam("@MaXepLoai",SqlDbType.NVarChar,pKQHT_XepLoaiTotNghiepInfo.MaXepLoai));
            colParam.Add(CreateParam("@HaXepLoaiThiLaiQuaMucPhanTram", SqlDbType.Bit, pKQHT_XepLoaiTotNghiepInfo.HaXepLoaiThiLaiQuaMucPhanTram));
            colParam.Add(CreateParam("@KQHT_XepLoaiTotNghiepID",SqlDbType.Int,pKQHT_XepLoaiTotNghiepInfo.KQHT_XepLoaiTotNghiepID));

            RunProcedure("sp_KQHT_XepLoaiTotNghiep_Update", colParam);
        }
        
        public void Delete(KQHT_XepLoaiTotNghiepInfo pKQHT_XepLoaiTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_XepLoaiTotNghiepID",SqlDbType.Int,pKQHT_XepLoaiTotNghiepInfo.KQHT_XepLoaiTotNghiepID));

            RunProcedure("sp_KQHT_XepLoaiTotNghiep_Delete", colParam);
        }
    }
}
