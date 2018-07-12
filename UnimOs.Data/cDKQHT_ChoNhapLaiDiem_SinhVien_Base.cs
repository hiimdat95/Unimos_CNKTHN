using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_ChoNhapLaiDiem_SinhVien : cDBase
    {
        public DataTable Get(KQHT_ChoNhapLaiDiem_SinhVienInfo pKQHT_ChoNhapLaiDiem_SinhVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_ChoNhapLaiDiem_SinhVienID",SqlDbType.Int,pKQHT_ChoNhapLaiDiem_SinhVienInfo.KQHT_ChoNhapLaiDiem_SinhVienID));

            return RunProcedureGet("sp_KQHT_ChoNhapLaiDiem_SinhVien_Get", colParam);            
        }

        public int Add(KQHT_ChoNhapLaiDiem_SinhVienInfo pKQHT_ChoNhapLaiDiem_SinhVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_ChoNhapLaiDiem",SqlDbType.Int,pKQHT_ChoNhapLaiDiem_SinhVienInfo.IDKQHT_ChoNhapLaiDiem));
            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_ChoNhapLaiDiem_SinhVienInfo.IDSV_SinhVien));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_ChoNhapLaiDiem_SinhVien_Add", colParam);
        }
        
        public void Update(KQHT_ChoNhapLaiDiem_SinhVienInfo pKQHT_ChoNhapLaiDiem_SinhVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_ChoNhapLaiDiem",SqlDbType.Int,pKQHT_ChoNhapLaiDiem_SinhVienInfo.IDKQHT_ChoNhapLaiDiem));
            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_ChoNhapLaiDiem_SinhVienInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@KQHT_ChoNhapLaiDiem_SinhVienID",SqlDbType.Int,pKQHT_ChoNhapLaiDiem_SinhVienInfo.KQHT_ChoNhapLaiDiem_SinhVienID));

            RunProcedure("sp_KQHT_ChoNhapLaiDiem_SinhVien_Update", colParam);
        }
        
        public void Delete(KQHT_ChoNhapLaiDiem_SinhVienInfo pKQHT_ChoNhapLaiDiem_SinhVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_ChoNhapLaiDiem_SinhVienID",SqlDbType.Int,pKQHT_ChoNhapLaiDiem_SinhVienInfo.KQHT_ChoNhapLaiDiem_SinhVienID));

            RunProcedure("sp_KQHT_ChoNhapLaiDiem_SinhVien_Delete", colParam);
        }
    }
}
