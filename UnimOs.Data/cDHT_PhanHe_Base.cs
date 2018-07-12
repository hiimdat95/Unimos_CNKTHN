using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDHT_PhanHe : cDBase
    {
        public DataTable Get(HT_PhanHeInfo pHT_PhanHeInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_PhanHeID",SqlDbType.Int,pHT_PhanHeInfo.HT_PhanHeID));

            return RunProcedureGet("sp_HT_PhanHe_Get", colParam);            
        }

        public int Add(HT_PhanHeInfo pHT_PhanHeInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaPhanHe",SqlDbType.NVarChar,pHT_PhanHeInfo.MaPhanHe));
            colParam.Add(CreateParam("@TenPhanHe",SqlDbType.NVarChar,pHT_PhanHeInfo.TenPhanHe));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NText,pHT_PhanHeInfo.MoTa));
            colParam.Add(CreateParam("@SapXep",SqlDbType.Int,pHT_PhanHeInfo.SapXep));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_HT_PhanHe_Add", colParam);
        }
        
        public void Update(HT_PhanHeInfo pHT_PhanHeInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaPhanHe",SqlDbType.NVarChar,pHT_PhanHeInfo.MaPhanHe));
            colParam.Add(CreateParam("@TenPhanHe",SqlDbType.NVarChar,pHT_PhanHeInfo.TenPhanHe));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NText,pHT_PhanHeInfo.MoTa));
            colParam.Add(CreateParam("@SapXep",SqlDbType.Int,pHT_PhanHeInfo.SapXep));
            colParam.Add(CreateParam("@HT_PhanHeID",SqlDbType.Int,pHT_PhanHeInfo.HT_PhanHeID));

            RunProcedure("sp_HT_PhanHe_Update", colParam);
        }
        
        public void Delete(HT_PhanHeInfo pHT_PhanHeInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_PhanHeID",SqlDbType.Int,pHT_PhanHeInfo.HT_PhanHeID));

            RunProcedure("sp_HT_PhanHe_Delete", colParam);
        }
    }
}
