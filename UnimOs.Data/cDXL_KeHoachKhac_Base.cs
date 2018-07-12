using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_KeHoachKhac : cDBase
    {
        public DataTable Get(XL_KeHoachKhacInfo pXL_KeHoachKhacInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_KeHoachKhacID",SqlDbType.Int,pXL_KeHoachKhacInfo.XL_KeHoachKhacID));

            return RunProcedureGet("sp_XL_KeHoachKhac_Get", colParam);            
        }

        public int Add(XL_KeHoachKhacInfo pXL_KeHoachKhacInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenKeHoachKhac",SqlDbType.NVarChar,pXL_KeHoachKhacInfo.TenKeHoachKhac));
            colParam.Add(CreateParam("@TenVietTat",SqlDbType.NVarChar,pXL_KeHoachKhacInfo.TenVietTat));
            colParam.Add(CreateParam("@MauNen",SqlDbType.Int,pXL_KeHoachKhacInfo.MauNen));
            colParam.Add(CreateParam("@MauChu",SqlDbType.Int,pXL_KeHoachKhacInfo.MauChu));
            colParam.Add(CreateParam("@DuLieuChuan",SqlDbType.Bit,pXL_KeHoachKhacInfo.DuLieuChuan));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_KeHoachKhac_Add", colParam);
        }
        
        public void Update(XL_KeHoachKhacInfo pXL_KeHoachKhacInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenKeHoachKhac",SqlDbType.NVarChar,pXL_KeHoachKhacInfo.TenKeHoachKhac));
            colParam.Add(CreateParam("@TenVietTat",SqlDbType.NVarChar,pXL_KeHoachKhacInfo.TenVietTat));
            colParam.Add(CreateParam("@MauNen",SqlDbType.Int,pXL_KeHoachKhacInfo.MauNen));
            colParam.Add(CreateParam("@MauChu",SqlDbType.Int,pXL_KeHoachKhacInfo.MauChu));
            colParam.Add(CreateParam("@DuLieuChuan",SqlDbType.Bit,pXL_KeHoachKhacInfo.DuLieuChuan));
            colParam.Add(CreateParam("@XL_KeHoachKhacID",SqlDbType.Int,pXL_KeHoachKhacInfo.XL_KeHoachKhacID));

            RunProcedure("sp_XL_KeHoachKhac_Update", colParam);
        }
        
        public void Delete(XL_KeHoachKhacInfo pXL_KeHoachKhacInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_KeHoachKhacID",SqlDbType.Int,pXL_KeHoachKhacInfo.XL_KeHoachKhacID));

            RunProcedure("sp_XL_KeHoachKhac_Delete", colParam);
        }
    }
}
