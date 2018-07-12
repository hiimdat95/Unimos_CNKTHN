using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_ThangRenLuyenTrongKy : cDBase
    {
        public DataTable Get(SV_ThangRenLuyenTrongKyInfo pSV_ThangRenLuyenTrongKyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_ThangRenLuyenTrongKyID",SqlDbType.Int,pSV_ThangRenLuyenTrongKyInfo.SV_ThangRenLuyenTrongKyID));

            return RunProcedureGet("sp_SV_ThangRenLuyenTrongKy_Get", colParam);            
        }

        public int Add(SV_ThangRenLuyenTrongKyInfo pSV_ThangRenLuyenTrongKyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pSV_ThangRenLuyenTrongKyInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pSV_ThangRenLuyenTrongKyInfo.HocKy));
            colParam.Add(CreateParam("@Thang",SqlDbType.Int,pSV_ThangRenLuyenTrongKyInfo.Thang));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_SV_ThangRenLuyenTrongKy_Add", colParam);
        }
        
        public void Update(SV_ThangRenLuyenTrongKyInfo pSV_ThangRenLuyenTrongKyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pSV_ThangRenLuyenTrongKyInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pSV_ThangRenLuyenTrongKyInfo.HocKy));
            colParam.Add(CreateParam("@Thang",SqlDbType.Int,pSV_ThangRenLuyenTrongKyInfo.Thang));
            colParam.Add(CreateParam("@SV_ThangRenLuyenTrongKyID",SqlDbType.Int,pSV_ThangRenLuyenTrongKyInfo.SV_ThangRenLuyenTrongKyID));

            RunProcedure("sp_SV_ThangRenLuyenTrongKy_Update", colParam);
        }
        
        public void Delete(SV_ThangRenLuyenTrongKyInfo pSV_ThangRenLuyenTrongKyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_ThangRenLuyenTrongKyID",SqlDbType.Int,pSV_ThangRenLuyenTrongKyInfo.SV_ThangRenLuyenTrongKyID));

            RunProcedure("sp_SV_ThangRenLuyenTrongKy_Delete", colParam);
        }
    }
}
