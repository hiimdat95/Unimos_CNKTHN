using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDSV_AnhXaMon : cDBase
    {
        public DataTable Get(SV_AnhXaMonInfo pSV_AnhXaMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_AnhXaMonID",SqlDbType.BigInt,pSV_AnhXaMonInfo.SV_AnhXaMonID));

            return RunProcedureGet("sp_SV_AnhXaMon_Get", colParam);            
        }

        public int Add(SV_AnhXaMonInfo pSV_AnhXaMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_AnhXaMonInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKyCu",SqlDbType.Int,pSV_AnhXaMonInfo.IDXL_MonHocTrongKyCu));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKyMoi",SqlDbType.Int,pSV_AnhXaMonInfo.IDXL_MonHocTrongKyMoi));
            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pSV_AnhXaMonInfo.IDDM_Lop));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_SV_AnhXaMon_Add", colParam);
        }
        
        public void Update(SV_AnhXaMonInfo pSV_AnhXaMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pSV_AnhXaMonInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKyCu",SqlDbType.Int,pSV_AnhXaMonInfo.IDXL_MonHocTrongKyCu));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKyMoi",SqlDbType.Int,pSV_AnhXaMonInfo.IDXL_MonHocTrongKyMoi));
            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pSV_AnhXaMonInfo.IDDM_Lop));
            colParam.Add(CreateParam("@SV_AnhXaMonID",SqlDbType.BigInt,pSV_AnhXaMonInfo.SV_AnhXaMonID));

            RunProcedure("sp_SV_AnhXaMon_Update", colParam);
        }
        
        public void Delete(SV_AnhXaMonInfo pSV_AnhXaMonInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SV_AnhXaMonID",SqlDbType.BigInt,pSV_AnhXaMonInfo.SV_AnhXaMonID));

            RunProcedure("sp_SV_AnhXaMon_Delete", colParam);
        }
    }
}
