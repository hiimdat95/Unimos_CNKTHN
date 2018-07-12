using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_MonHocTrongKy : cDBase
    {
        public DataTable Get(XL_MonHocTrongKyInfo pXL_MonHocTrongKyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_MonHocTrongKyID",SqlDbType.Int,pXL_MonHocTrongKyInfo.XL_MonHocTrongKyID));

            return RunProcedureGet("sp_XL_MonHocTrongKy_Get", colParam);            
        }

        public int Add(XL_MonHocTrongKyInfo pXL_MonHocTrongKyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_CTDT_ChiTiet",SqlDbType.BigInt,pXL_MonHocTrongKyInfo.IDKQHT_CTDT_ChiTiet));
            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pXL_MonHocTrongKyInfo.IDDM_Lop));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pXL_MonHocTrongKyInfo.HocKy));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pXL_MonHocTrongKyInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@SoTiet",SqlDbType.Int,pXL_MonHocTrongKyInfo.SoTiet));
            colParam.Add(CreateParam("@LyThuyet",SqlDbType.Int,pXL_MonHocTrongKyInfo.LyThuyet));
            colParam.Add(CreateParam("@ThucHanh",SqlDbType.Int,pXL_MonHocTrongKyInfo.ThucHanh));
            colParam.Add(CreateParam("@LoaiTietKhac1",SqlDbType.Int,pXL_MonHocTrongKyInfo.LoaiTietKhac1));
            colParam.Add(CreateParam("@LoaiTietKhac2",SqlDbType.Int,pXL_MonHocTrongKyInfo.LoaiTietKhac2));
            colParam.Add(CreateParam("@SoHocTrinh",SqlDbType.Real,pXL_MonHocTrongKyInfo.SoHocTrinh));
            colParam.Add(CreateParam("@ChoPhepXepLich",SqlDbType.Bit,pXL_MonHocTrongKyInfo.ChoPhepXepLich));
            colParam.Add(CreateParam("@IDDM_HinhThucThi",SqlDbType.Int,pXL_MonHocTrongKyInfo.IDDM_HinhThucThi));
            colParam.Add(CreateParam("@HocOLopTachGop",SqlDbType.Bit,pXL_MonHocTrongKyInfo.HocOLopTachGop));
            colParam.Add(CreateParam("@SapXep",SqlDbType.Int,pXL_MonHocTrongKyInfo.SapXep));
            colParam.Add(CreateParam("@TinhDiemToanKhoa", SqlDbType.Bit, pXL_MonHocTrongKyInfo.TinhDiemToanKhoa));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_XL_MonHocTrongKy_Add", colParam);
        }
        
        public void Update(XL_MonHocTrongKyInfo pXL_MonHocTrongKyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_CTDT_ChiTiet",SqlDbType.BigInt,pXL_MonHocTrongKyInfo.IDKQHT_CTDT_ChiTiet));
            colParam.Add(CreateParam("@IDDM_Lop",SqlDbType.Int,pXL_MonHocTrongKyInfo.IDDM_Lop));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pXL_MonHocTrongKyInfo.HocKy));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pXL_MonHocTrongKyInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@SoTiet",SqlDbType.Int,pXL_MonHocTrongKyInfo.SoTiet));
            colParam.Add(CreateParam("@LyThuyet",SqlDbType.Int,pXL_MonHocTrongKyInfo.LyThuyet));
            colParam.Add(CreateParam("@ThucHanh",SqlDbType.Int,pXL_MonHocTrongKyInfo.ThucHanh));
            colParam.Add(CreateParam("@LoaiTietKhac1",SqlDbType.Int,pXL_MonHocTrongKyInfo.LoaiTietKhac1));
            colParam.Add(CreateParam("@LoaiTietKhac2",SqlDbType.Int,pXL_MonHocTrongKyInfo.LoaiTietKhac2));
            colParam.Add(CreateParam("@SoHocTrinh",SqlDbType.Real,pXL_MonHocTrongKyInfo.SoHocTrinh));
            colParam.Add(CreateParam("@ChoPhepXepLich",SqlDbType.Bit,pXL_MonHocTrongKyInfo.ChoPhepXepLich));
            colParam.Add(CreateParam("@IDDM_HinhThucThi",SqlDbType.Int,pXL_MonHocTrongKyInfo.IDDM_HinhThucThi));
            colParam.Add(CreateParam("@HocOLopTachGop",SqlDbType.Bit,pXL_MonHocTrongKyInfo.HocOLopTachGop));
            colParam.Add(CreateParam("@SapXep",SqlDbType.Int,pXL_MonHocTrongKyInfo.SapXep));
            colParam.Add(CreateParam("@TinhDiemToanKhoa", SqlDbType.Bit, pXL_MonHocTrongKyInfo.TinhDiemToanKhoa));
            colParam.Add(CreateParam("@XL_MonHocTrongKyID",SqlDbType.Int,pXL_MonHocTrongKyInfo.XL_MonHocTrongKyID));

            RunProcedure("sp_XL_MonHocTrongKy_Update", colParam);
        }
        
        public void Delete(XL_MonHocTrongKyInfo pXL_MonHocTrongKyInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_MonHocTrongKyID",SqlDbType.Int,pXL_MonHocTrongKyInfo.XL_MonHocTrongKyID));

            RunProcedure("sp_XL_MonHocTrongKy_Delete", colParam);
        }
    }
}
