using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DanhSachHocTiep : cDBase
    {
        public DataTable Get(KQHT_DanhSachHocTiepInfo pKQHT_DanhSachHocTiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DanhSachHocTiepID",SqlDbType.Int,pKQHT_DanhSachHocTiepInfo.KQHT_DanhSachHocTiepID));

            return RunProcedureGet("sp_KQHT_DanhSachHocTiep_Get", colParam);            
        }

        public int Add(KQHT_DanhSachHocTiepInfo pKQHT_DanhSachHocTiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_DanhSachNgungHoc",SqlDbType.Int,pKQHT_DanhSachHocTiepInfo.IDKQHT_DanhSachNgungHoc));
            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DanhSachHocTiepInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@Hocky",SqlDbType.Int,pKQHT_DanhSachHocTiepInfo.Hocky));
            colParam.Add(CreateParam("@IDDM_Namhoc",SqlDbType.Int,pKQHT_DanhSachHocTiepInfo.IDDM_Namhoc));
            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pKQHT_DanhSachHocTiepInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayQuyetDinh",SqlDbType.DateTime,pKQHT_DanhSachHocTiepInfo.NgayQuyetDinh));
            colParam.Add(CreateParam("@Lydo",SqlDbType.NVarChar,pKQHT_DanhSachHocTiepInfo.Lydo));
            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pKQHT_DanhSachHocTiepInfo.IDDM_Lop));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_DanhSachHocTiep_Add", colParam);
        }
        
        public void Update(KQHT_DanhSachHocTiepInfo pKQHT_DanhSachHocTiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_DanhSachNgungHoc",SqlDbType.Int,pKQHT_DanhSachHocTiepInfo.IDKQHT_DanhSachNgungHoc));
            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DanhSachHocTiepInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@Hocky",SqlDbType.Int,pKQHT_DanhSachHocTiepInfo.Hocky));
            colParam.Add(CreateParam("@IDDM_Namhoc",SqlDbType.Int,pKQHT_DanhSachHocTiepInfo.IDDM_Namhoc));
            colParam.Add(CreateParam("@SoQuyetDinh",SqlDbType.NVarChar,pKQHT_DanhSachHocTiepInfo.SoQuyetDinh));
            colParam.Add(CreateParam("@NgayQuyetDinh",SqlDbType.DateTime,pKQHT_DanhSachHocTiepInfo.NgayQuyetDinh));
            colParam.Add(CreateParam("@Lydo",SqlDbType.NVarChar,pKQHT_DanhSachHocTiepInfo.Lydo));
            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pKQHT_DanhSachHocTiepInfo.IDDM_Lop));
            colParam.Add(CreateParam("@KQHT_DanhSachHocTiepID",SqlDbType.Int,pKQHT_DanhSachHocTiepInfo.KQHT_DanhSachHocTiepID));

            RunProcedure("sp_KQHT_DanhSachHocTiep_Update", colParam);
        }
        
        public void Delete(KQHT_DanhSachHocTiepInfo pKQHT_DanhSachHocTiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DanhSachHocTiepID",SqlDbType.Int,pKQHT_DanhSachHocTiepInfo.KQHT_DanhSachHocTiepID));

            RunProcedure("sp_KQHT_DanhSachHocTiep_Delete", colParam);
        }
    }
}
