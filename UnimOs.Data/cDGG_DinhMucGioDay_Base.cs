using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDGG_DinhMucGioDay : cDBase
    {
        public DataTable Get(GG_DinhMucGioDayInfo pGG_DinhMucGioDayInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@GG_DinhMucGioDayID",SqlDbType.Int,pGG_DinhMucGioDayInfo.GG_DinhMucGioDayID));

            return RunProcedureGet("sp_GG_DinhMucGioDay_Get", colParam);            
        }

        public int Add(GG_DinhMucGioDayInfo pGG_DinhMucGioDayInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pGG_DinhMucGioDayInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoGioGiam",SqlDbType.Float,pGG_DinhMucGioDayInfo.SoGioGiam));
            colParam.Add(CreateParam("@SoGioDinhMuc",SqlDbType.Float,pGG_DinhMucGioDayInfo.SoGioDinhMuc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pGG_DinhMucGioDayInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pGG_DinhMucGioDayInfo.HocKy));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_GG_DinhMucGioDay_Add", colParam);
        }
        
        public void Update(GG_DinhMucGioDayInfo pGG_DinhMucGioDayInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pGG_DinhMucGioDayInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoGioGiam",SqlDbType.Float,pGG_DinhMucGioDayInfo.SoGioGiam));
            colParam.Add(CreateParam("@SoGioDinhMuc",SqlDbType.Float,pGG_DinhMucGioDayInfo.SoGioDinhMuc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pGG_DinhMucGioDayInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pGG_DinhMucGioDayInfo.HocKy));
            colParam.Add(CreateParam("@GG_DinhMucGioDayID",SqlDbType.Int,pGG_DinhMucGioDayInfo.GG_DinhMucGioDayID));

            RunProcedure("sp_GG_DinhMucGioDay_Update", colParam);
        }
        
        public void Delete(GG_DinhMucGioDayInfo pGG_DinhMucGioDayInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@GG_DinhMucGioDayID",SqlDbType.Int,pGG_DinhMucGioDayInfo.GG_DinhMucGioDayID));

            RunProcedure("sp_GG_DinhMucGioDay_Delete", colParam);
        }
    }
}
