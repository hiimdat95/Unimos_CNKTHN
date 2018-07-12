using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_KhoiKienThuc : cDBase
    {
        public DataTable Get(DM_KhoiKienThucInfo pDM_KhoiKienThucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_KhoiKienThucID",SqlDbType.Int,pDM_KhoiKienThucInfo.DM_KhoiKienThucID));

            return RunProcedureGet("sp_DM_KhoiKienThuc_Get", colParam);            
        }

        public int Add(DM_KhoiKienThucInfo pDM_KhoiKienThucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaKhoiKienThuc",SqlDbType.NVarChar,pDM_KhoiKienThucInfo.MaKhoiKienThuc));
            colParam.Add(CreateParam("@TenKhoiKienThuc",SqlDbType.NVarChar,pDM_KhoiKienThucInfo.TenKhoiKienThuc));
            colParam.Add(CreateParam("@ParentID",SqlDbType.Int,pDM_KhoiKienThucInfo.ParentID));
            colParam.Add(CreateParam("@SoHocPhanPhaiChon",SqlDbType.Int,pDM_KhoiKienThucInfo.SoHocPhanPhaiChon));
            colParam.Add(CreateParam("@KhoaLuanTotNghiep",SqlDbType.Bit,pDM_KhoiKienThucInfo.KhoaLuanTotNghiep));
            colParam.Add(CreateParam("@SapXep",SqlDbType.Int,pDM_KhoiKienThucInfo.SapXep));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_KhoiKienThuc_Add", colParam);
        }
        
        public void Update(DM_KhoiKienThucInfo pDM_KhoiKienThucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaKhoiKienThuc",SqlDbType.NVarChar,pDM_KhoiKienThucInfo.MaKhoiKienThuc));
            colParam.Add(CreateParam("@TenKhoiKienThuc",SqlDbType.NVarChar,pDM_KhoiKienThucInfo.TenKhoiKienThuc));
            colParam.Add(CreateParam("@ParentID",SqlDbType.Int,pDM_KhoiKienThucInfo.ParentID));
            colParam.Add(CreateParam("@SoHocPhanPhaiChon",SqlDbType.Int,pDM_KhoiKienThucInfo.SoHocPhanPhaiChon));
            colParam.Add(CreateParam("@KhoaLuanTotNghiep",SqlDbType.Bit,pDM_KhoiKienThucInfo.KhoaLuanTotNghiep));
            colParam.Add(CreateParam("@SapXep",SqlDbType.Int,pDM_KhoiKienThucInfo.SapXep));
            colParam.Add(CreateParam("@DM_KhoiKienThucID",SqlDbType.Int,pDM_KhoiKienThucInfo.DM_KhoiKienThucID));

            RunProcedure("sp_DM_KhoiKienThuc_Update", colParam);
        }
        
        public void Delete(DM_KhoiKienThucInfo pDM_KhoiKienThucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_KhoiKienThucID",SqlDbType.Int,pDM_KhoiKienThucInfo.DM_KhoiKienThucID));

            RunProcedure("sp_DM_KhoiKienThuc_Delete", colParam);
        }
    }
}
