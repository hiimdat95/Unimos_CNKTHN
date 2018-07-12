using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_QuaTrinhBoiDuong : cDBase
    {
        public DataTable Get(NS_QuaTrinhBoiDuongInfo pNS_QuaTrinhBoiDuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_QuaTrinhBoiDuongID",SqlDbType.Int,pNS_QuaTrinhBoiDuongInfo.NS_QuaTrinhBoiDuongID));

            return RunProcedureGet("sp_NS_QuaTrinhBoiDuong_Get", colParam);            
        }

        public int Add(NS_QuaTrinhBoiDuongInfo pNS_QuaTrinhBoiDuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_QuaTrinhBoiDuongInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@NoiBoiDuong",SqlDbType.NVarChar,pNS_QuaTrinhBoiDuongInfo.NoiBoiDuong));
            colParam.Add(CreateParam("@NoiDungBoiDuong",SqlDbType.NVarChar,pNS_QuaTrinhBoiDuongInfo.NoiDungBoiDuong));
            colParam.Add(CreateParam("@TuNgay",SqlDbType.DateTime,pNS_QuaTrinhBoiDuongInfo.TuNgay));
            colParam.Add(CreateParam("@DenNgay",SqlDbType.DateTime,pNS_QuaTrinhBoiDuongInfo.DenNgay));
            colParam.Add(CreateParam("@IDDM_VanBangChungChi",SqlDbType.Int,pNS_QuaTrinhBoiDuongInfo.IDDM_VanBangChungChi));
            colParam.Add(CreateParam("@IDDM_XepLoaiChungChi",SqlDbType.Int,pNS_QuaTrinhBoiDuongInfo.IDDM_XepLoaiChungChi));
            colParam.Add(CreateParam("@IDDM_HinhThucDaoTao",SqlDbType.Int,pNS_QuaTrinhBoiDuongInfo.IDDM_HinhThucDaoTao));
            colParam.Add(CreateParam("@CoThoiHan",SqlDbType.Bit,pNS_QuaTrinhBoiDuongInfo.CoThoiHan));
            colParam.Add(CreateParam("@ThoiHanTuNgay",SqlDbType.DateTime,pNS_QuaTrinhBoiDuongInfo.ThoiHanTuNgay));
            colParam.Add(CreateParam("@ThoiHanDenNgay",SqlDbType.DateTime,pNS_QuaTrinhBoiDuongInfo.ThoiHanDenNgay));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_QuaTrinhBoiDuong_Add", colParam);
        }
        
        public void Update(NS_QuaTrinhBoiDuongInfo pNS_QuaTrinhBoiDuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien",SqlDbType.Int,pNS_QuaTrinhBoiDuongInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@NoiBoiDuong",SqlDbType.NVarChar,pNS_QuaTrinhBoiDuongInfo.NoiBoiDuong));
            colParam.Add(CreateParam("@NoiDungBoiDuong",SqlDbType.NVarChar,pNS_QuaTrinhBoiDuongInfo.NoiDungBoiDuong));
            colParam.Add(CreateParam("@TuNgay",SqlDbType.DateTime,pNS_QuaTrinhBoiDuongInfo.TuNgay));
            colParam.Add(CreateParam("@DenNgay",SqlDbType.DateTime,pNS_QuaTrinhBoiDuongInfo.DenNgay));
            colParam.Add(CreateParam("@IDDM_VanBangChungChi",SqlDbType.Int,pNS_QuaTrinhBoiDuongInfo.IDDM_VanBangChungChi));
            colParam.Add(CreateParam("@IDDM_XepLoaiChungChi",SqlDbType.Int,pNS_QuaTrinhBoiDuongInfo.IDDM_XepLoaiChungChi));
            colParam.Add(CreateParam("@IDDM_HinhThucDaoTao",SqlDbType.Int,pNS_QuaTrinhBoiDuongInfo.IDDM_HinhThucDaoTao));
            colParam.Add(CreateParam("@CoThoiHan",SqlDbType.Bit,pNS_QuaTrinhBoiDuongInfo.CoThoiHan));
            colParam.Add(CreateParam("@ThoiHanTuNgay",SqlDbType.DateTime,pNS_QuaTrinhBoiDuongInfo.ThoiHanTuNgay));
            colParam.Add(CreateParam("@ThoiHanDenNgay",SqlDbType.DateTime,pNS_QuaTrinhBoiDuongInfo.ThoiHanDenNgay));
            colParam.Add(CreateParam("@NS_QuaTrinhBoiDuongID",SqlDbType.Int,pNS_QuaTrinhBoiDuongInfo.NS_QuaTrinhBoiDuongID));

            RunProcedure("sp_NS_QuaTrinhBoiDuong_Update", colParam);
        }
        
        public void Delete(NS_QuaTrinhBoiDuongInfo pNS_QuaTrinhBoiDuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_QuaTrinhBoiDuongID",SqlDbType.Int,pNS_QuaTrinhBoiDuongInfo.NS_QuaTrinhBoiDuongID));

            RunProcedure("sp_NS_QuaTrinhBoiDuong_Delete", colParam);
        }
    }
}
