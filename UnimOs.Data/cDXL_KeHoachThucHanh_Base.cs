using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_KeHoachThucHanh : cDBase
    {
        public DataTable Get(XL_KeHoachThucHanhInfo pXL_KeHoachThucHanhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_KeHoachThucHanhID",SqlDbType.Int,pXL_KeHoachThucHanhInfo.XL_KeHoachThucHanhID));

            return RunProcedureGet("sp_XL_KeHoachThucHanh_Get", colParam);            
        }

        public int Add(XL_KeHoachThucHanhInfo pXL_KeHoachThucHanhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pXL_KeHoachThucHanhInfo.IDDM_Lop));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy",SqlDbType.Int,pXL_KeHoachThucHanhInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pXL_KeHoachThucHanhInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_PhongHoc",SqlDbType.Int,pXL_KeHoachThucHanhInfo.IDDM_PhongHoc));
            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pXL_KeHoachThucHanhInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoBuoi",SqlDbType.Int,pXL_KeHoachThucHanhInfo.SoBuoi));
            colParam.Add(CreateParam("@SoTiet",SqlDbType.Int,pXL_KeHoachThucHanhInfo.SoTiet));
            colParam.Add(CreateParam("@SoTo",SqlDbType.Int,pXL_KeHoachThucHanhInfo.SoTo));
            colParam.Add(CreateParam("@IDXL_KeHoachThucHanhKyHieu",SqlDbType.Int,pXL_KeHoachThucHanhInfo.IDXL_KeHoachThucHanhKyHieu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_KeHoachThucHanh_Add", colParam);
        }
        
        public void Update(XL_KeHoachThucHanhInfo pXL_KeHoachThucHanhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_PhongHoc",SqlDbType.Int,pXL_KeHoachThucHanhInfo.IDDM_PhongHoc));
            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pXL_KeHoachThucHanhInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoBuoi",SqlDbType.Int,pXL_KeHoachThucHanhInfo.SoBuoi));
            colParam.Add(CreateParam("@SoTiet",SqlDbType.Int,pXL_KeHoachThucHanhInfo.SoTiet));
            colParam.Add(CreateParam("@SoTo",SqlDbType.Int,pXL_KeHoachThucHanhInfo.SoTo));
            colParam.Add(CreateParam("@IDXL_KeHoachThucHanhKyHieu",SqlDbType.Int,pXL_KeHoachThucHanhInfo.IDXL_KeHoachThucHanhKyHieu));
            colParam.Add(CreateParam("@XL_KeHoachThucHanhID",SqlDbType.Int,pXL_KeHoachThucHanhInfo.XL_KeHoachThucHanhID));

            RunProcedure("sp_XL_KeHoachThucHanh_Update", colParam);
        }
        
        public void Delete(XL_KeHoachThucHanhInfo pXL_KeHoachThucHanhInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_KeHoachThucHanhID",SqlDbType.Int,pXL_KeHoachThucHanhInfo.XL_KeHoachThucHanhID));

            RunProcedure("sp_XL_KeHoachThucHanh_Delete", colParam);
        }
    }
}
