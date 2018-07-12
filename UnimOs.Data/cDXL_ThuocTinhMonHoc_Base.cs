using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_ThuocTinhMonHoc : cDBase
    {
        public DataTable Get(XL_ThuocTinhMonHocInfo pXL_ThuocTinhMonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_ThuocTinhMonHocID",SqlDbType.Int,pXL_ThuocTinhMonHocInfo.XL_ThuocTinhMonHocID));

            return RunProcedureGet("sp_XL_ThuocTinhMonHoc_Get", colParam);            
        }

        public int Add(XL_ThuocTinhMonHocInfo pXL_ThuocTinhMonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pXL_ThuocTinhMonHocInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@XepCachNgay",SqlDbType.Bit,pXL_ThuocTinhMonHocInfo.XepCachNgay));
            colParam.Add(CreateParam("@TietXepLichSang",SqlDbType.NVarChar,pXL_ThuocTinhMonHocInfo.TietXepLichSang));
            colParam.Add(CreateParam("@TietXepLichChieu",SqlDbType.NVarChar,pXL_ThuocTinhMonHocInfo.TietXepLichChieu));
            colParam.Add(CreateParam("@TietXepLichToi",SqlDbType.NVarChar,pXL_ThuocTinhMonHocInfo.TietXepLichToi));
            colParam.Add(CreateParam("@HocPhongChuyenMon",SqlDbType.Bit,pXL_ThuocTinhMonHocInfo.HocPhongChuyenMon));
            colParam.Add(CreateParam("@HocCachTietTrongBuoi",SqlDbType.Bit,pXL_ThuocTinhMonHocInfo.HocCachTietTrongBuoi));
            colParam.Add(CreateParam("@SoTietToiDaTrongNhomTiet",SqlDbType.Int,pXL_ThuocTinhMonHocInfo.SoTietToiDaTrongNhomTiet));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_ThuocTinhMonHoc_Add", colParam);
        }
        
        public void Update(XL_ThuocTinhMonHocInfo pXL_ThuocTinhMonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pXL_ThuocTinhMonHocInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@XepCachNgay",SqlDbType.Bit,pXL_ThuocTinhMonHocInfo.XepCachNgay));
            colParam.Add(CreateParam("@TietXepLichSang",SqlDbType.NVarChar,pXL_ThuocTinhMonHocInfo.TietXepLichSang));
            colParam.Add(CreateParam("@TietXepLichChieu",SqlDbType.NVarChar,pXL_ThuocTinhMonHocInfo.TietXepLichChieu));
            colParam.Add(CreateParam("@TietXepLichToi",SqlDbType.NVarChar,pXL_ThuocTinhMonHocInfo.TietXepLichToi));
            colParam.Add(CreateParam("@HocPhongChuyenMon",SqlDbType.Bit,pXL_ThuocTinhMonHocInfo.HocPhongChuyenMon));
            colParam.Add(CreateParam("@HocCachTietTrongBuoi",SqlDbType.Bit,pXL_ThuocTinhMonHocInfo.HocCachTietTrongBuoi));
            colParam.Add(CreateParam("@SoTietToiDaTrongNhomTiet",SqlDbType.Int,pXL_ThuocTinhMonHocInfo.SoTietToiDaTrongNhomTiet));
            colParam.Add(CreateParam("@XL_ThuocTinhMonHocID",SqlDbType.Int,pXL_ThuocTinhMonHocInfo.XL_ThuocTinhMonHocID));

            RunProcedure("sp_XL_ThuocTinhMonHoc_Update", colParam);
        }
        
        public void Delete(XL_ThuocTinhMonHocInfo pXL_ThuocTinhMonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_ThuocTinhMonHocID",SqlDbType.Int,pXL_ThuocTinhMonHocInfo.XL_ThuocTinhMonHocID));

            RunProcedure("sp_XL_ThuocTinhMonHoc_Delete", colParam);
        }
    }
}
