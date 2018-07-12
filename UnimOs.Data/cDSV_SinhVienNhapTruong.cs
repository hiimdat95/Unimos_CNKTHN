using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_SinhVienNhapTruong : cDBase
    {
        public DataTable GetByNamHoc(int IDDM_NamHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));

            return RunProcedureGet("sp_SV_SinhVienNhapTruong_GetByNamHoc", colParam);
        }

        public void UpdateNhapTruong(SV_SinhVienNhapTruongInfo pSV_SinhVienNhapTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NgayNhapTruong", SqlDbType.DateTime, pSV_SinhVienNhapTruongInfo.NgayNhapTruong));
            colParam.Add(CreateParam("@IDNguoiTiepNhan", SqlDbType.Int, pSV_SinhVienNhapTruongInfo.IDNguoiTiepNhan));
            colParam.Add(CreateParam("@SV_SinhVienNhapTruongID", SqlDbType.Int, pSV_SinhVienNhapTruongInfo.SV_SinhVienNhapTruongID));

            RunProcedure("sp_SV_SinhVienNhapTruong_UpdateNhapTruong", colParam);
        }

        public void UpdateHoSo(SV_SinhVienNhapTruongInfo pSV_SinhVienNhapTruongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HoVaTenTS", SqlDbType.NVarChar, pSV_SinhVienNhapTruongInfo.HoVaTenTS));
            colParam.Add(CreateParam("@TenTS", SqlDbType.NVarChar, pSV_SinhVienNhapTruongInfo.TenTS));
            colParam.Add(CreateParam("@SoBaoDanhTS", SqlDbType.NVarChar, pSV_SinhVienNhapTruongInfo.SoBaoDanhTS));
            colParam.Add(CreateParam("@KhoiThi", SqlDbType.NVarChar, pSV_SinhVienNhapTruongInfo.KhoiThi));
            colParam.Add(CreateParam("@NganhThi", SqlDbType.NVarChar, pSV_SinhVienNhapTruongInfo.NganhThi));
            colParam.Add(CreateParam("@KyHieuTruong", SqlDbType.NVarChar, pSV_SinhVienNhapTruongInfo.KyHieuTruong));
            colParam.Add(CreateParam("@DanToc", SqlDbType.NVarChar, pSV_SinhVienNhapTruongInfo.DanToc));
            colParam.Add(CreateParam("@DoiTuongTuyenSinh", SqlDbType.NChar, pSV_SinhVienNhapTruongInfo.DoiTuongTuyenSinh));
            colParam.Add(CreateParam("@XLHocLuc", SqlDbType.NVarChar, pSV_SinhVienNhapTruongInfo.XLHocLuc));
            colParam.Add(CreateParam("@XLHanhKiem", SqlDbType.NVarChar, pSV_SinhVienNhapTruongInfo.XLHanhKiem));
            colParam.Add(CreateParam("@XLTotNghiep", SqlDbType.NVarChar, pSV_SinhVienNhapTruongInfo.XLTotNghiep));
            colParam.Add(CreateParam("@NamTotNghiep", SqlDbType.NVarChar, pSV_SinhVienNhapTruongInfo.NamTotNghiep));
            colParam.Add(CreateParam("@KhuVucTuyenSinh", SqlDbType.NVarChar, pSV_SinhVienNhapTruongInfo.KhuVucTuyenSinh));
            colParam.Add(CreateParam("@DiemMon1", SqlDbType.Float, pSV_SinhVienNhapTruongInfo.DiemMon1));
            colParam.Add(CreateParam("@DiemMon2", SqlDbType.Float, pSV_SinhVienNhapTruongInfo.DiemMon2));
            colParam.Add(CreateParam("@DiemMon3", SqlDbType.Float, pSV_SinhVienNhapTruongInfo.DiemMon3));
            colParam.Add(CreateParam("@DiemMon4", SqlDbType.Float, pSV_SinhVienNhapTruongInfo.DiemMon4));
            colParam.Add(CreateParam("@DiemThuong", SqlDbType.Float, pSV_SinhVienNhapTruongInfo.DiemThuong));
            colParam.Add(CreateParam("@TongDiemLamTron", SqlDbType.Float, pSV_SinhVienNhapTruongInfo.TongDiemLamTron));
            colParam.Add(CreateParam("@TuyenThang", SqlDbType.Bit, pSV_SinhVienNhapTruongInfo.TuyenThang));
            colParam.Add(CreateParam("@LyDo", SqlDbType.NVarChar, pSV_SinhVienNhapTruongInfo.LyDo));
            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, pSV_SinhVienNhapTruongInfo.IDSV_SinhVien));

            RunProcedure("sp_SV_SinhVienNhapTruong_UpdateHoSo", colParam);
        }
    }
}
