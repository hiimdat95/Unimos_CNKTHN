using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_QuyetDinhKhenThuong : cDBase
    {
        public DataTable Get(SV_QuyetDinhKhenThuongInfo pSV_QuyetDinhKhenThuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_QuyetDinhKhenThuongID",SqlDbType.Int,pSV_QuyetDinhKhenThuongInfo.SV_QuyetDinhKhenThuongID));

            return RunProcedureGet("sp_SV_QuyetDinhKhenThuong_Get", colParam);            
        }

        public int Add(SV_QuyetDinhKhenThuongInfo pSV_QuyetDinhKhenThuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pSV_QuyetDinhKhenThuongInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pSV_QuyetDinhKhenThuongInfo.HocKy));
            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pSV_QuyetDinhKhenThuongInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayQuyetDinh",SqlDbType.DateTime,pSV_QuyetDinhKhenThuongInfo.NgayQuyetDinh));
            colParam.Add(CreateParam("@IDDM_CapKhenThuong",SqlDbType.Int,pSV_QuyetDinhKhenThuongInfo.IDDM_CapKhenThuong));
            colParam.Add(CreateParam("@IDDM_LoaiKhenThuong",SqlDbType.Int,pSV_QuyetDinhKhenThuongInfo.IDDM_LoaiKhenThuong));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NVarChar,pSV_QuyetDinhKhenThuongInfo.NoiDung));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_SV_QuyetDinhKhenThuong_Add", colParam);
        }
        
        public void Update(SV_QuyetDinhKhenThuongInfo pSV_QuyetDinhKhenThuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pSV_QuyetDinhKhenThuongInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pSV_QuyetDinhKhenThuongInfo.HocKy));
            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pSV_QuyetDinhKhenThuongInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayQuyetDinh",SqlDbType.DateTime,pSV_QuyetDinhKhenThuongInfo.NgayQuyetDinh));
            colParam.Add(CreateParam("@IDDM_CapKhenThuong",SqlDbType.Int,pSV_QuyetDinhKhenThuongInfo.IDDM_CapKhenThuong));
            colParam.Add(CreateParam("@IDDM_LoaiKhenThuong",SqlDbType.Int,pSV_QuyetDinhKhenThuongInfo.IDDM_LoaiKhenThuong));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NVarChar,pSV_QuyetDinhKhenThuongInfo.NoiDung));
            colParam.Add(CreateParam("@SV_QuyetDinhKhenThuongID",SqlDbType.Int,pSV_QuyetDinhKhenThuongInfo.SV_QuyetDinhKhenThuongID));

            RunProcedure("sp_SV_QuyetDinhKhenThuong_Update", colParam);
        }
        
        public void Delete(SV_QuyetDinhKhenThuongInfo pSV_QuyetDinhKhenThuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_QuyetDinhKhenThuongID",SqlDbType.Int,pSV_QuyetDinhKhenThuongInfo.SV_QuyetDinhKhenThuongID));

            RunProcedure("sp_SV_QuyetDinhKhenThuong_Delete", colParam);
        }
    }
}
