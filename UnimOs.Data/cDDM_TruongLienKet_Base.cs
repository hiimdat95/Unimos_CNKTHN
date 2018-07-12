using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_TruongLienKet : cDBase
    {
        public DataTable Get(DM_TruongLienKetInfo pDM_TruongLienKetInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_TruongLienKetID",SqlDbType.Int,pDM_TruongLienKetInfo.DM_TruongLienKetID));

            return RunProcedureGet("sp_DM_TruongLienKet_Get", colParam);            
        }

        public int Add(DM_TruongLienKetInfo pDM_TruongLienKetInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaTruong",SqlDbType.NVarChar,pDM_TruongLienKetInfo.MaTruong));
            colParam.Add(CreateParam("@TenTruong",SqlDbType.NVarChar,pDM_TruongLienKetInfo.TenTruong));
            colParam.Add(CreateParam("@DiaChi",SqlDbType.NVarChar,pDM_TruongLienKetInfo.DiaChi));
            colParam.Add(CreateParam("@IDDM_TinhHuyenXa",SqlDbType.Int,pDM_TruongLienKetInfo.IDDM_TinhHuyenXa));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_TruongLienKet_Add", colParam);
        }
        
        public void Update(DM_TruongLienKetInfo pDM_TruongLienKetInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaTruong",SqlDbType.NVarChar,pDM_TruongLienKetInfo.MaTruong));
            colParam.Add(CreateParam("@TenTruong",SqlDbType.NVarChar,pDM_TruongLienKetInfo.TenTruong));
            colParam.Add(CreateParam("@DiaChi",SqlDbType.NVarChar,pDM_TruongLienKetInfo.DiaChi));
            colParam.Add(CreateParam("@IDDM_TinhHuyenXa",SqlDbType.Int,pDM_TruongLienKetInfo.IDDM_TinhHuyenXa));
            colParam.Add(CreateParam("@DM_TruongLienKetID",SqlDbType.Int,pDM_TruongLienKetInfo.DM_TruongLienKetID));

            RunProcedure("sp_DM_TruongLienKet_Update", colParam);
        }
        
        public void Delete(DM_TruongLienKetInfo pDM_TruongLienKetInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_TruongLienKetID",SqlDbType.Int,pDM_TruongLienKetInfo.DM_TruongLienKetID));

            RunProcedure("sp_DM_TruongLienKet_Delete", colParam);
        }
    }
}
