using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_LoaiPhuCap : cDBase
    {
        public DataTable Get(NS_LoaiPhuCapInfo pNS_LoaiPhuCapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_LoaiPhuCapID",SqlDbType.Int,pNS_LoaiPhuCapInfo.NS_LoaiPhuCapID));

            return RunProcedureGet("sp_NS_LoaiPhuCap_Get", colParam);            
        }

        public int Add(NS_LoaiPhuCapInfo pNS_LoaiPhuCapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KyHieu",SqlDbType.NVarChar,pNS_LoaiPhuCapInfo.KyHieu));
            colParam.Add(CreateParam("@TenLoaiPhuCap",SqlDbType.NVarChar,pNS_LoaiPhuCapInfo.TenLoaiPhuCap));
            colParam.Add(CreateParam("@LaPhuCapChucVu", SqlDbType.Bit, pNS_LoaiPhuCapInfo.LaPhuCapChucVu));
            colParam.Add(CreateParam("@BHXH",SqlDbType.Bit,pNS_LoaiPhuCapInfo.BHXH));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_LoaiPhuCap_Add", colParam);
        }
        
        public void Update(NS_LoaiPhuCapInfo pNS_LoaiPhuCapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KyHieu",SqlDbType.NVarChar,pNS_LoaiPhuCapInfo.KyHieu));
            colParam.Add(CreateParam("@TenLoaiPhuCap",SqlDbType.NVarChar,pNS_LoaiPhuCapInfo.TenLoaiPhuCap));
            colParam.Add(CreateParam("@LaPhuCapChucVu", SqlDbType.Bit, pNS_LoaiPhuCapInfo.LaPhuCapChucVu));
            colParam.Add(CreateParam("@BHXH",SqlDbType.Bit,pNS_LoaiPhuCapInfo.BHXH));
            colParam.Add(CreateParam("@NS_LoaiPhuCapID",SqlDbType.Int,pNS_LoaiPhuCapInfo.NS_LoaiPhuCapID));

            RunProcedure("sp_NS_LoaiPhuCap_Update", colParam);
        }
        
        public void Delete(NS_LoaiPhuCapInfo pNS_LoaiPhuCapInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_LoaiPhuCapID",SqlDbType.Int,pNS_LoaiPhuCapInfo.NS_LoaiPhuCapID));

            RunProcedure("sp_NS_LoaiPhuCap_Delete", colParam);
        }
    }
}
