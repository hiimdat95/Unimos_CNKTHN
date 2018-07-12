using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_BaoBanGiaoVien : cDBase
    {
        public DataTable Get(XL_BaoBanGiaoVienInfo pXL_BaoBanGiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_BaoBanGiaoVienID",SqlDbType.Int,pXL_BaoBanGiaoVienInfo.XL_BaoBanGiaoVienID));

            return RunProcedureGet("sp_XL_BaoBanGiaoVien_Get", colParam);            
        }

        public int Add(XL_BaoBanGiaoVienInfo pXL_BaoBanGiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTuan",SqlDbType.BigInt,pXL_BaoBanGiaoVienInfo.IDTuan));
            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pXL_BaoBanGiaoVienInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@Thu",SqlDbType.Int,pXL_BaoBanGiaoVienInfo.Thu));
            colParam.Add(CreateParam("@Tiet",SqlDbType.Int,pXL_BaoBanGiaoVienInfo.Tiet));
            colParam.Add(CreateParam("@CaHoc",SqlDbType.Int,pXL_BaoBanGiaoVienInfo.CaHoc));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NVarChar,pXL_BaoBanGiaoVienInfo.MoTa));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_BaoBanGiaoVien_Add", colParam);
        }
        
        public void Update(XL_BaoBanGiaoVienInfo pXL_BaoBanGiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTuan",SqlDbType.BigInt,pXL_BaoBanGiaoVienInfo.IDTuan));
            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pXL_BaoBanGiaoVienInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@Thu",SqlDbType.Int,pXL_BaoBanGiaoVienInfo.Thu));
            colParam.Add(CreateParam("@Tiet",SqlDbType.Int,pXL_BaoBanGiaoVienInfo.Tiet));
            colParam.Add(CreateParam("@CaHoc",SqlDbType.Int,pXL_BaoBanGiaoVienInfo.CaHoc));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NVarChar,pXL_BaoBanGiaoVienInfo.MoTa));
            colParam.Add(CreateParam("@XL_BaoBanGiaoVienID",SqlDbType.Int,pXL_BaoBanGiaoVienInfo.XL_BaoBanGiaoVienID));

            RunProcedure("sp_XL_BaoBanGiaoVien_Update", colParam);
        }
        
        public void Delete(XL_BaoBanGiaoVienInfo pXL_BaoBanGiaoVienInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_BaoBanGiaoVienID",SqlDbType.Int,pXL_BaoBanGiaoVienInfo.XL_BaoBanGiaoVienID));

            RunProcedure("sp_XL_BaoBanGiaoVien_Delete", colParam);
        }
    }
}
