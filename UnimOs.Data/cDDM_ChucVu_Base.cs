using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_ChucVu : cDBase
    {
        public DataTable Get(DM_ChucVuInfo pDM_ChucVuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_ChucVuID",SqlDbType.Int,pDM_ChucVuInfo.DM_ChucVuID));

            return RunProcedureGet("sp_DM_ChucVu_Get", colParam);            
        }

        public int Add(DM_ChucVuInfo pDM_ChucVuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenChucVu",SqlDbType.NVarChar,pDM_ChucVuInfo.TenChucVu));
            colParam.Add(CreateParam("@SoGioGiam",SqlDbType.Int,pDM_ChucVuInfo.SoGioGiam));
            colParam.Add(CreateParam("@PhanTramGioGiam",SqlDbType.Float,pDM_ChucVuInfo.PhanTramGioGiam));
            colParam.Add(CreateParam("@IDLoaiVienChuc", SqlDbType.NVarChar, pDM_ChucVuInfo.IDLoaiVienChuc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_ChucVu_Add", colParam);
        }
        
        public void Update(DM_ChucVuInfo pDM_ChucVuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenChucVu",SqlDbType.NVarChar,pDM_ChucVuInfo.TenChucVu));
            colParam.Add(CreateParam("@SoGioGiam",SqlDbType.Int,pDM_ChucVuInfo.SoGioGiam));
            colParam.Add(CreateParam("@PhanTramGioGiam",SqlDbType.Float,pDM_ChucVuInfo.PhanTramGioGiam));
            colParam.Add(CreateParam("@IDLoaiVienChuc", SqlDbType.NVarChar, pDM_ChucVuInfo.IDLoaiVienChuc));
            colParam.Add(CreateParam("@DM_ChucVuID",SqlDbType.Int,pDM_ChucVuInfo.DM_ChucVuID));

            RunProcedure("sp_DM_ChucVu_Update", colParam);
        }
        
        public void Delete(DM_ChucVuInfo pDM_ChucVuInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_ChucVuID",SqlDbType.Int,pDM_ChucVuInfo.DM_ChucVuID));

            RunProcedure("sp_DM_ChucVu_Delete", colParam);
        }
    }
}
