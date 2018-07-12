using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDHT_ChucNang : cDBase
    {
        public DataTable Get(HT_ChucNangInfo pHT_ChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_ChucNangID",SqlDbType.Int,pHT_ChucNangInfo.HT_ChucNangID));

            return RunProcedureGet("sp_HT_ChucNang_Get", colParam);            
        }

        public int Add(HT_ChucNangInfo pHT_ChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDHT_PhanHe",SqlDbType.Int,pHT_ChucNangInfo.IDHT_PhanHe));
            colParam.Add(CreateParam("@TenChucNang",SqlDbType.NVarChar,pHT_ChucNangInfo.TenChucNang));
            colParam.Add(CreateParam("@Tag",SqlDbType.NVarChar,pHT_ChucNangInfo.Tag));
            colParam.Add(CreateParam("@ParentID",SqlDbType.Int,pHT_ChucNangInfo.ParentID));
            colParam.Add(CreateParam("@Level",SqlDbType.Int,pHT_ChucNangInfo.Level));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NText,pHT_ChucNangInfo.MoTa));
            colParam.Add(CreateParam("@barbtnName",SqlDbType.NVarChar,pHT_ChucNangInfo.barbtnName));
            colParam.Add(CreateParam("@KieuRibbon", SqlDbType.NVarChar, pHT_ChucNangInfo.KieuRibbon));
            colParam.Add(CreateParam("@btnThem",SqlDbType.NVarChar,pHT_ChucNangInfo.btnThem));
            colParam.Add(CreateParam("@btnSua",SqlDbType.NVarChar,pHT_ChucNangInfo.btnSua));
            colParam.Add(CreateParam("@btnXoa",SqlDbType.NVarChar,pHT_ChucNangInfo.btnXoa));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_HT_ChucNang_Add", colParam);
        }
        
        public void Update(HT_ChucNangInfo pHT_ChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDHT_PhanHe",SqlDbType.Int,pHT_ChucNangInfo.IDHT_PhanHe));
            colParam.Add(CreateParam("@TenChucNang",SqlDbType.NVarChar,pHT_ChucNangInfo.TenChucNang));
            colParam.Add(CreateParam("@Tag",SqlDbType.NVarChar,pHT_ChucNangInfo.Tag));
            colParam.Add(CreateParam("@ParentID",SqlDbType.Int,pHT_ChucNangInfo.ParentID));
            colParam.Add(CreateParam("@Level",SqlDbType.Int,pHT_ChucNangInfo.Level));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NText,pHT_ChucNangInfo.MoTa));
            colParam.Add(CreateParam("@barbtnName",SqlDbType.NVarChar,pHT_ChucNangInfo.barbtnName));
            colParam.Add(CreateParam("@KieuRibbon", SqlDbType.NVarChar, pHT_ChucNangInfo.KieuRibbon));
            colParam.Add(CreateParam("@btnThem",SqlDbType.NVarChar,pHT_ChucNangInfo.btnThem));
            colParam.Add(CreateParam("@btnSua",SqlDbType.NVarChar,pHT_ChucNangInfo.btnSua));
            colParam.Add(CreateParam("@btnXoa",SqlDbType.NVarChar,pHT_ChucNangInfo.btnXoa));
            colParam.Add(CreateParam("@HT_ChucNangID",SqlDbType.Int,pHT_ChucNangInfo.HT_ChucNangID));

            RunProcedure("sp_HT_ChucNang_Update", colParam);
        }
        
        public void Delete(HT_ChucNangInfo pHT_ChucNangInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_ChucNangID",SqlDbType.Int,pHT_ChucNangInfo.HT_ChucNangID));

            RunProcedure("sp_HT_ChucNang_Delete", colParam);
        }
    }
}
