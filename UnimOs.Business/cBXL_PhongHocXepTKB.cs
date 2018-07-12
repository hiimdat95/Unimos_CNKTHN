using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBXL_PhongHocXepTKB : cBBase
    {
        private cDXL_PhongHocXepTKB oDXL_PhongHocXepTKB;
        private XL_PhongHocXepTKBInfo oXL_PhongHocXepTKBInfo;

        public cBXL_PhongHocXepTKB()        
        {
            oDXL_PhongHocXepTKB = new cDXL_PhongHocXepTKB();
        }

        public DataTable Get(XL_PhongHocXepTKBInfo pXL_PhongHocXepTKBInfo)        
        {
            return oDXL_PhongHocXepTKB.Get(pXL_PhongHocXepTKBInfo);
        }

        public int Add(XL_PhongHocXepTKBInfo pXL_PhongHocXepTKBInfo)
        {
			int ID = 0;
            ID = oDXL_PhongHocXepTKB.Add(pXL_PhongHocXepTKBInfo);
            mErrorMessage = oDXL_PhongHocXepTKB.ErrorMessages;
            mErrorNumber = oDXL_PhongHocXepTKB.ErrorNumber;
            return ID;
        }

        public void Update(XL_PhongHocXepTKBInfo pXL_PhongHocXepTKBInfo)
        {
            oDXL_PhongHocXepTKB.Update(pXL_PhongHocXepTKBInfo);
            mErrorMessage = oDXL_PhongHocXepTKB.ErrorMessages;
            mErrorNumber = oDXL_PhongHocXepTKB.ErrorNumber;
        }
        
        public void Delete(XL_PhongHocXepTKBInfo pXL_PhongHocXepTKBInfo)
        {
            oDXL_PhongHocXepTKB.Delete(pXL_PhongHocXepTKBInfo);
            mErrorMessage = oDXL_PhongHocXepTKB.ErrorMessages;
            mErrorNumber = oDXL_PhongHocXepTKB.ErrorNumber;
        }

        public List<XL_PhongHocXepTKBInfo> GetList(XL_PhongHocXepTKBInfo pXL_PhongHocXepTKBInfo)
        {
            List<XL_PhongHocXepTKBInfo> oXL_PhongHocXepTKBInfoList = new List<XL_PhongHocXepTKBInfo>();
            DataTable dtb = Get(pXL_PhongHocXepTKBInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oXL_PhongHocXepTKBInfo = new XL_PhongHocXepTKBInfo();
                    

                    oXL_PhongHocXepTKBInfo.XL_PhongHocXepTKBID = int.Parse(dtb.Rows[i]["XL_PhongHocXepTKBID"].ToString());
                    oXL_PhongHocXepTKBInfo.IDHT_User = int.Parse(dtb.Rows[i]["IDHT_User"].ToString());
                    oXL_PhongHocXepTKBInfo.IDDM_PhongHoc = int.Parse(dtb.Rows[i]["IDDM_PhongHoc"].ToString());
                    
                    oXL_PhongHocXepTKBInfoList.Add(oXL_PhongHocXepTKBInfo);
                }
            }
            return oXL_PhongHocXepTKBInfoList;
        }
    }
}
