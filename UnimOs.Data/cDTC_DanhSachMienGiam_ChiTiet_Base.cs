using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_DanhSachMienGiam_ChiTiet : cDBase
    {
        public DataTable Get(TC_DanhSachMienGiam_ChiTietInfo pTC_DanhSachMienGiam_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_DanhSachMienGiam_ChiTietID",SqlDbType.Int,pTC_DanhSachMienGiam_ChiTietInfo.TC_DanhSachMienGiam_ChiTietID));

            return RunProcedureGet("sp_TC_DanhSachMienGiam_ChiTiet_Get", colParam);            
        }

        public int Add(TC_DanhSachMienGiam_ChiTietInfo pTC_DanhSachMienGiam_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTC_DanhSachMienGiam",SqlDbType.Int,pTC_DanhSachMienGiam_ChiTietInfo.IDTC_DanhSachMienGiam));
            colParam.Add(CreateParam("@Thang",SqlDbType.Int,pTC_DanhSachMienGiam_ChiTietInfo.Thang));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pTC_DanhSachMienGiam_ChiTietInfo.SoTien));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_TC_DanhSachMienGiam_ChiTiet_Add", colParam);
        }
        
        public void Update(TC_DanhSachMienGiam_ChiTietInfo pTC_DanhSachMienGiam_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTC_DanhSachMienGiam",SqlDbType.Int,pTC_DanhSachMienGiam_ChiTietInfo.IDTC_DanhSachMienGiam));
            colParam.Add(CreateParam("@Thang",SqlDbType.Int,pTC_DanhSachMienGiam_ChiTietInfo.Thang));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pTC_DanhSachMienGiam_ChiTietInfo.SoTien));
            colParam.Add(CreateParam("@TC_DanhSachMienGiam_ChiTietID",SqlDbType.Int,pTC_DanhSachMienGiam_ChiTietInfo.TC_DanhSachMienGiam_ChiTietID));

            RunProcedure("sp_TC_DanhSachMienGiam_ChiTiet_Update", colParam);
        }
        
        public void Delete(TC_DanhSachMienGiam_ChiTietInfo pTC_DanhSachMienGiam_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_DanhSachMienGiam_ChiTietID",SqlDbType.Int,pTC_DanhSachMienGiam_ChiTietInfo.TC_DanhSachMienGiam_ChiTietID));

            RunProcedure("sp_TC_DanhSachMienGiam_ChiTiet_Delete", colParam);
        }
    }
}
