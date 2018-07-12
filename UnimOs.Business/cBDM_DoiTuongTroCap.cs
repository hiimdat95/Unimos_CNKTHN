using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_DoiTuongTroCap : cBBase
    {
        private cDDM_DoiTuongTroCap oDDM_DoiTuongTroCap;
        private DM_DoiTuongTroCapInfo oDM_DoiTuongTroCapInfo;

        public cBDM_DoiTuongTroCap()        
        {
            oDDM_DoiTuongTroCap = new cDDM_DoiTuongTroCap();
        }
       
        public DataTable Get(DM_DoiTuongTroCapInfo pDM_DoiTuongTroCapInfo)        
        {
            return oDDM_DoiTuongTroCap.Get(pDM_DoiTuongTroCapInfo);
        }

        public int Add(DM_DoiTuongTroCapInfo pDM_DoiTuongTroCapInfo)
        {
			int ID = 0;
            ID = oDDM_DoiTuongTroCap.Add(pDM_DoiTuongTroCapInfo);
            mErrorMessage = oDDM_DoiTuongTroCap.ErrorMessages;
            mErrorNumber = oDDM_DoiTuongTroCap.ErrorNumber;
            return ID;
        }

        public void Update(DM_DoiTuongTroCapInfo pDM_DoiTuongTroCapInfo)
        {
            oDDM_DoiTuongTroCap.Update(pDM_DoiTuongTroCapInfo);
            mErrorMessage = oDDM_DoiTuongTroCap.ErrorMessages;
            mErrorNumber = oDDM_DoiTuongTroCap.ErrorNumber;
        }
        
        public void Delete(DM_DoiTuongTroCapInfo pDM_DoiTuongTroCapInfo)
        {
            oDDM_DoiTuongTroCap.Delete(pDM_DoiTuongTroCapInfo);
            mErrorMessage = oDDM_DoiTuongTroCap.ErrorMessages;
            mErrorNumber = oDDM_DoiTuongTroCap.ErrorNumber;
        }

        public List<DM_DoiTuongTroCapInfo> GetList(DM_DoiTuongTroCapInfo pDM_DoiTuongTroCapInfo)
        {
            List<DM_DoiTuongTroCapInfo> oDM_DoiTuongTroCapInfoList = new List<DM_DoiTuongTroCapInfo>();
            DataTable dtb = Get(pDM_DoiTuongTroCapInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_DoiTuongTroCapInfo = new DM_DoiTuongTroCapInfo();

                    oDM_DoiTuongTroCapInfo.DM_DoiTuongTroCapID = int.Parse(dtb.Rows[i]["DM_DoiTuongTroCapID"].ToString());
                    oDM_DoiTuongTroCapInfo.MaDoiTuongTroCap = dtb.Rows[i]["MaDoiTuongTroCap"].ToString();
                    oDM_DoiTuongTroCapInfo.TenDoiTuongTroCap = dtb.Rows[i]["TenDoiTuongTroCap"].ToString();
                    oDM_DoiTuongTroCapInfo.SoTienTroCap = double.Parse(dtb.Rows[i]["SoTienTroCap"].ToString());
                    
                    oDM_DoiTuongTroCapInfoList.Add(oDM_DoiTuongTroCapInfo);
                }
            }
            return oDM_DoiTuongTroCapInfoList;
        }
        
        public void ToDataRow(DM_DoiTuongTroCapInfo pDM_DoiTuongTroCapInfo, ref DataRow dr)
        {

			dr[pDM_DoiTuongTroCapInfo.strDM_DoiTuongTroCapID] = pDM_DoiTuongTroCapInfo.DM_DoiTuongTroCapID;
			dr[pDM_DoiTuongTroCapInfo.strMaDoiTuongTroCap] = pDM_DoiTuongTroCapInfo.MaDoiTuongTroCap;
			dr[pDM_DoiTuongTroCapInfo.strTenDoiTuongTroCap] = pDM_DoiTuongTroCapInfo.TenDoiTuongTroCap;
			dr[pDM_DoiTuongTroCapInfo.strSoTienTroCap] = pDM_DoiTuongTroCapInfo.SoTienTroCap;
        }
        
        public void ToInfo(ref DM_DoiTuongTroCapInfo pDM_DoiTuongTroCapInfo, DataRow dr)
        {

			pDM_DoiTuongTroCapInfo.DM_DoiTuongTroCapID = int.Parse(dr[pDM_DoiTuongTroCapInfo.strDM_DoiTuongTroCapID].ToString());
			pDM_DoiTuongTroCapInfo.MaDoiTuongTroCap = dr[pDM_DoiTuongTroCapInfo.strMaDoiTuongTroCap].ToString();
			pDM_DoiTuongTroCapInfo.TenDoiTuongTroCap = dr[pDM_DoiTuongTroCapInfo.strTenDoiTuongTroCap].ToString();
			pDM_DoiTuongTroCapInfo.SoTienTroCap = double.Parse(dr[pDM_DoiTuongTroCapInfo.strSoTienTroCap].ToString());
        }
    }
}
