using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DiemTongKetHocKy : cDBase
    {
        public DataTable Get(KQHT_DiemTongKetHocKyInfo pKQHT_DiemTongKetHocKyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DiemTongKetHocKyID", SqlDbType.Int, pKQHT_DiemTongKetHocKyInfo.KQHT_DiemTongKetHocKyID));

            return RunProcedureGet("sp_KQHT_DiemTongKetHocKy_Get", colParam);
        }

        public int Add(KQHT_DiemTongKetHocKyInfo pKQHT_DiemTongKetHocKyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, pKQHT_DiemTongKetHocKyInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, pKQHT_DiemTongKetHocKyInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, pKQHT_DiemTongKetHocKyInfo.HocKy));
            colParam.Add(CreateParam("@DiemL1", SqlDbType.Real, pKQHT_DiemTongKetHocKyInfo.DiemL1));
            colParam.Add(CreateParam("@IDDM_XepLoaiL1", SqlDbType.Int, pKQHT_DiemTongKetHocKyInfo.IDDM_XepLoaiL1));
            colParam.Add(CreateParam("@GhiChuL1", SqlDbType.NVarChar, pKQHT_DiemTongKetHocKyInfo.GhiChuL1));
            colParam.Add(CreateParam("@DiemL2", SqlDbType.Real, pKQHT_DiemTongKetHocKyInfo.DiemL2));
            colParam.Add(CreateParam("@IDDM_XepLoaiL2", SqlDbType.Int, pKQHT_DiemTongKetHocKyInfo.IDDM_XepLoaiL2));
            colParam.Add(CreateParam("@GhiChuL2", SqlDbType.NVarChar, pKQHT_DiemTongKetHocKyInfo.GhiChuL2));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_DiemTongKetHocKy_Add", colParam);
        }

        public void Update(KQHT_DiemTongKetHocKyInfo pKQHT_DiemTongKetHocKyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, pKQHT_DiemTongKetHocKyInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, pKQHT_DiemTongKetHocKyInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, pKQHT_DiemTongKetHocKyInfo.HocKy));
            colParam.Add(CreateParam("@DiemL1", SqlDbType.Real, pKQHT_DiemTongKetHocKyInfo.DiemL1));
            colParam.Add(CreateParam("@IDDM_XepLoaiL1", SqlDbType.Int, pKQHT_DiemTongKetHocKyInfo.IDDM_XepLoaiL1));
            colParam.Add(CreateParam("@IDDM_XepLoaiL1", SqlDbType.Int, pKQHT_DiemTongKetHocKyInfo.IDDM_XepLoaiL1));
            colParam.Add(CreateParam("@DiemL2", SqlDbType.Real, pKQHT_DiemTongKetHocKyInfo.DiemL2));
            colParam.Add(CreateParam("@IDDM_XepLoaiL2", SqlDbType.Int, pKQHT_DiemTongKetHocKyInfo.IDDM_XepLoaiL2));
            colParam.Add(CreateParam("@GhiChuL2", SqlDbType.NVarChar, pKQHT_DiemTongKetHocKyInfo.GhiChuL2));
            colParam.Add(CreateParam("@TrangThai", SqlDbType.Int, pKQHT_DiemTongKetHocKyInfo.TrangThai));
            colParam.Add(CreateParam("@KQHT_DiemTongKetHocKyID", SqlDbType.Int, pKQHT_DiemTongKetHocKyInfo.KQHT_DiemTongKetHocKyID));

            RunProcedure("sp_KQHT_DiemTongKetHocKy_Update", colParam);
        }

        public void Delete(KQHT_DiemTongKetHocKyInfo pKQHT_DiemTongKetHocKyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DiemTongKetHocKyID", SqlDbType.Int, pKQHT_DiemTongKetHocKyInfo.KQHT_DiemTongKetHocKyID));

            RunProcedure("sp_KQHT_DiemTongKetHocKy_Delete", colParam);
        }
    }
}
