using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_LoaiCongViec : cDBase
    {
        public DataTable Get(DM_LoaiCongViecInfo pDM_LoaiCongViecInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_LoaiCongViecID",SqlDbType.Int,pDM_LoaiCongViecInfo.DM_LoaiCongViecID));

            return RunProcedureGet("sp_DM_LoaiCongViec_Get", colParam);            
        }

        public int Add(DM_LoaiCongViecInfo pDM_LoaiCongViecInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenLoaiCongViec",SqlDbType.NVarChar,pDM_LoaiCongViecInfo.TenLoaiCongViec));
            colParam.Add(CreateParam("@SoLuong", SqlDbType.Float, pDM_LoaiCongViecInfo.SoLuong));
            colParam.Add(CreateParam("@DonVi",SqlDbType.NVarChar,pDM_LoaiCongViecInfo.DonVi));
            colParam.Add(CreateParam("@QuyChuan",SqlDbType.Float,pDM_LoaiCongViecInfo.QuyChuan));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_LoaiCongViec_Add", colParam);
        }
        
        public void Update(DM_LoaiCongViecInfo pDM_LoaiCongViecInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenLoaiCongViec",SqlDbType.NVarChar,pDM_LoaiCongViecInfo.TenLoaiCongViec));
            colParam.Add(CreateParam("@SoLuong", SqlDbType.Float, pDM_LoaiCongViecInfo.SoLuong));
            colParam.Add(CreateParam("@DonVi",SqlDbType.NVarChar,pDM_LoaiCongViecInfo.DonVi));
            colParam.Add(CreateParam("@QuyChuan", SqlDbType.Float, pDM_LoaiCongViecInfo.QuyChuan));
            colParam.Add(CreateParam("@DM_LoaiCongViecID",SqlDbType.Int,pDM_LoaiCongViecInfo.DM_LoaiCongViecID));

            RunProcedure("sp_DM_LoaiCongViec_Update", colParam);
        }
        
        public void Delete(DM_LoaiCongViecInfo pDM_LoaiCongViecInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_LoaiCongViecID",SqlDbType.Int,pDM_LoaiCongViecInfo.DM_LoaiCongViecID));

            RunProcedure("sp_DM_LoaiCongViec_Delete", colParam);
        }
    }
}
