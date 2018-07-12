using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBXL_GiaoVienXepTKB : cBBase
    {
        private cDXL_GiaoVienXepTKB oDXL_GiaoVienXepTKB;
        private XL_GiaoVienXepTKBInfo oXL_GiaoVienXepTKBInfo;

        public cBXL_GiaoVienXepTKB()        
        {
            oDXL_GiaoVienXepTKB = new cDXL_GiaoVienXepTKB();
        }

        public DataTable Get(XL_GiaoVienXepTKBInfo pXL_GiaoVienXepTKBInfo)        
        {
            return oDXL_GiaoVienXepTKB.Get(pXL_GiaoVienXepTKBInfo);
        }

        public int Add(XL_GiaoVienXepTKBInfo pXL_GiaoVienXepTKBInfo)
        {
			int ID = 0;
            ID = oDXL_GiaoVienXepTKB.Add(pXL_GiaoVienXepTKBInfo);
            mErrorMessage = oDXL_GiaoVienXepTKB.ErrorMessages;
            mErrorNumber = oDXL_GiaoVienXepTKB.ErrorNumber;
            return ID;
        }

        public void Update(XL_GiaoVienXepTKBInfo pXL_GiaoVienXepTKBInfo)
        {
            oDXL_GiaoVienXepTKB.Update(pXL_GiaoVienXepTKBInfo);
            mErrorMessage = oDXL_GiaoVienXepTKB.ErrorMessages;
            mErrorNumber = oDXL_GiaoVienXepTKB.ErrorNumber;
        }
        
        public void Delete(XL_GiaoVienXepTKBInfo pXL_GiaoVienXepTKBInfo)
        {
            oDXL_GiaoVienXepTKB.Delete(pXL_GiaoVienXepTKBInfo);
            mErrorMessage = oDXL_GiaoVienXepTKB.ErrorMessages;
            mErrorNumber = oDXL_GiaoVienXepTKB.ErrorNumber;
        }

        public List<XL_GiaoVienXepTKBInfo> GetList(XL_GiaoVienXepTKBInfo pXL_GiaoVienXepTKBInfo)
        {
            List<XL_GiaoVienXepTKBInfo> oXL_GiaoVienXepTKBInfoList = new List<XL_GiaoVienXepTKBInfo>();
            DataTable dtb = Get(pXL_GiaoVienXepTKBInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oXL_GiaoVienXepTKBInfo = new XL_GiaoVienXepTKBInfo();
                    

                    oXL_GiaoVienXepTKBInfo.XL_GiaoVienXepTKB = int.Parse(dtb.Rows[i]["XL_GiaoVienXepTKB"].ToString());
                    oXL_GiaoVienXepTKBInfo.IDHT_User = int.Parse(dtb.Rows[i]["IDHT_User"].ToString());
                    oXL_GiaoVienXepTKBInfo.IDDM_GiaoVien = int.Parse(dtb.Rows[i]["IDDM_GiaoVien"].ToString());
                    
                    oXL_GiaoVienXepTKBInfoList.Add(oXL_GiaoVienXepTKBInfo);
                }
            }
            return oXL_GiaoVienXepTKBInfoList;
        }
    }
}
