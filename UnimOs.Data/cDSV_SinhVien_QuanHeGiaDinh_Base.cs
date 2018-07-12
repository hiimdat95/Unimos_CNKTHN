using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_SinhVien_QuanHeGiaDinh : cDBase
    {
        public DataTable Get(SV_SinhVien_QuanHeGiaDinhInfo pSV_SinhVien_QuanHeGiaDinhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_SinhVien_QuanHeGiaDinhID",SqlDbType.Int,pSV_SinhVien_QuanHeGiaDinhInfo.SV_SinhVien_QuanHeGiaDinhID));

            return RunProcedureGet("sp_SV_SinhVien_QuanHeGiaDinh_Get", colParam);            
        }

        public int Add(SV_SinhVien_QuanHeGiaDinhInfo pSV_SinhVien_QuanHeGiaDinhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_SinhVien_QuanHeGiaDinhInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_QuanHeGiaDinh",SqlDbType.Int,pSV_SinhVien_QuanHeGiaDinhInfo.IDDM_QuanHeGiaDinh));
            colParam.Add(CreateParam("@HoVaTen",SqlDbType.NVarChar,pSV_SinhVien_QuanHeGiaDinhInfo.HoVaTen));
            colParam.Add(CreateParam("@NamSinh",SqlDbType.NVarChar,pSV_SinhVien_QuanHeGiaDinhInfo.NamSinh));
            colParam.Add(CreateParam("@NgheNghiep",SqlDbType.NVarChar,pSV_SinhVien_QuanHeGiaDinhInfo.NgheNghiep));
            colParam.Add(CreateParam("@DiaChi",SqlDbType.NVarChar,pSV_SinhVien_QuanHeGiaDinhInfo.DiaChi));
            colParam.Add(CreateParam("@ThongTinKhac",SqlDbType.NVarChar,pSV_SinhVien_QuanHeGiaDinhInfo.ThongTinKhac));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_SV_SinhVien_QuanHeGiaDinh_Add", colParam);
        }
        
        public void Update(SV_SinhVien_QuanHeGiaDinhInfo pSV_SinhVien_QuanHeGiaDinhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_SinhVien_QuanHeGiaDinhInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_QuanHeGiaDinh",SqlDbType.Int,pSV_SinhVien_QuanHeGiaDinhInfo.IDDM_QuanHeGiaDinh));
            colParam.Add(CreateParam("@HoVaTen",SqlDbType.NVarChar,pSV_SinhVien_QuanHeGiaDinhInfo.HoVaTen));
            colParam.Add(CreateParam("@NamSinh",SqlDbType.NVarChar,pSV_SinhVien_QuanHeGiaDinhInfo.NamSinh));
            colParam.Add(CreateParam("@NgheNghiep",SqlDbType.NVarChar,pSV_SinhVien_QuanHeGiaDinhInfo.NgheNghiep));
            colParam.Add(CreateParam("@DiaChi",SqlDbType.NVarChar,pSV_SinhVien_QuanHeGiaDinhInfo.DiaChi));
            colParam.Add(CreateParam("@ThongTinKhac",SqlDbType.NVarChar,pSV_SinhVien_QuanHeGiaDinhInfo.ThongTinKhac));
            colParam.Add(CreateParam("@SV_SinhVien_QuanHeGiaDinhID",SqlDbType.Int,pSV_SinhVien_QuanHeGiaDinhInfo.SV_SinhVien_QuanHeGiaDinhID));

            RunProcedure("sp_SV_SinhVien_QuanHeGiaDinh_Update", colParam);
        }
        
        public void Delete(SV_SinhVien_QuanHeGiaDinhInfo pSV_SinhVien_QuanHeGiaDinhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_SinhVien_QuanHeGiaDinhID",SqlDbType.Int,pSV_SinhVien_QuanHeGiaDinhInfo.SV_SinhVien_QuanHeGiaDinhID));

            RunProcedure("sp_SV_SinhVien_QuanHeGiaDinh_Delete", colParam);
        }
    }
}
