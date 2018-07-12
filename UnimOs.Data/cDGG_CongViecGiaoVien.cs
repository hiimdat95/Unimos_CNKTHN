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
        public DataTable Get(int IDNS_GiaoVien, int IDNamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDNamHoc", SqlDbType.Int, IDNamHoc));

            return RunProcedureGet("sp_GG_CongViecGiaoVien_Get_ByNamHoc", colParam);
        }

        public DataTable GetByHocKy(int IDDM_NamHoc, int HocKy, int IDNS_DonVi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@IDNS_DonVi", SqlDbType.Int, IDNS_DonVi));

            return RunProcedureGet("sp_GG_CongViecGiaoVien_GetAllByHocKy", colParam);
        }

        public DataTable GetByIDDM_LoaiCongViec(int IDDM_LoaiCongViec, int IDNS_DonVi, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_LoaiCongViec", SqlDbType.Int, IDDM_LoaiCongViec));
            colParam.Add(CreateParam("@IDNS_DonVi", SqlDbType.Int, IDNS_DonVi));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_GG_CongViecGiaoVien_GetByIDDM_LoaiCongViec", colParam);
        }

        public long UpdateAdd(GG_CongViecGiaoVienInfo pGG_CongViecGiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_LoaiCongViec", SqlDbType.Int, pGG_CongViecGiaoVienInfo.IDDM_LoaiCongViec));
            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, pGG_CongViecGiaoVienInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoGio", SqlDbType.Float, pGG_CongViecGiaoVienInfo.SoGio));
            colParam.Add(CreateParam("@HeSo", SqlDbType.Float, pGG_CongViecGiaoVienInfo.HeSo));
            colParam.Add(CreateParam("@GioQuyChuan", SqlDbType.Float, pGG_CongViecGiaoVienInfo.GioQuyChuan));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, pGG_CongViecGiaoVienInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, pGG_CongViecGiaoVienInfo.HocKy));
            colParam.Add(CreateParam("@GhiChu", SqlDbType.NVarChar, pGG_CongViecGiaoVienInfo.GhiChu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.BigInt));

            return (long)RunProcedureOut("sp_GG_CongViecGiaoVien_UpdateAdd", colParam);
        }

        public void DeleteNotIn(int IDNS_GiaoVien, int IDDM_NamHoc, int HocKy, string IDCVNotIn)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@IDCVNotIn", SqlDbType.NVarChar, IDCVNotIn));

            RunProcedure("sp_GG_CongViecGiaoVien_DeleteNotIn", colParam);
        }
    }
}
