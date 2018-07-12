using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{

    public partial class cDDM_DoiTuongMienGiam : cDBase
    {
        public DataTable Get(DM_DoiTuongMienGiamInfo pDM_DoiTuongMienGiamInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_DoiTuongMienGiamID",SqlDbType.Int,pDM_DoiTuongMienGiamInfo.DM_DoiTuongMienGiamID));

            return RunProcedureGet("sp_DM_DoiTuongMienGiam_Get", colParam);            
        }

        public int Add(DM_DoiTuongMienGiamInfo pDM_DoiTuongMienGiamInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaDoiTuongMienGiam",SqlDbType.NVarChar,pDM_DoiTuongMienGiamInfo.MaDoiTuongMienGiam));
            colParam.Add(CreateParam("@TenDoiTuongMienGiam",SqlDbType.NVarChar,pDM_DoiTuongMienGiamInfo.TenDoiTuongMienGiam));
            colParam.Add(CreateParam("@PhanTramMienGiam",SqlDbType.NVarChar,pDM_DoiTuongMienGiamInfo.MienGiam));
            colParam.Add(CreateParam("@SoTienMienGiam",SqlDbType.Money,pDM_DoiTuongMienGiamInfo.SoTienMienGiam));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_DoiTuongMienGiam_Add", colParam);
        }
        
        public void Update(DM_DoiTuongMienGiamInfo pDM_DoiTuongMienGiamInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaDoiTuongMienGiam",SqlDbType.NVarChar,pDM_DoiTuongMienGiamInfo.MaDoiTuongMienGiam));
            colParam.Add(CreateParam("@TenDoiTuongMienGiam",SqlDbType.NVarChar,pDM_DoiTuongMienGiamInfo.TenDoiTuongMienGiam));
            colParam.Add(CreateParam("@PhanTramMienGiam", SqlDbType.NVarChar, pDM_DoiTuongMienGiamInfo.MienGiam));
            colParam.Add(CreateParam("@SoTienMienGiam",SqlDbType.Money,pDM_DoiTuongMienGiamInfo.SoTienMienGiam));
            colParam.Add(CreateParam("@DM_DoiTuongMienGiamID",SqlDbType.Int,pDM_DoiTuongMienGiamInfo.DM_DoiTuongMienGiamID));

            RunProcedure("sp_DM_DoiTuongMienGiam_Update", colParam);
        }
        
        public void Delete(DM_DoiTuongMienGiamInfo pDM_DoiTuongMienGiamInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_DoiTuongMienGiamID",SqlDbType.Int,pDM_DoiTuongMienGiamInfo.DM_DoiTuongMienGiamID));

            RunProcedure("sp_DM_DoiTuongMienGiam_Delete", colParam);
        }
    }
}
