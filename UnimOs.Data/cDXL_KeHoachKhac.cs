using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_KeHoachKhac : cDBase
    {
        public DataTable GetCombo(XL_KeHoachKhacInfo pXL_KeHoachKhacInfo)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_KeHoachKhacID", SqlDbType.Int, pXL_KeHoachKhacInfo.XL_KeHoachKhacID));

            return RunProcedureGet("sp_XL_KeHoachKhac_GetCombo", colParam);
        }
    }
}
