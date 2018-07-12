using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_DanhSachTroCap_ChiTiet : cDBase
    {
        public DataTable Get(TC_DanhSachTroCap_ChiTietInfo pTC_DanhSachTroCap_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_DanhSachTroCap_ChiTietID",SqlDbType.Int,pTC_DanhSachTroCap_ChiTietInfo.TC_DanhSachTroCap_ChiTietID));

            return RunProcedureGet("sp_TC_DanhSachTroCap_ChiTiet_Get", colParam);            
        }

        public int Add(TC_DanhSachTroCap_ChiTietInfo pTC_DanhSachTroCap_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTC_DanhSachTroCap",SqlDbType.Int,pTC_DanhSachTroCap_ChiTietInfo.IDTC_DanhSachTroCap));
            colParam.Add(CreateParam("@Thang",SqlDbType.Int,pTC_DanhSachTroCap_ChiTietInfo.Thang));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pTC_DanhSachTroCap_ChiTietInfo.SoTien));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_TC_DanhSachTroCap_ChiTiet_Add", colParam);
        }
        
        public void Update(TC_DanhSachTroCap_ChiTietInfo pTC_DanhSachTroCap_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTC_DanhSachTroCap",SqlDbType.Int,pTC_DanhSachTroCap_ChiTietInfo.IDTC_DanhSachTroCap));
            colParam.Add(CreateParam("@Thang",SqlDbType.Int,pTC_DanhSachTroCap_ChiTietInfo.Thang));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pTC_DanhSachTroCap_ChiTietInfo.SoTien));
            colParam.Add(CreateParam("@TC_DanhSachTroCap_ChiTietID",SqlDbType.Int,pTC_DanhSachTroCap_ChiTietInfo.TC_DanhSachTroCap_ChiTietID));

            RunProcedure("sp_TC_DanhSachTroCap_ChiTiet_Update", colParam);
        }
        
        public void Delete(TC_DanhSachTroCap_ChiTietInfo pTC_DanhSachTroCap_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_DanhSachTroCap_ChiTietID",SqlDbType.Int,pTC_DanhSachTroCap_ChiTietInfo.TC_DanhSachTroCap_ChiTietID));

            RunProcedure("sp_TC_DanhSachTroCap_ChiTiet_Delete", colParam);
        }
    }
}
