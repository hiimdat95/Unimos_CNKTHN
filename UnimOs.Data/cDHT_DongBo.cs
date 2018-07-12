using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDHT_DongBo : cDBase
    {
        public DataTable GetSoThayDoi()
        {
            ArrayList colParam = new ArrayList();

            return RunProcedureGet("sp_HT_DongBo_GetSoThayDoi", colParam);
        }

        public DataTable GetThayDoi()
        {
            ArrayList colParam = new ArrayList();

            return RunProcedureGet("sp_HT_DongBo_GetThayDoi", colParam);
        }

        public DataTable GetDanhSachThayDoi(string TenBang, string IDThayDoi)
        {
            ArrayList colParam = new ArrayList();
            colParam.Add(CreateParam("@TenBang", SqlDbType.NVarChar, TenBang));
            colParam.Add(CreateParam("@IDThayDoi", SqlDbType.VarChar, IDThayDoi));

            return RunProcedureGet("sp_DongBoDuLieu_GetDanhSachThayDoi_ByTenBang_IDThayDois", colParam);
        }

        public void UpdateDanhSachThayDoi()
        {
            ArrayList colParam = new ArrayList();

            RunProcedure("sp_HT_DongBo_UpdateDanhSachThayDoi", colParam);
        }

        public DataTable GetDataChanged(string TenBang, long IDThayDoi)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenBang", SqlDbType.NVarChar, TenBang));
            colParam.Add(CreateParam("@IDThayDoi", SqlDbType.BigInt, IDThayDoi));

            return RunProcedureGet("sp_HT_DongBo_GetDataChanged", colParam);
        }

        public void UpdateTrangThai(bool DaDongBo, long HT_DongBoID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DaDongBo", SqlDbType.Bit, DaDongBo));
            colParam.Add(CreateParam("@HT_DongBoID", SqlDbType.BigInt, HT_DongBoID));

            RunProcedure("sp_HT_DongBo_UpdateTrangThai", colParam);
        }
    }
}
