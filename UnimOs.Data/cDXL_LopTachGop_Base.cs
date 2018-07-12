using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_LopTachGop : cDBase
    {
        public DataTable Get(XL_LopTachGopInfo pXL_LopTachGopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_LopTachGopID",SqlDbType.Int,pXL_LopTachGopInfo.XL_LopTachGopID));

            return RunProcedureGet("sp_XL_LopTachGop_Get", colParam);            
        }

        public int Add(XL_LopTachGopInfo pXL_LopTachGopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenLopTachGop",SqlDbType.NVarChar,pXL_LopTachGopInfo.TenLopTachGop));
            colParam.Add(CreateParam("@SoSinhVien",SqlDbType.Int,pXL_LopTachGopInfo.SoSinhVien));
            colParam.Add(CreateParam("@IDDM_LopGoc",SqlDbType.Int,pXL_LopTachGopInfo.IDDM_LopGoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pXL_LopTachGopInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pXL_LopTachGopInfo.HocKy));
            colParam.Add(CreateParam("@LopTach",SqlDbType.Bit,pXL_LopTachGopInfo.LopTach));
            colParam.Add(CreateParam("@ParentID",SqlDbType.Int,pXL_LopTachGopInfo.ParentID));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_LopTachGop_Add", colParam);
        }
        
        public void Update(XL_LopTachGopInfo pXL_LopTachGopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenLopTachGop",SqlDbType.NVarChar,pXL_LopTachGopInfo.TenLopTachGop));
            colParam.Add(CreateParam("@SoSinhVien",SqlDbType.Int,pXL_LopTachGopInfo.SoSinhVien));
            colParam.Add(CreateParam("@IDDM_LopGoc",SqlDbType.Int,pXL_LopTachGopInfo.IDDM_LopGoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pXL_LopTachGopInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pXL_LopTachGopInfo.HocKy));
            colParam.Add(CreateParam("@LopTach",SqlDbType.Bit,pXL_LopTachGopInfo.LopTach));
            colParam.Add(CreateParam("@ParentID",SqlDbType.Int,pXL_LopTachGopInfo.ParentID));
            colParam.Add(CreateParam("@XL_LopTachGopID",SqlDbType.Int,pXL_LopTachGopInfo.XL_LopTachGopID));

            RunProcedure("sp_XL_LopTachGop_Update", colParam);
        }
        
        public void Delete(XL_LopTachGopInfo pXL_LopTachGopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_LopTachGopID",SqlDbType.Int,pXL_LopTachGopInfo.XL_LopTachGopID));

            RunProcedure("sp_XL_LopTachGop_Delete", colParam);
        }
    }
}
