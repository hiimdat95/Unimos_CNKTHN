using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_ThamSoQuyChe : cDBase
    {
        public DataTable Get(KQHT_ThamSoQuyCheInfo pKQHT_ThamSoQuyCheInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_ThamSoQuyCheID",SqlDbType.Int,pKQHT_ThamSoQuyCheInfo.KQHT_ThamSoQuyCheID));

            return RunProcedureGet("sp_KQHT_ThamSoQuyChe_Get", colParam);            
        }

        public int Add(KQHT_ThamSoQuyCheInfo pKQHT_ThamSoQuyCheInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaThamSo",SqlDbType.NVarChar,pKQHT_ThamSoQuyCheInfo.MaThamSo));
            colParam.Add(CreateParam("@TenThamSo",SqlDbType.NVarChar,pKQHT_ThamSoQuyCheInfo.TenThamSo));
            colParam.Add(CreateParam("@GiaTriMacDinh",SqlDbType.NVarChar,pKQHT_ThamSoQuyCheInfo.GiaTriMacDinh));
            colParam.Add(CreateParam("@KieuTruong",SqlDbType.NVarChar,pKQHT_ThamSoQuyCheInfo.KieuTruong));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_ThamSoQuyChe_Add", colParam);
        }
        
        public void Update(KQHT_ThamSoQuyCheInfo pKQHT_ThamSoQuyCheInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaThamSo",SqlDbType.NVarChar,pKQHT_ThamSoQuyCheInfo.MaThamSo));
            colParam.Add(CreateParam("@TenThamSo",SqlDbType.NVarChar,pKQHT_ThamSoQuyCheInfo.TenThamSo));
            colParam.Add(CreateParam("@GiaTriMacDinh",SqlDbType.NVarChar,pKQHT_ThamSoQuyCheInfo.GiaTriMacDinh));
            colParam.Add(CreateParam("@KieuTruong",SqlDbType.NVarChar,pKQHT_ThamSoQuyCheInfo.KieuTruong));
            colParam.Add(CreateParam("@KQHT_ThamSoQuyCheID",SqlDbType.Int,pKQHT_ThamSoQuyCheInfo.KQHT_ThamSoQuyCheID));

            RunProcedure("sp_KQHT_ThamSoQuyChe_Update", colParam);
        }
        
        public void Delete(KQHT_ThamSoQuyCheInfo pKQHT_ThamSoQuyCheInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_ThamSoQuyCheID",SqlDbType.Int,pKQHT_ThamSoQuyCheInfo.KQHT_ThamSoQuyCheID));

            RunProcedure("sp_KQHT_ThamSoQuyChe_Delete", colParam);
        }
    }
}
