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
        public DataTable Get(KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DaChuyenDiemID", SqlDbType.BigInt, pKQHT_DaChuyenDiemInfo.KQHT_DaChuyenDiemID));

            return RunProcedureGet("sp_KQHT_DaChuyenDiem_Get", colParam);
        }

        public int Add(KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, pKQHT_DaChuyenDiemInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@DaNhapDiemThanhPhan", SqlDbType.Bit, pKQHT_DaChuyenDiemInfo.DaNhapDiemThanhPhan));
            colParam.Add(CreateParam("@NgayChuyenDiemThanhPhan", SqlDbType.DateTime, pKQHT_DaChuyenDiemInfo.NgayChuyenDiemThanhPhan));
            colParam.Add(CreateParam("@IDNS_GiaoVienChuyenDiemTP", SqlDbType.Int, pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemTP));
            colParam.Add(CreateParam("@DaNhapDiemThiL1", SqlDbType.Bit, pKQHT_DaChuyenDiemInfo.DaNhapDiemThiL1));
            colParam.Add(CreateParam("@NgayChuyenDiemThiL1", SqlDbType.DateTime, pKQHT_DaChuyenDiemInfo.NgayChuyenDiemThiL1));
            colParam.Add(CreateParam("@IDNS_GiaoVienChuyenDiemThiL1", SqlDbType.Int, pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemThiL1));
            colParam.Add(CreateParam("@DaNhapDiemThiL2", SqlDbType.Bit, pKQHT_DaChuyenDiemInfo.DaNhapDiemThiL2));
            colParam.Add(CreateParam("@NgayChuyenDiemThiL2", SqlDbType.DateTime, pKQHT_DaChuyenDiemInfo.NgayChuyenDiemThiL2));
            colParam.Add(CreateParam("@IDNS_GiaoVienChuyenDiemThiL2", SqlDbType.Int, pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemThiL2));
            colParam.Add(CreateParam("@DaNhapDiemThanhPhanL2", SqlDbType.Bit, pKQHT_DaChuyenDiemInfo.DaNhapDiemThanhPhanL2));
            colParam.Add(CreateParam("@NgayChuyenDiemThanhPhanL2", SqlDbType.DateTime, pKQHT_DaChuyenDiemInfo.NgayChuyenDiemThanhPhanL2));
            colParam.Add(CreateParam("@IDNS_GiaoVienChuyenDiemTPL2", SqlDbType.Int, pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemTPL2));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_DaChuyenDiem_Add", colParam);
        }

        public void Update(KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, pKQHT_DaChuyenDiemInfo.IDXL_MonHocTrongKy));
            colParam.Add(CreateParam("@DaNhapDiemThanhPhan", SqlDbType.Bit, pKQHT_DaChuyenDiemInfo.DaNhapDiemThanhPhan));
            colParam.Add(CreateParam("@NgayChuyenDiemThanhPhan", SqlDbType.DateTime, pKQHT_DaChuyenDiemInfo.NgayChuyenDiemThanhPhan));
            colParam.Add(CreateParam("@IDNS_GiaoVienChuyenDiemTP", SqlDbType.Int, pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemTP));
            colParam.Add(CreateParam("@DaNhapDiemThiL1", SqlDbType.Bit, pKQHT_DaChuyenDiemInfo.DaNhapDiemThiL1));
            colParam.Add(CreateParam("@NgayChuyenDiemThiL1", SqlDbType.DateTime, pKQHT_DaChuyenDiemInfo.NgayChuyenDiemThiL1));
            colParam.Add(CreateParam("@IDNS_GiaoVienChuyenDiemThiL1", SqlDbType.Int, pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemThiL1));
            colParam.Add(CreateParam("@DaNhapDiemThiL2", SqlDbType.Bit, pKQHT_DaChuyenDiemInfo.DaNhapDiemThiL2));
            colParam.Add(CreateParam("@NgayChuyenDiemThiL2", SqlDbType.DateTime, pKQHT_DaChuyenDiemInfo.NgayChuyenDiemThiL2));
            colParam.Add(CreateParam("@IDNS_GiaoVienChuyenDiemThiL2", SqlDbType.Int, pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemThiL2));
            colParam.Add(CreateParam("@DaNhapDiemThanhPhanL2", SqlDbType.Bit, pKQHT_DaChuyenDiemInfo.DaNhapDiemThanhPhanL2));
            colParam.Add(CreateParam("@NgayChuyenDiemThanhPhanL2", SqlDbType.DateTime, pKQHT_DaChuyenDiemInfo.NgayChuyenDiemThanhPhanL2));
            colParam.Add(CreateParam("@IDNS_GiaoVienChuyenDiemTPL2", SqlDbType.Int, pKQHT_DaChuyenDiemInfo.IDNS_GiaoVienChuyenDiemTPL2));
            colParam.Add(CreateParam("@KQHT_DaChuyenDiemID", SqlDbType.BigInt, pKQHT_DaChuyenDiemInfo.KQHT_DaChuyenDiemID));

            RunProcedure("sp_KQHT_DaChuyenDiem_Update", colParam);
        }

        public void Delete(KQHT_DaChuyenDiemInfo pKQHT_DaChuyenDiemInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DaChuyenDiemID", SqlDbType.BigInt, pKQHT_DaChuyenDiemInfo.KQHT_DaChuyenDiemID));

            RunProcedure("sp_KQHT_DaChuyenDiem_Delete", colParam);
        }
    }
}
