using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_DiemRenLuyenToanKhoa : cDBase
    {
        public DataTable Get(SV_DiemRenLuyenToanKhoaInfo pSV_DiemRenLuyenToanKhoaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_DiemRenLuyenToanKhoaID",SqlDbType.Int,pSV_DiemRenLuyenToanKhoaInfo.SV_DiemRenLuyenToanKhoaID));

            return RunProcedureGet("sp_SV_DiemRenLuyenToanKhoa_Get", colParam);            
        }

        public int Add(SV_DiemRenLuyenToanKhoaInfo pSV_DiemRenLuyenToanKhoaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_DiemRenLuyenToanKhoaInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@SoDiem",SqlDbType.Float,pSV_DiemRenLuyenToanKhoaInfo.SoDiem));
            colParam.Add(CreateParam("@IDDM_XepLoaiRenLuyen",SqlDbType.Int,pSV_DiemRenLuyenToanKhoaInfo.IDDM_XepLoaiRenLuyen));
            colParam.Add(CreateParam("@NhanXet",SqlDbType.NVarChar,pSV_DiemRenLuyenToanKhoaInfo.NhanXet));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_SV_DiemRenLuyenToanKhoa_Add", colParam);
        }
        
        public void Update(SV_DiemRenLuyenToanKhoaInfo pSV_DiemRenLuyenToanKhoaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_DiemRenLuyenToanKhoaInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@SoDiem",SqlDbType.Float,pSV_DiemRenLuyenToanKhoaInfo.SoDiem));
            colParam.Add(CreateParam("@IDDM_XepLoaiRenLuyen",SqlDbType.Int,pSV_DiemRenLuyenToanKhoaInfo.IDDM_XepLoaiRenLuyen));
            colParam.Add(CreateParam("@NhanXet",SqlDbType.NVarChar,pSV_DiemRenLuyenToanKhoaInfo.NhanXet));
            colParam.Add(CreateParam("@SV_DiemRenLuyenToanKhoaID",SqlDbType.Int,pSV_DiemRenLuyenToanKhoaInfo.SV_DiemRenLuyenToanKhoaID));

            RunProcedure("sp_SV_DiemRenLuyenToanKhoa_Update", colParam);
        }
        
        public void Delete(SV_DiemRenLuyenToanKhoaInfo pSV_DiemRenLuyenToanKhoaInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_DiemRenLuyenToanKhoaID",SqlDbType.Int,pSV_DiemRenLuyenToanKhoaInfo.SV_DiemRenLuyenToanKhoaID));

            RunProcedure("sp_SV_DiemRenLuyenToanKhoa_Delete", colParam);
        }
    }
}
