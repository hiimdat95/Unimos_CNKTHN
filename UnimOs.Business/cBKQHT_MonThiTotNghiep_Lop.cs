using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_MonThiTotNghiep_Lop : cBBase
    {
        private cDKQHT_MonThiTotNghiep_Lop oDKQHT_MonThiTotNghiep_Lop;
        private KQHT_MonThiTotNghiep_LopInfo oKQHT_MonThiTotNghiep_LopInfo;

        public cBKQHT_MonThiTotNghiep_Lop()        
        {
            oDKQHT_MonThiTotNghiep_Lop = new cDKQHT_MonThiTotNghiep_Lop();
        }

        public DataTable Get(KQHT_MonThiTotNghiep_LopInfo pKQHT_MonThiTotNghiep_LopInfo)        
        {
            return oDKQHT_MonThiTotNghiep_Lop.Get(pKQHT_MonThiTotNghiep_LopInfo);
        }
        public DataTable GetAllMon(int IDDM_NamHoc)
        {
            return oDKQHT_MonThiTotNghiep_Lop.GetAllMon(IDDM_NamHoc);
        }

        public DataTable GetIn_Mon(int IDDM_Lop)
        {
            return oDKQHT_MonThiTotNghiep_Lop.GetIn_Mon(IDDM_Lop);
        }

        public DataTable GetNotIn_Mon(int IDDM_Lop)
        {
            return oDKQHT_MonThiTotNghiep_Lop.GetNotIn_Mon(IDDM_Lop);
        }

        public int Add(KQHT_MonThiTotNghiep_LopInfo pKQHT_MonThiTotNghiep_LopInfo)
        {
			int ID = 0;
            ID = oDKQHT_MonThiTotNghiep_Lop.Add(pKQHT_MonThiTotNghiep_LopInfo);
            mErrorMessage = oDKQHT_MonThiTotNghiep_Lop.ErrorMessages;
            mErrorNumber = oDKQHT_MonThiTotNghiep_Lop.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_MonThiTotNghiep_LopInfo pKQHT_MonThiTotNghiep_LopInfo)
        {
            oDKQHT_MonThiTotNghiep_Lop.Update(pKQHT_MonThiTotNghiep_LopInfo);
            mErrorMessage = oDKQHT_MonThiTotNghiep_Lop.ErrorMessages;
            mErrorNumber = oDKQHT_MonThiTotNghiep_Lop.ErrorNumber;
        }

        public void Delete_ByLop(int IDDM_Lop)
        {
            oDKQHT_MonThiTotNghiep_Lop.Delete_ByLop(IDDM_Lop);
            mErrorMessage = oDKQHT_MonThiTotNghiep_Lop.ErrorMessages;
            mErrorNumber = oDKQHT_MonThiTotNghiep_Lop.ErrorNumber;
        }
        public void Delete(KQHT_MonThiTotNghiep_LopInfo pKQHT_MonThiTotNghiep_LopInfo)
        {
            oDKQHT_MonThiTotNghiep_Lop.Delete(pKQHT_MonThiTotNghiep_LopInfo);
            mErrorMessage = oDKQHT_MonThiTotNghiep_Lop.ErrorMessages;
            mErrorNumber = oDKQHT_MonThiTotNghiep_Lop.ErrorNumber;
        }

        public List<KQHT_MonThiTotNghiep_LopInfo> GetList(KQHT_MonThiTotNghiep_LopInfo pKQHT_MonThiTotNghiep_LopInfo)
        {
            List<KQHT_MonThiTotNghiep_LopInfo> oKQHT_MonThiTotNghiep_LopInfoList = new List<KQHT_MonThiTotNghiep_LopInfo>();
            DataTable dtb = Get(pKQHT_MonThiTotNghiep_LopInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_MonThiTotNghiep_LopInfo = new KQHT_MonThiTotNghiep_LopInfo();

                    oKQHT_MonThiTotNghiep_LopInfo.KQHT_MonThiTotNghiep_LopID = int.Parse(dtb.Rows[i]["KQHT_MonThiTotNghiep_LopID"].ToString());
                    oKQHT_MonThiTotNghiep_LopInfo.IDDM_Lop = int.Parse(dtb.Rows[i]["IDDM_Lop"].ToString());
                    oKQHT_MonThiTotNghiep_LopInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
                    oKQHT_MonThiTotNghiep_LopInfo.SoHocTrinh = int.Parse(dtb.Rows[i]["SoHocTrinh"].ToString());
                    oKQHT_MonThiTotNghiep_LopInfo.TinhDiem = bool.Parse(dtb.Rows[i]["TinhDiem"].ToString());
                    
                    oKQHT_MonThiTotNghiep_LopInfoList.Add(oKQHT_MonThiTotNghiep_LopInfo);
                }
            }
            return oKQHT_MonThiTotNghiep_LopInfoList;
        }
        
        public void ToDataRow(KQHT_MonThiTotNghiep_LopInfo pKQHT_MonThiTotNghiep_LopInfo, ref DataRow dr)
        {

			dr[pKQHT_MonThiTotNghiep_LopInfo.strKQHT_MonThiTotNghiep_LopID] = pKQHT_MonThiTotNghiep_LopInfo.KQHT_MonThiTotNghiep_LopID;
			dr[pKQHT_MonThiTotNghiep_LopInfo.strIDDM_Lop] = pKQHT_MonThiTotNghiep_LopInfo.IDDM_Lop;
            dr[pKQHT_MonThiTotNghiep_LopInfo.strIDDM_MonHoc] = pKQHT_MonThiTotNghiep_LopInfo.IDDM_MonHoc;
            dr[pKQHT_MonThiTotNghiep_LopInfo.strTinhDiem] = pKQHT_MonThiTotNghiep_LopInfo.TinhDiem;
            dr[pKQHT_MonThiTotNghiep_LopInfo.strSoHocTrinh] = pKQHT_MonThiTotNghiep_LopInfo.SoHocTrinh;
        }
        
        public void ToInfo(ref KQHT_MonThiTotNghiep_LopInfo pKQHT_MonThiTotNghiep_LopInfo, DataRow dr)
        {

			pKQHT_MonThiTotNghiep_LopInfo.KQHT_MonThiTotNghiep_LopID = int.Parse(dr[pKQHT_MonThiTotNghiep_LopInfo.strKQHT_MonThiTotNghiep_LopID].ToString());
			pKQHT_MonThiTotNghiep_LopInfo.IDDM_Lop = int.Parse(dr[pKQHT_MonThiTotNghiep_LopInfo.strIDDM_Lop].ToString());
            pKQHT_MonThiTotNghiep_LopInfo.IDDM_MonHoc = int.Parse(dr[pKQHT_MonThiTotNghiep_LopInfo.strIDDM_MonHoc].ToString());
            pKQHT_MonThiTotNghiep_LopInfo.TinhDiem = bool.Parse(dr[pKQHT_MonThiTotNghiep_LopInfo.strTinhDiem].ToString());
            pKQHT_MonThiTotNghiep_LopInfo.SoHocTrinh = int.Parse(dr[pKQHT_MonThiTotNghiep_LopInfo.strSoHocTrinh].ToString());
        }
    }
}
