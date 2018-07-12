using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_DonVi : cDBase
    {
        public DataTable Get(NS_DonViInfo pNS_DonViInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_DonViID", SqlDbType.Int, pNS_DonViInfo.NS_DonViID));

            return RunProcedureGet("sp_NS_DonVi_Get", colParam);
        }

        public int Add(NS_DonViInfo pNS_DonViInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaDonVi", SqlDbType.NVarChar, pNS_DonViInfo.MaDonVi));
            colParam.Add(CreateParam("@TenDonVi", SqlDbType.NVarChar, pNS_DonViInfo.TenDonVi));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pNS_DonViInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_BoMon", SqlDbType.Int, pNS_DonViInfo.IDDM_BoMon));
            colParam.Add(CreateParam("@ParentID", SqlDbType.Int, pNS_DonViInfo.ParentID));
            colParam.Add(CreateParam("@Level", SqlDbType.Int, pNS_DonViInfo.Level));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_DonVi_Add", colParam);
        }

        public void Update(NS_DonViInfo pNS_DonViInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaDonVi", SqlDbType.NVarChar, pNS_DonViInfo.MaDonVi));
            colParam.Add(CreateParam("@TenDonVi", SqlDbType.NVarChar, pNS_DonViInfo.TenDonVi));
            colParam.Add(CreateParam("@IDDM_Khoa", SqlDbType.Int, pNS_DonViInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_BoMon", SqlDbType.Int, pNS_DonViInfo.IDDM_BoMon));
            colParam.Add(CreateParam("@ParentID", SqlDbType.Int, pNS_DonViInfo.ParentID));
            colParam.Add(CreateParam("@Level", SqlDbType.Int, pNS_DonViInfo.Level));
            colParam.Add(CreateParam("@NS_DonViID", SqlDbType.Int, pNS_DonViInfo.NS_DonViID));

            RunProcedure("sp_NS_DonVi_Update", colParam);
        }
        
        public void Delete(NS_DonViInfo pNS_DonViInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_DonViID",SqlDbType.Int,pNS_DonViInfo.NS_DonViID));

            RunProcedure("sp_NS_DonVi_Delete", colParam);
        }
    }
}
