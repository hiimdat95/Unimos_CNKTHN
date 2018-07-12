using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DiemTongKetToanKhoa : cDBase
    {
        public DataTable Get(KQHT_DiemTongKetToanKhoaInfo pKQHT_DiemTongKetToanKhoaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DiemTongKetToanKhoaID", SqlDbType.BigInt, pKQHT_DiemTongKetToanKhoaInfo.KQHT_DiemTongKetToanKhoaID));

            return RunProcedureGet("sp_KQHT_DiemTongKetToanKhoa_Get", colParam);            
        }

        public int Add(KQHT_DiemTongKetToanKhoaInfo pKQHT_DiemTongKetToanKhoaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DiemTongKetToanKhoaInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@Diem",SqlDbType.Float,pKQHT_DiemTongKetToanKhoaInfo.Diem));
            colParam.Add(CreateParam("@DiemTHXL", SqlDbType.Float, pKQHT_DiemTongKetToanKhoaInfo.DiemTHXL));
            colParam.Add(CreateParam("@IDDM_XepLoai",SqlDbType.Int,pKQHT_DiemTongKetToanKhoaInfo.IDDM_XepLoai));
            colParam.Add(CreateParam("@DiemTBMH", SqlDbType.Float, pKQHT_DiemTongKetToanKhoaInfo.DiemTBMH));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, pKQHT_DiemTongKetToanKhoaInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, pKQHT_DiemTongKetToanKhoaInfo.LanThi));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pKQHT_DiemTongKetToanKhoaInfo.GhiChu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_DiemTongKetToanKhoa_Add", colParam);
        }
        
        public void Update(KQHT_DiemTongKetToanKhoaInfo pKQHT_DiemTongKetToanKhoaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DiemTongKetToanKhoaInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@Diem",SqlDbType.Float,pKQHT_DiemTongKetToanKhoaInfo.Diem));
            colParam.Add(CreateParam("@DiemTHXL", SqlDbType.Float, pKQHT_DiemTongKetToanKhoaInfo.DiemTHXL));
            colParam.Add(CreateParam("@IDDM_XepLoai",SqlDbType.Int,pKQHT_DiemTongKetToanKhoaInfo.IDDM_XepLoai));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pKQHT_DiemTongKetToanKhoaInfo.GhiChu));
            colParam.Add(CreateParam("@DiemTBMH", SqlDbType.Float, pKQHT_DiemTongKetToanKhoaInfo.DiemTBMH));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, pKQHT_DiemTongKetToanKhoaInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, pKQHT_DiemTongKetToanKhoaInfo.LanThi));
            colParam.Add(CreateParam("@KQHT_DiemTongKetToanKhoaID",SqlDbType.BigInt,pKQHT_DiemTongKetToanKhoaInfo.KQHT_DiemTongKetToanKhoaID));

            RunProcedure("sp_KQHT_DiemTongKetToanKhoa_Update", colParam);
        }
        
        public void Delete(KQHT_DiemTongKetToanKhoaInfo pKQHT_DiemTongKetToanKhoaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DiemTongKetToanKhoaID", SqlDbType.BigInt, pKQHT_DiemTongKetToanKhoaInfo.KQHT_DiemTongKetToanKhoaID));

            RunProcedure("sp_KQHT_DiemTongKetToanKhoa_Delete", colParam);
        }
    }
}
