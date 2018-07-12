using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_CapKhenThuong : cDBase
    {
        public DataTable Get(DM_CapKhenThuongInfo pDM_CapKhenThuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_CapKhenThuongID",SqlDbType.Int,pDM_CapKhenThuongInfo.DM_CapKhenThuongID));

            return RunProcedureGet("sp_DM_CapKhenThuong_Get", colParam);            
        }

        public int Add(DM_CapKhenThuongInfo pDM_CapKhenThuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenCapKhenThuong",SqlDbType.NVarChar,pDM_CapKhenThuongInfo.TenCapKhenThuong));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_CapKhenThuong_Add", colParam);
        }
        
        public void Update(DM_CapKhenThuongInfo pDM_CapKhenThuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenCapKhenThuong",SqlDbType.NVarChar,pDM_CapKhenThuongInfo.TenCapKhenThuong));
            colParam.Add(CreateParam("@DM_CapKhenThuongID",SqlDbType.Int,pDM_CapKhenThuongInfo.DM_CapKhenThuongID));

            RunProcedure("sp_DM_CapKhenThuong_Update", colParam);
        }
        
        public void Delete(DM_CapKhenThuongInfo pDM_CapKhenThuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_CapKhenThuongID",SqlDbType.Int,pDM_CapKhenThuongInfo.DM_CapKhenThuongID));

            RunProcedure("sp_DM_CapKhenThuong_Delete", colParam);
        }
    }
}
