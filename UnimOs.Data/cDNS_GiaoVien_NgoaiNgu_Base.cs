using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_GiaoVien_NgoaiNgu : cDBase
    {
        public DataTable Get(NS_GiaoVien_NgoaiNguInfo pNS_GiaoVien_NgoaiNguInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_GiaoVien_NgoaiNguID",SqlDbType.Int,pNS_GiaoVien_NgoaiNguInfo.NS_GiaoVien_NgoaiNguID));

            return RunProcedureGet("sp_NS_GiaoVien_NgoaiNgu_Get", colParam);            
        }

        public int Add(NS_GiaoVien_NgoaiNguInfo pNS_GiaoVien_NgoaiNguInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_GiaoVien_NgoaiNguInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDDM_NgoaiNgu",SqlDbType.Int,pNS_GiaoVien_NgoaiNguInfo.IDDM_NgoaiNgu));
            colParam.Add(CreateParam("@IDTrinhDo", SqlDbType.NVarChar, pNS_GiaoVien_NgoaiNguInfo.IDTrinhDo));
            colParam.Add(CreateParam("@TrinhDo",SqlDbType.NVarChar,pNS_GiaoVien_NgoaiNguInfo.TrinhDo));
            colParam.Add(CreateParam("@SoChungChi",SqlDbType.NVarChar,pNS_GiaoVien_NgoaiNguInfo.SoChungChi));
            colParam.Add(CreateParam("@NgayCap",SqlDbType.DateTime,pNS_GiaoVien_NgoaiNguInfo.NgayCap));
            colParam.Add(CreateParam("@NoiCap",SqlDbType.NVarChar,pNS_GiaoVien_NgoaiNguInfo.NoiCap));
            colParam.Add(CreateParam("@IDDM_TinhHuyenXaNoiCap",SqlDbType.Int,pNS_GiaoVien_NgoaiNguInfo.IDDM_TinhHuyenXaNoiCap));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_GiaoVien_NgoaiNgu_Add", colParam);
        }
        
        public void Update(NS_GiaoVien_NgoaiNguInfo pNS_GiaoVien_NgoaiNguInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_GiaoVien_NgoaiNguInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDDM_NgoaiNgu",SqlDbType.Int,pNS_GiaoVien_NgoaiNguInfo.IDDM_NgoaiNgu));
            colParam.Add(CreateParam("@IDTrinhDo", SqlDbType.NVarChar, pNS_GiaoVien_NgoaiNguInfo.IDTrinhDo));
            colParam.Add(CreateParam("@TrinhDo",SqlDbType.NVarChar,pNS_GiaoVien_NgoaiNguInfo.TrinhDo));
            colParam.Add(CreateParam("@SoChungChi",SqlDbType.NVarChar,pNS_GiaoVien_NgoaiNguInfo.SoChungChi));
            colParam.Add(CreateParam("@NgayCap",SqlDbType.DateTime,pNS_GiaoVien_NgoaiNguInfo.NgayCap));
            colParam.Add(CreateParam("@NoiCap",SqlDbType.NVarChar,pNS_GiaoVien_NgoaiNguInfo.NoiCap));
            colParam.Add(CreateParam("@IDDM_TinhHuyenXaNoiCap",SqlDbType.Int,pNS_GiaoVien_NgoaiNguInfo.IDDM_TinhHuyenXaNoiCap));
            colParam.Add(CreateParam("@NS_GiaoVien_NgoaiNguID",SqlDbType.Int,pNS_GiaoVien_NgoaiNguInfo.NS_GiaoVien_NgoaiNguID));

            RunProcedure("sp_NS_GiaoVien_NgoaiNgu_Update", colParam);
        }
        
        public void Delete(NS_GiaoVien_NgoaiNguInfo pNS_GiaoVien_NgoaiNguInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_GiaoVien_NgoaiNguID",SqlDbType.Int,pNS_GiaoVien_NgoaiNguInfo.NS_GiaoVien_NgoaiNguID));

            RunProcedure("sp_NS_GiaoVien_NgoaiNgu_Delete", colParam);
        }
    }
}
