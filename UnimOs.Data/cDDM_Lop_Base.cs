using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_Lop : cDBase
    {
        public DataTable Get(DM_LopInfo pDM_LopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_LopID",SqlDbType.Int,pDM_LopInfo.DM_LopID));

            return RunProcedureGet("sp_DM_Lop_Get", colParam);            
        }

        public int Add(DM_LopInfo pDM_LopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenLop",SqlDbType.NVarChar,pDM_LopInfo.TenLop));
            colParam.Add(CreateParam("@IDDM_He",SqlDbType.Int,pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo",SqlDbType.Int,pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa",SqlDbType.Int,pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_Nganh",SqlDbType.Int,pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_ChuyenNganh",SqlDbType.Int,pDM_LopInfo.IDDM_ChuyenNganh));
            colParam.Add(CreateParam("@NienKhoa",SqlDbType.NVarChar,pDM_LopInfo.NienKhoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc",SqlDbType.Int,pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_DiaDiem", SqlDbType.Int, pDM_LopInfo.IDDM_DiaDiem));
            colParam.Add(CreateParam("@SoSinhVien",SqlDbType.Int,pDM_LopInfo.SoSinhVien));
            colParam.Add(CreateParam("@NgayVao",SqlDbType.DateTime,pDM_LopInfo.NgayVao));
            colParam.Add(CreateParam("@NgayRa",SqlDbType.DateTime,pDM_LopInfo.NgayRa));
            colParam.Add(CreateParam("@DaRaTruong",SqlDbType.Bit,pDM_LopInfo.DaRaTruong));
            colParam.Add(CreateParam("@IDDM_TruongLienKet",SqlDbType.Int,pDM_LopInfo.IDDM_TruongLienKet));
            colParam.Add(CreateParam("@XepThoiKhoaBieu",SqlDbType.Bit,pDM_LopInfo.XepThoiKhoaBieu));
            colParam.Add(CreateParam("@KieuLopTachGop",SqlDbType.Int,pDM_LopInfo.KieuLopTachGop));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_Lop_Add", colParam);
        }
        
        public void Update(DM_LopInfo pDM_LopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@TenLop",SqlDbType.NVarChar,pDM_LopInfo.TenLop));
            colParam.Add(CreateParam("@IDDM_He",SqlDbType.Int,pDM_LopInfo.IDDM_He));
            colParam.Add(CreateParam("@IDDM_TrinhDo",SqlDbType.Int,pDM_LopInfo.IDDM_TrinhDo));
            colParam.Add(CreateParam("@IDDM_Khoa",SqlDbType.Int,pDM_LopInfo.IDDM_Khoa));
            colParam.Add(CreateParam("@IDDM_Nganh",SqlDbType.Int,pDM_LopInfo.IDDM_Nganh));
            colParam.Add(CreateParam("@IDDM_ChuyenNganh",SqlDbType.Int,pDM_LopInfo.IDDM_ChuyenNganh));
            colParam.Add(CreateParam("@NienKhoa",SqlDbType.NVarChar,pDM_LopInfo.NienKhoa));
            colParam.Add(CreateParam("@IDDM_KhoaHoc",SqlDbType.Int,pDM_LopInfo.IDDM_KhoaHoc));
            colParam.Add(CreateParam("@IDDM_DiaDiem", SqlDbType.Int, pDM_LopInfo.IDDM_DiaDiem));
            colParam.Add(CreateParam("@SoSinhVien",SqlDbType.Int,pDM_LopInfo.SoSinhVien));
            colParam.Add(CreateParam("@NgayVao",SqlDbType.DateTime,pDM_LopInfo.NgayVao));
            colParam.Add(CreateParam("@NgayRa",SqlDbType.DateTime,pDM_LopInfo.NgayRa));
            colParam.Add(CreateParam("@DaRaTruong",SqlDbType.Bit,pDM_LopInfo.DaRaTruong));
            colParam.Add(CreateParam("@IDDM_TruongLienKet",SqlDbType.Int,pDM_LopInfo.IDDM_TruongLienKet));
            colParam.Add(CreateParam("@XepThoiKhoaBieu",SqlDbType.Bit,pDM_LopInfo.XepThoiKhoaBieu));
            colParam.Add(CreateParam("@KieuLopTachGop",SqlDbType.Int,pDM_LopInfo.KieuLopTachGop));
            colParam.Add(CreateParam("@DM_LopID",SqlDbType.Int,pDM_LopInfo.DM_LopID));

            RunProcedure("sp_DM_Lop_Update", colParam);
        }
        
        public void Delete(DM_LopInfo pDM_LopInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_LopID",SqlDbType.Int,pDM_LopInfo.DM_LopID));

            RunProcedure("sp_DM_Lop_Delete", colParam);
        }
    }
}
