using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_QuyenHoaDon_TrinhDo : cDBase
    {
        public DataTable Get(TC_QuyenHoaDon_TrinhDoInfo pTC_QuyenHoaDon_TrinhDoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_QuyenHoaDon_TrinhDoID",SqlDbType.Int,pTC_QuyenHoaDon_TrinhDoInfo.TC_QuyenHoaDon_TrinhDoID));

            return RunProcedureGet("sp_TC_QuyenHoaDon_TrinhDo_Get", colParam);            
        }

        public int Add(TC_QuyenHoaDon_TrinhDoInfo pTC_QuyenHoaDon_TrinhDoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTC_QuyenHoaDon",SqlDbType.Int,pTC_QuyenHoaDon_TrinhDoInfo.IDTC_QuyenHoaDon));
            colParam.Add(CreateParam("@IDDM_TrinhDo",SqlDbType.Int,pTC_QuyenHoaDon_TrinhDoInfo.IDDM_TrinhDo));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_TC_QuyenHoaDon_TrinhDo_Add", colParam);
        }
        
        public void Update(TC_QuyenHoaDon_TrinhDoInfo pTC_QuyenHoaDon_TrinhDoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTC_QuyenHoaDon",SqlDbType.Int,pTC_QuyenHoaDon_TrinhDoInfo.IDTC_QuyenHoaDon));
            colParam.Add(CreateParam("@IDDM_TrinhDo",SqlDbType.Int,pTC_QuyenHoaDon_TrinhDoInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@TC_QuyenHoaDon_TrinhDoID",SqlDbType.Int,pTC_QuyenHoaDon_TrinhDoInfo.TC_QuyenHoaDon_TrinhDoID));

            RunProcedure("sp_TC_QuyenHoaDon_TrinhDo_Update", colParam);
        }
        
        public void Delete(TC_QuyenHoaDon_TrinhDoInfo pTC_QuyenHoaDon_TrinhDoInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_QuyenHoaDon_TrinhDoID",SqlDbType.Int,pTC_QuyenHoaDon_TrinhDoInfo.TC_QuyenHoaDon_TrinhDoID));

            RunProcedure("sp_TC_QuyenHoaDon_TrinhDo_Delete", colParam);
        }
    }
}
