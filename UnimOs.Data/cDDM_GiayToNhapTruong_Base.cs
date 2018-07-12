using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_GiayToNhapTruong : cDBase
    {
        public DataTable Get(DM_GiayToNhapTruongInfo pDM_GiayToNhapTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_GiayToNhapTruongID",SqlDbType.Int,pDM_GiayToNhapTruongInfo.DM_GiayToNhapTruongID));

            return RunProcedureGet("sp_DM_GiayToNhapTruong_Get", colParam);            
        }

        public int Add(DM_GiayToNhapTruongInfo pDM_GiayToNhapTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenGiayTo",SqlDbType.NVarChar,pDM_GiayToNhapTruongInfo.TenGiayTo));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_GiayToNhapTruong_Add", colParam);
        }
        
        public void Update(DM_GiayToNhapTruongInfo pDM_GiayToNhapTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenGiayTo",SqlDbType.NVarChar,pDM_GiayToNhapTruongInfo.TenGiayTo));
            colParam.Add(CreateParam("@DM_GiayToNhapTruongID",SqlDbType.Int,pDM_GiayToNhapTruongInfo.DM_GiayToNhapTruongID));

            RunProcedure("sp_DM_GiayToNhapTruong_Update", colParam);
        }
        
        public void Delete(DM_GiayToNhapTruongInfo pDM_GiayToNhapTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_GiayToNhapTruongID",SqlDbType.Int,pDM_GiayToNhapTruongInfo.DM_GiayToNhapTruongID));

            RunProcedure("sp_DM_GiayToNhapTruong_Delete", colParam);
        }
    }
}
