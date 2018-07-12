using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_GiaoVien : cDBase
    {
        public DataTable Get(NS_GiaoVienInfo pNS_GiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_GiaoVienID", SqlDbType.Int, pNS_GiaoVienInfo.NS_GiaoVienID));

            return RunProcedureGet("sp_NS_GiaoVien_Get", colParam);
        }

        public int Add(NS_GiaoVienInfo pNS_GiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaGiaoVien", SqlDbType.NVarChar, pNS_GiaoVienInfo.MaGiaoVien));
            colParam.Add(CreateParam("@HoTen", SqlDbType.NVarChar, pNS_GiaoVienInfo.HoTen));
            colParam.Add(CreateParam("@Ten", SqlDbType.NVarChar, pNS_GiaoVienInfo.Ten));
            colParam.Add(CreateParam("@TenVietTat", SqlDbType.NVarChar, pNS_GiaoVienInfo.TenVietTat));
            colParam.Add(CreateParam("@NgaySinh", SqlDbType.DateTime, pNS_GiaoVienInfo.NgaySinh));
            colParam.Add(CreateParam("@IDNS_DonVi", SqlDbType.Int, pNS_GiaoVienInfo.IDNS_DonVi));
            colParam.Add(CreateParam("@Anh", SqlDbType.Image, pNS_GiaoVienInfo.Anh));
            colParam.Add(CreateParam("@DienThoai", SqlDbType.VarChar, pNS_GiaoVienInfo.DienThoai));
            colParam.Add(CreateParam("@IDDM_TinhHuyenXaQueQuan", SqlDbType.Int, pNS_GiaoVienInfo.IDDM_TinhHuyenXaQueQuan));
            colParam.Add(CreateParam("@IDDM_TinhHuyenXaNoiSinh", SqlDbType.Int, pNS_GiaoVienInfo.IDDM_TinhHuyenXaNoiSinh));
            colParam.Add(CreateParam("@DiaChiThuongTru", SqlDbType.NVarChar, pNS_GiaoVienInfo.DiaChiThuongTru));
            colParam.Add(CreateParam("@IDDM_TinhHuyenXaThuongTru", SqlDbType.Int, pNS_GiaoVienInfo.IDDM_TinhHuyenXaThuongTru));
            colParam.Add(CreateParam("@DiaChiNoiO", SqlDbType.NVarChar, pNS_GiaoVienInfo.DiaChiNoiO));
            colParam.Add(CreateParam("@IDDM_TinhHuyenXaNoiO", SqlDbType.Int, pNS_GiaoVienInfo.IDDM_TinhHuyenXaNoiO));
            colParam.Add(CreateParam("@IDDM_DanToc", SqlDbType.Int, pNS_GiaoVienInfo.IDDM_DanToc));
            colParam.Add(CreateParam("@IDDM_TonGiao", SqlDbType.Int, pNS_GiaoVienInfo.IDDM_TonGiao));
            colParam.Add(CreateParam("@GioiTinh", SqlDbType.Bit, pNS_GiaoVienInfo.GioiTinh));
            colParam.Add(CreateParam("@SoCMND", SqlDbType.VarChar, pNS_GiaoVienInfo.SoCMND));
            colParam.Add(CreateParam("@NgayCap", SqlDbType.DateTime, pNS_GiaoVienInfo.NgayCap));
            colParam.Add(CreateParam("@Email", SqlDbType.NVarChar, pNS_GiaoVienInfo.Email));
            colParam.Add(CreateParam("@GiangDay", SqlDbType.Bit, pNS_GiaoVienInfo.GiangDay));
            colParam.Add(CreateParam("@TrangThaiGiaoVien", SqlDbType.Int, pNS_GiaoVienInfo.TrangThaiGiaoVien));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_GiaoVien_Add", colParam);
        }

        public void Update(NS_GiaoVienInfo pNS_GiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaGiaoVien", SqlDbType.NVarChar, pNS_GiaoVienInfo.MaGiaoVien));
            colParam.Add(CreateParam("@HoTen", SqlDbType.NVarChar, pNS_GiaoVienInfo.HoTen));
            colParam.Add(CreateParam("@Ten", SqlDbType.NVarChar, pNS_GiaoVienInfo.Ten));
            colParam.Add(CreateParam("@TenVietTat", SqlDbType.NVarChar, pNS_GiaoVienInfo.TenVietTat));
            colParam.Add(CreateParam("@NgaySinh", SqlDbType.DateTime, pNS_GiaoVienInfo.NgaySinh));
            colParam.Add(CreateParam("@IDNS_DonVi", SqlDbType.Int, pNS_GiaoVienInfo.IDNS_DonVi));
            colParam.Add(CreateParam("@Anh", SqlDbType.Image, pNS_GiaoVienInfo.Anh));
            colParam.Add(CreateParam("@DienThoai", SqlDbType.VarChar, pNS_GiaoVienInfo.DienThoai));
            colParam.Add(CreateParam("@IDDM_TinhHuyenXaQueQuan", SqlDbType.Int, pNS_GiaoVienInfo.IDDM_TinhHuyenXaQueQuan));
            colParam.Add(CreateParam("@IDDM_TinhHuyenXaNoiSinh", SqlDbType.Int, pNS_GiaoVienInfo.IDDM_TinhHuyenXaNoiSinh));
            colParam.Add(CreateParam("@DiaChiThuongTru", SqlDbType.NVarChar, pNS_GiaoVienInfo.DiaChiThuongTru));
            colParam.Add(CreateParam("@IDDM_TinhHuyenXaThuongTru", SqlDbType.Int, pNS_GiaoVienInfo.IDDM_TinhHuyenXaThuongTru));
            colParam.Add(CreateParam("@DiaChiNoiO", SqlDbType.NVarChar, pNS_GiaoVienInfo.DiaChiNoiO));
            colParam.Add(CreateParam("@IDDM_TinhHuyenXaNoiO", SqlDbType.Int, pNS_GiaoVienInfo.IDDM_TinhHuyenXaNoiO));
            colParam.Add(CreateParam("@IDDM_DanToc", SqlDbType.Int, pNS_GiaoVienInfo.IDDM_DanToc));
            colParam.Add(CreateParam("@IDDM_TonGiao", SqlDbType.Int, pNS_GiaoVienInfo.IDDM_TonGiao));
            colParam.Add(CreateParam("@GioiTinh", SqlDbType.Bit, pNS_GiaoVienInfo.GioiTinh));
            colParam.Add(CreateParam("@SoCMND", SqlDbType.VarChar, pNS_GiaoVienInfo.SoCMND));
            colParam.Add(CreateParam("@NgayCap", SqlDbType.DateTime, pNS_GiaoVienInfo.NgayCap));
            colParam.Add(CreateParam("@Email", SqlDbType.NVarChar, pNS_GiaoVienInfo.Email));
            colParam.Add(CreateParam("@GiangDay", SqlDbType.Bit, pNS_GiaoVienInfo.GiangDay));
            colParam.Add(CreateParam("@TrangThaiGiaoVien", SqlDbType.Int, pNS_GiaoVienInfo.TrangThaiGiaoVien));
            colParam.Add(CreateParam("@NS_GiaoVienID", SqlDbType.Int, pNS_GiaoVienInfo.NS_GiaoVienID));

            RunProcedure("sp_NS_GiaoVien_Update", colParam);
        }

        public void Delete(NS_GiaoVienInfo pNS_GiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_GiaoVienID", SqlDbType.Int, pNS_GiaoVienInfo.NS_GiaoVienID));

            RunProcedure("sp_NS_GiaoVien_Delete", colParam);
        }
    }
}
