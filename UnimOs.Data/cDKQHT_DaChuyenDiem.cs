using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DaChuyenDiem : cDBase
    {
        public DataTable GetByIDMonHocTrongKy(int IDXL_MonHocTrongKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, IDXL_MonHocTrongKy));

            return RunProcedureGet("sp_KQHT_DaChuyenDiem_GetByIDMonHocTrongKy", colParam);
        }

        public int AddChuyen(KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, pKQHT_DaChuyenDiemInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@DaNhapDiemThanhPhan", SqlDbType.Bit, pKQHT_DaChuyenDiemInfo.DaNhapDiemThanhPhan));
            colParam.Add(CreateParam("@IDNS_GiaoVienChuyenDiemTP", SqlDbType.Int, pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemTP));
            colParam.Add(CreateParam("@DaNhapDiemThiL1", SqlDbType.Bit, pKQHT_DaChuyenDiemInfo.DaNhapDiemThiL1));
            colParam.Add(CreateParam("@IDNS_GiaoVienChuyenDiemThiL1", SqlDbType.Int, pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemThiL1));
            colParam.Add(CreateParam("@DaNhapDiemThiL2", SqlDbType.Bit, pKQHT_DaChuyenDiemInfo.DaNhapDiemThiL2));
            colParam.Add(CreateParam("@IDNS_GiaoVienChuyenDiemThiL2", SqlDbType.Int, pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemThiL2));
            colParam.Add(CreateParam("@DaNhapDiemThanhPhanL2", SqlDbType.Bit, pKQHT_DaChuyenDiemInfo.DaNhapDiemThanhPhanL2));
            colParam.Add(CreateParam("@IDNS_GiaoVienChuyenDiemTPL2", SqlDbType.Int, pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemTPL2));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_DaChuyenDiem_AddChuyen", colParam);
        }

        public void UpdateTrangThaiChuyen(KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, pKQHT_DaChuyenDiemInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@DaNhapDiemThanhPhan", SqlDbType.Bit, pKQHT_DaChuyenDiemInfo.DaNhapDiemThanhPhan));
            colParam.Add(CreateParam("@DaNhapDiemThiL1", SqlDbType.Bit, pKQHT_DaChuyenDiemInfo.DaNhapDiemThiL1));
            colParam.Add(CreateParam("@DaNhapDiemThanhPhanL2", SqlDbType.Bit, pKQHT_DaChuyenDiemInfo.DaNhapDiemThanhPhanL2));
            colParam.Add(CreateParam("@DaNhapDiemThiL2", SqlDbType.Bit, pKQHT_DaChuyenDiemInfo.DaNhapDiemThiL2));

            RunProcedure("sp_KQHT_DaChuyenDiem_UpdateTrangThaiChuyen", colParam);
        }
        
        public DataTable GetLichSuSuaDiem(int IDXL_MonHocTrongKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, IDXL_MonHocTrongKy));

            return RunProcedureGet("sp_KQHT_DaChuyenDiem_GetLichSuSuaDiem", colParam);
        }
    }
}
