using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDKQHT_ToChucThi : cDBase
    {
        public DataTable Get(KQHT_ToChucThiInfo pKQHT_ToChucThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_ToChucThiID",SqlDbType.Int,pKQHT_ToChucThiInfo.KQHT_ToChucThiID));

            return RunProcedureGet("sp_KQHT_ToChucThi_Get", colParam);            
        }

        public int Add(KQHT_ToChucThiInfo pKQHT_ToChucThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_ToChucThiInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_ToChucThiInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_ToChucThiInfo.HocKy));
            colParam.Add(CreateParam("@LanThi",SqlDbType.Int,pKQHT_ToChucThiInfo.LanThi));
            colParam.Add(CreateParam("@DotThi",SqlDbType.Int,pKQHT_ToChucThiInfo.DotThi));
            colParam.Add(CreateParam("@NgayThi",SqlDbType.DateTime,pKQHT_ToChucThiInfo.NgayThi));
            colParam.Add(CreateParam("@CaThi",SqlDbType.Int,pKQHT_ToChucThiInfo.CaThi));
            colParam.Add(CreateParam("@NhomTiet",SqlDbType.Int,pKQHT_ToChucThiInfo.NhomTiet));
            colParam.Add(CreateParam("@IDHT_User",SqlDbType.Int,pKQHT_ToChucThiInfo.IDHT_User));
            colParam.Add(CreateParam("@DongTui",SqlDbType.Bit,pKQHT_ToChucThiInfo.DongTui));
            colParam.Add(CreateParam("@TotNghiep",SqlDbType.Bit,pKQHT_ToChucThiInfo.TotNghiep));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_KQHT_ToChucThi_Add", colParam);
        }
        
        public void Update(KQHT_ToChucThiInfo pKQHT_ToChucThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_MonHoc",SqlDbType.Int,pKQHT_ToChucThiInfo.IDDM_MonHoc));
            colParam.Add(CreateParam("@IDDM_NamHoc",SqlDbType.Int,pKQHT_ToChucThiInfo.IDDM_NamHoc));
            colParam.Add(CreateParam("@HocKy",SqlDbType.Int,pKQHT_ToChucThiInfo.HocKy));
            colParam.Add(CreateParam("@LanThi",SqlDbType.Int,pKQHT_ToChucThiInfo.LanThi));
            colParam.Add(CreateParam("@DotThi",SqlDbType.Int,pKQHT_ToChucThiInfo.DotThi));
            colParam.Add(CreateParam("@NgayThi",SqlDbType.DateTime,pKQHT_ToChucThiInfo.NgayThi));
            colParam.Add(CreateParam("@CaThi",SqlDbType.Int,pKQHT_ToChucThiInfo.CaThi));
            colParam.Add(CreateParam("@NhomTiet",SqlDbType.Int,pKQHT_ToChucThiInfo.NhomTiet));
            colParam.Add(CreateParam("@IDHT_User",SqlDbType.Int,pKQHT_ToChucThiInfo.IDHT_User));
            colParam.Add(CreateParam("@DongTui",SqlDbType.Bit,pKQHT_ToChucThiInfo.DongTui));
            colParam.Add(CreateParam("@TotNghiep",SqlDbType.Bit,pKQHT_ToChucThiInfo.TotNghiep));
            colParam.Add(CreateParam("@KQHT_ToChucThiID",SqlDbType.Int,pKQHT_ToChucThiInfo.KQHT_ToChucThiID));

            RunProcedure("sp_KQHT_ToChucThi_Update", colParam);
        }
        
        public void Delete(KQHT_ToChucThiInfo pKQHT_ToChucThiInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@KQHT_ToChucThiID",SqlDbType.Int,pKQHT_ToChucThiInfo.KQHT_ToChucThiID));

            RunProcedure("sp_KQHT_ToChucThi_Delete", colParam);
        }
    }
}
