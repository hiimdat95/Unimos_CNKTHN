using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_CongThucDiem_ThanhPhanDiem : cDBase
    {
        public DataTable Get(KQHT_CongThucDiem_ThanhPhanDiemInfo pKQHT_CongThucDiem_ThanhPhanDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_CongThucDiem_ThanhPhanDiemID",SqlDbType.Int,pKQHT_CongThucDiem_ThanhPhanDiemInfo.KQHT_CongThucDiem_ThanhPhanDiemID));

            return RunProcedureGet("sp_KQHT_CongThucDiem_ThanhPhanDiem_Get", colParam);            
        }

        public int Add(KQHT_CongThucDiem_ThanhPhanDiemInfo pKQHT_CongThucDiem_ThanhPhanDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_CongThucDiem",SqlDbType.Int,pKQHT_CongThucDiem_ThanhPhanDiemInfo.IDKQHT_CongThucDiem));
            colParam.Add(CreateParam("@IDKQHT_ThanhPhanDiem",SqlDbType.Int,pKQHT_CongThucDiem_ThanhPhanDiemInfo.IDKQHT_ThanhPhanDiem));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_CongThucDiem_ThanhPhanDiem_Add", colParam);
        }
        
        public void Update(KQHT_CongThucDiem_ThanhPhanDiemInfo pKQHT_CongThucDiem_ThanhPhanDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_CongThucDiem",SqlDbType.Int,pKQHT_CongThucDiem_ThanhPhanDiemInfo.IDKQHT_CongThucDiem));
            colParam.Add(CreateParam("@IDKQHT_ThanhPhanDiem",SqlDbType.Int,pKQHT_CongThucDiem_ThanhPhanDiemInfo.IDKQHT_ThanhPhanDiem));
            colParam.Add(CreateParam("@KQHT_CongThucDiem_ThanhPhanDiemID",SqlDbType.Int,pKQHT_CongThucDiem_ThanhPhanDiemInfo.KQHT_CongThucDiem_ThanhPhanDiemID));

            RunProcedure("sp_KQHT_CongThucDiem_ThanhPhanDiem_Update", colParam);
        }
        
        public void Delete(KQHT_CongThucDiem_ThanhPhanDiemInfo pKQHT_CongThucDiem_ThanhPhanDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_CongThucDiem_ThanhPhanDiemID",SqlDbType.Int,pKQHT_CongThucDiem_ThanhPhanDiemInfo.KQHT_CongThucDiem_ThanhPhanDiemID));

            RunProcedure("sp_KQHT_CongThucDiem_ThanhPhanDiem_Delete", colParam);
        }
    }
}
