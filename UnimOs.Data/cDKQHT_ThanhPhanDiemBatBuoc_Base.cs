using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_ThanhPhanDiemBatBuoc : cDBase
    {
        public DataTable Get(KQHT_ThanhPhanDiemBatBuocInfo pKQHT_ThanhPhanDiemBatBuocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_ThanhPhanDiemBatBuocID",SqlDbType.Int,pKQHT_ThanhPhanDiemBatBuocInfo.KQHT_ThanhPhanDiemBatBuocID));

            return RunProcedureGet("sp_KQHT_ThanhPhanDiemBatBuoc_Get", colParam);            
        }

        public int Add(KQHT_ThanhPhanDiemBatBuocInfo pKQHT_ThanhPhanDiemBatBuocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_ThanhPhanDiem",SqlDbType.Int,pKQHT_ThanhPhanDiemBatBuocInfo.IDKQHT_ThanhPhanDiem));
            colParam.Add(CreateParam("@SoHocTrinh",SqlDbType.Int,pKQHT_ThanhPhanDiemBatBuocInfo.SoHocTrinh));
            colParam.Add(CreateParam("@SoTiet",SqlDbType.Int,pKQHT_ThanhPhanDiemBatBuocInfo.SoTiet));
            colParam.Add(CreateParam("@SoDiemBatBuoc",SqlDbType.Int,pKQHT_ThanhPhanDiemBatBuocInfo.SoDiemBatBuoc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_ThanhPhanDiemBatBuoc_Add", colParam);
        }
        
        public void Update(KQHT_ThanhPhanDiemBatBuocInfo pKQHT_ThanhPhanDiemBatBuocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_ThanhPhanDiem",SqlDbType.Int,pKQHT_ThanhPhanDiemBatBuocInfo.IDKQHT_ThanhPhanDiem));
            colParam.Add(CreateParam("@SoHocTrinh",SqlDbType.Int,pKQHT_ThanhPhanDiemBatBuocInfo.SoHocTrinh));
            colParam.Add(CreateParam("@SoTiet",SqlDbType.Int,pKQHT_ThanhPhanDiemBatBuocInfo.SoTiet));
            colParam.Add(CreateParam("@SoDiemBatBuoc",SqlDbType.Int,pKQHT_ThanhPhanDiemBatBuocInfo.SoDiemBatBuoc));
            colParam.Add(CreateParam("@KQHT_ThanhPhanDiemBatBuocID",SqlDbType.Int,pKQHT_ThanhPhanDiemBatBuocInfo.KQHT_ThanhPhanDiemBatBuocID));

            RunProcedure("sp_KQHT_ThanhPhanDiemBatBuoc_Update", colParam);
        }
        
        public void Delete(KQHT_ThanhPhanDiemBatBuocInfo pKQHT_ThanhPhanDiemBatBuocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_ThanhPhanDiemBatBuocID",SqlDbType.Int,pKQHT_ThanhPhanDiemBatBuocInfo.KQHT_ThanhPhanDiemBatBuocID));

            RunProcedure("sp_KQHT_ThanhPhanDiemBatBuoc_Delete", colParam);
        }
    }
}
