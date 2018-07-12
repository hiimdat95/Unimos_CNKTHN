using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_CT_KhoiKienThuc : cDBase
    {
        public DataTable Get(KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_CT_KhoiKienThucID",SqlDbType.Int,pKQHT_CT_KhoiKienThucInfo.KQHT_CT_KhoiKienThucID));

            return RunProcedureGet("sp_KQHT_CT_KhoiKienThuc_Get", colParam);            
        }

        public int Add(KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenCT_KhoiKienThuc",SqlDbType.NVarChar,pKQHT_CT_KhoiKienThucInfo.TenCT_KhoiKienThuc));
            colParam.Add(CreateParam("@IDDM_TrinhDo",SqlDbType.Int,pKQHT_CT_KhoiKienThucInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Nganh",SqlDbType.Int,pKQHT_CT_KhoiKienThucInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_ChuyenNganh",SqlDbType.Int,pKQHT_CT_KhoiKienThucInfo.IDDM_ChuyenNganh));
            colParam.Add(CreateParam("@IDDM_KhoaHoc",SqlDbType.Int,pKQHT_CT_KhoiKienThucInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_KhoiKienThuc",SqlDbType.Int,pKQHT_CT_KhoiKienThucInfo.IDDM_KhoiKienThuc));
            colParam.Add(CreateParam("@CT_KhoiKienThucSo",SqlDbType.Int,pKQHT_CT_KhoiKienThucInfo.CT_KhoiKienThucSo));
            colParam.Add(CreateParam("@TongSoHocTrinh",SqlDbType.Real,pKQHT_CT_KhoiKienThucInfo.TongSoHocTrinh));
            colParam.Add(CreateParam("@TongSoMon",SqlDbType.Int,pKQHT_CT_KhoiKienThucInfo.TongSoMon));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NText,pKQHT_CT_KhoiKienThucInfo.MoTa));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_CT_KhoiKienThuc_Add", colParam);
        }
        
        public void Update(KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenCT_KhoiKienThuc",SqlDbType.NVarChar,pKQHT_CT_KhoiKienThucInfo.TenCT_KhoiKienThuc));
            colParam.Add(CreateParam("@IDDM_TrinhDo",SqlDbType.Int,pKQHT_CT_KhoiKienThucInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Nganh",SqlDbType.Int,pKQHT_CT_KhoiKienThucInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_ChuyenNganh",SqlDbType.Int,pKQHT_CT_KhoiKienThucInfo.IDDM_ChuyenNganh));
            colParam.Add(CreateParam("@IDDM_KhoaHoc",SqlDbType.Int,pKQHT_CT_KhoiKienThucInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_KhoiKienThuc",SqlDbType.Int,pKQHT_CT_KhoiKienThucInfo.IDDM_KhoiKienThuc));
            colParam.Add(CreateParam("@CT_KhoiKienThucSo",SqlDbType.Int,pKQHT_CT_KhoiKienThucInfo.CT_KhoiKienThucSo));
            colParam.Add(CreateParam("@TongSoHocTrinh",SqlDbType.Real,pKQHT_CT_KhoiKienThucInfo.TongSoHocTrinh));
            colParam.Add(CreateParam("@TongSoMon",SqlDbType.Int,pKQHT_CT_KhoiKienThucInfo.TongSoMon));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NText,pKQHT_CT_KhoiKienThucInfo.MoTa));
            colParam.Add(CreateParam("@KQHT_CT_KhoiKienThucID",SqlDbType.Int,pKQHT_CT_KhoiKienThucInfo.KQHT_CT_KhoiKienThucID));

            RunProcedure("sp_KQHT_CT_KhoiKienThuc_Update", colParam);
        }
        
        public void Delete(KQHT_CT_KhoiKienThucInfo pKQHT_CT_KhoiKienThucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_CT_KhoiKienThucID",SqlDbType.Int,pKQHT_CT_KhoiKienThucInfo.KQHT_CT_KhoiKienThucID));
           // colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

          //  return (int)RunProcedureOut("sp_KQHT_CT_KhoiKienThuc_Delete", colParam);
            RunProcedure("sp_KQHT_CT_KhoiKienThuc_Delete", colParam);
        }
    }
}
