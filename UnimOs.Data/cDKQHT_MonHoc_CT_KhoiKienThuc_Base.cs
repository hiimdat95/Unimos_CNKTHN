using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_MonHoc_CT_KhoiKienThuc : cDBase
    {
        public DataTable Get(KQHT_MonHoc_CT_KhoiKienThucInfo pKQHT_MonHoc_CT_KhoiKienThucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_MonHoc_CT_KhoiKienThucID",SqlDbType.Int,pKQHT_MonHoc_CT_KhoiKienThucInfo.KQHT_MonHoc_CT_KhoiKienThucID));

            return RunProcedureGet("sp_KQHT_MonHoc_CT_KhoiKienThuc_Get", colParam);            
        }

        public int Add(KQHT_MonHoc_CT_KhoiKienThucInfo pKQHT_MonHoc_CT_KhoiKienThucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_CT_KhoiKienThuc",SqlDbType.Int,pKQHT_MonHoc_CT_KhoiKienThucInfo.IDKQHT_CT_KhoiKienThuc));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_MonHoc_CT_KhoiKienThucInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@SoHocTrinh",SqlDbType.Real,pKQHT_MonHoc_CT_KhoiKienThucInfo.SoHocTrinh));
            colParam.Add(CreateParam("@SoTiet",SqlDbType.Int,pKQHT_MonHoc_CT_KhoiKienThucInfo.SoTiet));
            colParam.Add(CreateParam("@LyThuyet",SqlDbType.Int,pKQHT_MonHoc_CT_KhoiKienThucInfo.LyThuyet));
            colParam.Add(CreateParam("@ThucHanh",SqlDbType.Int,pKQHT_MonHoc_CT_KhoiKienThucInfo.ThucHanh));
            colParam.Add(CreateParam("@LoaiTietKhac1",SqlDbType.Int,pKQHT_MonHoc_CT_KhoiKienThucInfo.LoaiTietKhac1));
            colParam.Add(CreateParam("@LoaiTietKhac2",SqlDbType.Int,pKQHT_MonHoc_CT_KhoiKienThucInfo.LoaiTietKhac2));
            colParam.Add(CreateParam("@ChoPhepXepLich",SqlDbType.Bit,pKQHT_MonHoc_CT_KhoiKienThucInfo.ChoPhepXepLich));
            colParam.Add(CreateParam("@IDDM_HinhThucThi",SqlDbType.Int,pKQHT_MonHoc_CT_KhoiKienThucInfo.IDDM_HinhThucThi));
            colParam.Add(CreateParam("@TuChon",SqlDbType.Bit,pKQHT_MonHoc_CT_KhoiKienThucInfo.TuChon));
            colParam.Add(CreateParam("@SapXep",SqlDbType.Int,pKQHT_MonHoc_CT_KhoiKienThucInfo.SapXep));
            colParam.Add(CreateParam("@TinhDiemToanKhoa", SqlDbType.Bit, pKQHT_MonHoc_CT_KhoiKienThucInfo.TinhDiemToanKhoa));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_MonHoc_CT_KhoiKienThuc_Add", colParam);
        }
        
        public void Update(KQHT_MonHoc_CT_KhoiKienThucInfo pKQHT_MonHoc_CT_KhoiKienThucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_CT_KhoiKienThuc",SqlDbType.Int,pKQHT_MonHoc_CT_KhoiKienThucInfo.IDKQHT_CT_KhoiKienThuc));
            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_MonHoc_CT_KhoiKienThucInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@SoHocTrinh",SqlDbType.Real,pKQHT_MonHoc_CT_KhoiKienThucInfo.SoHocTrinh));
            colParam.Add(CreateParam("@SoTiet",SqlDbType.Int,pKQHT_MonHoc_CT_KhoiKienThucInfo.SoTiet));
            colParam.Add(CreateParam("@LyThuyet",SqlDbType.Int,pKQHT_MonHoc_CT_KhoiKienThucInfo.LyThuyet));
            colParam.Add(CreateParam("@ThucHanh",SqlDbType.Int,pKQHT_MonHoc_CT_KhoiKienThucInfo.ThucHanh));
            colParam.Add(CreateParam("@LoaiTietKhac1",SqlDbType.Int,pKQHT_MonHoc_CT_KhoiKienThucInfo.LoaiTietKhac1));
            colParam.Add(CreateParam("@LoaiTietKhac2",SqlDbType.Int,pKQHT_MonHoc_CT_KhoiKienThucInfo.LoaiTietKhac2));
            colParam.Add(CreateParam("@ChoPhepXepLich",SqlDbType.Bit,pKQHT_MonHoc_CT_KhoiKienThucInfo.ChoPhepXepLich));
            colParam.Add(CreateParam("@IDDM_HinhThucThi",SqlDbType.Int,pKQHT_MonHoc_CT_KhoiKienThucInfo.IDDM_HinhThucThi));
            colParam.Add(CreateParam("@TuChon",SqlDbType.Bit,pKQHT_MonHoc_CT_KhoiKienThucInfo.TuChon));
            colParam.Add(CreateParam("@SapXep",SqlDbType.Int,pKQHT_MonHoc_CT_KhoiKienThucInfo.SapXep));
            colParam.Add(CreateParam("@TinhDiemToanKhoa", SqlDbType.Bit, pKQHT_MonHoc_CT_KhoiKienThucInfo.TinhDiemToanKhoa));
            colParam.Add(CreateParam("@KQHT_MonHoc_CT_KhoiKienThucID",SqlDbType.Int,pKQHT_MonHoc_CT_KhoiKienThucInfo.KQHT_MonHoc_CT_KhoiKienThucID));

            RunProcedure("sp_KQHT_MonHoc_CT_KhoiKienThuc_Update", colParam);
        }
        
        public void Delete(KQHT_MonHoc_CT_KhoiKienThucInfo pKQHT_MonHoc_CT_KhoiKienThucInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_MonHoc_CT_KhoiKienThucID",SqlDbType.Int,pKQHT_MonHoc_CT_KhoiKienThucInfo.KQHT_MonHoc_CT_KhoiKienThucID));

            RunProcedure("sp_KQHT_MonHoc_CT_KhoiKienThuc_Delete", colParam);
        }
    }
}
