using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDHT_ThamSoHeThong : cDBase
    {
        public DataTable Get(HT_ThamSoHeThongInfo pHT_ThamSoHeThongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_ThamSoHeThongID",SqlDbType.Int,pHT_ThamSoHeThongInfo.HT_ThamSoHeThongID));

            return RunProcedureGet("sp_HT_ThamSoHeThong_Get", colParam);            
        }

        public int Add(HT_ThamSoHeThongInfo pHT_ThamSoHeThongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaThamSoHeThong",SqlDbType.NVarChar,pHT_ThamSoHeThongInfo.MaThamSoHeThong));
            colParam.Add(CreateParam("@TenThamSoHeThong",SqlDbType.NVarChar,pHT_ThamSoHeThongInfo.TenThamSoHeThong));
            colParam.Add(CreateParam("@IDDM_He",SqlDbType.Int,pHT_ThamSoHeThongInfo.IDDM_He));
            colParam.Add(CreateParam("@PhanHe",SqlDbType.Int,pHT_ThamSoHeThongInfo.PhanHe));
            colParam.Add(CreateParam("@GiaTri",SqlDbType.NVarChar,pHT_ThamSoHeThongInfo.GiaTri));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pHT_ThamSoHeThongInfo.GhiChu));
            colParam.Add(CreateParam("@TrangThai",SqlDbType.Bit,pHT_ThamSoHeThongInfo.TrangThai));
            colParam.Add(CreateParam("@SapXep",SqlDbType.Int,pHT_ThamSoHeThongInfo.SapXep));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_HT_ThamSoHeThong_Add", colParam);
        }
        
        public void Update(HT_ThamSoHeThongInfo pHT_ThamSoHeThongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@MaThamSoHeThong",SqlDbType.NVarChar,pHT_ThamSoHeThongInfo.MaThamSoHeThong));
            colParam.Add(CreateParam("@TenThamSoHeThong",SqlDbType.NVarChar,pHT_ThamSoHeThongInfo.TenThamSoHeThong));
            colParam.Add(CreateParam("@IDDM_He",SqlDbType.Int,pHT_ThamSoHeThongInfo.IDDM_He));
            colParam.Add(CreateParam("@PhanHe",SqlDbType.Int,pHT_ThamSoHeThongInfo.PhanHe));
            colParam.Add(CreateParam("@GiaTri",SqlDbType.NVarChar,pHT_ThamSoHeThongInfo.GiaTri));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pHT_ThamSoHeThongInfo.GhiChu));
            colParam.Add(CreateParam("@TrangThai",SqlDbType.Bit,pHT_ThamSoHeThongInfo.TrangThai));
            colParam.Add(CreateParam("@SapXep",SqlDbType.Int,pHT_ThamSoHeThongInfo.SapXep));
            colParam.Add(CreateParam("@HT_ThamSoHeThongID",SqlDbType.Int,pHT_ThamSoHeThongInfo.HT_ThamSoHeThongID));

            RunProcedure("sp_HT_ThamSoHeThong_Update", colParam);
        }
        
        public void Delete(HT_ThamSoHeThongInfo pHT_ThamSoHeThongInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@HT_ThamSoHeThongID",SqlDbType.Int,pHT_ThamSoHeThongInfo.HT_ThamSoHeThongID));

            RunProcedure("sp_HT_ThamSoHeThong_Delete", colParam);
        }
    }
}
