using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_QuyHocBong : cDBase
    {
        public DataTable Get(TC_QuyHocBongInfo pTC_QuyHocBongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_QuyHocBongID",SqlDbType.Int,pTC_QuyHocBongInfo.TC_QuyHocBongID));

            return RunProcedureGet("sp_TC_QuyHocBong_Get", colParam);            
        }

        public int Add(TC_QuyHocBongInfo pTC_QuyHocBongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He",SqlDbType.Int,pTC_QuyHocBongInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo",SqlDbType.Int,pTC_QuyHocBongInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_LoaiQuy",SqlDbType.Int,pTC_QuyHocBongInfo.IDDM_LoaiQuy));
            colParam.Add(CreateParam("@PhanTramHocPhi",SqlDbType.Float,pTC_QuyHocBongInfo.PhanTramHocPhi));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pTC_QuyHocBongInfo.SoTien));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pTC_QuyHocBongInfo.GhiChu));
            colParam.Add(CreateParam("@HetHan",SqlDbType.Bit,pTC_QuyHocBongInfo.HetHan));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_TC_QuyHocBong_Add", colParam);
        }
        
        public void Update(TC_QuyHocBongInfo pTC_QuyHocBongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_He",SqlDbType.Int,pTC_QuyHocBongInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo",SqlDbType.Int,pTC_QuyHocBongInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_LoaiQuy",SqlDbType.Int,pTC_QuyHocBongInfo.IDDM_LoaiQuy));
            colParam.Add(CreateParam("@PhanTramHocPhi",SqlDbType.Float,pTC_QuyHocBongInfo.PhanTramHocPhi));
            colParam.Add(CreateParam("@SoTien",SqlDbType.Money,pTC_QuyHocBongInfo.SoTien));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pTC_QuyHocBongInfo.GhiChu));
            colParam.Add(CreateParam("@HetHan",SqlDbType.Bit,pTC_QuyHocBongInfo.HetHan));
            colParam.Add(CreateParam("@TC_QuyHocBongID",SqlDbType.Int,pTC_QuyHocBongInfo.TC_QuyHocBongID));

            RunProcedure("sp_TC_QuyHocBong_Update", colParam);
        }
        
        public void Delete(TC_QuyHocBongInfo pTC_QuyHocBongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TC_QuyHocBongID",SqlDbType.Int,pTC_QuyHocBongInfo.TC_QuyHocBongID));

            RunProcedure("sp_TC_QuyHocBong_Delete", colParam);
        }
    }
}
