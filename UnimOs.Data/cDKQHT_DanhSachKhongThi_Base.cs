using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DanhSachKhongThi : cDBase
    {
        public DataTable Get(KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DanhSachKhongThiID",SqlDbType.Int,pKQHT_DanhSachKhongThiInfo.KQHT_DanhSachKhongThiID));

            return RunProcedureGet("sp_KQHT_DanhSachKhongThi_Get", colParam);            
        }

        public int Add(KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DanhSachKhongThiInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_DanhSachKhongThiInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_DanhSachKhongThiInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_DanhSachKhongThiInfo.HocKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, pKQHT_DanhSachKhongThiInfo.LanThi));
            colParam.Add(CreateParam("@LyDo",SqlDbType.NVarChar,pKQHT_DanhSachKhongThiInfo.LyDo));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_DanhSachKhongThi_Add", colParam);
        }
        
        public void Update(KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DanhSachKhongThiInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_DanhSachKhongThiInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_DanhSachKhongThiInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_DanhSachKhongThiInfo.HocKy));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, pKQHT_DanhSachKhongThiInfo.LanThi));
            colParam.Add(CreateParam("@LyDo",SqlDbType.NVarChar,pKQHT_DanhSachKhongThiInfo.LyDo));
            colParam.Add(CreateParam("@KQHT_DanhSachKhongThiID",SqlDbType.Int,pKQHT_DanhSachKhongThiInfo.KQHT_DanhSachKhongThiID));

            RunProcedure("sp_KQHT_DanhSachKhongThi_Update", colParam);
        }
        
        public void Delete(KQHT_DanhSachKhongThiInfo pKQHT_DanhSachKhongThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DanhSachKhongThiID",SqlDbType.Int,pKQHT_DanhSachKhongThiInfo.KQHT_DanhSachKhongThiID));

            RunProcedure("sp_KQHT_DanhSachKhongThi_Delete", colParam);
        }
    }
}
