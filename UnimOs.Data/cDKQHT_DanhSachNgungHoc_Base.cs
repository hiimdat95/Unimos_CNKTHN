using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DanhSachNgungHoc : cDBase
    {
        public DataTable Get(KQHT_DanhSachNgungHocInfo pKQHT_DanhSachNgungHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DanhSachNgungHocID",SqlDbType.Int,pKQHT_DanhSachNgungHocInfo.KQHT_DanhSachNgungHocID));

            return RunProcedureGet("sp_KQHT_DanhSachNgungHoc_Get", colParam);            
        }

        public int Add(KQHT_DanhSachNgungHocInfo pKQHT_DanhSachNgungHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DanhSachNgungHocInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_DanhSachNgungHocInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_DanhSachNgungHocInfo.HocKy));
            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pKQHT_DanhSachNgungHocInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayQuyetDinh",SqlDbType.DateTime,pKQHT_DanhSachNgungHocInfo.NgayQuyetDinh));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NVarChar,pKQHT_DanhSachNgungHocInfo.NoiDung));
            colParam.Add(CreateParam("@IDDM_LopCu",SqlDbType.Int,pKQHT_DanhSachNgungHocInfo.IDDM_LopCu));
            colParam.Add(CreateParam("@TrangThai", SqlDbType.Int, pKQHT_DanhSachNgungHocInfo.TrangThai));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_DanhSachNgungHoc_Add", colParam);
        }
        
        public void Update(KQHT_DanhSachNgungHocInfo pKQHT_DanhSachNgungHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DanhSachNgungHocInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_DanhSachNgungHocInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_DanhSachNgungHocInfo.HocKy));
            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pKQHT_DanhSachNgungHocInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayQuyetDinh",SqlDbType.DateTime,pKQHT_DanhSachNgungHocInfo.NgayQuyetDinh));
            colParam.Add(CreateParam("@NoiDung",SqlDbType.NVarChar,pKQHT_DanhSachNgungHocInfo.NoiDung));
            colParam.Add(CreateParam("@IDDM_LopCu",SqlDbType.Int,pKQHT_DanhSachNgungHocInfo.IDDM_LopCu));
            colParam.Add(CreateParam("@TrangThai", SqlDbType.Int, pKQHT_DanhSachNgungHocInfo.TrangThai));
            colParam.Add(CreateParam("@KQHT_DanhSachNgungHocID",SqlDbType.Int,pKQHT_DanhSachNgungHocInfo.KQHT_DanhSachNgungHocID));

            RunProcedure("sp_KQHT_DanhSachNgungHoc_Update", colParam);
        }
        
        public void Delete(KQHT_DanhSachNgungHocInfo pKQHT_DanhSachNgungHocInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DanhSachNgungHocID",SqlDbType.Int,pKQHT_DanhSachNgungHocInfo.KQHT_DanhSachNgungHocID));

            RunProcedure("sp_KQHT_DanhSachNgungHoc_Delete", colParam);
        }
    }
}
