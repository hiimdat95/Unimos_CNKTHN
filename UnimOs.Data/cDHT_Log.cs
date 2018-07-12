using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDHT_Log : cDBase
    {
        public DataTable Search(int IDPhanHe, int IDChucNang, string SuKien, string NguoiDung, string NoiDung, DateTime dtTuNgay, DateTime dtDenNgay)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDPhanHe", SqlDbType.Int, IDPhanHe));
            colParam.Add(CreateParam("@IDChucNang", SqlDbType.Int, IDChucNang));
            colParam.Add(CreateParam("@SuKien", SqlDbType.NVarChar,50, SuKien));
            colParam.Add(CreateParam("@NguoiDung", SqlDbType.NVarChar,50, NguoiDung));
            colParam.Add(CreateParam("@NoiDung", SqlDbType.NVarChar,200, NoiDung));

            colParam.Add(CreateParam("@dtTuNgay", SqlDbType.DateTime, dtTuNgay));
            colParam.Add(CreateParam("@dtDenNgay", SqlDbType.DateTime, dtDenNgay));

           return  RunProcedureGet("sp_HT_Log_Search", colParam);
        }
    }
}
