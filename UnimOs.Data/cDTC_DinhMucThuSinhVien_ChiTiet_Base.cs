using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_DinhMucThuSinhVien_ChiTiet : cDBase
    {
        public DataTable Get(TC_DinhMucThuSinhVien_ChiTietInfo pTC_DinhMucThuSinhVien_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_DinhMucThuSinhVien_ChiTietID",SqlDbType.Int,pTC_DinhMucThuSinhVien_ChiTietInfo.TC_DinhMucThuSinhVien_ChiTietID));

            return RunProcedureGet("sp_TC_DinhMucThuSinhVien_ChiTiet_Get", colParam);            
        }

        public int Add(TC_DinhMucThuSinhVien_ChiTietInfo pTC_DinhMucThuSinhVien_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTC_DinhMucThuSinhVien",SqlDbType.Int,pTC_DinhMucThuSinhVien_ChiTietInfo.IDTC_DinhMucThuSinhVien));
            colParam.Add(CreateParam("@Thang",SqlDbType.Int,pTC_DinhMucThuSinhVien_ChiTietInfo.Thang));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pTC_DinhMucThuSinhVien_ChiTietInfo.SoTien));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_TC_DinhMucThuSinhVien_ChiTiet_Add", colParam);
        }
        
        public void Update(TC_DinhMucThuSinhVien_ChiTietInfo pTC_DinhMucThuSinhVien_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTC_DinhMucThuSinhVien",SqlDbType.Int,pTC_DinhMucThuSinhVien_ChiTietInfo.IDTC_DinhMucThuSinhVien));
            colParam.Add(CreateParam("@Thang",SqlDbType.Int,pTC_DinhMucThuSinhVien_ChiTietInfo.Thang));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pTC_DinhMucThuSinhVien_ChiTietInfo.SoTien));
            colParam.Add(CreateParam("@TC_DinhMucThuSinhVien_ChiTietID",SqlDbType.Int,pTC_DinhMucThuSinhVien_ChiTietInfo.TC_DinhMucThuSinhVien_ChiTietID));

            RunProcedure("sp_TC_DinhMucThuSinhVien_ChiTiet_Update", colParam);
        }
        
        public void Delete(TC_DinhMucThuSinhVien_ChiTietInfo pTC_DinhMucThuSinhVien_ChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_DinhMucThuSinhVien_ChiTietID",SqlDbType.Int,pTC_DinhMucThuSinhVien_ChiTietInfo.TC_DinhMucThuSinhVien_ChiTietID));

            RunProcedure("sp_TC_DinhMucThuSinhVien_ChiTiet_Delete", colParam);
        }
    }
}
