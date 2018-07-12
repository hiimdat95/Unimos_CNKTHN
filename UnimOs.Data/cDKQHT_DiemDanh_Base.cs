using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DiemDanh : cDBase
    {
        public DataTable Get(KQHT_DiemDanhInfo pKQHT_DiemDanhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DiemDanhID", SqlDbType.Int, pKQHT_DiemDanhInfo.KQHT_DiemDanhID));

            return RunProcedureGet("sp_KQHT_DiemDanh_Get", colParam);
        }

        public int Add(KQHT_DiemDanhInfo pKQHT_DiemDanhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, pKQHT_DiemDanhInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, pKQHT_DiemDanhInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@CoLyDo", SqlDbType.Int, pKQHT_DiemDanhInfo.CoLyDo));
            colParam.Add(CreateParam("@KhongLyDo", SqlDbType.Int, pKQHT_DiemDanhInfo.KhongLyDo));
            colParam.Add(CreateParam("@DiemLan", SqlDbType.Int, pKQHT_DiemDanhInfo.DiemLan));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_DiemDanh_Add", colParam);
        }

        public void Update(KQHT_DiemDanhInfo pKQHT_DiemDanhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, pKQHT_DiemDanhInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, pKQHT_DiemDanhInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@CoLyDo", SqlDbType.Int, pKQHT_DiemDanhInfo.CoLyDo));
            colParam.Add(CreateParam("@KhongLyDo", SqlDbType.Int, pKQHT_DiemDanhInfo.KhongLyDo));
            colParam.Add(CreateParam("@KQHT_DiemDanhID", SqlDbType.Int, pKQHT_DiemDanhInfo.KQHT_DiemDanhID));

            RunProcedure("sp_KQHT_DiemDanh_Update", colParam);
        }

        public void Delete(KQHT_DiemDanhInfo pKQHT_DiemDanhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DiemDanhID", SqlDbType.Int, pKQHT_DiemDanhInfo.KQHT_DiemDanhID));

            RunProcedure("sp_KQHT_DiemDanh_Delete", colParam);
        }
    }
}
