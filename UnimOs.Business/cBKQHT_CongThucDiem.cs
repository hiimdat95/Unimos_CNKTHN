using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_CongThucDiem : cBBase
    {
        private cDKQHT_CongThucDiem oDKQHT_CongThucDiem;
        private KQHT_CongThucDiemInfo oKQHT_CongThucDiemInfo;

        public cBKQHT_CongThucDiem()        
        {
            oDKQHT_CongThucDiem = new cDKQHT_CongThucDiem();
        }

        public DataTable Get(KQHT_CongThucDiemInfo pKQHT_CongThucDiemInfo)        
        {
            return oDKQHT_CongThucDiem.Get(pKQHT_CongThucDiemInfo);
        }

        public DataTable GetMonChuaToChuc(int IDDM_Lop, int IDDM_NamHoc, int HocKy, int IDDM_MonHoc)        
        {
            return oDKQHT_CongThucDiem.GetMonChuaToChuc(IDDM_Lop, IDDM_NamHoc, HocKy, IDDM_MonHoc);
        }

        public DataTable GetMon(int IDDM_Lop, int IDDM_NamHoc, int HocKy, int IDDM_MonHoc)
        {
            return oDKQHT_CongThucDiem.GetMon(IDDM_Lop, IDDM_NamHoc, HocKy, IDDM_MonHoc);
        }

        public DataTable GetDiemThi(string IDDM_Lops, int IDDM_NamHoc, int HocKy, int IDDM_MonHoc)
        {
            return oDKQHT_CongThucDiem.GetDiemThi(IDDM_Lops, IDDM_NamHoc, HocKy, IDDM_MonHoc);
        }

        public DataTable GetByHocKyNamHoc(int IDDM_Lop, int IDDM_NamHoc, int HocKy)
        {
            return oDKQHT_CongThucDiem.GetByHocKyNamHoc(IDDM_Lop, IDDM_NamHoc, HocKy);
        }

        public int Add(KQHT_CongThucDiemInfo pKQHT_CongThucDiemInfo)
        {
			int ID = 0;
            ID = oDKQHT_CongThucDiem.Add(pKQHT_CongThucDiemInfo);
            mErrorMessage = oDKQHT_CongThucDiem.ErrorMessages;
            mErrorNumber = oDKQHT_CongThucDiem.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_CongThucDiemInfo pKQHT_CongThucDiemInfo)
        {
            oDKQHT_CongThucDiem.Update(pKQHT_CongThucDiemInfo);
            mErrorMessage = oDKQHT_CongThucDiem.ErrorMessages;
            mErrorNumber = oDKQHT_CongThucDiem.ErrorNumber;
        }
        
        public void Delete(KQHT_CongThucDiemInfo pKQHT_CongThucDiemInfo)
        {
            oDKQHT_CongThucDiem.Delete(pKQHT_CongThucDiemInfo);
            mErrorMessage = oDKQHT_CongThucDiem.ErrorMessages;
            mErrorNumber = oDKQHT_CongThucDiem.ErrorNumber;
        }

        public List<KQHT_CongThucDiemInfo> GetList(KQHT_CongThucDiemInfo pKQHT_CongThucDiemInfo)
        {
            List<KQHT_CongThucDiemInfo> oKQHT_CongThucDiemInfoList = new List<KQHT_CongThucDiemInfo>();
            DataTable dtb = Get(pKQHT_CongThucDiemInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_CongThucDiemInfo = new KQHT_CongThucDiemInfo();

                    oKQHT_CongThucDiemInfo.KQHT_CongThucDiemID = int.Parse(dtb.Rows[i]["KQHT_CongThucDiemID"].ToString());
                    oKQHT_CongThucDiemInfo.IDDM_Lop = int.Parse(dtb.Rows[i]["IDDM_Lop"].ToString());
                    oKQHT_CongThucDiemInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
                    oKQHT_CongThucDiemInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oKQHT_CongThucDiemInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oKQHT_CongThucDiemInfo.CongThuc = dtb.Rows[i]["CongThuc"].ToString();
                    
                    oKQHT_CongThucDiemInfoList.Add(oKQHT_CongThucDiemInfo);
                }
            }
            return oKQHT_CongThucDiemInfoList;
        }
        
        public void ToDataRow(KQHT_CongThucDiemInfo pKQHT_CongThucDiemInfo, ref DataRow dr)
        {

			dr[pKQHT_CongThucDiemInfo.strKQHT_CongThucDiemID] = pKQHT_CongThucDiemInfo.KQHT_CongThucDiemID;
			dr[pKQHT_CongThucDiemInfo.strIDDM_Lop] = pKQHT_CongThucDiemInfo.IDDM_Lop;
			dr[pKQHT_CongThucDiemInfo.strIDDM_MonHoc] = pKQHT_CongThucDiemInfo.IDDM_MonHoc;
			dr[pKQHT_CongThucDiemInfo.strIDDM_NamHoc] = pKQHT_CongThucDiemInfo.IDDM_NamHoc;
			dr[pKQHT_CongThucDiemInfo.strHocKy] = pKQHT_CongThucDiemInfo.HocKy;
			dr[pKQHT_CongThucDiemInfo.strCongThuc] = pKQHT_CongThucDiemInfo.CongThuc;
        }
        
        public void ToInfo(ref KQHT_CongThucDiemInfo pKQHT_CongThucDiemInfo, DataRow dr)
        {

			pKQHT_CongThucDiemInfo.KQHT_CongThucDiemID = int.Parse(dr[pKQHT_CongThucDiemInfo.strKQHT_CongThucDiemID].ToString());
			pKQHT_CongThucDiemInfo.IDDM_Lop = int.Parse(dr[pKQHT_CongThucDiemInfo.strIDDM_Lop].ToString());
			pKQHT_CongThucDiemInfo.IDDM_MonHoc = int.Parse(dr[pKQHT_CongThucDiemInfo.strIDDM_MonHoc].ToString());
			pKQHT_CongThucDiemInfo.IDDM_NamHoc = int.Parse(dr[pKQHT_CongThucDiemInfo.strIDDM_NamHoc].ToString());
			pKQHT_CongThucDiemInfo.HocKy = int.Parse(dr[pKQHT_CongThucDiemInfo.strHocKy].ToString());
			pKQHT_CongThucDiemInfo.CongThuc = dr[pKQHT_CongThucDiemInfo.strCongThuc].ToString();
        }
    }
}
