using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBXL_LopTachGop : cBBase
    {
        private cDXL_LopTachGop oDXL_LopTachGop;
        private XL_LopTachGopInfo oXL_LopTachGopInfo;

        public cBXL_LopTachGop()        
        {
            oDXL_LopTachGop = new cDXL_LopTachGop();
        }

        public DataTable Get(XL_LopTachGopInfo pXL_LopTachGopInfo)        
        {
            return oDXL_LopTachGop.Get(pXL_LopTachGopInfo);
        }

        public DataTable GetByHocKyNamHoc(int HocKy, int IDDM_NamHoc, bool LopTach)
        {
            return oDXL_LopTachGop.GetByHocKyNamHoc(HocKy, IDDM_NamHoc, LopTach);
        }

        public int Add(XL_LopTachGopInfo pXL_LopTachGopInfo)
        {
			int ID = 0;
            ID = oDXL_LopTachGop.Add(pXL_LopTachGopInfo);
            mErrorMessage = oDXL_LopTachGop.ErrorMessages;
            mErrorNumber = oDXL_LopTachGop.ErrorNumber;
            return ID;
        }

        public void Update(XL_LopTachGopInfo pXL_LopTachGopInfo)
        {
            oDXL_LopTachGop.Update(pXL_LopTachGopInfo);
            mErrorMessage = oDXL_LopTachGop.ErrorMessages;
            mErrorNumber = oDXL_LopTachGop.ErrorNumber;
        }

        public void UpdateTenLopGop(string mXL_LopTachGops, string TenLopGop)
        {
            oDXL_LopTachGop.UpdateTenLopGop(mXL_LopTachGops, TenLopGop);
            mErrorMessage = oDXL_LopTachGop.ErrorMessages;
            mErrorNumber = oDXL_LopTachGop.ErrorNumber;
        }
        
        public void Delete(XL_LopTachGopInfo pXL_LopTachGopInfo)
        {
            oDXL_LopTachGop.Delete(pXL_LopTachGopInfo);
            mErrorMessage = oDXL_LopTachGop.ErrorMessages;
            mErrorNumber = oDXL_LopTachGop.ErrorNumber;
        }

        public void DeleteByLopGoc(string mXL_LopTachGopIDs)
        {
            oDXL_LopTachGop.DeleteByLopGoc(mXL_LopTachGopIDs);
            mErrorMessage = oDXL_LopTachGop.ErrorMessages;
            mErrorNumber = oDXL_LopTachGop.ErrorNumber;
        }

        public List<XL_LopTachGopInfo> GetList(XL_LopTachGopInfo pXL_LopTachGopInfo)
        {
            List<XL_LopTachGopInfo> oXL_LopTachGopInfoList = new List<XL_LopTachGopInfo>();
            DataTable dtb = Get(pXL_LopTachGopInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oXL_LopTachGopInfo = new XL_LopTachGopInfo();

                    oXL_LopTachGopInfo.XL_LopTachGopID = int.Parse(dtb.Rows[i]["XL_LopTachGopID"].ToString());
                    oXL_LopTachGopInfo.TenLopTachGop = dtb.Rows[i]["TenLopTachGop"].ToString();
                    oXL_LopTachGopInfo.SoSinhVien = int.Parse(dtb.Rows[i]["SoSinhVien"].ToString());
                    oXL_LopTachGopInfo.IDDM_LopGoc = int.Parse(dtb.Rows[i]["IDDM_LopGoc"].ToString());
                    oXL_LopTachGopInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oXL_LopTachGopInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oXL_LopTachGopInfo.LopTach = bool.Parse(dtb.Rows[i]["LopTach"].ToString());
                    oXL_LopTachGopInfo.ParentID = int.Parse(dtb.Rows[i]["ParentID"].ToString());
                    
                    oXL_LopTachGopInfoList.Add(oXL_LopTachGopInfo);
                }
            }
            return oXL_LopTachGopInfoList;
        }
        
        public void ToDataRow(XL_LopTachGopInfo pXL_LopTachGopInfo, ref DataRow dr)
        {

			dr[pXL_LopTachGopInfo.strXL_LopTachGopID] = pXL_LopTachGopInfo.XL_LopTachGopID;
			dr[pXL_LopTachGopInfo.strTenLopTachGop] = pXL_LopTachGopInfo.TenLopTachGop;
			dr[pXL_LopTachGopInfo.strSoSinhVien] = pXL_LopTachGopInfo.SoSinhVien;
			dr[pXL_LopTachGopInfo.strIDDM_LopGoc] = pXL_LopTachGopInfo.IDDM_LopGoc;
			dr[pXL_LopTachGopInfo.strIDDM_NamHoc] = pXL_LopTachGopInfo.IDDM_NamHoc;
			dr[pXL_LopTachGopInfo.strHocKy] = pXL_LopTachGopInfo.HocKy;
			dr[pXL_LopTachGopInfo.strLopTach] = pXL_LopTachGopInfo.LopTach;
			dr[pXL_LopTachGopInfo.strParentID] = pXL_LopTachGopInfo.ParentID;
        }
        
        public void ToInfo(ref XL_LopTachGopInfo pXL_LopTachGopInfo, DataRow dr)
        {

			pXL_LopTachGopInfo.XL_LopTachGopID = int.Parse(dr[pXL_LopTachGopInfo.strXL_LopTachGopID].ToString());
			pXL_LopTachGopInfo.TenLopTachGop = dr[pXL_LopTachGopInfo.strTenLopTachGop].ToString();
			pXL_LopTachGopInfo.SoSinhVien = int.Parse(dr[pXL_LopTachGopInfo.strSoSinhVien].ToString());
			pXL_LopTachGopInfo.IDDM_LopGoc = int.Parse(dr[pXL_LopTachGopInfo.strIDDM_LopGoc].ToString());
			pXL_LopTachGopInfo.IDDM_NamHoc = int.Parse(dr[pXL_LopTachGopInfo.strIDDM_NamHoc].ToString());
			pXL_LopTachGopInfo.HocKy = int.Parse(dr[pXL_LopTachGopInfo.strHocKy].ToString());
			pXL_LopTachGopInfo.LopTach = bool.Parse(dr[pXL_LopTachGopInfo.strLopTach].ToString());
			pXL_LopTachGopInfo.ParentID = int.Parse(dr[pXL_LopTachGopInfo.strParentID].ToString());
        }
    }
}
