using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_LoaiLuanChuyen : cDBase
    {
        public DataTable Get(NS_LoaiLuanChuyenInfo pNS_LoaiLuanChuyenInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_LoaiLuanChuyenID",SqlDbType.Int,pNS_LoaiLuanChuyenInfo.NS_LoaiLuanChuyenID));

            return RunProcedureGet("sp_NS_LoaiLuanChuyen_Get", colParam);            
        }

        public int Add(NS_LoaiLuanChuyenInfo pNS_LoaiLuanChuyenInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenLoaiLuanChuyen",SqlDbType.NVarChar,pNS_LoaiLuanChuyenInfo.TenLoaiLuanChuyen));
            colParam.Add(CreateParam("@TrangThaiGiaoVien",SqlDbType.Int,pNS_LoaiLuanChuyenInfo.TrangThaiGiaoVien));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_LoaiLuanChuyen_Add", colParam);
        }
        
        public void Update(NS_LoaiLuanChuyenInfo pNS_LoaiLuanChuyenInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenLoaiLuanChuyen",SqlDbType.NVarChar,pNS_LoaiLuanChuyenInfo.TenLoaiLuanChuyen));
            colParam.Add(CreateParam("@TrangThaiGiaoVien",SqlDbType.Int,pNS_LoaiLuanChuyenInfo.TrangThaiGiaoVien));
            colParam.Add(CreateParam("@NS_LoaiLuanChuyenID",SqlDbType.Int,pNS_LoaiLuanChuyenInfo.NS_LoaiLuanChuyenID));

            RunProcedure("sp_NS_LoaiLuanChuyen_Update", colParam);
        }
        
        public void Delete(NS_LoaiLuanChuyenInfo pNS_LoaiLuanChuyenInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_LoaiLuanChuyenID",SqlDbType.Int,pNS_LoaiLuanChuyenInfo.NS_LoaiLuanChuyenID));

            RunProcedure("sp_NS_LoaiLuanChuyen_Delete", colParam);
        }
    }
}
