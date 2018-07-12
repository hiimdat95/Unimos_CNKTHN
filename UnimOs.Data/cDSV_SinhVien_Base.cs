using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_SinhVien : cDBase
    {
        public DataTable Get(SV_SinhVienInfo pSV_SinhVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_SinhVienID",SqlDbType.Int,pSV_SinhVienInfo.SV_SinhVienID));

            return RunProcedureGet("sp_SV_SinhVien_Get", colParam);            
        }

        public int Add(SV_SinhVienInfo pSV_SinhVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaSinhVien", SqlDbType.NVarChar, pSV_SinhVienInfo.MaSinhVien));
            colParam.Add(CreateParam("@HoVaTen", SqlDbType.NVarChar, pSV_SinhVienInfo.HoVaTen));
            colParam.Add(CreateParam("@Ten", SqlDbType.NVarChar, pSV_SinhVienInfo.Ten));
            colParam.Add(CreateParam("@NgaySinh", SqlDbType.DateTime, pSV_SinhVienInfo.NgaySinh));
            colParam.Add(CreateParam("@SoBaoDanh", SqlDbType.NVarChar, pSV_SinhVienInfo.SoBaoDanh));
            colParam.Add(CreateParam("@SoCMND", SqlDbType.VarChar, pSV_SinhVienInfo.SoCMND));
            colParam.Add(CreateParam("@NgayCapCMND", SqlDbType.DateTime, pSV_SinhVienInfo.NgayCapCMND));
            colParam.Add(CreateParam("@IDTinhNoiCapCMND", SqlDbType.Int, pSV_SinhVienInfo.IDTinhNoiCapCMND));
            colParam.Add(CreateParam("@Anh", SqlDbType.Image, pSV_SinhVienInfo.Anh));
            colParam.Add(CreateParam("@GioiTinh", SqlDbType.Bit, pSV_SinhVienInfo.GioiTinh));
            colParam.Add(CreateParam("@ThanhPhanXuatThan", SqlDbType.Int, pSV_SinhVienInfo.ThanhPhanXuatThan));
            colParam.Add(CreateParam("@IDDM_DanToc", SqlDbType.Int, pSV_SinhVienInfo.IDDM_DanToc));
            colParam.Add(CreateParam("@IDDM_TonGiao", SqlDbType.Int, pSV_SinhVienInfo.IDDM_TonGiao));
            colParam.Add(CreateParam("@IDDM_QuocTich", SqlDbType.Int, pSV_SinhVienInfo.IDDM_QuocTich));
            colParam.Add(CreateParam("@NoiSinh", SqlDbType.NVarChar, pSV_SinhVienInfo.NoiSinh));
            colParam.Add(CreateParam("@IDDM_TinhHuyenXaNoiSinh", SqlDbType.Int, pSV_SinhVienInfo.IDDM_TinhHuyenXaNoiSinh));
            colParam.Add(CreateParam("@QueQuan", SqlDbType.NVarChar, pSV_SinhVienInfo.QueQuan));
            colParam.Add(CreateParam("@IDDM_TinhHuyenXaQueQuan", SqlDbType.Int, pSV_SinhVienInfo.IDDM_TinhHuyenXaQueQuan));
            colParam.Add(CreateParam("@ThuongTru", SqlDbType.NVarChar, pSV_SinhVienInfo.ThuongTru));
            colParam.Add(CreateParam("@IDDM_TinhHuyenXaThuongTru", SqlDbType.Int, pSV_SinhVienInfo.IDDM_TinhHuyenXaThuongTru));
            colParam.Add(CreateParam("@NgayVaoDoan", SqlDbType.DateTime, pSV_SinhVienInfo.NgayVaoDoan));
            colParam.Add(CreateParam("@NgayVaoDang", SqlDbType.DateTime, pSV_SinhVienInfo.NgayVaoDang));
            colParam.Add(CreateParam("@DienThoaiNhaRieng", SqlDbType.VarChar, pSV_SinhVienInfo.DienThoaiNhaRieng));
            colParam.Add(CreateParam("@DienThoaiDiDong", SqlDbType.VarChar, pSV_SinhVienInfo.DienThoaiDiDong));
            colParam.Add(CreateParam("@BaoTinCho", SqlDbType.NVarChar, pSV_SinhVienInfo.BaoTinCho));
            colParam.Add(CreateParam("@DiaChiBaoTin", SqlDbType.NVarChar, pSV_SinhVienInfo.DiaChiBaoTin));
            colParam.Add(CreateParam("@Email", SqlDbType.NVarChar, pSV_SinhVienInfo.Email));
            colParam.Add(CreateParam("@Active", SqlDbType.Int, pSV_SinhVienInfo.Active));
            colParam.Add(CreateParam("@Xoa", SqlDbType.Bit, pSV_SinhVienInfo.Xoa));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_SV_SinhVien_Add", colParam);
        }

        public void Update(SV_SinhVienInfo pSV_SinhVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaSinhVien", SqlDbType.NVarChar, pSV_SinhVienInfo.MaSinhVien));
            colParam.Add(CreateParam("@HoVaTen", SqlDbType.NVarChar, pSV_SinhVienInfo.HoVaTen));
            colParam.Add(CreateParam("@Ten", SqlDbType.NVarChar, pSV_SinhVienInfo.Ten));
            colParam.Add(CreateParam("@NgaySinh", SqlDbType.DateTime, pSV_SinhVienInfo.NgaySinh));
            colParam.Add(CreateParam("@SoBaoDanh", SqlDbType.NVarChar, pSV_SinhVienInfo.SoBaoDanh));
            colParam.Add(CreateParam("@SoCMND", SqlDbType.VarChar, pSV_SinhVienInfo.SoCMND));
            colParam.Add(CreateParam("@NgayCapCMND", SqlDbType.DateTime, pSV_SinhVienInfo.NgayCapCMND));
            colParam.Add(CreateParam("@IDTinhNoiCapCMND", SqlDbType.Int, pSV_SinhVienInfo.IDTinhNoiCapCMND));
            colParam.Add(CreateParam("@Anh", SqlDbType.Image, pSV_SinhVienInfo.Anh));
            colParam.Add(CreateParam("@GioiTinh", SqlDbType.Bit, pSV_SinhVienInfo.GioiTinh));
            colParam.Add(CreateParam("@ThanhPhanXuatThan", SqlDbType.Int, pSV_SinhVienInfo.ThanhPhanXuatThan));
            colParam.Add(CreateParam("@IDDM_DanToc", SqlDbType.Int, pSV_SinhVienInfo.IDDM_DanToc));
            colParam.Add(CreateParam("@IDDM_TonGiao", SqlDbType.Int, pSV_SinhVienInfo.IDDM_TonGiao));
            colParam.Add(CreateParam("@IDDM_QuocTich", SqlDbType.Int, pSV_SinhVienInfo.IDDM_QuocTich));
            colParam.Add(CreateParam("@NoiSinh", SqlDbType.NVarChar, pSV_SinhVienInfo.NoiSinh));
            colParam.Add(CreateParam("@IDDM_TinhHuyenXaNoiSinh", SqlDbType.Int, pSV_SinhVienInfo.IDDM_TinhHuyenXaNoiSinh));
            colParam.Add(CreateParam("@QueQuan", SqlDbType.NVarChar, pSV_SinhVienInfo.QueQuan));
            colParam.Add(CreateParam("@IDDM_TinhHuyenXaQueQuan", SqlDbType.Int, pSV_SinhVienInfo.IDDM_TinhHuyenXaQueQuan));
            colParam.Add(CreateParam("@ThuongTru", SqlDbType.NVarChar, pSV_SinhVienInfo.ThuongTru));
            colParam.Add(CreateParam("@IDDM_TinhHuyenXaThuongTru", SqlDbType.Int, pSV_SinhVienInfo.IDDM_TinhHuyenXaThuongTru));
            colParam.Add(CreateParam("@NgayVaoDoan", SqlDbType.DateTime, pSV_SinhVienInfo.NgayVaoDoan));
            colParam.Add(CreateParam("@NgayVaoDang", SqlDbType.DateTime, pSV_SinhVienInfo.NgayVaoDang));
            colParam.Add(CreateParam("@DienThoaiNhaRieng", SqlDbType.VarChar, pSV_SinhVienInfo.DienThoaiNhaRieng));
            colParam.Add(CreateParam("@DienThoaiDiDong", SqlDbType.VarChar, pSV_SinhVienInfo.DienThoaiDiDong));
            colParam.Add(CreateParam("@BaoTinCho", SqlDbType.NVarChar, pSV_SinhVienInfo.BaoTinCho));
            colParam.Add(CreateParam("@DiaChiBaoTin", SqlDbType.NVarChar, pSV_SinhVienInfo.DiaChiBaoTin));
            colParam.Add(CreateParam("@Email", SqlDbType.NVarChar, pSV_SinhVienInfo.Email));
            colParam.Add(CreateParam("@Active", SqlDbType.Int, pSV_SinhVienInfo.Active));
            colParam.Add(CreateParam("@Xoa", SqlDbType.Bit, pSV_SinhVienInfo.Xoa));
            colParam.Add(CreateParam("@SV_SinhVienID", SqlDbType.Int, pSV_SinhVienInfo.SV_SinhVienID));

            RunProcedure("sp_SV_SinhVien_Update", colParam);
        }
        
        public void Delete(SV_SinhVienInfo pSV_SinhVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_SinhVienID",SqlDbType.Int,pSV_SinhVienInfo.SV_SinhVienID));

            RunProcedure("sp_SV_SinhVien_Delete", colParam);
        }
    }
}
