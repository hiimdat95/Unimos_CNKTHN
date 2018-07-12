using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_SinhVien_Lop : cDBase
    {
        public DataTable Get(SV_SinhVien_LopInfo pSV_SinhVien_LopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_SinhVien_LopID",SqlDbType.Int,pSV_SinhVien_LopInfo.SV_SinhVien_LopID));

            return RunProcedureGet("sp_SV_SinhVien_Lop_Get", colParam);            
        }

        public int Add(SV_SinhVien_LopInfo pSV_SinhVien_LopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_SinhVien_LopInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pSV_SinhVien_LopInfo.IDDM_Lop));
            colParam.Add(CreateParam("@TrangThaiSinhVien", SqlDbType.Bit, pSV_SinhVien_LopInfo.TrangThaiSinhVien));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_SV_SinhVien_Lop_Add", colParam);
        }
        
        public void Update(SV_SinhVien_LopInfo pSV_SinhVien_LopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_SinhVien_LopInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pSV_SinhVien_LopInfo.IDDM_Lop));
            colParam.Add(CreateParam("@TrangThaiSinhVien", SqlDbType.Bit, pSV_SinhVien_LopInfo.TrangThaiSinhVien));
            colParam.Add(CreateParam("@SV_SinhVien_LopID",SqlDbType.Int,pSV_SinhVien_LopInfo.SV_SinhVien_LopID));

            RunProcedure("sp_SV_SinhVien_Lop_Update", colParam);
        }
        
        public void Delete(SV_SinhVien_LopInfo pSV_SinhVien_LopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_SinhVien_LopID",SqlDbType.Int,pSV_SinhVien_LopInfo.SV_SinhVien_LopID));

            RunProcedure("sp_SV_SinhVien_Lop_Delete", colParam);
        }
    }
}
