using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_KeHoachThucHanhChiTiet : cDBase
    {
        public DataTable Get(XL_KeHoachThucHanhChiTietInfo pXL_KeHoachThucHanhChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_KeHoachThucHanhChiTietID",SqlDbType.BigInt,pXL_KeHoachThucHanhChiTietInfo.XL_KeHoachThucHanhChiTietID));

            return RunProcedureGet("sp_XL_KeHoachThucHanhChiTiet_Get", colParam);            
        }

        public int Add(XL_KeHoachThucHanhChiTietInfo pXL_KeHoachThucHanhChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_KeHoachThucHanh",SqlDbType.Int,pXL_KeHoachThucHanhChiTietInfo.IDXL_KeHoachThucHanh));
            colParam.Add(CreateParam("@IDXL_Tuan",SqlDbType.BigInt,pXL_KeHoachThucHanhChiTietInfo.IDXL_Tuan));
            colParam.Add(CreateParam("@CaHoc",SqlDbType.Int,pXL_KeHoachThucHanhChiTietInfo.CaHoc));
            colParam.Add(CreateParam("@ToThucHanh",SqlDbType.Int,pXL_KeHoachThucHanhChiTietInfo.ToThucHanh));
            colParam.Add(CreateParam("@NgayThucHanh",SqlDbType.DateTime,pXL_KeHoachThucHanhChiTietInfo.NgayThucHanh));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_KeHoachThucHanhChiTiet_Add", colParam);
        }
        
        public void Update(XL_KeHoachThucHanhChiTietInfo pXL_KeHoachThucHanhChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_KeHoachThucHanh",SqlDbType.Int,pXL_KeHoachThucHanhChiTietInfo.IDXL_KeHoachThucHanh));
            colParam.Add(CreateParam("@IDXL_Tuan",SqlDbType.BigInt,pXL_KeHoachThucHanhChiTietInfo.IDXL_Tuan));
            colParam.Add(CreateParam("@CaHoc",SqlDbType.Int,pXL_KeHoachThucHanhChiTietInfo.CaHoc));
            colParam.Add(CreateParam("@ToThucHanh",SqlDbType.Int,pXL_KeHoachThucHanhChiTietInfo.ToThucHanh));
            colParam.Add(CreateParam("@NgayThucHanh",SqlDbType.DateTime,pXL_KeHoachThucHanhChiTietInfo.NgayThucHanh));
            colParam.Add(CreateParam("@XL_KeHoachThucHanhChiTietID",SqlDbType.BigInt,pXL_KeHoachThucHanhChiTietInfo.XL_KeHoachThucHanhChiTietID));

            RunProcedure("sp_XL_KeHoachThucHanhChiTiet_Update", colParam);
        }
        
        public void Delete(XL_KeHoachThucHanhChiTietInfo pXL_KeHoachThucHanhChiTietInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_KeHoachThucHanhChiTietID",SqlDbType.BigInt,pXL_KeHoachThucHanhChiTietInfo.XL_KeHoachThucHanhChiTietID));

            RunProcedure("sp_XL_KeHoachThucHanhChiTiet_Delete", colParam);
        }
    }
}
