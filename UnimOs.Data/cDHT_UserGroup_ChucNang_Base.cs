using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDHT_UserGroup_ChucNang : cDBase
    {
        public DataTable Get(HT_UserGroup_ChucNangInfo pHT_UserGroup_ChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_UserGroup_ChucNangID",SqlDbType.Int,pHT_UserGroup_ChucNangInfo.HT_UserGroup_ChucNangID));

            return RunProcedureGet("sp_HT_UserGroup_ChucNang_Get", colParam);            
        }

        public int Add(HT_UserGroup_ChucNangInfo pHT_UserGroup_ChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDHT_UserGroup",SqlDbType.Int,pHT_UserGroup_ChucNangInfo.IDHT_UserGroup));
            colParam.Add(CreateParam("@IDHT_ChucNang",SqlDbType.Int,pHT_UserGroup_ChucNangInfo.IDHT_ChucNang));
            colParam.Add(CreateParam("@Xem",SqlDbType.Bit,pHT_UserGroup_ChucNangInfo.Xem));
            colParam.Add(CreateParam("@Sua",SqlDbType.Bit,pHT_UserGroup_ChucNangInfo.Sua));
            colParam.Add(CreateParam("@Xoa",SqlDbType.Bit,pHT_UserGroup_ChucNangInfo.Xoa));
            colParam.Add(CreateParam("@Them",SqlDbType.Bit,pHT_UserGroup_ChucNangInfo.Them));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_HT_UserGroup_ChucNang_Add", colParam);
        }
        
        public void Update(HT_UserGroup_ChucNangInfo pHT_UserGroup_ChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDHT_UserGroup",SqlDbType.Int,pHT_UserGroup_ChucNangInfo.IDHT_UserGroup));
            colParam.Add(CreateParam("@IDHT_ChucNang",SqlDbType.Int,pHT_UserGroup_ChucNangInfo.IDHT_ChucNang));
            colParam.Add(CreateParam("@Xem",SqlDbType.Bit,pHT_UserGroup_ChucNangInfo.Xem));
            colParam.Add(CreateParam("@Sua",SqlDbType.Bit,pHT_UserGroup_ChucNangInfo.Sua));
            colParam.Add(CreateParam("@Xoa",SqlDbType.Bit,pHT_UserGroup_ChucNangInfo.Xoa));
            colParam.Add(CreateParam("@Them",SqlDbType.Bit,pHT_UserGroup_ChucNangInfo.Them));
            colParam.Add(CreateParam("@HT_UserGroup_ChucNangID",SqlDbType.Int,pHT_UserGroup_ChucNangInfo.HT_UserGroup_ChucNangID));

            RunProcedure("sp_HT_UserGroup_ChucNang_Update", colParam);
        }
        
        public void Delete(HT_UserGroup_ChucNangInfo pHT_UserGroup_ChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_UserGroup_ChucNangID",SqlDbType.Int,pHT_UserGroup_ChucNangInfo.HT_UserGroup_ChucNangID));

            RunProcedure("sp_HT_UserGroup_ChucNang_Delete", colParam);
        }

        public void DeleteNotIn(int IDHT_UserGroup, string strNotIN)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDHT_UserGroup", SqlDbType.Int, IDHT_UserGroup));
            colParam.Add(CreateParam("@ChucNangNotIn", SqlDbType.NVarChar, strNotIN));

            RunProcedure("sp_HT_UserGroup_ChucNang_DeleteNotIn", colParam);
        }
    }
}
