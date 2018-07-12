using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_PhanBoQuyHocBong : cDBase
    {
        public DataTable Get(TC_PhanBoQuyHocBongInfo pTC_PhanBoQuyHocBongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_PhanBoQuyHocBongID",SqlDbType.Int,pTC_PhanBoQuyHocBongInfo.TC_PhanBoQuyHocBongID));

            return RunProcedureGet("sp_TC_PhanBoQuyHocBong_Get", colParam);            
        }

        public int Add(TC_PhanBoQuyHocBongInfo pTC_PhanBoQuyHocBongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pTC_PhanBoQuyHocBongInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pTC_PhanBoQuyHocBongInfo.HocKy));
            colParam.Add(CreateParam("@IDTC_QuyHocBong",SqlDbType.Int,pTC_PhanBoQuyHocBongInfo.IDTC_QuyHocBong));
            colParam.Add(CreateParam("@IDDM_Khoa",SqlDbType.Int,pTC_PhanBoQuyHocBongInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc",SqlDbType.Int,pTC_PhanBoQuyHocBongInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh",SqlDbType.Int,pTC_PhanBoQuyHocBongInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pTC_PhanBoQuyHocBongInfo.IDDM_Lop));
            colParam.Add(CreateParam("@SoSinhVien",SqlDbType.Int,pTC_PhanBoQuyHocBongInfo.SoSinhVien));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pTC_PhanBoQuyHocBongInfo.SoTien));
            colParam.Add(CreateParam("@PhanDacBiet",SqlDbType.Bit,pTC_PhanBoQuyHocBongInfo.PhanDacBiet));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_TC_PhanBoQuyHocBong_Add", colParam);
        }
        
        public void Update(TC_PhanBoQuyHocBongInfo pTC_PhanBoQuyHocBongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pTC_PhanBoQuyHocBongInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pTC_PhanBoQuyHocBongInfo.HocKy));
            colParam.Add(CreateParam("@IDTC_QuyHocBong",SqlDbType.Int,pTC_PhanBoQuyHocBongInfo.IDTC_QuyHocBong));
            colParam.Add(CreateParam("@IDDM_Khoa",SqlDbType.Int,pTC_PhanBoQuyHocBongInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc",SqlDbType.Int,pTC_PhanBoQuyHocBongInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_Nganh",SqlDbType.Int,pTC_PhanBoQuyHocBongInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pTC_PhanBoQuyHocBongInfo.IDDM_Lop));
            colParam.Add(CreateParam("@SoSinhVien",SqlDbType.Int,pTC_PhanBoQuyHocBongInfo.SoSinhVien));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pTC_PhanBoQuyHocBongInfo.SoTien));
            colParam.Add(CreateParam("@PhanDacBiet",SqlDbType.Bit,pTC_PhanBoQuyHocBongInfo.PhanDacBiet));
            colParam.Add(CreateParam("@TC_PhanBoQuyHocBongID",SqlDbType.Int,pTC_PhanBoQuyHocBongInfo.TC_PhanBoQuyHocBongID));

            RunProcedure("sp_TC_PhanBoQuyHocBong_Update", colParam);
        }
        
        public void Delete(TC_PhanBoQuyHocBongInfo pTC_PhanBoQuyHocBongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_PhanBoQuyHocBongID",SqlDbType.Int,pTC_PhanBoQuyHocBongInfo.TC_PhanBoQuyHocBongID));

            RunProcedure("sp_TC_PhanBoQuyHocBong_Delete", colParam);
        }
    }
}
