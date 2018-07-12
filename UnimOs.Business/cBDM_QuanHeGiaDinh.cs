using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_QuanHeGiaDinh : cBBase
    {
        private cDDM_QuanHeGiaDinh oDDM_QuanHeGiaDinh;
        private DM_QuanHeGiaDinhInfo oDM_QuanHeGiaDinhInfo;

        public cBDM_QuanHeGiaDinh()        
        {
            oDDM_QuanHeGiaDinh = new cDDM_QuanHeGiaDinh();
        }

        public DataTable Get(DM_QuanHeGiaDinhInfo pDM_QuanHeGiaDinhInfo)        
        {
            return oDDM_QuanHeGiaDinh.Get(pDM_QuanHeGiaDinhInfo);
        }

        public int Add(DM_QuanHeGiaDinhInfo pDM_QuanHeGiaDinhInfo)
        {
			int ID = 0;
            ID = oDDM_QuanHeGiaDinh.Add(pDM_QuanHeGiaDinhInfo);
            mErrorMessage = oDDM_QuanHeGiaDinh.ErrorMessages;
            mErrorNumber = oDDM_QuanHeGiaDinh.ErrorNumber;
            return ID;
        }

        public void Update(DM_QuanHeGiaDinhInfo pDM_QuanHeGiaDinhInfo)
        {
            oDDM_QuanHeGiaDinh.Update(pDM_QuanHeGiaDinhInfo);
            mErrorMessage = oDDM_QuanHeGiaDinh.ErrorMessages;
            mErrorNumber = oDDM_QuanHeGiaDinh.ErrorNumber;
        }
        
        public void Delete(DM_QuanHeGiaDinhInfo pDM_QuanHeGiaDinhInfo)
        {
            oDDM_QuanHeGiaDinh.Delete(pDM_QuanHeGiaDinhInfo);
            mErrorMessage = oDDM_QuanHeGiaDinh.ErrorMessages;
            mErrorNumber = oDDM_QuanHeGiaDinh.ErrorNumber;
        }

        public List<DM_QuanHeGiaDinhInfo> GetList(DM_QuanHeGiaDinhInfo pDM_QuanHeGiaDinhInfo)
        {
            List<DM_QuanHeGiaDinhInfo> oDM_QuanHeGiaDinhInfoList = new List<DM_QuanHeGiaDinhInfo>();
            DataTable dtb = Get(pDM_QuanHeGiaDinhInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_QuanHeGiaDinhInfo = new DM_QuanHeGiaDinhInfo();

                    oDM_QuanHeGiaDinhInfo.DM_QuanHeGiaDinhID = int.Parse(dtb.Rows[i]["DM_QuanHeGiaDinhID"].ToString());
                    oDM_QuanHeGiaDinhInfo.TenMoiQuanHe = dtb.Rows[i]["TenMoiQuanHe"].ToString();
                    oDM_QuanHeGiaDinhInfo.Bo = bool.Parse(dtb.Rows[i]["Bo"].ToString());
                    oDM_QuanHeGiaDinhInfo.Me = bool.Parse(dtb.Rows[i]["Me"].ToString());
                    
                    oDM_QuanHeGiaDinhInfoList.Add(oDM_QuanHeGiaDinhInfo);
                }
            }
            return oDM_QuanHeGiaDinhInfoList;
        }
        
        public void ToDataRow(DM_QuanHeGiaDinhInfo pDM_QuanHeGiaDinhInfo, ref DataRow dr)
        {

			dr[pDM_QuanHeGiaDinhInfo.strDM_QuanHeGiaDinhID] = pDM_QuanHeGiaDinhInfo.DM_QuanHeGiaDinhID;
			dr[pDM_QuanHeGiaDinhInfo.strTenMoiQuanHe] = pDM_QuanHeGiaDinhInfo.TenMoiQuanHe;
			dr[pDM_QuanHeGiaDinhInfo.strBo] = pDM_QuanHeGiaDinhInfo.Bo;
			dr[pDM_QuanHeGiaDinhInfo.strMe] = pDM_QuanHeGiaDinhInfo.Me;
        }
        
        public void ToInfo(ref DM_QuanHeGiaDinhInfo pDM_QuanHeGiaDinhInfo, DataRow dr)
        {

			pDM_QuanHeGiaDinhInfo.DM_QuanHeGiaDinhID = int.Parse(dr[pDM_QuanHeGiaDinhInfo.strDM_QuanHeGiaDinhID].ToString());
			pDM_QuanHeGiaDinhInfo.TenMoiQuanHe = dr[pDM_QuanHeGiaDinhInfo.strTenMoiQuanHe].ToString();
			pDM_QuanHeGiaDinhInfo.Bo = bool.Parse(dr[pDM_QuanHeGiaDinhInfo.strBo].ToString());
			pDM_QuanHeGiaDinhInfo.Me = bool.Parse(dr[pDM_QuanHeGiaDinhInfo.strMe].ToString());
        }
    }
}
