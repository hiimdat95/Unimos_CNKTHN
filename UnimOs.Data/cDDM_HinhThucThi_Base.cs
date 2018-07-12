using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_HinhThucThi : cDBase
    {
        public DataTable Get(DM_HinhThucThiInfo pDM_HinhThucThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_HinhThucThiID",SqlDbType.Int,pDM_HinhThucThiInfo.DM_HinhThucThiID));

            return RunProcedureGet("sp_DM_HinhThucThi_Get", colParam);            
        }

        public int Add(DM_HinhThucThiInfo pDM_HinhThucThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaHinhThucThi",SqlDbType.NVarChar,pDM_HinhThucThiInfo.MaHinhThucThi));
            colParam.Add(CreateParam("@TenHinhThucThi",SqlDbType.NVarChar,pDM_HinhThucThiInfo.TenHinhThucThi));
            colParam.Add(CreateParam("@XepLichThi",SqlDbType.Bit,pDM_HinhThucThiInfo.XepLichThi));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_HinhThucThi_Add", colParam);
        }
        
        public void Update(DM_HinhThucThiInfo pDM_HinhThucThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaHinhThucThi",SqlDbType.NVarChar,pDM_HinhThucThiInfo.MaHinhThucThi));
            colParam.Add(CreateParam("@TenHinhThucThi",SqlDbType.NVarChar,pDM_HinhThucThiInfo.TenHinhThucThi));
            colParam.Add(CreateParam("@XepLichThi",SqlDbType.Bit,pDM_HinhThucThiInfo.XepLichThi));
            colParam.Add(CreateParam("@DM_HinhThucThiID",SqlDbType.Int,pDM_HinhThucThiInfo.DM_HinhThucThiID));

            RunProcedure("sp_DM_HinhThucThi_Update", colParam);
        }
        
        public void Delete(DM_HinhThucThiInfo pDM_HinhThucThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_HinhThucThiID",SqlDbType.Int,pDM_HinhThucThiInfo.DM_HinhThucThiID));

            RunProcedure("sp_DM_HinhThucThi_Delete", colParam);
        }
    }
}
