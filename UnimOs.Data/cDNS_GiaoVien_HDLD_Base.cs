using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_GiaoVien_HDLD : cDBase
    {
        public DataTable Get(NS_GiaoVien_HDLDInfo pNS_GiaoVien_HDLDInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_GiaoVien_HDLDID",SqlDbType.Int,pNS_GiaoVien_HDLDInfo.NS_GiaoVien_HDLDID));

            return RunProcedureGet("sp_NS_GiaoVien_HDLD_Get", colParam);            
        }

        public int Add(NS_GiaoVien_HDLDInfo pNS_GiaoVien_HDLDInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_GiaoVien_HDLDInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDHinhThucHDLD",SqlDbType.NVarChar,pNS_GiaoVien_HDLDInfo.IDHinhThucHDLD));
            colParam.Add(CreateParam("@SoHopDong",SqlDbType.NVarChar,pNS_GiaoVien_HDLDInfo.SoHopDong));
            colParam.Add(CreateParam("@SoThangHopDong",SqlDbType.Int,pNS_GiaoVien_HDLDInfo.SoThangHopDong));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pNS_GiaoVien_HDLDInfo.GhiChu));
            colParam.Add(CreateParam("@ThoiGianBatDau",SqlDbType.DateTime,pNS_GiaoVien_HDLDInfo.ThoiGianBatDau));
            colParam.Add(CreateParam("@ThoiGianKetThuc",SqlDbType.DateTime,pNS_GiaoVien_HDLDInfo.ThoiGianKetThuc));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_GiaoVien_HDLD_Add", colParam);
        }
        
        public void Update(NS_GiaoVien_HDLDInfo pNS_GiaoVien_HDLDInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_GiaoVien_HDLDInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@IDHinhThucHDLD",SqlDbType.NVarChar,pNS_GiaoVien_HDLDInfo.IDHinhThucHDLD));
            colParam.Add(CreateParam("@SoHopDong",SqlDbType.NVarChar,pNS_GiaoVien_HDLDInfo.SoHopDong));
            colParam.Add(CreateParam("@SoThangHopDong",SqlDbType.Int,pNS_GiaoVien_HDLDInfo.SoThangHopDong));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pNS_GiaoVien_HDLDInfo.GhiChu));
            colParam.Add(CreateParam("@ThoiGianBatDau",SqlDbType.DateTime,pNS_GiaoVien_HDLDInfo.ThoiGianBatDau));
            colParam.Add(CreateParam("@ThoiGianKetThuc",SqlDbType.DateTime,pNS_GiaoVien_HDLDInfo.ThoiGianKetThuc));
            colParam.Add(CreateParam("@NS_GiaoVien_HDLDID",SqlDbType.Int,pNS_GiaoVien_HDLDInfo.NS_GiaoVien_HDLDID));

            RunProcedure("sp_NS_GiaoVien_HDLD_Update", colParam);
        }
        
        public void Delete(NS_GiaoVien_HDLDInfo pNS_GiaoVien_HDLDInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_GiaoVien_HDLDID",SqlDbType.Int,pNS_GiaoVien_HDLDInfo.NS_GiaoVien_HDLDID));

            RunProcedure("sp_NS_GiaoVien_HDLD_Delete", colParam);
        }
    }
}
