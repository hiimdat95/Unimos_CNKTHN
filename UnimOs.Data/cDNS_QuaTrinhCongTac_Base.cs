using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_QuaTrinhCongTac : cDBase
    {
        public DataTable Get(NS_QuaTrinhCongTacInfo pNS_QuaTrinhCongTacInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_QuaTrinhCongTacID",SqlDbType.Int,pNS_QuaTrinhCongTacInfo.NS_QuaTrinhCongTacID));

            return RunProcedureGet("sp_NS_QuaTrinhCongTac_Get", colParam);            
        }

        public int Add(NS_QuaTrinhCongTacInfo pNS_QuaTrinhCongTacInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_QuaTrinhCongTacInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@NoiCongTac",SqlDbType.NVarChar,pNS_QuaTrinhCongTacInfo.NoiCongTac));
            colParam.Add(CreateParam("@NoiDungCongTac",SqlDbType.NVarChar,pNS_QuaTrinhCongTacInfo.NoiDungCongTac));
            colParam.Add(CreateParam("@ChucVuDamNhiem",SqlDbType.NVarChar,pNS_QuaTrinhCongTacInfo.ChucVuDamNhiem));
            colParam.Add(CreateParam("@TuNgay",SqlDbType.DateTime,pNS_QuaTrinhCongTacInfo.TuNgay));
            colParam.Add(CreateParam("@DenNgay",SqlDbType.DateTime,pNS_QuaTrinhCongTacInfo.DenNgay));
            colParam.Add(CreateParam("@DiNuocNgoai",SqlDbType.Bit,pNS_QuaTrinhCongTacInfo.DiNuocNgoai));
            colParam.Add(CreateParam("@IDDM_QuocTich",SqlDbType.Int,pNS_QuaTrinhCongTacInfo.IDDM_QuocTich));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_QuaTrinhCongTac_Add", colParam);
        }
        
        public void Update(NS_QuaTrinhCongTacInfo pNS_QuaTrinhCongTacInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_QuaTrinhCongTacInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@NoiCongTac",SqlDbType.NVarChar,pNS_QuaTrinhCongTacInfo.NoiCongTac));
            colParam.Add(CreateParam("@NoiDungCongTac",SqlDbType.NVarChar,pNS_QuaTrinhCongTacInfo.NoiDungCongTac));
            colParam.Add(CreateParam("@ChucVuDamNhiem",SqlDbType.NVarChar,pNS_QuaTrinhCongTacInfo.ChucVuDamNhiem));
            colParam.Add(CreateParam("@TuNgay",SqlDbType.DateTime,pNS_QuaTrinhCongTacInfo.TuNgay));
            colParam.Add(CreateParam("@DenNgay",SqlDbType.DateTime,pNS_QuaTrinhCongTacInfo.DenNgay));
            colParam.Add(CreateParam("@DiNuocNgoai",SqlDbType.Bit,pNS_QuaTrinhCongTacInfo.DiNuocNgoai));
            colParam.Add(CreateParam("@IDDM_QuocTich",SqlDbType.Int,pNS_QuaTrinhCongTacInfo.IDDM_QuocTich));
            colParam.Add(CreateParam("@NS_QuaTrinhCongTacID",SqlDbType.Int,pNS_QuaTrinhCongTacInfo.NS_QuaTrinhCongTacID));

            RunProcedure("sp_NS_QuaTrinhCongTac_Update", colParam);
        }
        
        public void Delete(NS_QuaTrinhCongTacInfo pNS_QuaTrinhCongTacInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_QuaTrinhCongTacID",SqlDbType.Int,pNS_QuaTrinhCongTacInfo.NS_QuaTrinhCongTacID));

            RunProcedure("sp_NS_QuaTrinhCongTac_Delete", colParam);
        }
    }
}
