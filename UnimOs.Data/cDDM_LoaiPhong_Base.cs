using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_LoaiPhong : cDBase
    {
        public DataTable Get(DM_LoaiPhongInfo pDM_LoaiPhongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_LoaiPhongID",SqlDbType.Int,pDM_LoaiPhongInfo.DM_LoaiPhongID));

            return RunProcedureGet("sp_DM_LoaiPhong_Get", colParam);            
        }

        public int Add(DM_LoaiPhongInfo pDM_LoaiPhongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaLoaiPhong",SqlDbType.NVarChar,pDM_LoaiPhongInfo.MaLoaiPhong));
            colParam.Add(CreateParam("@TenLoaiPhong",SqlDbType.NVarChar,pDM_LoaiPhongInfo.TenLoaiPhong));
            colParam.Add(CreateParam("@LyThuyet",SqlDbType.Bit,pDM_LoaiPhongInfo.LyThuyet));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_LoaiPhong_Add", colParam);
        }
        
        public void Update(DM_LoaiPhongInfo pDM_LoaiPhongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaLoaiPhong",SqlDbType.NVarChar,pDM_LoaiPhongInfo.MaLoaiPhong));
            colParam.Add(CreateParam("@TenLoaiPhong",SqlDbType.NVarChar,pDM_LoaiPhongInfo.TenLoaiPhong));
            colParam.Add(CreateParam("@LyThuyet",SqlDbType.Bit,pDM_LoaiPhongInfo.LyThuyet));
            colParam.Add(CreateParam("@DM_LoaiPhongID",SqlDbType.Int,pDM_LoaiPhongInfo.DM_LoaiPhongID));

            RunProcedure("sp_DM_LoaiPhong_Update", colParam);
        }
        
        public void Delete(DM_LoaiPhongInfo pDM_LoaiPhongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_LoaiPhongID",SqlDbType.Int,pDM_LoaiPhongInfo.DM_LoaiPhongID));

            RunProcedure("sp_DM_LoaiPhong_Delete", colParam);
        }
    }
}
