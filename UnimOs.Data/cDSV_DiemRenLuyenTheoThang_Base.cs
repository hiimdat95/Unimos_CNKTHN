using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_DiemRenLuyenTheoThang : cDBase
    {
        public DataTable Get(SV_DiemRenLuyenTheoThangInfo pSV_DiemRenLuyenTheoThangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_DiemRenLuyenTheoThangID",SqlDbType.Int,pSV_DiemRenLuyenTheoThangInfo.SV_DiemRenLuyenTheoThangID));

            return RunProcedureGet("sp_SV_DiemRenLuyenTheoThang_Get", colParam);            
        }

        public int Add(SV_DiemRenLuyenTheoThangInfo pSV_DiemRenLuyenTheoThangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_DiemRenLuyenTheoThangInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDSV_ThangRenLuyenTrongKy",SqlDbType.Int,pSV_DiemRenLuyenTheoThangInfo.IDSV_ThangRenLuyenTrongKy));
            colParam.Add(CreateParam("@SoDiem",SqlDbType.Float,pSV_DiemRenLuyenTheoThangInfo.SoDiem));
            colParam.Add(CreateParam("@IDDM_XepLoaiRenLuyen",SqlDbType.Int,pSV_DiemRenLuyenTheoThangInfo.IDDM_XepLoaiRenLuyen));
            colParam.Add(CreateParam("@NhanXet",SqlDbType.NVarChar,pSV_DiemRenLuyenTheoThangInfo.NhanXet));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_SV_DiemRenLuyenTheoThang_Add", colParam);
        }
        
        public void Update(SV_DiemRenLuyenTheoThangInfo pSV_DiemRenLuyenTheoThangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_DiemRenLuyenTheoThangInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDSV_ThangRenLuyenTrongKy",SqlDbType.Int,pSV_DiemRenLuyenTheoThangInfo.IDSV_ThangRenLuyenTrongKy));
            colParam.Add(CreateParam("@SoDiem",SqlDbType.Float,pSV_DiemRenLuyenTheoThangInfo.SoDiem));
            colParam.Add(CreateParam("@IDDM_XepLoaiRenLuyen",SqlDbType.Int,pSV_DiemRenLuyenTheoThangInfo.IDDM_XepLoaiRenLuyen));
            colParam.Add(CreateParam("@NhanXet",SqlDbType.NVarChar,pSV_DiemRenLuyenTheoThangInfo.NhanXet));
            colParam.Add(CreateParam("@SV_DiemRenLuyenTheoThangID",SqlDbType.Int,pSV_DiemRenLuyenTheoThangInfo.SV_DiemRenLuyenTheoThangID));

            RunProcedure("sp_SV_DiemRenLuyenTheoThang_Update", colParam);
        }
        
        public void Delete(SV_DiemRenLuyenTheoThangInfo pSV_DiemRenLuyenTheoThangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_DiemRenLuyenTheoThangID",SqlDbType.Int,pSV_DiemRenLuyenTheoThangInfo.SV_DiemRenLuyenTheoThangID));

            RunProcedure("sp_SV_DiemRenLuyenTheoThang_Delete", colParam);
        }
    }
}
