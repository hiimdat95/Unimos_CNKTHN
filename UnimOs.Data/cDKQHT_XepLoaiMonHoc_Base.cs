using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_XepLoaiMonHoc : cDBase
    {
        public DataTable Get(KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_XepLoaiMonHocID",SqlDbType.Int,pKQHT_XepLoaiMonHocInfo.KQHT_XepLoaiMonHocID));

            return RunProcedureGet("sp_KQHT_XepLoaiMonHoc_Get", colParam);            
        }

        public int Add(KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenXepLoai",SqlDbType.NVarChar,pKQHT_XepLoaiMonHocInfo.TenXepLoai));
            colParam.Add(CreateParam("@TuDiem",SqlDbType.Float,pKQHT_XepLoaiMonHocInfo.TuDiem));
            colParam.Add(CreateParam("@MaXepLoai",SqlDbType.NVarChar,pKQHT_XepLoaiMonHocInfo.MaXepLoai));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_XepLoaiMonHoc_Add", colParam);
        }
        
        public void Update(KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenXepLoai",SqlDbType.NVarChar,pKQHT_XepLoaiMonHocInfo.TenXepLoai));
            colParam.Add(CreateParam("@TuDiem",SqlDbType.Float,pKQHT_XepLoaiMonHocInfo.TuDiem));
            colParam.Add(CreateParam("@MaXepLoai",SqlDbType.NVarChar,pKQHT_XepLoaiMonHocInfo.MaXepLoai));
            colParam.Add(CreateParam("@KQHT_XepLoaiMonHocID",SqlDbType.Int,pKQHT_XepLoaiMonHocInfo.KQHT_XepLoaiMonHocID));

            RunProcedure("sp_KQHT_XepLoaiMonHoc_Update", colParam);
        }
        
        public void Delete(KQHT_XepLoaiMonHocInfo pKQHT_XepLoaiMonHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_XepLoaiMonHocID",SqlDbType.Int,pKQHT_XepLoaiMonHocInfo.KQHT_XepLoaiMonHocID));

            RunProcedure("sp_KQHT_XepLoaiMonHoc_Delete", colParam);
        }
    }
}
