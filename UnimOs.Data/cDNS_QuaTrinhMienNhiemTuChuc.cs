using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDNS_QuaTrinhMienNhiemTuChuc : cDBase
    {
        public DataTable GetBy_IDNS_GiaoVien(int IDNS_GiaoVien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, IDNS_GiaoVien));

            return RunProcedureGet("sp_NS_QuaTrinhMienNhiemTuChuc_GetBy_IDNS_GiaoVien", colParam);
        }

        public int Add_QuaTrinhBoNhiemChucVu(NS_QuaTrinhMienNhiemTuChucInfo pNS_QuaTrinhMienNhiemTuChucInfo, int NS_QuaTrinhBoNhiemChucVuID1)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, pNS_QuaTrinhMienNhiemTuChucInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoQuyetDinh", SqlDbType.NVarChar, pNS_QuaTrinhMienNhiemTuChucInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayRaQuyetDinh", SqlDbType.DateTime, pNS_QuaTrinhMienNhiemTuChucInfo.NgayRaQuyetDinh));
            colParam.Add(CreateParam("@NgayCoHieuLuc", SqlDbType.DateTime, pNS_QuaTrinhMienNhiemTuChucInfo.NgayCoHieuLuc));
            colParam.Add(CreateParam("@IDDM_CapQuyetDinh", SqlDbType.Int, pNS_QuaTrinhMienNhiemTuChucInfo.IDDM_CapQuyetDinh));
            colParam.Add(CreateParam("@NS_QuaTrinhBoNhiemChucVuID1", SqlDbType.Int, NS_QuaTrinhBoNhiemChucVuID1));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_NS_QuaTrinhMienNhiemTuChuc_Add_QuaTrinhBoNhiemChucVu", colParam);
        }

        public void Update_QuaTrinhBoNhiem(NS_QuaTrinhMienNhiemTuChucInfo pNS_QuaTrinhMienNhiemTuChucInfo, int NS_QuaTrinhBoNhiemChucVuID, int NS_QuaTrinhBoNhiemChucVuID1)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, pNS_QuaTrinhMienNhiemTuChucInfo.IDNS_GiaoVien));
            colParam.Add(CreateParam("@SoQuyetDinh", SqlDbType.NVarChar, pNS_QuaTrinhMienNhiemTuChucInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayRaQuyetDinh", SqlDbType.DateTime, pNS_QuaTrinhMienNhiemTuChucInfo.NgayRaQuyetDinh));
            colParam.Add(CreateParam("@NgayCoHieuLuc", SqlDbType.DateTime, pNS_QuaTrinhMienNhiemTuChucInfo.NgayCoHieuLuc));
            colParam.Add(CreateParam("@IDDM_CapQuyetDinh", SqlDbType.Int, pNS_QuaTrinhMienNhiemTuChucInfo.IDDM_CapQuyetDinh));
            colParam.Add(CreateParam("@NS_QuaTrinhMienNhiemTuChucID", SqlDbType.Int, pNS_QuaTrinhMienNhiemTuChucInfo.NS_QuaTrinhMienNhiemTuChucID));
            colParam.Add(CreateParam("@NS_QuaTrinhBoNhiemChucVuID", SqlDbType.Int, NS_QuaTrinhBoNhiemChucVuID));
            colParam.Add(CreateParam("@NS_QuaTrinhBoNhiemChucVuID1", SqlDbType.Int, NS_QuaTrinhBoNhiemChucVuID1));

            RunProcedure("sp_NS_QuaTrinhMienNhiemTuChuc_Update_QuaTrinhBoNhiem", colParam);
        }

        public void Delete_QuaTrinhBoNhiemChucVu(NS_QuaTrinhMienNhiemTuChucInfo pNS_QuaTrinhMienNhiemTuChucInfo, int NS_QuaTrinhBoNhiemChucVuID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@NS_QuaTrinhMienNhiemTuChucID", SqlDbType.Int, pNS_QuaTrinhMienNhiemTuChucInfo.NS_QuaTrinhMienNhiemTuChucID));
            colParam.Add(CreateParam("@NS_QuaTrinhBoNhiemChucVuID", SqlDbType.Int, NS_QuaTrinhBoNhiemChucVuID));

            RunProcedure("sp_NS_QuaTrinhMienNhiemTuChuc_Delete_QuaTrinhBoNhiemChucVu", colParam);
        }
    }
}
