using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DanhSachKhongThi : cDBase
    {
        public DataTable GetIn_SinhVien(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));

            return RunProcedureGet("sp_KQHT_DanhSachKhongThi_GetIn_SinhVien", colParam);
        }

        public DataTable GetNotIn_SinhVien(int IDDM_Lop, int IDDM_MonHoc, int IDDM_NamHoc, int HocKy, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));

            return RunProcedureGet("sp_KQHT_DanhSachKhongThi_GetNotIn_SinhVien", colParam);
        }

        public int AddTuDong(KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, pKQHT_DanhSachKhongThiInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, pKQHT_DanhSachKhongThiInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, pKQHT_DanhSachKhongThiInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, pKQHT_DanhSachKhongThiInfo.HocKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, pKQHT_DanhSachKhongThiInfo.LanThi));
            colParam.Add(CreateParam("@SoTietHocLai", SqlDbType.Int, pKQHT_DanhSachKhongThiInfo.SoTietHocLai));
            colParam.Add(CreateParam("@LyDo", SqlDbType.NVarChar, pKQHT_DanhSachKhongThiInfo.LyDo));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_DanhSachKhongThi_AddTuDong", colParam);
        }

        public void DeleteTuDong(KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, pKQHT_DanhSachKhongThiInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, pKQHT_DanhSachKhongThiInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, pKQHT_DanhSachKhongThiInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, pKQHT_DanhSachKhongThiInfo.HocKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, pKQHT_DanhSachKhongThiInfo.LanThi));

            RunProcedure("sp_KQHT_DanhSachKhongThi_DeleteTuDong", colParam);
        }

        public void DeleteDanhSachDuThi(KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo, int IDXL_MonHocTrongKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, pKQHT_DanhSachKhongThiInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, pKQHT_DanhSachKhongThiInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, pKQHT_DanhSachKhongThiInfo.HocKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, pKQHT_DanhSachKhongThiInfo.LanThi));

            RunProcedure("sp_KQHT_DanhSachKhongThi_DeleteDanhSachDuThi", colParam);
        }
    }
}
