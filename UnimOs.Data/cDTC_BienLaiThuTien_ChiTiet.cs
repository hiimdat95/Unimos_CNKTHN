using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDTC_BienLaiThuTien_ChiTiet : cDBase
    {
        public DataTable GetBySinhVien(int IDSV_SinhVien, int IDTC_LoaiThuChi, int IDDM_NamHoc, int HocKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien", SqlDbType.Int, IDSV_SinhVien));
            colParam.Add(CreateParam("@IDTC_LoaiThuChi", SqlDbType.Int, IDTC_LoaiThuChi));
            colParam.Add(CreateParam("@IDDM_NamHoc", SqlDbType.Int, IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy", SqlDbType.Int, HocKy));

            return RunProcedureGet("sp_TC_BienLaiThuTien_ChiTiet_GetBySinhVien", colParam);
        }
        public void DeleteBy_BienLaiThuTien(int IDTC_BienLaiThuTien)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDTC_BienLaiThuTien", SqlDbType.Int, IDTC_BienLaiThuTien));

            RunProcedure("sp_TC_BienLaiThuTien_ChiTiet_DeleteBy_BienLaiThuTien", colParam);
        }
    }
}
