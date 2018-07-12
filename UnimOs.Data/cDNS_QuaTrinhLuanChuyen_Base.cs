using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_QuaTrinhLuanChuyen : cDBase
    {
        public DataTable Get(NS_QuaTrinhLuanChuyenInfo pNS_QuaTrinhLuanChuyenInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_QuaTrinhLuanChuyenID",SqlDbType.Int,pNS_QuaTrinhLuanChuyenInfo.NS_QuaTrinhLuanChuyenID));

            return RunProcedureGet("sp_NS_QuaTrinhLuanChuyen_Get", colParam);            
        }

        public int Add(NS_QuaTrinhLuanChuyenInfo pNS_QuaTrinhLuanChuyenInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_QuaTrinhLuanChuyenInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pNS_QuaTrinhLuanChuyenInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayQuyetDinh",SqlDbType.DateTime,pNS_QuaTrinhLuanChuyenInfo.NgayQuyetDinh));
            colParam.Add(CreateParam("@NgayCoHieuLuc",SqlDbType.DateTime,pNS_QuaTrinhLuanChuyenInfo.NgayCoHieuLuc));
            colParam.Add(CreateParam("@IDNS_LoaiLuanChuyen",SqlDbType.Int,pNS_QuaTrinhLuanChuyenInfo.IDNS_LoaiLuanChuyen));
            colParam.Add(CreateParam("@IDNS_DonViCu",SqlDbType.Int,pNS_QuaTrinhLuanChuyenInfo.IDNS_DonViCu));
            colParam.Add(CreateParam("@IDNS_DonViMoi",SqlDbType.Int,pNS_QuaTrinhLuanChuyenInfo.IDNS_DonViMoi));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NVarChar,pNS_QuaTrinhLuanChuyenInfo.NoiDung));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_QuaTrinhLuanChuyen_Add", colParam);
        }
        
        public void Update(NS_QuaTrinhLuanChuyenInfo pNS_QuaTrinhLuanChuyenInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_QuaTrinhLuanChuyenInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pNS_QuaTrinhLuanChuyenInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayQuyetDinh",SqlDbType.DateTime,pNS_QuaTrinhLuanChuyenInfo.NgayQuyetDinh));
            colParam.Add(CreateParam("@NgayCoHieuLuc",SqlDbType.DateTime,pNS_QuaTrinhLuanChuyenInfo.NgayCoHieuLuc));
            colParam.Add(CreateParam("@IDNS_LoaiLuanChuyen",SqlDbType.Int,pNS_QuaTrinhLuanChuyenInfo.IDNS_LoaiLuanChuyen));
            colParam.Add(CreateParam("@IDNS_DonViCu",SqlDbType.Int,pNS_QuaTrinhLuanChuyenInfo.IDNS_DonViCu));
            colParam.Add(CreateParam("@IDNS_DonViMoi",SqlDbType.Int,pNS_QuaTrinhLuanChuyenInfo.IDNS_DonViMoi));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NVarChar,pNS_QuaTrinhLuanChuyenInfo.NoiDung));
            colParam.Add(CreateParam("@NS_QuaTrinhLuanChuyenID",SqlDbType.Int,pNS_QuaTrinhLuanChuyenInfo.NS_QuaTrinhLuanChuyenID));

            RunProcedure("sp_NS_QuaTrinhLuanChuyen_Update", colParam);
        }
        
        public void Delete(NS_QuaTrinhLuanChuyenInfo pNS_QuaTrinhLuanChuyenInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_QuaTrinhLuanChuyenID",SqlDbType.Int,pNS_QuaTrinhLuanChuyenInfo.NS_QuaTrinhLuanChuyenID));

            RunProcedure("sp_NS_QuaTrinhLuanChuyen_Delete", colParam);
        }
    }
}
