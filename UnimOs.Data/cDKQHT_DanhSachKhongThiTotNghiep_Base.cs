using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DanhSachKhongThiTotNghiep : cDBase
    {
        public DataTable Get(KQHT_DanhSachKhongThiTotNghiepInfo pKQHT_DanhSachKhongThiTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DanhSachKhongThiTotNghiepID",SqlDbType.BigInt,pKQHT_DanhSachKhongThiTotNghiepInfo.KQHT_DanhSachKhongThiTotNghiepID));

            return RunProcedureGet("sp_KQHT_DanhSachKhongThiTotNghiep_Get", colParam);            
        }

        public int Add(KQHT_DanhSachKhongThiTotNghiepInfo pKQHT_DanhSachKhongThiTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DanhSachKhongThiTotNghiepInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@LyDo",SqlDbType.NVarChar,pKQHT_DanhSachKhongThiTotNghiepInfo.LyDo));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_DanhSachKhongThiTotNghiepInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@XetVot",SqlDbType.Bit,pKQHT_DanhSachKhongThiTotNghiepInfo.XetVot));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_DanhSachKhongThiTotNghiep_Add", colParam);
        }
        
        public void Update(KQHT_DanhSachKhongThiTotNghiepInfo pKQHT_DanhSachKhongThiTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DanhSachKhongThiTotNghiepInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@LyDo",SqlDbType.NVarChar,pKQHT_DanhSachKhongThiTotNghiepInfo.LyDo));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_DanhSachKhongThiTotNghiepInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@XetVot",SqlDbType.Bit,pKQHT_DanhSachKhongThiTotNghiepInfo.XetVot));
            colParam.Add(CreateParam("@KQHT_DanhSachKhongThiTotNghiepID",SqlDbType.BigInt,pKQHT_DanhSachKhongThiTotNghiepInfo.KQHT_DanhSachKhongThiTotNghiepID));

            RunProcedure("sp_KQHT_DanhSachKhongThiTotNghiep_Update", colParam);
        }
        
        public void Delete(KQHT_DanhSachKhongThiTotNghiepInfo pKQHT_DanhSachKhongThiTotNghiepInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DanhSachKhongThiTotNghiepID",SqlDbType.BigInt,pKQHT_DanhSachKhongThiTotNghiepInfo.KQHT_DanhSachKhongThiTotNghiepID));

            RunProcedure("sp_KQHT_DanhSachKhongThiTotNghiep_Delete", colParam);
        }
    }
}
