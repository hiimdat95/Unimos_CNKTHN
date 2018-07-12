using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDHT_ThongTinTruong : cDBase
    {
        public DataTable Get(HT_ThongTinTruongInfo pHT_ThongTinTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_ThongTinTruongID",SqlDbType.Int,pHT_ThongTinTruongInfo.HT_ThongTinTruongID));

            return RunProcedureGet("sp_HT_ThongTinTruong_Get", colParam);            
        }

        public int Add(HT_ThongTinTruongInfo pHT_ThongTinTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaThongTin",SqlDbType.NVarChar,pHT_ThongTinTruongInfo.MaThongTin));
            colParam.Add(CreateParam("@TenThongTin",SqlDbType.NVarChar,pHT_ThongTinTruongInfo.TenThongTin));
            colParam.Add(CreateParam("@GiaTri",SqlDbType.NVarChar,pHT_ThongTinTruongInfo.GiaTri));
            colParam.Add(CreateParam("@SapXep",SqlDbType.Int,pHT_ThongTinTruongInfo.SapXep));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_HT_ThongTinTruong_Add", colParam);
        }
        
        public void Update(HT_ThongTinTruongInfo pHT_ThongTinTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaThongTin",SqlDbType.NVarChar,pHT_ThongTinTruongInfo.MaThongTin));
            colParam.Add(CreateParam("@TenThongTin",SqlDbType.NVarChar,pHT_ThongTinTruongInfo.TenThongTin));
            colParam.Add(CreateParam("@GiaTri",SqlDbType.NVarChar,pHT_ThongTinTruongInfo.GiaTri));
            colParam.Add(CreateParam("@SapXep",SqlDbType.Int,pHT_ThongTinTruongInfo.SapXep));
            colParam.Add(CreateParam("@HT_ThongTinTruongID",SqlDbType.Int,pHT_ThongTinTruongInfo.HT_ThongTinTruongID));

            RunProcedure("sp_HT_ThongTinTruong_Update", colParam);
        }
        
        public void Delete(HT_ThongTinTruongInfo pHT_ThongTinTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_ThongTinTruongID",SqlDbType.Int,pHT_ThongTinTruongInfo.HT_ThongTinTruongID));

            RunProcedure("sp_HT_ThongTinTruong_Delete", colParam);
        }
    }
}
