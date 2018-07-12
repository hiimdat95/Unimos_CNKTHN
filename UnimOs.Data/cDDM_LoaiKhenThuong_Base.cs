using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_LoaiKhenThuong : cDBase
    {
        public DataTable Get(DM_LoaiKhenThuongInfo pDM_LoaiKhenThuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_LoaiKhenThuongID",SqlDbType.Int,pDM_LoaiKhenThuongInfo.DM_LoaiKhenThuongID));

            return RunProcedureGet("sp_DM_LoaiKhenThuong_Get", colParam);            
        }

        public int Add(DM_LoaiKhenThuongInfo pDM_LoaiKhenThuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaLoaiKhenThuong",SqlDbType.NVarChar,pDM_LoaiKhenThuongInfo.MaLoaiKhenThuong));
            colParam.Add(CreateParam("@TenLoaiKhenThuong",SqlDbType.NVarChar,pDM_LoaiKhenThuongInfo.TenLoaiKhenThuong));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_LoaiKhenThuong_Add", colParam);
        }
        
        public void Update(DM_LoaiKhenThuongInfo pDM_LoaiKhenThuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaLoaiKhenThuong",SqlDbType.NVarChar,pDM_LoaiKhenThuongInfo.MaLoaiKhenThuong));
            colParam.Add(CreateParam("@TenLoaiKhenThuong",SqlDbType.NVarChar,pDM_LoaiKhenThuongInfo.TenLoaiKhenThuong));
            colParam.Add(CreateParam("@DM_LoaiKhenThuongID",SqlDbType.Int,pDM_LoaiKhenThuongInfo.DM_LoaiKhenThuongID));

            RunProcedure("sp_DM_LoaiKhenThuong_Update", colParam);
        }
        
        public void Delete(DM_LoaiKhenThuongInfo pDM_LoaiKhenThuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_LoaiKhenThuongID",SqlDbType.Int,pDM_LoaiKhenThuongInfo.DM_LoaiKhenThuongID));

            RunProcedure("sp_DM_LoaiKhenThuong_Delete", colParam);
        }
    }
}
