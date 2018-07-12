using System.Collections.Generic;
using System.Data;
using TruongViet.UnimOs.Data;
using TruongViet.UnimOs.Entity;

namespace TruongViet.UnimOs.Business
{
    public class cBDM_BoMon : cBBase
    {
        private cDDM_BoMon oDDM_BoMon;
        private DM_BoMonInfo oDM_BoMonInfo;

        public cBDM_BoMon()
        {
            oDDM_BoMon = new cDDM_BoMon();
        }

        public DataTable Get(DM_BoMonInfo pDM_BoMonInfo)
        {
            return oDDM_BoMon.Get(pDM_BoMonInfo);
        }

        public int Add(DM_BoMonInfo pDM_BoMonInfo)
        {
            int ID = 0;
            ID = oDDM_BoMon.Add(pDM_BoMonInfo);
            mErrorMessage = oDDM_BoMon.ErrorMessages;
            mErrorNumber = oDDM_BoMon.ErrorNumber;
            return ID;
        }

        public void Update(DM_BoMonInfo pDM_BoMonInfo)
        {
            oDDM_BoMon.Update(pDM_BoMonInfo);
            mErrorMessage = oDDM_BoMon.ErrorMessages;
            mErrorNumber = oDDM_BoMon.ErrorNumber;
        }

        public void Delete(DM_BoMonInfo pDM_BoMonInfo)
        {
            oDDM_BoMon.Delete(pDM_BoMonInfo);
            mErrorMessage = oDDM_BoMon.ErrorMessages;
            mErrorNumber = oDDM_BoMon.ErrorNumber;
        }

        public List<DM_BoMonInfo> GetList(DM_BoMonInfo pDM_BoMonInfo)
        {
            List<DM_BoMonInfo> oDM_BoMonInfoList = new List<DM_BoMonInfo>();
            DataTable dtb = Get(pDM_BoMonInfo);
            if (dtb != null)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    oDM_BoMonInfo = new DM_BoMonInfo();

                    oDM_BoMonInfo.DM_BoMonID = int.Parse(dtb.Rows[i]["DM_BoMonID"].ToString());
                    oDM_BoMonInfo.IDDM_Khoa = int.Parse(dtb.Rows[i]["IDDM_Khoa"].ToString());
                    oDM_BoMonInfo.MaBoMon = dtb.Rows[i]["MaBoMon"].ToString();
                    oDM_BoMonInfo.TenBoMon = dtb.Rows[i]["TenBoMon"].ToString();

                    oDM_BoMonInfoList.Add(oDM_BoMonInfo);
                }
            }
            return oDM_BoMonInfoList;
        }

        public void ToDataRow(DM_BoMonInfo pDM_BoMonInfo, ref DataRow dr)
        {
            dr[pDM_BoMonInfo.strDM_BoMonID] = pDM_BoMonInfo.DM_BoMonID;
            dr[pDM_BoMonInfo.strIDDM_Khoa] = pDM_BoMonInfo.IDDM_Khoa;
            dr[pDM_BoMonInfo.strMaBoMon] = pDM_BoMonInfo.MaBoMon;
            dr[pDM_BoMonInfo.strTenBoMon] = pDM_BoMonInfo.TenBoMon;
        }

        public void ToInfo(ref DM_BoMonInfo pDM_BoMonInfo, DataRow dr)
        {
            pDM_BoMonInfo.DM_BoMonID = int.Parse(dr[pDM_BoMonInfo.strDM_BoMonID].ToString());
            pDM_BoMonInfo.IDDM_Khoa = int.Parse(dr[pDM_BoMonInfo.strIDDM_Khoa].ToString());
            pDM_BoMonInfo.MaBoMon = dr[pDM_BoMonInfo.strMaBoMon].ToString();
            pDM_BoMonInfo.TenBoMon = dr[pDM_BoMonInfo.strTenBoMon].ToString();
        }

        public DataTable GetByIDKhoa(int IDDM_Khoa)
        {
            return oDDM_BoMon.GetByIDKhoa(IDDM_Khoa);
        }
    }
}