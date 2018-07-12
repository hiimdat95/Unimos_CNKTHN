using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_HinhThucDaoTao : cBBase
    {
        private cDDM_HinhThucDaoTao oDDM_HinhThucDaoTao;
        private DM_HinhThucDaoTaoInfo oDM_HinhThucDaoTaoInfo;

        public cBDM_HinhThucDaoTao()        
        {
            oDDM_HinhThucDaoTao = new cDDM_HinhThucDaoTao();
        }

        public DataTable Get(DM_HinhThucDaoTaoInfo pDM_HinhThucDaoTaoInfo)        
        {
            return oDDM_HinhThucDaoTao.Get(pDM_HinhThucDaoTaoInfo);
        }

        public int Add(DM_HinhThucDaoTaoInfo pDM_HinhThucDaoTaoInfo)
        {
			int ID = 0;
            ID = oDDM_HinhThucDaoTao.Add(pDM_HinhThucDaoTaoInfo);
            mErrorMessage = oDDM_HinhThucDaoTao.ErrorMessages;
            mErrorNumber = oDDM_HinhThucDaoTao.ErrorNumber;
            return ID;
        }

        public void Update(DM_HinhThucDaoTaoInfo pDM_HinhThucDaoTaoInfo)
        {
            oDDM_HinhThucDaoTao.Update(pDM_HinhThucDaoTaoInfo);
            mErrorMessage = oDDM_HinhThucDaoTao.ErrorMessages;
            mErrorNumber = oDDM_HinhThucDaoTao.ErrorNumber;
        }
        
        public void Delete(DM_HinhThucDaoTaoInfo pDM_HinhThucDaoTaoInfo)
        {
            oDDM_HinhThucDaoTao.Delete(pDM_HinhThucDaoTaoInfo);
            mErrorMessage = oDDM_HinhThucDaoTao.ErrorMessages;
            mErrorNumber = oDDM_HinhThucDaoTao.ErrorNumber;
        }

        public List<DM_HinhThucDaoTaoInfo> GetList(DM_HinhThucDaoTaoInfo pDM_HinhThucDaoTaoInfo)
        {
            List<DM_HinhThucDaoTaoInfo> oDM_HinhThucDaoTaoInfoList = new List<DM_HinhThucDaoTaoInfo>();
            DataTable dtb = Get(pDM_HinhThucDaoTaoInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oDM_HinhThucDaoTaoInfo = new DM_HinhThucDaoTaoInfo();

                    oDM_HinhThucDaoTaoInfo.DM_HinhThucDaoTaoID = int.Parse(dtb.Rows[i]["DM_HinhThucDaoTaoID"].ToString());
                    oDM_HinhThucDaoTaoInfo.TenHinhThucDaoTao = dtb.Rows[i]["TenHinhThucDaoTao"].ToString();
                    
                    oDM_HinhThucDaoTaoInfoList.Add(oDM_HinhThucDaoTaoInfo);
                }
            }
            return oDM_HinhThucDaoTaoInfoList;
        }
        
        public void ToDataRow(DM_HinhThucDaoTaoInfo pDM_HinhThucDaoTaoInfo, ref DataRow dr)
        {

			dr[pDM_HinhThucDaoTaoInfo.strDM_HinhThucDaoTaoID] = pDM_HinhThucDaoTaoInfo.DM_HinhThucDaoTaoID;
			dr[pDM_HinhThucDaoTaoInfo.strTenHinhThucDaoTao] = pDM_HinhThucDaoTaoInfo.TenHinhThucDaoTao;
        }
        
        public void ToInfo(ref DM_HinhThucDaoTaoInfo pDM_HinhThucDaoTaoInfo, DataRow dr)
        {

			pDM_HinhThucDaoTaoInfo.DM_HinhThucDaoTaoID = int.Parse(dr[pDM_HinhThucDaoTaoInfo.strDM_HinhThucDaoTaoID].ToString());
			pDM_HinhThucDaoTaoInfo.TenHinhThucDaoTao = dr[pDM_HinhThucDaoTaoInfo.strTenHinhThucDaoTao].ToString();
        }
    }
}
