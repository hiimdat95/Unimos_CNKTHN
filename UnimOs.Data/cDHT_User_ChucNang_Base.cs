using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDHT_User_ChucNang : cDBase
    {
        public DataTable Get(HT_User_ChucNangInfo pHT_User_ChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_User_ChucNangID",SqlDbType.Int,pHT_User_ChucNangInfo.HT_User_ChucNangID));

            return RunProcedureGet("sp_HT_User_ChucNang_Get", colParam);            
        }

        public int Add(HT_User_ChucNangInfo pHT_User_ChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

           
            colParam.Add(CreateParam("@IDHT_User",SqlDbType.Int,pHT_User_ChucNangInfo.IDHT_User));
            colParam.Add(CreateParam("@IDHT_ChucNang",SqlDbType.Int,pHT_User_ChucNangInfo.IDHT_ChucNang));
            colParam.Add(CreateParam("@Them",SqlDbType.Bit,pHT_User_ChucNangInfo.Them));
            colParam.Add(CreateParam("@Sua",SqlDbType.Bit,pHT_User_ChucNangInfo.Sua));
            colParam.Add(CreateParam("@Xoa",SqlDbType.Bit,pHT_User_ChucNangInfo.Xoa));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_HT_User_ChucNang_Add", colParam);
        }
        
        public void Update(HT_User_ChucNangInfo pHT_User_ChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDHT_User",SqlDbType.Int,pHT_User_ChucNangInfo.IDHT_User));
            colParam.Add(CreateParam("@IDHT_ChucNang",SqlDbType.Int,pHT_User_ChucNangInfo.IDHT_ChucNang));
            colParam.Add(CreateParam("@Them",SqlDbType.Bit,pHT_User_ChucNangInfo.Them));
            colParam.Add(CreateParam("@Sua",SqlDbType.Bit,pHT_User_ChucNangInfo.Sua));
            colParam.Add(CreateParam("@Xoa",SqlDbType.Bit,pHT_User_ChucNangInfo.Xoa));
            colParam.Add(CreateParam("@HT_User_ChucNangID",SqlDbType.Int,pHT_User_ChucNangInfo.HT_User_ChucNangID));

            RunProcedure("sp_HT_User_ChucNang_Update", colParam);
        }
        
        public void Delete(HT_User_ChucNangInfo pHT_User_ChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_User_ChucNangID",SqlDbType.Int,pHT_User_ChucNangInfo.HT_User_ChucNangID));

            RunProcedure("sp_HT_User_ChucNang_Delete", colParam);
        }

        public void DeleteNotIn(int IDHT_User, string strNotIn)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDHT_User", SqlDbType.Int, IDHT_User));
            colParam.Add(CreateParam("@ChucNangNotIn", SqlDbType.NVarChar, strNotIn));

            RunProcedure("sp_HT_User_ChucNang_DeleteNotIn", colParam);
        }
    }
}
