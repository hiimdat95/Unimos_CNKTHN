using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_XepLoaiRenLuyen : cDBase
    {
        public DataTable Get(DM_XepLoaiRenLuyenInfo pDM_XepLoaiRenLuyenInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_XepLoaiRenLuyenID",SqlDbType.Int,pDM_XepLoaiRenLuyenInfo.DM_XepLoaiRenLuyenID));

            return RunProcedureGet("sp_DM_XepLoaiRenLuyen_Get", colParam);            
        }

        public int Add(DM_XepLoaiRenLuyenInfo pDM_XepLoaiRenLuyenInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KyHieu",SqlDbType.NVarChar,pDM_XepLoaiRenLuyenInfo.KyHieu));
            colParam.Add(CreateParam("@TenXepLoaiRenLuyen",SqlDbType.NVarChar,pDM_XepLoaiRenLuyenInfo.TenXepLoaiRenLuyen));
            colParam.Add(CreateParam("@TuDiem",SqlDbType.Int,pDM_XepLoaiRenLuyenInfo.TuDiem));
            colParam.Add(CreateParam("@DiemCongXetHocBong",SqlDbType.Float,pDM_XepLoaiRenLuyenInfo.DiemCongXetHocBong));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_XepLoaiRenLuyen_Add", colParam);
        }
        
        public void Update(DM_XepLoaiRenLuyenInfo pDM_XepLoaiRenLuyenInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KyHieu",SqlDbType.NVarChar,pDM_XepLoaiRenLuyenInfo.KyHieu));
            colParam.Add(CreateParam("@TenXepLoaiRenLuyen",SqlDbType.NVarChar,pDM_XepLoaiRenLuyenInfo.TenXepLoaiRenLuyen));
            colParam.Add(CreateParam("@TuDiem",SqlDbType.Int,pDM_XepLoaiRenLuyenInfo.TuDiem));
            colParam.Add(CreateParam("@DiemCongXetHocBong",SqlDbType.Float,pDM_XepLoaiRenLuyenInfo.DiemCongXetHocBong));
            colParam.Add(CreateParam("@DM_XepLoaiRenLuyenID",SqlDbType.Int,pDM_XepLoaiRenLuyenInfo.DM_XepLoaiRenLuyenID));

            RunProcedure("sp_DM_XepLoaiRenLuyen_Update", colParam);
        }
        
        public void Delete(DM_XepLoaiRenLuyenInfo pDM_XepLoaiRenLuyenInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_XepLoaiRenLuyenID",SqlDbType.Int,pDM_XepLoaiRenLuyenInfo.DM_XepLoaiRenLuyenID));

            RunProcedure("sp_DM_XepLoaiRenLuyen_Delete", colParam);
        }
    }
}
