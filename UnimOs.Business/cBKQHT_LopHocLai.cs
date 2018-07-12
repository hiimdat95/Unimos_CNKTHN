using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using TruongViet.UnimOs.Entity;
using TruongViet.UnimOs.Data;

namespace TruongViet.UnimOs.Business
{
    public class cBKQHT_LopHocLai : cBBase
    {
        private cDKQHT_LopHocLai oDKQHT_LopHocLai;
        private KQHT_LopHocLaiInfo oKQHT_LopHocLaiInfo;

        public cBKQHT_LopHocLai()        
        {
            oDKQHT_LopHocLai = new cDKQHT_LopHocLai();
        }

        public DataTable Get(KQHT_LopHocLaiInfo pKQHT_LopHocLaiInfo)        
        {
            return oDKQHT_LopHocLai.Get(pKQHT_LopHocLaiInfo);
        }
        public DataTable GetSinhVien(int IDKQHT_LopHocLai, int LanThi)
        {
            return oDKQHT_LopHocLai.GetSinhVien(IDKQHT_LopHocLai, LanThi);
        }
        public DataTable GetByHocKyNamHoc(int IDDM_MonHoc,int HocKy, int IDNamHoc)
        {
            return oDKQHT_LopHocLai.GetByHocKyNamHoc(IDDM_MonHoc,HocKy, IDNamHoc);
        }

        public int Add(KQHT_LopHocLaiInfo pKQHT_LopHocLaiInfo)
        {
			int ID = 0;
            ID = oDKQHT_LopHocLai.Add(pKQHT_LopHocLaiInfo);
            mErrorMessage = oDKQHT_LopHocLai.ErrorMessages;
            mErrorNumber = oDKQHT_LopHocLai.ErrorNumber;
            return ID;
        }

        public void Update(KQHT_LopHocLaiInfo pKQHT_LopHocLaiInfo)
        {
            oDKQHT_LopHocLai.Update(pKQHT_LopHocLaiInfo);
            mErrorMessage = oDKQHT_LopHocLai.ErrorMessages;
            mErrorNumber = oDKQHT_LopHocLai.ErrorNumber;
        }
        
        public void Delete(KQHT_LopHocLaiInfo pKQHT_LopHocLaiInfo)
        {
            oDKQHT_LopHocLai.Delete(pKQHT_LopHocLaiInfo);
            mErrorMessage = oDKQHT_LopHocLai.ErrorMessages;
            mErrorNumber = oDKQHT_LopHocLai.ErrorNumber;
        }

        public List<KQHT_LopHocLaiInfo> GetList(KQHT_LopHocLaiInfo pKQHT_LopHocLaiInfo)
        {
            List<KQHT_LopHocLaiInfo> oKQHT_LopHocLaiInfoList = new List<KQHT_LopHocLaiInfo>();
            DataTable dtb = Get(pKQHT_LopHocLaiInfo);
            if (dtb != null)
            {                
                for (int i=0;i<dtb.Rows.Count;i++)
                {
                    oKQHT_LopHocLaiInfo = new KQHT_LopHocLaiInfo();

                    oKQHT_LopHocLaiInfo.KQHT_LopHocLaiID = int.Parse(dtb.Rows[i]["KQHT_LopHocLaiID"].ToString());
                    oKQHT_LopHocLaiInfo.TenLop = dtb.Rows[i]["TenLop"].ToString();
                    oKQHT_LopHocLaiInfo.IDDM_MonHoc = int.Parse(dtb.Rows[i]["IDDM_MonHoc"].ToString());
                    oKQHT_LopHocLaiInfo.IDDM_NamHoc = int.Parse(dtb.Rows[i]["IDDM_NamHoc"].ToString());
                    oKQHT_LopHocLaiInfo.HocKy = int.Parse(dtb.Rows[i]["HocKy"].ToString());
                    oKQHT_LopHocLaiInfo.IDNS_GiaoVien = int.Parse(dtb.Rows[i]["IDNS_GiaoVien"].ToString());
                    
                    oKQHT_LopHocLaiInfoList.Add(oKQHT_LopHocLaiInfo);
                }
            }
            return oKQHT_LopHocLaiInfoList;
        }
        
        public void ToDataRow(KQHT_LopHocLaiInfo pKQHT_LopHocLaiInfo, ref DataRow dr)
        {

            dr[pKQHT_LopHocLaiInfo.strKQHT_LopHocLaiID] = pKQHT_LopHocLaiInfo.KQHT_LopHocLaiID;
			dr[pKQHT_LopHocLaiInfo.strTenLop] = pKQHT_LopHocLaiInfo.TenLop;
			dr[pKQHT_LopHocLaiInfo.strIDDM_MonHoc] = pKQHT_LopHocLaiInfo.IDDM_MonHoc;
			dr[pKQHT_LopHocLaiInfo.strIDDM_NamHoc] = pKQHT_LopHocLaiInfo.IDDM_NamHoc;
			dr[pKQHT_LopHocLaiInfo.strHocKy] = pKQHT_LopHocLaiInfo.HocKy;
			dr[pKQHT_LopHocLaiInfo.strIDNS_GiaoVien] = pKQHT_LopHocLaiInfo.IDNS_GiaoVien;
        }
        
        public void ToInfo(ref KQHT_LopHocLaiInfo pKQHT_LopHocLaiInfo, DataRow dr)
        {

			pKQHT_LopHocLaiInfo.KQHT_LopHocLaiID = int.Parse(dr[pKQHT_LopHocLaiInfo.strKQHT_LopHocLaiID].ToString());
			pKQHT_LopHocLaiInfo.TenLop = dr[pKQHT_LopHocLaiInfo.strTenLop].ToString();
			pKQHT_LopHocLaiInfo.IDDM_MonHoc = int.Parse(dr[pKQHT_LopHocLaiInfo.strIDDM_MonHoc].ToString());
			pKQHT_LopHocLaiInfo.IDDM_NamHoc = int.Parse(dr[pKQHT_LopHocLaiInfo.strIDDM_NamHoc].ToString());
			pKQHT_LopHocLaiInfo.HocKy = int.Parse(dr[pKQHT_LopHocLaiInfo.strHocKy].ToString());
			pKQHT_LopHocLaiInfo.IDNS_GiaoVien = int.Parse(dr[pKQHT_LopHocLaiInfo.strIDNS_GiaoVien].ToString());
        }
    }
}
