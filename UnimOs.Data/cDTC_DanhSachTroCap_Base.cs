using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_DanhSachTroCap : cDBase
    {
        public DataTable Get(TC_DanhSachTroCapInfo pTC_DanhSachTroCapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_DanhSachTroCapID",SqlDbType.Int,pTC_DanhSachTroCapInfo.TC_DanhSachTroCapID));

            return RunProcedureGet("sp_TC_DanhSachTroCap_Get", colParam);            
        }

        public int Add(TC_DanhSachTroCapInfo pTC_DanhSachTroCapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pTC_DanhSachTroCapInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pTC_DanhSachTroCapInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pTC_DanhSachTroCapInfo.HocKy));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pTC_DanhSachTroCapInfo.SoTien));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pTC_DanhSachTroCapInfo.GhiChu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_TC_DanhSachTroCap_Add", colParam);
        }
        
        public void Update(TC_DanhSachTroCapInfo pTC_DanhSachTroCapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pTC_DanhSachTroCapInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pTC_DanhSachTroCapInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pTC_DanhSachTroCapInfo.HocKy));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pTC_DanhSachTroCapInfo.SoTien));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pTC_DanhSachTroCapInfo.GhiChu));
            colParam.Add(CreateParam("@TC_DanhSachTroCapID",SqlDbType.Int,pTC_DanhSachTroCapInfo.TC_DanhSachTroCapID));

            RunProcedure("sp_TC_DanhSachTroCap_Update", colParam);
        }
        
        public void Delete(TC_DanhSachTroCapInfo pTC_DanhSachTroCapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_DanhSachTroCapID",SqlDbType.Int,pTC_DanhSachTroCapInfo.TC_DanhSachTroCapID));

            RunProcedure("sp_TC_DanhSachTroCap_Delete", colParam);
        }
    }
}
