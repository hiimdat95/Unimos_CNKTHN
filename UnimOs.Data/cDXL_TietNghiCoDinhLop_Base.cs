using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_TietNghiCoDinhLop : cDBase
    {
        public DataTable Get(XL_TietNghiCoDinhLopInfo pXL_TietNghiCoDinhLopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_TietNghiCoDinhLopID",SqlDbType.Int,pXL_TietNghiCoDinhLopInfo.XL_TietNghiCoDinhLopID));

            return RunProcedureGet("sp_XL_TietNghiCoDinhLop_Get", colParam);            
        }

        public int Add(XL_TietNghiCoDinhLopInfo pXL_TietNghiCoDinhLopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pXL_TietNghiCoDinhLopInfo.IDDM_Lop));
            colParam.Add(CreateParam("@Thu",SqlDbType.Int,pXL_TietNghiCoDinhLopInfo.Thu));
            colParam.Add(CreateParam("@Tiet",SqlDbType.Int,pXL_TietNghiCoDinhLopInfo.Tiet));
            colParam.Add(CreateParam("@Nghi",SqlDbType.Bit,pXL_TietNghiCoDinhLopInfo.Nghi));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NVarChar,pXL_TietNghiCoDinhLopInfo.MoTa));
            colParam.Add(CreateParam("@CaHoc",SqlDbType.Int,pXL_TietNghiCoDinhLopInfo.CaHoc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_TietNghiCoDinhLop_Add", colParam);
        }
        
        public void Update(XL_TietNghiCoDinhLopInfo pXL_TietNghiCoDinhLopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pXL_TietNghiCoDinhLopInfo.IDDM_Lop));
            colParam.Add(CreateParam("@Thu",SqlDbType.Int,pXL_TietNghiCoDinhLopInfo.Thu));
            colParam.Add(CreateParam("@Tiet",SqlDbType.Int,pXL_TietNghiCoDinhLopInfo.Tiet));
            colParam.Add(CreateParam("@Nghi",SqlDbType.Bit,pXL_TietNghiCoDinhLopInfo.Nghi));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NVarChar,pXL_TietNghiCoDinhLopInfo.MoTa));
            colParam.Add(CreateParam("@CaHoc",SqlDbType.Int,pXL_TietNghiCoDinhLopInfo.CaHoc));
            colParam.Add(CreateParam("@XL_TietNghiCoDinhLopID",SqlDbType.Int,pXL_TietNghiCoDinhLopInfo.XL_TietNghiCoDinhLopID));

            RunProcedure("sp_XL_TietNghiCoDinhLop_Update", colParam);
        }
        
        public void Delete(XL_TietNghiCoDinhLopInfo pXL_TietNghiCoDinhLopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_TietNghiCoDinhLopID",SqlDbType.Int,pXL_TietNghiCoDinhLopInfo.XL_TietNghiCoDinhLopID));

            RunProcedure("sp_XL_TietNghiCoDinhLop_Delete", colParam);
        }
    }
}
