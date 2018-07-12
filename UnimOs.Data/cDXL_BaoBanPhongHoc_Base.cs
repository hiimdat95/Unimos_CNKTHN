using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_BaoBanPhongHoc : cDBase
    {
        public DataTable Get(XL_BaoBanPhongHocInfo pXL_BaoBanPhongHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_BaoBanPhongHocID",SqlDbType.Int,pXL_BaoBanPhongHocInfo.XL_BaoBanPhongHocID));

            return RunProcedureGet("sp_XL_BaoBanPhongHoc_Get", colParam);            
        }

        public int Add(XL_BaoBanPhongHocInfo pXL_BaoBanPhongHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTuan",SqlDbType.BigInt,pXL_BaoBanPhongHocInfo.IDTuan));
            colParam.Add(CreateParam("@IDXL_PhongHoc",SqlDbType.Int,pXL_BaoBanPhongHocInfo.IDXL_PhongHoc));
            colParam.Add(CreateParam("@Thu",SqlDbType.Int,pXL_BaoBanPhongHocInfo.Thu));
            colParam.Add(CreateParam("@Tiet",SqlDbType.Int,pXL_BaoBanPhongHocInfo.Tiet));
            colParam.Add(CreateParam("@SoTiet",SqlDbType.Int,pXL_BaoBanPhongHocInfo.SoTiet));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NVarChar,pXL_BaoBanPhongHocInfo.MoTa));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_BaoBanPhongHoc_Add", colParam);
        }
        
        public void Update(XL_BaoBanPhongHocInfo pXL_BaoBanPhongHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTuan",SqlDbType.BigInt,pXL_BaoBanPhongHocInfo.IDTuan));
            colParam.Add(CreateParam("@IDXL_PhongHoc",SqlDbType.Int,pXL_BaoBanPhongHocInfo.IDXL_PhongHoc));
            colParam.Add(CreateParam("@Thu",SqlDbType.Int,pXL_BaoBanPhongHocInfo.Thu));
            colParam.Add(CreateParam("@Tiet",SqlDbType.Int,pXL_BaoBanPhongHocInfo.Tiet));
            colParam.Add(CreateParam("@SoTiet",SqlDbType.Int,pXL_BaoBanPhongHocInfo.SoTiet));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NVarChar,pXL_BaoBanPhongHocInfo.MoTa));
            colParam.Add(CreateParam("@XL_BaoBanPhongHocID",SqlDbType.Int,pXL_BaoBanPhongHocInfo.XL_BaoBanPhongHocID));

            RunProcedure("sp_XL_BaoBanPhongHoc_Update", colParam);
        }
        
        public void Delete(XL_BaoBanPhongHocInfo pXL_BaoBanPhongHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_BaoBanPhongHocID",SqlDbType.Int,pXL_BaoBanPhongHocInfo.XL_BaoBanPhongHocID));

            RunProcedure("sp_XL_BaoBanPhongHoc_Delete", colParam);
        }
    }
}
