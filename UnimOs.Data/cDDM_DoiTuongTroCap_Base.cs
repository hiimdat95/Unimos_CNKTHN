using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_DoiTuongTroCap : cDBase
    {
        public DataTable Get(DM_DoiTuongTroCapInfo pDM_DoiTuongTroCapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_DoiTuongTroCapID",SqlDbType.Int,pDM_DoiTuongTroCapInfo.DM_DoiTuongTroCapID));

            return RunProcedureGet("sp_DM_DoiTuongTroCap_Get", colParam);            
        }

        public int Add(DM_DoiTuongTroCapInfo pDM_DoiTuongTroCapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaDoiTuongTroCap",SqlDbType.NVarChar,pDM_DoiTuongTroCapInfo.MaDoiTuongTroCap));
            colParam.Add(CreateParam("@TenDoiTuongTroCap",SqlDbType.NVarChar,pDM_DoiTuongTroCapInfo.TenDoiTuongTroCap));
            colParam.Add(CreateParam("@SoTienTroCap",SqlDbType.Money,pDM_DoiTuongTroCapInfo.SoTienTroCap));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_DoiTuongTroCap_Add", colParam);
        }
        
        public void Update(DM_DoiTuongTroCapInfo pDM_DoiTuongTroCapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaDoiTuongTroCap",SqlDbType.NVarChar,pDM_DoiTuongTroCapInfo.MaDoiTuongTroCap));
            colParam.Add(CreateParam("@TenDoiTuongTroCap",SqlDbType.NVarChar,pDM_DoiTuongTroCapInfo.TenDoiTuongTroCap));
            colParam.Add(CreateParam("@SoTienTroCap",SqlDbType.Money,pDM_DoiTuongTroCapInfo.SoTienTroCap));
            colParam.Add(CreateParam("@DM_DoiTuongTroCapID",SqlDbType.Int,pDM_DoiTuongTroCapInfo.DM_DoiTuongTroCapID));

            RunProcedure("sp_DM_DoiTuongTroCap_Update", colParam);
        }
        
        public void Delete(DM_DoiTuongTroCapInfo pDM_DoiTuongTroCapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_DoiTuongTroCapID",SqlDbType.Int,pDM_DoiTuongTroCapInfo.DM_DoiTuongTroCapID));

            RunProcedure("sp_DM_DoiTuongTroCap_Delete", colParam);
        }
    }
}
