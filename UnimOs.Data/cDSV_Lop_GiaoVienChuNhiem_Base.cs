using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_Lop_GiaoVienChuNhiem : cDBase
    {
        public DataTable Get(SV_Lop_GiaoVienChuNhiemInfo pSV_Lop_GiaoVienChuNhiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_Lop_GiaoVienChuNhiemID",SqlDbType.Int,pSV_Lop_GiaoVienChuNhiemInfo.SV_Lop_GiaoVienChuNhiemID));

            return RunProcedureGet("sp_SV_Lop_GiaoVienChuNhiem_Get", colParam);            
        }

        public int Add(SV_Lop_GiaoVienChuNhiemInfo pSV_Lop_GiaoVienChuNhiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pSV_Lop_GiaoVienChuNhiemInfo.IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_GiaoVien",SqlDbType.Int,pSV_Lop_GiaoVienChuNhiemInfo.IDDM_GiaoVien));
            colParam.Add(CreateParam("@TuNgay",SqlDbType.DateTime,pSV_Lop_GiaoVienChuNhiemInfo.TuNgay));
            colParam.Add(CreateParam("@DenNgay",SqlDbType.DateTime,pSV_Lop_GiaoVienChuNhiemInfo.DenNgay));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_SV_Lop_GiaoVienChuNhiem_Add", colParam);
        }
        
        public void Update(SV_Lop_GiaoVienChuNhiemInfo pSV_Lop_GiaoVienChuNhiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pSV_Lop_GiaoVienChuNhiemInfo.IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_GiaoVien",SqlDbType.Int,pSV_Lop_GiaoVienChuNhiemInfo.IDDM_GiaoVien));
            colParam.Add(CreateParam("@TuNgay",SqlDbType.DateTime,pSV_Lop_GiaoVienChuNhiemInfo.TuNgay));
            colParam.Add(CreateParam("@DenNgay",SqlDbType.DateTime,pSV_Lop_GiaoVienChuNhiemInfo.DenNgay));
            colParam.Add(CreateParam("@SV_Lop_GiaoVienChuNhiemID",SqlDbType.Int,pSV_Lop_GiaoVienChuNhiemInfo.SV_Lop_GiaoVienChuNhiemID));

            RunProcedure("sp_SV_Lop_GiaoVienChuNhiem_Update", colParam);
        }
        
        public void Delete(SV_Lop_GiaoVienChuNhiemInfo pSV_Lop_GiaoVienChuNhiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_Lop_GiaoVienChuNhiemID",SqlDbType.Int,pSV_Lop_GiaoVienChuNhiemInfo.SV_Lop_GiaoVienChuNhiemID));

            RunProcedure("sp_SV_Lop_GiaoVienChuNhiem_Delete", colParam);
        }
    }
}
