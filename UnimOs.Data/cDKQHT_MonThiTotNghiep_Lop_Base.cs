using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_MonThiTotNghiep_Lop : cDBase
    {
        public DataTable Get(KQHT_MonThiTotNghiep_LopInfo pKQHT_MonThiTotNghiep_LopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_MonThiTotNghiep_LopID",SqlDbType.Int,pKQHT_MonThiTotNghiep_LopInfo.KQHT_MonThiTotNghiep_LopID));

            return RunProcedureGet("sp_KQHT_MonThiTotNghiep_Lop_Get", colParam);            
        }

        public int Add(KQHT_MonThiTotNghiep_LopInfo pKQHT_MonThiTotNghiep_LopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pKQHT_MonThiTotNghiep_LopInfo.IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_MonThiTotNghiep_LopInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@TinhDiem",SqlDbType.Bit,pKQHT_MonThiTotNghiep_LopInfo.TinhDiem));
            colParam.Add(CreateParam("@SoHocTrinh",SqlDbType.Float,pKQHT_MonThiTotNghiep_LopInfo.SoHocTrinh));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_MonThiTotNghiep_LopInfo.IDDM_NamHoc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_MonThiTotNghiep_Lop_Add", colParam);
        }
        
        public void Update(KQHT_MonThiTotNghiep_LopInfo pKQHT_MonThiTotNghiep_LopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pKQHT_MonThiTotNghiep_LopInfo.IDDM_Lop));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_MonThiTotNghiep_LopInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@TinhDiem",SqlDbType.Bit,pKQHT_MonThiTotNghiep_LopInfo.TinhDiem));
            colParam.Add(CreateParam("@SoHocTrinh", SqlDbType.Float, pKQHT_MonThiTotNghiep_LopInfo.SoHocTrinh));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_MonThiTotNghiep_LopInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@KQHT_MonThiTotNghiep_LopID",SqlDbType.Int,pKQHT_MonThiTotNghiep_LopInfo.KQHT_MonThiTotNghiep_LopID));

            RunProcedure("sp_KQHT_MonThiTotNghiep_Lop_Update", colParam);
        }
        
        public void Delete(KQHT_MonThiTotNghiep_LopInfo pKQHT_MonThiTotNghiep_LopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_MonThiTotNghiep_LopID",SqlDbType.Int,pKQHT_MonThiTotNghiep_LopInfo.KQHT_MonThiTotNghiep_LopID));

            RunProcedure("sp_KQHT_MonThiTotNghiep_Lop_Delete", colParam);
        }
    }
}
