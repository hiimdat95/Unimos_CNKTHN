using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDDM_TinhHuyenXa : cDBase
    {
        public DataTable GetTree()
        {
            ArrayList colParam = new ArrayList();

            return RunProcedureGet("sp_DM_TinhHuyenXa_GetTree", colParam);
        }

        public DataTable GetByCap(int Level, int ParentID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Level", SqlDbType.Int, Level));
            colParam.Add(CreateParam("@ParentID", SqlDbType.Int, ParentID));

            return RunProcedureGet("sp_DM_TinhHuyenXa_GetByCap", colParam);
        }

        public DataTable GetTinh(int DM_TinhHuyenXaID)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@DM_TinhHuyenXaID", SqlDbType.Int, DM_TinhHuyenXaID));

            return RunProcedureGet("sp_DM_TinhHuyenXa_GetTinh", colParam);
        }

        public string CheckExistByMa(string Mas)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Mas", SqlDbType.NVarChar, Mas));
            colParam.Add(CreateParamOut("@ExistMas", SqlDbType.NVarChar, 4000));

            return (string)RunProcedureOut("sp_DM_TinhHuyenXa_CheckExistByMa", colParam, "ExistMas");
        }

        public int AddByImport(DM_TinhHuyenXaInfo pDM_TinhHuyenXaInfo, string MaCha)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@Ma", SqlDbType.NVarChar, pDM_TinhHuyenXaInfo.Ma));
            colParam.Add(CreateParam("@Ten", SqlDbType.NVarChar, pDM_TinhHuyenXaInfo.Ten));
            colParam.Add(CreateParam("@MaCha", SqlDbType.NVarChar, MaCha));
            colParam.Add(CreateParamOut("@ID", SqlDbType.Int));

            return (int)RunProcedureOut("sp_DM_TinhHuyenXa_AddByImport", colParam);
        }
    }
}
