using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Data
{
    public partial class cDXL_LopTachGop_MonHoc : cDBase
    {
        public void AddMonHoc_ByLopTach(int mIDXl_MonHocTrongKyCu, int mIDDM_LopGoc, int mIDXl_MonHocTrongKy, int mIDNS_GiaoVien, int mIDDM_PhongHoc, int mCaHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_LopGoc", SqlDbType.Int, mIDDM_LopGoc));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, mIDXl_MonHocTrongKy));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKyCu", SqlDbType.Int, mIDXl_MonHocTrongKyCu));
            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, mIDNS_GiaoVien));
            colParam.Add(CreateParam("@IDDM_PhongHoc", SqlDbType.Int,mIDDM_PhongHoc));
            colParam.Add(CreateParam("@CaHoc", SqlDbType.Int, mCaHoc));


            RunProcedure("sp_XL_LopTachGop_MonHoc_AddByLopTach", colParam);
        }

        public void AddMonHoc_ByLopGop(string mXL_LopTachGopIDs, int mIDDM_MonHoc, int mIDNS_GiaoVien, int mIDDM_PhongHoc, int mCaHoc)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@XL_LopTachGopIDs", SqlDbType.VarChar,200, mXL_LopTachGopIDs));
            colParam.Add(CreateParam("@IDDM_MonHoc", SqlDbType.Int, mIDDM_MonHoc));
            colParam.Add(CreateParam("@IDNS_GiaoVien", SqlDbType.Int, mIDNS_GiaoVien));
            colParam.Add(CreateParam("@IDDM_PhongHoc", SqlDbType.Int, mIDDM_PhongHoc));
            colParam.Add(CreateParam("@CaHoc", SqlDbType.Int, mCaHoc));


            RunProcedure("sp_XL_LopTachGop_MonHoc_AddByLopGop", colParam);
        }

        public void DeleteByLopTach(int mIDDM_LopGoc, int mIDXL_MonHocTrongKy)
        {
            ArrayList colParam = new ArrayList();

            colParam.Add(CreateParam("@IDDM_LopGoc", SqlDbType.Int, mIDDM_LopGoc));
            colParam.Add(CreateParam("@IDXL_MonHocTrongKy", SqlDbType.Int, mIDXL_MonHocTrongKy));

            RunProcedure("sp_XL_LopTachGop_MonHoc_DeleteByLopTach", colParam);
        }
    }
}
