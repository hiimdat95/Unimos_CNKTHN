using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_Tuan : cDBase
    {
        public DataTable Get(XL_TuanInfo pXL_TuanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_TuanID",SqlDbType.BigInt,pXL_TuanInfo.XL_TuanID));

            return RunProcedureGet("sp_XL_Tuan_Get", colParam);            
        }

        public int Add(XL_TuanInfo pXL_TuanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pXL_TuanInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@TuanThu",SqlDbType.Int,pXL_TuanInfo.TuanThu));
            colParam.Add(CreateParam("@TuNgay",SqlDbType.DateTime,pXL_TuanInfo.TuNgay));
            colParam.Add(CreateParam("@DenNgay",SqlDbType.DateTime,pXL_TuanInfo.DenNgay));
            colParam.Add(CreateParam("@ChoPhepXemLich",SqlDbType.Bit,pXL_TuanInfo.ChoPhepXemLich));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pXL_TuanInfo.HocKy));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_Tuan_Add", colParam);
        }
        
        public void Update(XL_TuanInfo pXL_TuanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pXL_TuanInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@TuanThu",SqlDbType.Int,pXL_TuanInfo.TuanThu));
            colParam.Add(CreateParam("@TuNgay",SqlDbType.DateTime,pXL_TuanInfo.TuNgay));
            colParam.Add(CreateParam("@DenNgay",SqlDbType.DateTime,pXL_TuanInfo.DenNgay));
            colParam.Add(CreateParam("@ChoPhepXemLich",SqlDbType.Bit,pXL_TuanInfo.ChoPhepXemLich));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pXL_TuanInfo.HocKy));
            colParam.Add(CreateParam("@XL_TuanID",SqlDbType.BigInt,pXL_TuanInfo.XL_TuanID));

            RunProcedure("sp_XL_Tuan_Update", colParam);
        }
        
        public void Delete(XL_TuanInfo pXL_TuanInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_TuanID",SqlDbType.BigInt,pXL_TuanInfo.XL_TuanID));

            RunProcedure("sp_XL_Tuan_Delete", colParam);
        }
    }
}
