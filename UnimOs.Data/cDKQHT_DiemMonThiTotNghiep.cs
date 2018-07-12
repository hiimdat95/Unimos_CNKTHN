using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DiemMonThiTotNghiep : cDBase
    {
        public DataTable GetDanhSach(int IDDM_Lop, int IDKQHT_MonThiTotNghiep_Lop, int LanThi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.BigInt, IDDM_Lop));
            colParam.Add(CreateParam("@IDKQHT_MonThiTotNghiep_Lop", SqlDbType.Int, IDKQHT_MonThiTotNghiep_Lop));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, LanThi));

            return RunProcedureGet("sp_KQHT_DiemMonThiTotNghiep_GetDanhSach", colParam);
        }

        public void AddUpdate(KQHT_DiemMonThiTotNghiepInfo pKQHT_DiemMonThiTotNghiepInfo, int IDDM_MonHoc, int IDDM_Lop)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, pKQHT_DiemMonThiTotNghiepInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, IDDM_Lop));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, pKQHT_DiemMonThiTotNghiepInfo.LanThi));
            colParam.Add(CreateParam("@Diem", SqlDbType.Real, pKQHT_DiemMonThiTotNghiepInfo.Diem));
            colParam.Add(CreateParam("@IDKQHT_XepLoai", SqlDbType.Int, pKQHT_DiemMonThiTotNghiepInfo.IDKQHT_XepLoai));

            RunProcedure("sp_KQHT_DiemMonThiTotNghiep_AddUpdate", colParam);
        }
    }
}
