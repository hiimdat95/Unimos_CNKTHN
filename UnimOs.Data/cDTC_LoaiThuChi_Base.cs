using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_LoaiThuChi : cDBase
    {
        public DataTable Get(TC_LoaiThuChiInfo pTC_LoaiThuChiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_LoaiThuChiID",SqlDbType.Int,pTC_LoaiThuChiInfo.TC_LoaiThuChiID));

            return RunProcedureGet("sp_TC_LoaiThuChi_Get", colParam);            
        }

        public int Add(TC_LoaiThuChiInfo pTC_LoaiThuChiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenLoaiThuChi",SqlDbType.NVarChar,pTC_LoaiThuChiInfo.TenLoaiThuChi));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pTC_LoaiThuChiInfo.SoTien));
            colParam.Add(CreateParam("@KhoanThu",SqlDbType.Bit,pTC_LoaiThuChiInfo.KhoanThu));
            colParam.Add(CreateParam("@BatBuoc",SqlDbType.Bit,pTC_LoaiThuChiInfo.BatBuoc));
            colParam.Add(CreateParam("@TheoNienKhoa",SqlDbType.Bit,pTC_LoaiThuChiInfo.TheoNienKhoa));
            colParam.Add(CreateParam("@HocPhi",SqlDbType.Bit,pTC_LoaiThuChiInfo.HocPhi));
            colParam.Add(CreateParam("@NhapHoc",SqlDbType.Bit,pTC_LoaiThuChiInfo.NhapHoc));
            colParam.Add(CreateParam("@ParentID", SqlDbType.Int, pTC_LoaiThuChiInfo.ParentID));
            colParam.Add(CreateParam("@IDNamHoc", SqlDbType.Int, pTC_LoaiThuChiInfo.IDNamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, pTC_LoaiThuChiInfo.HocKy));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_TC_LoaiThuChi_Add", colParam);
        }
        
        public void Update(TC_LoaiThuChiInfo pTC_LoaiThuChiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenLoaiThuChi",SqlDbType.NVarChar,pTC_LoaiThuChiInfo.TenLoaiThuChi));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pTC_LoaiThuChiInfo.SoTien));
            colParam.Add(CreateParam("@KhoanThu",SqlDbType.Bit,pTC_LoaiThuChiInfo.KhoanThu));
            colParam.Add(CreateParam("@BatBuoc",SqlDbType.Bit,pTC_LoaiThuChiInfo.BatBuoc));
            colParam.Add(CreateParam("@TheoNienKhoa",SqlDbType.Bit,pTC_LoaiThuChiInfo.TheoNienKhoa));
            colParam.Add(CreateParam("@HocPhi",SqlDbType.Bit,pTC_LoaiThuChiInfo.HocPhi));
            colParam.Add(CreateParam("@NhapHoc",SqlDbType.Bit,pTC_LoaiThuChiInfo.NhapHoc));
            colParam.Add(CreateParam("@ParentID", SqlDbType.Int, pTC_LoaiThuChiInfo.ParentID));
            colParam.Add(CreateParam("@IDNamHoc", SqlDbType.Int, pTC_LoaiThuChiInfo.IDNamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, pTC_LoaiThuChiInfo.HocKy));
            colParam.Add(CreateParam("@TC_LoaiThuChiID", SqlDbType.Int, pTC_LoaiThuChiInfo.TC_LoaiThuChiID));

            RunProcedure("sp_TC_LoaiThuChi_Update", colParam);
        }
        
        public void Delete(TC_LoaiThuChiInfo pTC_LoaiThuChiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_LoaiThuChiID",SqlDbType.Int,pTC_LoaiThuChiInfo.TC_LoaiThuChiID));

            RunProcedure("sp_TC_LoaiThuChi_Delete", colParam);
        }
    }
}
