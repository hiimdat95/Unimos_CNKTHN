using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDGG_GiangDayGiaoVien : cDBase
    {
        public DataTable Get(GG_GiangDayGiaoVienInfo pGG_GiangDayGiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@GG_GiangDayGiaoVienID",SqlDbType.BigInt,pGG_GiangDayGiaoVienInfo.GG_GiangDayGiaoVienID));

            return RunProcedureGet("sp_GG_GiangDayGiaoVien_Get", colParam);            
        }

        public long Add(GG_GiangDayGiaoVienInfo pGG_GiangDayGiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pGG_GiangDayGiaoVienInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pGG_GiangDayGiaoVienInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pGG_GiangDayGiaoVienInfo.HocKy));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy",SqlDbType.BigInt,pGG_GiangDayGiaoVienInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@SoNhom", SqlDbType.Int, pGG_GiangDayGiaoVienInfo.SoNhom));
            colParam.Add(CreateParam("@SoSinhVien",SqlDbType.Int,pGG_GiangDayGiaoVienInfo.SoSinhVien));
            colParam.Add(CreateParam("@LyThuyet",SqlDbType.Int,pGG_GiangDayGiaoVienInfo.LyThuyet));
            colParam.Add(CreateParam("@LyThuyetQuyChuan",SqlDbType.Float,pGG_GiangDayGiaoVienInfo.LyThuyetQuyChuan));
            colParam.Add(CreateParam("@ThucHanh",SqlDbType.Int,pGG_GiangDayGiaoVienInfo.ThucHanh));
            colParam.Add(CreateParam("@ThucHanhQuyChuan",SqlDbType.Float,pGG_GiangDayGiaoVienInfo.ThucHanhQuyChuan));
            colParam.Add(CreateParam("@HeSoLopDong", SqlDbType.Float, pGG_GiangDayGiaoVienInfo.HeSoLopDong));
            colParam.Add(CreateParam("@SoGioChuan",SqlDbType.Float,pGG_GiangDayGiaoVienInfo.SoGioChuan));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pGG_GiangDayGiaoVienInfo.GhiChu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.BigInt));

            return (long)RunProcedureOut("sp_GG_GiangDayGiaoVien_Add", colParam);
        }
        
        public void Update(GG_GiangDayGiaoVienInfo pGG_GiangDayGiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pGG_GiangDayGiaoVienInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pGG_GiangDayGiaoVienInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pGG_GiangDayGiaoVienInfo.HocKy));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy",SqlDbType.BigInt,pGG_GiangDayGiaoVienInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@SoNhom", SqlDbType.Int, pGG_GiangDayGiaoVienInfo.SoNhom));
            colParam.Add(CreateParam("@SoSinhVien",SqlDbType.Int,pGG_GiangDayGiaoVienInfo.SoSinhVien));
            colParam.Add(CreateParam("@LyThuyet",SqlDbType.Int,pGG_GiangDayGiaoVienInfo.LyThuyet));
            colParam.Add(CreateParam("@LyThuyetQuyChuan",SqlDbType.Float,pGG_GiangDayGiaoVienInfo.LyThuyetQuyChuan));
            colParam.Add(CreateParam("@ThucHanh",SqlDbType.Int,pGG_GiangDayGiaoVienInfo.ThucHanh));
            colParam.Add(CreateParam("@ThucHanhQuyChuan",SqlDbType.Float,pGG_GiangDayGiaoVienInfo.ThucHanhQuyChuan));
            colParam.Add(CreateParam("@HeSoLopDong", SqlDbType.Float, pGG_GiangDayGiaoVienInfo.HeSoLopDong));
            colParam.Add(CreateParam("@SoGioChuan",SqlDbType.Float,pGG_GiangDayGiaoVienInfo.SoGioChuan));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pGG_GiangDayGiaoVienInfo.GhiChu));
            colParam.Add(CreateParam("@GG_GiangDayGiaoVienID",SqlDbType.BigInt,pGG_GiangDayGiaoVienInfo.GG_GiangDayGiaoVienID));

            RunProcedure("sp_GG_GiangDayGiaoVien_Update", colParam);
        }
        
        public void Delete(GG_GiangDayGiaoVienInfo pGG_GiangDayGiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@GG_GiangDayGiaoVienID",SqlDbType.BigInt,pGG_GiangDayGiaoVienInfo.GG_GiangDayGiaoVienID));

            RunProcedure("sp_GG_GiangDayGiaoVien_Delete", colParam);
        }
    }
}
