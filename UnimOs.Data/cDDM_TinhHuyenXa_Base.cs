using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_TinhHuyenXa : cDBase
    {
        public DataTable Get(DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_TinhHuyenXaID",SqlDbType.Int,pDM_TinhHuyenXaInfo.DM_TinhHuyenXaID));

            return RunProcedureGet("sp_DM_TinhHuyenXa_Get", colParam);            
        }

        public int Add(DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Ma",SqlDbType.NVarChar,pDM_TinhHuyenXaInfo.Ma));
            colParam.Add(CreateParam("@Ten",SqlDbType.NVarChar,pDM_TinhHuyenXaInfo.Ten));
            colParam.Add(CreateParam("@ParentID",SqlDbType.Int,pDM_TinhHuyenXaInfo.ParentID));
            colParam.Add(CreateParam("@Level",SqlDbType.Int,pDM_TinhHuyenXaInfo.Level));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_TinhHuyenXa_Add", colParam);
        }
        
        public void Update(DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Ma",SqlDbType.NVarChar,pDM_TinhHuyenXaInfo.Ma));
            colParam.Add(CreateParam("@Ten",SqlDbType.NVarChar,pDM_TinhHuyenXaInfo.Ten));
            colParam.Add(CreateParam("@ParentID",SqlDbType.Int,pDM_TinhHuyenXaInfo.ParentID));
            colParam.Add(CreateParam("@Level",SqlDbType.Int,pDM_TinhHuyenXaInfo.Level));
            colParam.Add(CreateParam("@DM_TinhHuyenXaID",SqlDbType.Int,pDM_TinhHuyenXaInfo.DM_TinhHuyenXaID));

            RunProcedure("sp_DM_TinhHuyenXa_Update", colParam);
        }
        
        public void Delete(DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_TinhHuyenXaID",SqlDbType.Int,pDM_TinhHuyenXaInfo.DM_TinhHuyenXaID));

            RunProcedure("sp_DM_TinhHuyenXa_Delete", colParam);
        }
    }
}
