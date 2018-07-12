using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_DinhMucThuSinhVien : cDBase
    {
        public DataTable Get(TC_DinhMucThuSinhVienInfo pTC_DinhMucThuSinhVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_DinhMucThuSinhVienID",SqlDbType.Int,pTC_DinhMucThuSinhVienInfo.TC_DinhMucThuSinhVienID));

            return RunProcedureGet("sp_TC_DinhMucThuSinhVien_Get", colParam);            
        }

        public int Add(TC_DinhMucThuSinhVienInfo pTC_DinhMucThuSinhVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pTC_DinhMucThuSinhVienInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pTC_DinhMucThuSinhVienInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pTC_DinhMucThuSinhVienInfo.HocKy));
            colParam.Add(CreateParam("@IDTC_LoaiThuChi",SqlDbType.Int,pTC_DinhMucThuSinhVienInfo.IDTC_LoaiThuChi));
            colParam.Add(CreateParam("@SoTienPhaiNop",SqlDbType.Money,pTC_DinhMucThuSinhVienInfo.SoTienPhaiNop));
            colParam.Add(CreateParam("@SoTienGiam",SqlDbType.Money,pTC_DinhMucThuSinhVienInfo.SoTienGiam));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pTC_DinhMucThuSinhVienInfo.GhiChu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_TC_DinhMucThuSinhVien_Add", colParam);
        }
        
        public void Update(TC_DinhMucThuSinhVienInfo pTC_DinhMucThuSinhVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pTC_DinhMucThuSinhVienInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pTC_DinhMucThuSinhVienInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pTC_DinhMucThuSinhVienInfo.HocKy));
            colParam.Add(CreateParam("@IDTC_LoaiThuChi",SqlDbType.Int,pTC_DinhMucThuSinhVienInfo.IDTC_LoaiThuChi));
            colParam.Add(CreateParam("@SoTienPhaiNop",SqlDbType.Money,pTC_DinhMucThuSinhVienInfo.SoTienPhaiNop));
            colParam.Add(CreateParam("@SoTienGiam",SqlDbType.Money,pTC_DinhMucThuSinhVienInfo.SoTienGiam));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pTC_DinhMucThuSinhVienInfo.GhiChu));
            colParam.Add(CreateParam("@TC_DinhMucThuSinhVienID",SqlDbType.Int,pTC_DinhMucThuSinhVienInfo.TC_DinhMucThuSinhVienID));

            RunProcedure("sp_TC_DinhMucThuSinhVien_Update", colParam);
        }
        
        public void Delete(TC_DinhMucThuSinhVienInfo pTC_DinhMucThuSinhVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_DinhMucThuSinhVienID",SqlDbType.Int,pTC_DinhMucThuSinhVienInfo.TC_DinhMucThuSinhVienID));

            RunProcedure("sp_TC_DinhMucThuSinhVien_Delete", colParam);
        }
    }
}
