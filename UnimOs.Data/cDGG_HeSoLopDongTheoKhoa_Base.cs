using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDGG_HeSoLopDongTheoKhoa : cDBase
    {
        public DataTable Get(GG_HeSoLopDongTheoKhoaInfo pGG_HeSoLopDongTheoKhoaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@GG_HeSoLopDongTheoKhoaID",SqlDbType.Int,pGG_HeSoLopDongTheoKhoaInfo.GG_HeSoLopDongTheoKhoaID));

            return RunProcedureGet("sp_GG_HeSoLopDongTheoKhoa_Get", colParam);            
        }

        public int Add(GG_HeSoLopDongTheoKhoaInfo pGG_HeSoLopDongTheoKhoaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@LoaiGiangDay",SqlDbType.NVarChar,pGG_HeSoLopDongTheoKhoaInfo.LoaiGiangDay));
            colParam.Add(CreateParam("@IDDM_TrinhDo",SqlDbType.Int,pGG_HeSoLopDongTheoKhoaInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa",SqlDbType.Int,pGG_HeSoLopDongTheoKhoaInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@SoSVToiDa",SqlDbType.Int,pGG_HeSoLopDongTheoKhoaInfo.SoSVToiDa));
            colParam.Add(CreateParam("@HeSoQuyChuan",SqlDbType.Float,pGG_HeSoLopDongTheoKhoaInfo.HeSoQuyChuan));
            colParam.Add(CreateParam("@SoCongThem1Tiet",SqlDbType.Int,pGG_HeSoLopDongTheoKhoaInfo.SoCongThem1Tiet));
            colParam.Add(CreateParam("@SoTietDinhMuc1Tuan",SqlDbType.Float,pGG_HeSoLopDongTheoKhoaInfo.SoTietDinhMuc1Tuan));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_GG_HeSoLopDongTheoKhoa_Add", colParam);
        }
        
        public void Update(GG_HeSoLopDongTheoKhoaInfo pGG_HeSoLopDongTheoKhoaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@LoaiGiangDay",SqlDbType.NVarChar,pGG_HeSoLopDongTheoKhoaInfo.LoaiGiangDay));
            colParam.Add(CreateParam("@IDDM_TrinhDo",SqlDbType.Int,pGG_HeSoLopDongTheoKhoaInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa",SqlDbType.Int,pGG_HeSoLopDongTheoKhoaInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@SoSVToiDa",SqlDbType.Int,pGG_HeSoLopDongTheoKhoaInfo.SoSVToiDa));
            colParam.Add(CreateParam("@HeSoQuyChuan",SqlDbType.Float,pGG_HeSoLopDongTheoKhoaInfo.HeSoQuyChuan));
            colParam.Add(CreateParam("@SoCongThem1Tiet",SqlDbType.Int,pGG_HeSoLopDongTheoKhoaInfo.SoCongThem1Tiet));
            colParam.Add(CreateParam("@SoTietDinhMuc1Tuan",SqlDbType.Float,pGG_HeSoLopDongTheoKhoaInfo.SoTietDinhMuc1Tuan));
            colParam.Add(CreateParam("@GG_HeSoLopDongTheoKhoaID",SqlDbType.Int,pGG_HeSoLopDongTheoKhoaInfo.GG_HeSoLopDongTheoKhoaID));

            RunProcedure("sp_GG_HeSoLopDongTheoKhoa_Update", colParam);
        }
        
        public void Delete(GG_HeSoLopDongTheoKhoaInfo pGG_HeSoLopDongTheoKhoaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@GG_HeSoLopDongTheoKhoaID",SqlDbType.Int,pGG_HeSoLopDongTheoKhoaInfo.GG_HeSoLopDongTheoKhoaID));

            RunProcedure("sp_GG_HeSoLopDongTheoKhoa_Delete", colParam);
        }
    }
}
