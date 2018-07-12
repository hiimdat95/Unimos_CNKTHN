using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_ThanhPhanDiem : cDBase
    {
        public DataTable Get(KQHT_ThanhPhanDiemInfo pKQHT_ThanhPhanDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_ThanhPhanDiemID", SqlDbType.Int, pKQHT_ThanhPhanDiemInfo.KQHT_ThanhPhanDiemID));

            return RunProcedureGet("sp_KQHT_ThanhPhanDiem_Get", colParam);
        }

        public int Add(KQHT_ThanhPhanDiemInfo pKQHT_ThanhPhanDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pKQHT_ThanhPhanDiemInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@KyHieu", SqlDbType.NVarChar, pKQHT_ThanhPhanDiemInfo.KyHieu));
            colParam.Add(CreateParam("@TenThanhPhan", SqlDbType.NVarChar, pKQHT_ThanhPhanDiemInfo.TenThanhPhan));
            colParam.Add(CreateParam("@SoDiem", SqlDbType.Int, pKQHT_ThanhPhanDiemInfo.SoDiem));
            colParam.Add(CreateParam("@Thi", SqlDbType.Bit, pKQHT_ThanhPhanDiemInfo.Thi));
            colParam.Add(CreateParam("@SoLanThi", SqlDbType.Int, pKQHT_ThanhPhanDiemInfo.SoLanThi));
            colParam.Add(CreateParam("@STT", SqlDbType.Int, pKQHT_ThanhPhanDiemInfo.STT));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_ThanhPhanDiem_Add", colParam);
        }

        public void Update(KQHT_ThanhPhanDiemInfo pKQHT_ThanhPhanDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_TrinhDo", SqlDbType.Int, pKQHT_ThanhPhanDiemInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@KyHieu", SqlDbType.NVarChar, pKQHT_ThanhPhanDiemInfo.KyHieu));
            colParam.Add(CreateParam("@TenThanhPhan", SqlDbType.NVarChar, pKQHT_ThanhPhanDiemInfo.TenThanhPhan));
            colParam.Add(CreateParam("@SoDiem", SqlDbType.Int, pKQHT_ThanhPhanDiemInfo.SoDiem));
            colParam.Add(CreateParam("@Thi", SqlDbType.Bit, pKQHT_ThanhPhanDiemInfo.Thi));
            colParam.Add(CreateParam("@SoLanThi", SqlDbType.Int, pKQHT_ThanhPhanDiemInfo.SoLanThi));
            colParam.Add(CreateParam("@STT", SqlDbType.Int, pKQHT_ThanhPhanDiemInfo.STT));
            colParam.Add(CreateParam("@KQHT_ThanhPhanDiemID", SqlDbType.Int, pKQHT_ThanhPhanDiemInfo.KQHT_ThanhPhanDiemID));

            RunProcedure("sp_KQHT_ThanhPhanDiem_Update", colParam);
        }

        public void Delete(KQHT_ThanhPhanDiemInfo pKQHT_ThanhPhanDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_ThanhPhanDiemID", SqlDbType.Int, pKQHT_ThanhPhanDiemInfo.KQHT_ThanhPhanDiemID));

            RunProcedure("sp_KQHT_ThanhPhanDiem_Delete", colParam);
        }
    }
}
