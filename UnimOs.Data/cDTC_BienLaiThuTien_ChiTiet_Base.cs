using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_BienLaiThuTien_ChiTiet : cDBase
    {
        public DataTable Get(TC_BienLaiThuTien_ChiTietInfo pTC_BienLaiThuTien_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_BienLaiThuTien_ChiTietID",SqlDbType.Int,pTC_BienLaiThuTien_ChiTietInfo.TC_BienLaiThuTien_ChiTietID));

            return RunProcedureGet("sp_TC_BienLaiThuTien_ChiTiet_Get", colParam);            
        }

        public int Add(TC_BienLaiThuTien_ChiTietInfo pTC_BienLaiThuTien_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTC_BienLaiThuTien",SqlDbType.Int,pTC_BienLaiThuTien_ChiTietInfo.IDTC_BienLaiThuTien));
            colParam.Add(CreateParam("@IDTC_LoaiThuChi",SqlDbType.Int,pTC_BienLaiThuTien_ChiTietInfo.IDTC_LoaiThuChi));
            colParam.Add(CreateParam("@IDTC_DinhMucThuSinhVien",SqlDbType.Int,pTC_BienLaiThuTien_ChiTietInfo.IDTC_DinhMucThuSinhVien));
            colParam.Add(CreateParam("@LanThu",SqlDbType.Int,pTC_BienLaiThuTien_ChiTietInfo.LanThu));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NVarChar,pTC_BienLaiThuTien_ChiTietInfo.NoiDung));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pTC_BienLaiThuTien_ChiTietInfo.SoTien));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_TC_BienLaiThuTien_ChiTiet_Add", colParam);
        }
        
        public void Update(TC_BienLaiThuTien_ChiTietInfo pTC_BienLaiThuTien_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTC_BienLaiThuTien",SqlDbType.Int,pTC_BienLaiThuTien_ChiTietInfo.IDTC_BienLaiThuTien));
            colParam.Add(CreateParam("@IDTC_LoaiThuChi",SqlDbType.Int,pTC_BienLaiThuTien_ChiTietInfo.IDTC_LoaiThuChi));
            colParam.Add(CreateParam("@IDTC_DinhMucThuSinhVien",SqlDbType.Int,pTC_BienLaiThuTien_ChiTietInfo.IDTC_DinhMucThuSinhVien));
            colParam.Add(CreateParam("@LanThu",SqlDbType.Int,pTC_BienLaiThuTien_ChiTietInfo.LanThu));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NVarChar,pTC_BienLaiThuTien_ChiTietInfo.NoiDung));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pTC_BienLaiThuTien_ChiTietInfo.SoTien));
            colParam.Add(CreateParam("@TC_BienLaiThuTien_ChiTietID",SqlDbType.Int,pTC_BienLaiThuTien_ChiTietInfo.TC_BienLaiThuTien_ChiTietID));

            RunProcedure("sp_TC_BienLaiThuTien_ChiTiet_Update", colParam);
        }
        
        public void Delete(TC_BienLaiThuTien_ChiTietInfo pTC_BienLaiThuTien_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_BienLaiThuTien_ChiTietID",SqlDbType.Int,pTC_BienLaiThuTien_ChiTietInfo.TC_BienLaiThuTien_ChiTietID));

            RunProcedure("sp_TC_BienLaiThuTien_ChiTiet_Delete", colParam);
        }
    }
}
