using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_QuaTrinhKyLuat : cDBase
    {
        public DataTable Get(NS_QuaTrinhKyLuatInfo pNS_QuaTrinhKyLuatInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_QuaTrinhKyLuatID",SqlDbType.Int,pNS_QuaTrinhKyLuatInfo.NS_QuaTrinhKyLuatID));

            return RunProcedureGet("sp_NS_QuaTrinhKyLuat_Get", colParam);            
        }

        public int Add(NS_QuaTrinhKyLuatInfo pNS_QuaTrinhKyLuatInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_QuaTrinhKyLuatInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pNS_QuaTrinhKyLuatInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayQuyetDinh",SqlDbType.DateTime,pNS_QuaTrinhKyLuatInfo.NgayQuyetDinh));
            colParam.Add(CreateParam("@IDDM_CapKhenThuong",SqlDbType.Int,pNS_QuaTrinhKyLuatInfo.IDDM_CapKhenThuong));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NVarChar,pNS_QuaTrinhKyLuatInfo.NoiDung));
            colParam.Add(CreateParam("@TangSoThangTangLuong",SqlDbType.Int,pNS_QuaTrinhKyLuatInfo.TangSoThangTangLuong));
            colParam.Add(CreateParam("@NgayCoHieuLuc",SqlDbType.DateTime,pNS_QuaTrinhKyLuatInfo.NgayCoHieuLuc));
            colParam.Add(CreateParam("@NgayHetHieuLuc",SqlDbType.DateTime,pNS_QuaTrinhKyLuatInfo.NgayHetHieuLuc));
            colParam.Add(CreateParam("@XoaKyLuat", SqlDbType.Bit, pNS_QuaTrinhKyLuatInfo.XoaKyLuat));
            colParam.Add(CreateParam("@NgayXoa", SqlDbType.DateTime, pNS_QuaTrinhKyLuatInfo.NgayXoa));
            colParam.Add(CreateParam("@LyDoXoa", SqlDbType.NVarChar, pNS_QuaTrinhKyLuatInfo.LyDoXoa));
            colParam.Add(CreateParam("@XoaTangSoThangTangLuong", SqlDbType.Bit, pNS_QuaTrinhKyLuatInfo.XoaTangSoThangTangLuong));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_QuaTrinhKyLuat_Add", colParam);
        }
        
        public void Update(NS_QuaTrinhKyLuatInfo pNS_QuaTrinhKyLuatInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_QuaTrinhKyLuatInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pNS_QuaTrinhKyLuatInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayQuyetDinh",SqlDbType.DateTime,pNS_QuaTrinhKyLuatInfo.NgayQuyetDinh));
            colParam.Add(CreateParam("@IDDM_CapKhenThuong",SqlDbType.Int,pNS_QuaTrinhKyLuatInfo.IDDM_CapKhenThuong));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NVarChar,pNS_QuaTrinhKyLuatInfo.NoiDung));
            colParam.Add(CreateParam("@TangSoThangTangLuong",SqlDbType.Int,pNS_QuaTrinhKyLuatInfo.TangSoThangTangLuong));
            colParam.Add(CreateParam("@NgayCoHieuLuc",SqlDbType.DateTime,pNS_QuaTrinhKyLuatInfo.NgayCoHieuLuc));
            colParam.Add(CreateParam("@NgayHetHieuLuc",SqlDbType.DateTime,pNS_QuaTrinhKyLuatInfo.NgayHetHieuLuc));
            colParam.Add(CreateParam("@XoaKyLuat", SqlDbType.Bit, pNS_QuaTrinhKyLuatInfo.XoaKyLuat));
            colParam.Add(CreateParam("@NgayXoa", SqlDbType.DateTime, pNS_QuaTrinhKyLuatInfo.NgayXoa));
            colParam.Add(CreateParam("@LyDoXoa", SqlDbType.NVarChar, pNS_QuaTrinhKyLuatInfo.LyDoXoa));
            colParam.Add(CreateParam("@XoaTangSoThangTangLuong", SqlDbType.Bit, pNS_QuaTrinhKyLuatInfo.XoaTangSoThangTangLuong));
            colParam.Add(CreateParam("@NS_QuaTrinhKyLuatID",SqlDbType.Int,pNS_QuaTrinhKyLuatInfo.NS_QuaTrinhKyLuatID));

            RunProcedure("sp_NS_QuaTrinhKyLuat_Update", colParam);
        }
        
        public void Delete(NS_QuaTrinhKyLuatInfo pNS_QuaTrinhKyLuatInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_QuaTrinhKyLuatID",SqlDbType.Int,pNS_QuaTrinhKyLuatInfo.NS_QuaTrinhKyLuatID));

            RunProcedure("sp_NS_QuaTrinhKyLuat_Delete", colParam);
        }
    }
}
