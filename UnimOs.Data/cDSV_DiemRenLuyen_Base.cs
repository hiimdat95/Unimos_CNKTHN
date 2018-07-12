using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_DiemRenLuyen : cDBase
    {
        public DataTable Get(SV_DiemRenLuyenInfo pSV_DiemRenLuyenInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_DiemRenLuyenID",SqlDbType.Int,pSV_DiemRenLuyenInfo.SV_DiemRenLuyenID));

            return RunProcedureGet("sp_SV_DiemRenLuyen_Get", colParam);            
        }

        public int Add(SV_DiemRenLuyenInfo pSV_DiemRenLuyenInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_DiemRenLuyenInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pSV_DiemRenLuyenInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@SoDiemKy1",SqlDbType.Float,pSV_DiemRenLuyenInfo.SoDiemKy1));
            colParam.Add(CreateParam("@IDDM_XepLoaiRenLuyenKy1",SqlDbType.Int,pSV_DiemRenLuyenInfo.IDDM_XepLoaiRenLuyenKy1));
            colParam.Add(CreateParam("@NhanXetKy1",SqlDbType.NVarChar,pSV_DiemRenLuyenInfo.NhanXetKy1));
            colParam.Add(CreateParam("@SoDiemKy2",SqlDbType.Float,pSV_DiemRenLuyenInfo.SoDiemKy2));
            colParam.Add(CreateParam("@IDDM_XepLoaiRenLuyenKy2",SqlDbType.Int,pSV_DiemRenLuyenInfo.IDDM_XepLoaiRenLuyenKy2));
            colParam.Add(CreateParam("@NhanXetKy2",SqlDbType.NVarChar,pSV_DiemRenLuyenInfo.NhanXetKy2));
            colParam.Add(CreateParam("@SoDiemCaNam",SqlDbType.Float,pSV_DiemRenLuyenInfo.SoDiemCaNam));
            colParam.Add(CreateParam("@IDDM_XepLoaiRenLuyenCaNam",SqlDbType.Int,pSV_DiemRenLuyenInfo.IDDM_XepLoaiRenLuyenCaNam));
            colParam.Add(CreateParam("@NhanXetCaNam",SqlDbType.NVarChar,pSV_DiemRenLuyenInfo.NhanXetCaNam));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_SV_DiemRenLuyen_Add", colParam);
        }
        
        public void Update(SV_DiemRenLuyenInfo pSV_DiemRenLuyenInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_DiemRenLuyenInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pSV_DiemRenLuyenInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@SoDiemKy1",SqlDbType.Float,pSV_DiemRenLuyenInfo.SoDiemKy1));
            colParam.Add(CreateParam("@IDDM_XepLoaiRenLuyenKy1",SqlDbType.Int,pSV_DiemRenLuyenInfo.IDDM_XepLoaiRenLuyenKy1));
            colParam.Add(CreateParam("@NhanXetKy1",SqlDbType.NVarChar,pSV_DiemRenLuyenInfo.NhanXetKy1));
            colParam.Add(CreateParam("@SoDiemKy2",SqlDbType.Float,pSV_DiemRenLuyenInfo.SoDiemKy2));
            colParam.Add(CreateParam("@IDDM_XepLoaiRenLuyenKy2",SqlDbType.Int,pSV_DiemRenLuyenInfo.IDDM_XepLoaiRenLuyenKy2));
            colParam.Add(CreateParam("@NhanXetKy2",SqlDbType.NVarChar,pSV_DiemRenLuyenInfo.NhanXetKy2));
            colParam.Add(CreateParam("@SoDiemCaNam",SqlDbType.Float,pSV_DiemRenLuyenInfo.SoDiemCaNam));
            colParam.Add(CreateParam("@IDDM_XepLoaiRenLuyenCaNam",SqlDbType.Int,pSV_DiemRenLuyenInfo.IDDM_XepLoaiRenLuyenCaNam));
            colParam.Add(CreateParam("@NhanXetCaNam",SqlDbType.NVarChar,pSV_DiemRenLuyenInfo.NhanXetCaNam));
            colParam.Add(CreateParam("@SV_DiemRenLuyenID",SqlDbType.Int,pSV_DiemRenLuyenInfo.SV_DiemRenLuyenID));

            RunProcedure("sp_SV_DiemRenLuyen_Update", colParam);
        }
        
        public void Delete(SV_DiemRenLuyenInfo pSV_DiemRenLuyenInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_DiemRenLuyenID",SqlDbType.Int,pSV_DiemRenLuyenInfo.SV_DiemRenLuyenID));

            RunProcedure("sp_SV_DiemRenLuyen_Delete", colParam);
        }
    }
}
