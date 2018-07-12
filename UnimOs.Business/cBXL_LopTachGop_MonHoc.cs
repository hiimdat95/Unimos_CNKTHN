using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBXL_LopTachGop_MonHoc : cBBase
    {
        private cDXL_LopTachGop_MonHoc oDXL_LopTachGop_MonHoc;
        private XL_LopTachGop_MonHocInfo oXL_LopTachGop_MonHocInfo;

        public cBXL_LopTachGop_MonHoc()        
        {
            oDXL_LopTachGop_MonHoc = new cDXL_LopTachGop_MonHoc();
        }

        public DataTable Get(XL_LopTachGop_MonHocInfo pXL_LopTachGop_MonHocInfo)        
        {
            return oDXL_LopTachGop_MonHoc.Get(pXL_LopTachGop_MonHocInfo);
        }

        public int Add(XL_LopTachGop_MonHocInfo pXL_LopTachGop_MonHocInfo)
        {
			int ID = 0;
            ID = oDXL_LopTachGop_MonHoc.Add(pXL_LopTachGop_MonHocInfo);
            mErrorMessage = oDXL_LopTachGop_MonHoc.ErrorMessages;
            mErrorNumber = oDXL_LopTachGop_MonHoc.ErrorNumber;
            return ID;
        }

        public void AddMonHoc_ByLopTach(int mIDXl_MonHocTrongKyCu, int mIDDM_LopGoc, int mIDXl_MonHocTrongKy, int mIDNS_GiaoVien, int mIDDM_PhongHoc, int mCaHoc)
        {
            oDXL_LopTachGop_MonHoc.AddMonHoc_ByLopTach(mIDXl_MonHocTrongKyCu, mIDDM_LopGoc, mIDXl_MonHocTrongKy, mIDNS_GiaoVien, mIDDM_PhongHoc, mCaHoc);
            mErrorMessage = oDXL_LopTachGop_MonHoc.ErrorMessages;
            mErrorNumber = oDXL_LopTachGop_MonHoc.ErrorNumber;
        }

        public void AddMonHoc_ByLopGop(string mXL_LopTachGopIDs, int mIDDM_MonHoc, int mIDNS_GiaoVien, int mIDDM_PhongHoc, int mCaHoc)
        {
            oDXL_LopTachGop_MonHoc.AddMonHoc_ByLopGop(mXL_LopTachGopIDs, mIDDM_MonHoc, mIDNS_GiaoVien, mIDDM_PhongHoc, mCaHoc);
            mErrorMessage = oDXL_LopTachGop_MonHoc.ErrorMessages;
            mErrorNumber = oDXL_LopTachGop_MonHoc.ErrorNumber;
        }

        public void Update(XL_LopTachGop_MonHocInfo pXL_LopTachGop_MonHocInfo)
        {
            oDXL_LopTachGop_MonHoc.Update(pXL_LopTachGop_MonHocInfo);
            mErrorMessage = oDXL_LopTachGop_MonHoc.ErrorMessages;
            mErrorNumber = oDXL_LopTachGop_MonHoc.ErrorNumber;
        }
        
        public void Delete(XL_LopTachGop_MonHocInfo pXL_LopTachGop_MonHocInfo)
        {
            oDXL_LopTachGop_MonHoc.Delete(pXL_LopTachGop_MonHocInfo);
            mErrorMessage = oDXL_LopTachGop_MonHoc.ErrorMessages;
            mErrorNumber = oDXL_LopTachGop_MonHoc.ErrorNumber;
        }

        public void DeleteByLopTach(int mIDDM_LopGoc, int mIDXL_MonHocTrongKy)
        {
            oDXL_LopTachGop_MonHoc.DeleteByLopTach( mIDDM_LopGoc, mIDXL_MonHocTrongKy);
            mErrorMessage = oDXL_LopTachGop_MonHoc.ErrorMessages;
            mErrorNumber = oDXL_LopTachGop_MonHoc.ErrorNumber;
        }

        public List<XL_LopTachGop_MonHocInfo> GetList(XL_LopTachGop_MonHocInfo pXL_LopTachGop_MonHocInfo)
        {
            List<XL_LopTachGop_MonHocInfo> oXL_LopTachGop_MonHocInfoList = new List<XL_LopTachGop_MonHocInfo>();
            DataTable dtb = Get(pXL_LopTachGop_MonHocInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oXL_LopTachGop_MonHocInfo = new XL_LopTachGop_MonHocInfo();

                    oXL_LopTachGop_MonHocInfo.XL_LopTachGop_MonHocID = int.Parse(dtb.Rows[i]["XL_LopTachGop_MonHocID"].ToString());
                    oXL_LopTachGop_MonHocInfo.IDXL_LopTachGop = int.Parse(dtb.Rows[i]["IDXL_LopTachGop"].ToString());
                    oXL_LopTachGop_MonHocInfo.IDXL_MonHocTrongKy = int.Parse(dtb.Rows[i]["IDXL_MonHocTrongKy"].ToString());
                    oXL_LopTachGop_MonHocInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    oXL_LopTachGop_MonHocInfo.IDDM_PhongHoc = int.Parse(dtb.Rows[i]["IDDM_PhongHoc"].ToString());
                    oXL_LopTachGop_MonHocInfo.CaHoc = int.Parse(dtb.Rows[i]["CaHoc"].ToString());
                    
                    oXL_LopTachGop_MonHocInfoList.Add(oXL_LopTachGop_MonHocInfo);
                }
            }
            return oXL_LopTachGop_MonHocInfoList;
        }
        
        public void ToDataRow(XL_LopTachGop_MonHocInfo pXL_LopTachGop_MonHocInfo, ref DataRow dr)
        {

			dr[pXL_LopTachGop_MonHocInfo.strXL_LopTachGop_MonHocID] = pXL_LopTachGop_MonHocInfo.XL_LopTachGop_MonHocID;
			dr[pXL_LopTachGop_MonHocInfo.strIDXL_LopTachGop] = pXL_LopTachGop_MonHocInfo.IDXL_LopTachGop;
			dr[pXL_LopTachGop_MonHocInfo.strIDXL_MonHocTrongKy] = pXL_LopTachGop_MonHocInfo.IDXL_MonHocTrongKy;
			dr[pXL_LopTachGop_MonHocInfo.strIDNS_GiaoVien] = pXL_LopTachGop_MonHocInfo.IDNS_GiaoVien;
			dr[pXL_LopTachGop_MonHocInfo.strIDDM_PhongHoc] = pXL_LopTachGop_MonHocInfo.IDDM_PhongHoc;
			dr[pXL_LopTachGop_MonHocInfo.strCaHoc] = pXL_LopTachGop_MonHocInfo.CaHoc;
        }
        
        public void ToInfo(ref XL_LopTachGop_MonHocInfo pXL_LopTachGop_MonHocInfo, DataRow dr)
        {

			pXL_LopTachGop_MonHocInfo.XL_LopTachGop_MonHocID = int.Parse(dr[pXL_LopTachGop_MonHocInfo.strXL_LopTachGop_MonHocID].ToString());
			pXL_LopTachGop_MonHocInfo.IDXL_LopTachGop = int.Parse(dr[pXL_LopTachGop_MonHocInfo.strIDXL_LopTachGop].ToString());
			pXL_LopTachGop_MonHocInfo.IDXL_MonHocTrongKy = int.Parse(dr[pXL_LopTachGop_MonHocInfo.strIDXL_MonHocTrongKy].ToString());
			pXL_LopTachGop_MonHocInfo.IDNS_GiaoVien = int.Parse(dr[pXL_LopTachGop_MonHocInfo.strIDNS_GiaoVien].ToString());
			pXL_LopTachGop_MonHocInfo.IDDM_PhongHoc = int.Parse(dr[pXL_LopTachGop_MonHocInfo.strIDDM_PhongHoc].ToString());
			pXL_LopTachGop_MonHocInfo.CaHoc = int.Parse(dr[pXL_LopTachGop_MonHocInfo.strCaHoc].ToString());
        }
    }
}
