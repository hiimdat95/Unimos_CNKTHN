using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_DanhSachHocBong : cDBase
    {
        public DataTable Get(TC_DanhSachHocBongInfo pTC_DanhSachHocBongInfo)
        {
            ArrayList colParam = new ArrayList();


            return RunProcedureGet("sp_TC_DanhSachHocBong_Get", colParam);            
        }

        public int Add(TC_DanhSachHocBongInfo pTC_DanhSachHocBongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pTC_DanhSachHocBongInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pTC_DanhSachHocBongInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pTC_DanhSachHocBongInfo.HocKy));
            colParam.Add(CreateParam("@IDTC_PhanBoQuyHocBong",SqlDbType.Int,pTC_DanhSachHocBongInfo.IDTC_PhanBoQuyHocBong));
            colParam.Add(CreateParam("@SoTienThang",SqlDbType.Money,pTC_DanhSachHocBongInfo.SoTienThang));
            colParam.Add(CreateParam("@SoTienKy",SqlDbType.Money,pTC_DanhSachHocBongInfo.SoTienKy));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_TC_DanhSachHocBong_Add", colParam);
        }
        
        public void Update(TC_DanhSachHocBongInfo pTC_DanhSachHocBongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_DanhSachHocBongID",SqlDbType.Int,pTC_DanhSachHocBongInfo.TC_DanhSachHocBongID));
            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pTC_DanhSachHocBongInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pTC_DanhSachHocBongInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pTC_DanhSachHocBongInfo.HocKy));
            colParam.Add(CreateParam("@IDTC_PhanBoQuyHocBong",SqlDbType.Int,pTC_DanhSachHocBongInfo.IDTC_PhanBoQuyHocBong));
            colParam.Add(CreateParam("@SoTienThang",SqlDbType.Money,pTC_DanhSachHocBongInfo.SoTienThang));
            colParam.Add(CreateParam("@SoTienKy",SqlDbType.Money,pTC_DanhSachHocBongInfo.SoTienKy));

            RunProcedure("sp_TC_DanhSachHocBong_Update", colParam);
        }
        
        public void Delete(TC_DanhSachHocBongInfo pTC_DanhSachHocBongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_DanhSachHocBongID", SqlDbType.Int, pTC_DanhSachHocBongInfo.TC_DanhSachHocBongID));

            RunProcedure("sp_TC_DanhSachHocBong_Delete", colParam);
        }
    }
}
