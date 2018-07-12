using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_DoiTuongMienGiam : cDBase
    {
        public DataTable Get(SV_DoiTuongMienGiamInfo pSV_DoiTuongMienGiamInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_DoiTuongMienGiamID",SqlDbType.Int,pSV_DoiTuongMienGiamInfo.SV_DoiTuongMienGiamID));

            return RunProcedureGet("sp_SV_DoiTuongMienGiam_Get", colParam);            
        }

        public int Add(SV_DoiTuongMienGiamInfo pSV_DoiTuongMienGiamInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_DoiTuongMienGiamInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_DoiTuongMienGiam",SqlDbType.Int,pSV_DoiTuongMienGiamInfo.IDDM_DoiTuongMienGiam));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pSV_DoiTuongMienGiamInfo.HocKy));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pSV_DoiTuongMienGiamInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pSV_DoiTuongMienGiamInfo.GhiChu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_SV_DoiTuongMienGiam_Add", colParam);
        }
        
        public void Update(SV_DoiTuongMienGiamInfo pSV_DoiTuongMienGiamInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_DoiTuongMienGiamInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_DoiTuongMienGiam",SqlDbType.Int,pSV_DoiTuongMienGiamInfo.IDDM_DoiTuongMienGiam));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pSV_DoiTuongMienGiamInfo.HocKy));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pSV_DoiTuongMienGiamInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pSV_DoiTuongMienGiamInfo.GhiChu));
            colParam.Add(CreateParam("@SV_DoiTuongMienGiamID",SqlDbType.Int,pSV_DoiTuongMienGiamInfo.SV_DoiTuongMienGiamID));

            RunProcedure("sp_SV_DoiTuongMienGiam_Update", colParam);
        }
        
        public void Delete(SV_DoiTuongMienGiamInfo pSV_DoiTuongMienGiamInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_DoiTuongMienGiamID",SqlDbType.Int,pSV_DoiTuongMienGiamInfo.SV_DoiTuongMienGiamID));

            RunProcedure("sp_SV_DoiTuongMienGiam_Delete", colParam);
        }
    }
}
