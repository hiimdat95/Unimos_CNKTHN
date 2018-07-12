using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_ToChucThi : cDBase
    {
        public DataTable GetByMonHoc(int IDDM_MonHoc, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_KQHT_ToChucThi_GetByMonHoc", colParam);
        }

        public DataTable GetDotThiByMonHoc(int IDDM_MonHoc, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_KQHT_ToChucThi_GetDotThiByMonHoc", colParam);
        }

        public DataTable GetDanhSachByDotThi(int IDKQHT_ToChucThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_ToChucThi", SqlDbType.Int, IDKQHT_ToChucThi));

            return RunProcedureGet("sp_KQHT_ToChucThi_GetDanhSachByDotThi", colParam);
        }

        public DataTable GetPhongThi(int IDKQHT_ToChucThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_ToChucThi", SqlDbType.Int, IDKQHT_ToChucThi));

            return RunProcedureGet("sp_KQHT_ToChucThi_GetPhongThi", colParam);
        }

        public DataTable GetDanhSachDuThi_TotNghiep(int IDKQHT_ToChucThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_ToChucThi", SqlDbType.Int, IDKQHT_ToChucThi));

            return RunProcedureGet("sp_KQHT_ToChucThi_GetDanhSachDuThi_TotNghiep", colParam);
        }

        public void UpdateDongTui(bool DongTui, int KQHT_ToChucThiID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DongTui", SqlDbType.Bit, DongTui));
            colParam.Add(CreateParam("@KQHT_ToChucThiID", SqlDbType.Int, KQHT_ToChucThiID));

            RunProcedure("sp_KQHT_ToChucThi_UpdateDongTui", colParam);
        }
    }
}
