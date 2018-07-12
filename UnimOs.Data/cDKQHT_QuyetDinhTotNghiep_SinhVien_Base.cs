using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_QuyetDinhTotNghiep_SinhVien : cDBase
    {
        public DataTable Get(KQHT_QuyetDinhTotNghiep_SinhVienInfo pKQHT_QuyetDinhTotNghiep_SinhVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_QuyetDinhTotNghiep_SinhVienID",SqlDbType.BigInt,pKQHT_QuyetDinhTotNghiep_SinhVienInfo.KQHT_QuyetDinhTotNghiep_SinhVienID));

            return RunProcedureGet("sp_KQHT_QuyetDinhTotNghiep_SinhVien_Get", colParam);            
        }

        public long Add(KQHT_QuyetDinhTotNghiep_SinhVienInfo pKQHT_QuyetDinhTotNghiep_SinhVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_QuyetDinhTotNghiep",SqlDbType.Int,pKQHT_QuyetDinhTotNghiep_SinhVienInfo.IDKQHT_QuyetDinhTotNghiep));
            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_QuyetDinhTotNghiep_SinhVienInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@DiemMonTotNghiep1",SqlDbType.Float,pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep1));
            colParam.Add(CreateParam("@DiemMonTotNghiep2",SqlDbType.Float,pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep2));
            colParam.Add(CreateParam("@DiemMonTotNghiep3",SqlDbType.Float,pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep3));
            colParam.Add(CreateParam("@DiemMonTotNghiep4",SqlDbType.Float,pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep4));
            colParam.Add(CreateParam("@DiemTrungBinhChungToanKhoa",SqlDbType.Float,pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemTrungBinhChungToanKhoa));
            colParam.Add(CreateParam("@DiemTrungBinhChungTotNghiep",SqlDbType.Float,pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemTrungBinhChungTotNghiep));
            colParam.Add(CreateParam("@DiemXepLoaiTotNghiep", SqlDbType.Float, pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemXepLoaiTotNghiep));
            colParam.Add(CreateParam("@IDKQHT_XepLoaiTotNghiep",SqlDbType.Int,pKQHT_QuyetDinhTotNghiep_SinhVienInfo.IDKQHT_XepLoaiTotNghiep));
            colParam.Add(CreateParamOut("@ID", SqlDbType.BigInt));

            return (long)RunProcedureOut("sp_KQHT_QuyetDinhTotNghiep_SinhVien_Add", colParam);
        }
        
        public void Update(KQHT_QuyetDinhTotNghiep_SinhVienInfo pKQHT_QuyetDinhTotNghiep_SinhVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_QuyetDinhTotNghiep",SqlDbType.Int,pKQHT_QuyetDinhTotNghiep_SinhVienInfo.IDKQHT_QuyetDinhTotNghiep));
            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_QuyetDinhTotNghiep_SinhVienInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@DiemMonTotNghiep1",SqlDbType.Float,pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep1));
            colParam.Add(CreateParam("@DiemMonTotNghiep2",SqlDbType.Float,pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep2));
            colParam.Add(CreateParam("@DiemMonTotNghiep3",SqlDbType.Float,pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep3));
            colParam.Add(CreateParam("@DiemMonTotNghiep4",SqlDbType.Float,pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemMonTotNghiep4));
            colParam.Add(CreateParam("@DiemTrungBinhChungToanKhoa",SqlDbType.Float,pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemTrungBinhChungToanKhoa));
            colParam.Add(CreateParam("@DiemTrungBinhChungTotNghiep",SqlDbType.Float,pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemTrungBinhChungTotNghiep));
            colParam.Add(CreateParam("@DiemXepLoaiTotNghiep", SqlDbType.Float, pKQHT_QuyetDinhTotNghiep_SinhVienInfo.DiemXepLoaiTotNghiep));
            colParam.Add(CreateParam("@IDKQHT_XepLoaiTotNghiep",SqlDbType.Int,pKQHT_QuyetDinhTotNghiep_SinhVienInfo.IDKQHT_XepLoaiTotNghiep));
            colParam.Add(CreateParam("@KQHT_QuyetDinhTotNghiep_SinhVienID",SqlDbType.BigInt,pKQHT_QuyetDinhTotNghiep_SinhVienInfo.KQHT_QuyetDinhTotNghiep_SinhVienID));

            RunProcedure("sp_KQHT_QuyetDinhTotNghiep_SinhVien_Update", colParam);
        }
        
        public void Delete(KQHT_QuyetDinhTotNghiep_SinhVienInfo pKQHT_QuyetDinhTotNghiep_SinhVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_QuyetDinhTotNghiep_SinhVienID",SqlDbType.BigInt,pKQHT_QuyetDinhTotNghiep_SinhVienInfo.KQHT_QuyetDinhTotNghiep_SinhVienID));

            RunProcedure("sp_KQHT_QuyetDinhTotNghiep_SinhVien_Delete", colParam);
        }
    }
}
