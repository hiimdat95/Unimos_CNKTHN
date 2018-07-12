using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_Luong : cDBase
    {
        public DataTable GetBy_IDNS_GiaoVien(int IDNS_GiaoVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));

            return RunProcedureGet("sp_NS_Luong_GetBy_IDNS_GiaoVien", colParam);
        }
        public int Add_InfoFull(NS_LuongInfo pNS_LuongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, pNS_LuongInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@CongViecDamNhiem", SqlDbType.NVarChar, pNS_LuongInfo.CongViecDamNhiem));
            colParam.Add(CreateParam("@IDNS_NgachCongChuc", SqlDbType.Int, pNS_LuongInfo.IDNS_NgachCongChuc));
            colParam.Add(CreateParam("@BacLuong", SqlDbType.Int, pNS_LuongInfo.BacLuong));
            colParam.Add(CreateParam("@HeSoLuong", SqlDbType.Float, pNS_LuongInfo.HeSoLuong));
            colParam.Add(CreateParam("@PhanTramHuong", SqlDbType.Float, pNS_LuongInfo.PhanTramHuong));
            colParam.Add(CreateParam("@TuNgay", SqlDbType.DateTime, pNS_LuongInfo.TuNgay));
            colParam.Add(CreateParam("@DenNgay", SqlDbType.DateTime, pNS_LuongInfo.DenNgay));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_Luong_Add_InfoFull", colParam);
        }

        public DataTable Get_BangLuong(DateTime TinhDenNgay)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TinhDenNgay", SqlDbType.DateTime, TinhDenNgay));

            return RunProcedureGet("sp_NS_Luong_Get_BangLuong", colParam);
        }

        public DataTable Get_CanhBaoHanNangLuong(int HanCanhBao, DateTime TinhDenNgay)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HanCanhBao", SqlDbType.Int, HanCanhBao));
            colParam.Add(CreateParam("@TinhDenNgay", SqlDbType.DateTime, TinhDenNgay));

            return RunProcedureGet("sp_NS_Luong_Get_CanhBaoHanNangLuong", colParam);
        }

        public DataTable GetBy_NS_SoQuyetDinhID(int NS_SoQuyetDinhID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_SoQuyetDinhID", SqlDbType.Int, NS_SoQuyetDinhID));

            return RunProcedureGet("sp_NS_Luong_GetBy_NS_SoQuyetDinhID", colParam);
        }

        public void Delete_NS_SoQuyetDinhID(int NS_SoQuyetDinhID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_SoQuyetDinhID", SqlDbType.Int, NS_SoQuyetDinhID));

            RunProcedure("sp_NS_Luong_SoQuyetDinh_Delete_NS_SoQuyetDinhID", colParam);
        }

        public DataTable GetSoLuongCongChuc(DateTime DenNgay)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DenNgay", SqlDbType.DateTime, DenNgay));

            return RunProcedureGet("sp_NS_NgachCongChuc_GetSoLuongCongChuc", colParam);
        }
    }
}
