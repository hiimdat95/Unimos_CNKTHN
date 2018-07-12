using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_TruongLienKet : cBBase
    {
        private cDDM_TruongLienKet oDDM_TruongLienKet;
        private DM_TruongLienKetInfo oDM_TruongLienKetInfo;

        public cBDM_TruongLienKet()        
        {
            oDDM_TruongLienKet = new cDDM_TruongLienKet();
        }

        public DataTable Get(DM_TruongLienKetInfo pDM_TruongLienKetInfo)        
        {
            return oDDM_TruongLienKet.Get(pDM_TruongLienKetInfo);
        }

        public int Add(DM_TruongLienKetInfo pDM_TruongLienKetInfo)
        {
			int ID = 0;
            ID = oDDM_TruongLienKet.Add(pDM_TruongLienKetInfo);
            mErrorMessage = oDDM_TruongLienKet.ErrorMessages;
            mErrorNumber = oDDM_TruongLienKet.ErrorNumber;
            return ID;
        }

        public void Update(DM_TruongLienKetInfo pDM_TruongLienKetInfo)
        {
            oDDM_TruongLienKet.Update(pDM_TruongLienKetInfo);
            mErrorMessage = oDDM_TruongLienKet.ErrorMessages;
            mErrorNumber = oDDM_TruongLienKet.ErrorNumber;
        }
        
        public void Delete(DM_TruongLienKetInfo pDM_TruongLienKetInfo)
        {
            oDDM_TruongLienKet.Delete(pDM_TruongLienKetInfo);
            mErrorMessage = oDDM_TruongLienKet.ErrorMessages;
            mErrorNumber = oDDM_TruongLienKet.ErrorNumber;
        }

        public List<DM_TruongLienKetInfo> GetList(DM_TruongLienKetInfo pDM_TruongLienKetInfo)
        {
            List<DM_TruongLienKetInfo> oDM_TruongLienKetInfoList = new List<DM_TruongLienKetInfo>();
            DataTable dtb = Get(pDM_TruongLienKetInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_TruongLienKetInfo = new DM_TruongLienKetInfo();

                    oDM_TruongLienKetInfo.DM_TruongLienKetID = int.Parse(dtb.Rows[i]["DM_TruongLienKetID"].ToString());
                    oDM_TruongLienKetInfo.MaTruong = dtb.Rows[i]["MaTruong"].ToString();
                    oDM_TruongLienKetInfo.TenTruong = dtb.Rows[i]["TenTruong"].ToString();
                    oDM_TruongLienKetInfo.DiaChi = dtb.Rows[i]["DiaChi"].ToString();
                    oDM_TruongLienKetInfo.IDDM_TinhHuyenXa = int.Parse(dtb.Rows[i]["IDDM_TinhHuyenXa"].ToString());
                    
                    oDM_TruongLienKetInfoList.Add(oDM_TruongLienKetInfo);
                }
            }
            return oDM_TruongLienKetInfoList;
        }
        
        public void ToDataRow(DM_TruongLienKetInfo pDM_TruongLienKetInfo, ref DataRow dr)
        {

			dr[pDM_TruongLienKetInfo.strDM_TruongLienKetID] = pDM_TruongLienKetInfo.DM_TruongLienKetID;
			dr[pDM_TruongLienKetInfo.strMaTruong] = pDM_TruongLienKetInfo.MaTruong;
			dr[pDM_TruongLienKetInfo.strTenTruong] = pDM_TruongLienKetInfo.TenTruong;
			dr[pDM_TruongLienKetInfo.strDiaChi] = pDM_TruongLienKetInfo.DiaChi;
			dr[pDM_TruongLienKetInfo.strIDDM_TinhHuyenXa] = pDM_TruongLienKetInfo.IDDM_TinhHuyenXa;
        }
    }
}
