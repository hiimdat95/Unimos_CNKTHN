using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_DanhSachDuThi : cDBase
    {
        public DataTable Get(KQHT_DanhSachDuThiInfo pKQHT_DanhSachDuThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DanhSachDuThiID",SqlDbType.BigInt,pKQHT_DanhSachDuThiInfo.KQHT_DanhSachDuThiID));

            return RunProcedureGet("sp_KQHT_DanhSachDuThi_Get", colParam);            
        }

        public int Add(KQHT_DanhSachDuThiInfo pKQHT_DanhSachDuThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_ToChucThi",SqlDbType.Int,pKQHT_DanhSachDuThiInfo.IDKQHT_ToChucThi));
            colParam.Add(CreateParam("@LanThi", SqlDbType.Int, pKQHT_DanhSachDuThiInfo.LanThi));
            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DanhSachDuThiInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_PhongHoc",SqlDbType.Int,pKQHT_DanhSachDuThiInfo.IDDM_PhongHoc));
            colParam.Add(CreateParam("@SoBaoDanh",SqlDbType.Int,pKQHT_DanhSachDuThiInfo.SoBaoDanh));
            colParam.Add(CreateParam("@SoPhach",SqlDbType.NVarChar,pKQHT_DanhSachDuThiInfo.SoPhach));
            colParam.Add(CreateParam("@TuiThiSo",SqlDbType.Int,pKQHT_DanhSachDuThiInfo.TuiThiSo));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pKQHT_DanhSachDuThiInfo.GhiChu));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_DanhSachDuThi_Add", colParam);
        }
        
        public void Update(KQHT_DanhSachDuThiInfo pKQHT_DanhSachDuThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDKQHT_ToChucThi",SqlDbType.Int,pKQHT_DanhSachDuThiInfo.IDKQHT_ToChucThi));
            colParam.Add(CreateParam("@IDSV_SinhVien",SqlDbType.Int,pKQHT_DanhSachDuThiInfo.IDSV_SinhVien));
            colParam.Add(CreateParam("@IDDM_PhongHoc",SqlDbType.Int,pKQHT_DanhSachDuThiInfo.IDDM_PhongHoc));
            colParam.Add(CreateParam("@SoBaoDanh",SqlDbType.Int,pKQHT_DanhSachDuThiInfo.SoBaoDanh));
            colParam.Add(CreateParam("@SoPhach",SqlDbType.NVarChar,pKQHT_DanhSachDuThiInfo.SoPhach));
            colParam.Add(CreateParam("@TuiThiSo",SqlDbType.Int,pKQHT_DanhSachDuThiInfo.TuiThiSo));
            colParam.Add(CreateParam("@GhiChu",SqlDbType.NVarChar,pKQHT_DanhSachDuThiInfo.GhiChu));
            colParam.Add(CreateParam("@KQHT_DanhSachDuThiID",SqlDbType.BigInt,pKQHT_DanhSachDuThiInfo.KQHT_DanhSachDuThiID));

            RunProcedure("sp_KQHT_DanhSachDuThi_Update", colParam);
        }
        
        public void Delete(KQHT_DanhSachDuThiInfo pKQHT_DanhSachDuThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_DanhSachDuThiID",SqlDbType.BigInt,pKQHT_DanhSachDuThiInfo.KQHT_DanhSachDuThiID));

            RunProcedure("sp_KQHT_DanhSachDuThi_Delete", colParam);
        }
    }
}
