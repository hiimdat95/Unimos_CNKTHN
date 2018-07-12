using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDGG_HeSoTheoTrinhDo : cDBase
    {
        public DataTable Get(GG_HeSoTheoTrinhDoInfo pGG_HeSoTheoTrinhDoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@GG_HeSoTheoTrinhDoID",SqlDbType.Int,pGG_HeSoTheoTrinhDoInfo.GG_HeSoTheoTrinhDoID));

            return RunProcedureGet("sp_GG_HeSoTheoTrinhDo_Get", colParam);            
        }

        public int Add(GG_HeSoTheoTrinhDoInfo pGG_HeSoTheoTrinhDoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@LoaiGiangDay",SqlDbType.NVarChar,pGG_HeSoTheoTrinhDoInfo.LoaiGiangDay));
            colParam.Add(CreateParam("@IDDM_TrinhDo",SqlDbType.Int,pGG_HeSoTheoTrinhDoInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@TuSo",SqlDbType.Int,pGG_HeSoTheoTrinhDoInfo.TuSo));
            colParam.Add(CreateParam("@DenSo",SqlDbType.Int,pGG_HeSoTheoTrinhDoInfo.DenSo));
            colParam.Add(CreateParam("@HeSo",SqlDbType.Float,pGG_HeSoTheoTrinhDoInfo.HeSo));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_GG_HeSoTheoTrinhDo_Add", colParam);
        }
        
        public void Update(GG_HeSoTheoTrinhDoInfo pGG_HeSoTheoTrinhDoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@LoaiGiangDay",SqlDbType.NVarChar,pGG_HeSoTheoTrinhDoInfo.LoaiGiangDay));
            colParam.Add(CreateParam("@IDDM_TrinhDo",SqlDbType.Int,pGG_HeSoTheoTrinhDoInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@TuSo",SqlDbType.Int,pGG_HeSoTheoTrinhDoInfo.TuSo));
            colParam.Add(CreateParam("@DenSo",SqlDbType.Int,pGG_HeSoTheoTrinhDoInfo.DenSo));
            colParam.Add(CreateParam("@HeSo",SqlDbType.Float,pGG_HeSoTheoTrinhDoInfo.HeSo));
            colParam.Add(CreateParam("@GG_HeSoTheoTrinhDoID",SqlDbType.Int,pGG_HeSoTheoTrinhDoInfo.GG_HeSoTheoTrinhDoID));

            RunProcedure("sp_GG_HeSoTheoTrinhDo_Update", colParam);
        }
        
        public void Delete(GG_HeSoTheoTrinhDoInfo pGG_HeSoTheoTrinhDoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@GG_HeSoTheoTrinhDoID",SqlDbType.Int,pGG_HeSoTheoTrinhDoInfo.GG_HeSoTheoTrinhDoID));

            RunProcedure("sp_GG_HeSoTheoTrinhDo_Delete", colParam);
        }
    }
}
