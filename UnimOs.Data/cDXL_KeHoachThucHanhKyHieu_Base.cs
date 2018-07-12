using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_KeHoachThucHanhKyHieu : cDBase
    {
        public DataTable Get(XL_KeHoachThucHanhKyHieuInfo pXL_KeHoachThucHanhKyHieuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_KeHoachThucHanhKyHieuID",SqlDbType.Int,pXL_KeHoachThucHanhKyHieuInfo.XL_KeHoachThucHanhKyHieuID));

            return RunProcedureGet("sp_XL_KeHoachThucHanhKyHieu_Get", colParam);            
        }

        public int Add(XL_KeHoachThucHanhKyHieuInfo pXL_KeHoachThucHanhKyHieuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pXL_KeHoachThucHanhKyHieuInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@KyHieu",SqlDbType.NVarChar,pXL_KeHoachThucHanhKyHieuInfo.KyHieu));
            colParam.Add(CreateParam("@MauChu",SqlDbType.Int,pXL_KeHoachThucHanhKyHieuInfo.MauChu));
            colParam.Add(CreateParam("@MauNen",SqlDbType.Int,pXL_KeHoachThucHanhKyHieuInfo.MauNen));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_KeHoachThucHanhKyHieu_Add", colParam);
        }
        
        public void Update(XL_KeHoachThucHanhKyHieuInfo pXL_KeHoachThucHanhKyHieuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pXL_KeHoachThucHanhKyHieuInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@KyHieu",SqlDbType.NVarChar,pXL_KeHoachThucHanhKyHieuInfo.KyHieu));
            colParam.Add(CreateParam("@MauChu",SqlDbType.Int,pXL_KeHoachThucHanhKyHieuInfo.MauChu));
            colParam.Add(CreateParam("@MauNen",SqlDbType.Int,pXL_KeHoachThucHanhKyHieuInfo.MauNen));
            colParam.Add(CreateParam("@XL_KeHoachThucHanhKyHieuID",SqlDbType.Int,pXL_KeHoachThucHanhKyHieuInfo.XL_KeHoachThucHanhKyHieuID));

            RunProcedure("sp_XL_KeHoachThucHanhKyHieu_Update", colParam);
        }
        
        public void Delete(XL_KeHoachThucHanhKyHieuInfo pXL_KeHoachThucHanhKyHieuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_KeHoachThucHanhKyHieuID",SqlDbType.Int,pXL_KeHoachThucHanhKyHieuInfo.XL_KeHoachThucHanhKyHieuID));

            RunProcedure("sp_XL_KeHoachThucHanhKyHieu_Delete", colParam);
        }
    }
}
