using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDGG_CongViecGiaoVien : cDBase
    {
        public DataTable Get(GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@GG_CongViecGiaoVienID",SqlDbType.Int,pGG_CongViecGiaoVienInfo.GG_CongViecGiaoVienID));

            return RunProcedureGet("sp_GG_CongViecGiaoVien_Get", colParam);            
        }

        public long Add(GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_LoaiCongViec",SqlDbType.Int,pGG_CongViecGiaoVienInfo.IDDM_LoaiCongViec));
            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pGG_CongViecGiaoVienInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoGio",SqlDbType.Float,pGG_CongViecGiaoVienInfo.SoGio));
            colParam.Add(CreateParam("@HeSo",SqlDbType.Float,pGG_CongViecGiaoVienInfo.HeSo));
            colParam.Add(CreateParam("@GioQuyChuan",SqlDbType.Float,pGG_CongViecGiaoVienInfo.GioQuyChuan));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pGG_CongViecGiaoVienInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pGG_CongViecGiaoVienInfo.HocKy));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pGG_CongViecGiaoVienInfo.GhiChu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.BigInt));

            return (long)RunProcedureOut("sp_GG_CongViecGiaoVien_Add", colParam);
        }
        
        public void Update(GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_LoaiCongViec",SqlDbType.Int,pGG_CongViecGiaoVienInfo.IDDM_LoaiCongViec));
            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pGG_CongViecGiaoVienInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoGio", SqlDbType.Float, pGG_CongViecGiaoVienInfo.SoGio));
            colParam.Add(CreateParam("@HeSo",SqlDbType.Float,pGG_CongViecGiaoVienInfo.HeSo));
            colParam.Add(CreateParam("@GioQuyChuan",SqlDbType.Float,pGG_CongViecGiaoVienInfo.GioQuyChuan));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pGG_CongViecGiaoVienInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pGG_CongViecGiaoVienInfo.HocKy));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pGG_CongViecGiaoVienInfo.GhiChu));
            colParam.Add(CreateParam("@GG_CongViecGiaoVienID",SqlDbType.Int,pGG_CongViecGiaoVienInfo.GG_CongViecGiaoVienID));

            RunProcedure("sp_GG_CongViecGiaoVien_Update", colParam);
        }
        
        public void Delete(GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@GG_CongViecGiaoVienID",SqlDbType.Int,pGG_CongViecGiaoVienInfo.GG_CongViecGiaoVienID));

            RunProcedure("sp_GG_CongViecGiaoVien_Delete", colParam);
        }
    }
}
