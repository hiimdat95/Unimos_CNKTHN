using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBSV_ThangRenLuyenTrongKy : cBBase
    {
        private cDSV_ThangRenLuyenTrongKy oDSV_ThangRenLuyenTrongKy;
        private SV_ThangRenLuyenTrongKyInfo oSV_ThangRenLuyenTrongKyInfo;

        public cBSV_ThangRenLuyenTrongKy()        
        {
            oDSV_ThangRenLuyenTrongKy = new cDSV_ThangRenLuyenTrongKy();
        }

        public DataTable Get(SV_ThangRenLuyenTrongKyInfo pSV_ThangRenLuyenTrongKyInfo)        
        {
            return oDSV_ThangRenLuyenTrongKy.Get(pSV_ThangRenLuyenTrongKyInfo);
        }

        public DataTable GetByHocKyNamHoc(int IDDM_NamHoc, int HocKy)
        {
            return oDSV_ThangRenLuyenTrongKy.GetByHocKyNamHoc(IDDM_NamHoc, HocKy);
        }

        public int Add(SV_ThangRenLuyenTrongKyInfo pSV_ThangRenLuyenTrongKyInfo)
        {
			int ID = 0;
            ID = oDSV_ThangRenLuyenTrongKy.Add(pSV_ThangRenLuyenTrongKyInfo);
            mErrorMessage = oDSV_ThangRenLuyenTrongKy.ErrorMessages;
            mErrorNumber = oDSV_ThangRenLuyenTrongKy.ErrorNumber;
            return ID;
        }

        public void Update(SV_ThangRenLuyenTrongKyInfo pSV_ThangRenLuyenTrongKyInfo)
        {
            oDSV_ThangRenLuyenTrongKy.Update(pSV_ThangRenLuyenTrongKyInfo);
            mErrorMessage = oDSV_ThangRenLuyenTrongKy.ErrorMessages;
            mErrorNumber = oDSV_ThangRenLuyenTrongKy.ErrorNumber;
        }
        
        public void Delete(SV_ThangRenLuyenTrongKyInfo pSV_ThangRenLuyenTrongKyInfo)
        {
            oDSV_ThangRenLuyenTrongKy.Delete(pSV_ThangRenLuyenTrongKyInfo);
            mErrorMessage = oDSV_ThangRenLuyenTrongKy.ErrorMessages;
            mErrorNumber = oDSV_ThangRenLuyenTrongKy.ErrorNumber;
        }

        public List<SV_ThangRenLuyenTrongKyInfo> GetList(SV_ThangRenLuyenTrongKyInfo pSV_ThangRenLuyenTrongKyInfo)
        {
            List<SV_ThangRenLuyenTrongKyInfo> oSV_ThangRenLuyenTrongKyInfoList = new List<SV_ThangRenLuyenTrongKyInfo>();
            DataTable dtb = Get(pSV_ThangRenLuyenTrongKyInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oSV_ThangRenLuyenTrongKyInfo = new SV_ThangRenLuyenTrongKyInfo();

                    oSV_ThangRenLuyenTrongKyInfo.SV_ThangRenLuyenTrongKyID = int.Parse(dtb.Rows[i]["SV_ThangRenLuyenTrongKyID"].ToString());
                    oSV_ThangRenLuyenTrongKyInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oSV_ThangRenLuyenTrongKyInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oSV_ThangRenLuyenTrongKyInfo.Thang = int.Parse(dtb.Rows[i]["Thang"].ToString());
                    
                    oSV_ThangRenLuyenTrongKyInfoList.Add(oSV_ThangRenLuyenTrongKyInfo);
                }
            }
            return oSV_ThangRenLuyenTrongKyInfoList;
        }
        
        public void ToDataRow(SV_ThangRenLuyenTrongKyInfo pSV_ThangRenLuyenTrongKyInfo, ref DataRow dr)
        {

			dr[pSV_ThangRenLuyenTrongKyInfo.strSV_ThangRenLuyenTrongKyID] = pSV_ThangRenLuyenTrongKyInfo.SV_ThangRenLuyenTrongKyID;
			dr[pSV_ThangRenLuyenTrongKyInfo.strIDDM_NamHoc] = pSV_ThangRenLuyenTrongKyInfo.IDDM_NamHoc;
			dr[pSV_ThangRenLuyenTrongKyInfo.strHocKy] = pSV_ThangRenLuyenTrongKyInfo.HocKy;
			dr[pSV_ThangRenLuyenTrongKyInfo.strThang] = pSV_ThangRenLuyenTrongKyInfo.Thang;
        }
        
        public void ToInfo(ref SV_ThangRenLuyenTrongKyInfo pSV_ThangRenLuyenTrongKyInfo, DataRow dr)
        {

			pSV_ThangRenLuyenTrongKyInfo.SV_ThangRenLuyenTrongKyID = int.Parse(dr[pSV_ThangRenLuyenTrongKyInfo.strSV_ThangRenLuyenTrongKyID].ToString());
			pSV_ThangRenLuyenTrongKyInfo.IDDM_NamHoc = int.Parse(dr[pSV_ThangRenLuyenTrongKyInfo.strIDDM_NamHoc].ToString());
			pSV_ThangRenLuyenTrongKyInfo.HocKy = int.Parse(dr[pSV_ThangRenLuyenTrongKyInfo.strHocKy].ToString());
			pSV_ThangRenLuyenTrongKyInfo.Thang = int.Parse(dr[pSV_ThangRenLuyenTrongKyInfo.strThang].ToString());
        }
    }
}
