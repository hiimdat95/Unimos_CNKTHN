using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_ChoNhapLaiDiem : cDBase
    {
        public DataTable Get(KQHT_ChoNhapLaiDiemInfo pKQHT_ChoNhapLaiDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_ChoNhapLaiDiemID",SqlDbType.Int,pKQHT_ChoNhapLaiDiemInfo.KQHT_ChoNhapLaiDiemID));

            return RunProcedureGet("sp_KQHT_ChoNhapLaiDiem_Get", colParam);            
        }

        public int Add(KQHT_ChoNhapLaiDiemInfo pKQHT_ChoNhapLaiDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_DaChuyenDiem",SqlDbType.Int,pKQHT_ChoNhapLaiDiemInfo.IDKQHT_DaChuyenDiem));
            colParam.Add(CreateParam("@IDHT_User",SqlDbType.Int,pKQHT_ChoNhapLaiDiemInfo.IDHT_User));
            colParam.Add(CreateParam("@LanChoNhapLai",SqlDbType.Int,pKQHT_ChoNhapLaiDiemInfo.LanChoNhapLai));
            colParam.Add(CreateParam("@NgayChoNhapLai",SqlDbType.DateTime,pKQHT_ChoNhapLaiDiemInfo.NgayChoNhapLai));
            colParam.Add(CreateParam("@DiemThanhPhan_L1",SqlDbType.Bit,pKQHT_ChoNhapLaiDiemInfo.DiemThanhPhan_L1));
            colParam.Add(CreateParam("@DiemThi_L1",SqlDbType.Bit,pKQHT_ChoNhapLaiDiemInfo.DiemThi_L1));
            colParam.Add(CreateParam("@DiemThanhPhan_L2",SqlDbType.Bit,pKQHT_ChoNhapLaiDiemInfo.DiemThanhPhan_L2));
            colParam.Add(CreateParam("@DiemThi_L2",SqlDbType.Bit,pKQHT_ChoNhapLaiDiemInfo.DiemThi_L2));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_ChoNhapLaiDiem_Add", colParam);
        }
        
        public void Update(KQHT_ChoNhapLaiDiemInfo pKQHT_ChoNhapLaiDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_DaChuyenDiem",SqlDbType.Int,pKQHT_ChoNhapLaiDiemInfo.IDKQHT_DaChuyenDiem));
            colParam.Add(CreateParam("@IDHT_User",SqlDbType.Int,pKQHT_ChoNhapLaiDiemInfo.IDHT_User));
            colParam.Add(CreateParam("@LanChoNhapLai",SqlDbType.Int,pKQHT_ChoNhapLaiDiemInfo.LanChoNhapLai));
            colParam.Add(CreateParam("@NgayChoNhapLai",SqlDbType.DateTime,pKQHT_ChoNhapLaiDiemInfo.NgayChoNhapLai));
            colParam.Add(CreateParam("@DiemThanhPhan_L1",SqlDbType.Bit,pKQHT_ChoNhapLaiDiemInfo.DiemThanhPhan_L1));
            colParam.Add(CreateParam("@DiemThi_L1",SqlDbType.Bit,pKQHT_ChoNhapLaiDiemInfo.DiemThi_L1));
            colParam.Add(CreateParam("@DiemThanhPhan_L2",SqlDbType.Bit,pKQHT_ChoNhapLaiDiemInfo.DiemThanhPhan_L2));
            colParam.Add(CreateParam("@DiemThi_L2",SqlDbType.Bit,pKQHT_ChoNhapLaiDiemInfo.DiemThi_L2));
            colParam.Add(CreateParam("@KQHT_ChoNhapLaiDiemID",SqlDbType.Int,pKQHT_ChoNhapLaiDiemInfo.KQHT_ChoNhapLaiDiemID));

            RunProcedure("sp_KQHT_ChoNhapLaiDiem_Update", colParam);
        }
        
        public void Delete(KQHT_ChoNhapLaiDiemInfo pKQHT_ChoNhapLaiDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_ChoNhapLaiDiemID",SqlDbType.Int,pKQHT_ChoNhapLaiDiemInfo.KQHT_ChoNhapLaiDiemID));

            RunProcedure("sp_KQHT_ChoNhapLaiDiem_Delete", colParam);
        }
    }
}
