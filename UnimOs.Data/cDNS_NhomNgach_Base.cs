using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_NhomNgach : cDBase
    {
        public DataTable Get(NS_NhomNgachInfo pNS_NhomNgachInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_NhomNgachID",SqlDbType.Int,pNS_NhomNgachInfo.NS_NhomNgachID));

            return RunProcedureGet("sp_NS_NhomNgach_Get", colParam);            
        }

        public int Add(NS_NhomNgachInfo pNS_NhomNgachInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KyHieu",SqlDbType.NVarChar,pNS_NhomNgachInfo.KyHieu));
            colParam.Add(CreateParam("@TenNhomNgach",SqlDbType.NVarChar,pNS_NhomNgachInfo.TenNhomNgach));
            colParam.Add(CreateParam("@LoaiCongChuc",SqlDbType.NVarChar,pNS_NhomNgachInfo.LoaiCongChuc));
            colParam.Add(CreateParam("@IDNS_LinhVucCongTac", SqlDbType.Int, pNS_NhomNgachInfo.IDNS_LinhVucCongTac));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NVarChar,pNS_NhomNgachInfo.MoTa));
            colParam.Add(CreateParam("@SoNamNangBac",SqlDbType.Float,pNS_NhomNgachInfo.SoNamNangBac));
            colParam.Add(CreateParam("@BacCaoNhat",SqlDbType.Int,pNS_NhomNgachInfo.BacCaoNhat));
            colParam.Add(CreateParam("@HeSoLuongBac_1",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_1));
            colParam.Add(CreateParam("@HeSoLuongBac_2",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_2));
            colParam.Add(CreateParam("@HeSoLuongBac_3",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_3));
            colParam.Add(CreateParam("@HeSoLuongBac_4",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_4));
            colParam.Add(CreateParam("@HeSoLuongBac_5",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_5));
            colParam.Add(CreateParam("@HeSoLuongBac_6",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_6));
            colParam.Add(CreateParam("@HeSoLuongBac_7",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_7));
            colParam.Add(CreateParam("@HeSoLuongBac_8",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_8));
            colParam.Add(CreateParam("@HeSoLuongBac_9",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_9));
            colParam.Add(CreateParam("@HeSoLuongBac_10",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_10));
            colParam.Add(CreateParam("@HeSoLuongBac_11",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_11));
            colParam.Add(CreateParam("@HeSoLuongBac_12",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_12));
            colParam.Add(CreateParam("@HeSoLuongBac_13",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_13));
            colParam.Add(CreateParam("@HeSoLuongBac_14",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_14));
            colParam.Add(CreateParam("@HeSoLuongBac_15",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_15));
            colParam.Add(CreateParam("@HeSoLuongBac_16",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_16));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_NhomNgach_Add", colParam);
        }
        
        public void Update(NS_NhomNgachInfo pNS_NhomNgachInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KyHieu",SqlDbType.NVarChar,pNS_NhomNgachInfo.KyHieu));
            colParam.Add(CreateParam("@TenNhomNgach",SqlDbType.NVarChar,pNS_NhomNgachInfo.TenNhomNgach));
            colParam.Add(CreateParam("@LoaiCongChuc",SqlDbType.NVarChar,pNS_NhomNgachInfo.LoaiCongChuc));
            colParam.Add(CreateParam("@IDNS_LinhVucCongTac", SqlDbType.Int, pNS_NhomNgachInfo.IDNS_LinhVucCongTac));
            colParam.Add(CreateParam("@MoTa",SqlDbType.NVarChar,pNS_NhomNgachInfo.MoTa));
            colParam.Add(CreateParam("@SoNamNangBac",SqlDbType.Float,pNS_NhomNgachInfo.SoNamNangBac));
            colParam.Add(CreateParam("@BacCaoNhat",SqlDbType.Int,pNS_NhomNgachInfo.BacCaoNhat));
            colParam.Add(CreateParam("@HeSoLuongBac_1",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_1));
            colParam.Add(CreateParam("@HeSoLuongBac_2",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_2));
            colParam.Add(CreateParam("@HeSoLuongBac_3",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_3));
            colParam.Add(CreateParam("@HeSoLuongBac_4",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_4));
            colParam.Add(CreateParam("@HeSoLuongBac_5",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_5));
            colParam.Add(CreateParam("@HeSoLuongBac_6",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_6));
            colParam.Add(CreateParam("@HeSoLuongBac_7",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_7));
            colParam.Add(CreateParam("@HeSoLuongBac_8",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_8));
            colParam.Add(CreateParam("@HeSoLuongBac_9",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_9));
            colParam.Add(CreateParam("@HeSoLuongBac_10",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_10));
            colParam.Add(CreateParam("@HeSoLuongBac_11",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_11));
            colParam.Add(CreateParam("@HeSoLuongBac_12",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_12));
            colParam.Add(CreateParam("@HeSoLuongBac_13",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_13));
            colParam.Add(CreateParam("@HeSoLuongBac_14",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_14));
            colParam.Add(CreateParam("@HeSoLuongBac_15",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_15));
            colParam.Add(CreateParam("@HeSoLuongBac_16",SqlDbType.Float,pNS_NhomNgachInfo.HeSoLuongBac_16));
            colParam.Add(CreateParam("@NS_NhomNgachID",SqlDbType.Int,pNS_NhomNgachInfo.NS_NhomNgachID));

            RunProcedure("sp_NS_NhomNgach_Update", colParam);
        }
        
        public void Delete(NS_NhomNgachInfo pNS_NhomNgachInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_NhomNgachID",SqlDbType.Int,pNS_NhomNgachInfo.NS_NhomNgachID));

            RunProcedure("sp_NS_NhomNgach_Delete", colParam);
        }
    }
}
