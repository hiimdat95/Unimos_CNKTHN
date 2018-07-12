using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_QuyetDinhTotNghiep : cDBase
    {
        public DataTable Get(KQHT_QuyetDinhTotNghiepInfo pKQHT_QuyetDinhTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_QuyetDinhTotNghiepID",SqlDbType.Int,pKQHT_QuyetDinhTotNghiepInfo.KQHT_QuyetDinhTotNghiepID));

            return RunProcedureGet("sp_KQHT_QuyetDinhTotNghiep_Get", colParam);            
        }

        public int Add(KQHT_QuyetDinhTotNghiepInfo pKQHT_QuyetDinhTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pKQHT_QuyetDinhTotNghiepInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayQuyetDinh",SqlDbType.DateTime,pKQHT_QuyetDinhTotNghiepInfo.NgayQuyetDinh));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NText,pKQHT_QuyetDinhTotNghiepInfo.NoiDung));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_QuyetDinhTotNghiepInfo.IDDM_NamHoc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_QuyetDinhTotNghiep_Add", colParam);
        }
        
        public void Update(KQHT_QuyetDinhTotNghiepInfo pKQHT_QuyetDinhTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pKQHT_QuyetDinhTotNghiepInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayQuyetDinh",SqlDbType.DateTime,pKQHT_QuyetDinhTotNghiepInfo.NgayQuyetDinh));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NText,pKQHT_QuyetDinhTotNghiepInfo.NoiDung));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_QuyetDinhTotNghiepInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@KQHT_QuyetDinhTotNghiepID",SqlDbType.Int,pKQHT_QuyetDinhTotNghiepInfo.KQHT_QuyetDinhTotNghiepID));

            RunProcedure("sp_KQHT_QuyetDinhTotNghiep_Update", colParam);
        }
        
        public void Delete(KQHT_QuyetDinhTotNghiepInfo pKQHT_QuyetDinhTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_QuyetDinhTotNghiepID",SqlDbType.Int,pKQHT_QuyetDinhTotNghiepInfo.KQHT_QuyetDinhTotNghiepID));

            RunProcedure("sp_KQHT_QuyetDinhTotNghiep_Delete", colParam);
        }
    }
}
