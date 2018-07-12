using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_DanhSachMienGiam : cDBase
    {
        public DataTable Get(TC_DanhSachMienGiamInfo pTC_DanhSachMienGiamInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_DanhSachMienGiamID",SqlDbType.Int,pTC_DanhSachMienGiamInfo.TC_DanhSachMienGiamID));

            return RunProcedureGet("sp_TC_DanhSachMienGiam_Get", colParam);            
        }

        public int Add(TC_DanhSachMienGiamInfo pTC_DanhSachMienGiamInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pTC_DanhSachMienGiamInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pTC_DanhSachMienGiamInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pTC_DanhSachMienGiamInfo.HocKy));
            colParam.Add(CreateParam("@IDTC_LoaiThuChi",SqlDbType.Int,pTC_DanhSachMienGiamInfo.IDTC_LoaiThuChi));
            colParam.Add(CreateParam("@SoTienMienGiam",SqlDbType.Money,pTC_DanhSachMienGiamInfo.SoTienMienGiam));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pTC_DanhSachMienGiamInfo.GhiChu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_TC_DanhSachMienGiam_Add", colParam);
        }
        
        public void Update(TC_DanhSachMienGiamInfo pTC_DanhSachMienGiamInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pTC_DanhSachMienGiamInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pTC_DanhSachMienGiamInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pTC_DanhSachMienGiamInfo.HocKy));
            colParam.Add(CreateParam("@IDTC_LoaiThuChi",SqlDbType.Int,pTC_DanhSachMienGiamInfo.IDTC_LoaiThuChi));
            colParam.Add(CreateParam("@SoTienMienGiam",SqlDbType.Money,pTC_DanhSachMienGiamInfo.SoTienMienGiam));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pTC_DanhSachMienGiamInfo.GhiChu));
            colParam.Add(CreateParam("@TC_DanhSachMienGiamID",SqlDbType.Int,pTC_DanhSachMienGiamInfo.TC_DanhSachMienGiamID));

            RunProcedure("sp_TC_DanhSachMienGiam_Update", colParam);
        }
        
        public void Delete(TC_DanhSachMienGiamInfo pTC_DanhSachMienGiamInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_DanhSachMienGiamID",SqlDbType.Int,pTC_DanhSachMienGiamInfo.TC_DanhSachMienGiamID));

            RunProcedure("sp_TC_DanhSachMienGiam_Delete", colParam);
        }
    }
}
