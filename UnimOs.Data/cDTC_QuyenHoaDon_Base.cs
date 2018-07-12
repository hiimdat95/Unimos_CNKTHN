using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_QuyenHoaDon : cDBase
    {
        public DataTable Get(TC_QuyenHoaDonInfo pTC_QuyenHoaDonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_QuyenHoaDonID",SqlDbType.Int,pTC_QuyenHoaDonInfo.TC_QuyenHoaDonID));

            return RunProcedureGet("sp_TC_QuyenHoaDon_Get", colParam);            
        }

        public int Add(TC_QuyenHoaDonInfo pTC_QuyenHoaDonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_DiaDiem", SqlDbType.Int, pTC_QuyenHoaDonInfo.IDDM_DiaDiem));
            colParam.Add(CreateParam("@TenQuyenHoaDon",SqlDbType.NVarChar,pTC_QuyenHoaDonInfo.TenQuyenHoaDon));
            colParam.Add(CreateParam("@TuSo",SqlDbType.NVarChar,pTC_QuyenHoaDonInfo.TuSo));
            colParam.Add(CreateParam("@SoHienTai",SqlDbType.NVarChar,pTC_QuyenHoaDonInfo.SoHienTai));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pTC_QuyenHoaDonInfo.HocKy));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pTC_QuyenHoaDonInfo.IDDM_NamHoc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_TC_QuyenHoaDon_Add", colParam);
        }
        
        public void Update(TC_QuyenHoaDonInfo pTC_QuyenHoaDonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_DiaDiem", SqlDbType.Int, pTC_QuyenHoaDonInfo.IDDM_DiaDiem));
            colParam.Add(CreateParam("@TenQuyenHoaDon",SqlDbType.NVarChar,pTC_QuyenHoaDonInfo.TenQuyenHoaDon));
            colParam.Add(CreateParam("@TuSo",SqlDbType.NVarChar,pTC_QuyenHoaDonInfo.TuSo));
            colParam.Add(CreateParam("@SoHienTai",SqlDbType.NVarChar,pTC_QuyenHoaDonInfo.SoHienTai));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pTC_QuyenHoaDonInfo.HocKy));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pTC_QuyenHoaDonInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@TC_QuyenHoaDonID",SqlDbType.Int,pTC_QuyenHoaDonInfo.TC_QuyenHoaDonID));

            RunProcedure("sp_TC_QuyenHoaDon_Update", colParam);
        }
        
        public void Delete(TC_QuyenHoaDonInfo pTC_QuyenHoaDonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_QuyenHoaDonID",SqlDbType.Int,pTC_QuyenHoaDonInfo.TC_QuyenHoaDonID));

            RunProcedure("sp_TC_QuyenHoaDon_Delete", colParam);
        }
    }
}
