using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDGG_DinhMucTheoChucDanh : cDBase
    {
        public DataTable Get(GG_DinhMucTheoChucDanhInfo pGG_DinhMucTheoChucDanhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@GG_DinhMucTheoChucDanhID",SqlDbType.Int,pGG_DinhMucTheoChucDanhInfo.GG_DinhMucTheoChucDanhID));

            return RunProcedureGet("sp_GG_DinhMucTheoChucDanh_Get", colParam);            
        }

        public int Add(GG_DinhMucTheoChucDanhInfo pGG_DinhMucTheoChucDanhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_ChucDanh",SqlDbType.Int,pGG_DinhMucTheoChucDanhInfo.IDDM_ChucDanh));
            colParam.Add(CreateParam("@HeSo",SqlDbType.Float,pGG_DinhMucTheoChucDanhInfo.HeSo));
            colParam.Add(CreateParam("@HeSoGioChuan",SqlDbType.Float,pGG_DinhMucTheoChucDanhInfo.HeSoGioChuan));
            colParam.Add(CreateParam("@GioLamViec",SqlDbType.Float,pGG_DinhMucTheoChucDanhInfo.GioLamViec));
            colParam.Add(CreateParam("@GioChuanGiang",SqlDbType.Float,pGG_DinhMucTheoChucDanhInfo.GioChuanGiang));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_GG_DinhMucTheoChucDanh_Add", colParam);
        }
        
        public void Update(GG_DinhMucTheoChucDanhInfo pGG_DinhMucTheoChucDanhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_ChucDanh",SqlDbType.Int,pGG_DinhMucTheoChucDanhInfo.IDDM_ChucDanh));
            colParam.Add(CreateParam("@HeSo",SqlDbType.Float,pGG_DinhMucTheoChucDanhInfo.HeSo));
            colParam.Add(CreateParam("@HeSoGioChuan",SqlDbType.Float,pGG_DinhMucTheoChucDanhInfo.HeSoGioChuan));
            colParam.Add(CreateParam("@GioLamViec",SqlDbType.Float,pGG_DinhMucTheoChucDanhInfo.GioLamViec));
            colParam.Add(CreateParam("@GioChuanGiang",SqlDbType.Float,pGG_DinhMucTheoChucDanhInfo.GioChuanGiang));
            colParam.Add(CreateParam("@GG_DinhMucTheoChucDanhID",SqlDbType.Int,pGG_DinhMucTheoChucDanhInfo.GG_DinhMucTheoChucDanhID));

            RunProcedure("sp_GG_DinhMucTheoChucDanh_Update", colParam);
        }
        
        public void Delete(GG_DinhMucTheoChucDanhInfo pGG_DinhMucTheoChucDanhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@GG_DinhMucTheoChucDanhID",SqlDbType.Int,pGG_DinhMucTheoChucDanhInfo.GG_DinhMucTheoChucDanhID));

            RunProcedure("sp_GG_DinhMucTheoChucDanh_Delete", colParam);
        }
    }
}
