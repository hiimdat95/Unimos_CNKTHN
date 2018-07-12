using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_DanhSachHocBong_ChiTiet : cDBase
    {
        public void UpdateThieuCong(TC_DanhSachHocBong_ChiTietInfo pTC_DanhSachHocBong_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SoNgayThieuCong", SqlDbType.Int, pTC_DanhSachHocBong_ChiTietInfo.SoNgayThieuCong));
            colParam.Add(CreateParam("@SoTienThieuCong", SqlDbType.Money, pTC_DanhSachHocBong_ChiTietInfo.SoTienThieuCong));
            colParam.Add(CreateParam("@GhiChu", SqlDbType.NVarChar, pTC_DanhSachHocBong_ChiTietInfo.GhiChu));
            colParam.Add(CreateParam("@TC_DanhSachHocBong_ChiTietID", SqlDbType.Int, pTC_DanhSachHocBong_ChiTietInfo.TC_DanhSachHocBong_ChiTietID));

            RunProcedure("sp_TC_DanhSachHocBong_ChiTiet_UpdateNgayCong", colParam);
        }
        
        public void DeleteBy_HocBong(int IDTC_DanhSachHocBong)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTC_DanhSachHocBong", SqlDbType.Int, IDTC_DanhSachHocBong));

            RunProcedure("sp_TC_DinhMucThuSinhVien_ChiTiet_DeleteBy_HocBong", colParam);
        }
    }
}
