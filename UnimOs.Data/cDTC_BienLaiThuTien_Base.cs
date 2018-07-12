using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_BienLaiThuTien : cDBase
    {
        public DataTable Get(TC_BienLaiThuTienInfo pTC_BienLaiThuTienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_BienLaiThuTienID",SqlDbType.Int,pTC_BienLaiThuTienInfo.TC_BienLaiThuTienID));

            return RunProcedureGet("sp_TC_BienLaiThuTien_Get", colParam);            
        }

        public int Add(TC_BienLaiThuTienInfo pTC_BienLaiThuTienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pTC_BienLaiThuTienInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pTC_BienLaiThuTienInfo.IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pTC_BienLaiThuTienInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pTC_BienLaiThuTienInfo.HocKy));
            colParam.Add(CreateParam("@PhieuThu",SqlDbType.Bit,pTC_BienLaiThuTienInfo.PhieuThu));
            colParam.Add(CreateParam("@SoPhieu",SqlDbType.NVarChar,pTC_BienLaiThuTienInfo.SoPhieu));
            colParam.Add(CreateParam("@NgayThu",SqlDbType.DateTime,pTC_BienLaiThuTienInfo.NgayThu));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NVarChar,pTC_BienLaiThuTienInfo.NoiDung));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pTC_BienLaiThuTienInfo.SoTien));
            colParam.Add(CreateParam("@SoTienBangChu",SqlDbType.NVarChar,pTC_BienLaiThuTienInfo.SoTienBangChu));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pTC_BienLaiThuTienInfo.GhiChu));
            colParam.Add(CreateParam("@PhieuHuy",SqlDbType.Bit,pTC_BienLaiThuTienInfo.PhieuHuy));
            colParam.Add(CreateParam("@NgayHuy",SqlDbType.DateTime,pTC_BienLaiThuTienInfo.NgayHuy));
            colParam.Add(CreateParam("@IDHT_NguoiHuy",SqlDbType.Int,pTC_BienLaiThuTienInfo.IDHT_NguoiHuy));
            colParam.Add(CreateParam("@IDHT_NguoiThu",SqlDbType.Int,pTC_BienLaiThuTienInfo.IDHT_NguoiThu));
            colParam.Add(CreateParam("@IDSV_SinhVienNhapTruong", SqlDbType.Int, pTC_BienLaiThuTienInfo.IDSV_SinhVienNhapTruong));
            colParam.Add(CreateParam("@Printed",SqlDbType.Bit,pTC_BienLaiThuTienInfo.Printed));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_TC_BienLaiThuTien_Add", colParam);
        }
        
        public void Update(TC_BienLaiThuTienInfo pTC_BienLaiThuTienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pTC_BienLaiThuTienInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_Lop", SqlDbType.Int, pTC_BienLaiThuTienInfo.IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pTC_BienLaiThuTienInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pTC_BienLaiThuTienInfo.HocKy));
            colParam.Add(CreateParam("@PhieuThu",SqlDbType.Bit,pTC_BienLaiThuTienInfo.PhieuThu));
            colParam.Add(CreateParam("@SoPhieu",SqlDbType.NVarChar,pTC_BienLaiThuTienInfo.SoPhieu));
            colParam.Add(CreateParam("@NgayThu",SqlDbType.DateTime,pTC_BienLaiThuTienInfo.NgayThu));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NVarChar,pTC_BienLaiThuTienInfo.NoiDung));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pTC_BienLaiThuTienInfo.SoTien));
            colParam.Add(CreateParam("@SoTienBangChu",SqlDbType.NVarChar,pTC_BienLaiThuTienInfo.SoTienBangChu));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pTC_BienLaiThuTienInfo.GhiChu));
            colParam.Add(CreateParam("@PhieuHuy",SqlDbType.Bit,pTC_BienLaiThuTienInfo.PhieuHuy));
            colParam.Add(CreateParam("@NgayHuy",SqlDbType.DateTime,pTC_BienLaiThuTienInfo.NgayHuy));
            colParam.Add(CreateParam("@IDHT_NguoiHuy",SqlDbType.Int,pTC_BienLaiThuTienInfo.IDHT_NguoiHuy));
            colParam.Add(CreateParam("@IDHT_NguoiThu",SqlDbType.Int,pTC_BienLaiThuTienInfo.IDHT_NguoiThu));
            colParam.Add(CreateParam("@Printed",SqlDbType.Bit,pTC_BienLaiThuTienInfo.Printed));
            colParam.Add(CreateParam("@IDSV_SinhVienNhapTruong", SqlDbType.Int, pTC_BienLaiThuTienInfo.IDSV_SinhVienNhapTruong));
            colParam.Add(CreateParam("@TC_BienLaiThuTienID",SqlDbType.Int,pTC_BienLaiThuTienInfo.TC_BienLaiThuTienID));

            RunProcedure("sp_TC_BienLaiThuTien_Update", colParam);
        }
        
        public void Delete(TC_BienLaiThuTienInfo pTC_BienLaiThuTienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_BienLaiThuTienID",SqlDbType.Int,pTC_BienLaiThuTienInfo.TC_BienLaiThuTienID));

            RunProcedure("sp_TC_BienLaiThuTien_Delete", colParam);
        }
    }
}
