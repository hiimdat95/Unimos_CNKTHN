using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_QuyetDinhKyLuat : cDBase
    {
        public DataTable Get(SV_QuyetDinhKyLuatInfo pSV_QuyetDinhKyLuatInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_QuyetDinhKyLuatID",SqlDbType.Int,pSV_QuyetDinhKyLuatInfo.SV_QuyetDinhKyLuatID));

            return RunProcedureGet("sp_SV_QuyetDinhKyLuat_Get", colParam);            
        }

        public DataTable GetByHocKyNamHoc(int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_SV_QuyetDinhKyLuat_GetByHocKyNamHoc", colParam);
        }

        public int Add(SV_QuyetDinhKyLuatInfo pSV_QuyetDinhKyLuatInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pSV_QuyetDinhKyLuatInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pSV_QuyetDinhKyLuatInfo.HocKy));
            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pSV_QuyetDinhKyLuatInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayQuyetDinh",SqlDbType.DateTime,pSV_QuyetDinhKyLuatInfo.NgayQuyetDinh));
            colParam.Add(CreateParam("@IDDM_CapKhenThuong",SqlDbType.Int,pSV_QuyetDinhKyLuatInfo.IDDM_CapKhenThuong));
            colParam.Add(CreateParam("@IDDM_HanhVi",SqlDbType.Int,pSV_QuyetDinhKyLuatInfo.IDDM_HanhVi));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NVarChar,pSV_QuyetDinhKyLuatInfo.NoiDung));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_SV_QuyetDinhKyLuat_Add", colParam);
        }
        
        public void Update(SV_QuyetDinhKyLuatInfo pSV_QuyetDinhKyLuatInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pSV_QuyetDinhKyLuatInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pSV_QuyetDinhKyLuatInfo.HocKy));
            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pSV_QuyetDinhKyLuatInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayQuyetDinh",SqlDbType.DateTime,pSV_QuyetDinhKyLuatInfo.NgayQuyetDinh));
            colParam.Add(CreateParam("@IDDM_CapKhenThuong",SqlDbType.Int,pSV_QuyetDinhKyLuatInfo.IDDM_CapKhenThuong));
            colParam.Add(CreateParam("@IDDM_HanhVi",SqlDbType.Int,pSV_QuyetDinhKyLuatInfo.IDDM_HanhVi));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NVarChar,pSV_QuyetDinhKyLuatInfo.NoiDung));
            colParam.Add(CreateParam("@SV_QuyetDinhKyLuatID",SqlDbType.Int,pSV_QuyetDinhKyLuatInfo.SV_QuyetDinhKyLuatID));

            RunProcedure("sp_SV_QuyetDinhKyLuat_Update", colParam);
        }
        
        public void Delete(SV_QuyetDinhKyLuatInfo pSV_QuyetDinhKyLuatInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_QuyetDinhKyLuatID",SqlDbType.Int,pSV_QuyetDinhKyLuatInfo.SV_QuyetDinhKyLuatID));

            RunProcedure("sp_SV_QuyetDinhKyLuat_Delete", colParam);
        }
    }
}
