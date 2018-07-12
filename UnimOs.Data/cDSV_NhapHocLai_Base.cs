using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_NhapHocLai : cDBase
    {
        public DataTable Get(SV_NhapHocLaiInfo pSV_NhapHocLaiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_NhapHocLaiID",SqlDbType.Int,pSV_NhapHocLaiInfo.SV_NhapHocLaiID));

            return RunProcedureGet("sp_SV_NhapHocLai_Get", colParam);            
        }

        public int Add(SV_NhapHocLaiInfo pSV_NhapHocLaiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_NhapHocLaiInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_LopCu",SqlDbType.Int,pSV_NhapHocLaiInfo.IDDM_LopCu));
            colParam.Add(CreateParam("@IDDM_LopMoi",SqlDbType.Int,pSV_NhapHocLaiInfo.IDDM_LopMoi));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pSV_NhapHocLaiInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pSV_NhapHocLaiInfo.HocKy));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_SV_NhapHocLai_Add", colParam);
        }
        
        public void Update(SV_NhapHocLaiInfo pSV_NhapHocLaiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_NhapHocLaiInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_LopCu",SqlDbType.Int,pSV_NhapHocLaiInfo.IDDM_LopCu));
            colParam.Add(CreateParam("@IDDM_LopMoi",SqlDbType.Int,pSV_NhapHocLaiInfo.IDDM_LopMoi));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pSV_NhapHocLaiInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pSV_NhapHocLaiInfo.HocKy));
            colParam.Add(CreateParam("@SV_NhapHocLaiID",SqlDbType.Int,pSV_NhapHocLaiInfo.SV_NhapHocLaiID));

            RunProcedure("sp_SV_NhapHocLai_Update", colParam);
        }
        
        public void Delete(SV_NhapHocLaiInfo pSV_NhapHocLaiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_NhapHocLaiID",SqlDbType.Int,pSV_NhapHocLaiInfo.SV_NhapHocLaiID));

            RunProcedure("sp_SV_NhapHocLai_Delete", colParam);
        }
    }
}
