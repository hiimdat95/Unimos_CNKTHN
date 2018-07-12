using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_GiaoVien_QuanHeGiaDinh : cDBase
    {
        public DataTable Get(NS_GiaoVien_QuanHeGiaDinhInfo pNS_GiaoVien_QuanHeGiaDinhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_GiaoVien_QuanHeGiaDinhID",SqlDbType.Int,pNS_GiaoVien_QuanHeGiaDinhInfo.NS_GiaoVien_QuanHeGiaDinhID));

            return RunProcedureGet("sp_NS_GiaoVien_QuanHeGiaDinh_Get", colParam);            
        }

        public int Add(NS_GiaoVien_QuanHeGiaDinhInfo pNS_GiaoVien_QuanHeGiaDinhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_GiaoVien_QuanHeGiaDinhInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDDM_QuanHeGiaDinh",SqlDbType.Int,pNS_GiaoVien_QuanHeGiaDinhInfo.IDDM_QuanHeGiaDinh));
            colParam.Add(CreateParam("@HoVaTen",SqlDbType.NVarChar,pNS_GiaoVien_QuanHeGiaDinhInfo.HoVaTen));
            colParam.Add(CreateParam("@NamSinh",SqlDbType.NChar,pNS_GiaoVien_QuanHeGiaDinhInfo.NamSinh));
            colParam.Add(CreateParam("@DiaChiQueQuan",SqlDbType.NVarChar,pNS_GiaoVien_QuanHeGiaDinhInfo.DiaChiQueQuan));
            colParam.Add(CreateParam("@IDDM_TinhHuyenXaQueQuan",SqlDbType.Int,pNS_GiaoVien_QuanHeGiaDinhInfo.IDDM_TinhHuyenXaQueQuan));
            colParam.Add(CreateParam("@NgheNghiep", SqlDbType.NVarChar, pNS_GiaoVien_QuanHeGiaDinhInfo.NgheNghiep));
            colParam.Add(CreateParam("@ThongTinKhac",SqlDbType.NVarChar,pNS_GiaoVien_QuanHeGiaDinhInfo.ThongTinKhac));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_GiaoVien_QuanHeGiaDinh_Add", colParam);
        }
        
        public void Update(NS_GiaoVien_QuanHeGiaDinhInfo pNS_GiaoVien_QuanHeGiaDinhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_GiaoVien_QuanHeGiaDinhInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDDM_QuanHeGiaDinh",SqlDbType.Int,pNS_GiaoVien_QuanHeGiaDinhInfo.IDDM_QuanHeGiaDinh));
            colParam.Add(CreateParam("@HoVaTen",SqlDbType.NVarChar,pNS_GiaoVien_QuanHeGiaDinhInfo.HoVaTen));
            colParam.Add(CreateParam("@NamSinh",SqlDbType.NChar,pNS_GiaoVien_QuanHeGiaDinhInfo.NamSinh));
            colParam.Add(CreateParam("@DiaChiQueQuan",SqlDbType.NVarChar,pNS_GiaoVien_QuanHeGiaDinhInfo.DiaChiQueQuan));
            colParam.Add(CreateParam("@IDDM_TinhHuyenXaQueQuan",SqlDbType.Int,pNS_GiaoVien_QuanHeGiaDinhInfo.IDDM_TinhHuyenXaQueQuan));
            colParam.Add(CreateParam("@NgheNghiep", SqlDbType.NVarChar, pNS_GiaoVien_QuanHeGiaDinhInfo.NgheNghiep));
            colParam.Add(CreateParam("@ThongTinKhac",SqlDbType.NVarChar,pNS_GiaoVien_QuanHeGiaDinhInfo.ThongTinKhac));
            colParam.Add(CreateParam("@NS_GiaoVien_QuanHeGiaDinhID",SqlDbType.Int,pNS_GiaoVien_QuanHeGiaDinhInfo.NS_GiaoVien_QuanHeGiaDinhID));

            RunProcedure("sp_NS_GiaoVien_QuanHeGiaDinh_Update", colParam);
        }
        
        public void Delete(NS_GiaoVien_QuanHeGiaDinhInfo pNS_GiaoVien_QuanHeGiaDinhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_GiaoVien_QuanHeGiaDinhID",SqlDbType.Int,pNS_GiaoVien_QuanHeGiaDinhInfo.NS_GiaoVien_QuanHeGiaDinhID));

            RunProcedure("sp_NS_GiaoVien_QuanHeGiaDinh_Delete", colParam);
        }
    }
}
