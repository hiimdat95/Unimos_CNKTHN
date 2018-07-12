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
        public DataTable Get(TC_DanhSachHocBong_ChiTietInfo pTC_DanhSachHocBong_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_DanhSachHocBong_ChiTietID",SqlDbType.Int,pTC_DanhSachHocBong_ChiTietInfo.TC_DanhSachHocBong_ChiTietID));

            return RunProcedureGet("sp_TC_DanhSachHocBong_ChiTiet_Get", colParam);            
        }

        public int Add(TC_DanhSachHocBong_ChiTietInfo pTC_DanhSachHocBong_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTC_DanhSachHocBong",SqlDbType.Int,pTC_DanhSachHocBong_ChiTietInfo.IDTC_DanhSachHocBong));
            colParam.Add(CreateParam("@Thang",SqlDbType.Int,pTC_DanhSachHocBong_ChiTietInfo.Thang));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pTC_DanhSachHocBong_ChiTietInfo.SoTien));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_TC_DanhSachHocBong_ChiTiet_Add", colParam);
        }
        
        public void Update(TC_DanhSachHocBong_ChiTietInfo pTC_DanhSachHocBong_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTC_DanhSachHocBong",SqlDbType.Int,pTC_DanhSachHocBong_ChiTietInfo.IDTC_DanhSachHocBong));
            colParam.Add(CreateParam("@Thang",SqlDbType.Int,pTC_DanhSachHocBong_ChiTietInfo.Thang));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pTC_DanhSachHocBong_ChiTietInfo.SoTien));
            colParam.Add(CreateParam("@TC_DanhSachHocBong_ChiTietID",SqlDbType.Int,pTC_DanhSachHocBong_ChiTietInfo.TC_DanhSachHocBong_ChiTietID));

            RunProcedure("sp_TC_DanhSachHocBong_ChiTiet_Update", colParam);
        }
        
        public void Delete(TC_DanhSachHocBong_ChiTietInfo pTC_DanhSachHocBong_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_DanhSachHocBong_ChiTietID",SqlDbType.Int,pTC_DanhSachHocBong_ChiTietInfo.TC_DanhSachHocBong_ChiTietID));

            RunProcedure("sp_TC_DanhSachHocBong_ChiTiet_Delete", colParam);
        }
    }
}
