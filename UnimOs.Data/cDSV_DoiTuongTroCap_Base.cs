using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_DoiTuongTroCap : cDBase
    {
        public DataTable Get(SV_DoiTuongTroCapInfo pSV_DoiTuongTroCapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_DoiTuongTroCapID",SqlDbType.Int,pSV_DoiTuongTroCapInfo.SV_DoiTuongTroCapID));

            return RunProcedureGet("sp_SV_DoiTuongTroCap_Get", colParam);            
        }

        public int Add(SV_DoiTuongTroCapInfo pSV_DoiTuongTroCapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_DoiTuongTroCapInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_DoiTuongTroCap",SqlDbType.Int,pSV_DoiTuongTroCapInfo.IDDM_DoiTuongTroCap));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pSV_DoiTuongTroCapInfo.HocKy));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pSV_DoiTuongTroCapInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pSV_DoiTuongTroCapInfo.GhiChu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_SV_DoiTuongTroCap_Add", colParam);
        }
        
        public void Update(SV_DoiTuongTroCapInfo pSV_DoiTuongTroCapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_DoiTuongTroCapInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_DoiTuongTroCap",SqlDbType.Int,pSV_DoiTuongTroCapInfo.IDDM_DoiTuongTroCap));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pSV_DoiTuongTroCapInfo.HocKy));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pSV_DoiTuongTroCapInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pSV_DoiTuongTroCapInfo.GhiChu));
            colParam.Add(CreateParam("@SV_DoiTuongTroCapID",SqlDbType.Int,pSV_DoiTuongTroCapInfo.SV_DoiTuongTroCapID));

            RunProcedure("sp_SV_DoiTuongTroCap_Update", colParam);
        }
        
        public void Delete(SV_DoiTuongTroCapInfo pSV_DoiTuongTroCapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_DoiTuongTroCapID",SqlDbType.Int,pSV_DoiTuongTroCapInfo.SV_DoiTuongTroCapID));

            RunProcedure("sp_SV_DoiTuongTroCap_Delete", colParam);
        }
    }
}
