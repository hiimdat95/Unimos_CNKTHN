using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_QuaTrinhKhenThuong : cDBase
    {
        public DataTable Get(NS_QuaTrinhKhenThuongInfo pNS_QuaTrinhKhenThuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_QuaTrinhKhenThuongID",SqlDbType.Int,pNS_QuaTrinhKhenThuongInfo.NS_QuaTrinhKhenThuongID));

            return RunProcedureGet("sp_NS_QuaTrinhKhenThuong_Get", colParam);            
        }

        public int Add(NS_QuaTrinhKhenThuongInfo pNS_QuaTrinhKhenThuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_QuaTrinhKhenThuongInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pNS_QuaTrinhKhenThuongInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayQuyetDinh",SqlDbType.DateTime,pNS_QuaTrinhKhenThuongInfo.NgayQuyetDinh));
            colParam.Add(CreateParam("@NgayCoHieuLuc",SqlDbType.DateTime,pNS_QuaTrinhKhenThuongInfo.NgayCoHieuLuc));
            colParam.Add(CreateParam("@IDDM_CapKhenThuong",SqlDbType.Int,pNS_QuaTrinhKhenThuongInfo.IDDM_CapKhenThuong));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NVarChar,pNS_QuaTrinhKhenThuongInfo.NoiDung));
            colParam.Add(CreateParam("@GiamSoThangTangLuong",SqlDbType.Int,pNS_QuaTrinhKhenThuongInfo.GiamSoThangTangLuong));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pNS_QuaTrinhKhenThuongInfo.SoTien));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_QuaTrinhKhenThuong_Add", colParam);
        }
        
        public void Update(NS_QuaTrinhKhenThuongInfo pNS_QuaTrinhKhenThuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_QuaTrinhKhenThuongInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pNS_QuaTrinhKhenThuongInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayQuyetDinh",SqlDbType.DateTime,pNS_QuaTrinhKhenThuongInfo.NgayQuyetDinh));
            colParam.Add(CreateParam("@NgayCoHieuLuc",SqlDbType.DateTime,pNS_QuaTrinhKhenThuongInfo.NgayCoHieuLuc));
            colParam.Add(CreateParam("@IDDM_CapKhenThuong",SqlDbType.Int,pNS_QuaTrinhKhenThuongInfo.IDDM_CapKhenThuong));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NVarChar,pNS_QuaTrinhKhenThuongInfo.NoiDung));
            colParam.Add(CreateParam("@GiamSoThangTangLuong",SqlDbType.Int,pNS_QuaTrinhKhenThuongInfo.GiamSoThangTangLuong));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pNS_QuaTrinhKhenThuongInfo.SoTien));
            colParam.Add(CreateParam("@NS_QuaTrinhKhenThuongID",SqlDbType.Int,pNS_QuaTrinhKhenThuongInfo.NS_QuaTrinhKhenThuongID));

            RunProcedure("sp_NS_QuaTrinhKhenThuong_Update", colParam);
        }
        
        public void Delete(NS_QuaTrinhKhenThuongInfo pNS_QuaTrinhKhenThuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_QuaTrinhKhenThuongID",SqlDbType.Int,pNS_QuaTrinhKhenThuongInfo.NS_QuaTrinhKhenThuongID));

            RunProcedure("sp_NS_QuaTrinhKhenThuong_Delete", colParam);
        }
    }
}
