using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_LoaiHocBong : cDBase
    {
        public DataTable Get(TC_LoaiHocBongInfo pTC_LoaiHocBongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_LoaiHocBongID",SqlDbType.Int,pTC_LoaiHocBongInfo.TC_LoaiHocBongID));

            return RunProcedureGet("sp_TC_LoaiHocBong_Get", colParam);            
        }

        public int Add(TC_LoaiHocBongInfo pTC_LoaiHocBongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenLoaiHocBong",SqlDbType.NVarChar,pTC_LoaiHocBongInfo.TenLoaiHocBong));
            colParam.Add(CreateParam("@KyHieu",SqlDbType.NVarChar,pTC_LoaiHocBongInfo.KyHieu));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Float,pTC_LoaiHocBongInfo.SoTien));
            colParam.Add(CreateParam("@IDDM_TrinhDo",SqlDbType.Int,pTC_LoaiHocBongInfo.IDDM_TrinhDo));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_TC_LoaiHocBong_Add", colParam);
        }
        
        public void Update(TC_LoaiHocBongInfo pTC_LoaiHocBongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenLoaiHocBong",SqlDbType.NVarChar,pTC_LoaiHocBongInfo.TenLoaiHocBong));
            colParam.Add(CreateParam("@KyHieu",SqlDbType.NVarChar,pTC_LoaiHocBongInfo.KyHieu));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Float,pTC_LoaiHocBongInfo.SoTien));
            colParam.Add(CreateParam("@IDDM_TrinhDo",SqlDbType.Int,pTC_LoaiHocBongInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@TC_LoaiHocBongID",SqlDbType.Int,pTC_LoaiHocBongInfo.TC_LoaiHocBongID));

            RunProcedure("sp_TC_LoaiHocBong_Update", colParam);
        }
        
        public void Delete(TC_LoaiHocBongInfo pTC_LoaiHocBongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_LoaiHocBongID",SqlDbType.Int,pTC_LoaiHocBongInfo.TC_LoaiHocBongID));

            RunProcedure("sp_TC_LoaiHocBong_Delete", colParam);
        }
    }
}
