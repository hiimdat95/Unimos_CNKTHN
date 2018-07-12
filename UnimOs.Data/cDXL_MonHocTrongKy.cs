using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_MonHocTrongKy : cDBase
    {
        public DataTable GetToChucThi(int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_XL_MonHocTrongKy_GetToChucThi", colParam);
        }

        public DataTable GetMonKy(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_XL_MonHocTrongKy_GetMonKy", colParam);
        }

        public DataTable GetMonKyToanKhoaByLop(int IDDM_Lop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));

            return RunProcedureGet("sp_XL_MonHocTrongKy_GetMonKyToanKhoaByLop", colParam);
        }

        public DataTable GetMonKyChuaThucHanh(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_XL_MonHocTrongKy_GetMonKyChuaThucHanh", colParam);
        }

        public DataTable GetByLop(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_XL_MonHocTrongKy_GetByLop", colParam);
        }

        public DataTable GetByLopKhoa(int IDDM_Lop, int IDKhoa_GiaoVu, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDKhoa_GiaoVu", SqlDbType.Int, IDKhoa_GiaoVu));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_XL_MonHocTrongKy_GetByLopKhoa", colParam);
        }

        public DataTable GetToanKhoa(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_XL_MonHocTrongKy_GetToanKhoa", colParam);
        }

        public DataTable GetByHocKyNamHoc(int IDDM_Lop, int HocKy, int IDDM_NamHoc, int IDDM_Khoa, int IDDM_BoMon)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_BoMon", SqlDbType.Int, IDDM_BoMon));

            return RunProcedureGet("sp_XL_MonHocTrongKy_GetByHocKyNamHoc", colParam);
        }

        public DataTable GetByIDGiaoVien(int IDNS_GiaoVien, int IDDM_Lop, int HocKy, int IDDM_NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));

            return RunProcedureGet("sp_XL_MonHocTrongKy_GetByIDGiaoVien", colParam);
        }

        public DataTable GetNhapDuLieuByHocKyNamHoc(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_XL_MonHocTrongKy_GetNhapDuLieuByHocKyNamHoc", colParam);
        }

        public DataTable GetAllByHocKyNamHoc(int IDDM_Lop, int HocKy, int IDDM_NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));

            return RunProcedureGet("sp_XL_MonHocTrongKy_GetAllByHocKyNamHoc", colParam);
        }

        public DataTable GetByLopGop(string IDDM_Lops, int HocKy, int IDDM_NamHoc, int SoLop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lops", SqlDbType.VarChar,100, IDDM_Lops));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@SoLop", SqlDbType.Int, SoLop));

            return RunProcedureGet("sp_XL_MonHocTrongKy_GetByLopGop", colParam);
        }

        public void ChuyenDiemByChuyenLop(int IDSV_SinhVien, int IDXL_MonHocTrongKy_Cu, int IDDM_MonHoc_Cu, int IDXL_MonHocTrongKy_Moi, int IDDM_MonHoc_Moi,
            int IDDM_NamHoc_Moi, int HocKy_Moi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy_Cu", SqlDbType.Int, IDXL_MonHocTrongKy_Cu));
            colParam.Add(CreateParam("@IDDM_MonHoc_Cu", SqlDbType.Int, IDDM_MonHoc_Cu));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy_Moi", SqlDbType.Int, IDXL_MonHocTrongKy_Moi));
            colParam.Add(CreateParam("@IDDM_MonHoc_Moi", SqlDbType.Int, IDDM_MonHoc_Moi));
            colParam.Add(CreateParam("@IDDM_NamHoc_Moi", SqlDbType.Int, IDDM_NamHoc_Moi));
            colParam.Add(CreateParam("@HocKy_Moi", SqlDbType.Int, HocKy_Moi));

            RunProcedure("sp_XL_MonHocTrongKy_ChuyenDiemByChuyenLop", colParam);
        }

        public void DeleteByHocKyNamHoc(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            RunProcedure("sp_XL_MonHocTrongKy_DeleteByHocKyNamHoc", colParam);
        }

        public void DeleteMonHocNotIn(int IDDM_Lop, int IDDM_NamHoc, int HocKy, string IDDM_MonHocs)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@IDKQHT_CTDT_ChiTiets", SqlDbType.NVarChar, IDDM_MonHocs));

            RunProcedure("sp_XL_MonHocTrongKy_DeleteMonHocNotIn", colParam);
        }

        public void UpdateTachGop(int XL_MonHocTrongKyID, bool HocOLopTachGop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HocOLopTachGop", SqlDbType.Bit, HocOLopTachGop));
            colParam.Add(CreateParam("@XL_MonHocTrongKyID", SqlDbType.Int, XL_MonHocTrongKyID));

            RunProcedure("sp_XL_MonHocTrongKy_UpdateTachGop", colParam);
        }

        public void ApDungCacLopKhac(int DM_LopID, int DM_LopIDNew,int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_LopID", SqlDbType.Int, DM_LopID));
            colParam.Add(CreateParam("@DM_LopIDNew", SqlDbType.Int, DM_LopIDNew));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            RunProcedure("sp_XL_MonHocTrongKy_ApDungLopKhac", colParam);
        }

        public DataTable GetDiemMonByIDSV_SinhVienAndIDDM_Lop(int IDSV_SinhVien, int IDDM_Lop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));

            return RunProcedureGet("sp_XL_MonHocTrongKy_GetDiemMonByIDSV_SinhVienAndIDDM_Lop", colParam);
        }
    }
}
