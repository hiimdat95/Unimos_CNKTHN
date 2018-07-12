using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_GiaoVien_ThongTin : cDBase
    {
        public DataTable Get(NS_GiaoVien_ThongTinInfo pNS_GiaoVien_ThongTinInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_GiaoVien_ThongTinID",SqlDbType.Int,pNS_GiaoVien_ThongTinInfo.NS_GiaoVien_ThongTinID));

            return RunProcedureGet("sp_NS_GiaoVien_ThongTin_Get", colParam);            
        }

        public int Add(NS_GiaoVien_ThongTinInfo pNS_GiaoVien_ThongTinInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_GiaoVien_ThongTinInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@NgheNghiepTuyenDung",SqlDbType.NVarChar,pNS_GiaoVien_ThongTinInfo.NgheNghiepTuyenDung));
            colParam.Add(CreateParam("@NgayTuyenDung",SqlDbType.DateTime,pNS_GiaoVien_ThongTinInfo.NgayTuyenDung));
            colParam.Add(CreateParam("@IsGiaoVienChinhTri", SqlDbType.Bit, pNS_GiaoVien_ThongTinInfo.IsGiaoVienChinhTri));
            colParam.Add(CreateParam("@IDDM_ChucDanh",SqlDbType.Int,pNS_GiaoVien_ThongTinInfo.IDDM_ChucDanh));
            colParam.Add(CreateParam("@IDDM_HocHam",SqlDbType.Int,pNS_GiaoVien_ThongTinInfo.IDDM_HocHam));
            colParam.Add(CreateParam("@IDDM_HocVi", SqlDbType.Int, pNS_GiaoVien_ThongTinInfo.IDDM_HocVi));
            colParam.Add(CreateParam("@TrinhDoPhoThong",SqlDbType.NVarChar,pNS_GiaoVien_ThongTinInfo.TrinhDoPhoThong));
            colParam.Add(CreateParam("@IDTrinhDoTinHoc", SqlDbType.NVarChar, pNS_GiaoVien_ThongTinInfo.IDTrinhDoTinHoc));
            colParam.Add(CreateParam("@TrinhDoTinHoc",SqlDbType.NVarChar,pNS_GiaoVien_ThongTinInfo.TrinhDoTinHoc));
            colParam.Add(CreateParam("@IDDM_TrinhDoChuyenMon",SqlDbType.Int,pNS_GiaoVien_ThongTinInfo.IDDM_TrinhDoChuyenMon));
            colParam.Add(CreateParam("@IDDM_TrinhDoLyLuan",SqlDbType.Int,pNS_GiaoVien_ThongTinInfo.IDDM_TrinhDoLyLuan));
            colParam.Add(CreateParam("@IDDM_QuanLyHanhChinhNhaNuoc",SqlDbType.Int,pNS_GiaoVien_ThongTinInfo.IDDM_QuanLyHanhChinhNhaNuoc));
            colParam.Add(CreateParam("@NgayVaoDang",SqlDbType.DateTime,pNS_GiaoVien_ThongTinInfo.NgayVaoDang));
            colParam.Add(CreateParam("@NgayVaoDangChinhThuc",SqlDbType.DateTime,pNS_GiaoVien_ThongTinInfo.NgayVaoDangChinhThuc));
            colParam.Add(CreateParam("@IDDM_DanhHieuDuocPhongTang",SqlDbType.Int,pNS_GiaoVien_ThongTinInfo.IDDM_DanhHieuDuocPhongTang));
            colParam.Add(CreateParam("@SoTruongCongTac",SqlDbType.NVarChar,pNS_GiaoVien_ThongTinInfo.SoTruongCongTac));
            colParam.Add(CreateParam("@TinhTrangSucKhoe",SqlDbType.NVarChar,pNS_GiaoVien_ThongTinInfo.TinhTrangSucKhoe));
            colParam.Add(CreateParam("@ChieuCao",SqlDbType.Float,pNS_GiaoVien_ThongTinInfo.ChieuCao));
            colParam.Add(CreateParam("@CanNang",SqlDbType.Float,pNS_GiaoVien_ThongTinInfo.CanNang));
            colParam.Add(CreateParam("@NhomMau",SqlDbType.NVarChar,pNS_GiaoVien_ThongTinInfo.NhomMau));
            colParam.Add(CreateParam("@SoSoBaoHiemXaHoi",SqlDbType.NVarChar,pNS_GiaoVien_ThongTinInfo.SoSoBaoHiemXaHoi));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_GiaoVien_ThongTin_Add", colParam);
        }
        
        public void Update(NS_GiaoVien_ThongTinInfo pNS_GiaoVien_ThongTinInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_GiaoVien_ThongTinInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@NgheNghiepTuyenDung",SqlDbType.NVarChar,pNS_GiaoVien_ThongTinInfo.NgheNghiepTuyenDung));
            colParam.Add(CreateParam("@NgayTuyenDung",SqlDbType.DateTime,pNS_GiaoVien_ThongTinInfo.NgayTuyenDung));
            colParam.Add(CreateParam("@IsGiaoVienChinhTri", SqlDbType.Bit, pNS_GiaoVien_ThongTinInfo.IsGiaoVienChinhTri));
            colParam.Add(CreateParam("@IDDM_ChucDanh",SqlDbType.Int,pNS_GiaoVien_ThongTinInfo.IDDM_ChucDanh));
            colParam.Add(CreateParam("@IDDM_HocHam",SqlDbType.Int,pNS_GiaoVien_ThongTinInfo.IDDM_HocHam));
            colParam.Add(CreateParam("@IDDM_HocVi", SqlDbType.Int, pNS_GiaoVien_ThongTinInfo.IDDM_HocVi));
            colParam.Add(CreateParam("@TrinhDoPhoThong",SqlDbType.NVarChar,pNS_GiaoVien_ThongTinInfo.TrinhDoPhoThong));
            colParam.Add(CreateParam("@IDTrinhDoTinHoc", SqlDbType.NVarChar, pNS_GiaoVien_ThongTinInfo.IDTrinhDoTinHoc));
            colParam.Add(CreateParam("@TrinhDoTinHoc",SqlDbType.NVarChar,pNS_GiaoVien_ThongTinInfo.TrinhDoTinHoc));
            colParam.Add(CreateParam("@IDDM_TrinhDoChuyenMon",SqlDbType.Int,pNS_GiaoVien_ThongTinInfo.IDDM_TrinhDoChuyenMon));
            colParam.Add(CreateParam("@IDDM_TrinhDoLyLuan",SqlDbType.Int,pNS_GiaoVien_ThongTinInfo.IDDM_TrinhDoLyLuan));
            colParam.Add(CreateParam("@IDDM_QuanLyHanhChinhNhaNuoc",SqlDbType.Int,pNS_GiaoVien_ThongTinInfo.IDDM_QuanLyHanhChinhNhaNuoc));
            colParam.Add(CreateParam("@NgayVaoDang",SqlDbType.DateTime,pNS_GiaoVien_ThongTinInfo.NgayVaoDang));
            colParam.Add(CreateParam("@NgayVaoDangChinhThuc",SqlDbType.DateTime,pNS_GiaoVien_ThongTinInfo.NgayVaoDangChinhThuc));
            colParam.Add(CreateParam("@IDDM_DanhHieuDuocPhongTang",SqlDbType.Int,pNS_GiaoVien_ThongTinInfo.IDDM_DanhHieuDuocPhongTang));
            colParam.Add(CreateParam("@SoTruongCongTac",SqlDbType.NVarChar,pNS_GiaoVien_ThongTinInfo.SoTruongCongTac));
            colParam.Add(CreateParam("@TinhTrangSucKhoe",SqlDbType.NVarChar,pNS_GiaoVien_ThongTinInfo.TinhTrangSucKhoe));
            colParam.Add(CreateParam("@ChieuCao",SqlDbType.Float,pNS_GiaoVien_ThongTinInfo.ChieuCao));
            colParam.Add(CreateParam("@CanNang",SqlDbType.Float,pNS_GiaoVien_ThongTinInfo.CanNang));
            colParam.Add(CreateParam("@NhomMau",SqlDbType.NVarChar,pNS_GiaoVien_ThongTinInfo.NhomMau));
            colParam.Add(CreateParam("@SoSoBaoHiemXaHoi",SqlDbType.NVarChar,pNS_GiaoVien_ThongTinInfo.SoSoBaoHiemXaHoi));
            colParam.Add(CreateParam("@NS_GiaoVien_ThongTinID",SqlDbType.Int,pNS_GiaoVien_ThongTinInfo.NS_GiaoVien_ThongTinID));

            RunProcedure("sp_NS_GiaoVien_ThongTin_Update", colParam);
        }
        
        public void Delete(NS_GiaoVien_ThongTinInfo pNS_GiaoVien_ThongTinInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_GiaoVien_ThongTinID",SqlDbType.Int,pNS_GiaoVien_ThongTinInfo.NS_GiaoVien_ThongTinID));

            RunProcedure("sp_NS_GiaoVien_ThongTin_Delete", colParam);
        }
    }
}
