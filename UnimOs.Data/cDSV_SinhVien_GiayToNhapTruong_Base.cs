using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_SinhVien_GiayToNhapTruong : cDBase
    {
        public DataTable Get(SV_SinhVien_GiayToNhapTruongInfo pSV_SinhVien_GiayToNhapTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_SinhVien_GiayToNhapTruongID",SqlDbType.Int,pSV_SinhVien_GiayToNhapTruongInfo.SV_SinhVien_GiayToNhapTruongID));

            return RunProcedureGet("sp_SV_SinhVien_GiayToNhapTruong_Get", colParam);            
        }

        public int Add(SV_SinhVien_GiayToNhapTruongInfo pSV_SinhVien_GiayToNhapTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_SinhVien_GiayToNhapTruongInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDSV_SinhVienNhapTruong",SqlDbType.Int,pSV_SinhVien_GiayToNhapTruongInfo.IDSV_SinhVienNhapTruong));
            colParam.Add(CreateParam("@IDDM_GiayToNhapTruong",SqlDbType.Int,pSV_SinhVien_GiayToNhapTruongInfo.IDDM_GiayToNhapTruong));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pSV_SinhVien_GiayToNhapTruongInfo.GhiChu));
            colParam.Add(CreateParam("@DaTra",SqlDbType.Bit,pSV_SinhVien_GiayToNhapTruongInfo.DaTra));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_SV_SinhVien_GiayToNhapTruong_Add", colParam);
        }
        
        public void Update(SV_SinhVien_GiayToNhapTruongInfo pSV_SinhVien_GiayToNhapTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_SinhVien_GiayToNhapTruongInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDSV_SinhVienNhapTruong",SqlDbType.Int,pSV_SinhVien_GiayToNhapTruongInfo.IDSV_SinhVienNhapTruong));
            colParam.Add(CreateParam("@IDDM_GiayToNhapTruong",SqlDbType.Int,pSV_SinhVien_GiayToNhapTruongInfo.IDDM_GiayToNhapTruong));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pSV_SinhVien_GiayToNhapTruongInfo.GhiChu));
            colParam.Add(CreateParam("@DaTra",SqlDbType.Bit,pSV_SinhVien_GiayToNhapTruongInfo.DaTra));
            colParam.Add(CreateParam("@SV_SinhVien_GiayToNhapTruongID",SqlDbType.Int,pSV_SinhVien_GiayToNhapTruongInfo.SV_SinhVien_GiayToNhapTruongID));

            RunProcedure("sp_SV_SinhVien_GiayToNhapTruong_Update", colParam);
        }
        
        public void Delete(SV_SinhVien_GiayToNhapTruongInfo pSV_SinhVien_GiayToNhapTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_SinhVien_GiayToNhapTruongID",SqlDbType.Int,pSV_SinhVien_GiayToNhapTruongInfo.SV_SinhVien_GiayToNhapTruongID));

            RunProcedure("sp_SV_SinhVien_GiayToNhapTruong_Delete", colParam);
        }
    }
}
